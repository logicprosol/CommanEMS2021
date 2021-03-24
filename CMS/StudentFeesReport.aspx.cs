using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CMS
{
    public partial class StudentFeesReport : System.Web.UI.Page
    {
        public static int orgId=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["OrgId"]!=null)
            orgId = Convert.ToInt32(Session["OrgId"].ToString());
            //if (orgId == 0)
            //{
            //    Response.Redirect("~/CMSHome.aspx");
            //}
            //else
            {
                //orgId = Convert.ToInt32(Session["OrgId"].ToString());
                if (!IsPostBack)
                {
                    if(Session["Staff"].ToString()== "StudentFeesStatus")
                    {
                        Label2.Text = "Student Fees Status";
                        // lblStatus.Text = Session["class"].ToString();
                    lblStatus.Text = Session["CourseName"].ToString();
                    }
                    else
                    {
                        lblStatus.Text = Session["Course"].ToString();
                        Label2.Text = "Staff List";
                    }
                    BindGrid();
                    //export();
                    ExportGridToPDF();
                    
                }
            }
        }
        private void BindGrid()
        {
          SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

            {
                //string query = "with AllData as(SELECT  tblStudent.UserCode," +
                //    " (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,max(tblStudentFeesPaid.TotalAmount) Total, " +
                //    " sum(tblStudentFeesPaid.PaidAmount) Paid, max(tblStudentFeesPaid.TotalAmount)-sum(tblStudentFeesPaid.PaidAmount)Pending" +
                //    " FROM  tblStudent INNER JOIN tblStudentFeesPaid ON tblStudent.UserCode = tblStudentFeesPaid.StudentId" +
                //    " where PaidAmount<>0 and OrgId='" + orgId.ToString() + "' group by UserCode,FirstName,MiddleName,LastName" +
                //    " union all" +
                //    " SELECT  tblStudent.UserCode," +
                //    " (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,tblStudentBusFeesPaid.TotalAmount Total, " +
                //    " sum(tblStudentBusFeesPaid.PaidAmount) Paid, tblStudentBusFeesPaid.TotalAmount-sum(tblStudentBusFeesPaid.PaidAmount)Pending FROM" +
                //    "  tblStudent INNER JOIN tblStudentBusFeesPaid ON tblStudent.UserCode = tblStudentBusFeesPaid.StudentId" +
                //    " where PaidAmount<>0 and OrgId='" + orgId.ToString() + "' group by UserCode,FirstName,MiddleName,LastName,TotalAmount)" +
                //    " select  UserCode,StudentName 'Student Name',Sum(Total) 'Total Fees',Sum(Paid) 'Paid Fees',Sum(pending) 'Due Fees'" +
                //    " from AllData group by UserCode,StudentNAme order by UserCode";

                string query = Session["strquery1"].ToString();

                using (SqlCommand cmd = new SqlCommand(query))
                    //("SELECT  tblStudentFeesPaid.GroupReceiptNo ReceiptNo,tblStudent.UserCode, (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,   tblStudentFeesPaid.TotalAmount Total, tblStudentFeesPaid.PaidAmount Paid, tblStudentFeesPaid.PendingAmount Pending,Convert(Varchar(20), tblStudentFeesPaid.TransDate,105)TransDate FROM  tblStudent INNER JOIN tblStudentFeesPaid ON tblStudent.UserCode = tblStudentFeesPaid.StudentId where PaidAmount<>0 and OrgId='" + orgId.ToString() + "'"))
                    
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = cn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>alert('Record Not Found...!')</script>");
                            }
                        }
                    }
                }

            }
        }
        public void export()
        {
            string dt = System.DateTime.Now.ToString("MM-yyyy");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Session["Staff"].ToString() + "_" + dt + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw1 = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.BindGrid();

                GridView1.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                // GridView1.RenderControl(hw);
                GridView1.RenderControl(hw1);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ExportGridToPDF()
        {
            string dt = System.DateTime.Now.ToString("MM/yyyy");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + Session["Staff"].ToString() + "_" + dt + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
            ST.LoadTagStyle("body", "encoding", "Identity-H");
            
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
            htmlparser.Style = ST;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridView1.AllowPaging = true;
            GridView1.DataBind();
            
        }
    }
}
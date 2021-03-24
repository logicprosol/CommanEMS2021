using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class FeesReports : System.Web.UI.Page
    {
        public static int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgId"] != null)
            {
                orgId = Convert.ToInt32(Session["OrgId"].ToString());
            }
            else
            {
                Response.Redirect("~/CMSHome.aspx");
            }

            if (!IsPostBack)
            {
                BindGrid();
                //export();
                ExportGridToPDF();

            }
        }

        private void BindGrid()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

            {


                //("SELECT  tblStudentFeesPaid.GroupReceiptNo ReceiptNo,tblStudent.UserCode, (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,   tblStudentFeesPaid.TotalAmount Total, tblStudentFeesPaid.PaidAmount Paid, tblStudentFeesPaid.PendingAmount Pending,Convert(Varchar(20), tblStudentFeesPaid.TransDate,105)TransDate FROM  tblStudent INNER JOIN tblStudentFeesPaid ON tblStudent.UserCode = tblStudentFeesPaid.StudentId where PaidAmount<>0 and OrgId='" + orgId.ToString() + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand("sp_Fees_Pending");
                    cmd.Parameters.AddWithValue("@Action", "StudentFeesReport");
                    cmd.Parameters.AddWithValue("@OrgId", orgId);
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public void export()
        {
            string dt = System.DateTime.Now.ToString("MM-yyyy");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=StudentFeesReport" + dt + ".xls");
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
            Response.AddHeader("content-disposition", "attachment;filename=StudentFeesReport" + dt + ".pdf");
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
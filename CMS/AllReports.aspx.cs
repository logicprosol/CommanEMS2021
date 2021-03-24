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
using CMS.Forms.Admin;
using iTextSharp.text.pdf;



namespace CMS
{
    public partial class ResultFormat : System.Web.UI.Page
    {
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"].ToString());
            if (orgId.ToString() == null)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                orgId = Convert.ToInt32(Session["OrgId"].ToString());
                if (!IsPostBack)
                {
                    BindGrid();
                    //export();
                    //ExportPDF();
                    
                        ExportGridToPDF();
                    
                }
            }
        }

        private void BindGrid()
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

                {
                    using (SqlCommand cmd = new SqlCommand("SP_Common")) //new SqlCommand("SELECT  AdmissionID, OrgID, ApplicationDate, FeesCategory, FirstName, MiddleName, LastName, Gender, BirthDate, BirthPlace, Address1, Address2, Taluka, Mobile, EMail,  Nationality, BloodGroup, Religion, GuardianName, Relation, GuardianMobile, GuardianEMail, ParentName, MotherName, ParentMobile, ParentEMail, LastInstitute,   Username, Password, Status, MotherTongue FROM  tblAdmissionDetails where OrgID='" + orgId.ToString() + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Action", "AdmmisionReports");
                            cmd.Parameters.AddWithValue("@OrgId", orgId.ToString());
                            //cmd.Parameters.AddWithValue("@CourseId", Session["CourseId"].ToString());
                            //cmd.Parameters.AddWithValue("@BranchId", Session["BranchId"].ToString());
                            //cmd.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                            cmd.Parameters.AddWithValue("@AcademicYear", Session["YearId"].ToString());
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                if (dt.Rows.Count > 0)
                                {
                                    GridView1.HeaderRow.Style.Add("width", "15%");
                                    GridView1.HeaderRow.Style.Add("font-size", "10px");
                                    GridView1.Style.Add("text-decoration", "none");
                                    GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                                    GridView1.Style.Add("font-size", "8px");
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }
        public void export()
        {
            string dt=System.DateTime.Now.ToString("MM/yyyy");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=StudentAdmissionReport"+dt+".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

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

                GridView1.RenderControl(hw);

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

        //public void ExportPDF()
        //{
        //    string dt = System.DateTime.Now.ToString("MM/yyyy");
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=StudentAdmissionReport" + dt + ".pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.AllowPaging = false;
        //    GridView1.DataBind();
        //    GridView1.RenderControl(hw);
        //    GridView1.HeaderRow.Style.Add("width", "15%");
        //    GridView1.HeaderRow.Style.Add("font-size", "10px");
        //    GridView1.Style.Add("text-decoration", "none");
        //    GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //    GridView1.Style.Add("font-size", "8px");
        //    StringReader sr = new StringReader(hw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);
        //    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //}

        private void ExportGridToPDF()
        {
            
                string dt = System.DateTime.Now.ToString("MM/yyyy");
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=StudentAdmissionReport" + dt + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                Panel1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
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

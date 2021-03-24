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
using EntityWebApp.Library;
using BusinessAccessLayer.Library;

namespace CMS
{
    public partial class BookReport : System.Web.UI.Page

    {
        public static int orgId=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgId"].ToString());
                //if (orgId== 0)
                //{
                //    Response.Redirect("~/CMSHome.aspx");
                //}
                //else
                {

                   
                    if (!IsPostBack)
                    {
                        BindGrid();
                        //export();
                        ExportGridToPDF();
                    }
                }

            }
            catch(Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

   
        private void BindGrid()
        {
            BL_AddBook objBL = new BL_AddBook();
            EWA_AddBook objEWA = new EWA_AddBook();

            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

            DataSet ds = objBL.GetBook_BL(objEWA);

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Record Not Found...!')</script>");
            }

           
        }
    

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion




        public void export()
        {
            string dt = System.DateTime.Now.ToString("MM-yyyy");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BookReport" + dt + ".xls");
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
            Response.AddHeader("content-disposition", "attachment;filename=BookReport" + dt + ".pdf");
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
  
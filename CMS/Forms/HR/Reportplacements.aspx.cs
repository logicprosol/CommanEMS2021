using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using System.Configuration;
using System.IO;
using iTextSharp.text;

namespace CMS.Forms.HR
{
    public partial class Reportplacements : System.Web.UI.Page
    {
        database db = new database();
        string strCon = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        StringBuilder str = new StringBuilder();
        BL_Dashbord objBL = new BL_Dashbord();
        EWA_Dashbord objEWA = new EWA_Dashbord();
        int OrgID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                OrgID = Convert.ToInt32(Session["OrgId"]);


                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                else
                {
                    if (Page.IsPostBack == false)
                    {
                        //BindChart();
                        //BindPaiChart(); 
                        objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                        grdStudent.DataSource = null;
                        grdStudent.DataBind();
                        lblplaced.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where pr.OrgId='" + objEWA.OrgId.ToString() + "' and LTRIM(RTRIM(pr.Status))='" + "Offered & Joined" + "'");
                        LblOffered.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where pr.OrgId='" + objEWA.OrgId.ToString() + "' and LTRIM(RTRIM(pr.Status))='" + "Offered" + "'");
                        lblUnplaced.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where pr.OrgId='" + objEWA.OrgId.ToString() + "' and LTRIM(RTRIM(pr.Status))='" + "UnPlaced" + "'");
                    }
                }
            }
            catch (Exception ex) {
                //Response.Redirect("~/CMSHome.aspx");
            }
        }

        protected void ddlSearchStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                database db = new database();
                DataTable dt = new DataTable();
                //string sql= "select pr.UserCode,pr.FirstName As StudentName,cr.CourseName,br.BranchName,pr.Mobile,pr.pemail as MailId,pr.Company_Name,pr.Company_Address,pr.Position from Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode INNER JOIN tblCourse cr ON st.CourseId = cr.CourseId INNER JOIN tblBranch br ON st.BranchId = br.BranchId where pr.Status = '"+ ddlSearchStudent.SelectedValue.ToString() +"' And pr.OrgId = '"+ Convert.ToInt32(Session["OrgId"]) +"'";
                string sql = "select pr.FirstName As Name,pr.Mobile,pr.pemail as MailId,pr.Company_Name AS Company,pr.Company_Address as Address,pr.Position " +
                    "from Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode " +
                    "where LTRIM(RTRIM(pr.Status)) = '" + ddlSearchStudent.SelectedValue.ToString() + "' And pr.OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "'";
                dt = db.DisplaygridView(sql);

                grdStudent.DataSource = dt;
                grdStudent.DataBind();
            }
            catch (Exception ex) {
               // Response.Redirect("~/CMSHome.aspx");
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        private void ExportGridToPDF()
        {
            string dt = System.DateTime.Now.ToString("MM/yyyy");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=StudentPlacementReport" + dt + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            PanelStudent.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grdStudent.AllowPaging = true;
            grdStudent.DataBind();
        }
    }
}
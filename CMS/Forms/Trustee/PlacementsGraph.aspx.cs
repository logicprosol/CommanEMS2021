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

namespace CMS.Forms.Trustee
{
    public partial class PlacementsGraph : System.Web.UI.Page
    {
        public static int orgId=0;
        database db = new database();
       
        protected void Page_Load(object sender, EventArgs e)
        {
             orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }


            if (!IsPostBack)
            {
                grdStudent.DataSource = null;
                grdStudent.DataBind();
                string query1 = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
                DataTable dt = GetData(query1);
                ddlOrganization.DataSource = dt;
                ddlOrganization.DataTextField = "OrgName";
                ddlOrganization.DataValueField = "OrganizationId";
                ddlOrganization.DataBind();
                ddlOrganization.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", ""));

                lblplaced.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode  where  LTRIM(RTRIM(pr.Status))='" + "Offered & Joined" + "'");
                LblOffered.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where LTRIM(RTRIM(pr.Status))='" + "Offered" + "'");
                lblUnplaced.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode  where  LTRIM(RTRIM(pr.Status))='" + "UnPlaced" + "'");

            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                database db = new database();
                DataTable dt = new DataTable();
                //string sql= "select pr.UserCode,pr.FirstName As StudentName,cr.CourseName,br.BranchName,pr.Mobile,pr.pemail as MailId,pr.Company_Name,pr.Company_Address,pr.Position from Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode INNER JOIN tblCourse cr ON st.CourseId = cr.CourseId INNER JOIN tblBranch br ON st.BranchId = br.BranchId where pr.Status = '"+ ddlSearchStudent.SelectedValue.ToString() +"' And pr.OrgId = '"+ Convert.ToInt32(Session["OrgId"]) +"'";
                string sql = "select pr.FirstName As Name,pr.Mobile,pr.pemail as MailId,pr.Company_Name AS Company,pr.Company_Address as Address,pr.Position from Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where LTRIM(RTRIM(pr.Status)) = '" + ddlSearchStudent.SelectedValue.ToString().Trim() + "' And pr.OrgId = '" + ddlOrganization.SelectedValue + "'";
                dt = db.DisplaygridView(sql);

                grdStudent.DataSource = dt;
                grdStudent.DataBind();
                lblplaced.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where pr.OrgId='" + ddlOrganization.SelectedValue + "' and LTRIM(RTRIM(pr.Status))='" + "Offered & Joined" + "'");
                LblOffered.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where pr.OrgId='" + ddlOrganization.SelectedValue + "' and LTRIM(RTRIM(pr.Status))='" + "Offered" + "'");
                lblUnplaced.Text = db.getDbstatus_Value("SELECT isnull(COUNT(pr.UserCode),0) FROM Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where pr.OrgId='" + ddlOrganization.SelectedValue + "' and LTRIM(RTRIM(pr.Status))='" + "UnPlaced" + "'");


            }
            catch (Exception ex) {
                //Response.Redirect("~/CMSHome.aspx");
            }
        }

        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection constr1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            using (SqlConnection con = (constr1))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
        protected void ddlSearchStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                database db = new database();
                DataTable dt = new DataTable();
                //string sql= "select pr.UserCode,pr.FirstName As StudentName,cr.CourseName,br.BranchName,pr.Mobile,pr.pemail as MailId,pr.Company_Name,pr.Company_Address,pr.Position from Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode INNER JOIN tblCourse cr ON st.CourseId = cr.CourseId INNER JOIN tblBranch br ON st.BranchId = br.BranchId where pr.Status = '"+ ddlSearchStudent.SelectedValue.ToString() +"' And pr.OrgId = '"+ Convert.ToInt32(Session["OrgId"]) +"'";
                string sql = "select pr.FirstName As Name,pr.Mobile,pr.pemail as MailId,pr.Company_Name AS Company,pr.Company_Address as Address,pr.Position from Placement_Registration pr INNER JOIN tblStudent st ON st.UserCode = pr.UserCode where LTRIM(RTRIM(pr.Status)) = '" + ddlSearchStudent.SelectedValue.ToString() + "' And pr.OrgId = '" + ddlOrganization.SelectedValue + "'";
                dt = db.DisplaygridView(sql);

                grdStudent.DataSource = dt;
                grdStudent.DataBind();
            }
            catch (Exception ex) {
                //Response.Redirect("~/CMSHome.aspx");
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
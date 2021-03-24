using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
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
    public partial class StudentAttendance : System.Web.UI.Page
    {
        public static int orgId=0;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgId"]);
                txtSelectDate_CalendarExtender.EndDate = DateTime.Today;
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    string query = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
                    DataTable dt = GetData(query);
                    ddlorganization.DataSource = dt;
                    ddlorganization.DataTextField = "OrgName";
                    ddlorganization.DataValueField = "OrganizationId";
                    ddlorganization.DataBind();
                    ddlorganization.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", ""));
                    BindCourse();
                    grdStudentAtten.DataSource = null;
                    grdStudentAtten.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {

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

                }
            }
            catch (Exception ex) { }
            return dt;
        }

        #region

        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        #region[Bind Branch]

        private void BindBranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlBranch.DataSource = ds;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataBind();
                }
                else
                    ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion 

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

        #region[Bind Game]

        private void BindClass()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                if (!objEWA.BranchId.Equals("Select"))
                {
                    DataSet ds = objBL.BindClass_BL(objEWA);

                    ddlClass.DataSource = ds;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ddlClass.DataTextField = "ClassName";
                        ddlClass.DataValueField = "ClassId";
                        ddlClass.DataBind();
                    }
                    else
                        ddlClass.Items.Clear();
                }
                else
                    ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('"+msg+"')", true);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = ddlorganization.SelectedValue;//Session["OrgId"].ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.date = txtDate.Text; // Convert.ToDateTime((Convert.ToDateTime(txtDate.Text.ToString()).ToShortDateString())).ToString("dd/MM/yyyy");

                DataSet ds = objBL.BindStudentAttendance_BL(objEWA);

                if(ds.Tables[0].Rows.Count > 0)
                {
                    grdStudentAtten.DataSource = ds;
                    grdStudentAtten.DataBind();
                    //grdStudentAtten.ControlStyle.Width  = 90;
                    //grdStudentAtten.CellPadding = 20;
                }
                else
                {
                    grdStudentAtten.DataSource = ds;
                    grdStudentAtten.DataBind();
                    GeneralErr("No Record Present...!");
                }
                
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
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
            grdStudentAtten.AllowPaging = true;
            grdStudentAtten.DataBind();
        }

    }
}

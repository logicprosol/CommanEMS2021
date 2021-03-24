using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer.Admin;
using EntityWebApp;
using BusinessAccessLayer;

namespace CMS.Forms.Admin
{
    public partial class PreviousYearPendingFeeReport : System.Web.UI.Page
    {

        #region[Objects]
        public static int orgId;
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        EWA_Common objEWA = new EWA_Common();
        BL_Common objBL = new BL_Common();
        int OrgID = 0;
        private DataView dvBranch = null;
        private DataView dvClass = null;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                orgId = Convert.ToInt32(Session["OrgId"]);
                if (!IsPostBack)
                {
                    BindCourse();
                }
                SqlCommand cmd1 = new SqlCommand("select Logo,OrgName from tblOrganization   where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'", cn);
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);
                string Photo = ds1.Tables[0].Rows[0]["Logo"].ToString();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }


        private void BindCourse()
        {
            try
            {

                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];

                ddlCourse.Items.Clear();
                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));

                DDLAcademicYear.Items.Clear();
                DDLAcademicYear.DataSource = ds.Tables[7];
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
                DDLAcademicYear.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrdFeesPaidDetails.Visible = false;
                BindBranch();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void BindBranch()
        {
            try
            {
                dvBranch = new DataView(ViewState["dvBranch"] as DataTable);
                dvBranch.RowFilter = "[CourseId] = " + ddlCourse.SelectedValue + "";
                ddlBranch.DataSource = dvBranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));
                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        private void BindClass()
        {
            try
            {
                dvClass = new DataView(ViewState["dvClass"] as DataTable);
                dvClass.RowFilter = "[BranchId] = " + ddlBranch.SelectedValue + "";
                ddlClass.DataSource = dvClass;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            lblstatus.Text = ddlCourse.SelectedItem.Text + '-' + ddlBranch.SelectedItem.Text + '-' + ddlClass.SelectedItem.Text + '(' + DDLAcademicYear.SelectedItem.Text + ')';
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_GetPreviousYearFeesData11";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@CourseId", ddlCourse.SelectedValue);
            cmd.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedValue);
            cmd.Parameters.AddWithValue("@ClassId", ddlClass.SelectedValue);
            cmd.Parameters.AddWithValue("@AcademicYear", DDLAcademicYear.SelectedValue);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ToString() != null)
                {
                    GrdFeesPaidDetails.DataSource = ds;
                    GrdFeesPaidDetails.DataBind();
                    GrdFeesPaidDetails.Visible = true;
                }
            }
            else
            {
                GrdFeesPaidDetails.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Record Not Found ..!!');", true);
            }

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            ddlClass.ClearSelection();
            DDLAcademicYear.ClearSelection();
            GrdFeesPaidDetails.Visible = false;
            lblstatus.Text = "";
            lblstatus.Visible = false;
        }
    }
}
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

namespace CMS.Forms.Admin
{
    public partial class StudentAdmissionReport : System.Web.UI.Page
    {
        public static int orgId;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    BindAcademicYear();
                    BindCourse();
                    BindFeesCategory();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #region

        private void BindAcademicYear()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindAcademicYear_BL(objEWA);

                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "AcademicYear";
                ddlAcademicYear.DataValueField = "AcademicYearId";
                ddlAcademicYear.DataBind();
                ddlAcademicYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

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

                ddlBranch.Items.Clear();
                ddlClass.Items.Clear();
                ddlBranch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
                ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
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

                
                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

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

        #region FeesCategory

        private void BindFeesCategory()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindFeesCategory_BL(objEWA);

                ddlFeesCategory.DataSource = ds;
                ddlFeesCategory.DataTextField = "FeesCategoryName";
                ddlFeesCategory.DataValueField = "FeesCategoryId";
                ddlFeesCategory.DataBind();
                ddlFeesCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //private void BindGrid()
        //{
            
        //    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //    {
        //        using (SqlCommand cmd = new SqlCommand("SP_Common")) //new SqlCommand("SELECT  AdmissionID, OrgID, ApplicationDate, FeesCategory, FirstName, MiddleName, LastName, Gender, BirthDate, BirthPlace, Address1, Address2, Taluka, Mobile, EMail,  Nationality, BloodGroup, Religion, GuardianName, Relation, GuardianMobile, GuardianEMail, ParentName, MotherName, ParentMobile, ParentEMail, LastInstitute,   Username, Password, Status, MotherTongue FROM  tblAdmissionDetails where OrgID='" + orgId.ToString() + "'"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = cn;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@Action", "GetAdmin_AdmmisionReports");
        //                cmd.Parameters.AddWithValue("@OrgId", orgId.ToString());
        //                cmd.Parameters.AddWithValue("@CourseId", ddlCourse.SelectedValue.ToString());
        //                cmd.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedValue.ToString());
        //                cmd.Parameters.AddWithValue("@ClassId", ddlClass.SelectedValue.ToString());
        //                cmd.Parameters.AddWithValue("@AcademicYear", ddlAcademicYear.SelectedValue.ToString());
        //                sda.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    sda.Fill(dt);
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        Panel1.Visible = true;
        //                        btnExport.Visible = true;
        //                        GridView1.DataSource = dt;
        //                        GridView1.DataBind();
        //                    }
        //                    else
        //                    {
        //                       GridView1.DataSource = null;
        //                        GridView1.DataBind();
        //                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record not found !!!')", true);
        //                    }

        //                 }
        //            }
        //        }

        //    }
        //}

        private void BindGrid1()
        {
            try
            {
                string strquery = "SELECT UserCode, FirstName +' ' + MiddleName + ' ' + LastName AS StudentName, CourseName as Course,BranchName as Branch,TCL.ClassName as Class,TFC.FeesCategoryName as FeesCategory,AY.AcademicYear FROM tblStudent TS LEFT JOIN tblCourse TC ON TC.CourseId = TS.CourseId LEFT JOIN tblBranch TB ON TB.BranchId = TS.BranchId LEFT OUTER JOIN tblClass TCL ON TCL.ClassId = TS.ClassId LEFT JOIN tblAcademicYear AY ON AY.AcademicYearId = TS.AcademicYearId LEFT JOIN tblFeesCategory TFC ON TS.FeesCategory = TFC.FeesCategoryId Where TS.OrgId ='"+ Session["OrgId"].ToString() + "'";
                
                if(ddlCourse.SelectedValue != "0")
                {
                    strquery = strquery + " And TC.CourseId = '" + ddlCourse.SelectedValue + "'";
                }

                if(ddlBranch.SelectedValue != "0")
                {
                    strquery = strquery + " And TB.BranchId = '" + ddlBranch.SelectedValue + "'";
                }

                if(ddlClass.SelectedValue != "0")
                {
                    strquery = strquery + " And TCL.ClassId = '" + ddlClass.SelectedValue + "'";
                }

                if(ddlAcademicYear.SelectedValue != "0")
                {
                    strquery = strquery + " And AY.AcademicYearId = '" + ddlAcademicYear.SelectedValue + "'";
                }

                if(ddlFeesCategory.SelectedValue != "0")
                {
                    strquery = strquery + " And TFC.FeesCategoryId = '" + ddlFeesCategory.SelectedValue + "'";
                }

                strquery = strquery + " order by UserCode asc";

                Session["strquery"] = strquery;

                database db = new database();
                DataTable dt= db.DisplaygridView(strquery);

                if (dt.Rows.Count > 0)
                {
                    Panel1.Visible = true;
                    btnExport.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record not found !!!')", true);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void GeneralErr(String msg)
        {
            //Response.Write("<script>alert('" + msg + "')</script>");
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //BindGrid();
            BindGrid1();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //ExportGridToPDF();
            if (GridView1.Rows.Count > 0)
            {
                Session["CourseId"] = ddlCourse.SelectedValue.ToString();
                Session["BranchId"] = ddlBranch.SelectedValue.ToString();
                Session["ClassId"] = ddlClass.SelectedValue.ToString();
                Session["YearId"] = ddlAcademicYear.SelectedValue.ToString();
                Response.Redirect("../../AllReports1.aspx");
            }
        }
        
    }
}
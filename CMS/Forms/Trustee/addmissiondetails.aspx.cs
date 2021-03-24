using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Trustee
{
    public partial class addmissiondetails : System.Web.UI.Page
    {
        public static int orgId=0;
        protected void Page_Load(object sender, EventArgs e)
        {
             orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
            if (!IsPostBack)
            {
                try
                {
                    BindOrganization();
                }
                catch(Exception ex)
                {
                    
                    //Response.Redirect("~/CMSHome.aspx");
                }
            }
            
        }


        public void BindOrganization()
        {
            string query = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
            DataTable dt = GetData(query);
            ddlOrgnization.DataSource = dt;
            ddlOrgnization.DataTextField = "OrgName";
            ddlOrgnization.DataValueField = "OrganizationId";
            ddlOrgnization.DataBind();
            ddlOrgnization.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void ddlOrgnization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["OrgId"] = ddlOrgnization.SelectedValue.ToString();
                BindAcademicYear();
                //BindCourse();
            }
            catch (Exception ex) { }
        }

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



        #region

        //private void BindCourse()
        //{
        //    try
        //    {
        //        EWA_Common objEWA = new EWA_Common();
        //        BL_Common objBL = new BL_Common();
        //        objEWA.OrgId = Session["OrgId"].ToString();
        //        DataSet ds = objBL.BindCourses_BL(objEWA);

        //        ddlCourse.DataSource = ds;
        //        ddlCourse.DataTextField = "CourseName";
        //        ddlCourse.DataValueField = "CourseId";
        //        ddlCourse.DataBind();
        //        ddlCourse.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindBranch();
        //}

        #region[Bind Branch]

        //private void BindBranch()
        //{
        //    try
        //    {
        //        EWA_Common objEWA = new EWA_Common();
        //        DL_Common objDL = new DL_Common();
        //        objEWA.CourseId = ddlCourse.SelectedValue.ToString();

        //        DataSet ds = objDL.BindBranch_DL(objEWA);
        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            ddlBranch.DataSource = ds;
        //            ddlBranch.DataTextField = "BranchName";
        //            ddlBranch.DataValueField = "BranchId";
        //            ddlBranch.DataBind();
        //        }
        //        else
        //            ddlBranch.Items.Clear();
        //        ddlBranch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion 

        //protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindClass();
        //}

        #region[Bind Game]

        //private void BindClass()
        //{
        //    try
        //    {
        //        EWA_Common objEWA = new EWA_Common();
        //        BL_Common objBL = new BL_Common();
        //        objEWA.BranchId = ddlBranch.SelectedValue.ToString();
        //        if (!objEWA.BranchId.Equals("Select"))
        //        {
        //            DataSet ds = objBL.BindClass_BL(objEWA);

        //            ddlClass.DataSource = ds;
        //            if (ds.Tables[0].Rows.Count != 0)
        //            {
        //                ddlClass.DataTextField = "ClassName";
        //                ddlClass.DataValueField = "ClassId";
        //                ddlClass.DataBind();
        //            }
        //            else
        //                ddlClass.Items.Clear();
        //        }
        //        else
        //            ddlClass.Items.Clear();
        //        ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        protected void GeneralErr(String msg)
        {
            Response.Write("<script>alert('" + msg + "')</script>");
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }


        

        //protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //string query = string.Format("select AdmissionYear, count(ApplicationId) from tblAdmissionDetails where OrgID = '{0}'  and  Status='Admission Completed' group by AdmissionYear", ddlCountries.SelectedItem.Value);
        //    //string query = string.Format("select ay.AcademicYear, count(st.StudentId) from tblStudent st,tblAcademicYear ay  where st.OrgId = '{0}' and st.AcademicYearId = ay.AcademicYearId  group by AcademicYear", ddlCountries.SelectedItem.Value);
        //    string query = string.Format("select DATEPART(year, st.AdmissionDate) AcademicYear, count(st.StudentId)NoOfStudents from tblStudent st,tblAcademicYear ay  where st.OrgId = '{0}' and st.AcademicYearId = ay.AcademicYearId  group by DATEPART(year, st.AdmissionDate)", ddlCountries.SelectedItem.Value);
        //    DataTable dt = GetData(query);
        //    if (dt.Rows.Count > 0)
        //    {
        //        string[] x = new string[dt.Rows.Count];
        //    decimal[] y = new decimal[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        x[i] = dt.Rows[i][0].ToString();
        //        y[i] = Convert.ToInt32(dt.Rows[i][1]);

        //    }
        //    //   BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
        //    BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y, BarColor = "#3CAEE6"});/*"#82191D" */
        //    BarChart1.CategoriesAxis = string.Join(",", x);
        //    BarChart1.ChartTitle = string.Format("Graphical Admission Report"); 
        //    // + ddlCountries.SelectedItem.ToString() + "", ddlCountries.SelectedItem.Value);

        //    if (x.Length > 3)
        //    {
        //        BarChart1.ChartWidth = (x.Length * 100).ToString();
        //    }
        //    BarChart1.Visible = ddlCountries.SelectedItem.Value != "";
        //    }
        //    else
        //    {
        //        msgBox.ShowMessage("No record found", "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //    }
        //}


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

        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
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
                        cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"].ToString());
                        //cmd.Parameters.AddWithValue("@CourseId", ddlCourse.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@BranchId", ddlBranch.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@ClassId", ddlClass.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@AcademicYear", ddlAcademicYear.SelectedValue.ToString());
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
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

                            //GridView1.HeaderRow.Style.Add("width", "15%");
                            //GridView1.HeaderRow.Style.Add("font-size", "10px");
                            //GridView1.Style.Add("text-decoration", "none");
                            //GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                            //GridView1.Style.Add("font-size", "8px");
                        }
                    }
                }

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
         {
            //Session["CourseId"] = ddlCourse.SelectedValue.ToString();
            //Session["BranchId"] = ddlBranch.SelectedValue.ToString();
            //Session["ClassId"] = ddlClass.SelectedValue.ToString();
            Session["YearId"] = ddlAcademicYear.SelectedValue.ToString();
            Response.Redirect("../../AllReports.aspx");
        }
    }
}
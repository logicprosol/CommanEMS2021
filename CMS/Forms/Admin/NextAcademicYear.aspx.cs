using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using EntityWebApp;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using CrystalDecisions.Shared;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System.Data.SqlClient;

namespace CMS.Forms.Admin
{
    public partial class NextAcademicYear : System.Web.UI.Page
    {
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        int orgId = 0;
        EWA_Common objEWA = new EWA_Common();
        BL_Common objBL = new BL_Common();
        int indexOfColumn = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }

            if (!IsPostBack)
            {

               BindCourse();
                BindCourseNextYear();
                /*BindOragnization()*/;
                DDLAcademicYear.SelectedIndex = 0;
                //DDLAcademicYear.SelectedIndex = drpacedemicyear1.Items.Count - 1;

                drpacedemicyear1.SelectedIndex = 0;
                //drpacedemicyear1.SelectedIndex = drpacedemicyear1.Items.Count - 1;

            }

        }

        private DataView dvBranch = null;
        private DataView dvClass = null;
        private DataView dvDivision = null;
        private DataView dvStudentData = null;

        private DataView dvdrpBranch = null;
        private DataView dvdrpClass = null;
        private DataView dvdrpDivision = null;
        private DataView dvdrpStudentData = null;


        // Added by Ashwini 25-sep-2020
        private DataView DVCategory = null;
        private DataView DVFees = null;
        private DataView DVPendingAmount = null;
        //Added by Ashwini 9-Oct-2020---
        private DataView DVCourse = null;
        
        //
        #region[Bind Course]

        private void BindCourse()
        {
            try
            {

                objEWA.OrgId = Session["OrgId"].ToString();
               // objEWA.OrgId = ddlOrg.SelectedValue;
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];
                ViewState["dvDivision"] = ds.Tables[4];
                ViewState["dvStudentData"] = ds.Tables[5];
                ViewState["DVCourse"]= ds.Tables[0];
                ddlCourse.Items.Clear();
                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));

            

                //ddlCasteCategory.DataSource = ds.Tables[1];
                //ddlCasteCategory.DataTextField = "CasteCategoryName";
                //ddlCasteCategory.DataValueField = "CasteCategoryId";
                //ddlCasteCategory.DataBind();
                ddlCasteCategory.Items.Insert(0, new ListItem("---Select---", "0"));

                DDLAcademicYear.Items.Clear();
                DDLAcademicYear.DataSource = ds.Tables[7];
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
                DDLAcademicYear.Items.Insert(0, new ListItem("---Select---", "0"));


                drpacedemicyear1.Items.Clear();
                drpacedemicyear1.DataSource = ds.Tables[7];
                drpacedemicyear1.DataTextField = "AcademicYear";
                drpacedemicyear1.DataValueField = "AcademicYearId";
                drpacedemicyear1.DataBind();
                drpacedemicyear1.Items.Insert(0, new ListItem("---Select---", "0"));



                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));


                drpbranch.Items.Clear();
                drpbranch.Items.Insert(0, new ListItem("---Select---", "0"));

                drpclass.Items.Clear();
                drpclass.Items.Insert(0, new ListItem("---Select---", "0"));



                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet dsRoute = objBL.Bind_Route(objEWA);
                DDLBusRoute.DataSource = dsRoute;
                DDLBusRoute.DataTextField = "Route";
                DDLBusRoute.DataValueField = "RouteId";
                DDLBusRoute.DataBind();
                DDLBusRoute.Items.Insert(0, new ListItem("---Select---", "0"));

                if (IsPostBack)
                {
                    GrdStudent.DataSource = ds.Tables[5];
                    GrdStudent.DataBind();
                    gvPrint.DataSource = ds.Tables[5];
                    gvPrint.DataBind();
                    ViewState["PrintData"] = ds.Tables[5];
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void BindStudent()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);


                ViewState["dvStudentData"] = ds.Tables[5];

                GrdStudent.DataSource = ds.Tables[5];
                GrdStudent.DataBind();
                gvPrint.DataSource = ds.Tables[5];
                gvPrint.DataBind();
                ViewState["PrintData"] = ds.Tables[5];


            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Course Changed
        #region[Course Changed]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlCasteCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData(); printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void GetStudentData()
        {
            string strQuery = null;
            dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);

            ///////////////////////////////////////////////////////
            if (ddlCourse.SelectedValue != "0")
            {
                if (ddlCasteCategory.SelectedValue == "0" && txtStudName.Text.Length == 0 && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (ddlCasteCategory.SelectedValue != "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (txtStudName.Text.Length != 0)
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [CourseId] = " + ddlCourse.SelectedValue + "";
                }


                if (ddlCasteCategory.SelectedValue != "0" && txtStudName.Text.Length != 0)
                {
                    strQuery = "[CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "' And [StudentName] like '"
                    + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (ddlCasteCategory.SelectedValue != "0" && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "' And [CourseId] = " + ddlCourse.SelectedValue + " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
                if (txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue +
                    " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
                if (ddlCasteCategory.SelectedValue != "0" && txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "' And [StudentName] like '"
                    + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            else if (ddlCasteCategory.SelectedValue != "0")
            {
                if (ddlCourse.SelectedValue == "0" && txtStudName.Text.Length == 0 && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (txtStudName.Text.Length != 0)
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CasteCategoryId] = '" + ddlCasteCategory.SelectedItem.Text + "' And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            else if (txtStudName.Text.Length != 0)
            {
                if (ddlCourse.SelectedValue == "0" && ddlCasteCategory.SelectedValue == "0" && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%'";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [StudentName] like '" + txtStudName.Text + "%'";
                }
            }
            else if (DDLAcademicYear.SelectedValue != "0")
            {
                if (ddlCourse.SelectedValue == "0" && ddlCasteCategory.SelectedValue == "0" && txtStudName.Text.Length == 0)
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            /////////////////////////////////////////////////////            
            if (ddlBranch.SelectedValue != "0")
            {
                strQuery = strQuery + " And [BranchId] = " + ddlBranch.SelectedValue + "";
            }
            if (ddlClass.SelectedValue != "0")
            {
                strQuery = strQuery + " And [ClassId] = " + ddlClass.SelectedValue + "";
            }

            dvStudentData.RowFilter = strQuery;
            GrdStudent.DataSource = dvStudentData;
            GrdStudent.DataBind();
            ViewState["PrintData"] =
            ViewState["PrintableData"] = strQuery;

         
            //ViewState["PrintableData"] = dvStudentData;
        }

        //Bind Branch
        #region[Bind Branch]

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



                GetStudentData();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Changed
        #region[Branch Changed]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Class
        #region[Bind Class]

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







                GetStudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Selected Class
        #region[Class Changed]

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //BindDivision();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Division
        #region[Bind Division]

        private void BindDivision()
        {
            try
            {
                dvDivision = new DataView(ViewState["dvDivision"] as DataTable);
                dvDivision.RowFilter = "[ClassId] = " + ddlClass.SelectedValue + "";
                //ddlDivision.DataSource = dvDivision;
                //ddlDivision.DataTextField = "DivisionName";
                //ddlDivision.DataValueField = "DivisionId";
                //ddlDivision.DataBind();
                //ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));
                GetStudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Division Changing
        #region[Division Changing]

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //StudentLinkButtonClick

        #region StudentLinkButtonClick

        protected void lnkBtnStudentName_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                // throw;
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion CreateAccouncement Code


        protected void DDLAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData();
                printabledata();
              
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void txtStudName_TextChanged(object sender, EventArgs e)
        {
            GetStudentData(); printabledata();
        }
        public void printabledata()
        {
            DataTable dt = new DataTable();
            if (ViewState["PrintableData"] != null)
            {
                dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
                dvStudentData.RowFilter = ViewState["PrintableData"].ToString();
                dt = dvStudentData.ToTable();
            }
            else
            {
                dt = ViewState["PrintData"] as DataTable;
            }


            DataSet ReportData = new DataSet();
            ReportData.Tables.Add(dt);
            HttpContext.Current.Session.Remove("ReportData");
            HttpContext.Current.Session.Add("ReportData", ReportData);
            gvPrint.DataSource = dt;
            gvPrint.DataBind();
        }
        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (ViewState["PrintableData"] != null)
            {
                dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
                dvStudentData.RowFilter = ViewState["PrintableData"].ToString();
                dt = dvStudentData.ToTable();
            }
            else
            {
                dt = ViewState["PrintData"] as DataTable;
            }


            DataSet ReportData = new DataSet();
            ReportData.Tables.Add(dt);
            HttpContext.Current.Session.Remove("ReportData");
            HttpContext.Current.Session.Add("ReportData", ReportData);
            gvPrint.DataSource = dt;
            gvPrint.DataBind();
            string url = "/Forms/Reports/ReportViewer.aspx?ReportName=crStudentList";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);
        }

        protected void gvPrint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            // e.Row.Cells[6].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;

        }

        protected void BtnUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                GRDBusDetails.Visible = false;
                if (drpcourse.SelectedIndex == 0)
                {
                    Shwmsg.Text = "Please Select Course";
                    Shwmsg.ForeColor = System.Drawing.Color.Red;
                    Shwmsg.Visible = true;
                    return;
                }
                if (drpbranch.SelectedIndex == 0)
                {
                    Shwmsg.Text = "Please Select Branch";
                    Shwmsg.ForeColor = System.Drawing.Color.Red;
                    Shwmsg.Visible = true;
                    return;
                }
                if (drpclass.SelectedIndex == 0)
                {
                    Shwmsg.Text = "Please Select Class";
                    Shwmsg.ForeColor = System.Drawing.Color.Red;
                    Shwmsg.Visible = true;
                    return;
                }

                if (drpacedemicyear1.SelectedIndex == 0)
                {
                    Shwmsg.Text = "Please Select Academic Year";
                    Shwmsg.ForeColor = System.Drawing.Color.Red;
                    Shwmsg.Visible = true;
                    return;
                }
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                       
                        UpgradeAcademicyear("UpgradeYear");
                        // Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                    }
                }
            }
            catch (Exception exp)
            {
                //throw exp;
            }

        }
        private void UpgradeAcademicyear(string strAction)
        {

            try
            {
                EWA_Admission objEWA = new EWA_Admission();
                BL_Admission objBAL = new BL_Admission();
                int Userid = Convert.ToInt32(Session["UserCode"]);
                // Get College ID And Name From Session

                // Panel 1
                var count = GrdStudent.Rows.Count;
                string[] AdmissionID = new string[count];
                int i = 0;
                int oldOrgId = Convert.ToInt32(Session["OrgId"].ToString());
              //  int orgid = Convert.ToInt32(ddlOrg.SelectedValue);
                foreach (GridViewRow gvrow in GrdStudent.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    // string xya
                    if (chk != null && chk.Checked)
                    {
                        Label addmissionId = (Label)gvrow.FindControl("lbladdmissionid");
                        Label UserCode = (Label)gvrow.FindControl("lblUserCode");
                        string _drpcourse = drpcourse.SelectedValue;
                        string _drpbranch = drpbranch.SelectedValue;
                        string _drpclass = drpclass.SelectedValue;
                        //float fees = db.getDb_Value("SELECT         isnull(TotalAmount-sum(paidamount),0) AS PendingAmount FROM            tblStudentFeesPaid where  StudentId='" + UserCode.Text + "' group by TotalAmount");

                        float castcatergoryid = db.getDb_Value(" select feescategory FROM  tbladmissiondetails WHERE   admissionid='" + addmissionId.Text + "' and OrgID='" + oldOrgId + "' ");
                        float AcademicYearId = db.getDb_Value("SELECT AcademicYearId FROM tblStudent WHERE (UserCode = '" + UserCode.Text + "') and OrgID='" + oldOrgId + "' ");

                        //float fees_Bus = db.getDb_Value("SELECT isnull(TotalAmount-sum(paidamount),0) AS PendingAmount FROM            tblStudentFeesPaid where  StudentId='" + UserCode.Text + "' group by TotalAmount");

                        //if ((fees+ fees_Bus) <= 0)
                        //{
                        //Added by Ashwini  21-sep-2020
                        float fessid = 0;
                        float FeesDetailsid = 0;
                        string FeesParticular;
                        float TotalAmt = 0;
                        DateTime currentDate = System.DateTime.Now.Date;
                        fessid = db.getDb_Value("SELECT  top(1) dbo.tblFeesDetails.FeesId FROM  dbo.tblFees INNER JOIN  dbo.tblFeesDetails ON dbo.tblFees.FeesId = dbo.tblFeesDetails.FeesId  where AcademicYearId='" + drpacedemicyear1.SelectedValue + "' and CourseId='" + _drpcourse + "' and  BranchId='" + _drpbranch + "' and  ClassId='" + _drpclass + "' and CasteCategoryId='" + castcatergoryid.ToString() + "' ");

                        FeesDetailsid = db.getDb_Value("SELECT top(1) dbo.tblFeesDetails.FeesDetailsId FROM  dbo.tblFees INNER JOIN  dbo.tblFeesDetails ON dbo.tblFees.FeesId = dbo.tblFeesDetails.FeesId  where AcademicYearId='" + drpacedemicyear1.SelectedValue + "' and CourseId='" + _drpcourse + "' and  BranchId='" + _drpbranch + "' and  ClassId='" + _drpclass + "' and CasteCategoryId='" + castcatergoryid.ToString() + "' ");
                        if (fessid > 0)
                        {
                            DataTable dt = new DataTable();
                            cn.Close();
                            cn.Open();
                            using (SqlCommand cmd = new SqlCommand("SELECT top(1) dbo.tblFeesDetails.Particular FROM  dbo.tblFees INNER JOIN  dbo.tblFeesDetails ON dbo.tblFees.FeesId = dbo.tblFeesDetails.FeesId  where AcademicYearId='" + drpacedemicyear1.SelectedValue + "' and CourseId='" + _drpcourse + "' and  BranchId='" + _drpbranch + "' and  ClassId='" + _drpclass + "'  and CasteCategoryId='" + castcatergoryid.ToString() + "'", cn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = cn;
                                // cn.Open();
                                // DataTable dt = new DataTable();
                                SqlDataReader dr = cmd.ExecuteReader();
                                dt.Load(dr);
                                FeesParticular = dt.Rows[0]["Particular"].ToString();
                            }

                            TotalAmt = db.getDb_Value("select sum(Amount) as TotalAmount from tblFeesDetails where FeesId='" + Convert.ToInt32(fessid) + "' ");
                            Shwmsg.Visible = false;
                            BtnAddFees.Visible = false;
                        }
                        else
                        {
                            Shwmsg.Visible = true;
                            Shwmsg.Text = "Please Add Fees For This Class";
                            BtnAddFees.Visible = true;
                            return;
                        }
                        //

                        float reciptno = db.getDb_Value("SELECT Max(ReceiptNo)  FROM tblStudentFeesPaid where StudentId='" + UserCode.Text + "'");

                        //if (orgid == oldOrgId)
                        //{

                            db.insert("update tblAdmissionDetails set CourseId='" + _drpcourse + "', BranchId='" + _drpbranch + "', ClassId='" + _drpclass + "' where AdmissionID='" + addmissionId.Text + "' ");
                            //db.insert("update tblStudent set CourseId='" + _drpcourse + "', BranchId='" + _drpbranch + "',AcademicYearId=" + drpacedemicyear1.SelectedValue + " where AdmissionID='" + addmissionId.Text + "' ");
                            db.insert("update tblStudent_Details set AcademicYearId=" + drpacedemicyear1.SelectedValue + " where AdmissionID='" + addmissionId.Text + "' ");
                        //}
                        //else
                        //{

                        //    DataSet ds = new DataSet();
                        //    cn.Close();
                        //    cn.Open();
                        //    using (SqlCommand cmd = new SqlCommand("select * from tblStudent where Usercode='" + UserCode.Text + "'", cn))
                        //    {
                        //        cmd.CommandType = CommandType.Text;
                        //        cmd.Connection = cn;
                        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        //        sda.Fill(ds);
                        //        objEWA.OrgID = orgid;
                        //        objEWA.ApplicationDate = DateTime.Now.ToString("DD-MM-YYYY");
                        //        objEWA.AdmissionType = ds.Tables[0].Rows[0]["AdmissionType"].ToString();
                        //        objEWA.CourseId = drpcourse.SelectedValue;
                        //        objEWA.ClassId = drpclass.SelectedValue;
                        //        objEWA.Branch_ID = Convert.ToInt32(drpbranch.SelectedValue);
                        //        objEWA.FeesCategory = ds.Tables[0].Rows[0]["FeesCategory"].ToString();
                        //        objEWA.CasteCategoryId = ds.Tables[0].Rows[0]["CasteCategoryId"].ToString();
                        //        objEWA.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        //        objEWA.MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                        //        objEWA.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                        //        objEWA.Gender1 = ds.Tables[0].Rows[0]["Gender"].ToString();
                        //        objEWA.BirthDate = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                        //        objEWA.BirthPlace = ds.Tables[0].Rows[0]["BirthPlace"].ToString();
                        //        objEWA.AddressLine1 = ds.Tables[0].Rows[0]["Address1"].ToString();
                        //        objEWA.AddressLine2 = ds.Tables[0].Rows[0]["Address2"].ToString() != "" ? ds.Tables[0].Rows[0]["Address2"].ToString() : "";
                        //        objEWA.Country1 = ds.Tables[0].Rows[0]["Country"].ToString();
                        //        objEWA.State1 = ds.Tables[0].Rows[0]["State"].ToString();
                        //        objEWA.District1 = ds.Tables[0].Rows[0]["District"].ToString();
                        //        objEWA.Taluka1 = ds.Tables[0].Rows[0]["Taluka"].ToString();
                        //        objEWA.City1 = ds.Tables[0].Rows[0]["City"].ToString();
                        //        objEWA.PinCode1 = ds.Tables[0].Rows[0]["Pin_Code"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["Pin_Code"].ToString()) : 0;
                        //        objEWA.MobileNo = ds.Tables[0].Rows[0]["Mobile"].ToString() != "" ? ds.Tables[0].Rows[0]["Mobile"].ToString() : "";
                        //        objEWA.E_Mail = ds.Tables[0].Rows[0]["EMail"].ToString() != "" ? ds.Tables[0].Rows[0]["EMail"].ToString() : "";
                        //        objEWA.Nationality1 = ds.Tables[0].Rows[0]["Nationality"].ToString();
                        //        objEWA.BloodGroup = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                        //        objEWA.Handicaped = ds.Tables[0].Rows[0]["Handicap"].ToString() != "" ? ds.Tables[0].Rows[0]["Handicap"].ToString() : "";
                        //        objEWA.AdharNo = ds.Tables[0].Rows[0]["AdharNo"].ToString();
                        //        objEWA.Religion1 = ds.Tables[0].Rows[0]["Religion"].ToString();
                        //        objEWA.Subcaste = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                        //        objEWA.ParentName = ds.Tables[0].Rows[0]["ParentName"].ToString();
                        //        objEWA.Relation1 = ds.Tables[0].Rows[0]["Relation"].ToString();
                        //        objEWA.MotherName = ds.Tables[0].Rows[0]["MotherName"].ToString();
                        //        objEWA.LastInstitute = ds.Tables[0].Rows[0]["LastInstitute"].ToString();
                        //        objEWA.Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString() != "" ? ds.Tables[0].Rows[0]["Photo"].ToString() : "";
                        //        objEWA.QualifiedExam = ds.Tables[0].Rows[0]["QualifiedExam"].ToString() != "" ? ds.Tables[0].Rows[0]["QualifiedExam"].ToString() : "";
                        //        objEWA.Status = ds.Tables[0].Rows[0]["Status"].ToString() != "" ? ds.Tables[0].Rows[0]["Status"].ToString() : "";
                        //        objEWA.GRNo = ds.Tables[0].Rows[0]["GRNo"].ToString();
                        //        objEWA.MotherTongue = ds.Tables[0].Rows[0]["MotherTongue"].ToString();
                        //        objEWA.AdmissionDate = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();
                        //        objEWA.PreviousRollNo = ds.Tables[0].Rows[0]["RollNo"].ToString();
                        //        objEWA.SaralId = ds.Tables[0].Rows[0]["SaralId"].ToString();
                        //        //objEWA.StudentsSignature = ds.Tables[0].Rows[0]["StudentsSignature"].ToString();
                        //        DataSet Ds = objBL.InsertPromoteStudentData(objEWA);
                        //    }
                        //}
                            //Added by Ashwini 11-sep-2020
                            //
                            db.insert("update  [dbo].[tblStudentFeesPaid] set StudentId='" + UserCode.Text + "',FeesId='" + Convert.ToInt32(fessid) + "',TotalAmount='" + Convert.ToInt32(TotalAmt) + "',PaidAmount=0,PendingAmount='" + Convert.ToInt32(TotalAmt) + "',UserId= '" + Convert.ToInt32(Userid) + "',TransDate= '" + currentDate + "',remark= '" + FeesParticular.ToString() + "',FeesDetailsId= '" + Convert.ToInt32(FeesDetailsid) + "' where  StudentId	='" + UserCode.Text + "' and GroupReceiptNo=0 ");
                        //

                        //db.insert("Update tblStudentClassDiv set ClassId='" + _drpclass + "' where StudentId='" + UserCode.Text + "'");
                        //float feesamount = db.getDb_Value("SELECT   sum(Amount) as     Amount FROM            tblFeesDetails WHERE        (FeesId = '" + fessid + "') ");


                        //db.insert("DELETE FROM tblStudentFeesPaid WHERE        (ReceiptNo <> '" + reciptno + "' and StudentId='" + UserCode.Text + "')");
                        // db.insert("update tblStudentFeesPaid set  PendingAmount='" + (feesamount - 0).ToString() + "'  ,FeesId='" + fessid + "' ,PaidAmount='" + "0" + "', TotalAmount='" + feesamount.ToString() + "' where StudentId='" + UserCode.Text + "'");

                        // db.insert("DELETE FROM tblStudentBusFeesPaid WHERE StudentId='" + UserCode.Text + "'");



                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Upgraded", "alert('Student Upgraded Successfully !!!')", true);
                        //msgBox.ShowMessage("Student Upgraded Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);

                        //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);


                        //BindStudent();
                        //ddlCourse.ClearSelection();
                        //ddlBranch.ClearSelection();
                        //ddlClass.ClearSelection();
                        //ddlCasteCategory.ClearSelection();
                        //txtStudName.Text = String.Empty;
                        //GrdStudent.DataSource = null;
                        //GrdStudent.DataBind();
                        //drpclass.ClearSelection();
                        //drpcourse.ClearSelection();
                        //drpbranch.ClearSelection();
                        //drpacedemicyear1.ClearSelection();
                        //    }
                        //    else
                        //    {
                        //        msgBox.ShowMessage("Please add fees for the respective academic year and caste category !!!", "Critical", UserControls.MessageBox.MessageStyle.Information);
                        //        return;
                        //    }




                        //}

                        //else
                        //{
                        //    msgBox.ShowMessage("Please pay all Pending fees  !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        //}
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Student Promoted Successfully ..!!');window.location='NextAcademicYear.aspx';", true);


                    }
                }
            
                    dvBranch = null;
                    dvClass = null;
                    dvDivision = null;
                    dvStudentData = null;

                    dvdrpBranch = null;
                    dvdrpClass = null;
                    dvdrpDivision = null;
                    dvdrpStudentData = null;

                    GrdStudent.DataSource = null;
                    GrdStudent.DataBind();

                    BindCourse();
                    GetStudentData();
                    //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Upgraded Successfully !!!')", true);
                    //Added by Ashwini more 21-sep-2020
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('SomeThing Is Wrong..!!');window.location='NextAcademicYear.aspx';", true);
                    //
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (drpBranch.Items.Count <= 1)
            //    {
            //        using (SqlCommand cmd = new SqlCommand("SELECT BranchId,BranchName FROM tblBranch  where CourseId='" + drpCourse.Text+ "' ", cn))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = cn;
            //            cn.Open();
            //            drpBranch.DataSource = cmd.ExecuteReader();
            //            drpBranch.DataTextField = "BranchName";
            //            drpBranch.DataValueField = "BranchId";
            //            drpBranch.DataBind();
            //            cn.Close();
            //        }
            //        drpBranch.Items.Insert(0, new ListItem("--Select Branch--"));

            //    }

            //}
            //catch(Exception ex)
            //{
            //}
            try
            {
                BindBranch();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    if (drpClass.Items.Count <= 1)
            //    {
            //        using (SqlCommand cmd = new SqlCommand("SELECT ClassId,ClassName FROM tblClass  where BranchId='" +  drpBranch.Text + "' ", cn))
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = cn;
            //            cn.Open();
            //            drpClass.DataSource = cmd.ExecuteReader();
            //            drpClass.DataTextField = "ClassName";
            //            drpClass.DataValueField = "ClassId";
            //            drpClass.DataBind();
            //            cn.Close();
            //        }
            //        drpClass.Items.Insert(0, new ListItem("--Select Class--"));

            //    }

            //}
            //catch (Exception ex)
            //{
            //}
            try
            {
                BindClass();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //BindDivision();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void drpcourse_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindBranch1();
        }
        void BindBranch1()
        {
            drpbranch.Items.Clear();

            dvBranch = new DataView(ViewState["dvBranch"] as DataTable);
            dvBranch.RowFilter = "[CourseId] = " + drpcourse.SelectedValue + "";
            drpbranch.DataSource = dvBranch;
            drpbranch.DataTextField = "BranchName";
            drpbranch.DataValueField = "BranchId";
            drpbranch.DataBind();
            drpbranch.Items.Insert(0, new ListItem("---Select---", "0"));

            //drpclass.Items.Clear();
            //drpclass.Items.Insert(0, new ListItem("---Select---", "0"));



            //GetStudentData();
        }

        protected void drpbranch_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindClass1();
        }
        void BindClass1()
        {
            drpclass.Items.Clear();

            dvClass = new DataView(ViewState["dvClass"] as DataTable);
            dvClass.RowFilter = "[BranchId] = " + drpbranch.SelectedValue + "";
            drpclass.DataSource = dvClass;
            drpclass.DataTextField = "ClassName";
            drpclass.DataValueField = "ClassId";
            drpclass.DataBind();
            drpclass.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void drpacedemicyear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData();
                printabledata();
               // UpgradeBusFeesDetails();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void BtnAddFees_Click(object sender, EventArgs e)
        {
           // Response.Redirect("AddFees.aspx");
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('AddFees.aspx' ,'_blank');", true);
        }

        //Added by Ashwini 21-sep-2020
        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ChechPendingAmount();
        }
        //

        //Added by Ashwini 25-sep-2020
        public void ChechPendingAmount()
        {
            string _drpcourse = ddlCourse.SelectedValue;
            string _drpbranch = ddlBranch.SelectedValue;
            string _drpclass = ddlClass.SelectedValue;
            foreach (GridViewRow gvrow in GrdStudent.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                // string xya
                if (chk != null && chk.Checked)
                {
                    Label addmissionId = (Label)gvrow.FindControl("lbladdmissionid");
                    Label UserCode = (Label)gvrow.FindControl("lblUserCode");
                    Label Branch = (Label)gvrow.FindControl("lblBranch");
                    Label Class = (Label)gvrow.FindControl("LblClass");
                    Label AcademicID = (Label)gvrow.FindControl("LblAcademicID");
                    string course = ddlCourse.SelectedValue;
                    //Added by Ashwini 25-sep-2020
                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.addmissionId = addmissionId.Text;
                    objEWA.StudId = UserCode.Text;
                    objEWA.course = course.ToString();
                    DataSet dsFeesDtls = objBL.GetAllDataFees(objEWA);
                    ViewState["DVCategory"] = dsFeesDtls.Tables[0];
                    DataTable DSFEES = dsFeesDtls.Tables[1];
                    foreach (DataRow Row in DSFEES.Rows)
                    {
                        int FeesId1 = Convert.ToInt32(Row["FeesId"].ToString());
                        float pendingAmt1 = db.getDb_Value("SELECT isnull(TotalAmount-sum(paidamount),0) AS PendingAmount FROM tblStudentFeesPaid where  StudentId='" + UserCode.Text + "' and FeesId='" + FeesId1 + "' group by TotalAmount");
                     
                        if (pendingAmt1 > 0)
                        {
                            chk.Checked = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Check Pending School Fees For Student .... !!!')", true);
                            // return;
                        }
                        else
                        {
                            float BusStud = db.getDb_Value("select StudentRouteId From tblStudentRouteAssign where UserCode='" + UserCode.Text + "' and CourseId='" + course + "' and BranchId='" + Branch.Text + "' and  ClassId='" + Class.Text + "' and AcademicYearId='" + AcademicID.Text + "' ");
                            if (BusStud > 0)
                            {
                                float BusFeesPaid = db.getDb_Value("Select StudentRouteId from tblStudentBusFeesPaid where StudentId='"+ UserCode.Text + "' ");
                                if (Convert.ToInt32(BusFeesPaid)>0)
                                {
                                    float PendingBusFee = db.getDb_Value("select tblStudentBusFeesPaid.TotalAmount-sum(tblStudentBusFeesPaid.PaidAmount) as pendingAmount from tblStudentRouteAssign Inner join tblStudentBusFeesPaid on tblStudentBusFeesPaid.StudentRouteId = tblStudentRouteAssign.StudentRouteId  where  tblStudentBusFeesPaid.StudentId='" + UserCode.Text + "' and tblStudentRouteAssign.CourseId='" + course + "' and tblStudentRouteAssign.BranchId='" + Branch.Text + "' and  tblStudentRouteAssign.ClassId='" + Class.Text + "' and tblStudentRouteAssign.AcademicYearId='" + AcademicID.Text + "' group by tblStudentBusFeesPaid.TotalAmount");
                                    if (PendingBusFee > 0)
                                    {
                                        chk.Checked = false;
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Check Pending Bus Fees For Student .... !!!')", true);

                                    }
                                }
                                else
                                {
                                    chk.Checked = false;
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Check Pending Bus Fees For Student .... !!!')", true);
                                }
                            }
                        }

                    }

                    //float PendingBusFee = db.getDb_Value("select StudentRouteId from tblStudentRouteAssign Inner join tblStudentBusFeesPaid on tblStudentBusFeesPaid.StudentId = tblStudentRouteAssign.Usercode  where  StudentId='" + UserCode.Text + "'");
                    //if (PendingBusFee == 0)
                    //{
                    //    chk.Checked = false;
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Check Bus Fee For Student .... !!!')", true);
                    //}

                }
            }
        }
        //

        //Added by Ashwini 26-sep-2020
        public void UpgradeBusFeesDetails()
        {
            DataSet DsBusFeesDetails = new DataSet();
            DataSet FinalDS = new DataSet();
            foreach (GridViewRow GrStudRow in GrdStudent.Rows)
            {
                CheckBox chkStud = (CheckBox)GrStudRow.FindControl("chkbox");
                // string xya
                if (chkStud.Checked==true)
                {
                    Label UserCode = (Label)GrStudRow.FindControl("lblUserCode");
                    objEWA.StudId = UserCode.Text;
                    objEWA.CourseId = drpcourse.SelectedValue;
                    objEWA.ClassId = drpclass.SelectedValue;
                    objEWA.BranchId = drpbranch.SelectedValue;
                    objEWA.AcademicYear = drpacedemicyear1.SelectedValue;
                     DsBusFeesDetails = objBL.GetBusFeesDetails(objEWA);
                }
                FinalDS.Merge(DsBusFeesDetails);
                
                if (DsBusFeesDetails != null)
                {
                    if (DsBusFeesDetails.Tables.Count > 0)
                    {

                        foreach(DataTable t1 in DsBusFeesDetails.Tables)
                        {
                            foreach(DataRow dr in t1.Rows)
                            {
                                dr.Delete();
                            }

                        }
                        //if (DsBusFeesDetails.Tables[0].Rows.Count > 0)
                        //{
                        //    DataRow dr = DsBusFeesDetails.Tables[0].Rows[0];
                        //    dr.Delete();
                        //}
                    }
                    
                }
                
                DsBusFeesDetails.AcceptChanges();
            }
            //RouteassignPanal.Visible = true;
            if(FinalDS.Tables.Count >0)
            {
                if(FinalDS.Tables[0].Rows.Count>0)
                {
                    GRDBusDetails.DataSource = FinalDS;
                    GRDBusDetails.DataBind();
                    GRDBusDetails.Visible = true;
                    return;
                }
                else
                {
                    DivAllotBus.Visible = true;
                    foreach (GridViewRow GrStudRow in GrdStudent.Rows)
                    {
                        CheckBox chkStud = (CheckBox)GrStudRow.FindControl("chkbox");
                        // string xya
                        if (chkStud.Checked == true)
                        {
                            Label UserCode = (Label)GrStudRow.FindControl("lblUserCode");
                            lblStudId.Text = UserCode.Text;
                        }
                    }

                }

            }
           
           
        }


        protected void btnchnageRoute_Click(object sender, EventArgs e)
        {
            //Response.Redirect("TransportDetails.aspx");
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('TransportDetails.aspx' ,'_blank');", true);
        }

        protected void GRDBusDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string StudentID = e.CommandArgument.ToString();
                if (e.CommandName == "DeallotRoute")
                {
                   
                    cn.Close();
                    cn.Open();
                    GRDBusDetails.Visible = false;
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tblStudentRouteAssign WHERE UserCode='" + StudentID + "'", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bus Route Successfully Deallotcated !!!')", true);
                    }
                }

                if (e.CommandName == "PayBusFee")
                {
                    // DivAllotBus.Visible = true;
                    // lblStudId.Text = e.CommandArgument.ToString();
                    string StudentId = e.CommandArgument.ToString();
                    TxtRoute.Text = GRDBusDetails.Rows[0].Cells[7].Text;
                    TxtBusTotalAmount.Text = GRDBusDetails.Rows[0].Cells[8].Text;
                    DivPayFees.Visible = true;
                   

                }

               
            }
            catch (Exception exp)
            {

            }


        }
        //Added by Ashwini 28-sep-2020
        protected void DDLBusRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RouteId = Convert.ToInt32(DDLBusRoute.SelectedValue);
            string RouteTitle = db.getDbstatus_Value("select Route from tblRoute where RouteId='" + RouteId + "' ");
            float Amount = db.getDb_Value("select Amount from tblRoute where RouteId='" + RouteId + "' ");
            TxtRouteTitle.Text = RouteTitle.ToString();
            TxtAmount.Text = Amount.ToString();
        }

        protected void btnAlloteRoute_Command(object sender, CommandEventArgs e)
        {
           // lblStudId.Text = e.CommandArgument.ToString();
            if (e.CommandName == "AllotbusBtnClick")
            {
                int Studentid =Convert.ToInt32(lblStudId.Text);
                int routeid = Convert.ToInt32(DDLBusRoute.SelectedValue);
                string Route = DDLBusRoute.SelectedItem.Text;
                string RouteTitle = TxtRouteTitle.Text;
                DateTime todaysDate = DateTime.Now.Date;
                int CourseId = Convert.ToInt32(drpcourse.SelectedValue);
                int ClassId = Convert.ToInt32(drpclass.SelectedValue);
                int BranchId = Convert.ToInt32(drpbranch.SelectedValue);
                int AcademicYearID = Convert.ToInt32(drpacedemicyear1.SelectedValue);
               
                cn.Close();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[tblStudentRouteAssign]([UserCode],[RouteId],[TransDate],[IsActive],[CourseId],[ClassId],[BranchId],[AcademicYearId])VALUES ('" + lblStudId.Text + "','" + routeid + "','" + todaysDate + "','1','"+ CourseId + "','"+ ClassId + "','"+ BranchId + "','"+ AcademicYearID + "')", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                    DivAllotBus.Visible = false;
                    GRDBusDetails.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bus Route Successfully allotcated !!!')", true);
                }
            }
        }

        protected void BtnPramote_Click(object sender, EventArgs e)
        {
            if (drpcourse.SelectedIndex == 0)
            {
                Shwmsg.Text = "Please Select Course";
                Shwmsg.ForeColor = System.Drawing.Color.Red;
                Shwmsg.Visible = true;
                return;
            }
            if (drpbranch.SelectedIndex == 0)
            {
                Shwmsg.Text = "Please Select Branch";
                Shwmsg.ForeColor = System.Drawing.Color.Red;
                Shwmsg.Visible = true;
                return;
            }
            if (drpclass.SelectedIndex == 0)
            {
                Shwmsg.Text = "Please Select Class";
                Shwmsg.ForeColor = System.Drawing.Color.Red;
                Shwmsg.Visible = true;
                return;
            }

            if (drpacedemicyear1.SelectedIndex == 0)
            {
                Shwmsg.Text = "Please Select Academic Year";
                Shwmsg.ForeColor = System.Drawing.Color.Red;
                Shwmsg.Visible = true;
                return;
            }
            Button1.Visible = true;
            BtnPramote.Visible = false;
            checkPreviousBusAllot();
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAllotBus_Click(object sender, EventArgs e)
        {
            UpgradeBusFeesDetails();
        }

        //

        public void checkPreviousBusAllot()
        {
            DataSet DsBusAllot = new DataSet();
            DataSet DsbusfeePay = new DataSet();
            foreach (GridViewRow GrStudRow in GrdStudent.Rows)
            {
                CheckBox chkStud = (CheckBox)GrStudRow.FindControl("chkbox");
                // string xya
                if (chkStud.Checked == true)
                {
                    Label UserCode = (Label)GrStudRow.FindControl("lblUserCode");
                    Label AcademicYearn = (Label)GrStudRow.FindControl("Label1");
                    Session["StudentId"] = UserCode;
                    string Coursename = GrdStudent.Rows[0].Cells[4].Text;
                    string courseId = db.getDbstatus_Value("select * from tblCourse where CourseName='" + Coursename + "' ");
                    string BranchName = GrdStudent.Rows[0].Cells[5].Text;
                    string BranchId = db.getDbstatus_Value("select * from tblbranch where BranchName='" + BranchName + "' and Courseid='"+ courseId + "' ");
                    string ClassName = GrdStudent.Rows[0].Cells[6].Text;
                    string classId = db.getDbstatus_Value("select * From tblclass where ClassName='" + ClassName + "' and BranchId='"+ BranchId + "' ");
                  
                    string AcademicYearn1 = AcademicYearn.Text;
                    string AcademicYear = db.getDbstatus_Value("select * from tblAcademicYear where AcademicYear='" + AcademicYearn1 + "' ");
                    objEWA.StudId = UserCode.Text;
                    objEWA.CourseId = courseId;
                    objEWA.ClassId = classId;
                    objEWA.BranchId = BranchId;
                    objEWA.AcademicYear = AcademicYear;
                    DsBusAllot = objBL.CheckAllotBus(objEWA);
                   
                        if (DsBusAllot.Tables.Count > 0)
                        {
                            if (DsBusAllot.Tables[0].Rows.Count >= 0)
                            {
                                BtnAllotBus.Visible = true;
                                Shwmsg.Visible = true;
                                Shwmsg.Text = "Please Allot Bus For this Student For This Course...";
                                Shwmsg.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    
                   
                  
                   
                }
            }
        }

        protected void BtnBusFeeCancel_Click(object sender, EventArgs e)
        {
            DivPayFees.Visible = false;
        }

        protected void BtnAllotCancel_Click(object sender, EventArgs e)
        {
            DivAllotBus.Visible = false;
        }

        protected void chkboxbus_CheckedChanged(object sender, EventArgs e)
        {
                foreach (GridViewRow BusDetails in GRDBusDetails.Rows)
                {
                CheckBox chkBus = (CheckBox)BusDetails.FindControl("chkboxbus");
                Button BtnPayBusFee = (Button)BusDetails.FindControl("BtnAllocate");
                Label UserCode = (Label)BusDetails.FindControl("lblUserCode");
                Label Routeid = (Label)BusDetails.FindControl("LblRouteId");
                string CourseId = GRDBusDetails.Rows[0].Cells[6].Text;
                string ClassId= GRDBusDetails.Rows[0].Cells[6].Text;
                string BrnachId= GRDBusDetails.Rows[0].Cells[6].Text;
                string AcademicyearId= GRDBusDetails.Rows[0].Cells[6].Text;
                if (chkBus.Checked == true)
                    {
                      float busfee = db.getDb_Value("select BusFeesId from tblStudentBusFeesPaid where StudentId='" + UserCode.Text + "' and StudentRouteId='" + Routeid.Text + "' ");
                    int BusFee = Convert.ToInt32(busfee);
                    if (BusFee > 0)
                    {
                        BtnPayBusFee.Enabled = false;
                    }
                    else
                    {
                        BtnPayBusFee.Enabled = true;
                    }
               
                }
            }
        }

        protected void BtnPayBusFee_Click(object sender, EventArgs e)
        {
            //--------Added by Ashwini 8-oct-2020-------------------------------------------------------------------------------------------
            decimal TotalAmt = TxtBusTotalAmount.Text != "" ? Convert.ToDecimal(TxtBusTotalAmount.Text):0;
            decimal PayAmt1 = txtPayAmt.Text != "" ? Convert.ToDecimal(txtPayAmt.Text) : 0;
            if(PayAmt1> TotalAmt)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Total Amount...')", true);
             
                txtPayAmt.Text = "";
                txtPayAmt.Focus();
                return;
            }
            //-----------------------------------------------------------------------------------------------------------------------
            foreach (GridViewRow GrBusRow in GRDBusDetails.Rows)
            {
                CheckBox chkBus = (CheckBox)GrBusRow.FindControl("chkboxbus");
                // string xya
                if (chkBus.Checked == true)
                {
                    Label UserCode = (Label)GrBusRow.FindControl("lblUserCode");
                    Label RouteId = (Label)GrBusRow.FindControl("LblRouteId");
                    string totalAmt = TxtBusTotalAmount.Text;
                    string PayAmt = txtPayAmt.Text;
                    double PaidAmt = Convert.ToDouble(totalAmt) - Convert.ToDouble(PayAmt);
                    string Remark = "BusFees";
                    int Userid = Convert.ToInt32(Session["UserCode"]);
                    float Reciept = db.getDb_Value("select isnull(max(ReceiptNo),0)+1 from tblstudentBusfeespaid");
                    DateTime trandate = System.DateTime.Now;
                    cn.Close();
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[tblStudentBusFeesPaid]([ReceiptNo],[StudentId],[StudentRouteId],[TotalAmount],[PaidAmount],[PendingAmount],[UserId],[TransDate],[remark],[Paymentmode])VALUES('"+ Reciept.ToString() + "','" + UserCode.Text + "','" + RouteId.Text + "','" + TxtBusTotalAmount.Text + "','" + txtPayAmt.Text + "','" + PaidAmt.ToString() + "','" + Userid + "','" + trandate + "','" + Remark + "','" + ddlpaymentmode.SelectedItem.Text + "' )", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                        DivPayFees.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bus Fee Pay SuccessFully....!!!')", true);
                    }
                }
            }
            DivPayFees.Visible = false;
        }

//Added by Ashwini 9-Oct-2020------------------------------------------------------------------------------------------------------------------
        //public void BindOragnization()
        //{
        //    DataSet ds = new DataSet();
        //    cn.Close();
        //    cn.Open();
        //    using (SqlCommand cmd = new SqlCommand(" select OrganizationId,OrgName from tblOrganization", cn))
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Connection = cn;
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(ds);
        //        ddlOrg.DataSource = ds;
        //        ddlOrg.DataTextField = "OrgName";
        //        ddlOrg.DataValueField = "OrganizationId";
        //        ddlOrg.DataBind();
        //        ddlOrg.Items.Insert(0, new ListItem("---Select---", "0"));
        //    }
        //}

        protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpbranch.Items.Clear();
            drpclass.Items.Clear();
            drpbranch.Items.Insert(0, new ListItem("---Select---", "0"));
            drpclass.Items.Insert(0, new ListItem("---Select---", "0"));
            BindCourseNextYear();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------
      //  Added by Ashwini 9-Oct-2020
        public void BindCourseNextYear()
        {
            //if (ddlOrg.SelectedValue == "0")
            //{
            //    Shwmsg.Text = "Please Select Orgnization...";
            //    Shwmsg.ForeColor = System.Drawing.Color.Red;
            //    ddlOrg.Focus();
            //    return;
            //}
            objEWA.OrgId = Session["OrgId"].ToString();
           // objEWA.OrgId = ddlOrg.SelectedValue;
            DataSet ds = objBL.BindCourses_BL(objEWA);

           // DVCourse = new DataView(ViewState["DVCourse"] as DataTable);
            drpcourse.Items.Clear();
            drpcourse.DataSource = ds.Tables[0];
            drpcourse.DataTextField = "CourseName";
            drpcourse.DataValueField = "CourseId";
            drpcourse.DataBind();
            drpcourse.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
}
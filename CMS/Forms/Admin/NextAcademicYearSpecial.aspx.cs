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
    public partial class NextAcademicYearSpecial : System.Web.UI.Page
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
                /*BindOragnization()*/
                ;
                DDLAcademicYear.SelectedIndex = 0;
                //DDLAcademicYear.SelectedIndex = drpacedemicyear1.Items.Count - 1;

                drpacedemicyear1.SelectedIndex = 0;
                //drpacedemicyear1.SelectedIndex = drpacedemicyear1.Items.Count - 1;

            }

        }

        private DataView dvBranch = null;
        private DataView dvClass = null;
        private DataView dvStudentData = null;
        private DataView dvdrpBranch = null;
        private DataView dvdrpClass = null;
        private DataView dvdrpStudentData = null;


        // Added by Ashwini 25-sep-2020
        private DataView DVFees = null;
        //Added by Ashwini 9-Oct-2020---
        private DataView DVCourse = null;

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }
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
                ViewState["DVCourse"] = ds.Tables[0];
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
                var count = GrdStudent.Rows.Count;
                string[] AdmissionID = new string[count];
                int i = 0;
                int oldOrgId = Convert.ToInt32(Session["OrgId"].ToString());
                foreach (GridViewRow gvrow in GrdStudent.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    if (chk != null && chk.Checked)
                    {
                        Label addmissionId = (Label)gvrow.FindControl("lbladdmissionid");
                        Label UserCode = (Label)gvrow.FindControl("lblUserCode");
                        Label Branch = (Label)gvrow.FindControl("lblBranch");
                        Label Class = (Label)gvrow.FindControl("LblClass");
                        Label AcademicYear = (Label)gvrow.FindControl("LblAcademicID");
                        string _drpcourse = drpcourse.SelectedValue;
                        string _drpbranch = drpbranch.SelectedValue;
                        string _drpclass = drpclass.SelectedValue;
                        float castcatergoryid = db.getDb_Value(" select feescategory FROM  tbladmissiondetails WHERE   admissionid='" + addmissionId.Text + "' and OrgID='" + oldOrgId + "' ");
                        float AcademicYearId = db.getDb_Value("SELECT AcademicYearId FROM tblStudent WHERE (UserCode = '" + UserCode.Text + "') and OrgID='" + oldOrgId + "' ");
                        
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
                        float reciptno = db.getDb_Value("SELECT Max(ReceiptNo)  FROM tblStudentFeesPaid where StudentId='" + UserCode.Text + "'");
                        db.insert("update tblAdmissionDetails set CourseId='" + _drpcourse + "', BranchId='" + _drpbranch + "', ClassId='" + _drpclass + "' where AdmissionID='" + addmissionId.Text + "' ");
                        db.insert("update tblStudent_Details set AcademicYearId=" + drpacedemicyear1.SelectedValue + " where AdmissionID='" + addmissionId.Text + "' ");
                        db.insert("update  [dbo].[tblStudentFeesPaid] set StudentId='" + UserCode.Text + "',FeesId='" + Convert.ToInt32(fessid) + "',TotalAmount='" + Convert.ToInt32(TotalAmt) + "',PaidAmount=0,PendingAmount='" + Convert.ToInt32(TotalAmt) + "',UserId= '" + Convert.ToInt32(Userid) + "',TransDate= '" + currentDate + "',remark= '" + FeesParticular.ToString() + "',FeesDetailsId= '" + Convert.ToInt32(FeesDetailsid) + "' where  StudentId	='" + UserCode.Text + "' and GroupReceiptNo=0 ");
                        objEWA.OrgID= Convert.ToInt32(Session["OrgId"].ToString());
                        objEWA.student_Code = UserCode.Text;
                        objEWA.CourseId = ddlCourse.SelectedValue;
                        objEWA.Branch_ID = Convert.ToInt32(Branch.Text);
                        objEWA.ClassId = Class.Text;
                        objEWA.AcademicYearID = AcademicYear.Text;
                        objEWA.PinCode1 = Convert.ToInt32(Userid);
                        string StatusSave = objBAL.SaveStudentFeesHistrory(objEWA);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Student Promoted Successfully ..!!');window.location='NextAcademicYearSpecial.aspx';", true);


                    }
                }

                dvBranch = null;
                dvClass = null;
                dvStudentData = null;
                dvdrpBranch = null;
                dvdrpClass = null;
                dvdrpStudentData = null;
                GrdStudent.DataSource = null;
                GrdStudent.DataBind();
                BindCourse();
                GetStudentData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('SomeThing Is Wrong..!!');window.location='NextAcademicYearSpecial.aspx';", true);
            

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
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
        protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
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
        protected void drpacedemicyear1_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void BtnAddFees_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('AddFees.aspx' ,'_blank');", true);
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        
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
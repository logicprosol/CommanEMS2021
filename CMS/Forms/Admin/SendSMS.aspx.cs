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
using EntityWebApp.Admin;
using BusinessAccessLayer.Admin;
using System.Net;
using System.IO;

namespace CMS.Forms.Admin
{
    public partial class SendSMS : System.Web.UI.Page
    {
        string Password = ConfigurationManager.AppSettings["SmsPass"].ToString();
        string UserName = ConfigurationManager.AppSettings["SmsUser"].ToString(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            int orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }

            if (!IsPostBack)
            {
                BindCourse();
            }
        }

        private DataView dvBranch = null;
        private DataView dvClass = null;
        private DataView dvDivision = null;
        private DataView dvStudentData = null;

        #region[Bind Course]

        private void BindCourse()
        {
            try
            {
                EWA_SendSMS objEWA = new EWA_SendSMS();
                BL_SendSMS objBL = new BL_SendSMS();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];
                ViewState["dvDivision"] = ds.Tables[4];
                ViewState["dvStudentData"] = ds.Tables[5];

                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlCasteCategory.DataSource = ds.Tables[1];
                ddlCasteCategory.DataTextField = "CasteCategoryName";
                ddlCasteCategory.DataValueField = "CasteCategoryId";
                ddlCasteCategory.DataBind();
                ddlCasteCategory.Items.Insert(0, new ListItem("---Select---", "0"));

                DDLAcademicYear.DataSource = ds.Tables[7];
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
                DDLAcademicYear.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));

                GrdStudent.DataSource = ds.Tables[5];
                GrdStudent.DataBind();
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
                GetStudentData();
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
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [StudentName] like '"
                    + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (ddlCasteCategory.SelectedValue != "0" && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [CourseId] = " + ddlCourse.SelectedValue + " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
                if (txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue +
                    " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
                if (ddlCasteCategory.SelectedValue != "0" && txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [StudentName] like '"
                    + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            else if (ddlCasteCategory.SelectedValue != "0")
            {
                if (ddlCourse.SelectedValue == "0" && txtStudName.Text.Length == 0 && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (txtStudName.Text.Length != 0)
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [Caste] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [Caste] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
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
            if (ddlDivision.SelectedValue != "0")
            {
                strQuery = strQuery + " And [DivisionId] = " + ddlDivision.SelectedValue + "";
            }
            dvStudentData.RowFilter = strQuery;
            GrdStudent.DataSource = dvStudentData;
            GrdStudent.DataBind();
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

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));

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
                BindDivision();
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
                ddlDivision.DataSource = dvDivision;
                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "DivisionId";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));
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
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void txtStudName_TextChanged(object sender, EventArgs e)
        {
            GetStudentData();
        }

        #region SEND SMS
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SendStudentSMS("SentToStudent");
            }
            catch (Exception)
            {
                
                throw;
            }
               
          
        }

        private void SendStudentSMS(string strAction)
        {
            try
            {
                int count = GrdStudent.Rows.Count;
                string[] MobileNo = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdStudent.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                    if (chk != null && chk.Checked)
                    {
                        MobileNo[i] = GrdStudent.DataKeys[gvrow.RowIndex].Values["ParentMobile"].ToString();

                        SendStudSMS(MobileNo);
                    }
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }

        }

        private void SendStudSMS(string[] MobileNo)
        {
            try
            {
                string Message = txtMessage.Text;

                WebClient client = new WebClient();
                //string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";
                //string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser&password=834309065&sendername=DM&mobileno=9420928041&message=CMS SMS TEST";

                //Redsms
                string baseurl = "http://login.redsms.in/API/SendMessage.ashx?user=" + UserName + "&password=" + Password + "&phone=" + MobileNo + "&text=" + Message + " &type=p";

                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
            }
            catch (Exception exp)
            {

                throw exp;
            }

        }
        #endregion
       
    }
}
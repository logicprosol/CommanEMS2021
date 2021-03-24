using System;

//Admin Home
namespace CMS.Forms.Admin
{
    public partial class Admin_Home1 : System.Web.UI.Page
    {
        public static int orgId;
        //Page Load
        #region[Page Load]
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                if (!IsPostBack)
                if (Convert.ToInt32(Request.QueryString["Msg"]) > 0)
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Saved", "alert('Staff Registered Successfully with Username/EmpCode="+ Request.QueryString["Msg"] + " and Email Sent !!!');", true);
                }
                //int orgId = Convert.ToInt32(Session["OrgId"]);
            }
            catch(Exception ex)
            {
                //GeneralErr(ex.Message);
            }
        }
        #endregion
        
        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Page Links
        #region[Page Links]
        //Admission
        protected void lbtnStudentAdmission_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("StudentAdmissionList.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Student Details
        protected void lbtnViewStudentDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("StudentList.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Manage User
        protected void lbtnManageUser_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Role.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Time Table
        protected void lbtnTimeTable_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("TimeTableCreation.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //View Attendance
        protected void lbtViewAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ProgramExecutive.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Settings
        protected void lbtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ChangePassword.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Human Resources
        protected void lbtnHumanResources_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SearchFaculty.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Examinations
        protected void lbtnExaminations_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddFees.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Manage News
        protected void lbtnManageNews_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AdminCreateAnnouncement.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
    }
}
using System;

namespace CMS.Forms.Student
{
    public partial class Student_Home1 : System.Web.UI.Page
    {
        public static int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
}

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Page Links
        #region[Page Links]

        //Profile
        protected void lbtnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewProfile.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Study Material
        protected void lbtnStudyMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewUploadDocument.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Announcement
        protected void lbtnAnnouncements_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewAnnouncement.aspx");
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
                Response.Redirect("");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Fee
        protected void lbtnFee_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewFeesDetails.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Assignment
        protected void lbtnAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewUploadDocument.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Exam
        protected void lbtnExam_Click(object sender, EventArgs e)
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

        #endregion
    }
}
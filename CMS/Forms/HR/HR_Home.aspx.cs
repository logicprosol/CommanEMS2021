using System;

namespace CMS.Forms.HR
{
    public partial class HR_Home : System.Web.UI.Page
    {
        //Page Load
        #region[Page Load]
        int OrgID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OrgID = Convert.ToInt32(Session["OrgId"]);
                //int AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);

                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            }
            catch (Exception exp)
            {
                //Response.Redirect("~/CMSHome.aspx");
                //GeneralErr(exp.Message);
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

        //Emp Info
        protected void lbtnEmpInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddStaff.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Assign Sub
        protected void lbtnAssignSubjects_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("EmpAssignSubject.aspx");
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
                Response.Redirect("HRCreateAnnouncement.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Pay Settings
        protected void lbtnPaySettings_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BasicPaySettings.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Add Emp
        protected void lbtAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddStaff.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Settings
        protected void lbtnSetting_Click(object sender, EventArgs e)
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
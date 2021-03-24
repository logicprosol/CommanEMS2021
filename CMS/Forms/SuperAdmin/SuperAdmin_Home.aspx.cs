using System;

//Super Admin
namespace CMS.Forms.SuperAdmin
{
    public partial class SuperAdmin_Home : System.Web.UI.Page
    {
        //Page Load
        #region[Page Load]
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserType"] == null)
            //{
            //    Response.Redirect("~/CMSHome.aspx");
            //}
            
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
        protected void lbtnAddCollege_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SuperAdmin_AddNewCollege.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //University
        protected void AddUnivercity_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("University.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Announcements
        protected void lbtnAnnouncements_Click(object sender, EventArgs e)
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

        //Manage User
        protected void lbtnManageUser_Click(object sender, EventArgs e)
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

        //Sport
        protected void lbtSport_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SportMaster.aspx");
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
        #endregion
    }
}
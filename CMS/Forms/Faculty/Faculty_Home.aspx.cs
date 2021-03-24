using System;

//Faculty Home
namespace CMS.Forms.Faculty
{
    public partial class Faculty_Home : System.Web.UI.Page
    {
        //Object
        #region[Objects]
        public int OrgID=0;
        public string Usertype, UserName;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OrgID = Convert.ToInt32(Session["OrgId"]);
                //Usertype = Convert.ToString(Session["UserType"]);
                //UserName = Convert.ToString(Session["UserName"]);

                if (OrgID == 0 )
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                //if (!IsPostBack)
                //{
                //}




            }
            catch (Exception exp)
            {
                //Response.Redirect("~/CMSHome.aspx");
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Dash Board
        #region [Dash Bord]

        protected void lbtnViewProfile_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FacultyViewProfile.aspx");
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
                Response.Redirect("StudentAttendance.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Announcement Click

        protected void lbtnAnnouncements_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CreateAnnouncement.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Apply Leave

        protected void lbtnApplyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("LeaveApplication.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Attendance Event

        protected void lbtViewAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewAnnouncementStaff.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //View Salary

        protected void lbtnViewSalry_Click(object sender, EventArgs e)
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

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion CreateAccouncement Code
    }
}
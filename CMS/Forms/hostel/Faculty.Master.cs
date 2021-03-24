using System;
using System.Data;
using System.Web;
using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;

namespace CMS.Forms.hostel
{
    public partial class hostel : System.Web.UI.MasterPage
    {
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

        private BindControl ObjHelper = new BindControl();

        public int OrgID=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            OrgID = Convert.ToInt32(Session["OrgId"]);

            if (OrgID == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                lblDate.Text = System.DateTime.Now.ToShortDateString();

                Get_OrganizationDetails(OrgID);

                lblUserType.Text = Convert.ToString(Session["UserType"]);
                lblUserName.Text = Convert.ToString(Session["UserName"]);
            }
        }

        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {
                DataSet ds = objBL.Get_OrganizationDetails(OrgID);

                string StaffPhoto = ds.Tables[0].Rows[0]["Logo"].ToString();
                if (StaffPhoto != null && StaffPhoto != "")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    ImageButton_logo.ImageUrl = "data:image/png;base64," + base64String;
                }

                lbl_CollegeName.Text = ds.Tables[0].Rows[0]["OrgName"].ToString();
                lbl_CollegeAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                Lbl_TrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();

            }

            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }
        //Logout
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Session.Contents.RemoveAll();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();

            Response.Redirect("~/CMSHome.aspx");
        }

        protected void lbtnLogout1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Session.Contents.RemoveAll();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            Response.Redirect("~/CMSHome.aspx");
        }
    }
}
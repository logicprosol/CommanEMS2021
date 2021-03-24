using System;
using System.Web;

namespace CMS.Forms.SuperAdmin
{
    public partial class SuperAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (Session["UserType"].ToString().Trim().ToUpper() == "SuperAdmin".ToUpper())
            {
              int  OrgID = Convert.ToInt32(Session["OrgId"]);

            }
            //else
            //{
            //    Response.Redirect("~/CMSHome.aspx");
            //}
        }
        //Logout
        #region[Logout]

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

        #endregion


        protected void ahrd(object sender, EventArgs e)
        { 
        
        }
    }
}
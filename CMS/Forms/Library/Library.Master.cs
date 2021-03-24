using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using EntityWebApp;
using DataAccessLayer;
using System.Data;

namespace CMS.Forms.Library
{
    public partial class Library : System.Web.UI.MasterPage
    {
        #region[Objects]
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();
        public static int orgId = 0;
        private BindControl ObjHelper = new BindControl();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
                 if (Session["UserType"].ToString().Trim().ToUpper() == "Librarian".ToUpper())
                {

                   int OrgID = Convert.ToInt32(Session["OrgId"]);
                    lblDate.Text = DateTime.Now.ToString();
                    Get_OrganizationDetails(OrgID);
                }
                else
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            }
            catch (Exception)
            {
                //Response.Redirect("~/CMSHome.aspx");
            }
        }

        //Get Organization Details
        #region[Get Organization Details]

        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {
                
                    DataSet ds = objBL.Get_OrganizationDetails(OrgID);

                    string OrgLogo = ds.Tables[0].Rows[0]["Logo"].ToString();
                    if (OrgLogo != null && OrgLogo != "")
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
                //Response.Redirect("~/CMS/CMS/CMSHome.aspx");
                //throw;
            }
        }

        #endregion

        //Logout
        #region MyRegion
        
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

    }
}
using BusinessAccessLayer;
using EntityWebApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Trustee
{
    public partial class Trustee : System.Web.UI.MasterPage
    {
        //Objects
        #region[Objects]
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();
public static int orgId = 0;
        //private BindControl ObjHelper = new BindControl();
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
                 if (Session["UserType"].ToString().Trim().ToUpper() == "Trustee".ToUpper())
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
            catch (Exception ex){
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

 

        protected void lbtnLogout1_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoServerCaching();
                HttpContext.Current.Response.Cache.SetNoStore();
                Session.Abandon();
                Response.Redirect("~/CMSHome.aspx");

            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoServerCaching();
                HttpContext.Current.Response.Cache.SetNoStore();
                Session.Abandon();
                Response.Redirect("~/CMSHome.aspx");

                
            }
            catch (Exception)
            {
                //throw;
            }
        }


    }
}
using System;
using System.Data;
using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using System.Web.UI;
using System.Web;

//Admin Home
namespace CMS.Forms.Admin
{
    public partial class AdminHome : System.Web.UI.MasterPage
    {
        //Objects
        #region[Objects]
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

        private BindControl ObjHelper = new BindControl();
        #endregion
        private static int OrgID = 0;
        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID != 0)
                {
                    //Response.Redirect("~/Admin_Home.aspx");
                     if (Session["UserType"].ToString().Trim().ToUpper() == "Admin".ToUpper())
                    {
                        
                        if (!IsPostBack)
                        {
                            OrgID = Convert.ToInt32(Session["OrgId"]);
                               lblDate.Text = DateTime.Now.ToString();
                                Get_OrganizationDetails(OrgID);
                            
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/CMSHome.aspx");

                }


            }
            catch (Exception ex)
            {
                //throw;
                GeneralErr(ex.Message);
            }
        }

        #endregion
        protected void GeneralErr(String msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('" + msg + "')", true);
        }

        //Get Organization Details
        #region[Get Organization Details]

        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {
                if (!IsPostBack)
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
            }

            catch (Exception)
            {
                //Response.Redirect("~/CMS/CMS/CMSHome.aspx");
               // throw;
            }
        }

        #endregion

        //Logout
        #region[Logout]


        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            try
            {

                Session.RemoveAll();
                Session.Abandon();
                Session.Clear();
                Session.Contents.RemoveAll();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoServerCaching();
                HttpContext.Current.Response.Cache.SetNoStore();
                //Response.Redirect("~/Forms/Admin/College_Home.aspx");/CMSHome.aspx
                Response.Redirect("~/CMSHome.aspx");
            }
            catch (Exception)
            {
                //throw;
            }
        }

        #endregion


        protected void lbtnLogout1_Click(object sender, EventArgs e)
        {
            try
            {
                Session.RemoveAll();
                Session.Abandon();
                Session.Clear();
                Session.Contents.RemoveAll();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoServerCaching();
                HttpContext.Current.Response.Cache.SetNoStore();
                //Response.Redirect("~/Forms/Admin/College_Home.aspx");/CMSHome.aspx
                Response.Redirect("~/CMSHome.aspx");
            }
            catch (Exception)
            {
                //throw;
            }
        }
  
}
}
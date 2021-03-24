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

namespace CMS.Forms.Inventory
{
    public partial class Inventory : System.Web.UI.MasterPage
    {
        
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();
public static int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
            if (Session["UserType"].ToString().Trim().ToUpper() == "Inventor".ToUpper())
            {
                
        
                if (!IsPostBack)
                {
                    int OrgID = Convert.ToInt32(Session["OrgId"]);
                    lblDate.Text = DateTime.Now.ToString();
                    Get_OrganizationDetails(OrgID);

                    // lblUserType.Text = Convert.ToString(Session["UserType"]);
                    // lblUserName.Text = Convert.ToString(Session["UserName"]);
                }
               
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('master page')", true);
                    //Response.Redirect("~/CMSHome.aspx");
                }
                }
            }

        //Logout
        #region[Logout]

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

        #endregion
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

            catch (Exception exp)
            {
               GeneralErr(exp.Message.ToString());
                //throw exp;
            }
        }


        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
using System;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web;

namespace CMS
{
    public partial class CMS_Home : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && TxtPassword.Text != "")
            {
                try
                {
                DataSet dsUser = CheckUserLogin();

                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    string UserType = dsUser.Tables[0].Rows[0]["UserType"].ToString();
                    string UserName = dsUser.Tables[0].Rows[0]["UserName"].ToString();
                    string UserCode = dsUser.Tables[0].Rows[0]["UserCode"].ToString();
                    Session["UserName"] = UserName;
                    Session["UserCode"] = UserCode;
                    Session["UserType"] = UserType;
                    Response.Redirect("~/Forms/SuperAdmin/SuperAdmin_Home.aspx");
                }
                else 
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PLease Check Username And Password ')", true);
                    //lblMsg.Text = "Please Enter Valid UserName & Password";
                }
                }
                catch (Exception exp)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", exp.Message, true);
                   // throw exp;
                }
            }
        }

        private DataSet CheckUserLogin()
        {
            DataSet ds=null;
            try
            {
                EWA_Login objEWA = new EWA_Login();
                BL_Login objBL = new BL_Login();

                objEWA.UserName = txtUserName.Text.Trim().ToString();
                objEWA.Password = TxtPassword.Text.Trim().ToString();
                objEWA.UserType = "SuperAdmin";
                 ds = objBL.CheckValidUser_BL(objEWA);
               
            }
            catch (Exception exp)
            {
               // Response.Redirect("~/CMSHome.aspx"); 
                //throw exp;
            }
            return ds;
        }

        protected void btnAdminLoginModel_Click(object sender, EventArgs e)
        {

        }
    }
}
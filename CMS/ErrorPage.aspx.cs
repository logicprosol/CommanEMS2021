using System;
using System.Web.UI;
using System.Web.UI.WebControls;

//Error Page
namespace CMS
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Button btn = Page.Master.FindControl("btnAdminLoginModel") as Button;
                btn.Visible = false;
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('" + exp + "')", true);
            }
        }

        #endregion

        //Home Redirect
        #region[Home Redirect]

        protected void lbtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion
    }
}
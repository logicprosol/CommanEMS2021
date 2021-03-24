using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BTSDemo.UserControls
{
    public partial class PagePopup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnOk.OnClientClick = String.Format("fnClickOK('{0}','{1}')", btnOk.UniqueID, "");
            //btnOk.Focus();
        }

        public void ShowPage(string PageName)
        {
            HtmlGenericControl PgPopup = (HtmlGenericControl)this.FindControl("PgPopup");
            PgPopup.Attributes["src"] = PageName;
            mpext.Show();
        }

        //protected void btnOk_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Session["MasterPopup"] = null;
        //}

    }
}
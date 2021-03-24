using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Trustee
{
    public partial class TrusteeHome : System.Web.UI.Page
    {
        public static int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
}

        protected void lbtnAddCollege_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Forms/Trustee/addmissiondetails.aspx");
        }

        protected void lbtnSettings0_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Forms/Trustee/ChangePassword.aspx");
        }

        protected void lblPlacement_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Forms/Trustee/PlacementsGraph.aspx");
        }

        protected void lblINVENTORY_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Forms/Trustee/InventoryGraphs.aspx");

        }
    }
}
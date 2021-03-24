using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Common
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
           
            this.MasterPageFile ="~/Forms/Admin/Admin.Master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {

        }
    }
}
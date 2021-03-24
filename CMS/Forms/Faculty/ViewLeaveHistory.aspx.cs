using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp.Faculty;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Faculty
{
    public partial class ViewLeaveHistory : System.Web.UI.Page
    {
        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    BindLeaveHistory();
                }
                catch (Exception exp)
                {
                    
                }
            }
        }

        public void BindLeaveHistory()
        {
            try
            {
                BL_Leave ObjBL = new BL_Leave();
                EWA_Leave ObjEWA = new EWA_Leave();

                ObjEWA.OrgID = orgId;
                ObjEWA.UserCode = Session["UserCode"].ToString();
                DataSet ds = ObjBL.BL_GetLeaveHistory(ObjEWA);

                grdStaffLeave.DataSource = ds;
                grdStaffLeave.DataBind();
            }
            catch(Exception ext)
            {

            }
        }
    }
}
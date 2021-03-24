using System;
using System.Data;
using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;

namespace CMS
{
    public partial class Collage_Home : System.Web.UI.MasterPage
    {
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

        private BindControl ObjHelper = new BindControl();
        int OrgID =0;
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                orgId = Convert.ToInt32(Session["OrgID"]);
                //if (orgId == 0)
                //{
                //    Response.Redirect("~/CMSHome.aspx");
                //}

            if (!IsPostBack)
            {
                //int OrgID = Convert.ToInt32(Request.QueryString["OrgID"]);

                 OrgID = Convert.ToInt32(Session["OrgId"]);

                ImageButton_logo.ImageUrl = "~/Handler/Image_Handler.ashx?OrgID=" + OrgID;

                Get_OrganizationDetails(OrgID);
            }
        }

        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {
               
                    DataSet ds = objBL.Get_OrganizationDetails(OrgID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //string StaffPhoto = ds.Tables[0].Rows[0]["Logo"].ToString();
                    //if (StaffPhoto != null && StaffPhoto != "")
                    //{
                    //    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                    //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    //    ImageButton_logo.ImageUrl = "data:image/png;base64," + base64String;
                    //}

                    lbl_CollegeName.Text = ds.Tables[0].Rows[0][1].ToString();
                    lbl_CollegeAddress.Text = ds.Tables[0].Rows[0][12].ToString();
                    Lbl_TrustName.Text = ds.Tables[0].Rows[0][6].ToString();
                }
            }

            catch (Exception ex)
            {
                // GeneralErr(exp.Message.ToString());
                //throw;
            }
        }
    }
}
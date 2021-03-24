using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer;
using System.Data;
using Entity;
using dal;
using System.Data.SqlClient;
using System.Configuration;
using BusinessAccessLayer;
using EntityWebApp;

namespace CMS.Forms.Admin
{
    public partial class ProductKey : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        DataSet ds = new DataSet();
        database db = new database();
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        clse_productkey clse = new clse_productkey();
        clsd clsd = new clsd();
        //Objects
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

            if (!IsPostBack)
            {
                //

                orgId = Convert.ToInt32(Request.QueryString["OrgID"]);
                string ORGName = db.getDbstatus_Value("select OrgName from tblOrganization where OrganizationId='" + orgId.ToString() + "'");
                txtCollege.Text = ORGName;
                //AddCollegeToDropDown();
            }

            //if (DropDownList1.Items.Count <= 1)
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT OrgLabel FROM tblOrganization where OrganizationId='" + orgId.ToString() + "' "))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = cn;
            //        cn.Open();
            //        DropDownList1.DataSource = cmd.ExecuteReader();
            //        DropDownList1.DataTextField = "OrgLabel";
            //        DropDownList1.DataValueField = "OrgLabel";
            //        DropDownList1.DataBind();
            //        cn.Close();
            //    }

            //    DropDownList1.Items.Insert(0, new ListItem("--Select College--"));
            //}
            
        }
        #region Bind_College

        private void AddCollegeToDropDown()
        {

            //try
            //{
            //    EWA_SuperAdmin clas1 = new EWA_SuperAdmin();
            //    BL_SuperAdmin bcls = new BL_SuperAdmin();

            //    DataSet ds = bcls.AddCollegeToDropDown();

            //    DropDownList1.DataTextField = "OrgLabel";
            //    DropDownList1.DataValueField = "OrganizationId";
            //    DropDownList1.DataSource = ds;
            //    DropDownList1.DataBind();
            //    DropDownList1.Items.Insert(0, "Select");
            //}
            //catch (Exception exp)
            //{
               
            //}
        }

        #endregion Bind_College

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = db.getDbstatus_Value("selct id from Trailset1 where   OrgId='" + orgId.ToString() + "'");
            string key = db.getDbstatus_Value("select name from Productkey");
            string otpOwner = db.getDbstatus_Value("select OTPOwner from Productkey");
            if (TextBox1.Text == key.ToString() && txtOTPABC.Text == otpOwner.ToString())
            {

                if (id == null)
                {
                    db.cnopen();
                    db.insert("insert into Trailset1 values('" + txtTimePeriod.Text + "','" + txtCollege.Text + "' ,'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "') ");
                    db.cnclose();
                }
                else
                {
                    db.cnopen();
                    db.insert("update Trailset1 set date='" + txtTimePeriod.Text + "'  where OrgId='" + txtCollege.Text + "' ");
                    db.cnclose();
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Congratualtions.! Your Software now Activated ')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry.! You Should Enter Correct Product Key For Activate ')", true);

            }

            clear();
        }


        void clear()
        {
            TextBox1.Text = "";


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
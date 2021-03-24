using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

//Get Attendance Device Data
namespace CMS.Forms.Admin
{
    public partial class GetAttDeveiceData : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private EWA_DownloadAttDeviceData objEWA = new EWA_DownloadAttDeviceData();
        private BL_DownloadAttDeviceData objBL = new BL_DownloadAttDeviceData();
        public static int orgId;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
               
                if (!IsPostBack)
                {
                    BindDevices();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Device
        #region[Bind Device]

        private void BindDevices()
        {
            try
            {
                objEWA.OrgId = Convert.ToString(orgId);
                DataSet dsDesignation = objBL.BindAttDevices_BL(objEWA);
                ddlDeviceName.DataSource = dsDesignation;
                ddlDeviceName.DataTextField = "DeviceName";
                ddlDeviceName.DataValueField = "DeviceSettingId";

                ddlDeviceName.DataBind();
                ddlDeviceName.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Download Device Data
        #region[Download Device data]

        protected void lblDownloadDeviceData_Click(object sender, EventArgs e)
        {
            try
            {
                //DataSet ds = new DataSet();
                //AttServiceReference.ServiceClient ss = new AttServiceReference.ServiceClient();
             //   AttendanceServiceReference.ServiceClient ss = new AttendanceServiceReference.ServiceClient();
                //ds = ss.GetAttData("192.168.0.201", "4370");
                //ViewState["GetAttData"] = ds;
                //GrdDeviceData.DataSource = ds.Tables[0];
                //GrdDeviceData.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Device Data
        #region[Device Data]

        protected void GrdDeviceData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["GetAttData"];
                GrdDeviceData.PageIndex = e.NewPageIndex;
                GrdDeviceData.DataSource = ds.Tables[0];
                GrdDeviceData.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Attendance
        #region[Save Attendance]

        protected void btnSaveAtt_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["GetAttData"];
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dt.Columns.RemoveAt(0);
                flag = objBL.DeviceDataAction_BL(dt);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
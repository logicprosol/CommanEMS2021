using System;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

//using zkemkeeper;

//Download Attendance Data
namespace CMS.Forms.Admin
{
    public partial class DownloadAttendanceData : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private static DataSet dsAttData = new DataSet();
        public static int orgId;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                orgId = Convert.ToInt32(Session["OrgID"]);
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

        //Bind Devices
        #region[Bind Devices]

        private void BindDevices()
        {
            try
            {
                EWA_DownloadAttDeviceData objEWA = new EWA_DownloadAttDeviceData();
                BL_DownloadAttDeviceData objBL = new BL_DownloadAttDeviceData();
                objEWA.OrgId = "1";
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

        //Down Device Data
        #region[Down Device Data]

        protected void lblDownloadDeviceData_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "Started...";
                // AttendanceService.AttendanceService service = new AttendanceService.AttendanceService();

                lblMessage.Text = "Calling service for device data list...";
                //var devices = service.GetDeviceData();
                string Ip = "192.168.0.201";

                Console.WriteLine("Device list received...");

                lblMessage.Text = "Device data import starting...{0}" + Ip;
                DownloadDeviceData("192.168.0.201", "4370");
                lblMessage.Text = "Device data import Completed...{0}" + Ip;

                lblMessage.Text = "Completed reading device data...Click on Show Data..";
            }
            catch (Exception ex)
            {
                string exDetails = ex.Message + Environment.NewLine + ex.StackTrace;
                Console.WriteLine(exDetails);
            }
            Console.Read();
        }

        #endregion

        //Download Device Data
        #region[Download Device Data]

        public static void DownloadDeviceData(string ip, string PortNo)
        {
            try
            {
                //lblMessage.Text="{0}{1}==================================================================");

                //-*------------Uncoment This Run Target Solution as VS3.5 in Project Properties
                //CZKEMClass objZ;

                DataSet dsData = GetDataSet("Id", "dwMachineNumber",
                 "dwEnrollNumber",
                 "dwVerifyMode",
                 "dwInOutMode",
                 "dwYear",
                 "dwMonth",
                 "dwDay",
                 "dwHour",
                 "dwMinute",
                 "dwSecond",
                 "dwWorkCode");

                // string deviceIP = cmbDevoice.SelectedValue.ToString();
                //--*----------------- objZ = new CZKEMClass();

                //lblMessage.Text="Connecting to device...{0}"+ip;
                //--*----------------- Uncomment This
                //    if (objZ.Connect_Net(ip, int.Parse(PortNo)))
                //    {
                //        //lblMessage.Text="Connected to device...{0}", ip;

                //        while (objZ.SSR_GetGeneralLogData(dwMachineNumber,
                //          out  dwEnrollNumber,
                //          out  dwVerifyMode,
                //          out  dwInOutMode, out  dwYear,
                //          out  dwMonth, out  dwDay, out  dwHour, out  dwMinute, out  dwSecond, ref  dwWorkCode))

                //            if (dwDay == DateTime.Now.Day && dwMonth == DateTime.Now.Month && dwYear == DateTime.Now.Year)
                //            {
                //                AddRow(ref dsData, Guid.NewGuid().ToString(), dwMachineNumber.ToString(),
                //                    dwEnrollNumber.ToString(),
                //                    dwVerifyMode.ToString(),
                //                    dwInOutMode.ToString(),
                //                    dwYear.ToString(),
                //                    dwMonth.ToString(),
                //                    dwDay.ToString(),
                //                    dwHour.ToString(),
                //                    dwMinute.ToString(),
                //                    dwSecond.ToString(),
                //                    dwWorkCode.ToString());

                //                recordsReceived++;
                //            }
                //        //if(DateTime.Now.Day==dsData)

                //        dataReadCompleted = true;
                //        //lblMessage.Text="Data read completed from device...{0}"+ ip;
                //        //AttendanceService.AttendanceService service = new AttendanceService.AttendanceService();
                //        //SaveRealTimeData(dsData);

                //        dsAttData = dsData;
                //        //Console.WriteLine(string.Format("Data Save to CMS completed for device...{0}, Total records - {1}", ip, dsData.Tables[0].Rows.Count));
                //    }
                //    else
                //    {
                //        //lblMessage.Text="Connection failed...{0}"+ip;
                //        //label1.Text = "Could not connect to device, please make sure device is on and in network.Please check IP and port is correct.";
                //    }
            }

            catch (Exception ex)
            {
                string exDetails = ex.Message + Environment.NewLine + ex.StackTrace;
                // lblMessage.Text=exDetails + Environment.NewLine + Environment.NewLine + Environment.NewLine );
            }
        }

        #endregion

        //Get Data Set
        #region[Get Data Set]

        private static DataSet GetDataSet(params string[] columnName)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                foreach (var column in columnName)
                {
                    dt.Columns.Add(column);
                }

                ds.Tables.Add(dt);

                return ds;
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
                throw exp;
                //return null;
            }
        }

        #endregion

        //Add Row
        #region[Add Row]

        private static void AddRow(ref DataSet ds, params string[] columnValues)
        {
            try
            {
                DataRow drNew = ds.Tables[0].NewRow();

                int columnCounter = 0;
                foreach (var columnValue in columnValues)
                {
                    drNew[columnCounter] = columnValue.ToString();
                    columnCounter++;
                }

                ds.Tables[0].Rows.Add(drNew);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Show Real Data
        #region[Show Real Data]

        protected void btnShowRealData_Click(object sender, EventArgs e)
        {
            try
            {
                GrdDeviceData.DataSource = dsAttData;
                GrdDeviceData.DataBind();
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
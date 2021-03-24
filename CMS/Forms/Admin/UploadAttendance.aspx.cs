using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

//Upload Attendance
namespace CMS.Forms.Admin
{
    public partial class UploadAttendance : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        public static int orgId;
        #endregion
        int orgID = 0;
        //PageLoad
        #region MyRegion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                    orgID = Convert.ToInt32(Session["OrgId"]);
                    if (orgID == 0)
                    {
                        Response.Redirect("CMSHome.aspx");
                    }
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion MyRegion 

        //FileUpload

        #region FileUploadRegion

        protected void btnImportData_Click(object sender, EventArgs e)
        {
            try
            {// int orgID = Convert.ToInt32(Session["OrgId"]);
                //string SelectDate = txtDate.Text;
                if (AttFileUpload.HasFile)
                {
                    try
                    {
                        ViewState["filename"] = Path.GetFileName(AttFileUpload.FileName);
                        string filename = ViewState["filename"].ToString();
                        AttFileUpload.SaveAs(Server.MapPath("~/UploadFile/") + filename);
                        //StatusLabel.Text = "Upload status: File uploaded!";
                        msgBox.ShowMessage("File uploaded Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        GrdAttendanceReport.DataSource = FetchData();
                        GrdAttendanceReport.DataBind();
                        btnSave.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion FileUploadRegion

        //FetchData

        #region FetchDataRegion

        public DataSet FetchData()
        {
            DataSet ds = new DataSet();
            try
            {
                string Foldername = Server.MapPath("~/UploadFile");
                string filename1 = ViewState["filename"].ToString();

                string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Foldername + "/" + filename1 + ";" + "Persist Security Info=True";

                OleDbConnection cn = new OleDbConnection(conString);
                OleDbDataAdapter da = new OleDbDataAdapter("Select EmployeeId,AttendanceDate,InTime,OutTime,PunchRecords,Status from AttendanceLogs", cn);

                da.Fill(ds);

                return ds;
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return ds;
            }
        }

        #endregion FetchDataRegion

        //Page Indext Created

        #region GrdIndexChanged

        protected void GrdAttendanceReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdAttendanceReport.PageIndex = e.NewPageIndex;

                GrdAttendanceReport.DataSource = FetchData();
                GrdAttendanceReport.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion GrdIndexChanged

        //SaveAttendanceData

        #region SaveAttendanceDataRegion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAction("Save");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Action
        #region[Save Action]

        private void SaveAction(string strAction)
        {
            try
            {
                EWA_EmpStudAttendance objEWA = new EWA_EmpStudAttendance();
                BL_EmpStudAttendance objBL = new BL_EmpStudAttendance();
                DataSet dsData = new DataSet();
                dsData = FetchData();

                objEWA.EmpCode = dsData.Tables[0].Rows[0]["EmployeeId"].ToString();
                objEWA.AttendanceDate = dsData.Tables[0].Rows[0]["AttendanceDate"].ToString();
                objEWA.InTime = dsData.Tables[0].Rows[0]["InTime"].ToString();
                objEWA.OutTime = dsData.Tables[0].Rows[0]["OutTime"].ToString();
                objEWA.PunchingRecords = dsData.Tables[0].Rows[0]["PunchRecords"].ToString();
                //objEWA.Leave = dsData.Tables[0].Rows[0]["Leave"].ToString();
                objEWA.Status = dsData.Tables[0].Rows[0]["Status"].ToString();
                //Below Values Need to be pass from session
                objEWA.Action = "SaveEmpAttendance";
                objEWA.OrgId = orgId;
                DataTable dtEmpattendance = new DataTable();
                dtEmpattendance = dsData.Tables[0] as DataTable;

                int flag = objBL.SaveAction_BL(objEWA, dtEmpattendance);
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
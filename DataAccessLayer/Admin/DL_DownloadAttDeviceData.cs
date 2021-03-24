using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityWebApp.Admin;
using System.Data.SqlClient;

namespace DataAccessLayer.Admin
{
    /* =============================================
-- Author:		Deepak Sawant
-- Create date: 29/Jan/2014
-- Description:	To Perform DownloadAttDeviceData Operation
-- ============================================= */

    public class DeviceInformation
    {
        public int DeviceId { get; set; }

        public string IP { get; set; }

        public string DeviceNuber { get; set; }

        public string Port { get; set; }
    }

    public class DL_DownloadAttDeviceData
    {
        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        //SqlTransaction sqlTransaction;
        SqlCommand cmd;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion DeclareObjects

        // Bind Departments BindDepartment

        #region Bind AttDevices

        public DataSet BindAttDevices_DL(EWA_DownloadAttDeviceData objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchAttDevices";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_DownloadAttDeviceData ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        
        }

        #endregion Bind AttDevices


        public int DeviceDataAction_DL(DataTable dt)
        {
            try
            {
                cmd = new SqlCommand("SP_DownloadAttDeviceData", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@Action", "SaveDeviceData");
                cmd.Parameters.AddWithValue("@CreatedBy", HttpContext.Current.Session["UserCode"]);
                SqlParameter sqlPara = cmd.Parameters.AddWithValue("@AttendanceDeviceData", dt);
                sqlPara.SqlDbType = SqlDbType.Structured;

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
    }
}
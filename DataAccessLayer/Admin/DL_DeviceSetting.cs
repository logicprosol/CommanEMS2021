using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Device Setting
namespace DataAccessLayer.Admin
{
    public class DL_DeviceSetting
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Device Setting Table

        #region[Perform Actions On Device Setting]
        public int DeviceSettingAction_DL(EWA_DeviceSetting objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_DeviceSetting", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DeviceSettingId", objEWA.DeviceSettingId);
                cmd.Parameters.AddWithValue("@DeviceName", objEWA.DeviceName);
                cmd.Parameters.AddWithValue("@IP", objEWA.IP);
                cmd.Parameters.AddWithValue("@PortNo", objEWA.PortNo);
                cmd.Parameters.AddWithValue("@MachineId", objEWA.MachineId);
                cmd.Parameters.AddWithValue("@Description", objEWA.Description);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception exp)
            {
                int err = ((System.Data.SqlClient.SqlException)(exp)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw exp;
                }
            }
        }
        #endregion

        //To Bind DeviceGrid
        #region[Bind Device Grid]
        public DataSet BindDeviceGrid_DL(EWA_DeviceSetting objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_DeviceSetting");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DeviceSettingId");
                    dt.Columns.Add("DeviceName");
                    dt.Columns.Add("IP");
                    dt.Columns.Add("PortNo");
                    dt.Columns.Add("MachineId");
                    dt.Columns.Add("Description");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //To CheckDuplicateDevice
        #region[Check Duplicate Device]
        public int CheckDuplicateDevice_DL(EWA_DeviceSetting objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";
                prmList[2] = "@DeviceName";
                prmList[3] = objEWA.DeviceName;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_DeviceSetting");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

namespace DataAccessLayer.Admin
{
    public class DL_TimeSlotMaster
    {
        //Objects

        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion DeclareObjects

        #region Action

        public int TimeSlotAction_DL(EWA_TimeSlotMaster objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_TimeSlot", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@SlotId", objEWA.SlotId);
                cmd.Parameters.AddWithValue("@SlotFrom", objEWA.SlotFrom);
                cmd.Parameters.AddWithValue("@SlotTo", objEWA.SlotTo);
                cmd.Parameters.AddWithValue("@SlotType", objEWA.SlotType);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
        #endregion


        public DataSet GetTimeSlotData(EWA_TimeSlotMaster objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                ds = ObjHelper.FillControl(prmList, "SP_TimeSlot");
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SlotId");
                    dt.Columns.Add("TimeSlot");
                    dt.Columns.Add("SlotFrom");
                    dt.Columns.Add("SlotTo");
                    dt.Columns.Add("SlotType");
                    dt.Columns.Add("SlotTypeStr");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    ds.Tables.RemoveAt(0);
                    ds.Tables.Add(dt);
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int CheckData(EWA_TimeSlotMaster objEWA)
        {
            DataSet ds = new DataSet();
            int cnt = 0;
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@SlotFrom";
                prmList[5] = objEWA.SlotFrom;
                prmList[6] = "@SlotTo";
                prmList[7] = objEWA.SlotTo;
                prmList[8] = "@SlotId";
                prmList[9] = objEWA.SlotId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeSlot");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cnt = 1;
                }
                return cnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

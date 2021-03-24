using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Leave Type
namespace DataAccessLayer.Admin
{
    public class DL_LeaveType
    {
        //Objects
        #region [Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();

        #endregion [Declare Objects]

        //To Perform Insert,Update,Delete and Search Actions On Leave Table
        #region[Perform Actions On Leave]

        public int LeaveAction_DL(EWA_LeaveType objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Leave", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@LeaveId", objEWA.LeaveId);
                cmd.Parameters.AddWithValue("@LeaveName", objEWA.LeaveName);
                cmd.Parameters.AddWithValue("@LeaveCode", objEWA.LeaveCode);
                cmd.Parameters.AddWithValue("@LeaveCount", objEWA.LeaveCount);
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

        //To Bind LeaveGrid
        #region[Bind Leave Grid]

        public DataSet BindLeaveTypeGrid_DL(EWA_LeaveType objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = "1";
                prmList[4] = "@UserId";
                prmList[5] = "1";

                ds = ObjHelper.FillControl(prmList, "SP_Leave");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("LeaveId");
                    dt.Columns.Add("LeaveName");
                    dt.Columns.Add("LeaveCode");
                    dt.Columns.Add("LeaveCount");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();

                    return null;
                }
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        //To CheckDuplicateLeave
        #region[Check Duplicate Leave]

        public int CheckDuplicateLeave_DL(EWA_LeaveType objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";
                prmList[2] = "@LeaveName";
                prmList[3] = objEWA.LeaveName;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Leave");
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
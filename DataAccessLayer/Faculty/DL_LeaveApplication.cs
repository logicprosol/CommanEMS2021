using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Faculty;

namespace DataAccessLayer.Faculty
{
    public class DL_LeaveApplication
    {
        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion DeclareObjects

        //To Bind LeaveBalanceGrid

        #region BindLeaveBalanceGrid

        public DataSet BindLeaveBalanceGrid_DL(EWA_LeaveApplication objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@UserCode";
                prmList[5] = objEWA.UserCode.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_LeaveApplication");
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                throw exp;
            }
            return ds;
        }

        #endregion BindLeaveBalanceGrid

        //To Perform Insert,Update,Delete and Search Actions On Device Setting Table

        #region PerformActionsOnDeviceSetting

        public int LeaveApplicationAction_DL(EWA_LeaveApplication objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_LeaveApplication", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@ApplicationDate", objEWA.ApplicationDate);
                cmd.Parameters.AddWithValue("@FromDate", objEWA.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", objEWA.ToDate);
                cmd.Parameters.AddWithValue("@TotalLeave", objEWA.TotalLeave);
                cmd.Parameters.AddWithValue("@Reason", objEWA.Reason);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@LeaveStatus", objEWA.LeaveStatus);

                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@LeaveDetails", objEWA.dtLeaveDetails);  //Passing table value parameter
                tblvaluetype.SqlDbType = SqlDbType.Structured;

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception exp)
            {
                int err = ((System.Data.SqlClient.SqlException)(exp)).Number;
                if (err == 547 && objEWA.Action == "Save")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw exp;
                }
            }
        }

        #endregion PerformActionsOnDeviceSetting
    }
}
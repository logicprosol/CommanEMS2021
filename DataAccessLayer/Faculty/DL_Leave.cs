using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Faculty;

//Leave
namespace DataAccessLayer.Faculty
{
    public class DL_Leave
    {
        // Object Declaration
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Save Leave Application
        #region[Save Leave Application]
        public int DLSaveLeaveApplication(EWA_Leave objEWA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LeaveRecords", con);
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objEWA.strAction);
                cmd.Parameters.AddWithValue(@"ApplicationID", objEWA.ApplicationID);
                cmd.Parameters.AddWithValue(@"ApplicationDate", Convert.ToDateTime(objEWA.ApplicationDate));
                cmd.Parameters.AddWithValue(@"OrgID", objEWA.OrgID);
                cmd.Parameters.AddWithValue(@"UserCode", objEWA.@UserCode);
                cmd.Parameters.AddWithValue(@"LeaveTypeID", objEWA.LeaveTypeID);

                cmd.Parameters.AddWithValue(@"BalanceLeave", objEWA.BalanceLeave);
                cmd.Parameters.AddWithValue(@"leaveCategory", objEWA.leaveCategory);
                cmd.Parameters.AddWithValue(@"Subject", objEWA.subject);
                cmd.Parameters.AddWithValue(@"FromDate", Convert.ToDateTime(objEWA.fromDate));
                cmd.Parameters.AddWithValue(@"LeaveDays", objEWA.LeaveDays);
                cmd.Parameters.AddWithValue(@"ToDate", Convert.ToDateTime(objEWA.toDate));
                cmd.Parameters.AddWithValue(@"Reason", objEWA.reason);
                cmd.Parameters.AddWithValue(@"LeaveStatus", objEWA.LeaveStatus);

                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Get Application
        #region[Get Application]
        public DataSet DL_GetApplication(EWA_Leave objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectLeaveID";
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgID.ToString();

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeaveRecords");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                return ds;
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }
        #endregion


        //Get Leave Application
        #region[Get Leave Application]
        public DataSet DL_GetLeaveHistory(EWA_Leave objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "StaffLeaveHistory";
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgID.ToString();
                prmList[4] = "@UserCode";
                prmList[5] = objEWA.UserCode.ToString();

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeaveApplication");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                
            }
            catch (Exception ex)
            {
                // GeneralErr(exp.Message.ToString());
                //throw;
            }return ds;
        }
        #endregion

    }
}
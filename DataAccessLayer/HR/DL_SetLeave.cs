using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityWebApp.Admin;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Admin
{
    public class DL_SetLeave
    {
        #region DeclareObjects
        //To Fetch the Connection String From Static Class ConnectionString
        SqlConnection con = new SqlConnection(ConnectionString.consstr());
        SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        
        //To Bind EmployeeGrid
        #region  BindEmployeeGrid
        public DataSet BindEmployeeGrid_DL(EWA_SetLeave objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@SearchValue";
                prmList[5] = objEWA.SearchValue;
               

                ds = ObjHelper.FillControl(prmList, "SP_SetLeave");
              
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                throw exp;
            }
            return ds;

        }
        #endregion




        //To Bind AllEmployeeGrid
        #region  BindAllEmployeeGrid
        public DataSet BindAllEmployeeGrid_DL(EWA_SetLeave objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                


                ds = ObjHelper.FillControl(prmList, "SP_SetLeave");

            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                throw exp;
            }
            return ds;

        }
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On EmpDeptDes Table
        #region PerformActionsOnLeaveBalance
        public int SetLeaveAction_DL(EWA_SetLeave objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SetLeave", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
              // cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);                           
                cmd.Parameters.AddWithValue("@LeaveId", objEWA.LeaveId);
                cmd.Parameters.AddWithValue("@BalanceLeave", objEWA.BalanceLeave);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
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
            //finally
            //{
            //    con.Close();
            //    cmd.Dispose();
            //}
        }
        #endregion


        public int CheckDuplicateEmployee_DL(EWA_SetLeave objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.UserCode;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId.ToString();

                DataSet ds = ObjHelper.FillControl(prmList, "SP_SetLeave");
                if (ds.Tables[0].Rows.Count > 0)
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

        public DataSet BindLeaveTypeGrid_DL(EWA_SetLeave objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectLeaveData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();


                ds = ObjHelper.FillControl(prmList, "SP_SetLeave");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
               throw exp;
            }
            return ds;
        }
    }
}

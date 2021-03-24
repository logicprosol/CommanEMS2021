using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Emp Dept Design
namespace DataAccessLayer.Admin
{
    public class DL_AssignDeptDes
    {
        //objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion


        //To Perform Insert,Update,Delete and Search Actions On EmpDeptDes Table

        #region[Perform Actions On Emp Dept Des]

        public int EmpDeptDesAction_DL(EWA_AssignDeptDes objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_EmpAssignDeptDes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@DepartmentId", objEWA.DepartmentId);
                cmd.Parameters.AddWithValue("@DesignationTypeId", objEWA.DesignationTypeId);
                cmd.Parameters.AddWithValue("@DesignationId", objEWA.DesignationId);
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
        }

        #endregion

        //To Bind EmployeeGrid

        #region[Bind Employee Grid]

        public DataSet BindEmployeeGrid_DL(EWA_AssignDeptDes objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";

                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@DesignationTypeId";
                prmList[5] = objEWA.DesignationTypeId.ToString();
                prmList[6] = "@DepartmentId";
                prmList[7] = objEWA.DepartmentId.ToString();
                prmList[8] = "@DesignationId";
                prmList[9] = objEWA.DesignationId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_EmpAssignDeptDes");

                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Fetch department
        #region[Fetch Department]

        public DataSet FetchDepartment_DL(EWA_AssignDeptDes ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@UserCode";
                prmList[3] = ObjEWA.UserCode;

                ds = ObjHelper.FillControl(prmList, "SP_EmpAssignDeptDes");
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
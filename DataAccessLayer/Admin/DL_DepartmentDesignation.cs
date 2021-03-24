using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Dept Design
namespace DataAccessLayer.Admin
{
    public class DL_DepartmentDesignation
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Document Table
        #region[Perform Actions On Document]

        public int DepartmentAction_DL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DepartmentId", objEWA.DepartmentId);
                cmd.Parameters.AddWithValue("@DepartmentCode", objEWA.DepartmentCode);
                cmd.Parameters.AddWithValue("@DepartmentName", objEWA.DepartmentName);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

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

        //To Bind DocumentGrid

        #region[Bind Department Grid]

        public DataSet BindDepartmentGrid_DL(EWA_DepartmentDesignation objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Department");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    //dt.Columns.Add("DepartmentId");
                    dt.Columns.Add("DepartmentCode");
                    dt.Columns.Add("DepartmentName");

                    //dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To CheckDuplicateDocument
        #region[Check Duplicate Document]

        public int CheckDuplicateDepartment_DL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@DepartmentName";
                prmList[3] = objEWA.DepartmentName;

                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Department");
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

        #endregion CheckDuplicateDocument

        //Perform Action
        #region [Perform Actions On Designation]

        public int DesignationAction_DL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Designation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DepartmentId", objEWA.DepartmentId);
                cmd.Parameters.AddWithValue("@DesignationId", objEWA.DesignationId);
                cmd.Parameters.AddWithValue("@DesignationCode", objEWA.DesignationCode);
                cmd.Parameters.AddWithValue("@DesignationName", objEWA.DesignationName);
                cmd.Parameters.AddWithValue("@DesignationTypeId", objEWA.DesignationTypeId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

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

        //To Bind DesignationGrid
        #region[Bind Designation Grid]

        public DataSet BindDesignationGrid_DL(EWA_DepartmentDesignation objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@DepartmentId";
                prmList[5] = Convert.ToString(objEWA.DepartmentId);

                ds = ObjHelper.FillControl(prmList, "SP_Designation");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    //dt.Columns.Add("DepartmentId");
                    dt.Columns.Add("DesignationCode");
                    dt.Columns.Add("DesignationName");

                    //dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To Check Duplicate Document
        #region Check Duplicate Designation]

        public int CheckDuplicateDesignation_DL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@DesignationName";
                prmList[3] = objEWA.DesignationName;

                prmList[4] = "@DepartmentId";
                prmList[5] = Convert.ToString(objEWA.DepartmentId);

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Designation");
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

        //To Bind Dropdown Of DesignationType
        #region[Bind Designation Type]

        public DataSet BindDDLDesignationType_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchDesignationType";

                ds = ObjHelper.FillControl(prmList, "SP_Designation");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion BindDesignationType

        //Bind Department
        #region[Bind Department]

        public DataSet BindDepartment_DL(int OrgId)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchDepartment";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Department");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Login
namespace DataAccessLayer.Admin
{
    public class DL_Login
    {
        //Declare Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        #endregion

        //Check Valid User
        #region[Check Valid User]

        public DataSet CheckValidUser_DL(EWA_Login objEWA)
        {
            try
            {
                if (objEWA.UserType=="0" || objEWA.UserType == "trustee" || objEWA.UserType == "Admin" || objEWA.UserType == "Staff" || objEWA.UserType == "Student" || objEWA.UserType == "HR" || objEWA.UserType == "Inventor" || objEWA.UserType == "Librarian")
                {
                    prmList = new string[10];
                    prmList[0] = "@Action";
                    prmList[1] = "CheckData";
                    prmList[2] = "@UserType";
                    prmList[3] = objEWA.UserType;
                    prmList[4] = "@UserName";
                    prmList[5] = objEWA.UserName;
                    prmList[6] = "@Password";
                    prmList[7] = objEWA.Password;
                    prmList[8] = "@OrgId";
                    prmList[9] = objEWA.OrgId;

                    DataSet dsData = ObjHelper.FillControl(prmList, "SP_User");
                    return dsData;
                   
                }
                         
                //else if(objEWA.UserType == "trustee" ) 
                //{
                //    prmList = new string[10];
                //    prmList[0] = "@Action";
                //    prmList[1] = "CheckData";
                //    prmList[2] = "@UserType";
                //    prmList[3] = objEWA.UserType;
                //    prmList[4] = "@UserName";
                //    prmList[5] = objEWA.UserName;
                //    prmList[6] = "@Password";
                //    prmList[7] = objEWA.Password;
                //    prmList[8] = "@OrgId";
                //    prmList[9] = objEWA.OrgId;

                //    DataSet dsData = ObjHelper.FillControl(prmList, "SP_User");
                //    return dsData;
                //}

                    
                else 
                {
                    prmList = new string[8];
                    prmList[0] = "@Action";
                    prmList[1] = "CheckSuperAdmin";
                    prmList[2] = "@UserName";
                    prmList[3] = objEWA.UserName;
                    prmList[4] = "@Password";
                    prmList[5] = objEWA.Password;
                    prmList[6] = "@UserType";
                    prmList[7] = objEWA.UserType;

                    DataSet dsData = ObjHelper.FillControl(prmList, "SP_User");
                    return dsData;
                }
            }
            catch (Exception exp)
            {
                throw exp; 
            }
        }

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On User Table
        #region[Perform Actions On User]

        public int UserAction_DL(EWA_Login objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@UserType", objEWA.UserType);
                cmd.Parameters.AddWithValue("@UserName", objEWA.UserName);
                cmd.Parameters.AddWithValue("@Password", objEWA.Password);
                cmd.Parameters.AddWithValue("@Role", objEWA.Role);
                cmd.Parameters.AddWithValue("@UserTypeId", objEWA.UserTypeId);
                cmd.Parameters.AddWithValue("@Status", objEWA.Status);

                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
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

        //Get Academic Year
        #region[Get Academic Year]

        public DataSet DL_GetAcademicYear(EWA_Login objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchOrgAcademicYear";
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgId;

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_OrgDetails");
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
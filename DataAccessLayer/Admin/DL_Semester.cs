using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Semester
namespace DataAccessLayer.Admin
{
    public class DL_Semester
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

        //To Perform Insert,Update,Delete and Search Actions On Semester Table
        #region[Perform Actions On Semester]
        public int SemesterAction_DL(EWA_Semester objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Semester", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@SemesterId", objEWA.SemesterId);
                cmd.Parameters.AddWithValue("@SemesterName", objEWA.SemesterName);
                cmd.Parameters.AddWithValue("@Pattern", objEWA.Pattern);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
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

        //To Bind Semester Grid
        #region[Bind Semester Grid]
        public DataSet BindSemesterGrid_DL(EWA_Semester objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Semester");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SemesterId");
                    dt.Columns.Add("SemesterName");
                    dt.Columns.Add("Pattern");

                    dt.Rows.Add();
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

        //To CheckDuplicatePatterns
        #region[Check Duplicate Patterns]
        public int CheckDuplicatePatterns_DL(EWA_Semester objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@SemesterName";
                prmList[3] = objEWA.SemesterName;

                prmList[4] = "@ClassId";
                prmList[5] = Convert.ToString(objEWA.ClassId);

                DataSet dsData = ObjHelper.FillControl(prmList, "[SP_Semester]");
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
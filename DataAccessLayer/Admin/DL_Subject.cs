using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Subjects
namespace DataAccessLayer.Admin
{
    public class DL_Subject
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

        //To Perform Insert,Update,Delete and Search Actions On Subject Table
        #region[Perform Actions On Subject]

        public int SubjectAction_DL(EWA_Subject objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Subject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@SubjectId", objEWA.SubjectId);
                cmd.Parameters.AddWithValue("@SubjectName", objEWA.SubjectName);
                cmd.Parameters.AddWithValue("@SubjectCode", objEWA.SubjectCode);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                //cmd.Parameters.AddWithValue("@SemesterId", objEWA.SemesterId);
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

        //To Bind SubjectGrid
        #region[Bind Subject Grid]

        public DataSet BindSubjectGrid_DL(EWA_Subject objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Subject");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SubjectId");
                    dt.Columns.Add("SubjectCode");
                    dt.Columns.Add("SubjectName");

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
    }
}
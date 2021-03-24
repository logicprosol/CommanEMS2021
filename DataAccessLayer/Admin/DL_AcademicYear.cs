using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Academic Year
namespace DataAccessLayer.Admin
{
    public class DL_AcademicYear
    {
        //Objects

        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion 

        //To Perform Insert,Update,Delete and Search Actions On AcademicYear Table

        #region[Perform Actions On Academic Year]

        public int AcademicYearAction_DL(EWA_AcademicYear objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_AcademicYear", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
                cmd.Parameters.AddWithValue("@AcademicYear", objEWA.AcademicYear);
                cmd.Parameters.AddWithValue("@StartDate", objEWA.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", objEWA.EndDate);
                cmd.Parameters.AddWithValue("@Code", objEWA.Code);
                cmd.Parameters.AddWithValue("@IsCurrentYear", objEWA.IsCurrentYear);
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

        //To Bind DocumentGrid
        #region[Bind Document Grid]

        public DataSet BindAcademicYearGrid_DL(EWA_AcademicYear objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                ds = ObjHelper.FillControl(prmList, "SP_AcademicYear");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("AcademicYear");
                    dt.Columns.Add("StartDate");
                    dt.Columns.Add("EndDate");

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

        //To check IsCurrentAcademic Year
        #region[Is Current Academic Year Region]

        public int CheckAcademicYear_DL(EWA_AcademicYear objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CurrentAcademicYear";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_AcademicYear");
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

        //To CheckDuplicateDocument
        #region[Check Duplicate Document]

        public int CheckDuplicateAcademicYear_DL(EWA_AcademicYear objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@AcademicYear";
                prmList[3] = objEWA.AcademicYear;
                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_AcademicYear");
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

        //BindCurrentYear
        #region[Bind Current Year]

        public DataSet BindCurrentYear_DL(EWA_AcademicYear ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CurrentAcademicYear";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(ObjEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_AcademicYear");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
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
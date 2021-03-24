using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Caste Category
namespace DataAccessLayer.Admin
{
    public class DL_CasteCategory
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

        //Perform Action

        #region[Perform Actions On Caste Category]

        public int CasteCategoryAction_DL(EWA_CasteCategory objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_CasteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@CasteCategoryId", objEWA.CasteCategoryId);
                cmd.Parameters.AddWithValue("@CasteCategoryName", objEWA.CasteCategoryName);
                cmd.Parameters.AddWithValue("@Code", objEWA.Code);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@AcademicYearId", 0);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@TransDate", objEWA.TransDate);
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

        //Bind Caste Category
        #region[Bind Caste Category Grid]

        public DataSet BindCasteCategoryGrid_DL(EWA_CasteCategory objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_CasteCategory");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CasteCategoryName");
                    dt.Columns.Add("CasteCategorytCode");

                    // dt.Columns.Add("DocumentType");

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

        //To Check Duplicate Document
        #region[Check Duplicate Caste Category]

        public int CheckDuplicateCasteCategory_DL(EWA_CasteCategory objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@CasteCategoryName";
                prmList[3] = objEWA.CasteCategoryName;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId.ToString();

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_CasteCategory");
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
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Admin
{
    public class DL_FeesCategory
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

        #region[Perform Actions On Fees Category]

        public int FeesCategoryAction_DL(EWA_FeesCategory objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_FeesCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@FeesCategoryId", objEWA.FeesCategoryId);
                cmd.Parameters.AddWithValue("@FeesCategoryName", objEWA.FeesCategoryName);
                cmd.Parameters.AddWithValue("@Code", objEWA.Code);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
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

        //Bind Fees Category
        #region[Bind Fees Category Grid]

        public DataSet BindFeesCategoryGrid_DL(EWA_FeesCategory objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_FeesCategory");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FeesCategoryName");
                    dt.Columns.Add("FeesCategorytCode");

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
        #region[Check Duplicate Fees Category]

        public int CheckDuplicateFeesCategory_DL(EWA_FeesCategory objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@FeesCategoryName";
                prmList[3] = objEWA.FeesCategoryName;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId.ToString();

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_FeesCategory");
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

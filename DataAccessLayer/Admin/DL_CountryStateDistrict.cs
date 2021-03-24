using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Admin
{
    public class DL_CountryStateDistrict
    {

        #region[Declare Objects]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //To Bind CountryGrid
        #region[Bind Country Grid]
        public DataSet BindCountryGrid_DL(EWA_CountryStateDistrict objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                

                ds = ObjHelper.FillControl(prmList, "SP_CountryStateDistrict");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CountryId");
                    dt.Columns.Add("CountryName");

                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //dt.Rows.Add();
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

        //To CheckDuplicateCountry
        #region[Check Duplicate Country]
        public int CheckDuplicateCountry_DL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;

                prmList[2] = "@CountryName";
                prmList[3] = objEWA.CountryName;
                

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_CountryStateDistrict");
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

        //To Perform Insert,Update,Delete and Search Actions On Country Table
        #region[Perform Actions On Country]
        public int CountryAction_DL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_CountryStateDistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@CountryId", objEWA.CountryId);
                cmd.Parameters.AddWithValue("@CountryName", objEWA.CountryName);

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


        //To Perform Insert,Update,Delete and Search Actions On State Table
        #region[Perform Actions On State]
        public int StateAction_DL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_CountryStateDistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@StateId", objEWA.StateId);
                cmd.Parameters.AddWithValue("@StateName", objEWA.StateName);
                cmd.Parameters.AddWithValue("@CountryId", objEWA.CountryId);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "DeleteState")
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

        //To Bind StateGrid
        #region[Bind State Grid]
        public DataSet BindStateGrid_DL(EWA_CountryStateDistrict objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;

                prmList[2] = "@CountryId";
                prmList[3] = objEWA.CountryId;

                ds = ObjHelper.FillControl(prmList, "SP_CountryStateDistrict");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("StateId");
                    dt.Columns.Add("StateName");
                    dt.Columns.Add("CountryId");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return ds;
        }
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On District Table
        #region[Perform Actions On District]
        public int DistrictAction_DL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_CountryStateDistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DistrictId", objEWA.DistrictId);
                cmd.Parameters.AddWithValue("@StateId", objEWA.StateId);
                cmd.Parameters.AddWithValue("@DistrictName", objEWA.DistrictName);
                

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "DeleteDistrict")
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

        //To Bind DistrictGrid
        #region[Bind District Grid]
        public DataSet BindDistrictGrid_DL(EWA_CountryStateDistrict objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@StateId";
                prmList[3] = objEWA.StateId;

                ds = ObjHelper.FillControl(prmList, "SP_CountryStateDistrict");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DistrictId");
                    dt.Columns.Add("StateId");
                    dt.Columns.Add("DistrictName");

                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //dt.Rows.Add();
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

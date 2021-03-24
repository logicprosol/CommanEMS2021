using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Admin
{
    public class BL_CountryStateDistrict
    {
        //To Call Country Grid Bind
        #region[Country Grid Bind]

        public DataSet CountryGridBind_BL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
                DataSet ds = objDL.BindCountryGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Check Duplicate Data
        #region[Check Duplicate Course]

        public int CheckDuplicateCountry_BL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
                int i = objDL.CheckDuplicateCountry_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operaeion on Country Table
        #region[Action Performed]

        public int CountryAction_BL(EWA_CountryStateDistrict objEWA)
        {
            DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
            try
            {
                int flag = objDL.CountryAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //Insert Update Delete operation on State Table
        #region[Action Performed]

        public int StateAction_BL(EWA_CountryStateDistrict objEWA)
        {
            DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
            try
            {
                int flag = objDL.StateAction_DL(objEWA);
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
                // con.Close();
                // cmd.Dispose();
                objDL = null;
            }
        }

        #endregion

        //To Call StateGridBind
        #region[State Grid Bind]

        public DataSet StateGridBind_BL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
                DataSet ds = objDL.BindStateGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        //Insert Update Delete operaeion on District Table
        #region[Action Performed]

        public int DistrictAction_BL(EWA_CountryStateDistrict objEWA)
        {
            DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
            try
            {
                int flag = objDL.DistrictAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //To Call District Grid Bind
        #region[District Grid Bind]

        public DataSet DistrictGridBind_BL(EWA_CountryStateDistrict objEWA)
        {
            try
            {
                DL_CountryStateDistrict objDL = new DL_CountryStateDistrict();
                DataSet ds = objDL.BindDistrictGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}

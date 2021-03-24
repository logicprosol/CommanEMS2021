using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityWebApp.HR;
using DataAccessLayer.HR;
using System.Data;
using System.IO;
using System.Net;


namespace BusinessAccessLayer.HR
{

    public class BL_SalarySettings
    {

        //Objetcs
        #region[Objects]
        private DL_SalarySettings objDL;
        #endregion

        public int SalaryContents_BL(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                int flag = objDL.SalaryContents_DL(objEWA);
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

        public DataSet BL_BindPayGroup(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                DataSet ds = objDL.DL_BindPayGroup(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SalaryHeads_BL(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                int flag = objDL.SalaryHeads_DL(objEWA);
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

        public DataSet BL_BindSalaryHeads(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                DataSet ds = objDL.DL_BindSalaryHeads(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet BL_BindEmployeeList(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                DataSet ds = objDL.DL_BindEmployeeList(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        public int BL_UpdatePayScale(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                int flag = objDL.DL_UpdatePayScale(objEWA);
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

        public DataSet GetSalarySettings(EWA_SalarySettings objEWA)
        {
            try
            {
                objDL = new DL_SalarySettings();
                DataSet ds = objDL.DL_GetSalarySettings(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        // Save Salary A
        public int SaveSalarySlip(EWA_SalarySettings objEWA, DataTable Earnings)
        {
            try
            {
                DL_SalarySettings objDL = new DL_SalarySettings();
                int flag = objDL.DL_SaveSalarySlip(objEWA,Earnings);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }

        public DataSet SaveSalaryContent(EWA_SalarySettings objEWA)
        {
            try
            {
                DL_SalarySettings objDL = new DL_SalarySettings();
               return objDL.DL_SaveSalaryContent(objEWA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }
      

    }
}

using System;
using System.Data;
using DataAccessLayer.HR;
using EntityWebApp.HR;

//Staff HR BAL
namespace BusinessAccessLayer.HR
{
    public class BL_Staff
    {
        //Object

        #region [Objects]

        private DL_Staff objDL = new DL_Staff();

        #endregion [Objects]

        //To Fetch CourseId

        #region [Fetch StaffId]

        public DataSet GetStaffCode_BL(EWA_Staff objEWA)
        {
            try
            {
                DL_Staff objStaffClass = new DL_Staff();
                DataSet ds = objDL.GetStaffCode_DL(objEWA);
                return ds;
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

        //Insert Update Delete operaeion on Staff Table

        #region [ActionPerformed For Staff]

        public DataTable StaffAction_BL(EWA_Staff objEWA)
        {
            try
            {
                DL_Staff objDL = new DL_Staff();
                DataTable  flag = objDL.staffAction(objEWA);
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

        #endregion [ActionPerformed For Staff]

        //To Call StaffGridBind

        #region [StaffGridBind]

        public DataSet StaffGridBind_BL()
        {
            try
            {
                DL_Staff objDL = new DL_Staff();
                DataSet ds = objDL.BindStaffGrid_DL();
                return ds;
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

        #endregion [StaffGridBind]

        //To Check Duplicate Data Of Staff

        #region [CheckDuplicateStaff]

        public int CheckDuplicateStaff_BL(EWA_Staff objEWA)
        {
            try
            {
                DL_Staff objDL = new DL_Staff();
                int i = objDL.CheckDuplicateStaff_DL(objEWA);
                return i;
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

        #endregion [CheckDuplicateStaff]

        //Bind Caste Category Bind Caste Category_BL

        #region [Bind CasteCategory]

        public DataSet BindCasteCategory_BL(EWA_Staff objEWA)
        {
            try
            {
                DL_Staff objDL = new DL_Staff();
                DataSet ds = objDL.BindCasteCategory_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Bind CasteCategory]
    }
}
using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Leave Type
namespace BusinessAccessLayer.Admin
{
    public class BL_LeaveType
    {
        //Objects
        #region[Objects]
        private DL_LeaveType objDL = new DL_LeaveType();
        #endregion

        //Insert Update Delete operaeion on Leave Table
        #region[ActionPerformed For Leave]

        public int LeaveAction_BL(EWA_LeaveType objEWA)
        {
            try
            {
                int flag = objDL.LeaveAction_DL(objEWA);
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

        //To Call LeaveGridBind
        #region[Leave Grid Bind]

        public DataSet LeaveTypeGridBind_BL(EWA_LeaveType objEWA)
        {
            try
            {
                DL_LeaveType objDL = new DL_LeaveType();
                DataSet ds = objDL.BindLeaveTypeGrid_DL(objEWA);
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

        //To CheckDuplicateDataOfLeave
        #region[Check Duplicate Leave]

        public int CheckDuplicateLeave_BL(EWA_LeaveType objEWA)
        {
            try
            {
                int i = objDL.CheckDuplicateLeave_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
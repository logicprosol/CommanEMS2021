using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;
using System.Data;

namespace BusinessAccessLayer.Faculty
{
     
    public class BL_LeaveApplication
    {
        DL_LeaveApplication objDL = new DL_LeaveApplication();

        //To Call LeaveBalanceGridBind
        #region LeaveBalanceGridBind
        public DataSet LeaveBalanceGridBind_BL(EWA_LeaveApplication objEWA)
        {
            try
            {

                DataSet ds = objDL.BindLeaveBalanceGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion






        public int LeaveApplicationAction_BL(EWA_LeaveApplication objEWA)
        {
            try
            {
                int flag = objDL.LeaveApplicationAction_DL(objEWA);
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }    
        }
    }
}

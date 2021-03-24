using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.HR;
using EntityWebApp.HR;
using System.Data;

namespace BusinessAccessLayer.HR
{
     
    public class BL_LeaveStatus
    {
        DL_LeaveStatus objDL = new DL_LeaveStatus();

        //To Call LeaveDataGridBind
        #region LeaveDataGridBind
        public DataSet LeaveDataBind_BL(EWA_LeaveStatus objEWA)
        {
            try
            {
                DataSet ds = objDL.BindLeaveDataGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion


        public int LeaveApplicationAction_BL(EWA_LeaveStatus objEWA)
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

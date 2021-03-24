using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Data;

namespace BusinessAccessLayer.Admin
{
    public class BL_SetLeave
    {
        DL_SetLeave objDL = new DL_SetLeave();


       

        //To Call EmployeeGridBind
        #region EmployeeGridBind
        public DataSet EmployeeGridBind_BL(EWA_SetLeave objEWA)
        {
            try
            {
                //DL_EmployeeDeptDes objDL = new DL_EmployeeDeptDes();
                DataSet ds = objDL.BindEmployeeGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion


        //To Call AllEmployeeGridBind
        #region AllEmployeeGridBind
        public DataSet AllEmployeeGridBind_BL(EWA_SetLeave objEWA)
        {
            try
            {
                DataSet ds = objDL.BindAllEmployeeGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }        
        #endregion

        //Insert operaeion on Leave Balance Table
        #region ActionPerformed For LeaveBalance
        public int SetLeaveAction_BL(EWA_SetLeave objEWA)
        {

            try
            {

                int flag = objDL.SetLeaveAction_DL(objEWA);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    objDL = null;
            //}

        }
        #endregion

        public int CheckDuplicateEmployee_BL(EWA_SetLeave objEWA)
        {
            try
            {
                int i = objDL.CheckDuplicateEmployee_DL(objEWA);
                return i;
            }
            catch (Exception exp)
            {

                throw exp;
            }   
        }
         //To Call LeaveGridBind
        #region LeaveGridBind
        public DataSet LeaveTypeGridBind_BL(EWA_SetLeave objEWA)
        {
            
        
            try
            {
               
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
        
    }
}

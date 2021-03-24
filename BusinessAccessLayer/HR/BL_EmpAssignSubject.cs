using System;
using System.Data;
using DataAccessLayer.HR;
using EntityWebApp.HR;

//Employee Course HR BAL
namespace BusinessAccessLayer.HR
{
    public class BL_EmpAssignSubject
    {
        //Ojects
        #region[Objects]
        private DL_EmpAssignSubject objDL = new DL_EmpAssignSubject();
        #endregion

        //Insert Update Delete operaeion on EmployeeDeptDes Table
        #region [ActionPerformed For EmployeeDeptDes]

        public int EmpCourseClassAction_BL(EWA_EmpAssignSubject objEWA)
        {
            try
            {
                int flag = objDL.EmpCourseClassAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call EmployeeGridBind
        #region [EmployeeGridBind]

        public System.Data.DataSet EmployeeGridBind_BL(EWA_EmpAssignSubject objEWA)
        {
            try
            {
                DL_EmpAssignSubject objDL = new DL_EmpAssignSubject();
                DataSet ds = objDL.BindEmployeeGrid_DL(objEWA);
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

        //Fetch Subject
        #region[Fetch Subject]

        public DataSet FetchSubject_BL(EWA_EmpAssignSubject ObjEWA)
        {
            try
            {
                DL_EmpAssignSubject objDL = new DL_EmpAssignSubject();
                DataSet ds = objDL.FetchSubject_DL(ObjEWA);
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
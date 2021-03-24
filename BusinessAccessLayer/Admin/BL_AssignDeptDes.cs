using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Emp Design Dept
namespace BusinessAccessLayer.Admin
{
    public class BL_AssignDeptDes
    {
        //Objects
        #region[Objects]
        private DL_AssignDeptDes objDL = new DL_AssignDeptDes();
        #endregion


        //Insert Update Delete operaeion on EmployeeDeptDes Table
        #region[ActionPerformed For EmployeeDeptDes]

        public int EmpDeptDesAction_BL(EWA_AssignDeptDes objEWA)
        {
            try
            {
                int flag = objDL.EmpDeptDesAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call Employee Grid Bind
        #region[Employee Grid Bind]

        public System.Data.DataSet EmployeeGridBind_BL(EWA_AssignDeptDes objEWA)
        {
            try
            {
                DL_AssignDeptDes objDL = new DL_AssignDeptDes();
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

        //Course Class Action
        #region[Course Class Action]

        public int EmpCourseClassAction_BL(EWA_AssignDeptDes objEWA)
        {
            try
            {
                int flag = objDL.EmpDeptDesAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Fetch Department
        #region[Fetch Department]

        public DataSet FetchDepartment_BL(EWA_AssignDeptDes ObjEWA)
        {
            try
            {
                DL_AssignDeptDes objDL = new DL_AssignDeptDes();
                DataSet ds = objDL.FetchDepartment_DL(ObjEWA);
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
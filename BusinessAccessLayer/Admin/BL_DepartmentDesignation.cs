using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Dept Designation
namespace BusinessAccessLayer.Admin
{
    public class BL_DepartmentDesignation
    {
        //Check Duplicate for Designation
        #region[Check Duplicate Department]

        public int CheckDuplicateDepartment_BL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                int i = objDL.CheckDuplicateDepartment_DL(objEWA);
                return i;
            }

            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //ActionPerformed For Department
        #region [ActionPerformed For Department]

        public int DepartmentAction_BL(EWA_DepartmentDesignation objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                int flag = objDL.DepartmentAction_DL(objEWA);

                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call DepartmentGridBind
        #region [Department Grid Bind]

        public DataSet DepartmentGridBind_BL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                DataSet ds = objDL.BindDepartmentGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Check Duplicate for Designation
        #region[Check Duplicate Designation]

        public int CheckDuplicateDesignation_BL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                int i = objDL.CheckDuplicateDesignation_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //ActionPerformed For Designation
        #region[ActionPerformed For Designation]

        public int DesignationAction_BL(EWA_DepartmentDesignation objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                int flag = objDL.DesignationAction_DL(objEWA);

                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call Designation Grid Bind
        #region[Designation Grid Bind]

        public DataSet DesignationGridBind_BL(EWA_DepartmentDesignation objEWA)
        {
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                DataSet ds = objDL.BindDesignationGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Designation type
        #region[Bind DDL Designation Type]

        public DataSet BindDDLDesignationType_BL()
        {
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                DataSet ds = objDL.BindDDLDesignationType_DL();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Department
        #region[Bind Department]

        public DataSet BindDepartment_BL(int OrgId)
        {
            try
            {
                DL_DepartmentDesignation objDL = new DL_DepartmentDesignation();
                DataSet ds = objDL.BindDepartment_DL(OrgId);
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
using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Academic year
namespace BusinessAccessLayer.Admin
{
    public class BL_AcademicYear
    {
        //Objects

        #region [Objects]

        private DL_AcademicYear objDL = new DL_AcademicYear();

        #endregion [Objects]

        //Insert Update Delete operaeion on AcademicYear Table

        #region [Action Performed]

        public int AcademicYearAction_BL(EWA_AcademicYear objEWA)
        {
            try
            {
                DL_AcademicYear objDL = new DL_AcademicYear();
                int flag = objDL.AcademicYearAction_DL(objEWA);
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

        #endregion [Action Performed]

        //To Call AcademicYearGridBind

        #region [Academic Year Grid Bind]

        public DataSet AcademicYearGridBind_BL(EWA_AcademicYear objEWA)
        {
            try
            {
                DL_AcademicYear objDL = new DL_AcademicYear();
                DataSet ds = objDL.BindAcademicYearGrid_DL(objEWA);
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

        #endregion [Academic Year Grid Bind]

        //To check IsCurrentAcademic Year

        #region [Current Academic Year Region]

        public int CheckAcademicYear_BL(EWA_AcademicYear objEWA)
        {
            try
            {
                DL_AcademicYear objDL = new DL_AcademicYear();
                int i = objDL.CheckAcademicYear_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Current Academic Year Region]

        //To Check Duplicate Data Of Academic Year

        #region [Check Duplicate Academic Year]

        public int CheckDuplicateAcademicYear_BL(EWA_AcademicYear objEWA)
        {
            try
            {
                DL_AcademicYear objDL = new DL_AcademicYear();
                int i = objDL.CheckDuplicateAcademicYear_DL(objEWA);
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

        #endregion [Check Duplicate Academic Year]

        //Bind Current Year

        #region [Bind Current Year Region]

        public DataSet BindCurrentYear_BL(EWA_AcademicYear ObjEWA)
        {
            try
            {
                DL_AcademicYear ObjDL = new DL_AcademicYear();
                DataSet ds = ObjDL.BindCurrentYear_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Bind Current Year Region]
    }
}
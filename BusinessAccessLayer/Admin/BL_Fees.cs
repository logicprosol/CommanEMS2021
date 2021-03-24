using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Fees
namespace BusinessAccessLayer.Admin
{
    public class BL_Fees
    {
        //Objects
        #region[Objects]
        private DL_Fees objDL = new DL_Fees();
        #endregion

        //Bind Course
        #region[Bind Course]

        public DataSet BindCourses_BL(EWA_Fees objEWA)
        {
            try
            {
                DL_Fees objDL = new DL_Fees();
                DataSet ds = objDL.BindCourses_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        // Bind Class BindClass_BL
        #region[Bind Class]

        public DataSet BindClass_BL(int CourseId)
        {
            try
            {
                DL_Fees objDL = new DL_Fees();
                DataSet ds = objDL.BindClass_DL(CourseId);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Category BindCategory_BL
        #region[Bind Cast Category]

        public DataSet BindCasteCategory_BL(EWA_Fees objEWA)
        {
            try
            {
                DL_Fees objDL = new DL_Fees();
                DataSet ds = objDL.BindCategory_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Fee Id
        #region[Get Fee Id]

        public DataSet GetFeesId_BL(EWA_Fees ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                DataSet ds = ObjDL.GetFeesId_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Gridview
        #region[Bind Grid View]

        public DataSet BindGridView_BL(EWA_Fees ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                DataSet ds = ObjDL.BindGridView_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Add new row
        #region[Add new row]

        public void AddNewRow_BL(EWA_Fees ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                ObjDL.AddNewRow_DL(ObjEWA);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Perticular
        #region[Update Perticular]

        public int UpdateParticular_BL(EWA_Fees ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                return ObjDL.UpdateParticular_DL(ObjEWA);
            }
            catch (Exception)
            {
                return 0;
            }
           
        }

        #endregion

        //Delete Perticular
        #region[Delete Perticular]

        public void DeleteParticular_BL(EWA_Fees ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                ObjDL.DeleteParticular_DL(ObjEWA);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Add new fees
        #region[Add New Fee]

        public void AddNewFees_BL(EWA_Fees ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                ObjDL.AddNewFees_DL(ObjEWA);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Current Year Region
        #region[Bind Current Year Region]

        public DataSet BindAcademicYear_BL(EWA_AcademicYear ObjEWA)
        {
            try
            {
                DL_Fees ObjDL = new DL_Fees();
                DataSet ds = ObjDL.BindAcademicYear_DL(ObjEWA);
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
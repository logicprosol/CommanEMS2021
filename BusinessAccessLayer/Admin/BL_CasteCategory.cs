using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Caste Category
namespace BusinessAccessLayer.Admin
{
    public class BL_CasteCategory
    {
        //Objects

        #region [Objects]

        private DL_CasteCategory objDL = new DL_CasteCategory();

        #endregion [Objects]

        //Action Performed
        #region[ActionPerformed For CasteCategory]

        public int CasteCategoryAction_BL(EWA_CasteCategory objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_CasteCategory objDL = new DL_CasteCategory();
                int flag = objDL.CasteCategoryAction_DL(objEWA);
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

        //Caste Category Grid Bind
        #region[Caste Category Grid Bind]

        public DataSet CasteCategoryGridBind_BL(EWA_CasteCategory objEWA)
        {
            try
            {
                DL_CasteCategory objDL = new DL_CasteCategory();
                DataSet ds = objDL.BindCasteCategoryGrid_DL(objEWA);
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

        //Check Duplicate  caste category
        #region[Check Duplicate Caste Category]

        public int CheckDuplicateCasteCategory_BL(EWA_CasteCategory objEWA)
        {
            try
            {
                DL_CasteCategory objDL = new DL_CasteCategory();
                int i = objDL.CheckDuplicateCasteCategory_DL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion
    }
}
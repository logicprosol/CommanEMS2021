using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Admin
{
    public class BL_FeesCategory
    {
        //Objects

        #region [Objects]

        private DL_FeesCategory objDL = new DL_FeesCategory();

        #endregion [Objects]

        //Action Performed
        #region[ActionPerformed For FeesCategory]

        public int FeesCategoryAction_BL(EWA_FeesCategory objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_FeesCategory objDL = new DL_FeesCategory();
                int flag = objDL.FeesCategoryAction_DL(objEWA);
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

        //Fees Category Grid Bind
        #region[Fees Category Grid Bind]

        public DataSet FeesCategoryGridBind_BL(EWA_FeesCategory objEWA)
        {
            try
            {
                DL_FeesCategory objDL = new DL_FeesCategory();
                DataSet ds = objDL.BindFeesCategoryGrid_DL(objEWA);
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

        //Check Duplicate  Fees category
        #region[Check Duplicate Fees Category]

        public int CheckDuplicateFeesCategory_BL(EWA_FeesCategory objEWA)
        {
            try
            {
                DL_FeesCategory objDL = new DL_FeesCategory();
                int i = objDL.CheckDuplicateFeesCategory_DL(objEWA);
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

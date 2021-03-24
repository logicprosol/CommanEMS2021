using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Inventory;
using EntityWebApp.Inventory;
using System.Data;

namespace BusinessAccessLayer.Inventory
{
    public class BL_Category
    {
        //Objects

        #region [Objects]

        private DL_Category objDL = new DL_Category();

        #endregion [Objects]

        //Action Performed
        #region[ActionPerformed For ItemCategory]

        public int CategoryAction_BL(EWA_Category objEWA)
        {

            try
            {
                DL_Category objDL = new DL_Category();
                int flag = objDL.CategoryAction_DL(objEWA);
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Item Category Grid Bind
        #region[Item Category Grid Bind]

        public DataSet CategoryGridBind_BL(EWA_Category objEWA)
        {
            try
            {
                DL_Category objDL = new DL_Category();
                DataSet ds = objDL.BindCategoryGrid_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Check Duplicate  Item category
        #region[Check Duplicate Item Category]

        public int CheckDuplicateCategory_BL(EWA_Category objEWA)
        {
            try
            {
                DL_Category objDL = new DL_Category();
                int i = objDL.CheckDuplicateCategory_DL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion
    }
}

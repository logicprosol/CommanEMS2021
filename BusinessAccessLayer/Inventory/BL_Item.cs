using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Inventory;
using EntityWebApp.Inventory;

namespace BusinessAccessLayer.Inventory
{
    public class BL_Item
    {

        //Bind Item Category
        #region[Bind Item Category]

        public DataSet BindCategory_BL()
        {
            try
            {
                DL_Item objDL = new DL_Item();
                DataSet ds = objDL.BindCategory_DL();
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Item Unit 
        #region[Bind Item Unit]

        public DataSet BindUnit_BL(EWA_Item objEWA)
        {
            try
            {
                DL_Item objDL = new DL_Item();
                DataSet ds = objDL.BindUnit_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

      
        //Item Grid Bind
        #region[Item Grid Bind]

        public DataSet BindItemGrid_BL()
        {
            try
            {
                DL_Item objDL = new DL_Item();
                DataSet ds = objDL.BindItemGrid_DL();
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Check Duplicate  Item 
        #region[Check Duplicate Item]

        public int CheckDuplicateItem_BL(EWA_Item objEWA)
        {
            try
            {
                DL_Item objDL = new DL_Item();
                int i = objDL.CheckDuplicateItem_DL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                throw exp;
            }
           
        }

        #endregion

        //Action Performed
        #region[ActionPerformed For Item ]

        public int ItemAction_BL(EWA_Item objEWA)
        {

            try
            {
                DL_Item objDL = new DL_Item();
                int flag = objDL.ItemAction_DL(objEWA);
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion



        public DataSet GetItemCode_BL(EWA_Item objEWA)
        {
            try
            {
                DL_Item objDL = new DL_Item();
                DataSet ds = objDL.GetItemCode_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}

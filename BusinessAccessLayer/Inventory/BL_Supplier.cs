using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityWebApp.Inventory;
using DataAccessLayer.Inventory;

namespace BusinessAccessLayer.Inventory
{
    public class BL_Supplier
    {
        //Bind Supplier Category
        #region[Bind Supplier Category]

        public DataSet BindCategory_BL()
        {
            try
            {
                DL_Supplier objDL = new DL_Supplier();
                DataSet ds = objDL.BindCategory_DL();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        //Item Grid Bind
        #region[Item Grid Bind]

        public DataSet BindItemGrid_BL(EWA_Supplier objEWA)
        {
            try
            {
                DL_Supplier objDL = new DL_Supplier();
                DataSet ds = objDL.BindItemGrid_DL(objEWA);
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

        public DataSet BindSupplierData_BL(EWA_Supplier objEWA)
        {
            try
            {
                DL_Supplier objDL = new DL_Supplier();
                DataSet ds = objDL.BindSupplierData_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Supplier Grid Bind
        #region[Supplier Grid Bind]

        public DataSet BindSupplierGrid_BL(EWA_Supplier objEWA)
        {
            try
            {
                DL_Supplier objDL = new DL_Supplier();
                DataSet ds = objDL.BindSupplierGrid_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Check Duplicate  Supplier 
        #region[Check Duplicate Supplier]

        public int CheckDuplicateSupplier_BL(EWA_Supplier objEWA)
        {
            try
            {
                DL_Supplier objDL = new DL_Supplier();
                int i = objDL.CheckDuplicateSupplier_DL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Action Performed
        #region[ActionPerformed For Supplier ]

        public int SupplierAction_BL(EWA_Supplier objEWA,DataTable dt)
        {

            try
            {
                DL_Supplier objDL = new DL_Supplier();
                int flag = objDL.SupplierAction_DL(objEWA,dt);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

     
    }
}

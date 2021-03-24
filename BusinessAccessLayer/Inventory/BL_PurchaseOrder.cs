using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityWebApp.Inventory;
using DataAccessLayer.Inventory;

namespace BusinessAccessLayer.Inventory
{
    public class BL_PurchaseOrder
    {

        //To Fetch CourseId

        #region [Fetch POCode]

        public DataSet GetPOCode_BL(EWA_PurchaseOrder objEWA)
        {
            try
            {
                DL_PurchaseOrder objDL = new DL_PurchaseOrder();
                DataSet ds = objDL.GetPOCode_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            
        }

        #endregion 
        //Bind Supplier Category
        #region[Bind Supplier Category]

        public DataSet BindSupplier_BL(EWA_PurchaseOrder objEWA)
        {
            try
            {
                DL_PurchaseOrder objDL = new DL_PurchaseOrder();
                DataSet ds = objDL.BindSupplier_DL(objEWA);
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

        public DataSet BindItemGrid_BL(EWA_PurchaseOrder objEWA)
        {
            try
            {
                DL_PurchaseOrder objDL = new DL_PurchaseOrder();
                DataSet ds= objDL.BindItemGrid_DL(objEWA);
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

        public DataSet POAction_BL(EWA_PurchaseOrder objEWA, DataTable dt)
        {
            DataSet ds = new DataSet();
            try
            {
                DL_PurchaseOrder objDL = new DL_PurchaseOrder();
              ds = objDL.POAction_DL(objEWA, dt);
                
            }
            catch (Exception)
            {
                //throw;
            }
return ds;
        }

        #endregion
    }
}

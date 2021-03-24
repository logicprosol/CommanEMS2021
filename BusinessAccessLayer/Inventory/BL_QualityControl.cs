using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Inventory;
using EntityWebApp.Inventory;

namespace BusinessAccessLayer.Inventory
{
    public class BL_QualityControl
    {
        //To Fetch QCId

        #region [Fetch QCCode]

        public DataSet GetQCCode_BL(EWA_QualityControl objEWA)
        {
            try
            {
                DL_QualityControl objDL = new DL_QualityControl();
                DataSet ds = objDL.GetQCCode_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //To Fetch POCode

        #region [Fetch POCode]

        public DataSet GetPOCode_BL(EWA_QualityControl objEWA)
        {
            try
            {
                DL_QualityControl objDL = new DL_QualityControl();
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

        public DataSet BindSupplier_BL(EWA_QualityControl objEWA)
        {
            try
            {
                DL_QualityControl objDL = new DL_QualityControl();
                DataSet ds = objDL.BindSupplier_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Supplier Category
        #region[Bind PO Details]

        public DataSet BindPODetails_BL(EWA_QualityControl objEWA)
        {
            try
            {
                DL_QualityControl objDL = new DL_QualityControl();
                DataSet ds = objDL.BindPODetails_DL(objEWA);
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

        public DataSet BindItemGrid_BL(EWA_QualityControl objEWA)
        {
            try
            {
                DL_QualityControl objDL = new DL_QualityControl();
                DataSet ds = objDL.BindItemGrid_DL(objEWA);
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

        public DataSet BindSupplierGrid_BL()
        {
            try
            {
                //EWA_QualityControl objEWA = new EWA_QualityControl();
                //objEWA.OrgId = orgId;
                //DL_Supplier objDL = new DL_Supplier();
                DataSet ds = null;// = objDL.BindSupplierGrid_DL();
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

        public int QCAction_BL(EWA_QualityControl objEWA, DataTable dt)
        {

            try
            {
                DL_QualityControl objDL = new DL_QualityControl();
                int flag = objDL.QCAction_DL(objEWA, dt);
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

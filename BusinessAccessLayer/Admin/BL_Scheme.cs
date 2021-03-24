using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Scheme
namespace BusinessAccessLayer.Admin
{
    public class BL_Scheme
    {
        //Objects
        #region[Objects]
        //private DL_Scheme objDL = new DL_Scheme();
        #endregion

        //Get Scheme
        #region[Get Scheme]
        public DataSet GetScheme_BL(EWA_Scheme ObjEWA)
        {
            try
            {
                DL_Scheme objDL = new DL_Scheme();
                DataSet ds = objDL.GetScheme_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Get Data
        #region[Get Data]

        public DataSet BindScheme_BL(EWA_Scheme ObjEWA)
        {
            try
            {
                DL_Scheme objDL = new DL_Scheme();
                DataSet ds = objDL.BindScheme_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Delete Scheme
        #region[Bind Class]

        public DataSet DeleteScheme_BL(EWA_Scheme ObjEWA)
        {
            try
            {
                DL_Scheme objDL = new DL_Scheme();
                DataSet ds = objDL.DeleteScheme_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Scheme
        #region[Insert Scheme]

        public DataSet InsertScheme_BL(EWA_Scheme objEWA)
        {
            try
            {
                DL_Scheme objDL = new DL_Scheme();
                DataSet ds = objDL.InsertScheme_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Scheme
        #region[Update Scheme]

        public DataSet UpdateScheme_BL(EWA_Scheme objEWA)
        {
            try
            {
                DL_Scheme objDL = new DL_Scheme();
                DataSet ds = objDL.UpdateScheme_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public int SchemeAction_BL(EWA_Scheme objEWA)
        {
            try
            {

                DL_Scheme objDL = new DL_Scheme();
                int flag = objDL.SchemeAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet SchemeGridBind_BL(EWA_Scheme objEWA)
        {
            try
            {
                DL_Scheme objDL = new DL_Scheme();
                DataSet ds = objDL.SchemeGridBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
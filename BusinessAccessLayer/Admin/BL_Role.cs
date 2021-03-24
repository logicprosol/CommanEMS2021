using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Role
namespace BusinessAccessLayer.Admin
{
    public class BL_Role
    {
        //Objects
        #region[Objects]
        //private DL_Scheme objDL = new DL_Scheme();
        #endregion

        //Get Role
        #region[Get Role]
        public DataSet GetRole_BL(EWA_Role ObjEWA)
        {
            try
            {
                DL_Role objDL = new DL_Role();
                DataSet ds = objDL.GetRole_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Update Role
        #region[Update Role]

        public DataSet UpdateRole_BL(EWA_Role ObjEWA)
        {
            try
            {
                DL_Role objDL = new DL_Role();
                DataSet ds = objDL.UpdateRole_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Delete Role
        #region[Bind Class]

        public DataSet DeleteRole_BL(EWA_Role ObjEWA)
        {
            try
            {
                DL_Role objDL = new DL_Role();
                DataSet ds = objDL.DeleteRole_DL(ObjEWA);
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
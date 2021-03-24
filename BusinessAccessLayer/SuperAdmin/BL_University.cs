using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.SuperAdmin;
using EntityWebApp.SuperAdmin;

//Super Admin
namespace BusinessAccessLayer.SuperAdmin
{
    public class BL_University
    {
        #region [Objects]

        private DL_University objDL = new DL_University();

        #endregion [Objects]

        //Insert Update Delete operaeion on Document Table

        #region [Action Performed]

        public int UniversityAction_BL(EWA_University objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_University objDL = new DL_University();
                int flag = objDL.UniversityAction_DL(objEWA);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion [Action Performed]

        //To Call University GridBind

        #region [University GridBind]

        public DataSet UniversityGridBind_BL()
        {
            try
            {
                DL_University objDL = new DL_University();
                DataSet ds = objDL.BindUniversityGrid_DL();
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

        #endregion [University GridBind]

        //To Check Duplicate Data Of University

        #region [Check Duplicate University]

        public int CheckDuplicateUniversity_BL(EWA_University objEWA)
        {
            try
            {
                DL_University objDL = new DL_University();
                int i = objDL.CheckDuplicateUniversity_DL(objEWA);
                return i;
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

        #endregion [Check Duplicate University]

        //Image Logo

        #region [get Image Logo]

        public SqlDataReader getImageLogo_BL(string UniversityName)
        {
            try
            {
                SqlDataReader dr = null;

                dr = objDL.getImageLogo_DL(UniversityName);

                return dr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [get Image Logo]
    }
}
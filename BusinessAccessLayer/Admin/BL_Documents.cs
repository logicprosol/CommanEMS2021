using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Documents
namespace BusinessAccessLayer.Admin
{
    public class BL_Documents
    {
        //Documents_BL
        #region[Objects]
        private DL_Documents objDL = new DL_Documents();
        #endregion

        //Insert Update Delete operaeion on Document Table
        #region[Action Performed For Documents]

        public int DocumentAction_BL(EWA_Documents objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_Documents objDL = new DL_Documents();
                int flag = objDL.DocumentAction_DL(objEWA);
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

        //To Call Documents GridBind
        #region[Documents Grid Bind]

        public DataSet DocumentsGridBind_BL(EWA_Documents objEWA)
        {
            try
            {
                DL_Documents objDL = new DL_Documents();
                
                DataSet ds = objDL.BindDocumentGrid_DL(objEWA);
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

        //To Check Duplicate Data Of Documents
        #region[Check Duplicate Document]

        public int CheckDuplicateDocuments_BL(EWA_Documents objEWA)
        {
            try
            {
                DL_Documents objDL = new DL_Documents();
                int i = objDL.CheckDuplicateDocument_DL(objEWA);
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

        #endregion
    }
}
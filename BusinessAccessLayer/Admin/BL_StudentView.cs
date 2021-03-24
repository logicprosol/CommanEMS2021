using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Student View
namespace BusinessAccessLayer.Admin
{
    public class BL_StudentView
    {
        //Object
        #region[Objects]
        private DL_StudentView objDAL = new DL_StudentView();
        #endregion

        //Student Id
        #region[Student Id]

        public DataSet BL_StudentViewId(EWA_StudentView objEWA)
        {
            try
            {
                DataSet ds = objDAL.DL_ShowStudentViewProfile(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        // Bind GrdId GrdId_BL
        #region[Bind GrdId]

        public DataSet BL_StudentIcard(EWA_StudentView objEWA)
        {
            try
            {
                DataSet ds = objDAL.DL_StudentIcard(objEWA);
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
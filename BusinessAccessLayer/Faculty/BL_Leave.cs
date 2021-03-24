using System;
using System.Data;
using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;

//Faculty Leave
namespace BusinessAccessLayer.Faculty
{
    public class BL_Leave
    {
        //Objects
        #region[Objects]
        private DL_Leave objDL = new DL_Leave();
        #endregion

        // Faculty Leave Application
        #region [Save Leave Application]

        public int BLSaveLeaveApplication(EWA_Leave objEWA)
        {
            try
            {
                int flag = objDL.DLSaveLeaveApplication(objEWA);

                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Application
        #region[Get Application]

        public DataSet BL_GetApplication(EWA_Leave objEWA)
        {
            try
            {
                DataSet ds = objDL.DL_GetApplication(objEWA);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Leave History
        #region[Get Leave History]

        public DataSet BL_GetLeaveHistory(EWA_Leave objEWA)
        {
            try
            {
                DataSet ds = objDL.DL_GetLeaveHistory(objEWA);

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
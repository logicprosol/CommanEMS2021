using System;
using System.Data;
using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;

//Faculty
namespace BusinessAccessLayer.Faculty
{
    public class BL_Faculty
    {
        //Objects
        #region[Objects]
        private DL_Faculty objDAL = new DL_Faculty();
        #endregion

        //Faculty Profile
        #region[Faculty Profile]

        public DataSet BL_ShowFacultyProfile(EWA_Faculty objEWA)
        {
            try
            {
                DL_Faculty objDL = new DL_Faculty();
                DataSet ds = objDL.DL_ShowFacultyProfile(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //get Employee Record
        #region[get Employee Record]

        public DataSet BL_GetEmployeeRecord(EWA_Faculty objEWA)
        {
            try
            {
                DL_Faculty objDL = new DL_Faculty();
                //DataSet ds = objDL.UpdateStaffRecord_DL(objEWA);
                DataSet ds = objDL.DL_GetEmployeeRecord(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Faculty Profile
        #region [Update Faculty Profile]

        public int BL_UpdateFaculty(EWA_Faculty objEWA)
        {
            DL_Faculty objDL = new DL_Faculty();
            try
            {
                int flag = objDL.DL_UpdateFaculty(objEWA);
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
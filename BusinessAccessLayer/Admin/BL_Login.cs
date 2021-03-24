using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
    public class BL_Login
    {
        //To CheckValidUser_DL

        #region[Check Valid User]
        public DataSet CheckValidUser_BL(EWA_Login objEWA)
        {
            try
            {
                DL_Login objDL = new DL_Login();
                DataSet ds = objDL.CheckValidUser_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Insert Update Delete operaeion on User Information Table
        #region[Action Performed For Login]
        public int UserAction_BL(EWA_Login objEWA)
        {
            
            try
            {
                DL_Login objDL = new DL_Login();
                int flag = objDL.UserAction_DL(objEWA);
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //Get Academic Year
        #region[Get Academic Year]
        public DataSet BL_GetAcademicYear(EWA_Login objEWA)
        {
            try
            {
                DL_Login objDL = new DL_Login();
                DataSet ds = objDL.DL_GetAcademicYear(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion
    }
}
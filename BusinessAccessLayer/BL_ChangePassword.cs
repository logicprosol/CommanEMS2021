using System;
using System.Data;
using DataAccessLayer;
using EntityWebApp;

//Chnage Password Business Layer
namespace BusinessAccessLayer
{
    public class BL_ChangePassword
    {
        //Chnage Password
        #region[Chnage Password]

        public DataSet ChangePassword(EWA_ChangePassword objEWA)
        {
            DataSet ds=new DataSet();
            try
            {
                DL_ChangePassword objDL=new DL_ChangePassword();
                ds=objDL.ChangePassword(objEWA);
                return ds;
            }
            catch(Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
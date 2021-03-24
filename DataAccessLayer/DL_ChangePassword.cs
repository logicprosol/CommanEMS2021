using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp;

//Change Password Data Access Layer
namespace DataAccessLayer
{
    public class DL_ChangePassword
    {
        // Object Declaration
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Change Password
        #region[Change Password]

        public DataSet ChangePassword(EWA_ChangePassword objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "ChangePassword";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.UserCode;
                prmList[4] = "@OldPassword";
                prmList[5] = objEWA.OldPassword;
                prmList[6] = "@NewPassword";
                prmList[7] = objEWA.NewPassword;

                ds = ObjHelper.FillControl(prmList, "SP_ChangePassword");
                
                return ds;
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion
    }
}
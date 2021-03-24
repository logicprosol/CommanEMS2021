using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Scheme
namespace DataAccessLayer.Admin
{
    public class DL_Role
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        #endregion

        //Get Role
        #region[Get Role]

        public DataSet GetRole_DL(EWA_Role ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetRole";
                prmList[2] = "@OrganizationId";
                prmList[3] = ObjEWA.OrganizationId.ToString();
                prmList[4] = "@UserType";
                prmList[5] = ObjEWA.UserType;

                ds = ObjHelper.FillControl(prmList, "SP_Role");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Role
        #region[Get Data]

        public DataSet UpdateRole_DL(EWA_Role ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "UpdateRole";
                prmList[2] = "@OrganizationId";
                prmList[3] = ObjEWA.OrganizationId.ToString();
                prmList[4] = "@UserType";
                prmList[5] = ObjEWA.UserType.ToString();
                prmList[6] = "@UserCode";
                prmList[7] = ObjEWA.UserId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Role");
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

        public DataSet DeleteRole_DL(EWA_Role ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "DeleteRole";
                prmList[2] = "@OrganizationId";
                prmList[3] = ObjEWA.OrganizationId.ToString();
                prmList[4] = "@UserCode";
                prmList[5] = ObjEWA.UserId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Role");
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
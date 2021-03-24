using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityWebApp.Admin;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Admin
{
    public class DL_SendSMS
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        // Bind Courses BindCourses_DL
        #region[Bind Course Region]

        public DataSet BindCourses_DL(EWA_SendSMS ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCourses";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_SendSMS");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
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

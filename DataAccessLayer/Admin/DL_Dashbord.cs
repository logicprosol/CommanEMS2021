using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntityWebApp.Admin;

namespace DataAccessLayer.Admin
{
    public class DL_Dashbord
    {
        //Objects

        EWA_Dashbord objEWA = new EWA_Dashbord();

        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

      



        #region[Bind Caste Category Grid]

        public DataSet DL_GetData(EWA_Dashbord objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetDashBordData";
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_ChartData");
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    ds = null; 
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

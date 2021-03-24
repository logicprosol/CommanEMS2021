using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

namespace DataAccessLayer.Reports
{
    public class DL_HandicapEmpReport
    {
        // Object Declaration

        #region[Object Declaration]
        //private SqlConnection con = new SqlConnection(ConnectionString.consstr());
       // private SqlCommand cmd;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        // Bind Paid Receipt Report
        #region[Paid Receipt Report]
        public DataSet BindHandicapEmpListReport(int OrgId)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "HandicapEmpList";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_EmployeesReport");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

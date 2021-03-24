using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityWebApp.Reports;

namespace DataAccessLayer.Reports
{
   public class DL_CommonReports
    {
//
        #region[Object Declaration]
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion
        // Bind Reports Header
        #region[Bind Reports Header]
        public DataSet DL_BindReportsHeader(EWA_CommonReports objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@ViewName";
                prmList[1] = objEWA.ViewName;
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_GetReportData");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        // Bind Reports Data
        #region[Bind Reports Data]
        public DataSet DL_BindReports(EWA_CommonReports objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@ViewName";
                prmList[1] = objEWA.ViewName;
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_GetReportData");
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

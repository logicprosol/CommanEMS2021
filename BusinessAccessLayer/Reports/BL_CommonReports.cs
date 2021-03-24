using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityWebApp.Reports;
using DataAccessLayer.Reports;

namespace BusinessAccessLayer.Reports
{
    public class BL_CommonReports
    {
        // Bind Reports Header
        #region[Bind Reports Header]
        public DataSet BL_BindReportsHeader(EWA_CommonReports objEWA)
        {     
        try
        {
            DataSet ds = new DataSet();
            DL_CommonReports objDL = new DL_CommonReports();
            ds=objDL.DL_BindReportsHeader(objEWA);
             return ds;
        }
            catch(Exception exp)
        {
            throw exp;
            }

        }
        #endregion
          // Bind Reports Data
        #region[Bind Reports Data]
        public DataSet BL_BindReports(EWA_CommonReports objEWA)
        {    
        try
        {
            DataSet ds = new DataSet();
            DL_CommonReports objDL = new DL_CommonReports();
            ds = objDL.DL_BindReports(objEWA);
             return ds;
        }
            catch(Exception exp)
        {
            throw exp;
            }

        }
        #endregion
       
    }
}

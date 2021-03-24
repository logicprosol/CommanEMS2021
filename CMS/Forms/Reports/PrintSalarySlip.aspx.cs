using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DataAccessLayer.HR;
using EntityWebApp.HR;
using System.Data;

namespace CMS.Forms.Reports
{
    public partial class PrintSalarySlip : System.Web.UI.Page
    {
        //Report Doc
        private string DBServerName = string.Empty;

        private string Database = string.Empty;
        private string DBUserId = string.Empty;
        private string DBPassword = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                Session.Remove("CR_Session");
                //Session.Clear();
                DBServerName = ConfigurationManager.AppSettings["ServerName"].ToString();
                Database = ConfigurationManager.AppSettings["DataBaseName"].ToString();
                DBUserId = ConfigurationManager.AppSettings["DBUserID"].ToString();
                DBPassword = ConfigurationManager.AppSettings["DBPassword"].ToString();
              
                GetReportData();
            }
            crvPrintSalarySlip.ReportSource = Session["CR_Session"];  //Set Report Source for Viewer
        }

        private void GetReportData()
        {
            crEmployeePaySlip crt = new crEmployeePaySlip();
            EWA_SalarySettings objEWA = new EWA_SalarySettings();
            DL_SalarySettings objDL = new DL_SalarySettings();

            String EmpCode = Session["EmpCode"].ToString();
            objEWA.UserCode = EmpCode;
            objEWA.SalaryMonth = Session["PayMonth"].ToString();

            DataSet ds = objDL.BindSalarySlipReport(objEWA);

            crt.SetDataSource(ds.Tables[0]);
            crvPrintSalarySlip.ReportSource = crt;
            crvPrintSalarySlip.RefreshReport();

            Session.Add("CR_Session", crt);  //Add Report into Session CR_Session
        }
    }

}
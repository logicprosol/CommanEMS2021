using System;
using System.Configuration;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace CMS.Forms.Reports
{
    public partial class PrintFeesReciept1 : System.Web.UI.Page
    {
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
            crvPrintfeesReceipt.ReportSource = Session["CR_Session"];  //Set Report Source for Viewer
        }

        private void GetReportData()
        {
            crFeesReceipt crt = new crFeesReceipt();
            EWA_PayFees objEWA = new EWA_PayFees();
            DL_PayFees objDL = new DL_PayFees();
            String StudCode = Session["StudentReceiptCode"].ToString();
            objEWA.StudentCode = StudCode;
            DataSet ds = objDL.BindPaidReceiptReport(objEWA);
            crt.SetDataSource(ds.Tables[0]);
            crvPrintfeesReceipt.ReportSource = crt;
            crvPrintfeesReceipt.RefreshReport();
            Session.Add("CR_Session", crt);  //Add Report into Session CR_Session
        }
    }
}
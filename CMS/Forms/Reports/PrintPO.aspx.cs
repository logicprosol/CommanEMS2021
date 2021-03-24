using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using EntityWebApp.Inventory;
using DataAccessLayer.Inventory;
using System.Data;

namespace CMS.Forms.Reports
{
    public partial class PrintPO : System.Web.UI.Page
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
            crvPO.ReportSource = Session["CR_Session"];  //Set Report Source for Viewer
        }

        private void GetReportData()
        {
            crPurchaseOrder crt = new crPurchaseOrder();
            EWA_PurchaseOrder objEWA = new EWA_PurchaseOrder();
            DL_PurchaseOrder objDL = new DL_PurchaseOrder();
            String POCode = Session["POCode"].ToString();
            objEWA.POCode = POCode;
            DataSet ds = objDL.BindPurchaseOrderReport(objEWA);
            crt.SetDataSource(ds.Tables[0]);

            crvPO.ReportSource = crt;
            crvPO.RefreshReport();
            Session.Add("CR_Session", crt);  //Add Report into Session CR_Session
        }

    }
}
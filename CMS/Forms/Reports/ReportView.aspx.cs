using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace CMS.Forms.Reports
{
    public partial class ReportView : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ReportDocument ReportObj=null;


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = string.Format("CMS : Report Viewer " + DateTime.Now.ToString("dd/MM/yyyy"));
            if (!IsPostBack)
            {
                GetReportData();
            }
           
            
        }

        private CrystalDecisions.Shared.TableLogOnInfo ReportLog()
        {
            CrystalDecisions.Shared.TableLogOnInfo crLogonInfo;
            crLogonInfo = ReportObj.Database.Tables[0].LogOnInfo;
            crLogonInfo.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["ServerName"].ToString();
            crLogonInfo.ConnectionInfo.UserID = ConfigurationManager.AppSettings["DBUserID"].ToString();
            crLogonInfo.ConnectionInfo.Password = ConfigurationManager.AppSettings["DBPassword"].ToString();
            crLogonInfo.ConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["DataBaseName"].ToString();
            return crLogonInfo;
        }

        public void GetReportData()
        {
            string RptName = string.Empty;
            RptName = Request.QueryString["ReportName"].ToString();
            switch (RptName)
            {
                case "rptHandicapEmpList":
                    {
                        ReportObj = new crHandicapEmpList();
                        dataset = new DataSet();
                        dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                        ReportObj.SetDataSource(dataset.Tables[0]);
                        break;
                    }                

                default:
                    break;
            }

            ReportObj.Database.Tables[0].ApplyLogOnInfo(ReportLog());
            CrystalReportViewer1.ReportSource = ReportObj;
            CrystalReportViewer1.RefreshReport();
            //Session["ReportFormat"] = "PDF";
            if (Session["ReportFormat"] != null)
            {
                if (Session["ReportFormat"].ToString() == "PDF")
                {
                    System.IO.MemoryStream oStream;
                    oStream = (System.IO.MemoryStream)
                    ReportObj.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(oStream.ToArray());
                    Response.End();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using EntityWebApp.Reports;
using BusinessAccessLayer.Reports;
using CrystalDecisions.Shared;

namespace CMS.Forms.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ReportDocument ReportObj;
        private ReportDocument subRepDoc;

        private Sections crSections;
        private ReportObjects crReportObjects;
        private SubreportObject crSubreportObject;
        private Database crDatabase;
        private Tables crTables;
        private TableLogOnInfo crTableLogOnInfo;
        private ConnectionInfo crConnectionInfo;
        private string DBServerName = string.Empty;
        private string Database = string.Empty;
        private string DBUserId = string.Empty;
        private string DBPassword = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = string.Format("CMS : Report Viewer " + DateTime.Now.ToString("dd/MM/yyyy"));
                if(!IsPostBack)
                {
                DBServerName = ConfigurationManager.AppSettings["ServerName"].ToString();
                Database = ConfigurationManager.AppSettings["DataBaseName"].ToString();
                DBUserId = ConfigurationManager.AppSettings["DBUserID"].ToString();
                DBPassword = ConfigurationManager.AppSettings["DBPassword"].ToString();

                GetReportData();
                }
            }
            catch (Exception exp)
            {

                GeneralErr(exp.Message.ToString());
            }
          
        }

        private void GetReportData()
        {
           DataSet dsMaster = new DataSet();
           EWA_CommonReports objEWA = new EWA_CommonReports();
           BL_CommonReports objBL = new BL_CommonReports();
           string RecSelFormula = string.Empty;
           objEWA.ViewName = "vwReportHeader";
            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
            dsMaster = objBL.BL_BindReportsHeader(objEWA);

            if (Request.QueryString["ReportName"] != null)
            {
                string RptName = string.Empty;
                RptName = Request.QueryString["ReportName"].ToString();

                switch (RptName)
                {
                    case "rptHandicapEmpList":
                        {
                            ReportObj = new CMS.Forms.Reports.crHandicapEmpList();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }
                    case "rptHandicapStudList":
                        {
                            ReportObj = new CMS.Forms.Reports.crHandicapStudList();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }
                    case "rptSportsStudList":
                        {
                            ReportObj = new CMS.Forms.Reports.crSportsStudList();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }
                    case "rptGovernmentSchemes":
                        {
                            ReportObj = new CMS.Forms.Reports.crGovernmentScheme();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }
                    case "crStudentList":
                        {
                            ReportObj = new CMS.Forms.Reports.crStudentList();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }
                    case "crStudentAdmissionList":
                        {
                            ReportObj = new CMS.Forms.Reports.crStudentAdmissionList();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }
                    case "crPurchaseOrder":
                        {
                            ReportObj = new CMS.Forms.Reports.crPurchaseOrder();
                            dataset = new DataSet();
                            dataset = (DataSet)HttpContext.Current.Session["ReportData"];
                            ReportObj.SetDataSource(dataset.Tables[0]);
                            ReportObj.Subreports["crReportHeader.rpt"].SetDataSource(dsMaster);
                            ReportObj.Subreports["crReportHeader.rpt"].RecordSelectionFormula = "{vwReportHeader.OrganizationId}=" + HttpContext.Current.Session["OrgId"].ToString();
                            break;
                        }

                    default:
                     break;

                }

                if (null != ReportObj)
                {
                    crTableLogOnInfo = new TableLogOnInfo();
                    crConnectionInfo = new ConnectionInfo();

                    //Crystal Report Properties
                    //	CrystalDecisions.CrystalReports.Engine.Table crTable;
                    crConnectionInfo.ServerName = DBServerName;
                    crConnectionInfo.DatabaseName = Database;
                    crConnectionInfo.UserID = DBUserId;
                    crConnectionInfo.Password = DBPassword;
                    crDatabase = ReportObj.Database;
                    crTables = crDatabase.Tables;

                    foreach (CrystalDecisions.CrystalReports.Engine.Table crTable1 in crTables)
                    {
                        crTableLogOnInfo = crTable1.LogOnInfo;
                        crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                        crTable1.ApplyLogOnInfo(crTableLogOnInfo);
                    }

                    //'Set the sections collection with report sections

                    crSections = ReportObj.ReportDefinition.Sections;

                    //'Loop through each section and find all the report objects
                    //'Loop through all the report objects to find all subreport objects, then set the
                    //'logoninfo to the subreport

                    foreach (Section crSection in crSections)
                    {
                        crReportObjects = crSection.ReportObjects;
                        foreach (ReportObject crReportObject in crReportObjects)
                        {
                            if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                            {
                                //'If you find a subreport, typecast the reportobject to a subreport object
                                crSubreportObject = (SubreportObject)crReportObject;

                                //'Open the subreport
                                subRepDoc = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);

                                crDatabase = subRepDoc.Database;
                                crTables = crDatabase.Tables;

                                //'Loop through each table and set the connection info
                                //'Pass the connection info to the logoninfo object then apply the
                                //'logoninfo to the subreport

                                foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
                                {
                                    crConnectionInfo.ServerName = DBServerName;
                                    crConnectionInfo.DatabaseName = Database;
                                    crConnectionInfo.UserID = DBUserId;
                                    crConnectionInfo.Password = DBPassword;

                                    crTableLogOnInfo = crTable.LogOnInfo;
                                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                                    crTable.ApplyLogOnInfo(crTableLogOnInfo);
                                    crTable.Location = crTable.Name;
                                }
                            }
                        }
                    }

                    CrystalReportViewer1.SeparatePages = true;
                    CrystalReportViewer1.Width = 780;
                    CrystalReportViewer1.Height = 600;

                    //ReportObj.DataDefinition.FormulaFields["CollegeName"].Text = "'" + CommonConstants.CollegeName + "'";
                    //ReportObj.DataDefinition.FormulaFields["CollegeAddress"].Text = "'" + CommonConstants.CollgeAddress + "'";

                    if (RecSelFormula != string.Empty)
                        ReportObj.RecordSelectionFormula = RecSelFormula;


                    CrystalReportViewer1.RefreshReport();
                    CrystalReportViewer1.ReportSource = ReportObj;

                    CrystalReportViewer1.RefreshReport();

                    //ReportObj.PrintToPrinter(1, false, 0, 0);
                    Session["ReportFormat"] = "PDF";
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

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
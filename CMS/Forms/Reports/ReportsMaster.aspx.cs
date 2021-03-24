using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityWebApp.Reports;
using BusinessAccessLayer.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using CrystalDecisions.Shared;

namespace CMS.Forms.Reports
{
    public partial class ReportsMaster : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        public DataSet ReportData = null;
        private ReportDocument ReportObj;



        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
      
                    GetReport();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
             
            }
        }

        #endregion

        //Get Report
        #region[Get Report]

        private void GetReport()
        {
            try
            {
                switch (Request.QueryString["ReportName"].ToString())
                {
                    case "rptHandicapEmpList":
                        {
                            
                            EWA_CommonReports objEWA=new EWA_CommonReports();
                            BL_CommonReports objBL=new BL_CommonReports();
                            objEWA.ViewName = "vwEmpHandicapList";
                            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                            ReportData = objBL.BL_BindReports(objEWA);

                            if (ReportData.Tables[0].Rows.Count == 0)
                            {
                                msgBox.ShowMessage("No Records Found!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            }
                            else
                            {
                                HttpContext.Current.Session.Remove("ReportData");
                                HttpContext.Current.Session.Add("ReportData", ReportData);
                                //Response.Redirect("~/Forms/Reports/ReportViewer.aspx?ReportName=rptHandicapEmpList");
                                string url = "ReportViewer.aspx?ReportName=rptHandicapEmpList";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);
                 
                            }
                            break;
                        }

                    case "rptHandicapStudList":
                        {

                            EWA_CommonReports objEWA = new EWA_CommonReports();
                            BL_CommonReports objBL = new BL_CommonReports();
                            objEWA.ViewName = "vwHandicapStudList";
                            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                            ReportData = objBL.BL_BindReports(objEWA);

                            if (ReportData.Tables[0].Rows.Count == 0)
                            {
                                msgBox.ShowMessage("No Records Found!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            }
                            else
                            {
                                HttpContext.Current.Session.Remove("ReportData");
                                HttpContext.Current.Session.Add("ReportData", ReportData);
                                //Response.Redirect("~/Forms/Reports/ReportViewer.aspx?ReportName=rptHandicapEmpList");
                                string url = "ReportViewer.aspx?ReportName=rptHandicapStudList";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);

                            }
                            break;
                        }

                    case "rptSportsStudList":
                        {

                            EWA_CommonReports objEWA = new EWA_CommonReports();
                            BL_CommonReports objBL = new BL_CommonReports();
                            objEWA.ViewName = "vwSportsStudList";
                            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                            ReportData = objBL.BL_BindReports(objEWA);

                            if (ReportData.Tables[0].Rows.Count == 0)
                            {
                                msgBox.ShowMessage("No Records Found!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            }
                            else
                            {
                                HttpContext.Current.Session.Remove("ReportData");
                                HttpContext.Current.Session.Add("ReportData", ReportData);
                                //Response.Redirect("~/Forms/Reports/ReportViewer.aspx?ReportName=rptHandicapEmpList");
                                string url = "ReportViewer.aspx?ReportName=rptSportsStudList";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);

                            }
                            break;
                        }
                    case "rptGovernmentSchemes":
                        {

                            EWA_CommonReports objEWA = new EWA_CommonReports();
                            BL_CommonReports objBL = new BL_CommonReports();
                            objEWA.ViewName = "vwGovernmentSchemes";
                            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                            ReportData = objBL.BL_BindReports(objEWA);

                            if (ReportData.Tables[0].Rows.Count == 0)
                            {
                                msgBox.ShowMessage("No Records Found!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            }
                            else
                            {
                                HttpContext.Current.Session.Remove("ReportData");
                                HttpContext.Current.Session.Add("ReportData", ReportData);
                                //Response.Redirect("~/Forms/Reports/ReportViewer.aspx?ReportName=rptHandicapEmpList");
                                string url = "ReportViewer.aspx?ReportName=rptGovernmentSchemes";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);

                            }
                            break;
                        }
                       default:
                        break;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
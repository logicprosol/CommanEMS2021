using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Threading.Tasks;
using System.Threading;

namespace CMS.Forms.Student
{
    public partial class abcdREsult : System.Web.UI.Page
    {
        database db = new database();
        public static int orgId;
        string usercode;      
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }

            if (!IsPostBack)
            {
                int orgId = Convert.ToInt32(Session["OrgId"]);
                usercode = Convert.ToString(Session["UserName"]);

                ReportViewer1.Reset();
                DataTable dt = GetData();
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(ds);
                ReportViewer1.LocalReport.ReportPath = "Report2.rdlc";
                ReportViewer1.LocalReport.Refresh();
            }
            lblObtain.Text = db.getDbstatus_Value("SELECT COUNT(Status) AS Expr1 FROM  tblOnlineResult WHERE (OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "') AND (UserCode = '" + Convert.ToString(Session["UserName"]) + "') AND (unitType = '" + Session["testtype"].ToString() + "') AND (SubjectName = '" + Convert.ToString(Session["subject"]) + "') AND (Status = '" + "TRUE" + "')");

            lblOutOf.Text = db.getDbstatus_Value("SELECT  COUNT(Status) AS Expr1 FROM  tblOnlineResult WHERE  (OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "') AND (UserCode = '" + Convert.ToString(Session["UserName"]) + "') AND (unitType = '" + Session["testtype"].ToString() + "') AND (SubjectName = '" + Convert.ToString(Session["subject"]) + "')");

            Thread.Sleep(1000);
            db.insert("delete tblOnlineResult where UserCode ='" + Convert.ToString(Session["UserName"]) + "'");
            //Response.Redirect("~/Student_Home.aspx");
        


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

        }


        

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
              
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand("select Status,queId from tblOnlineResult where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and UserCode='" + Convert.ToString(Session["UserName"]) + "' and unitType='" + Session["testtype"].ToString() + "' and SubjectName='" + Convert.ToString(Session["subject"]) + "' ", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }
       
    }
}
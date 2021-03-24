using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Trustee
{
    public partial class InventoryGraphs : System.Web.UI.Page
    {
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {

        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
            if (!IsPostBack)
            {
                string query = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
                DataTable dt = GetData(query);
                ddlCountries.DataSource = dt;
                ddlCountries.DataTextField = "OrgName";
                ddlCountries.DataValueField = "OrganizationId";
                ddlCountries.DataBind();
                ddlCountries.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", ""));
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("SELECT Distinct dbo.tblCategory.CategoryName, dbo.tblItem.ItemName, dbo.tblItem.Stock FROM dbo.tblItem INNER JOIN dbo.tblUnit ON dbo.tblItem.UnitId = dbo.tblUnit.UnitId INNER JOIN dbo.tblCategory ON dbo.tblItem.CategoryId = dbo.tblCategory.CategoryId  where dbo.tblItem.OrgId= '{0}'   ", ddlCountries.SelectedItem.Value);
            DataTable dt = GetData(query);
            if (dt.Rows.Count > 0)
            {
                //string[] x = new string[dt.Rows.Count];
                //decimal[] y = new decimal[dt.Rows.Count];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    x[i] = dt.Rows[i][0].ToString();
                //    y[i] = Convert.ToInt32(dt.Rows[i][1]);
                //}
                ////   BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
                //BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y, BarColor = "#ddb3b5" });
                //BarChart1.CategoriesAxis = string.Join(",", x);
                //BarChart1.ChartTitle = string.Format("Graph Format For Inventory Stock");// + ddlCountries.SelectedItem.ToString() + "", ddlCountries.SelectedItem.Value);
                //if (x.Length > 3)
                //{
                //    BarChart1.ChartWidth = (x.Length * 100).ToString();
                //}
                //BarChart1.Visible = ddlCountries.SelectedItem.Value != "";
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                //msgBox.ShowMessage("No record found", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('No record found')", true);
            }
            }

        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection constr1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            using (SqlConnection con = (constr1))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        private void ExportGridToPDF()
        {
            string dt = System.DateTime.Now.ToString("MM/yyyy");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=StudentPlacementReport" + dt + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            PanelStudent.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridView1.AllowPaging = true;
            GridView1.DataBind();
        }
    }
}
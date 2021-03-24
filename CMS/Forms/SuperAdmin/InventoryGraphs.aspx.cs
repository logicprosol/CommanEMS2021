using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CMS.Forms.SuperAdmin
{
    public partial class InventoryGraphs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select OrganizationId, OrgName  from tblOrganization";
                DataTable dt = GetData(query);
                ddlCountries.DataSource = dt;
                ddlCountries.DataTextField = "OrgName";
                ddlCountries.DataValueField = "OrganizationId";
                ddlCountries.DataBind();
                ddlCountries.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {


            string query = string.Format("SELECT Distinct dbo.tblItem.ItemName, dbo.tblItem.Stock FROM dbo.tblItem INNER JOIN dbo.tblUnit ON dbo.tblItem.UnitId = dbo.tblUnit.UnitId INNER JOIN dbo.tblCategory ON dbo.tblItem.CategoryId = dbo.tblCategory.CategoryId INNER JOIN dbo.tblPurchaseOrderDetails ON dbo.tblItem.ItemId = dbo.tblPurchaseOrderDetails.ItemId INNER JOIN dbo.tblPurchaseOrder ON dbo.tblPurchaseOrderDetails.POId = dbo.tblPurchaseOrder.POId where dbo.tblItem.OrgId= '{0}'   ", ddlCountries.SelectedItem.Value);
            DataTable dt = GetData(query);

            string[] x = new string[dt.Rows.Count];
            decimal[] y = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            //   BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
            BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y, BarColor = "#82191D" });
            BarChart1.CategoriesAxis = string.Join(",", x);
            BarChart1.ChartTitle = string.Format("School/College Name:- "+ddlCountries.SelectedItem.ToString() + "", ddlCountries.SelectedItem.Value);
            if (x.Length > 3)
            {
                BarChart1.ChartWidth = (x.Length * 100).ToString();
            }
            BarChart1.Visible = ddlCountries.SelectedItem.Value != "";
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
    }
}
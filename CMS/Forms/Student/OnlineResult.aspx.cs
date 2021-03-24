using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Student
{
    public partial class OnlineResult : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public static int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }

    SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Insert_TestDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            DataSet ds = new DataSet();
            using (cn)
            {

                // cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Action", "Final_Result");
                cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
               // string username = Session["Username"].ToString();
                cmd.Parameters.AddWithValue("@UserName", Session["Username"]);
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(ds);
                }
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();

                    
                }
            }
        }
    }
}
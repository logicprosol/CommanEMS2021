using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer;
using System.Configuration;
using System.Data.Common;
using Entity;
using dal;

namespace CMS.Forms.Admin
{
    public partial class AddRoom : System.Web.UI.Page
    {
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        DataSet ds = new DataSet();
        database db = new database();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
               orgId = Convert.ToInt32(Session["OrgID"]);
               if (orgId == 0)
               {
                   Response.Redirect("~/CMSHome.aspx");
               }
               else
               {
                   hdnid.Value = orgId.ToString();
                   //Bind  Hostel NAME
                   if (ddlHostel.Items.Count <= 1)
                   {
                       using (SqlCommand cmd = new SqlCommand("SELECT Hostel_name FROM AddHostel  where OrgId='" + orgId.ToString() + "' "))
                       {
                           cmd.CommandType = CommandType.Text;
                           cmd.Connection = cn;
                           cn.Open();
                           ddlHostel.DataSource = cmd.ExecuteReader();
                           ddlHostel.DataTextField = "Hostel_name";
                           ddlHostel.DataValueField = "Hostel_name";
                           ddlHostel.DataBind();
                           cn.Close();
                       }

                       ddlHostel.Items.Insert(0, new ListItem("--Select Hostel--"));
                   }
               }
               ////Bind  hOSTEL Type
               //if (drpHostelType.Items.Count <= 1)
               //{
               //    using (SqlCommand cmd = new SqlCommand("SELECT Distinct Hostel_Types FROM AddHostel  where OrgId='" + orgId.ToString() + "' "))
               //    {
               //        cmd.CommandType = CommandType.Text;
               //        cmd.Connection = cn;
               //        cn.Open();
               //        drpHostelType.DataSource = cmd.ExecuteReader();
               //        drpHostelType.DataTextField = "Hostel_Types";
               //        drpHostelType.DataValueField = "Hostel_Types";
               //        drpHostelType.DataBind();
               //        cn.Close();
               //    }

               //    drpHostelType.Items.Insert(0, new ListItem("--Select Type--"));
               //}
             
        }

        

        protected void btnSave_Click1(object sender, EventArgs e)
        {

            db.cnopen();
            db.insert("insert into HostelRoom (Host_name,Host_type,Host_room,OrgId) values ('" + ddlHostel.Text + "','" + TextBox1.Text + "','" + TextBox3.Text + "','" + orgId.ToString() + "') ");
            db.cnclose();
            GridView1.DataBind();
            //gvhostel.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted successfully')", true);
          
        }

        protected void ddlHostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FETCH DATA USING DROPDOWN
            SqlCommand cmd1 = new SqlCommand("select  Hostel_Types from AddHostel where OrgId='" + orgId.ToString() + "' and Hostel_name='"+ddlHostel.Text+"' ", cn);
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataSet ds1 = new DataSet();
            adp1.SelectCommand = cmd1;
            adp1.Fill(ds1);
            TextBox1.Text = ds1.Tables[0].Rows[0]["Hostel_Types"].ToString();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

   
    }
}
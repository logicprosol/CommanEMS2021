using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CMS.Forms.Faculty
{
    public partial class TimeTable_Staff : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SP_TimeTableCreationAction", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Action", "TimeTable_For_Staff");
                cmd1.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"].ToString()));
                cmd1.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserCode"].ToString()));
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);


                if (ds1.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds1;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

             //   SqlCommand cmd11 = new SqlCommand("SP_TimeTableCreationAction", cn);
             //   cmd11.CommandType = CommandType.StoredProcedure;
             //   cmd11.Parameters.AddWithValue("@Action", "GetMaxLecturestaff");
             //   cmd11.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"].ToString()));
             //   cmd11.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserCode"].ToString()));
             //   SqlDataAdapter adp11 = new SqlDataAdapter();
             //   DataSet ds11 = new DataSet();
             //   adp11.SelectCommand = cmd1;
             //   adp11.Fill(ds11);

             //   DataTable dt = new DataTable();
             //   DataRow dr = null;
             //   dt.Columns.Add(new DataColumn("Day", typeof(string)));
             //   dt.Columns.Add(new DataColumn("Subject", typeof(string)));
             //   dt.Columns.Add(new DataColumn("Class", typeof(string)));
             //   dt.Columns.Add(new DataColumn("Time", typeof(string)));
             
             //   //int i = 0;
             //   //int len = ds11.Tables[0].Rows.Count;
             //   //while(len<=i)
             //   //{
             //   // int lecture =Convert.ToInt16(ds11.Tables[0].Rows[0]["LectureNo"]);
             //int Day = 2;
             //   int j = 0;
             //   List<string> Detailslist = new List<string>();

             //   Detailslist.Add("Day");
             //   Detailslist.Add("Subject");
             //   Detailslist.Add("Class");
             //   Detailslist.Add("Time");
            }
            catch (Exception ex) { }
        }
    }
}
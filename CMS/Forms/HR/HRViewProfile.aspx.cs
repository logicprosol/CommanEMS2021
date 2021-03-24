using System;
using System.Data;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp.Faculty;
using System.Configuration;
using System.Data.SqlClient;
using Entity;
using dal;
namespace CMS.Forms.HR
{
    public partial class AddViewProfile : System.Web.UI.Page
    {
        
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        DataSet ds = new DataSet();
        database db = new database();
        public static int orgId;
        clse_hrprofile clse = new clse_hrprofile();
        clsd clsd = new clsd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
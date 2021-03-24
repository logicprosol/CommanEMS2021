using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CMS
{
    /// <summary>
    /// Summary description for OrganizationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class OrganizationService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetOrganizationName(string OrgName)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            List<string> organisationName = new List<string>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getmatchingName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@OrgName", OrgName);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    organisationName.Add(rdr["OrgName"].ToString());
                }
            }
            return organisationName;
        }

       
    }
}

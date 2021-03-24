using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
namespace CMS
{
    /// <summary>
    /// Summary description for OrganisationHandler
    /// </summary>
    public class OrganisationHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"] ?? "";
            string cs = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            List<string> listOrganizationName = new List<string>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getmatchingName",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter() {
                    ParameterName = "@term",
                    Value=term
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listOrganizationName.Add(rdr["OrgName"].ToString());
                }

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
           context.Response.Write( js.Serialize(listOrganizationName));
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
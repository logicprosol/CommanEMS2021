using System;
using System.Configuration;
using System.Data.SqlClient;

//Data Access Layer
namespace DataAccessLayer
{
    internal class Connection
    {
        //Objects
        #region[Objects]
        private SqlConnection con = new SqlConnection();
        #endregion

        //Conncetion String
        #region[Conncetion String]

        public string consstr()
        {
            try
            {
                //string constr = @"Data Source=comp9;Initial Catalog=CMSDB;Persist Security Info=True;User ID=sa;Password=12345678";
                string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                return constr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Open Conncetion
        #region[Open Conncetion]

        public void opencon()
        {
            try
            {
                con.ConnectionString = consstr();
                this.con.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Execute query
        #region[Execute Query]

        public SqlDataReader executequery(SqlCommand cmd)
        {
            try
            {
                SqlDataReader dr;
                // closecon();
                cmd.Connection = this.con;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Execute Non Query
        #region[Execute Non Query]

        public void executenonquery(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = this.con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Close Connection
        #region[Close Connection]

        public void closecon()
        {
            try
            {
                this.con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }

    internal static class ConnectionString
    {
        //Connection String
        #region[Connection String]

        public static string consstr()
        {
            try
            {
                //string constr = @"Data Source=comp9;Initial Catalog=CMSDB;Persist Security Info=True;User ID=sa;Password=12345678";
                string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                return constr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
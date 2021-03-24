using System;
using System.Data;
using System.Data.SqlClient;

//Bind Controls
namespace DataAccessLayer
{
    public class BindControl
    {
        //Objects
        #region[Objects]
        //private SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DBConnection"].ToString());
        //private SqlConnection con = new SqlConnection("Data Source=comp9;Initial Catalog=CMSDB;Persist Security Info=True;User ID=sa;Password=12345678;");

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        private SqlDataAdapter da = null;
        private DataSet ds = null;
        //SqlTransaction sqlTransaction;
        #endregion

        //Common Method To Fetch the Data from Database through Action and
        //Stored Procedure as Input Paramand Return DataSet
        #region[Fill Controls]
        public DataSet FillControl(string[] parameterList, string procName)
        {
            try
            {
                cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
             //  cmd.Parameters.Clear();
                cmd.Connection = con;

                cmd.CommandTimeout = 200;
                for (int i = 0; i < parameterList.Length; )
                {
                  
                    cmd.Parameters.AddWithValue(parameterList[i], parameterList[i + 1]);
                    //cmd.Parameters.Clear();
                    i = i + 2;
                }
                con.Close();
                con.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 10054)
                {
                    return null;//throw new SystemException("Record is in use !!!");
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region[For DB Backup]
        public int ExecuteQueryForBackup(string[] parameterList, string procName)
        {
            try
            {
                cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                for (int i = 0; i < parameterList.Length; )
                {
                    cmd.Parameters.AddWithValue(parameterList[i], parameterList[i + 1]);
                    i = i + 2;
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

    }
}
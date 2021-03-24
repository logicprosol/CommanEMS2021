using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;
namespace DataAccessLayer.Admin
{
   public class DL_AddQuestions
    {
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        public int AddQuestions(EWA_AddQuestions Obj, string StoreProcedure)
        {
            int flag = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(StoreProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (con)
                {
                    cmd.CommandText = StoreProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Action", Obj.Action);
                    cmd.Parameters.AddWithValue("@Question", Obj.Question);
                    cmd.Parameters.AddWithValue("@ImgQuestion", Obj.ImgQuestion);
                    cmd.Parameters.AddWithValue("@IsImgQuestion", Obj.IsImgQuestion);
                    cmd.Parameters.AddWithValue("@Answer", Obj.Answer);
                    cmd.Parameters.AddWithValue("@optA", Obj.optA);
                    cmd.Parameters.AddWithValue("@optB", Obj.optB);
                    cmd.Parameters.AddWithValue("@optC", Obj.optC);
                    cmd.Parameters.AddWithValue("@optD", Obj.optD);
                    cmd.Parameters.AddWithValue("@TestId", Obj.TestId);
                    cmd.Parameters.AddWithValue("@OrgId", Obj.OrgId);
                    cmd.Parameters.AddWithValue("@Id", Obj.Id);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }

                    flag = Convert.ToInt32(dt.Rows[0][0].ToString());

                }




            }
            catch (Exception ex)
            {
                //throw;
            }
            return flag;
        }
    }
}

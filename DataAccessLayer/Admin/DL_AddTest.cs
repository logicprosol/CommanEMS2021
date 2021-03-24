using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

namespace DataAccessLayer.Admin
{
   public class DL_AddTest
    {
       
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        public int AddTest(EWA_AddTest Obj_AddTest, string StoreProcedure)
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
                    cmd.Parameters.AddWithValue("@Action", Obj_AddTest.Action);
                    cmd.Parameters.AddWithValue("@TestName", Obj_AddTest.TestName);
                    cmd.Parameters.AddWithValue("@CourseId", Obj_AddTest.CourseId);
                    cmd.Parameters.AddWithValue("@BranchId", Obj_AddTest.BranchId);
                    cmd.Parameters.AddWithValue("@ClassId", Obj_AddTest.ClassId);
                    cmd.Parameters.AddWithValue("@TestMarks", Obj_AddTest.TestMarks);
                    cmd.Parameters.AddWithValue("@TestDate", Obj_AddTest.TestDate);
                    cmd.Parameters.AddWithValue("@SubjectId", Obj_AddTest.@SubjectId);
                    cmd.Parameters.AddWithValue("@IsActive", Obj_AddTest.IsActive);
                    cmd.Parameters.AddWithValue("@PerQuestionMark", Obj_AddTest.PerQuestionMark);
                    cmd.Parameters.AddWithValue("@OrgId", Obj_AddTest.OrgId);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }

                        flag =Convert.ToInt32( dt.Rows[0][0].ToString());

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

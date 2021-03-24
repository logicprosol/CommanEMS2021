using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Emp Stu Attendance
namespace DataAccessLayer.Admin
{
    public class DL_EmpStudAttendance
    {
        // Object Declaration
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;

        private BindControl ObjHelper = new BindControl();
        #endregion

        //Student Action
        #region[StudentInsert]

        public int SaveAction_DL(EWA_EmpStudAttendance objEWA, DataTable dtEmpAttendance)
        {
            try
            {
                cmd = new SqlCommand("SP_EmployeeStudentAttendance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                //Save data in StudentFeesPaid Table
                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@EmployeeAttendance", dtEmpAttendance);  //Passing table value parameter
                tblvaluetype.SqlDbType = SqlDbType.Structured;

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
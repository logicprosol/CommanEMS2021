using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp;

//Student Attendance
namespace DataAccessLayer.Faculty
{
    public class DL_StudentAttendance
    {
        //Objects
        #region[Declare Object]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Action Performed
        #region[Perform Action On Student Attendance]

        public int StudentAttendance_DL(EWA_StudentAttendance objEWA, DataTable StudentClassAttendance)
        {
            try
            {
                cmd = new SqlCommand("SP_StudentAttendance", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@OrgID", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@DivId", objEWA.DivisionId);
                cmd.Parameters.AddWithValue("@SubjectId", objEWA.SubjectId);
                cmd.Parameters.AddWithValue("@EmployeeId", objEWA.EmployeeId);
                cmd.Parameters.AddWithValue("@AttendanceDate", objEWA.Date);
                cmd.Parameters.AddWithValue("@AttendanceTime", objEWA.Time);

                //SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@DataStudentClassAttendance", StudentClassAttendance);  //Passing table value parameter
                //tblvaluetype.SqlDbType = SqlDbType.Structured;

                int flag =Convert.ToInt32( cmd.ExecuteScalar().ToString());
                con.Close();
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Attendance Data
        #region[Get Attendance Data]

        public DataSet GetAttendanceData_DL(EWA_StudentAttendance objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "CheckAttendace";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId  ";
                prmList[9] = objEWA.ClassId;
                //prmList[8] = "@DivisionId";
                //prmList[9] = objEWA.Division;
                //prmList[10] = "@SubjectId";
                //prmList[11] = objEWA.SubjectId;
                //prmList[12] = "@Date";
                //prmList[13] = objEWA.Date;
                //prmList[14] = "@Time";
                //prmList[15] = objEWA.Time;

                ds = ObjHelper.FillControl(prmList, "SP_StudentAttendance");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                return ds;
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion
    }
}
using System;
using System.Data;
using DataAccessLayer.Faculty;
using EntityWebApp;

//Faculty Student Attendace
namespace BusinessAccessLayer.Faculty
{
    public class BL_StudentAttendance
    {
        //Attendance

        #region [Attendance Region]

        public int SaveAttendance(EWA_StudentAttendance ObjEWA, DataTable StudentClassAttendance)
        {
            try
            {
                DL_StudentAttendance ObjDL = new DL_StudentAttendance();
                int flag = ObjDL.StudentAttendance_DL(ObjEWA, StudentClassAttendance);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Attendance Region]

        //Student Attendane Data
        #region[Student Attendance Data]

        public DataSet BL_StudentAttendanceData(EWA_StudentAttendance objEWA)
        {
            try
            {
                DL_StudentAttendance objDL = new DL_StudentAttendance();
                DataSet ds = objDL.GetAttendanceData_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Student Attendance
namespace BusinessAccessLayer.Admin
{
    public class BL_EmpStudAttendance
    {
        // Save Student Registration
        #region[Save EMP Stud Attendance]
        public int SaveAction_BL(EWA_EmpStudAttendance objEWA, DataTable dtEmpattendance)
        {
            try
            {
                DL_EmpStudAttendance objDL = new DL_EmpStudAttendance();
                int flag = objDL.SaveAction_DL(objEWA, dtEmpattendance);
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
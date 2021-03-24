using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Student
namespace BusinessAccessLayer.Admin
{
    public class BL_Student
    {
        //Max Student Id

        #region MaxStudentId

        public DataSet GetStudentCode_BL(EWA_Student objEWA)
        {
            try
            {
                DL_Student objDL = new DL_Student();
                DataSet ds = objDL.GetStudentCode_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion MaxStudentId

        //Get Student Admission Details
        #region[Get Student Admission Details]

        public DataSet GetStudentAdmissionDetails_BL(EWA_Student objEWA)
        {
            try
            {
                DL_Student objDL = new DL_Student();
                DataSet ds = objDL.GetStudentAdmissionDetails_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        // Save Student Registration
        #region[Save Student]

        public int Action_BL(EWA_Student objEWA,DataTable dtFees)
        {
            try
            {
                DL_Student objDL = new DL_Student();
                int flag = objDL.StudentAction_DL(objEWA, dtFees);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Student;
using EntityWebApp.Student;
using BusinessAccessLayer.Student;

namespace BusinessAccessLayer.Student
{
    public class BL_StudentProfile
    {
        DL_StudentProfile objDL = new DL_StudentProfile();
        // Show Student Profile 

        #region Show Student Profile
        public DataSet BL_ShowStudentProfile(EWA_StudentProfile objEWA)
        {
            try
            {
                DL_StudentProfile objDL = new DL_StudentProfile();
                DataSet ds = objDL.DL_ShowStudentProfile(objEWA);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

       
        

        #region Update Student Registration
        public int UpdateStudent(EWA_StudentProfile objEWA)
        {
            try
            {

                int flag = objDL.UpdateStudentProfile(objEWA);
                return flag;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        #endregion 


        #region [Sport Details]
        public DataSet BindSportName()
        {
            try
            {
                DataSet ds = objDL.DL_BindSportName();
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        public DataSet BindCasteCategory_BL(EWA_StudentProfile objEWA)
        {
            try
            {
                //DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.BindCasteCategory_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    
        
    }
}

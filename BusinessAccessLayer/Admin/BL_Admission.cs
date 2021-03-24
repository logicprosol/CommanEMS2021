using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Admission
namespace BusinessAccessLayer.Admin
{
    public class BL_Admission
    {
        //Object

        #region [Object]

        private DL_Admission objDAL = new DL_Admission();

        #endregion [Object]

        // Save Student Registration

        #region [Save Student Registration]

        public int InsertInto(EWA_Admission objBEL)
        {
            try
            {
                int flag = objDAL.SaveAdmission(objBEL);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertEnquiryInfo(EWA_Admission objBEL)
        {
            try
            {
                int flag = objDAL.SaveEnquiryInfo(objBEL);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int UpgradeYear(EWA_Admission objBEL, string[] AdmissionID)
        {
            try
            {
                int flag = objDAL.UpgradeYear(objBEL, AdmissionID);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion [Save Student Registration]

        //Select Data

        #region [Select Data]

        public DataSet SelectData(int orgID)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.SelectAdmissionData(orgID);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        //Get Documnet

        #region [get Documnet]

        public DataSet GetDocument(int orgID)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.GetDocument(orgID);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Select Data]

        //Bind Courses
        #region[Bind Courses]

        public DataSet BL_BindCourse(EWA_Admission objEWA)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.DL_BindCourse(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Branch
        #region[Bind Branch]

        public DataSet BL_BindBranch(EWA_Admission objEWA)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.DL_BindBranch(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Class
        #region[Bind Region]

        public DataSet BL_BindClass(EWA_Admission objEWA)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.DL_BindClass(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Caste Category
        #region[Bind Caste Category]

        public DataSet BindCasteCategory_BL(EWA_Admission objEWA)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.BindCasteCategory_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Select Student Addmission
        #region[Select Student Addmission]

        public DataSet SelectStudentAdmission(EWA_Admission objEWA)
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.DL_SelectStudentAdmission(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Addmission Status
        #region[Update Admission Status]

        public int UpdateAdmissionStatus(EWA_Admission objEWA)
        {
            try
            {
                //DL_Admission objDL = new DL_Admission();
                int flag = objDAL.DL_UpdateAdmissionStatus(objEWA);
                return flag;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
        public string SaveStudentFeesHistrory(EWA_Admission objEWA)
        {
            try
            {
                //DL_Admission objDL = new DL_Admission();
                string flag = objDAL.SaveStudentFeesHistrory(objEWA);
                return flag;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        // Bind Sport Details 

        #region [Sport Details]
        public DataSet BindSportName()
        {
            try
            {
                DL_Admission objDL = new DL_Admission();
                DataSet ds = objDL.DL_BindSportName();
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion



       
}
}
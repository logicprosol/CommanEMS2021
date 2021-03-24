using System;
using System.Data;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;

//Bussiness Access Layer
namespace BusinessAccessLayer
{
    /* =============================================
   -- Author:		Deepak Sawant
   -- Create date: 06/Jan/2014
   -- Description:	To Perform Common Operation
   -- ============================================= */

    public class BL_Common
    {
        // Bind Department BindDepartment_BL
        #region[Bind Department]

        public DataSet BindDepartment_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindDepartment_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Designation BindDesignation_BL
        #region[Bind Designation]

        public DataSet BindDesignation_BL(EWA_Common ObjEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindDesignation_DL(ObjEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Courses BindClass_BL
        #region[Bind Courses]

        public DataSet BindCourses_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindCourses_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet SaveInstallment(EWA_Common objEWA)
        {
            DL_Common objDL = new DL_Common();
            DataSet ds = new DataSet();
            try
            {
             
           ds = objDL.SaveInstallments(objEWA);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }


        // Bind Courses BindFeesCategory_BL
        #region[Bind FeesCategory]

        public DataSet BindFeesCategory_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindFeesCategory_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        public DataSet Bind_AdmissionCompleted_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.Bind_AdmissionCompleted_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        // Bind Courses BindAcademicYear_BL
        #region[Bind AcademicYaer]

        public DataSet BindAcademicYear_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindAcademicYear_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Subjedct BindDivision_BL
        #region[Bind Subject]

        public DataSet BindSubject_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindSubject_DL(objEWA); 
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        public DataSet BindClassForinstallments(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindClasses(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet GetInstallmentData(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.GetInstallmentData(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet Deleteinstallment(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.Deleteinstallment(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet BindAcademicYear(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindAcademicYear(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        public DataSet BindAssigned_Subject_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindAssigned_Subject_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Branches BindBranches_BL
        #region[Bind Branches]

        public DataSet BindBranches_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindBranches_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Class BindClass_BL
        #region[Bind Class]

        public DataSet BindClass_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindClass_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion 
        
         

        // Bind Semester
        #region[Bind Semester]

        public DataSet BindSemester_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindSemester_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Divisions BindDivisions_BL
        #region[Bind Divisions]

        public DataSet BindDivision_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindDivision_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind CasteCategory BindCasteCategory_BL
        #region[Bind CasteCategory]

        public DataSet BindCasteCategory_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindCasteCategory_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Grid of StudentData_BL
        #region[Bind Student Data Region]

        public DataSet BindStudentData_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindStudentData_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Grid of FacultyData_BL
        #region[Bind Faculty Data Region]

        public DataSet BindFacultyData_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindFacultyData_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Subject
        #region[Bind Subject]

        public DataSet FatchSubject_BL(EWA_Common ObjEWA)
        {
            try
            {
                DL_Common ObjDL = new DL_Common();
                DataSet ds = ObjDL.FetchSubject_DL(ObjEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Designation BindDesignationType_BL
        #region[Bind Designation Type]

        public DataSet BindDesignationType_BL()
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindDesignationType_DL();
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind University
        #region[Bind University]

        public DataSet BL_BindUniversity()
        {
            try
            {
                DL_Common ObjDL = new DL_Common();
                DataSet ds = ObjDL.DL_BindUniversity();
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind TimeTable]

        public DataSet BindTimeTable_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindTimeTable_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind StudentAttendance]

        public DataSet BindStudentAttendance_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindStudentAttendance_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind ResultFormat]

        public DataSet BindResultFormat_BL(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindResultFormat_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Branch
        #region [BIND BRANCH]
        public DataSet BindBranch_BL(EWA_Common objEWA)
        {
            DataSet ds = null;
            DL_Common ObjDL = new DL_Common();
            try
            {
                ds = ObjDL.BindBranch_DL(objEWA);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        // Bind Staff Names
        #region [BIND Staff Names]
        public DataSet BindFacultyName(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.DL_BindFacultyName(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion
        // Bind Staff List
        #region [BIND Staff List]
        public DataSet BindStaffList_BL(EWA_Common objEWA)
        {
            DataSet ds = null;
            DL_Common ObjDL = new DL_Common();
            try
            {
                ds = ObjDL.BindStaffList_DL(objEWA);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        //To Bind StudentGridBind for route
        #region[Student Grid Bind For route]

        public DataSet BindStudentForRoute_BL(EWA_Common objEWA)
        {
            DL_Common objDL = new DL_Common();
            try
            {
                DataSet ds = objDL.BindStudentForRoute_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //Added by Ashwini 25-sep-2020
        public DataSet GetAllDataFees(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.GetAllFeesData(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //


        //Added by Ashwini 26-sep-2020
        public DataSet GetBusFeesDetails(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.GetBusFeesDetails(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //

        //Added by Ashwini 28-sep-2020
        public DataSet Bind_Route(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.BindBusRoute_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //


        //Added by Ashwini 30-sep-2020
        public DataSet CheckAllotBus(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.CheckAllotBus(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //

        //Added by Ashwini 9-OCT-2020
        public DataSet InsertPromoteStudentData(EWA_Admission objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.InsertPromoteStudentData(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //



            //Added By ashwini 23-Oct-2020
        public DataSet GetStudentWiseData(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.GetStudentWiseData(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        //Added by Ashwini 23-Oct-2020
        public DataSet GetStudentListFilterWise(EWA_Common objEWA)
        {
            try
            {
                DL_Common objDL = new DL_Common();
                DataSet ds = objDL.GetStudentListFilterWise(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet BindFeeStructure(EWA_Common objEWA)
        {
            DataSet ds = null;
            DL_Common ObjDL = new DL_Common();
            try
            {
                ds = ObjDL.BindFeeStructure(objEWA);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
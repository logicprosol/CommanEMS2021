using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp;
using EntityWebApp.Admin;

namespace DataAccessLayer
{
    /* =============================================
   -- Author:		Deepak Sawant
   -- Create date: 06/Jan/2014
   -- Description:	To Perform Common Operation
   -- ============================================= */

    public class DL_Common
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        // Bind Departments BindDepartment
        #region[Bind Department]

        public DataSet BindDepartment_DL(EWA_Common objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchDepartments";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Designation BindDesignation_DL
        #region[Bind Designation Region]

        public DataSet BindDesignation_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchDesignation";
                prmList[2] = "@DesignationTypeId";
                prmList[3] = ObjEWA.DesignationTypeId;
                prmList[4] = "@DepartmentId";
                prmList[5] = ObjEWA.DepartmentId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Courses BindCourses_DL
        #region[Bind Course Region]

        public DataSet BindCourses_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCourses";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId.ToString();
                //prmList[4] = "@CourseId";
                //prmList[5] = ObjEWA.CourseId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet SaveInstallments(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[18];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId1;
                prmList[4] = "@Class";
                prmList[5] = ObjEWA.Class;
                prmList[6] = "@Academicyear";
                prmList[7] = ObjEWA.AcademicYearId;
                prmList[8] = "@installmentNo";
                prmList[9] = ObjEWA.installmentNo;
                prmList[10] = "@installmentAmt";
                prmList[11] = ObjEWA.installmentAmt.ToString();
                prmList[12] = "@fromdate";
                prmList[13] =ObjEWA.fromdate.ToString();
                prmList[14] = "@todate";
                prmList[15] = ObjEWA.todate.ToString();
                prmList[16] = "@installmentId";
                prmList[17] = ObjEWA.installmentId!=""?ObjEWA.installmentId:"";
                ds = ObjHelper.FillControl(prmList, "Sp_ManageInstallments");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        // Bind Courses BindFeesCategory_DL
        #region[Bind FeesCategory]

        public DataSet BindFeesCategory_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId.ToString();
                //prmList[4] = "@CourseId";
                //prmList[5] = ObjEWA.CourseId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_FeesCategory");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        public DataSet Bind_AdmissionCompleted_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "FetchAdmission_Completed";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId.ToString();
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId.ToString();
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId.ToString();
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId.ToString();
                prmList[10] = "@Status";
                prmList[11] = ObjEWA.Status;
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Courses BindAcademicYear_DL
        #region[Bind AcademicYear Region]

        public DataSet BindAcademicYear_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "BindAcademicYear";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId.ToString();
                //prmList[4] = "@CourseId";
                //prmList[5] = ObjEWA.CourseId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Courses BindCourses_DL
        #region[Bind Course Region]

        public DataSet FetchSubject_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "Fetch_Assigned_Subject";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId.ToString();
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId.ToString();
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId; 
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                //prmList[10] = "@DivisionId";
                //prmList[11] = ObjEWA.DivisionId;
                prmList[10] = "@UserCode";
                prmList[11] = ObjEWA.UserCode;
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Branches BindBranches_DL
        #region[Bind Branches Region]

        public DataSet BindBranches_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchBranches";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Class BindClass_DL
        #region[Bind Class]
            
        public DataSet BindClass_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchClasses";
                prmList[2] = "@BranchId";
                prmList[3] = ObjEWA.BranchId;
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
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

        public DataSet BindSemester_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchSemester";
                prmList[2] = "@ClassId";
                prmList[3] = ObjEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                } return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Division_DL
        #region[Bind Division]

        public DataSet BindDivision_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchDivisions";
                prmList[2] = "@ClassId";
                prmList[3] = ObjEWA.ClassId;
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind CastCategory_DL
        #region[Bind CastCategory]

        public DataSet BindCasteCategory_DL(EWA_Common ObjEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCasteCategory";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Grid of StudentData_DL
        #region[Bind Student Data Region]

        public DataSet BindStudentData_DL(EWA_Common objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudent";
                prmList[2] = "@CourseId";
                prmList[3] = objEWA.CourseId;
                prmList[4] = "@ClassId";
                prmList[5] = objEWA.ClassId;
                prmList[6] = "@OrgId";
                prmList[7] = objEWA.OrgId;
                prmList[8] = "@BranchId";
              prmList[9] = objEWA.BranchId;
               // prmList[10] = "@DivisionId";
               //prmList[11] = objEWA.DivisionId;
                
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Bind Grid of FacultyData_DL
        #region[Bind Faculty Data Region]

        public DataSet BindFacultyData_DL(EWA_Common objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "FetchFaculty";
                prmList[2] = "@DesignationId";
                prmList[3] = objEWA.DesignationId;
                prmList[4] = "@DepartmentId";
                prmList[5] = objEWA.DepartmentId;
                prmList[6] = "@OrgId";
                prmList[7] = objEWA.OrgId;
                prmList[8] = "@UserCode";
                prmList[9] = objEWA.UserCode;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
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

        public DataSet BindSubject_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchSubject";
                prmList[2] = "@ClassId";
                prmList[3] = ObjEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet BindClasses(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "BindClass";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "Sp_ManageInstallments");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet GetInstallmentData(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetInstallments";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "Sp_ManageInstallments");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet Deleteinstallment(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "DeleteInstallments";
                prmList[2] = "@installmentId";
                prmList[3] = ObjEWA.installmentId;

                ds = ObjHelper.FillControl(prmList, "Sp_ManageInstallments");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet BindAcademicYear(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "BindAcadmicYear";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "Sp_ManageInstallments");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet BindAssigned_Subject_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "Fetch_Assigned_Subject";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@UserCode";
                prmList[5] = ObjEWA.UserCode;
                prmList[6] = "@CourseId";
                prmList[7] = ObjEWA.CourseId;
                prmList[8] = "@BranchId";
                prmList[9] = ObjEWA.BranchId;
                prmList[10] = "@ClassId";
                prmList[11] = ObjEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
               
            }
            catch (Exception exp)
            {
                //throw exp;
            } return ds;
        }

        #endregion

        //Bind DesignationType_DL
        #region[Bind Designation Type]

        public DataSet BindDesignationType_DL()
        {
            DataSet ds = null;
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchDesignationType";

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Branch
        #region[Bind Branch]

        public DataSet BindBranch_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchBranches";
                prmList[2] = "@CourseId";
                prmList[3] = ObjEWA.CourseId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
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

        public DataSet DL_BindUniversity()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "BindUniversity";

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind TimeTable]

        public DataSet BindTimeTable_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {

                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "GetTimeTable_HomeWork";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                prmList[10] = "@Date";
                prmList[11] = ObjEWA.date;
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind StudentAttendance]

        public DataSet BindStudentAttendance_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {

                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "CountAttendace";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                prmList[10] = "@AttendanceDate";
                prmList[11] = ObjEWA.date;
                ds = ObjHelper.FillControl(prmList, "SP_StudentAttendance");

                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind ResultFormat]

        public DataSet BindResultFormat_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {

                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "FetchResultFormat";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                //prmList[10] = "@SemesterId";
                //prmList[11] = ObjEWA.SemesterId;
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion


        //Fetch Staff with Filters
        #region [Fetch Staff with FiltersRegion]
        public DataSet DL_BindFacultyName(EWA_Common objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "GetFacultyName";
                prmList[2] = "@DesignationId";
                prmList[3] = objEWA.DesignationId;
                prmList[4] = "@DepartmentId";
                prmList[5] = objEWA.DepartmentId;
                prmList[6] = "@DesignationTypeId";
                prmList[7] = objEWA.DesignationTypeId;
                prmList[8] = "@OrgId";
                prmList[9] = objEWA.OrgId;

                         
                ds = ObjHelper.FillControl(prmList, "SP_Common");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion


        //Fetch StaffList
        #region MyRegion
        public DataSet BindStaffList_DL(EWA_Common objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchStaffList";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //To Bind StudentGrid
        #region[Bind Student Grid For Route]

        public DataSet BindStudentForRoute_DL(EWA_Common objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "StudentListForRoute";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "SP_Common");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserCode");
                    dt.Columns.Add("FullName");
                    dt.Columns.Add("Mobile");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Added by Ashwini 25-sep-2020
        public DataSet GetAllFeesData(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@OrgId";
                prmList[1] = ObjEWA.OrgId.ToString();
                prmList[2] = "@addmissionId";
                prmList[3] = ObjEWA.addmissionId.ToString();
                prmList[4] = "@StudId";
                prmList[5] = ObjEWA.StudId.ToString();
                prmList[6] = "@Course";
                prmList[7] = ObjEWA.course.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_GetAllDataAboutFeesForUpgradeStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //

        //Added by Ashwini 26-sep-2020
        public DataSet GetBusFeesDetails(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@StudId";
                prmList[1] = ObjEWA.StudId.ToString();
                prmList[2] = "@CourseId";
                prmList[3] = ObjEWA.CourseId.ToString();
                prmList[4] = "@ClassId";
                prmList[5] = ObjEWA.ClassId.ToString();
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId.ToString();
                prmList[8] = "@AcademicYear";
                prmList[9] = ObjEWA.AcademicYear.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_GetAllDataAboutBusFeesForUpgradeStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //
        //Added by ashwni 28-sep-2020
        public DataSet BindBusRoute_DL(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@OrgId";
                prmList[1] = ObjEWA.OrgId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_GetAllRoutePramoteStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //

        //Added by Ashwini 30-sep-2020
        public DataSet CheckAllotBus(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@StudId";
                prmList[1] = ObjEWA.StudId.ToString();
                prmList[2] = "@CourseId";
                prmList[3] = ObjEWA.CourseId.ToString();
                prmList[4] = "@ClassId";
                prmList[5] = ObjEWA.ClassId.ToString();
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId.ToString();
                prmList[8] = "@AcademicYear";
                prmList[9] = ObjEWA.AcademicYear.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_CheckBusAllotForStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //

        //Added by Ashwini 30-sep-2020
        public DataSet InsertPromoteStudentData(EWA_Admission ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@OrgID";
                prmList[1] = ObjEWA.OrgID.ToString();
                prmList[2] = "@ApplicationDate";
                prmList[3] = ObjEWA.ApplicationDate.ToString();
                prmList[4] = "@AdmissionType";
                prmList[5] = ObjEWA.AdmissionType.ToString();
                prmList[6] = "@CourseId";
                prmList[7] = ObjEWA.CourseId.ToString();
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId.ToString();
                prmList[10] = "@BranchId";
                prmList[11] = ObjEWA.Branch_ID.ToString();
                prmList[12] = "@FeesCategory";
                prmList[13] = ObjEWA.FeesCategory.ToString();
                prmList[14] = "@CasteCategoryId";
                prmList[15] = ObjEWA.CasteCategoryId.ToString();
                prmList[16] = "@FirstName";
                prmList[17] = ObjEWA.FirstName.ToString();
                prmList[18] = "@MiddleName";
                prmList[19] = ObjEWA.MiddleName.ToString();
                prmList[20] = "@LastName";
                prmList[21] = ObjEWA.LastName.ToString();
                prmList[22] = "@Gender";
                prmList[23] = ObjEWA.Gender1.ToString();
                prmList[24] = "@BirthDate";
                prmList[25] = ObjEWA.BirthDate.ToString();
                prmList[26] = "@BirthPlace";
                prmList[27] = ObjEWA.BirthPlace.ToString();
                prmList[28] = "@Address1";
                prmList[29] = ObjEWA.AddressLine1.ToString();
                prmList[30] = "@Address2";
                prmList[31] = ObjEWA.AddressLine2.ToString();
                prmList[32] = "@Country";
                prmList[33] = ObjEWA.Country1.ToString();
                prmList[34] = "@State";
                prmList[35] = ObjEWA.State1.ToString();
                prmList[36] = "@District";
                prmList[37] = ObjEWA.District1.ToString();
                prmList[38] = "@Taluka";
                prmList[39] = ObjEWA.Taluka1.ToString();
                prmList[40] = "@City";
                prmList[41] = ObjEWA.City1.ToString();
                prmList[42] = "@Pin_Code";
                prmList[43] = ObjEWA.PinCode1.ToString();
                prmList[44] = "@Mobile";
                prmList[45] = ObjEWA.MobileNo.ToString();
                prmList[46] = "@EMail";
                prmList[47] = ObjEWA.E_Mail.ToString();
                prmList[48] = "@Nationality";
                prmList[49] = ObjEWA.Nationality1.ToString();
                prmList[50] = "@BloodGroup";
                prmList[51] = ObjEWA.BloodGroup.ToString();
                prmList[52] = "@Handicap";
                prmList[53] = ObjEWA.Handicaped.ToString();
                prmList[54] = "@AdharNo";
                prmList[55] = ObjEWA.AdharNo.ToString();
                prmList[56] = "@Religion";
                prmList[57] = ObjEWA.Religion1.ToString();
                prmList[58] = "@SubCaste";
                prmList[59] = ObjEWA.Subcaste.ToString();
                prmList[60] = "@ParentName";
                prmList[61] = ObjEWA.ParentName.ToString();
                prmList[62] = "@Relation";
                prmList[63] = ObjEWA.Relation1.ToString();
                prmList[64] = "@LastInstitute";
                prmList[65] = ObjEWA.LastInstitute.ToString();
                prmList[66] = "@Photo";
                prmList[67] = ObjEWA.Photo1.ToString();
                prmList[68] = "@QualifiedExam";
                prmList[69] = ObjEWA.QualifiedExam.ToString();
                prmList[70] = "@Status";
                prmList[71] = ObjEWA.Status.ToString();
                prmList[72] = "@GRNo";
                prmList[73] = ObjEWA.GRNo.ToString();
                prmList[74] = "@MotherTongue";
                prmList[75] = ObjEWA.MotherTongue.ToString();
                prmList[76] = "@AdmissionDate";
                prmList[77] = ObjEWA.AdmissionDate.ToString();
                prmList[78] = "@RollNo";
                prmList[79] = ObjEWA.PreviousRollNo.ToString();
                prmList[80] = "@SaralId";
                prmList[81] = ObjEWA.SaralId.ToString();
                prmList[82] = "@MotherName";
                prmList[83] = ObjEWA.MotherName.ToString();
                ds = ObjHelper.FillControl(prmList, "ssp_SavePromoteStudentOverOrg");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //


            //Added by ashwini 23-Oct-2020
        public DataSet GetStudentWiseData(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Student";
                prmList[1] = ObjEWA.student;
                prmList[2] = "@Action";
                prmList[3] = "GetStudentAdmissionStatus";
                ds = ObjHelper.FillControl(prmList, "SP_GetAdmissionStatusByStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //Added by ashwini 23-Oct-2020
        public DataSet GetStudentListFilterWise(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Criteria";
                prmList[1] = ObjEWA.Criteria;
                prmList[2] = "@CriteriaValue";
                prmList[3] = ObjEWA.CriteriaValue;
                prmList[4] = "@Action";
                prmList[5] = "GetStudentListFilterWise";
                ds = ObjHelper.FillControl(prmList, "SP_GetAdmissionStatusByStudent");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataSet BindFeeStructure(EWA_Common ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "BindFeeStucture";
                prmList[2] = "@orgId";
                prmList[3] = ObjEWA.OrgId;
                ds = ObjHelper.FillControl(prmList, "Sp_BindFeeStructure");
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


    }
}
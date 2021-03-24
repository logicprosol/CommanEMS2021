using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Addmission
namespace DataAccessLayer.Admin
{
    public class DL_Admission
    {
        // Object Declaration

        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlTransaction sqlTransaction;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //SaveAdmission

        #region[Save Admission]

        public int UpgradeYear(EWA_Admission objBEL, string[] _AdmissionID)
        {
            int flag=0;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AdmissionForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                foreach (string AdmissionID in _AdmissionID)
                {
                    cmd.Parameters.AddWithValue(@"Action", objBEL.TransationAction);
                    cmd.Parameters.AddWithValue(@"AdmissionID", AdmissionID);
                   
                    cmd.Parameters.AddWithValue(@"OrgId", objBEL.OrgID);
                   

                    cmd.Parameters.AddWithValue(@"CourseId", objBEL.Course);
                    cmd.Parameters.AddWithValue(@"BranchId", objBEL.Branch_ID);
                    cmd.Parameters.AddWithValue(@"ClassId", objBEL.Class1);

                   
                    //cmd.Parameters.AddWithValue(@"CasteCategoryId", objBEL.CasteCategory);

                    cmd.Parameters.AddWithValue(@"Status", objBEL.Status);
                  
                                       
                     flag = cmd.ExecuteNonQuery();

                    
                  
                }
 return flag;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
               
            }
        }
        public int SaveAdmission(EntityWebApp.Admin.EWA_Admission objBEL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AdmissionForm", con);
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                // Panel General Information

                cmd.Parameters.AddWithValue(@"Action", objBEL.TransationAction);
                cmd.Parameters.AddWithValue(@"AdmissionID", objBEL.AdmissionID);
                cmd.Parameters.AddWithValue(@"ApplicationDate", objBEL.AdmissionDate);
                cmd.Parameters.AddWithValue(@"OrgId", objBEL.OrgID);
                cmd.Parameters.AddWithValue(@"GRNo", objBEL.GRNo);
                cmd.Parameters.AddWithValue(@"SaralId", objBEL.SaralId);
                //for Adhar No
                cmd.Parameters.AddWithValue(@"AdharNo", objBEL.AdharNo);

                cmd.Parameters.AddWithValue(@"FirstName", objBEL.FirstName);
                cmd.Parameters.AddWithValue(@"MiddleName", objBEL.MiddleName);
                cmd.Parameters.AddWithValue(@"LastName", objBEL.LastName);

                cmd.Parameters.AddWithValue(@"CourseId", objBEL.Course);
                cmd.Parameters.AddWithValue(@"BranchId", objBEL.Branch_ID);
                cmd.Parameters.AddWithValue(@"ClassId", objBEL.Class1);
                
                cmd.Parameters.AddWithValue(@"FeesCategory", objBEL.FeesCategory);
                cmd.Parameters.AddWithValue(@"CasteCategoryId", objBEL.CasteCategory);
                cmd.Parameters.AddWithValue(@"SubCaste", objBEL.Subcaste);
                // Panel Personal Inforamtion

                cmd.Parameters.AddWithValue(@"Gender", objBEL.Gender1);
                cmd.Parameters.AddWithValue(@"BirthDate", objBEL.BirthDate);
                cmd.Parameters.AddWithValue(@"BirthPlace", objBEL.BirthPlace);
                cmd.Parameters.AddWithValue(@"Address1", objBEL.AddressLine1);
                cmd.Parameters.AddWithValue(@"Address2", objBEL.AddressLine2);
                cmd.Parameters.AddWithValue(@"Country", objBEL.Country1);
                cmd.Parameters.AddWithValue(@"State", objBEL.State1);
                cmd.Parameters.AddWithValue(@"District", objBEL.District1);
                cmd.Parameters.AddWithValue(@"Taluka", objBEL.Taluka1);
                cmd.Parameters.AddWithValue(@"City", objBEL.City1);
               
         
                cmd.Parameters.AddWithValue(@"Mobile", objBEL.ParentMobile);
                cmd.Parameters.AddWithValue(@"EMail", objBEL.ParentEmail);
                cmd.Parameters.AddWithValue(@"Nationality", objBEL.Nationality1);
                cmd.Parameters.AddWithValue(@"MotherTongue", objBEL.MotherTongue);
                cmd.Parameters.AddWithValue(@"BloodGroup", objBEL.BloodGroup);
                cmd.Parameters.AddWithValue(@"Religion", objBEL.Religion1);
                // Panel Guardian Info

                //cmd.Parameters.AddWithValue(@"GuardianName", objBEL.GuardianName);
                cmd.Parameters.AddWithValue(@"Relation", objBEL.Relation1);
         
                //cmd.Parameters.AddWithValue(@"GuardianMobile", objBEL.GuardianMobile);
                //cmd.Parameters.AddWithValue(@"GuardianEMail", objBEL.GuardianEmail);
                //cmd.Parameters.AddWithValue(@"GuardianEducation", objBEL.Guardian_Education);
                //cmd.Parameters.AddWithValue(@"GuardianOccupation", objBEL.Guardian_Occupation);

                // Panel Parent Info

                cmd.Parameters.AddWithValue(@"ParentName", objBEL.ParentName);
                cmd.Parameters.AddWithValue(@"MotherName", objBEL.MotherName);
                //cmd.Parameters.AddWithValue(@"ParentEducation", objBEL.Parent_Education);
                //cmd.Parameters.AddWithValue(@"ParentOccupation", objBEL.Parent_Occupation);

                //cmd.Parameters.AddWithValue(@"ParentMobile", objBEL.ParentMobile);
                //cmd.Parameters.AddWithValue(@"ParentEMail", objBEL.ParentEmail);

                cmd.Parameters.AddWithValue(@"LastInstitute", objBEL.LastInstitute);

                
                cmd.Parameters.AddWithValue("@Photo", objBEL.StudentPhoto);

                //cmd.Parameters.AddWithValue(@"Username", objBEL.StudentUserName);
                //cmd.Parameters.AddWithValue(@"Password", objBEL.StudentPassword);
                cmd.Parameters.AddWithValue(@"Status", objBEL.Status);
                //cmd.Parameters.AddWithValue(@"AdmissionYear", objBEL.AdmissionYear);

                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@Documents", objBEL.dtDocuments);  //Passing table value parameter
                tblvaluetype.SqlDbType = SqlDbType.Structured;

                int flag = cmd.ExecuteNonQuery();

                return flag;
            }
            catch (Exception EXP)
            {
                throw EXP;
            }
            finally
            {
                con.Close();
            }
        }
        public int SaveEnquiryInfo(EntityWebApp.Admin.EWA_Admission objBEL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_ManageEnquiry", con);
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"Action", "SaveEnquiry");
                cmd.Parameters.AddWithValue(@"ChildFN", objBEL.FirstName);
                cmd.Parameters.AddWithValue(@"ChildLN", objBEL.LastName);
                cmd.Parameters.AddWithValue(@"ChildDOB", objBEL.BirthDate);
                cmd.Parameters.AddWithValue(@"Standard", objBEL.Branch1);
                cmd.Parameters.AddWithValue(@"Email", objBEL.ParentEmail);
                cmd.Parameters.AddWithValue(@"MobileNo", objBEL.MobileNo);
                cmd.Parameters.AddWithValue(@"Address", objBEL.AddressLine1);
                cmd.Parameters.AddWithValue(@"todaysDate", objBEL.ApplicationDate);
                cmd.Parameters.AddWithValue(@"ChildMN", objBEL.MiddleName);
                int flag = cmd.ExecuteNonQuery();

                return flag;
            }
            catch (Exception EXP)
            {
                throw EXP;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        //To Bind DocumentGrid

        #region[Bind Document Grid]

        public DataSet SelectAdmissionData(int orgID)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
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

        //To Bind DocumentGrid

        #region[Bind Document Grid]

        public DataSet GetDocument(int orgID)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetDocument";
                prmList[2] = "@orgID";
                prmList[3] = orgID.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
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

        // Bind Course
        #region[Bind Course]

        public DataSet DL_BindCourse(EWA_Admission objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCourse";
                prmList[2] = "@OrgID";
                prmList[3] = Convert.ToString(objEWA.OrgID);
                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
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

        // Bind Branch
        #region[Bind Branch]

        public DataSet DL_BindClass(EWA_Admission objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchClass";
                prmList[2] = "@OrgID";
                prmList[3] = Convert.ToString(objEWA.OrgID);
                prmList[4] = "@BranchId";
                prmList[5] = Convert.ToString(objEWA.Branch_ID);

                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
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

        // Bind Class
        #region[Bind Class]

        public DataSet DL_BindBranch(EWA_Admission objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchBranch";
                prmList[2] = "@OrgID";
                prmList[3] = Convert.ToString(objEWA.OrgID);
                prmList[4] = "@CourseId";
                prmList[5] = Convert.ToString(objEWA.Course);
                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
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

        // Bind Cate Category
        #region[Cate Category]

        public DataSet BindCasteCategory_DL(EntityWebApp.Admin.EWA_Admission objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCasteCategory";
                prmList[2] = "@OrgID";
                prmList[3] = Convert.ToString(objEWA.OrgID);

                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        // Select Data
        #region[Select Data]

        public DataSet DL_SelectStudentAdmission(EWA_Admission objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                // DateTime dt = DateTime.Parse(objEWA.FromDate);
                prmList = new string[16];
                prmList[0] = "@Action";
                prmList[1] = "FetchAdmissionDetails";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgID);
                prmList[4] = "@CourseId";
                prmList[5] = Convert.ToString(objEWA.Course);
                prmList[6] = "@BranchId";
                prmList[7] = Convert.ToString(objEWA.Branch_ID);
                prmList[8] = "@ClassId";
                prmList[9] = Convert.ToString(objEWA.Class1);
                prmList[10] = "@FromDate";
                prmList[11] = objEWA.FromDate;
                prmList[12] = "@ToDate";
                prmList[13] = objEWA.ToDate;
                prmList[14] = "@Status";
                prmList[15] = "Pending";

                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
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

        //Update Admission Data
        #region[Update Admission]

        public int DL_UpdateAdmissionStatus(EntityWebApp.Admin.EWA_Admission objBEL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AdmissionForm", con);
                con.Close();
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objBEL.TransationAction);
                cmd.Parameters.AddWithValue(@"OrgID", objBEL.OrgID);
                cmd.Parameters.AddWithValue(@"AdmissionId", objBEL.AdmissionID);
                cmd.Parameters.AddWithValue(@"EMail", objBEL.E_Mail);
                cmd.Parameters.AddWithValue(@"Status", objBEL.Status);
                cmd.Parameters.AddWithValue(@"AcademicYearId", objBEL.AcademicYearID);
                sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;

                var flag = cmd.ExecuteScalar();

                sqlTransaction.Commit();
                con.Close();
                return Convert.ToInt32( flag);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        public string SaveStudentFeesHistrory(EntityWebApp.Admin.EWA_Admission objBEL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SaveStudentFeesHistory", con);
                con.Close();
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", "SaveStudentFeesHistory");
                cmd.Parameters.AddWithValue(@"OrgID", objBEL.OrgID);
                cmd.Parameters.AddWithValue(@"student_Code", objBEL.student_Code);
                cmd.Parameters.AddWithValue(@"CourseId", objBEL.CourseId);
                cmd.Parameters.AddWithValue(@"Branch_ID", objBEL.Branch_ID);
                cmd.Parameters.AddWithValue(@"ClassId", objBEL.ClassId);
                cmd.Parameters.AddWithValue(@"AcademicYearID", objBEL.AcademicYearID);
                cmd.Parameters.AddWithValue(@"UserId", objBEL.PinCode1);
                sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;

                var flag = cmd.ExecuteScalar();

                sqlTransaction.Commit();
                con.Close();
                return  flag.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        // Bind Sport Name

        #region [Bind Sport Details]

        public DataSet DL_BindSportName()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchSportName";

                ds = ObjHelper.FillControl(prmList, "SP_AdmissionForm");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                throw exp;
            }
        #endregion
        }
    }
}
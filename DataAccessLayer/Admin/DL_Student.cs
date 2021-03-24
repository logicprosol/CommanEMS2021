using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Student
namespace DataAccessLayer.Admin
{
    public class DL_Student
    {
        // Object Declaration
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
     
        private SqlCommand cmd = null;
        private SqlTransaction sqlTransaction;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Get MaxStudentId
        #region[Max Student Id]

        public DataSet GetStudentCode_DL(EWA_Student objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetStudCode";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Student");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                //GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        //To Get StudentDetails
        #region[Get Student Details]

        public DataSet GetStudentAdmissionDetails_DL(EWA_Student objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "StudentAdmissionDetails";
                prmList[2] = "@AdmissionId";
                prmList[3] = objEWA.AdmissionID;

                ds = ObjHelper.FillControl(prmList, "SP_Student");
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

        //To Save StudentDetails
        #region[Save Student Details]

        public int StudentAction_DL(EWA_Student objEWA, DataTable dtFees)
        {
            try
            {
                cmd = new SqlCommand("SP_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);

                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@AdmissionId", objEWA.AdmissionID);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@AdmissionDate", objEWA.AdmissionDate);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@FirstName", objEWA.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objEWA.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objEWA.LastName);
                cmd.Parameters.AddWithValue("@Gender", objEWA.Gender);
                cmd.Parameters.AddWithValue("@BirthDate", objEWA.BirthDate);
                cmd.Parameters.AddWithValue("@BirthPlace", objEWA.BirthPlace);
                cmd.Parameters.AddWithValue("@Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@Country", objEWA.Country);
                cmd.Parameters.AddWithValue("@State", objEWA.State);
                cmd.Parameters.AddWithValue("@District", objEWA.District);
                cmd.Parameters.AddWithValue("@Taluka", objEWA.Taluka);
                cmd.Parameters.AddWithValue("@City", objEWA.City);
                cmd.Parameters.AddWithValue("@PinCode", objEWA.PinCode);
                cmd.Parameters.AddWithValue("@Mobile", objEWA.Mobile);
                cmd.Parameters.AddWithValue("@EMail", objEWA.EMail);
                cmd.Parameters.AddWithValue("@Nationality", objEWA.Nationality);
                //cmd.Parameters.AddWithValue("@MotherTongue", objEWA.MotherTongue);
                //cmd.Parameters.AddWithValue("@MaritalStatus", objEWA.MaritalStatus);
                cmd.Parameters.AddWithValue("@BloodGroup", objEWA.BloodGroup);
                cmd.Parameters.AddWithValue("@Religion", objEWA.Religion);
                cmd.Parameters.AddWithValue("@CasteCategoryId", objEWA.CasteCategoryId);
                //cmd.Parameters.AddWithValue("@Caste", objEWA.Caste);
                cmd.Parameters.AddWithValue("@Subcaste", objEWA.Subcaste);
                cmd.Parameters.AddWithValue("@Handicaped", objEWA.Handicaped);
                //cmd.Parameters.AddWithValue("@ConveyanceUse", objEWA.ConveyanceUse);
                //cmd.Parameters.AddWithValue("@SportId", objEWA.SportId);
                cmd.Parameters.AddWithValue("@AdharNo", objEWA.AdharNo);

                cmd.Parameters.AddWithValue("@ParentName", objEWA.ParentName);
                cmd.Parameters.AddWithValue("@MotherName", objEWA.MotherName);
               // cmd.Parameters.AddWithValue("@ParentAddress", objEWA.ParentAddress);
               // cmd.Parameters.AddWithValue("@ParentCountry", objEWA.ParentCountry);
               // cmd.Parameters.AddWithValue("@ParentState", objEWA.ParentState);
               // cmd.Parameters.AddWithValue("@ParentDistrict", objEWA.ParentDistrict);
               // cmd.Parameters.AddWithValue("@ParentTaluka", objEWA.ParentTaluka);
               // cmd.Parameters.AddWithValue("@ParentCity", objEWA.ParentCity);
               // cmd.Parameters.AddWithValue("@ParentPinCode", objEWA.ParentPinCode);
               // cmd.Parameters.AddWithValue("@ParentMobile", objEWA.ParentMobile.Trim());
               // cmd.Parameters.AddWithValue("@ParentEmail", objEWA.ParentEmail.Trim());
               //// cmd.Parameters.AddWithValue("@ParentProfession", objEWA.ParentProfession);
               // //cmd.Parameters.AddWithValue("@AnnualIncome", objEWA.AnnualIncome);
               // cmd.Parameters.AddWithValue("@ResidentType", objEWA.ResidentType);
               // //cmd.Parameters.AddWithValue("@ResidanceState", objEWA.ResidanceState);
               // cmd.Parameters.AddWithValue("@GuardianName", objEWA.GuardianName);
                cmd.Parameters.AddWithValue("@Relation", objEWA.Relation);
                //cmd.Parameters.AddWithValue("@GuardianAddress", objEWA.GuardianAddress);
                //cmd.Parameters.AddWithValue("@GuardianCountry", objEWA.GuardianCountry);
                //cmd.Parameters.AddWithValue("@GuardianState", objEWA.GuardianState);
                //cmd.Parameters.AddWithValue("@GuardianDistrict", objEWA.GuardianDistrict);
                //cmd.Parameters.AddWithValue("@GuardianTaluka", objEWA.GuardianTaluka);
                //cmd.Parameters.AddWithValue("@GuardianCity", objEWA.GuardianCity);
                //cmd.Parameters.AddWithValue("@GuardianPinCode", objEWA.GuardianPinCode);
                //cmd.Parameters.AddWithValue("@GuardianMobile", objEWA.GuardianMobile);
                //cmd.Parameters.AddWithValue("@GuardianEmail", objEWA.GuardianEmail);
                //cmd.Parameters.AddWithValue("@LastClass", objEWA.LastClass);
                cmd.Parameters.AddWithValue("@LastInstitute", objEWA.LastInstitute);
                cmd.Parameters.AddWithValue("@QualifiedExam", objEWA.QualifiedExam);
               // cmd.Parameters.AddWithValue("@Board", objEWA.Board);
                //cmd.Parameters.AddWithValue("@SeatNo", objEWA.SeatNo);
                //cmd.Parameters.AddWithValue("@PassingMonth", objEWA.PassingMonth);
                //cmd.Parameters.AddWithValue("@PassingYear", objEWA.PassingYear);
                //cmd.Parameters.AddWithValue("@Percentage", objEWA.Percentage);
                //cmd.Parameters.AddWithValue("@Result", objEWA.Result);
               // cmd.Parameters.AddWithValue("@CreamyLayerStatus", objEWA.CreamyLayerStatus);
                //cmd.Parameters.AddWithValue("@Eligibility", objEWA.Eligibility);

                //cmd.Parameters.AddWithValue("@Gap", objEWA.Gap);
                //cmd.Parameters.AddWithValue("@TcNo", objEWA.TcNo);
               // cmd.Parameters.AddWithValue("@TcIssueDate", objEWA.TcIssueDate);
               // cmd.Parameters.AddWithValue("@FeesConcession", objEWA.FeesConcession);
               // cmd.Parameters.AddWithValue("@ConcessionType", objEWA.ConcessionType);
                //cmd.Parameters.AddWithValue("@BankName", objEWA.BankName);
                //cmd.Parameters.AddWithValue("@Branch", objEWA.BankBranch);
                //cmd.Parameters.AddWithValue("@IFSCCode", objEWA.IFSCCode);
                //cmd.Parameters.AddWithValue("@BankAccountNo", objEWA.BankAccountNo);
               // cmd.Parameters.AddWithValue("@PassportNo", objEWA.PassportNo);
                objEWA.Photo = null;
                objEWA.Signature = null;
                // objEWA.Photo = (StudentDetailsDs.Tables[0].Rows[0]["Photo"]);
                // objEWA.Signature = StudentDetailsDs.Tables[0].Rows[0]["Signature"];
                cmd.Parameters.AddWithValue("@Status", objEWA.Status);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                //StudentClassDiv Table
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                //User Table Data
                cmd.Parameters.AddWithValue("@UserType", objEWA.UserType);
                cmd.Parameters.AddWithValue("@UserName", objEWA.UserName);
                cmd.Parameters.AddWithValue("@Password", objEWA.Password);
                cmd.Parameters.AddWithValue("@Role", objEWA.Role);

                //Save data in StudentFeesPaid Table
                //SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@StudentFeesPaid", dtStudentFeesPaid);  //Passing table value parameter
                //tblvaluetype.SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@StudentId", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@FeesId", objEWA.FeesId);
                cmd.Parameters.AddWithValue("@FeesDetailsId", objEWA.FeesDetailsId);
                cmd.Parameters.AddWithValue("@TotalAmount", objEWA.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", objEWA.TotalPaidAmount);
                cmd.Parameters.AddWithValue("@PendingAmount", objEWA.TotalPendingAmount);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@StudentFeesPaid", dtFees);

                con.Close();
                con.Open();
                sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;
                var flag = cmd.ExecuteScalar();
                sqlTransaction.Commit();
                con.Close();
                return Convert.ToInt32( flag);
               
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                //con.Close();
                cmd.Dispose();
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityWebApp.Student;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Student
{
    public class DL_StudentProfile
    {



        // Object Declaration 

        #region Object Declaration
        SqlConnection con = new SqlConnection(ConnectionString.consstr());
        SqlCommand cmd;
        SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion
        
        
        // Student View Profile Method

        #region Student View Profile Method

        public DataSet DL_ShowStudentProfile(EWA_StudentProfile objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "StudentProfile";
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@UserCode";
                prmList[5] = objEWA.UserCode;
                //prmList[4] = "@UserName";
                //prmList[5] = objEWA.StudentUserName;
                //prmList[6] = "@UserType";
                //prmList[7] = Convert.ToString(objEWA.Usertype);



                ds = ObjHelper.FillControl(prmList, "SP_Student");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {

                }
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                throw exp;
            }
            return ds;
        }

        #endregion 


        #region SaveAdmission

        public int UpdateStudentProfile(EWA_StudentProfile objEWA)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Student", con);               

                cmd.CommandType = CommandType.StoredProcedure;

                // Panel Personal Information  
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);

                cmd.Parameters.AddWithValue("@GRNo", objEWA.GRNo);
                cmd.Parameters.AddWithValue("@StudentId", objEWA.StudentId);
                cmd.Parameters.AddWithValue("@FirstName", objEWA.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objEWA.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objEWA.LastName);
                cmd.Parameters.AddWithValue("@Gender", objEWA.Gender);
                cmd.Parameters.AddWithValue("@BirthDate", objEWA.BirthDate);
                cmd.Parameters.AddWithValue("@BirthPlace", objEWA.BirthPlace);
                cmd.Parameters.AddWithValue("@Address", objEWA.StudentAddress);
                cmd.Parameters.AddWithValue("@Country", objEWA.StudentCountry);
                cmd.Parameters.AddWithValue("@State", objEWA.StudentState);
                cmd.Parameters.AddWithValue("@District", objEWA.StudentDistrict);
                cmd.Parameters.AddWithValue("@Taluka", objEWA.StudentTaluka);
                cmd.Parameters.AddWithValue("@City", objEWA.StudentCity);

                //cmd.Parameters.AddWithValue("@PinCode", objEWA.StudentPincode);
                cmd.Parameters.AddWithValue("@Mobile", objEWA.StudentMobile);
                cmd.Parameters.AddWithValue("@EMail", objEWA.StudentEMail);
                cmd.Parameters.AddWithValue("@Nationality", objEWA.Nationality);
                cmd.Parameters.AddWithValue("@AdharNo", objEWA.AdharNo);
                cmd.Parameters.AddWithValue("@BloodGroup", objEWA.BloodGroup);                                   
                cmd.Parameters.AddWithValue("@Religion", objEWA.Religion);
                cmd.Parameters.AddWithValue("@CasteCategoryId", objEWA.CasteCategoryId);
                cmd.Parameters.AddWithValue("@FeesCategoryId", objEWA.FeesCategoryId);
                cmd.Parameters.AddWithValue("@SubCaste", objEWA.SubCaste);
                cmd.Parameters.AddWithValue("@Handicaped", objEWA.Handicaped);
                              
                                         
                          
                // Panel Parent Info 
                cmd.Parameters.AddWithValue("@ParentName", objEWA.ParentName);
                cmd.Parameters.AddWithValue("@MotherName", objEWA.MotherName);
                //cmd.Parameters.AddWithValue("@ParentAddress", objEWA.ParentAddress);
                //cmd.Parameters.AddWithValue("@ParentCountry", objEWA.ParentCountry);
                //cmd.Parameters.AddWithValue("@ParentState", objEWA.ParentState);
                //cmd.Parameters.AddWithValue("@ParentDistrict", objEWA.ParentDistrict);
                //cmd.Parameters.AddWithValue("@ParentTaluka", objEWA.ParentTaluka);
                //cmd.Parameters.AddWithValue("@ParentCity", objEWA.ParentCity);
                //cmd.Parameters.AddWithValue("@ParentPincode", objEWA.ParentPinCode);
                //cmd.Parameters.AddWithValue("@ParentMobile", objEWA.ParentMobile);               
                //cmd.Parameters.AddWithValue("@ParentEMail", objEWA.ParentEmail);
               

                //Panel Education Info
                //cmd.Parameters.AddWithValue("@LastClass", objEWA.LastClass);
                cmd.Parameters.AddWithValue("@LastInstitute", objEWA.LastInstitute);
                cmd.Parameters.AddWithValue("@QualifiedExam", objEWA.LastQualifiedExam);               
                //cmd.Parameters.AddWithValue("@SeatNo", objEWA.SeatNo);                
                //cmd.Parameters.AddWithValue("@PassingMonth", objEWA.PassingMonth);
                //cmd.Parameters.AddWithValue("@PassingYear", objEWA.PassingYear);
                //cmd.Parameters.AddWithValue("@Percentage", objEWA.Percentage);
                //cmd.Parameters.AddWithValue("@Result", objEWA.Result);

               
                //cmd.Parameters.AddWithValue("@TcNo", objEWA.TcNo);
               
                //cmd.Parameters.AddWithValue("@BankName", objEWA.BankName);
                //cmd.Parameters.AddWithValue("@Branch", objEWA.Branch);
                //cmd.Parameters.AddWithValue("@IFSCCode", objEWA.IFSCCode);
                //cmd.Parameters.AddWithValue("@BankAccountNo", objEWA.BankAccountNo);
                //cmd.Parameters.AddWithValue("@Signature", objEWA.StudentSign);
                cmd.Parameters.AddWithValue("@Photo", objEWA.StudentPhoto);

               
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
        #endregion

         #region [Bind Sport Details]

        public DataSet DL_BindSportName()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchSportName";

                ds = ObjHelper.FillControl(prmList, "SP_Student");
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
        }
        #endregion

        public DataSet BindCasteCategory_DL(EWA_StudentProfile objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCasteCategory";
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgId;

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


    }
}

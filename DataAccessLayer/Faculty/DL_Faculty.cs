using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Faculty;

//Faculty
namespace DataAccessLayer.Faculty
{
    public class DL_Faculty
    {
        //Objects
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Show Faculty
        #region[View Faculty]

        public DataSet DL_ShowFacultyProfile(EWA_Faculty objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                //Stored procedure Action value
                prmList[1] = "FacultyViewProfile";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@UserCode";
                prmList[5] = Convert.ToString(objEWA.StaffId);

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_Employee");
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

        //Get Employee Record
        #region[Get Employee Record]

        public DataSet DL_GetEmployeeRecord(EWA_Faculty objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FacultyViewProfile";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@UserCode";
                prmList[5] = Convert.ToString(objEWA.EmployeeId);

                ds = ObjHelper.FillControl(prmList, "SP_Employee");
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
                throw;
            }
        }

        #endregion

        //Update Faculty
        #region[Update Faculty Profile]

        public int DL_UpdateFaculty(EWA_Faculty objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //personal Information
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                //cmd.Parameters.AddWithValue("@Department", objEWA.Department);
                //cmd.Parameters.AddWithValue("@Designation", objEWA.Designation);
                //cmd.Parameters.AddWithValue("@Course", objEWA.Course);
                cmd.Parameters.AddWithValue("@FirstName", objEWA.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objEWA.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objEWA.LastName);
                cmd.Parameters.AddWithValue("@MotherName", objEWA.MotherName);
                cmd.Parameters.AddWithValue("@Gender", objEWA.Gender);
                cmd.Parameters.AddWithValue("@DOB", objEWA.BirthDate);
                cmd.Parameters.AddWithValue("@BloodGroup", objEWA.BloodGroup);
                cmd.Parameters.AddWithValue("@MaritalStatus", objEWA.MaritalStatus);
                //pass OrgId and StaffId
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.EmployeeId);

                //Contact Information
                cmd.Parameters.AddWithValue("@PresentAddress", objEWA.PresentAddress);
                cmd.Parameters.AddWithValue("@PresentCountry", objEWA.PresentCountry);
                cmd.Parameters.AddWithValue("@PresentState", objEWA.PresentState);
                cmd.Parameters.AddWithValue("@PresentCity", objEWA.PresentCity);
                cmd.Parameters.AddWithValue("@PresentPinCode", objEWA.PresentPinCode);
                //cmd.Parameters.AddWithValue("@PermanentAddress", objEWA.PermanentAddress);
                //cmd.Parameters.AddWithValue("@PermanentCountry", objEWA.PermanentCountry);
                //cmd.Parameters.AddWithValue("@PermanentState", objEWA.PermanentState);
                //cmd.Parameters.AddWithValue("@PermanentCity", objEWA.PermanentCity);
                //cmd.Parameters.AddWithValue("@PermanentPinCode", objEWA.PermanentPincode);
                cmd.Parameters.AddWithValue("@PhoneNumber", objEWA.PhoneNo);
                cmd.Parameters.AddWithValue("@Mobile", objEWA.Mobile);
                //cmd.Parameters.AddWithValue("@Fax", objEWA.Fax);
                cmd.Parameters.AddWithValue("@Email", objEWA.Email);
                cmd.Parameters.AddWithValue("@CasteCategory", objEWA.CasteCategory);
                cmd.Parameters.AddWithValue("@Nationality", objEWA.Nationality);
                //cmd.Parameters.AddWithValue("@WebsiteBlog", objEWA.WebsiteBlog);
                cmd.Parameters.AddWithValue("@PanCardNo", objEWA.PancardNo);
                cmd.Parameters.AddWithValue("@DateOfJoining", objEWA.DateoOfJoining);

                //Education Information
                cmd.Parameters.AddWithValue("@UGDegree", objEWA.UGDegree);
                cmd.Parameters.AddWithValue("@PGDegree", objEWA.PGDegree);
                //cmd.Parameters.AddWithValue("@DoctorateDegree", objEWA.Doctoratedegree);
                cmd.Parameters.AddWithValue("@OtherQualification", objEWA.OtherQualificaton);
                cmd.Parameters.AddWithValue("@Specialization", objEWA.Specialization);
                cmd.Parameters.AddWithValue("@TeachingExperience", objEWA.TeachingExperience);
                //cmd.Parameters.AddWithValue("@IndustrialExperience", objEWA.IndustrialExperience);
                //cmd.Parameters.AddWithValue("@ResearchExperience", objEWA.ResearchExperience);
                //cmd.Parameters.AddWithValue("@NationalPublication", objEWA.NationalPublication);
                //cmd.Parameters.AddWithValue("@InternationalPublication", objEWA.InternationalPublication);
                //cmd.Parameters.AddWithValue("@BookPublished", objEWA.BooksPublished);
                //cmd.Parameters.AddWithValue("@Patents", objEWA.Patents);
                cmd.Parameters.AddWithValue("@Photo",objEWA.Photo);
                //Other Information
                //cmd.Parameters.AddWithValue("@PFNumber", objEWA.PFNumber);
                cmd.Parameters.AddWithValue("@BankAccountNumber", objEWA.BankAccountNumber);
                cmd.Parameters.AddWithValue("@BankName", objEWA.BankName);
                cmd.Parameters.AddWithValue("@BankBranchName", objEWA.BankBranchName);
                //cmd.Parameters.AddWithValue("@BankIFSCCode", objEWA.BankIFSCCode);

                con.Open();
                int flag = cmd.ExecuteNonQuery();

                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
        }

        #endregion
    }
}
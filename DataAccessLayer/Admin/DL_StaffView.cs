using System;

//Add this Namespaces
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Staff View
namespace DataAccessLayer.Admin
{
    public class DL_StaffView
    {
        //fetch Records
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion Object Declaration

        //Bind Faculty Data
        #region[Bind Faculty Data]

        public DataSet DL_BindFacultyData(EWA_StaffView objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "GetEmployeeProfile";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@DepartmentId";
                prmList[5] = objEWA.DepartmentId;
                prmList[6] = "@DesignationId";
                prmList[7] = objEWA.Designation;
                //Stored procedure name
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

        // Bind GrdSearchFaculty GrdSearchFaculty_DL
        #region[Faculty ICard]

        public DataSet FacultyIcard_DL(EWA_StaffView objEWA)
        {
            //throw new NotImplementedException();
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetEmployeeProfileData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@EmpCode";
                prmList[5] = Convert.ToString(objEWA.EmpCode);

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

        //Commented
        #region[Commented]
        // Update Staff
        //public int UpdateFaculty_DL(EWA_StaffView objEWA)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("SP_Staff", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //personal Information
        //        cmd.Parameters.AddWithValue("@Action", objEWA.Action);
        //        cmd.Parameters.AddWithValue("@FirstName", objEWA.FirstName);
        //        cmd.Parameters.AddWithValue("@MiddleName", objEWA.MiddleName);
        //        //cmd.Parameters.AddWithValue("@LastName", objEWA.LastName);

        //        //cmd.Parameters.AddWithValue("@MotherName", objEWA.MotherName);
        //        //cmd.Parameters.AddWithValue("@Gender", objEWA.Gender);
        //        //cmd.Parameters.AddWithValue("@DOB", objEWA.DOB);
        //        //cmd.Parameters.AddWithValue("@BloodGroup", objEWA.BloodGroup);
        //        //cmd.Parameters.AddWithValue("@MaritalStatus", objEWA.MaritalStatus);

        //        //Contact Information
        //        //cmd.Parameters.AddWithValue("@PresentAddress", objEWA.PresentAddress);
        //        //cmd.Parameters.AddWithValue("@PresentCountry", objEWA.PresentCountry);
        //        //cmd.Parameters.AddWithValue("@PresentState", objEWA.PresentState);
        //        //cmd.Parameters.AddWithValue("@PresentCity", objEWA.PresentCity);
        //        //cmd.Parameters.AddWithValue("@PresentPinCode", objEWA.PresentPinCode);
        //        //cmd.Parameters.AddWithValue("@PermanentAddress", objEWA.PermanentAddress);
        //        //cmd.Parameters.AddWithValue("@PermanentCountry", objEWA.PermanentCountry);
        //        //cmd.Parameters.AddWithValue("@PermanentState", objEWA.PermanentState);
        //        //cmd.Parameters.AddWithValue("@PermanentCity", objEWA.PermanentCity);
        //        //cmd.Parameters.AddWithValue("@PermanentPinCode", objEWA.PermanentPinCode);
        //        //cmd.Parameters.AddWithValue("@PhoneNo", objEWA.PhoneNo);
        //        //cmd.Parameters.AddWithValue("@Mobile", objEWA.Mobile);
        //        //cmd.Parameters.AddWithValue("@Fax", objEWA.Fax);
        //        //cmd.Parameters.AddWithValue("@Email", objEWA.Email);
        //        //cmd.Parameters.AddWithValue("@CasteCategory", objEWA.CasteCategory);
        //        //cmd.Parameters.AddWithValue("@Nationality", objEWA.Nationality);
        //        //cmd.Parameters.AddWithValue("@WebsiteBlog", objEWA.WebsiteBlog);
        //        //cmd.Parameters.AddWithValue("@PanCardNo", objEWA.PanCardNo);
        //        //cmd.Parameters.AddWithValue("@DateOfJoining", objEWA.DateOfJoining);

        //        //Education Qualification
        //        //cmd.Parameters.AddWithValue("@UGDegree", objEWA.UGDegree);
        //        //cmd.Parameters.AddWithValue("@PGDegree", objEWA.PGDegree);
        //        //cmd.Parameters.AddWithValue("@DoctrateDegree", objEWA.DoctrateDegree);
        //        //cmd.Parameters.AddWithValue("@OtherQualification", objEWA.OtherQualification);
        //        //cmd.Parameters.AddWithValue("@Specialization", objEWA.Specialization);
        //        //cmd.Parameters.AddWithValue("@TeachingExperience", objEWA.TeachingExperience);
        //        //cmd.Parameters.AddWithValue("@IndustrialExperience", objEWA.IndustrialExperience);
        //        //cmd.Parameters.AddWithValue("@ResearchExperience", objEWA.ResearchExperience);
        //        //cmd.Parameters.AddWithValue("@NationalPublication", objEWA.NationalPublication);
        //        //cmd.Parameters.AddWithValue("@InternationalPublication", objEWA.InternationalPublication);
        //        //cmd.Parameters.AddWithValue("@BookPublished", objEWA.BookPublished);
        //        //cmd.Parameters.AddWithValue("@Patents", objEWA.Patents);

        //        //Other Information
        //        //cmd.Parameters.AddWithValue("@PFNumber", objEWA.PFNumber);
        //        //cmd.Parameters.AddWithValue("@BankAccountNumber", objEWA.BankAccountNumber);
        //        //cmd.Parameters.AddWithValue("@BankName", objEWA.BankName);
        //        //cmd.Parameters.AddWithValue("@BankBranchName", objEWA.BankBranchName);
        //        //cmd.Parameters.AddWithValue("@BankIFSCCode", objEWA.BankIFSCCode);

        //        //cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
        //        //// cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
        //        //cmd.Parameters.AddWithValue("@StaffID", objEWA.StaffID);
        //        ////cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
        //        //cmd.Parameters.AddWithValue("@TransDate", objEWA.TransDate);
        //        //cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
        //        con.Open();
        //        int flag = cmd.ExecuteNonQuery();
        //        con.Close();
        //        return flag;
        //    }
        //    catch (Exception)
        //    {
        //        // throw;
        //    }
        //    //return ds;
        //}
        #endregion


        //Delete Faculty
        #region[Delete Faculty]

        public int DeleteFaculty_DL(EWA_StaffView objEWA)
        {
            int flag = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("SP_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.StaffID);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open(); 
                flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception)
            {
                return flag;
            }

        }

        #endregion


        //Faculty Data
        #region[Faculty I Card Data]

        public DataSet DL_GetFacultyIcardData(EWA_StaffView objEWA)
        {
            DataSet ds = new DataSet();

            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "GetEmployeeProfile";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@DepartmentId";
                prmList[5] = objEWA.DepartmentId;
                prmList[6] = "@DesignationId";
                prmList[7] = objEWA.Designation;

                //Stored procedure name
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

        //Faculty Data
        #region[Faculty Data]

        public DataSet DL_FacultyData(EWA_StaffView objEWA)
        {
            DataSet ds = new DataSet();

            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FacultyProfile";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@EmpCode";
                prmList[5] = objEWA.EmpCode;
             
                //Stored procedure name
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

        // Bind GrdSearchFaculty GrdSearchFaculty_DL
        #region[Faculty ICard]

        public DataSet FacultyIcardf_DL(EWA_StaffView objEWA)
        {
            //throw new NotImplementedException();
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchFacultyforUpdate";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@StaffId";
                prmList[5] = Convert.ToString(objEWA.StaffID);
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
    }
}
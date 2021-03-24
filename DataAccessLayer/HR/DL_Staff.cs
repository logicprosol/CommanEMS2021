using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.HR;

//Staff
namespace DataAccessLayer.HR
{
    public class DL_Staff
    {
        //Objects
        #region[Declare Objects]
        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;
        private SqlTransaction sqlTransaction;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Get MaxStaffId
        #region[Max Staff Id]
        public DataSet GetStaffCode_DL(EWA_Staff objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetCountEmpId";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Employee");
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

        //To Perform Insert,Update,Delete and Search Actions On Staff Table
        #region[Perform Actions On Staff]
        public DataTable staffAction(EWA_Staff objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@EmpCode", objEWA.EmpCode);
                cmd.Parameters.AddWithValue("@DesignationTypeId", objEWA.DesignationTypeId);

                cmd.Parameters.AddWithValue("@FirstName", objEWA.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objEWA.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objEWA.LastName);
                cmd.Parameters.AddWithValue("@MotherName", objEWA.MotherName);
                cmd.Parameters.AddWithValue("@Gender", objEWA.Gender);
                cmd.Parameters.AddWithValue("@DOB", objEWA.DOB);
                cmd.Parameters.AddWithValue("@BloodGroup", objEWA.BloodGroup);
                cmd.Parameters.AddWithValue("@MaritalStatus", objEWA.MaritalStatus);
                //cmd.Parameters.AddWithValue("@Handicap", objEWA.Handicap);
                //cmd.Parameters.AddWithValue("@HandicapPercentage", objEWA.HandicapPercentage);

                //Address details
                cmd.Parameters.AddWithValue("@PresentAddress", objEWA.PresentAddress);
                cmd.Parameters.AddWithValue("@PresentCountry", objEWA.PresentCountry);
                cmd.Parameters.AddWithValue("@PresentState", objEWA.PresentState);
                cmd.Parameters.AddWithValue("@PresentCity", objEWA.PresentCity);
                cmd.Parameters.AddWithValue("@PresentPinCode", objEWA.PresentPinCode);
                //cmd.Parameters.AddWithValue("@PermanentAddress", objEWA.PermanentAddress);
                //cmd.Parameters.AddWithValue("@PermanentCountry", objEWA.PermanentCountry);
                //cmd.Parameters.AddWithValue("@PermanentState", objEWA.PermanentState);
                //cmd.Parameters.AddWithValue("@PermanentCity", objEWA.PermanentCity);
                //cmd.Parameters.AddWithValue("@PermanentPinCode", objEWA.PermanentPinCode);
                //Contact Deyails
                cmd.Parameters.AddWithValue("@PhoneNo", objEWA.PhoneNo);
                cmd.Parameters.AddWithValue("@Mobile", objEWA.Mobile);
                //cmd.Parameters.AddWithValue("@Fax", objEWA.Fax);
                //other Details
                cmd.Parameters.AddWithValue("@Email", objEWA.Email);

                cmd.Parameters.AddWithValue("@CasteCategory", objEWA.CasteCategory);
                cmd.Parameters.AddWithValue("@Nationality", objEWA.Nationality);

                cmd.Parameters.AddWithValue("@PanCardNo", objEWA.PanCardNo);
                cmd.Parameters.AddWithValue("@DateOfJoining", objEWA.DateOfJoining);
                //Educational Qualification
                cmd.Parameters.AddWithValue("@UGDegree", objEWA.UGDegree);
                cmd.Parameters.AddWithValue("@PGDegree", objEWA.PGDegree);
                //cmd.Parameters.AddWithValue("@DoctorateDegree", objEWA.DoctrateDegree);
                cmd.Parameters.AddWithValue("@OtherQualification", objEWA.OtherQualification);
                cmd.Parameters.AddWithValue("@Specialization", objEWA.Specialization);
                cmd.Parameters.AddWithValue("@TeachingExperience", objEWA.TeachingExperience);
                //cmd.Parameters.AddWithValue("@WebsiteBlog", objEWA.WebsiteBlog);

                //cmd.Parameters.AddWithValue("@PreviousPackage", objEWA.PreviousPackage);
                //cmd.Parameters.AddWithValue("@PayScale", objEWA.PayScale);
                //cmd.Parameters.AddWithValue("@SalaryMode", objEWA.SalaryMode);
                //cmd.Parameters.AddWithValue("@PFNumber", objEWA.PFNumber);
                cmd.Parameters.AddWithValue("@BankAccountNumber", objEWA.BankAccountNumber);
                cmd.Parameters.AddWithValue("@BankName", objEWA.BankName);

                cmd.Parameters.AddWithValue("@BankBranchName", objEWA.BankBranchName);
                //cmd.Parameters.AddWithValue("@BankIFSCCode", objEWA.BankIFSCCode);
                cmd.Parameters.AddWithValue("@Photo", objEWA.Photo);
                //User Table Data
                cmd.Parameters.AddWithValue("@UserCode", objEWA.EmpCode);
                cmd.Parameters.AddWithValue("@UserType", objEWA.UserType);
                cmd.Parameters.AddWithValue("@UserName", objEWA.UserName);
                cmd.Parameters.AddWithValue("@Password", objEWA.Password);
                cmd.Parameters.AddWithValue("@Role", objEWA.Role);
                //cmd.Parameters.AddWithValue("@UserTypeId", objEWA.UserTypeId);
                cmd.Parameters.AddWithValue("@Status", objEWA.Status);

                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                cmd.Parameters.AddWithValue("@DesignationID", objEWA.DesignationId);
                cmd.Parameters.AddWithValue("@DepartmentId", objEWA.DepartmentId);

                //con.Open();
                // sqlTransaction = con.BeginTransaction();
                // cmd.Transaction = sqlTransaction;
                DataTable tbl = new DataTable();
                using (con)
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {

                        ad.Fill(tbl);
                    }
                }

                //int flag = cmd.ExecuteNonQuery();
                int flag =Convert.ToInt32( tbl.Rows[0]["Username"].ToString());
                //sqlTransaction.Commit();
                return tbl;
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
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        #endregion

        //To Bind StaffGrid
        #region[Bind Staff Grid]
        public DataSet BindStaffGrid_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                ds = ObjHelper.FillControl(prmList, "SP_Employee");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("StaffId");
                    dt.Columns.Add("StaffName");
                    dt.Columns.Add("StaffType");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
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

        // Bind Class BindCastCategory
        #region[Bind Category]
        public DataSet BindCasteCategory_DL(EWA_Staff objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCasteCategory";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Employee");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //To CheckDuplicateStaff
        #region[Check Duplicate Staff]
        public int CheckDuplicateStaff_DL(EWA_Staff objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                // prmList[2] = "@StaffName";
                // prmList[3] = objEWA.StName;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Employee");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                //GeneralErr(exp.Message.ToString());
                throw;
                //return 1;
            }
        }
        #endregion

        
    }
}
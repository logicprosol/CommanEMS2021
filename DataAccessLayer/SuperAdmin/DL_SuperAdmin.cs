using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp;

//Super Admin
namespace DataAccessLayer
{
    public class DL_SuperAdmin
    {
        // Object Declaration
        #region[Objects]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        // Get Max Organization ID
        #region[Get Max ID]

        public int Get_OrgID()
        {
            try
            {
                SqlDataReader dr;
                Connection concls = new Connection();
                SqlCommand cmd = new SqlCommand();
                string instr = "select isnull(MAX(OrganizationId),0) from tblOrganization";

                concls.opencon();
                cmd.CommandText = instr;

                dr = concls.executequery(cmd);
                dr.Read();

                int stdid = Convert.ToInt32(dr[0].ToString());
                concls.closecon();
                return stdid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        // Add College Name DropDown
        //Bind Data To Drop Down with Acadmin Year in session
        #region [Add College To DropDown[

        public DataSet AddCollegeToDropDown()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchOrgNames";

                ds = ObjHelper.FillControl(prmList, "SP_OrgDetails");
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
                //GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        // Insert Data In tblOrganization Tabel
        #region[Insert Organization]

        public void insertNew_College_RegistrationDLL(EWA_SuperAdmin objEWA)
        {
            try
            {
                Connection concls = new Connection();
                SqlCommand cmd = new SqlCommand("SP_CollegeRegistration");
                concls.opencon();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Save");
                cmd.Parameters.AddWithValue("@orgID", objEWA.orgID);
                cmd.Parameters.AddWithValue("@OrgCode", objEWA.OrgCode);
                cmd.Parameters.AddWithValue("@OrgName", objEWA.OrgName);
                cmd.Parameters.AddWithValue("@OrgType", objEWA.OrgType);
                cmd.Parameters.AddWithValue("@OrgUniversity", objEWA.OrgUniversity);
                cmd.Parameters.AddWithValue("@OrgLabel", objEWA.OrgLabel);
                cmd.Parameters.AddWithValue("@PhoneNo", objEWA.PhoneNo);
                cmd.Parameters.AddWithValue("@FaxNo", objEWA.FaxNo);
                cmd.Parameters.AddWithValue("@Logo", objEWA.LogoImage);
                cmd.Parameters.AddWithValue("@LetterHead", objEWA.LetterHeadImage);
                cmd.Parameters.AddWithValue("@Website", objEWA.Website);
                cmd.Parameters.AddWithValue("@Email", objEWA.Email);
                cmd.Parameters.AddWithValue("@Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@Country", objEWA.Country);
                cmd.Parameters.AddWithValue("@State", objEWA.State);
                cmd.Parameters.AddWithValue("@City", objEWA.City);
                cmd.Parameters.AddWithValue("@Pincode", objEWA.Pincode);
                cmd.Parameters.AddWithValue("@UniversityCode", objEWA.UniversityCode);
                cmd.Parameters.AddWithValue("@MSBTECode", objEWA.MSBTECode);
                cmd.Parameters.AddWithValue("@AICTECode", objEWA.AICTECode);
                cmd.Parameters.AddWithValue("@TrustName", objEWA.TrustName);

                concls.executenonquery(cmd);
                concls.closecon();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update College Data
        #region[Update College Data]

        public void Update_College_Data(EWA_SuperAdmin objEWA)
        {
            try
            {
                Connection concls = new Connection();
                SqlCommand cmd = new SqlCommand("SP_CollegeRegistration");
                concls.opencon();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@OrgName", objEWA.OrgName);
                cmd.Parameters.AddWithValue("@orgID", objEWA.orgID);
                cmd.Parameters.AddWithValue("@OrgCode", objEWA.OrgCode);
                cmd.Parameters.AddWithValue("@OrgLabel", objEWA.OrgLabel);
                cmd.Parameters.AddWithValue("@OrgUniversity", objEWA.OrgUniversity);
                cmd.Parameters.AddWithValue("@PhoneNo", objEWA.PhoneNo);
                cmd.Parameters.AddWithValue("@FaxNo", objEWA.FaxNo);
                cmd.Parameters.AddWithValue("@Logo", objEWA.LogoImage);
                cmd.Parameters.AddWithValue("@LetterHead", objEWA.LetterHeadImage);
                cmd.Parameters.AddWithValue("@TrustName", objEWA.TrustName);
                cmd.Parameters.AddWithValue("@Website", objEWA.Website);
                cmd.Parameters.AddWithValue("@Email", objEWA.Email);
                cmd.Parameters.AddWithValue("@Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@Country", objEWA.Country);
                cmd.Parameters.AddWithValue("@State", objEWA.State);
                cmd.Parameters.AddWithValue("@City", objEWA.City);
                cmd.Parameters.AddWithValue("@Pincode", objEWA.Pincode);
                cmd.Parameters.AddWithValue("@UniversityCode", objEWA.UniversityCode);
                cmd.Parameters.AddWithValue("@MSBTECode", objEWA.MSBTECode);
                cmd.Parameters.AddWithValue("@AICTECode", objEWA.AICTECode);
                cmd.Parameters.AddWithValue("@DTECode", objEWA.DTECode);
                cmd.Parameters.AddWithValue("@OrgType", objEWA.OrgType);
                concls.executenonquery(cmd);
                concls.closecon();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Bind CourseGrid
        #region[Bind Course Grid]

        public DataSet Get_OrganizationDetails(int OrgID)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "OrgID";
                prmList[3] = Convert.ToString(OrgID);
                ds = ObjHelper.FillControl(prmList, "SP_CollegeRegistration");
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
    }
}
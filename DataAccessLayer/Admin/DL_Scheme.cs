
using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Scheme
namespace DataAccessLayer.Admin
{
    public class DL_Scheme
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        #endregion

        //Get Scheme
        #region[Get Scheme]

        public DataSet GetScheme_DL(EWA_Scheme ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetScheme";
                prmList[2] = "@OrganizationId";
                prmList[3] = ObjEWA.OrganizationId.ToString();
                prmList[4] = "@AcademicYearId";
                prmList[5] = ObjEWA.AcademicYearId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Scheme");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Data
        #region[Get Data]

        public DataSet BindScheme_DL(EWA_Scheme ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "GetData";
                prmList[2] = "@OrganizationId";
                prmList[3] = ObjEWA.OrganizationId.ToString();
                prmList[4] = "@AcademicYearId";
                prmList[5] = ObjEWA.AcademicYearId.ToString();
                prmList[6] = "@SchemeId";
                prmList[7] = ObjEWA.SchemeId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Scheme");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Delete Scheme
        #region[Bind Class]

        public DataSet DeleteScheme_DL(EWA_Scheme ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "Delete";
                prmList[2] = "@SchemeDetailsId";
                prmList[3] = ObjEWA.SchemeDetailsId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_Scheme");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Scheme
        #region[Insert Scheme]

        public DataSet InsertScheme_DL(EWA_Scheme objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[16];
                prmList[0] = "@Action";
                prmList[1] = "Save";
                prmList[2] = "@SchemeId";
                prmList[3] = objEWA.SchemeId.ToString();
                prmList[4] = "@FundName";
                prmList[5] = objEWA.FundName;
                prmList[6] = "@DistributedAmount";
                prmList[7] = objEWA.DistributedAmount.ToString();
                prmList[8] = "@AcademicYearId";
                prmList[9] = objEWA.AcademicYearId.ToString();
                prmList[10] = "@OrganizationId";
                prmList[11] = objEWA.OrganizationId.ToString();
                prmList[12] = "@UserId";
                prmList[13] = objEWA.UserId.ToString();
                prmList[14] = "@IsActive";
                prmList[15] = objEWA.IsActive.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Scheme");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Scheme
        #region[Insert Scheme]

        public DataSet UpdateScheme_DL(EWA_Scheme objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "Update";
                prmList[2] = "@SchemeId";
                prmList[3] = objEWA.SchemeId.ToString();

                prmList[4] = "@SchemeDetailsId";
                prmList[5] = objEWA.SchemeDetailsId.ToString();

                prmList[6] = "@FundName";
                prmList[7] = objEWA.FundName;
                prmList[8] = "@DistributedAmount";
                prmList[9] = objEWA.DistributedAmount.ToString();

                prmList[10] = "@UserId";
                prmList[11] = objEWA.UserId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Scheme");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion





        //To Perform Insert,Update,Delete and Search Actions On Subject Table
        #region[Perform Actions On Subject]

        public int SchemeAction_DL(EWA_Scheme objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Scheme", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@SchemeId", objEWA.SchemeId);
                cmd.Parameters.AddWithValue("@SchemeName", objEWA.SchemeName);
                cmd.Parameters.AddWithValue("@GrantedAmt", objEWA.SchemeAmount);
                cmd.Parameters.AddWithValue("@OrganizationId", objEWA.OrganizationId);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
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
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        #endregion



        public DataSet SchemeGridBind_DL(EWA_Scheme objEWA)
        {
           
            
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "BindSchemeName";
                prmList[2] = "@OrganizationId";
                prmList[3] = objEWA.OrganizationId.ToString();
                prmList[4] = "@AcademicYearId";
                prmList[5] = objEWA.AcademicYearId.ToString();
                prmList[6] = "@SchemeId";
                prmList[7] = objEWA.SchemeId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Scheme");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
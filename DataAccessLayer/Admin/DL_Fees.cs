using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Fee
namespace DataAccessLayer.Admin
{
    public class DL_Fees
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

        // Bind Class BindCourse_DL
        #region[Bind Course Region]

        public DataSet BindCourses_DL(EWA_Fees ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCourses";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_Fees");
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

        //Bind Class BindClass_DL
        #region[Bind Class]

        public DataSet BindClass_DL(int CourseId)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchClass";
                prmList[2] = "@CourseId";
                prmList[3] = Convert.ToString(CourseId);

                ds = ObjHelper.FillControl(prmList, "SP_Fees");
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

        //Bind Class BindCastCategory_DL
        #region Bind CastCategory

        public DataSet BindCategory_DL(EWA_Fees objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCasteCategory";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_Fees");
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

        //Get Fee Id
        #region[get Fee Id]

        public DataSet GetFeesId_DL(EWA_Fees ObjEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "FetchFeesId";

                prmList[2] = "@CourseId";
                prmList[3] = ObjEWA.CourseId;
                prmList[4] = "@ClassId";
                prmList[5] = ObjEWA.ClassId;
                prmList[6] = "@CasteCategoryId";
                prmList[7] = ObjEWA.CasteCategoryId;
                prmList[8] = "@OrgId";
                prmList[9] = ObjEWA.OrgId;
                prmList[10] = "@AcademicYearId";
                prmList[11] = ObjEWA.AcademicYear;

                ds = ObjHelper.FillControl(prmList, "SP_Fees");
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

        //Bind Grid View
        #region[Bind Grid View]

        public DataSet BindGridView_DL(EWA_Fees ObjEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchParticular";
                prmList[2] = "@FeesId";
                prmList[3] = ObjEWA.FeesId;
                ds = ObjHelper.FillControl(prmList, "SP_FeesDetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Add New Row
        #region[Add New Row]

        public void AddNewRow_DL(EWA_Fees ObjEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_FeesDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@FeesId", ObjEWA.FeesId);
                cmd.Parameters.AddWithValue("@Particular", ObjEWA.Particular);
                cmd.Parameters.AddWithValue("@Amount", ObjEWA.Amount);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Update Perticular
        #region[Update Perticular]

        public int UpdateParticular_DL(EWA_Fees ObjEWA)
        {
            int flag = 0;
            try
            {
                cmd = new SqlCommand("SP_FeesDetails", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@FeesId", ObjEWA.FeesId);
                cmd.Parameters.AddWithValue("@FeesDetalsId", ObjEWA.FeesDetalsId);
                cmd.Parameters.AddWithValue("@Particular", ObjEWA.Particular);
                cmd.Parameters.AddWithValue("@Amount", ObjEWA.Amount);
                cmd.Parameters.AddWithValue("@OldParticular", ObjEWA.OldParticular);
                cmd.Parameters.AddWithValue("@OldAmount", ObjEWA.OldAmount);
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

        //Delete Perticular
        #region[Delete Perticular]

        public void DeleteParticular_DL(EWA_Fees ObjEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_FeesDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@FeesId", ObjEWA.FeesId);
                cmd.Parameters.AddWithValue("@FeesDetalsId", ObjEWA.FeesDetalsId);
                cmd.Parameters.AddWithValue("@Particular", ObjEWA.Particular);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Add New Fee
        #region[Add New Fee]

        public void AddNewFees_DL(EWA_Fees ObjEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Fees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@OrgId", ObjEWA.OrgId);
                cmd.Parameters.AddWithValue("@CourseId", ObjEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", ObjEWA.BranchId);
                cmd.Parameters.AddWithValue("@ClassId", ObjEWA.ClassId);
                cmd.Parameters.AddWithValue("@AcademicYearId", ObjEWA.AcademicYear);
                cmd.Parameters.AddWithValue("@CasteCategoryId", ObjEWA.CasteCategoryId);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Current Year
        #region[Bind Current Year]

        public DataSet BindAcademicYear_DL(EWA_AcademicYear ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "AcademicYear";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(ObjEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_AcademicYear");
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
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

//University
namespace DataAccessLayer.SuperAdmin
{
    public class DL_University
    {
        //objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On University Table
        #region[Perform Actions On University]

        public int UniversityAction_DL(EntityWebApp.SuperAdmin.EWA_University objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_University", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UniversityId", objEWA.UniversityId);
                cmd.Parameters.AddWithValue("@UniversityName", objEWA.UniversityName);
                cmd.Parameters.AddWithValue("@Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@Country", objEWA.Country);
                cmd.Parameters.AddWithValue("@State", objEWA.State);
                cmd.Parameters.AddWithValue("@City", objEWA.City);
                cmd.Parameters.AddWithValue("@PinCode", objEWA.PinCode);
                cmd.Parameters.AddWithValue("@Email", objEWA.Email);
                cmd.Parameters.AddWithValue("@Contact1", objEWA.Contact);
                // cmd.Parameters.AddWithValue("@ContactNo2", objEWA.Contact2);
                cmd.Parameters.AddWithValue("@FaxNo1", objEWA.FaxNo);
                //cmd.Parameters.AddWithValue("@FaxNo2", objEWA.FaxNo2);
                cmd.Parameters.AddWithValue("@Logo", objEWA.Logo);

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

        //To Bind UniversityGrid
        #region[Bind Document Grid]

        public DataSet BindUniversityGrid_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                ds = ObjHelper.FillControl(prmList, "SP_University");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UniversityId");
                    dt.Columns.Add("UniversityName");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Country");
                    dt.Columns.Add("State");
                    dt.Rows.Add("City");
                    dt.Rows.Add("PinCode");
                    dt.Rows.Add("Email");
                    dt.Columns.Add("ContactNo");
                    dt.Columns.Add("FaxNo");

                    //return dsCode;
                    return null;
                }
            }
            catch (Exception ex)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        //Check Duplicate University
        #region[Check Duplicate University]

        public int CheckDuplicateUniversity_DL(EntityWebApp.SuperAdmin.EWA_University objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@UniversityName";
                prmList[3] = objEWA.UniversityName;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_University");
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

        //Get Image Logo
        #region[Get Image Logo]

        public SqlDataReader getImageLogo_DL(string UniversityName)
        {
            try
            {
                SqlDataReader dr = null;
                return dr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
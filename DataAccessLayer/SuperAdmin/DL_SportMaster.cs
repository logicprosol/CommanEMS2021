using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.SuperAdmin;

//Sport Master
namespace DataAccessLayer.SuperAdmin
{
    public class DL_SportMaster
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

        //To Perform Insert,Update,Delete and Search Actions On Document Table
        #region[Perform Actions On Sport]

        public int SportAction_DL(EWA_SportMaster objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SportMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@SportId", objEWA.SportId);
                
                cmd.Parameters.AddWithValue("@SportName", objEWA.SportName);
            
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();

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

        //To Bind DocumentGrid

        #region[Bind Sport Grid]

        public DataSet BindSportGrid_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchDepartment";
           

                ds = ObjHelper.FillControl(prmList, "SP_SportMaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SportId");
                    
                    dt.Columns.Add("SportName");

                    //dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To CheckDuplicate Sport
        #region[Check Duplicate Sport]

        public int CheckDuplicateSport_DL(EWA_SportMaster objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@SportName";
                prmList[3] = objEWA.SportName;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_SportMaster");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Department
        #region[Bind Department]

        public DataSet BindDepartment_DL(int OrgId)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchSport";

                ds = ObjHelper.FillControl(prmList, "SP_Sport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
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
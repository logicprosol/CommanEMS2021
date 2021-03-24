using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Documents
namespace DataAccessLayer.Admin
{
    public class DL_Documents
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

        #region[Perform Actions On Document]

        public int DocumentAction_DL(EWA_Documents objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Documents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DocumentId", objEWA.DocumentId);
                cmd.Parameters.AddWithValue("@DocumentName", objEWA.DocumentName);
                cmd.Parameters.AddWithValue("@DocumentType", objEWA.DocumentType);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
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

        //To Bind DocumentGrid

        #region[Bind Document Grid]

        public DataSet BindDocumentGrid_DL( EWA_Documents objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_Documents");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DocumentId");
                    dt.Columns.Add("DocumentName");
                    dt.Columns.Add("DocumentType");

                    dt.Rows.Add();
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

        //To CheckDuplicateDocument
        #region[Check Duplicate Document]

        public int CheckDuplicateDocument_DL(EWA_Documents objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";
                prmList[2] = "@DocumentName";
                prmList[3] = objEWA.DocumentName;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId.ToString();

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Documents");
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
    }
}
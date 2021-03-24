using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Library;

namespace DataAccessLayer.Library
{
    public class DL_AddBook
    {
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        public int BookAction_DL(EWA_AddBook objEWA)
        {
            int flag = 0;
            try
            {
                cmd = new SqlCommand("SP_LibAddBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@BookId", objEWA.BookId);
                cmd.Parameters.AddWithValue("@BookName", objEWA.BookName);
                cmd.Parameters.AddWithValue("@GroupId", objEWA.GroupId);
                cmd.Parameters.AddWithValue("@Publisher", objEWA.Publisher);
                cmd.Parameters.AddWithValue("@Author", objEWA.Author);
                cmd.Parameters.AddWithValue("@PublishingYear", objEWA.PublishingYear);
                cmd.Parameters.AddWithValue("@Edition", objEWA.Edition);
                cmd.Parameters.AddWithValue("@Price", objEWA.Price);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@barcode", objEWA.barcode);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                cmd.Parameters.AddWithValue("@qty", objEWA.qty);
                con.Open();
                flag = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
            }
            return flag;
        }

        public DataSet GetBook_DL(EWA_AddBook objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetData";
                prmList[2] = "OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_LibAddBook");
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BookId");
                    dt.Columns.Add("BookCode");
                    dt.Columns.Add("BookName");
                    dt.Columns.Add("GroupId");
                    dt.Columns.Add("GroupName");
                    dt.Columns.Add("Publisher");
                    //dt.Columns.Add("barcode");
                    dt.Columns.Add("Author");
                    dt.Columns.Add("PublishingYear");
                    dt.Columns.Add("Edition");
                    dt.Columns.Add("Price");
                    dt.Columns.Add("qty");
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //ds.Tables.RemoveAt(0);
                    //ds.Tables.Add(dt);
                }
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public int CheckBookName_DL(EWA_AddBook objEWA)
        {
            DataSet ds = new DataSet();
            int cnt = 0;
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckBookName";
                prmList[2] = "@BookName";
                prmList[3] = objEWA.BookName.ToString();
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_LibAddBook");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cnt = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            return cnt;
        }

        public DataSet GetBookGroup_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "GetGroup";

                ds = ObjHelper.FillControl(prmList, "SP_LibAddBook");
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
    }
}

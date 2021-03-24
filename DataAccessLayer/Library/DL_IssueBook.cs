using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Library;

namespace DataAccessLayer.Library
{
    public class DL_IssueBook
    {
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        public int IssueBookAction_DL(EWA_IssueBook objEWA)
        {
            int flag = 0;
            try
            {
                cmd = new SqlCommand("SP_LibIssueBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@IssueId", objEWA.IssueId);
                cmd.Parameters.AddWithValue("@BookId", objEWA.BookId);
                cmd.Parameters.AddWithValue("@GroupId", objEWA.GroupId);
                cmd.Parameters.AddWithValue("@StudentId", objEWA.StudentId);
                cmd.Parameters.AddWithValue("@IssueDate", objEWA.IssueDate);
                cmd.Parameters.AddWithValue("@DueDate", objEWA.DueDate);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                flag = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
            }
            return flag;
        }

        public DataSet GetIsueeBook_DL(EWA_IssueBook objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_LibIssueBook");
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IssueId");
                    dt.Columns.Add("IssueDate");
                    dt.Columns.Add("DueDate");
                    dt.Columns.Add("BookId");
                    dt.Columns.Add("BookName");
                    dt.Columns.Add("GroupId");
                    dt.Columns.Add("GroupName");
                    dt.Columns.Add("PublishingYear");
                    dt.Columns.Add("StudentId");
                    dt.Columns.Add("StdName");
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

        public DataSet GetBookGroup_DL(EWA_IssueBook objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetGroup";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_LibIssueBook");
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet GetBook_DL(EWA_IssueBook objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetBook";
                prmList[2] = "@GroupId";
                prmList[3] = objEWA.GroupId.ToString();


                ds = ObjHelper.FillControl(prmList, "SP_LibIssueBook");
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet GetBookInfo_DL(EWA_IssueBook objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetBookInfo";
                prmList[2] = "@BookId";
                prmList[3] = objEWA.BookId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_LibIssueBook");
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet GetStudentInfo_DL(EWA_IssueBook objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetStudentInfo";
                prmList[2] = "@StudentCode";
                prmList[3] = objEWA.StudentCode;

                ds = ObjHelper.FillControl(prmList, "SP_LibIssueBook");
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

    }
}

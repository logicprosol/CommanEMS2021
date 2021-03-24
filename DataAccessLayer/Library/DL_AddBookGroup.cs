using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Library;

namespace DataAccessLayer.Library
{
    public class DL_AddBookGroup
    {
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        public int BookGroupAction_DL(EWA_AddBookGroup objEWA)
        {
            int flag=0;
            try 
	        {
                cmd = new SqlCommand("SP_LibAddGroup",con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action",objEWA.Action);
                cmd.Parameters.AddWithValue("@GroupId",objEWA.GroupId);
                cmd.Parameters.AddWithValue("@GroupCode",objEWA.GroupCode);
                cmd.Parameters.AddWithValue("@GroupName",objEWA.GroupName);
                cmd.Parameters.AddWithValue("@OrgId",objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId",objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive",objEWA.IsActive);
                con.Open();
                flag = cmd.ExecuteNonQuery();
                con.Close();
               
	        }
	        catch (Exception)
	        {
	        }
            return flag;
        }
        
        public DataSet GetBookGroup_DL(EWA_AddBookGroup objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1]= "GetData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                
                ds = ObjHelper.FillControl(prmList,"SP_LibAddGroup");
                if (ds.Tables[0].Rows.Count <=0)
	            {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("GroupId");
                    dt.Columns.Add("GroupCode");
                    dt.Columns.Add("GroupName");
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //ds.Tables.RemoveAt(0);
                    //ds.Tables.Add(dt);
	            }
            }
            catch(Exception ex)
            {

            }
            return ds;
        }

        public int CheckGroupName_DL(EWA_AddBookGroup objEWA)
        {
            DataSet ds = new DataSet();
            int cnt = 0;
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckGroupName";
                prmList[2] = "@GroupName";
                prmList[3] = objEWA.GroupName;
                prmList[4] = "@GroupId";
                prmList[5] = objEWA.GroupId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_LibAddGroup");
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
        
    }
}

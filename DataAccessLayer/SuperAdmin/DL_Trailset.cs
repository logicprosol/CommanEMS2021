using EntityWebApp.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.SuperAdmin
{

    public class DL_Trailset
    {
        #region[Declare Objects]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //To Bind Organization
        #region[Bind Organization]
        public DataSet Bind_DDLOrganization_DL(EWA_Trailset objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;


                ds = ObjHelper.FillControl(prmList, "SP_Trailset");
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

        //To CheckOrganization
        #region[Check Organization]
        public int CheckOrganization_DL(EWA_Trailset objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Trailset", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);

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

        //To Bind Grd
        #region[Bind Grd]
        public int TrailsetAction_DL(EWA_Trailset objEWA)
        {

            try
            {
                cmd = new SqlCommand("SP_Trailset", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@id", objEWA.id);
                cmd.Parameters.AddWithValue("@ValidDate", objEWA.ValidDate);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@SenderId", objEWA.SenderId);
                cmd.Parameters.AddWithValue("@AppKey", objEWA.AppKey);

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

        
    }
}

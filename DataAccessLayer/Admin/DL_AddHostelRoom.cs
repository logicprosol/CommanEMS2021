using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Inventory;
using EntityWebApp.Admin;

namespace DataAccessLayer.Admin
{
    public class DL_AddHostelRoom
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

 
        private BindControl ObjHelper = new BindControl();

        #endregion

        //Perform Action on AddHostel Table
        #region[Perform Actions On Item Category]

        public int CategoryAction_DL(EWA_AddHostelRoom objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_AddHostelRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@Hostel_id", objEWA.HostelId);
                cmd.Parameters.AddWithValue("@Hostel_name", objEWA.HostelName);
                cmd.Parameters.AddWithValue("@Hostel_Types", objEWA.Types);
                cmd.Parameters.AddWithValue("@Hostel_Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@H_totalroom", objEWA.TotalRoom);
                cmd.Parameters.AddWithValue("@H_allocateroom", objEWA.AllocateRoom);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
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

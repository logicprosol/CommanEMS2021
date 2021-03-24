using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Admin
{
    public class DL_Holiday
    {
        //Objects
        #region [Declare Objects]

        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion 


        //To Perform Insert,Update,Delete and Search Actions On tblHoliday Table
        #region[Perform Actions On Holiday]

        public int HolidayAction_DL(EWA_Holiday objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Holiday", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@HolidayId", objEWA.HolidayId);
                cmd.Parameters.AddWithValue("@HolidayName", objEWA.HolidayName);
                cmd.Parameters.AddWithValue("@HolidayDate", objEWA.HolidayDate);
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

        //To Bind HolidayGrid
        #region[Bind Holiday Grid]

        public DataSet HolidayGridBind_DL(EWA_Holiday objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgID";
                prmList[3] = objEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_Holiday");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Week Day
namespace DataAccessLayer.Admin
{
    public class DL_WeekDay
    {
        //Object Declaration
        #region[Declare Objects]
        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //To Bind DayGrid
        #region[Bind Day Grid]
        public DataSet BindDayGrid_DL(EWA_WeekDay objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchWeekDay";
                ds = ObjHelper.FillControl(prmList, "SP_WeekDay");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    prmList = new string[2];
                    prmList[0] = "@Action";
                    prmList[1] = "FetchDays";
                    ds = ObjHelper.FillControl(prmList, "SP_WeekDay");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds;
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("DayId");
                        dt.Columns.Add("Day");
                        dt.Rows.Add();
                        dt.Rows.Add();
                    }
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["OrgId"].ToString() == objEWA.OrgId)
                    {
                        prmList = new string[4];
                        prmList[0] = "@Action";
                        prmList[1] = "FetchOrgWeekDay";
                        prmList[2] = "@OrgId";
                        prmList[3] = objEWA.OrgId;
                        ds = ObjHelper.FillControl(prmList, "SP_WeekDay");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            return ds;
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("DayId");
                            dt.Columns.Add("Day");
                            dt.Columns.Add("Set/NotSet");
                            dt.Rows.Add();
                            dt.Rows.Add();
                            dt.Rows.Add();
                        }
                    }
                    else
                    {
                        prmList = new string[2];
                        prmList[0] = "@Action";
                        prmList[1] = "FetchDays";
                        ds = ObjHelper.FillControl(prmList, "SP_WeekDay");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            return ds;
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("DayId");
                            dt.Columns.Add("Day");
                            dt.Rows.Add();
                            dt.Rows.Add();
                        }
                    }
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Week Day Table
        #region[Perform Actions On Week Day]
        public int WeekDayAction_DL(EWA_WeekDay objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_WeekDay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DayId", objEWA.DayId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception exp)
            {
                int err = ((System.Data.SqlClient.SqlException)(exp)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw exp;
                }
            }
        }
        #endregion

        //To CheckDuplicateOrganization record
        #region[Check Duplicate Organization]
        public int CheckDuplicateOrg_DL(EWA_WeekDay objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@DayId";
                prmList[5] = objEWA.DayId;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_WeekDay");
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
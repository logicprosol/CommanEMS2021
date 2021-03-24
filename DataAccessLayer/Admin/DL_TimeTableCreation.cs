using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

namespace DataAccessLayer.Admin
{
    public class DL_TimeTableCreation
    {
        //Objects

        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion DeclareObjects

        #region Action

        public int TimeTableCreationAction_DL(EWA_TimeTableCreation objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_TimeTableCreationAction", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@TimeTableId", objEWA.TimeTableId);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue("@SubjectId", objEWA.SubjectId);
                cmd.Parameters.AddWithValue("@SubEmpId", objEWA.SubEmpId);
                cmd.Parameters.AddWithValue("@DayId", objEWA.DayId);
                cmd.Parameters.AddWithValue("@TimeSlotId", objEWA.TimeSlotId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@LectureNo", objEWA.LecNo);
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


        public DataSet GetDays()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "GetDays";
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetTimeSlot()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "GetTimeSlot";
                //prmList[2] = "OrgId";
                //prmList[3] = objEWA.OrgId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetEmpSub(EWA_TimeTableCreation objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetSubEmp";
                prmList[2] = "@SubjectId";
                prmList[3] = objEWA.SubjectId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetTimeTable(EWA_TimeTableCreation objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetTimeTable";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet CheckTimeTable(EWA_TimeTableCreation objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "CheckTimeTable";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId.ToString();
                prmList[4] = "@TimeSlotId";
                prmList[5] = objEWA.TimeSlotId.ToString();
                prmList[6] = "@DayId";
                prmList[7] = objEWA.DayId.ToString();
                prmList[8] = "@SubEmpId";
                prmList[9] = objEWA.SubEmpId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet CheckTimeTable1(EWA_TimeTableCreation objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "CheckTimeTable1";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId.ToString();
                prmList[4] = "@TimeSlotId";
                prmList[5] = objEWA.TimeSlotId.ToString();
                prmList[6] = "@DayId";
                prmList[7] = objEWA.DayId.ToString();
                prmList[8] = "@SubEmpId";
                prmList[9] = objEWA.SubEmpId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet CheckEmployeeExists(EWA_TimeTableCreation objEWA2)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "CheckEmployeeExists";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA2.ClassId.ToString();
                prmList[4] = "@DayId";
                prmList[5] = objEWA2.DayId.ToString();
                prmList[6] = "@SubEmpId";
                prmList[7] = objEWA2.SubEmpId.ToString();
                prmList[8] = "@LectureNo";
                prmList[9] = objEWA2.LecNo.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_TimeTableCreationAction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

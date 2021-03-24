using System;
using System.Data;

//Add this Namespaces
using System.Data.SqlClient;
using EntityWebApp.Admin;

namespace DataAccessLayer.Admin
{
    public class DL_LC
    {
        //fetch Records

        #region Object Declaration

        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion Object Declaration

        //To Bind Usercode

        #region BindUsercode

        public DataSet BindUsercode_DL(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "GetStudentUsercode";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId;
                prmList[4] = "@DivisionId";
                prmList[5] = objEWA.DivisionId;
                prmList[6] = "@OrgId";
                prmList[7] = objEWA.OrgId;

                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        #endregion BindUsercode

        //Fetch Records Student Information Leaving ceritificate

        #region Student Leaving Ceritificate

        public DataSet DL_LeavingCertificate(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchLeavingCertificate";
                prmList[2] = "@UserCode";
                prmList[3] = Convert.ToString(objEWA.Usercode);

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                throw exp;
            }
            return ds;
        }

        #endregion Student Leaving Ceritificate

        //Save Leaving Certificate

        #region Save LC

        public int SaveUpdateLC_DL(EWA_LC objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_LeavingCertificate", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Save Student Leaving Certificate
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.StudentId);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);
                cmd.Parameters.AddWithValue("@StudentName", objEWA.FullName);
                cmd.Parameters.AddWithValue("@Caste", objEWA.Caste);
                cmd.Parameters.AddWithValue("@Nationality", objEWA.Nationality);
                cmd.Parameters.AddWithValue("@BirthPlace", objEWA.BirthPlace);
                cmd.Parameters.AddWithValue("@DOB", objEWA.DOB);
                cmd.Parameters.AddWithValue("@LastSchoolAttended", objEWA.LastSchoolAttended);
                cmd.Parameters.AddWithValue("@DateOfAdmission", objEWA.DateOfAdmission);
                cmd.Parameters.AddWithValue("@Progress", objEWA.Progress);
                cmd.Parameters.AddWithValue("@Behaviour", objEWA.Behaviour);
                cmd.Parameters.AddWithValue("@DateOfLeaving", objEWA.DateOfLeaving);
                cmd.Parameters.AddWithValue("@YearStudying", objEWA.YearStudying);
                cmd.Parameters.AddWithValue("@Reaseon", objEWA.Reaseon);
                cmd.Parameters.AddWithValue("@Remarks", objEWA.Remarks);
                cmd.Parameters.AddWithValue("@TodayDate", objEWA.TodayDate);

                //pass OrgId
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);

                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Save LC

        //Return Application Id

        #region Get Application Id

        public DataSet DL_StudentLC(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "FetchLCRecord";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@AcademicYearId";
                prmList[5] = Convert.ToString(objEWA.AcademicYearId);
                prmList[6] = "@StudentId_Name";
                prmList[7] = objEWA.StudentId_Name;

                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return ds;
        }

        #endregion Get Application Id

        //Get student Record

        #region Get student Record

        public DataSet DL_StudentGetRecord(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "GetRecord";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.Usercode;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId;
                prmList[6] = "@AcademicYearId";
                prmList[7] = Convert.ToString(objEWA.AcademicYearId);

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return ds;
        }

        #endregion Get student Record

        //Check Duplicate Record in Leaving Certificate
        #region[Duplicate Record Findind]

        public DataSet CheckDuplicateRecord_DL(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();

            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckDuplicateRecord";
                prmList[2] = "@StudentId";
                prmList[3] = objEWA.StudentId;
                prmList[4] = "@OrgId";
                prmList[5] = objEWA.OrgId;

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        #endregion

        //Get All Student Leaving Certificate Record
        #region[All Student Leaving Certificate]

        public DataSet GetStudentAllRecord(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetAllStudentRecord";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@AcademicYearId";
                prmList[5] = Convert.ToString(objEWA.AcademicYearId);

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");
                if (ds.Tables[1].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return ds;
        }

        #endregion

        //Get Student Information
        #region[Get Student Information]

        public DataSet GetStudentInformation(EWA_LC objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "GetStudentInformation";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@AcademicYearId";
                prmList[5] = Convert.ToString(objEWA.AcademicYearId);
                prmList[6] = "@StudentId";
                prmList[7] = objEWA.StudentId;

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_LeavingCertificate");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return ds;
        }

        #endregion
    }
}
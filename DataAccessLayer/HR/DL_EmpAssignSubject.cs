using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.HR;

//Employee Course Class
namespace DataAccessLayer.HR
{
    public class DL_EmpAssignSubject
    {
        //Objects
        #region[Objects]
        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On EmpDeptDes Table
        #region[Perform Actions On Emp Dept Des]
        public int EmpCourseClassAction_DL(EWA_EmpAssignSubject objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_EmpAssignSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue("@SubjectId", objEWA.SubjectId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
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
            //finally
            //{
            //    con.Close();
            //    cmd.Dispose();
            //}
        }
        #endregion

        //To Bind EmployeeGrid
        #region[BindEmployeeGrid]
        public DataSet BindEmployeeGrid_DL(EWA_EmpAssignSubject objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[14];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@DesignationTypeId";
                prmList[5] = objEWA.DesignationTypeId.ToString();
                prmList[6] = "@CourseId";
                prmList[7] = objEWA.CourseId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;
                prmList[10] = "@SubjectId";
                prmList[11] = objEWA.SubjectId;
                prmList[12] = "@BranchId";
                prmList[13] = objEWA.BranchId;

                ds = ObjHelper.FillControl(prmList, "SP_EmpAssignSubject");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    return ds;
                //}
                //else
                //{
                //    DataTable dt = new DataTable();
                //    dt.Columns.Add("UserCode");
                //    dt.Columns.Add("SubjectCode");
                //    dt.Columns.Add("SubjectName");

                //    dt.Rows.Add();
                //    dt.Rows.Add();
                //    dt.Rows.Add();
                //    //return dsCode;
                //}
                return ds;
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }
        #endregion

        //Fetch Subject
        #region[Fetch Subject]
        public DataSet FetchSubject_DL(EWA_EmpAssignSubject ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@UserCode";
                prmList[3] = ObjEWA.UserCode;
                prmList[4] = "@OrgId";
                prmList[5] = ObjEWA.OrgId;
                ds = ObjHelper.FillControl(prmList, "SP_EmpAssignSubject");
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Program Executive
namespace DataAccessLayer.Admin
{
    public class DL_ProgramExecutive
    {
        //private SqlConnection con = new SqlConnection("Data Source=comp9;Initial Catalog=CMSDB;Persist Security Info=True;User ID=sa;Password=12345678");
        //Create Objects
        #region[Declare Objects]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion


        //To Perform Insert,Update,Delete and Search Actions On Course Table
        #region[Perform Actions On Course]
        public int CourseAction_DL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Course", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", objEWA.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", objEWA.CourseCode);

                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        //To Bind CourseGrid
        #region[Bind Course Grid]
        public DataSet BindCourseGrid_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Course");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CourseId");
                    dt.Columns.Add("CourseCode");
                    dt.Columns.Add("CourseName");

                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }  
        }
        #endregion

        //To CheckDuplicateCourse
        #region[Check Duplicate Course]
        public int CheckDuplicateCourse_DL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@CourseName";
                prmList[3] = objEWA.CourseName;

                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Course");
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

        //To Perform Insert,Update,Delete and Search Actions On Branch Table
        #region[Perform Actions On Branch]
        public int BranchAction_DL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Branch", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.ActionB);
                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@BranchName", objEWA.BranchName);
                cmd.Parameters.AddWithValue("@BranchCode", objEWA.BranchCode);
                cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        //To Bind BranchGrid
        #region[Bind Branch Grid]
        public DataSet BindBranchGrid_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                prmList[2] = "@CourseId";
                prmList[3] = objEWA.CourseId;

                ds = ObjHelper.FillControl(prmList, "SP_Branch");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BranchId");
                    dt.Columns.Add("BranchName");
                    dt.Columns.Add("BranchCode");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return ds;
        }
        #endregion

        //BindCourseDropDown
        #region[Bind Course Drop Down Region]
        public DataSet BindddlCourse_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchCourse";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Class");

                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //Bind Branch 
        #region[Bind Branch Drop Down Region]
        public DataSet BindddlBranchesD_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchBranches";

                prmList[2] = "@CourseId";
                prmList[3] = objEWA.CourseId;

                ds = ObjHelper.FillControl(prmList, "SP_Class");
                //if (ds.Tables[0].Rows.Count > 0)

                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Class Table
        #region[Perform Actions On Class]
        public int ClassAction_DL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Class", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.ActionC);
                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue("@ClassCode", objEWA.ClassCode);
                cmd.Parameters.AddWithValue("@ClassName", objEWA.ClassName);

                cmd.Parameters.AddWithValue("@BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        //To Bind ClassGrid
        #region[Bind Class Grid]
        public DataSet BindClassGrid_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@BranchId";
                prmList[3] = objEWA.BranchId;

                ds = ObjHelper.FillControl(prmList, "SP_Class");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ClassId");
                    dt.Columns.Add("ClassCode");
                    dt.Columns.Add("ClassName");

                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
         
        }
        #endregion

        //BindClassesDropDown
        #region[Bind Classes Drop Down Region]
        public DataSet BindddlClasses_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchClasses";

                prmList[2] = "@BranchId";
                prmList[3] = objEWA.BranchId;

                ds = ObjHelper.FillControl(prmList, "SP_Class");
                //if (ds.Tables[0].Rows.Count > 0)

                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Division Table
        #region[Perform Actions On Division]
        public int DivisionAction_DL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Division", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.ActionD);
                cmd.Parameters.AddWithValue("@DivisionId", objEWA.DivisionId);
                cmd.Parameters.AddWithValue("@DivisionName", objEWA.DivisionName);
                cmd.Parameters.AddWithValue("@DivisionCode", objEWA.DivisionCode);

                cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        //To Bind DivisionGrid
        #region[Bind Division Grid]
        public DataSet BindDivisionGrid_DL(EWA_ProgramExecutive objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@ClassId";
                prmList[3] = objEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "SP_Division");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DivisionId");
                    dt.Columns.Add("DivisionCode");
                    dt.Columns.Add("DivisionName");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
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
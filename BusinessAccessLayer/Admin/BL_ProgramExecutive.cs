using System;
using System.Data;
using DataAccessLayer.Admin;

//using EntityWebApp;
using EntityWebApp.Admin;

//Program Executive
namespace BusinessAccessLayer.Admin
{
    public class BL_ProgramExecutive
    {
        //Insert Update Delete operaeion on Course Table
        #region[Action Performed]

        public int CourseAction_BL(EWA_ProgramExecutive objEWA)
        {
            DL_ProgramExecutive objDL = new DL_ProgramExecutive();
            try
            {
                int flag = objDL.CourseAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //To Call Course Grid Bind
        #region[Course Grid Bind]

        public DataSet CourseGridBind_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindCourseGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Check Duplicate Data
        #region[Check Duplicate Course]

        public int CheckDuplicateCourse_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                int i = objDL.CheckDuplicateCourse_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operation on Branch Table
        #region[Action Performed]

        public int BranchAction_BL(EWA_ProgramExecutive objEWA)
        {
            DL_ProgramExecutive objDL = new DL_ProgramExecutive();
            try
            {
                int flag = objDL.BranchAction_DL(objEWA);
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
                // con.Close();
                // cmd.Dispose();
                objDL = null;
            }
        }

        #endregion

        //To Call BranchGridBind
        #region[Branch Grid Bind]

        public DataSet BranchGridBind_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindBranchGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //BindCourses
        #region[Bind Courses Region]

        public DataSet BindddlCourse_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindddlCourse_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Branches
        #region[Bind Branches]

        public DataSet BindddlBranchesD_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindddlBranchesD_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operaeion on Class Table
        #region[Action Performed]

        public int ClassAction_BL(EWA_ProgramExecutive objEWA)
        {
            DL_ProgramExecutive objDL = new DL_ProgramExecutive();
            try
            {
                int flag = objDL.ClassAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //To Call Class Grid Bind
        #region[Class Grid Bind]

        public DataSet ClassGridBind_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindClassGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Classes
        #region[Bind Classes Region]

        public DataSet BindddlClasses_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindddlClasses_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operaeion on Division Table
        #region[Action Performed]

        public int DivisionAction_BL(EWA_ProgramExecutive objEWA)
        {
            DL_ProgramExecutive objDL = new DL_ProgramExecutive();
            try
            {
                int flag = objDL.DivisionAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //To Call CourseGridBind
        #region[Division GridBind]

        public DataSet DivisionGridBind_BL(EWA_ProgramExecutive objEWA)
        {
            try
            {
                DL_ProgramExecutive objDL = new DL_ProgramExecutive();
                DataSet ds = objDL.BindDivisionGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
using System;

//Add this Namespaces
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Student View
namespace DataAccessLayer.Admin
{
    public class DL_StudentView
    {
        //Objects
        #region[Object Declaration[
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Student View Profile
        #region[Student Id View]

        public DataSet DL_ShowStudentViewProfile(EWA_StudentView objEWA)
        {
            DataSet ds = new DataSet();

            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                //Stored procedure Action value
                prmList[1] = "SelectStudentICardView";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);
                prmList[4] = "@UserCode";
                prmList[5] = Convert.ToString(objEWA.StudentID);

                //Stored procedure name
                ds = ObjHelper.FillControl(prmList, "SP_Student");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                return ds;
            }
            catch (Exception)
            {
                // GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        // Bind GrdId GrdId_DL
        #region[Bind GrdId]

        public DataSet DL_StudentIcard(EWA_StudentView objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudentData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId.ToString();
                prmList[6] = "@ClassId";
                prmList[7] = objEWA.ClassId.ToString();
                prmList[8] = "@BranchId";
                prmList[9] = objEWA.BranchId.ToString();
                //[2] = "@Course";
                //prmList[3] = objEWA.Course;
                //prmList[2] = "@Branch";
                //prmList[3] = objEWA.Branch;
                //prmList[2] = "@Class";
                //prmList[3] = objEWA.Class;
                //prmList[2] = "@Division";
                //prmList[3] = objEWA.Division;

                ds = ObjHelper.FillControl(prmList, "SP_Student");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
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
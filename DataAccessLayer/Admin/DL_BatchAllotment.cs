using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Batch Allotment
namespace DataAccessLayer.Admin
{
    public class DL_BatchAllotment
    {
        // Object Declaration

        #region[Object Declaration]

        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //Bind Student Data
        #region[Bind Student Data]

        public DataSet DL_BindStudentData(EWA_BatchAllotment objEWABatch)
        {
            DataSet ds = new DataSet();
            try
            {
                // DateTime dt = DateTime.Parse(objEWA.FromDate);
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudentData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWABatch.OrgId);
                prmList[4] = "@AcademicYearId";
                prmList[5] = Convert.ToString(objEWABatch.AcademicYearId);
                prmList[6] = "@CourseId";
                prmList[7] = Convert.ToString(objEWABatch.CourseId);
                prmList[8] = "@BranchId";
                prmList[9] = Convert.ToString(objEWABatch.BranchId);
                prmList[10] = "@ClassId";
                prmList[11] = Convert.ToString(objEWABatch.ClassId);

                ds = ObjHelper.FillControl(prmList, "SP_BatchAllotment");

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
                //GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        //Set Division
        #region[Set Division]

        public int DL_SetDivision(EWA_BatchAllotment objEWABatch, DataTable StudentDataTable)
        {
            try
            {
                cmd = new SqlCommand("SP_BatchAllotment", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWABatch.Action);
                cmd.Parameters.AddWithValue("@DivisionId", objEWABatch.DivisionId);

                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@StudentDataTable", StudentDataTable);  //Passing table value parameter
                tblvaluetype.SqlDbType = SqlDbType.Structured;

                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Faculty;

//Compose Message
namespace DataAccessLayer.Faculty
{
    public class DL_ComposeMessage
    {
        //Objects
        #region[Declare Objects]
        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        //SqlTransaction sqlTransaction;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //Bind Grid Data
        #region[Bind Grid Data]
        public DataSet BindGridData_DL(EWA_ComposeMessage ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[14];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                prmList[10] = "@DepartmentId";
                prmList[11] = ObjEWA.DepartmentId;
                prmList[12] = "@DesignationId";
                prmList[13] = ObjEWA.DesignationId;

                ds = ObjHelper.FillControl(prmList, "SP_SMS");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
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
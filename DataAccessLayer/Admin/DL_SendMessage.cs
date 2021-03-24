using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Send Message
namespace DataAccessLayer.Admin
{
    public class DL_SendMessage
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion

        //To Bind EmployeeGrid
        #region[Bind Employee Grid]

        public DataSet BindEmployeeGrid_DL(EWA_SendMessage objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "SelectEmployee";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@DepartmentId";
                prmList[5] = objEWA.DepartmentId;
                prmList[6] = "@DesignationTypeId";
                prmList[7] = objEWA.DesignationTypeId;
                prmList[8] = "@DesignationId";
                prmList[9] = objEWA.DesignationId;

                ds = ObjHelper.FillControl(prmList, "SP_SendSMS");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserCode");
                    dt.Columns.Add("FullName");
                    dt.Columns.Add("Designation");
                    dt.Columns.Add("Mobile");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
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

        //To Bind StudentGrid
        #region[Bind Student Grid]

        public DataSet BindStudentGrid_DL(EWA_SendMessage objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "SelectStudent";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;

                ds = ObjHelper.FillControl(prmList, "SP_SendSMS");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserCode");
                    dt.Columns.Add("FullName");
                    dt.Columns.Add("Mobile");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To Bind ParentGrid
        #region[Bind Parent Grid]

        public DataSet BindParentGrid_DL(EWA_SendMessage objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = "SelectParent";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;
             

                ds = ObjHelper.FillControl(prmList, "SP_SendSMS");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserCode");
                    dt.Columns.Add("FullName");
                    dt.Columns.Add("FatherName");
                    dt.Columns.Add("Mobile");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Inventory;

namespace DataAccessLayer.Inventory
{
    public class DL_Supplier
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        private SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //Bind Supplier category
        #region[Bind Supplier category]

        public DataSet BindCategory_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "FetchCategory";

                //prmList[2] = "@OrgId";
                //prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Supplier");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
             
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind Item Category
        #region[Bind Item Grid]

        public DataSet BindItemGrid_DL(EWA_Supplier objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchItemData";

               // prmList[2] = "@CategoryId";
               // prmList[3] = objEWA.CategoryId;
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Supplier");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ItemName");

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

        //Perform Action on Supplier Table

        #region[Perform Actions On Supplier]

        public int SupplierAction_DL(EWA_Supplier objEWA,DataTable dt)
        {
            try
            {
                cmd = new SqlCommand("SP_Supplier", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@SupplierId", objEWA.SupplierId);
                cmd.Parameters.AddWithValue("@SupplierName", objEWA.SupplierName);
                cmd.Parameters.AddWithValue("@MobileNo", objEWA.MobileNo);
                cmd.Parameters.AddWithValue("@PhoneNo", objEWA.PhoneNo);
                cmd.Parameters.AddWithValue("@FaxNo", objEWA.FaxNo);
                cmd.Parameters.AddWithValue("@EmailId", objEWA.EmailId);
                cmd.Parameters.AddWithValue("@Website", objEWA.Website);
                cmd.Parameters.AddWithValue("@Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@SupplierItem", dt);  //Passing table value parameter
                tblvaluetype.SqlDbType = SqlDbType.Structured;

                con.Open();
                sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;
                int flag = cmd.ExecuteNonQuery();
                sqlTransaction.Commit();   
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

        //Bind Supplier Category
        #region[Bind Supplier Grid]

        public DataSet BindSupplierGrid_DL(EWA_Supplier objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Supplier");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SupplierName");

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

        //Bind Supplier Data To Update & Delete
        #region[Bind Supplier Data]

        public DataSet BindSupplierData_DL(EWA_Supplier objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetDataAccordingId";
                prmList[2] = "@SupplierId";
                prmList[3] = Convert.ToString(objEWA.SupplierId);
                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Supplier");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SupplierName");

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
        //To Check Duplicate Supplier 
        #region[Check Duplicate Supplier]

        public int CheckDuplicateSupplier_DL(EWA_Supplier objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@SupplierName";
                prmList[3] = objEWA.SupplierName;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Supplier");
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

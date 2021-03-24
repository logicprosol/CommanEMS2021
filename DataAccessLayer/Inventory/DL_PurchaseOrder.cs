using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntityWebApp.Inventory;

namespace DataAccessLayer.Inventory
{
    public class DL_PurchaseOrder
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

        //Get GetPOCode
        #region[Max POCode Id]
        public DataSet GetPOCode_DL(EWA_PurchaseOrder objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetCode";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_PurchaseOrder");
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


        //Bind Supplier category
        #region[Bind Supplier]

        public DataSet BindSupplier_DL(EWA_PurchaseOrder objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchSupplier";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_PurchaseOrder");
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

        public DataSet BindItemGrid_DL(EWA_PurchaseOrder objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchItemData";

                prmList[2] = "@SupplierId";
                prmList[3] = objEWA.SupplierId;

                ds = ObjHelper.FillControl(prmList, "SP_PurchaseOrder");
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

        public DataSet POAction_DL(EWA_PurchaseOrder objEWA, DataTable dt)
        { DataSet ds=new DataSet();
            try
            {
                cmd = new SqlCommand("SP_PurchaseOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@POId", objEWA.POId);
                cmd.Parameters.AddWithValue("@PODate", objEWA.PODate);
                cmd.Parameters.AddWithValue("@POCode", objEWA.POCode);
                cmd.Parameters.AddWithValue("@SupplierId", objEWA.SupplierId);
                cmd.Parameters.AddWithValue("@GrandTotal", objEWA.GrandTotal);
                cmd.Parameters.AddWithValue("@PaymentMode", objEWA.PaymentMode);
                cmd.Parameters.AddWithValue("@DeliveryMode", objEWA.DeliveryMode);

                cmd.Parameters.AddWithValue("@Remark", objEWA.Remark);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                // cmd.Parameters.AddWithValue("@Status", objEWA.Status);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@PODetails", dt);  //Passing table value parameter
                tblvaluetype.SqlDbType = SqlDbType.Structured;

                con.Open();
                sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;
               
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                //int flag = cmd.ExecuteNonQuery();
                sqlTransaction.Commit();
                
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
                    //throw ex;
                }
            }
            finally 
            {
               
                cmd.Dispose();
                con.Close();
            }
       return ds;
        }

        #endregion

        //Bind Supplier Category
        #region[Bind Supplier Grid]

        public DataSet BindSupplierGrid_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

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

        // Bind Purchase Order Report
        #region[Purchase Order Report]
        public DataSet BindPurchaseOrderReport(EWA_PurchaseOrder objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "PrintPO";
                prmList[2] = "@POCode";
                prmList[3] = objEWA.POCode;

                ds = ObjHelper.FillControl(prmList, "SP_PurchaseOrder");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

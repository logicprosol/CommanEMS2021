using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntityWebApp.Inventory;

namespace DataAccessLayer.Inventory
{
    public class DL_QualityControl
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
        #region[Max POCode Code]
        public DataSet GetPOCode_DL(EWA_QualityControl objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetPOCode";
                prmList[2] = "@POCode";
                prmList[3] = objEWA.PreText;
                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_QualityControl");
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

        //Get GetQCCode
        #region[Max QCCode Id]
        public DataSet GetQCCode_DL(EWA_QualityControl objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "GetCode";
                //prmList[2] = "@OrgId";
                //prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_QualityControl");
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

        public DataSet BindSupplier_DL(EWA_QualityControl objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchSupplier";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_QualityControl");
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

        public DataSet BindItemGrid_DL(EWA_QualityControl objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchItemData";

                prmList[2] = "@SupplierId";
                prmList[3] = objEWA.SupplierId;

                ds = ObjHelper.FillControl(prmList, "SP_QualityControl");
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

        public int QCAction_DL(EWA_QualityControl objEWA, DataTable dt)
        {
            try
            {
                cmd = new SqlCommand("SP_QualityControl", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@POId", objEWA.POId);
                cmd.Parameters.AddWithValue("@QCId", objEWA.QCId);
                cmd.Parameters.AddWithValue("@QCDate", objEWA.QCDate);
                cmd.Parameters.AddWithValue("@POCode", objEWA.POCode);
                cmd.Parameters.AddWithValue("@SupplierId", objEWA.SupplierId);
              
                cmd.Parameters.AddWithValue("@Remark", objEWA.Remark);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);

                SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@QCDetails", dt);  //Passing table value parameter
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


        //Get Data
        #region[Get Data]

        public DataSet BindPODetails_DL(EWA_QualityControl objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "GetDataByPOCode";
                prmList[2] = "@POCode";
                prmList[3] = objEWA.POCode;
                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                DataSet ds = ObjHelper.FillControl(prmList, "SP_QualityControl");
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

    }
}

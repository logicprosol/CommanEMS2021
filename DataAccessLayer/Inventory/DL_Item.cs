using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntityWebApp.Inventory;

namespace DataAccessLayer.Inventory
{
   public class DL_Item
    {
        //Objects
        #region[Declare Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //Get GetItemCode
        #region[Max ItemCode Id]
        public DataSet GetItemCode_DL(EWA_Item objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "GetCode";
                prmList[2] = "@CategoryId";
                prmList[3] = Convert.ToString(objEWA.CategoryId);

                ds = ObjHelper.FillControl(prmList, "SP_Item");
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

        //Bind Item category
        #region[Bind Item category]

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

                ds = ObjHelper.FillControl(prmList, "SP_Item");
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

        //Bind Item Unit
        #region[Bind Item Unit]

        public DataSet BindUnit_DL(EWA_Item objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchUnit";

                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Item");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Perform Action on Item Table

        #region[Perform Actions On Item]

        public int ItemAction_DL(EWA_Item objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Item", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@ItemId", objEWA.ItemId);
                cmd.Parameters.AddWithValue("@ItemName", objEWA.ItemName);
                cmd.Parameters.AddWithValue("@ItemCode", objEWA.ItemCode);
                cmd.Parameters.AddWithValue("@CategoryId", objEWA.CategoryId);
                cmd.Parameters.AddWithValue("@UnitId", objEWA.UnitId);
                cmd.Parameters.AddWithValue("@Stock", objEWA.Stock);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
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

        //Bind Item Category
        #region[Bind Item Grid]

        public DataSet BindItemGrid_DL()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                ds = ObjHelper.FillControl(prmList, "SP_Item");
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

        //To Check Duplicate Item 
        #region[Check Duplicate Item]

        public int CheckDuplicateItem_DL(EWA_Item objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@ItemName";
                prmList[3] = objEWA.ItemName;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Item");
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

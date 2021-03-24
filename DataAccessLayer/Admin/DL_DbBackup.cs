using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Admin
{
 
    public class DL_DbBackup
    {
        //Objects

        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #endregion 

        //Get Backup List
        #region[Get Backup List]
        //
        public int GetDBBackup()
        {
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "BackUp";
                int count= ObjHelper.ExecuteQueryForBackup(prmList, "GETDATABACKUP");
                if (count > 0)
                {
                    return count;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ExFileName");
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                  
                }
                return count;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

    }
}

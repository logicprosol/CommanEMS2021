using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Batch Allotment
namespace BusinessAccessLayer.Admin
{
    public class BL_BatchAllotment
    {
        //Objects
        #region[Objects]
        private DL_BatchAllotment objBatchDL = new DL_BatchAllotment();
        #endregion

        //Student Data
        #region[Student Data]
        public DataSet BL_StudentData(EWA_BatchAllotment objEWABatch)
        {
            try
            {
                DataSet ds = objBatchDL.DL_BindStudentData(objEWABatch);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Set Division
        #region [Set Division]
        public int SetDivision(EWA_BatchAllotment objEWABatch, DataTable StudentDataTable)
        {
            try
            {
                int flag = objBatchDL.DL_SetDivision(objEWABatch, StudentDataTable);
                return flag;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
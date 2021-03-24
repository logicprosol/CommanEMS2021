using System;

//Add this Namespaces
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
    public class BL_LC
    {
        //Create the object of DL_LC
        private DL_LC objDL = new DL_LC();

        // Bind Student Usercode
        #region[ Bind Student Usercode]

        public DataSet BindUsercode_BL(EWA_LC objEWA)
        {
            DL_LC objDL = new DL_LC();
            DataSet ds = objDL.BindUsercode_DL(objEWA);
            return ds;
        }

        #endregion

        //Save Records Student Leaving Certificate
        #region[Save record-Leaving Certificate Record]

        public int BL_SaveUpdateLC(EWA_LC objEWA)
        {
            DL_LC objDL = new DL_LC();
            try
            {
                int flag = objDL.SaveUpdateLC_DL(objEWA);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        

        //Fetch Records From student table for Leaving certificate
        #region Student Leaving Ceritificate

        public DataSet BL_LeavingCertificate(EWA_LC objEWA)
        {
            try
            {
                DL_LC objDL = new DL_LC();
                DataSet ds = objDL.DL_LeavingCertificate(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Fetch Student Is and Name
        #region[Student Id and name]

        public DataSet BL_StudentLC(EWA_LC objEWA)
        {
            try
            {
                DL_LC objDL = new DL_LC();
                DataSet ds = objDL.DL_StudentLC(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get student Record From LC Table
        #region[Student Get Record]

        public DataSet BL_StudentGetRecord(EWA_LC objEWA)
        {
            try
            {
                DL_LC objDL = new DL_LC();
                DataSet ds = objDL.DL_StudentGetRecord(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Check for Duplicate Record
        #region[Duplicate Record]

        public DataSet BL_CheckDuplicateRecord(EWA_LC objEWA)
        {
            try
            {
                DL_LC objDL = new DL_LC();
                DataSet ds = objDL.CheckDuplicateRecord_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //All Student Leaving certificate Records
        #region[Get All Student Records]

        public DataSet GetStudentAllRecord(EWA_LC objEWA)
        {
            try
            {
                DL_LC objDL = new DL_LC();
                DataSet ds = objDL.GetStudentAllRecord(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Student Information
        #region[Get Student Information]

        public DataSet BL_GetStudentInformation(EWA_LC objEWA)
        {
            try
            {
                DL_LC objDL = new DL_LC();
                DataSet ds = objDL.GetStudentInformation(objEWA);
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
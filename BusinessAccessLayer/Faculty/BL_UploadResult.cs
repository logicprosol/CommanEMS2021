using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Faculty
{
    public class BL_UploadResult
    {

        #region[Bind UploadTest]

        public int InsertUploadTest_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                int rs = objDL.InsertUploadTest_DL(objEWA);
                return rs;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind UploadResult]

        public int InsertUploadResult_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                int rs = objDL.InsertUploadResult_DL(objEWA);
                return rs;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Bind UploadMark]

        public int InsertUploadMark_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                int rs = objDL.InsertUploadMark_DL(objEWA);
                return rs;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Fatch Student
        #region[Fatch Student]

        public DataSet FatchStudent_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                DataSet ds = objDL.FatchStudent_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Fatch Test
        #region[Fatch Test]

        public DataSet FatchTest_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                DataSet ds = objDL.FatchTest_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Fatch Result
        #region[Fatch Result]

        public DataSet FatchResult_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                DataSet ds = objDL.FatchResult_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion


        #region[Bind UploadResultPDF]

        public int InsertUploadResultPDF_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                int rs = objDL.InsertUploadResultPDF_DL(objEWA);
                return rs;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        // Fatch ResultPDF
        #region[Fatch ResultPDF]

        public DataSet FatchResultPDF_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                DataSet ds = objDL.FatchResultPDF_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet FatchResultPDF_BL1(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                DataSet ds = objDL.FatchResultPDF_DL1(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        #region[Delete UploadResultPDF]

        public int DeleteUploadResultPDF_BL(EWA_UploadResult objEWA)
        {
            try
            {
                DL_UploadResult objDL = new DL_UploadResult();
                int rs = objDL.DeleteUploadResultPDF_DL(objEWA);
                return rs;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

    }
}

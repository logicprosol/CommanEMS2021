using System;
using System.Data;
using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;

//Faculty Upload Document
namespace BusinessAccessLayer.Faculty
{
    public class BL_UploadDocument
    {
        //Student Bind Data
        #region[Student Bind Data]

        public DataSet StudentBind_BL(EWA_UploadDocument ObjEWA)
        {
            try
            {
                DataSet ds = null;
                DL_UploadDocument ObjDL = new DL_UploadDocument();
                ds = ObjDL.StudentBind_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Upload Document
        #region[Upload Document]

        public int UploadDocument_BL(EWA_UploadDocument ObjEWA)
        {
            try
            {
                int flag;
                DL_UploadDocument ObjDL = new DL_UploadDocument();
                flag = ObjDL.UploadDocument_DL(ObjEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public DataSet BindUploadDocument_BL(EWA_UploadDocument ObjEWA)
        {
            DataSet ds=null;
            try
            {
                DL_UploadDocument ObjDL = new DL_UploadDocument();
                ds = ObjDL.BindUploadDocument_DL(ObjEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
           // return ds;
        }

        public void DeleteUploadDocument_BL(EWA_UploadDocument ObjEWA)
        {
            try
            {
                DL_UploadDocument ObjDL = new DL_UploadDocument();
                ObjDL.DeleteUploadDocument_DL(ObjEWA);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
using System;
using System.Data;
using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;

//faculty Message
namespace BusinessAccessLayer.Faculty
{
    public class BL_Messages
    {
        //Object
        #region[Object]
        private DL_Messages ObjDL = new DL_Messages();
        #endregion

        //Save Student Message
        #region[Save Student Message]

        public string SaveStudentMessage_BL(EWA_Messages ObjEWA)
        {
            try
            {
                string messageid= ObjDL.SaveStudentMessage_DL(ObjEWA);
                return messageid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Send Student Message
        #region[Send Student Message]

        public void SendStudentMessage_BL(EWA_Messages ObjEWA, string[] StudentId)
        {
            try
            {
                ObjDL.SendStudentMessage_DL(ObjEWA, StudentId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Save Staff Message
        #region[Save Staff Message]

        public string SaveStaffMessage_BL(EWA_Messages ObjEWA)
        {
            try
            {
                string messageid =  ObjDL.SaveStaffMessage_DL(ObjEWA);
                return messageid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Send Staff Message
        #region[Send Staff Message]

        public void SendStaffMessage_BL(EWA_Messages ObjEWA, string[] StaffId)
        {
            try
            {
                ObjDL.SendStaffMessage_DL(ObjEWA, StaffId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Grid view anouncement
        #region[Grid View announcement]

        public DataSet BindGrdViewAnnouncement_BL(EWA_Messages objEWA)
        {
            try
            {
                DataSet ds = null;
                DL_Messages objDL = new DL_Messages();
                ds = objDL.BindGrdViewAnnouncement_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
      
        //Save Attachment
        #region[Save Attachment]

        public void SaveAttachment_BL(EWA_Messages ObjEWA)
        {
            try
            {
                DL_Messages ObjDL = new DL_Messages();
                ObjDL.SaveAttachment_DL(ObjEWA);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
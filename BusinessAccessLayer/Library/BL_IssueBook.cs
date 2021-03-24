using System;
using System.Data;
using DataAccessLayer.Library;
using EntityWebApp.Library;

namespace BusinessAccessLayer.Library
{
    public class BL_IssueBook
    {
        DL_IssueBook objDL = new DL_IssueBook();

        public int IssueBookAction_BL(EWA_IssueBook objEWA)
        {
            int flag = objDL.IssueBookAction_DL(objEWA);
            return flag;
        }

        public DataSet GetIsueeBook_BL(EWA_IssueBook objEWA)
        {
            DataSet ds = objDL.GetIsueeBook_DL(objEWA);
            return ds;
        }

        public DataSet GetBookGroup_BL(EWA_IssueBook objEWA)
        {
            DataSet ds = objDL.GetBookGroup_DL(objEWA);
            return ds;
        }

        public DataSet GetBook_BL(EWA_IssueBook objEWA)
        {
            DataSet ds = objDL.GetBook_DL(objEWA);
            return ds;
        }

        public DataSet GetBookInfo_BL(EWA_IssueBook objEWA)
        {
            DataSet ds = objDL.GetBookInfo_DL(objEWA);
            return ds;
        }

        public DataSet GetStudentInfo_BL(EWA_IssueBook objEWA)
        {
            DataSet ds = objDL.GetStudentInfo_DL(objEWA);
            return ds;
        }
    }
}

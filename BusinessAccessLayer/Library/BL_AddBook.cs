using System;
using System.Data;
using DataAccessLayer.Library;
using EntityWebApp.Library;

namespace BusinessAccessLayer.Library
{
    public class BL_AddBook
    {
        DL_AddBook objDL = new DL_AddBook();

        public int BookAction_BL(EWA_AddBook objEWA)
        {
            int flag = objDL.BookAction_DL(objEWA);
            return flag;
        }

        public DataSet GetBook_BL(EWA_AddBook objEWA)
        {
            DL_AddBook objDL = new DL_AddBook();
            DataSet ds = objDL.GetBook_DL(objEWA);
            return ds;
        }

        public int CheckBookName_BL(EWA_AddBook objEWA)
        {
            int cnt = objDL.CheckBookName_DL(objEWA);
            return cnt;
        }

        public DataSet GetBookGroup_BL()
        {
            DataSet ds = objDL.GetBookGroup_DL();
            return ds;
        }
    }
}

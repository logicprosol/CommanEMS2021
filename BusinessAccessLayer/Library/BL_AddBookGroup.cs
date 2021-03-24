using System;
using System.Data;
using DataAccessLayer.Library;
using EntityWebApp.Library;

namespace BusinessAccessLayer.Library
{
    public class BL_AddBookGroup
    {
        DL_AddBookGroup objDL = new DL_AddBookGroup();

        public int BookGroupAction_BL(EWA_AddBookGroup objEWA)
        {
            int flag = objDL.BookGroupAction_DL(objEWA);
            return flag;
        }

        public DataSet GetBookGroup_BL(EWA_AddBookGroup objEWA)
        {
            DataSet ds = objDL.GetBookGroup_DL(objEWA);
            return ds;
        }

        public int CheckGroupName_BL(EWA_AddBookGroup objEWA)
        {
            int cnt = objDL.CheckGroupName_DL(objEWA);
            return cnt;
        }
    }
}

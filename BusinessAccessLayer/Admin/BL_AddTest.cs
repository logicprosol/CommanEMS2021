using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;
namespace BusinessAccessLayer.Admin
{
   public class BL_AddTest
    {
        DL_AddTest ObjDAL = new DL_AddTest();

        public int AddTest(EWA_AddTest objBEL)
        {
            try
            {
                int flag = ObjDAL.AddTest(objBEL, "sp_Insert_TestDetails");
                return flag;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

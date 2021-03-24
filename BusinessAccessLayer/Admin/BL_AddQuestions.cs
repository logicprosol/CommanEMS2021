using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;
namespace BusinessAccessLayer.Admin
{
   public class BL_AddQuestions
    {
        DL_AddQuestions ObjDAL = new DL_AddQuestions();

        public int AddQuestions(EWA_AddQuestions obj)
        {
            try
            {
                int flag = ObjDAL.AddQuestions(obj, "sp_Insert_Questions");
                return flag;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
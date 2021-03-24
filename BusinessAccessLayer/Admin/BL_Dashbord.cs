using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
  

    public class BL_Dashbord
    {
         DL_Dashbord objDL = new DL_Dashbord();

         public DataSet GetData(EWA_Dashbord objEWA)
         {
             DataSet dt = new DataSet();
             dt = objDL.DL_GetData(objEWA);

             return dt;

         }




       
    }
}

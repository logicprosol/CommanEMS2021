using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Data;
namespace BusinessAccessLayer.Admin
{
    public class BL_AddHostelRoom
    {
         //Objects

        #region [Objects]

       private DL_AddHostelRoom objDL = new DL_AddHostelRoom();

        #endregion [Objects]

       //Action Performed
       #region[ActionPerformed For AddHostelRoom]

       public int CategoryAction_BL(EWA_AddHostelRoom objEWA)
        {

            try
            {
                DL_AddHostelRoom objDL = new  DL_AddHostelRoom();
                int flag = objDL.CategoryAction_DL(objEWA);
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

    }
}

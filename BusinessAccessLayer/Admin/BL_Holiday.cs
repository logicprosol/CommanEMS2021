using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Admin
{
    public class BL_Holiday
    {
        DL_Holiday objDL = new DL_Holiday();

        #region[ActionPerformed For Holiday]

        public int HolidayAction_BL(EWA_Holiday objEWA)
        {
            try
            {
                int flag = objDL.HolidayAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call HolidayGridBind
        #region[Holiday Grid Bind]

        public DataSet HolidayGridBind_BL(EWA_Holiday objEWA)
        {
            try
            {
                DataSet ds = objDL.HolidayGridBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}

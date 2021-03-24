using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Week Day
namespace BusinessAccessLayer.Admin
{
    public class BL_WeekDay
    {
        //objects
        #region[Objects]
        private DL_WeekDay objDL = new DL_WeekDay();
        #endregion

        //Day Grid Bind
        #region[DayGridBind_BL]

        public DataSet DayGridBind_BL(EWA_WeekDay objEWA)
        {
            try
            {
                DataSet ds = objDL.BindDayGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Action Perform on WeekDay Table
        #region[Week Day Action_BL]

        public int WeekDayAction_BL(EWA_WeekDay objEWA)
        {
            try
            {
                int flag = objDL.WeekDayAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Check Duplicate Organization record
        #region[Check Duplicate Org]

        public int CheckDuplicateOrg_BL(EWA_WeekDay objEWA)
        {
            try
            {
                int i = objDL.CheckDuplicateOrg_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
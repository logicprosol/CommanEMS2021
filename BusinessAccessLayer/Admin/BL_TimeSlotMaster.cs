using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
    public class BL_TimeSlotMaster
    {
        //Objects

        #region [Objects]

        private DL_TimeSlotMaster objDL = new DL_TimeSlotMaster();

        #endregion [Objects]

        //Insert Update Delete operaeion on AcademicYear Table

        #region [Action Performed]

        public int TimeSlotMaster_BL(EWA_TimeSlotMaster objEWA)
        {
            try
            {
                DL_TimeSlotMaster objDL = new DL_TimeSlotMaster();
                int flag = objDL.TimeSlotAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion [Action Performed]


        public DataSet GetTimeSlotData(EWA_TimeSlotMaster objEWA)
        {
            try
            {
                DL_TimeSlotMaster objDL = new DL_TimeSlotMaster();
                DataSet ds = objDL.GetTimeSlotData(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        public int CheckData(EWA_TimeSlotMaster objEWA)
        {
            try
            {
                DL_TimeSlotMaster objDL = new DL_TimeSlotMaster();
                int cnt = objDL.CheckData(objEWA);
                return cnt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}

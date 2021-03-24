using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Admin Device Setting
namespace BusinessAccessLayer.Admin
{
    public class BL_DeviceSetting
    {
        //Object
        #region[Object]
        private DL_DeviceSetting objDL = new DL_DeviceSetting();
        #endregion

        //Insert Update Delete operation on Device Setting Table
        #region[Action Performed For Device Setting]

        public int DeviceSettingAction_BL(EWA_DeviceSetting objEWA)
        {
            try
            {
                int flag = objDL.DeviceSettingAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call DeviceGridBind
        #region[Device Grid Bind]

        public DataSet DeviceGridBind_BL(EWA_DeviceSetting objEWA)
        {
            try
            {
                DataSet ds = objDL.BindDeviceGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Check Duplicate Data Of Device
        #region[Check Duplicate Device]

        public int CheckDuplicateDevice_BL(EWA_DeviceSetting objEWA)
        {
            try
            {
                int i = objDL.CheckDuplicateDevice_DL(objEWA);
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
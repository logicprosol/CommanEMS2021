using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
    /* =============================================
-- Author:		Deepak Sawant
-- Create date: 06/Jan/2014
-- Description:	To Perform DownloadAttDeviceData Operation
-- ============================================= */

    public class BL_DownloadAttDeviceData
    {
        // Bind Department BindDepartment_BL

        #region[Bind DeviceSettings]

        public DataSet BindAttDevices_BL(EWA_DownloadAttDeviceData objEWA)
        {
            try
            {
                DL_DownloadAttDeviceData objDL = new DL_DownloadAttDeviceData();
                DataSet ds = objDL.BindAttDevices_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Action

        public int DeviceDataAction_BL(DataTable dt)
        {
           
            try
            {
                DL_DownloadAttDeviceData objDL = new DL_DownloadAttDeviceData();
                int flag = objDL.DeviceDataAction_DL(dt);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Action
    }
}
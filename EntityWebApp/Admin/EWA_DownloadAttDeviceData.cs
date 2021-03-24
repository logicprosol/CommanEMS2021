using System;
namespace EntityWebApp.Admin
{
    /* =============================================
  -- Author:		Deepak Sawant
  -- Create date: 29/Jan/2014
  -- Description:	To Perform DownloadAttDeviceData Operation
  -- ============================================= */

    public class EWA_DownloadAttDeviceData
    {
        #region DeclareDownloadAttDeviceDataRegion

        public string Action { get; set; }

        public string OrgId { get; set; }

        public string DeviceId { get; set; }

        public DateTime CreateOn { get; set; }

        public Int32 CreatedBy { get; set; }

        #endregion DeclareDownloadAttDeviceDataRegion
    }
}
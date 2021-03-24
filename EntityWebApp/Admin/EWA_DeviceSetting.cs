using System;

namespace EntityWebApp.Admin
{
    public class EWA_DeviceSetting
    {
        //Properties of Device Setting

        #region Properties

        public string Action { get; set; }

        public string DeviceSettingId { get; set; }

        public string DeviceName { get; set; }

        public string IP { get; set; }

        public string PortNo { get; set; }

        public string MachineId { get; set; }

        public string Description { get; set; }

        public string OrgId { get; set; }

        public string UserId { get; set; }

        public Boolean IsActive { get; set; }

        #endregion Properties
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_AddHostelRoom
    {
        #region AddHostelRoomRegion

        public string Action { get; set; }
        public int HostelId { get; set; }
        public string HostelName { get; set; }
        public int Types { get; set; }
        public string Address { get; set; }
        public string TotalRoom { get; set; }
        public string AllocateRoom { get; set; }

        #endregion 
    }
}

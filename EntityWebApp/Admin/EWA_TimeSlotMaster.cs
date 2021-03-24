using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_TimeSlotMaster
    {
        public string Action { get; set; }
        public Int32 SlotId { get; set; }
        public string SlotFrom { get; set; }
        public string SlotTo { get; set; }
        public int SlotType { get; set; }
        public int OrgId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }
    }
}

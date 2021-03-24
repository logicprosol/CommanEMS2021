using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Inventory
{
   public class EWA_Unit
    {
        #region AddUnitPropertyRegion

        public string Action { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int OrgId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }

        #endregion
    }
}

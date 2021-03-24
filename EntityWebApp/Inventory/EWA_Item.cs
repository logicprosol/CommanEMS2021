using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Inventory
{
   public class EWA_Item
    {
        #region AddUnitPropertyRegion

        public string Action { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryId { get; set; }
        public string ItemCode { get; set; }
        public string UnitId { get; set; }
        public int OrgId { get; set; }
        public int DeptId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }
        public string Stock { get; set; }

        #endregion
    }
}

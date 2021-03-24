using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Inventory
{
    public class EWA_QualityControl
    {
        #region AddSupplierPropertyRegion

        public string Action { get; set; }
        public int QCId { get; set; }
        public int POId { get; set; }
        public string PreText { get; set; }
        public DateTime PODate { get; set; }
        public string POCode { get; set; }
        public DateTime QCDate { get; set; }
        public string SupplierId { get; set; }
        public string ItemId { get; set; }
        public string Remark { get; set; }
        public int OrgId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }

        #endregion
    }
}

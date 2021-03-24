using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Inventory
{
    public class EWA_Supplier
    {
        #region AddSupplierPropertyRegion

        public string Action { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string CategoryId { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public int OrgId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }
        public string ItemId { get; set; }
        #endregion
    }
}

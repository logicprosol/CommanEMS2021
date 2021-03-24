using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntityWebApp.Inventory
{
    public class EWA_Category
    {
        #region AddCategoryPropertyRegion

        public string Action { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int OrgId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }

        #endregion 
    }
}

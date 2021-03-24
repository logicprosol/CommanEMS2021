using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Library
{
    public class EWA_AddBookGroup
    {
        public string Action { get; set; }
        public Int32 GroupId { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 UserId { get; set; }
        public string IsActive { get; set; }
    }
}

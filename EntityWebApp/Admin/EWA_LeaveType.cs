using System;

namespace EntityWebApp.Admin
{
    public class EWA_LeaveType
    {
        public string Action { get; set; }

        public string LeaveId { get; set; }

        public string LeaveCode { get; set; }

        public string LeaveName { get; set; }

        public int LeaveCount { get; set; }

        public string OrgId { get; set; }

        public string UserId { get; set; }

        public Boolean IsActive { get; set; }
    }
}
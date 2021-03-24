using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_SetLeave
    {
        public string Action { get; set; }
        public string LeaveBalanceId { get; set; }
        public string AcademicYearId { get; set; }
        public string UserCode { get; set; }
        public string LeaveId { get; set; }
        public string BalanceLeave { get; set; }
        public int OrgId { get; set; }
        public string UserId { get; set; }
        public Boolean IsActive { get; set; }

        public int EmpDeptDesId { get; set; }

        public string SearchValue { get; set; }
    }
}

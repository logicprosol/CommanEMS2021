using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityWebApp.HR
{
    public class EWA_LeaveStatus
    {
        #region FacultyApplyRegion

        public string Action { get; set; }
        public int OrgId { get; set; }
        public string UserCode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string TotalLeave { get; set; }
        public string ApplicationDate { get; set; }
        public string Reason { get; set; }
        public string LeaveStatus { get; set; }

        public string ApplicationId { get; set; }
        public string LeaveId { get; set; }
        public string Date { get; set; }
        public string FullHalf { get; set; }

        public DataTable dtLeaveDetails { get; set; }
          
        #endregion
    }
}
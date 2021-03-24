namespace EntityWebApp.Faculty
{
    public class EWA_Leave
    {
        #region FacultyApplyRegion

        public string strAction { get; set; }

        public int OrgID { get; set; }

        public string UserCode { get; set; }

        public string DeptID { get; set; }

        public string CourseID { get; set; }

        public int LeaveID { get; set; }

        public string LeaveType { get; set; }

        public int BalanceLeave { get; set; }

        public int LeaveDays { get; set; }

        public string leaveCategory { get; set; }

        public string subject { get; set; }

        public string fromDate { get; set; }

        public string toDate { get; set; }

        public string reason { get; set; }

        public string LeaveStatus { get; set; }

        public string ApplicationDate { get; set; }

        public int ApplicationID { get; set; }

        public int LeaveTypeID { get; set; }

        #endregion FacultyApplyRegion
    }
}
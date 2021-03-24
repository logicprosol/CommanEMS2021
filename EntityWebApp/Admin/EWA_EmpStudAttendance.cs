using System;

namespace EntityWebApp.Admin
{
    public class EWA_EmpStudAttendance
    {
        public string Action { get; set; }

        public string EmpAttId { get; set; }

        public string EmpCode { get; set; }

        public string InTime { get; set; }

        public string OutTime { get; set; }

        public string PunchingRecords { get; set; }

        public string Leave { get; set; }

        public string Status { get; set; }

        public string AttendanceDate { get; set; }

        public string StudAttId { get; set; }

        public string StudentCode { get; set; }

        public Int32 OrgId { get; set; }
    }
}
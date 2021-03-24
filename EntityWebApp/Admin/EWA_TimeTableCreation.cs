using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_TimeTableCreation
    {
        public string Action { get; set; }
        public Int32 TimeTableId { get; set; }
        public Int32 CourseId { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 ClassId { get; set; }
        public Int32 SubjectId { get; set; }
        public Int32 SubEmpId { get; set; }
        public Int32 DayId { get; set; }
        public Int32 TimeSlotId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 LecNo { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }
    }
}

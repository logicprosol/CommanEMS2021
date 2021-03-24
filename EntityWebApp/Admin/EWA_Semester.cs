using System;

namespace EntityWebApp.Admin
{
    public class EWA_Semester
    {
        public string Action { get; set; }

        public int SemesterId { get; set; }

        public string SemesterName { get; set; }

        public string Pattern { get; set; }

        public int CourseId { get; set; }

        public int BranchId { get; set; }

        public int ClassId { get; set; }

        public int OrgId { get; set; }

        public int AcademicYearId { get; set; }

        public int UserId { get; set; }

        public Boolean IsActive { get; set; }
    }
}
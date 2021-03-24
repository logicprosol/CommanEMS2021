using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
   public class EWA_AddTest
    {
        public string Action { get; set; }

        public string TestName { get; set; }

        public int CourseId { get; set; }

        public int BranchId { get; set; }

        public int ClassId { get; set; }

        public string TestMarks { get; set; }

        public string TestDate { get; set; }

        public int SubjectId { get; set; }

        public int IsActive { get; set; }

        public int OrgId { get; set; }

        public string  PerQuestionMark { get; set; }

    }
}

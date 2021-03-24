using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Faculty
{
    public class EWA_UploadResult
    {

        public string Action { get; set; }

        public string OrgId { get; set; }

        public string UserCode { get; set; }

        public string CourseId { get; set; }

        public string BranchId { get; set; }

        public string ClassId { get; set; }

        public string SemesterId { get; set; }

        public string TestId { get; set; }

        public string TestName { get; set; }

        public string TotalMark { get; set; }

        public string ResultId { get; set; }

        public string Result { get; set; }

        public string SubjectId { get; set; }

        public string MarkId { get; set; }

        public string Mark { get; set; }

        public string Outofmark { get; set; }

        public string Status { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] UploadedFile { get; set; }

        public string AcademinYear { get; set; }
    }
}

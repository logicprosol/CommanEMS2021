using System;
using System.Data;

namespace EntityWebApp.Faculty
{
    public class EWA_UploadDocument
    {

        public string UploadDocReceiptId { get; set; }

        public string Action { get; set; }

        public string OrgId { get; set; }

        public string FacultyId { get; set; }

        public string CourseId { get; set; }

        public string BranchId { get; set; }

        public string ClassId { get; set; }

      public string DivisionId { get; set; }

        public string MessageContent { get; set; }

        public string Subject { get; set; }

        public string StudentId { get; set; }

        public string FileName { get; set; }

        public byte[] Data { get; set; }

        public int UploadPurpose { get; set; }

        public string ContentType { get; set; }

        public DataTable StudentDataTable { get; set; }
    }
}
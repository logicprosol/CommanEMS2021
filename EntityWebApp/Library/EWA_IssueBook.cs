using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Library
{
    public class EWA_IssueBook
    {
        public string Action { get; set; }
        public Int32 IssueId { get; set; }
        public Int32 GroupId { get; set; }
        public Int32 BookId { get; set; }
        public Int32 StudentId { get; set; }
        public string StudentCode { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 UserId { get; set; }
        public string IsActive { get; set; }
    }
}

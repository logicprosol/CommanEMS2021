using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Library
{
    public class EWA_AddBook
    {
        public string Action { get; set; }
        public Int32 BookId { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public int GroupId { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string PublishingYear { get; set; }
        public string Edition { get; set; }
        public double Price { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 UserId { get; set; }
        public string barcode { get; set; }
        public string IsActive { get; set; }
        public Int32 qty { get; set; }
    }
}

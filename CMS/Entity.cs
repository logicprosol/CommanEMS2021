using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{


    public class clse_hostel
    {
        public int Hostel_id { get; set; }
        public string Hostel_name { get; set; }
        public string Hostel_Types { get; set; }
        public int H_totalroom { get; set; }
        public string Hostel_Address { get; set; }
        public int OrgId { get; set; }
    }
    public class clse_productkey
    {
        public int OrgId { get; set; }

    }

    public class clse_returnbook
    {
        public string barcode { get; set; }
        public string groupname { get; set; }
        public string bookname { get; set; }
        public string author { get; set; }
        public string issuedate { get; set; }
        public string usercode { get; set; }
        public string username { get; set; }
        public string duedate { get; set; }
        public string StudentId { get; set; }
    }

    public class clse_companymaster
    {
        public int Company_id { get; set; }
        public string Company_Name { get; set; }
        public string Company_City { get; set; }
        public string Company_Address { get; set; }
        public string Company_email { get; set; }
        public string Company_mob { get; set; }
        public string Contact_Person { get; set; }
    }

    public class clse_hrprofile
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }


    public class clse_HostelRoom
    {
        public int RoomId { get; set; }
        public int Hostel_id { get; set; }
        public string RoomName { get; set; }
        public int OrgId { get; set; }
        public string Status { get; set; }
        public int StudentCount { get; set; }
    }

}
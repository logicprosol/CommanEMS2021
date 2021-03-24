using System;

namespace EntityWebApp.SuperAdmin
{
    public class EWA_SportMaster
    {
        public string Action{get;set;}
        public int SportId{get;set;}
        public string SportName{get;set;}
        public string UserId{get;set;}
        public Boolean IsActive { get; set; }
    }
}
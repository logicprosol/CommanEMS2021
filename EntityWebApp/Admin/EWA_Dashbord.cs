using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_Dashbord
    {

        public string Action { get; set; }
        public int OrgId { get; set; }
        public string StudentId { get; set; }
        public string UserCode { get; set; }


        //Added by Ashwini More -8-Oct-2020--------------------------------------------------

        public string CourseId { get; set;}
        public string BranchId { get; set; }
        public string ClassId { get; set; }
        public string AcademicId { get; set; }
        public string DeptId { get; set; }
        public string DesignationId { get; set; }
        public string FacultytypeId { get; set; }

    }
}

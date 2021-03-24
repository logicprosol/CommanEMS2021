using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_LC
    {
        //Property Declaration
        public string Action { get; set; }
        public string OrgId { get; set; }
        public string CourseId { get; set; }
        public string ClassId { get; set; }//
        public string BranchId { get; set; }//
        public string DivisionId { get; set; }//

        public string StudentId_Name { get; set; }
        public string Usercode { get; set; }//
        public string StudentId { get; set; }
        public Int32 AcademicYearId { get; set; }
        public int RegisterRollNo { get; set; }
        public string FullName { get; set; }
        public string Caste { get; set; }

        public string Nationality { get; set; }
        public string BirthPlace { get; set; }
        public DateTime DOB { get; set; }
        public string LastSchoolAttended { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string Progress { get; set; }
        public string Behaviour { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public DateTime YearStudying { get; set; }
        public string Reaseon { get; set; }
        public string Remarks { get; set; }
        public DateTime TodayDate { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.HR
{
    public class EWA_SalarySettings
    {
          
        public int OrgId { get; set; }

        public int AcademicYearId { get; set; }

        public int UserId { get; set; }

        public  bool IsActive { get; set; }
        
        public string Action { get; set; }

        public int PayGrpID { get; set; }

        public int PayGrpContentID { get; set; }

        public string EmployeeName { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }
        
      
     //   cvccx

        public string PayGrpName { get; set; }

        public double BasicSalary { get; set; }

        public string CategoryName { get; set; }

        public double CategoryValue { get; set; }

        public string ValueType { get; set; }

        public string ValueOn { get; set; }

        public string ContentAction { get; set; }

        public string UserCode { get; set; }

        public string SalaryMonth { get; set; }

        public double GorssSalary { get; set; }

        public double TotalDeduction { get; set; }

         public double LeaveDeduction { get; set; }

        public double NetSalary { get; set; }

        public string PostedMonth { get; set; }

        public string SalarySleepID { get; set; }
        public string ContentValue { get; set; }
        

    }
}

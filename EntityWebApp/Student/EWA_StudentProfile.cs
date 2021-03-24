using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Student
{
    public class EWA_StudentProfile
    {

        #region Variables
        #region StudentVariables

        public string Action { get; set; }
        public string OrgId { get; set; }
        public string StudentId { get; set; }
        public string UserCode { get; set; }



        private string AdmissionID { get; set; }
        public string AdmissionDate { get; set; }
        public string RollNo { get; set; }
        public string PRN { get; set; }
        public string CourseId { get; set; }
        public string ClassId { get; set; }
        public string BranchId { get; set; }
        public string DivisionId { get; set; }
        public string AcademicYearId { get; set; }
       
      

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string StudentAddress { get; set; }
        public string StudentCountry { get; set; }
        public string StudentState { get; set; }
        public string StudentDistrict { get; set; }
        public string StudentTaluka { get; set; }
        public string StudentCity { get; set; }
        public string StudentPincode { get; set; }
        public string StudentMobile { get; set; }
        public string StudentEMail { get; set; }
        //public string StudentPhone { get; set; }
        //public string StudentFax { get; set; }
      
       
        
        
        public string Nationality { get; set; }
        public string MotherTongue { get; set; }
        public string MarriedStatus { get; set; }
        //public string OccupationalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string CasteCategoryId { get; set; }
        public string FeesCategoryId { get; set; }
        public string SubCaste { get; set; }
        public string Handicaped { get; set; }
        public string ConveyanceUse { get; set; }
        public string SportId { get; set; }
        public string AdharNo { get; set; }
        public string GRNo { get; set; }






        #endregion

        #region GuardianVariables
        //private string Guardian_Name;
        //private string Relation;
        //private string Guardian_Address1;
        //private string Guardian_Address2;
        //private string Guardian_Country;
        //private string Guardian_State;
        //private string Guardian_District;
        //private string Guardian_Taluka;
        //private string Guardian_City;
        //private int Guardian_PinCode;
        //private string Guardian_PhoneNo;
        //private string Guardian_Fax;
        //private string Guardian_Mobile;
        //private string Guardian_Email;
        #endregion

        #region ParentVariables
        public string ParentName { get; set; }
        public string MotherName { get; set; }
        public string ParentAddress { get; set; }
        public string ParentCountry { get; set; }
        public string ParentState { get; set; }
        public string ParentDistrict { get; set; }
        public string ParentTaluka { get; set; }
        public string ParentCity { get; set; }
        public string ParentPinCode { get; set; }
        public string ParentMobile { get; set; }
        public string ParentEmail { get; set; }                    
        public string Profession { get; set; }
        public string AnnualIncome { get; set; }
        public string ResidentType { get; set; }
        public string ResidanceState { get; set; }

        
        #endregion

        #region PerviousInformationVariables
        public string LastClass { get; set; }
        public string LastInstitute { get; set; }
        public string LastQualifiedExam { get; set; }
        public string Board { get; set; }
        public string SeatNo { get; set; }
        public string PassingMonth { get; set; }
        public string PassingYear { get; set; }       
        public string Percentage { get; set; }
        public string Result { get; set; }

        public string CreamyLayerStatus { get; set; }
        public string Eligibility { get; set; }
        public string TcNo { get; set;}
        public string TcIssueDate { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string BankAccountNo { get; set; }
        
       


      

      
        
        #endregion

        public string OtherActivity { get; set; }

        #region FeesVariables
        //private string FeeConcession { get; set; }
        //private string ConcessionType { get; set; }
        //private string BankName { get; set; }
        //private string Branch { get; set; }
        //private string IFSCCode { get; set; }
        //private int AccountNo { get; set; }
        //private string MaintenanceAllowance { get; set; }
        //private int AwardNo { get; set; }
        #endregion       
     
       
        public string Status { get; set; }
        public byte[] StudentPhoto { get; set; }
        public byte[] StudentSign { get; set; }
       
        public string StudentUserName { get; set; }
       

       

        #endregion
    }
}

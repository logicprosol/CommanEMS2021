using System;

namespace EntityWebApp.Admin
{
    public class EWA_Student
    {
        public string Action { get; set; }

        public int StudentId { get; set; }

        public string UserCode { get; set; }

        public string AdmissionID { get; set; }

        public int OrgId { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string CourseId { get; set; }

        public string BranchId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public string Taluka { get; set; }

        public string City { get; set; }

        public string PinCode { get; set; }

        public string Mobile { get; set; }

        public string EMail { get; set; }

        public string Nationality { get; set; }

        public string MotherTongue { get; set; }

        public string MaritalStatus { get; set; }

        public string BloodGroup { get; set; }

        public string Religion { get; set; }

        public string CasteCategoryId { get; set; }

        public string Caste { get; set; }

        public string Subcaste { get; set; }

        public string ConveyanceUse { get; set; }

        public string Handicaped { get; set; }

        public string SportId { get; set; }

        public string AdharNo { get; set; }

        //Parent Tab

        #region ParentRegion

        public string ParentName { get; set; }

        public string MotherName { get; set; }

        public string ParentAddress { get; set; }

        public string ParentCountry { get; set; }

        public string ParentState { get; set; }

        public string ParentDistrict { get; set; }

        public string ParentTaluka { get; set; }

        public string ParentCity { get; set; }

        public string ParentPinCode { get; set; }

        public string ParentPhone { get; set; }

        public string ParentMobile { get; set; }

        public string ParentEmail { get; set; }

        public string ParentProfession { get; set; }

        public string AnnualIncome { get; set; }

        #endregion ParentRegion

        //Guardian Tab

        #region GuardianInformation

        public string GuardianName { get; set; }

        public string Relation { get; set; }

        public string GuardianAddress { get; set; }

        public string GuardianCountry { get; set; }

        public string GuardianState { get; set; }

        public string GuardianDistrict { get; set; }

        public string GuardianTaluka { get; set; }

        public string GuardianCity { get; set; }

        public string GuardianPinCode { get; set; }

        public string GuardianMobile { get; set; }

        public string GuardianEmail { get; set; }

        #endregion GuardianInformation

        //Educational Details

        #region EducationalDetailsRegion

        public string LastClass { get; set; }

        public string ResidentType { get; set; }

        public string LastInstitute { get; set; }

        public string QualifiedExam { get; set; }

        public string Board { get; set; }

        public string SeatNo { get; set; }

        public string PassingMonth { get; set; }

        public string PassingYear { get; set; }

        public string Percentage { get; set; }

        public string Result { get; set; }

        public string CreamyLayerStatus { get; set; }

        public string Eligibility { get; set; }

        public string ResidanceState { get; set; }

        public string Gap { get; set; }

        public string TcNo { get; set; }

        public DateTime TcIssueDate { get; set; }

        public string FeesConcession { get; set; }

        public string ConcessionType { get; set; }

        #endregion EducationalDetailsRegion

        public string BankName { get; set; }

        public string BankBranch { get; set; }

        public string IFSCCode { get; set; }

        public string BankAccountNo { get; set; }

        public string PassportNo { get; set; }

        public byte[] Photo { get; set; }

        public byte[] Signature { get; set; }

        public string Status { get; set; }

        public string AcademicYearId { get; set; }

        public Boolean IsActive { get; set; }

        //Insert Data into Student Table
        public string ClassId { get; set; }

        // public string DivisionId { get; set; }

        //Insert Data into User Table
        public string UserType { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string UserTypeId { get; set; }

        //public string Status { get; set; }
        //public string OrgId { get; set; }

        //Insert data into StudentFeesPaid Table
        public string FeesId { get; set; }
        public string FeesDetailsId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalPaidAmount { get; set; }

        public decimal TotalPendingAmount { get; set; }

        public string UserId { get; set; }
    }
}
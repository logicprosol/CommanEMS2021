using System;

namespace EntityWebApp.Admin
{
    public class EWA_StaffView
    {
        //StaffViewregion

        #region StaffViewregion

        private string _Action;
        private int _OrgId;

        //Personal Information
        private string _EmpCode;

        private string _Department;
        private string _Designation;
        private string _Course;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _MotherName;
        private string _Gender;
        private DateTime _DOB;
        private string _BloodGroup;
        private string _MaritalStatus;

        //Contact Information
        private string _PresentAddress;

        private string _PresentCountry;
        private string _PresentState;
        private string _PresentCity;
        private int _PresentPinCode;

        private string _Class;
        private long _StaffID;

        private string _PermanentAddress;
        private string _PermanentCountry;
        private string _PermanentState;
        private string _PermanentCity;
        private int _PermanentPinCode;

        private string _PhoneNo;
        private string _Mobile;
        private string _Fax;
        private string _Email;
        private string _CasteCategory;
        private string _Nationality;
        private string _WebsiteBlog;
        private string _PanCardNo;
        private DateTime _DateOfJoining;

        //Education Qualification
        private string _UGDegree;

        private string _PGDegree;
        private string _DoctrateDegree;
        private string _OtherQualification;
        private string _Specialization;
        private int _TeachingExperience;
        private int _IndustrialExperience;
        private int _ResearchExperience;
        private int _NationalPublication;
        private int _InternationalPublication;
        private int _BookPublished;
        private int _Patents;
        private int _IsActive;

        //Other Information
        private string _PFNumber;

        private string _BankAccountNumber;
        private string _BankName;
        private string _BankBranchName;
        private string _BankIFSCCode;

        #endregion StaffViewregion

        //g
        //PropertyDeclaration

        #region StaffPropertyRegion

        //PrpertyFor Personal Information
        public string EmpCode
        {
            get { return _EmpCode; }
            set { _EmpCode = value; }
        }

        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

        public string Course
        {
            get { return _Course; }
            set { _Course = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string MotherName
        {
            get { return _MotherName; }
            set { _MotherName = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        public string BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
        }

        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }

        //PrpertyFor Contact Information
        public string PresentAddress
        {
            get { return _PresentAddress; }
            set { _PresentAddress = value; }
        }

        public string PresentCountry
        {
            get { return _PresentCountry; }
            set { _PresentCountry = value; }
        }

        public string PresentState
        {
            get { return _PresentState; }
            set { _PresentState = value; }
        }

        public string PresentCity
        {
            get { return _PresentCity; }
            set { _PresentCity = value; }
        }

        public int PresentPinCode
        {
            get { return _PresentPinCode; }
            set { _PresentPinCode = value; }
        }

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }
        
        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        public string Class
        {
            get { return _Class; }
            set { _Class = value; }
        }

        public long StaffID
        {
            get { return _StaffID; }
            set { _StaffID = value; }
        }

        public string PermanentAddress
        {
            get { return _PermanentAddress; }
            set { _PermanentAddress = value; }
        }

        public string PermanentCountry
        {
            get { return _PermanentCountry; }
            set { _PermanentCountry = value; }
        }

        public string PermanentState
        {
            get { return _PermanentState; }
            set { _PermanentState = value; }
        }

        public string PermanentCity
        {
            get { return _PermanentCity; }
            set { _PermanentCity = value; }
        }

        public int PermanentPinCode
        {
            get { return _PermanentPinCode; }
            set { _PermanentPinCode = value; }
        }

        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }

        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string CasteCategory
        {
            get { return _CasteCategory; }
            set { _CasteCategory = value; }
        }

        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }

        public string WebsiteBlog
        {
            get { return _WebsiteBlog; }
            set { _WebsiteBlog = value; }
        }

        public string PanCardNo
        {
            get { return _PanCardNo; }
            set { _PanCardNo = value; }
        }

        public DateTime DateOfJoining
        {
            get { return _DateOfJoining; }
            set { _DateOfJoining = value; }
        }

        //Property For Education Qulaification
        public string UGDegree
        {
            get { return _UGDegree; }
            set { _UGDegree = value; }
        }

        public string PGDegree
        {
            get { return _PGDegree; }
            set { _PGDegree = value; }
        }

        public string DoctrateDegree
        {
            get { return _DoctrateDegree; }
            set { _DoctrateDegree = value; }
        }

        public string OtherQualification
        {
            get { return _OtherQualification; }
            set { _OtherQualification = value; }
        }

        public string Specialization
        {
            get { return _Specialization; }
            set { _Specialization = value; }
        }

        public int TeachingExperience
        {
            get { return _TeachingExperience; }
            set { _TeachingExperience = value; }
        }

        public int IndustrialExperience
        {
            get { return _IndustrialExperience; }
            set { _IndustrialExperience = value; }
        }

        public int ResearchExperience
        {
            get { return _ResearchExperience; }
            set { _ResearchExperience = value; }
        }

        public int NationalPublication
        {
            get { return _NationalPublication; }
            set { _NationalPublication = value; }
        }

        public int InternationalPublication
        {
            get { return _InternationalPublication; }
            set { _InternationalPublication = value; }
        }

        public int BookPublished
        {
            get { return _BookPublished; }
            set { _BookPublished = value; }
        }

        public int Patents
        {
            get { return _Patents; }
            set { _Patents = value; }
        }

        //Property for Other Information
        public string PFNumber
        {
            get { return _PFNumber; }
            set { _PFNumber = value; }
        }

        public string BankAccountNumber
        {
            get { return _BankAccountNumber; }
            set { _BankAccountNumber = value; }
        }

        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }

        public string BankBranchName
        {
            get { return _BankBranchName; }
            set { _BankBranchName = value; }
        }

        public string BankIFSCCode
        {
            get { return _BankIFSCCode; }
            set { _BankIFSCCode = value; }
        }

        public string DepartmentId { get; set; }

        public string DesignationTypeId { get; set; }

        #endregion StaffPropertyRegion
    }
}
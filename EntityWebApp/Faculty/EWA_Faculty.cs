using System;

namespace EntityWebApp.Faculty
{
    public class EWA_Faculty
    {
        //Facultyregion-Personal Information

        #region FacultyRegion

        private string _Action;
        private int _OrgId;
        private string _Usertype;
        private int _UserTypeId;

        private int _StaffId;
        private string _Department;
        private string _FacultyType;
        private string _Designation;
        private string _Course;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _MotherName;
        private string _Gender;
        private string _BirthDate;
        private string _BloodGroup;
        private string _MaritalStatus;
        //private string _UserName;
        //private string _Password;
        //private string _ConfirmPassword;

        //Facultyregion-Contact Information
        private string _PresentAddress;

        private string _PresentCountry;
        private string _PresentState;
        private string _PresentCity;
        private string _PresentPinCode;
        //private string _PermanentAddress;
        //private string _PermanentCountry;
        //private string _PermanentState;
        //private string _PermanentCity;
        //private string _PermanentPincode;

        private byte[] _Photo;
        private string _PhoneNo;
        private string _Mobile;
        //private string _Fax;
        private string _Email;
        private string _CasteCategory;
        private string _Nationality;
        //private string _WebsiteBlog;
        private string _PancardNo;

        //Facultyregion-Education Qualification
        private string _DateoOfJoining;

        private string _UGDegree;
        private string _PGDegree;
        //private string _Doctoratedegree;
        private string _OtherQualificaton;
        private string _Specialization;
        private string _TeachingExperience;
        //private string _IndustrialExperience;
        //private string _ResearchExperience;
        //private string _NationalPublication;
        //private string _InternationalPublication;
        //private string _BooksPublished;
        //private string _Patents;

        //Other Information
        //private string _PFNumber;

        private string _BankAccountNumber;
        private string _BankName;
        private string _BankBranchName;
        //private string _BankIFSCCode;

        #endregion FacultyRegion

        //Property Declaration

        #region FacultyPropertyRegion

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

        public string Usertype
        {
            get { return _Usertype; }
            set { _Usertype = value; }
        }

        public int UserTypeId
        {
            get { return _UserTypeId; }
            set { _UserTypeId = value; }
        }

        public int StaffId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }

        public int EmployeeId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }

        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public string FacultyType
        {
            get { return _FacultyType; }
            set { _FacultyType = value; }
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

        public string BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
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

        //public string UserName
        //{
        //    get { return _UserName; }
        //    set { _UserName = value; }
        //}

        //public string Password
        //{
        //    get { return _Password; }
        //    set { _Password = value; }
        //}

        //public string ConfirmPassword
        //{
        //    get { return _ConfirmPassword; }
        //    set { _ConfirmPassword = value; }
        //}

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

        public string PresentPinCode
        {
            get { return _PresentPinCode; }
            set { _PresentPinCode = value; }
        }

        //public string PermanentAddress
        //{
        //    get { return _PermanentAddress; }
        //    set { _PermanentAddress = value; }
        //}

        //public string PermanentCountry
        //{
        //    get { return _PermanentCountry; }
        //    set { _PermanentCountry = value; }
        //}

        //public string PermanentState
        //{
        //    get { return _PermanentState; }
        //    set { _PermanentState = value; }
        //}

        //public string PermanentCity
        //{
        //    get { return _PermanentCity; }
        //    set { _PermanentCity = value; }
        //}

        //public string PermanentPincode
        //{
        //    get { return _PermanentPincode; }
        //    set { _PermanentPincode = value; }
        //}

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
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

        //public string Fax
        //{
        //    get { return _Fax; }
        //    set { _Fax = value; }
        //}

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

        //public string WebsiteBlog
        //{
        //    get { return _WebsiteBlog; }
        //    set { _WebsiteBlog = value; }
        //}

        public string PancardNo
        {
            get { return _PancardNo; }
            set { _PancardNo = value; }
        }

        public string DateoOfJoining
        {
            get { return _DateoOfJoining; }
            set { _DateoOfJoining = value; }
        }

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

        //public string Doctoratedegree
        //{
        //    get { return _Doctoratedegree; }
        //    set { _Doctoratedegree = value; }
        //}

        public string OtherQualificaton
        {
            get { return _OtherQualificaton; }
            set { _OtherQualificaton = value; }
        }

        public string Specialization
        {
            get { return _Specialization; }
            set { _Specialization = value; }
        }

        public string TeachingExperience
        {
            get { return _TeachingExperience; }
            set { _TeachingExperience = value; }
        }

        //public string IndustrialExperience
        //{
        //    get { return _IndustrialExperience; }
        //    set { _IndustrialExperience = value; }
        //}

        //public string ResearchExperience
        //{
        //    get { return _ResearchExperience; }
        //    set { _ResearchExperience = value; }
        //}

        //public string NationalPublication
        //{
        //    get { return _NationalPublication; }
        //    set { _NationalPublication = value; }
        //}

        //public string InternationalPublication
        //{
        //    get { return _InternationalPublication; }
        //    set { _InternationalPublication = value; }
        //}

        //public string BooksPublished
        //{
        //    get { return _BooksPublished; }
        //    set { _BooksPublished = value; }
        //}

        //public string Patents
        //{
        //    get { return _Patents; }
        //    set { _Patents = value; }
        //}

        ////Property for Other Information
        //public string PFNumber
        //{
        //    get { return _PFNumber; }
        //    set { _PFNumber = value; }
        //}

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

        //public string BankIFSCCode
        //{
        //    get { return _BankIFSCCode; }
        //    set { _BankIFSCCode = value; }
        //}

        #endregion FacultyPropertyRegion
    }
}
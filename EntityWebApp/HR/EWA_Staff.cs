using System;

namespace EntityWebApp.HR
{
    public class EWA_Staff
    {
        //Staffregion

        #region StaffRegion

        //Login Variables Declaration

        #region StaffVariablesRegion

        public string _Action;
        private int _EmpId;
        private string _EmpCode;
        private string _DesignationTypeId;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _MotherName;
        private string _Gender;
        private string _DOB;
        private string _BloodGroup;
        private string _MaritalStatus;
        private string _Handicap;
        private int _HandicapPercentage;
        private string _PresentAddress;
        private string _PresentCountry;
        private string _PresentState;
        private string _PresentCity;
        private int _PresentPinCode;

        private string _PermanentAddress;
        private string _PermanentCountry;
        private string _PermanentState;
        private string _PermanentCity;
        private int _PermanentPinCode;
        private byte[] _Photo;
        private byte[] _Sign;

        private string _PhoneNo;
        private string _Mobile;
        private string _Fax;

        private string _Email;
        private string _CasteCategory;
        private string _Nationality;
        private string _WebsiteBlog;
        private string _PanCardNo;
        private string _DateOfJoining;

        private string _UGDegree;
        private string _PGDegree;
        private string _DoctrateDegree;
        private string _OtherQualification;
        private string _Specialization;
        private string _TeachingExperience;
        private string _PreviousPackage;

        private int _PayScale;
        private string _SalaryMode;
        private string _PFNumber;
        private string _BankAccountNumber;
        private string _BankName;
        private string _BankBranchName;
        private string _BankIFSCCode;

        //Insert Data into User Table
        private string _UserType;

        private string _UserName;
        private string _Password;
        private string _Role;
        private string _UserTypeId;
        private string _Status;
        private int _OrgId;
        private string _IsActive;
        private string _DepartmentId;
        private string _DesignationId;

        #endregion StaffVariablesRegion

        //PropertyDeclaration

        #region LoginPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }

        public string EmpCode
        {
            get { return _EmpCode; }
            set { _EmpCode = value; }
        }

        public string DesignationTypeId
        {
            get { return _DesignationTypeId; }
            set { _DesignationTypeId = value; }
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

        public string DOB
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
    
        public string Handicap
        {
            get { return _Handicap; }
            set { _Handicap = value; }
        }
        public int HandicapPercentage
        {
            get { return _HandicapPercentage; }
            set { _HandicapPercentage = value; }
        }

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

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        public byte[] Sign
        {
            get { return _Sign; }
            set { _Sign = value; }
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

        public string DateOfJoining
        {
            get { return _DateOfJoining; }
            set { _DateOfJoining = value; }
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

        public string TeachingExperience
        {
            get { return _TeachingExperience; }
            set { _TeachingExperience = value; }
        }

        public string PreviousPackage
        {
            get { return _PreviousPackage; }
            set { _PreviousPackage = value; }
        }

        public int PayScale
        {
            get { return _PayScale; }
            set { _PayScale = value; }
        }

        public string SalaryMode
        {
            get { return _SalaryMode; }
            set { _SalaryMode = value; }
        }

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

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }

        public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public string UserTypeId
        {
            get { return _UserTypeId; }
            set { _UserTypeId = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

        public string IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        public string DepartmentId
        {
            get { return _DepartmentId; }
            set { _DepartmentId = value; }
        }

        public string DesignationId
        {
            get { return _DesignationId; }
            set { _DesignationId = value; }
        }
        #endregion LoginPropertyRegion

        #endregion StaffRegion
    }
}
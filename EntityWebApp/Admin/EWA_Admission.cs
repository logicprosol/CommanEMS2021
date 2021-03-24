using System.Data;
namespace EntityWebApp.Admin
{
    public class EWA_Admission
    {
        #region Variables

        #region StudentVariables

        private int _OrgID;
        private string _AdmissionID;

        public string GRNo { get; set; }

        private string Admission_Type;
        private string Class;
        private string Previous_Roll_No;
        private string First_Name;
        private string Middle_Name;
        private string Last_Name;
        private string Fees_Category;
        private string Gender;
        private string Address1;
        private string Address2;
        private string Country;
        private string State;
        private string District;
        private string Taluka;
        private string City;
        private int Pincode;
        private string Phone;
        private string Fax;
        private string EMail;
        private string Mobile;
        private string Birth_Date;
        private string Birth_Place;
        private string Nationality;
        private string Mother_Tongue;
        private string Married_Status;
        private string Occupational_Status;
        private string Blood_Group;
        private string Handicap;
        private string Conveyance_Use;
        private string Religion;
        private string Caste;
        private string Sub_Caste;
        private string Category;

        //added 7-jan-2020
        private string studentCode;
        #endregion StudentVariables

        #region GuardianVariables

        private string Guardian_Name;
        private string Relation;
        private string Guardian_Address1;
        private string Guardian_Address2;
        private string Guardian_Country;
        private string Guardian_State;
        private string Guardian_District;
        private string Guardian_Taluka;
        private string Guardian_City;
        private int Guardian_PinCode;
        private string Guardian_PhoneNo;
        private string Guardian_Fax;
        private string Guardian_Mobile;
        private string Guardian_Email;

        public string Guardian_Occupation { get; set; }
        public string Guardian_Education { get; set; }

        #endregion GuardianVariables

        #region ParentVariables

        private string Parent_Name;
        private string Mother_Name;
        private string Parent_Address1;
        private string Parent_Address2;
        private string Parent_Country;
        private string Parent_State;
        private string Parent_District;
        private string Parent_Taluka;
        private string Parent_City;
        private int Parent_PinCode;
        private string Parent_PhoneNo;
        private string Parent_Fax;
        private string Parent_Mobile;
        private string Parent_Email;

        public string Parent_Occupation { get; set; }
        public string Parent_Education { get; set; }
        public DataTable dtDocuments { get; set; }

        private string Annul_Income;
        private string Creamy_Layer_Status;

        #endregion ParentVariables

        #region PerviousInformationVariables

        private string Last_Class;
        private string Resident_Type;
        private string Last_Institute;
        private string LastQualified_Exam;
        private string Board;
        private string Seat_No;
        private string Passing_Month;
        private string Passing_Year;
        private string Result;
        private string Percentage;
        private string Eligibility;
        private string Residance_State;
        private string Gap;
        private string Tc_No;
        private string Tc_Issue_Date;

        #endregion PerviousInformationVariables

        private string Other_Activity;

        #region FeesVariables

        private string Fee_Concession;
        private string Concession_Type;
        private string Bank_Name;
        private string Branch;
        private string IFSC_Code;
        private string Account_No;
        private string Maintenance_Allowance;


        #endregion FeesVariables

        #region PersonalInfoVariables

        private string Passport;
        private string Signature;
        private string Photo;
        private string User_Name;
        private string Password;

        #endregion PersonalInfoVariables

        //Added by Ashwini 9-sep-2020
        #region UpgradeFees Details
        #endregion

        #endregion Variables

        //public int AdmissionID { get; set; }
        public string AdmissionDate { get; set; }
        public string SaralId { get; set; }
        public string Course { get; set; }
        public string AdmissionID
        {
            get
            {
                return _AdmissionID;
            }
            set
            {
                _AdmissionID = value;
            }
        }
        public int OrgID
        {
            get
            {
                return _OrgID;
            }
            set
            {
                _OrgID = value;
            }
        }
       //Added By ashwini 9-Oct-2020-----------------
        public string AdmissionType
        {
            get
            {
                return Admission_Type;
            }
            set
            {
                Admission_Type = value;
            }
        }

        public string student_Code
        {
            get
            {
                return studentCode;
            }
            set
            {
                studentCode = value;
            }
        }

        public string CourseId
        {
            get
            {
                return Course_Id;
            }
            set
            {
                Course_Id = value;
            }
        }
        public string ApplicationDate
        {
            get
            {
                return Application_Date;
            }
            set
            {
                Application_Date = value;
            }
        }
        public string CasteCategoryId
        {
            get
            {
                return CasteCategory_Id;
            }
            set
            {
                CasteCategory_Id = value;
            }
        }
       

        //--------------------------------------------------------------------------
        public string Class1
        {
            get
            {
                return Class;
            }
            set
            {
                Class = value;
            }
        }
        public string ClassId
        {
            get
            {
                return Class;
            }
            set
            {
                Class = value;
            }
        }
        public int Branch_ID { get; set; }
        //public string Branch_Name { get; set; }

        public string PreviousRollNo
        {
            get
            {
                return Previous_Roll_No;
            }
            set
            {
                Previous_Roll_No = value;
            }
        }

        public string FeesCategory
        {
            get
            {
                return Fees_Category;
            }
            set
            {
                Fees_Category = value;
            }
        }

        public string CasteCategory
        {
            get
            {
                return Category;
            }
            set
            {
                Category = value;
            }
        }

        public string FirstName
        {
            get
            {
                return First_Name;
            }
            set
            {
                First_Name = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return Middle_Name;
            }
            set
            {
                Middle_Name = value;
            }
        }

        public string LastName
        {
            get
            {
                return Last_Name;
            }
            set
            {
                Last_Name = value;
            }
        }

        public string Gender1
        {
            get
            {
                return Gender;
            }
            set
            {
                Gender = value;
            }
        }

        public string BirthDate
        {
            get
            {
                return Birth_Date;
            }
            set
            {
                Birth_Date = value;
            }
        }

        public string BirthPlace
        {
            get
            {
                return Birth_Place;
            }
            set
            {
                Birth_Place = value;
            }
        }

        public string AddressLine1
        {
            get
            {
                return Address1;
            }
            set
            {
                Address1 = value;
            }
        }

        public string AddressLine2
        {
            get
            {
                return Address2;
            }
            set
            {
                Address2 = value;
            }
        }

        public string Country1
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value;
            }
        }

        public string State1
        {
            get
            {
                return State;
            }
            set
            {
                State = value;
            }
        }

        public string District1
        {
            get
            {
                return District;
            }
            set
            {
                District = value;
            }
        }

        public string Taluka1
        {
            get
            {
                return Taluka;
            }
            set
            {
                Taluka = value;
            }
        }

        public string City1
        {
            get
            {
                return City;
            }
            set
            {
                City = value;
            }
        }

        public int PinCode1
        {
            get
            {
                return Pincode;
            }
            set
            {
                Pincode = value;
            }
        }

        //public string Fax1
        //{
        //    get
        //    {
        //        return Fax;
        //    }
        //    set
        //    {
        //        Fax = value;
        //    }
        //}

        //public string PhoneNo
        //{
        //    get
        //    {
        //        return Phone;
        //    }
        //    set
        //    {
        //        Phone = value;
        //    }
        //}

        public string MobileNo
        {
            get
            {
                return Mobile;
            }
            set
            {
                Mobile = value;
            }
        }

        public string E_Mail
        {
            get
            {
                return EMail;
            }
            set
            {
                EMail = value;
            }
        }

        public string Nationality1
        {
            get
            {
                return Nationality;
            }
            set
            {
                Nationality = value;
            }
        }

        public string MotherTongue
        {
            get
            {
                return Mother_Tongue;
            }
            set
            {
                Mother_Tongue = value;
            }
        }

        //public string MarriedStatus
        //{
        //    get
        //    {
        //        return Married_Status;
        //    }
        //    set
        //    {
        //        Married_Status = value;
        //    }
        //}

        //public string OccupationalStatus
        //{
        //    get
        //    {
        //        return Occupational_Status;
        //    }
        //    set
        //    {
        //        Occupational_Status = value;
        //    }
        //}

        public string BloodGroup
        {
            get
            {
                return Blood_Group;
            }
            set
            {
                Blood_Group = value;
            }
        }

        public string Handicaped
        {
            get
            {
                return Handicap;
            }
            set
            {
                Handicap = value;
            }
        }

        public string Religion1
        {
            get
            {
                return Religion;
            }
            set
            {
                Religion = value;
            }
        }

        //public string Caste1
        //{
        //    get
        //    {
        //        return Caste;
        //    }
        //    set
        //    {
        //        Caste = value;
        //    }
        //}

        public string Subcaste
        {
            get
            {
                return Sub_Caste;
            }
            set
            {
                Sub_Caste = value;
            }
        }

        //public string Conveyanceuse
        //{
        //    get
        //    {
        //        return Conveyance_Use;
        //    }
        //    set
        //    {
        //        Conveyance_Use = value;
        //    }
        //}



        public string GuardianName
        {
            get
            {
                return Guardian_Name;
            }
            set
            {
                Guardian_Name = value;
            }
        }

        public string Relation1
        {
            get
            {
                return Relation;
            }
            set
            {
                Relation = value;
            }
        }

        //public string GuardianAddress1
        //{
        //    get
        //    {
        //        return Guardian_Address1;
        //    }
        //    set
        //    {
        //        Guardian_Address1 = value;
        //    }
        //}

        //public string GuardianAddress2
        //{
        //    get
        //    {
        //        return Guardian_Address2;
        //    }
        //    set
        //    {
        //        Guardian_Address2 = value;
        //    }
        //}

        //public string GuardianCountry
        //{
        //    get
        //    {
        //        return Guardian_Country;
        //    }
        //    set
        //    {
        //        Guardian_Country = value;
        //    }
        //}

        //public string GuardianState
        //{
        //    get
        //    {
        //        return Guardian_State;
        //    }
        //    set
        //    {
        //        Guardian_State = value;
        //    }
        //}

        //public string GuardianDistrict
        //{
        //    get
        //    {
        //        return Guardian_District;
        //    }
        //    set
        //    {
        //        Guardian_District = value;
        //    }
        //}

        //public string GuardianTaluka
        //{
        //    get
        //    {
        //        return Guardian_Taluka;
        //    }
        //    set
        //    {
        //        Guardian_Taluka = value;
        //    }
        //}

        //public string GuardianCity
        //{
        //    get
        //    {
        //        return Guardian_City;
        //    }
        //    set
        //    {
        //        Guardian_City = value;
        //    }
        //}

        //public int GuardianPinCode
        //{
        //    get
        //    {
        //        return Guardian_PinCode;
        //    }
        //    set
        //    {
        //        Guardian_PinCode = value;
        //    }
        //}

        //public string GuardianPhone
        //{
        //    get
        //    {
        //        return Guardian_PhoneNo;
        //    }
        //    set
        //    {
        //        Guardian_PhoneNo = value;
        //    }
        //}

        //public string GuardianFax
        //{
        //    get
        //    {
        //        return Guardian_Fax;
        //    }
        //    set
        //    {
        //        Guardian_Fax = value;
        //    }
        //}

        public string GuardianMobile
        {
            get
            {
                return Guardian_Mobile;
            }
            set
            {
                Guardian_Mobile = value;
            }
        }

        public string GuardianEmail
        {
            get
            {
                return Guardian_Email;
            }
            set
            {
                Guardian_Email = value;
            }
        }


        public string ParentName
        {
            get
            {
                return Parent_Name;
            }
            set
            {
                Parent_Name = value;
            }
        }

        public string MotherName
        {
            get
            {
                return Mother_Name;
            }
            set
            {
                Mother_Name = value;
            }
        }

        //public string ParentAddress1
        //{
        //    get
        //    {
        //        return Parent_Address1;
        //    }
        //    set
        //    {
        //        Parent_Address1 = value;
        //    }
        //}

        //public string ParentAddress2
        //{
        //    get
        //    {
        //        return Parent_Address2;
        //    }
        //    set
        //    {
        //        Parent_Address2 = value;
        //    }
        //}

        //public string ParentCountry
        //{
        //    get
        //    {
        //        return Parent_Country;
        //    }
        //    set
        //    {
        //        Parent_Country = value;
        //    }
        //}

        //public string ParentState
        //{
        //    get
        //    {
        //        return Parent_State;
        //    }
        //    set
        //    {
        //        Parent_State = value;
        //    }
        //}

        //public string ParentDistrict
        //{
        //    get
        //    {
        //        return Parent_District;
        //    }
        //    set
        //    {
        //        Parent_District = value;
        //    }
        //}

        //public string ParentTaluka
        //{
        //    get
        //    {
        //        return Parent_Taluka;
        //    }
        //    set
        //    {
        //        Parent_Taluka = value;
        //    }
        //}

        //public string ParentCity
        //{
        //    get
        //    {
        //        return Parent_City;
        //    }
        //    set
        //    {
        //        Parent_City = value;
        //    }
        //}

        //public int ParentPinCode
        //{
        //    get
        //    {
        //        return Parent_PinCode;
        //    }
        //    set
        //    {
        //        Parent_PinCode = value;
        //    }
        //}

        //public string ParentPhone
        //{
        //    get
        //    {
        //        return Parent_PhoneNo;
        //    }
        //    set
        //    {
        //        Parent_PhoneNo = value;
        //    }
        //}

        //public string ParentFax
        //{
        //    get
        //    {
        //        return Parent_Fax;
        //    }
        //    set
        //    {
        //        Parent_Fax = value;
        //    }
        //}

        public string ParentMobile
        {
            get
            {
                return Parent_Mobile;
            }
            set
            {
                Parent_Mobile = value;
            }
        }

        public string ParentEmail
        {
            get
            {
                return Parent_Email;
            }
            set
            {
                Parent_Email = value;
            }
        }


        //public string AnnualIncome
        //{
        //    get
        //    {
        //        return Annul_Income;
        //    }
        //    set
        //    {
        //        Annul_Income = value;
        //    }
        //}

        //public string CreamyLayer
        //{
        //    get
        //    {
        //        return Creamy_Layer_Status;
        //    }
        //    set
        //    {
        //        Creamy_Layer_Status = value;
        //    }
        //}



        //public string LastClass
        //{
        //    get
        //    {
        //        return Last_Class;
        //    }
        //    set
        //    {
        //        Last_Class = value;
        //    }
        //}

        //public string ResidentType
        //{
        //    get
        //    {
        //        return Resident_Type;
        //    }
        //    set
        //    {
        //        Resident_Type = value;
        //    }
        //}

        public string LastInstitute
        {
            get
            {
                return Last_Institute;
            }
            set
            {
                Last_Institute = value;
            }
        }

        public string QualifiedExam
        {
            get
            {
                return LastQualified_Exam;
            }
            set
            {
                LastQualified_Exam = value;
            }
        }

        //public string Board1
        //{
        //    get
        //    {
        //        return Board;
        //    }
        //    set
        //    {
        //        Board = value;
        //    }
        //}

        //public string SeatNo
        //{
        //    get
        //    {
        //        return Seat_No;
        //    }
        //    set
        //    {
        //        Seat_No = value;
        //    }
        //}

        //public string PassingMonth
        //{
        //    get
        //    {
        //        return Passing_Month;
        //    }
        //    set
        //    {
        //        Passing_Month = value;
        //    }
        //}

        //public string PassingYear
        //{
        //    get
        //    {
        //        return Passing_Year;
        //    }
        //    set
        //    {
        //        Passing_Year = value;
        //    }
        //}

        //public string Result1
        //{
        //    get
        //    {
        //        return Result;
        //    }
        //    set
        //    {
        //        Result = value;
        //    }
        //}

        //public string Percentage1
        //{
        //    get
        //    {
        //        return Percentage;
        //    }
        //    set
        //    {
        //        Percentage = value;
        //    }
        //}

        //public string Eligibility1
        //{
        //    get
        //    {
        //        return Eligibility;
        //    }
        //    set
        //    {
        //        Eligibility = value;
        //    }
        //}

        //public string ResidanceState
        //{
        //    get
        //    {
        //        return Residance_State;
        //    }
        //    set
        //    {
        //        Residance_State = value;
        //    }
        //}

        //public string Gap1
        //{
        //    get
        //    {
        //        return Gap;
        //    }
        //    set
        //    {
        //        Gap = value;
        //    }
        //}

        //public string TcNo
        //{
        //    get
        //    {
        //        return Tc_No;
        //    }
        //    set
        //    {
        //        Tc_No = value;
        //    }
        //}

        //public string TcIssueDate
        //{
        //    get
        //    {
        //        return Tc_Issue_Date;
        //    }
        //    set
        //    {
        //        Tc_Issue_Date = value;
        //    }
        //}

        //public string OtherActivity
        //{
        //    get
        //    {
        //        return Other_Activity;
        //    }
        //    set
        //    {
        //        Other_Activity = value;
        //    }
        //}


        //public string FeeConcession
        //{
        //    get
        //    {
        //        return Fee_Concession;
        //    }
        //    set
        //    {
        //        Fee_Concession = value;
        //    }
        //}

        //public string ConcessionType
        //{
        //    get
        //    {
        //        return Concession_Type;
        //    }
        //    set
        //    {
        //        Concession_Type = value;
        //    }
        //}

        //public string BankName
        //{
        //    get
        //    {
        //        return Bank_Name;
        //    }
        //    set
        //    {
        //        Bank_Name = value;
        //    }
        //}

        //public string AccountNo
        //{
        //    get
        //    {
        //        return Account_No;
        //    }
        //    set
        //    {
        //        Account_No = value;
        //    }
        //}

        public string Branch1
        {
            get
            {
                return Branch;
            }
            set
            {
                Branch = value;
            }
        }

        //public string IFSCCode
        //{
        //    get
        //    {
        //        return IFSC_Code;
        //    }
        //    set
        //    {
        //        IFSC_Code = value;
        //    }
        //}

        //public string MaintenanceAllowance
        //{
        //    get
        //    {
        //        return Maintenance_Allowance;
        //    }
        //    set
        //    {
        //        Maintenance_Allowance = value;
        //    }
        //}





        //public string Passport1
        //{
        //    get
        //    {
        //        return Passport;
        //    }
        //    set
        //    {
        //        Passport = value;
        //    }
        //}

        public string Photo1
        {
            get
            {
                return Photo;
            }
            set
            {
                Photo = value;
            }
        }

        //public string Sign
        //{
        //    get
        //    {
        //        return Signature;
        //    }
        //    set
        //    {
        //        Signature = value;
        //    }
        //}

        //public string UserName
        //{
        //    get
        //    {
        //        return User_Name;
        //    }
        //    set
        //    {
        //        User_Name = value;
        //    }
        //}

        //public string Password1
        //{
        //    get
        //    {
        //        return Password;
        //    }
        //    set
        //    {
        //        Password = value;
        //    }
        //}



        //public string PassportNo { get; set; }

        public byte[] StudentPhoto { get; set; }

        //public byte[] StudentSign { get; set; }

        public string StudentUserName { get; set; }

        public string StudentPassword { get; set; }

        public string TransationAction { get; set; }

        public string Status { get; set; }
        public string AdmissionYear { get; set; }
        public string AcademicYearID { get; set; }
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        //public string SportId { get; set; }
        public string AdharNo { get; set; }


        //Added by ashwini 9-oct-20202
        public string Application_Date { get; set; }
        public string Course_Id { get; set; }
        public string CasteCategory_Id { get; set; }
        //
    }
}
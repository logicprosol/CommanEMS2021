namespace EntityWebApp
{
    public class EWA_SuperAdmin
    {
        #region OrganizationVariablesRegion

        private int _orgID;
        private string _Action;
        
        private string _OrgCode;
        private string _OrgName;
        private string _OrgLabel;
        private string _PhoneNo;
        private string _FaxNo;
        private string _Email;
        private string _Website;
        private string _Address;
        private string _Country;
        private string _State;
        private string _City;
        private int _Pincode;
        private string _UniversityCode;
        private string _MSBTECode;
        private string _AICTECode;
        private string _DTECode;
        private byte[] _LogoImage;
        private byte[] _LetterHeadImage;
        private string _TrustName;
        private string _OrgType;
        private string _UniversityName;

        #endregion OrganizationVariablesRegion

        #region OrganizationPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public string OrgType
        {
            get { return _OrgType; }
            set { _OrgType = value; }
        }

        public string OrgUniversity
        {
            get { return _UniversityName; }
            set { _UniversityName = value; }
        }

        public int orgID
        {
            get { return _orgID; }
            set { _orgID = value; }
        }

        public string OrgCode
        {
            get { return _OrgCode; }
            set { _OrgCode = value; }
        }

        public string TrustName
        {
            get { return _TrustName; }
            set { _TrustName = value; }
        }

        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }

        public string OrgLabel
        {
            get { return _OrgLabel; }
            set { _OrgLabel = value; }
        }

        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }

        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public int Pincode
        {
            get { return _Pincode; }
            set { _Pincode = value; }
        }

        public string UniversityCode
        {
            get { return _UniversityCode; }
            set { _UniversityCode = value; }
        }

        public string MSBTECode
        {
            get { return _MSBTECode; }
            set { _MSBTECode = value; }
        }

        public string AICTECode
        {
            get { return _AICTECode; }
            set { _AICTECode = value; }
        }

        public string DTECode
        {
            get { return _DTECode; }
            set { _DTECode = value; }
        }

        public byte[] LogoImage
        {
            get { return _LogoImage; }
            set { _LogoImage = value; }
        }

        public byte[] LetterHeadImage
        {
            get { return _LetterHeadImage; }
            set { _LetterHeadImage = value; }
        }

        #endregion OrganizationPropertyRegion
    }
}
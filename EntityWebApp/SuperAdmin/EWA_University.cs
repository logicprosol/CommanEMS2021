namespace EntityWebApp.SuperAdmin
{
    public class EWA_University
    {
        //University region

        //University Variables Declaration

        #region UniversityVariablesRegion

        public string _Action;
        private int _UniversityId;
        private string _UniversityName;
        private string _Address;
        private string _Country;
        private string _State;
        private string _City;
        private string _PinCode;
        private string _Email;
        private string _Contact;

        //private string _Contact2;
        private string _FaxNo;

        //  private string _FaxNo2;
        private byte[] _Logo;

        #endregion UniversityVariablesRegion

        //University Properties Declaration

        #region UniversityPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int UniversityId
        {
            get { return _UniversityId; }
            set { _UniversityId = value; }
        }

        public string UniversityName
        {
            get { return _UniversityName; }
            set { _UniversityName = value; }
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

        public string PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }

        /*
        public string Contact2
        {
            get { return _Contact2; }
            set { _Contact2 = value; }
        }
         */

        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }

        /*
        public string FaxNo2
        {
            get { return _FaxNo2; }
            set { _FaxNo2 = value; }
        }
         */

        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        #endregion UniversityPropertyRegion
    }
}
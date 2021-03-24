namespace EntityWebApp.Admin
{
    public class EWA_Login
    {
        //Loginregion

        #region LoginRegion

        //Login Variables Declaration

        #region LoginVariablesRegion

        public string _Action;
        private int _UserId;
        private string _UserType;
        private string _UserName;
        private string _Password;
        private string _Role;
        private string _UserTypeId;
        private string _Status;
        private string _OrgId;
        private string _IsActive;
        private string _UserCode;
        #endregion LoginVariablesRegion

        //Hello
        //PropertyDeclaration

        #region LoginPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }

        public string UserCode
        {
            get { return _UserCode; }
            set { _UserCode= value; }
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

        public string OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

        public string IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        #endregion LoginPropertyRegion

        #endregion LoginRegion
    }
}
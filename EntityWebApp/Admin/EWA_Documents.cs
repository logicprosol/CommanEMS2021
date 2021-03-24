namespace EntityWebApp.Admin
{
    public class EWA_Documents
    {
        //Documentregion

        #region DocumentRegion

        //Document Variables Declaration

        #region DocumentVariablesRegion

        public string _Action;
        private int _DocumentId;
        private string _DocumentName;
        private string _DocumentType;
     //   private int _OrgId;
        private string _AcademicYearId;
        private string _UserId;
        private string _IsActive;

        #endregion DocumentVariablesRegion

        //Document Properties Declaration

        #region DocumentPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int DocumentId
        {
            get { return _DocumentId; }
            set { _DocumentId = value; }
        }

        public string DocumentName
        {
            get { return _DocumentName; }
            set { _DocumentName = value; }
        }

        public string DocumentType
        {
            get { return _DocumentType; }
            set { _DocumentType = value; }
        }

        public int OrgId { get; set; }

        

        public string AcademicYearId
        {
            get { return _AcademicYearId; }
            set { _AcademicYearId = value; }
        }

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        #endregion DocumentPropertyRegion

        #endregion DocumentRegion
    }
}
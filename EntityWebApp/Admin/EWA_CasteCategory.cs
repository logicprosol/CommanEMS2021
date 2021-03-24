namespace EntityWebApp.Admin
{
    public class EWA_CasteCategory
    {
        #region CasteCategoryRegion

        //Document Variables Declaration

        #region CasteCategoryVariablesRegion

        public string _Action;
        private int _CasteCategoryId;
        private string _CasteCategoryName;
        private string _Code;
        private int _OrgId;
        private string _AcademicYearId;
        private string _UserId;
        private string _TransDate;
        private string _IsActive;

        #endregion CasteCategoryVariablesRegion

        #region CasteCategoryPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int CasteCategoryId
        {
            get { return _CasteCategoryId; }
            set { _CasteCategoryId = value; }
        }

        public string CasteCategoryName
        {
            get { return _CasteCategoryName; }
            set { _CasteCategoryName = value; }
        }

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

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

        public string TransDate
        {
            get { return _TransDate; }
            set { _TransDate = value; }
        }

        public string IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        #endregion CasteCategoryPropertyRegion

        #endregion CasteCategoryRegion
    }
}
namespace EntityWebApp.Admin
{
    public class EWA_ProgramExecutive
    {
        //Courseregion

        #region CourseRegion

        //Courses Variables Declaration

        #region CoursesVariablesRegion

        public string _Action;
        private string _CourseId;
        private string _CourseCode;
        private string _CourseName;
        private int _OrgId;
        private string _AcademicYearId;
        private string _UserId;
        private string _IsActive;

        #endregion CoursesVariablesRegion

        //Courses Properties Declaration

        #region CoursesPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public string CourseId
        {
            get { return _CourseId; }
            set { _CourseId = value; }
        }

        public string CourseCode
        {
            get { return _CourseCode; }
            set { _CourseCode = value; }
        }

        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; }
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

        public string IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        #endregion CoursesPropertyRegion

        #endregion CourseRegion

        //Branchregion

        #region BranchRegion

        //Branch Variables Declaration

        #region BranchVariablesRegion

        public string _ActionB;
        private string _BranchId;

        private string _BranchCode;
        private string _BranchName;

        #endregion BranchVariablesRegion

        //Branch Properties Declaration

        #region BranchPropertyRegion

        public string ActionB
        {
            get { return _ActionB; }
            set { _ActionB = value; }
        }

        public string BranchId
        {
            get { return _BranchId; }
            set { _BranchId = value; }
        }

        public string BranchCode
        {
            get { return _BranchCode; }
            set { _BranchCode = value; }
        }

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        #endregion BranchPropertyRegion

        #endregion BranchRegion

        //Classregion

        #region ClassRegion

        //Classes Variables Declaration

        #region ClassesVariablesRegion

        public string _ActionC;
        private string _ClassId;
        private string _ClassCode;
        private string _ClassName;

        #endregion ClassesVariablesRegion

        //Classes Properties Declaration

        #region ClassesPropertyRegion

        public string ActionC
        {
            get { return _ActionC; }
            set { _ActionC = value; }
        }

        public string ClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; }
        }

        public string ClassCode
        {
            get { return _ClassCode; }
            set { _ClassCode = value; }
        }

        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }

        #endregion ClassesPropertyRegion

        #endregion ClassRegion

        //Divisionregion

        #region DivisionRegion

        //Division Variables Declaration

        #region DivisionVariablesRegion

        public string _ActionD;
        private string _DivisionId;
        private string _DivisionCode;
        private string _DivisionName;

        #endregion DivisionVariablesRegion

        //Division Properties Declaration

        #region DivisionPropertyRegion

        public string ActionD
        {
            get { return _ActionD; }
            set { _ActionD = value; }
        }

        public string DivisionId
        {
            get { return _DivisionId; }
            set { _DivisionId = value; }
        }

        public string DivisionCode
        {
            get { return _DivisionCode; }
            set { _DivisionCode = value; }
        }

        public string DivisionName
        {
            get { return _DivisionName; }
            set { _DivisionName = value; }
        }

        #endregion DivisionPropertyRegion

        #endregion DivisionRegion
    }
}
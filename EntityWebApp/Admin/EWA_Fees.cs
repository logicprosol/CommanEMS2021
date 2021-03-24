namespace EntityWebApp.Admin
{
    public class EWA_Fees
    {
        //Insert Data into Fees Table

        #region Variables

        private string _Action;
        private string _FeesId;
        private string _FeesDetalsId;
        private string _Particular;
        private string _Amount;
        private string _OldParticular;
        private string _OldAmount;
        private string _CourseId;
        private string _BranchId;
        private string _ClassId;
        private string _CasteCategoryId;
        private string _OrgId;
        private string _AcademicYear;

        #endregion Variables

        //PropertyDeclaration

        public string Action
        {
            get
            {
                return _Action;
            }
            set
            {
                _Action = value;
            }
        }

        public string FeesId
        {
            get
            {
                return _FeesId;
            }
            set
            {
                _FeesId = value;
            }
        }

        public string FeesDetalsId
        {
            get
            {
                return _FeesDetalsId;
            }
            set
            {
                _FeesDetalsId = value;
            }
        }

        public string CourseId
        {
            get
            {
                return _CourseId;
            }
            set
            {
                _CourseId = value;
            }
        }

        public string BranchId
        {
            get
            {
                return _BranchId;
            }
            set
            {
                _BranchId = value;
            }
        }

        public string ClassId
        {
            get
            {
                return _ClassId;
            }
            set
            {
                _ClassId = value;
            }
        }

        public string AcademicYear
        {
            get
            {
                return _AcademicYear;
            }
            set
            {
                _AcademicYear = value;
            }
        }

        public string CasteCategoryId
        {
            get
            {
                return _CasteCategoryId;
            }
            set
            {
                _CasteCategoryId = value;
            }
        }

        public string OrgId
        {
            get
            {
                return _OrgId;
            }
            set
            {
                _OrgId = value;
            }
        }

        public string Particular
        {
            get
            {
                return _Particular;
            }
            set
            {
                _Particular = value;
            }
        }

        public string Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }

        public string OldParticular
        {
            get
            {
                return _OldParticular;
            }
            set
            {
                _OldParticular = value;
            }
        }

        public string OldAmount
        {
            get
            {
                return _OldAmount;
            }
            set
            {
                _OldAmount = value;
            }
        }
    }
}
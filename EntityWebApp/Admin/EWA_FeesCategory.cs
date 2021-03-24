using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_FeesCategory
    {
        #region FeesCategoryRegion

        //Document Variables Declaration

        #region FeesCategoryVariablesRegion

        public string _Action;
        private int _FeesCategoryId;
        private string _FeesCategoryName;
        private string _Code;
        private int _OrgId;
        private string _AcademicYearId;
        private string _UserId;
        private string _TransDate;
        private string _IsActive;

        #endregion FeesCategoryVariablesRegion

        #region FeesCategoryPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int FeesCategoryId
        {
            get { return _FeesCategoryId; }
            set { _FeesCategoryId = value; }
        }

        public string FeesCategoryName
        {
            get { return _FeesCategoryName; }
            set { _FeesCategoryName = value; }
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

        #endregion FeesCategoryPropertyRegion

        #endregion FeesCategoryRegion
    }
}

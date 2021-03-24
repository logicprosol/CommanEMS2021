using System;

namespace EntityWebApp.Admin
{
    public class EWA_DepartmentDesignation
    {
        //Departmentregion

        #region DepartmentRegion

        //Department Variables Declaration

        #region DepartmentsVariablesRegion

        public string _Action;
        private int _DepartmentId;
        private string _DepartmentCode;
        private string _DepartmentName;

        //Common Region Variable Declaration
        private int _OrgId;

        private int _AcademicYearId;
        private string _UserId;
        private Boolean _IsActive;

        #endregion DepartmentsVariablesRegion

        //Department Properties Declaration

        #region DepartmentPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int DepartmentId
        {
            get { return _DepartmentId; }
            set { _DepartmentId = value; }
        }

        public string DepartmentCode
        {
            get { return _DepartmentCode; }
            set { _DepartmentCode = value; }
        }

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        #endregion DepartmentPropertyRegion

        #endregion DepartmentRegion

        //Designationregion

        #region DesignationRegion

        //Designation Variables Declaration

        #region DesignationVariablesRegion

        public string _ActionDes;
        private int _DesignationId;
        private string _DesignationCode;
        private string _DesignationName;
        private string _DesignationTypeId;

        #endregion DesignationVariablesRegion

        //Department Properties Declaration

        #region DesignationPropertyRegion

        public string ActionDes
        {
            get { return _ActionDes; }
            set { _ActionDes = value; }
        }

        public int DesignationId
        {
            get { return _DesignationId; }
            set { _DesignationId = value; }
        }

        public string DesignationCode
        {
            get { return _DesignationCode; }
            set { _DesignationCode = value; }
        }

        public string DesignationName
        {
            get { return _DesignationName; }
            set { _DesignationName = value; }
        }

        public string DesignationTypeId
        {
            get { return _DesignationTypeId; }
            set { _DesignationTypeId = value; }
        }

        #endregion DesignationPropertyRegion

        #endregion DesignationRegion

        #region CommonRegion

        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

        public int AcademicYearId
        {
            get { return _AcademicYearId; }
            set { _AcademicYearId = value; }
        }

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        #endregion CommonRegion
    }
}
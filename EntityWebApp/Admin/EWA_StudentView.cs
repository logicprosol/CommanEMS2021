using System;

namespace EntityWebApp.Admin
{
    public class EWA_StudentView
    {
        //StudentViewregion

        #region StudentViewregion

        private string _Action;
        private int _OrgId;
        private string _Usertype;

        //Organization
        private DateTime _Date;

        private string _TrustName;
        private string _CollageName;
        private string _Address;
        private string _Name;

        //Student Admission Details
        private int _ApplicationId;

        private DateTime _DOB;
        private string _Stream;
        private string _CurrentAddress;
        private string _PermanentAddress;
        private string _Email;
        private string _BloodGroup;

        #endregion StudentViewregion

        //Property Declaration

        #region StudentPropertyRegion

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

        public string Usertype
        {
            get { return _Usertype; }
            set { _Usertype = value; }
        }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string TrustName
        {
            get { return _TrustName; }
            set { _TrustName = value; }
        }

        public string CollageName
        {
            get { return _CollageName; }
            set { _CollageName = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }

        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        public string Stream
        {
            get { return _Stream; }
            set { _Stream = value; }
        }

        public string CurrentAddress
        {
            get { return _CurrentAddress; }
            set { _CurrentAddress = value; }
        }

        public string PermanentAddress
        {
            get { return _PermanentAddress; }
            set { _PermanentAddress = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
        }

        public long StudentID { get; set; }

        #endregion StudentPropertyRegion

        public string BranchId { get; set; }

        public string DivisionId { get; set; }

        public string ClassId { get; set; }

        public string CourseId { get; set; }

        public string StaffId { get; set; }
    }
}
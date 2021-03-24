using System;

namespace EntityWebApp.Admin
{
    public class EWA_AcademicYear
    {
        //AcademicYear Property Region

        #region AcademicYearRegion

        public int AcademicYearId { get; set; }

        public string Action { get; set; }

        public string AcademicYear { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Code { get; set; }

        public Boolean IsCurrentYear { get; set; }

        public int OrgId { get; set; }

        public string UserId { get; set; }

        public string IsActive { get; set; }

        #endregion AcademicYearRegion
    }
}
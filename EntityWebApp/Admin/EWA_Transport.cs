using System;

namespace EntityWebApp.Admin
{
    public class EWA_Transport
    {
        //Route Property Declaration

        #region RoutePropertyRegion

        public string ActionV { get; set; }

        public int RouteId { get; set; }

        public string Route { get; set; }

        public string RouteTitle { get; set; }

        public Double Amount { get; set; }

        #endregion RoutePropertyRegion

        //Route Property Declaration

        #region BoardPropertyRegion

        public string ActionB { get; set; }

        public int BoardId { get; set; }

        public string BoardTitle { get; set; }

        #endregion BoardPropertyRegion

        //Vehicle Property Declaration

        #region VehiclePropertyRegion

        public string Action { get; set; }

        public int VehicleId { get; set; }

        public string VehicleType { get; set; }

        public string VehicleNumber { get; set; }

        public string VehicleModel { get; set; }

        public int VehicleCapacity { get; set; }

        public int OrgId { get; set; }

        //private string _AcademicYearId;
        //private string _UserId;
        public string IsActive { get; set; }

        #endregion VehiclePropertyRegion

        //DriverInfo Property Declaration

        #region DriverInfoPropertyRegion

        public string ActionD { get; set; }

        public int DriverId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string LicenseId { get; set; }

        public string LicenseType { get; set; }

        public byte[] UploadImage { get; set; }

        #endregion DriverInfoPropertyRegion


        //AllotDriverInfo Property Declaration

        #region AllotDriverInfoPropertyRegion
        public string ActionAD { get; set; }
        #endregion DriverInfoPropertyRegion


        //Added by Ashwini 30-sep-2020
        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public int BranchId { get; set; }
        public int AcademicYear { get; set; }
        //

    }
}
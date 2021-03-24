namespace EntityWebApp.Admin
{
    public class EWA_Scheme
    {
        public string Action { get; set; }

        public int SchemeDetailsId { get; set; }

        public int SchemeId { get; set; }

        public double SchemeAmount { get; set; }

        public string SchemeName { get; set; }

        public string FundName { get; set; }

        //public double GrantedAmount { get; set; }

        public double DistributedAmount { get; set; }

        public int AcademicYearId { get; set; }

        public int OrganizationId { get; set; }

        public string UserId { get; set; }

        public bool IsActive { get; set; }
    }
}
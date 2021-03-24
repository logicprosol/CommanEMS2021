namespace EntityWebApp.Admin
{
    public class EWA_Role
    {
        public string Action { get; set; }

        public string Role { get; set; }

        public string UserType { get; set; }

        //public int AcademicYearId { get; set; }

        public int OrganizationId { get; set; }

        public string UserId { get; set; }

        public bool IsActive { get; set; }
    }
}
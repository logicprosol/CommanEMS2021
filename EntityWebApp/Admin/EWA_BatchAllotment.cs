namespace EntityWebApp.Admin
{
    public class EWA_BatchAllotment
    {
        #region DeclareCommoinPropertyRegion

        public string Action { get; set; }

        public string OrgId { get; set; }

        public string DepartmentId { get; set; }

        public string DesignationId { get; set; }

        public string DesignationTypeId { get; set; }

        public string CourseId { get; set; }

        public string BranchId { get; set; }

        public string ClassId { get; set; }

        public string SemesterId { get; set; }

        public string DivisionId { get; set; }

        public string DesignationType { get; set; }

        //Student GridBind
        public string AdmissionId { get; set; }
        public int AcademicYearId { get; set; }

        #endregion 
    }
}
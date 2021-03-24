namespace DataAccessLayer.Admin
{
    public class EWA_BatchAllotment
    {
        public int orgId { get; set; }

        public int AcadminYearId { get; set; }

        public int studentId { get; set; }

        public int studentName { get; set; }

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

        #endregion DeclareCommoinPropertyRegion
    }
}
namespace EntityWebApp
{
    /* =============================================
    -- Author:		Deepak Sawant
    -- Create date: 06/Jan/2014
    -- Description:	To Perform Common Operation
    -- ============================================= */

    public class EWA_Common
    {
        #region DeclareCommoinPropertyRegion

        public string Action { get; set; }
        public string OrgId { get; set; }
        public string AcademicYear { get; set; }

        public string UserCode { get; set; }

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

        public string date { get; set; }
        public string Status { get; set; }

        //Added by Ashwini 25-sep-2020
        public string addmissionId { get; set;}
        public string StudId { get; set;}
        public string course { get; set; }

        //Added by Ashwini 23-Oct-2020
        public string student { get; set; }
        public string Criteria { get; set; }
        public string CriteriaValue { get; set; }



        public string todate { get; set; }
        public string fromdate { get; set; }
        public decimal installmentAmt { get; set; }
        public string installmentNo { get; set; }
        public string AcademicYearId { get; set; }
        public string OrgId1 { get; set; }
        public string Class { get; set; }
        public string installmentId { get; set; }
        #endregion DeclareCommoinPropertyRegion
    }
}
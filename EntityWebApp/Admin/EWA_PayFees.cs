using System;

namespace EntityWebApp.Admin
{
    public class EWA_PayFees
    {
        #region Pay Fees PropertyRegion

        public string Action { get; set; }

        public int OrgId { get; set; }

        //Student GridBind
        public string AdmissionId { get; set; }

        public string FeesId { get; set; }
        public string FeesDetailsId { get; set; }
        public string StudentCode { get; set; }

        public int AcadmicYearId { get; set; }

        #endregion Pay Fees PropertyRegion

        //Pay FeesInstallment region
        //Insert data into StudentFeesPaid Table
        #region [Pay Fees Installment Region]
     
        public decimal TotalAmount { get; set; }

        public decimal TotalPaidAmount { get; set; }

        public decimal TotalPendingAmount { get; set; }

        public string UserId { get; set; }
        public string Paymentmode{get; set;}
        public string remark { get; set;  }
        public DateTime TransactionDate { get; set; }
        #endregion


        //Added by Ashwini More-5-Oct-2020
        public string CourseId { get; set; }
        public string ClassId { get; set; }
        public string BranchId { get; set; }

        //
    }
}
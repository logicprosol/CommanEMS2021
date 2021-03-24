using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
    public class BL_PayFees
    {
        //Bind Grid of StudentData_BL to confirm Admission
        #region[Bind Student Data Region]

        public DataSet BindStudentData_BL(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindStudentData_DL(objEWA);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        //Bind Grid of StudentFeesDetails_BL to confirm Admission
        #region[Student Fees Details]

        public DataSet BindStudentFeesDetails_BL(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindStudentFeesDetails_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Grid of StudentData_BL to Pay Fees Installment
        #region[Bind Student Data Region]

        public DataSet BindStudentDetails_BL(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindStudentDetails_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Grid of StudentFeesPaidDetails_BL to confirm Admission
        #region[Student Fees Details]

        public DataSet BindStudentFeesPaidDetails_BL(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindStudentFeesPaidDetails_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Grid of StudentFeesPendingDetails_BL to Pay
        #region[Student Fees Pending Details]

        public DataSet BindStudentFeesPendingDetails_BL(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindStudentFeesPending_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Pay Fees Installments
        // Save Student Registration
        #region[Save Student]

        public int PayFeesInstallmentsAction_BL(EWA_PayFees objEWA, DataTable dtFees, DataTable dtFees_Bus)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                int flag = objDL.PayFeesInstallmentsAction_DL(objEWA,  dtFees,dtFees_Bus);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public DataSet GetDataStudentFeesPaid(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindPreviousFeeRecord(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetDataStudent(EWA_PayFees objEWA)
        {
            try
            {
                DL_PayFees objDL = new DL_PayFees();
                DataSet ds = objDL.BindGetstudentData(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
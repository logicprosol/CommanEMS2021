using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using EntityWebApp.Admin;

//Pay Fee
namespace DataAccessLayer.Admin
{
    public class DL_PayFees
    {
        // Object Declaration
        
        #region[Object Declaration]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd;
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        #endregion
       

        // Bind Grid of StudentData_DL
        #region[Bind Student Data Region]
        public DataSet BindStudentData_DL(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudentToPayFees";
                prmList[2] = "@AdmissionId";
                prmList[3] = objEWA.AdmissionId;
                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);
                prmList[6] = "@AcademicId";
                prmList[7] = objEWA.AcadmicYearId.ToString();
              
             
                //prmList[7] = HttpContext.Current.Session["AcademicYearId"].ToString();

                ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                return ds;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        // Bind Grid of StudentFeesDetails_DL
        #region[Bind Student Data Region]
        public DataSet BindStudentFeesDetails_DL(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet(); 
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudentFeesDetails";
                prmList[2] = "@FeesId";
                prmList[3] = objEWA.FeesId;
                prmList[4] = "@AdmissionId";
                prmList[5] = objEWA.AdmissionId;
                prmList[6] = "@AcademicId";
                prmList[7] = objEWA.AcadmicYearId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        // Bind Grid of StudentData_DL To Pay Fees Installment
        #region[Bind Student Details Region]
        public DataSet BindStudentDetails_DL(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudToPayInstallment";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.StudentCode;
                prmList[4] = "@OrgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        // Bind Grid of StudentFeesPaidDetails_DL
        #region[Bind Student Data Region]
        public DataSet BindStudentFeesPaidDetails_DL(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                //    //    //Commnented by Ashwini More 5 - Oct - 2020
                //    prmList = new string[4];
                //    prmList[0] = "@Action";
                //    prmList[1] = "FetchStudFeesPaidDetails";
                //    prmList[2] = "@UserCode";
                //    prmList[3] = objEWA.StudentCode;
                //    ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                //    return ds;
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
              //  Added by Ashwini 5 - Oct - 2020
            prmList = new string[12];
                 prmList[0] = "@Action";
                 prmList[1] = "FetchStudFeesPaidDetails";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.StudentCode;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;
                prmList[10] = "@AcademicId";
                prmList[11] = objEWA.AcadmicYearId.ToString();
                //
                ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        // Bind Grid of StudentFeesInstallmentToPay_DL
        #region[Bind Student Data Region]
        public DataSet BindStudentFeesPending_DL(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                //Commented By Ashwini 6-oct-2020
                //    prmList = new string[4];
                //    prmList[0] = "@Action";
                //    prmList[1] = "PayPendingFees";
                //    prmList[2] = "@UserCode";
                //    prmList[3] = objEWA.StudentCode;

                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "PayPendingFees";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.StudentCode;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@ClassId";
                prmList[7] = objEWA.ClassId;
                prmList[8] = "@BranchId";
                prmList[9] = objEWA.BranchId;
                prmList[10] = "@AcademicId";
                prmList[11] = objEWA.AcadmicYearId.ToString();
                ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion   

        // Bind Paid Receipt Report
        #region[Paid Receipt Report]
        public DataSet BindPaidReceiptReport(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "PrintReceipt";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.StudentCode;

                ds = ObjHelper.FillControl(prmList, "SP_PayFees");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        // To Pay Fees Installments
        #region[ Pay Fees Installments]
        public int PayFeesInstallmentsAction_DL(EWA_PayFees objEWA, DataTable dtFees, DataTable dtFees_Bus)
        { 
            try
            {
                //Save PayFeesInstallments data in StudentFeesPaid Table
                cmd = new SqlCommand("SP_PayFees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.StudentCode);
                cmd.Parameters.AddWithValue("@FeesId", objEWA.FeesId);
                cmd.Parameters.AddWithValue("@FeesDetailsId", objEWA.FeesDetailsId);
                cmd.Parameters.AddWithValue("@TotalAmount", objEWA.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", objEWA.TotalPaidAmount);
                cmd.Parameters.AddWithValue("@PendingAmount", objEWA.TotalPendingAmount);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
                cmd.Parameters.AddWithValue("@Paymentmode", objEWA.Paymentmode);
                cmd.Parameters.AddWithValue("@remark", objEWA.remark);
                cmd.Parameters.AddWithValue("@TransDate", objEWA.TransactionDate);
                cmd.Parameters.AddWithValue("@StudentFeesPaid", dtFees);
                cmd.Parameters.AddWithValue("@StudentBusFeesPaid", dtFees_Bus);


                con.Open();
                var flag = cmd.ExecuteScalar();
                con.Close();
                return Convert.ToInt32(flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public DataSet BindPreviousFeeRecord(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "FetchInstallments";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.StudentCode;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;
                prmList[10] = "@AcademicId";
                prmList[11] = objEWA.AcadmicYearId.ToString();
                //
                ds = ObjHelper.FillControl(prmList, "SP_GetPreviousYearFeesData");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BindGetstudentData(EWA_PayFees objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudentData";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.StudentCode;
                prmList[4] = "@CourseId";
                prmList[5] = objEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = objEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = objEWA.ClassId;
                prmList[10] = "@AcademicId";
                prmList[11] = objEWA.AcadmicYearId.ToString();
                //
                ds = ObjHelper.FillControl(prmList, "SP_GetPreviousYearFeesData");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
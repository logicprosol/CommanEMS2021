using EntityWebApp.HR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.HR
{
    public class DL_ChallanRecAdmin
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public DataSet DL_ChallanByAdmin(EWA_ChallanRecAdmin objEWA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ChallanFeesHr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ChallanAmt_getdisplayhr");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet DL_ChallanByHr(EWA_ChallanRecAdmin objEWA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_FeesDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ChallanAmt_Approvehr");
                cmd.Parameters.AddWithValue("@GroupReceiptNo", objEWA.GroupReceiptNo);
                cmd.Parameters.AddWithValue("@StudentId", objEWA.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", objEWA.StudentName);
                cmd.Parameters.AddWithValue("@TotalAmount", objEWA.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", objEWA.PaidAmount);
                cmd.Parameters.AddWithValue("@PendingAmount", objEWA.PendingAmount);
                cmd.Parameters.AddWithValue("@Status", objEWA.Status);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet DL_ChallanBySearchRep(EWA_ChallanRecAdmin objEWA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ChallanFees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ChallanAmt_getadminonsearch");
                cmd.Parameters.AddWithValue("@GroupReceiptNo", objEWA.GroupReceiptNo);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

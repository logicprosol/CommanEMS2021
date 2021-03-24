using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Admin
{    
  public class DL_Challanrecord
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public DataSet DL_Challan(EWA_Challanrecord objEWA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Fees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ChallanAmt_getadmin");
               

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

        public DataSet DL_ChallanByadmin(EWA_Challanrecord objEWA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_FeesDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ChallanAmt_gethr");
                // cmd.Parameters.AddWithValue("@Id", objEWA.Id);
                cmd.Parameters.AddWithValue("@GroupReceiptNo", objEWA.GroupReceiptNo);
                cmd.Parameters.AddWithValue("@StudentId", objEWA.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", objEWA.StudentName);
                cmd.Parameters.AddWithValue("@TotalAmount", objEWA.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", objEWA.PaidAmount);
                cmd.Parameters.AddWithValue("@PendingAmount", objEWA.PendingAmount);
                //cmd.Parameters.AddWithValue("Status", "Approve By Admin");


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
        public DataSet DL_ChallanBySearchRep(EWA_Challanrecord objEWA)
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

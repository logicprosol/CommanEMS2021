using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace dal
{
   
    public class clsd
    {
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter DA = new SqlDataAdapter();

// Insert into Product Master////////////////////////////////////////////////////////////////////////////////////
        //public void insertHostel(clse_hostel clse_hostel)
        //{
        //    cn.Open();
        //    cmd.Connection = cn;
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_productMaster";
        //    //cmd.Parameters.AddWithValue("@Action", "insert");
        //    cmd.Parameters.AddWithValue("Hostel_id", clse_hostel.Hostel_id);
        //    cmd.Parameters.AddWithValue("Hostel_name", clse_hostel.Hostel_name);
        //    cmd.Parameters.AddWithValue("Hostel_Types", clse_hostel.Hostel_Types);
        //    cmd.Parameters.AddWithValue("H_totalroom", clse_hostel.H_totalroom);
        //    cmd.Parameters.AddWithValue("Hostel_Address", clse_hostel.Hostel_Address);
          
        //    cmd.ExecuteNonQuery();
        //    cn.Close();
        //}

        //public void updateproduct(clse_hostel clse_Product_master)
        //{
        //    cn.Open();
        //    cmd.Parameters.Clear();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_productMaster";
        //    cmd.Parameters.AddWithValue("@Action", "update");
        //    cmd.Parameters.AddWithValue("p_id", clse_Product_master.p_id);
        //    cmd.Parameters.AddWithValue("p_name", clse_Product_master.p_name);
        //    cmd.Parameters.AddWithValue("p_type", clse_Product_master.p_type);
        //    cmd.Parameters.AddWithValue("p_price", clse_Product_master.p_price);
        //    cmd.Parameters.AddWithValue("p_unit", clse_Product_master.p_unit);
        //    cmd.Parameters.AddWithValue("p_description", clse_Product_master.p_description);
        //    cmd.ExecuteNonQuery();
        //    cn.Close();
        //}

        //public void deleteproduct(clse_hostel clse_Product_master)
        //{
        //    cn.Open();
        //    cmd.Parameters.Clear();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_productMaster";
        //    cmd.Parameters.AddWithValue("@Action", "delete");
        //    cmd.Parameters.AddWithValue("p_id", clse_Product_master.p_id);
        //    cmd.Parameters.AddWithValue("p_name", clse_Product_master.p_name);
        //    cmd.Parameters.AddWithValue("p_type", clse_Product_master.p_type);
        //    cmd.Parameters.AddWithValue("p_price", clse_Product_master.p_price);
        //    cmd.Parameters.AddWithValue("p_unit", clse_Product_master.p_unit);
        //    cmd.Parameters.AddWithValue("p_description", clse_Product_master.p_description);
        //    cmd.ExecuteNonQuery();
        //    cn.Close();
        //}

        public DataSet SELECTHOSTEL(clse_hostel clse_hostel)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_HostelAdmission";
            cmd.Parameters.AddWithValue("@HostelId", clse_hostel.Hostel_id);
            cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(clse_hostel.OrgId));
            cmd.Parameters.AddWithValue("@Action", "SelectHostel");
            cmd.ExecuteNonQuery();
            DA.SelectCommand = cmd;
            DA.Fill(ds);
            cn.Close();
            return ds;

        }

        //public DataSet SELECTHOSTELROOM(clse_HostelRoom clse_HostelRoom)
        //{
        //    cn.Open();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_HostelRoom";
        //    cmd.Parameters.AddWithValue("Host_id", clse_HostelRoom.RoomId);
        //    cmd.ExecuteNonQuery();
        //    DA.SelectCommand = cmd;
        //    DA.Fill(ds);
        //    cn.Close();
        //    return ds;

        //}

        public DataSet COMPANY(clse_companymaster clse_companymaster)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_SELECTCOMPANY";
            cmd.Parameters.AddWithValue("Company_id", clse_companymaster.Company_id);
            cmd.ExecuteNonQuery();
            DA.SelectCommand = cmd;
            DA.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataSet productkey(clse_productkey clse_productkey)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_OrgDetails";
            cmd.Parameters.AddWithValue("OrgId", clse_productkey.OrgId);
            cmd.ExecuteNonQuery();
            DA.SelectCommand = cmd;
            DA.Fill(ds);
            cn.Close();
            return ds;

        }

        public DataSet returnbook(clse_returnbook clse_returnbook)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "returnbook";
            cmd.Parameters.AddWithValue("StudentId", clse_returnbook.StudentId);
            cmd.ExecuteNonQuery();
            DA.SelectCommand = cmd;
            DA.Fill(ds);
            cn.Close();
            return ds;

        }

        //public DataSet hrProfile(clse_hrprofile clse_hrprofile)
        //{
        //    cn.Open();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "returnbook";
        //    cmd.Parameters.AddWithValue("StudentId", clse_hrprofile.StudentId);
        //    cmd.ExecuteNonQuery();
        //    DA.SelectCommand = cmd;
        //    DA.Fill(ds);
        //    cn.Close();
        //    return ds;

        //}


        


        //Insert Supplier Master //////////////////////////////////////////////////////////////////////////////////////
        //public void insertSupplier(clse_Supmaster clse_Supmaster)
        //{
        //    cn.Open();
        //    cmd.Connection = cn;

        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_Supmaster";
        //    cmd.Parameters.AddWithValue("sup_id", clse_Supmaster.sup_id);
        //    cmd.Parameters.AddWithValue("sup_companyName", clse_Supmaster.sup_companyName);
        //    cmd.Parameters.AddWithValue("sup_name", clse_Supmaster.sup_name);
        //    cmd.Parameters.AddWithValue("sup_address", clse_Supmaster.sup_address);
        //    cmd.Parameters.AddWithValue("sup_mob", clse_Supmaster.sup_mob);
        //    cmd.Parameters.AddWithValue("sup_contactno", clse_Supmaster.sup_contactno);
        //    cmd.ExecuteNonQuery();
        //    cn.Close();
        //}
        //public void updateSupplier(clse_Supmaster clse_Supmaster)
        //{
        //    cn.Open();
        //    cmd.Connection = cn;
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_Supmaster";
        //    cmd.Parameters.AddWithValue("sup_id", clse_Supmaster.sup_id);
        //    cmd.Parameters.AddWithValue("sup_companyName", clse_Supmaster.sup_companyName);
        //    cmd.Parameters.AddWithValue("sup_name", clse_Supmaster.sup_name);
        //    cmd.Parameters.AddWithValue("sup_address", clse_Supmaster.sup_address);
        //    cmd.Parameters.AddWithValue("sup_mob", clse_Supmaster.sup_mob);
        //    cmd.Parameters.AddWithValue("sup_contactno", clse_Supmaster.sup_contactno);
        //    cmd.ExecuteNonQuery();
        //    cn.Close();
        //}
        //public void deleteSupplier(clse_Supmaster clse_Supmaster)
        //{
        //    cn.Open();
        //    cmd.Connection = cn;
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_Supmaster";
           
        //    cmd.Parameters.AddWithValue("sup_id", clse_Supmaster.sup_id);
        //    cmd.Parameters.AddWithValue("sup_companyName", clse_Supmaster.sup_companyName);
        //    cmd.Parameters.AddWithValue("sup_name", clse_Supmaster.sup_name);
        //    cmd.Parameters.AddWithValue("sup_address", clse_Supmaster.sup_address);
        //    cmd.Parameters.AddWithValue("sup_mob", clse_Supmaster.sup_mob);
        //    cmd.Parameters.AddWithValue("sup_contactno", clse_Supmaster.sup_contactno);
        //    cmd.ExecuteNonQuery();
        //    cn.Close();
        //}

//        public DataSet selectsupplier(clse_Supmaster clse_Supmaster)
//        {
//            cn.Open();
//            cmd.Connection = cn;
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "SP_Select_Supmaster";
//            cmd.Parameters.AddWithValue("sup_id", clse_Supmaster.sup_id);
//            cmd.ExecuteNonQuery();
//            DA.SelectCommand = cmd;
//            DA.Fill(ds);
//            cn.Close();
//            return ds;
            
//        }

//// insert into unitmaster//////////////////////////////////////////////////////////////////////////////////////////////////
//        public void insertunitmaster(clse_unitmaster clse_unitmaster)
//        {
//            cn.Open();
//            cmd.Connection = cn;
//            cmd.Parameters.Clear();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "SP_UnitMaster";
//            cmd.Parameters.AddWithValue("@Action", "insert");
//            cmd.Parameters.AddWithValue("u_id", clse_unitmaster.u_id);
//            cmd.Parameters.AddWithValue("u_name", clse_unitmaster.u_name);
//            cmd.Parameters.AddWithValue("u_desc", clse_unitmaster.u_desc);
    
//            cmd.ExecuteNonQuery();
//            cn.Close();
//        }

//        public void updateunitmaster(clse_unitmaster clse_unitmaster)
//        {
//            cn.Open();
//             cmd.Connection = cn;
//            cmd.Parameters.Clear();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "SP_UnitMaster";
//            cmd.Parameters.AddWithValue("@Action", "update");
//            cmd.Parameters.AddWithValue("u_id", clse_unitmaster.u_id);
//            cmd.Parameters.AddWithValue("u_name", clse_unitmaster.u_name);
//            cmd.Parameters.AddWithValue("u_desc", clse_unitmaster.u_desc);

//            cmd.ExecuteNonQuery();
//            cn.Close();
//        }
//        public void deleteunitmaster(clse_unitmaster clse_unitmaster)
//        {
//            cn.Open();
//            cmd.Connection = cn;
//            cmd.Parameters.Clear();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "SP_UnitMaster";
//            cmd.Parameters.AddWithValue("@Action", "delete");
//            cmd.Parameters.AddWithValue("u_id", clse_unitmaster.u_id);
//            cmd.Parameters.AddWithValue("u_name", clse_unitmaster.u_name);
//            cmd.Parameters.AddWithValue("u_desc", clse_unitmaster.u_desc);

//            cmd.ExecuteNonQuery();
//            cn.Close();
//        }

//        public DataSet selectunit(clse_unitmaster clse_unitmaster)
//        {
//            cn.Open();
//            cmd.Connection = cn;
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "SP_Select_Unit";
//            cmd.Parameters.AddWithValue("u_id", clse_unitmaster.u_id);
//            cmd.ExecuteNonQuery();
//            DA.SelectCommand = cmd;
//            DA.Fill(ds);
//            cn.Close();
//            return ds;
           
//        }

        ///insert into  Custmaster////////////////////////////////////////////////////////////////////////////////////////////////
        ///

      //public  void insertcustmaster(clse_Cust_Master clse_Cust_Master)
      //  {
      //      try
      //      {
      //          cn.Open();
                
      //          cmd.Parameters.Clear();
      //          cmd.CommandType = CommandType.StoredProcedure;
      //          cmd.CommandText = "SP_CustMaster";
      //          cmd.Connection = cn;
      //          cmd.Parameters.AddWithValue("@Action", "insert");
      //          cmd.Parameters.AddWithValue("cust_id", clse_Cust_Master.cust_id);
      //          cmd.Parameters.AddWithValue("cust_name", clse_Cust_Master.cust_name);
      //          cmd.Parameters.AddWithValue("cust_mob", clse_Cust_Master.cust_mob);
      //          cmd.Parameters.AddWithValue("cust_contact", clse_Cust_Master.cust_contact);
      //          cmd.Parameters.AddWithValue("cust_address", clse_Cust_Master.cust_address);
      //          cmd.Parameters.AddWithValue("cust_dob", clse_Cust_Master.cust_dob);
      //          cmd.ExecuteNonQuery();
      //          cn.Close();
      //      }
      //      catch(Exception ex)
      //      {
      //      }
      //  }
      //public void updatecustmaster(clse_Cust_Master clse_Cust_Master)
      //  {
      //      cn.Open();
      //      cmd.Parameters.Clear();
      //      cmd.Connection = cn;
      //      cmd.CommandType = CommandType.StoredProcedure;
      //      cmd.CommandText = "SP_CustMaster";
 
      //      cmd.Parameters.AddWithValue("@Action", "update");
      //      cmd.Parameters.AddWithValue("cust_id", clse_Cust_Master.cust_id);
      //      cmd.Parameters.AddWithValue("cust_name", clse_Cust_Master.cust_name);
      //      cmd.Parameters.AddWithValue("cust_mob", clse_Cust_Master.cust_mob);
      //      cmd.Parameters.AddWithValue("cust_contact", clse_Cust_Master.cust_contact);
      //      cmd.Parameters.AddWithValue("cust_address", clse_Cust_Master.cust_address);
      //      cmd.Parameters.AddWithValue("cust_dob", clse_Cust_Master.cust_dob);
      //      cmd.ExecuteNonQuery();
      //      cn.Close();
      //  }
      //public void deletecustmaster(clse_Cust_Master clse_Cust_Master)
      //  {
      //      cn.Open();
        
      //      cmd.Parameters.Clear();
      //      cmd.CommandType = CommandType.StoredProcedure;
      //      cmd.CommandText = "SP_CustMaster";
      //      cmd.Connection = cn;
      //      cmd.Parameters.AddWithValue("@Action", "delete");
      //      cmd.Parameters.AddWithValue("cust_id", clse_Cust_Master.cust_id);
      //      cmd.Parameters.AddWithValue("cust_name", clse_Cust_Master.cust_name);
      //      cmd.Parameters.AddWithValue("cust_mob", clse_Cust_Master.cust_mob);
      //      cmd.Parameters.AddWithValue("cust_contact", clse_Cust_Master.cust_contact);
      //      cmd.Parameters.AddWithValue("cust_address", clse_Cust_Master.cust_address);
      //      cmd.Parameters.AddWithValue("cust_dob", clse_Cust_Master.cust_dob);
      //      cmd.ExecuteNonQuery();
      //      cn.Close();
      //  }
      //public DataSet selectcust(clse_Cust_Master clse_Cust_Master)
      //  {
      //      cn.Open();
      //      cmd.Connection = cn;
      //      cmd.CommandType = CommandType.StoredProcedure;
      //      cmd.CommandText = "SP_Select_CustMaster";
      //      cmd.Parameters.AddWithValue("cust_id", clse_Cust_Master.cust_id);
      //      cmd.ExecuteNonQuery();
      //      DA.SelectCommand = cmd;
      //      DA.Fill(ds);
      //      cn.Close();
      //      return ds;
           
      //  }
      //public DataSet seelcttype(clse_addtype clse_addtype)
      //{
      //    cn.Open();
      //    cmd.Connection = cn;
      //    cmd.CommandType = CommandType.StoredProcedure;
      //    cmd.CommandText = "Sp_select Type";
      //    cmd.Parameters.AddWithValue("id", clse_addtype.id);
      //    cmd.ExecuteNonQuery();
      //    DA.SelectCommand = cmd;
      //    DA.Fill(ds);
      //    cn.Close();
      //    return ds;
           
      //}
    }
    
    }
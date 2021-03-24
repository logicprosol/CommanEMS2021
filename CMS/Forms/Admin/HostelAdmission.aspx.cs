using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer;
using System.Configuration;
using System.Data.Common;
using Entity;
using dal;

namespace CMS.Forms.Admin
{
    public partial class HostelAdmission : System.Web.UI.Page
    {
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        DataSet ds = new DataSet();
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clear();
            }

                orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                if (!IsPostBack)
                { 
                    //Bind  hOSTEL Type
                    if (ddlHostel.Items.Count <= 1)
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_HostelAdmission";
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@OrgId", orgId);
                        cmd.Parameters.AddWithValue("@Action", "Select_HostelAdmission_PageLoad");
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        cn.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddlHostel.DataSource = ds.Tables[0];
                            ddlHostel.DataTextField = "Hostel_name";
                            ddlHostel.DataValueField = "Hostel_id";
                            ddlHostel.DataBind();

                        }
                        ddlHostel.Items.Insert(0, new ListItem("--Select Hostel--"));


                    }


            

                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvhostelInfo.DataSource = ds.Tables[1];// db.DisplaygridView("SELECT HostelAdmission.H_id as Id, tblStudent.FirstName,tblStudent.MiddleName, tblStudent.LastName, HostelAdmission.Hostel_Name, HostelAdmission.Hostel_Type,HostelAdmission.H_Room FROM HostelAdmission INNER JOIN tblStudent ON HostelAdmission.H_StudentUserId = tblStudent.UserCode where HostelAdmission.OrgId='" + orgId.ToString() + "' ");
                    gvhostelInfo.DataBind();
                }
            
         
            if (ds.Tables[2].Rows.Count > 0)
            {
               
                    ddlStudent.DataSource = ds.Tables[2];
                    ddlStudent.DataTextField = "Name";
                    ddlStudent.DataValueField = "UserCode";
                    ddlStudent.DataBind();
                    cn.Close();
            }
            ddlStudent.Items.Insert(0, new ListItem("--Select Student--"));



                    if (Request.QueryString["AdmissionId"] != null)
                    {
                        if (!IsPostBack)
                        {
                            
                            int AdmissionId = int.Parse(Request.QueryString["AdmissionId"].ToString());
                            ds = new DataSet();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_HostelAdmission";
                            cmd.Connection = cn;
                            cmd.Parameters.AddWithValue("@AdmissionId", AdmissionId);
                            cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                            cmd.Parameters.AddWithValue("@Action", "HostelAdmission_Details");
                            cn.Open();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);
                            cn.Close();


                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ddlHostel.SelectedValue = ds.Tables[0].Rows[0]["Hostel_Id"].ToString();
                                UpdateRoom();
                                ddlRoom.SelectedValue = ds.Tables[0].Rows[0]["RoomId"].ToString();
                                ddlStudent.SelectedValue = ds.Tables[0].Rows[0]["UserCode"].ToString();
                                txtFees.Text = ds.Tables[0].Rows[0]["H_fees"].ToString();
                                txtTotalFees.Text = ds.Tables[0].Rows[0]["Total_fees"].ToString();
                                hdbId.Value = (AdmissionId).ToString();
                            }
                            btnUpdate.Visible = true;
                            btnDelete.Visible = true;
                            btnSave.Visible = false;
                        }

                    }

                }
            }
        }

    //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        //FETCH DATA USING DROPDOWN
    //        SqlCommand cmd1 = new SqlCommand("select * from tblStudentFeesPaid  where StudentId='" + DropDownList2.SelectedItem + "' ORDER BY ReceiptNo DESC", cn);
    //        SqlDataAdapter adp1 = new SqlDataAdapter();
    //        DataSet ds1 = new DataSet();
    //        adp1.SelectCommand = cmd1;
    //        adp1.Fill(ds1);
    //        if (ds1.Tables[0].Rows[0]["PendingAmount"].ToString() != "0")
    //        {
    //            //TextBox4.Text = ds1.Tables[0].Rows[0]["PendingAmount"].ToString();
    //        }
    //        else
    //        {
    //           // TextBox4.Text = "0";
    //        }
    //    }
        //protected void GeneralErr(String msg)
        //{
            
        //    msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlHostel.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Select Hostel Name ')", true);
                }
                else
                { 
                DataSet dt = new DataSet();
              
                   
                    SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", ddlRoom.SelectedValue);
                    cmd.Parameters.AddWithValue("@HostelId", ddlHostel.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserCode", ddlStudent.SelectedValue);
                    cmd.Parameters.AddWithValue("@Fees", txtFees.Text);
                    cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                    cmd.Parameters.AddWithValue("@Action", "Insert_HostelAdmission");
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    cn.Close();

                    string msg = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gvhostelInfo.DataSource = ds.Tables[1];
                        gvhostelInfo.DataBind();
                        clear();
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;
                    }
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+msg+"')", true);
                           
                        
                  
                }
            }

            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

     

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            clear();
            
        }
      void clear()
        {
            ddlHostel.ClearSelection();
            txtFees.Text = "";
            ddlRoom.ClearSelection();
            ddlStudent.ClearSelection();
            txtTotalFees.Text = "";
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        
         public void UpdateRoom()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@HostelId", ddlHostel.SelectedValue);
               
                cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                
                cmd.Parameters.AddWithValue("@Action", "Select_Room");
                cn.Open();
                DataSet _ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(_ds);
                cn.Close();

                ddlRoom.DataSource = _ds;
                ddlRoom.DataTextField = "RoomName";
                ddlRoom.DataValueField = "RoomId";
                ddlRoom.DataBind();
                ddlRoom.Items.Insert(0, "Select");

            }
            catch (Exception ex) { }
        } 
       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlHostel.Text == "--Select Hostel--")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Please Select  Hostel ')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                       
                       SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoomID", ddlRoom.SelectedValue);
                        cmd.Parameters.AddWithValue("@HostelId", ddlHostel.SelectedValue);
                        cmd.Parameters.AddWithValue("@UserCode", ddlStudent.SelectedValue);
                        cmd.Parameters.AddWithValue("@Fees", txtFees.Text);
                        cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                        cmd.Parameters.AddWithValue("@AdmissionId", hdbId.Value);
                        cmd.Parameters.AddWithValue("@Action", "Update_HostelAdmission");
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        cn.Close();

                        string msg = ds.Tables[0].Rows[0][0].ToString();
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            gvhostelInfo.DataSource = ds.Tables[1];
                            gvhostelInfo.DataBind();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnSave.Visible = true;
                            clear();
                        }
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);

                      
                       
                    }
                }
            }

            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlHostel.Text == "--Select Hostel--")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Please Select  Hostel ')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                        cmd.Parameters.AddWithValue("@AdmissionId", hdbId.Value);
                        cmd.Parameters.AddWithValue("@Action", "Delete_HostelAdmission");
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        cn.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gvhostelInfo.DataSource = ds.Tables[0];
                            gvhostelInfo.DataBind();

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully')", true);
                            clear();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnSave.Visible = true;
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete')", true);
                        }
                    }
                }
            }

            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        protected void ddlHostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                cmd.Parameters.AddWithValue("@HostelId", ddlHostel.SelectedValue);
                cmd.Parameters.AddWithValue("@Action", "Select_Room_HostelChanged");
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cn.Close();

                ddlRoom.DataSource = ds.Tables[0];
                ddlRoom.DataTextField = "RoomName";
                ddlRoom.DataValueField = "RoomId";
                ddlRoom.DataBind();
                ddlRoom.Items.Insert(0, "Select");

                txtTotalFees.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            catch(Exception ex) { }
        }
    }
}
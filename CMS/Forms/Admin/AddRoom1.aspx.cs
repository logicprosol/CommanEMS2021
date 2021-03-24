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
    public partial class AddRoom1 : System.Web.UI.Page
    {
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        DataSet ds = new DataSet();
        database db = new database();
        clse_HostelRoom clse = new clse_HostelRoom();
        clsd clsd = new clsd();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CMSDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgID"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    hdnid.Value = orgId.ToString();
                    //Bind  Hostel NAME
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_HostelAdmission";
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("@OrgId", orgId);
                    cmd.Parameters.AddWithValue("@Action", "Select_HostelRoom_PageLoad");
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    cn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = ds.Tables[0];// db.Displaygrid("SELECT * FROM HostelRoom where OrgId='" + orgId.ToString() + "'");
                        GridView1.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ddlHostel.DataSource = ds.Tables[1];
                        ddlHostel.DataTextField = "Hostel_name";
                        ddlHostel.DataValueField = "Hostel_id";
                        ddlHostel.DataBind();

                    }

                    ddlHostel.Items.Insert(0, new ListItem("--Select Hostel--"));
                }

                if (Request.QueryString["RoomId"] != null)
                {
                    if (!IsPostBack)
                    {

                        int RoomId = int.Parse(Request.QueryString["RoomId"].ToString());
                        ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_HostelAdmission";
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@RoomID", RoomId);
                        cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"]));
                        cmd.Parameters.AddWithValue("@Action", "HostelRoom_Details");
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        cn.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddlHostel.SelectedValue = ds.Tables[0].Rows[0]["Hostel_id"].ToString();
                            txtHostelType.Text = ds.Tables[0].Rows[0]["Hostel_Types"].ToString();
                            txtRoom.Text = ds.Tables[0].Rows[0]["RoomName"].ToString();
                            txtStudentCount.Text = ds.Tables[0].Rows[0]["StudentCount"].ToString();
                            hdbId.Value = (RoomId).ToString();
                        }
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                    }



                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;

                }

            }
            ////Bind  hOSTEL Type
            //if (drpHostelType.Items.Count <= 1)
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT Distinct Hostel_Types FROM AddHostel  where OrgId='" + orgId.ToString() + "' "))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = cn;
            //        cn.Open();
            //        drpHostelType.DataSource = cmd.ExecuteReader();
            //        drpHostelType.DataTextField = "Hostel_Types";
            //        drpHostelType.DataValueField = "Hostel_Types";
            //        drpHostelType.DataBind();
            //        cn.Close();
            //    }

            //    drpHostelType.Items.Insert(0, new ListItem("--Select Type--"));
            //}
           
        }

        protected void ddlHostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //FETCH DATA USING DROPDOWN
                SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HostelId",Convert.ToInt32( ddlHostel.SelectedValue));
                cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"].ToString()));
                cmd.Parameters.AddWithValue("@Action", "Select_HostelType");
                SqlDataAdapter adp1 = new SqlDataAdapter();
                cn.Open();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd;
                adp1.Fill(ds1);
                cn.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                    txtHostelType.Text = ds1.Tables[0].Rows[0]["Hostel_Types"].ToString();
                else
                    txtHostelType.Text = "";
            }
            catch (Exception ex) { }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {

            if (ddlHostel.Text == "--Select Hostel--")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select  Hostel ')", true);
            }
            else
            {

               DataTable  dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_HostelAdmission";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@HostelId", ddlHostel.SelectedValue);
                cmd.Parameters.AddWithValue("@RoomName", txtRoom.Text);
                cmd.Parameters.AddWithValue("@OrgId",Session["OrgId"]);
                cmd.Parameters.AddWithValue("@StudentCount",txtStudentCount.Text);
                cmd.Parameters.AddWithValue("@Action", "Insert_HostelRoom");
                cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();

            //    db.cnopen();
            //db.insert("insert into HostelRoom (Host_name,Host_type,Host_room,OrgId,StudentCount,Status) " +
            //    "values ('" + ddlHostel.Text + "','" + TextBox1.Text + "','" + TextBox3.Text + "','" + orgId.ToString() + "'," + txtStudentCount.Text.Trim() +",'-' ) ");
            //db.cnclose();
            clear();
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;// db.Displaygrid("SELECT * FROM HostelRoom where OrgId='" + orgId.ToString() + "'");
                    GridView1.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted successfully')", true);
                }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record already exists')", true);
        }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
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

                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_HostelAdmission";
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@HostelId", ddlHostel.SelectedValue);
                        cmd.Parameters.AddWithValue("@RoomName", txtRoom.Text);
                        cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                        cmd.Parameters.AddWithValue("@StudentCount", txtStudentCount.Text);
                        cmd.Parameters.AddWithValue("@RoomId", hdbId.Value);
                        cmd.Parameters.AddWithValue("@Action", "Update_HostelRoom");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        string msg = ds.Tables[0].Rows[0][0].ToString();

                        
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                //db.cnopen();
                                //db.insert("update HostelRoom set  Host_name='" + ddlHostel.Text + "',Host_type='" + TextBox1.Text + "',Host_room='" + txtRoom.Text +"',StudentCount='" + txtStudentCount.Text +
                                //    "' where Host_id ='" + hdbId.Value + "'");
                                //db.cnclose();
                                GridView1.DataSource = ds.Tables[1];// db.Displaygrid("SELECT * FROM HostelRoom where OrgId='" + orgId.ToString() + "'");
                                GridView1.DataBind();
                                //gvhostel.DataSource = gvhostel;
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated successfully')", true);
                                clear();
                                btnUpdate.Visible = false;
                                btnDelete.Visible = false;
                                btnSave.Visible = true;
                            }
                            
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+msg+"')", true);
                            
                        


                    }
                }
            }

            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        public void clear()
        {
            ddlHostel.ClearSelection();
            txtHostelType.Text = "";
            txtRoom.Text = "";
            txtStudentCount.Text = "";
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
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
                        //   db.cnopen();
                        //float IsRoomInUse=db.getDb_Value("select count(*) from HostelAdmission inner join HostelRoom on HostelRoom.Host_room=H_Room where  Host_id ='" + hdbId.Value + "'");
                        //   db.cnclose();

                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_HostelAdmission";
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@RoomId", hdbId.Value);
                        cmd.Parameters.AddWithValue("@Action", "Delete_HostelRoom");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                //db.cnopen();
                                //db.insert("delete HostelRoom where  Host_id ='" + hdbId.Value + "'");
                                //db.cnclose();
                                GridView1.DataSource = ds.Tables[1];// db.Displaygrid("SELECT * FROM HostelRoom where OrgId='" + orgId.ToString() + "'");
                                GridView1.DataBind();
                            }
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully')", true);
                                clear();
                                btnUpdate.Visible = false;
                                btnDelete.Visible = false;
                                btnSave.Visible = true;
                                GridView1.DataSource = null;
                                GridView1.DataBind();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use')", true);
                        }
                    }
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
    }
}
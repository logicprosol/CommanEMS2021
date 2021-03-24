using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer;
using System.Data;
using Entity;
using dal;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Admin
{
    public partial class AddHostelRoom : System.Web.UI.Page
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        DataSet ds = new DataSet();
        database db = new database();
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        clse_hostel clse = new clse_hostel();
        clsd clsd = new clsd();
        //Objects

        protected void Page_Load(object sender, EventArgs e)
        {
       
                orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                else
                {
                    hdnid.Value = orgId.ToString();
                    gvhostel.DataBind();
                    if (Request.QueryString["Hostel_id"] != null)
                    {
                        if (!IsPostBack)
                        {

                            clse.Hostel_id = int.Parse(Request.QueryString["Hostel_id"].ToString());
                        clse.OrgId = int.Parse(Session["OrgId"].ToString());
                        ds = clsd.SELECTHOSTEL(clse);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                            

                                TextBox2.Text = ds.Tables[0].Rows[0]["Hostel_name"].ToString();
                                ddlHostel.Text = ds.Tables[0].Rows[0]["type"].ToString();
                                TextBox3.Text = ds.Tables[0].Rows[0]["Hostel_Address"].ToString();
                            txtFees.Text= ds.Tables[0].Rows[0]["Fees"].ToString();
                            hdbId.Value = (clse.Hostel_id).ToString();
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
                
        }

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {

                    //db.cnopen();
                    //db.insert("update AddHostel set  Hostel_name='" + TextBox2.Text + "',Hostel_Types='" + ddlHostel.Text + "',Hostel_Address='" + TextBox3.Text + "',OrgId='" + orgId.ToString() + "' where Hostel_id ='" + hdbId.Value + "'");
                    //db.cnclose();
                    //gvhostel.DataBind();
                    ////gvhostel.DataSource = gvhostel;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated successfully')", true);
                    //clear();
                    //btnUpdate.Visible = false;
                    //btnDelete.Visible = false;
                    //btnSave.Visible = true;
                    DataSet dt = new DataSet();

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("update AddHostel set Fees=@Fees, Hostel_name=@Hostel_name,Hostel_Types=@Hostel_Types,Hostel_Address=@Hostel_Address,OrgId=@OrgId where Hostel_id =@Hostel_id ", cn);
                    cmd.Parameters.AddWithValue("@Hostel_name", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Hostel_Types", ddlHostel.Text);
                    cmd.Parameters.AddWithValue("@Hostel_Address", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(orgId.ToString()));
                    cmd.Parameters.AddWithValue("@Hostel_id", Convert.ToInt32(hdbId.Value));
                    cmd.Parameters.AddWithValue("@Fees", Convert.ToDecimal(txtFees.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    
                        gvhostel.DataBind();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated successfully')", true);
                        clear();
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;
                    
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            try
            {
                DataSet dt = new DataSet();

                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into AddHostel(Hostel_name, Hostel_Types, Hostel_Address, OrgId,Fees) " +
                    "values(@Hostel_name, @Hostel_Types, @Hostel_Address, @OrgId,@Fees) ", cn);
                cmd.Parameters.AddWithValue("@Hostel_name", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Hostel_Types", ddlHostel.Text);
                cmd.Parameters.AddWithValue("@Hostel_Address", TextBox3.Text);
                cmd.Parameters.AddWithValue("@OrgId",Convert.ToInt32( orgId.ToString()));
                cmd.Parameters.AddWithValue("@Fees", Convert.ToInt32(txtFees.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
               
                    gvhostel.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted successfully')", true);
                    clear();
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                

                //else
                //{


                //db.cnopen();
                //        db.insert("insert into AddHostel (Hostel_name,Hostel_Types,Hostel_Address,OrgId) values ('" + TextBox2.Text + "','" + ddlHostel.Text + "','" + TextBox3.Text + "','" + orgId.ToString() + "') ");
                //        db.cnclose();
                //        gvhostel.DataBind();
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted successfully')", true);
                //        clear();
                //        btnUpdate.Visible = false;
                //        btnDelete.Visible = false;
                //        btnSave.Visible = true;

                        
                       

                }
         //   }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    db.cnopen();
                    float IsRoomInUse = db.getDb_Value("select count(*) from HostelRoom where Hostel_id ='" + hdbId.Value + "'");
                    db.cnclose();

                    if (IsRoomInUse == 0)
                    {
                        db.cnopen();
                        db.insert("delete AddHostel where  Hostel_id ='" + hdbId.Value + "'");
                        db.cnclose();
                        gvhostel.DataBind();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully')", true);
                        clear();
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use')", true);
                    }
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            clear();
        }

        void clear()
        {
            TextBox2.Text = "";
            ddlHostel.Text = "";
            TextBox3.Text = "";
            ddlHostel.ClearSelection();
            txtFees.Text = "";
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}

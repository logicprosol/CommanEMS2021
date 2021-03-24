using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Admin
{
    public partial class Experienced_Certificate : System.Web.UI.Page
    {
   
        public static int orgId;
        DataSet ds = new DataSet();
        database db = new database();
        Label bookid = new Label();
        Label studid = new Label();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
         float count = db.getDb_Value("select count(exp_id) from  tblExperienceLetter   where OrgId='" + orgId.ToString() + "'and UserCode='" + txtEmployeeId.Text + "'");
         int a = Convert.ToInt32(count);
         if (a!=0)
         {
             SqlCommand cmd2 = new SqlCommand("SELECT exp_name, exp_dateofjoining,application_date,exp_designation FROM tblExperienceLetter where OrgId='" + orgId.ToString() + "'and UserCode='" + txtEmployeeId.Text + "'", cn);
             SqlDataAdapter adp2 = new SqlDataAdapter();
             DataSet ds2 = new DataSet();
             adp2.SelectCommand = cmd2;
             adp2.Fill(ds2);
             txtEmployeeName.Text = ds2.Tables[0].Rows[0]["exp_name"].ToString();
             
             string applicationdate = ds2.Tables[0].Rows[0]["application_date"].ToString();
             txtTodayDate.Text = (applicationdate.ToString());

             ddlProgress0.Text = ds2.Tables[0].Rows[0]["exp_designation"].ToString();

             string joiningdate = ds2.Tables[0].Rows[0]["exp_dateofjoining"].ToString();
             txtDOB.Text = (joiningdate.ToString());

             btnSave.Enabled = false;
             btnPrint.Enabled = true;
      
         }
         else
         {
             txtEmployeeId.Focus();
             //panDetails.Visible = true;
             btnUpdate.Enabled = false;
             btnPrint.Enabled = false;
             try
             {
                 //FETCH DATA 
                 if (txtEmployeeId.Text != null)
                 {
                     SqlCommand cmd1 = new SqlCommand("SELECT FirstName + ' ' + MiddleName + ' ' + LastName StdName, DateOfJoining FROM tblEmployee where OrgId='" + orgId.ToString() + "'and UserCode='" + txtEmployeeId.Text + "'", cn);
                     SqlDataAdapter adp1 = new SqlDataAdapter();
                     DataSet ds1 = new DataSet();
                     adp1.SelectCommand = cmd1;
                     adp1.Fill(ds1);

                        if (ds1.Tables[0].Rows.Count >0)
                        {

                            panDetails.Visible = true;
                            txtEmployeeName.Text = ds1.Tables[0].Rows[0]["StdName"].ToString();

                            string joiningdate = ds1.Tables[0].Rows[0]["DateOfJoining"].ToString();
                            txtDOB.Text = Convert.ToDateTime(joiningdate.ToString()).ToShortDateString();
                        }
                        else
                        {
                            panDetails.Visible = false;
                            msgBox.ShowMessage("Please Check Employee Id..!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }

                 }
                 //  bookid.Text = ds1.Tables[0].Rows[0]["BookId"].ToString();
             }
             catch (Exception ex)
             {
                 msgBox.ShowMessage("Record Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
             }
         }
        }

        protected void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {
            txtEmployeeId.Focus();
            panDetails.Visible = true;
            btnUpdate.Enabled = false;
            btnPrint.Enabled = false;
            try
            {

                //FETCH DATA 
                if (txtEmployeeId.Text != null)
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT FirstName + ' ' + MiddleName + ' ' + LastName StdName, DateOfJoining FROM tblEmployee where OrgId='" + orgId.ToString() + "'and UserCode='" + txtEmployeeId.Text + "'", cn);
                    SqlDataAdapter adp1 = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();
                    adp1.SelectCommand = cmd1;
                    adp1.Fill(ds1);
                    txtEmployeeName.Text = ds1.Tables[0].Rows[0]["StdName"].ToString();

                    string joiningdate = ds1.Tables[0].Rows[0]["DateOfJoining"].ToString();
                    txtDOB.Text = Convert.ToDateTime(joiningdate.ToString()).ToShortDateString();

                  
                }
                //  bookid.Text = ds1.Tables[0].Rows[0]["BookId"].ToString();
            }
            catch (Exception ex)
            {
                msgBox.ShowMessage("Record Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlProgress0.Text.ToString() != "Select")
            {

                db.cnopen();
                db.insert("insert into tblExperienceLetter values('" + txtTodayDate.Text + "','" + txtEmployeeName.Text + "','" + ddlProgress0.Text + "','" + txtDOB.Text + "','" + orgId.ToString() + "','" + txtEmployeeId.Text + "')");
                db.cnclose();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Saved Successfully')", true);
                clear();
                btnPrint.Enabled = true;
                ddlProgress0.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Plase Select  Designation')", true);
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PnlStudentLeavingCertificate.Visible = true;
                panDetails.Visible = false;

                SqlCommand cmd1 = new SqlCommand("SELECT Address, Logo,OrgName FROM tblOrganization where OrganizationId='" + orgId.ToString() + "'", cn);
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);
                lblCollageFullName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
                lblAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                string logo= ds1.Tables[0].Rows[0]["Logo"].ToString();
                if (logo != null && logo != "")
                {
                    Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Logo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgClgLogo.ImageUrl = "data:image/png;base64," + base64String;
                }

                SqlCommand cmd2 = new SqlCommand("SELECT exp_name, exp_dateofjoining,application_date,exp_designation FROM tblExperienceLetter where OrgId='" + orgId.ToString() + "'and UserCode='" + txtEmployeeId.Text + "'", cn);
                SqlDataAdapter adp2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                adp2.SelectCommand = cmd2;
                adp2.Fill(ds2);
                lblname.Text = ds2.Tables[0].Rows[0]["exp_name"].ToString();
                lblorganisation.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
                
                string joinmingdate = ds2.Tables[0].Rows[0]["exp_dateofjoining"].ToString();
                //Remove Time only show date..
                lblJoiningDate.Text = Convert.ToDateTime(joinmingdate.ToString()).ToShortDateString();

                string applicationdate = ds2.Tables[0].Rows[0]["application_date"].ToString();
                //lblApplDate.Text = Convert.ToDateTime(applicationdate.ToString()).ToShortDateString();
                lblApplDate.Text = (applicationdate.ToString());

                LblDesignation.Text = ds2.Tables[0].Rows[0]["exp_designation"].ToString();
                lblTodayDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                lblCollageName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
               // GetStudentRecordPrint(Convert.ToInt64(txtStudentId.Text));
                btnPrintLC.Visible = true;
                panPrint.Visible = true;
            }
            catch (Exception exp)
            {
            //    GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            txtTodayDate.Text = "";
            txtEmployeeName.Text = "";
            ddlProgress0.SelectedIndex  = 0;
            txtDOB.Text = "";
        }

        protected void chkDuplicateCopy_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
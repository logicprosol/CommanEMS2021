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

namespace CMS.Forms.HR
{
    public partial class Bonafied : System.Web.UI.Page
    {
        public static int orgId=0;
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
             txtStudentId.Focus();
             panDetails.Visible = true;
             btnSave.Enabled = true;
             btnClear.Enabled = true;
             btnPrint.Enabled = false;
             try
             {
                 //FETCH DATA 
                 if (txtStudentId.Text != null)
                 {
                     SqlCommand cmd1 = new SqlCommand("SELECT FirstName + ' ' + MiddleName + ' ' + LastName StdName, AdmissionDate FROM tblStudent where OrgId='" + orgId.ToString() + "'and UserCode='" + txtStudentId.Text + "'", cn);
                     SqlDataAdapter adp1 = new SqlDataAdapter();
                     DataSet ds1 = new DataSet();
                     adp1.SelectCommand = cmd1;
                     adp1.Fill(ds1);
                     txtStudentName.Text = ds1.Tables[0].Rows[0]["StdName"].ToString();

                     string admissionDate = ds1.Tables[0].Rows[0]["AdmissionDate"].ToString();
                     txtDateOfAdmission0.Text = Convert.ToDateTime(admissionDate.ToString()).ToShortDateString();


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
            string date = Convert.ToDateTime(txtDateOfAdmission0.Text).ToString("dd/MM/yyyy");
            db.cnopen();
            db.insert("insert into tblBonafied values('" + txtStudentId.Text + "','" + orgId.ToString() + "','" + txtTodayDate.Text + "','" + txtStudentName.Text + "','" + date.ToString()+ "','" + ddlBehaviour0.Text + "','" + txtReaseon0.Text + "')");
            db.cnclose();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Saved Successfully')", true);
           
            btnPrint.Enabled = true;
            btnSave.Enabled = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
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
                string logo = ds1.Tables[0].Rows[0]["Logo"].ToString();
                if (logo != null && logo != "")
                {
                    Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Logo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgClgLogo.ImageUrl = "data:image/png;base64," + base64String;
                }

                SqlCommand cmd2 = new SqlCommand("SELECT stud_name, AdmissionDate,Application_date FROM tblBonafied where OrgId='" + orgId.ToString() + "'and UserCode='" + txtStudentId.Text + "'", cn);
                SqlDataAdapter adp2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                adp2.SelectCommand = cmd2;
                adp2.Fill(ds2);
                lblname.Text = ds2.Tables[0].Rows[0]["stud_name"].ToString();
                lblorganisation.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
                lblAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
               // string AdmissionDate = ds2.Tables[0].Rows[0]["AdmissionDate"].ToString();
                ////Remove Time only show date..
                lblAdmissionDate.Text = txtDateOfAdmission0.Text;

                //string applicationdate = ds2.Tables[0].Rows[0]["Application_date"].ToString();
                //lblApplDate.Text = Convert.ToDateTime(applicationdate.ToString()).ToShortDateString();

                //lblbehaviour.Text = ds2.Tables[0].Rows[0]["behaviour"].ToString();
                lblTodayDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                lblCollageName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
                //GetStudentRecordPrint(Convert.ToInt64(txtStudentId.Text));
                btnPrintLC.Visible = true;
                panPrint.Visible = true;
            }
            catch (Exception exp)
            {
                //    GeneralErr(exp.Message.ToString());
            }
        }

        public void clear()
        {
            txtTodayDate.Text = "";
            txtStudentName.Text = "";
            txtDateOfAdmission0.Text = "";
            ddlBehaviour0.ClearSelection();
            txtReaseon0.Text="";
        }

        protected void btnPrintLC_Click(object sender, EventArgs e)
        {
      
           
        }
    }
}
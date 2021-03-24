using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class backdatedlc : System.Web.UI.Page
    {
        database db = new database();
        string orgid;
        public static int orgId;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
                orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

            orgid = Session["OrgId"].ToString();
              if (!Page.IsPostBack)
              {
                float maxid = db.getDb_Value("select applicationid from  tblbackdatedlc where OrgId='" + orgid + "' ");
                maxid++;
                txtusercode.Text = orgid + "/" + "00" + maxid.ToString();


             


                

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            db.cnopen();
            db.insert("insert into tblbackdatedlc values('" + txtStudentName.Text + "' ,'" + txtStudentCaste.Text + "','" + txtNationality.Text + "','" + txtBirthPlace.Text + "','" + Convert.ToDateTime(txtDOB.Text) + "','" + txtLastSchoolAttended.Text + "','" + Convert.ToDateTime(txtDateOfAdmission.Text) + "','" + ddlProgress.Text + "','" + ddlBehaviour.Text + "','" + Convert.ToDateTime(txtDateOfLeaving.Text) + "','" + Convert.ToDateTime(txtYearOfStudying.Text) + "','" + txtReaseon.Text + "','" + txtRemarks.Text + "','" + Convert.ToDateTime(txtTodayDate.Text) + "','" + Session["OrgId"].ToString() + "','" + txtusercode.Text + "')");
            db.cnclose();

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            btnUpdate.Enabled = true;
            txtStudentName.ReadOnly = false;
            txtStudentCaste.ReadOnly = false;
            txtNationality.ReadOnly = false;
            txtBirthPlace.ReadOnly = false;
            txtDOB.ReadOnly = false;
            txtLastSchoolAttended.ReadOnly = false;
            txtDateOfAdmission.ReadOnly = false;
            txtYearOfStudying.ReadOnly = false;
            btnPrint.Enabled = true;
            //panDetails.Visible = true;

            SqlCommand cmd1 = new SqlCommand(" SELECT * from tblbackdatedlc   where  Usercode= '" + txtStudentId.Text + "' ", cn);

            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataSet dsUpdate = new DataSet();
            adp1.SelectCommand = cmd1;
            adp1.Fill(dsUpdate);
            if (dsUpdate.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = dsUpdate.Tables[0].Rows[0]["StudentName"].ToString();
                txtStudentName.Text = dsUpdate.Tables[0].Rows[0]["StudentName"].ToString();
                txtStudentCaste.Text = dsUpdate.Tables[0].Rows[0]["Caste"].ToString();
                txtNationality.Text = dsUpdate.Tables[0].Rows[0]["Nationality"].ToString();
                txtBirthPlace.Text = dsUpdate.Tables[0].Rows[0]["BirthPlace"].ToString();
                txtDOB.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                txtLastSchoolAttended.Text = dsUpdate.Tables[0].Rows[0]["LastSchoolAttended"].ToString();
                txtDateOfAdmission.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DateOfAdmission"].ToString()).ToString("dd/MM/yyyy");
                txtYearOfStudying.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");

                txtTodayDate.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                txtDateOfLeaving.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DateOfLeaving"].ToString()).ToString("dd/MM/yyyy");
                ddlProgress.Items.FindByText(dsUpdate.Tables[0].Rows[0]["Progress"].ToString()).Selected = true;


                ddlBehaviour.Items.FindByText(dsUpdate.Tables[0].Rows[0]["Behaviour"].ToString()).Selected = true; txtReaseon.Text = dsUpdate.Tables[0].Rows[0]["Reaseon"].ToString();
                txtRemarks.Text = dsUpdate.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }

        protected void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            btnUpdate.Enabled = true;
            txtStudentName.ReadOnly = false;
            txtStudentCaste.ReadOnly = false;
            txtNationality.ReadOnly = false;
            txtBirthPlace.ReadOnly = false;
            txtDOB.ReadOnly = false;
            txtLastSchoolAttended.ReadOnly = false;
            txtDateOfAdmission.ReadOnly = false;
            txtYearOfStudying.ReadOnly = false;
            btnPrint.Enabled = true;
            //panDetails.Visible = true;

            SqlCommand cmd1 = new SqlCommand(" SELECT * from tblbackdatedlc   where  Usercode= '" + txtStudentId.Text + "' ", cn);

            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataSet dsUpdate = new DataSet();
            adp1.SelectCommand = cmd1;
            adp1.Fill(dsUpdate);
            if (dsUpdate.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = dsUpdate.Tables[0].Rows[0]["StudentName"].ToString();
                txtStudentName.Text = dsUpdate.Tables[0].Rows[0]["StudentName"].ToString();
                txtStudentCaste.Text = dsUpdate.Tables[0].Rows[0]["Caste"].ToString();
                txtNationality.Text = dsUpdate.Tables[0].Rows[0]["Nationality"].ToString();
                txtBirthPlace.Text = dsUpdate.Tables[0].Rows[0]["BirthPlace"].ToString();
                txtDOB.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                txtLastSchoolAttended.Text = dsUpdate.Tables[0].Rows[0]["LastSchoolAttended"].ToString();
                txtDateOfAdmission.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DateOfAdmission"].ToString()).ToString("dd/MM/yyyy");
                txtYearOfStudying.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");

                txtTodayDate.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                txtDateOfLeaving.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DateOfLeaving"].ToString()).ToString("dd/MM/yyyy");
                ddlProgress.Items.FindByText(dsUpdate.Tables[0].Rows[0]["Progress"].ToString()).Selected = true;


                ddlBehaviour.Items.FindByText(dsUpdate.Tables[0].Rows[0]["Behaviour"].ToString()).Selected = true; txtReaseon.Text = dsUpdate.Tables[0].Rows[0]["Reaseon"].ToString();
                txtRemarks.Text = dsUpdate.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
        
    }
    }

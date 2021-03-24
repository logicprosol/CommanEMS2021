using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Student
{
    public partial class StudentPlacementReg : System.Web.UI.Page
    {
        public static int orgId=0;
        DataSet ds = new DataSet();
        database db = new database();
        Label bookid = new Label();
        Label studid = new Label();
        float count = 0;
        string status = "";
        static float a, b;

        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }

            if(!IsPostBack)
            {
                txtUserCode.Text = Session["UserCode"].ToString();
                fatchdetails();
            }
        }

        protected void fatchdetails()
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT        FirstName + ' ' + MiddleName + ' ' + LastName AS FirstName, Address1 as Address, Mobile, EMail, MiddleName  FROM            tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "'", cn);
                        SqlDataAdapter adp1 = new SqlDataAdapter();
                        DataSet ds1 = new DataSet();
                        adp1.SelectCommand = cmd1;
                        adp1.Fill(ds1);
                        txtStudentName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString();
                        txtAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        txtMobile.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();
                        txtEmail.Text = ds1.Tables[0].Rows[0]["EMail"].ToString();
                        a = db.getDb_Value("select CourseId from tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "'");
                        txtCourseName.Text = db.getDbstatus_Value("select  CourseName from  tblCourse where  CourseId='" + a.ToString() + "' and OrgId='" + orgId.ToString() + "'");
                        b = db.getDb_Value("select BranchId from tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "'");
                        txtBranchName.Text = db.getDbstatus_Value("select  BranchName from  tblBranch where  BranchId='" + b.ToString() + "'and  CourseId='" + a.ToString() + "'");

                count = db.getDb_Value("SELECT COUNT(UserCode) FROM Placement_Registration where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "'");
                if (count == 0)
                {

                    //txtUserCode.Focus();



                    //FETCH DATA 
                    if (txtUserCode.Text != null)
                    {
                       
                       
                        //if (ddlcompanyName.Items.Count <= 1)
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT Company_Name FROM tblCompanyPlacementMaster  where OrgId='" + orgId.ToString() + "' "))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = cn;
                                cn.Open();
                                ddlcompanyName.DataSource = cmd.ExecuteReader();
                                ddlcompanyName.DataTextField = "Company_Name";
                                ddlcompanyName.DataValueField = "Company_Name";
                                ddlcompanyName.DataBind();
                                cn.Close();
                            }

                            ddlcompanyName.Items.Insert(0, new ListItem("--Select Company--", "0"));
                        }
                    }
                }

                //   status = db.getDbstatus_Value("select Status from tblPlacementConfirmed where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCod.Text + "'");


                else
                {

                    status = db.getDbstatus_Value("select Status from Placement_Registration where  OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "' ");
                    if (status.ToString() == "Offered & Joined" || status.ToString() == " Offered")
                    {
                        msgBox.ShowMessage("Sorry.You Are Already Selected In Good Company !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        msgBox.ShowMessage("Sorry.You Are Already Registerd !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //msgBox.ShowMessage("Record Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
            }
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            db.cnopen();
            string AcademicYearId1 = db.getDbstatus_Value("  SELECT AcademicYearId FROM tblAcademicYear WHERE IsCurrentYear=1 AND OrgId='" + orgId.ToString() + "'");
            int AcademicYearId = Convert.ToInt32(AcademicYearId1);
            db.cnclose();
            db.cnopen();
            db.insert("insert into Placement_Registration (UserCode,FirstName,CourseId,BranchId,Address,Mobile,pemail,Company_Name,Company_Address,Position,OrgId,Status,AcademicYearId) " +
                "values ('" + txtUserCode.Text + "','" + txtStudentName.Text + "','" + a.ToString() + "','" + b.ToString() + "','" + txtAddress.Text + "'," +
                "'" + txtMobile.Text + "','" + txtEmail.Text + "','" + ddlcompanyName.Text + "','" + txtCompanyAddress.Text + "','_','" + orgId.ToString() + "','" + "UnPlaced" + "','" + AcademicYearId + "') ");
            db.cnclose();
            msgBox.ShowMessage("Congrats, Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
            clear();
        }

        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void ddlcompanyName_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //txtCompanyAddress.Text = db.getDbstatus_Value("select Company_Address from tblCompanyPlacementMaster where OrgId='" + orgId.ToString() + "' and Company_Name='" + ddlcompanyName.Text + "'");
            DataTable ddt=db.DbCon("Select * from  tblCompanyPlacementMaster where OrgId='" + orgId.ToString() + "' and Company_Name='" + ddlcompanyName.Text + "'");
            txtCompanyAddress.Text = ddt.Rows[0]["Company_Address"].ToString();
            txtWebsite.Text= ddt.Rows[0]["Website"].ToString();
            txtCompanyEmail.Text = ddt.Rows[0]["Company_email"].ToString();
            txtCompanyMobile.Text = ddt.Rows[0]["Company_mob"].ToString();
            txtContactPerson.Text = ddt.Rows[0]["Contact_Person"].ToString();
            txtCriteria.Text = ddt.Rows[0]["Criteria"].ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            //txtUserCode.Text = "";
            //txtStudentName.Text = "";
            txtCriteria.Text = "";
            //txtMobile.Text = "";
            //txtEmail.Text = "";
            //txtCourseName.Text = "";
            txtCompanyAddress.Text = "";
            //txtBranchName.Text = "";
            //txtAddress.Text = "";
            ddlcompanyName.SelectedIndex = 0;
            txtWebsite.Text = "";
            txtCompanyEmail.Text = "";
            txtCompanyMobile.Text = "";
            txtContactPerson.Text = "";
         
        }
       
    }
}
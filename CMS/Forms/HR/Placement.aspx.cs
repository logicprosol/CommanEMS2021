using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Mail;

namespace CMS.Forms.HR
{
    public partial class Placement : System.Web.UI.Page
    {
        public static int orgId=0;
        DataSet ds = new DataSet();
        database db = new database();
        Label bookid = new Label();
        Label studid = new Label();
        float a,b;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
       
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            if (!IsPostBack)
            {
                BindUserCode();
            }
        }

        public void BindUserCode()
        {
            string status = "UnPlaced";
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Placement_Registration where OrgId='" + orgId.ToString() + "'and Status='" + status + "'", cn);
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            DDUserCode.DataSource = ds1;
            DDUserCode.DataTextField = "UserCode";
            DDUserCode.DataValueField = "UserCode";
            DDUserCode.DataBind();
            DDUserCode.Items.Insert(0, new ListItem("--Select UserCode--", "0"));
        }

        //protected void txtUserCode_TextChanged(object sender, EventArgs e)
        //{
        //    txtUserCode.Focus();

        //    try
        //    {

        //        //FETCH DATA 
        //        if (txtUserCode.Text != null)
        //        {
        //            SqlCommand cmd1 = new SqlCommand("SELECT FirstName, Address,Mobile,pemail,Company_Name,Company_Address,Position FROM Placement_Registration where OrgId='" + orgId.ToString() + "'and UserCode='" + txtUserCode.Text + "'", cn);
        //            SqlDataAdapter adp1 = new SqlDataAdapter();
        //            DataSet ds1 = new DataSet();
        //            adp1.SelectCommand = cmd1;
        //            adp1.Fill(ds1);
        //            txtStudentName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString();
        //            txtAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
        //            txtMobile.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();
        //            txtEmail.Text = ds1.Tables[0].Rows[0]["pemail"].ToString();
        //            txtCompanyName.Text = ds1.Tables[0].Rows[0]["Company_Name"].ToString();
        //            txtCompanyAddress.Text = ds1.Tables[0].Rows[0]["Company_Address"].ToString();
        //            txtposition.Text = ds1.Tables[0].Rows[0]["Position"].ToString();
        //            a = db.getDb_Value("select CourseId from tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "'");
        //            txtCourseName.Text = db.getDbstatus_Value("select  CourseName from  tblCourse where  CourseId='" + a.ToString() + "' and OrgId='" + orgId.ToString() + "'");
        //            b = db.getDb_Value("select BranchId from tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + txtUserCode.Text + "'");
        //            txtBranchName.Text = db.getDbstatus_Value("select  BranchName from  tblBranch where  BranchId='" + b.ToString() + "'and  CourseId='" + a.ToString() + "'");


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgBox.ShowMessage("Record Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
        //    }
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCompanyAddress.Text = db.getDbstatus_Value("select Company_Address from tblCompanyPlacementMaster where OrgId='" + orgId.ToString() + "' and Company_Name='" + txtCompanyName.Text + "'");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            db.cnopen();
            string AcademicYearId1 = db.getDbstatus_Value("  SELECT AcademicYearId FROM tblAcademicYear WHERE IsCurrentYear=1 AND OrgId='" + orgId.ToString() + "'");
            int AcademicYearId = Convert.ToInt32(AcademicYearId1);
            db.cnclose();
            db.cnopen();
            db.insert("insert into tblPlacementConfirmed (UserCode,FirstName,CourseId,BranchId,Address,Mobile,pemail,Company_Name,Company_Address,Position,Package,OrgId,Status,AcademicYearId) values ('" + DDUserCode.SelectedValue + "','" + txtStudentName.Text + "','" + a.ToString() + "','" + b.ToString() + "','" + txtAddress.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "','" + txtCompanyName.Text + "','" + txtCompanyAddress.Text + "','" + txtposition.Text + "','" + txtPackage.Text + "','" + orgId.ToString() + "','"+rdoPlacementStatus.Text+"','" + AcademicYearId + "') ");
            db.cnclose();
            msgBox.ShowMessage("Congrats, Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);

            db.cnopen();
            if (rdoPlacementStatus.SelectedValue == "Offered")
            {
                db.insert("update Placement_Registration set Status='" +" Offered"+ "',Position='" + txtposition.Text + "' where OrgId='" + orgId.ToString() + "'and UserCode='" + DDUserCode.SelectedValue + "' ");
                string status = "Offered";
                SendEmails(status);
            }
            else
            {
                db.insert("update Placement_Registration set Status='" + "Offered & Joined"+ "',Position='" + txtposition.Text + "' where OrgId='" + orgId.ToString() + "'and UserCode='" + DDUserCode.SelectedValue + "' ");
                string status = "Offered & Joined";
                SendEmails(status);
            }
            ClearData();
            db.cnclose();
            //clear();
         }

        protected void DDUserCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDUserCode.Focus();

            try
            {

                //FETCH DATA 
                if (DDUserCode.SelectedValue != "0")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT FirstName, Address,Mobile,pemail,Company_Name,Company_Address,Position FROM Placement_Registration where OrgId='" + orgId.ToString() + "'and UserCode='" + DDUserCode.SelectedValue + "'", cn);
                    SqlDataAdapter adp1 = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();
                    adp1.SelectCommand = cmd1;
                    adp1.Fill(ds1);
                    txtStudentName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString();
                    txtAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                    txtMobile.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();
                    txtEmail.Text = ds1.Tables[0].Rows[0]["pemail"].ToString();
                    txtCompanyName.Text = ds1.Tables[0].Rows[0]["Company_Name"].ToString();
                    txtCompanyAddress.Text = ds1.Tables[0].Rows[0]["Company_Address"].ToString();
                   // txtposition.Text = ds1.Tables[0].Rows[0]["Position"].ToString();
                    a = db.getDb_Value("select CourseId from tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + DDUserCode.SelectedValue + "'");
                    txtCourseName.Text = db.getDbstatus_Value("select  CourseName from  tblCourse where  CourseId='" + a.ToString() + "' and OrgId='" + orgId.ToString() + "'");
                    b = db.getDb_Value("select BranchId from tblStudent where OrgId='" + orgId.ToString() + "' and UserCode='" + DDUserCode.SelectedValue + "'");
                    txtBranchName.Text = db.getDbstatus_Value("select  BranchName from  tblBranch where  BranchId='" + b.ToString() + "'and  CourseId='" + a.ToString() + "'");


                }
                else
                {
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                msgBox.ShowMessage("Record Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
            }
        }

        public void ClearData()
        {
            BindUserCode();
            txtStudentName.Text = "";
            txtCourseName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtBranchName.Text = "";
            txtMobile.Text = "";
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtposition.Text = "";
            txtPackage.Text = "";
            rdoPlacementStatus.SelectedIndex = -1;

        }

        #region SendeMailRegion

        private string SendEmails(string status)
        {
            string stringResult = null;
            //string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
            //string password = Convert.ToString("logicpro@2017");
            string mailFrom = WebConfigurationManager.AppSettings["mail"];
            string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(txtEmail.Text);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Confirm Placement";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "Dear \n" + txtStudentName.Text + "\n Congratulations on your '"+ status + "' from '"+ txtCompanyName.Text  + "'! We are delighted to offer you the position of '"+ txtposition.Text + "'. \n\nIf you choose to accept this offer, please Meet Your HR.";// "Thanks for visiting our Hotel...Come again And Enjoy Your Service : \n\n    Your Total Reward Points Are :" + txtTotalReward.Text + " \n\n Thanks And Regards,\n\n " + companyNm+ "";

            //email.Body = "Dear " + txtFirstName.Text + "  " + txtLastName.Text + " Your Registration Submitted Successfully .  Please Note Down Your Login Details UserName : " + txtUserName.Text + " Password : " + txtPassword.Text.Trim() + " Thank You For Registraion !!";
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);//Add the Creddentials- use your own email id and password
            Smtp.Port = 587;   // Gmail works on this port
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
            try
            {
                Smtp.Send(email);
                stringResult = "Email has been sent successfully...";
            }
            catch (Exception ex)
            {
                stringResult = ex.Message;
            }
            finally
            {
                
            }
            return stringResult;
        }

        #endregion


        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
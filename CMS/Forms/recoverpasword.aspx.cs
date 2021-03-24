using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer;
using EntityWebApp;
using System.Net.Mail;
using System.Windows.Forms;
using System.Web.Configuration;
using System.Configuration;

namespace Forms
{
    public partial class recoverpasword : System.Web.UI.Page
    {
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddCollegeToDropDown();
            }
        }
        private void AddCollegeToDropDown()
        {

            try
            {
                if (ddlorg.Items.Count <= 0)
                {
                    EWA_SuperAdmin clas1 = new EWA_SuperAdmin();
                    BL_SuperAdmin bcls = new BL_SuperAdmin();

                    DataSet ds = bcls.AddCollegeToDropDown();

                    ddlorg.DataTextField = "OrgLabel";
                    ddlorg.DataValueField = "OrganizationId";
                    ddlorg.DataSource = ds;
                    ddlorg.DataBind();
                    ddlorg.Items.Insert(0, "Select Organisation");
                }
            }
           catch(Exception ex)
            {
           }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string password = db.getDbstatus_Value("select  Password from tblUser where UserName='" + txtusername.Text + "' and  OrgId='" + ddlorg.SelectedValue + "'");
            string usercode = (db.getDb_Value("select UserCode from tblUser where UserName='" + txtusername.Text + "' and  OrgId='" + ddlorg.SelectedValue + "'")).ToString();
            if (DropDownList1.Text == "Student")
            {







                SqlCommand cmd1 = new SqlCommand(" select FirstName,EMail from tblStudent where UserCode='" + txtusername.Text + "' ", cn);
                //SqlCommand cmd1 = new SqlCommand("SELECT  tblLibAddBook.BookName, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblStudent.FirstName, tblLibAddGroup.GroupName FROM            tblLibAddBook INNER JOIN                          tblLibIssueBook ON tblLibAddBook.BookId = tblLibIssueBook.BookId INNER JOIN                          tblLibAddGroup ON tblLibAddBook.GroupId = tblLibAddGroup.GroupId AND tblLibIssueBook.GroupId = tblLibAddGroup.GroupId INNER JOIN                          tblStudent ON tblLibIssueBook.StudentId = tblStudent.StudentId WHERE        (tblLibIssueBook.StudentId = '" + id.ToString()+ "') ", cn);
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    string emailid = ds1.Tables[0].Rows[0]["EMail"].ToString();
                    string fname = ds1.Tables[0].Rows[0]["FirstName"].ToString();
                    //  string emailid = db.getDbstatus_Value("select EMail from tblStudent where UserCode='" + usercode + "'  ");
                    //  string fname = db.getDbstatus_Value("select FirstName from tblStudent where UserCode='" + usercode + "'  ");


                    string stringResult = null;
                    //string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
                    //string password1 = Convert.ToString("logicpro@2017");
                    string mailFrom = WebConfigurationManager.AppSettings["mail"];
                    string password1 = WebConfigurationManager.AppSettings["password"];
                    //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

                    string mailTo = Convert.ToString(emailid.ToString());

                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                    email.To.Add(new System.Net.Mail.MailAddress(mailTo));
                    email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solution ERP", System.Text.Encoding.UTF8);

                    email.Subject = "Password Recoverd";
                    email.SubjectEncoding = System.Text.Encoding.UTF8;

                    email.Body = "Dear  " + fname + "  Your Password Is " + password.ToString() + "";
                    email.BodyEncoding = System.Text.Encoding.UTF8;
                    email.Priority = System.Net.Mail.MailPriority.High;
                    password = System.Drawing.Color.Red.ToString();
                    password = System.Drawing.Brushes.Aqua.ToString();
                    password = System.Drawing.FontStyle.Bold.ToString();
                    System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
                    Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password1);//Add the Creddentials- use your own email id and password
                    Smtp.Port = 587;   // Gmail works on this port
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
                    try
                    {
                        Smtp.Send(email);
                        msgBox.ShowMessage("Password has been sent  on register mail id    !!!", "Send Msg", CMS.UserControls.MessageBox.MessageStyle.Successfull);

                    }
                    catch (Exception ex)
                    {
                        stringResult = ex.Message;
                    }
                    finally
                    {
                        //  Response.Redirect("~/CMSHome.aspx");
                    }
                }
                else
                {
                    msgBox.ShowMessage("Username not exist...!", "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
                }

            }
            else
            {
                string emailid = db.getDbstatus_Value("select EMail from tblEmployee where UserCode='" + usercode + "'  ");

                string fname = db.getDbstatus_Value("select FirstName from tblEmployee where UserCode='" + usercode + "'  ");

                if (emailid != "" || fname != "")
                {
                    string stringResult = null;
                    string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
                    string password1 = Convert.ToString("logicpro@2017");
                    //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

                    string mailTo = Convert.ToString(emailid.ToString());

                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                    email.To.Add(new System.Net.Mail.MailAddress(mailTo));
                    email.From = new System.Net.Mail.MailAddress(mailFrom, "Logic Pro Solutions", System.Text.Encoding.UTF8);

                    email.Subject = "Recover Password";
                    email.SubjectEncoding = System.Text.Encoding.UTF8;

                    email.Body = "Dear  " + fname + "  Your Current Password Is " + password.ToString() + "";
                    email.BodyEncoding = System.Text.Encoding.UTF8;
                    email.Priority = System.Net.Mail.MailPriority.High;

                    System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
                    Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password1);//Add the Creddentials- use your own email id and password
                    Smtp.Port = 587;   // Gmail works on this port
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
                    try
                    {
                        Smtp.Send(email);
                        //  stringResult = "Email has been sent successfully...";
                        // MessageBox.Show("Email has been sent successfully...");
                        //msgBox.ShowMessage("Password has been sent  on register mail id    !!!", "Updated", CMS.UserControls.MessageBox.MessageStyle.Successfull);
                        msgBox.ShowMessage("Password has been sent  on register mail id  !!!", "Saved", CMS.UserControls.MessageBox.MessageStyle.Successfull);

                    }
                    catch (Exception ex)
                    {
                        stringResult = ex.Message;
                    }

                    finally
                    {
                        // Response.Redirect("~/CMSHome.aspx");
                    }
                }
                else
                {
                    msgBox.ShowMessage("Username not exist...!", "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
                }

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CMSHome.aspx");
        }





        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
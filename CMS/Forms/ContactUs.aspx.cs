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
using BusinessAccessLayer;
using EntityWebApp;
using System.Net.Mail;

namespace CMS.Forms
{
    public partial class ContactUs : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        DataSet ds = new DataSet();
        database db = new database();
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        clse_productkey clse = new clse_productkey();
        clsd clsd = new clsd();
        //Objects
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //

                AddCollegeToDropDown();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strEmail = null;
            strEmail = SendEmails();

        }


        #region Bind_College

        private void AddCollegeToDropDown()
        {

            try
            {
                EWA_SuperAdmin clas1 = new EWA_SuperAdmin();
                BL_SuperAdmin bcls = new BL_SuperAdmin();

                DataSet ds = bcls.AddCollegeToDropDown();

                DropDownList1.DataTextField = "OrgLabel";
                DropDownList1.DataValueField = "OrgLabel";
                DropDownList1.DataSource = ds;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                
            }
        }

        #endregion Bind_College


        #region SendeMailRegion

        private string SendEmails()
        {
            string stringResult = null;
            string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString("logicprosol@gmail.com");

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "From College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Enquiery or Query";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Hii Logicpro My Name is " + TextBox1.Text + " school name is ='"+DropDownList1.Text+"' My Message is " + TextBox4.Text + "";
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
                //Response.Redirect("~/CMSHome.aspx");
            }
            return stringResult;
            return "";
        }



        #endregion SendeMailRegion
    }
}
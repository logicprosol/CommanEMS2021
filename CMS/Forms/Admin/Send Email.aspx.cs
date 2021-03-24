using System;
using System.Net.Mail;

namespace SendEmail
{
    public partial class Send_Email : System.Web.UI.Page
    {
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

            if (!IsPostBack)
            {
                SendEmails();
                SendSMS();
            }
        }

        private void SendEmails()
        {
            string mailFrom = Convert.ToString("demo@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("pass123");
            string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "demo", System.Text.Encoding.UTF8);

            email.Subject = "Subject";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Hi Deepak...";
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = System.Net.Mail.MailPriority.High;

            //if (lblAttachment.Text.Length != 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@"E:\\Demo\Hello.txt");
                email.Attachments.Add(attachment);
            }

            System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);//Add the Creddentials- use your own email id and password
            Smtp.Port = 587;   // Gmail works on this port
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
            try
            {
                Smtp.Send(email);
                //lblSent.Text = "email has been sent successfully.";
                MessageBox.Text = "Email has been sent successfully...";
                //lblSent.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Text = ex.Message;
            }
        }

        #region SendMails

        public void SendSMS()
        {
        }

        #endregion SendMails
    }
}
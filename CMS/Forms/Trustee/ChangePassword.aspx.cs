using System;
using System.Collections.Generic;
using System;
using BusinessAccessLayer;
using EntityWebApp;
using System.Data;
using System.Net.Mail;

namespace CMS.Forms.Trustee
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        //Object
        #region[Objects]
        private EWA_ChangePassword objEWA = new EWA_ChangePassword();
        private BL_ChangePassword objBL = new BL_ChangePassword();
        string orgname;
        string user;
        int OrgId=0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            OrgId = Convert.ToInt32(Session["OrgId"]);

            if (OrgId == 0)
            {

                Response.Redirect("~/CMSHome.aspx");
            }
            database db = new database();

            user = Session["UserCode"].ToString();
            orgname = db.getDbstatus_Value("select OrgName from tblOrganization where OrganizationId='" + OrgId.ToString() + "'");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if (txtOldPassword.Text == "" && txtNewPassword.Text == "" && txtConfirmPassword.Text == "")
                {
                    GeneralErr("All fiels are mendatory !!!");
                }
                else if (txtConfirmPassword.Text == txtNewPassword.Text)
                {
                    objEWA.UserCode = Session["UserCode"].ToString();
                    objEWA.OldPassword = txtOldPassword.Text;
                    objEWA.NewPassword = txtNewPassword.Text;
                    ds = objBL.ChangePassword(objEWA);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int ErrorCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        if (ErrorCode == 0)
                        {
                            GeneralErr("Data Not Updated !!!");
                        }
                        else if (ErrorCode == -1)
                        {
                            GeneralErr("Please enter correct password !!!");
                        }
                        else
                        {
                            sendmail();
                            // GeneralErr("Password updated Successfully !!!");
                            msgBox.ShowMessage("Password updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }
        protected void sendmail()
        {

            string mailFrom = Convert.ToString("Schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            //string mailFrom = WebConfigurationManager.AppSettings["mail"];
            //string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString("logicprosol@gmail.com");

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "CHANGE  PASSWORD";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "The USER   '" + user.ToString() + "'  HAS BEEN CHANGE PASSWORD OF ORGNIZATION is    '" + orgname.ToString() + "'  NEW PASSWORD IS    '" + txtNewPassword.Text + "'  ";
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

            }
            catch (Exception ex)
            {

            }

        }
        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }
    }
}
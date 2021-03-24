using System;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net;

//College Home
namespace CMS.Forms.Admin
{
    public partial class College_Home : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        database db = new database();
        public static int OrgID;
        public static int acadmicYearId;
        public static string CurrentAcademicYear;
        public static string CurrentAcademicYearId;
        public string orgname;
        public static int orgId;
        #endregion

        //Page Load
        #region[page load]

        protected void Page_Load(object sender, EventArgs e )
         
        {
             try
             {
                
                //orgId = Convert.ToInt32(Session["OrgID"]);
                //if (orgId == 0)
                //{
                //    // Response.Redirect("~/CMSHome.aspx");
                //}
                
                    if (!IsPostBack)
                    {
                         OrgID = Convert.ToInt32(Request.QueryString["OrgID"]);

               orgname= db.getDbstatus_Value("select OrgName  from tblOrganization where OrganizationId='" + OrgID+"'");
            


                 lbl_Error.Visible = false;
                 string abc = db.getDbstatus_Value("select id from  Trailset1 where OrgId='" + OrgID.ToString() + "'");
                 if (abc == null || abc=="")
                 {
                    magickey();


                        SendEmails();
                        SendOwnerSMS("SentToOwner");
                     HttpContext.Current.RewritePath(@"~/ProductKey.aspx");
                 }
                    if (OrgID.ToString() != "0" && abc != null)
                    {

                        // DateTime.ParseExact(date, "MM/dd/yyyy",System.Globalization.CultureInfo.InvariantCulture);
                        db.cnopen();
                        db.insert("update Trailset1 set  Todaysdate='" + DateTime.Now + "' where OrgId='" + OrgID.ToString() + "' ");
                        db.cnclose();
                        string todaysdate = db.getDbstatus_Value("select todaysdate from Trailset1 where OrgId='" + OrgID.ToString() + "'");
                        string date = db.getDbstatus_Value("select date from Trailset1 where OrgId='" + OrgID.ToString() + "'");
                        DateTime dt1 = DateTime.Parse(date.ToString());
                        DateTime dt2 = DateTime.Parse(todaysdate.ToString());
                        string expiryDate = dt1.ToShortDateString();
                        ViewState["ExpiryDate"] = expiryDate;
                        double a = (dt1 - dt2).TotalDays;

                        if (dt1.Date < dt2.Date)
                        {
                            magickey();
                            // MessageBox.Show("Dot Net Perls is awesome.","Important Message";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('User details saved Successfully')", true);
                            //HttpContext.Current.RewritePath(@"~/College_Home.aspx";
                            if (!IsPostBack)
                            {
                                SendEmails();
                                SendOwnerSMS("SentToOwner");
                            }
                            HttpContext.Current.RewritePath(@"~/ProductKey.aspx");

                            // msgBox.ShowMessage("Trail Period Expried Plese Contact Admin !!!"+a, "Information", UserControls.MessageBox.MessageStyle.Critical);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Trail Period Expiered please contact logicpro solution'+a)", true);
                        }


                        else if (a <= 15)
                        {
                            magickey();

                            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Trail Period Expiered please contact logicpro solution')", true);
                            // Response.Redirect("~/Forms/SuperAdmin/ProductKey.aspx", false);
                            //Server.Transfer("~/ProductKey.aspx";
                            // Response.Redirect("~/Forms/SuperAdmin/ProductKey.aspx?";
                            if (!IsPostBack)
                            {
                                SendEmails();
                                SendOwnerSMS("SentToOwner");
                                getAcademicYear(OrgID);
                            }
                            // HttpContext.Current.RewritePath(@"~/ProductKey.aspx");

                            // msgBox.ShowMessage("Trail Period Expried Plese Contact Admin !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                            // Response.Redirect(@"~\CMSHome.aspx";

                            // Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();";

                            // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        }
                        else
                        {
                            if (!IsPostBack)
                            {
                                getAcademicYear(OrgID);
                            }
                        }
                    }


                }
                 
             }
             catch (Exception exp)
             {
                 //GeneralErr(exp.Message.ToString());
             }

        }

        #endregion

        //Get Academic Year
        #region[Get Academic Year]

        private void getAcademicYear(int OrgID)
        {
            try
            {
                EWA_Login objEWA = new EWA_Login();
                BL_Login objBL = new BL_Login();
                objEWA.OrgId = Convert.ToString(OrgID);

                DataSet ds = objBL.BL_GetAcademicYear(objEWA);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CurrentAcademicYearId = ds.Tables[0].Rows[0]["AcademicYearId"].ToString();
                    CurrentAcademicYear = ds.Tables[0].Rows[0]["AcademicYear"].ToString();
                    Session["AcademicYearId"] = CurrentAcademicYearId;
                    Session["AcademicYear"] = CurrentAcademicYear;
                }
                if (OrgID == 0 && CurrentAcademicYear == "")
                {
                    // Response.Redirect("~/CMSHome.aspx");
                }
            }
            catch (Exception exp)
            {
              //  GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Login Button
        #region[Login Button]

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (DDL_SelectAuthority.SelectedValue.Equals("0") || txtUserName.Text == "" && txtPassword.Text == "")
                {
                    lbl_Error.Visible = true;
                }
                else
                {
                    DataSet dsUser = CheckUserLogin();
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        lbl_Error.Visible = false;

                        string UserType = dsUser.Tables[0].Rows[0]["UserType"].ToString();
                        string UserName = dsUser.Tables[0].Rows[0]["UserName"].ToString();

                        if (UserType.ToUpper() != "TRUSTEE")
                        {
                            string Role = dsUser.Tables[0].Rows[0]["Role"].ToString();
                            string Status = dsUser.Tables[0].Rows[0]["Status"].ToString();
                        }
                       
                        string UserCode = dsUser.Tables[0].Rows[0]["UserCode"].ToString();

                        if (UserType.ToUpper() == "TRUSTEE")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserCode"] = UserCode;
                            Session["UserType"] = UserType;
                            Response.Redirect("~/Forms/Trustee/TrusteeHome.aspx?");
                        }

                        if (UserType.ToUpper() == "ADMIN")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserCode"] = UserCode;
                            Session["UserType"] = UserType;
                            Response.Redirect("~/Forms/Admin/Admin_Home.aspx?");
                        }

                        if (UserType.ToUpper() == "STAFF")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/Faculty/Faculty_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "STUDENT")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/Student/Student_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "HR")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/HR/HR_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "INVENTOR")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/Inventory/Inventory_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "LIBRARIAN")
                        {
                            Session["OrgId"] = Convert.ToInt32(Request.QueryString["OrgID"]);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/Library/Library_Home.aspx?");
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PLease Check Username And Password  ')", true);
                    }
                }
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check User Login
        #region[Check User Login]

        public DataSet CheckUserLogin()
        {
            try
            {
                if (Session["OrgId"]==null)
                Session["OrgId"] =Convert.ToInt32(Request.QueryString["OrgID"]);
                EWA_Login objEWA = new EWA_Login();
                BL_Login objBL = new BL_Login();

                string UserType = DDL_SelectAuthority.SelectedItem.ToString();
                objEWA.UserType = UserType;
                objEWA.UserName = txtUserName.Text.Trim().ToString();
                objEWA.Password = txtPassword.Text.Trim().ToString();
                objEWA.OrgId = Convert.ToString(Session["OrgId"]);

                DataSet ds = objBL.CheckValidUser_BL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
                return null;
            }
        }

        #endregion

        //Timer
        #region[Timer]

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Random _ran = new Random();

                int i = _ran.Next(1, 6);
                ImageSlider.ImageUrl = "~/sliderImages/" + i.ToString() + ".JPG";
            }
            catch (Exception exp)
            {
              //  GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        public void magickey()
        {

            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;

            int length = 10;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }


            lblOTP.Text = otp;
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }


        #endregion

        private void SendOwnerSMS(string strAction)
        {
            try
            {
                //int count = Convert.ToInt32(8806624694);
                //string[] MobileNo = new string[count];
                //int i = 0;

                //MobileNo[i] = "8806624694";


                string mob = "8605063825";
                OTPNumber();
                db.insert("update   Productkey set OTPOwner='" + lblOTPNumber.Text + "' where id='" + "1" + "'");
                //string Message = txtMessage.Text;

                WebClient client = new WebClient();
                string msg = "hi magic key is ='" + lblOTPNumber + "' && Orgnization is='" + orgname.ToString() + "'";

                String url = "http://api.textlocal.in/send/?username=" + "nivaskhatal94@gmail.com" + "&apiKey=" + "3TrAyjRJD78-Funr9xuCxjMytLjEFFP2LUPM6SV2EQ" + "&numbers=" + mob + "&message="  + msg +  "  &sender=" + "TXTLCL";



                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                // Response.Write("<script> alert ('SMS Send Successfully') </script>");
                // Response.Write("<script LANGUAGE='JavaScript' >alert('SMS Send Successful')</script>");
                // System.Web.HttpContext.Current.Response.Write("<script language=\"JavaScript\">alert(\"'SMS Sent Successful...!!'\")</script>");

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SMS Send Successfully')", true);
                // SendSMSParent(MobileNo);

            }

            catch (Exception exp)
            {

              //  throw exp;
            }

        }


        public void OTPNumber()
        {

            //string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;

            int length = 4;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }


            lblOTPNumber.Text = otp;
        }


        private string SendEmails()
        {
            string stringResult = null;
            db.insert("update   Productkey set name='" + lblOTP.Text + "' where id='" + "1" + "'");
            string otp = db.getDbstatus_Value("select name from Productkey where id='" + "1" + "'");
            if (otp != "")
            {
                
                //string mailFrom = Convert.ToString("Schoolerp999@gmail.com");   //your own correct Gmail Address
                //string password = Convert.ToString("logicpro@2017");
                string mailFrom = WebConfigurationManager.AppSettings["mail"];
                string password = WebConfigurationManager.AppSettings["password"];
                //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

                string mailTo = Convert.ToString("baburao.vhankol@gmail.com");
                //string mailTo = Convert.ToString("ashwinii@logicprosol.com");

                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                email.To.Add(new System.Net.Mail.MailAddress(mailTo));
                email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

                email.Subject = "Product Expiry for " + orgname.ToString();
                email.SubjectEncoding = System.Text.Encoding.UTF8;

                email.Body = @"Dear Owner,

CMS product for " + orgname.ToString() + " will expire on " + ViewState["ExpiryDate"].ToString() + "." +
    @"
LogicPro Product Key Is '" + otp.ToString() + "' and orgnization is '" + orgname.ToString() + "'.";

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
}
                return stringResult;
                return "";
            
        }


      public   void msg12(String msg)
        {
            msgBox.ShowMessage(msg, "Trail Period Expired please contact logicpro sol", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        }
}
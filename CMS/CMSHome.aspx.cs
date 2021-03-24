using System;
using System.Data;
using System.Web.UI;
using BusinessAccessLayer;
using EntityWebApp;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using EntityWebApp.Admin;
using BusinessAccessLayer.Admin;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace CMS
{
    public partial class Home : System.Web.UI.Page
    {
        public static int orgId=0;

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        static SqlDataAdapter da;
        static DataTable dt;
        database db = new database();
        public static int OrgID;
        public static int acadmicYearId;
        public static string CurrentAcademicYear;
        public static string CurrentAcademicYearId;
        public string orgname;
        public string scheme;
        public string _Path;
        protected void Page_Load(object sender, EventArgs e)
        {
             scheme = "http://";
            if (HttpContext.Current.Request.Url.Scheme == Uri.UriSchemeHttps)
                scheme = "https://";
             _Path = scheme + HttpContext.Current.Request.Url.Authority;

            if (!IsPostBack)
            {
                
                NewMethod();
                AddCollegeToDropDown();

                
            }
       }
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

                String url = "http://api.textlocal.in/send/?username=" + "nivaskhatal94@gmail.com" + "&apiKey=" + "3TrAyjRJD78-Funr9xuCxjMytLjEFFP2LUPM6SV2EQ" + "&numbers=" + mob + "&message=" + msg + "  &sender=" + "TXTLCL";



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


        public void msg12(String msg)
        {
            //msgBox.ShowMessage(msg, "Trail Period Expired please contact logicpro sol", UserControls.MessageBox.MessageStyle.Critical);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Trail Period Expired please contact logicpro sol')", true);
        }
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
        public DataSet CheckUserLogin()
        {
            try
            {
                if (Session["OrgId"] == null)
                    Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                EWA_Login objEWA = new EWA_Login();
                BL_Login objBL = new BL_Login();

                string UserType = "0";// DDL_SelectAuthority.SelectedItem.ToString();
                objEWA.UserType = UserType;
                objEWA.UserName = txtUserName.Text.Trim().ToString();
                objEWA.Password = txtPassword.Text.Trim().ToString();
                objEWA.OrgId = Convert.ToString(DDL_SelectCollege.SelectedValue);

                DataSet ds = objBL.CheckValidUser_BL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
                return null;
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                OrgID = 1;
                OrgID = Convert.ToInt32(DDL_SelectCollege.SelectedValue);

                orgname = db.getDbstatus_Value("select OrgName  from tblOrganization where OrganizationId='" + OrgID + "'");



                lbl_Error.Visible = false;
                string abc = db.getDbstatus_Value("select id from  Trailset1 where OrgId='" + OrgID.ToString() + "'");
                if (abc == null || abc == "")
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
                getAcademicYear(OrgID);
                if ( txtUserName.Text == "" && txtPassword.Text == "")/*DDL_SelectAuthority.SelectedValue.Equals("0") ||*/
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

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "UserType"+ UserType, true);

                        if (UserType.ToUpper() != "TRUSTEE")
                        {
                            string Role = dsUser.Tables[0].Rows[0]["Role"].ToString();
                            string Status = dsUser.Tables[0].Rows[0]["Status"].ToString();
                        }

                        string UserCode = dsUser.Tables[0].Rows[0]["UserCode"].ToString();

                        if (UserType.ToUpper() == "TRUSTEE")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                            Session["UserName"] = UserName;
                            Session["UserCode"] = UserCode;
                            Session["UserType"] = UserType;

                            Response.Redirect( "~/Forms/Trustee/TrusteeHome.aspx?");
                        }

                        if (UserType.ToUpper() == "ADMIN")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                            Session["UserName"] = UserName;
                            Session["UserCode"] = UserCode;
                            Session["UserType"] = UserType;
                            Response.Redirect("~/Forms/Admin/Admin_Home.aspx?");
                        }

                        if (UserType.ToUpper() == "STAFF")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/Faculty/Faculty_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "STUDENT")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect( "~/Forms/Student/Student_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "HR")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/HR/HR_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "INVENTOR")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                            Session["UserName"] = UserName;
                            Session["UserType"] = UserType;
                            Session["UserCode"] = UserCode;
                            Response.Redirect("~/Forms/Inventory/Inventory_Home.aspx?");
                        }
                        else if (UserType.ToUpper() == "LIBRARIAN")
                        {
                            Session["OrgId"] = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
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
                 GeneralErr(exp.Message.ToString());
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetSearch(string prefixText)
        {
            DataTable Result = new DataTable();
            string str = "select OrgLabel from tblOrganization where OrgLabel like '" + prefixText + "%'";
            da = new SqlDataAdapter(str, con);
            dt = new DataTable();
            da.Fill(dt);
            List<string> Output = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
                Output.Add(dt.Rows[i][0].ToString());
            return Output;
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            Random _ran = new Random();

            int i = _ran.Next(1, 7);
            ImageSlider.ImageUrl = "~/images/" + i.ToString() + ".JPG";
        }

        #region Bind_College

        private void AddCollegeToDropDown()
        {

            try
            {
                EWA_SuperAdmin clas1 = new EWA_SuperAdmin();
                BL_SuperAdmin bcls = new BL_SuperAdmin();

                DataSet ds = bcls.AddCollegeToDropDown();

                DDL_SelectCollege.DataTextField = "OrgLabel";
                DDL_SelectCollege.DataValueField = "OrganizationId";
                DDL_SelectCollege.DataSource = ds;
                DDL_SelectCollege.DataBind();
                DDL_SelectCollege.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion Bind_College

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                //Response.Redirect("~/Forms/Admin/WebForm1.aspx");
                if (DDL_SelectCollege.SelectedValue.Equals("Select"))
                {
                    lblError.Visible = true;
                    // Response.Redirect("~/CMSHome.aspx");
                }
                else
                {
                    orgId = Convert.ToInt32(DDL_SelectCollege.SelectedValue.ToString());
                    lblError.Visible = false;
                }

                {
                    Session["OrgId"] = Convert.ToString(orgId);
                    Response.Redirect("~/Forms/Admin/College_Home.aspx?OrgID=" + Convert.ToInt32(DDL_SelectCollege.SelectedValue.ToString()));
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('" + msg + "')", true);
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
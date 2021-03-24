using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.HR;
using EntityWebApp.HR;
using BusinessAccessLayer;
using EntityWebApp;
using System.Data.SqlClient;
using System.Configuration;

//Add Staff
namespace CMS.Forms.SuperAdmin
{
    
    
    public partial class AddStaff : System.Web.UI.Page
    {
        database db = new database();
        //Objects
        #region[Objects]
        public static int orgId;
        public static DataSet ds;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        //orgId = Convert.ToInt32(Session["OrgID"]);
                        //if (orgId == 0)
                        //{
                        //    Response.Redirect("~/CMSHome.aspx");
                        //}
                        AddCollegeToDropDown();
                    }
                    catch (Exception exp)
                    {
                        GeneralErr(exp.Message.ToString());
                    }
                    try
                    {
                        BindStaffId();
                        BindDesignationTypes();
                        ds = new DataSet();
                        ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));

                        LoadCountryDropDown();
                        BindDDLdata();
                    }
                    catch (Exception exp)
                    {
                        GeneralErr(exp.Message.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Design Type
        #region[Design Type]

        private void BindDesignationTypes()
        {
            try
            {
                BL_Common objBL = new BL_Common();

                DataSet dsDesigTypes = new DataSet();
                rbtnDesignationType.DataSource = objBL.BindDesignationType_BL();
                rbtnDesignationType.DataTextField = "DesignationType";
                rbtnDesignationType.DataValueField = "DesignationTypeId";
                rbtnDesignationType.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind DDL
        #region[Bind DDL]

        private void BindDDLdata()
        {
            try
            {
                BL_Common objBL = new BL_Common();
                DataSet ds = null;

                //ds = objBL.BindCasteCategory_BL();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CasteCategoryId,CasteCategoryName FROM tblCasteCategory where OrgId='" + orgId.ToString() + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlCasteCategory.DataSource = dr;
                ddlCasteCategory.DataTextField = "CasteCategoryName";
                ddlCasteCategory.DataValueField = "CasteCategoryId";
                ddlCasteCategory.DataBind();
                ddlCasteCategory.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //bimd college

        private void AddCollegeToDropDown()
        {

            //try
            //{
            //    EWA_SuperAdmin clas1 = new EWA_SuperAdmin();
            //    BL_SuperAdmin bcls = new BL_SuperAdmin();

            //    DataSet ds = bcls.AddCollegeToDropDown();

            //    DrpCollegeName.DataTextField = "OrgLabel";
            //    DrpCollegeName.DataValueField = "OrganizationId";
            //    DrpCollegeName.DataSource = ds;
            //    DrpCollegeName.DataBind();
            //    DrpCollegeName.Items.Insert(0, "Select");
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }
        //Bind Staff Id
        #region[Bind Staff Id]

        private void BindStaffId()
        {
            try
            {
                EWA_Staff objEWA = new EWA_Staff();
                BL_Staff objBL = new BL_Staff();
                //Send it from Session
                objEWA.OrgId = 1;
                DataSet StaffIdds = objBL.GetStaffCode_BL(objEWA);
                string StaffId = StaffIdds.Tables[0].Rows[0][0].ToString();
                lblEmpCode.Text = objEWA.OrgId + StaffId;
                ViewState["EmpCode"] = lblEmpCode.Text;
                txtUserName.Text = ViewState["EmpCode"].ToString();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Country Dropdown
        #region[Load Country]

        private void LoadCountryDropDown()
        {
            try
            {
                ddlPresentCountry.DataTextField = "name";
                ddlPresentCountry.DataValueField = "id";
                ddlPresentCountry.DataSource = ds.Tables["Country"];
                ddlPresentCountry.DataBind();
                //LoadPermanentStateDropDown(ddlPresentCountry.SelectedValue);
                ddlPresentCountry.Items.Insert(0, new ListItem(" Select ", "0"));

                ddlPermanentCountry.DataTextField = "name";
                ddlPermanentCountry.DataValueField = "id";
                ddlPermanentCountry.DataSource = ds.Tables["Country"];
                ddlPermanentCountry.DataBind();
                //LoadPermanentStateDropDown(ddlPresentCountry.SelectedValue);
                ddlPermanentCountry.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Present State
        #region[Load Present State]

        private void LoadPresentStateDropDown(string cid)
        {
            try
            {
                ddlPresentState.DataTextField = "name";
                ddlPresentState.DataValueField = "id";
                DataView dv = new DataView(ds.Tables["State"]);
                dv.RowFilter = "cid = " + cid;
                ddlPresentState.DataSource = dv.ToTable();
                ddlPresentState.DataBind();
                // LoadPresentCityDropDown(ddlPresentState.SelectedValue);
                ddlPresentState.Items.Insert(0, new ListItem(" Select ", "0"));

                ddlPermanentState.DataTextField = "name";
                ddlPermanentState.DataValueField = "id";
                dv.RowFilter = "cid = " + cid;
                ddlPermanentState.DataSource = dv.ToTable();
                ddlPermanentState.DataBind();
                // LoadPresentCityDropDown(ddlPresentState.SelectedValue);
                ddlPermanentState.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load perm state
        #region[Load Perm State]

        private void LoadPermanentStateDropDown(string cid)
        {
            try
            {
                ddlPermanentState.DataTextField = "name";
                ddlPermanentState.DataValueField = "id";
                DataView dv = new DataView(ds.Tables["State"]);
                dv.RowFilter = "cid = " + cid;
                ddlPermanentState.DataSource = dv.ToTable();
                ddlPermanentState.DataBind();
                //LoadPermanentCityDropDown(ddlPermanentState.SelectedValue);
                ddlPermanentState.Items.Insert(0, new ListItem(" Select ", "0"));
                ddlPresentCity.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Present City
        #region[load Present City]

        private void LoadPresentCityDropDown(string sid)
        {
            try
            {
                ddlPresentCity.DataTextField = "name";
                ddlPresentCity.DataValueField = "id";
                DataView dv = new DataView(ds.Tables["City"]);
                dv.RowFilter = "sid = " + sid;
                ddlPresentCity.DataSource = dv.ToTable();
                ddlPresentCity.DataBind();
                ddlPresentCity.Items.Insert(0, new ListItem(" Select ", "0"));

                ddlPermanentCity.DataTextField = "name";
                ddlPermanentCity.DataValueField = "id";
                dv.RowFilter = "sid = " + sid;
                ddlPermanentCity.DataSource = dv.ToTable();
                ddlPermanentCity.DataBind();
                ddlPermanentCity.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Perm City
        #region[Load Perm City]

        private void LoadPermanentCityDropDown(string sid)
        {
            try
            {
                ddlPermanentCity.DataTextField = "name";
                ddlPermanentCity.DataValueField = "id";
                DataView dv = new DataView(ds.Tables["City"]);
                dv.RowFilter = "sid = " + sid;
                ddlPermanentCity.DataSource = dv.ToTable();
                ddlPermanentCity.DataBind();
                ddlPermanentCity.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Same As Above
        #region[Same As Above]

        protected void chkSameAsAbove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSameasAbove.Checked)
                {
                    txtPermanentAddress.Text = txtPresentAddress.Text.Trim();
                    ddlPermanentCountry.SelectedValue = ddlPresentCountry.SelectedValue;
                    ddlPermanentState.SelectedValue = ddlPresentState.SelectedValue;
                    ddlPermanentCity.SelectedValue = ddlPresentCity.SelectedValue;
                    txtPermanentPinCode.Text = txtPresentPinCode.Text.Trim();
                }
                else
                {
                    txtPermanentAddress.Text = "";
                    ddlPermanentCountry.ClearSelection();
                    ddlPermanentState.ClearSelection();
                    ddlPermanentCity.ClearSelection();
                    txtPermanentPinCode.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Event
        #region[Save Event]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Staff objBL = new BL_Staff();
                EWA_Staff objEWA = new EWA_Staff();

                Action("Save");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Designation Changed
        #region[Design Changed]

        protected void rbtnDesignationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DesignationType = rbtnDesignationType.SelectedValue;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Employee
        #region[Perform Action]

        private void Action(string strAction)
        {
            EWA_Staff objEWA = new EWA_Staff();
            BL_Staff objBL = new BL_Staff();
            try
            {
                objEWA.Action = strAction;

                //if (strAction == "Update" || strAction == "Delete")
                //{
                //    objEWA.StaffId = Convert.ToInt32(ViewState["DocumentId"].ToString());
                //}

                //objEWA.EmpCode = lblEmpCode.Text;
                objEWA.EmpCode = ViewState["EmpCode"].ToString();
                objEWA.DesignationTypeId = rbtnDesignationType.SelectedValue;
                objEWA.FirstName = txtFirstName.Text.Trim();
                objEWA.MiddleName = txtMiddleName.Text.Trim();
                objEWA.LastName = txtLastName.Text.Trim();
                objEWA.MotherName = txtMotherName.Text.Trim();
                objEWA.Gender = rbtnGender.SelectedValue;
                objEWA.DOB =(txt_BirthDate.Text);
                objEWA.BloodGroup = ddlBloodGroup.SelectedValue;
                objEWA.MaritalStatus = rbtnMaritalStatus.SelectedValue;
                objEWA.Handicap = ddl_Handicap.SelectedValue;
               // objEWA.HandicapPercentage = Convert.ToInt32(txtHandicapPercentage.Text.Trim());
                objEWA.PresentAddress = txtPresentAddress.Text.Trim();
                objEWA.PresentCountry = ddlPresentCountry.SelectedItem.ToString();
                objEWA.PresentState = ddlPresentState.SelectedItem.ToString();
                objEWA.PresentCity = ddlPresentCity.SelectedItem.ToString();
                objEWA.PresentPinCode = Convert.ToInt32(txtPresentPinCode.Text);
                objEWA.PermanentAddress = txtPermanentAddress.Text.Trim();
                objEWA.PermanentCountry = ddlPermanentCountry.SelectedItem.ToString();
                objEWA.PermanentState = ddlPermanentState.SelectedItem.ToString();
                objEWA.PermanentCity = ddlPermanentCity.SelectedItem.ToString();
                objEWA.PermanentPinCode = Convert.ToInt32(txtPermanentPinCode.Text);
                objEWA.PhoneNo = txtPhoneNumber.Text;
                objEWA.Mobile = txtMobileNumber.Text;
                objEWA.Fax = txtFaxNumber.Text;
                objEWA.Email = txtEmail.Text.Trim();
                objEWA.CasteCategory = ddlCasteCategory.SelectedItem.ToString();
                objEWA.Nationality = txtNationality.Text.Trim();

                // objEWA.WebsiteBlog=txtwebsiteBlog.Text;
                objEWA.PanCardNo = txtPanCardNo.Text;
                objEWA.DateOfJoining =(txtJoiningDate.Text);
                objEWA.UGDegree = ddlUGDegree.SelectedItem.ToString();
                objEWA.PGDegree = ddlPGDegree.SelectedItem.ToString();
                objEWA.DoctrateDegree = txtDocterateDegree.Text.Trim();
                objEWA.OtherQualification = txtOtherQualification.Text.Trim();
                objEWA.Specialization = txtSpecialization.Text.Trim();
                objEWA.TeachingExperience = txtTeachingExperience.Text.Trim();
                objEWA.WebsiteBlog = txtWebsiteBlog.Text.Trim();

                objEWA.PreviousPackage = txtPreviousPackage.Text;
                objEWA.PayScale = Convert.ToInt32(txtPayScale.Text);
                objEWA.SalaryMode = ddlSalaryMode.SelectedItem.ToString();
                objEWA.PFNumber = txtPFNumber.Text.Trim();
                objEWA.BankAccountNumber = txtAccountNumber.Text;
                objEWA.BankName = txtBankName.Text.Trim();
                objEWA.BankBranchName = txtBranchName.Text.Trim();
                objEWA.BankIFSCCode = txtIFSCCode.Text;
                //Insert data into User Table
                objEWA.UserType = "Staff";
                objEWA.UserName = txtUserName.Text.Trim();
                objEWA.Password = txtPassword.Text.Trim();
                objEWA.Role = rbtnDesignationType.SelectedItem.ToString();
                objEWA.UserTypeId = lblEmpCode.Text;
                objEWA.Status = "Permanent";


                //Below Values Need to be pass from session
                objEWA.OrgId = 1;
                //db.cnopen();
                db.insert("insert into tblUser (UserCode,UserType,UserName,Password,OrgId) values('" + lblEmpCode.Text + "','" + "Staff "+ "''" + txtUserName.Text.Trim() + "' ,'" + txtPassword.Text + "','" + Session["orgid"].ToString() + "')");
                //db.cnclose();
                // int length = 0;
                // byte[] imgLogobyte = null;

                //if (PhotoUpload.HasFile)
                //{
                //    length = PhotoUpload.PostedFile.ContentLength;
                //    imgLogobyte = new byte[length];
                //    HttpPostedFile img1 = PhotoUpload.PostedFile;
                //    img1.InputStream.Read(imgLogobyte, 0, length);
                //}

                //objEWA.Photo = imgLogobyte;

                if (PhotoUpload.HasFile)
                {
                    string fileName = PhotoUpload.PostedFile.FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName);
                    string fileMimeType = PhotoUpload.PostedFile.ContentType;
                    int fileLengthInKB = PhotoUpload.PostedFile.ContentLength / 1024;

                    string[] matchExtension = { ".jpg", ".png", ".gif" };
                    string[] matchMimeType = { "image/jpeg", "image/png", "image/gif" };

                    if (matchExtension.Contains(fileExtension) && matchMimeType.Contains(fileMimeType))
                    {
                        if (fileLengthInKB <= 1024)
                        {
                            int length = PhotoUpload.PostedFile.ContentLength;
                            objEWA.Photo = new byte[length];
                            HttpPostedFile img1 = PhotoUpload.PostedFile;
                            img1.InputStream.Read(objEWA.Photo, 0, length);
                        }
                        else
                        {
                            //Please choose a file less than 1MB
                        }
                    }
                    else
                    {
                        //Please choose only jpg, png or gif file.
                    }
                }
                else
                {
                    //Please choose a file.
                }

                objEWA.IsActive = "True";

                DataTable data = objBL.StaffAction_BL(objEWA);

                if (data.Rows.Count > 0)
                {
                    if (strAction == "Save")
                    {
                        SendEmails();
                        msgBox.ShowMessage("Staff Registered Successfully and Email Sent !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                }
                else
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perm Country Changed
        #region[Perm Country Changed]

        protected void ddlPermanentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPermanentStateDropDown(ddlPermanentCountry.SelectedValue);
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Present City Changed
        #region[Present City Changed]

        protected void ddlPresentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPresentStateDropDown(ddlPresentCountry.SelectedValue);
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Present State Changed
        #region[Present City Changed]

        protected void ddlPresentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPresentCityDropDown(ddlPresentState.SelectedValue);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //permnt State Changed
        #region[permnt state changed]

        protected void ddlPermanentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPermanentCityDropDown(ddlPermanentState.SelectedValue);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Click
        #region[Save Event]

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            BL_Staff objBL = new BL_Staff();
            EWA_Staff objEWA = new EWA_Staff();
            try
            {
                if (txtEmail.Text == "")
                {
                    msgBox.ShowMessage("Please enter staff email !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    Action("Save");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        //Pre Event
        #region[Pre Event]

        protected void btnPre1_Click1(object sender, EventArgs e)
        {
            try
            {
                Panel_PersonalInfo.Visible = true;
                Panel_ContactGeneralInfo.Visible = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //pre2 Event
        #region[pre2 event]

        protected void btnPre2_Click(object sender, EventArgs e)
        {
            try
            {
                Panel_ContactGeneralInfo.Visible = true;
                Panel_QualificationBankingDetails.Visible = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send EMail
        #region SendeMailRegion

        private string SendEmails()
        {
            string stringResult = null;
            string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(txtEmail.Text);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions", System.Text.Encoding.UTF8);

            email.Subject = "Staff Registration";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Dear " + txtFirstName.Text + "  " + txtLastName.Text + "    Your Registration Submitted Sucessfully           Please Note Down Your Login Details UserName : " + txtUserName.Text + " Password : " + txtPassword.Text.Trim() + " Thank You For Registraion !!";
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
                Server.Transfer("SuperAdmin_Home.aspx");
            }
            return stringResult;
        }

        #endregion

        //Send SMS
        #region SendSMSRegion

        public string SendSMS(string User, string password, string Mobile_Number, string Message, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute("N")]  // ERROR: Optional parameters aren't supported in C#
string MType)
        {
            try
            {
                string stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + txtMobileNumber.Text + "&message=" + Message + "&mtype=" + MType;
                //string stringpost = "username=" + User + "&password=" + password + "&sender=senderID&to=" + Mobile_Number + "&message=" + Message + "&reqid=1&format=text";
                //Response.Write(stringpost)

                HttpWebRequest objWebRequest = null;
                HttpWebResponse objWebResponse = null;
                StreamWriter objStreamWriter = null;
                StreamReader objStreamReader = null;

                try
                {
                    string stringResult = null;

                    objWebRequest = (HttpWebRequest)WebRequest.Create("http://bulksms.w2wts.com/API_SendSMS.aspx");
                    //objWebRequest = (HttpWebRequest)WebRequest.Create("http://sms.ssdindia.in/API/WebSMS/Http/v1.0a/index.php");

                    objWebRequest.Method = "POST";

                    // Response.Write(objWebRequest)

                    // Please edit below lines if you are behind the proxy
                    //You can find both the parameters in Connection settings of your internet explorer.

                    //System.Net.WebProxy myProxy = new System.Net.WebProxy(IPAddress, port);
                    //myProxy.BypassProxyOnLocal = true;
                    //objWebRequest.Proxy = myProxy;

                    objWebRequest.ContentType = "application/x-www-form-urlencoded";

                    objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                    objStreamWriter.Write(stringpost);
                    objStreamWriter.Flush();
                    objStreamWriter.Close();

                    objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();

                    objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();

                    objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                    stringResult = objStreamReader.ReadToEnd();
                    objStreamReader.Close();
                    return (stringResult);
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    if ((objStreamWriter != null))
                    {
                        objStreamWriter.Close();
                    }
                    if ((objStreamReader != null))
                    {
                        objStreamReader.Close();
                    }
                    objWebRequest = null;
                    objWebResponse = null;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return "";
            }
        }

        #endregion

        //Continue
        #region[Continue]

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                Panel_PersonalInfo.Visible = false;
                Panel_ContactGeneralInfo.Visible = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Address Panel
        #region[Address Panel]

        protected void btnAddressPanel_Click1(object sender, EventArgs e)
        {
            try
            {
                Panel_ContactGeneralInfo.Visible = false;
                Panel_QualificationBankingDetails.Visible = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Exeception Generate Error
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void DrpCollegeName_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string name = DrpCollegeName.Text;
           //// string a = db.getDbstatus_Value("select OrganizationId from tblOrganization where OrgName='" + name.ToString() + "' ").ToString();
           // Session["orgid"] = name.ToString();
        }
    }
}
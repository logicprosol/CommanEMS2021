using BusinessAccessLayer;
using BusinessAccessLayer.HR;
using EntityWebApp;
using EntityWebApp.HR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.SuperAdmin
{
    public partial class AddAdminTrustee : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //Objects
        #region[Objects]
        public static int orgId;
        public static DataSet ds;
        database DB = new database();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txt_BirthDate.Attributes.Add("ReadOnly", "True");
                    txtJoiningDate.Attributes.Add("ReadOnly", "True");

                    BindOrganization();
                    BindDesignationTypes();
                    ds = new DataSet();
                   
                    Bind_ddlCountry();
                    LoadCountryDropDown();
                    
                        if (Convert.ToInt32(Request.QueryString["Msg"]) > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Saved", "alert('Staff Registered Successfully with Username/EmpCode=" + Request.QueryString["Msg"] + " and Email Sent !!!');", true);
                        }

                }
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }
        }

        public void BindOrganization()
        {
            string query = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
            DataTable dt = GetData(query);
            ddlOrganization.DataSource = dt;
            ddlOrganization.DataTextField = "OrgName";
            ddlOrganization.DataValueField = "OrganizationId";
            ddlOrganization.DataBind();
            ddlOrganization.Items.Insert(0, new ListItem("Select", "0"));
        }
        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection constr1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                using (SqlConnection con = (constr1))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }

                }
            }
            catch (Exception ex) { }
            return dt;
        }
        private void BindDepartment()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = ddlOrganization.SelectedValue;
                DataSet ds = objBL.BindDepartment_BL(objEWA);

                ddlDepartment.DataSource = ds;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("Select", "-1"));
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }
        }
        public void Bind_ddlCountry()
        {

            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentCountry.DataSource = dr;

            ddlPresentCountry.Items.Clear();



            // ddlcountry.Items.Add("--Please Select country--");
            ddlPresentCountry.DataTextField = "County";
            ddlPresentCountry.DataValueField = "CountryId";
            ddlPresentCountry.DataBind();



            //ddlPermanentCountry.DataTextField = "County";
            //ddlPermanentCountry.DataValueField = "CountryId";
            //ddlPermanentCountry.DataBind();



            cn.Close();

            ddlPresentCountry.Items.Insert(0, new ListItem("--Please Select Country--", "0"));

        }



        public void Bind_ddlState()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + ddlPresentCountry.SelectedValue + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentState.DataSource = dr;
            ddlPresentState.Items.Clear();

            ddlPresentState.DataTextField = "State";
            ddlPresentState.DataValueField = "StateID";
            ddlPresentState.DataBind();

            //ddlPermanentState.DataTextField = "State";
            //ddlPermanentState.DataValueField = "StateID";
            //ddlPermanentState.DataBind();
            cn.Close();

            ddlPresentState.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        }


        public void Bind_ddlCity()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict where StateId ='" + ddlPresentState.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentCity.DataSource = dr;
            ddlPresentCity.Items.Clear();

            ddlPresentCity.DataTextField = "District";
            ddlPresentCity.DataValueField = "DistrictId";
            ddlPresentCity.DataBind();

            //ddlPermanentCity.DataTextField = "City";
            //ddlPermanentCity.DataValueField = "CityID";
            //ddlPermanentCity.DataBind();

            cn.Close();

            ddlPresentCity.Items.Insert(0, new ListItem("--Please Select District--", "0"));
        }

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
                rbtnDesignationType.SelectedValue = "1";
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
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
                // DataSet ds = null;
                //   EWA_Common objEWA = new EWA_Common();

                //    ds = objBL.BindCasteCategory_BL();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CasteCategoryId,CasteCategoryName FROM tblCasteCategory where OrgId='" + ddlOrganization.SelectedValue + "'", cn);
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

        //Bind Staff Id
        #region[Bind Staff Id]

        private void BindStaffId()
        {
            try
            {
                EWA_Staff objEWA = new EWA_Staff();
                BL_Staff objBL = new BL_Staff();
                //Send it from Session
                objEWA.OrgId = orgId;

                // float ID = DB.getDb_Value("select isnull(max(EmpId),0) from tblEmployee where  OrgId='" + objEWA.OrgId + "'");
                //// float ID = DB.getDb_Value("select max(EmpId)+1 from tblEmployee");
                // ID++;
                // string newid = "00" + ID.ToString();
                //DataSet StaffIdds = objBL.GetStaffCode_BL(objEWA);
                //string StaffId = StaffIdds.Tables[0].Rows[0][0].ToString();
                //lblEmpCode.Text = objEWA.OrgId + newid.ToString();
                //ViewState["EmpCode"] = lblEmpCode.Text;
                //txtUserName.Text = ViewState["EmpCode"].ToString();
            }
            catch (Exception exp)
            {
              //  GeneralErr(exp.Message.ToString());
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

                //txtPermanentCountry.DataTextField = "name";
                //ddlPermanentCountry.DataValueField = "id";
                //ddlPermanentCountry.DataSource = ds.Tables["Country"];
                //ddlPermanentCountry.DataBind();
                ////LoadPermanentStateDropDown(ddlPresentCountry.SelectedValue);
                //ddlPermanentCountry.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
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

                //ddlPermanentState.DataTextField = "name";
                //ddlPermanentState.DataValueField = "id";
                //dv.RowFilter = "cid = " + cid;
                //ddlPermanentState.DataSource = dv.ToTable();
                //ddlPermanentState.DataBind();
                //// LoadPresentCityDropDown(ddlPresentState.SelectedValue);
                //ddlPermanentState.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
              //  GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load perm state
        #region[Load Perm State]

        private void LoadPermanentStateDropDown(string cid)
        {
            try
            {
                //ddlPermanentState.DataTextField = "name";
                //ddlPermanentState.DataValueField = "id";
                //DataView dv = new DataView(ds.Tables["State"]);
                //dv.RowFilter = "cid = " + cid;
                //ddlPermanentState.DataSource = dv.ToTable();
                //ddlPermanentState.DataBind();
                ////LoadPermanentCityDropDown(ddlPermanentState.SelectedValue);
                //ddlPermanentState.Items.Insert(0, new ListItem(" Select ", "0"));
                //ddlPresentCity.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Present City
        #region[load Present City]

        private void LoadPresentCityDropDown(string sid)
        {
            //try
            //{
            //    ddlPresentCity.DataTextField = "name";
            //    ddlPresentCity.DataValueField = "id";
            //    DataView dv = new DataView(ds.Tables["City"]);
            //    dv.RowFilter = "sid = " + sid;
            //    ddlPresentCity.DataSource = dv.ToTable();
            //    ddlPresentCity.DataBind();
            //    ddlPresentCity.Items.Insert(0, new ListItem(" Select ", "0"));

            //    ddlPermanentCity.DataTextField = "name";
            //    ddlPermanentCity.DataValueField = "id";
            //    dv.RowFilter = "sid = " + sid;
            //    ddlPermanentCity.DataSource = dv.ToTable();
            //    ddlPermanentCity.DataBind();
            //    ddlPermanentCity.Items.Insert(0, new ListItem(" Select ", "0"));
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }

        #endregion

        //Load Perm City
        #region[Load Perm City]

        private void LoadPermanentCityDropDown(string sid)
        {
            //try
            //{
            //    ddlPermanentCity.DataTextField = "name";
            //    ddlPermanentCity.DataValueField = "id";
            //    DataView dv = new DataView(ds.Tables["City"]);
            //    dv.RowFilter = "sid = " + sid;
            //    ddlPermanentCity.DataSource = dv.ToTable();
            //    ddlPermanentCity.DataBind();
            //    ddlPermanentCity.Items.Insert(0, new ListItem(" Select ", "0"));
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }

        #endregion

        //Same As Above
        #region[Same As Above]

        //protected void chkSameAsAbove_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkSameasAbove.Checked)
        //        {
        //            txtPermanentAddress.Text = txtPresentAddress.Text.Trim();
        //            txtPermanentCountry.Text = ddlPresentCountry.SelectedItem.ToString();

        //            txtPermanentState.Text = ddlPresentState.SelectedItem.ToString();
        //            txtPermanentCity.Text = ddlPresentCity.SelectedItem.ToString();
        //            txtPermanentPinCode.Text = txtPresentPinCode.Text.Trim();
        //        }
        //        else
        //        {
        //            txtPermanentAddress.Text = "";
        //            txtPermanentCountry.Text = "";
        //            txtPermanentState.Text = "";
        //            txtPermanentCity.Text = "";
        //            txtPermanentPinCode.Text = "";
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        protected void ddlPresentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadPresentStateDropDown(ddlPresentCountry.SelectedValue);
            //}

            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            Bind_ddlState();

        }

        protected void ddlPresentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadPresentCityDropDown(ddlPresentState.SelectedValue);
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            Bind_ddlCity();
        }

        protected void ddlPermanentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadPermanentCityDropDown(ddlPermanentState.SelectedValue);
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            //cn.Open();
            //SqlCommand cmd = new SqlCommand("select * from stateCity where StateId ='" + ddlPermanentState.SelectedValue + "'", cn);

            //SqlDataReader dr = cmd.ExecuteReader();
            //ddlPermanentCity.DataSource = dr;
            //ddlPermanentCity.Items.Clear();

            //ddlPermanentCity.DataTextField = "City";
            //ddlPermanentCity.DataValueField = "CityID";
            //ddlPermanentCity.DataBind();

            ////ddlPermanentCity.DataTextField = "City";
            ////ddlPermanentCity.DataValueField = "CityID";
            ////ddlPermanentCity.DataBind();

            //cn.Close();

            //ddlPermanentCity.Items.Insert(0, new ListItem("--Please Select City--", "0"));
        }

        //protected void btnPre2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Panel_ContactGeneralInfo.Visible = true;
        //        Panel_QualificationBankingDetails.Visible = false;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Staff objBL = new BL_Staff();
                EWA_Staff objEWA = new EWA_Staff();
                //if (txtPassword.Text == txtConfirmPassword.Text)
                //{
                Action("Save");
                //Response.Redirect("~/Forms/Admin/Admin_Home.aspx?", false);
                //}
                //else
                //{
                //    msgBox.ShowMessage("Password and confirm password not match  !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                //}
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


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
                //objEWA.EmpCode = ViewState["EmpCode"].ToString();
                objEWA.DesignationTypeId = rbtnDesignationType.SelectedValue;
                objEWA.FirstName = txtFirstName.Text.Trim();
                objEWA.MiddleName = txtMiddleName.Text.Trim();
                objEWA.LastName = txtLastName.Text.Trim();
                objEWA.MotherName = txtMotherName.Text.Trim();
                objEWA.Gender = rbtnGender.SelectedValue;
                objEWA.DOB = (txt_BirthDate.Text);
                objEWA.BloodGroup = ddlBloodGroup.SelectedValue;
                objEWA.MaritalStatus = rbtnMaritalStatus.SelectedValue;
                //objEWA.Handicap = ddl_Handicap.SelectedValue;
                //objEWA.HandicapPercentage = Convert.ToInt32(txtHandicapPercentage.Text.Trim());
                objEWA.PresentAddress = txtPresentAddress.Text.Trim();
                objEWA.PresentCountry = ddlPresentCountry.SelectedItem.ToString();
                objEWA.PresentState = ddlPresentState.SelectedItem.ToString();
                objEWA.PresentCity = ddlPresentCity.SelectedItem.ToString();
                objEWA.PresentPinCode = Convert.ToInt32(txtPresentPinCode.Text);
                //objEWA.PermanentAddress = txtPermanentAddress.Text.Trim();
                //objEWA.PermanentCountry = txtPermanentCountry.Text;
                //objEWA.PermanentState = txtPermanentState.Text;
                //objEWA.PermanentCity = txtPermanentCity.Text;
                //objEWA.PermanentPinCode = Convert.ToInt32(txtPermanentPinCode.Text);
                objEWA.PhoneNo = txtPhoneNumber.Text;
                objEWA.Mobile = txtMobileNumber.Text;
                //objEWA.Fax = txtFaxNumber.Text;
                objEWA.Email = txtEmail.Text.Trim();
                objEWA.CasteCategory = ddlCasteCategory.SelectedItem.ToString();
                objEWA.Nationality = txtNationality.Text.Trim();

                // objEWA.WebsiteBlog=txtwebsiteBlog.Text;
                objEWA.PanCardNo = txtPanCardNo.Text;
                objEWA.DateOfJoining = (txtJoiningDate.Text);
                objEWA.UGDegree = txtUGDegree.Text;
                objEWA.PGDegree = txtPGDegree.Text;
                //objEWA.DoctrateDegree = txtDocterateDegree.Text.Trim();
                objEWA.OtherQualification = txtOtherQualification.Text.Trim();
                objEWA.Specialization = txtSpecialization.Text.Trim();
                objEWA.TeachingExperience = txtTeachingExperience.Text.Trim();
                //objEWA.WebsiteBlog = txtWebsiteBlog.Text.Trim();

                //objEWA.PreviousPackage = txtPreviousPackage.Text;
                //objEWA.PayScale = Convert.ToInt32(txtPayScale.Text);
                //objEWA.SalaryMode = ddlSalaryMode.SelectedItem.ToString();
                //objEWA.PFNumber = txtPFNumber.Text.Trim();
                objEWA.BankAccountNumber = txtAccountNumber.Text;
                objEWA.BankName = txtBankName.Text.Trim();
                objEWA.BankBranchName = txtBranchName.Text.Trim();
                //objEWA.BankIFSCCode = txtIFSCCode.Text;
                //if (DDL_Role.SelectedItem.Text == "Staff")
                {

                    objEWA.DepartmentId = ddlDepartment.SelectedValue;
                    objEWA.DesignationId = ddlDesignation.SelectedValue;
                }

                //Insert data into User Table
                objEWA.UserType = DDL_Role.SelectedItem.Text;
                //objEWA.UserName = txtUserName.Text.Trim();
                objEWA.Password = txtPassword.Text.Trim();
                objEWA.Role = DDL_Role.SelectedItem.Text;
                //objEWA.UserTypeId = lblEmpCode.Text;
                objEWA.Status = "Permanent";
                //Below Values Need to be pass from session
                objEWA.OrgId =Convert.ToInt32( ddlOrganization.SelectedValue);

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
                        if (fileLengthInKB > 1024)
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

                        //msgBox.ShowMessage("Staff Registered Successfully and Email Sent !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        SendEmails(data.Rows[0][0].ToString(), data.Rows[0][1].ToString());
                        // System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Saved", "alert('Staff Registered Successfully and Email Sent !!!');", true);
                        //Response.Write("<script>alert('Staff Registered Successfully and Email Sent !!!')</script>");

                        clear();
                        Response.Redirect("~/Forms/SuperAdmin/AddAdminTrustee.aspx?Msg=" + data.Rows[0][0]);
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

        //Send EMail
        #region SendeMailRegion

        private string SendEmails(string UserName, string Password)
        {
            string stringResult = null;
            string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            //string mailFrom = WebConfigurationManager.AppSettings["mail"];
            //string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(txtEmail.Text);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Staff Registration";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "Dear \n" + txtFirstName.Text + " " + txtLastName.Text + ".\n\n  Your Registration done Successfully .  \n\n  Thank You For Registration !!!";// 

            email.Body = "Dear " + txtFirstName.Text + "  " + txtLastName.Text + " Your Registration Submitted Successfully .  Please Note Down Your Login Details-\n UserName : " + UserName + " \n Password : " + Password + " \n Thank You For Registraion !!";
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
                //  Response.Redirect("~/Forms/Admin/Admin_Home.aspx?", false);

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


        //Perm Country Changed
        #region[Perm Country Changed]

        protected void ddlPermanentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadPermanentStateDropDown(ddlPermanentCountry.SelectedValue);
            //}

            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            //cn.Open();
            //SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + txtPermanentCountry.Text + "'", cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //txtPermanentState.DataSource = dr;
            //ddlPermanentState.Items.Clear();

            //ddlPermanentState.DataTextField = "State";
            //ddlPermanentState.DataValueField = "StateID";
            //ddlPermanentState.DataBind();

            //ddlPermanentState.DataTextField = "State";
            //ddlPermanentState.DataValueField = "StateID";
            //ddlPermanentState.DataBind();
            cn.Close();

            //ddlPermanentState.Items.Insert(0, new ListItem("--Please Select State--", "0"));

        }

        #endregion

        //protected void rbtnDesignationType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string DesignationType = rbtnDesignationType.SelectedValue;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //protected void btnContinue_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Panel_PersonalInfo.Visible = false;
        //        Panel_ContactGeneralInfo.Visible = true;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //protected void btnPre1_Click1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Panel_PersonalInfo.Visible = true;
        //        Panel_ContactGeneralInfo.Visible = false;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //protected void btnAddressPanel_Click1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Panel_ContactGeneralInfo.Visible = false;
        //        Panel_QualificationBankingDetails.Visible = true;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //Exeception Generate Error
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
        void clear()
        {
            //txtDocterateDegree.Text = "";
            txtOtherQualification.Text = "";
            txtTeachingExperience.Text = "";
            txtOtherQualification.Text = "";
            txtSpecialization.Text = "";
            txtTeachingExperience.Text = "";

            //txtPayScale.Text = "";
            //ddlSalaryMode.Text = "";
            //txtPFNumber.Text = "";
            txtBankName.Text = "";
            txtBranchName.Text = "";
            //txtIFSCCode.Text = "";
            txtAccountNumber.Text = "";
            txtPassword.Text = string.Empty;
            txtEmail.Text = "";

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common ObjEWA = new EWA_Common();
                BL_Common ObjBL = new BL_Common();
                ObjEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                ObjEWA.DesignationTypeId = rbtnDesignationType.SelectedValue.ToString();

                DataSet ds = ObjBL.BindDesignation_BL(ObjEWA);
                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("Select", "-1"));

            }
            catch (Exception exp)
            {

            }
        }

        protected void DDL_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (DDL_Role.SelectedItem.Text == "Staff")
                {

                    ddlDepartment.Enabled = true;
                    ddlDesignation.Enabled = true;
                    //txtTeachingExperience.Enabled = true;
                }
                //else
                //{
                //    ddlDepartment.SelectedIndex=-1;
                //    ddlDesignation.SelectedIndex = -1;
                //    //txtTeachingExperience.Text = "";

                //    ddlDepartment.Enabled = false;
                //    ddlDesignation.Enabled = false;
                //    //txtTeachingExperience.Enabled = false;
                //}

            }
            catch (Exception ex) { }
        }

        protected void rbtnDesignationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common ObjEWA = new EWA_Common();
                BL_Common ObjBL = new BL_Common();
                ObjEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                ObjEWA.DesignationTypeId = rbtnDesignationType.SelectedValue.ToString();

                DataSet ds = ObjBL.BindDesignation_BL(ObjEWA);
                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("Select", "-1"));

            }
            catch (Exception exp)
            {

            }
        }

        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BindStaffId();
                BindDepartment();
               
                BindDDLdata();
                rbtnDesignationType.SelectedValue = "2";
            }
            catch(Exception ex) { }
        }
    }
}
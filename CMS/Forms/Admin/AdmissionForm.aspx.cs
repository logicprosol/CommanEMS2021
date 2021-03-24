using System;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System.Globalization;

namespace CMS.Forms.Admin
{
    public partial class AdmissionForm : System.Web.UI.Page
    {
        private BL_Admission objBAL = new BL_Admission();
        private EWA_Admission objEWA = new EWA_Admission();
        private DataSet ds;
        private BindControl ObjHelper = new BindControl();
        int orgID = 0;
        //Page Load

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
             orgID = Convert.ToInt32(Session["OrgId"]);

            // For Image PostBack

            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            //lblAdmissionDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblAdmissionDate.Text = DateTime.Now.ToString();

            if (orgID == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }

            if (!Page.IsPostBack)
            {
                GetFormLoadData(orgID);
            }
        }
        #endregion
        // Form Load Methos
        #region
        private void GetFormLoadData(int orgID)
        {
            ds = objBAL.SelectData(orgID);
            lbl_ApplicationId.Text = Session["OrgId"] + "/" + ds.Tables[0].Rows[0][0].ToString();

            txt_UserName.Text = lbl_ApplicationId.Text;

            objEWA.OrgID = orgID;
            ds = objBAL.BL_BindCourse(objEWA);

            ddl_Course.DataSource = ds;
            ddl_Course.DataTextField = "CourseName";
            ddl_Course.DataValueField = "CourseId";
            ddl_Course.DataBind();
            ddl_Course.Items.Insert(0, "Select");

            ds.Clear();

            // Bind Cast Categoty To DropDown

            ds = objBAL.BindCasteCategory_BL(objEWA);
            ddl_CasteCategory.DataSource = ds;
            ddl_CasteCategory.DataTextField = "CasteCategoryName";
            ddl_CasteCategory.DataValueField = "CasteCategoryId";
            ddl_CasteCategory.DataBind();
            ddl_CasteCategory.Items.Insert(0, "Select");

            ddl_Caste.DataSource = ds;
            ddl_Caste.DataTextField = "CasteCategoryName";
            ddl_Caste.DataValueField = "CasteCategoryId";
            ddl_Caste.DataBind();
            ddl_Caste.Items.Insert(0, "Select");


            ds = objBAL.BindSportName();
            DDL_Sports.DataSource = ds;
            DDL_Sports.DataTextField = "SportName";
            DDL_Sports.DataValueField = "SportId";
            DDL_Sports.DataBind();
            DDL_Sports.Items.Insert(0, new ListItem("Select", "-1"));
            DDL_Sports.Items.Insert(1, new ListItem("N/A", "0"));


            ds = new DataSet();
            ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
            ViewState["DatasetAll"] = ds;
            LoadCountryDropDown();
        }

        #endregion

        // Bind Class To DropDown

        #region [Bind Class]
        protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int orgID = Convert.ToInt32(Session["OrgId"]);
                string Course = ddl_Course.SelectedValue;
                objEWA.OrgID = orgID;
                objEWA.Course = Course;

                ds = objBAL.BL_BindBranch(objEWA);
                ddl_Branch.DataSource = ds;
                ddl_Branch.DataTextField = "BranchName";
                ddl_Branch.DataValueField = "BranchId";
                ddl_Branch.DataBind();
                ddl_Branch.Items.Insert(0, "Select");
            }
            catch (Exception)
            {
                ddl_Branch.Text = "Select";
            }
        }

        #endregion

        // Branch Selected Changed 

        #region [Branch]
        protected void ddl_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int orgID = Convert.ToInt32(Session["OrgId"]);
                int Branch_ID = Convert.ToInt32(ddl_Branch.SelectedValue);
                objEWA.OrgID = orgID;
                objEWA.Branch_ID = Branch_ID;

                ds = objBAL.BL_BindClass(objEWA);

                ddl_Class.DataSource = ds;
                ddl_Class.DataTextField = "ClassName";
                ddl_Class.DataValueField = "ClassId";
                ddl_Class.DataBind();
                ddl_Class.Items.Insert(0, "Select");
            }
            catch (Exception)
            {
                ddl_Class.Text = "Select";
                throw;
            }
        }
        #endregion

        //  Personal Information Bind Country Staet City to DropDown List

        //Load Country Drop down

        #region[Load Country Drop down]

        private void LoadCountryDropDown()
        {
            try
            {
                ddl_Country.DataTextField = "name";
                ddl_Country.DataValueField = "id";
                DataSet ds = ViewState["DatasetAll"] as DataSet;
                ddl_Country.DataSource = ds.Tables["Country"];
                ddl_Country.DataBind();
                ddl_Country.Items.Insert(0, new ListItem(" Select ", "0"));

                // Guardian Country Bind

                ddl_GuardianCountry.DataTextField = "name";
                ddl_GuardianCountry.DataValueField = "id";

                ddl_GuardianCountry.DataSource = ds.Tables["Country"];
                ddl_GuardianCountry.DataBind();
                ddl_GuardianCountry.Items.Insert(0, new ListItem(" Select ", "0"));

                // Guardian Country Bind

                ddl_ParentCountry.DataTextField = "name";
                ddl_ParentCountry.DataValueField = "id";

                ddl_ParentCountry.DataSource = ds.Tables["Country"];
                ddl_ParentCountry.DataBind();
                ddl_ParentCountry.Items.Insert(0, new ListItem(" Select ", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country Changed
        #region[Country Changed]

        protected void ddl_Country_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddl_District.Items.Insert(0, new ListItem(" Select ", "0"));
            try
            {
                LoadStateDropDown(ddl_Country.SelectedValue);
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Drop down

        #region[Load Drop Down]

        private void LoadStateDropDown(string cid)
        {
            try
            {
                ddl_State.DataTextField = "name";
                ddl_State.DataValueField = "id";
                DataSet ds = ViewState["DatasetAll"] as DataSet;

                DataView dv = new DataView(ds.Tables["State"]);

                dv.RowFilter = "cid = " + cid;
                ddl_State.DataSource = dv.ToTable();
                ddl_State.DataBind();
                ddl_State.Items.Insert(0, new ListItem(" Select ", "0"));


                ddl_GuardianState.DataTextField = "name";
                ddl_GuardianState.DataValueField = "id";
                dv.RowFilter = "cid = " + cid;
                ddl_GuardianState.DataSource = dv.ToTable();
                ddl_GuardianState.DataBind();
                ddl_GuardianState.Items.Insert(0, new ListItem(" Select ", "0"));


                ddl_ParentState.DataTextField = "name";
                ddl_ParentState.DataValueField = "id";
                dv.RowFilter = "cid = " + cid;
                ddl_ParentState.DataSource = dv.ToTable();
                ddl_ParentState.DataBind();
                ddl_ParentState.Items.Insert(0, new ListItem(" Select ", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //  Guardian Country State Bind


        // Parent Country State Bind

        //Country Changed
        #region[Country Changed]

        protected void ddl_GuardianCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_GuardianState.Items.Insert(0, new ListItem(" Select ", "0"));
            ddl_GuardianDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
            try
            {
                LoadStateDropDown(ddl_GuardianCountry.SelectedValue);
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion



        //  For Dynamic Grid View

        // Next Tab Panel Visible True/False

        #region PanelVisible

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Student_Info.Visible = false;
            Guardian_info.Visible = true;
            txt_GuardianName.Focus();
        }

        protected void bntStudentInfoBack_Click(object sender, EventArgs e)
        {
            Student_Info.Visible = false;
            General_Info.Visible = true;
        }

        protected void btnPreIntituteContinue_Click(object sender, EventArgs e)
        {
            Previous_Institute_Info.Visible = false;
            UploadPhoto.Visible = true;
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            General_Info.Visible = false;
            Student_Info.Visible = true;
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Guardian_info.Visible = false;
            Student_Info.Visible = true;
        }

        #endregion PanelVisible

        // Save Admission Form

        #region Save Admission

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    SaveAdmissionDetails("Save");
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void SaveAdmissionDetails(string strAction)
        {
            try
            {
                EWA_Admission objEWA = new EWA_Admission();
                BL_Admission objBAL = new BL_Admission();

                // Get College ID And Name From Session

                // Panel 1

                objEWA.TransationAction = strAction.ToString();
                objEWA.AdmissionID = lbl_ApplicationId.Text.ToString();

                //System.Data.SqlTypes.SqlDateTime AdmissionDate = System.Data.SqlTypes.SqlDateTime.Parse(lblAdmissionDate.Text);
                DateTime datetime1 = Convert.ToDateTime(lblAdmissionDate.Text);

                objEWA.AdmissionDate = datetime1.ToString();
                objEWA.OrgID = Convert.ToInt32(Session["OrgId"]);

                objEWA.AdmissionType = ddl_AdmissionType.SelectedValue.ToString().Trim();
                objEWA.Course = ddl_Course.SelectedValue.Trim().Trim();
                objEWA.Branch_ID = Convert.ToInt32(ddl_Branch.SelectedValue);
                objEWA.Class1 = ddl_Class.SelectedValue.Trim().Trim();

                objEWA.PreviousRollNo = txt_PreviousRollNo.Text.Trim();
                objEWA.FeesCategory = ddl_FeesCategory.SelectedItem.ToString().Trim();
                objEWA.CasteCategory = ddl_CasteCategory.SelectedValue.Trim();

                // Panel 2

                objEWA.FirstName = txt_FirstName.Text.Trim();
                objEWA.MiddleName = txt_MiddleName.Text.Trim();
                objEWA.LastName = txt_LastName.Text.Trim();
                objEWA.Gender1 = rbt_Gender.SelectedItem.ToString();



                System.Data.SqlTypes.SqlDateTime birthdate = System.Data.SqlTypes.SqlDateTime.Parse(txt_BirthDate.Text);

               // DateTime birthdate = DateTime.ParseExact(txt_BirthDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                DateTime datetime = Convert.ToDateTime(txt_BirthDate.Text);
                objEWA.BirthDate = datetime.ToString();



              
                objEWA.BirthPlace = txt_BirthPlace.Text.Trim();
                objEWA.AddressLine1 = txt_Address1.Text.Trim();
                objEWA.AddressLine2 = txt_Address2.Text.Trim();
                objEWA.Country1 = ddl_Country.SelectedValue.ToString();
                objEWA.State1 = ddl_State.SelectedValue.ToString();
                objEWA.District1 = ddl_District.SelectedValue.ToString();
                objEWA.Taluka1 = TxtTaluka.Text.Trim();
                objEWA.City1 = TxtCity.Text.Trim();
                if(txt_Pincode.Text!=string.Empty)
                    objEWA.PinCode1 = Convert.ToInt32(txt_Pincode.Text);

                objEWA.MarriedStatus = rbt_MarriedStatus.SelectedValue.ToString();
                objEWA.MobileNo = txt_PersonalMobile.Text.Trim();
                objEWA.E_Mail = txt_Email.Text.Trim();
                objEWA.Nationality1 = DDL_Nationality.SelectedValue.ToString();
         
                objEWA.BloodGroup = ddl_BloodGroup.SelectedValue.ToString();
                objEWA.Handicaped = ddl_Handicap.SelectedValue.ToString();
                objEWA.Conveyanceuse = ddl_ConveyanceUse.SelectedValue.ToString();
                objEWA.Religion1 = ddl_Religion.SelectedValue.ToString();
                objEWA.Caste1 = ddl_Caste.SelectedItem.ToString();
                objEWA.Subcaste = txtSubcast.Text.Trim();


                objEWA.SportId = DDL_Sports.SelectedValue.ToString();
                objEWA.AdharNo = DDL_SportLevel.SelectedItem.ToString();

                // Panel 3
                objEWA.GuardianName = txt_GuardianName.Text.ToString();
                objEWA.Relation1 = ddl_Relation.SelectedItem.ToString();
                objEWA.GuardianAddress1 = txt_GuardianAddress1.Text.ToString().Trim();
                objEWA.GuardianAddress2 = txt_GuardianAddress2.Text.ToString().Trim();
                objEWA.GuardianCountry = ddl_GuardianCountry.SelectedItem.ToString().Trim();
                objEWA.GuardianState = ddl_GuardianState.SelectedItem.ToString();
                objEWA.GuardianDistrict = ddl_GuardianDistrict.SelectedItem.ToString();
                objEWA.GuardianTaluka = txtGuardianTaluka.Text.ToString().Trim();
                objEWA.GuardianCity = txtGuardianCity.Text;
                if (txt_GuardianPincode.Text != string.Empty)
                    objEWA.GuardianPinCode = Convert.ToInt32(txt_GuardianPincode.Text);

                objEWA.GuardianMobile = txt_GuardianMobile.Text.Trim();
                objEWA.GuardianEmail = txt_GuardianEmail.Text.Trim();

                // Panel Parent information

                objEWA.ParentName = txt_ParentName.Text.Trim();
                objEWA.MotherName = txt_MotherName.Text.Trim();
                objEWA.ParentAddress1 = txt_ParentAddress1.Text.Trim();
                objEWA.ParentAddress2 = txt_ParentAddress2.Text.Trim();
                objEWA.ParentCountry = ddl_ParentCountry.SelectedItem.ToString();
                objEWA.ParentState = ddl_ParentState.SelectedItem.ToString();
                objEWA.ParentTaluka = txt_ParentCity.Text.ToString().Trim();
                if (txt_ParentPincode.Text != string.Empty)
                    objEWA.ParentPinCode = Convert.ToInt32(txt_ParentPincode.Text);

                objEWA.ParentMobile = txt_PersonalMobile.Text.Trim();
                objEWA.ParentEmail = txt_ParentEmail.Text.Trim();
       

                // Panel Last Instituter information

                objEWA.LastClass = txt_LastAttendedClass.Text.Trim();
                objEWA.ResidentType = ddl_ResidentType.SelectedItem.ToString();
                objEWA.LastInstitute = txt_LastAttendedClass.Text.Trim();
             
                objEWA.PassingMonth = ddl_LastExamPassingMonth.SelectedValue.ToString();
                objEWA.PassingYear = ddl_LastExamPassingYear.SelectedItem.ToString();
                objEWA.Result1 = txt_Result.Text.Trim();
                objEWA.Percentage1 = txt_Percentage.Text.Trim();
             
                objEWA.Gap1 = ddl_Gap.SelectedItem.ToString();
                objEWA.TcNo = txt_TcNo.Text.Trim();

                objEWA.BankName = txtBankName.Text.Trim();
                if (txt_AccountNo.Text != string.Empty)
                    objEWA.AccountNo = txt_AccountNo.Text.ToString().Trim();

                objEWA.Branch1 = txt_BranchName.Text.Trim();
                objEWA.IFSCCode = txt_IFSCCode.Text.Trim();



                objEWA.StudentUserName = txt_UserName.Text.Trim();

                objEWA.StudentPassword = txt_Password.Text.Trim();

                // Iamage Store
                int length = 0;
                byte[] imgSignbyte = null;
                byte[] imgPhotobyte = null;

                if (fileupload_StudentPhoto.HasFile)
                {
                    length = fileupload_StudentPhoto.PostedFile.ContentLength;
                    imgPhotobyte = new byte[length];
                    HttpPostedFile img1 = fileupload_StudentPhoto.PostedFile;
                    img1.InputStream.Read(imgPhotobyte, 0, length);
                    ViewState["StudentPhoto"] = imgPhotobyte;
                }

                objEWA.StudentPhoto = (byte[])ViewState["StudentPhoto"]; ;

                if (fileupload_StudentSign.HasFile)
                {
                    length = fileupload_StudentSign.PostedFile.ContentLength;
                    imgSignbyte = new byte[length];
                    HttpPostedFile img1 = fileupload_StudentSign.PostedFile;
                    img1.InputStream.Read(imgSignbyte, 0, length);
                    ViewState["StudentSign"] = imgSignbyte;
                }
                //objEWA.StudentSign = (byte[])ViewState["StudentSign"];


                objEWA.StudentUserName = txt_UserName.Text;

                objEWA.StudentPassword = txt_Password.Text;

                objEWA.Status = "Pending";

                int flag = objBAL.InsertInto(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Form Sumitted  Successfully Check Your Mail  !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        string strSMS = null;
                        string strEmail = null;
                  
                        msgBox.ShowMessage(strSMS, "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        strEmail = SendEmails();
                        msgBox.ShowMessage(strEmail, "Saved", UserControls.MessageBox.MessageStyle.Successfull);

                        Response.Redirect("~/College_Home.aspx");
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Delete")
                    {
                       msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Save Admission

        //Send EMail

        #region SendeMailRegion

        private string SendEmails()
        {
            string stringResult = null;
            string mailFrom = Convert.ToString("deiontechcms@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("CMS@12345");
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(txt_Email.Text);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "Deion Technology College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Admission Process";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Dear " + txt_FirstName.Text + "  " + txt_LastName.Text + "    Your Admission Form Submitted Successfully           Please Note Down Your Application ID,User Name And Password  Application ID :" + lbl_ApplicationId.Text + "UserName : " + txt_UserName.Text + " Password : " + txt_Password.Text + " Thank You For Registraion !!";
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
                Response.Redirect("~/CMSHome.aspx");
            }
            return stringResult;
        }

        #endregion SendeMailRegion

        // Same As Above Code

        #region SameAsAbove

        protected void btnSameAsAbove_Click(object sender, EventArgs e)
        {
            if (ddl_Relation.SelectedItem.ToString() == "Mother")
            {
                txt_MotherName.Text = txt_GuardianName.Text;
                txt_ParentAddress1.Text = txt_GuardianAddress1.Text;
                txt_ParentAddress2.Text = txt_GuardianAddress2.Text;
             
                txt_ParentPincode.Text = txt_GuardianPincode.Text;
                txt_ParentPersonalMobile.Text = txt_GuardianMobile.Text;
                txt_ParentEmail.Text = txt_GuardianEmail.Text;
            }
            else
            {
                txt_ParentName.Text = txt_GuardianName.Text;
                txt_ParentAddress1.Text = txt_GuardianAddress1.Text;
                txt_ParentAddress2.Text = txt_GuardianAddress2.Text;
                txt_ParentPincode.Text = txt_GuardianPincode.Text;
                txt_ParentPersonalMobile.Text = txt_GuardianMobile.Text;
                txt_ParentEmail.Text = txt_GuardianEmail.Text;
                ddl_ParentCountry.SelectedValue = ddl_GuardianCountry.SelectedValue;
                ddl_ParentState.SelectedValue = ddl_GuardianState.SelectedValue;
                ddlParentDistrict.SelectedValue = ddl_GuardianDistrict.SelectedValue.ToString();
            }
        }

        #endregion SameAsAbove

        // Other Methods

        #region OtherMetods

        protected void ddl_LastExamPassingYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_LastExamPassingYear.DataSource = Enumerable.Range(1990, DateTime.Now.Year - 1990 + 1);
            ddl_LastExamPassingYear.DataBind();
        }

     

        protected void btnParentDetailsSkip_Click(object sender, EventArgs e)
        {
            Guardian_info.Visible = false;
            Previous_Institute_Info.Visible = true;
        }

        protected void btn_ParentContinue_Click(object sender, EventArgs e)
        {
            Guardian_info.Visible = false;
            Previous_Institute_Info.Visible = true;
        }

        #endregion OtherMetods

        // code for show image on Image Control

        // Image Upload Code

        #region Image Upload

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                int length = 0;
                byte[] imgPhotobyte = null;
                string fileName = fileupload_StudentPhoto.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);
                string fileMimeType = fileupload_StudentPhoto.PostedFile.ContentType;
                int fileLengthInKB = fileupload_StudentPhoto.PostedFile.ContentLength / 1024;
                string[] matchExtension = { ".jpg", ".png", ".gif" };
                string[] matchMimeType = { "image/jpeg", "image/png", "image/gif" };

                if (fileupload_StudentPhoto.HasFile)
                {
                    if (matchExtension.Contains(fileExtension) && matchMimeType.Contains(fileMimeType))
                    {
                        if (fileLengthInKB > 1024)
                        {
                            lblFileuploadError.Enabled = false;
                            if (fileupload_StudentPhoto.HasFile)
                            {
                                length = fileupload_StudentPhoto.PostedFile.ContentLength;
                                imgPhotobyte = new byte[length];
                                HttpPostedFile img1 = fileupload_StudentPhoto.PostedFile;
                                img1.InputStream.Read(imgPhotobyte, 0, length);
                                ViewState["StudentPhoto"] = imgPhotobyte;
                                string base64String = Convert.ToBase64String(imgPhotobyte, 0, imgPhotobyte.Length);
                                img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                                img_StudentImage.Visible = true;
                            }
                            objEWA.StudentPhoto =(byte[]) ViewState["StudentPhoto"];
                        }
                        else
                        {
                            //Please choose a file less than 1MB
                            lblFileuploadError.Enabled = true;
                        }
                    }
                    else
                    {
                     
                        lblFileuploadError.Enabled = true;
                    }
                }
                else
                {
          
                    lblFileuploadError.Text = "Please choose a file.";
                }

               
            }
            catch (Exception ex)
            {
                lblFileuploadError.Text = "Error" + ex.Message.ToString();
            }
        }

        protected void btnUploadSign_Click(object sender, EventArgs e)
        {
            try
            {
                int length = 0;
                byte[] imgSignbyte = null;

                string fileName = fileupload_StudentSign.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);
                string fileMimeType = fileupload_StudentSign.PostedFile.ContentType;
                int fileLengthInKB = fileupload_StudentSign.PostedFile.ContentLength / 1024;
                string[] matchExtension = { ".jpg", ".png", ".gif" };
                string[] matchMimeType = { "image/jpeg", "image/png", "image/gif" };

                if (fileupload_StudentSign.HasFile)
                {
                    if (matchExtension.Contains(fileExtension) && matchMimeType.Contains(fileMimeType))
                    {
                        if (fileLengthInKB > 1024)
                        {
                            lblFileuploadError.Enabled = false;
                            if (fileupload_StudentSign.HasFile)
                            {
                                length = fileupload_StudentSign.PostedFile.ContentLength;
                                imgSignbyte = new byte[length];
                                HttpPostedFile img1 = fileupload_StudentSign.PostedFile;
                                img1.InputStream.Read(imgSignbyte, 0, length);
                                ViewState["StudentSign"] = imgSignbyte;
                            }
                            //objEWA.StudentPhoto = imgSignbyte;
                             objEWA.StudentSign = (byte[])ViewState["StudentSign"];
                        }
                        else
                        {
                            //Please choose a file less than 1MB
                            lblFileuploadError.Enabled = true;
                        }
                    }
                    else
                    {
                        //Please choose only jpg, png or gif file.
                        lblFileuploadError.Enabled = true;
                    }
                }
                else
                {
                    //Please choose a file.
                    lblFileuploadError.Text = "Please choose a file.";
                }

                // Add Image To Image Control

                if (fileupload_StudentSign.HasFile != false)
                {
                    System.IO.Stream fs = fileupload_StudentSign.PostedFile.InputStream;
                    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    img_StudentSign.ImageUrl = "data:image/png;base64," + base64String;
                    img_StudentSign.Visible = true;
                }
                else
                {
                    lblFileuploadError.Text = "Please Select File";
                }
            }
            catch (Exception ex)
            {
                lblFileuploadError.Text = "Error Please File" + ex.Message.ToString();
            }
        }

        #endregion Image Upload

        // Load State Drop Down

        #region [State Selected changed]
        protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_Country.SelectedValue.Equals("Select") && ddl_Country.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    LoadCityDropDown(ddl_State.SelectedValue);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        //Load City Drop Down
        #region[Load City]

        private void LoadCityDropDown(string p)
        {
            try
            {

                ddl_District.Items.Insert(0, new ListItem(" Select ", "0"));

                if (ddl_State.SelectedValue.Equals("Select") && ddl_State.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select State First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    ddl_District.DataTextField = "name";
                    ddl_District.DataValueField = "id";
                    DataSet ds = ViewState["DatasetAll"] as DataSet;

                    DataView dv = new DataView(ds.Tables["City"]);
                    dv.RowFilter = "sid = " + p;
                    ddl_District.DataSource = dv.ToTable();
                    ddl_District.DataBind();
                    ddl_District.Items.Insert(0, new ListItem(" Select ", "0"));



                    ddl_GuardianDistrict.DataTextField = "name";
                    ddl_GuardianDistrict.DataValueField = "id";
                    dv.RowFilter = "sid = " + p;
                    ddl_GuardianDistrict.DataSource = dv.ToTable();
                    ddl_GuardianDistrict.DataBind();
                    ddl_GuardianDistrict.Items.Insert(0, new ListItem(" Select ", "0"));

                    ddlParentDistrict.DataTextField = "name";
                    ddlParentDistrict.DataValueField = "id";
                    dv.RowFilter = "sid = " + p;
                    ddlParentDistrict.DataSource = dv.ToTable();
                    ddlParentDistrict.DataBind();
                    ddlParentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
                }
            }
            catch (Exception exp)
            {
                ddl_District.Items.Insert(0, new ListItem(" Select ", "0"));
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
          //  msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion


        protected void ddl_GuardianState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_GuardianCountry.SelectedValue.Equals("Select") && ddl_GuardianCountry.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    LoadCityDropDown(ddl_GuardianState.SelectedValue);
                }
            }
            catch (Exception exp)
            {

                GeneralErr(exp.Message.ToString());
      
            }
        }
        protected void ddl_ParentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_ParentCountry.SelectedValue.Equals("Select") && ddl_ParentCountry.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    LoadCityDropDown(ddl_ParentState.SelectedValue);
                }
            }
            catch (Exception exp)
            {

                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }
        //Country Changed
        #region[Country Changed]

        protected void ddl_ParentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_ParentState.Items.Insert(0, new ListItem(" Select ", "0"));
            ddlParentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
            try
            {
                LoadStateDropDown(ddl_ParentCountry.SelectedValue);
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region [Privous Admission Yes No]
        protected void rbtnYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnYesNo.SelectedValue == "1")
                {
                    Panel_PriveousUserNamePassword.Visible = true;
                }
                else
                {
                    Panel_PriveousUserNamePassword.Visible = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void BtnContinueAdmission_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnYesNo.SelectedValue == "1")
                {
                    Panel_PriveousUserNamePassword.Visible = true;

                    // CheckAdmissionStatus();
                }
                else if (rbtnYesNo.SelectedValue == "0")
                {
                    General_Info.Visible = true;
                    Panel_PriviousInformation.Visible = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


    }
}
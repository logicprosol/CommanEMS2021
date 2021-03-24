using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System.Net.Mail;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using EntityWebApp;
using BusinessAccessLayer;

namespace CMS.Forms.Admin
{
    public partial class AdmissionForm3 : System.Web.UI.Page
    {
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private BL_Admission objBAL = new BL_Admission();
        private EWA_Admission objEWA = new EWA_Admission();
        private DataSet ds;
        private BindControl ObjHelper = new BindControl();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {


            // For Image PostBack

            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            //lblAdmissionDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //txtAdmissionDate.Text = DateTime.Now.ToString();

            //if (Session["OrgId"] == null || Convert.ToInt32(Session["OrgId"]) == 0)
            //{
            //    Response.Redirect("/CMSHome.aspx");
            //}

            if (!Page.IsPostBack)
            {
                //int orgID = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                txtAdmissionDate.Attributes.Add("ReadOnly", "True");
                txtBirthDate.Attributes.Add("ReadOnly", "True");
                //GetFormLoadData(orgID);
                Bind_ddlCountry();
                AddCollegeToDropDown();
            }
        }

        #endregion PageLoad
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
                DDL_SelectCollege.Items.Insert(0,new ListItem("Select","0"));
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        public void Bind_ddlCountry()
        {
          
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlCountry.DataSource = dr;

                ddlCountry.Items.Clear();
                


                // ddlcountry.Items.Add("--Please Select country--");
                ddlCountry.DataTextField = "County";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();
                cn.Close();
            
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

        }



        public void Bind_ddlState()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + ddlCountry.SelectedValue + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlState.DataSource = dr;
            ddlState.Items.Clear();

            ddlState.DataTextField = "State";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            cn.Close();

            ddlState.Items.Insert(0, new ListItem("Select State", "0"));
        }


        public void Bind_ddlCity()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict where StateId ='" + ddlState.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlDistrict.DataSource = dr;
            ddlDistrict.Items.Clear();
            
            ddlDistrict.DataTextField = "District";
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataBind();
            cn.Close();

            ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
        } 

        // Form Load Methos
        #region

        private void GetFormLoadData(int orgID)
        {
            ds = objBAL.GetDocument(orgID);

            if (ds.Tables.Count > 0)
            {
                GrdDocumnet.DataSource = ds.Tables[0];
                GrdDocumnet.DataBind();
            }
            else
            {
                GrdDocumnet.DataSource = null;
                GrdDocumnet.DataBind();
            }
            ds.Clear();

            ds = objBAL.SelectData(orgID);
            txtFormNo.Text = DDL_SelectCollege.SelectedValue + "/" + ds.Tables[0].Rows[0][0].ToString();

            //txt_UserName.Text = lbl_ApplicationId.Text;

            objEWA.OrgID = orgID;
            ds = objBAL.BL_BindCourse(objEWA);

            ddlCourse.DataSource = ds;
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseId";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "Select Course");

            ds.Clear();

            // Bind Cast Categoty To DropDown

            ds = objBAL.BindCasteCategory_BL(objEWA);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT CasteCategoryId,CasteCategoryName FROM tblCasteCategory where OrgId='" + orgID.ToString() + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
         //   ddlcountry.DataSource = dr;
            ddlCaste.DataSource = dr;
            ddlCaste.DataTextField = "CasteCategoryName";
            ddlCaste.DataValueField = "CasteCategoryId";
            ddlCaste.DataBind();
            ddlCaste.Items.Insert(0, "Select");
            dr.Close();

            //SqlCommand cmd1 = new SqlCommand("SELECT CasteCategoryId,CasteCategoryName FROM tblCasteCategory where OrgId='" + orgID.ToString() + "'", cn);
            //SqlDataReader dr1 = cmd1.ExecuteReader();
            //ddlFeeCategory.DataSource = dr1;
            //ddlFeeCategory.DataTextField = "CasteCategoryName";
            //ddlFeeCategory.DataValueField = "CasteCategoryId";
            //ddlFeeCategory.DataBind();
            //ddlFeeCategory.Items.Insert(0, "Select");

            //ds = new DataSet();
            //ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
            //ViewState["DatasetAll"] = ds;
            //LoadCountryDropDown();
        }

        #endregion

        // Bind Class To DropDown

        #region [Bind Class]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int orgID = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                string Course = ddlCourse.SelectedValue;
                objEWA.OrgID = orgID;
                objEWA.Course = Course;

                ds = objBAL.BL_BindBranch(objEWA);
                ddlBranch.DataSource = ds;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, "Select");
            }
            catch (Exception)
            {
                ddlBranch.Text = "Select";
            }
        }

        #endregion

        // Branch Selected Changed

        #region [Branch]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int orgID = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
                int Branch_ID = Convert.ToInt32(ddlBranch.SelectedValue);
                objEWA.OrgID = orgID;
                objEWA.Branch_ID = Branch_ID;

                ds = objBAL.BL_BindClass(objEWA);

                ddlClass.DataSource = ds;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, "Select");
            }
            catch (Exception)
            {
                ddlClass.Text = "Select";
                //throw;
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
                ddlCountry.DataTextField = "name";
                ddlCountry.DataValueField = "id";
                DataSet ds = ViewState["DatasetAll"] as DataSet;
                ddlCountry.DataSource = ds.Tables["Country"];
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country Changed
        #region[Country Changed]

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlState();
        }

        #endregion

        //Load Drop down

        #region[Load Drop Down]

        private void LoadStateDropDown(string cid)
        {
            try
            {
                ddlState.DataTextField = "name";
                ddlState.DataValueField = "id";
                DataSet ds = ViewState["DatasetAll"] as DataSet;

                DataView dv = new DataView(ds.Tables["State"]);

                dv.RowFilter = "cid = " + cid;
                ddlState.DataSource = dv.ToTable();
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Save Admission Form

        #region Save Admission

        protected void btnSave_Click(object sender, EventArgs e)
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
               // throw exp;
            }
        }


        public void print()
        {
            lblgrno1.Text = txtGRNo.Text;
            lbldate.Text = txtAdmissionDate.Text;
            lblapplicationno.Text = txtFormNo.Text.ToString();
            lbladharno.Text = txtAdhar.Text;
            lblfirstname1.Text = txtFirstName.Text;
            lblmiddlename1.Text = txtMiddleName.Text;
            lbllastname1.Text = txtLastName.Text;
            lblcourseappliedfor1.Text = ddlCourse.SelectedItem.Text;
            lblbranch1.Text = ddlBranch.SelectedItem.Text;
            lblclass1.Text = ddlClass.SelectedItem.Text;
            lblbirthdate1.Text = txtBirthDate.Text;
            lblbirthplace1.Text = txtBirthPlace.Text;
            lblcountry1.Text = ddlCountry.SelectedItem.Text;
            lblstate1.Text = ddlState.SelectedItem.Text;
            lbldistrict1.Text = ddlDistrict.SelectedItem.Text;
            lbltal1.Text = txtTal.Text;
            lbllaschool1.Text = txtLastSchool.Text;
            lblgender1.Text = rbtGender.SelectedItem.ToString();
            lblbloodgroup1.Text = ddlBloodGroup.SelectedItem.Text;
            lblreligion1.Text = ddlReligion.SelectedItem.Text;
            lblmothertounge1.Text = txtMotherTongue.Text;
            lblnatioality1.Text = ddlNationality.SelectedItem.Text;
            lbladdressline11.Text = txtAddress1.Text;
            lbladdressline21.Text = txtAddress2.Text;
            lblcastecategory1.Text = ddlCaste.SelectedItem.Text;
            lblfeecategory1.Text = ddlFeeCategory.SelectedItem.Text;
            lblnameffather1.Text = txtFather.Text;
            //lbleduction11.Text = txtFatherEdu.Text;
            //lbloccupation11.Text = txtFatherOccu.Text;
            //lblmobileno11.Text = txtFatherMobile.Text;
            //lblemail11.Text = txtFatherEmail.Text;
            lblnameofmother1.Text = txtMother.Text;
            //lbleducation12.Text = txtMotherEdu.Text;
            //lbloccupation12.Text = txtMotherOccu.Text;
            //lblmobileno12.Text = txtMotherMobile.Text;
            //lblemail12.Text = txtMotherEmail.Text;
           // objEWA.StudentPhoto = (byte[])ViewState["StudentPhoto"]; 
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
                objEWA.AdmissionID = txtFormNo.Text.ToString();

                objEWA.AdmissionDate = txtAdmissionDate.Text;
                objEWA.OrgID = Convert.ToInt32(DDL_SelectCollege.SelectedValue);

                objEWA.GRNo = txtGRNo.Text;
                objEWA.AdharNo = txtAdhar.Text;

                objEWA.FirstName = txtFirstName.Text.Trim();
                objEWA.MiddleName = txtMiddleName.Text.Trim();
                objEWA.LastName = txtLastName.Text.Trim();

                objEWA.Course = ddlCourse.SelectedValue.Trim().Trim();
                objEWA.Branch_ID = Convert.ToInt32(ddlBranch.SelectedValue);
                objEWA.Class1 = ddlClass.SelectedValue.Trim().Trim();
                objEWA.BirthDate = txtBirthDate.Text;
                objEWA.BirthPlace = txtBirthPlace.Text.Trim();
                objEWA.Country1 = ddlCountry.SelectedValue.ToString();
                objEWA.State1 = ddlState.SelectedValue.ToString();
                objEWA.District1 = ddlDistrict.SelectedValue.ToString();
                objEWA.Taluka1 = txtTal.Text.Trim();
                objEWA.City1 = txtCity.Text.Trim();
                objEWA.LastInstitute = txtLastSchool.Text.Trim();
                objEWA.Gender1 = rbtGender.SelectedItem.ToString();
                objEWA.BloodGroup = ddlBloodGroup.SelectedValue.ToString();
                objEWA.Religion1 = ddlReligion.SelectedValue.ToString();
                objEWA.Subcaste = txtSubcaste.Text;
                objEWA.MotherTongue = txtMotherTongue.Text;
                objEWA.Nationality1 = ddlNationality.SelectedValue.ToString();
                objEWA.AddressLine1 = txtAddress1.Text.Trim();
                objEWA.AddressLine2 = txtAddress2.Text.Trim();
                objEWA.FeesCategory = ddlFeeCategory.SelectedValue.ToString().Trim();
                objEWA.CasteCategory = ddlCaste.SelectedValue.Trim();

                objEWA.ParentName = txtFather.Text.Trim();
                objEWA.MotherName = txtMother.Text.Trim();

                objEWA.ParentMobile = txtFatherMobile.Text.Trim();
                objEWA.ParentEmail = txtFatherEmail.Text.Trim();

                objEWA.Parent_Education = txtFatherEdu.Text.Trim();
                objEWA.Parent_Occupation = txtFatherOccu.Text.Trim();

                objEWA.MobileNo = txtFatherMobile.Text.Trim();
                objEWA.E_Mail = txtFatherEmail.Text.Trim();
                objEWA.AdmissionYear = System.DateTime.Now.ToString("yyyy");
                objEWA.GuardianName = txtMother.Text.ToString();
                objEWA.Relation1 = "Mother";

                objEWA.GuardianMobile = txtMotherMobile.Text.Trim();
                objEWA.GuardianEmail = txtMotherEmail.Text.Trim();

                objEWA.Guardian_Education = txtMotherEdu.Text.Trim();
                objEWA.Guardian_Occupation = txtMotherOccu.Text.Trim();

                // Panel Parent information

                objEWA.StudentUserName = txtFormNo.Text.Trim();

                objEWA.StudentPassword = txtFormNo.Text.Trim();

                // Iamage Store
                int length = 0;
                byte[] imgPhotobyte = null;

                if (fileupload_StudentPhoto.HasFile)
                {
                    length = fileupload_StudentPhoto.PostedFile.ContentLength;
                    imgPhotobyte = new byte[length];
                    HttpPostedFile img1 = fileupload_StudentPhoto.PostedFile;
                    img1.InputStream.Read(imgPhotobyte, 0, length);
                    ViewState["StudentPhoto"] = imgPhotobyte;
                }
                GridToDatatable();
                objEWA.dtDocuments = ViewState["tempDocs"] as DataTable;
                objEWA.StudentPhoto = (byte[])ViewState["StudentPhoto"]; 

                objEWA.Status = "Pending";

                if (Session["GRNO"] != null)
                {
                    if (Session["GRNO"].ToString() == txtGRNo.Text)
                    {
                        //msgBox.ShowMessage("Record already present !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Form Submitted Successfully')", true);
                        ClearControls();
                        return;
                    }
                }
                else
                {
                    Session["GRNO"] = txtGRNo.Text;
                }

                    int flag = objBAL.InsertInto(objEWA);

                    if (flag > 0)
                    {
                        if (strAction == "Save")
                        {
                            //string strSMS = null;
                            //string strEmail = null;

                            // strEmail = SendEmails();
                            msgBox.ShowMessage("Form Submitted  Successfully", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                            print();
                            Button1.Visible = true;
                            btnSave.Visible = false;

                            // msgBox.ShowMessage(strSMS, "Saved", UserControls.MessageBox.MessageStyle.Successfull);

                            // msgBox.ShowMessage(strEmail, "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Form Sumitted  Successfully Check Your Mail  !!!')", true);

                            //  Response.Redirect("~/College_Home.aspx");
                            ClearControls();
                            // Response.Redirect("~/Forms/Admin/College_Home.aspx");
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
               // throw;
            }
        }

        #endregion Save Admission

        //Send EMail

        #region SendeMailRegion

        private string SendEmails()
        {
            string stringResult = null;
            string mailFrom = Convert.ToString("Schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
           // string mailFrom = WebConfigurationManager.AppSettings["mail"];
            //string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(txtFatherEmail.Text);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Admission Process";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Dear " + txtFirstName.Text + "  " + txtLastName.Text + "  \n  Your Admission Form Submitted Successfully \n Please Note Down Your  Application ID,  User Name And  Password \n Application ID :" + txtFormNo.Text + "\n UserName : '" + txtFormNo.Text + "' \n Thank You For Registraion !!";
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

            return stringResult;
            
        }

        #endregion SendeMailRegion

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
                        if (fileLengthInKB < 1024 && fileLengthInKB > 4)
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
                                Image1.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            objEWA.StudentPhoto = (byte[])ViewState["StudentPhoto"];
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

        #endregion Image Upload

        // Load State Drop Down

        #region [State Selected changed]

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlCity(); 
      

        }

        #endregion

        //Load City Drop Down
        #region[Load City]

        private void LoadCityDropDown(string p)
        {
            try
            {
                ddlDistrict.Items.Insert(0, new ListItem(" Select ", "0"));

                if (ddlState.SelectedValue.Equals("Select") && ddlState.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select State First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    ddlDistrict.DataTextField = "name";
                    ddlDistrict.DataValueField = "id";
                    DataSet ds = ViewState["DatasetAll"] as DataSet;

                    DataView dv = new DataView(ds.Tables["City"]);
                    dv.RowFilter = "sid = " + p;
                    ddlDistrict.DataSource = dv.ToTable();
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
                }
            }
            catch (Exception exp)
            {
                ddlDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Grid Date Data To DataTable
        #region[Grid To DataTable]

        protected void GridToDatatable()
        {
            try
            {
                DataTable dtDocs = new DataTable();
                dtDocs.Columns.Add("DocumentId");
                dtDocs.Columns.Add("DocumentName");
                dtDocs.Columns.Add("DocumentType");
                CheckBox chkbx = new CheckBox();

                foreach (GridViewRow grw in GrdDocumnet.Rows)
                {
                    chkbx = grw.Cells[0].FindControl("checkbox") as CheckBox;
                    if (chkbx.Checked == true)
                    {
                        string documentID = (grw.Cells[1].FindControl("lblDocumentId") as Label).Text;
                        string documentName = grw.Cells[2].Text;
                        string documentType = grw.Cells[3].Text;

                        dtDocs.Rows.Add(documentID, documentName, documentType);
                    }
                }
                ViewState["tempDocs"] = dtDocs;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        public void ClearControls()
        {
            txtFormNo.Text = "";

            txtAdmissionDate.Text = "";
            txtAdhar.Text = string.Empty;
            txtGRNo.Text = "";
            txtCity.Text = string.Empty;
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";

            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            ddlClass.ClearSelection();
            
            txtBirthDate.Text = "";
            txtBirthPlace.Text = "";
            ddlCountry.ClearSelection();
            ddlState.ClearSelection();
            ddlDistrict.ClearSelection();
            txtTal.Text = "";
            ddlDistrict.ClearSelection();
            txtLastSchool.Text = "";
            rbtGender.ClearSelection();
            ddlBloodGroup.ClearSelection();
            ddlReligion.ClearSelection();
            txtMotherTongue.Text = "";
            ddlNationality.ClearSelection();
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            ddlFeeCategory.ClearSelection();
            ddlCaste.ClearSelection();
            txtFather.Text = "";
            txtMother.Text = "";
            txtFatherMobile.Text = "";
            txtFatherEmail.Text = "";
            txtFatherEdu.Text = "";
            txtFatherOccu.Text = "";
            txtFatherMobile.Text = "";
            txtFatherEmail.Text = "";
            txtMother.Text = "";
            txtMotherMobile.Text = "";
            txtMotherEmail.Text = "";
            txtMotherEdu.Text = "";
            txtMotherOccu.Text = "";

            txtFormNo.Text = "";

            txtFormNo.Text = "";
            ViewState["StudentPhoto"] = null;
            ViewState["tempDocs"] = null;
            img_StudentImage.ImageUrl = "~/images/userphoto.gif";
            int orgID = Convert.ToInt32(DDL_SelectCollege.SelectedValue);
            ds = objBAL.SelectData(orgID);
            txtFormNo.Text = DDL_SelectCollege.SelectedValue + "/" + ds.Tables[0].Rows[0][0].ToString();
            ds.Clear();

           
            GetFormLoadData(orgID);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
          
            ClearControls();
            Button1.Visible = false;
            btnSave.Visible = true;
        
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          
            ClearControls();
          
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DDL_SelectCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["OrgId"] = DDL_SelectCollege.SelectedValue;
            GetFormLoadData(Convert.ToInt32(DDL_SelectCollege.SelectedValue));
            Get_OrganizationDetails(Convert.ToInt32(DDL_SelectCollege.SelectedValue));

            
        }
        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {

                DataSet ds = objBL.Get_OrganizationDetails(OrgID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label lbl_CollegeName = this.Master.FindControl("lbl_CollegeName") as Label;
                    Label lbl_CollegeAddress = this.Master.FindControl("lbl_CollegeAddress") as Label;
                    Label Lbl_TrustName = this.Master.FindControl("Lbl_TrustName") as Label;
                    Image ImageButton_logo = this.Master.FindControl("ImageButton_logo") as Image;

                    string StaffPhoto = ds.Tables[0].Rows[0]["Logo"].ToString();
                    if (StaffPhoto != null && StaffPhoto != "")
                    {
                        Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ImageButton_logo.ImageUrl = "data:image/png;base64," + base64String;
                    }

                   

                    lbl_CollegeName.Text = ds.Tables[0].Rows[0][1].ToString();
                    lbl_CollegeAddress.Text = ds.Tables[0].Rows[0][12].ToString();
                    Lbl_TrustName.Text = ds.Tables[0].Rows[0][6].ToString();
                }
            }

            catch (Exception ex)
            {
                // GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        protected void rbtGender0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtLanguage.SelectedValue == "English")
            {
                Page.Validate("vg");
                btnSave.ValidationGroup = "vg";
            }
            else
            {
                Page.Validate("ab");
                btnSave.ValidationGroup = "ab";
            }
        }
    }
}
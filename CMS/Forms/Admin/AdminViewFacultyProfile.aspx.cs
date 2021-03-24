using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp.Faculty;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class AdminViewFacultyProfile : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //Objects
        #region[Objects]
        private EWA_Faculty objEWA = new EWA_Faculty();
        private BL_Faculty objBAL = new BL_Faculty();
        private BindControl ObjHelper = new BindControl();
        #endregion
        int OrgID = 0;
        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            //  Bind_ddlCountry();

            // Bind_ddlCountryPresent();
            try
            {
                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    txtDateOfJoining.Attributes.Add("ReadOnly", "True");
                    txtBirthDate.Attributes.Add("ReadOnly", "True");
                    //Bind_ddlCountry();
                    //Bind_ddlState1();
                    //Bind_ddlCity1();

                    Bind_ddlCountryPresent();
                    Bind_ddlStatePresent1();
                    Bind_ddlCityPresent1();
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                    objEWA.EmployeeId = Convert.ToInt32(Session["EmpUserCode"]);
                    BindDDLdata();

                    GetEmployeeRecord(objEWA.OrgId, objEWA.EmployeeId);
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform To Get Staff Detail For Update
        #region[Get Employee Record]

        private void GetEmployeeRecord(int OrgID, int EmployeeId)
        {
            DataSet ds;
            try
            {
                database db = new database();
                //objEWA.OrgId = OrgID;
                //objEWA.EmployeeId = EmployeeId;
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                objEWA.EmployeeId = Convert.ToInt32(Session["EmpUserCode"]);
                //To Show The Record of staff
                //ds = objBAL.BL_UpdateEMPRecord(objEWA);
                ds = objBAL.BL_GetEmployeeRecord(objEWA);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    lblStaffId.Text = ds.Tables[0].Rows[0]["UserCode"].ToString();
                    //lblStaffId.Text = "10";

                    //Personal Information
                    // txtDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                    // txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                    //  txtCourse.Text = ds.Tables[0].Rows[0]["Course"].ToString();
                    //tblStaff-FirstName,MiddleName,LastName
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtMiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    // string BirthDate = ds.Tables[0].Rows[0]["DOB"].ToString();
                    txtBirthDate.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB1"].ToString()).ToString("dd/MM/yyyy");
                    ddlbloodgroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    txtMaritalStatus.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

                    //Conatct Information
                    txtPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                    ddlPresentCountry.SelectedValue = db.getDbstatus_Value("Select CountryId From Country where  County='" + ds.Tables[0].Rows[0]["PresentCountry"].ToString() + "'");
                    ddlPresentStATE.SelectedValue = db.getDbstatus_Value("Select StateID From countryState where  State='" + ds.Tables[0].Rows[0]["PresentState"].ToString() + "'");
                    ddlPresentCity.SelectedValue = db.getDbstatus_Value("Select CityID From stateCity where  City='" + ds.Tables[0].Rows[0]["PresentCity"].ToString() + "'");
                    txtPresentPinCode.Text = ds.Tables[0].Rows[0]["PresentPinCode"].ToString();
                    //txtPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                    //ddlPermantCountry.SelectedItem.Text = ds.Tables[0].Rows[0]["PermanentCountry"].ToString();
                    //ddlPermantState.SelectedItem.Text = ds.Tables[0].Rows[0]["PermanentState"].ToString();
                    //ddlPermantCity.SelectedItem.Text = ds.Tables[0].Rows[0]["PermanentCity"].ToString();
                    //txtPermanentPinCode.Text = ds.Tables[0].Rows[0]["PermanentPinCode"].ToString();
                    txtPhoneNumber.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    //txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString(); 
                    ddlCastCategory.SelectedValue = db.getDbstatus_Value("Select CasteCategoryId From tblCasteCategory where  CasteCategoryName='" + ds.Tables[0].Rows[0]["CasteCategory"].ToString() + "' And OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "'"); 
                    txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    //txtWebsiteBlog.Text = ds.Tables[0].Rows[0]["WebsiteBlog"].ToString();
                    txtPanCardNo.Text = ds.Tables[0].Rows[0]["PanCardNo"].ToString();
                    txtDateOfJoining.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfJoining1"].ToString()).ToString("dd/MM/yyyy");

                    //Education Information
                    txtUGDegree.Text = ds.Tables[0].Rows[0]["UGDegree"].ToString();
                    txtPGDegree.Text = ds.Tables[0].Rows[0]["PGDegree"].ToString();
                    //txtDoctorateDegree.Text = ds.Tables[0].Rows[0]["DoctorateDegree"].ToString();
                    txtOtherQualification.Text = ds.Tables[0].Rows[0]["OtherQualification"].ToString();
                    txtSpecialization.Text = ds.Tables[0].Rows[0]["Specialization"].ToString();
                    txtTeachingExperience.Text = ds.Tables[0].Rows[0]["TeachingExperience"].ToString();
                    //txtIndustrialExperience.Text = ds.Tables[0].Rows[0]["IndustrialExperience"].ToString();
                    //txtResearchExperience.Text = ds.Tables[0].Rows[0]["ResearchExperience"].ToString();
                    //txtNationalPublication.Text = ds.Tables[0].Rows[0]["NationalPublication"].ToString();
                    //txtInternationalPublication.Text = ds.Tables[0].Rows[0]["InternationalPublication"].ToString();
                    //txtBookPublished.Text = ds.Tables[0].Rows[0]["BookPublished"].ToString();
                    //txtPatents.Text = ds.Tables[0].Rows[0]["Patents"].ToString();

                    //Other Information
                    //txtPFNumber.Text = ds.Tables[0].Rows[0]["PFNumber"].ToString();
                    txtBankAccountNumber.Text = ds.Tables[0].Rows[0]["BankAccountNumber"].ToString();
                    txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    txtBankBranchName.Text = ds.Tables[0].Rows[0]["BankBranchName"].ToString();
                    //txtBankIFSCCode.Text = ds.Tables[0].Rows[0]["BankIFSCCode"].ToString();

                    //  txtDepartment.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                    // txtDesignation.Text = ds.Tables[0].Rows[0]["DesignationName"].ToString();
                    //GrdCourse.DataSource = ds.Tables[];
                    //GrdCourse.DataBind();
                }

                //for Staff Logo
                string Photo = ds.Tables[0].Rows[0]["Photo"].ToString();

                if (Photo != null && Photo != "Photo")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                    ViewState["StudentPhoto"] = bytes;
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform To Update Staff Detail
        #region update button

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Update is the stored procedure Action name and Action is the method
                Action("UpdateProfile");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        
        public void Bind_ddlCountryPresent()
        {
            if (ddlPresentCountry.Items.Count <= 0)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlPresentCountry.DataSource = dr;
                ddlPresentCountry.Items.Clear();
                // ddlPresentCountry.Items.Add("--Please Select country--");
                ddlPresentCountry.DataTextField = "County";
                ddlPresentCountry.DataValueField = "CountryId";
                ddlPresentCountry.DataBind();
                cn.Close();
            }
            ddlPresentCountry.Items.Insert(0, new ListItem("--Please Select Country--", "0"));
        }


        public void Bind_ddlStatePresent()
        {
            cn.Open();

            SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + ddlPresentCountry.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentStATE.DataSource = dr;
            ddlPresentStATE.Items.Clear();
            // ddlPresentStATE.Items.Add("--Please Select state--");
            ddlPresentStATE.DataTextField = "State";
            ddlPresentStATE.DataValueField = "StateID";
            ddlPresentStATE.DataBind();
            cn.Close();
            ddlPresentStATE.Items.Insert(0, new ListItem("--Please Select State--", "0"));

        }
        public void Bind_ddlStatePresent1()
        {
            cn.Open();

            SqlCommand cmd = new SqlCommand("select State,StateID from countryState ", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentStATE.DataSource = dr;
            ddlPresentStATE.Items.Clear();
            // ddlPresentStATE.Items.Add("--Please Select state--");
            ddlPresentStATE.DataTextField = "State";
            ddlPresentStATE.DataValueField = "StateID";
            ddlPresentStATE.DataBind();
            cn.Close();
            ddlPresentStATE.Items.Insert(0, new ListItem("--Please Select State--", "0"));

        }
        public void Bind_ddlCityPresent()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict where StateId ='" + ddlPresentStATE.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentCity.DataSource = dr;
            ddlPresentCity.Items.Clear();
            //ddlPresentCity.Items.Add("--Please Select city--");
            ddlPresentCity.DataTextField  = "District";
            ddlPresentCity.DataValueField = "DistrictId";
            ddlPresentCity.DataBind();
            cn.Close();
            ddlPresentCity.Items.Insert(0, new ListItem("--Please Select City--", "0"));

        }
        public void Bind_ddlCityPresent1()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict ", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlPresentCity.DataSource = dr;
            ddlPresentCity.Items.Clear();
            //ddlPresentCity.Items.Add("--Please Select city--");
            ddlPresentCity.DataTextField  = "District";
            ddlPresentCity.DataValueField = "DistrictId";
            ddlPresentCity.DataBind();
            cn.Close();
            ddlPresentCity.Items.Insert(0, new ListItem("--Please Select City--", "0"));

        }


        #region[Bind DDL]

        private void BindDDLdata()
        {
            try
            {
                BL_Common objBL = new BL_Common();
                // DataSet ds = null;

                //ds = objBL.BindCasteCategory_BL();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select  CasteCategoryName ,CasteCategoryId from tblCasteCategory where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'", cn);

                SqlDataReader dr = cmd.ExecuteReader();
                ddlCastCategory.DataSource = dr;

                ddlCastCategory.DataTextField = "CasteCategoryName";
                ddlCastCategory.DataValueField = "CasteCategoryId";
                ddlCastCategory.DataBind();
                ddlCastCategory.Items.Insert(0, new ListItem("Select", "0"));
                cn.Close();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform To Action for update Staff
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "UpdateProfile")
                {
                    objEWA.EmployeeId = Convert.ToInt32(Session["EmpUserCode"]);

                    //Personal Information
                    objEWA.FirstName = txtFirstName.Text;
                    objEWA.MiddleName = txtMiddleName.Text;
                    objEWA.LastName = txtLastName.Text;
                    objEWA.MotherName = txtMotherName.Text;
                    objEWA.Gender = txtGender.Text;
                    objEWA.BirthDate =txtBirthDate.Text;
                    objEWA.BloodGroup = ddlbloodgroup.Text;
                    objEWA.MaritalStatus = txtMaritalStatus.Text;

                    //Contact Information
                    objEWA.PresentAddress = txtPresentAddress.Text;
                    objEWA.PresentCountry = ddlPresentCountry.SelectedItem.ToString();
                    objEWA.PresentState = ddlPresentStATE.SelectedItem.ToString();
                    objEWA.PresentCity = ddlPresentCity.SelectedItem.ToString();
                    objEWA.PresentPinCode = txtPresentPinCode.Text;
                    //objEWA.PermanentAddress = txtPermanentAddress.Text;
                    //objEWA.PermanentCountry = ddlPermantCountry.SelectedItem.ToString();
                    //objEWA.PermanentState = ddlPermantState.SelectedItem.ToString();
                    //objEWA.PermanentCity = ddlPermantCity.SelectedItem.ToString(); 
                    //objEWA.PermanentPincode = txtPermanentPinCode.Text;
                    objEWA.PhoneNo = txtPhoneNumber.Text;
                    objEWA.Mobile = txtMobile.Text;
                    //objEWA.Fax = txtFax.Text;
                    objEWA.Email = txtEmail.Text;
                    objEWA.CasteCategory = ddlCastCategory.SelectedItem.ToString();
                    objEWA.Nationality = txtNationality.Text;
                    //objEWA.WebsiteBlog = txtWebsiteBlog.Text;
                    objEWA.PancardNo = txtPanCardNo.Text;
                    objEWA.DateoOfJoining =txtDateOfJoining.Text;

                    //Education Information
                    objEWA.UGDegree = txtUGDegree.Text;
                    objEWA.PGDegree = txtPGDegree.Text;
                    //objEWA.Doctoratedegree = txtDoctorateDegree.Text;
                    objEWA.OtherQualificaton = txtOtherQualification.Text;
                    objEWA.Specialization = txtSpecialization.Text;
                    objEWA.TeachingExperience = txtTeachingExperience.Text;
                    //objEWA.IndustrialExperience = txtIndustrialExperience.Text;
                    //objEWA.ResearchExperience = txtResearchExperience.Text;
                    //objEWA.NationalPublication = txtNationalPublication.Text;
                    //objEWA.InternationalPublication = txtInternationalPublication.Text;
                    //objEWA.BooksPublished = txtBookPublished.Text;
                    //objEWA.Patents = txtPatents.Text;

                    //Other Information
                    //objEWA.PFNumber = txtPFNumber.Text;
                    objEWA.BankAccountNumber = txtBankAccountNumber.Text;
                    objEWA.BankName = txtBankName.Text;
                    objEWA.BankBranchName = txtBankBranchName.Text;
                    //objEWA.BankIFSCCode = txtBankIFSCCode.Text;

                    int length = 0;
                    byte[] imgSignbyte = null;
                    byte[] imgPhotobyte = null;

                    if (fileupload1.HasFile)
                    {
                        length = fileupload1.PostedFile.ContentLength;
                        imgPhotobyte = new byte[length];
                        HttpPostedFile img1 = fileupload1.PostedFile;
                        img1.InputStream.Read(imgPhotobyte, 0, length);
                        ViewState["StudentPhoto"] = imgPhotobyte;
                        string base64String = Convert.ToBase64String(imgPhotobyte, 0, imgPhotobyte.Length);
                        img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                    }



                    objEWA.Photo = (byte[])ViewState["StudentPhoto"];
                    //  objEWA.Photo=

                    //Below Values Need to be pass from session
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                    int flag = objBAL.BL_UpdateFaculty(objEWA);

                    if (flag > 0)
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else
                    {
                        if (strAction == "Update")
                        {
                            msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        }
                    }
                }
            }

            //catch (System.Data.SqlClient.SqlException exp)
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform To Clear the all textboxes
        #region[Clear Controls]

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //Personal Information
                // txtDepartment.Text = "";
                // txtDesignation.Text = "";
                txtFirstName.Text = "";
                txtMiddleName.Text = "";
                txtLastName.Text = "";
                txtMotherName.Text = "";
                txtGender.Text = "";
                txtBirthDate.Text = "";
                // ddlbloodgroup.Text = "";
                txtMaritalStatus.Text = "";

                //Contact Information
                txtPresentAddress.Text = "";
                //  ddlPresentCountry.Text = "";
                //  ddlPresentStATE.Text = "";
                //  ddlPresentCity.Text = "";
                txtPresentPinCode.Text = "";
                //txtPermanentAddress.Text = "";
                //   ddlPermantCountry.Text = "";
                //   ddlPermantState.Text = "";
                //   ddlPermantCity.Text = "";
                //txtPermanentPinCode.Text = "";
                txtPhoneNumber.Text = "";
                txtMobile.Text = "";
                //txtFax.Text = "";
                txtEmail.Text = "";
                //  ddlCastCategory.Text = "";
                txtNationality.Text = "";
                //txtWebsiteBlog.Text = "";
                txtPanCardNo.Text = "";
                txtDateOfJoining.Text = "";

                //Educational Information
                txtPGDegree.Text = "";
                txtUGDegree.Text = "";
                //txtDoctorateDegree.Text = "";
                txtOtherQualification.Text = "";
                txtSpecialization.Text = "";
                txtTeachingExperience.Text = "";
                //txtIndustrialExperience.Text = "";
                //txtResearchExperience.Text = "";
                //txtNationalPublication.Text = "";
                //txtInternationalPublication.Text = "";
                //txtBookPublished.Text = "";
                // txtPatents.Text = "";

                //Other Information
                //txtPFNumber.Text = "";
                txtBankAccountNumber.Text = "";
                txtBankName.Text = "";
                txtBankBranchName.Text = "";
                //txtBankIFSCCode.Text = "";
            }
            catch (Exception exp)
            {
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

        //protected void ddlPermantCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Bind_ddlState();
        //}

        //protected void ddlPermantState_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Bind_ddlCity(); 
        //}

        protected void ddlPermantCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPresentCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPresentStATE_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlCityPresent();
        }

        protected void ddlPresentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlStatePresent();
        }

        protected void ddlCastCategory_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                int length = 0;
                byte[] imgPhotobyte = null;
                string fileName = fileupload1.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);
                string fileMimeType = fileupload1.PostedFile.ContentType;
                int fileLengthInKB = fileupload1.PostedFile.ContentLength / 1024;
                string[] matchExtension = { ".jpg", ".png", ".gif" };
                string[] matchMimeType = { "image/jpeg", "image/png", "image/gif" };

                if (fileupload1.HasFile)
                {

                    if (fileLengthInKB < 1024 && fileLengthInKB > 4)
                    {
                        lblFileuploadError.Enabled = false;
                        if (fileupload1.HasFile)
                        {
                            length = fileupload1.PostedFile.ContentLength;
                            imgPhotobyte = new byte[length];
                            HttpPostedFile img1 = fileupload1.PostedFile;
                            img1.InputStream.Read(imgPhotobyte, 0, length);
                            ViewState["StudentPhoto"] = imgPhotobyte;
                            string base64String = Convert.ToBase64String(imgPhotobyte, 0, imgPhotobyte.Length);
                            img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                            img_StudentImage.Visible = true;
                        }
                        objEWA.Photo = (byte[])ViewState["StudentPhoto"];
                    }
                    else
                    {
                        //Please choose a file less than 1MB
                        lblFileuploadError.Enabled = true;
                    }

                    //else
                    //{

                    //    lblFileuploadError.Enabled = true;
                    //}
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchFaculty.aspx");
        }
    }
}
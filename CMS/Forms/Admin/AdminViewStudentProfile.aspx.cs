using BusinessAccessLayer.Admin;
using BusinessAccessLayer.Student;
using DataAccessLayer;
using EntityWebApp.Admin;
using EntityWebApp.Student;
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
    public partial class AdminViewStudentProfile : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //Object Declaration
        public static int orgId = 0;
        #region Objects
        private BindControl ObjHelper = new BindControl();
        DataSet ds = new DataSet();
        BL_StudentProfile objBAL = new BL_StudentProfile();
        EWA_StudentProfile objEWA = new EWA_StudentProfile();
        database db = new database();
        string _strAction = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {

                if (!IsPostBack)
                {
                    //if (Session["OrgId"] == null)
                    //{
                    //    Response.Redirect("/CMSHome.aspx");
                    //}
                    objEWA.OrgId = Session["OrgId"].ToString();

                    txtBirthDate.Attributes.Add("ReadOnly", "True");
                    //ds = new DataSet();
                    //ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
                    //ViewState["DatasetAll"] = ds;
                    //LoadCountryDropDown();
                    //LoadSportDropDown();
                    LoadCasteCategoryDropDown();
                    Bind_ddlCountry();
                    Bind_ddlState1();

                    BL_FeesCategory objBL = new BL_FeesCategory();
                    EWA_FeesCategory objEWA1 = new EWA_FeesCategory();
                    objEWA1.OrgId = Convert.ToInt32(Session["OrgId"]);
                    DataSet ds = objBL.FeesCategoryGridBind_BL(objEWA1);
                    ddlFeesCategory.DataSource = ds;
                    ddlFeesCategory.DataTextField = "FeesCategoryName";
                    ddlFeesCategory.DataValueField = "FeesCategoryId";
                    ddlFeesCategory.DataBind();
                    ddlFeesCategory.Items.Insert(0, new ListItem("Select","0"));



                    ShowStudentProfile(objEWA);

                    SqlCommand cmd1 = new SqlCommand("select Photo from tblStudent where OrgId='" + Session["OrgId"].ToString() + "' and UserCode='" + Session["StusUserCode"].ToString() + "'", cn);
                    SqlDataAdapter adp1 = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();
                    adp1.SelectCommand = cmd1;
                    adp1.Fill(ds1);
                    //lblTrustName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();

                    string Photo = ds1.Tables[0].Rows[0]["Photo"].ToString();// db.getDbstatus_Value("select Photo from tblStudent where OrgId='" + Session["OrgId"].ToString() + "' and UserCode='" + Session["UserCode"].ToString() + "'");



                    if (Photo != "0" && Photo != "")
                    {
                        Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Photo"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                        ViewState["StudentPhoto"] = bytes;
                        txtimg.Text = "Done";
                    }
                }

            }
        }

        public void Bind_ddlCountry()
        {

            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlStudentCountry.DataSource = dr;

            ddlStudentCountry.Items.Clear();



            // ddlcountry.Items.Add("--Please Select country--");
            ddlStudentCountry.DataTextField = "County";
            ddlStudentCountry.DataValueField = "CountryId";
            ddlStudentCountry.DataBind();
            cn.Close();

            ddlStudentCountry.Items.Insert(0, new ListItem("--Please Select Country--", "0"));

        }

        public void Bind_ddlState()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + ddlStudentCountry.SelectedValue + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlStudentState.DataSource = dr;
            ddlStudentState.Items.Clear();

            ddlStudentState.DataTextField = "State";
            ddlStudentState.DataValueField = "StateID";
            ddlStudentState.DataBind();
            cn.Close();

            ddlStudentState.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        }


        public void Bind_ddlState1()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select State,StateID from countryState", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlStudentState.DataSource = dr;
            ddlStudentState.Items.Clear();

            ddlStudentState.DataTextField = "State";
            ddlStudentState.DataValueField = "StateID";
            ddlStudentState.DataBind();
            cn.Close();

            ddlStudentState.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        }

        private void ShowStudentProfile(EWA_StudentProfile objEWA)
        {
            DataSet ds;
            try
            {

                objEWA.UserCode = Session["StusUserCode"].ToString();
                objEWA.OrgId = Session["OrgId"].ToString();
                ds = objBAL.BL_ShowStudentProfile(objEWA);
                ViewState["UserCode"] = ds.Tables[0].Rows[0]["UserCode"].ToString();

                //Personal Information
                txtStudentId.Text= ds.Tables[0].Rows[0]["SaralId"].ToString();
                txtGRNO.Text= ds.Tables[0].Rows[0]["GRNo"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                rbtGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                txtBirthDate.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                txtBirthPlace.Text = ds.Tables[0].Rows[0]["BirthPlace"].ToString();
                txtBloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                txtRollNo.Text = ds.Tables[0].Rows[0]["StudentId"].ToString();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtStudentEmail.Text = ds.Tables[0].Rows[0]["EMail"].ToString();
                //rbtMarriedStatus.SelectedValue = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();               
                txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                txtHandicaped.Text = ds.Tables[0].Rows[0]["Handicap"].ToString();
                ddlReligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                ddlCasteCategory.SelectedValue = ds.Tables[0].Rows[0]["CasteCategoryId"].ToString();
                ddlFeesCategory.SelectedValue = ds.Tables[0].Rows[0]["FeesCategory"].ToString();
                txtSubCaste.Text = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                


                //Contact Information
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                // ddlStudentCountry.Items.FindByText(ds.Tables[0].Rows[0]["Country"].ToString()).Selected = true;              
                txtStudentTaluka.Text = ds.Tables[0].Rows[0]["Taluka"].ToString();


                //string city;
                //city = ds.Tables[0].Rows[0]["City"].ToString();
                txtStudentCity.Text = ds.Tables[0].Rows[0]["City"].ToString();//db.getDbstatus_Value("select City from stateCity where CityId='" + city + "'");



                
                //Academic Information
                txtCourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                txtBranch1.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                txtAcademicYear.Text = ds.Tables[0].Rows[0]["AcademicYear"].ToString();
                
                txtAdharNo.Text = ds.Tables[0].Rows[0]["AdharNo"].ToString();
                ddlStudentCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryID"].ToString();
                Bind_ddlState();
                ddlStudentState.SelectedValue = ds.Tables[0].Rows[0]["StateId"].ToString();
                Bind_ddlCity();
                ddlStudentDistrict.SelectedValue = ds.Tables[0].Rows[0]["DistrictId"].ToString();
                //Other Information
                //txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                ////txtBranch.Text = ds.Tables[0].Rows[0]["Branch"].ToString();
                //txtIFSCCode.Text = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                //txtAccountNo.Text = ds.Tables[0].Rows[0]["BankAccountNo"].ToString();
            }
            catch (Exception exp)
            {
                // throw exp;
            }
        }


        // Save Update Form 

        #region  Update 

        private void UpdateDetails(string strAction)
        {

            try
            {
                EWA_StudentProfile objEWA = new EWA_StudentProfile();
                objEWA.Action = strAction.ToString();
                objEWA.UserCode = ViewState["UserCode"].ToString();
                objEWA.OrgId = Session["OrgId"].ToString();

                objEWA.StudentId = txtStudentId.Text.Trim();
                objEWA.GRNo = txtGRNO.Text.Trim();
                objEWA.FirstName = txtFirstName.Text;
                objEWA.MiddleName = txtMiddleName.Text;
                objEWA.LastName = txtLastName.Text;
                objEWA.Gender = rbtGender.SelectedValue.ToString();
                objEWA.BirthDate = txtBirthDate.Text;
                objEWA.BirthPlace = txtBirthPlace.Text;

                objEWA.StudentMobile = txtMobileNo.Text;
                objEWA.StudentEMail = txtStudentEmail.Text;
                objEWA.BloodGroup = txtBloodGroup.Text;
                objEWA.Handicaped = txtHandicaped.Text;
                //objEWA.MarriedStatus = rbtMarriedStatus.SelectedValue.ToString();
                objEWA.Religion = ddlReligion.SelectedItem.ToString();
                objEWA.CasteCategoryId = ddlCasteCategory.SelectedValue.ToString();
                objEWA.FeesCategoryId = ddlFeesCategory.SelectedValue.ToString();
                objEWA.SubCaste = txtSubCaste.Text;

                objEWA.StudentAddress = txtAddress.Text;
                objEWA.StudentCountry = ddlStudentCountry.SelectedValue;
                objEWA.StudentState = ddlStudentState.SelectedValue;
                objEWA.StudentDistrict = ddlStudentDistrict.SelectedValue;
                objEWA.StudentTaluka = txtStudentTaluka.Text;
                objEWA.StudentCity = txtStudentCity.Text;
                objEWA.AdharNo = txtAdharNo.Text;


                // Panel Parent information

                //objEWA.ParentName = txtParentName.Text;
                //objEWA.MotherName = txtMotherName.Text;
                //objEWA.ParentAddress = txtParentAddress.Text;
                //objEWA.ParentCountry = ddlParentCountry.SelectedValue;
                //objEWA.ParentState = ddlParentState.SelectedValue;
                //objEWA.ParentDistrict = ddlStudentDistrict.SelectedValue;
                //objEWA.ParentTaluka = txtParentTaluka.Text;
                //objEWA.ParentPinCode = txtParentPinCode.Text;
                //objEWA.ParentMobile = txtParentMobileNo.Text;
                //objEWA.ParentEmail = txtParentEmail.Text;                

                //// Panel Last Institute information

                //objEWA.LastClass = txtLastClass.Text;                
                //objEWA.LastInstitute = txtLastInstitute.Text;
                //objEWA.LastQualifiedExam = txtQualifiedExam.Text;
                // objEWA.SeatNo = txtSeatNo.Text;               
                // objEWA.PassingMonth = txtPassingMonth.Text;
                // objEWA.PassingYear = txtPassingYear.Text;
                // objEWA.Percentage = txtPercentage.Text;
                // objEWA.Result = txtResult.Text;


                //objEWA.BankName= txtBankName.Text; 
                // objEWA.Branch= txtBranch1.Text ;
                // objEWA.IFSCCode= txtIFSCCode.Text ;
                // objEWA.BankAccountNo = txtAccountNo.Text;
                // objEWA.TcNo = txtTcNo.Text;
                // objEWA.SportId = ddlSport.SelectedValue.ToString();
                //objEWA.AdharNo = txtAdharNo.Text;

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
                    string base64String = Convert.ToBase64String(imgPhotobyte, 0, imgPhotobyte.Length);
                    img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                }

                objEWA.StudentPhoto = (byte[])ViewState["StudentPhoto"];

                //if (fileupload_StudentSign.HasFile)
                //{
                //    length = fileupload_StudentSign.PostedFile.ContentLength;
                //    imgSignbyte = new byte[length];
                //    HttpPostedFile img1 = fileupload_StudentSign.PostedFile;
                //    img1.InputStream.Read(imgSignbyte, 0, length);
                //    ViewState["StudentSign"] = imgSignbyte;
                //}
                //objEWA.StudentSign = (byte[])ViewState["StudentSign"];          

                int flag = objBAL.UpdateStudent(objEWA);
                if (flag > 0)
                {

                    if (strAction == "Update")
                    {
                        _strAction = "Record Updated Successfully!!!";
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }

                }

            }
            catch (Exception exp)
            {
                //throw exp;

            }
        }
        #endregion

        //  Personal Information Bind Country State District to DropDown List

        #region[Load Country Drop down]

        private void LoadCountryDropDown()
        {
            try
            {
                ddlStudentCountry.DataTextField = "name";
                ddlStudentCountry.DataValueField = "id";
                DataSet ds = ViewState["DatasetAll"] as DataSet;
                ddlStudentCountry.DataSource = ds.Tables["Country"];
                ddlStudentCountry.DataBind();
                ddlStudentCountry.Items.Insert(0, new ListItem(" Select ", "0"));



                //ddlParentCountry.DataTextField = "name";
                //ddlParentCountry.DataValueField = "id";

                //ddlParentCountry.DataSource = ds.Tables["Country"];
                //ddlParentCountry.DataBind();
                //ddlParentCountry.Items.Insert(0, new ListItem(" Select ", "0"));



            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country Changed
        #region[Country Changed]

        protected void ddlStudentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            //ddlStudentState.Items.Insert(0, new ListItem(" Select ", "0"));
            //ddlStudentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
            //try
            //{
            //    LoadStateDropDown(ddlStudentCountry.SelectedValue);
            //}

            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}

            Bind_ddlState();
        }

        private void LoadStateDropDown(string cid)
        {
            try
            {
                ddlStudentState.DataTextField = "name";
                ddlStudentState.DataValueField = "cid";
                DataSet ds = ViewState["DatasetAll"] as DataSet;

                DataView dv = new DataView(ds.Tables["State"]);

                dv.RowFilter = "cid = " + cid;
                ddlStudentState.DataSource = dv.ToTable();
                ddlStudentState.DataBind();
                ddlStudentState.Items.Insert(0, new ListItem(" Select ", "0"));

                //ddlParentState.DataTextField = "name";
                //ddlParentState.DataValueField = "cid";
                //dv.RowFilter = "cid = " + cid;
                //ddlParentState.DataSource = dv.ToTable();
                //ddlParentState.DataBind();
                //ddlParentState.Items.Insert(0, new ListItem(" Select ", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Country Changed
        #region[Country Changed]

        //protected void ddlParentCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    ddlParentState.Items.Insert(0, new ListItem(" Select ", "0"));
        //    ddlParentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
        //    try
        //    {
        //        LoadStateDropDown(ddlParentCountry.SelectedValue);
        //    }

        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion


        private void LoadCityDropDown(string p)
        {
            try
            {

                ddlStudentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));

                if (ddlStudentState.SelectedValue.Equals("Select") && ddlStudentState.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select State First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    ddlStudentDistrict.DataTextField = "name";
                    ddlStudentDistrict.DataValueField = "id";
                    DataSet ds = ViewState["DatasetAll"] as DataSet;

                    DataView dv = new DataView(ds.Tables["City"]);
                    dv.RowFilter = "sid = " + p;
                    ddlStudentDistrict.DataSource = dv.ToTable();
                    ddlStudentDistrict.DataBind();
                    ddlStudentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));


                    //ddlParentDistrict.DataTextField = "name";
                    //ddlParentDistrict.DataValueField = "id";
                    //dv.RowFilter = "sid = " + p;
                    //ddlParentDistrict.DataSource = dv.ToTable();
                    //ddlParentDistrict.DataBind();
                    //ddlParentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
                }
            }
            catch (Exception exp)
            {
                ddlStudentDistrict.Items.Insert(0, new ListItem(" Select ", "0"));
                GeneralErr(exp.Message.ToString());
            }
        }


        #endregion


        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion


        private void LoadCasteCategoryDropDown()
        {

            ds = objBAL.BindCasteCategory_BL(objEWA);
            ddlCasteCategory.DataSource = ds;
            ddlCasteCategory.DataTextField = "CasteCategoryName";
            ddlCasteCategory.DataValueField = "CasteCategoryId";
            ddlCasteCategory.DataBind();
            ddlCasteCategory.Items.Insert(0, new ListItem("Select", "0"));

        }

        protected void ddlStudentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Bind_ddlCity();
            }
            catch (Exception ex) { }
        }

        public void Bind_ddlCity()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict where StateId ='" + ddlStudentState.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlStudentDistrict.DataSource = dr;
            ddlStudentDistrict.Items.Clear();

            ddlStudentDistrict.DataTextField = "District";
            ddlStudentDistrict.DataValueField = "DistrictID";
            ddlStudentDistrict.DataBind();
            cn.Close();

            ddlStudentDistrict.Items.Insert(0, new ListItem("Select District", "0"));
        }

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
                        if (fileLengthInKB < 1024 )
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
                                txtimg.Text = "Done";
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

        protected void btnUpdateEducationDetails_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    UpdateDetails("Update");
                }
            }
            catch (Exception exp)
            {
                // throw exp;

            }
        }

        protected void btnUpdateOtherDetails_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    UpdateDetails("Update");
                }
            }
            catch (Exception exp)
            {
                //throw exp;

            }
        }

        protected void btnUpdatePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    UpdateDetails("Update");
                    msgBox.ShowMessage(_strAction, "Information", UserControls.MessageBox.MessageStyle.Successfull);
                    
                }
            }
            catch (Exception exp)
            {
                // throw exp;

            }
        }

        protected void btnUpdateParentDetails_Click1(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    UpdateDetails("Update");
                }
            }
            catch (Exception exp)
            {
                // throw exp;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }
    }
}
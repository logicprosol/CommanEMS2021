using System;
using System.Data;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp.Faculty;

//View Staff Profile
namespace CMS.Forms.Faculty
{
    public partial class ViewStaffProfile : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BindControl ObjHelper = new BindControl();
        private DataSet ds = new DataSet();
        private BL_Faculty objBAL = new BL_Faculty();
        private EWA_Faculty objEWA = new EWA_Faculty();
        #endregion
        int OrgID = 0;
        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    //objEWA.OrgId=(int)Session["OrgId"];
                    //objEWA.UserName=(string)Session["UserName"];
                    // objEWA.Usertype = (string)Session["UserType"];
                    // objEWA.UserTypeId = 1;
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                    objEWA.StaffId = Convert.ToInt32(Session["UserCode"]);

                    
                    ShowFacultyProfile(objEWA);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Faculty Profile
        #region[Faculty Profile]

        private void ShowFacultyProfile(EWA_Faculty objEWA)
        {
            DataSet ds;
            try
            {
                ds = objBAL.BL_ShowFacultyProfile(objEWA);

                //Personal Information
                lblStaffId.Text = ds.Tables[0].Rows[0]["UserCode"].ToString();
                //lblDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                // lblFacultyType.Text = ds.Tables[0].Rows[0]["FacultyType"].ToString();
                // lblDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                //lblClass.Text = ds.Tables[0].Rows[0]["Course"].ToString();
                lblFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                lblMiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                lblLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                lblMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();

                lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                lblBirthDate.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                lblBloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                lblMaritalStatus.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
                //lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                //lblPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();

                //For Contact Information
                lblPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                lblPresentCountry.Text = ds.Tables[0].Rows[0]["PresentCountry"].ToString();
                lblPresentState.Text = ds.Tables[0].Rows[0]["PresentState"].ToString();
                lblPresentCity.Text = ds.Tables[0].Rows[0]["PresentCity"].ToString();
                lblPinCode.Text = ds.Tables[0].Rows[0]["PresentPinCode"].ToString();
                lblPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                lblPermamentCountry.Text = ds.Tables[0].Rows[0]["PermanentCountry"].ToString();
                lblPermanentState.Text = ds.Tables[0].Rows[0]["PermanentState"].ToString();
                lblPermanentCity.Text = ds.Tables[0].Rows[0]["PermanentCity"].ToString();
                lblPermanentPincode.Text = ds.Tables[0].Rows[0]["PermanentPincode"].ToString();
                //ImgPhoto.ImageUrl = ds.Tables[0].Rows[0][""].ToString();

                lblPhoneNo.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                lblCasteCategory.Text = ds.Tables[0].Rows[0]["CasteCategory"].ToString();
                lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                lblWebsiteBlog.Text = ds.Tables[0].Rows[0]["WebsiteBlog"].ToString();
                lblPanCardNo.Text = ds.Tables[0].Rows[0]["PanCardNo"].ToString();

                //For Education Qualification
                lblDateOfJoining.Text = ds.Tables[0].Rows[0]["DateOfJoining"].ToString();
                lblUGDegree.Text = ds.Tables[0].Rows[0]["UGDegree"].ToString();
                lblPGDegree.Text = ds.Tables[0].Rows[0]["PGDegree"].ToString();
                lblDoctorateDegree.Text = ds.Tables[0].Rows[0]["DoctorateDegree"].ToString();
                lblOtherQualification.Text = ds.Tables[0].Rows[0]["OtherQualification"].ToString();
                lblSpecialization.Text = ds.Tables[0].Rows[0]["Specialization"].ToString();
                lblTeachingExperience.Text = ds.Tables[0].Rows[0]["TeachingExperience"].ToString();
                // lblIndustrialExperience.Text = ds.Tables[0].Rows[0]["IndustrialExperience"].ToString();
                //lblReaserchExperience.Text = ds.Tables[0].Rows[0]["ReaserchExperience"].ToString();
                //lblNationalPublication.Text = ds.Tables[0].Rows[0]["NationalPublication"].ToString();
                // lblInternationalPublication.Text = ds.Tables[0].Rows[0]["InternationalPublication"].ToString();
                //lblBookPublished.Text = ds.Tables[0].Rows[0]["BookPublished"].ToString();
                //lblPatents.Text = ds.Tables[0].Rows[0]["Patents"].ToString();
                string StaffPhoto = ds.Tables[0].Rows[0]["Photo"].ToString();
                if (StaffPhoto != null && StaffPhoto != "")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    ImgStaff.ImageUrl = "data:image/png;base64," + base64String;
                }
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
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
using System;
using System.Data;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

//View Faculty
namespace CMS
{
    public partial class ViewFacultyProfile : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BindControl ObjHelper = new BindControl();
        private DataSet ds = new DataSet();
public static int orgId;
        public static int OrgID;
        public static string EmpCode;
        private BL_StaffView objBL = new BL_StaffView();
        private EWA_StaffView objEWA = new EWA_StaffView();
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                if (!IsPostBack)
                {
                    OrgID = Convert.ToInt32(Session["OrgId"]);
                    EmpCode = Convert.ToString(Session["UserCode"]);
                    //EmpCode =Convert.ToString(Request.QueryString["UserCode"]);
                    ShowSearchFaculty(OrgID, EmpCode);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Show Search Faculty
        #region[Search faculty]

        private void ShowSearchFaculty(int OrgID, string EmpCode)
        {
            try
            {
                DataSet ds;

                objEWA.OrgId = OrgID;
                objEWA.EmpCode = EmpCode;
               

                ds = objBL.BL_ViewFacultyData(objEWA);

                string strFirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                string strMiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                string strLastName = ds.Tables[0].Rows[0]["LastName"].ToString();

                //concatinate the FullName
                string strFullName = strFirstName + ' ' + strMiddleName + ' ' + strLastName;
                lblStaffName.Text = strFullName;

                lblEmpCode.Text = ds.Tables[0].Rows[0]["UserCode"].ToString();
                //lblDepartment.Text = ddlDepartment.SelectedItem.ToString();
                //lblDesignation.Text = ddlDesignation.SelectedItem.ToString();

                lblMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
                lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();

                string DateOfBirth = ds.Tables[0].Rows[0]["DOB"].ToString();

                DateTime DOB = Convert.ToDateTime(DateOfBirth);

                lblDBO.Text = DOB.ToShortDateString();

                lblBloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                lblMaritalStatus.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

                //for Faculty photo
                string Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString();

                if (Photo1 != null && Photo1 != "")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgStaff.ImageUrl = "data:image/png;base64," + base64String;
                }
                //Conatact Information
                lblPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                lblPresentCountry.Text = ds.Tables[0].Rows[0]["PresentCountry"].ToString();
                lblPresentState.Text = ds.Tables[0].Rows[0]["PresentState"].ToString();
                lblPresentCity.Text = ds.Tables[0].Rows[0]["PresentCity"].ToString();
                lblPresentPinCode.Text = ds.Tables[0].Rows[0]["PresentPinCode"].ToString();
                lblPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                lblPermanentCountry.Text = ds.Tables[0].Rows[0]["PermanentCountry"].ToString();
                lblPermanentState.Text = ds.Tables[0].Rows[0]["PermanentState"].ToString();
                lblPermanentCity.Text = ds.Tables[0].Rows[0]["PermanentCity"].ToString();
                lblPermanentPinCode.Text = ds.Tables[0].Rows[0]["PermanentPinCode"].ToString();
                lblPhoneNumber.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                lblCasteCategory.Text = ds.Tables[0].Rows[0]["CasteCategory"].ToString();
                lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                lblWebsiteBlog.Text = ds.Tables[0].Rows[0]["WebsiteBlog"].ToString();
                lblPanCardNo.Text = ds.Tables[0].Rows[0]["PanCardNo"].ToString();
                lblDateOfJoining.Text = ds.Tables[0].Rows[0]["DateOfJoining"].ToString();

                //Education Qualification
                lblUGDegree.Text = ds.Tables[0].Rows[0]["UGDegree"].ToString();
                lblPGDegree.Text = ds.Tables[0].Rows[0]["PGDegree"].ToString();
                lblDoctorateDegree.Text = ds.Tables[0].Rows[0]["DoctorateDegree"].ToString();
                lblOtherQualification.Text = ds.Tables[0].Rows[0]["OtherQualification"].ToString();
                lblSpecialization.Text = ds.Tables[0].Rows[0]["Specialization"].ToString();
                //lblTeachingExperience.Text = ds.Tables[0].Rows[0]["TeachingExperience"].ToString();
                //lblIndustrialExperience.Text = ds.Tables[0].Rows[0]["IndustrialExperience"].ToString();
                //lblResearchExperience.Text = ds.Tables[0].Rows[0]["ResearchExperience"].ToString();
                //lblNationalPublication.Text = ds.Tables[0].Rows[0]["NationalPublication"].ToString();
                //lblInternationalPublication.Text = ds.Tables[0].Rows[0]["InternationalPublication"].ToString();
                //lblBookPublished.Text = ds.Tables[0].Rows[0]["BookPublished"].ToString();
                //lblPatents.Text = ds.Tables[0].Rows[0]["Patents"].ToString();

                //Other Information
                lblPFNumber.Text = ds.Tables[0].Rows[0]["PFNumber"].ToString();
                lblBankAccountNumber.Text = ds.Tables[0].Rows[0]["BankAccountNumber"].ToString();
                lblBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                lblBankBranchName.Text = ds.Tables[0].Rows[0]["BankBranchName"].ToString();
                lblBankIFSCCode.Text = ds.Tables[0].Rows[0]["BankIFSCCode"].ToString();
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
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
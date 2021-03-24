using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using EntityWebApp;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
//Add New College
namespace CMS.Forms.SuperAdmin
{
    public partial class SuperAdmin_AddNewCollege : System.Web.UI.Page
    {

        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //objects
        #region[Objects]
        private DataSet ds;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int orgID1 = Get_orgID();

                    orgID1 = orgID1 + 1;
                    TxtOrgID.Text = orgID1.ToString();

                    int orgCode = Get_orgCode();
                    TxtOrgCode.Text = "CLG/" + orgCode + 1;

                    //ds = new DataSet();
                    //ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
                    //ViewState["DatasetAll"] = ds;
                   // LoadCountryDropDown();

                    BindUniversity();

                    Bind_ddlCountry();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        public void Bind_ddlCountry()
        {
            if (ddlcountry.Items.Count <= 0)
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlcountry.DataSource = dr;

                ddlcountry.Items.Clear();


              
               // ddlcountry.Items.Add("--Please Select country--");
                ddlcountry.DataTextField = "County";
                ddlcountry.DataValueField = "CountryId";
                ddlcountry.DataBind();
                cn.Close();
            }  
            ddlcountry.Items.Insert(0, new ListItem("--Please Select Country--", "0"));
        
        }

        public void Bind_ddlState()
        {
            
            cn.Open();
            SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + ddlcountry.SelectedValue + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlstate.DataSource = dr;
            ddlstate.Items.Clear();
          
            ddlstate.DataTextField = "State";
            ddlstate.DataValueField = "StateID";
            ddlstate.DataBind();
            cn.Close();
           
            ddlstate.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        }

        public void Bind_ddlCity()
        {
            
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict where StateId ='" + ddlstate.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlcity.DataSource = dr;
            ddlcity.Items.Clear();
        
            ddlcity.DataTextField = "District";
            ddlcity.DataValueField = "DistrictId";
            ddlcity.DataBind();
            cn.Close();
            
            ddlcity.Items.Insert(0, new ListItem("--Please Select District--", "0"));
        } 
     

        //Bind University
        #region[Bind University]

        private void BindUniversity()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                DataSet ds = new DataSet();
                ds = objBL.BL_BindUniversity();
                DDL_University.DataSource = ds.Tables[0];
                DDL_University.DataTextField = "UniversityName";
                DDL_University.DataValueField = "UniversityId";
                DDL_University.DataBind();
                DDL_University.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        ////Load Country Drop down
        //#region[Load Country Drop down]

        //private void LoadCountryDropDown()
        //{
        //    try
        //    {
        //        DDL_Country.DataTextField = "name";
        //        DDL_Country.DataValueField = "id";
        //        DataSet ds = ViewState["DatasetAll"] as DataSet;
        //        DDL_Country.DataSource = ds.Tables["Country"];
        //        DDL_Country.DataBind();
        //        DDL_Country.Items.Insert(0, new ListItem(" Select ", "0"));
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion

        //Country Changed
        //#region[Country Changed]

        //protected void DDL_Country_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DDL_State.Items.Insert(0, new ListItem(" Select ", "0"));
        //    DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
        //    try
        //    {
        //        LoadStateDropDown(DDL_Country.SelectedValue);
        //    }

        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion

        //Load Drop down
        //#region[Load Drop Down]

        //private void LoadStateDropDown(string cid)
        //{
        //    try
        //    {
        //        DDL_State.DataTextField = "name";
        //        DDL_State.DataValueField = "cid";
        //        DataSet ds = ViewState["DatasetAll"] as DataSet;

        //        DataView dv = new DataView(ds.Tables["State"]);

        //        dv.RowFilter = "cid = " + cid;
        //        DDL_State.DataSource = dv.ToTable();
        //        DDL_State.DataBind();
        //        DDL_State.Items.Insert(0, new ListItem(" Select ", "0"));
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion

        //State Changed
        //#region[State Changed]

        //protected void DDL_State_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
        //        {
        //            msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
        //        }
        //        else
        //        {
        //            LoadCityDropDown(DDL_State.SelectedValue);
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //        //throw;
        //    }
        //}

        //#endregion

        //Load City Drop Down
        //#region[Load City]

        //private void LoadCityDropDown(string p)
        //{
        //    try
        //    {
        //        DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));

        //        if (DDL_State.SelectedValue.Equals("Select") && DDL_State.SelectedValue.Equals(""))
        //        {
        //            msgBox.ShowMessage("Please Select State First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
        //        }
        //        else
        //        {
        //            DDL_City.DataTextField = "name";
        //            DDL_City.DataValueField = "id";
        //            DataSet ds = ViewState["DatasetAll"] as DataSet;

        //            DataView dv = new DataView(ds.Tables["City"]);
        //            dv.RowFilter = "sid = " + p;
        //            DDL_City.DataSource = dv.ToTable();
        //            DDL_City.DataBind();
        //            DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion

        //DDL Text Changed
        //#region[DDL Text changed]

        //protected void DDL_State_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LoadCityDropDown(DDL_State.SelectedValue);
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        #region SAVE_Button

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            BL_SuperAdmin objBL = new BL_SuperAdmin();
            EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

            try
            {
                objEWA.orgID = Convert.ToInt32(TxtOrgID.Text);
                objEWA.OrgCode = TxtOrgCode.Text;
                objEWA.OrgName = TxtOrgName.Text;
                objEWA.OrgLabel = TxtOrgLabel.Text;
                objEWA.PhoneNo = TxtPhoneNo.Text;
                objEWA.FaxNo = TxtFax.Text;
                objEWA.Website = Txtwebsite.Text;
                objEWA.Email = TxtEmail.Text;
                objEWA.Address = TxtAddress.Text;
                objEWA.Country = ddlcountry.SelectedItem.Text;
                objEWA.State = ddlstate.SelectedItem.Text;
                objEWA.City = ddlcity.SelectedItem.Text;
                objEWA.Pincode = Convert.ToInt32(TxtPincode.Text);
                objEWA.UniversityCode = TxtUniversityCode.Text;
                objEWA.MSBTECode = TxtMSBTEcode.Text;
                objEWA.AICTECode = TxtAICTECode.Text;
                objEWA.DTECode = TxtDTEcode.Text;
                objEWA.TrustName = TxtTrustName.Text;
                objEWA.OrgType = rbl_OrganizationType.SelectedValue.ToString();
                objEWA.OrgUniversity = DDL_University.SelectedValue.ToString();

                // Code for store Logo Image

                int length = 0;
                byte[] imgLogobyte = null;
                byte[] imgLetterHeadbyte = null;

                if (FileLogoImage.HasFile)
                {
                    length = FileLogoImage.PostedFile.ContentLength;
                    imgLogobyte = new byte[length];
                    HttpPostedFile img1 = FileLogoImage.PostedFile;
                    img1.InputStream.Read(imgLogobyte, 0, length);
                }
                objEWA.LogoImage = imgLogobyte;

                if (FileLetterHeadImage.HasFile)
                {
                    length = FileLetterHeadImage.PostedFile.ContentLength;
                    imgLetterHeadbyte = new byte[length];
                    HttpPostedFile img1 = FileLetterHeadImage.PostedFile;
                    img1.InputStream.Read(imgLetterHeadbyte, 0, length);
                }
                objEWA.LetterHeadImage = imgLetterHeadbyte;

                objBL.insertNew_College_RegistrationBLL(objEWA);

                string emailmsg = SendEmails();

                TxtOrgName.Text = "";
                TxtPhoneNo.Text = "";
                TxtAddress.Text = "";
                TxtPincode.Text = "";
                TxtTrustName.Text = "";
                TxtUniversityCode.Text = "";
                Txtwebsite.Text = "";
                TxtEmail.Text = "";
                TxtMSBTEcode.Text = "";
                TxtFax.Text = "";
                TxtAICTECode.Text = "";
                TxtDTEcode.Text = "";

                ddlcity.Items.Insert(0, new ListItem("Select", "0"));

                ddlcountry.Items.Insert(0, new ListItem("Select", "0"));
                ddlstate.Items.Insert(0, new ListItem("Select", "0"));
                DDL_University.Items.Insert(0, new ListItem("Select", "0"));

                int orgID1 = Get_orgID();

                orgID1 = orgID1 + 1;
                TxtOrgID.Text = orgID1.ToString();

                int orgCode = Get_orgCode();
                TxtOrgCode.Text = "CLG/" + orgCode + 1;
                msgBox.ShowMessage("College Register Successfully !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
            }
            catch (Exception ex)
            {
                msgBox.ShowMessage("College Registeration Failed !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
            }
            finally
            {
                
            }
        }

        #endregion SAVE_Button


        #region SendeMailRegion

        private string SendEmails()
        {
            string stringResult = null;
            string mailFrom = Convert.ToString("Schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            // string mailFrom = WebConfigurationManager.AppSettings["mail"];
            //string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(TxtEmail.Text);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Admission Process";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Dear " + TxtOrgName.Text + "  \n  Your Registration Submitted Successfully \n Please Note Down Your  Organization ID And  Organization Code \n Organization ID :" + TxtOrgID.Text + "\n Organization Code : '" + TxtOrgCode.Text + "' \n Thank You For Registraion !!";
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

        //Get Org Id
        #region GET_IDs

        private int Get_orgID()
        {
            try
            {
                BL_SuperAdmin bcls = new BL_SuperAdmin();
                int org_ID = bcls.Get_orgID();
                return org_ID;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Get Org Code
        #region[Get Org Code]

        private int Get_orgCode()
        {
            try
            {
                BL_SuperAdmin bcls = new BL_SuperAdmin();
                int org_Code = bcls.Get_orgCode();
                return org_Code;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Clear Controls
        #region[Clear Controls]

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                TxtOrgName.Text = "";
                TxtPhoneNo.Text = "";
                TxtAddress.Text = "";
                TxtPincode.Text = "";
                TxtTrustName.Text = "";
                TxtUniversityCode.Text = "";
                Txtwebsite.Text = "";
                TxtEmail.Text = "";
                TxtMSBTEcode.Text = "";
                TxtFax.Text = "";
                TxtAICTECode.Text = "";
                TxtDTEcode.Text = "";
                TxtOrgLabel.Text = "";
                ddlcity.Items.Insert(0, new ListItem("Select", "0"));

                ddlcountry.Items.Insert(0, new ListItem("Select", "0"));
                ddlcity.Items.Insert(0, new ListItem("Select", "0"));
                DDL_University.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlState();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlCity(); 
        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
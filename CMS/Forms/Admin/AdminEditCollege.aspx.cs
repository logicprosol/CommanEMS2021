using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using System.Data.SqlClient;
using System.Configuration;

//Edit College
namespace CMS.Forms.Admin
{
    public partial class AdminEditCollege : System.Web.UI.Page
    {
        //Objects
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
      
        #region Object_Declaration

        public static int orgID;
        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();
        private BindControl ObjHelper = new BindControl();
        private DataSet ds;
        database db = new database();
        #endregion Object_Declaration

        // Page Load

        #region [Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgID = Convert.ToInt32(Session["OrgID"]);
                if (orgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    Bind_ddlCountry();
                    Bind_ddlCity1();
                    Bind_ddlState1();
                    BindUniversity();
                    BindOrganizationData(orgID);

                   

                    //ds = new DataSet();
                    //ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
                    //ViewState["DatasetAll"] = ds;
                    //LoadCountryDropDown();


                   
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion [Page Load]

        //Bind University

        #region [Bind Unversity]

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

        #endregion [Bind Unversity]



        public void Bind_ddlCountry()
        {
            if (DDL_Country.Items.Count <= 0)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                DDL_Country.DataSource = dr;
                DDL_Country.Items.Clear();
                DDL_Country.Items.Add("--Please Select country--");
                DDL_Country.DataTextField = "County";
                DDL_Country.DataValueField = "CountryId";
                DDL_Country.DataBind();
                cn.Close();
            }
            DDL_Country.Items.Insert(0, new ListItem("--Please Select Country--", "0"));
        }

        public void Bind_ddlState()
        {

            cn.Open();

            SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + DDL_Country.SelectedValue + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DDL_State.DataSource = dr;
            DDL_State.Items.Clear();

            DDL_State.DataTextField = "State";
            DDL_State.DataValueField = "StateID";
            DDL_State.DataBind();
            cn.Close();

            DDL_State.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        }
        public void Bind_ddlState1()
        {

            cn.Open();

            SqlCommand cmd = new SqlCommand("select State,StateID from countryState ", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DDL_State.DataSource = dr;
            DDL_State.Items.Clear();

            DDL_State.DataTextField = "State";
            DDL_State.DataValueField = "StateID";
            DDL_State.DataBind();
            cn.Close();

            DDL_State.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        }
        public void Bind_ddlCity()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict where StateId ='" + DDL_State.SelectedValue + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL_City.DataSource = dr;
            DDL_City.Items.Clear();

            DDL_City.DataTextField = "District";
            DDL_City.DataValueField = "DistrictId";
            DDL_City.DataBind();
            cn.Close();

            DDL_City.Items.Insert(0, new ListItem("--Please Select City--", "0"));
        }

        public void Bind_ddlCity1()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict ", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL_City.DataSource = dr;
            DDL_City.Items.Clear();

            DDL_City.DataTextField = "District";
            DDL_City.DataValueField = "DistrictId";
            DDL_City.DataBind();
            cn.Close();

            DDL_City.Items.Insert(0, new ListItem("--Please Select City--", "0"));
        }

        //Load Country

        #region LoadCountryDropDown

        private void LoadCountryDropDown()
        {
            try
            {
                DDL_Country.DataTextField = "name";
                DDL_Country.DataValueField = "id";
                DataSet ds = ViewState["DatasetAll"] as DataSet;
                DDL_Country.DataSource = ds.Tables["Country"];
                DDL_Country.DataBind();
                DDL_Country.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion LoadCountryDropDown

        // ADD_DATA TO Form For Update

        #region ADD_DATA For Update

        private void       BindOrganizationData(int OrgID)
        {
            try
            {
                string[] prmList = null;
                BindControl ObjHelper = new BindControl();

                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgID";
                prmList[3] = Convert.ToString(OrgID);

                DataSet dsCode = ObjHelper.FillControl(prmList, "SP_CollegeRegistration");
                if (dsCode.Tables[0].Rows.Count > 0)
                {
                    TxtOrgID.Text = dsCode.Tables[0].Rows[0][0].ToString();
                    TxtOrgName.Text = dsCode.Tables[0].Rows[0][1].ToString();
                    TxtOrgCode.Text = dsCode.Tables[0].Rows[0][2].ToString();
                    rbl_OrganizationType.SelectedValue = dsCode.Tables[0].Rows[0][4].ToString();
                    TxtTrustName.Text = dsCode.Tables[0].Rows[0][5].ToString();



                    string University = dsCode.Tables[0].Rows[0][3].ToString();
                    if (University != null && University != "")
                    {
                        DDL_University.SelectedValue = University;
                    }
                    //int OrgType = Convert.ToInt16(dsCode.Tables[0].Rows[0][4]);
                    //rbl_OrganizationType.ClearSelection();
                    //if (OrgType == 0)
                    //{
                    //    rbl_OrganizationType.Items.FindByText("College").Selected = true;

                    //}
                    //else
                    //    rbl_OrganizationType.Items.FindByText("School").Selected = true;

                    TxtOrgLabel.Text = dsCode.Tables[0].Rows[0][5].ToString();
                    TxtTrustName.Text = dsCode.Tables[0].Rows[0][6].ToString();
                    TxtPhoneNo.Text = dsCode.Tables[0].Rows[0][7].ToString();
                    TxtFax.Text = dsCode.Tables[0].Rows[0][8].ToString();

                    Txtwebsite.Text = dsCode.Tables[0].Rows[0][10].ToString();
                    TxtEmail.Text = dsCode.Tables[0].Rows[0][11].ToString();
                    TxtAddress.Text = dsCode.Tables[0].Rows[0][12].ToString();

                    string country = db.getDbstatus_Value("select Country from tblOrganization where OrganizationId ='" + Convert.ToInt32(Session["OrgId"]) + "' ");
                    DDL_Country.SelectedItem.Text = country.ToString();

                    string State = db.getDbstatus_Value("select State from tblOrganization where OrganizationId ='" + Convert.ToInt32(Session["OrgId"]) + "' ");
                    DDL_State.SelectedItem.Text  = State.ToString();


                    string city = db.getDbstatus_Value("select City from tblOrganization where OrganizationId ='" + Convert.ToInt32(Session["OrgId"]) + "' ");
                    DDL_City.SelectedItem.Text  = city.ToString();

                    TxtPincode.Text = dsCode.Tables[0].Rows[0][16].ToString();
                    TxtUniversityCode.Text = dsCode.Tables[0].Rows[0][17].ToString();
                    TxtMSBTEcode.Text = dsCode.Tables[0].Rows[0][18].ToString();
                    TxtAICTECode.Text = dsCode.Tables[0].Rows[0][19].ToString();
                    TxtDTEcode.Text = dsCode.Tables[0].Rows[0][20].ToString();

                    string Logo = dsCode.Tables[0].Rows[0]["Logo"].ToString();

                    if (Logo != null && Logo != "")
                    {
                        Byte[] bytes = (Byte[])dsCode.Tables[0].Rows[0]["Logo"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ViewState["Logo"] = bytes;
                    }


                    string LetterHead = dsCode.Tables[0].Rows[0]["LetterHead"].ToString();

                    if (LetterHead != null && LetterHead != "")
                    {
                        Byte[] bytes = (Byte[])dsCode.Tables[0].Rows[0]["LetterHead"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ViewState["LetterHead"] = bytes;
                    }
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion ADD_DATA For Update

        // Bind Country State City to Dropdownbox   Data

        #region Country_State_City Bind

        protected void DDL_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DDL_State.Items.Insert(0, new ListItem(" Select ", "0"));
            //DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
            //try
            //{
            //    LoadStateDropDown(DDL_Country.SelectedValue);
            //}

            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            Bind_ddlState();
        }

        #endregion Country_State_City Bind

        //Load State
        #region[Load State]

        private void LoadStateDropDown(string cid)
        {
            try
            {
                DDL_State.DataTextField = "name";
                DDL_State.DataValueField = "cid";
                DataSet ds = ViewState["DatasetAll"] as DataSet;

                DataView dv = new DataView(ds.Tables["State"]);

                dv.RowFilter = "cid = " + cid;
                DDL_State.DataSource = dv.ToTable();
                DDL_State.DataBind();
                DDL_State.Items.Insert(0, new ListItem(" Select ", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //State Index Change
        #region[State Index Change]

        protected void DDL_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
            //    {
            //        msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
            //    }
            //    else
            //    {
            //        LoadCityDropDown(DDL_State.SelectedValue);
            //    }
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            Bind_ddlCity();
        }

        #endregion

        //Load City
        #region[Load City]

        private void LoadCityDropDown(string p)
        {
            try
            {
                DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));

                if (DDL_State.SelectedValue.Equals("Select") && DDL_State.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select State First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    DDL_City.DataTextField = "name";
                    DDL_City.DataValueField = "id";
                    DataSet ds = ViewState["DatasetAll"] as DataSet;

                    DataView dv = new DataView(ds.Tables["City"]);
                    dv.RowFilter = "sid = " + p;
                    DDL_City.DataSource = dv.ToTable();
                    DDL_City.DataBind();
                    DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
                }
            }
            catch (Exception exp)
            {
                DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Update College Information

        #region UpdateCollegeData

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            BL_SuperAdmin objBL = new BL_SuperAdmin();
            EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    objEWA.Action = "Update";
                    objEWA.orgID = Convert.ToInt32(TxtOrgID.Text);
                    objEWA.OrgUniversity = DDL_University.SelectedValue;
                    objEWA.OrgCode = TxtOrgCode.Text;
                    objEWA.TrustName = TxtTrustName.Text;
                    objEWA.OrgName = TxtOrgName.Text;
                    objEWA.OrgLabel = TxtOrgLabel.Text;
                    objEWA.PhoneNo = TxtPhoneNo.Text;
                    objEWA.FaxNo = TxtFax.Text;
                    objEWA.Website = Txtwebsite.Text;
                    objEWA.Email = TxtEmail.Text;
                    objEWA.Address = TxtAddress.Text;
                    objEWA.Country = DDL_Country.SelectedItem.Text;
                    objEWA.State = DDL_State.SelectedItem.Text;
                    objEWA.City = DDL_City.SelectedItem.Text;
                    objEWA.Pincode = Convert.ToInt32(TxtPincode.Text);
                    objEWA.UniversityCode = TxtUniversityCode.Text;
                    objEWA.MSBTECode = TxtMSBTEcode.Text;
                    objEWA.AICTECode = TxtAICTECode.Text;
                    objEWA.DTECode = TxtDTEcode.Text;
                    objEWA.OrgType = rbl_OrganizationType.SelectedValue;
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
                        objEWA.LogoImage = imgLogobyte;
                    }
                    else
                    {
                        objEWA.LogoImage = (byte[])ViewState["Logo"];
                    }
                   

                    if (FileLetterHeadImage.HasFile)
                    {
                        length = FileLetterHeadImage.PostedFile.ContentLength;
                        imgLetterHeadbyte = new byte[length];
                        HttpPostedFile img1 = FileLetterHeadImage.PostedFile;
                        img1.InputStream.Read(imgLetterHeadbyte, 0, length);
                        objEWA.LetterHeadImage = imgLetterHeadbyte;
                    }
                    else
                    {
                        objEWA.LetterHeadImage = (byte[])ViewState["LetterHead"];
                    }
                    

                    objBL.Update_College_Data(objEWA);
                    msgBox.ShowMessage("College Data Updated Successfully !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                }
            }
            catch (Exception)
            {
                msgBox.ShowMessage("College Updation Failed.. !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
            }
        }

        #endregion UpdateCollegeData

        // Select City

        #region City DropDown

        protected void DDL_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDL_State.SelectedValue.Equals("Select") && DDL_State.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select State First.. !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion City DropDown

        // Clear Button

        #region [Clear Button]

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                TxtOrgName.Text = "";
                TxtPhoneNo.Text = "";
                TxtPincode.Text = "";
                TxtTrustName.Text = "";
                TxtUniversityCode.Text = "";
                Txtwebsite.Text = "";
                TxtMSBTEcode.Text = "";
                TxtFax.Text = "";
                TxtEmail.Text = "";
                TxtDTEcode.Text = "";
                TxtAICTECode.Text = "";
                TxtAddress.Text = "";
                TxtOrgLabel.Text = "";
            }
            catch (Exception exp)
            {
              //  GeneralErr(exp.Message.ToString());
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
    }
}
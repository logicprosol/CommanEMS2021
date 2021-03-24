using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using System.Data.SqlClient;
using System.Configuration;

//Edit College Details
namespace CMS.Forms.SuperAdmin
{
    public partial class SuperAdmin_EditCollegeDetails : System.Web.UI.Page
    {
        //Objects
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        #region Object_Declaration

        private BL_SuperAdmin objBL = new BL_SuperAdmin();
        private EWA_SuperAdmin objEWA = new EWA_SuperAdmin();
        public static DataSet ds;
        private BindControl ObjHelper = new BindControl();
        database db = new database();

        #endregion Object_Declaration

        // Page Load

        #region pageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_ddlCountry();
                try
                {
                    BindUniversity();
                    AddCollegeToDropDown();

                    ds = new DataSet();
                   
                    //ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
                   // ViewState["DatasetAll"] = ds;
                    //LoadCountryDropDown();
                    
                    
                }
              
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                }
              
            }
        }

        #endregion pageLoad

        //bind country

        public void Bind_ddlCountry()
        {
            if (ddlcountry.Items.Count <= 0)
            {
             
            cn.Open();
            SqlCommand cmd = new SqlCommand("select County,CountryId from Country", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlcountry.DataSource = dr;
            ddlcountry.Items.Clear();
            //ddlcountry.Items.Add("--Please Select country--");
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
           // ddlstate.Items.Add("--Please Select state--");
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
           // ddlcity.Items.Add("--Please Select city--");
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

        // Bind College Name to Drop Down Box Using List

        #region Bind_College

        private void AddCollegeToDropDown()
        {
            try
            {
                DataSet ds = objBL.AddCollegeToDropDown();

                DDL_SelectCollege.DataTextField = "OrgLabel";
                DDL_SelectCollege.DataValueField = "OrganizationId";
                DDL_SelectCollege.DataSource = ds;
                DDL_SelectCollege.DataBind();
                DDL_SelectCollege.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Bind Country To DDL_Country

        //#region LoadCountryDropDown

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

        // ADD_DATA TO Form For Update

        #region ADD_DATA For Update

        protected void DDL_SelectCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string collegeName = DDL_SelectCollege.SelectedValue.ToString();

                string[] prmList = null;
                BindControl ObjHelper = new BindControl();

                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgID";
                prmList[3] = DDL_SelectCollege.SelectedValue.ToString();

                DataSet dsCode = ObjHelper.FillControl(prmList, "SP_CollegeRegistration");
                if (dsCode.Tables[0].Rows.Count > 0)
                {
                    TxtOrgID.Text = dsCode.Tables[0].Rows[0][0].ToString();
                    TxtOrgName.Text = dsCode.Tables[0].Rows[0][1].ToString();
                    TxtOrgCode.Text = dsCode.Tables[0].Rows[0][2].ToString();

                    string University = dsCode.Tables[0].Rows[0][3].ToString();
                    if (University != "0")
                    {
                        if (University != null && University != "")
                        {
                            string univercityName = db.getDbstatus_Value("select UniversityName from tblUniversity where UniversityId='" + University.ToString() + "'");
                            DDL_University.SelectedValue = University;
                        }
                    }
                    int OrgType = Convert.ToInt16(dsCode.Tables[0].Rows[0][4]);
                    rbl_OrganizationType.ClearSelection();
                    if (OrgType == 0)
                    {
                        rbl_OrganizationType.Items.FindByText("College").Selected = true;
                        
                    }
                    else
                        rbl_OrganizationType.Items.FindByText("School").Selected = true;

                

                    TxtOrgLabel.Text = dsCode.Tables[0].Rows[0][5].ToString();
                    TxtTrustName.Text = dsCode.Tables[0].Rows[0][6].ToString();
                    TxtPhoneNo.Text = dsCode.Tables[0].Rows[0][7].ToString();
                    TxtFax.Text = dsCode.Tables[0].Rows[0][8].ToString();
                    Txtwebsite.Text = dsCode.Tables[0].Rows[0][10].ToString();
                    TxtEmail.Text = dsCode.Tables[0].Rows[0][11].ToString();
                    TxtAddress.Text = dsCode.Tables[0].Rows[0][12].ToString();



                    string country = db.getDbstatus_Value("select Country from tblOrganization where OrganizationId='" + TxtOrgID.Text + "'");          
                    ddlcountry.ClearSelection();
                    float abc = db.getDb_Value("select CountryId from Country where County='" + country.ToString() + "' ");
                    ddlcountry.SelectedValue = abc.ToString();

                    string sta = db.getDbstatus_Value("select State from tblOrganization where OrganizationId='" + TxtOrgID.Text + "'");
                    ddlstate.ClearSelection();
                    Bind_ddlState1();
                    float pqr = db.getDb_Value("select StateId from countryState where State='" + sta.ToString() + "'");
                    ddlstate.SelectedValue =  pqr.ToString();

                    string ci = db.getDbstatus_Value("select City from tblOrganization where OrganizationId='" + TxtOrgID.Text + "'");
                    ddlcity.ClearSelection();
                    Bind_ddlCity1();
                    float xyz = db.getDb_Value("select DistrictId from tblDistrict where District='" + ci.ToString() + "'");
                    ddlcity.SelectedValue = xyz.ToString();




                    TxtPincode.Text = dsCode.Tables[0].Rows[0][16].ToString();
                    TxtUniversityCode.Text = dsCode.Tables[0].Rows[0][17].ToString();
                    TxtMSBTEcode.Text = dsCode.Tables[0].Rows[0][18].ToString();
                    TxtAICTECode.Text = dsCode.Tables[0].Rows[0][19].ToString();
                    TxtDTEcode.Text = dsCode.Tables[0].Rows[0][20].ToString();

                    string Photo = dsCode.Tables[0].Rows[0]["Logo"].ToString();

                    if (Photo != "0" && Photo != "")
                    {
                        Byte[] bytes = (Byte[])dsCode.Tables[0].Rows[0]["Logo"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ViewState["Logo"] = bytes;
                    }

                   Photo = dsCode.Tables[0].Rows[0]["LetterHead"].ToString();

                    if (Photo != "0" && Photo != "")
                    {
                        Byte[] bytes = (Byte[])dsCode.Tables[0].Rows[0]["LetterHead"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        ViewState["LetterHead"] = bytes;
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Bind Country State City to Dropdownbox   Data

        //#region Country_State_City Bind

        //protected void DDL_Country_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    Bind_ddlCountry();
        //    //try
        //    //{
        //    //    LoadStateDropDown(DDL_Country.SelectedValue);
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    GeneralErr(exp.Message.ToString());
        //    //}
        //}

        //#endregion

        //Load State
        //#region[Load State]

        //private void LoadStateDropDown(string cid)
        //{
        //    try
        //    {
        //        if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
        //        {
        //            msgBox.ShowMessage("Please Select Country First.. !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
        //            SetFocus(DDL_Country.Text);
        //        }
        //        else
        //        {
        //            DDL_State.DataTextField = "name";
        //            DDL_State.DataValueField = "cid";
        //            DataSet ds = ViewState["DatasetAll"] as DataSet;

        //            DataView dv = new DataView(ds.Tables["State"]);

        //            dv.RowFilter = "cid = " + cid;
        //            DDL_State.DataSource = dv.ToTable();
        //            DDL_State.DataBind();
        //            DDL_State.Items.Insert(0, new ListItem(" Select ", "0"));
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion

        //State Changed
        #region[State Changed]

        //protected void DDL_State_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    Bind_ddlState();
        //    //try
        //    //{
        //    //    LoadCityDropDown(DDL_State.SelectedValue);
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    GeneralErr(exp.Message.ToString());
        //    //}
        //}

        #endregion

        //Load City
        //#region[Load City]

        //private void LoadCityDropDown(string p)
        //{
        //    //try
        //    //{
        //    //    if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals("") && DDL_State.SelectedValue.Equals(""))
        //    //    {
        //    //        msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
        //    //    }
        //    //    else
        //    //    {
        //    //        DDL_City.DataTextField = "name";
        //    //        DDL_City.DataValueField = "id";
        //    //        DataSet ds = ViewState["DatasetAll"] as DataSet;

        //    //        DataView dv = new DataView(ds.Tables["City"]);
        //    //        dv.RowFilter = "sid = " + p;
        //    //        DDL_City.DataSource = dv.ToTable();
        //    //        DDL_City.DataBind();
        //    //        DDL_City.Items.Insert(0, new ListItem(" Select ", "0"));
        //    //    }
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    GeneralErr(exp.Message.ToString());
        //    //}
        //    Bind_ddlCity(); 
        //}

        //#endregion

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
                    objEWA.OrgCode = TxtOrgCode.Text;
                    objEWA.TrustName = TxtTrustName.Text;
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

                    // Code for store Logo Image

                    int length = 0;
                    byte[] imgLogobyte = null;
                    byte[] imgLetterHeadbyte = null;

                    if (FileLogoImage.HasFile)
                    {
                        length = FileLogoImage.PostedFile.ContentLength;
                        imgLogobyte = new byte[length];
                        ViewState["Logo"] = imgLogobyte;
                        HttpPostedFile img1 = FileLogoImage.PostedFile;
                        img1.InputStream.Read(imgLogobyte, 0, length);
                    }
                    objEWA.LogoImage = (byte[])ViewState["Logo"];

                    if (FileLetterHeadImage.HasFile)
                    {
                        length = FileLetterHeadImage.PostedFile.ContentLength;
                        imgLetterHeadbyte = new byte[length];
                        ViewState["LetterHead"] = imgLetterHeadbyte;
                        HttpPostedFile img1 = FileLetterHeadImage.PostedFile;
                        img1.InputStream.Read(imgLetterHeadbyte, 0, length);
                    }
                    objEWA.LetterHeadImage = (byte[])ViewState["LetterHead"];
                    objEWA.OrgUniversity = DDL_University.SelectedValue;
                    objBL.Update_College_Data(objEWA);
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                msgBox.ShowMessage("College Updation Failed.. !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
            }
            finally
            {
                msgBox.ShowMessage("College Data Updated Successfully !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
            }
        }

        #endregion

        // Select City

        //#region City DropDown

        //protected void DDL_City_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (DDL_State.SelectedValue.Equals("Select") && DDL_State.SelectedValue.Equals(""))
        //    //{
        //    //    msgBox.ShowMessage("Please Select State First.. !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
        //    //}
        //}

       // #endregion City DropDown

        // General Error Method
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("SuperAdmin_Home.aspx");
        }

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
        public void Bind_ddlState1()
        {

            cn.Open();

            SqlCommand cmd = new SqlCommand("select State,StateID from countryState ", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            ddlstate.DataSource = dr;
            ddlstate.Items.Clear();

            ddlstate.DataTextField = "State";
            ddlstate.DataValueField = "StateID";
            ddlstate.DataBind();
            cn.Close();

            ddlstate.Items.Insert(0, new ListItem("--Please Select State--", "0"));
        } 
        public void Bind_ddlCity1()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlcity.DataSource = dr;
            ddlcity.Items.Clear();

            ddlcity.DataTextField = "District";
            ddlcity.DataValueField = "DistrictId";
            ddlcity.DataBind();
            cn.Close();

            ddlcity.Items.Insert(0, new ListItem("--Please Select District--", "0"));
        }

    }
}
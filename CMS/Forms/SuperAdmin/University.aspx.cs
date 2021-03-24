using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessAccessLayer.SuperAdmin;
using EntityWebApp.SuperAdmin;
using System.Data.SqlClient;
using System.Configuration;

//University
namespace CMS.Forms.SuperAdmin
{
    public partial class University : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        //Objects
        #region[Objects]
        private BL_University objBL = new BL_University();
        public static DataSet ds;
        private EWA_University objEWA = new EWA_University();
        bool flag;
        string country;
        string ci;
        database db = new database();
        string sta;

        // private BindControl ObjHelper = new BindControl();

        #endregion

        // Page Load
        #region [PageLoad]

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (!IsPostBack)
                {
                    //ds = new DataSet();
                    //ds.ReadXml(Server.MapPath("AddressXMLFile.xml"));
                    //ViewState["DatasetAll"] = ds;
                    //LoadCountryDropDown();
                    GrdUniversityBind();

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

            DDL_City.Items.Insert(0, new ListItem("--Please Select District--", "0"));
        }

        //University Grid Bind
        #region[University Grid Bind]

        private void GrdUniversityBind()
        {
            try
            {
                DataSet ds = objBL.UniversityGridBind_BL();
                GrdUniversity.DataSource = ds;
                GrdUniversity.DataBind();
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());

            }
        }

        #endregion

        //Load Drop down
        #region Load DropDown of Country,State,City Region

        protected void DDL_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlState();
        }

        #endregion

        //State Changed
        #region[State Changed]

        protected void DDL_State_SelectedIndexChanged2(object sender, EventArgs e)
        {

            //try
            //{
            //    if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
            //    {
            //        msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
            //    }
            //    else
            //    {
            //       // DDL_State.Text = DDL_State.SelectedValue.ToString();
            //        LoadCityDropDown(DDL_State.SelectedValue);
            //    }
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //    //throw;
            //}
            Bind_ddlCity();
        }

        #endregion

        //Load Country
        #region[Load Country]

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

        #endregion

        //Load State
        #region[Load State]

        private void LoadStateDropDown(string cid)
        {
            try
            {
                if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select Country First.. !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                    SetFocus(DDL_Country.Text);
                }
                else
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
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DDL State Changed
        #region[DDL State Changed]

        protected void DDL_State_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
                {
                    msgBox.ShowMessage("Please Select Country First !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    LoadCityDropDown(DDL_State.SelectedValue);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load City
        #region[Load City]

        private void LoadCityDropDown(string p)
        {
            try
            {
                if (DDL_Country.SelectedValue.Equals("Select") && DDL_Country.SelectedValue.Equals(""))
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
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save University
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_University objBL = new BL_University();
            EWA_University objEWA = new EWA_University();
            try
            {
                lock (this)
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Select * from [tblUniversity] ";
                    cmd.Connection = cn;
                    SqlDataReader rd = cmd.ExecuteReader();


                    while (rd.Read())
                    {

                        if (rd[1].ToString() == txtUniversityName.Text)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        msgBox.ShowMessage("Record Already Exist!!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        clear();
                        //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Already Exists')", true);
                    }

                    else
                    {
                        Action("Save");
                        clear();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Existing Data
        #region[Check Data]

        private int CheckData()
        {
            try
            {
                EWA_University objEWA = new EWA_University();
                objEWA.UniversityName = txtUniversityName.Text;
                int i = objBL.CheckDuplicateUniversity_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        // Update
        #region Update Data

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BL_University objBL = new BL_University();
            EWA_University objEWA = new EWA_University();
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                        cn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "Select * from [tblUniversity] ";
                        cmd.Connection = cn;
                        SqlDataReader rd = cmd.ExecuteReader();


                        //while (rd.Read())
                        //{

                        //    if (rd[1].ToString() == txtUniversityName.Text)
                        //    {
                        //        flag = true;
                        //        break;
                        //    }
                        //}
                        if (flag == true)
                        {
                            msgBox.ShowMessage("Record Already Exist!!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);

                            clear();
                            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Already Exists')", true);
                        }
                        else
                        {
                            Action("Update");
                            clear();

                            btnNew.Visible = true;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;



                        }
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Delete
        #region [Delete University]

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BL_University objBL = new BL_University();
            EWA_University objEWA = new EWA_University();
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                        Action("Delete");
                        clear();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        #endregion

        //Perform Action for University

        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.UniversityId = Convert.ToInt32(ViewState["UniversityId"].ToString());
                }
                objEWA.UniversityName = txtUniversityName.Text.Trim();
                objEWA.Address = txtAddress.Text.Trim();

                objEWA.Country = DDL_Country.SelectedItem.ToString();
                objEWA.State = DDL_State.SelectedItem.ToString();
                objEWA.City = DDL_City.SelectedItem.ToString();

                objEWA.PinCode = txtPinCode.Text.Trim();
                objEWA.Email = txtEmail.Text.Trim();
                objEWA.Contact = txtContactNo.Text.Trim();
                objEWA.FaxNo = txtFaxNo.Text.Trim();
                if (flpLogo.HasFile)
                {
                    int length = flpLogo.PostedFile.ContentLength;
                    objEWA.Logo = new byte[length];
                    HttpPostedFile img1 = flpLogo.PostedFile;
                    img1.InputStream.Read(objEWA.Logo, 0, length);
                }

                int flag = objBL.UniversityAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    GrdUniversityBind();
                }
                else
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //University Changing
        #region[University Changing]

        protected void GrdUniversity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdUniversity.PageIndex = e.NewPageIndex;
                DataSet ds = objBL.UniversityGridBind_BL();
                GrdUniversity.DataSource = ds;
                GrdUniversity.DataBind();
            }
            catch (Exception exp)
            {

                GeneralErr(exp.Message.ToString());
            }

        }

        #endregion

        // Selected Index Changes
        #region Selected Index Change

        protected void lnkBtnUniversityName_Click(object sender, EventArgs e)
        {
            try
            {
                btnNew.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                txtUniversityName.Enabled = true;
                txtAddress.Enabled = true;

                txtEmail.Enabled = true;

                txtPinCode.Enabled = true;
                txtContactNo.Enabled = true;
                txtFaxNo.Enabled = true;

                flpLogo.Enabled = true;
                DDL_City.Enabled = true;
                DDL_Country.Enabled = true;
                DDL_State.Enabled = true;

                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["UniversityId"] = GrdUniversity.DataKeys[grdrow.RowIndex].Values["UniversityId"].ToString();
                    txtUniversityName.Text = GrdUniversity.DataKeys[grdrow.RowIndex].Values["UniversityName"].ToString();
                    txtAddress.Text = GrdUniversity.DataKeys[grdrow.RowIndex].Values["Address"].ToString();
                   
                    //LoadCountryDropDown();
                   // DDL_Country.SelectedValue = GrdUniversity.DataKeys[grdrow.RowIndex].Values["Country"].ToString();
                    //LoadStateDropDown(DDL_Country.SelectedValue);
                    //LoadCityDropDown(DDL_State.SelectedValue);
                    // DDL_City.SelectedValue = GrdUniversity.DataKeys[grdrow.RowIndex].Values["City"].ToString();
                    //DDL_Country.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
                   
                    
                    //FETCH COUNTRY,STATE,CITY
                    int id =Convert.ToInt32( ViewState["UniversityId"].ToString());

                    country = db.getDbstatus_Value("select Country from tblUniversity where UniversityId='" + id + "'");
                  //  DDL_Country.Items.FindByValue(CountryId).Selected = true;
                    DDL_Country.ClearSelection(); 
                    float abc = db.getDb_Value("select CountryId from Country where County='" + country .ToString()+ "' ");
                    DDL_Country.SelectedValue = abc.ToString();


                    sta = db.getDbstatus_Value("select State from tblUniversity where UniversityId='" + id + "'");
                    DDL_State.ClearSelection();
                    Bind_ddlState1();
                    float pqr = db.getDb_Value("select StateId from countryState where State='"+sta.ToString()+"'");
                    DDL_State.SelectedValue = pqr.ToString();

                    ci = db.getDbstatus_Value("select City from tblUniversity where UniversityId='" + id + "'");
                    DDL_City.ClearSelection();
                    Bind_ddlCity1();
                    float xyz = db.getDb_Value("select DistrictId from tblDistrict where District='" + ci.ToString()+"'");
                    DDL_City.SelectedValue = xyz.ToString();


                    // DDL_State.Text = state.ToString();
                    //DDL_State.SelectedValue = state.ToString();
                    // DDL_State.SelectedValue = GrdUniversity.DataKeys[grdrow.RowIndex].Values["state"].ToString();



                    txtPinCode.Text = GrdUniversity.DataKeys[grdrow.RowIndex].Values["PinCode"].ToString();
                    txtEmail.Text = GrdUniversity.DataKeys[grdrow.RowIndex].Values["Email"].ToString();
                    txtContactNo.Text = GrdUniversity.DataKeys[grdrow.RowIndex].Values["ContactNo1"].ToString();
                    txtFaxNo.Text = GrdUniversity.DataKeys[grdrow.RowIndex].Values["FaxNo1"].ToString();

                    
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel Link
        #region[Cancel Link]

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            try
            {
                txtUniversityName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtPinCode.Text = "";
                txtContactNo.Text = "";
                txtFaxNo.Text = "";

                btnNew.Visible = true;
                btnDelete.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
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
         public void Bind_ddlCity1()
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDistrict", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DDL_City.DataSource = dr;
            DDL_City.Items.Clear();

            DDL_City.DataTextField = "District";
            DDL_City.DataValueField = "DistrictId";
            DDL_City.DataBind();
            cn.Close();

            DDL_City.Items.Insert(0, new ListItem("--Please Select District--", "0"));
        }


        #endregion

        //New Event
        #region[New Event]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtUniversityName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtPinCode.Text = "";
                txtContactNo.Text = "";
                txtFaxNo.Text = "";
                btnNew.Visible = false;
                btnSave.Visible = true;
                txtUniversityName.Enabled = true;
                txtAddress.Enabled = true;

                txtEmail.Enabled = true;

                txtPinCode.Enabled = true;
                txtContactNo.Enabled = true;
                txtFaxNo.Enabled = true;

                flpLogo.Enabled = true;
                DDL_City.Enabled = true;
                DDL_Country.Enabled = true;
                DDL_State.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // General Error Method

        #region General Error

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        public void clear()
        {
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtEmailid.Text = "";
            txtFaxNo.Text = "";
            txtPinCode.Text = "";
            txtUniversityName.Text = "";
            DDL_Country.ClearSelection();
            DDL_State.ClearSelection();
            DDL_City.ClearSelection();
        }

        protected void DDL_City_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrdUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_Country.Items.Add(GrdUniversity.SelectedRow.Cells[2].Text.ToString());
           // DDL_State.Items.Add(GrdUniversity.SelectedRow.Cells[1].Text.ToString());
        }

       
    }
}
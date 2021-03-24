using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class ContryStateDist : System.Web.UI.Page
    {

        #region[Objects]
        private BL_CountryStateDistrict objBL = new BL_CountryStateDistrict();
        private EWA_CountryStateDistrict objEWA = new EWA_CountryStateDistrict();
        private BindControl ObjHelper = new BindControl();
        public static int orgId;
        database db = new database();
        float count, a;
        #endregion

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
                    //To Call Form Controlles Load
                    #region CallAllMethods
                    LoadCountryTab();
                    GrdCountryBind();
                    LoadStateTab();
                    ddlCountryStateBind();
                    LoadDistrictTab();
                    ddlCountryBind();
                    //LoadDivisionTab();
                    //ddlCourseDBind();

                    #endregion
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Country Load
        #region[Country Load]

        private void LoadCountryTab()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtCountryName.Enabled = false;
                txtCountryId.Enabled = false;
                txtCountryName.Text = "";
                txtCountryId.Text = "";
                ddlCountry.SelectedIndex = 0;
                ddlStateD.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load State
        #region[Load State]

        private void LoadStateTab()
        {
            try
            {
                btnNewS.Visible = true;
                btnCancelS.Visible = true;
                btnSaveS.Visible = false;
                btnUpdateS.Visible = false;
                btnDeleteS.Visible = false;
                txtStateName.Enabled = false;
                //txtStateId.Enabled = false;
                txtStateName.Text = "";
                //txtStateId.Text = "";
                ddlCountryS.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load District
        #region[Load District]

        private void LoadDistrictTab()
        {
            try
            {
                btnNewD.Visible = true;
                btnCancelD.Visible = true;
                btnSaveD.Visible = false;
                btnUpdateD.Visible = false;
                btnDeleteD.Visible = false;
                txtDistrictName.Enabled = false;
                //txtDistrictId.Enabled = false;
                txtDistrictName.Text = "";
                //txtDistrictId.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country Grid Bind
        #region[Country Grid Bind]

        private void GrdCountryBind()
        {
            try
            {
                objEWA = new EWA_CountryStateDistrict();
                //Pass it from Session
                objEWA.Action = "SelectDataCountry";
                DataSet ds = objBL.CountryGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdCountry.DataSource = ds;
                    GrdCountry.DataBind();
                    int columncount = GrdCountry.Rows[0].Cells.Count;
                    GrdCountry.Rows[0].Cells.Clear();
                    GrdCountry.Rows[0].Cells.Add(new TableCell());
                    GrdCountry.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdCountry.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdCountry.DataSource = ds;
                    GrdCountry.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country State Bind
        #region[Country State Bind]

        private void ddlCountryStateBind()
        {
            try
            {
                objEWA = new EWA_CountryStateDistrict();
                objEWA.Action = "SelectDataCountry";
                DataSet ds = objBL.CountryGridBind_BL(objEWA);
                ddlCountryS.DataSource = ds;
                ddlCountryS.DataTextField = "CountryName";
                ddlCountryS.DataValueField = "CountryId";
                ddlCountryS.DataBind();
                ddlCountryS.Items.Insert(0, "Select");
                ddlCountryS.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country Bind
        #region[Country Bind]

        private void ddlCountryBind()
        {
            try
            {
                objEWA = new EWA_CountryStateDistrict();
                objEWA.Action = "SelectDataCountry";
                DataSet ds = objBL.CountryGridBind_BL(objEWA);
                ddlCountry.DataSource = ds;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, "Select");
                ddlCountry.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion






        //Update Country
        #region[Update Country]

        public void UpdateCountryTab()
        {
            try
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtCountryName.Enabled = true;
                txtCountryId.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Branch
        #region[Update Branch]

        public void UpdateBranchTab()
        {
            try
            {
                btnUpdateS.Visible = true;
                btnDeleteS.Visible = true;
                btnSaveS.Visible = false;
                btnNewS.Visible = false;
                btnCancelS.Visible = true;
                txtStateName.Enabled = true;
                //txtStateId.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update District
        #region[Update District]

        public void UpdateDistrictTab()
        {
            try
            {
                btnUpdateD.Visible = true;
                btnDeleteD.Visible = true;
                btnSaveD.Visible = false;
                btnNewD.Visible = false;
                btnCancelD.Visible = true;
                txtDistrictName.Enabled = true;
                //txtDistrictId.Enabled = true;
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
                objEWA = new EWA_CountryStateDistrict();
                objEWA.CountryName = txtCountryName.Text.Trim();
                objEWA.Action = "CheckDataCountry";
                int i = objBL.CheckDuplicateCountry_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Save Country
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_ProgramExecutive objBL = new BL_ProgramExecutive();
            EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
            try
            {
                lock (this)
                {
                    if (txtCountryId.Text == "")
                    {
                        msgBox.ShowMessage("Country Id Not Found !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else if (txtCountryName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Course Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        //ViewState["CountryId"] = 0;
                        int chk = CheckData();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            Action("SaveCountry");
                            GrdCountryBind();
                            LoadCountryTab();

                            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
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

        //UpdateData
        #region UpdateCountry

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("UpdateCountry");
                    GrdCountryBind();
                    LoadCountryTab();

                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Country
        #region DeleteCountry

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                count = db.getDb_Value("select count(CountryId) from countryState where CountryId='" + ViewState["CountryId"].ToString() + "'");

                if (count != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        Action("DeleteCountry");
                        //GrdCountryBind();
                        //LoadCountryTab();
                    }
                }
            }
            catch (Exception exp)
            {
                //GeneralErr("Unable to delete. State is added for the selected country");
            }
        }

        #endregion

        //Cancel Action
        #region CancelRegion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCountryTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Country
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "UpdateCountry" || strAction == "DeleteCountry")
                {
                    objEWA.CountryId = ViewState["CountryId"].ToString();
                }
                objEWA.CountryName = txtCountryName.Text.Trim();
                objEWA.CountryId = txtCountryId.Text.Trim();

                

                int flag = objBL.CountryAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "SaveCountry")
                    {
                        //msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "UpdateCountry")
                    {
                        //msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Updated", "alert('Record Updated Successfully !!!')", true);
                    }
                    else if (strAction == "DeleteCountry")
                    {
                        //msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Deleted", "alert('Record Deleted Successfully !!!')", true);
                    }
                    GrdCountryBind();
                    LoadCountryTab();
                }
                else if (flag == -1)
                {
                    if (strAction == "SaveCountry")
                    {
                        msgBox.ShowMessage(objEWA.CountryName + "is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else if (strAction == "UpdateCountry")
                    {
                        msgBox.ShowMessage(objEWA.CountryName + "is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                }
                else
                {
                    if (strAction == "SaveCountry")
                    {
                        //msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "UpdateCountry")
                    {
                        //msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "DeleteCountry")
                    {
                       // msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete !!!')", true);
                    }
                }
            }
            catch (Exception exp)
            {
                int err = ((System.Data.SqlClient.SqlException)(exp)).Number;
                if (err == 547 && objEWA.Action == "DeleteState")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Record Is in Use !!!')", true);
                }
            }
        }

        #endregion

        //AddNew
        #region AddNew

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtCountryName.Enabled = true;
                txtCountryId.Enabled = true;
                txtCountryName.Text = "";
                txtCountryId.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //EnableControls
        #region EnableControls

        private void EnableControls()
        {
            try
            {
                txtCountryId.Enabled = true;
                txtCountryName.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //ClearControls
        #region ClearControls

        private void ClearControls()
        {
            try
            {
                txtCountryId.Text = "";
                txtCountryName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdCountry.PageIndex = e.NewPageIndex;
                objEWA = new EWA_CountryStateDistrict();
                objEWA.Action = "SelectDataCountry";
                GrdCountry.DataSource = objBL.CountryGridBind_BL(objEWA);
                GrdCountry.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //CountryLinkButtonClick
        #region CourseLinkButtonClick

        protected void lnkBtnCountryName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["CountryId"] = GrdCountry.DataKeys[grdrow.RowIndex].Values["CountryId"].ToString();
                    txtCountryId.Text = GrdCountry.DataKeys[grdrow.RowIndex].Values["CountryId"].ToString();
                    txtCountryName.Text = GrdCountry.DataKeys[grdrow.RowIndex].Values["CountryName"].ToString();

                    UpdateCountryTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For StateTab

        #region StateTab

        protected void ddlCountryS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrdStateBind();
                txtStateName.Text = "";
                txtStateId.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //AddNewButtonToAddState
        #region AddState

        protected void btnNewS_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveS.Visible = true; ;
                btnUpdateS.Visible = false;
                btnDeleteS.Visible = false;
                btnNewS.Visible = false;
                txtStateName.Enabled = true;
                txtStateId.Enabled = true;
                txtStateName.Text = "";
                txtStateId.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SaveState
        #region SaveState

        protected void btnSaveS_Click(object sender, EventArgs e)
        {
            try
            {
                ActionS("SaveState");
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for State
        #region[Perform Action]

        private void ActionS(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                objEWA.StateId = "0";
                if (strAction == "UpdateState" || strAction == "DeleteState")
                {
                    objEWA.StateId = ViewState["StateId"].ToString();
                }
                objEWA.StateName = txtStateName.Text.Trim();
                
                if (ddlCountryS.SelectedIndex != 0)
                {
                    objEWA.CountryId = ddlCountryS.SelectedValue.ToString();
                }
                


                int flag = objBL.StateAction_BL(objEWA);

                if (flag > 0)
                {
                   if (strAction == "SaveState")
                    {
                        //msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "UpdateState")
                    {
                        //msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Updated", "alert('Record Updated Successfully !!!')", true);
                    }
                    else if (strAction == "DeleteState")
                    {
                        //msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Deleted", "alert('Record Deleted Successfully !!!')", true);
                    }
                    GrdStateBind();
                    LoadStateTab();
                }
                else if (flag == -1)
                {
                    if (strAction == "SaveState")
                    {
                        msgBox.ShowMessage(objEWA.StateName + "is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else if (strAction == "UpdateState")
                    {
                        msgBox.ShowMessage(objEWA.StateName + "is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                }
                else
                {
                    
                    if (strAction == "SaveState")
                    {
                        //msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "UpdateState")
                    {
                        //msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "DeleteState")
                    {
                        // msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete !!!')", true);
                    }
                }
            }
            catch (Exception exp)
            {
                int err = ((System.Data.SqlClient.SqlException)(exp)).Number;
                if (err == 547 && objEWA.Action == "DeleteState")
                {
                    //msgBox.ShowMessage("Record is in use !", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Record Is in Use !!!')", true);
                }
            }
        }

        #endregion

        //UpdateState
        #region UpdateState

        protected void btnUpdateS_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    ActionS("UpdateState");
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DeleteState
        #region DeleteState

        protected void btnDeleteS_Click(object sender, EventArgs e)
        {
            try
            {
                count = db.getDb_Value("select count(StateId) from tblDistrict where  StateId='" + ViewState["StateId"].ToString() + "'  ");

                if (count != 0 )
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        ActionS("DeleteState");
                        //GrdStateBind();
                    }
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //CancelState
        #region CancelState

        protected void btnCancelS_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStateTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //State Grid Bind
        #region[State Grid Bind]

        private void GrdStateBind()
        {
            try
            {
                objEWA = new EWA_CountryStateDistrict();
                objEWA.Action = "SelectDataState";
                objEWA.CountryId = ddlCountryS.SelectedValue.ToString();
                if (ddlCountryS.SelectedValue.ToString() != "Select")
                {
                    DataSet ds = objBL.StateGridBind_BL(objEWA);
                    if (ds.Tables[0].Rows.Count == 0 || ds == null)
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        GrdState.DataSource = ds;
                        GrdState.DataBind();
                        int columncount = GrdState.Rows[0].Cells.Count;
                        GrdState.Rows[0].Cells.Clear();
                        GrdState.Rows[0].Cells.Add(new TableCell());
                        GrdState.Rows[0].Cells[0].ColumnSpan = columncount;
                        GrdState.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    else
                    {
                        GrdState.DataSource = ds;
                        GrdState.DataBind();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdState_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdState.PageIndex = e.NewPageIndex;
                objEWA = new EWA_CountryStateDistrict();
                objEWA.Action = "SelectDataState";
                objEWA.CountryId = ddlCountryS.SelectedValue.ToString();
                GrdState.DataSource = objBL.StateGridBind_BL(objEWA);
                GrdState.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //StateLinkButtonClick
        #region StateLinkButtonClick

        protected void lnkBtnStateName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["StateId"] = GrdState.DataKeys[grdrow.RowIndex].Values["StateId"].ToString();
                    txtStateName.Text = GrdState.DataKeys[grdrow.RowIndex].Values["StateName"].ToString();
                    txtStateId.Text = GrdState.DataKeys[grdrow.RowIndex].Values["StateId"].ToString();
                    ddlCountryS.SelectedValue = GrdState.DataKeys[grdrow.RowIndex].Values["CountryId"].ToString();
                    UpdateBranchTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//

        //AddNewButtonToAddDistrict
        #region AddDistrict

        protected void btnNewD_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveD.Visible = true; ;
                btnUpdateD.Visible = false;
                btnDeleteD.Visible = false;
                btnNewD.Visible = false;
                txtDistrictName.Enabled = true;
                txtDistrictId.Enabled = true;
                txtDistrictName.Text = "";
                txtDistrictId.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Country Index
        #region[Country Index Changed]

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlStateDBind();
                //GrdClassBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //State grid
        #region[State Grid]

        private void ddlStateDBind()
        {
            try
            {
                objEWA = new EWA_CountryStateDistrict();
                objEWA.Action = "SelectDataState";
                objEWA.CountryId = ddlCountry.SelectedValue.ToString();
                DataSet ds = objBL.StateGridBind_BL(objEWA);
                ddlStateD.DataSource = ds;
                ddlStateD.DataTextField = "StateName";
                ddlStateD.DataValueField = "StateId";
                ddlStateD.DataBind();
                ddlStateD.Items.Insert(0, "Select");
                ddlStateD.SelectedIndex = 0;
                GrdDistrict.DataSource = null;
                GrdDistrict.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //State Selected Index Changed
        #region[State Index changed]

        protected void ddlStateD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrdDistrictBind();
                txtDistrictId.Text = "";
                txtDistrictName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SaveDistrict
        #region SaveDistrict

        protected void btnSaveD_Click(object sender, EventArgs e)
        {
            try
            {
                ActionD("SaveDistrict");
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for District
        #region[Perform Action]

        private void ActionD(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                objEWA.DistrictId = "0";
                if (strAction == "UpdateDistrict" || strAction == "DeleteDistrict")
                {
                    objEWA.DistrictId = ViewState["DistrictId"].ToString();
                }
                
                objEWA.DistrictName = txtDistrictName.Text.Trim();
                //if (ddlCourse.SelectedIndex != 0)
                //{
                //    objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                //}

                if (ddlStateD.SelectedIndex != 0)
                {
                    objEWA.StateId = ddlStateD.SelectedValue.ToString();
                }
                

                int flag = objBL.DistrictAction_BL(objEWA);

                if (flag > 0)
                {
                    
                    if (strAction == "SaveDistrict")
                    {
                        //msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "UpdateDistrict")
                    {
                        //msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Updated", "alert('Record Updated Successfully !!!')", true);
                    }
                    else if (strAction == "DeleteDistrict")
                    {
                        //msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Deleted", "alert('Record Deleted Successfully !!!')", true);
                    }
                    GrdDistrictBind();
                    LoadDistrictTab();
                }
                else if (flag == -1)
                {
                    if (strAction == "SaveDistrict")
                    {
                        msgBox.ShowMessage("Data is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else if (strAction == "UpdateDistrict")
                    {
                        msgBox.ShowMessage("Data is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                }
                else
                {
                    
                    if (strAction == "SaveDistrict")
                    {
                        //msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "UpdateDistrict")
                    {
                        //msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "DeleteDistrict")
                    {
                        // msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete !!!')", true);
                    }
                }
            }
            catch (Exception exp)
            {
                int err = ((System.Data.SqlClient.SqlException)(exp)).Number;
                if (err == 547 && objEWA.Action == "DeleteState")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Record Is in Use !!!')", true);
                }
            }
        }

        #endregion

        //UpdateDistrict
        #region UpdateDistrict

        protected void btnUpdateD_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    ActionD("UpdateDistrict");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DeleteDistrict
        #region DeleteDistrict

        protected void btnDeleteD_Click(object sender, EventArgs e)
        {
            try
            {

                count = db.getDb_Value("select Count(*) from tblAdmissionDetails where District='" + ViewState["DistrictId"] + "'");
               
                if (count != 0 )
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        ActionD("DeleteDistrict");
                    }
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //CancelDistrict
        #region CancelDistrict

        protected void btnCancelD_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDistrictTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //GridDistrictBind
        #region[DistrictGridBind]

        private void GrdDistrictBind()
        {
            try
            {
                objEWA = new EWA_CountryStateDistrict();
                

                objEWA.Action = "SelectDataDistrict";
                objEWA.StateId = ddlStateD.SelectedValue.ToString();
                DataSet ds = objBL.DistrictGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdDistrict.DataSource = ds;
                    GrdDistrict.DataBind();
                    int columncount = GrdDistrict.Rows[0].Cells.Count;
                    GrdDistrict.Rows[0].Cells.Clear();
                    GrdDistrict.Rows[0].Cells.Add(new TableCell());
                    GrdDistrict.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdDistrict.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdDistrict.DataSource = ds;
                    GrdDistrict.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            

            try
            {
                GrdDistrict.PageIndex = e.NewPageIndex;
                GrdDistrictBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DistrictLinkButtonClick
        #region DistrictLinkButtonClick

        protected void lnkBtnDistrictName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["DistrictId"] = GrdDistrict.DataKeys[grdrow.RowIndex].Values["DistrictId"].ToString();
                    txtDistrictId.Text = GrdDistrict.DataKeys[grdrow.RowIndex].Values["DistrictId"].ToString();
                    txtDistrictName.Text = GrdDistrict.DataKeys[grdrow.RowIndex].Values["DistrictName"].ToString();
                    ddlStateD.SelectedValue= GrdDistrict.DataKeys[grdrow.RowIndex].Values["StateId"].ToString();
                    UpdateDistrictTab();
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
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
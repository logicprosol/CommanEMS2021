using BusinessAccessLayer.SuperAdmin;
using EntityWebApp.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.SuperAdmin
{
    public partial class AddTrailset : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        EWA_Trailset objEWA = new EWA_Trailset();
        BL_Trailset objBL = new BL_Trailset();
        
        public static DataSet ds;
        database db = new database();

        // private BindControl ObjHelper = new BindControl();

        #endregion

        //Page_Load
        #region[Page_Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Bind_DDLOrganization();
                    GrdOrganizationBind();
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Organization  Bind
        #region[Organization  Bind]

        public void Bind_DDLOrganization()
        {
            objEWA = new EWA_Trailset();
            objEWA.Action = "FatchOrganization";

            DataSet ds = objBL.Bind_DDLOrganization_BL(objEWA);
            DDL_Organization.DataSource = ds;
            DDL_Organization.DataTextField = "OrgName";
            DDL_Organization.DataValueField = "OrganizationId";
            DDL_Organization.DataBind();
            DDL_Organization.Items.Insert(0, "Select");
            DDL_Organization.SelectedIndex = 0;
        }

        #endregion

        //Trailset Grid Bind
        #region[Trailset Grid Bind]

        private void GrdOrganizationBind()
        {
            try
            {
                objEWA = new EWA_Trailset();
                objEWA.Action = "SelectData";
                DataSet ds = objBL.Bind_DDLOrganization_BL(objEWA);
                GrdTrailset.DataSource = ds;
                GrdTrailset.DataBind();
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());

            }
        }

        #endregion

        //clear Data
        #region[clear Data]

        public void clear()
        {
            txtValidDate.Text = "";
            txtSenderId.Text = "";
            txtAppKey.Text = "";
            DDL_Organization.SelectedIndex = 0;
        }

        #endregion

        // General Error Method

        #region General Error

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Save University
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objEWA = new EWA_Trailset();
            try
            {
                lock (this)
                {
                    objEWA = new EWA_Trailset();
                    objEWA.Action = "CheckData";

                    int rs = objBL.CheckOrganization_BL(objEWA);
                    
                    if (rs == 1)
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
        
        // Update
        #region Update Data

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                        
                            Action("Update");
                            clear();

                            btnNew.Visible = true;

                            txtValidDate.Enabled = true;
                            txtSenderId.Enabled = true;
                            txtAppKey.Enabled = true;
                            DDL_Organization.SelectedIndex = 0;

                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;


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
           
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                        Action("Delete");
                        clear();

                        btnNew.Visible = true;

                        txtValidDate.Enabled = true;
                        txtSenderId.Enabled = true;
                        txtAppKey.Enabled = true;
                        DDL_Organization.SelectedIndex = 0;

                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
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
                objEWA = new EWA_Trailset();
                objEWA.Action = strAction;
                objEWA.id = "0";
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.id = ViewState["id"].ToString();
                }
                objEWA.ValidDate = txtValidDate.Text.Trim();
                objEWA.SenderId = txtSenderId.Text.Trim();
                objEWA.AppKey = txtAppKey.Text.ToString();
                objEWA.OrgId = DDL_Organization.SelectedValue.ToString();
                
                int flag = objBL.TrailsetAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    GrdOrganizationBind();
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

        //protected void GrdUniversity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        GrdTrailset.PageIndex = e.NewPageIndex;
        //        DataSet ds = objBL.UniversityGridBind_BL();
        //        GrdTrailset.DataSource = ds;
        //        GrdTrailset.DataBind();
        //    }
        //    catch (Exception exp)
        //    {

        //        GeneralErr(exp.Message.ToString());
        //    }

        //}

        #endregion

        // Selected Index Changes
        #region Selected Index Change

        protected void lnkBtnOrgName_Click(object sender, EventArgs e)
        {
            try
            {
                btnNew.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                txtValidDate.Enabled = true;
                txtSenderId.Enabled = true;
                txtAppKey.Enabled = true;
                DDL_Organization.Enabled = true;
                

                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["id"] = GrdTrailset.DataKeys[grdrow.RowIndex].Values["id"].ToString();
                    txtValidDate.Text = Convert.ToDateTime(GrdTrailset.DataKeys[grdrow.RowIndex].Values["date"].ToString()).ToShortDateString();
                    txtSenderId.Text = GrdTrailset.DataKeys[grdrow.RowIndex].Values["SenderId"].ToString();
                    txtAppKey.Text = GrdTrailset.DataKeys[grdrow.RowIndex].Values["AppKey"].ToString();
                    DDL_Organization.SelectedValue = GrdTrailset.DataKeys[grdrow.RowIndex].Values["OrgId"].ToString();
                    
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
                txtValidDate.Text = "";
                txtSenderId.Text = "";
                txtAppKey.Text = "";
                DDL_Organization.SelectedIndex = 0;

                txtValidDate.Enabled = false;
                txtSenderId.Enabled = false;
                txtAppKey.Enabled = false;
                DDL_Organization.Enabled = false;

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

        #endregion
        
        //New Event
        #region[New Event]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtValidDate.Text = "";
                txtSenderId.Text = "";
                txtAppKey.Text = "";
                DDL_Organization.SelectedIndex = 0;
                
                btnNew.Visible = false;
                btnSave.Visible = true;
                txtValidDate.Enabled = true;
                txtSenderId.Enabled = true;
                txtAppKey.Enabled = true;
                DDL_Organization.Enabled = true;
                
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

    }
}
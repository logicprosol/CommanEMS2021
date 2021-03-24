using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

//Device Setting
namespace CMS.Forms.Admin
{
    public partial class DeviceSetting : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_DeviceSetting objBL = new BL_DeviceSetting();
        private EWA_DeviceSetting objEWA = new EWA_DeviceSetting();
        private BindControl ObjHelper = new BindControl();
        public static int orgId;
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
                    LoadForm();
                    GrdDeviceBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Form
        #region[Load Form]

        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtDeviceName.Enabled = false;
                txtIP.Enabled = false;
                txtPortNo.Enabled = false;
                txtMachineId.Enabled = false;
                txtDescription.Enabled = false;
                txtDeviceName.Text = "";
                txtIP.Text = "";
                txtPortNo.Text = "";
                txtMachineId.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Upadte
        #region[Call Update]

        public void CallUpdate()
        {
            try
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtDeviceName.Enabled = true;
                txtIP.Enabled = true;
                txtPortNo.Enabled = true;
                txtMachineId.Enabled = true;
                txtDescription.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //New Button
        #region[New Button]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtDeviceName.Enabled = true;
                txtIP.Enabled = true;
                txtPortNo.Enabled = true;
                txtMachineId.Enabled = true;
                txtDescription.Enabled = true;
                txtDeviceName.Text = "";
                txtIP.Text = "";
                txtPortNo.Text = "";
                txtMachineId.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel Button
        #region[Cancel Event]

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadForm();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Button
        #region SaveDeviceData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    if (txtDeviceName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Document Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        //ViewState["DocumentId"] = 0;
                        int chk = CheckData();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            Action("Save");
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
        #region UpdateDeviceData

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Data
        #region DeleteDeviceData

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Device
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.DeviceSettingId = ViewState["DeviceSettingId"].ToString();
                }
                objEWA.DeviceName = txtDeviceName.Text.Trim();
                objEWA.IP = txtIP.Text.Trim();
                objEWA.PortNo = txtPortNo.Text.Trim();
                objEWA.MachineId = txtMachineId.Text.Trim();
                objEWA.Description = txtDescription.Text.Trim();

                //Below Values Need to be pass from session
                objEWA.OrgId = "1";
                objEWA.UserId = "1";
                objEWA.IsActive = true;

                int flag = objBL.DeviceSettingAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    GrdDeviceBind();
                    LoadForm();
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

        // Device Grid Bind
        #region[Device Grid Bind]

        private void GrdDeviceBind()
        {
            try
            {
                objEWA.OrgId =Convert.ToString(orgId);
                DataSet ds = objBL.DeviceGridBind_BL(objEWA);
                GrdDevice.DataSource = ds;
                GrdDevice.DataBind();
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid PageIndex Change
        #region GrdIndexChanged

        protected void GrdDevice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objEWA.OrgId = "1";
                GrdDevice.PageIndex = e.NewPageIndex;
                GrdDevice.DataSource = objBL.DeviceGridBind_BL(objEWA);
                GrdDevice.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DeviceNameLinkButtonClick
        #region DeviceNameLinkButtonClick

        protected void lnkBtnDeviceName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["DeviceSettingId"] = GrdDevice.DataKeys[grdrow.RowIndex].Values["DeviceSettingId"].ToString();
                    txtDeviceName.Text = GrdDevice.DataKeys[grdrow.RowIndex].Values["DeviceName"].ToString();
                    txtIP.Text = GrdDevice.DataKeys[grdrow.RowIndex].Values["IP"].ToString();
                    txtPortNo.Text = GrdDevice.DataKeys[grdrow.RowIndex].Values["PortNo"].ToString();
                    txtMachineId.Text = GrdDevice.DataKeys[grdrow.RowIndex].Values["MachineId"].ToString();
                    txtDescription.Text = GrdDevice.DataKeys[grdrow.RowIndex].Values["Description"].ToString();

                    CallUpdate();
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
                objEWA.DeviceName = txtDeviceName.Text;
                objEWA.OrgId = "1";
                int i = objBL.CheckDuplicateDevice_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
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
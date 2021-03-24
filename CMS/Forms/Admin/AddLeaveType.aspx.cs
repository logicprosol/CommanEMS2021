using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

//Add Fee Type
namespace CMS.Forms.Admin
{
    public partial class AddLeaveType : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_LeaveType objBL = new BL_LeaveType();
        private EWA_LeaveType objEWA = new EWA_LeaveType();
        public static int orgId;
        private BindControl ObjHelper = new BindControl();

        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                if (!IsPostBack)
                {
                    LoadForm();
                    GrdLeaveBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Form
        #region[Form Load]

        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtLeaveName.Enabled = false;
                txtLeaveCode.Enabled = false;
                txtLeaveCount.Enabled = false;
                txtLeaveName.Text = "";
                txtLeaveCode.Text = "";
                txtLeaveCount.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
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
                txtLeaveName.Enabled = true;
                txtLeaveCode.Enabled = true;
                txtLeaveCount.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //New Button
        #region[NEw Button]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtLeaveName.Enabled = true;
                txtLeaveCode.Enabled = true;
                txtLeaveCount.Enabled = true;
                txtLeaveName.Text = "";
                txtLeaveCode.Text = "";
                txtLeaveCount.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel Button
        #region[Cancel Button]

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

        //Save Data
        #region[Save Data]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    if (txtLeaveName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Document Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
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

        //Update Data
        #region[Update Leave]

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

        //Delete Leave
        #region DeleteLeave

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

        //Perform Action for Leave
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.LeaveId = ViewState["LeaveId"].ToString();
                }
                objEWA.LeaveName = txtLeaveName.Text.Trim();
                objEWA.LeaveCode = txtLeaveCode.Text.Trim();
                objEWA.LeaveCount = Convert.ToInt32(txtLeaveCount.Text);
                //Below Values Need to be pass from session
                objEWA.OrgId = orgId.ToString();
                objEWA.UserId = "1";
                objEWA.IsActive = true;

                int flag = objBL.LeaveAction_BL(objEWA);

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
                    GrdLeaveBind();
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

        //Leave Grid Bind
        #region[Leave Grid Bind]

        private void GrdLeaveBind()
        {
            try
            {
                //EWA_LeaveType objEWA = new EWA_LeaveType();
                //objEWA.LeaveId = Convert.ToInt32(ViewState["LeaveId"].ToString());

                DataSet ds = objBL.LeaveTypeGridBind_BL(objEWA);
                GrdLeaveType.DataSource = ds;
                GrdLeaveType.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //LeaveLinkButtonClick
        #region LeaveLinkButtonClick

        protected void lnkBtnLeaveName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["LeaveId"] = GrdLeaveType.DataKeys[grdrow.RowIndex].Values["LeaveId"].ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtLeaveName.Text = GrdLeaveType.DataKeys[grdrow.RowIndex].Values["LeaveName"].ToString();
                    txtLeaveCode.Text = GrdLeaveType.DataKeys[grdrow.RowIndex].Values["LeaveCode"].ToString();
                    txtLeaveCount.Text = GrdLeaveType.DataKeys[grdrow.RowIndex].Values["LeaveCount"].ToString();

                    CallUpdate();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid PageIndex Change
        #region GrdIndexChanged

        protected void GrdLeaveType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objEWA.OrgId = "1";
                GrdLeaveType.PageIndex = e.NewPageIndex;
                GrdLeaveType.DataSource = objBL.LeaveTypeGridBind_BL(objEWA);
                GrdLeaveType.DataBind();
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
                objEWA.LeaveName = txtLeaveName.Text;
                objEWA.OrgId = "1";
                int i = objBL.CheckDuplicateLeave_BL(objEWA);
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
          //  msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
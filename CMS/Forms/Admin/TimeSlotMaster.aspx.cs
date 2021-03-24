using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

namespace CMS.Forms.TimeTable
{
    public partial class TimeSlotMaster : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_TimeSlotMaster objBL = new BL_TimeSlotMaster();
        private EWA_TimeSlotMaster objEWA = new EWA_TimeSlotMaster();
        database db = new database();
        public static int orgId;
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
                    DisableCntrl();
                    GrdBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void EnableCntrl()
        {
            txtFromTime.Enabled = true;
            txtToTime.Enabled = true;
            ddlSlotType.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void DisableCntrl()
        {
            txtFromTime.Enabled = false;
            txtToTime.Enabled = false;
            ddlSlotType.Enabled = false;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void ClearCntrl()
        {
            txtFromTime.Text = "";
            txtToTime.Text = "";
            ddlSlotType.SelectedIndex = -1;
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                //To check Date According to Current Date
                DateTime CurrentDate = DateTime.Now.Date;
                int CurrentStartYear = CurrentDate.Year;
                DateTime CurrentEndYear = CurrentDate.AddYears(1);
                int CurrentMonth = CurrentDate.Month;

                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.SlotId = Convert.ToInt32(ViewState["SlotId"].ToString());
                    if (strAction == "Delete")
                    {
                        float result = db.getDb_Value("select count(*) from tblTimeTableCreation where TimeSlotId="+ objEWA.SlotId);
                        if (result > 0)
                        {
                            msgBox.ShowMessage("Record is in use !!!", "Inforamtion", UserControls.MessageBox.MessageStyle.Information);
                            return;
                        }
                    }
                }
                else
                {
                    objEWA.SlotId = 0;
                }
                objEWA.SlotFrom = txtFromTime.Text.Trim();
                objEWA.SlotTo = txtToTime.Text.Trim();
                objEWA.SlotType = Convert.ToInt16(ddlSlotType.SelectedValue);
                objEWA.OrgId = orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                if (objBL.CheckData(objEWA) > 0 && strAction != "Delete")
                {
                    msgBox.ShowMessage("Record Already Exist !!!", "Inforamtion", UserControls.MessageBox.MessageStyle.Information);
                    return;
                }

                int flag = objBL.TimeSlotMaster_BL(objEWA);

                if (flag > 0)
                {
                    ClearCntrl();
                    DisableCntrl();
                    GrdBind();
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

        private void GrdBind()
        {
            try
            {
                objEWA.OrgId = orgId;
                DataSet ds = new DataSet();
                ds = objBL.GetTimeSlotData(objEWA);
                GrdTimeSlot.DataSource = ds;
                GrdTimeSlot.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        protected void lnkTimeSlot_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkSlot = (LinkButton)sender;
                GridViewRow grdRow = (GridViewRow) lnkSlot.NamingContainer;
                ViewState["SlotId"] = GrdTimeSlot.DataKeys[grdRow.RowIndex].Values["SlotId"].ToString();
                txtFromTime.Text = GrdTimeSlot.DataKeys[grdRow.RowIndex].Values["SlotFrom"].ToString();
                txtToTime.Text = GrdTimeSlot.DataKeys[grdRow.RowIndex].Values["SlotTo"].ToString();
                ddlSlotType.SelectedValue = GrdTimeSlot.DataKeys[grdRow.RowIndex].Values["SlotType"].ToString();
                EnableCntrl();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            EnableCntrl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Action("Save");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Update");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCntrl();
            DisableCntrl();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Delete");
            }
        }
    }
}
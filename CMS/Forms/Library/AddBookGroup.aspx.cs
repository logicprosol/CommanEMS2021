using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Library;
using EntityWebApp.Library;
using System.Data;

namespace CMS.Forms.Library
{
    public partial class AddBookGroup : System.Web.UI.Page
    {
        BL_AddBookGroup objBL = new BL_AddBookGroup();
        EWA_AddBookGroup objEWA = new EWA_AddBookGroup();
        DataSet ds = new DataSet();
        int orgId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            if (!IsPostBack)
            {
                
                GetBookGroup();
                DisableCntrl();
                
            }
        }

        private void GetBookGroup()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                ds = objBL.GetBookGroup_BL(objEWA);
                GrdGroupName.DataSource = ds;
                GrdGroupName.DataBind();
               
            }
            catch (Exception)
            {
            }
        }

        private void EnableCntrl()
        {
            txtGroupName.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DisableCntrl()
        {
            txtGroupName.Enabled = false;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private int CheckGroupName(EWA_AddBookGroup objEWA)
        {
            int cnt = objBL.CheckGroupName_BL(objEWA);
            return cnt;
        }

        private void Action(string strAction)
        {
            try
            {
                objEWA = new EWA_AddBookGroup();
                objEWA.Action = strAction;
                objEWA.GroupId = Convert.ToInt32(ViewState["GroupId"].ToString());
                objEWA.GroupCode = Convert.ToString(ViewState["GroupCode"]);
                objEWA.GroupName = txtGroupName.Text.ToString();
                objEWA.OrgId = orgId;
                objEWA.UserId = Convert.ToInt32(Session["UserCode"].ToString());
                objEWA.IsActive = "true";

                if (CheckGroupName(objEWA)>0)
                {
                    msgBox.ShowMessage("Record Already Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    return;
                }

                int flag = objBL.BookGroupAction_BL(objEWA);
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
                    txtGroupName.Text = "";
                    DisableCntrl();
                    GetBookGroup();
                }
                else if(flag == -1)
                {
                    if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Record is in Used !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }
                else
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("already exists cann't  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
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
            catch (Exception)
            {
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = "";
            EnableCntrl();
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ViewState["GroupId"] = 0;
            ViewState["GroupCode"] = "";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Delete");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = "";
            DisableCntrl();
            btnNew.Enabled = true;
        }

        protected void lnkGroupCode_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkGroupCode = (LinkButton)sender;
                GridViewRow grdRow = (GridViewRow)lnkGroupCode.NamingContainer;
                ViewState["GroupId"] = GrdGroupName.DataKeys[grdRow.RowIndex].Values["GroupId"].ToString();
                ViewState["GroupCode"] = GrdGroupName.DataKeys[grdRow.RowIndex].Values["GroupCode"].ToString();
                txtGroupName.Text = GrdGroupName.DataKeys[grdRow.RowIndex].Values["GroupName"].ToString();
                EnableCntrl();
                btnSave.Enabled = false;

            }
            catch (Exception)
            {
            }
        }
    }
}
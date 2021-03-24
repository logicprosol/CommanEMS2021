using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Inventory;
using EntityWebApp.Inventory;
using System.Data;

namespace CMS.Forms.Inventory
{
    public partial class AddUnit : System.Web.UI.Page
    {
       
            
        //Objects
        #region[Objects]
        private BL_Unit objBL = new BL_Unit();
        private EWA_Unit objEWA = new EWA_Unit();

        public static int orgId=0;
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
                    try
                    {
                        LoadForm();

                        GrdUnitBind();
                    }
                    catch (Exception exp)
                    {
                        GeneralErr(exp.Message.ToString());
                    }
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
                btnNew.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtUnitName.Enabled = false;
                txtUnitName.Text = "";
            
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Item Unit
        #region[Item Unit Grid Bind]

        private void GrdUnitBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.UnitGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdUnit.DataSource = ds;
                    GrdUnit.DataBind();
                    int columncount = GrdUnit.Rows[0].Cells.Count;
                    GrdUnit.Rows[0].Cells.Clear();
                    GrdUnit.Rows[0].Cells.Add(new TableCell());
                    GrdUnit.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdUnit.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdUnit.DataSource = ds;
                    GrdUnit.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Data
        #region[Check Data]

        private int CheckData()
        {
            int i = 0;
            try
            {
                EWA_Unit objEWA = new EWA_Unit();
                objEWA.UnitName = txtUnitName.Text.Trim();
                i = objBL.CheckDuplicateUnit_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Save Data
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_Unit objBL = new BL_Unit();
            EWA_Unit objEWA = new EWA_Unit();
            try
            {
                lock (this)
                {
                    if (txtUnitName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Unit Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            GrdUnitBind();
                            LoadForm();
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

        //Add New
        #region AddNew

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSave.Enabled = true; ;
                    btnCancel.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    txtUnitName.Enabled = true;
                  
                    txtUnitName.Text = "";
                  
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel
        #region BtnCancelRegion

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

        //Clear Controls
        #region ClearControls

        private void ClearControls()
        {
            try
            {
                txtUnitName.Text = "";
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdUnit.PageIndex = e.NewPageIndex;

                GrdUnit.DataSource = objBL.UnitGridBind_BL(objEWA);
                GrdUnit.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Item Unit Link
        #region ItemUnitLinkButtonClick

        protected void lnkBtnUnitName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["UnitId"] = GrdUnit.DataKeys[grdrow.RowIndex].Value.ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtUnitName.Text = GrdUnit.DataKeys[grdrow.RowIndex].Values["UnitName"].ToString();
                   

                    callUpdate();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
        #region[Call Update]

        public void callUpdate()
        {
            try
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnNew.Enabled = false;
                btnCancel.Enabled = true;
                txtUnitName.Enabled = true;
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //UpdateData
        #region UpdateDocument

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                    GrdUnitBind();
                    LoadForm();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.UnitId = Convert.ToInt32(ViewState["UnitId"].ToString());
                }
                objEWA.UnitName = txtUnitName.Text.Trim();

                objEWA.OrgId = orgId;
               
                objEWA.UserId = Session["UserCode"].ToString();
             
                objEWA.IsActive = "True";

                int flag = objBL.UnitAction_BL(objEWA);

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

        //Delete Item Unit
        #region DeleteItemUnit

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    GrdUnitBind();
                    LoadForm();
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
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
        }
    }

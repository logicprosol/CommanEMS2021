using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityWebApp.Inventory;
using BusinessAccessLayer.Inventory;
using System.Data;

namespace CMS.Forms.Inventory
{
    public partial class Supplier : System.Web.UI.Page
    {
        //Objects
        #region[Objects]

        private EWA_Supplier objEWA = new EWA_Supplier();
        private BL_Supplier objBL = new BL_Supplier();

        public static int orgId=0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                LoadForm();
                //BindCategory();
                BindItemGrid();
                BindSupplierGrid();
            
               
            }
        }
           protected void gvCheckboxes_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkBxSelect");
            CheckBox chkBxHeader = (CheckBox)this.GrdItem.HeaderRow.FindControl("chkBxHeader");

            chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
        }
    }

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
                txtSupplierName.Enabled = false;
                 txtMobileNo.Enabled = false;
                    //ddlCategory.Enabled = false;
                    txtPhoneNo.Enabled = false;
                    txtFaxNo.Enabled = false;
                    txtEmailId.Enabled = false;
                    txtWebsite.Enabled = false;
                    txtAddress.Enabled = false;
                    txtSupplierName.Text = "";
                    //ddlCategory.SelectedIndex = -1;
                    txtMobileNo.Text = "";
                    txtPhoneNo.Text = "";
                    txtFaxNo.Text = "";
                    txtEmailId.Text = "";
                    txtWebsite.Text = "";
                    txtAddress.Text = "";
          
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //private void BindCategory()
        //{
        //    try
        //    {
        //        EWA_Supplier objEWA = new EWA_Supplier();
        //        BL_Supplier ObjBL = new BL_Supplier();
        //        //objEWA.OrgId = orgId;
        //        DataSet dsCategory = ObjBL.BindCategory_BL();
        //        ddlCategory.DataSource = dsCategory;
        //        ddlCategory.DataTextField = "CategoryName";
        //        ddlCategory.DataValueField = "CategoryId";
        //        ddlCategory.DataBind();
        //        ddlCategory.Items.Insert(0, "Select");
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }


        //}

        //Branch Selected Index Changed
        #region[Category Dropdown Index changed]

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               // BindItemGrid();
                
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Item Grid Bind
        #region[Item Category Grid Bind]

        private void BindItemGrid()
        {
            try
            {
                EWA_Supplier objEWA = new EWA_Supplier();
                BL_Supplier objBL = new BL_Supplier();
               // objEWA.CategoryId = ddlCategory.SelectedValue;
                objEWA.OrgId = orgId;
                DataSet ds = objBL.BindItemGrid_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdItem.DataSource = ds;
                    GrdItem.DataBind();
                    int columncount = GrdItem.Rows[0].Cells.Count;
                    GrdItem.Rows[0].Cells.Clear();
                    GrdItem.Rows[0].Cells.Add(new TableCell());
                    GrdItem.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdItem.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdItem.DataSource = ds;
                    GrdItem.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                BL_Item objBL = new BL_Item();
                GrdItem.PageIndex = e.NewPageIndex;

                GrdItem.DataSource = objBL.BindItemGrid_BL();
                GrdItem.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //SupplierCategory
        #region[SupplierCategory Grid Bind]

        private void BindSupplierGrid()
        {
            try
            {
                EWA_Supplier objEWA = new EWA_Supplier();
                objEWA.OrgId = orgId;
                DataSet ds = objBL.BindSupplierGrid_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdSupplier.DataSource = ds;
                    GrdSupplier.DataBind();
                    int columncount = GrdSupplier.Rows[0].Cells.Count;
                    GrdSupplier.Rows[0].Cells.Clear();
                    GrdSupplier.Rows[0].Cells.Add(new TableCell());
                    GrdSupplier.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdSupplier.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdSupplier.DataSource = ds;
                    GrdSupplier.DataBind();
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
                EWA_Supplier objEWA = new EWA_Supplier();
                BL_Supplier objBL = new BL_Supplier();
                objEWA.SupplierName = txtSupplierName.Text.Trim();
                i = objBL.CheckDuplicateSupplier_BL(objEWA);
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
           
            try
            {
                lock (this)
                {
                    if (txtSupplierName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Category Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            BindSupplierGrid();
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
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnCancel.Enabled = true;
                    btnNew.Enabled = false;
                    txtSupplierName.Enabled = true;
                    txtMobileNo.Enabled = true;
                   // ddlCategory.Enabled = true;
                    txtPhoneNo.Enabled = true;
                    txtFaxNo.Enabled = true;
                    txtEmailId.Enabled = true;
                    txtWebsite.Enabled = true;
                    txtAddress.Enabled = true;
                    txtSupplierName.Text = "";
                  // ddlCategory.SelectedIndex = -1;
                    txtMobileNo.Text = "";
                    txtPhoneNo.Text = "";
                    txtFaxNo.Text = "";
                    txtEmailId.Text = "";
                    txtWebsite.Text = "";
                    txtAddress.Text = "";
                    ViewState["PartyLinkage"] = null;
                    BindItemGrid();
                    clear();

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
                BindItemGrid();
                clear();
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
                txtSupplierName.Text = "";

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objEWA.OrgId = orgId;
                GrdSupplier.PageIndex = e.NewPageIndex;

                GrdSupplier.DataSource = objBL.BindSupplierGrid_BL(objEWA);
                GrdSupplier.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SupplierCategory Link
        #region SupplierSupplierLinkButtonClick

        protected void lnkBtnSupplierName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    BL_Supplier objBL = new BL_Supplier();
                    EWA_Supplier objEWA = new EWA_Supplier();

                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                   // lnkBtnId = (LinkButton)grdrow.Cells[0].FindControl("SupplierId");
                    
                    ViewState["SupplierId"] = GrdSupplier.DataKeys[grdrow.RowIndex].Value.ToString();
                    objEWA.SupplierId = Convert.ToInt32(ViewState["SupplierId"]);
                    objEWA.OrgId = orgId;
                    DataSet ds = objBL.BindSupplierData_BL(objEWA);

                    txtSupplierName.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["SupplierName"].ToString();
                    //ddlCategory.SelectedValue = GrdSupplier.DataKeys[grdrow.RowIndex].Values["CategoryId"].ToString();
                    txtMobileNo.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["MobileNo"].ToString();
                    txtPhoneNo.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["PhoneNo"].ToString();
                    txtFaxNo.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["FaxNo"].ToString();
                    txtEmailId.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["EmailId"].ToString();
                    txtWebsite.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["Website"].ToString();
                    txtAddress.Text = GrdSupplier.DataKeys[grdrow.RowIndex].Values["Address"].ToString();
                    if (ds.Tables[1].Rows.Count >= 0)
                    {
                        ViewState["SuppItem"] = ds;
                        GrdItem.DataSource = ds.Tables[2];
                        GrdItem.DataBind();
                    }
                    else 
                    {
                         BindItemGrid();
                    
                    }
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
                txtSupplierName.Enabled = true;
               // ddlCategory.Enabled = true;
                txtMobileNo.Enabled = true;
               // ddlCategory.Enabled = true;
                txtPhoneNo.Enabled = true;
                txtFaxNo.Enabled = true;
                txtEmailId.Enabled = true;
                txtWebsite.Enabled = true;
                txtAddress.Enabled = true;

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        private void clear()
        {
            try
            {
                txtSupplierName.Text = "";
                txtMobileNo.Text = "";
                txtPhoneNo.Text = "";
                txtFaxNo.Text = "";
                txtEmailId.Text = "";
                txtWebsite.Text = "";
                txtAddress.Text = "";
                foreach (GridViewRow Row in GrdItem.Rows)
                {
                    CheckBox chk = Row.Cells[0].FindControl("chkBxSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        chk.Checked = false;
                    }

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

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
                    BindSupplierGrid();
                    LoadForm();
                    BindItemGrid();
                    clear();
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
                    objEWA.SupplierId = Convert.ToInt32(ViewState["SupplierId"].ToString());
                }
                objEWA.SupplierName = txtSupplierName.Text.Trim();
           
                objEWA.MobileNo = txtMobileNo.Text.Trim();
                objEWA.PhoneNo = txtPhoneNo.Text.Trim();
                objEWA.FaxNo = txtFaxNo.Text.Trim();
                objEWA.EmailId = txtEmailId.Text.Trim();
                objEWA.Website = txtWebsite.Text.Trim();
                objEWA.Address = txtAddress.Text.Trim();

                objEWA.OrgId = orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int count = GrdItem.Rows.Count;
                //string[] ItemId = new string[count];
                DataTable dt = new DataTable();
               // int i = 0;
                foreach (GridViewRow gvrow in GrdItem.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkBxSelect");
                    if (chk != null && chk.Checked)
                    {
                       // ItemId[i] = GrdItem.DataKeys[gvrow.RowIndex].Values["ItemId"].ToString();
                       // i++;
                        //objEWA.ItemId = ItemId[i];
                        if (ViewState["SupplierItem"] == null)
                        {
                           
                            dt.Columns.Add("ItemId");
                            dt.Columns.Add("SupplierId");
                            DataRow rw = dt.NewRow();
                            // rw["SupplierId"] = ddlPartyName.SelectedItem.Value.ToString();
                            rw["ItemId"] = GrdItem.DataKeys[gvrow.RowIndex].Values["ItemId"].ToString();
                            dt.Rows.Add(rw);
                            ViewState["SupplierItem"] = dt as DataTable;
                        }
                        else  
                        {
                            int cnt = 0;
                            dt = ViewState["SupplierItem"] as DataTable;
                            foreach (DataRow drow in dt.Rows)
                            {
                                if (!chk.Checked)
                                {
                                    cnt = 1;
                                }
                            }

                            if (cnt == 0)
                            {
                                DataRow rw = dt.NewRow();
                                rw["ItemId"] = GrdItem.DataKeys[gvrow.RowIndex].Values["ItemId"].ToString();
                                dt.Rows.Add(rw);
                                ViewState["SupplierItem"] = dt as DataTable;
                            }
                        
                        }
                        
                    }
                }
              
                dt = ViewState["SupplierItem"] as DataTable;
     
                int flag = objBL.SupplierAction_BL(objEWA,dt);

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

        //Delete SupplierCategory
        #region DeleteSupplierCategory

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    BindSupplierGrid();
                    LoadForm();
                    BindItemGrid();
                    clear();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        protected void GrdItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (ViewState["SuppItem"] != null)
                {
                    DataSet ds = ViewState["SuppItem"] as DataSet;
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (GrdItem.DataKeys[e.Row.RowIndex].Values["ItemId"].ToString().Trim() == ds.Tables[1].Rows[i]["ItemId"].ToString().Trim())
                        {
                            CheckBox cbk = e.Row.Cells[0].FindControl("chkBxSelect") as CheckBox;
                            cbk.Checked = true;
                        }
                    }
                }
            }
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
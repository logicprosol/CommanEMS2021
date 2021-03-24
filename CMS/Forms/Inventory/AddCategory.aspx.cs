using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Inventory;
using EntityWebApp.Inventory;
using DataAccessLayer;
using System.Data;

namespace CMS.Forms.Inventory
{
    public partial class AddCategory : System.Web.UI.Page
    {

        //Objects
        #region[Objects]
        private BL_Category objBL = new BL_Category();
        private EWA_Category objEWA = new EWA_Category();
        private BindControl ObjHelper = new BindControl();
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
                        GrdCategoryBind();
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
                txtCategoryName.Enabled = false;
                txtCategoryName.Text = "";

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Item Category
        #region[Item Category Grid Bind]

        private void GrdCategoryBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.CategoryGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdCategory.DataSource = ds;
                    GrdCategory.DataBind();
                    int columncount = GrdCategory.Rows[0].Cells.Count;
                    GrdCategory.Rows[0].Cells.Clear();
                    GrdCategory.Rows[0].Cells.Add(new TableCell());
                    GrdCategory.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdCategory.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdCategory.DataSource = ds;
                    GrdCategory.DataBind();
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
                EWA_Category objEWA = new EWA_Category();
                objEWA.OrgId = orgId;
                objEWA.CategoryName = txtCategoryName.Text.Trim();
                i = objBL.CheckDuplicateCategory_BL(objEWA);
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
            BL_Category objBL = new BL_Category();
            EWA_Category objEWA = new EWA_Category();
            try
            {
                lock (this)
                {
                    if (txtCategoryName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Category Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            GrdCategoryBind();
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
                    btnNew.Enabled = false;
                    btnCancel.Enabled = true;
                    txtCategoryName.Enabled = true;

                    txtCategoryName.Text = "";

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
                txtCategoryName.Text = "";

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdCategory.PageIndex = e.NewPageIndex;

                GrdCategory.DataSource = objBL.CategoryGridBind_BL(objEWA);
                GrdCategory.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Item Category Link
        #region ItemCategoryLinkButtonClick

        protected void lnkBtnCategoryName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["CategoryId"] = GrdCategory.DataKeys[grdrow.RowIndex].Value.ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtCategoryName.Text = GrdCategory.DataKeys[grdrow.RowIndex].Values["CategoryName"].ToString();


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
                txtCategoryName.Enabled = true;

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
                    GrdCategoryBind();
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
                    objEWA.CategoryId = Convert.ToInt32(ViewState["CategoryId"].ToString());
                }
                objEWA.CategoryName = txtCategoryName.Text.Trim();

                objEWA.OrgId = orgId;

                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.CategoryAction_BL(objEWA);

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

        //Delete Item Category
        #region DeleteItemCategory

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    GrdCategoryBind();
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
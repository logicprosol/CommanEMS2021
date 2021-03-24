using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

//Caste Category
namespace CMS.Forms.Admin
{
    public partial class CasteCategory : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_CasteCategory objBL = new BL_CasteCategory();
        private EWA_CasteCategory objEWA = new EWA_CasteCategory();

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
                    try
                    {
                        LoadForm();

                        GrdCasteCategoryBind();
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
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtCasteCategoryName.Enabled = false;
                txtCasteCategoryCode.Enabled = false;
                txtCasteCategoryName.Text = "";
                txtCasteCategoryCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Catse Category
        #region[Caste Category Grid Bind]

        private void GrdCasteCategoryBind()
        {
            try
            {
               // objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.CasteCategoryGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdCasteCategory.DataSource = ds;
                    GrdCasteCategory.DataBind();
                    int columncount = GrdCasteCategory.Rows[0].Cells.Count;
                    GrdCasteCategory.Rows[0].Cells.Clear();
                    GrdCasteCategory.Rows[0].Cells.Add(new TableCell());
                    GrdCasteCategory.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdCasteCategory.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
        
                    GrdCasteCategory.DataSource = ds;
                    GrdCasteCategory.DataBind();
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
                EWA_CasteCategory objEWA = new EWA_CasteCategory();

                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                objEWA.CasteCategoryName = txtCasteCategoryName.Text.Trim();
                i = objBL.CheckDuplicateCasteCategory_BL(objEWA);
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
            BL_CasteCategory objBL = new BL_CasteCategory();
            EWA_CasteCategory objEWA = new EWA_CasteCategory();
            try
            {
                lock (this)
                {
                    if (txtCasteCategoryName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Caste Category Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            GrdCasteCategoryBind();
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
                    btnSave.Visible = true; ;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnNew.Visible = false;
                    txtCasteCategoryName.Enabled = true;
                    txtCasteCategoryCode.Enabled = true;
                    txtCasteCategoryName.Text = "";
                    txtCasteCategoryCode.Text = "";
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
                txtCasteCategoryName.Text = "";
                txtCasteCategoryCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdCasteCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdCasteCategory.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                GrdCasteCategory.DataSource = objBL.CasteCategoryGridBind_BL(objEWA);
                GrdCasteCategory.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Caste Category Link
        #region CastCategoryLinkButtonClick

        protected void lnkBtnCasteCategoryName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["CasteCategoryId"] = GrdCasteCategory.DataKeys[grdrow.RowIndex].Value.ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtCasteCategoryName.Text = GrdCasteCategory.DataKeys[grdrow.RowIndex].Values["CasteCategoryName"].ToString();
                    txtCasteCategoryCode.Text = GrdCasteCategory.DataKeys[grdrow.RowIndex].Values["Code"].ToString();

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
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtCasteCategoryName.Enabled = true;
                txtCasteCategoryCode.Enabled = true;
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
                    GrdCasteCategoryBind();
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
                    objEWA.CasteCategoryId = Convert.ToInt32(ViewState["CasteCategoryId"].ToString());
                }
                objEWA.Code = Convert.ToInt32(txtCasteCategoryCode.Text).ToString();
                objEWA.CasteCategoryName = txtCasteCategoryName.Text.Trim();
                //objEWA.Code = txtCasteCategoryCode.Text.Trim();
                //objEWA.Code = Convert.ToInt32(txtCasteCategoryCode.Text).ToString();

                //objEWA.AcademicYearId = "0";
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                objEWA.IsActive = "True";

                int flag = 0; 
                 flag  = objBL.CasteCategoryAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                       // msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                       // msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                       // msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record Deleted Successfully !!!')", true);
                    }
                    GrdCasteCategoryBind();
                }
                else
                {
                    if (strAction == "Save")
                    {
                       // msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                      //  msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                       // msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Unable to  Delete !!!')", true);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Caste Category
        #region DeleteCasteCategory

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    GrdCasteCategoryBind();
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
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
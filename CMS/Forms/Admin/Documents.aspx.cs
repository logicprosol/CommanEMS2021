using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

//Document
namespace CMS.Forms.Admin
{
    public partial class Documents : System.Web.UI.Page
    {
        //Objects

        #region[Objects]
        private BL_Documents objBL = new BL_Documents();
        private EWA_Documents objEWA = new EWA_Documents();
        database db = new database();
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
                    //To Call Form Controlles Load

                    
                        LoadForm();
                        GrdDocumentBind();
                    
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //on form load
        #region LoadRegion

        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtDocumentName.Enabled = false;
                txtDocumentType.Enabled = false;
                txtDocumentName.Text = "";
                txtDocumentType.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Documents Grid Bind
        #region[Documents Grid Bind]

        private void GrdDocumentBind()
        {
            try
            {
                objEWA.OrgId = orgId;
                DataSet ds = objBL.DocumentsGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdDocument.DataSource = ds;
                    GrdDocument.DataBind();
                    int columncount = GrdDocument.Rows[0].Cells.Count;
                    GrdDocument.Rows[0].Cells.Clear();
                    GrdDocument.Rows[0].Cells.Add(new TableCell());
                    GrdDocument.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdDocument.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdDocument.DataSource = ds;
                    GrdDocument.DataBind();
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
            int i = 0;
            try
            {
                EWA_Documents objEWA = new EWA_Documents();
                objEWA.DocumentName = txtDocumentName.Text.Trim();
                objEWA.OrgId = orgId;
                i = objBL.CheckDuplicateDocuments_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return i;
            }
        }

        #endregion

        //Save Document
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_Documents objBL = new BL_Documents();
            EWA_Documents objEWA = new EWA_Documents();
            try
            {
                lock (this)
                {
                    if (txtDocumentName.Text == "")
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
                            GrdDocumentBind();
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
                    GrdDocumentBind();
                    LoadForm();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Document
        #region DeleteDocument

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
              float  count = db.getDb_Value("select count(*) from tblStudentDoc where DocumentId='" + ViewState["DocumentId"].ToString() + "'");

                if (count != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        Action("Delete");
                        GrdDocumentBind();
                        LoadForm();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Document
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.DocumentId = Convert.ToInt32(ViewState["DocumentId"].ToString());
                }
                objEWA.DocumentName = txtDocumentName.Text.Trim();
                objEWA.DocumentType = txtDocumentType.Text.Trim();

                //Below Values Need to be pass from session
                objEWA.OrgId = Convert.ToInt32(orgId);
                objEWA.AcademicYearId = Session["AcademicYearId"].ToString();
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.DocumentAction_BL(objEWA);

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

        //AddNew
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
                    txtDocumentName.Enabled = true;
                    txtDocumentType.Enabled = true;
                    txtDocumentName.Text = "";
                    txtDocumentType.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //btn Cancel
        #region btnCancelRegion

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

        #region ClearControls

        private void ClearControls()
        {
            try
            {
                txtDocumentName.Text = "";
                txtDocumentType.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdDocument.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                GrdDocument.DataSource = objBL.DocumentsGridBind_BL(objEWA);
                GrdDocument.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DocumentLinkButtonClick
        #region DocumentLinkButtonClick

        protected void lnkBtnDocumentName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["DocumentId"] = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtDocumentName.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentName"].ToString();
                    txtDocumentType.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentType"].ToString();

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
                txtDocumentName.Enabled = true;
                txtDocumentType.Enabled = true;
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
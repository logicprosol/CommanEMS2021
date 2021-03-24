using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class FeesCategory : System.Web.UI.Page
    {
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //Objects
        #region[Objects]
        private BL_FeesCategory objBL = new BL_FeesCategory();
        private EWA_FeesCategory objEWA = new EWA_FeesCategory();

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

                        GrdFeesCategoryBind();
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
                txtFeesCategoryName.Enabled = false;
                txtFeesCategoryCode.Enabled = false;
                txtFeesCategoryName.Text = "";
                txtFeesCategoryCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Fees Category
        #region[Fees Category Grid Bind]

        private void GrdFeesCategoryBind()
        {
            try
            {
                // objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.FeesCategoryGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdFeesCategory.DataSource = ds;
                    GrdFeesCategory.DataBind();
                    int columncount = GrdFeesCategory.Rows[0].Cells.Count;
                    GrdFeesCategory.Rows[0].Cells.Clear();
                    GrdFeesCategory.Rows[0].Cells.Add(new TableCell());
                    GrdFeesCategory.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdFeesCategory.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {

                    GrdFeesCategory.DataSource = ds;
                    GrdFeesCategory.DataBind();
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
                EWA_FeesCategory objEWA = new EWA_FeesCategory();

                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                objEWA.FeesCategoryName = txtFeesCategoryName.Text.Trim();
                i = objBL.CheckDuplicateFeesCategory_BL(objEWA);
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
            BL_FeesCategory objBL = new BL_FeesCategory();
            EWA_FeesCategory objEWA = new EWA_FeesCategory();
            try
            {
                lock (this)
                {
                    if (txtFeesCategoryName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Fees Category Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            GrdFeesCategoryBind();
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
                    txtFeesCategoryName.Enabled = true;
                    txtFeesCategoryCode.Enabled = true;
                    txtFeesCategoryName.Text = "";
                    txtFeesCategoryCode.Text = "";
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
                txtFeesCategoryName.Text = "";
                txtFeesCategoryCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdFeesCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdFeesCategory.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                GrdFeesCategory.DataSource = objBL.FeesCategoryGridBind_BL(objEWA);
                GrdFeesCategory.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Fees Category Link
        #region FeesCategoryLinkButtonClick

        protected void lnkBtnFeesCategoryName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["FeesCategoryId"] = GrdFeesCategory.DataKeys[grdrow.RowIndex].Value.ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtFeesCategoryName.Text = GrdFeesCategory.DataKeys[grdrow.RowIndex].Values["FeesCategoryName"].ToString();
                    txtFeesCategoryCode.Text = GrdFeesCategory.DataKeys[grdrow.RowIndex].Values["Code"].ToString();

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
                txtFeesCategoryName.Enabled = true;
                txtFeesCategoryCode.Enabled = true;
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
                    GrdFeesCategoryBind();
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
                    objEWA.FeesCategoryId = Convert.ToInt32(ViewState["FeesCategoryId"].ToString());
                }
                //Added Ashwini More 22-sep-2020
                if (strAction == "Delete")
                {
                    float count,countAdmission;
                    int catid = Convert.ToInt32(ViewState["FeesCategoryId"].ToString());
                    count = db.getDb_Value("select count(studentId) from tblstudent where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'  and  FeesCategory='" + catid + "'");
                    countAdmission = db.getDb_Value("Select count(AdmissionID) from tblAdmissionDetails where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'  and  FeesCategory='" + catid + "'");
                    if (count != 0 || countAdmission!=0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                        return;
                    }

                }
                //
                objEWA.Code = Convert.ToInt32(txtFeesCategoryCode.Text).ToString();
                objEWA.FeesCategoryName = txtFeesCategoryName.Text.Trim();
                //objEWA.Code = txtFeesCategoryCode.Text.Trim();
                //objEWA.Code = Convert.ToInt32(txtFeesCategoryCode.Text).ToString();

             //   objEWA.AcademicYearId = ddlAcademicYear.SelectedValue;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                objEWA.IsActive = "True";

                int flag = 0;
                flag = objBL.FeesCategoryAction_BL(objEWA);

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
                    GrdFeesCategoryBind();
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
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert(' Record is already exist !!!')", true);
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
                    GrdFeesCategoryBind();
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
using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

//Acdemic Year
namespace CMS.Forms.Admin
{
    public partial class AcademicYear : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
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
                    GrdAcademicYearBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //on form load
        #region[Load Region]

        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtAcademicYear.Enabled = false;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
                txtCode.Enabled = false;
                chkboxCurrentYear.Enabled = false;
                txtAcademicYear.Text = "";
                txtStartDate.Text = "";
                txtEndDate.Text = "";
                txtCode.Text = "";
                chkboxCurrentYear.Checked = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Click AddNew
        #region[Add New]

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
                    txtAcademicYear.Enabled = true;
                    txtStartDate.Enabled = true;
                    txtEndDate.Enabled = true;
                    txtCode.Enabled = true;
                    chkboxCurrentYear.Enabled = true;
                    txtAcademicYear.Text = "";
                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                    txtCode.Text = "";
                    chkboxCurrentYear.Checked = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save AcademicYear
        #region[Save Data]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_AcademicYear objBL = new BL_AcademicYear();
            EWA_AcademicYear objEWA = new EWA_AcademicYear();
            try
            {
                lock (this)
                {
                    if (txtAcademicYear.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter AcademicYear Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            AcademicYearAction("Save");
                            GrdAcademicYearBind();
                            LoadForm();
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        // Update AcademicYear
        #region[btn Update Region]

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    AcademicYearAction("Update");
                    GrdAcademicYearBind();
                    LoadForm();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Delete AcademicYear
        #region[btn Delete Region]

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    AcademicYearAction("Delete");
                    GrdAcademicYearBind();
                    LoadForm();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Academic Year Current/Not
        #region[Academic Year check]

        protected void chkboxCurrentYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                objEWA.OrgId = orgId;
                if (chkboxCurrentYear.Checked)
                {
                    int IsCurrentYear = objBL.CheckAcademicYear_BL(objEWA);
                    if (IsCurrentYear == 1)
                    {
                        msgBox.ShowMessage("Their is already one Current Year", "Information", UserControls.MessageBox.MessageStyle.Information);
                        chkboxCurrentYear.Checked = false;
                    }
                }
                else
                {
                    msgBox.ShowMessage("You Can set this Year as a Current Year.", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Click CancelButton
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

        //Perform Action for Document

        #region[Perform Action]

        private void AcademicYearAction(string strAction)
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
                    objEWA.AcademicYearId = Convert.ToInt32(ViewState["AcademicYearId"].ToString());
                }
                objEWA.AcademicYear = txtAcademicYear.Text.Trim();
                objEWA.StartDate = Convert.ToDateTime(txtStartDate.Text);
                objEWA.EndDate = Convert.ToDateTime(txtEndDate.Text);
                objEWA.Code = txtCode.Text;
                if (chkboxCurrentYear.Checked)
                {
                    objEWA.IsCurrentYear = true;
                }
                else
                {
                    objEWA.IsCurrentYear = false;
                }
                //Below Values Need to be pass from session
                objEWA.OrgId = orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.AcademicYearAction_BL(objEWA);

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

        //Check Existing Data
        #region[Check Data]

        private int CheckData()
        {
            try
            {
                int i = 0;
                EWA_AcademicYear objEWA = new EWA_AcademicYear();
                objEWA.OrgId = orgId;
                objEWA.AcademicYear = txtAcademicYear.Text.Trim();
                i = objBL.CheckDuplicateAcademicYear_BL(objEWA);
                return i;
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //AcademicYear Grid Bind
        #region[AcademicYear Grid Bind]

        private void GrdAcademicYearBind()
        {
            try
            {
                objEWA.OrgId = orgId;
                DataSet ds = objBL.AcademicYearGridBind_BL(objEWA);

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdAcademicYear.DataSource = ds;
                    GrdAcademicYear.DataBind();
                    int columncount = GrdAcademicYear.Rows[0].Cells.Count;
                    GrdAcademicYear.Rows[0].Cells.Clear();
                    GrdAcademicYear.Rows[0].Cells.Add(new TableCell());
                    GrdAcademicYear.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdAcademicYear.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdAcademicYear.DataSource = ds;
                    GrdAcademicYear.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region[Grd Index Changed]

        protected void GrdAcademicYear_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objEWA.OrgId = orgId;
                GrdAcademicYear.PageIndex = e.NewPageIndex;

                GrdAcademicYear.DataSource = objBL.AcademicYearGridBind_BL(objEWA);
                GrdAcademicYear.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //DocumentLinkButtonClick
        #region[Academic Year Link Button Click]

        protected void lnkBtnAcademicYear_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["AcademicYearId"] = GrdAcademicYear.DataKeys[grdrow.RowIndex].Values["AcademicYearId"].ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtAcademicYear.Text = GrdAcademicYear.DataKeys[grdrow.RowIndex].Values["AcademicYear"].ToString();
                    txtStartDate.Text = GrdAcademicYear.DataKeys[grdrow.RowIndex].Values["StartDate"].ToString();
                    txtEndDate.Text = GrdAcademicYear.DataKeys[grdrow.RowIndex].Values["EndDate"].ToString();
                    txtCode.Text = GrdAcademicYear.DataKeys[grdrow.RowIndex].Values["Code"].ToString();
                    string isCurrent = GrdAcademicYear.DataKeys[grdrow.RowIndex].Values["IsCurrentYear"].ToString();
                    if (isCurrent == "True")
                    {
                        chkboxCurrentYear.Checked = true;
                    }
                    else
                    {
                        chkboxCurrentYear.Checked = false;
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
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtAcademicYear.Enabled = true;
                txtStartDate.Enabled = true;
                txtEndDate.Enabled = true;
                txtCode.Enabled = true;
                chkboxCurrentYear.Enabled = true;
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
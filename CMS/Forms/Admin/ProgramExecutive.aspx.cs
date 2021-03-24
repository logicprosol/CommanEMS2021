using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System.Web;
using System.Web.UI;

//Program Executive
namespace CMS.Forms.Admin
{
    public partial class ProgramExecutive : System.Web.UI.Page
    {
        //Objects

        #region[Objects]
        private BL_ProgramExecutive objBL = new BL_ProgramExecutive();
        private EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
        private BindControl ObjHelper = new BindControl();
        public static int orgId;
        database db = new database();
        float count,a;
        #endregion
        //Page Load
        #region PageLoad

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
                    #region CallAllMethods
                    LoadCourseTab();
                    GrdCourseBind();
                    LoadBranchTab();
                    ddlCourseBranchBind();
                    LoadClassTab();
                    ddlCourseBind();
                    //LoadDivisionTab();
                    //ddlCourseDBind();

                    #endregion
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Branch Bind
        #region[Course Branch Bind]

        private void ddlCourseBranchBind()
        {
            try
            {
                EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
                objEWA.OrgId = orgId;
                DataSet ds = objBL.BindddlCourse_BL(objEWA);
                ddlCourseB.DataSource = ds;
                ddlCourseB.DataTextField = "CourseName";
                ddlCourseB.DataValueField = "CourseId";
                ddlCourseB.DataBind();
                ddlCourseB.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Bind
        #region[Course Bind]

        private void ddlCourseBind()
        {
            try
            {
                EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
                objEWA.OrgId = orgId;
                DataSet ds = objBL.BindddlCourse_BL(objEWA);
                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Bind
        #region[Course Bind]

        //private void ddlCourseDBind()
        //{
        //    try
        //    {
        //        EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
        //        objEWA.OrgId = orgId;
        //        DataSet ds = objBL.BindddlCourse_BL(objEWA);
        //        ddlCourseD.DataSource = ds;
        //        ddlCourseD.DataTextField = "CourseName";
        //        ddlCourseD.DataValueField = "CourseId";
        //        ddlCourseD.DataBind();
        //        ddlCourseD.Items.Insert(0, "Select");
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Course Load
        #region[Course Load]

        private void LoadCourseTab()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtCourseName.Enabled = false;
                txtCourseCode.Enabled = false;
                txtCourseName.Text = "";
                txtCourseCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Branch
        #region[Load Branch]

        private void LoadBranchTab()
        {
            try
            {
                btnNewB.Visible = true;
                btnCancelB.Visible = true;
                btnSaveB.Visible = false;
                btnUpdateB.Visible = false;
                btnDeleteB.Visible = false;
                txtBranchName.Enabled = false;
                txtBranchCode.Enabled = false;
                txtBranchName.Text = "";
                txtBranchCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Class
        #region[Load Class]

        private void LoadClassTab()
        {
            try
            {
                btnNewC.Visible = true;
                btnCancelC.Visible = true;
                btnSaveC.Visible = false;
                btnUpdateC.Visible = false;
                btnDeleteC.Visible = false;
                txtClassName.Enabled = false;
                txtClassCode.Enabled = false;
                txtClassName.Text = "";
                txtClassCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Division
        #region[Load Division]

        //private void LoadDivisionTab()
        //{
        //    try
        //    {
        //        btnNewD.Visible = true;
        //        btnCancelD.Visible = true;
        //        btnSaveD.Visible = false;
        //        btnUpdateD.Visible = false;
        //        btnDeleteD.Visible = false;
        //        txtDivisionName.Enabled = false;
        //        txtDivisionCode.Enabled = false;
        //        txtDivisionName.Text = "";
        //        txtDivisionCode.Text = "";
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Update Course
        #region[Update Course]

        public void UpdateCourseTab()
        {
            try
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtCourseName.Enabled = true;
                txtCourseCode.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Branch
        #region[Update Branch]

        public void UpdateBranchTab()
        {
            try
            {
                btnUpdateB.Visible = true;
                btnDeleteB.Visible = true;
                btnSaveB.Visible = false;
                btnNewB.Visible = false;
                btnCancelB.Visible = true;
                txtBranchName.Enabled = true;
                txtBranchCode.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Class
        #region[Update Class]

        public void UpdateClassTab()
        {
            try
            {
                btnUpdateC.Visible = true;
                btnDeleteC.Visible = true;
                btnSaveC.Visible = false;
                btnNewC.Visible = false;
                btnCancelC.Visible = true;
                txtClassName.Enabled = true;
                txtClassCode.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Division
        #region[Update Division]

        //public void UpdateDivisionTab()
        //{
        //    try
        //    {
        //        btnUpdateD.Visible = true;
        //        btnDeleteD.Visible = true;
        //        btnSaveD.Visible = false;
        //        btnNewD.Visible = false;
        //        btnCancelD.Visible = true;
        //        txtDivisionName.Enabled = true;
        //        txtDivisionCode.Enabled = true;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Course Grid Bind
        #region[Course Grid Bind]

        private void GrdCourseBind()
        {
            try
            {
                EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
                //Pass it from Session
                objEWA.OrgId = orgId;
                DataSet ds = objBL.CourseGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdCourse.DataSource = ds;
                    GrdCourse.DataBind();
                    int columncount = GrdCourse.Rows[0].Cells.Count;
                    GrdCourse.Rows[0].Cells.Clear();
                    GrdCourse.Rows[0].Cells.Add(new TableCell());
                    GrdCourse.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdCourse.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdCourse.DataSource = ds;
                    GrdCourse.DataBind();
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
                EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
                objEWA.CourseName = txtCourseName.Text.Trim();
                //Pass from session
                objEWA.OrgId = orgId;
                int i = objBL.CheckDuplicateCourse_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Save Course
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_ProgramExecutive objBL = new BL_ProgramExecutive();
            EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
            try
            {
                lock (this)
                {
                    //if (txtCourseCode.Text == "")
                    //{
                    //    msgBox.ShowMessage("Course Code Not Found !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    //}
                    //else
                    if (txtCourseName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Course Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        //ViewState["CourseId"] = 0;
                        int chk = CheckData();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            Action("Save");
                            GrdCourseBind();
                            LoadCourseTab();

                            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
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
        #region UpdateCourse

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                    GrdCourseBind();
                    LoadCourseTab();

                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Course
        #region DeleteCourse

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                count = db.getDb_Value("select count(CourseId) from tblAdmissionDetails where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and  CourseId='" + ViewState["CourseId"].ToString()+ "'");
               
                if (count != 0 && count != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Is in Use !!!')", true);
                }
                else
                {
                    float CountBranch = db.getDb_Value("Select Count(BranchId) from tblBranch where CourseId='" + ViewState["CourseId"].ToString() + "'");
                    if (CountBranch != 0 && count != null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please First delete Branch For Respective Course !!!')", true);
                        return;
                    }
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        Action("Delete");
                        GrdCourseBind();
                        LoadCourseTab();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Cancel Action
        #region CancelRegion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCourseTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Course
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.CourseId = ViewState["CourseId"].ToString();
                }
                objEWA.CourseName = txtCourseName.Text.Trim();
                objEWA.CourseCode = txtCourseCode.Text.Trim();

                //Below Values Need to be pass from session
                objEWA.OrgId = orgId;
                objEWA.AcademicYearId = "1";
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.CourseAction_BL(objEWA);

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
                    GrdCourseBind();
                    LoadCourseTab();
                }
                else if (flag == -1)
                {
                    string msg = "Data is  Already exist!!!";
                    msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);
                    
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
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtCourseName.Enabled = true;
                txtCourseCode.Enabled = true;
                txtCourseName.Text = "";
                txtCourseCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //EnableControls
        #region EnableControls

        private void EnableControls()
        {
            try
            {
                txtCourseCode.Enabled = true;
                txtCourseName.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //ClearControls
        #region ClearControls

        private void ClearControls()
        {
            try
            {
                txtCourseCode.Text = "";
                txtCourseName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdCourse.PageIndex = e.NewPageIndex;
                //SelectData();
                objEWA.OrgId = orgId;
                GrdCourse.DataSource = objBL.CourseGridBind_BL(objEWA);
                GrdCourse.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //CourseLinkButtonClick
        #region CourseLinkButtonClick

        protected void lnkBtnCourseName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["CourseId"] = GrdCourse.DataKeys[grdrow.RowIndex].Values["CourseId"].ToString();
                    txtCourseCode.Text = GrdCourse.DataKeys[grdrow.RowIndex].Values["CourseCode"].ToString();
                    txtCourseName.Text = GrdCourse.DataKeys[grdrow.RowIndex].Values["CourseName"].ToString();

                    UpdateCourseTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For BranchTab

        #region BranchTab

        protected void ddlCourseB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrdBranchBind();
                txtBranchName.Text = "";
                txtBranchCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //AddNewButtonToAddBranch
        #region AddBranch

        protected void btnNewB_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveB.Visible = true; ;
                btnUpdateB.Visible = false;
                btnDeleteB.Visible = false;
                btnNewB.Visible = false;
                txtBranchName.Enabled = true;
                txtBranchCode.Enabled = true;
                txtBranchName.Text = "";
                txtBranchCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SaveBranch
        #region SaveBranch

        protected void btnSaveB_Click(object sender, EventArgs e)
        {
            try
            {
                ActionB("Save");
               // Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Branch
        #region[Perform Action]

        private void ActionB(string strAction)
        {
            try
            {
                objEWA.ActionB = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.BranchId = ViewState["BranchId"].ToString();
                }
                objEWA.BranchName = txtBranchName.Text.Trim();
                objEWA.BranchCode = txtBranchCode.Text.Trim();
                if (ddlCourseB.SelectedIndex != 0)
                {
                    objEWA.CourseId = ddlCourseB.SelectedValue.ToString();
                }
                //Pass these values through Session
                // objEWA.OrgId =Session["OrgId"].ToString();
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.BranchAction_BL(objEWA);

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
                    GrdBranchBind();
                    LoadBranchTab();
                }
                else if (flag == -1)
                {
                    string msg = "Data is  Already exist!!!";
                    msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);
                    
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

        //UpdateBranch
        #region UpdateBranch

        protected void btnUpdateB_Click(object sender, EventArgs e)
        {
            try
            {

               
                   ActionB("Update");
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //DeleteBranch
        #region DeleteBranch

        protected void btnDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                count = db.getDb_Value("select count(BranchId) from tblAdmissionDetails where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'  and BranchId='" + ViewState["BranchId"].ToString()+ "'  ");

                 if (count != 0 && count != null)
                 {
                     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                 }
                 else
                 {
                     ActionB("Delete");
                     GrdBranchBind();
                 }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //CancelBranch
        #region CancelBranch

        protected void btnCancelB_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBranchTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Branch Grid Bind
        #region[Branch Grid Bind]

        private void GrdBranchBind()
        {
            try
            {
                objEWA.CourseId = ddlCourseB.SelectedValue.ToString();
                //Send this parameter from session
                // objEWA.OrgId =Session["OrgId"].ToString();
                DataSet ds = objBL.BranchGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdBranch.DataSource = ds;
                    GrdBranch.DataBind();
                    int columncount = GrdBranch.Rows[0].Cells.Count;
                    GrdBranch.Rows[0].Cells.Clear();
                    GrdBranch.Rows[0].Cells.Add(new TableCell());
                    GrdBranch.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdBranch.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdBranch.DataSource = ds;
                    GrdBranch.DataBind();                 
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdBranch.PageIndex = e.NewPageIndex;
                //objEWA.OrgId =Session["OrgId"].ToString();
                objEWA.CourseId = ddlCourseB.SelectedValue.ToString();
                GrdBranch.DataSource = objBL.BranchGridBind_BL(objEWA);
                GrdBranch.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //BranchLinkButtonClick
        #region BranchLinkButtonClick

        protected void lnkBtnBranchName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["BranchId"] = GrdBranch.DataKeys[grdrow.RowIndex].Value.ToString();
                    txtBranchName.Text = GrdBranch.DataKeys[grdrow.RowIndex].Values["BranchName"].ToString();
                    txtBranchCode.Text = GrdBranch.DataKeys[grdrow.RowIndex].Values["BranchCode"].ToString();

                    UpdateBranchTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//

        //AddNewButtonToAddClass
        #region AddClass

        protected void btnNewC_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveC.Visible = true; ;
                btnUpdateC.Visible = false;
                btnDeleteC.Visible = false;
                btnNewC.Visible = false;
                txtClassName.Enabled = true;
                txtClassCode.Enabled = true;
                txtClassName.Text = "";
                txtClassCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Index
        #region[Coursr Index Changed]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBranchCBind();
                //GrdClassBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch grid
        #region[Branch Grid]

        private void ddlBranchCBind()
        {
            try
            {
                EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                DataSet ds = objBL.BindddlBranchesD_BL(objEWA);
                ddlBranchC.DataSource = ds;
                ddlBranchC.DataTextField = "BranchName";
                ddlBranchC.DataValueField = "BranchId";
                ddlBranchC.DataBind();
                ddlBranchC.Items.Insert(0, "Select");
                GrdClass.DataSource = null;
                GrdClass.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Selected Index Changed
        #region[Branch Index changed]

        protected void ddlBranchC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrdClassBind();
                txtClassCode.Text = "";
                txtClassName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SaveClass
        #region SaveClass

        protected void btnSaveC_Click(object sender, EventArgs e)
        {
            try
            {
                ActionC("Save");
               // Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Class
        #region[Perform Action]

        private void ActionC(string strAction)
        {
            try
            {
                objEWA.ActionC = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.ClassId = ViewState["ClassId"].ToString();
                }
             
                objEWA.ClassCode = txtClassCode.Text.Trim();
                objEWA.ClassName = txtClassName.Text.Trim();
                //if (ddlCourse.SelectedIndex != 0)
                //{
                //    objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                //}

                if (ddlBranchC.SelectedIndex != 0)
                {
                    objEWA.BranchId = ddlBranchC.SelectedValue.ToString();
                }

                //Below Values Need to be pass from session
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.ClassAction_BL(objEWA);

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
                    GrdClassBind();
                    LoadClassTab();
                }
                else if (flag == -1)
                {
                    string msg ="Data is  Already exist!!!";
                    msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);
                  
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

        //UpdateBranch
        #region UpdateClass

        protected void btnUpdateC_Click(object sender, EventArgs e)
        {
            try
            {
                
               {
                   ActionC("Update");
               }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //DeleteClass
        #region DeleteClass

        protected void btnDeleteC_Click(object sender, EventArgs e)
        {
            try
            {

                count = db.getDb_Value("select count(ClassId) from tblAdmissionDetails where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'  and  ClassId='" + ViewState["ClassId"] + "'");

                if (count != 0 && count != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    ActionC("Delete");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //CancelClass
        #region CancelClass

        protected void btnCancelC_Click(object sender, EventArgs e)
        {
            try
            {
                LoadClassTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //GridClassBind
        #region[ClassGridBind]

        private void GrdClassBind()
        {
            try
            {
                EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
                //Pass it from Session
                // objEWA.OrgId =Session["OrgId"].ToString();
                objEWA.BranchId = ddlBranchC.SelectedValue.ToString();
                DataSet ds = objBL.ClassGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdClass.DataSource = ds;
                    GrdClass.DataBind();
                    int columncount = GrdClass.Rows[0].Cells.Count;
                    GrdClass.Rows[0].Cells.Clear();
                    GrdClass.Rows[0].Cells.Add(new TableCell());
                    GrdClass.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdClass.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdClass.DataSource = ds;
                    GrdClass.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{

            //    GrdClass.PageIndex = e.NewPageIndex;
            //    //objEWA.OrgId = orgId;
            //    GrdClass.DataSource = objBL.ClassGridBind_BL(objEWA);
            //    GrdClass.DataBind();
              
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}

            try
            {
                GrdClass.PageIndex = e.NewPageIndex;
                GrdClassBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //BranchLinkButtonClick
        #region ClassLinkButtonClick

        protected void lnkBtnClassName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["ClassId"] = GrdClass.DataKeys[grdrow.RowIndex].Value.ToString();
                    txtClassCode.Text = GrdClass.DataKeys[grdrow.RowIndex].Values["ClassCode"].ToString();
                    txtClassName.Text = GrdClass.DataKeys[grdrow.RowIndex].Values["ClassName"].ToString();

                    UpdateClassTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For DivisionTab

        //Data Binding
        #region Course Index changed

        //protected void ddlCourseD_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //GrdClassBind();
        //        //ddlClassDBind();
        //        ddlBranchDBind();
        //        txtDivisionName.Text = "";
        //        txtDivisionCode.Text = "";
        //        GrdDivision.DataSource = null;
        //        GrdDivision.DataBind();
        //        ddlClassD.SelectedIndex = 0;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Branch Index Changed
        #region[Branch Index Changed]

        //protected void ddlBranchD_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ddlClassDBind();
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Class Bind
        #region[Class Bind]

        //private void ddlClassDBind()
        //{
        //    try
        //    {
        //        EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
        //        objEWA.BranchId = ddlBranchD.SelectedValue.ToString();
        //        DataSet ds = objBL.BindddlClasses_BL(objEWA);
        //        ddlClassD.DataSource = ds;
        //        ddlClassD.DataTextField = "ClassName";
        //        ddlClassD.DataValueField = "ClassId";
        //        ddlClassD.DataBind();
        //        ddlClassD.Items.Insert(0, "Select");
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Branch Grid Bind
        #region[Branch Grid Bind]

        //private void ddlBranchDBind()
        //{
        //    try
        //    {
        //        EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
        //        objEWA.CourseId = ddlCourseD.SelectedValue.ToString();
        //        DataSet ds = objBL.BindddlBranchesD_BL(objEWA);
        //        ddlBranchD.DataSource = ds;
        //        ddlBranchD.DataTextField = "BranchName";
        //        ddlBranchD.DataValueField = "BranchId";
        //        ddlBranchD.DataBind();
        //        ddlBranchD.Items.Insert(0, "Select");
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Class Index Changed
        #region[Class Index Changed]

        //protected void ddlClassD_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //GrdDivisionBind();
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //AddNewButtonToAddDivision
        #region AddDivision

        //protected void btnNewD_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        btnSaveD.Visible = true; ;
        //        btnUpdateD.Visible = false;
        //        btnDeleteD.Visible = false;
        //        btnNewD.Visible = false;
        //        txtDivisionName.Enabled = true;
        //        txtDivisionCode.Enabled = true;
        //        txtDivisionName.Text = "";
        //        txtDivisionCode.Text = "";
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion
        //SaveDivision
        #region SaveDivision

        protected void btnSaveD_Click(object sender, EventArgs e)
        {
            try
            {
                ActionD("Save");
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Division
        #region[Perform Action]

        private void ActionD(string strAction)
        {
            try
            {
                objEWA.ActionD = strAction;
                //objEWA.DivisionId = Convert.ToInt32(txtDivisionId.Text);
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.DivisionId = ViewState["DivisionId"].ToString();
                }
                //if (ddlCourseD.SelectedIndex != 0)
                //{
                //    objEWA.CourseId = ddlCourseD.SelectedValue.ToString();
                //}
                //if (ddlBranchD.SelectedIndex != 0)
                //{
                //    objEWA.BranchId = ddlBranchD.SelectedValue.ToString();
                //}
                //if (ddlClassD.SelectedIndex != 0)
                //{
                //    objEWA.ClassId = ddlClassD.SelectedValue.ToString();
                //}
                //objEWA.DivisionName = txtDivisionName.Text.Trim();
                //objEWA.DivisionCode = txtDivisionCode.Text.Trim();

                //Below Values Need to be pass from session
                //objEWA.OrgId =Session["OrgId"].ToString();

                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.DivisionAction_BL(objEWA);
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
                    //GrdDivisionBind();
                    //LoadDivisionTab();
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

        //UpdateBranch
        #region UpdateDivision

        protected void btnUpdateD_Click(object sender, EventArgs e)
        {
            try
            {
                ActionD("Update");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //DeleteDivision
        #region DeleteDivision

        protected void btnDeleteD_Click(object sender, EventArgs e)
        {
            try
            {
                ActionD("Delete");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //AddNewButtonToAddDivision
        #region CancelDivision

        //protected void btnCancelD_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LoadDivisionTab();
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //GridDivisionBind
        #region[DivisionGridBind]

        //private void GrdDivisionBind()
        //{
        //    try
        //    {
        //        EWA_ProgramExecutive objEWA = new EWA_ProgramExecutive();
        //        //Pass it from Session
        //        objEWA.ClassId = ddlClassD.SelectedValue;
        //        DataSet ds = objBL.DivisionGridBind_BL(objEWA);
        //        if (ds.Tables[0].Rows.Count == 0 || ds == null)
        //        {
        //            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //            GrdDivision.DataSource = ds;
        //            GrdDivision.DataBind();
        //            int columncount = GrdDivision.Rows[0].Cells.Count;
        //            GrdDivision.Rows[0].Cells.Clear();
        //            GrdDivision.Rows[0].Cells.Add(new TableCell());
        //            GrdDivision.Rows[0].Cells[0].ColumnSpan = columncount;
        //            GrdDivision.Rows[0].Cells[0].Text = "No Records Found";
        //        }
        //        else
        //        {
        //            GrdDivision.DataSource = ds;
        //            GrdDivision.DataBind();
        //        }
        //    }

        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Page Indext Createds
        #region GrdIndexChanged

        //protected void GrdDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        GrdDivision.PageIndex = e.NewPageIndex;
        //        GrdDivisionBind();
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //BranchLinkButtonClick
        #region DivisionLinkButtonClick

        protected void lnkBtnDivisionName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    //ViewState["DivisionId"] = GrdDivision.DataKeys[grdrow.RowIndex].Value.ToString();
                    //txtDivisionCode.Text = GrdDivision.DataKeys[grdrow.RowIndex].Values["DivisionCode"].ToString();
                    //txtDivisionName.Text = GrdDivision.DataKeys[grdrow.RowIndex].Values["DivisionName"].ToString();

                    //UpdateDivisionTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        

        #endregion
        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
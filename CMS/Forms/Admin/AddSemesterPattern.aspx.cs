using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Web;

//Add Semester Pattern
namespace CMS.Forms.Admin
{
    public partial class AddSemesterPattern : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_Semester objBL = new BL_Semester();
        private EWA_Semester objEWA = new EWA_Semester();

        private BindControl ObjHelper = new BindControl();
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
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            if (!IsPostBack)
            {
                try
                {
                    BindCourses();
                    // GrdSemesterBind();
                    LoadForm();
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                }
            }
        }
        #endregion

        //Bind Class
        #region[Bind Class]
        private void BindCourses()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Convert.ToString(orgId);
                DataSet ds = objBL.BindCourses_BL(objEWA);

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

        //Bind Branches
        #region[Bind Branches]
        private void BindBranches()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objBL.BindBranches_BL(objEWA);

                ddlBranch.DataSource = ds;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Bind Classes
        #region[Bind Classes]
        private void BindClasses()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();

                DataSet ds = objBL.BindClass_BL(objEWA);

                ddlClass.DataSource = ds;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Course Index Changed
        #region[Course Index Changed]
        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranches();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Branch Insex Changed
        #region[Branch Index Changed]
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClasses();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Class Index Changed
        #region[Class Index Changed]
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        #endregion

        //Pattern Index Changed
        #region[Pattern Index Changed]
        protected void rblPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlClass.SelectedItem.Text.Equals("Select"))
                {

                }
                else 
                GrdSemesterBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Form Load
        #region[Form Load]
        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtSemesterName.Enabled = false;
                txtSemesterName.Text = "";
                rblPattern.ClearSelection();
                rblPattern.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Call Update
        #region[Call Update]
        public void CallUpdate()
        {
            try
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtSemesterName.Enabled = true;
                rblPattern.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Save Button
        #region[Save Button]
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    if (txtSemesterName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Pattern Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
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
                            GrdSemesterBind();
                            LoadForm();
                            //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
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
        #region UpdateSubject

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                    GrdSemesterBind();
                    LoadForm();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Subject
        #region DeleteSemester

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    GrdSemesterBind();
                    LoadForm();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //New Button
        #region[New Button]
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtSemesterName.Enabled = true;
                txtSemesterName.Text = "";
                rblPattern.ClearSelection();
                rblPattern.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Cancel Button
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

        //Check Existing Data
        #region[Check Data]

        private int CheckData()
        {
            int i = 0;
            try
            {
                //EWA_Semester objEWA = new EWA_Semester();
                objEWA.SemesterName = txtSemesterName.Text.Trim();
                objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                i = objBL.CheckDuplicatePatterns_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return i;
            }

            
        }

        #endregion

        //Perform Action for Subject
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.SemesterId = Convert.ToInt32(ViewState["SemesterId"].ToString());
                }
                objEWA.SemesterName = txtSemesterName.Text.Trim();
                //     if (rblPattern.SelectedValue=="Semester")
                // {
                objEWA.Pattern = rblPattern.SelectedValue;
                // }

                //objEWA.Pattern = txtPattern.Text.Trim();

                objEWA.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
                objEWA.BranchId = Convert.ToInt32(ddlBranch.SelectedValue);
                objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue);

                //Below Values Need to be pass from session
                objEWA.OrgId = orgId;
                objEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);
                objEWA.UserId = Convert.ToInt32(Session["UserCode"]);
                objEWA.IsActive = true;

                int flag = objBL.SemesterAction_BL(objEWA);

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
                    //GrdDocumentBind();
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

        //Semester Grid Bind
        #region[Semester Grid Bind]

        private void GrdSemesterBind()
        {
            try
            {
                EWA_Semester objEWA = new EWA_Semester();
                objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                DataSet ds = new DataSet();
                ds = objBL.SemesterGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdSemester.DataSource = ds;
                    GrdSemester.DataBind();
                    int columncount = GrdSemester.Rows[0].Cells.Count;
                    GrdSemester.Rows[0].Cells.Clear();
                    GrdSemester.Rows[0].Cells.Add(new TableCell());
                    GrdSemester.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdSemester.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdSemester.DataSource = ds;
                    GrdSemester.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SubjectLinkButtonClick
        #region SemesterLinkButtonClick

        protected void lnkBtnSemesterName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["SemesterId"] = GrdSemester.DataKeys[grdrow.RowIndex].Values["SemesterId"].ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtSemesterName.Text = GrdSemester.DataKeys[grdrow.RowIndex].Values["SemesterName"].ToString();
                    rblPattern.SelectedValue = GrdSemester.DataKeys[grdrow.RowIndex].Values["Pattern"].ToString();
                    //ddlCourse.SelectedValue = GrdSubject.DataKeys[grdrow.RowIndex].Values["CourseId"].ToString();
                    //BindBranch();
                    //BindClass();
                    //ddlBranch.SelectedValue = GrdSubject.DataKeys[grdrow.RowIndex].Values["BranchId"].ToString();
                    //ddlClass.SelectedValue = GrdSubject.DataKeys[grdrow.RowIndex].Values["ClassId"].ToString();
                    CallUpdate();
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
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
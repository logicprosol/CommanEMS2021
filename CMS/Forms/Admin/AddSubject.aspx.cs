using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Web;
using System.Web.UI;

namespace CMS.Forms.Admin
{
    public partial class AddSubject : System.Web.UI.Page
    {
        //Objects

        #region[Objects]
        private BL_Subject objBL = new BL_Subject();
        private EWA_Subject objEWA = new EWA_Subject();
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
                orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                } if (!IsPostBack)
                {
                    try
                    {
                        BindCourses();
                        LoadForm();
                        //GrdSubjectBind();
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

        //LoadForm
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
                txtSubject.Enabled = false;
                txtSubjectCode.Enabled = false;
                txtSubject.Text = "";
                txtSubjectCode.Text = "";
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
                txtSubject.Enabled = true;
                txtSubjectCode.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Courses
        #region[Bind Courses]

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
               // ddlCourse.Items.Insert(0, "Select");
                ddlCourse.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Branch
        #region[Bind Branch]

        private void BindBranch()
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
                //ddlBranch.Items.Insert(0, "Select");
                ddlBranch.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Class
        #region[Bind Class]

        private void BindClass()
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
               // ddlClass.Items.Insert(0, "Select");
                ddlClass.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Semester
        #region[Bind Semester]

        private void BindSemester()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();

                DataSet ds = objBL.BindSemester_BL(objEWA);

                ddlSemester.DataSource = ds;
                ddlSemester.DataTextField = "SemesterName";
                ddlSemester.DataValueField = "SemesterId";
                ddlSemester.DataBind();
               // ddlSemester.Items.Insert(0, "Select");
                ddlSemester.Items.Insert(0, new ListItem("Select"));
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
                if (ddlCourse.SelectedItem.Text.Equals("Select"))
                {
                    ddlBranch.SelectedIndex = -1;
                    ddlClass.SelectedIndex = -1;
                    ddlSemester.SelectedIndex = -1;
                }
                else
                {
                    BindBranch();
                }
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Index Changed
        #region[Branch Index Changed]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
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
            try
            {
               // BindSemester();
                GrdSubjectBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Semester Index Changed
        #region[Semester Index changed]

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrdSubjectBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region[Subject Index Changed]

        protected void GrdSubject_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
        }

        #endregion

        //NewButton
        #region[New Button]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtSubject.Enabled = true;
                txtSubjectCode.Enabled = true;
                txtSubject.Text = "";
                txtSubjectCode.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //CancelButton
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

        //saveData
        #region[Save Data]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BL_Subject objBL = new BL_Subject();
            EWA_Subject objEWA = new EWA_Subject();
            try
            {
                lock (this)
                {
                    if (txtSubject.Text == "")
                    {
                        // msgBox.ShowMessage("Please Enter Document Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        Action("Save");
                       // Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
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
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Subject
        #region DeleteSubject

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               float count = db.getDb_Value("select count(*) from tblEmpAssignSubject where SubjectId='" + ViewState["SubjectId"].ToString() + "'");

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
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
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
                    objEWA.SubjectId = Convert.ToInt32(ViewState["SubjectId"].ToString());
                }
                objEWA.SubjectName = txtSubject.Text.Trim();
                objEWA.SubjectCode = txtSubjectCode.Text.Trim();
                objEWA.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
                objEWA.BranchId = Convert.ToInt32(ddlBranch.SelectedValue);
                objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                //objEWA.SemesterId = Convert.ToInt32(ddlSemester.SelectedValue);
                //Below Values Need to be pass from session
                objEWA.OrgId = orgId;
                objEWA.AcademicYearId = Convert.ToInt32(Session["AcademicId"]);
                objEWA.UserId = Convert.ToInt32(Session["UserCode"]);
                objEWA.IsActive = true;

                int flag = objBL.SubjectAction_BL(objEWA);

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
                    GrdSubjectBind();
                    txtSubject.Text = string.Empty;
                   // LoadForm();
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

        //Subjects Grid Bind
        #region[Subject Grid Bind]

        private void GrdSubjectBind()
        {
            try
            {
                EWA_Subject objEWA = new EWA_Subject();
                objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                DataSet ds = objBL.SubjectGridBind_BL(objEWA);
                GrdSubject.DataSource = ds;
                GrdSubject.DataBind();
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //SubjectLinkButtonClick
        #region SubjectLinkButtonClick

        protected void lnkBtnSubjectName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["SubjectId"] = GrdSubject.DataKeys[grdrow.RowIndex].Values["SubjectId"].ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtSubject.Text = GrdSubject.DataKeys[grdrow.RowIndex].Values["SubjectName"].ToString();
                    txtSubjectCode.Text = GrdSubject.DataKeys[grdrow.RowIndex].Values["SubjectCode"].ToString();
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

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ddlCourse.Items.Clear();
            ddlCourse.Items.Insert(0, new ListItem("Select"));
            BindCourses();
            ddlClass.Items.Clear();
            ddlClass.Items.Insert(0, new ListItem("Select"));
            BindClass();
            ddlBranch.Items.Clear();
            ddlBranch.Items.Insert(0, new ListItem("Select"));
            BindBranch();
            txtSubject.Text = string.Empty;

            GrdSubject.DataSource = null;
            GrdSubject.DataBind();

            btnNew.Visible = true;
            btnNew.Enabled = true;
            btnSave.Visible = false;
            btnSave.Visible = false;
            txtSubject.Enabled = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }
    }
}
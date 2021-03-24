using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer.Admin;
using EntityWebApp;
using EntityWebApp.Admin;

//Batch Allotment
namespace CMS.Forms.Admin
{
    public partial class BatchAllotment : System.Web.UI.Page
    {
        // Global Variable Declaration

        #region Glogal Declaration

        public static int OrgID=0;
        public static Int32 AcademicYearId;
        public static string strAction;
        private EWA_Common objEWA = new EWA_Common();
        private BL_Common objBL = new BL_Common();

        private EWA_BatchAllotment objEWABatch = new EWA_BatchAllotment();
        private BL_BatchAllotment objBLBatch = new BL_BatchAllotment();

        #endregion Glogal Declaration
       
        // Page Load

        #region Page Load Code

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OrgID = Convert.ToInt32(Session["OrgId"]);
                AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);

                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    try
                    {
                        BindCourse(OrgID);
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

        #endregion Page Load Code

        // Biding Methods

        #region Biding Comman Methods

        private void BindCourse(int OrgID)
        {
            try
            {
                objEWA.OrgId = Convert.ToString(OrgID);
                DataSet ds = objBL.BindCourses_BL(objEWA);
                ddlCourses.DataSource = ds;
                ddlCourses.DataTextField = "CourseName";
                ddlCourses.DataValueField = "CourseId";
                ddlCourses.DataBind();
                ddlCourses.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion Biding Comman Methods

        //  Bind Class to Drop Down
        #region[Bind Class]

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
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

        //Bind Branches
        #region[Bind Branches]

        private void BindBranches()
        {
            try
            {
                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.CourseId = ddlCourses.SelectedValue;

                DataSet ds = objBL.BindBranches_BL(objEWA);

                ddlBranches.DataSource = ds;
                ddlBranches.DataTextField = "BranchName";
                ddlBranches.DataValueField = "BranchId";
                ddlBranches.DataBind();
                ddlBranches.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branches Index Changed
        #region[Branches Index Changed]

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objEWA.BranchId = ddlBranches.SelectedValue;

                DataSet ds = objBL.BindClass_BL(objEWA);
                ddlClasses.DataSource = ds;
                ddlClasses.DataTextField = "ClassName";
                ddlClasses.DataValueField = "ClassId";
                ddlClasses.DataBind();
                ddlClasses.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Classes Index Changed
        #region[Classes Index Changed]

        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindStudentsDetails();
                BindDivision();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Division
        #region[Bind Division]

        private void BindDivision()
        {
            try
            {
                objEWA.ClassId = ddlClasses.SelectedValue;

                DataSet ds = objBL.BindDivision_BL(objEWA);

                ddlDivision.DataSource = ds;

                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "DivisionId";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Student Details
        #region[Bind Student Details]

        private void BindStudentsDetails()
        {
            try
            {
                objEWABatch.OrgId = Convert.ToString(Session["OrgId"]);
                objEWABatch.AcademicYearId = AcademicYearId;
                objEWABatch.CourseId = ddlCourses.SelectedValue;
                objEWABatch.BranchId = ddlBranches.SelectedValue;
                objEWABatch.ClassId = ddlClasses.SelectedValue;

                DataSet ds = objBLBatch.BL_StudentData(objEWABatch);

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    grdBatchAllotment.DataSource = ds;
                    grdBatchAllotment.DataBind();
                    int columncount = grdBatchAllotment.Rows[0].Cells.Count;
                    grdBatchAllotment.Rows[0].Cells.Clear();
                    grdBatchAllotment.Rows[0].Cells.Add(new TableCell());
                    grdBatchAllotment.Rows[0].Cells[0].ColumnSpan = columncount;
                    grdBatchAllotment.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    grdBatchAllotment.DataSource = ds;
                    grdBatchAllotment.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Button
        #region[Save Button]

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            DataTable StudentDataTable = new DataTable();

            StudentDataTable.Columns.Add("StudentID");

            try
            {
                int UserCode = 0;

                foreach (GridViewRow gvrow in grdBatchAllotment.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");

                    if (chk != null && chk.Checked)
                    {
                        UserCode = Convert.ToInt32(grdBatchAllotment.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString());
                    }

                    // Set Division

                    objEWABatch.Action = "Update";
                    objEWABatch.DivisionId = ddlDivision.SelectedValue;

                    StudentDataTable.Rows.Add(UserCode);
                }

                int flag = objBLBatch.SetDivision(objEWABatch, StudentDataTable);
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

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
          //  msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }


        #endregion

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
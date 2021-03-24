using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusinessAccessLayer;
using EntityWebApp;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

namespace CMS.Forms.Admin
{
    public partial class DeleteConfirmAdmission : System.Web.UI.Page
    {

        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        int orgId = 0;
       int indexOfColumn = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
             orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }

            if (!IsPostBack)
            {

                BindCourse();
                DDLAcademicYear.SelectedIndex = 0;
             //                                                             DDLAcademicYear.SelectedIndex = DDLAcademicYear.Items.Count - 1;





            }

        }
        private DataView dvBranch = null;
        private DataView dvClass = null;
        private DataView dvDivision = null;
        private DataView dvStudentData = null;


        #region[Bind Course]

        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];
                ViewState["dvDivision"] = ds.Tables[4];
                ViewState["dvStudentData"] = ds.Tables[5];

                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));




                ddlCasteCategory.DataSource = ds.Tables[1];
                ddlCasteCategory.DataTextField = "CasteCategoryName";
                ddlCasteCategory.DataValueField = "CasteCategoryId";
                ddlCasteCategory.DataBind();
                ddlCasteCategory.Items.Insert(0, new ListItem("---Select---", "0"));

                DDLAcademicYear.DataSource = ds.Tables[7];
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
                DDLAcademicYear.Items.Insert(0, new ListItem("---Select---", "0"));






                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));



                if (IsPostBack)
                {
                    GrdStudent.DataSource = ds.Tables[5];
                    GrdStudent.DataBind();
                    gvPrint.DataSource = ds.Tables[5];
                    gvPrint.DataBind();
                    ViewState["PrintData"] = ds.Tables[5];
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Changed
        #region[Course Changed]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        protected void ddlCasteCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData(); printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void GetStudentData()
        {
            string strQuery = null;
            dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);

            ///////////////////////////////////////////////////////
            if (ddlCourse.SelectedValue != "0")
            {
                if (ddlCasteCategory.SelectedValue == "0" && txtStudName.Text.Length == 0 && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (ddlCasteCategory.SelectedValue != "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (txtStudName.Text.Length != 0)
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [CourseId] = " + ddlCourse.SelectedValue + "";
                }


                if (ddlCasteCategory.SelectedValue != "0" && txtStudName.Text.Length != 0)
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [StudentName] like '"
                    + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + "";
                }
                if (ddlCasteCategory.SelectedValue != "0" && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [CourseId] = " + ddlCourse.SelectedValue + " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
                if (txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue +
                    " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
                if (ddlCasteCategory.SelectedValue != "0" && txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [StudentName] like '"
                    + txtStudName.Text + "%' And [CourseId] = " + ddlCourse.SelectedValue + " And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            else if (ddlCasteCategory.SelectedValue != "0")
            {
                if (ddlCourse.SelectedValue == "0" && txtStudName.Text.Length == 0 && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[Caste] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (txtStudName.Text.Length != 0)
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [Caste] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [Caste] = '" + ddlCasteCategory.SelectedItem.Text + "'";
                }
                if (txtStudName.Text.Length != 0 && DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%' And [Caste] = '" + ddlCasteCategory.SelectedItem.Text + "' And [AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            else if (txtStudName.Text.Length != 0)
            {
                if (ddlCourse.SelectedValue == "0" && ddlCasteCategory.SelectedValue == "0" && DDLAcademicYear.SelectedValue == "0")
                {
                    strQuery = "[StudentName] like '" + txtStudName.Text + "%'";
                }
                if (DDLAcademicYear.SelectedValue != "0")
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue + " And [StudentName] like '" + txtStudName.Text + "%'";
                }
            }
            else if (DDLAcademicYear.SelectedValue != "0")
            {
                if (ddlCourse.SelectedValue == "0" && ddlCasteCategory.SelectedValue == "0" && txtStudName.Text.Length == 0)
                {
                    strQuery = "[AcademicYearId] = " + DDLAcademicYear.SelectedValue;
                }
            }
            /////////////////////////////////////////////////////            
            if (ddlBranch.SelectedValue != "0")
            {
                strQuery = strQuery + " And [BranchId] = " + ddlBranch.SelectedValue + "";
            }
            if (ddlClass.SelectedValue != "0")
            {
                strQuery = strQuery + " And [ClassId] = " + ddlClass.SelectedValue + "";
            }

            dvStudentData.RowFilter = strQuery;
            GrdStudent.DataSource = dvStudentData;
            GrdStudent.DataBind();
            ViewState["PrintData"] =
            ViewState["PrintableData"] = strQuery;
            //ViewState["PrintableData"] = dvStudentData;
        }

        //Bind Branch
        #region[Bind Branch]

        private void BindBranch()
        {
            try
            {
                dvBranch = new DataView(ViewState["dvBranch"] as DataTable);
                dvBranch.RowFilter = "[CourseId] = " + ddlCourse.SelectedValue + "";
                ddlBranch.DataSource = dvBranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));



                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));



                GetStudentData();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Changed
        #region[Branch Changed]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
                printabledata();
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
                dvClass = new DataView(ViewState["dvClass"] as DataTable);
                dvClass.RowFilter = "[BranchId] = " + ddlBranch.SelectedValue + "";
                ddlClass.DataSource = dvClass;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));







                GetStudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Selected Class
        #region[Class Changed]

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindDivision();
                printabledata();
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
                //dvDivision = new DataView(ViewState["dvDivision"] as DataTable);
                //dvDivision.RowFilter = "[ClassId] = " + ddlClass.SelectedValue + "";
                //ddlDivision.DataSource = dvDivision;
                //ddlDivision.DataTextField = "DivisionName";
                //ddlDivision.DataValueField = "DivisionId";
                //ddlDivision.DataBind();
                //ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));
                GetStudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Division Changing
        #region[Division Changing]

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        #region StudentLinkButtonClick

        protected void lnkBtnStudentName_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                // throw;
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion CreateAccouncement Code


        protected void DDLAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStudentData();
                printabledata();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void txtStudName_TextChanged(object sender, EventArgs e)
        {
            GetStudentData(); printabledata();
        }
        public void printabledata()
        {
            DataTable dt = new DataTable();
            if (ViewState["PrintableData"] != null)
            {
                dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
                dvStudentData.RowFilter = ViewState["PrintableData"].ToString();
                dt = dvStudentData.ToTable();
            }
            else
            {
                dt = ViewState["PrintData"] as DataTable;
            }


            DataSet ReportData = new DataSet();
            ReportData.Tables.Add(dt);
            HttpContext.Current.Session.Remove("ReportData");
            HttpContext.Current.Session.Add("ReportData", ReportData);
            gvPrint.DataSource = dt;
            gvPrint.DataBind();
        }
        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (ViewState["PrintableData"] != null)
            {
                dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
                dvStudentData.RowFilter = ViewState["PrintableData"].ToString();
                dt = dvStudentData.ToTable();
            }
            else
            {
                dt = ViewState["PrintData"] as DataTable;
            }


            DataSet ReportData = new DataSet();
            ReportData.Tables.Add(dt);
            HttpContext.Current.Session.Remove("ReportData");
            HttpContext.Current.Session.Add("ReportData", ReportData);
            gvPrint.DataSource = dt;
            gvPrint.DataBind();
            string url = "/Forms/Reports/ReportViewer.aspx?ReportName=crStudentList";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);
        }

        protected void gvPrint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            // e.Row.Cells[6].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    int count = GrdStudent.Rows.Count;
                    string[] AdmissionID = new string[count];

                    foreach (GridViewRow gvrow in GrdStudent.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");

                        Label UserCode = (Label)gvrow.FindControl("lblUserCode");

                        // string xya

                        if (chk != null && chk.Checked)
                        {
                            db.insert("delete tblStudent_Details where UserCode='" + UserCode.Text + "'");
                            db.insert("delete tblUser where UserCode='" + UserCode.Text + "'");

                            msgBox.ShowMessage("Student record Deleted Succefully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);




                        }
                        else
                        {
                            // msgBox.ShowMessage("please select Student To delete  !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        }


                    }
                    BindCourse();
                    // BindBranch();
                    //printabledata();
                }
            }
            catch (Exception ex) { }
            }


        
    }

}

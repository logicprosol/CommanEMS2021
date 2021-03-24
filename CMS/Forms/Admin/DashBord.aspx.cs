using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Web.Services;
using System.Web.UI.DataVisualization.Charting;
using BusinessAccessLayer;
using EntityWebApp;

namespace CMS.Forms.Admin
{
    public partial class DashBord : System.Web.UI.Page
    {
        database db = new database();
        // Object Area

        #region [Object Declaration]

        StringBuilder str = new StringBuilder();
        BL_Dashbord objBL = new BL_Dashbord();
        EWA_Dashbord objEWA = new EWA_Dashbord();
        BL_Common bl = new BL_Common();
        EWA_Common ec = new EWA_Common();
        int OrgId = 0;
        #endregion

        // Page Load
        #region [PageLoad]

        protected void Page_Load(object sender, EventArgs e)
        {

          
            OrgId =Convert.ToInt32(Session["OrgId"]);



            if (OrgId == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Can't find organization details')", true);
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
               if (Page.IsPostBack == false)
                {
                    //BindChart();
                    //BindPaiChart();
                    BindCourse();
                    BindDepartment();
                    lblCurrentOrder.Text = db.getDbstatus_Value("SELECT COUNT(StudentId) FROM tblStudent where OrgId=" + OrgId + "");
                    lblemplyee.Text = db.getDbstatus_Value("SELECT COUNT(EmpId) FROM tblEmployee where OrgId=" + OrgId + "");
                }
            }

        }

        private DataView dvBranch = null;
        private DataView dvClass = null;

        //private void BindPaiChart()
        //{
        //    EWA_Dashbord objEWA = new EWA_Dashbord();
        //    BL_Dashbord objBL = new BL_Dashbord();
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();

        //    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

        //    ds = objBL.GetData(objEWA);
        //    if (ds != null)
        //    {
        //        if (ds.Tables[1].Rows.Count > 0)
        //        {

        //            dt = ds.Tables[1];

        //            // dt = ds.Tables[0];

        //            foreach (DataRow row in dt.Rows)
        //            {
        //                PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
        //                {
        //                    Category = row["CourseName"].ToString(),
        //                    Data = Convert.ToDecimal(row["NumberOfStudent"])
        //                });
        //            }
        //        }
        //    }

        //}


        #endregion


        // Bind Bar Chart

        //        #region [Bind Chart]

        //        private void BindChart()
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {

        //                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
        //                ds = objBL.GetData(objEWA);

        //                str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
        //                            google.setOnLoadCallback(drawChart);
        //                            function drawChart() {
        //                            var data = new google.visualization.DataTable();
        //                            data.addColumn('string', 'MONTH');
        //                            data.addColumn('number', 'NumberofStudent');     
        // 
        //                            data.addRows(" + ds.Tables[0].Rows.Count + ");");

        //                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //                {
        //                    str.Append("data.setValue( " + i + "," + 0 + "," + "'" + ds.Tables[0].Rows[i]["MONTH"].ToString() + "');");
        //                    str.Append("data.setValue(" + i + "," + 1 + "," + ds.Tables[0].Rows[i]["NumberofStudent"].ToString() + ") ;");
        //                }

        //                str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
        //                str.Append(" chart.draw(data, {width: 400, height: 300, title: 'Student Admissions Status ',");
        //                str.Append("hAxis: {title: 'Month', titleTextStyle: {color: 'green'}}");
        //                str.Append("}); }");
        //                str.Append("</script>");
        //                lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        //            }
        //            catch
        //            { }
        //        }


        //        #endregion


        // For Pai Chart 

        #region [Pai Chart]





        #endregion


        //Added by Ashwini More 8-Oct-2020-----------------------------
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlType.SelectedValue== "Student")
            {
                StudentDiv.Visible = true;
                TeacherDiv.Visible = false;
                btnGo.Visible = true;
            }
            else if(ddlType.SelectedValue== "Teacher")
            {
                StudentDiv.Visible = false;
                TeacherDiv.Visible = true;
                btnGo.Visible = true;
            }
            else
            {
                StudentDiv.Visible = false;
                TeacherDiv.Visible = false;
                btnGo.Visible = false;

            }
           
        }

        //Added by Ashwini 8-Oct-2020
        private void BindCourse()
        {
            try
            {

                ec.OrgId = Session["OrgId"].ToString();
                DataSet ds = bl.BindCourses_BL(ec);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];
                ViewState["dvDivision"] = ds.Tables[4];
                ViewState["dvStudentData"] = ds.Tables[5];

                ddlCourse.Items.Clear();
                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));

                DDLAcademicYear.Items.Clear();
                DDLAcademicYear.DataSource = ds.Tables[7];
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
                DDLAcademicYear.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch();
               
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
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

                

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
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
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        private void BindDepartment()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindDepartment_BL(objEWA);

                ddlDepartment.DataSource = ds;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("Select", "Select"));
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        private void BindDesignation(String strFacultyType)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                objEWA.DesignationTypeId = strFacultyType;

                DataSet ds = objBL.BindDesignation_BL(objEWA);

                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "Select");
                ddlDesignation.SelectedIndex = 0;
              
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartment.SelectedItem.Text.Equals("Select"))
                {
                }
                else
                {
                    ddlDesignation.SelectedIndex = 0;
                    rbtnFacultyType.SelectedIndex = -1;
                    rbtnFacultyType.Enabled = true;
                    ddlDesignation.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        protected void rbtnFacultyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlDepartment.Enabled = true;
                BindDesignation(rbtnFacultyType.SelectedValue.ToString());
             
                ddlDesignation.Enabled = true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Added by Ashwini 8-Oct-2020
        protected void btnGo_Click(object sender, EventArgs e)
        {
            string CourseId = ddlCourse.SelectedValue!=""? ddlCourse.SelectedValue:"0";
            string ClassId = ddlClass.SelectedValue!=""? ddlClass.SelectedValue:"0";
            string BranchId = ddlBranch.SelectedValue!=""? ddlBranch.SelectedValue:"0";
            string AcademicId = DDLAcademicYear.SelectedValue !=""? DDLAcademicYear.SelectedValue:"0";
            string DeptId = ddlDepartment.SelectedValue!=""? ddlDepartment.SelectedValue:"0";
            string DesignationId = ddlDesignation.SelectedValue!=""? ddlDesignation.SelectedValue:"0";
            string FacultytypeId = rbtnFacultyType.SelectedValue!=""? rbtnFacultyType.SelectedValue:"0";
            string TotalStudent = db.getDbstatus_Value("select count(usercode) from tblstudent where CourseId='"+ CourseId + "' and ClassId='"+ ClassId + "' and BranchId='"+ BranchId + "' and AcademicYearId='" + AcademicId + "' ");
            string TotalTeacher = db.getDbstatus_Value("select count(EmpDeptDesId) from tblEmpAssignDeptDes where DepartmentId = '"+ DeptId + "'and DesignationTypeId ='"+ FacultytypeId + "' and DesignationId='"+ DesignationId + "' ");
            if (ddlType.SelectedValue == "Student")
            {
                lblemplyee.Text= db.getDbstatus_Value("SELECT COUNT(EmpId) FROM tblEmployee where OrgId=" + OrgId + "");
                lblCurrentOrder.Text = TotalStudent;
            }
            else if(ddlType.SelectedValue == "Teacher")
            {
                lblemplyee.Text = TotalTeacher;
               lblCurrentOrder.Text = db.getDbstatus_Value("SELECT COUNT(StudentId) FROM tblStudent where OrgId=" + OrgId + "");
            }
            else
            {
                lblemplyee.Text= db.getDbstatus_Value("SELECT COUNT(EmpId) FROM tblEmployee where OrgId=" + OrgId + "");
                lblCurrentOrder.Text = db.getDbstatus_Value("SELECT COUNT(StudentId) FROM tblStudent where OrgId=" + OrgId + "");
            }
        }
    }
}

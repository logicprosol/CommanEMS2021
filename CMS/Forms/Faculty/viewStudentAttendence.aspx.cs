using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using EntityWebApp;

namespace CMS.Forms.Faculty
{
    public partial class viewStudentAttendence : System.Web.UI.Page
    {

        //Objects
        #region[Objects]
        public static int OrgID=0;
        #endregion
        database db = new database();
        
        //Page Load
        #region[Page Load]
        protected void Page_Load(object sender, EventArgs e)
          {
            try
            {
                 OrgID = Convert.ToInt32(Session["OrgId"]);

                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    txtSelectDate.Attributes.Add("ReadOnly","True");
                    BindCourse(OrgID);
                }
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
                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.CourseId = ddlCourses.SelectedValue;

                DataSet ds = objBL.BindBranches_BL(objEWA);

                ddlBranches.DataSource = ds;
                ddlBranches.DataTextField = "BranchName";
                ddlBranches.DataValueField = "BranchId";
                ddlBranches.DataBind();
                ddlBranches.Items.Insert(0, new ListItem("Select", "0"));
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
                objEWA.BranchId = ddlBranches.SelectedValue;

                DataSet ds = objBL.BindClass_BL(objEWA);

                ddlClasses.DataSource = ds;
                ddlClasses.DataTextField = "ClassName";
                ddlClasses.DataValueField = "ClassId";
                ddlClasses.DataBind();
                ddlClasses.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //Bind Course
        #region[Bind Courses]

        private void BindCourse(int OrgID)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                //Pass from Session
                objEWA.OrgId = Convert.ToString(OrgID);
                DataSet ds = objBL.BindCourses_BL(objEWA);
                ddlCourses.DataSource = ds;
                ddlCourses.DataTextField = "CourseName";
                ddlCourses.DataValueField = "CourseId";
                ddlCourses.DataBind();
                ddlCourses.Items.Insert(0, new ListItem("Select", "0"));
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
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.ClassId = ddlClasses.SelectedValue;

                DataSet ds = objBL.BindDivision_BL(objEWA);

                ddlDivision.DataSource = ds;

                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "DivisionId";
                ddlDivision.DataBind();
                //ddlDivision.Items.Insert(0, "Select");
                ddlDivision.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Bind Subject
        #region[Bind Subjects]

        private void BindSubject()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserCode = Session["Username"].ToString();
                objEWA.CourseId = ddlCourses.SelectedValue;
                objEWA.BranchId = ddlBranches.SelectedValue;
                objEWA.ClassId = ddlClasses.SelectedValue;
                DataSet ds = objBL.BindAssigned_Subject_BL(objEWA);

                ddlSelectSubject.DataSource = ds;

                ddlSelectSubject.DataTextField = "SubjectName";
                ddlSelectSubject.DataValueField = "SubjectId";
                ddlSelectSubject.DataBind();
                ddlSelectSubject.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //go Event
        #region[Go event]
        protected void btnGo_Click(object sender, EventArgs e)
        {

            try
            {
                EWA_StudentAttendance objEWA = new EWA_StudentAttendance();
                BL_StudentAttendance objBAL = new BL_StudentAttendance();

                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                objEWA.CourseId = ddlCourses.SelectedValue.Trim();
                objEWA.ClassId = ddlClasses.SelectedValue.Trim();
                objEWA.DivisionId = ddlDivision.SelectedValue.Trim();
                objEWA.BranchId = ddlBranches.SelectedValue.Trim();
                objEWA.SubjectId = ddlSelectSubject.SelectedValue.Trim();
                objEWA.Date = txtSelectDate.Text;
                objEWA.Time = txtTime.Text;
                DataSet ds = new DataSet();

                ds = objBAL.BL_StudentAttendanceData(objEWA);

                if (ds.Tables[0] == null)
                {
                    //btnUpdate.Visible = false;
                    //btnSave.Visible = true;

                    BindGrid();
                }
                else
                {
                }

                db.cnopen();
                if (RadioButtonList1.SelectedValue == "Present")
                {

                    grdAttendance.DataSource = db.Displaygrid("SELECT      isnull(tblStudent.RollNo,0)RollNo,   tblStudetnClassAttendanceMaster.AttendanceDate, tblStudetnClassAttendanceMaster.AttendanceTime, tblStudent.FirstName + '  ' + tblStudent.MiddleName + '  ' + tblStudent.LastName AS Studentname,  tblClass.ClassName, tblCourse.CourseName, tblBranch.BranchName, tblOrganization.OrgName, tblSubject.SubjectName FROM            tblStudetnClassAttendanceMaster INNER JOIN  tblStudentClassAttendance ON tblStudetnClassAttendanceMaster.AttendanceId = tblStudentClassAttendance.AttendanceID INNER JOIN tblClass ON tblStudetnClassAttendanceMaster.ClassId = tblClass.ClassId INNER JOIN tblCourse ON tblStudetnClassAttendanceMaster.CourseId = tblCourse.CourseId INNER JOIN tblBranch ON tblClass.BranchId = tblBranch.BranchId AND tblCourse.CourseId = tblBranch.CourseId AND tblStudetnClassAttendanceMaster.BranchId = tblBranch.BranchId INNER JOIN  tblOrganization ON tblCourse.OrgId = tblOrganization.OrganizationId AND tblStudetnClassAttendanceMaster.OrgId = tblOrganization.OrganizationId INNER JOIN tblSubject ON tblClass.ClassId = tblSubject.ClassId AND tblCourse.CourseId = tblSubject.CourseId AND tblBranch.BranchId = tblSubject.BranchId AND tblOrganization.OrganizationId = tblSubject.OrgId AND tblStudetnClassAttendanceMaster.SubjectId = tblSubject.SubjectId INNER JOIN  tblEmployee ON tblOrganization.OrganizationId = tblEmployee.OrgId AND tblStudetnClassAttendanceMaster.EmployeeId = tblEmployee.UserCode INNER JOIN tblStudent ON tblStudentClassAttendance.StudentID = tblStudent.UserCode  and tblStudent.orgid= tblStudetnClassAttendanceMaster.OrgID WHERE(tblStudentClassAttendance.Status = 'P' And tblStudetnClassAttendanceMaster.CourseId='" + ddlCourses.SelectedValue.Trim() + "' and tblStudetnClassAttendanceMaster.ClassId='" + ddlClasses.SelectedValue.Trim() + "' and tblSubject.SubjectId = '" + ddlSelectSubject.SelectedValue +"'  and tblStudetnClassAttendanceMaster.AttendanceDate='" + txtSelectDate.Text + "' and tblStudetnClassAttendanceMaster.OrgID="+Session["OrgId"].ToString() +") Order By tblStudent.RollNo");
                    grdAttendance.DataBind();

                }
                else 
                {
                    //grdAttendance.DataSource = db.Displaygrid(" SELECT tblStudetnClassAttendanceMaster.AttendanceDate, tblStudetnClassAttendanceMaster.AttendanceTime, tblStudentClassAttendance.StudentID,                            tblStudentClassAttendance.StudentName,  tblClass.ClassName, tblCourse.CourseName, tblBranch.BranchName,                           tblOrganization.OrgName, tblDivision.DivisionName, tblSubject.SubjectName    FROM            tblStudetnClassAttendanceMaster INNER JOIN                             tblStudentClassAttendance ON tblStudetnClassAttendanceMaster.AttendanceId = tblStudentClassAttendance.AttendanceID INNER JOIN                              tblClass ON tblStudetnClassAttendanceMaster.ClassId = tblClass.ClassId INNER JOIN                            tblCourse ON tblStudetnClassAttendanceMaster.CourseId = tblCourse.CourseId INNER JOIN                           tblBranch ON tblClass.BranchId = tblBranch.BranchId AND tblCourse.CourseId = tblBranch.CourseId AND                              tblStudetnClassAttendanceMaster.BranchId = tblBranch.BranchId INNER JOIN                            tblOrganization ON tblCourse.OrgId = tblOrganization.OrganizationId AND tblStudetnClassAttendanceMaster.OrgId = tblOrganization.OrganizationId INNER JOIN                            tblDivision ON tblClass.ClassId = tblDivision.ClassId AND tblStudetnClassAttendanceMaster.DivId = tblDivision.DivisionId INNER JOIN                            tblSubject ON tblClass.ClassId = tblSubject.ClassId AND tblCourse.CourseId = tblSubject.CourseId AND tblBranch.BranchId = tblSubject.BranchId AND                            tblOrganization.OrganizationId = tblSubject.OrgId AND tblStudetnClassAttendanceMaster.SubjectId = tblSubject.SubjectId INNER JOIN                             tblEmployee ON tblOrganization.OrganizationId = tblEmployee.OrgId AND tblStudetnClassAttendanceMaster.EmployeeId = tblEmployee.UserCode    WHERE (tblStudentClassAttendance.Status = ' '  And tblStudetnClassAttendanceMaster.CourseId='" + ddlCourses.SelectedValue.Trim() + "' and tblStudetnClassAttendanceMaster.ClassId='" + ddlClasses.SelectedValue.Trim() + "' and tblSubject.SubjectId = '" + ddlSelectSubject.SelectedValue + "'  and tblStudetnClassAttendanceMaster.AttendanceDate='" + txtSelectDate.Text + "')");
                    grdAttendance.DataSource = db.Displaygrid("SELECT    isnull(tblStudent.RollNo,0)RollNo,    tblStudetnClassAttendanceMaster.AttendanceDate, tblStudetnClassAttendanceMaster.AttendanceTime, tblStudent.FirstName + '  ' + tblStudent.MiddleName + '  ' + tblStudent.LastName AS Studentname,  tblClass.ClassName, tblCourse.CourseName, tblBranch.BranchName, tblOrganization.OrgName, tblSubject.SubjectName FROM            tblStudetnClassAttendanceMaster INNER JOIN  tblStudentClassAttendance ON tblStudetnClassAttendanceMaster.AttendanceId = tblStudentClassAttendance.AttendanceID INNER JOIN tblClass ON tblStudetnClassAttendanceMaster.ClassId = tblClass.ClassId INNER JOIN tblCourse ON tblStudetnClassAttendanceMaster.CourseId = tblCourse.CourseId INNER JOIN tblBranch ON tblClass.BranchId = tblBranch.BranchId AND tblCourse.CourseId = tblBranch.CourseId AND tblStudetnClassAttendanceMaster.BranchId = tblBranch.BranchId INNER JOIN  tblOrganization ON tblCourse.OrgId = tblOrganization.OrganizationId AND tblStudetnClassAttendanceMaster.OrgId = tblOrganization.OrganizationId INNER JOIN tblSubject ON tblClass.ClassId = tblSubject.ClassId AND tblCourse.CourseId = tblSubject.CourseId AND tblBranch.BranchId = tblSubject.BranchId AND tblOrganization.OrganizationId = tblSubject.OrgId AND tblStudetnClassAttendanceMaster.SubjectId = tblSubject.SubjectId INNER JOIN  tblEmployee ON tblOrganization.OrganizationId = tblEmployee.OrgId AND tblStudetnClassAttendanceMaster.EmployeeId = tblEmployee.UserCode INNER JOIN tblStudent ON tblStudentClassAttendance.StudentID = tblStudent.UserCode  and tblStudent.orgid= tblStudetnClassAttendanceMaster.OrgID WHERE(tblStudentClassAttendance.Status = 'A' And tblStudetnClassAttendanceMaster.CourseId='" + ddlCourses.SelectedValue.Trim() + "' and tblStudetnClassAttendanceMaster.ClassId='" + ddlClasses.SelectedValue.Trim() + "' and tblSubject.SubjectId = '" + ddlSelectSubject.SelectedValue + "'  and tblStudetnClassAttendanceMaster.AttendanceDate='" + txtSelectDate.Text + "' and tblStudetnClassAttendanceMaster.OrgID=" + Session["OrgId"].ToString() + ") Order By tblStudent.RollNo");

                    grdAttendance.DataBind();
                }
                

                db.cnclose();
                //   BindGrid();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        #endregion

        //Bind Grid
        #region[Bind Grid]

        private void BindGrid()
        {
            try
            {
                EWA_StudentAttendance objEWA = new EWA_StudentAttendance();
                BL_StudentAttendance objBAL = new BL_StudentAttendance();

                objEWA.CourseId = ddlCourses.SelectedValue;
                objEWA.ClassId = ddlClasses.SelectedValue;
                objEWA.BranchId = ddlBranches.SelectedValue;
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = new DataSet();

                ds = objBAL.BL_StudentAttendanceData(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdAttendance.DataSource = ds.Tables[0];
                    grdAttendance.DataBind();

                
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserCode");
                    dt.Columns.Add("FullName");

                    dt.Rows.Add();
                    dt.Rows.Add();

                    grdAttendance.DataSource = dt;
                    grdAttendance.DataBind();
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
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion


         //Course Changed
        #region[Course Changed]
        protected void ddlCourses_SelectedIndexChanged1(object sender, EventArgs e)
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

        //Branches Changed
        #region[Branches Changed]
        protected void ddlBranches_SelectedIndexChanged1(object sender, EventArgs e)
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


        //Classes Changed
        #region[Clasees Changed]
        protected void ddlClasses_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                //BindDivision();
                BindSubject();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        protected void ddlSelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTime.Text = db.getDbstatus_Value("SELECT tblTimeSlotMaster.SlotFrom FROM  tblTimeTableCreation INNER JOIN tblTimeSlotMaster ON tblTimeTableCreation.TimeSlotId = tblTimeSlotMaster.SlotId WHERE tblTimeTableCreation.SubjectId ='" + ddlSelectSubject.Text + "' ");

        }
    }
}
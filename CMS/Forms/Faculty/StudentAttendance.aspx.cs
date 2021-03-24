using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using EntityWebApp;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Web;

//Student Attendance
namespace CMS.Forms.Faculty
{
    public partial class StudentAttendance : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        public static int OrgID=0;
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        string mobile;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //
                OrgID = Convert.ToInt32(Session["OrgId"]);
                txtSelectDate_CalendarExtender.EndDate = DateTime.Today;
                if (OrgID == 0)
                {
                    Response.Redirect("/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    txtSelectDate.Attributes.Add("ReadOnly","True");
                    int OrgID = Convert.ToInt32(Session["OrgId"]);
                    BindCourse(OrgID);
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
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

        //Course Changed
        #region[Course Changed]

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

        //Branches Changed
        #region[Branches Changed]

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
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
                objEWA.CourseId = ddlCourses.SelectedValue;
                objEWA.BranchId = ddlBranches.SelectedValue;
                objEWA.ClassId = ddlClasses.SelectedValue;
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserCode = Session["Username"].ToString();

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
                objEWA.SubjectId = ddlSelectSubject.SelectedValue.Trim();
                objEWA.BranchId = ddlBranches.SelectedValue.Trim();
                objEWA.Date = txtSelectDate.Text;
                objEWA.Time = txtTime.Text;
                objEWA.DivisionId = ddlDivision.SelectedValue.Trim();
                DataSet ds = new DataSet();

                ds = objBAL.BL_StudentAttendanceData(objEWA);

                if (ds.Tables[0] == null)
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;

                   // BindGrid();
                }
                else
                {
                }

                BindGrid();
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
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

                    btnSave.Visible = true;
                }
                else
                {

                    msgBox.ShowMessage("No Record Found !!!", "Saved", UserControls.MessageBox.MessageStyle.Information);
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("UserCode");
                    //dt.Columns.Add("FullName");
                    //dt.Columns.Add("Mobile");
                    //dt.Rows.Add();
                    //dt.Rows.Add();

                    //grdAttendance.DataSource = dt;
                    //grdAttendance.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Click
        #region[Save Event]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EWA_StudentAttendance ObjEWA = new EWA_StudentAttendance();

                BL_StudentAttendance ObjBL = new BL_StudentAttendance();
                ObjEWA.Action = "SaveStudentClassAttendance";
                ObjEWA.CourseId = ddlCourses.SelectedValue;
                ObjEWA.BranchId = ddlBranches.SelectedValue;
                ObjEWA.ClassId = ddlClasses.SelectedValue;
                ObjEWA.DivisionId = ddlDivision.SelectedValue;
                ObjEWA.SubjectId = ddlSelectSubject.SelectedValue;
                ObjEWA.EmployeeId = Session["UserCode"].ToString();
                ObjEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                ObjEWA.Date = txtSelectDate.Text;
                ObjEWA.Time = txtTime.Text;

                DataTable DataStudentClassAttendance = new DataTable();
            int flag = ObjBL.SaveAttendance(ObjEWA, DataStudentClassAttendance);
                if (flag > 0)
                {
                    btnSave.Visible = false;

                    DataStudentClassAttendance.Columns.Add("AttendanceID");
                    DataStudentClassAttendance.Columns.Add("StudentID");
                    DataStudentClassAttendance.Columns.Add("StudentName");
                    DataStudentClassAttendance.Columns.Add("Status");

                    int i = 0;

                    string id, name, Astatus;

                    foreach (GridViewRow gvrow in grdAttendance.Rows)
                    {
                        CheckBox chk = ((CheckBox)gvrow.FindControl("chkboxStatus"));

                        if (chk.Checked == true)
                        {
                            Astatus = "P";
                        }
                        else
                        {
                            Astatus = "A";
                            //SendSMSParents("SentToParent");
                        }
                        id = grdAttendance.Rows[gvrow.RowIndex].Cells[4].Text;
                        name = grdAttendance.Rows[gvrow.RowIndex].Cells[2].Text;
                        mobile = grdAttendance.Rows[gvrow.RowIndex].Cells[3].Text;
                        //DataStudentClassAttendance.Rows.Add("0", id, name, Astatus);
                        DataStudentClassAttendance.Rows.Add(flag, id, name, Astatus);
                        i++;

                    }
                    string cs = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    using (SqlConnection sqlConn = new SqlConnection(cs))
                    {
                        sqlConn.Open();
                        using (SqlBulkCopy sqlbc = new SqlBulkCopy(sqlConn))
                        {
                            sqlbc.DestinationTableName = "tblStudentClassAttendance";
                            sqlbc.WriteToServer(DataStudentClassAttendance);
                            sqlConn.Close();
                            //Response.Write("Bulk data stored successfully");
                            msgBox.ShowMessage("Attendance Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                            clearcontrol();
                        }
                    }
                }
                else if(flag==-1)
                {
                    msgBox.ShowMessage("Record already exists !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                {
                    msgBox.ShowMessage("Try Again with different attendance Time !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                //if (flag > 0)
                //{

                //    msgBox.ShowMessage("Attendance Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                //   
                //    // Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

                //}
            }
            catch (Exception exp)
            {
                // GeneralErr(exp.Message.ToString());
            }
        }

        #endregion



        private void SendSMSParents(string strAction)
        {
            try
            {
                int count = grdAttendance.Rows.Count;
                string[] MobileNo = new string[count];
                int i = 0;



                string mob = mobile.ToString();


                string Message = "Your Student Is Absent Today..! Please Visit in School";

                WebClient client = new WebClient();

                //my sms Mantra

                // string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";
                //string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=" + UserName + " & password=" + Password + " & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";

                //Redsms

                //smsApiCall(baseurl);


                //  string baseurl="http://api.Textlocal.in/send/?username=nivaskhatal94@gmail.com&apiKey=3TrAyjRJD78-Funr9xuCxjMytLjEFFP2LUPM6SV2EQ&sender=TXTLCL&numbers=918605063825&message=Test_message.

                String url = "http://api.textlocal.in/send/?username=" + "nivaskhatal94@gmail.com" + "&apiKey=" + "3TrAyjRJD78-Funr9xuCxjMytLjEFFP2LUPM6SV2EQ" + "&numbers=" + mob + "&message=" + Message + "&sender=" + "TXTLCL";



                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string popupScript = "<script language=JavaScript>";
                popupScript += "alert('Please enter valid Email Id');";
                popupScript += "</";
                popupScript += "script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                //Response.Write("<script LANGUAGE='JavaScript' >alert('SMS Send Successful')</script>");
                //SendSMS(MobileNo);
                // System.Web.HttpContext.Current.Response.Write("<script language=\"JavaScript\">alert(\"SMS Send Successful'\")</script>");

            }


            catch (Exception exp)
            {

                throw exp;
            }

        }

        //Update Event
        #region[Update Event]

        protected void btnUpdate_Click(object sender, EventArgs e, string str)
        {
            try
            {
                EWA_StudentAttendance objEWA = new EWA_StudentAttendance();
                BL_StudentAttendance objBL = new BL_StudentAttendance();
                int i = 0;
                int count = grdAttendance.Rows.Count;
                string[] StudentId = new string[count];
                string[] StudentName = new string[count];
                string[] Status = new string[count];
                //string str;

                foreach (GridViewRow gvrow in grdAttendance.Rows)
                {
                    RadioButtonList rbl = ((RadioButtonList)gvrow.FindControl("rbtnlStatus"));
                    objEWA.Action = str;

                    if (str == "Update" || str == "Delete")
                    {
                        objEWA.StudentId = ViewState["StudentId"].ToString();
                    }

                    objEWA.AttendanceStatus = rbl.SelectedValue.ToString();
                    objEWA.StudentId = rbl.SelectedValue.ToString();
                    objEWA.StudentFullName = rbl.SelectedValue.ToString();
                    //int flag = objBL.SaveAttendance(objEWA);

                    if (rbl != null && rbl.SelectedValue == "A")
                    {
                        Status[i] = "A";
                    }
                    else if (rbl != null && rbl.SelectedValue == "P")
                    {
                        Status[i] = "P";
                    }
                    StudentId[i] = grdAttendance.Rows[gvrow.RowIndex].Cells[0].Text;
                    StudentName[i] = grdAttendance.Rows[gvrow.RowIndex].Cells[1].Text;
                    i++;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Click
        #region[Update Event]

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        #endregion

        //Division
        #region[Division]

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //select Subject
        #region[Select Subject]

        protected void ddlSelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTime.Text = db.getDbstatus_Value("SELECT tblTimeSlotMaster.SlotFrom FROM  tblTimeTableCreation INNER JOIN tblTimeSlotMaster ON tblTimeTableCreation.TimeSlotId = tblTimeSlotMaster.SlotId WHERE tblTimeTableCreation.SubjectId ='" + ddlSelectSubject.Text + "' and tblTimeSlotMaster.OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' ");
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void grdAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAttendance.PageIndex = e.NewPageIndex;
        }
        protected void clearcontrol()
        {
            DataTable dt = new DataTable();
            int OrgID = Convert.ToInt32(Session["OrgId"]);
            BindCourse(OrgID);
            grdAttendance.DataSource = null;
            grdAttendance.DataBind();

            ddlBranches.DataSource = dt;
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("Select", "0"));

            ddlClasses.DataSource = dt;
            ddlClasses.DataBind();
            ddlClasses.Items.Insert(0, new ListItem("Select", "0"));

            ddlSelectSubject.DataSource =dt;
            ddlSelectSubject.DataBind();
            ddlSelectSubject.Items.Insert(0, new ListItem("Select", "0"));

            txtSelectDate.Text = "";
            txtTime.Text = "";

        }
        
    }
}
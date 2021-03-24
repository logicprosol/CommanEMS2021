using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Configuration;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Web.UI;
namespace CMS.Forms.Admin
{
    public partial class SendMessage : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_SendMessage objBL = new BL_SendMessage();
        private EWA_SendMessage objEWA = new EWA_SendMessage();
        private BindControl ObjHelper = new BindControl();
        public static int orgID;
        string Password = ConfigurationManager.AppSettings["SmsPass"].ToString();
        string UserName = ConfigurationManager.AppSettings["SmsUser"].ToString();
        string status = "false";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgID = Convert.ToInt32(Session["OrgId"]);
                if (orgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Radio Button Send Message

        #region rbtlSendMessage_SelectedIndexChanged

        protected void rbtlSendMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtlSendMessage.SelectedValue.ToString() == "Student")
            {

                Panel_Student.Visible = true;
                Panel_StudentSub.Visible = true;
                Panel_Parent.Visible = false;
                Panel_Employee.Visible = false;
                //ShowEmptyGridView(GrdStudent);
                BindCourses();
                Panel_Message.Visible = true;
            }
            else if (rbtlSendMessage.SelectedValue.ToString() == "Parents")
            {
                Panel_Student.Visible = true;
                Panel_Parent.Visible = true;
                Panel_StudentSub.Visible = false;
                Panel_Employee.Visible = false;
                //ShowEmptyGridView(GrdParent);
                BindCourses();
                Panel_Message.Visible = true;
            }
            else if (rbtlSendMessage.SelectedValue.ToString() == "Staff")
            {
                Panel_Employee.Visible = true;
                Panel_Parent.Visible = false;
                Panel_Student.Visible = false;
               // BindDepartment();
               // BindDesignationType();
                BindDepartment();
                Panel_Message.Visible = true;
                rbtlDesType.Enabled = false;
                ddlDesignation.Enabled = false;
            }
        }

        #endregion

        //Bind Department
        #region [Bind Department]

        private void BindDepartment()
        {
            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.OrgId = Convert.ToString(orgID);
            DataSet ds = objBL.BindDepartment_BL(objEWA);
            ddlDepartment.DataSource = ds;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentId";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "Select");
        }

        #endregion

        //Bind Designation Type
        #region Bind Designation Type

        private void BindDesignationType()
        {
            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.OrgId = Convert.ToString(Session["OrgId"]);

            DataSet ds = objBL.BindDesignationType_BL();

            rbtlDesType.DataSource = ds;
            rbtlDesType.DataTextField = "DesignationType";
            rbtlDesType.DataValueField = "DesignationTypeId";
            rbtlDesType.DataBind();
        }

        #endregion

        protected void rbtlDesignationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdEmployeeBind();
        }

        //Bind Courses
        #region Bind Courses

        private void BindCourses()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Classes
        #region Bind Class

        private void BindClass()
        {

            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.BranchId = ddlBranch.SelectedValue.ToString();
            if (!objEWA.BranchId.Equals("Select"))
            {
                DataSet ds = objBL.BindClass_BL(objEWA);

                ddlClass.DataSource = ds;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
            }
            else
            {
                ddlClass.Items.Clear();
            }
            ddlClass.Items.Insert(0, new ListItem("Select", "Select"));

        }


        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
            //BindClass();

        }

        private void BindBranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);

                ddlBranch.DataSource = ds;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();

                ddlBranch.Items.Insert(0, new ListItem("Select", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception exp)
            {

                throw exp;
            }    
           
        }


        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
          //  BindDivision();

        }
        #endregion

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string senderType = rbtlSendMessage.SelectedValue.ToString();
            //if (senderType.Equals("Student"))
            //{
            //    Panel_StudentSub.Visible = true;

            //    GrdStudentBind();
            //}
            //if (senderType.Equals("Parents"))
            //{
            //    Panel_StudentSub.Visible = false;
            //    GrdStudent.Visible = false;
            //    GrdParentBind();
            //}

        }

        //  Bind Student Grid Data

        //#region StudentGrid
        //private void BindStudentGridData()
        //{
        //    EWA_Common objEWA = new EWA_Common();
        //    BL_Common objBL = new BL_Common();

        //    objEWA.OrgId = Session["OrgId"].ToString();
        //    objEWA.CourseId = ddlCourse.SelectedValue.ToString();
        //    objEWA.BranchId = ddlBranch.SelectedValue.ToString();
        //    objEWA.ClassId = ddlClass.SelectedValue.ToString();
        //    objEWA.DivisionId = ddlDivision.SelectedValue.ToString();

        //    DataSet ds = objBL.BindStudentData_BL(objEWA);
        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        GrdStudent.DataSource = ds;
        //        GrdStudent.DataBind();

        //    }

        //    else
        //    {


        //        DataTable dt = new DataTable();
        //        dt.Clear();
        //        dt.Columns.Add("StudentId");
        //        dt.Columns.Add("StudentName");
        //        dt.Columns.Add("Mobile");

        //        dt.Rows.Add(dt.NewRow());
        //        GrdStudent.DataSource = dt;
        //        GrdStudent.DataBind();
        //        int totalcolums = GrdStudent.Rows[0].Cells.Count;
        //        GrdStudent.Rows[0].Cells.Clear();
        //        GrdStudent.Rows[0].Cells.Add(new TableCell());
        //        GrdStudent.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        GrdStudent.Rows[0].Cells[0].Text = "No Data Found";
        //    }
        //}

        //// For Student Empty Grid

        //private void ShowEmptyGridView(GridView grid)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(grid.Columns[0].HeaderText);
        //    dt.Columns.Add(grid.Columns[1].HeaderText);
        //    dt.Columns.Add(grid.Columns[2].HeaderText);
        //    dt.Columns.Add(grid.Columns[3].HeaderText);
        //    DataRow dr = dt.NewRow();
        //    dt.Rows.Add(dr);

        //    grid.DataSource = dt;
        //    grid.DataBind();
        //    grid.Columns[0].Visible = true;
        //    grid.Rows[0].Cells[1].ColumnSpan = 3;
        //    foreach (GridViewRow row in grid.Rows)
        //    {
        //        row.Cells[2].Visible = false;
        //        row.Cells[3].Visible = false;
        //    }
        //    grid.Rows[0].Cells[1].Text = "No Record found";
        //}

        //#endregion

        //Employee Grid Bind

        #region[Employee Grid Bind]

        private void GrdEmployeeBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
                objEWA.DesignationId = ddlDesignation.SelectedValue;
                DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
                GrdEmployee.DataSource = ds;
                GrdEmployee.DataBind();
            }

            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Bind  Parent Grid
        #region Bind Parent Grid

        //Student Grid Bind
        #region[Student Grid Bind]

        private void GrdStudentBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                DataSet ds = objBL.StudentGridBind_BL(objEWA);

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    msgBox.ShowMessage("No Record Found !!!", "Saved", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    GrdStudent.DataSource = ds;
                    GrdStudent.DataBind();
                }

            }

            catch (Exception)
            {
               // throw;
            }
        }

        #endregion

        //Parent Grid Bind
        #region[Parent Grid Bind]

        private void GrdParentBind()
        {

            try
            {
                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                
                DataSet ds = objBL.ParentGridBind_BL(objEWA);
              

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    msgBox.ShowMessage("No Record Found !!!", "Saved", UserControls.MessageBox.MessageStyle.Information);
                  
                }
                else
                {
                    GrdParent.DataSource = ds;
                    GrdParent.DataBind();
                }

            }

            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindDivision();
            string senderType = rbtlSendMessage.SelectedValue.ToString();
            if (senderType.Equals("Student"))
            {
                Panel_StudentSub.Visible = true;

                GrdStudentBind();
            }
            if (senderType.Equals("Parents"))
            {
                Panel_StudentSub.Visible = false;
                GrdStudent.Visible = false;
                GrdParentBind();
            }
        }

        private void BindDivision()
        {
            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.ClassId = ddlClass.SelectedValue.ToString();
            if (!objEWA.ClassId.Equals("Select"))
            {
                DataSet ds = objBL.BindDivision_BL(objEWA);

                ddlDivision.DataSource = ds;
                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "DivisionId";
                ddlDivision.DataBind();
            }
            else
            {
               ddlDivision.Items.Clear();
            }
            ddlDivision.Items.Insert(0, new ListItem("Select", "Select"));

        }

        #endregion


        #region [SMS Send Button Events]
        protected void btnSend_Click(object sender, EventArgs e)
        {

            if (rbtlSendMessage.SelectedValue.Equals("Student"))
            {               
                SendStudentSMS("SentToStudent");
            }
            else if (rbtlSendMessage.SelectedValue.Equals("Parents"))
            {
                SendParentsSMS("SentToParents");
            }
            else if (rbtlSendMessage.SelectedValue.Equals("Staff"))
            {
                SendStaffSMS("SendToStaff");
            }
           // msgBox.ShowMessage("Message Send Successfully ");
        }

        #endregion

        #region [SMS Send Button Events]

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (rbtlSendMessage.SelectedValue.Equals("Student"))
            {
                SendStudentSMS("SentToStudent");
            }
            else if (rbtlSendMessage.SelectedValue.Equals("Parents"))
            {
                SendParentsSMS("SentToParents");
            }
            else if (rbtlSendMessage.SelectedValue.Equals("Staff"))
            {
                SendStaffSMS("SendToStaff");
            }
            //msgBox.ShowMessage("Message Send Successfully ");
        }

        #endregion


        // Send SMS To Members

        #region SEND_SMS

        private void SendStaffSMS(string p)
        {
            //int count = GrdEmployee.Rows.Count;
            //string[] MobileNo = new string[count];
            //int i = 0;
            //foreach (GridViewRow gvrow in GrdEmployee.Rows)
            //{
            //    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
            //    if (chk != null && chk.Checked)
            //    {
            //        MobileNo[i] = GrdEmployee.DataKeys[gvrow.RowIndex].Values["Mobile"].ToString();
            //       // SendSMSEmployee(MobileNo);
            //        string mob = MobileNo[0];

            //        string Message = txtMessage.Text;

            //        WebClient client = new WebClient();
            //        // string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";

            //        //my sms Mantra

            //        // string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";
            //        //string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=" + UserName + " & password=" + Password + " & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";

            //        //Redsms
            //        String url = "http://api.textlocal.in/send/?username=" +"nivaskhatal94@gmail.com" +"&hash=" + "3TrAyjRJD78-Funr9xuCxjMytLjEFFP2LUPM6SV2EQ" + "&numbers=" + MobileNo + "&message=" + Message + "&sender=" + "TXTLCL";

            //        Stream data = client.OpenRead(url);
            //        StreamReader reader = new StreamReader(data);
            //        string s = reader.ReadToEnd();
            //        data.Close();
            //    }
            //}
            int count = GrdEmployee.Rows.Count;
        
            string[] MobileNo = new string[count];
            int i = 0;
            foreach (GridViewRow gvrow in GrdEmployee.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                if (chk != null && chk.Checked)
                {
                     status = "true";
                    MobileNo[i] = GrdEmployee.DataKeys[gvrow.RowIndex].Values["Mobile"].ToString();
                    // SendSMSEmployee(MobileNo);
                    string mob = MobileNo[0];

                    string Message = txtMessage.Text;

                    WebClient client = new WebClient();
                    String url = "http://api.textlocal.in/send/?username=" + "info@logicprosol.com" + "&apiKey=" + "cDotMW9pSI8-lqRk9oFHtH3iGJKeLicdH4BDvx0sTT" + "&numbers=" + mob + "&message=" + Message + "&sender=" + "TXTLCL";
                    Stream data = client.OpenRead(url);
                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    data.Close();
                  //  Response.Write("<script> alert ('SMS Send Successfully') </script>");
                   // Response.Write("<script LANGUAGE='JavaScript' >alert('SMS Send Successful')</script>");
                    System.Web.HttpContext.Current.Response.Write("<script language=\"JavaScript\">alert(\"SMS Sent Successful'\")</script>");
                    
                }
                
            }
            if (status != "true")
            {
                msgBox.ShowMessage("Please Select Atleast 1 Student ", "Saved", UserControls.MessageBox.MessageStyle.Information);
            }
            else
            {
                clear();
                msgBox.ShowMessage("SMS Send Successfully", "Saved", UserControls.MessageBox.MessageStyle.Information);
            }

        }

        private void SendSMSEmployee(string[] MobileNo)
        {
            
        }

        private void SendParentsSMS(string strAction)
        {
            try
            {
                int count = GrdParent.Rows.Count;
               
                string[] MobileNo = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdParent.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                    if (chk != null && chk.Checked)
                    {
                        status = "true";
                        MobileNo[i] = GrdParent.DataKeys[gvrow.RowIndex].Values["Mobile"].ToString();


                        string mob = MobileNo[0];

                        string Message = txtMessage.Text;

                        WebClient client = new WebClient();

                        String url = "http://api.textlocal.in/send/?username=" + "info@logicprosol.com" + "&apiKey=" + "cDotMW9pSI8-lqRk9oFHtH3iGJKeLicdH4BDvx0sTT" + "&numbers=" + mob + "&message=" + Message + "&sender=" + "TXTLCL";



                        Stream data = client.OpenRead(url);
                        StreamReader reader = new StreamReader(data);
                        string s = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                       // Response.Write("<script> alert ('SMS Send Successfully') </script>");
                       // Response.Write("<script LANGUAGE='JavaScript' >alert('SMS Send Successful')</script>");
                        System.Web.HttpContext.Current.Response.Write("<script language=\"JavaScript\">alert(\"SMS Sent Successful'\")</script>");

                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SMS Send Successfully')", true);
                        // SendSMSParent(MobileNo);
                        
                    }
                    
                }
                if (status != "true")
                {
                    msgBox.ShowMessage("Please Select Atleast 1 Student ", "Saved", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    clear();
                    msgBox.ShowMessage("SMS Send Successfully", "Saved", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
          
        }

        private void SendSMSParent(string[] MobileNo)
        {
            try
            {
               
              string Message = txtMessage.Text;

                WebClient client = new WebClient();

                //my sms Mantra

               // string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";
                //string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=" + UserName + " & password=" + Password + " & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";

                //Redsms
                //string baseurl = "http://login.redsms.in/API/SendMessage.ashx?user=" + UserName + "&password=" + Password + "&phone=" + MobileNo + "&text=" + Message + " &type=p";
                String url = "http://api.textlocal.in/send/?username=" + "info@logicprosol.com" + "&hash=" + "cDotMW9pSI8-lqRk9oFHtH3iGJKeLicdH4BDvx0sTT" + "&numbers=" + MobileNo + "&message=" + Message + "&sender=" + "TXTLCL";
                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();

            }
            catch (Exception exp)
            {

                throw exp;
            }
           
        }

        private void SendStudentSMS(string strAction)
        {
            try
            {
                string urlName = "", senderName = "", smsType = "", apiKey = "";
                int count = GrdStudent.Rows.Count;
                string[] MobileNo = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdStudent.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");


                    if (chk != null && chk.Checked)
                    {

                        status = "true";
                        MobileNo[i] = GrdStudent.DataKeys[gvrow.RowIndex].Values["Mobile"].ToString();
                        string mob = MobileNo[0];


                        string Message = txtMessage.Text;

                        WebClient client = new WebClient();

                        //my sms Mantra

                        // string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";
                        //string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=" + UserName + " & password=" + Password + " & sendername=DM &mobileno =" + MobileNo + " & message=" + Message + " ";

                        //Redsms
                        //  string baseurl = "http://login.redsms.in/API/SendMessage.ashx?user=" + UserName + "&password=" + Password + "&phone=" + mob + "&text=" + Message + " &type=p";


                        string url = "http://api.textlocal.in/send/?username=" + "info@logicprosol.com" + "&apiKey=" + "cDotMW9pSI8-lqRk9oFHtH3iGJKeLicdH4BDvx0sTT" + "&numbers=" + mob + "&message=" + Message + "&sender=" + "TXTLCL";


                        Stream data = client.OpenRead(url);
                        StreamReader reader = new StreamReader(data);
                        string s = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                        // Response.Write("<script LANGUAGE='JavaScript' >alert('SMS Send Successful')</script>");
                        // System.Web.HttpContext.Current.Response.Write("<script language=\"JavaScript\">alert(\"SMS Send Successful'\")</script>");
                        //string popupScript = "<script language=JavaScript>";
                        //popupScript += "alert('Please enter valid Email Id');";
                        //popupScript += "</";
                        //popupScript += "script>";
                        //Page.RegisterStartupScript("PopupScript", popupScript);

                    }

                }


                if (status != "true")
                {
                    msgBox.ShowMessage("Please Select Atleast 1 Student ", "Saved", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    clear();
                    msgBox.ShowMessage("Message Send Successfully ", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        private void SendSMS(string[] MobileNo)
        {
                      
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void rbtlDesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common ObjEWA = new EWA_Common();
                BL_Common ObjBL = new BL_Common();
                ObjEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                ObjEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();

                DataSet ds = ObjBL.BindDesignation_BL(ObjEWA);
                ddlDesignation.Enabled = true;
                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("Select", "-1"));
                //ShowEmptyGridView(GrdEmployee);
                //ShowEmptyGridView(GrdViewEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartment.SelectedItem.Text.Equals("Select"))
                {
                    //GrdEmployee.DataSource = null;

                  //  GrdEmployee.DataBind();

                }
                else
                {
                    rbtlDesType.Enabled = true;
                    BindDesignationType();
                    ddlDesignation.Enabled = false;
                   // GrdEmployeeBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDesignation.SelectedItem.Text.Equals("Select"))
                {
                    GrdEmployee.DataSource = null;
          
                    GrdEmployee.DataBind();
                   
                }
                else
                {
                    //GrdViewEmployeeBind();
                    GrdEmployeeBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        void clear()
        {
            GrdEmployee.DataSource = "";
            GrdEmployee.DataBind();
            GrdParent.DataSource = "";
            GrdParent.DataBind();
            GrdStudent.DataSource = "";
            GrdStudent.DataBind();
            txtMessage.Text = "";
        }
        protected void GrdParent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdParent.PageIndex = e.NewPageIndex;
        }

    }
}
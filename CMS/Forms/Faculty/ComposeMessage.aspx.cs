using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Faculty;
using System.Configuration;
//Compose Message
namespace CMS.Forms.Faculty
{
    public partial class ComposeMessage : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private static DataSet dsGrdParent;
        private static DataSet dsGrdStudent;
        private static DataSet dsGrdEmployee;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                } BindEmptyGrid(GrdParent);
                BindEmptyGrid(GrdStudent);
                BindEmptyGrid(GrdEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

            //if (!IsPostBack)
            //{
            //}
        }

        #endregion

        // Add Dummy row to Grid

        #region BindEmptyGrid Method

        protected void BindEmptyGrid(GridView gv)
        {
            try
            {
                 SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
              // SqlConnection con = new SqlConnection("Data Source=comp9;Initial Catalog=CMSDB;Persist Security Info=True;User ID=sa;Password=12345678;");
                con.Open();
                SqlCommand cmd;
                if (gv.ID.Equals("GrdParent") || gv.ID.Equals("GrdStudent"))
                    cmd = new SqlCommand("select UserCode as 'StudentId',FirstName+' '+LastName as 'StudentName',ParentName+' '+LastName as 'ParentName',Mobile,ParentMobile from tblStudent where UserCode='-1'", con);
                else
                    cmd = new SqlCommand("select UserCode as 'EmployeeId',FirstName+' '+LastName as 'EmployeeName',Mobile from tblEmployee where UserCode='-1'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gv.DataSource = ds;
                gv.DataBind();
                int columncount = gv.Rows[0].Cells.Count;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Columns[3].Visible = false;
                //    gv.Columns[1].Visible = false;
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Black;
                gv.Rows[0].Cells[0].Font.Bold = true;
                gv.Rows[0].Cells[0].Text = "No Records Found";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion BindEmptyGrid Method

        //Sender Chnaged
        #region[Sender changed]

        protected void ddlSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSender.SelectedItem.Text.Equals("Select"))
                {
                    PanelEmployee.Visible = false;
                    PanelStudent.Visible = false;
                    PanelParent.Visible = false;
                }
                else if (ddlSender.SelectedItem.Text.Equals("Parent"))
                {
                    PanelParent.Visible = true;
                    PanelStudent.Visible = false;
                    PanelEmployee.Visible = false;

                    BindCourse(ddlParentCourse);
                    BindBranch(ddlParentCourse, ddlParentBranch);
                    BindClass(ddlParentBranch, ddlParentClass);
                }
                else if (ddlSender.SelectedItem.Text.Equals("Student"))
                {
                    PanelParent.Visible = false;
                    PanelStudent.Visible = true;
                    PanelEmployee.Visible = false;
                    BindCourse(ddlStudentCourse);
                    BindBranch(ddlParentCourse, ddlParentBranch);
                    BindClass(ddlParentBranch, ddlParentClass);
                }
                else if (ddlSender.SelectedItem.Text.Equals("Employee"))
                {
                    PanelParent.Visible = false;
                    PanelStudent.Visible = false;
                    PanelEmployee.Visible = true;
                    BindDepartment(ddlDepartment);
                    BindDesignation();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Dept
        #region[Bind Dept]

        private void BindDepartment(DropDownList ddlDepartment)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();// Session["OrgId"].ToString();
                DataSet ds = objBL.BindDepartment_BL(objEWA);

                ddlDepartment.DataSource = ds;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("Select", "-1"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Course
        #region[Bind Course]

        private void BindCourse(DropDownList ddlCourse)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();// Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "-1"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Parent Course Chnaged
        #region[Parent Course Changed]

        protected void ddlParentCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch(ddlParentCourse, ddlParentBranch);

                //BindClass(ddlParentCourse,ddlParentClass);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Branch
        #region[Bind BranCh]

        private void BindBranch(DropDownList ddlCourse, DropDownList ddlBranch)
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
                ddlBranch.Items.Insert(0, new ListItem("Select", "-1"));
                BindClass(ddlBranch, ddlParentClass);
                BindClass(ddlBranch, ddlStudentClass);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Class
        #region[Bind Class]

        private void BindClass(DropDownList ddlBranch, DropDownList ddlClass)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                if (!objEWA.BranchId.Equals("-1"))
                {
                    objEWA.OrgId = Session["OrgId"].ToString();// Session["OrgId"].ToString();
                    DataSet ds = objBL.BindClass_BL(objEWA);

                    ddlClass.DataSource = ds;
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ClassId";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("Select", "-1"));
                }
                else
                {
                    ddlClass.Items.Clear();
                    ddlClass.Items.Insert(0, new ListItem("Select", "-1"));
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Parent Class Changed
        #region[Parent Class Changed]

        protected void ddlParentClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_ComposeMessage ObjEWA = new EWA_ComposeMessage();
                ObjEWA.Action = "FetchParent";
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.CourseId = ddlParentCourse.SelectedValue.ToString();
                ObjEWA.ClassId = ddlParentClass.SelectedValue.ToString();
                ObjEWA.BranchId = ddlParentBranch.SelectedValue.ToString();

                DataSet ds = BindGridData(ObjEWA, GrdParent);
                dsGrdParent = ds.Copy();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind grid Data
        #region[Bind grid Data]

        private DataSet BindGridData(EWA_ComposeMessage ObjEWA, GridView Grd)
        {
            try
            {
                DataSet ds;
                BL_ComposeMessage ObjBL = new BL_ComposeMessage();

                ds = ObjBL.BindGridData_BL(ObjEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Grd.DataSource = ds;
                    Grd.DataBind();
                    Grd.Columns[3].Visible = true;
                }
                return ds;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return null;
            }
        }

        #endregion

        //Student Class Chnaged
        #region[Student Class Changed]

        protected void ddlStudentClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_ComposeMessage ObjEWA = new EWA_ComposeMessage();
                ObjEWA.Action = "FetchStudent";
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.CourseId = ddlStudentCourse.SelectedValue.ToString();
                ObjEWA.ClassId = ddlStudentClass.SelectedValue.ToString();
                ObjEWA.BranchId = ddlStudentBranch.SelectedValue.ToString();
                DataSet ds = BindGridData(ObjEWA, GrdStudent);
                dsGrdStudent = ds.Copy();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Student Course
        #region[Student course]

        protected void ddlStudentCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch(ddlStudentCourse, ddlStudentBranch);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Department chnaged
        #region[Department changed]

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindDesignation();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Design
        #region[Bind Design]

        private void BindDesignation()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();

                DataSet ds = objBL.BindDesignation_BL(objEWA);

                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Parent Branch
        #region[Parent Branch]

        protected void ddlParentBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass(ddlParentBranch, ddlParentClass);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Student Branch
        #region[Student Branch]

        protected void ddlStudentBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass(ddlStudentBranch, ddlStudentClass);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Design Changed
        #region[Design Changed]

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_ComposeMessage ObjEWA = new EWA_ComposeMessage();
                ObjEWA.Action = "FetchEmployee";
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                ObjEWA.DesignationId = ddlDesignation.SelectedValue.ToString();
                DataSet ds = BindGridData(ObjEWA, GrdEmployee);
                dsGrdEmployee = ds.Copy();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send Event
        #region[Send Event]

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSender.SelectedItem.Text.Equals("Student"))
                    SendSMS(GrdStudent);
                else if (ddlSender.SelectedItem.Text.Equals("Parent"))
                    SendSMS(GrdParent);
                else if (ddlSender.SelectedItem.Text.Equals("Employee"))
                    SendSMS(GrdEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send SMS
        #region[Send SMS]

        private void SendSMS(GridView GrdSender)
        {
            try
            {
                int count = GrdSender.Rows.Count;
                string[] MobileNo = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in Grd.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    if (chk.Checked)
                    {
                        MobileNo[i] = GrdSender.DataKeys[gvrow.RowIndex].Values["Mobile"].ToString();
                        i++;
                    }
                }
                SendSMS(MobileNo, i);
                
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send SMS
        #region[Send SMS]

        private void SendSMS(string[] MobileNo, int n)
        {
            try
            {
                string Message = txtMessage.Text;
                WebClient client = new WebClient();

                for (int i = 0; i < n; i++)
                {
                    string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=demouser & password=834309065 & sendername=DM &mobileno =" + MobileNo[i] + " & message=" + Message + " ";
                    Stream data = client.OpenRead(baseurl);
                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Employee Changed
        #region[Employee Changed]

        protected void GrdEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdEmployee.PageIndex = e.NewPageIndex;
                GrdEmployee.DataSource = dsGrdEmployee;
                GrdEmployee.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Student Chnaging
        #region[Student Changing]

        protected void GrdStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdStudent.PageIndex = e.NewPageIndex;
                GrdStudent.DataSource = dsGrdStudent;
                GrdStudent.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Parent Changing
        #region[Parent Changing]

        protected void GrdParent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdParent.PageIndex = e.NewPageIndex;
                GrdParent.DataSource = dsGrdParent;
                GrdParent.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
    }
}
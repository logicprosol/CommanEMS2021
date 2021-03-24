using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.HR;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.HR;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;

//Emp Course Class
namespace CMS.Forms.Admin
{
    public partial class EmpAssignSubject : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_EmpAssignSubject objBL = new BL_EmpAssignSubject();
        private EWA_EmpAssignSubject objEWA = new EWA_EmpAssignSubject();

        private BindControl ObjHelper = new BindControl();
        string mailid;
        string subject;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    BindCourse();

                    ShowEmptyGridView(GrdEmployee);
                    ShowEmptyGridView(GrdViewEmployee);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //  Show Empty GridView Function

        #region [Show Empty Grid Function]

        private void ShowEmptyGridView(GridView grid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(grid.Columns[0].HeaderText);
                dt.Columns.Add(grid.Columns[1].HeaderText);
                dt.Columns.Add(grid.Columns[2].HeaderText);
                dt.Columns.Add(grid.Columns[3].HeaderText);

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grid.DataSource = dt;
                grid.DataBind();
                grid.Columns[3].Visible = false;
                grid.Rows[0].Cells[0].ColumnSpan = 3;
                foreach (GridViewRow row in grid.Rows)
                {
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                }
                grid.Rows[0].Cells[0].Text = "Record not found !!!";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Course
        #region

        private void BindCourse()
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
                ddlCourse.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Game
        #region[Bind Game]

        private void BindClass()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                if (!objEWA.BranchId.Equals("Select"))
                {
                    DataSet ds = objBL.BindClass_BL(objEWA);

                    ddlClass.DataSource = ds;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ddlClass.DataTextField = "ClassName";
                        ddlClass.DataValueField = "ClassId";
                        ddlClass.DataBind();
                    }
                    else
                        ddlClass.Items.Clear();
                }
                else
                    ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, "Select");
                ddlSubject.SelectedIndex = 0;
                ShowEmptyGridView(GrdEmployee);
                ShowEmptyGridView(GrdViewEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Emp Grid
        #region[Employee Grid Bind]

        private void GrdEmployeeBind()
        {
            try
            {
                EWA_EmpAssignSubject objEWA = new EWA_EmpAssignSubject();
                BL_EmpAssignSubject objBL = new BL_EmpAssignSubject();
                objEWA.Action = "FetchFacultyCourseClass";
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.DesignationTypeId = "1";
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.SubjectId = ddlSubject.SelectedValue.ToString();

                DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GrdEmployee.DataSource = ds;
                    GrdEmployee.DataBind();
                    GrdEmployee.Columns[3].Visible = true;
                }
                else
                    ShowEmptyGridView(GrdEmployee);
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

                ShowEmptyGridView(GrdEmployee);
                ShowEmptyGridView(GrdViewEmployee);
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
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlBranch.DataSource = ds;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataBind();
                }
                else
                    ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, "Select");
                BindClass();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Class Changed
        #region[Class Changed]

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common ObjEWA = new EWA_Common();
                BL_Common ObjBL = new BL_Common();

                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.CourseId = ddlCourse.SelectedValue.ToString();
                ObjEWA.ClassId = ddlClass.SelectedValue.ToString();

                DataSet ds = ObjBL.BindSubject_BL(ObjEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlSubject.DataSource = ds;
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubjectId";
                    ddlSubject.DataBind();
                }
                else
                    ddlSubject.Items.Clear();

                ddlSubject.Items.Insert(0, "Select");
                ddlSubject.SelectedIndex = 0;

                ShowEmptyGridView(GrdEmployee);
                ShowEmptyGridView(GrdViewEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save ,Update,Delete Action performed on EmpDeptDes table
        #region[Perform Action]

        protected void lnkbtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                //if (strAction == "Update" || strAction == "Delete")
                //{
                //    objEWA.EmpDeptDesId = Convert.ToInt32(ViewState["EmpDeptDesId"].ToString());
                //}

                string strAction = "Save";
                int flag = 0;
                GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;

                objEWA.UserCode = grdrow.Cells[0].Text;
                objEWA.Action = strAction;
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.DesignationTypeId = "1";
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.SubjectId = ddlSubject.SelectedValue.ToString();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.IsActive = true;
                flag = objBL.EmpCourseClassAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {

                        database db=new database();
                         mailid = db.getDbstatus_Value("select Email from tblEmployee where UserCode='" + objEWA.UserCode + "'");
                         subject = db.getDbstatus_Value("select SubjectName from tblSubject where SubjectId='" + ddlSubject.SelectedValue.ToString() + "'");
                         sendmail();
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        GrdViewEmployeeBind();
                        GrdEmployeeBind();
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
                        msgBox.ShowMessage("already exists cann't  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
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
                GrdViewEmployeeBind();
                GrdEmployeeBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Subject Changed
        #region[Subject Changed]

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSubject.SelectedItem.Text.Equals("Select"))
                {
                    ShowEmptyGridView(GrdEmployee);
                    ShowEmptyGridView(GrdViewEmployee);
                }
                else
                {
                    Panel_Save.Visible = true;

                    GrdViewEmployeeBind();
                    GrdEmployeeBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Emp Grid Bind
        #region[Emp Grid Bind]

        private void GrdViewEmployeeBind()
        {
            try
            {
                EWA_EmpAssignSubject objEWA = new EWA_EmpAssignSubject();
                BL_EmpAssignSubject objBL = new BL_EmpAssignSubject();
                objEWA.Action = "FetchAssignedEmployee";
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.DesignationTypeId = "1";
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.SubjectId = ddlSubject.SelectedValue.ToString();
                DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GrdViewEmployee.DataSource = ds;
                    GrdViewEmployee.DataBind();
                    GrdViewEmployee.Columns[3].Visible = true;
                }
                else
                    ShowEmptyGridView(GrdViewEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Linkbtn Event
        #region[LnkBtb Event]

        protected void lnkbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    int flag;

                    EWA_EmpAssignSubject ObjEWA = new EWA_EmpAssignSubject();
                    BL_EmpAssignSubject ObjBL = new BL_EmpAssignSubject();
                    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;

                    ObjEWA.Action = "Delete";
                    ObjEWA.UserCode = grdrow.Cells[0].Text;
                    ObjEWA.CourseId = ddlCourse.SelectedValue.ToString();
                    ObjEWA.ClassId = ddlClass.SelectedValue.ToString();
                    ObjEWA.SubjectId = ddlSubject.SelectedValue.ToString();
                    ObjEWA.OrgId = Session["OrgId"].ToString();
                    flag = ObjBL.EmpCourseClassAction_BL(ObjEWA);
                    if (flag > 0)
                        msgBox.ShowMessage("deleted !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    GrdViewEmployeeBind();
                    GrdEmployeeBind();
                }
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
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //General message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Employee Data Bind
        #region[Employee Data Bind]

        protected void GrdViewEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    GridViewRow GrdRow = e.Row;

                    EWA_EmpAssignSubject ObjEWA = new EWA_EmpAssignSubject();
                    BL_EmpAssignSubject ObjBL = new BL_EmpAssignSubject();

                    ObjEWA.Action = "FetchSubject";
                    ObjEWA.UserCode = GrdRow.Cells[0].Text;
                    ObjEWA.OrgId = Session["OrgId"].ToString();
                    DataSet ds = ObjBL.FetchSubject_BL(ObjEWA);
                    string joinstr = "No record found";
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        joinstr = ds.Tables[0].Rows[0][0].ToString();
                        for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                        {
                            joinstr += "," + ds.Tables[0].Rows[i][0].ToString();
                        }
                    }
                    GrdRow.Cells[2].Text = joinstr;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Emp Data Bind
        #region[Emp Data Bind]

        protected void GrdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    GridViewRow GrdRow = e.Row;

                    EWA_EmpAssignSubject ObjEWA = new EWA_EmpAssignSubject();
                    BL_EmpAssignSubject ObjBL = new BL_EmpAssignSubject();

                    ObjEWA.Action = "FetchSubject";
                    ObjEWA.UserCode = GrdRow.Cells[0].Text;
                    ObjEWA.OrgId = Session["OrgId"].ToString();
                    DataSet ds = ObjBL.FetchSubject_BL(ObjEWA);
                    string joinstr = "No record found";
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        joinstr = ds.Tables[0].Rows[0][0].ToString();
                        for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                        {
                            joinstr += "," + ds.Tables[0].Rows[i][0].ToString();
                        }
                    }
                    GrdRow.Cells[2].Text = joinstr;
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        protected void GrdEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdViewEmployeeBind();
            GrdEmployee.PageIndex = e.NewPageIndex;
        }
        protected void sendmail()
        {

            string mailFrom = Convert.ToString("Schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            //string mailFrom = WebConfigurationManager.AppSettings["mail"];
            //string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = mailid.ToString();

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Assign Subject";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = " Dear,Teacher  ,HR assign to   subject '"+subject+"' for teaching so please prepared it ..Best of Luck ";
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);//Add the Creddentials- use your own email id and password
            Smtp.Port = 587;   // Gmail works on this port
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
            try
            {
                Smtp.Send(email);

            }
            catch (Exception ex)
            {

            }

        }
      
    }
}
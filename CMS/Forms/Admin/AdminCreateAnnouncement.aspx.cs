using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using DataAccessLayer.Faculty;
using EntityWebApp;
using EntityWebApp.Faculty;

//Create Anouncement
namespace CMS.Forms.Admin
{
    public partial class AdminCreateAnnouncement : System.Web.UI.Page
    {
        //Objects

        #region CreateAccouncement Code

        private DL_Messages ObjDL = new DL_Messages();
        private BL_Messages ObjBL = new BL_Messages();
        private EWA_Messages ObjEWA = new EWA_Messages();

        private static DataSet dsGrdSender;
        private static DataSet dsGrdFacultySender;
        int orgId = 0;
        #endregion CreateAccouncement Code

        //Page Load
        #region[Page load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                   Response.Redirect("~/CMSHome.aspx");
                }

                if (!IsPostBack)
                {
                    

                    BindCourse();
                    BindDepartment();

                    ShowEmptyGridView(GrdSender);
                    ShowEmptyGridView(GrdFacultySender);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Department
        #region[Bind Department]

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
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Course
        #region[Bind Course]

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
                ddlCourse.Items.Insert(0, new ListItem("Select", "Select"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //File Attachment
        #region[File Attachment]

        protected void lbtnFileAttachment_Click(object sender, EventArgs e)
        {
        }

        #endregion

        //Image Button plus
        #region[Image Button]

       
        #endregion

        //Image Button minus
        #region[Image Button Minus]

        
        #endregion

        //Image Button minus three
        #region[Image Button Minus three]

        

        #endregion

        //Image Button plus second          
        #region[Image button plus secound]

        
        #endregion

        //Course Index Changed
        #region[course index changed]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch();
                BindClass();
                ShowEmptyGridView(GrdSender);
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
                if (!objEWA.CourseId.Equals("Select"))
                {
                    DataSet ds = objDL.BindBranch_DL(objEWA);

                    ddlBranch.DataSource = ds;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataBind();
                }
                else
                    ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("Select", "Select"));
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
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[Commented]
        //protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string senderType=rbtnSender.SelectedValue.ToString();
        //    if (senderType.Equals("Student"))
        //    {
        //        BindStudentGridData();
        //    }

        //}
        #endregion

        //Bind Staff grid Data
        #region[Bind Staff grid Data]

        private void BindStaffGridData()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserCode = Session["UserCode"].ToString();
                objEWA.DesignationId = ddlDesignation.SelectedValue.ToString();
                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                DataSet ds = objBL.BindFacultyData_BL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GrdFacultySender.DataSource = ds;

                    GrdFacultySender.DataBind();
                    GrdFacultySender.Columns[2].Visible = true;
                    dsGrdFacultySender = ds.Copy();
                }
                else
                    ShowEmptyGridView(GrdFacultySender);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Student Grid Data
        #region[Bind Student Grid Data]

        private void BindStudentGridData()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                //objEWA.DivisionId = ddlDivision.SelectedValue.ToString();

                DataSet ds = objBL.BindStudentData_BL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GrdSender.DataSource = ds;
                    GrdSender.DataBind();
                    GrdSender.Columns[2].Visible = true;
                    dsGrdSender = ds.Copy();
                }
                else
                    ShowEmptyGridView(GrdSender);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send Button
        #region[Send Button]

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnSender.SelectedValue.Equals("Student"))
                    Action("SaveStudent");
                else if (rbtnSender.SelectedValue.Equals("Staff"))
                    Action("SaveStaff");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                if (strAction.Equals("SaveStudent"))
                {
                    SendStudentMessage(strAction);
                }
                else if (strAction.Equals("SaveStaff"))
                {
                    SendStaffMessage("SaveStaff");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send Staff MEssage
        #region[Send Staff Message]

        private void SendStaffMessage(string strAction)
        {
            try
            {
                DataSet MessageIdds = ObjDL.Get_MessageId();
                string MessageId = MessageIdds.Tables[0].Rows[0][0].ToString();
                ObjEWA.MessageId = MessageId;

                ObjEWA.Action = strAction;
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.FacultyId = Session["UserCode"].ToString();
                ObjEWA.DepartmentId = ddlDepartment.SelectedValue;
                ObjEWA.DesignationId = ddlDesignation.SelectedValue;
                ObjEWA.Subject = txtSubject.Text;
                ObjEWA.MessageContent = txtMessage.Text;

                int count = GrdFacultySender.Rows.Count;
                string[] UserCode = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdFacultySender.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    if (chk != null && chk.Checked)
                    {
                        UserCode[i] = GrdFacultySender.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString();
                        i++;
                    }
                }
              string _messageid=  ObjBL.SaveStaffMessage_BL(ObjEWA);
                ObjEWA.MessageId = _messageid;

                ObjEWA.Action = "SaveSender";
                string[] uCode = new string[i];

                Array.Copy(UserCode, 0, uCode, 0, i);

                ObjBL.SendStaffMessage_BL(ObjEWA, uCode);

                msgBox.ShowMessage("Sent Announcement Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                ClearControl();
                #region oldcode

                /*
                if (flpFirst.HasFile)
                {
                    int length = flpFirst.PostedFile.ContentLength;
                    ObjEWA.Data = new byte[length];
                    HttpPostedFile file1 = flpFirst.PostedFile;
                    file1.InputStream.Read(ObjEWA.Data, 0, length);
                }
                if (flpSecond.HasFile)
                {
                    int length = flpSecond.PostedFile.ContentLength;
                    ObjEWA.Data = new byte[length];
                    HttpPostedFile file2 = flpSecond.PostedFile;
                    file2.InputStream.Read(ObjEWA.Data, 0, length);
                }
                if (flpThird.HasFile)
                {
                    int length = flpThird.PostedFile.ContentLength;
                    ObjEWA.Data = new byte[length];
                    HttpPostedFile file3 = flpThird.PostedFile;
                    file3.InputStream.Read(ObjEWA.Data, 0, length);
                }

                int count = GrdFacultySender.Rows.Count;
                string[] StaffId = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdFacultySender.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                    if (chk != null && chk.Checked)
                    {
                        StaffId[i] = GrdFacultySender.DataKeys[gvrow.RowIndex].Values["StaffId"].ToString();
                        i++;
                    }
                }
                ObjBL.SaveStaffMessage_BL(ObjEWA);
                //ObjEWA.Action = "SaveSender";
                //ObjBL.SendStaffMessage_BL(ObjEWA, StaffId);

                msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                 */

                #endregion oldcode
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Send Student Message
        #region[Send Student Message]

        private void SendStudentMessage(string strAction)
        {
            try
            {
                database db = new database();
                DataSet MessageIdds = ObjDL.Get_MessageId();
                string MessageId = MessageIdds.Tables[0].Rows[0][0].ToString();
                ObjEWA.MessageId = MessageId;

                ObjEWA.Action = strAction;
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.FacultyId = Session["UserCode"].ToString();
                ObjEWA.CourseId = ddlCourse.SelectedValue.ToString();
                ObjEWA.BranchId = ddlBranch.SelectedValue.ToString();
                ObjEWA.CLassId = ddlClass.SelectedValue.ToString();
                ObjEWA.Subject = txtSubject.Text;
                //ObjEWA.DivisionId = ddlDivision.SelectedValue.ToString();
                ObjEWA.MessageContent = txtMessage.Text;
                ObjEWA.DepartmentId = db.getUniqueId("SELECT MAX(MessageId)MessageId from tblMessageSave").ToString();
                ObjEWA.DesignationId = "0";

                int count = GrdSender.Rows.Count;
                string[] UserCode = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdSender.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    if (chk != null && chk.Checked)
                    {
                        UserCode[i] = GrdSender.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString();
                        i++;
                    }
                }
              string _messageid=  ObjBL.SaveStudentMessage_BL(ObjEWA);

                ObjEWA.MessageId = _messageid;

                ObjEWA.Action = "SaveSender";
                string[] uCode = new string[i];
                Array.Copy(UserCode, 0, uCode, 0, i);
                ObjBL.SendStudentMessage_BL(ObjEWA, uCode);

                msgBox.ShowMessage("Sent Announcement Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                ClearControl();
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Sender Index Changed
        #region[Sender Index Changed]

        protected void rbtnSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnSender.Text.Equals("Staff"))
                {
                    Panel2.Visible = true;
                    Panel1.Visible = false;
                    ddlDepartment.SelectedIndex = 0;
                    rbtnFacultyType.SelectedIndex = -1;
                    ddlDesignation.SelectedIndex = 0;
                    ShowEmptyGridView(GrdFacultySender);
                    rbtnFacultyType.Enabled = false;
                    ddlDesignation.Enabled = false;
                }
                else if (rbtnSender.Text.Equals("Student"))
                {
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                    ddlCourse.SelectedIndex = 0;

                    //ddlBranch.SelectedIndex = 0;
                    //ddlClass.SelectedIndex = 0;
                    //ddlDivision.SelectedIndex = 0;

                    BindBranch();
                    BindClass();
                    BindDivision();

                    ShowEmptyGridView(GrdSender);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //Faculty Type Index Changed
        #region[Faculty Type Index Changed]

        protected void rbtnFacultyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlDepartment.Enabled = true;
                BindDesignation(rbtnFacultyType.SelectedValue.ToString());
                ShowEmptyGridView(GrdFacultySender);
                ddlDesignation.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Design
        #region[Bind Design]

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
                GrdFacultySender.DataSource = null;
                GrdFacultySender.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Designation Index Changed
        #region[Designation Index Changed]

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindStaffGridData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Faculty Sender Index Changed
        #region[Faculty Index Changed]

        protected void GrdFacultySender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Dept Selected Index Changed
        #region[Dept Selected Index Changed]
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
                    ddlDesignation.SelectedIndex = 0;
                    rbtnFacultyType.SelectedIndex = -1;
                    rbtnFacultyType.Enabled = true;
                    ddlDesignation.Enabled = false;
                    ShowEmptyGridView(GrdFacultySender);

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
      
        #endregion

        //Branch Index Changed
        #region[Branch Index Change]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
                BindDivision();
                ShowEmptyGridView(GrdSender);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Class Selected Index Changed
        #region[Class Selected Index Changed]

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //string senderType = rbtnSender.SelectedValue.ToString();
            //    //if (senderType.Equals("Student"))
            //    //{
            //    //    BindStudentGridData();
            //    //}

            //    //if (!ddlClass.SelectedValue.Equals("Select"))
            //    //    BindDivision();

            //    //else
            //    //    BindDivision();
            //   //ShowEmptyGridView(GrdSender);


               
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            try
            {
                string senderType = rbtnSender.SelectedValue.ToString();
                if (senderType.Equals("Student"))
                {
                    BindStudentGridData();
                }
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
                ShowEmptyGridView(GrdSender);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Show Empty Grid
        #region[Show Empty Grid]

        private void ShowEmptyGridView(GridView grid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(grid.Columns[0].HeaderText);
                dt.Columns.Add(grid.Columns[1].HeaderText);
                dt.Columns.Add(grid.Columns[2].HeaderText);

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grid.DataSource = dt;
                grid.DataBind();
                grid.Columns[2].Visible = false;
                grid.Rows[0].Cells[0].ColumnSpan = 2;
                foreach (GridViewRow row in grid.Rows)
                {
                    row.Cells[1].Visible = false;
                }
                grid.Rows[0].Cells[0].Text = "No Record found";
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

        #endregion CreateAccouncement Code

        //Sender Index Changing
        #region[Sender Index Changing]

        protected void GrdSender_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdSender.PageIndex = e.NewPageIndex;
                GrdSender.DataSource = dsGrdSender;
                GrdSender.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Faculty Sender Index Changing
        #region[Faculty Sender Index Changing]

        protected void GrdFacultySender_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdFacultySender.PageIndex = e.NewPageIndex;
                GrdFacultySender.DataSource = dsGrdFacultySender;
                GrdFacultySender.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Division Index Changing
        #region[Division Index Changing]

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string senderType = rbtnSender.SelectedValue.ToString();
            //    if (senderType.Equals("Student"))
            //    {
            //        BindStudentGridData();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }

        #endregion

        // Clear Control
        #region[CLEAR CONTROL]

        public void ClearControl()
        {
            BindCourse();
            BindBranch();
            BindClass();
            BindDivision();
            BindDepartment();

            rbtnSender.ClearSelection();
            rbtnFacultyType.ClearSelection();
            ShowEmptyGridView(GrdSender);
            ShowEmptyGridView(GrdFacultySender);
            txtMessage.Text = "";
            txtSubject.Text = "";

        }

        #endregion
    }
}
using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
//using BusinessAccessLayer.Admin;
using EntityWebApp;
using EntityWebApp.Admin;
using DataAccessLayer;
using BusinessAccessLayer.Admin;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CMS.Forms.Admin
{
    public partial class TimeTableCreation : System.Web.UI.Page
    {
        public static int orgId;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
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
                    BindDays();
                    BindTimeSlot();
                    DisableCntrl();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

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
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
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
                ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
                BindClass();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion        

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
                ddlClass.Items.Insert(0, new ListItem("Select", "0"));
                ddlSubject.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        private void BindSubject()
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

                ddlSubject.Items.Insert(0, new ListItem("Select", "0"));
                ddlSubject.Items.Insert(1, new ListItem("Break", "501"));
                ddlSubject.SelectedIndex = 0;

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        private void BindDays()
        {
            try
            {
                BL_TimeTableCreation objBL = new BL_TimeTableCreation();
                ddlDay.Items.Clear();
                DataSet ds = objBL.GetDays();
                ddlDay.DataSource = ds;
                ddlDay.DataTextField = "DAY";
                ddlDay.DataValueField = "DayId";
                ddlDay.DataBind();

                ddlDay.Items.Insert(0, new ListItem("Select", "0"));
                ddlDay.SelectedIndex = 0;

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        private void BindTimeSlot()
        {
            try
            {
                //BL_TimeTableCreation objBL = new BL_TimeTableCreation();
                //ddlTimeSlot.Items.Clear();
                //DataSet ds = objBL.GetTimeSlot();
                //ddlTimeSlot.DataSource = ds;
                //ddlTimeSlot.DataTextField = "TimeSlot";
                //ddlTimeSlot.DataValueField = "SlotId";
                //ddlTimeSlot.DataBind();

                //ddlTimeSlot.Items.Insert(0, new ListItem("Select", "0"));
               // ddlTimeSlot.SelectedIndex = 0;
                if (ddlTimeSlot.Items.Count <= 1)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SlotId,SlotFrom + '-' + SlotTo TimeSlot FROM tblTimeSlotMaster where OrgId='" + orgId.ToString() + "' "))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        ddlTimeSlot.DataSource = cmd.ExecuteReader();
                        ddlTimeSlot.DataTextField = "TimeSlot";
                        ddlTimeSlot.DataValueField = "SlotId";
                        ddlTimeSlot.DataBind();
                        cn.Close();
                    }

                    ddlTimeSlot.Items.Insert(0, new ListItem("--Select TimeSlot--"));
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        private void BindEmpSub()
        {
            try
            {
                BL_TimeTableCreation objBl = new BL_TimeTableCreation();
                EWA_TimeTableCreation objEwa = new EWA_TimeTableCreation();
                ddlEmployee.Items.Clear();
                if (ddlSubject.SelectedValue == "501")
                {
                    ddlEmployee.Items.Insert(0, new ListItem("NA", "501"));
                }
                else
                {
                    objEwa.SubjectId = Convert.ToInt32(ddlSubject.SelectedValue.ToString());
                    DataSet ds = objBl.GetEmpSub(objEwa);

                    ddlEmployee.DataSource = ds;
                    ddlEmployee.DataTextField = "EmpName";
                    ddlEmployee.DataValueField = "EmpId";
                    ddlEmployee.DataBind();
                }
                ddlEmployee.Items.Insert(0, new ListItem("Select", "0"));
                ddlEmployee.SelectedIndex = 0;

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        private void BindTimeTable()
        {
            try
            {
                BL_TimeTableCreation objBl = new BL_TimeTableCreation();
                EWA_TimeTableCreation objEwa = new EWA_TimeTableCreation();
                
                objEwa.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                DataSet ds = objBl.GetTimeTable(objEwa);

                GrdTimeTable.DataSource = ds;
                GrdTimeTable.DataBind();
           }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        private void EnableCntrl()
        {
            ddlSubject.Enabled = true;
            ddlDay.Enabled = true;
            ddlTimeSlot.Enabled = true;
            ddlEmployee.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            txtlectureno.Enabled = true;
           
        }

        private void DisableCntrl()
        {
            ddlSubject.Enabled = false;
            ddlDay.Enabled = false;
            ddlTimeSlot.Enabled = false;
            ddlEmployee.Enabled = false;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            txtlectureno.Enabled = false;
        }

        private void ClearCntrl()
        {
            ddlSubject.SelectedIndex = -1;
            ddlDay.SelectedIndex = -1;
            ddlTimeSlot.SelectedIndex = -1;
            ddlEmployee.SelectedIndex = -1;
        }

        private void clear()
        {
            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            ddlClass.ClearSelection();
            ddlSubject.ClearSelection();
            ddlDay.ClearSelection();
            ddlTimeSlot.ClearSelection();
            ddlEmployee.ClearSelection();
            txtlectureno.Text = "";
        }

        //General message
        #region[General Message]

        private void Action(string strAction)
        {
            try
            {
                BL_TimeTableCreation objBl1 = new BL_TimeTableCreation();
                EWA_TimeTableCreation objEWA1 = new EWA_TimeTableCreation();
                objEWA1.Action = strAction;
                Session["strAction"] = strAction;

                objEWA1.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                objEWA1.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                objEWA1.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                objEWA1.SubEmpId= Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                objEWA1.LecNo = Convert.ToInt32(txtlectureno.Text);

                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA1.TimeTableId = Convert.ToInt32(ViewState["TimeTableId"].ToString());
                }
                else
                { 
                    objEWA1.TimeTableId = 0;
                }

                DataSet ds= objBl1.CheckTimeTable(objEWA1);

                if ((ds.Tables[0].Rows.Count <= 0 && strAction == "Save") || (strAction == "Update" && ds.Tables[0].Rows.Count <= 0) || (strAction == "Update" && ds.Tables[0].Rows[0][0].ToString() == objEWA1.TimeTableId.ToString()) || strAction == "Delete")
                {
                    BL_TimeTableCreation objBl2 = new BL_TimeTableCreation();
                    EWA_TimeTableCreation objEWA2 = new EWA_TimeTableCreation();
                    BL_TimeTableCreation objBl22 = new BL_TimeTableCreation();
                    EWA_TimeTableCreation objEWA22 = new EWA_TimeTableCreation();

                    objEWA22.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                    objEWA22.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                    objEWA22.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                    objEWA22.SubEmpId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                    objEWA2.LecNo = Convert.ToInt32(txtlectureno.Text);
                    DataSet dss = objBl22.Employeetest(objEWA22);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        msgBox.ShowMessage("Already lecture assigned to teacher for that day", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                    }

                    objEWA2.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                    objEWA2.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                    objEWA2.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                    objEWA2.SubEmpId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                    objEWA2.LecNo = Convert.ToInt32(txtlectureno.Text);
                   
                    if (strAction == "Update" || strAction == "Delete")
                    {
                        objEWA2.TimeTableId = Convert.ToInt32(ViewState["TimeTableId"].ToString());
                    }
                    else
                    {
                        objEWA2.TimeTableId = 0;
                    }

                    DataSet ds1 = objBl2.CheckTimeTable1(objEWA2);

                    if ((ds1.Tables[0].Rows.Count <= 0 && strAction == "Save") || (strAction == "Update" && ds1.Tables[0].Rows.Count <= 0) || (strAction == "Update" && ds1.Tables[0].Rows[0][0].ToString() == objEWA1.TimeTableId.ToString()) || strAction == "Delete")
                    {
                        //To check Date According to Current Date
                        DateTime CurrentDate = DateTime.Now.Date;
                        int CurrentStartYear = CurrentDate.Year;
                        DateTime CurrentEndYear = CurrentDate.AddYears(1);
                        int CurrentMonth = CurrentDate.Month;

                        BL_TimeTableCreation objBl = new BL_TimeTableCreation();
                        EWA_TimeTableCreation objEWA = new EWA_TimeTableCreation();
                        objEWA.Action = strAction;

                        objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                        objEWA.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                        objEWA.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                        objEWA.LecNo = Convert.ToInt32(txtlectureno.Text);
                        if (strAction == "Update" || strAction == "Delete")
                        {
                            objEWA.TimeTableId = Convert.ToInt32(ViewState["TimeTableId"].ToString());
                        }
                        else
                        {
                            objEWA.TimeTableId = 0;
                        }

                        objEWA.CourseId = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                        objEWA.BranchId = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                        objEWA.SubjectId = Convert.ToInt32(ddlSubject.SelectedValue.ToString());
                        objEWA.SubEmpId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                        objEWA.OrgId = orgId;
                        objEWA.UserId = Session["UserCode"].ToString();
                        objEWA.IsActive = "True";
                        objEWA.LecNo = Convert.ToInt32(txtlectureno.Text);
                        //int flag = objBL.(objEWA);
                        int flag = objBl.TimeTableCreationAction_BL(objEWA);
                        if (flag > 0 && flag!=2)
                        {
                            ClearCntrl();
                            DisableCntrl();
                            BindTimeTable();
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

                        else if (flag > 0 && flag == 2)
                        {
                            if (strAction == "Save")
                            {
                                msgBox.ShowMessage("Sorry For that day Lecture NO Already Used!!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                            }
                            else if (strAction == "Update")
                            {
                                msgBox.ShowMessage("Sorry For that day Lecture NO Already Used !!!", "Updated", UserControls.MessageBox.MessageStyle.Critical);
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
                    else
                    {
                        MessagePopUp1.Show();

                        //msgBox.ShowMessage("Already Created !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        //DialogResult res = MessageBox.Show("Employee Overlap! Are You OK with Employee Overlap?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        //if (res == DialogResult.Yes)
                        //{
                            
                        //    overlapEmployee(strAction);
                        //}
                        //if (res == DialogResult.No)
                        //{
                            

                        //}
                    }
                }
                else
                {
                    //string message = "Your request is being processed.";
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("alert('");
                    //sb.Append(message);
                    //sb.Append("');");
                    //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());

                    MessagePopUp.Show();

                    //DialogResult res = MessageBox.Show("Subject Overlap! Are You OK with Subject Overlap?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //if (res == DialogResult.Yes)
                    //{
                    //    //MessageBox.Show("You have clicked Ok Button");
                    //    overlapsubject(strAction);
                    //}
                    //if (res == DialogResult.No)
                    //{
                    //    //MessageBox.Show("You have clicked Cancel Button");

                    //}

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            BindTimeTable();
            EnableCntrl();
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmpSub();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            EnableCntrl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           if(ddlTimeSlot.SelectedIndex==0)
            {
                msgBox.ShowMessage("Please Select Time Slot!!!", "Successfull", UserControls.MessageBox.MessageStyle.Critical);
            }
            if (txtlectureno.Text=="")
            {
                msgBox.ShowMessage("Please Enter Lecture Number According to its time!!!", "Successfull", UserControls.MessageBox.MessageStyle.Critical);
            }
            Action("Save");


        }

        protected void lnkTimeSlot_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkSlot = (LinkButton)sender;
                GridViewRow grdRow = (GridViewRow)lnkSlot.NamingContainer;
                ViewState["TimeTableId"] = GrdTimeTable.DataKeys[grdRow.RowIndex].Values["TimeTableId"].ToString();
                ddlSubject.SelectedValue = GrdTimeTable.DataKeys[grdRow.RowIndex].Values["SubjectId"].ToString();
                txtlectureno.Text = GrdTimeTable.DataKeys[grdRow.RowIndex].Values["LectureNo"].ToString();
                ddlDay.SelectedValue = GrdTimeTable.DataKeys[grdRow.RowIndex].Values["DayId"].ToString();
                ddlTimeSlot.SelectedValue = GrdTimeTable.DataKeys[grdRow.RowIndex].Values["SlotId"].ToString();
                BindEmpSub();
                ddlEmployee.SelectedValue = GrdTimeTable.DataKeys[grdRow.RowIndex].Values["EmpId"].ToString();
                EnableCntrl();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Update");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Delete");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCntrl();
            DisableCntrl();
            clear();
        }

        public void overlapsubject(string strAction)
        {
            try
            {

                BL_TimeTableCreation objBl1 = new BL_TimeTableCreation();
                EWA_TimeTableCreation objEWA1 = new EWA_TimeTableCreation();
                objEWA1.Action = strAction;

                objEWA1.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                objEWA1.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                objEWA1.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                objEWA1.SubEmpId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                objEWA1.LecNo = Convert.ToInt32(txtlectureno.Text);
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA1.TimeTableId = Convert.ToInt32(ViewState["TimeTableId"].ToString());
                }
                else
                {
                    objEWA1.TimeTableId = 0;
                }

                DataSet ds1 = objBl1.CheckTimeTable1(objEWA1);

                if ((ds1.Tables[0].Rows.Count <= 0 && strAction == "Save") || (strAction == "Update" && ds1.Tables[0].Rows.Count <= 0) || (strAction == "Update" && ds1.Tables[0].Rows[0][0].ToString() == objEWA1.TimeTableId.ToString()) || strAction == "Delete")
                {
                    //To check Date According to Current Date
                    DateTime CurrentDate = DateTime.Now.Date;
                    int CurrentStartYear = CurrentDate.Year;
                    DateTime CurrentEndYear = CurrentDate.AddYears(1);
                    int CurrentMonth = CurrentDate.Month;

                    BL_TimeTableCreation objBl = new BL_TimeTableCreation();
                    EWA_TimeTableCreation objEWA = new EWA_TimeTableCreation();
                    objEWA.Action = strAction;

                    objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                    objEWA.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                    objEWA.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                    objEWA.LecNo = Convert.ToInt32(txtlectureno.Text);
                    if (strAction == "Update" || strAction == "Delete")
                    {
                        objEWA.TimeTableId = Convert.ToInt32(ViewState["TimeTableId"].ToString());
                    }
                    else
                    {
                        objEWA.TimeTableId = 0;
                    }

                    objEWA.CourseId = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                    objEWA.BranchId = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                    objEWA.SubjectId = Convert.ToInt32(ddlSubject.SelectedValue.ToString());
                    objEWA.SubEmpId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                    objEWA.LecNo = Convert.ToInt32(txtlectureno.Text);
                    objEWA.OrgId = orgId;
                    objEWA.UserId = Session["UserCode"].ToString();
                    objEWA.IsActive = "True";

                    //int flag = objBL.(objEWA);
                    int flag = objBl.TimeTableCreationAction_BL(objEWA);
                    if (flag > 0)
                    {
                        ClearCntrl();
                        DisableCntrl();
                        BindTimeTable();
                        if (strAction == "Save")
                        {
                            msgBox.ShowMessage("Overlap Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                        else if (strAction == "Update")
                        {
                            msgBox.ShowMessage("Overlap Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                        else if (strAction == "Delete")
                        {
                            msgBox.ShowMessage("Overlap Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
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
                else
                {
                    MessagePopUp1.Show();

                    //msgBox.ShowMessage("Already Created !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    //DialogResult res = MessageBox.Show("Employee Overlap! Are You OK with Employee Overlap?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //if (res == DialogResult.Yes)
                    //{
                    //    overlapEmployee(strAction);
                    //}
                    //if (res == DialogResult.No)
                    //{
                        
                    //}
                }
            }
            catch(Exception ex)
            {

            }
       
        }

        public void overlapEmployee(string strAction)
        {
            try
            {


                //To check Date According to Current Date
                DateTime CurrentDate = DateTime.Now.Date;
                int CurrentStartYear = CurrentDate.Year;
                DateTime CurrentEndYear = CurrentDate.AddYears(1);
                int CurrentMonth = CurrentDate.Month;

                BL_TimeTableCreation objBl = new BL_TimeTableCreation();
                EWA_TimeTableCreation objEWA = new EWA_TimeTableCreation();
                objEWA.Action = strAction;

                objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue.ToString());
                objEWA.DayId = Convert.ToInt32(ddlDay.SelectedValue.ToString());
                objEWA.TimeSlotId = Convert.ToInt32(ddlTimeSlot.SelectedValue.ToString());
                objEWA.LecNo = Convert.ToInt32(txtlectureno.Text);
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.TimeTableId = Convert.ToInt32(ViewState["TimeTableId"].ToString());
                }
                else
                {
                    objEWA.TimeTableId = 0;
                }

                objEWA.CourseId = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                objEWA.BranchId = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                objEWA.SubjectId = Convert.ToInt32(ddlSubject.SelectedValue.ToString());
                objEWA.SubEmpId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                objEWA.OrgId = orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.LecNo = Convert.ToInt32(txtlectureno.Text);
                objEWA.IsActive = "True";

                //int flag = objBL.(objEWA);
                int flag = objBl.TimeTableCreationAction_BL(objEWA);
                if (flag > 0)
                {
                    ClearCntrl();
                    DisableCntrl();
                    BindTimeTable();
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Overlap Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Overlap Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Overlap Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
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
            catch (Exception ex)
            {

            }

        }

        protected void btnoverlapsubject_Click(object sender, EventArgs e)
        {
            overlapsubject(Session["strAction"].ToString());
            //msgBox.ShowMessage("overlap subject !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
        }

        protected void btnoverlapEmployee_Click(object sender, EventArgs e)
        {
            overlapEmployee(Session["strAction"].ToString());
            //msgBox.ShowMessage("overlap Employee !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
        }

        protected void btnPayFeeForgetAdmission_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('TimeSlotMaster.aspx' ,'_blank');", true);
        }
    }
}
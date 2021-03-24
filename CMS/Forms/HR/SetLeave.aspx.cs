using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using EntityWebApp;
using BusinessAccessLayer;
using System.Data;
using EntityWebApp.Admin;
using BusinessAccessLayer.Admin;

namespace CMS.Forms.HR
{
    public partial class SetLeave : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        EWA_SetLeave objEWA = new EWA_SetLeave();
        BL_SetLeave objBL = new BL_SetLeave();
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();
        int OrgID = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            OrgID = Convert.ToInt32(Session["OrgId"]);
            if (OrgID == 0)
            {
                Response.Redirect("~/College_Home.aspx");
            }
            if (!IsPostBack)
            {

                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                objEWA.UserCode = Convert.ToString(Session["UserCode"]);



                
                

            }
        }

        protected void rbtFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtFor.SelectedValue.ToString() == "Individual")
            {
                Panel_All.Visible = false;
                Panel_Individual.Visible = true;
            }
            else if (rbtFor.SelectedValue.ToString() == "All")
            {
                Panel_Individual.Visible = false;
                Panel_All.Visible = true;
                GrdAllEmployeeBind();
                GrdLeaveTypeForAllBind();
            }
            else
            {
                msgBox.ShowMessage("Please Select For Whom You Want To Set Leave", "Please Select!", UserControls.MessageBox.MessageStyle.Information);
            }
        }           


        private void GrdEmployeeBind()
        {
            try
            {
                objEWA.Action = "SearchEmployee";
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.SearchValue = txtName.Text;
                DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
                GrdEmployee.DataSource = ds;
                GrdEmployee.DataBind();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        protected void btnDetails_Click(object sender, EventArgs e)
        {
            
                if (txtName.Text != "")
                {
                    GrdEmployeeBind();
                    GrdLeaveTypeBind();
                }
                else
                {
                    msgBox.ShowMessage("Please Enter First Name Of Employee!", "Information", UserControls.MessageBox.MessageStyle.Information);
                  
                }
            
        }

        private void GrdAllEmployeeBind()
        {
            try
            {
                objEWA.Action = "FetchAllEmployee";
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());               
                DataSet ds = objBL.AllEmployeeGridBind_BL(objEWA);
                GrdAllEmployee.DataSource = ds;
                GrdAllEmployee.DataBind();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Leave Type Grid Bind
                #region[Leave Type Grid Bind]
                private void GrdLeaveTypeBind()
                {
                    try
                    {
                        int chk = CheckData();
                        if (chk > 0)
                        {
                            

                            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                            DataSet ds = objBL.LeaveTypeGridBind_BL(objEWA);
                            grdLeaveType.DataSource = ds;
                            grdLeaveType.DataBind();
                        }
                        else
                        {
                            //BL_LeaveType objBL1 = new BL_LeaveType();
                            //EWA_LeaveType objEWA1 = new EWA_LeaveType();

                            objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                            DataSet ds = objBL.LeaveTypeGridBind_BL(objEWA);
                            grdLeaveType.DataSource = ds;
                            grdLeaveType.DataBind();
                        }


                        //BL_LeaveType objBL = new BL_LeaveType();
                        //EWA_LeaveType objEWA = new EWA_LeaveType();

                        //objEWA.OrgId = "1";//Session["OrgId"].toString();
                        //DataSet ds = objBL.LeaveTypeGridBind_BL(objEWA);
                        //grdLeaveType.DataSource = ds;
                        //grdLeaveType.DataBind();
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                }

                #endregion   

                //Leave Type for All Grid Bind
                #region[Leave Type for All Grid Bind]
                private void GrdLeaveTypeForAllBind()
                {
                    try
                    {
                        BL_LeaveType objBL = new BL_LeaveType();
                        EWA_LeaveType objEWA = new EWA_LeaveType();
                        objEWA.OrgId = "1";//Session["OrgId"].toString();
                        DataSet ds = objBL.LeaveTypeGridBind_BL(objEWA);
                        GrdLeaveTypeForAll.DataSource = ds;
                        GrdLeaveTypeForAll.DataBind();
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                }

                #endregion   

                protected void btnSave_Click(object sender, EventArgs e)
                {
                    int chk = CheckData();
                    if (chk > 0)
                    {
                        Action("Update");
                    }
                    else
                    {
                        Action("Save");
                    }
                }

                //Save Action performed on Leave Balance table
                #region[Perform Action]
                private void Action(string strAction)
                {
                    try
                    {
                        int flag = 0;
                        int count = grdLeaveType.Rows.Count;
                        string[] LeaveId = new string[count];
                        int i = 0;
                        foreach (GridViewRow gvrow in grdLeaveType.Rows)
                        {
                            TextBox txt = (TextBox)gvrow.FindControl("txtTotalLeave");
                            if (txt != null && txt.Text != null)
                            {
                                LeaveId[i] = grdLeaveType.DataKeys[gvrow.RowIndex].Values["LeaveId"].ToString();
                                objEWA.LeaveId = LeaveId[i];
                                objEWA.BalanceLeave = txt.Text;
                                objEWA.Action = strAction;
                                objEWA.UserCode = Convert.ToString(GrdEmployee.Rows[1].Cells[0].Text);
                                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                                objEWA.UserId = Convert.ToString(Session["UserCode"]);                              
                                
                                objEWA.IsActive = true;
                                flag = objBL.SetLeaveAction_BL(objEWA);
                            }
                            i++;
                        }
                        if (flag > 0)
                        {
                            if (strAction == "Save")
                            {
                                msgBox.ShowMessage("Leave Set Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                            }
                            else if (strAction == "Update")
                            {
                                msgBox.ShowMessage("Leave Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
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
                        }                                            
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                }
                #endregion

           protected void BtnSaveForAll_Click(object sender, EventArgs e)
             {

                     try
                {
                int c = CheckDataForAll();
                if (c > 0)
                {
                    objEWA.Action = "Update";
                }
                else
                {
                    objEWA.Action = "Save";
                }
                int flag = 0;
                int count = grdLeaveType.Rows.Count;
                string[] LeaveId = new string[count];
                int i = 0;
                foreach (GridViewRow gdvrow in GrdAllEmployee.Rows)
                {
                    CheckBox chk = (CheckBox)gdvrow.FindControl("checkbox");
                    if (chk != null && chk.Checked)
                    {                                                        
                        foreach (GridViewRow gvrow in GrdLeaveTypeForAll.Rows)
                        {
                            TextBox txt = (TextBox)gvrow.FindControl("txtTotalLeave");
                            if (txt != null && txt.Text != null)
                            {                                                                                                    
                                objEWA.UserCode = (GrdAllEmployee.DataKeys[gdvrow.RowIndex].Values["UserCode"].ToString());//ViewState["UserCode"].ToString();
                                objEWA.LeaveId = GrdLeaveTypeForAll.DataKeys[gvrow.RowIndex].Values["LeaveId"].ToString(); //LeaveId[i];
                                objEWA.BalanceLeave = txt.Text;
                                objEWA.AcademicYearId = Convert.ToString(Session["academicYearId"]);
                                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                                objEWA.UserCode = Convert.ToString(Session["UserCode"]);
                                objEWA.IsActive = true;
                                flag = objBL.SetLeaveAction_BL(objEWA);
                            }
                           
                        }

                    }
                }
                if (flag > 0)
                {

                    if (objEWA.Action == "Save")
                    {
                        msgBox.ShowMessage("Leave Set Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (objEWA.Action == "Update")
                    {
                        msgBox.ShowMessage("Leave Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }

                }
                else
                {
                    if (objEWA.Action == "Save")
                    {
                        msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (objEWA.Action == "Update")
                    {
                        msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }             
               
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

                //Check Existing Data
                #region[Check Data]

                private int CheckData()
                {
                    int flag = 0;                   
                    objEWA.UserCode = Convert.ToString(GrdEmployee.Rows[1].Cells[0].Text);
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                    flag = objBL.CheckDuplicateEmployee_BL(objEWA);                   
                    return flag;
                }

                #endregion

                //Check Existing Data
                #region[Check Data]

                private int CheckDataForAll()
                {
                    int flag = 0;
                    int count = GrdAllEmployee.Rows.Count;
                    string[] UserCode = new string[count];
                    int i = 0;
                    foreach (GridViewRow gvrow in GrdAllEmployee.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                        if (chk != null && chk.Checked)
                        {

                    UserCode[i] = GrdAllEmployee.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString();
                    objEWA.UserCode = UserCode[i];
                    //objEWA.UserCode = Convert.ToString(GrdEmployee.Rows[1].Cells[0].Text);
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                    flag = objBL.CheckDuplicateEmployee_BL(objEWA);
                        }
                        i++;
                    }
                    return flag;
                }

                #endregion


                //Merge  Employee Name For Individual
        //        #region [Merge Employee Name For Individual]
        //        protected void OnDataBound(object sender, EventArgs e)
        //        {
        //            for (int i = GrdEmployee.Rows.Count - 1; i > 0; i--)
        //            {
        //                GridViewRow row = GrdEmployee.Rows[i];
        //                GridViewRow previousRow = GrdEmployee.Rows[i - 1];
        //                for (int j = 0; j < row.Cells.Count - 2; j++)
        //                {
        //                    //run this loop for the column which you thing the data will be similar
        //                    if ((row.Cells[j]).Text == (previousRow.Cells[j]).Text)
        //                    {
        //                        if (previousRow.Cells[j].RowSpan == 0)
        //                        {
        //                            if (row.Cells[j].RowSpan == 0)
        //                            {
        //                                previousRow.Cells[j].RowSpan += 2;
        //                            }
        //                            else
        //                            {
        //                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
        //                            }
        //                            row.Cells[j].Visible = false;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //#endregion

                //Merge Employee Name For All
                //#region [Merge Employee Name  For All]
                //protected void OnDataBound1(object sender, EventArgs e)
                //{

                //    for (int i = GrdAllEmployee.Rows.Count - 1; i > 0; i--)
                //    {
                //        GridViewRow row = GrdAllEmployee.Rows[i];
                //        GridViewRow previousRow = GrdAllEmployee.Rows[i - 1];
                //        for (int j = 0; j < row.Cells.Count - 2; j++)
                //        {
                //            //run this loop for the column which you thing the data will be similar
                //            //if (((CheckBox)row.Cells[j].FindControl("checkbox")).Text == ((CheckBox)previousRow.Cells[j].FindControl("checkbox")).Text)
                //            if ((row.Cells[j + 1]).Text == (previousRow.Cells[j + 1]).Text)
                //            {
                //                if (previousRow.Cells[j].RowSpan == 0)
                //                {
                //                    if (row.Cells[j].RowSpan == 0)
                //                    {
                //                        previousRow.Cells[j].RowSpan += 2;
                //                    }
                //                    else
                //                    {
                //                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                //                    }
                //                    row.Cells[j].Visible = false;
                //                }
                //            }
                //        }
                //    }
                //}
                //#endregion

                //Page Index Created
                #region GrdIndexChanged
                protected void GrdAllEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
                {
                    try
                    {
                        GrdAllEmployee.PageIndex = e.NewPageIndex;

                        GrdAllEmployee.DataSource = objBL.AllEmployeeGridBind_BL(objEWA);
                        GrdAllEmployee.DataBind();
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

                protected void grdLeaveType_PageIndexChanging(object sender, GridViewPageEventArgs e)
                {
                    grdLeaveType.PageIndex = e.NewPageIndex;
                }

                protected void GrdEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
                {
                    GrdEmployee.PageIndex = e.NewPageIndex;
                }
    }
       
}
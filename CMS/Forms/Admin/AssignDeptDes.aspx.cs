using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;

//Emp Design Dept
namespace CMS.Forms.Admin
{
    public partial class AssignDeptDes : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_AssignDeptDes objBL = new BL_AssignDeptDes();
        private EWA_AssignDeptDes objEWA = new EWA_AssignDeptDes();

        private BindControl ObjHelper = new BindControl();
        private static DataSet dsGrdViewEmployee;
        private static DataSet dsGrdEmployee;
        int orgId = 0;

        #endregion

        //Page Load
        #region[Page Load]

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
                    BindDepartment();
                    rbtlDesType.SelectedIndex = -1;
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

        //Bind Department
        #region[Bind Departments]

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
                ddlDepartment.Items.Insert(0, new ListItem("Select", "-1"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Department Index Changed
        #region[Department Index Changed]

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rbtlDesType.SelectedIndex = -1;
                ddlDesignation.Items.Clear();
                ddlDesignation.Items.Insert(0, new ListItem("Select", "-1"));
                ShowEmptyGridView(GrdEmployee);
                ShowEmptyGridView(GrdViewEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //RBT Design Index Changed
        #region[Design Index Changed]

        protected void rbtlDesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common ObjEWA = new EWA_Common();
                BL_Common ObjBL = new BL_Common();
                ObjEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                ObjEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();

                DataSet ds = ObjBL.BindDesignation_BL(ObjEWA);
                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("Select", "-1"));
                ShowEmptyGridView(GrdEmployee);
                ShowEmptyGridView(GrdViewEmployee);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DDL Design Index Changed
        #region[Design Index Changed]

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDesignation.SelectedItem.Text.Equals("Select"))
                {
                    GrdViewEmployee.DataSource = null;
                    GrdEmployee.DataSource = null;
                    GrdEmployee.DataBind();
                    GrdViewEmployee.DataBind();
                }
                else
                {
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

        //Emp Bind
        #region[Emp Bind]

        private void GrdViewEmployeeBind()
        {
            try
            {
                EWA_AssignDeptDes objEWA = new EWA_AssignDeptDes();
                BL_AssignDeptDes objBL = new BL_AssignDeptDes();
                objEWA.Action = "FetchAssignedEmployee";
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();

                objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
                objEWA.DesignationId = ddlDesignation.SelectedValue.ToString();
                DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GrdViewEmployee.DataSource = ds;
                    GrdViewEmployee.DataBind();
                    dsGrdViewEmployee = ds.Copy();
                    GrdViewEmployee.Columns[3].Visible = true;
                }
                else
                {
                    GrdViewEmployee.DataSource = null;
                    GrdViewEmployee.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Emp Bind
        #region[Grid Emp Bind]

        private void GrdEmployeeBind()
        {
            try
            {
                EWA_AssignDeptDes objEWA = new EWA_AssignDeptDes();
                BL_AssignDeptDes objBL = new BL_AssignDeptDes();
                objEWA.Action = "FetchNotAssignedEmployee";
                objEWA.OrgId = Session["OrgId"].ToString();

                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
                objEWA.DesignationId = ddlDesignation.SelectedValue.ToString();

                DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GrdEmployee.DataSource = ds;
                    GrdEmployee.DataBind();
                    dsGrdEmployee = ds.Copy();
                    GrdEmployee.Columns[3].Visible = true;
                }
                else
                {
                    ShowEmptyGridView(GrdEmployee);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Assign Event
        #region[Assign Event]

        protected void lnkbtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                string strAction = "Update";
                int flag = 0;
                GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
                objEWA.Action = strAction;
                objEWA.UserCode = grdrow.Cells[0].Text;
                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
                objEWA.DesignationId = ddlDesignation.SelectedValue.ToString();
                objEWA.OrgId = Session["OrgId"].ToString(); ;
                objEWA.UserId = Session["UserCode"].ToString(); ;
                objEWA.IsActive = true;
                flag = objBL.EmpDeptDesAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        GrdViewEmployeeBind();
                        GrdEmployeeBind();
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        GrdViewEmployeeBind();
                        GrdEmployeeBind();
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
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Link Button
        #region[Link Button]

        protected void lnkbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    int flag;

                    EWA_AssignDeptDes ObjEWA = new EWA_AssignDeptDes();
                    BL_AssignDeptDes ObjBL = new BL_AssignDeptDes();
                    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;

                    ObjEWA.Action = "Delete";
                    ObjEWA.UserCode = grdrow.Cells[0].Text;
                    ObjEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
                    ObjEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
                    ObjEWA.DesignationId = ddlDesignation.SelectedValue.ToString();

                    flag = ObjBL.EmpDeptDesAction_BL(ObjEWA);
                    if (flag > 0)
                        msgBox.ShowMessage("deleted !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    else
                        msgBox.ShowMessage("Not Deleted. Atleast one department should be assigned !!!", "Not Deleted", UserControls.MessageBox.MessageStyle.Information);
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

        //Emp Index Changed
        #region[Emp Index Changed]

        protected void GrdEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //Emp Data Bound
        #region[Emp Data Bound]

        protected void GrdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    ////foreach (GridViewRow GrdRow in GrdEmployee.Rows)
                    ////{
                    GridViewRow GrdRow = e.Row;
                    EWA_AssignDeptDes ObjEWA = new EWA_AssignDeptDes();
                    BL_AssignDeptDes ObjBL = new BL_AssignDeptDes();
                    ObjEWA.Action = "FetchDepartment";
                    ObjEWA.UserCode = GrdRow.Cells[0].Text;

                    DataSet ds = ObjBL.FetchDepartment_BL(ObjEWA);
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
                    //}
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Emp Data Bound
        #region[Emp Data Bound]

        protected void GrdViewEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowIndex > -1)
                {
                    GridViewRow GrdRow = e.Row;
                    EWA_AssignDeptDes ObjEWA = new EWA_AssignDeptDes();
                    BL_AssignDeptDes ObjBL = new BL_AssignDeptDes();
                    ObjEWA.Action = "FetchDepartment";
                    ObjEWA.UserCode = GrdRow.Cells[0].Text;

                    DataSet ds = ObjBL.FetchDepartment_BL(ObjEWA);
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

        //Emp Page Index Change
        #region[Emp Page Index Change]

        protected void GrdViewEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdViewEmployee.PageIndex = e.NewPageIndex;
                GrdViewEmployee.DataSource = dsGrdViewEmployee;
                GrdViewEmployee.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Emp Page Index Change
        #region[Emp Page Index Change]

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

        //Commented
        #region[Commented]
        //#region OldCode

        ////Save ,Update,Delete Action performed on EmpDeptDes table
        //#region[Perform Action]
        //private void Action(string strAction)
        //{
        //        try
        //        {
        //            //if (strAction == "Update" || strAction == "Delete")
        //            //{
        //            //    objEWA.EmpDeptDesId = Convert.ToInt32(ViewState["EmpDeptDesId"].ToString());
        //            //}

        //            int flag=0;
        //            int count = GrdEmployee.Rows.Count;
        //            string[] UserCode = new string[count];
        //            int i = 0;
        //            foreach (GridViewRow gvrow in GrdEmployee.Rows)
        //            {
        //                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
        //                if (chk != null && chk.Checked)
        //                {
        //                    UserCode[i] = GrdEmployee.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString();
        //                    objEWA.UserCode = UserCode[i];

        //                }
        //                objEWA.Action = strAction;
        //                objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
        //                objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
        //                objEWA.DesignationID = ddlDesignation.SelectedValue.ToString();

        //                objEWA.OrgId = "1";
        //                objEWA.UserId = "1";
        //                objEWA.IsActive = true;
        //                flag = objBL.EmpDeptDesAction_BL(objEWA);
        //                i++;

        //            }

        //            if (flag > 0)
        //            {
        //                if (strAction == "Save")
        //                {
        //                    msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
        //                }
        //                else if (strAction == "Update")
        //                {
        //                    msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
        //                }
        //                else if (strAction == "Delete")
        //                {
        //                    msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
        //                }

        //            }
        //            else
        //            {
        //                if (strAction == "Save")
        //                {
        //                    msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //                }
        //                else if (strAction == "Update")
        //                {
        //                    msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //                }
        //                else if (strAction == "Delete")
        //                {
        //                    msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //                }
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            throw;
        //        }

        //}

        //#endregion

        ////Bind Department
        //private void BindDepartment()
        //{
        //    EWA_Common objEWA = new EWA_Common();
        //    BL_Common objBL = new BL_Common();
        //    objEWA.OrgId = "1";
        //    DataSet ds = objBL.BindDepartment_BL(objEWA);

        //    ddlDepartment.DataSource = ds;
        //    ddlDepartment.DataTextField = "DepartmentName";
        //    ddlDepartment.DataValueField = "DepartmentId";
        //    ddlDepartment.DataBind();
        //    ddlDepartment.Items.Insert(0, "Select");

        //}

        //protected void rbtlDesType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Panel_Save.Visible = true;
        //    BindDesignation();
        //    GrdEmployeeBind();
        //}

        ////Bind Designation
        //private void BindDesignation()
        //{
        //    EWA_Common objEWA = new EWA_Common();
        //    BL_Common objBL = new BL_Common();
        //    objEWA.DepartmentId = ddlDepartment.SelectedValue.ToString();
        //    objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
        //    //objEWA.OrgId = "1";
        //    DataSet ds = objBL.BindDesignation_BL(objEWA);

        //    ddlDesignation.DataSource = ds;
        //    ddlDesignation.DataTextField = "DesignationName";
        //    ddlDesignation.DataValueField = "DesignationId";
        //    ddlDesignation.DataBind();
        //    ddlDesignation.Items.Insert(0, "Select");

        //}

        ////Employee Grid Bind
        //#region[Employee Grid Bind]

        //private void GrdEmployeeBind()
        //{
        //    try
        //    {
        //        EWA_AssignDeptDes objEWA = new EWA_AssignDeptDes();
        //        objEWA.OrgId = "1";
        //        objEWA.DesignationTypeId = rbtlDesType.SelectedValue.ToString();
        //        DataSet ds = objBL.EmployeeGridBind_BL(objEWA);
        //        GrdEmployee.DataSource = ds;
        //        GrdEmployee.DataBind();
        //    }

        //    catch (Exception exp)
        //    {
        //        //GeneralErr(exp.Message.ToString());
        //        //throw;
        //    }
        //}

        //#endregion

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //  Action("Save");
        //}

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
                dt.Columns.Add(grid.Columns[3].HeaderText);

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grid.DataSource = dt;
                grid.DataBind();
                grid.Columns[3].Visible = false;
                string empty = grid.Rows[0].Cells[2].Text;
                grid.Rows[0].Cells[2].Text = null;
                grid.Rows[0].Cells[0].ColumnSpan = 3;
                foreach (GridViewRow row in grid.Rows)
                {
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                }
                grid.Rows[0].Cells[0].Text = empty;
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

        #endregion
    }
}
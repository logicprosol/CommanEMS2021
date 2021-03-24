using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.SuperAdmin
{
    public partial class DepartmentDesignationSA : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_DepartmentDesignation objBL = new BL_DepartmentDesignation();
        private EWA_DepartmentDesignation objEWA = new EWA_DepartmentDesignation();

        private BindControl ObjHelper = new BindControl();
        public static int orgId;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //To Call Form Controlles Load
                    DataTable dt = new DataTable();
                    dt = BindOrganization();
                    ddlOrganization.DataSource = dt;
                    ddlOrganization.DataTextField = "OrgName";
                    ddlOrganization.DataValueField = "OrganizationId";
                    ddlOrganization.DataBind();
                    ddlOrganization.Items.Insert(0, new ListItem("Select", "0"));

                    ddlOrganization1.DataSource = dt;
                    ddlOrganization1.DataTextField = "OrgName";
                    ddlOrganization1.DataValueField = "OrganizationId";
                    ddlOrganization1.DataBind();
                    ddlOrganization1.Items.Insert(0, new ListItem("Select", "0"));
                    #region CallAllMethods
                    LoadDepartmentTab();
                    GrdDepartmentBind();
                    LoadDesignationTab();
                    BindDDLDesignationType();
                    BindddlDepartment();

                    #endregion
                }

            }
            catch (Exception exp)
            {
               //GeneralErr(exp.Message.ToString());
            }
        }

        public DataTable BindOrganization()
        {
            string query = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
            return GetData(query);
            
            
        }
        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection constr1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                using (SqlConnection con = (constr1))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }

                }
            }
            catch (Exception ex) { }
            return dt;
        }
        //Bind DL Department
        #region[Bind DL Departmernt]

        private void BindddlDepartment()
        {
            try
            {
                DataSet ds = objBL.BindDepartment_BL(Convert.ToInt32( ddlOrganization1.SelectedValue));
                ddlDepartment.DataSource = ds;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //on form load
        #region[Load Dept Tab]

        private void LoadDepartmentTab()
        {
            try
            {
                btnNew.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtDepartmentCode.Enabled = false;
                txtDepartmentName.Enabled = false;
                rbtStatus.Enabled = false;
                txtDepartmentCode.Text = "";
                txtDepartmentName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Load Design Tab
        #region[Load Design Tab]

        private void LoadDesignationTab()
        {
            try
            {
                btnNewD.Visible = true;
                btnSaveD.Visible = false;
                btnUpdateD.Visible = false;
                btnDeleteD.Visible = false;
                txtDesignationCode.Enabled = false;
                txtDesignationName.Enabled = false;
                ddlDesignationType.Enabled = false;
                txtDesignationCode.Text = "";
                txtDesignationName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //on grid item click
        #region[On Grid Click]

        private void GridItemClick()
        {
            try
            {
                btnNew.Visible = false;
                btnSave.Visible = false;
                btnSave.Enabled = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                txtDepartmentCode.Enabled = true;
                txtDepartmentName.Enabled = true;
                rbtStatus.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //InsertUpdateDelete for Department
        #region InsertUpdateDelete

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnNew.Visible = false;
                txtDepartmentCode.Enabled = true;
                txtDepartmentName.Enabled = true;
                rbtStatus.Enabled = true;
                txtDepartmentCode.Text = "";
                txtDepartmentName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Event
        #region[Save Event]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    int chk = CheckData();
                    if (chk > 0)
                    {
                        msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        Action("Save");
                        GrdDepartmentBind();
                        LoadDepartmentTab();

                        //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Event
        #region[update Event]

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    int chk = CheckData();
                    if (chk > 1)
                    {
                        msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        string[] confirmValue = Request.Form["confirm_value"].Split(',');
                        if (confirmValue[confirmValue.Length - 1] == "Yes")
                        {
                            Action("Update");
                            GrdDepartmentBind();
                            LoadDepartmentTab();
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Event
        #region[Delete Event]

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    GrdDepartmentBind();
                    LoadDepartmentTab();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel Event
        #region[Cancel Event]

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                rbtStatus.ClearSelection();
                LoadDepartmentTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Department
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.DepartmentId = Convert.ToInt32(ViewState["DepartmentId"].ToString());
                }
                objEWA.DepartmentCode = txtDepartmentCode.Text.Trim();
                objEWA.DepartmentName = txtDepartmentName.Text.Trim();
                //Send these values from Session
                objEWA.OrgId =Convert.ToInt32( ddlOrganization.SelectedValue);// orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                if (rbtStatus.Items[0].Selected)
                {
                    objEWA.IsActive = true;
                }
                else
                {
                    objEWA.IsActive = false;
                }
                int flag = objBL.DepartmentAction_BL(objEWA);
                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        //msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                        //msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Updated", "alert('Record Updated Successfully !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                        //msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Deleted", "alert('Record Deleted Successfully !!!')", true);
                    }
                }
                else
                {
                    if (strAction == "Save")
                    {
                        //msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                        //msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                        //msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete !!!')", true);
                    }
                }
                //strAction = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Existing Data
        #region[Check Data]

        private int CheckData()
        {
            int i = 0;
            try
            {
                EWA_DepartmentDesignation objEWA = new EWA_DepartmentDesignation();
                objEWA.DepartmentName = txtDepartmentName.Text.Trim();
                objEWA.OrgId = Convert.ToInt32(ddlOrganization.SelectedValue);// orgId;
                i = objBL.CheckDuplicateDepartment_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            return i;
        }

        #endregion
        //Department Grid Bind
        #region[Department Grid Bind]

        private void GrdDepartmentBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(ddlOrganization.SelectedValue);// orgId;
                DataSet ds = objBL.DepartmentGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdDepartment.DataSource = ds;
                    GrdDepartment.DataBind();
                    int columncount = GrdDepartment.Rows[0].Cells.Count;
                    GrdDepartment.Rows[0].Cells.Clear();
                    GrdDepartment.Rows[0].Cells.Add(new TableCell());
                    GrdDepartment.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdDepartment.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdDepartment.DataSource = ds;
                    GrdDepartment.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DepartmentLinkButtonClick
        #region DepartmentLinkButtonClick

        protected void lnkBtnDepartmentName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    rbtStatus.ClearSelection();
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["DepartmentId"] = GrdDepartment.DataKeys[grdrow.RowIndex].Values["DepartmentId"].ToString();
                    //txtDepartmentId.Text = GrdDepartment.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtDepartmentName.Text = GrdDepartment.DataKeys[grdrow.RowIndex].Values["DepartmentName"].ToString();
                    txtDepartmentCode.Text = GrdDepartment.DataKeys[grdrow.RowIndex].Values["DepartmentCode"].ToString();
                    string isActive = GrdDepartment.DataKeys[grdrow.RowIndex].Values["IsActive"].ToString();
                    if (isActive == "True")
                    {
                        rbtStatus.Items[0].Selected = true;
                    }
                    else
                    {
                        rbtStatus.Items[1].Selected = true;
                    }

                    GridItemClick();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdDepartment.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(ddlOrganization.SelectedValue); //orgId;
                GrdDepartment.DataSource = objBL.DepartmentGridBind_BL(objEWA);
                GrdDepartment.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Designation Tab Region
        #region DesignationTabRegion

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartment.SelectedItem.Text.Equals("Select"))
                {

                }
                else
                {
                    GrdDesignationBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //on grid item click
        #region[On grid Item Click]

        private void GridItemClickD()
        {
            try
            {
                btnNewD.Visible = false;
                btnSaveD.Visible = false;
                btnSaveD.Enabled = true;
                btnUpdateD.Visible = true;
                btnDeleteD.Visible = true;
                txtDesignationCode.Enabled = true;
                txtDesignationName.Enabled = true;
                ddlDesignationType.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //InsertUpdateDelete for Designation
        #region InsertUpdateDelete Designation

        //BtnNew
        protected void btnNewD_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveD.Visible = true; ;
                btnUpdateD.Visible = false;
                btnDeleteD.Visible = false;
                btnNewD.Visible = false;
                btnUpdateD.Enabled = true;
                btnDeleteD.Enabled = true;
                txtDesignationCode.Enabled = true;
                txtDesignationName.Enabled = true;
                ddlDesignationType.Enabled = true;
                txtDesignationCode.Text = "";
                txtDesignationName.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //BtnSave
        #region[Save Doc Click]

        protected void btnSaveD_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    int chk = CheckDataD();
                    if (chk > 0)
                    {
                        msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        ActionD("Save");
                        GrdDesignationBind();
                        LoadDesignationTab();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //BtnUpdate
        #region[Update Event]

        protected void btnUpdateD_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    int chk = CheckDataD();
                    if (chk > 1)
                    {
                        msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        ActionD("Update");
                        GrdDesignationBind();
                        LoadDesignationTab();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //BtnDelete
        #region[Delete Event]

        protected void btnDeleteD_Click(object sender, EventArgs e)
        {
            try
            {
                ActionD("Delete");
                GrdDesignationBind();
                LoadDesignationTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Btncancel
        #region[Cancel Event]

        protected void btnCancelD_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDesignationTab();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Designation
        #region[Perform Action]

        private void ActionD(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.DesignationId = Convert.ToInt32(ViewState["DesignationId"].ToString());
                }
                if (ddlDepartment.SelectedIndex != 0)
                {
                    objEWA.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                }
                objEWA.DesignationCode = txtDesignationCode.Text.Trim();
                objEWA.DesignationName = txtDesignationName.Text.Trim();
                //Values from Session
                objEWA.OrgId = Convert.ToInt32(ddlOrganization1.SelectedValue); //orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = true;

                if (ddlDesignationType.SelectedIndex != 0)
                {
                    objEWA.DesignationTypeId = ddlDesignationType.SelectedValue;
                }
                else
                {
                    msgBox.ShowMessage("Please select DesignationType !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
                int flag = objBL.DesignationAction_BL(objEWA);
                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        //msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                        //msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Updated", "alert('Record Updated Successfully !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                        //msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Deleted", "alert('Record Deleted Successfully !!!')", true);
                    }
                }
                else
                {
                    if (strAction == "Save")
                    {
                        //msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                        //msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                        //msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete !!!')", true);
                    }
                }
                strAction = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Existing Data
        #region[Check Data]

        private int CheckDataD()
        {
            int i = 0;
            try
            {
                EWA_DepartmentDesignation objEWA = new EWA_DepartmentDesignation();
                objEWA.DesignationName = txtDesignationName.Text.Trim();
                objEWA.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                i = objBL.CheckDuplicateDesignation_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            return i;
        }

        #endregion
        //Designation Grid Bind
        #region[Designation Grid Bind]

        private void GrdDesignationBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(ddlOrganization1.SelectedValue); //orgId;
                objEWA.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                DataSet ds = objBL.DesignationGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdDesignation.DataSource = ds;
                    GrdDesignation.DataBind();
                    int columncount = GrdDesignation.Rows[0].Cells.Count;
                    GrdDesignation.Rows[0].Cells.Clear();
                    GrdDesignation.Rows[0].Cells.Add(new TableCell());
                    GrdDesignation.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdDesignation.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdDesignation.DataSource = ds;
                    GrdDesignation.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DesignationLinkButtonClick
        #region DesignationLinkButtonClick

        protected void lnkBtnDesignationName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["DesignationId"] = GrdDesignation.DataKeys[grdrow.RowIndex].Value.ToString();

                    txtDesignationCode.Text = GrdDesignation.DataKeys[grdrow.RowIndex].Values["DesignationCode"].ToString();
                    txtDesignationName.Text = GrdDesignation.DataKeys[grdrow.RowIndex].Values["DesignationName"].ToString();
                    string DesignationTypeId = GrdDesignation.DataKeys[grdrow.RowIndex].Values["DesignationTypeId"].ToString();
                    ddlDesignationType.SelectedValue = DesignationTypeId;
                    //string DepartmentId = GrdDesignation.DataKeys[grdrow.RowIndex].Values["DepartmentId"].ToString();
                    //ddlDepartment.SelectedValue = DepartmentId;

                    GridItemClickD();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(ddlOrganization.SelectedValue); //orgId;
                objEWA.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                GrdDesignation.PageIndex = e.NewPageIndex;
                GrdDesignation.DataSource = objBL.DesignationGridBind_BL(objEWA);
                GrdDesignation.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //select dat of Designation Type
        #region BindDDLDesignationType

        private void BindDDLDesignationType()
        {
            try
            {
                EWA_DepartmentDesignation objEWA = new EWA_DepartmentDesignation();
                DataSet dsDesignation = objBL.BindDDLDesignationType_BL();
                ddlDesignationType.DataSource = dsDesignation;
                ddlDesignationType.DataTextField = "DesignationType";
                ddlDesignationType.DataValueField = "DesignationTypeId";

                ddlDesignationType.DataBind();
                ddlDesignationType.Items.Insert(0, "Select");
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
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('"+ msg + "')", true);
        }

        #endregion

        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                GrdDepartmentBind();
            }
            catch (Exception ex) { }
        }

        protected void ddlOrganization1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindddlDepartment();
                
            }
            catch (Exception ex) { }
        }
    }
}
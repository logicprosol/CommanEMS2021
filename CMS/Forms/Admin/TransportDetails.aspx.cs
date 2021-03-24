using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Web;
using System.Web.UI;
using EntityWebApp;
using BusinessAccessLayer;
using DataAccessLayer;
//Transport Details
namespace CMS.Forms.Admin
{
    public partial class TransportDetails : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        public static int orgId;
        private BL_Transport objBL = new BL_Transport();
        private EWA_Transport objEWA = new EWA_Transport();
        database db = new database();
        // private BindControl ObjHelper = new BindControl();

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
                    //RoutsTabLoad
                    LoadFormR();
                    GrdRouteBind();

                    //Board TabLoad
                    LoadFormB();
                    ddlRouteBBind();
                    GrdBoardBind();

                    //VehicleTabLoad
                    LoadFormV();
                    ddlBoardBind();
                    GrdVehicleBind();

                    //DriverTabLoad
                    LoadFormD();
                    GrdDriverInfoBind();

                    //AllotDriverToBusTabLoad
                    ddlDriverBind();
                    ddlVehicleBind();
                    GrdAllotDriverBind();

                    //AlloteRouteTabLoad
                    LoadFormAR();
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For RoutTab

        //on form load
        #region[Form Load]

        private void LoadFormR()
        {
            try
            {
                btnNewR.Visible = true;
                btnSaveR.Visible = false;
                btnUpdateR.Visible = false;
                btnDeleteR.Visible = false;
                btnCancelR.Visible = true;
                txtRoute.Enabled = false;
                txtRouteTitle.Enabled = false;
                txtAmount.Enabled = false;
                txtRoute.Text = "";
                txtRouteTitle.Text = "";
                txtAmount.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Route Grid Bind
        #region[Route Grid Bind]

        private void GrdRouteBind()
        {
            try
            {
                objEWA.OrgId = orgId;
                DataSet ds = objBL.RouteGridBind_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdRoute.DataSource = ds;
                    GrdRoute.DataBind();
                    int columncount = GrdRoute.Rows[0].Cells.Count;
                    GrdRoute.Rows[0].Cells.Clear();
                    GrdRoute.Rows[0].Cells.Add(new TableCell());
                    GrdRoute.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdRoute.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdRoute.DataSource = ds;
                    GrdRoute.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Existing Data
        #region[Check Data]

        private int CheckDataR()
        {
            try
            {
                EWA_Transport objEWA = new EWA_Transport();
                objEWA.OrgId = orgId;
                objEWA.Route = txtRoute.Text.Trim();
                int i = objBL.CheckDuplicateRoute_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Perform Action for Route
        #region[Perform Action]

        private void ActionR(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.RouteId = Convert.ToInt32(ViewState["RouteId"].ToString());
                }
                objEWA.Route = txtRoute.Text.Trim();
                objEWA.RouteTitle = txtRouteTitle.Text.Trim();
                objEWA.Amount = Convert.ToDouble(txtAmount.Text.Trim());

                // Below Values Need to be pass from session
                objEWA.OrgId = orgId;
                // objEWA.AcademicYearId = "1";
                // objEWA.UserId = "1";
                objEWA.IsActive = "True";

                int flag = objBL.RouteAction_BL(objEWA);

                if (flag > 0)
                {
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
                    GrdRouteBind();
                }
                else if (flag == -1)
                {
                    string msg = "Data is  Already exist!!!";
                    if (strAction == "Save")
                    {
                        
                        msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);

                        //msgBox.ShowMessage(objEWA.RouteTitle + "is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);

                        //msgBox.ShowMessage(objEWA.RouteTitle + "is  Already exist!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else if (strAction == "Delete")
                    {
                        msg = "Record is in Used !!!";
                        msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);
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
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        //protected void GrdRoute_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        GrdRoute.PageIndex = e.NewPageIndex;
        //        DataSet ds = objBL.RouteGridBind_BL(objEWA);
        //        if (ds.Tables[0].Rows.Count == 0 || ds == null)
        //        {
        //            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //            GrdRoute.DataSource = ds;
        //            GrdRoute.DataBind();
        //            int columncount = GrdRoute.Rows[0].Cells.Count;
        //            GrdRoute.Rows[0].Cells.Clear();
        //            GrdRoute.Rows[0].Cells.Add(new TableCell());
        //            GrdRoute.Rows[0].Cells[0].ColumnSpan = columncount;
        //            GrdRoute.Rows[0].Cells[0].Text = "No Records Found";
        //        }
        //        else
        //        {
        //            GrdRoute.DataSource = ds;
        //            GrdRoute.DataBind();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}


        protected void GrdRoute_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdRoute.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                GrdRoute.DataSource = objBL.RouteGridBind_BL(objEWA);
                GrdRoute.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }



        #endregion
        //RouteLinkButtonClick
        #region RouteLinkButtonClick

        protected void lnkBtnRoute_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["RouteId"] = GrdRoute.DataKeys[grdrow.RowIndex].Values["RouteId"].ToString();
                    txtRoute.Text = GrdRoute.DataKeys[grdrow.RowIndex].Values["Route"].ToString();
                    txtRouteTitle.Text = GrdRoute.DataKeys[grdrow.RowIndex].Values["RouteTitle"].ToString();
                    txtAmount.Text = GrdRoute.DataKeys[grdrow.RowIndex].Values["Amount"].ToString();

                    callUpdateR();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
        #region[Call update]

        public void callUpdateR()
        {
            try
            {
                btnUpdateR.Visible = true;
                btnDeleteR.Visible = true;
                btnSaveR.Visible = false;
                btnNewR.Visible = false;
                btnCancelR.Visible = true;
                txtRoute.Enabled = true;
                txtRouteTitle.Enabled = true;
                txtAmount.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //AddNew
        #region AddNew

        protected void btnNewR_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSaveR.Visible = true; ;
                    btnUpdateR.Visible = false;
                    btnDeleteR.Visible = false;
                    btnNewR.Visible = false;
                    btnCancelR.Visible = true;
                    txtRoute.Enabled = true;
                    txtRouteTitle.Enabled = true;
                    txtAmount.Enabled = true;
                    txtRoute.Text = "";
                    txtRouteTitle.Text = "";
                    txtAmount.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Save Data
        #region SaveData

        protected void btnSaveR_Click(object sender, EventArgs e)
        {
            BL_Transport objBL = new BL_Transport();
            EWA_Transport objEWA = new EWA_Transport();
            try
            {
                lock (this)
                {
                    if (txtRoute.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Route Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        // ViewState["RouteId"] = 0;
                        int chk = CheckDataR();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            ActionR("Save");
                            GrdRouteBind();
                            LoadFormR();

                            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

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
        //UpdateData
        #region UpdateRoute

        protected void btnUpdateR_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    ActionR("Update");
                    GrdRouteBind();
                    LoadFormR();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Delete Route Data
        #region Delete

        protected void btnDeleteR_Click(object sender, EventArgs e)
        {
            try
            {
                float count = db.getDb_Value("select count(*) from tblBoard where RouteIdId='" + ViewState["RouteId"].ToString() + "'");

                if (count != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    string[] confirmValue = Request.Form["confirm_value"].Split(',');
                    if (confirmValue[confirmValue.Length - 1] == "Yes")
                    {
                        ActionR("Delete");
                        GrdRouteBind();
                        LoadFormR();
                    }
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

        protected void btnCancelR_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormR();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Route Index Changed
        #region[Rote Index Changed]

        protected void GrdRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For Board Tab

        //on form load
        #region[Form Load]

        private void LoadFormB()
        {
            try
            {
                btnNewB.Visible = true;
                btnCancelB.Visible = true;
                btnSaveB.Visible = false;
                btnUpdateB.Visible = false;
                btnDeleteB.Visible = false;
                ddlRoute.Enabled = false;
                txtBoardTitle.Enabled = false;
                txtBoardTitle.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Board Grid Bind

        #region[Board Grid Bind]

        private void ddlRouteBBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.ddlRouteBind_BL(objEWA);

                ddlRoute.DataSource = ds;
                ddlRoute.DataTextField = "Route";
                ddlRoute.DataValueField = "RouteId";
                ddlRoute.DataBind();

                ddlRoute.Items.Insert(0, "Select");
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Board Grid Bind
        #region[Board Grid Bind]

        private void GrdBoardBind()
        {
            try
            {
                EWA_Transport objEWA = new EWA_Transport();
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.BoardGridBind_BL(objEWA);

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdBoard.DataSource = ds;
                    GrdBoard.DataBind();
                    int columncount = GrdBoard.Rows[0].Cells.Count;
                    GrdBoard.Rows[0].Cells.Clear();
                    GrdBoard.Rows[0].Cells.Add(new TableCell());
                    GrdBoard.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdBoard.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdBoard.DataSource = ds;
                    GrdBoard.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Existing Data
        #region[Check Data]

        private int CheckDuplicateBoard_BL()
        {
            EWA_Transport objEWA = new EWA_Transport();
            objEWA.BoardTitle = txtBoardTitle.Text;
            int i = objBL.CheckDuplicateBoard_BL(objEWA);
            return i;
        }

        #endregion

        //Perform Action for Board
        #region[Perform Action]

        private void ActionB(string strAction)
        {
            try
            {
                objEWA.ActionB = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.BoardId = Convert.ToInt32(ViewState["BoardId"].ToString());
                }
                objEWA.RouteId = Convert.ToInt32(ddlRoute.SelectedValue);
                objEWA.BoardTitle = txtBoardTitle.Text.Trim();
                objEWA.IsActive = "True";
                objEWA.OrgId = orgId;
                int flag = objBL.BoardAction_BL(objEWA);

                if (flag > 0)
                {
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
                    GrdBoardBind();



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
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdBoard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdBoard.PageIndex = e.NewPageIndex;

                GrdBoard.DataSource = objBL.BoardGridBind_BL(objEWA);
                GrdBoard.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //BoardLinkButtonClick
        #region BoardLinkButtonClick

        protected void lnkBtnBoard_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["BoardId"] = GrdBoard.DataKeys[grdrow.RowIndex].Values["BoardId"].ToString();
                    var a = GrdBoard.DataKeys[grdrow.RowIndex].Values["RouteId"].ToString();
                    ddlRoute.SelectedValue = a;
                    txtBoardTitle.Text = GrdBoard.DataKeys[grdrow.RowIndex].Values["BoardTitle"].ToString();
                    callUpdateB();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
        #region[Call Update]

        public void callUpdateB()
        {
            try
            {
                btnUpdateB.Visible = true;
                btnDeleteB.Visible = true;
                btnSaveB.Visible = false;
                btnNewB.Visible = false;
                btnCancelB.Visible = true;
                ddlRoute.Enabled = true;
                txtBoardTitle.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //AddNew
        #region AddNew

        protected void btnNewB_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSaveB.Visible = true;
                    btnCancelB.Visible = true;
                    btnUpdateB.Visible = false;
                    btnDeleteB.Visible = false;
                    btnNewB.Visible = false;
                    ddlRoute.Enabled = true;
                    txtBoardTitle.Enabled = true;
                    txtBoardTitle.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Data
        #region SaveData

        protected void btnSaveB_Click(object sender, EventArgs e)
        {
            BL_Transport objBL = new BL_Transport();
            EWA_Transport objEWA = new EWA_Transport();
            try
            {
                lock (this)
                {
                    if (ddlRoute.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Route Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        // ViewState["RouteId"] = 0;

                        int chk = CheckDuplicateBoard_BL();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            ActionB("Save");
                            GrdBoardBind();
                            LoadFormB();

                        }
                        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //UpdateData
        #region UpdateRoute

        protected void btnUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                ActionB("Update");
                GrdBoardBind();
                LoadFormB();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Delete Board Data
        #region Delete

        protected void btnDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                float count = db.getDb_Value("select count(*) from tblVehicle where BoardId='" + ViewState["BoardId"].ToString() + "'");

                if (count != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    ActionB("Delete");
                    GrdBoardBind();
                    LoadFormB();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Clear Data
        #region CancelControls

        protected void btnCancelB_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormB();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Board Index Changed
        #region[Board Index Changed]

        protected void GrdBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //Route Index Changed
        #region[Route Index Changed]

        protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For VehicleTab

        //on form load
        #region[Veh Form Load]

        private void LoadFormV()
        {
            try
            {
                btnAddV.Visible = true;
                btnSaveV.Visible = false;
                btnUpdateV.Visible = false;
                btnDeleteV.Visible = false;
                btnCancelV.Visible = true;
                ddlBoard.Enabled = false;
                txtVehicleType.Enabled = false;
                txtVehicleNumber.Enabled = false;
                txtVehicleModel.Enabled = false;
                txtVehicleCapacity.Enabled = false;
                txtVehicleType.Text = "";
                txtVehicleNumber.Text = "";
                txtVehicleModel.Text = "";
                txtVehicleCapacity.Text = "";

                ddlBoard.ClearSelection();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Board Grid Bind
        #region[Board Grid Bind]

        private void ddlBoardBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.ddlBoardBind_BL(objEWA);
                ddlBoard.DataSource = ds;
                ddlBoard.DataTextField = "BoardTitle";
                ddlBoard.DataValueField = "BoardId";
                ddlBoard.DataBind();
                ddlBoard.Items.Insert(0, "Select");
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Vehicle Grid Bind
        #region[Vehicle Grid Bind]

        private void GrdVehicleBind()
        {
            try
            {

                EWA_Transport objEWA = new EWA_Transport();
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.VehicleGridBind_BL(objEWA);
                GrdVehicle.DataSource = ds;
                GrdVehicle.DataBind();
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Check Existing Data
        #region[Check Data]

        private int CheckDataV()
        {
            int i = 0;
            try
            {
                EWA_Transport objEWA = new EWA_Transport();
                objEWA.VehicleType = txtVehicleType.Text;
                i = objBL.CheckDuplicateVehicle_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion
        //AddNew
        #region AddNew

        protected void btnAddV_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSaveV.Visible = true;
                    btnCancelV.Visible = true;
                    btnUpdateV.Visible = false;
                    btnDeleteV.Visible = false;
                    btnAddV.Visible = false;
                    ddlBoard.Enabled = true;
                    txtVehicleType.Enabled = true;
                    txtVehicleNumber.Enabled = true;
                    txtVehicleModel.Enabled = true;
                    txtVehicleCapacity.Enabled = true;
                    txtVehicleType.Text = "";
                    txtVehicleNumber.Text = "";
                    txtVehicleModel.Text = "";
                    txtVehicleCapacity.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Save Data
        #region SaveData

        protected void btnSaveV_Click(object sender, EventArgs e)
        {
            BL_Transport objBL = new BL_Transport();
            EWA_Transport objEWA = new EWA_Transport();
            try
            {
                lock (this)
                {
                    if (txtVehicleType.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Vehicle Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        //ViewState["VehicleId"] = 0;
                        int chk = CheckDataV();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            ActionV("Save");
                            GrdVehicleBind();
                            LoadFormV();
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

        //UpdateData
        #region UpdateVehicle

        protected void btnUpdateV_Click(object sender, EventArgs e)
        {
            try
            {
                ActionV("Update");
                GrdVehicleBind();
                LoadFormV();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Delete Vehicle Data
        #region Delete

        protected void btnDeleteV_Click(object sender, EventArgs e)
        {
            try
            {
                float count = db.getDb_Value("select count(*) from tblAllotDriver where VehicleId='" + ViewState["VehicleId"].ToString() + "'");

                if (count != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    ActionV("Delete");
                    GrdVehicleBind();
                    LoadFormV();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Vehicle
        #region[Perform Action]

        private void ActionV(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.VehicleId = Convert.ToInt32(ViewState["VehicleId"].ToString());
                }
                objEWA.BoardId = ddlBoard.SelectedIndex;
                objEWA.VehicleType = txtVehicleType.Text.Trim();
                objEWA.VehicleNumber = txtVehicleNumber.Text.Trim();
                objEWA.VehicleModel = txtVehicleModel.Text.Trim();
                objEWA.VehicleCapacity = Convert.ToInt32(txtVehicleCapacity.Text.Trim());
                objEWA.OrgId = orgId;
                objEWA.IsActive = "True";

                int flag = objBL.VehicleAction_BL(objEWA);

                if (flag > 0)
                {
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
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Page Indext Created
        #region GrdIndexChanged

        protected void GrdVehicle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdVehicle.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                GrdVehicle.DataSource = objBL.VehicleGridBind_BL(objEWA);
                GrdVehicle.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //VehicleLinkButtonClick
        #region VehicleLinkButtonClick

        protected void lnkBtnVehicleType_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["VehicleId"] = GrdVehicle.DataKeys[grdrow.RowIndex].Values["VehicleId"].ToString();
                    //ddlBoard.SelectedValue = GrdVehicle.DataKeys[grdrow.RowIndex].Values["BoardId"].ToString();
                    txtVehicleType.Text = GrdVehicle.DataKeys[grdrow.RowIndex].Values["VehicleType"].ToString();
                    txtVehicleNumber.Text = GrdVehicle.DataKeys[grdrow.RowIndex].Values["VehicleNumber"].ToString();
                    txtVehicleModel.Text = GrdVehicle.DataKeys[grdrow.RowIndex].Values["VehicleModel"].ToString();
                    txtVehicleCapacity.Text = GrdVehicle.DataKeys[grdrow.RowIndex].Values["VehicleCapacity"].ToString();

                    callUpdateV();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
        #region[Call update]

        public void callUpdateV()
        {
            try
            {
                btnUpdateV.Visible = true;
                btnDeleteV.Visible = true;
                btnSaveV.Visible = false;
                btnAddV.Visible = false;
                btnCancelV.Visible = true;
                ddlBoard.Enabled = true;
                txtVehicleType.Enabled = true;
                txtVehicleNumber.Enabled = true;
                txtVehicleModel.Enabled = true;
                txtVehicleCapacity.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Button Cancel
        #region[Cancel Button]

        protected void btnCancelV_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormV();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //GrdVehicle_SelectedIndexChanged
        #region[Veh Index Changed]

        protected void GrdVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For DriverTab

        //on form load
        #region[Driver Form Load]

        private void LoadFormD()
        {
            try
            {
                btnNewD.Visible = true;
                btnSaveD.Visible = false;
                btnUpdateD.Visible = false;
                btnDeleteD.Visible = false;
                txtName.Enabled = false;
                txtAddress.Enabled = false;
                txtPhoneNo.Enabled = false;
                txtLicenseId.Enabled = false;
                txtLicenseType.Enabled = false;
                // txtUploadImage.Enabled = false;
                txtName.Text = "";
                txtAddress.Text = "";
                txtPhoneNo.Text = "";
                txtLicenseId.Text = "";
                txtLicenseType.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DriverInfo Grid Bind
        #region[DriverInfo Grid Bind]

        private void GrdDriverInfoBind()
        {
            try
            {
                EWA_Transport objEWA = new EWA_Transport();
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.DriverInfoGridBind_BL(objEWA);
                GrdDriverInfo.DataSource = ds;
                GrdDriverInfo.DataBind();
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
            try
            {
                EWA_Transport objEWA = new EWA_Transport();
                objEWA.LicenseId = txtLicenseId.Text;
                int i = objBL.CheckDuplicateDriverInfo_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //Save Data
        #region SaveData

        protected void btnSaveD_Click(object sender, EventArgs e)
        {
            BL_Transport objBL = new BL_Transport();
            EWA_Transport objEWA = new EWA_Transport();
            try
            {
                lock (this)
                {
                    if (txtName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter  Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        //ViewState["DriverId"] = 0;
                        int chk = CheckDataD();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            ActionD("Save");
                            GrdDriverInfoBind();
                            LoadFormD();
                            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

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

        //UpdateData
        #region UpdateDriverInfo

        protected void btnUpdateD_Click(object sender, EventArgs e)
        {
            try
            {
                ActionD("Update");
                GrdDriverInfoBind();
                LoadFormD();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DeleteData
        #region DeleteDriverInfo

        protected void btnDeleteD_Click(object sender, EventArgs e)
        {
            try
            {
                float count = db.getDb_Value("select count(*) from tblAllotDriver where DriverId='" + ViewState["DriverId"].ToString() + "'");

                if (count != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is in use !!!')", true);
                }
                else
                {
                    ActionD("Delete");
                    GrdDriverInfoBind();
                    LoadFormD();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for DriverInfo
        #region[Perform Action]

        private void ActionD(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.DriverId = Convert.ToInt32(ViewState["DriverId"].ToString());
                }
                objEWA.Name = txtName.Text.Trim();
                objEWA.Address = txtAddress.Text.Trim();
                objEWA.PhoneNo = txtPhoneNo.Text.Trim();
                objEWA.LicenseId = txtLicenseId.Text.Trim();
                objEWA.LicenseType = txtLicenseType.Text.Trim();
                objEWA.OrgId = orgId;

                objEWA.IsActive = "True";

                int flag = objBL.DriverInfoAction_BL(objEWA);

                if (flag > 0)
                {
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
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //AddNew
        #region AddNew

        protected void btnNewD_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSaveD.Visible = true; ;
                    btnUpdateD.Visible = false;
                    btnDeleteD.Visible = false;
                    btnNewD.Visible = false;
                    txtName.Enabled = true;
                    txtAddress.Enabled = true;
                    txtPhoneNo.Enabled = true;
                    txtLicenseId.Enabled = true;
                    txtLicenseType.Enabled = true;
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtPhoneNo.Text = "";
                    txtLicenseId.Text = "";
                    txtLicenseType.Text = "";
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

        protected void GrdVehicle_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdDriverInfo.PageIndex = e.NewPageIndex;
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                GrdDriverInfo.DataSource = objBL.DriverInfoGridBind_BL(objEWA);
                GrdDriverInfo.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DriverInfoLinkButtonClick
        #region DriverInfoLinkButtonClick

        protected void lnkBtnName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["DriverId"] = GrdDriverInfo.DataKeys[grdrow.RowIndex].Values["DriverId"].ToString();
                    txtName.Text = GrdDriverInfo.DataKeys[grdrow.RowIndex].Values["Name"].ToString();
                    txtAddress.Text = GrdDriverInfo.DataKeys[grdrow.RowIndex].Values["Address"].ToString();
                    txtPhoneNo.Text = GrdDriverInfo.DataKeys[grdrow.RowIndex].Values["PhoneNo"].ToString();
                    txtLicenseId.Text = GrdDriverInfo.DataKeys[grdrow.RowIndex].Values["LicenseId"].ToString();
                    txtLicenseType.Text = GrdDriverInfo.DataKeys[grdrow.RowIndex].Values["LicenseType"].ToString();

                    callUpdateD();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
        #region[Call Update]

        public void callUpdateD()
        {
            try
            {
                btnUpdateD.Visible = true;
                btnDeleteD.Visible = true;
                btnSaveD.Visible = false;
                btnNewD.Visible = false;
                btnCancelD.Visible = true;
                txtName.Enabled = true;
                txtAddress.Enabled = true;
                txtPhoneNo.Enabled = true;
                txtLicenseId.Enabled = true;
                txtLicenseType.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel Button
        #region[Cancel Button]

        protected void btnCancelD_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormD();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Driver Info
        #region[Driver Info]

        protected void GrdDriverInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For AllotDriverToBusTab
        #region[Driver Form Load]

        private void LoadFormAD()
        {
            try
            {
                btnNewAD.Visible = true;
                btnCancelAD.Visible = true;
                btnSaveAD.Visible = false;
                btnUpdateAD.Visible = false;
                btnDeleteAD.Visible = false;
                ddlDriver.Enabled = false;
                ddlVehicle.Enabled = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Driver Bind
        #region[Driver Bind]

        private void ddlDriverBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.ddlDriverBind_BL(objEWA);

                ddlDriver.DataSource = ds;
                ddlDriver.DataTextField = "Name";
                ddlDriver.DataValueField = "DriverId";
                ddlDriver.DataBind();

                ddlDriver.Items.Insert(0, "Select");
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Vehicle Bind
        #region[Vehicle Bind]

        private void ddlVehicleBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.ddlVehicleBind_BL(objEWA);

                ddlVehicle.DataSource = ds;
                ddlVehicle.DataTextField = "VehicleNumber";
                ddlVehicle.DataValueField = "VehicleId";
                ddlVehicle.DataBind();

                ddlVehicle.Items.Insert(0, "Select");
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //AddNew
        #region AddNew

        protected void btnNewAD_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSaveR.Visible = true; ;
                    btnUpdateR.Visible = false;
                    btnDeleteR.Visible = false;
                    btnNewR.Visible = false;
                    btnCancelR.Visible = true;
                    txtRoute.Enabled = true;
                    txtRouteTitle.Enabled = true;
                    txtAmount.Enabled = true;
                    txtRoute.Text = "";
                    txtRouteTitle.Text = "";
                    txtAmount.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Save Data
        #region SaveData

        protected void btnSaveAD_Click(object sender, EventArgs e)
        {
            BL_Transport objBL = new BL_Transport();
            EWA_Transport objEWA = new EWA_Transport();
            try
            {
                //lock (this)
                //{
                //    if (txtRoute.Text == "")
                //    {
                //        msgBox.ShowMessage("Please Enter Route Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                //    }

                //    else
                //    {
                ActionAD("Save");
                GrdAllotDriverBind();
                // LoadFormAD();
                // }
                //   }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Vehicle
        #region[Perform Action]

        private void ActionAD(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                //if (strAction == "Update" || strAction == "Delete")
                //{
                //    objEWA.AllotDriverId = Convert.ToInt32(ViewState["AllotDriverId"].ToString());
                //}

                objEWA.DriverId = Convert.ToInt32(ddlDriver.SelectedValue);
                objEWA.VehicleId = Convert.ToInt32(ddlVehicle.SelectedValue);
                objEWA.OrgId = orgId;
                objEWA.IsActive = "True";

                int flag = objBL.AllotDriverAction_BL(objEWA);

                if (flag > 0)
                {
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
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DriverInfo Grid Bind
        #region[AllotDriver Grid Bind]

        private void GrdAllotDriverBind()
        {
            try
            {
                EWA_Transport objEWA = new EWA_Transport();
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.AllotDriverGridBind_BL(objEWA);
                GrdAllotDriver.DataSource = ds;
                GrdAllotDriver.DataBind();

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
        }

        #endregion


        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//
        //For Allot Route Tab

        #region[Allote Route Form Load]

        private void LoadFormAR()
        {
            try
            {
                btnNewAR.Visible = true;
                btnCancelAR.Visible = true;
                btnSaveAR.Visible = false;
                btnUpdateAR.Visible = false;
                btnDeleteAR.Visible = false;
                ddlCourse.Enabled = false;
                ddlBranch.Enabled = false;
                ddlClass.Enabled = false;
                DDLAcademicYear.Enabled = false;
                ddlstudRoute.Enabled = false;
                grdAllotRoute.Visible = false;
                grdpanal.Visible = false;
                grdpanal1.Visible = false;
                RouteassignPanal.Visible = false;
                RouteassignPanal1.Visible = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind dllRoute
        #region[ddlstudRoute Bind]

        private void ddlstudRouteBind()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                DataSet ds = objBL.ddlRouteBind_BL(objEWA);

                ddlstudRoute.DataSource = ds;
                ddlstudRoute.DataTextField = "Route";
                ddlstudRoute.DataValueField = "RouteId";
                ddlstudRoute.DataBind();

                ddlstudRoute.Items.Insert(0, "Select");
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //AddNew
        #region AddNew

        protected void btnNewAR_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSaveAR.Visible = true; ;
                    btnUpdateAR.Visible = false;
                    btnDeleteAR.Visible = false;
                    btnNewAR.Visible = false;
                    btnCancelAR.Visible = true;
                    ddlCourse.Enabled = true;
                    ddlBranch.Enabled = true;
                    ddlClass.Enabled = true;
                    DDLAcademicYear.Enabled = true;
                    ddlstudRoute.Enabled = true;
                    grdAllotRoute.Visible = true;
                    grdAssignRout.Visible = true;

                    BindCourses();
                    ddlstudRouteBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Clear Data
        #region CancelControls

        protected void btnCancelAR_Click(object sender, EventArgs e)
        {
            calcel();
        }

        public void calcel()
        {
            try
            {
                ddlCourse.Items.Clear();
                ddlBranch.Items.Clear();
                ddlClass.Items.Clear();
                DDLAcademicYear.Items.Clear();
                ddlstudRoute.Items.Clear();
                LoadFormAR();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Courses
        #region Bind Courses

        private void BindCourses()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = orgId.ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "Select"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("Select", "Select"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("Select", "Select"));

                DDLAcademicYear.Items.Clear();
                DDLAcademicYear.Items.Insert(0, new ListItem("select", "select"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Branch
        #region Bind Branch
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

                ddlBranch.Items.Insert(0, new ListItem("Select", "Select"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception exp)
            {

                throw exp;
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

        #endregion

        //Added by Ashwini 30-sep-2020
        private void BindAcademicyear()
        {
            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.OrgId = Convert.ToString(orgId.ToString());
                DataSet ds = objBL.BindAcademicYear_BL(objEWA);
                DDLAcademicYear.DataSource = ds;
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
            DDLAcademicYear.Items.Insert(0, new ListItem("Select", "Select"));
        }
        //

        //ddlCourse SelectedIndexChanged
        #region[ddlCourse SelectedIndexChanged]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdpanal.Visible = false;
            grdpanal1.Visible = false;
            RouteassignPanal.Visible = false;
            RouteassignPanal1.Visible = false;
            btnDeleteAR.Visible = false;
            BindBranch();
        }

        #endregion

        //ddlBranch SelectedIndexChanged
        #region[ddlBranch SelectedIndexChanged]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdpanal.Visible = false;
            grdpanal1.Visible = false;
            RouteassignPanal.Visible = false;
            RouteassignPanal1.Visible = false;
            btnDeleteAR.Visible = false;
            BindClass();
            BindAcademicyear();
        }

        #endregion

        //ddlClass SelectedIndexChanged
        #region[ddlClass SelectedIndexChanged]
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdStudentBind();
        }

        #endregion

        //Student Grid Bind
        #region[Student Grid Bind]

        private void GrdStudentBind()
        {
            try
            {
                BL_Common objBL = new BL_Common(); 
                EWA_Common objEWA = new EWA_Common();
                objEWA.OrgId = Convert.ToString(orgId.ToString());
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                DataSet ds = objBL.BindStudentForRoute_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    btnSaveAR.Enabled = true;

                    grdpanal.Visible = true;
                    grdpanal1.Visible = true;
                    grdAllotRoute.DataSource = ds.Tables[0];
                    grdAllotRoute.DataBind();

                    RouteassignPanal.Visible = true;
                    RouteassignPanal1.Visible = true;
                    grdAssignRout.DataSource = ds.Tables[1];
                    grdAssignRout.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        NoData.Visible = false;
                        btnDeleteAR.Visible = true;
                        btnUpdateAR.Visible= true;
                    }
                    else
                    {
                        NoData.Visible = true;
                        btnDeleteAR.Visible = false;
                        btnUpdateAR.Visible = false;
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        NoData1.Visible = false;
                        btnSaveAR.Enabled = true;
                    }
                    else
                    {
                        NoData1.Visible = true;
                        btnSaveAR.Enabled = false;
                    }
                }
                else
                {
                    grdpanal.Visible = false;
                    grdpanal1.Visible = false;
                    RouteassignPanal.Visible = false;
                    RouteassignPanal1.Visible = false;
                    msgBox.ShowMessage("No Record Found !!!", "Information", UserControls.MessageBox.MessageStyle.Information);

                    btnSaveAR.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                // throw;
            }
        }

        #endregion

        //Save Data
        #region SaveData

        protected void btnSaveAR_Click(object sender, EventArgs e)
        {
            try
            {
                int count = grdAllotRoute.Rows.Count;
                string[] UserCode = new string[count];
                int i = 0;
                string status = "false";

                foreach (GridViewRow gvrow in grdAllotRoute.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");

                    if (chk != null && chk.Checked)
                    {
                        status = "true";

                        UserCode[i] = grdAllotRoute.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString();
                        i++;

                    }
                }

                if (status != "true")
                {
                    msgBox.ShowMessage("Please Select Atleast 1 Student ", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    objBL = new BL_Transport();
                    objEWA = new EWA_Transport();

                    objEWA.ActionV = "Save_AssignStudentRoute";
                    objEWA.RouteId = Convert.ToInt32(ddlstudRoute.SelectedValue);

                    // Added by Ashwini 30-sep-2020
                    objEWA.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
                    objEWA.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                    objEWA.BranchId = Convert.ToInt32(ddlBranch.SelectedValue);
                    objEWA.AcademicYear = Convert.ToInt32(DDLAcademicYear.SelectedValue);
                    //
                    string[] uCode = new string[i];

                    Array.Copy(UserCode, 0, uCode, 0, i);

                    objBL.AssignRouteAction_BL(objEWA, uCode);
                    
                    GrdStudentBind();

                    msgBox.ShowMessage("Route Assign Successfully !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
                }

            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        //Delete Data
        #region DeleteData

        protected void btnDeleteAR_Click(object sender, EventArgs e)
        {
            try
            {
                int count = grdAssignRout.Rows.Count;
                string[] UserCode = new string[count];
                int i = 0;
                string status = "false";

                foreach (GridViewRow gvrow in grdAssignRout.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");

                    if (chk != null && chk.Checked)
                    {
                        status = "true";

                        UserCode[i] = grdAssignRout.DataKeys[gvrow.RowIndex].Values["StudentRouteId"].ToString();
                        i++;

                    }
                }

                if (status != "true")
                {
                    msgBox.ShowMessage("Please Select Atleast 1 Student ", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    objBL = new BL_Transport();
                    objEWA = new EWA_Transport();

                    objEWA.ActionV = "Delete_AssignStudentRoute";
                    objEWA.RouteId = 0; // Convert.ToInt32(ddlstudRoute.SelectedValue);
                    string[] uCode = new string[i];

                    Array.Copy(UserCode, 0, uCode, 0, i);

                    objBL.AssignRouteAction_BL(objEWA, uCode);
                    
                    GrdStudentBind();

                    msgBox.ShowMessage("Delete Route Successfully !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);

                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        //Update Data
        #region UpdateData

        protected void btnUpdateAR_Click(object sender, EventArgs e)
        {
            try
            {
                int count = grdAssignRout.Rows.Count;
                string[] UserCode = new string[count];
                int i = 0;
                string status = "false";

                foreach (GridViewRow gvrow in grdAssignRout.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");

                    if (chk != null && chk.Checked)
                    {
                        status = "true";

                        UserCode[i] = grdAssignRout.DataKeys[gvrow.RowIndex].Values["StudentRouteId"].ToString();
                        i++;

                    }
                }

                if (status != "true")
                {
                    msgBox.ShowMessage("Please Select Atleast 1 Student ", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
                else
                {
                    objBL = new BL_Transport();
                    objEWA = new EWA_Transport();

                    objEWA.ActionV = "Update_AssignStudentRoute";
                    objEWA.RouteId = Convert.ToInt32(ddlstudRoute.SelectedValue);
                    string[] uCode = new string[i];

                    Array.Copy(UserCode, 0, uCode, 0, i);

                    objBL.AssignRouteAction_BL(objEWA, uCode);

                    GrdStudentBind();

                    msgBox.ShowMessage("Update Route Successfully !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        protected void DDLAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
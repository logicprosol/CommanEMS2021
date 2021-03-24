using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.SuperAdmin;
using DataAccessLayer;
using EntityWebApp.SuperAdmin;

//SportMaster
namespace CMS.Forms.SuperAdmin
{
    public partial class SportMaster : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_SportMaster objBL = new BL_SportMaster();
        private EWA_SportMaster objEWA = new EWA_SportMaster();

        private BindControl ObjHelper = new BindControl();
        public static int orgId;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string UserCode = Convert.ToString(Session["UserCode"]);
                //if (UserCode=="")
                //{
                //    Response.Redirect("~/CMSHome.aspx");
                //}

                if (!IsPostBack)
                {
                    //To Call Form Controlles Load

                    LoadSport();
                    GrdSportBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //on form load
        #region[Load Dept Tab]

        private void LoadSport()
        {
            try
            {
                btnNew.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                txtSportName.Enabled = false;
                rbtStatus.Enabled = false;
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
                txtSportName.Enabled = true;
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
                txtSportName.Enabled = true;
                rbtStatus.Enabled = true;
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
                        GrdSportBind();
                        LoadSport();
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
                            GrdSportBind();
                            LoadSport();
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
                    GrdSportBind();
                    LoadSport();
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
                txtSportName.Text = "";
                rbtStatus.ClearSelection();
                LoadSport();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Sport
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.SportId = Convert.ToInt32(ViewState["SportId"].ToString());
                }
                objEWA.SportName = txtSportName.Text.Trim();
                //Send these values from Session
                objEWA.UserId = Session["UserCode"].ToString();
                if (rbtStatus.Items[0].Selected)
                {
                    objEWA.IsActive = true;
                }
                else
                {
                    objEWA.IsActive = false;
                }
                int flag = objBL.SportAction_BL(objEWA);
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

                    txtSportName.Text = "";
                    rbtStatus.ClearSelection();
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
                EWA_SportMaster objEWA = new EWA_SportMaster();
                objEWA.SportName = txtSportName.Text.Trim();
                i = objBL.CheckDuplicateSport_BL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            return i;
        }

        #endregion
        //Sport Grid Bind
        #region[Sport Grid Bind]

        private void GrdSportBind()
        {
            try
            {
                DataSet ds = objBL.SportGridBind_BL();
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdSport.DataSource = ds;
                    GrdSport.DataBind();
                    int columncount = GrdSport.Rows[0].Cells.Count;
                    GrdSport.Rows[0].Cells.Clear();
                    GrdSport.Rows[0].Cells.Add(new TableCell());
                    GrdSport.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdSport.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdSport.DataSource = ds;
                    GrdSport.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //DepartmentLinkButtonClick
        #region SportLinkButtonClick

        protected void lnkBtnSportName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    rbtStatus.ClearSelection();
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["SportId"] = GrdSport.DataKeys[grdrow.RowIndex].Values["SportId"].ToString();
                    //txtDepartmentId.Text = GrdDepartment.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtSportName.Text = GrdSport.DataKeys[grdrow.RowIndex].Values["SportName"].ToString();
                    string isActive = GrdSport.DataKeys[grdrow.RowIndex].Values["IsActive"].ToString();
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

        protected void GrdSport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdSport.PageIndex = e.NewPageIndex;

                GrdSport.DataSource = objBL.SportGridBind_BL();
                GrdSport.DataBind();
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityWebApp.Inventory;
using BusinessAccessLayer.Inventory;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Inventory
{
    public partial class QualirtControl : System.Web.UI.Page
    {
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgID"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                LoadForm();
                GetPOCode();
                // EmptyItemGrid();
                BindSupplier();
            }
        }
        //On form load
        #region[On form load]

        private void LoadForm()
        {
            try
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                // btnPrint.Enabled = false;
                DisableControl();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        //Enable controls
        #region[Enable Controls]

        private void EnableControl()
        {
            try
            {
                txtQCDate.Enabled = true;
                txtPOCode.Enabled = true;
                ddlSupplier.Enabled = true;
               // txtAddress.Enabled = true;
                txtRemark.Enabled = true;
                GrdItems.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        //Disable Controls
        #region[Disable Controls]

        private void DisableControl()
        {
            try
            {
                ddlSupplier.Enabled = false;
                txtQCDate.Enabled = false;
                txtPOCode.Enabled = false;
               // txtAddress.Enabled = false;
                txtRemark.Enabled = false;
                GrdItems.Enabled = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());

            }
        }

        #endregion

        //PO code text changed
        #region[Po code text changed]

        protected void txtPOCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
                //throw
            }
        }

        #endregion

        //Web Service for get user id
        #region [Web Service for get user id]

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetPOCodes(string prefixText)
        {
            List<string> POCodes = new List<string>();
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                EWA_QualityControl objEWA = new EWA_QualityControl();
                BL_QualityControl objBL = new BL_QualityControl();
                objEWA.PreText = prefixText;
                objEWA.OrgId = orgId;

                ds = objBL.GetPOCode_BL(objEWA);

                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    POCodes.Add(dt.Rows[i][0].ToString());
                }
            }

            catch (Exception)
            {
                return null;
                //throw;
            }
            return POCodes;
        }

        #endregion



        //Get Data
        #region[Get Data]

        private void GetData()
        {
            try
            {
                EWA_QualityControl objEWA = new EWA_QualityControl();
                BL_QualityControl objBL = new BL_QualityControl();
                //Send it from Session
                objEWA.OrgId = orgId;
                objEWA.POCode = txtPOCode.Text.Trim();
                DataSet ds = objBL.BindPODetails_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPOCode.Text = ds.Tables[0].Rows[0]["POCode"].ToString();
                    //txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    ddlSupplier.SelectedValue = ds.Tables[0].Rows[0]["SupplierId"].ToString();
                    ViewState["POId"] = ds.Tables[0].Rows[0]["POId"].ToString();
                    ViewState["PODate"] = ds.Tables[0].Rows[0][1];
                    ViewState["GrdItem"] = ds.Tables[1];
                    GrdItems.DataSource = ds.Tables[1];
                    GrdItems.DataBind();
                }
                else
                {
                    ddlSupplier.SelectedIndex=0;
                    txtQCDate.Text = "";
                    txtPOCode.Text = "";
                    //txtAddress.Text = "";
                   
                    ViewState["POId"] = null;
                    ViewState["PODate"] = null;
                    ViewState["GrdItem"] = null;
                    GrdItems.DataSource = null;
                    GrdItems.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);

            }
        }

        #endregion

        private void GetPOCode()
        {
            try
            {
                EWA_QualityControl objEWA = new EWA_QualityControl();
                BL_QualityControl objBL = new BL_QualityControl();
                //Send it from Session
                objEWA.OrgId = orgId;
                DataSet POCodeds = objBL.GetQCCode_BL(objEWA);
                string POCode = POCodeds.Tables[0].Rows[0][0].ToString();
                // lblPOCode.Text = objEWA.OrgId + StaffId;
                ViewState["POCode"] = POCode;
                // txtPOCode.Text = ViewState["POCode"].ToString();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }



        private void BindSupplier()
        {
            try
            {
                EWA_QualityControl objEWA = new EWA_QualityControl();
                BL_QualityControl ObjBL = new BL_QualityControl();
                objEWA.OrgId = orgId;
                DataSet dsSupplier = ObjBL.BindSupplier_BL(objEWA);
                ddlSupplier.DataSource = dsSupplier;
                ddlSupplier.DataTextField = "SupplierName";
                ddlSupplier.DataValueField = "SupplierId";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }


        }

        //Empty Item Grid
        #region[Empty Item Grid]

        private void EmptyItemGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ItemId");

                dt.Columns.Add("ItemName");
                dt.Columns.Add("CategoryName");
                dt.Columns.Add("UnitName");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Rate");
                dt.Rows.Add();
                dt.Rows.Add();
                GrdItems.DataSource = dt;
                GrdItems.DataBind();

                // GrdSelectedItems.DataSource = dt;
                //GrdSelectedItems.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion
        //Add New
        #region AddNew

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    // btnSave.Visible = true; ;
                    //btnPrint.Visible = false;
                    // btnNew.Visible = false;
                    // EnableControl();

                    btnNew.Enabled = false;
                    btnSave.Enabled = true;
                    //btnPrint.Enabled = true;
                    EnableControl();

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Supplier Selected Index Changed
        #region[Supplier Dropdown Index changed]

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              //  BindItemGrid();
                GetData();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


      

        //Item Grid Bind
        #region[Item Category Grid Bind]

        private void BindItemGrid()
        {
            try
            {
                EWA_QualityControl objEWA = new EWA_QualityControl();
                BL_QualityControl objBL = new BL_QualityControl();
                objEWA.SupplierId = ddlSupplier.SelectedValue;
                objEWA.OrgId = orgId;
                DataSet ds = objBL.BindItemGrid_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdItems.DataSource = ds;
                    GrdItems.DataBind();
                    int columncount = GrdItems.Rows[0].Cells.Count;
                    GrdItems.Rows[0].Cells.Clear();
                    GrdItems.Rows[0].Cells.Add(new TableCell());
                    GrdItems.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdItems.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdItems.DataSource = ds;
                    GrdItems.DataBind();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                BL_Item objBL = new BL_Item();
                GrdItems.PageIndex = e.NewPageIndex;

                GrdItems.DataSource = objBL.BindItemGrid_BL();
                GrdItems.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //Calculate Amount
        #region[Calculate Amount]

        private void CalculateAmt()
        {
            try
            {
                double totAmt = 0;
                foreach (GridViewRow rw in GrdItems.Rows)
                {
                    totAmt = totAmt + (Convert.ToDouble(rw.Cells[4].Text) * Convert.ToDouble(rw.Cells[5].Text));
                }
                // lblTotalAmount.Text = totAmt.ToString("#,##00.00");
                //lGrandTot.Text = totAmt.ToString("#,##00.00");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion


        //Save Data
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EWA_QualityControl objEWA = new EWA_QualityControl();
            BL_QualityControl objBL = new BL_QualityControl();
            try
            {
                lock (this)
                {

                    //ViewState["DocumentId"] = 0;
                    int chk = 0;//= CheckData();
                    if (chk > 0)
                    {
                        msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        Action("Save");
                        //BindSupplierGrid();
                        LoadForm();
                    }
                }
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
                EWA_QualityControl objEWA = new EWA_QualityControl();
                BL_QualityControl objBL = new BL_QualityControl();
                try
                {
                    objEWA.Action = strAction;
                    if (strAction == "Update" || strAction == "Delete")
                    {
                        objEWA.QCId = Convert.ToInt32(ViewState["QCId"].ToString());
                    }
                    objEWA.POId = Convert.ToInt32(ViewState["POId"].ToString());
                    objEWA.QCDate = Convert.ToDateTime(txtQCDate.Text);
                    objEWA.POCode = txtPOCode.Text.Trim();
                    objEWA.SupplierId = ddlSupplier.SelectedValue;
                    objEWA.Remark = txtRemark.Text;
                    objEWA.OrgId = orgId;
                    objEWA.UserId = Session["UserCode"].ToString();
                    objEWA.IsActive = "True";
               
                    DataTable dt = new DataTable();
                    dt = GetItemDetail();
                    if (dt.Rows.Count <= 0)
                    {
                        msgBox.ShowMessage("Unable to Save, Item Not Available  !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        return;
                    }
                    int i = objBL.QCAction_BL(objEWA, dt);
                    if (i > 0)
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
                        //SelectData();
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
                            msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox .MessageStyle.Critical);
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

        //Get Item Details
        #region[Get Item Details]

        private DataTable GetItemDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("POId");
                dt.Columns.Add("ItemId");
                dt.Columns.Add("ActualQty");
                dt.Columns.Add("AcceptedQty");
                dt.Columns.Add("RejectedQty");

                foreach (GridViewRow grdItem in GrdItems.Rows)
                {
                    TextBox txtAcceptedQty = (TextBox)grdItem.FindControl("txtAcceptedQty");
                    TextBox txtRejectedQty = (TextBox)grdItem.FindControl("txtRejectedQty");
                    dt.Rows.Add(ViewState["POId"], GrdItems.DataKeys[grdItem.RowIndex].Value, GrdItems.Rows[grdItem.RowIndex].Cells[4].Text, txtAcceptedQty.Text, txtRejectedQty.Text);
                }
                return dt;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
                //throw
                return null;
            }
        }

        #endregion

        //Accepted Qty text changed
        #region[Accepted qty text changed]

        protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtAcceptedQty = (TextBox)sender;
                GridViewRow grdRow = txtAcceptedQty.NamingContainer as GridViewRow;
                TextBox txtRejectedQty = (TextBox)grdRow.FindControl("txtRejectedQty");
                if (Convert.ToDouble(GrdItems.Rows[grdRow.RowIndex].Cells[4].Text) >= Convert.ToDouble(txtAcceptedQty.Text))
                    txtRejectedQty.Text = Convert.ToString(Convert.ToDouble(GrdItems.Rows[grdRow.RowIndex].Cells[4].Text) - Convert.ToDouble(txtAcceptedQty.Text));
                else
                {
                    txtAcceptedQty.Text = txtRejectedQty.Text = ""; msgBox.ShowMessage("Accepted Qty is Greater than Pending Qty !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
                //throw
            }
        }

        #endregion

        //Rejected qty text changed
        #region[Rejected qty text changed]

        protected void txtRejectedQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtRejectedQty = (TextBox)sender;
                GridViewRow grdRow = txtRejectedQty.NamingContainer as GridViewRow;
                TextBox txtAcceptedQty = (TextBox)grdRow.FindControl("txtAcceptedQty");
                if (Convert.ToDouble(GrdItems.Rows[grdRow.RowIndex].Cells[4].Text) >= Convert.ToDouble(txtRejectedQty.Text))
                    txtAcceptedQty.Text = Convert.ToString(Convert.ToDouble(GrdItems.Rows[grdRow.RowIndex].Cells[4].Text) - Convert.ToDouble(txtRejectedQty.Text));
                else
                {
                    txtAcceptedQty.Text = txtRejectedQty.Text = ""; msgBox.ShowMessage("Rejected Qty is Greater than Pending Qty !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
                //throw
            }
        }

        #endregion



        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveCode("Print");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdQualityControl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //BL_Item objBL = new BL_Item();
                //GrdItems.PageIndex = e.NewPageIndex;

                //GrdItems.DataSource = objBL.BindItemGrid_BL();
                //GrdItems.DataBind();
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
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
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        database db = new database();
        public static int orgId=0;
        public float stock;
        public string itemname12;
        public float itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                txtPODate.Attributes.Add("ReadOnly", "True");
                LoadForm();
                GetPOCode();
                EmptyItemGrid();
                BindSupplier();
            }
            SqlCommand cmd1 = new SqlCommand("select Logo,OrgName from tblOrganization where OrganizationId='" + orgId.ToString() + "'", cn);
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataSet ds1 = new DataSet();
            adp1.SelectCommand = cmd1;
            adp1.Fill(ds1);
            lblTrustName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();

            string Photo = db.getDbstatus_Value("select Logo from tblOrganization");



            if (Photo != null && Photo != "")
            {
                Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Logo"];

                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                imgClgLogo.ImageUrl = "data:image/png;base64," + base64String;
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
                btnPrint.Enabled = false;
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
                ddlSupplier.Enabled = true;
                ddlDeliveryMode.Enabled = true;
                ddlPaymentMode.Enabled = true;
                txtPODate.Enabled = true;
                txtRemark.Enabled = true;
                GrdItem.Enabled = true;

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
                ddlDeliveryMode.Enabled = false;
                ddlPaymentMode.Enabled = false;
                txtPODate.Enabled = false;
                txtRemark.Enabled = false;
                GrdItem.Enabled = false;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());

            }
        }

        #endregion

        private void GetPOCode()
        {
            try
            {
                EWA_PurchaseOrder objEWA = new EWA_PurchaseOrder();
                BL_PurchaseOrder objBL = new BL_PurchaseOrder();
                //Send it from Session
                objEWA.OrgId = orgId;
                DataSet POCodeds = objBL.GetPOCode_BL(objEWA);
                string POCode = POCodeds.Tables[0].Rows[0][0].ToString();
                String POrdCode = "PO/" + orgId + "/" + POCode;
                // lblPOCode.Text = objEWA.OrgId + StaffId;
                ViewState["POCode"] = POrdCode;
                Session["POCode"] = POrdCode;
                txtPOCode.Text = ViewState["POCode"].ToString();

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
                EWA_PurchaseOrder objEWA = new EWA_PurchaseOrder();
                BL_PurchaseOrder ObjBL = new BL_PurchaseOrder();
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
                GrdItem.DataSource = dt;
                GrdItem.DataBind();

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

                    // btnNew.Enabled = false;
                    clear();
                    btnSave.Enabled = true;
                    btnPrint.Enabled = false;
                    EnableControl();
                    GetPOCode();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        public void clear()
        {
            txtPODate.Text = string.Empty;
            ddlSupplier.ClearSelection();
            GrdItem.DataSource = null;
            GrdItem.DataBind();
            ddlDeliveryMode.ClearSelection();
            ddlPaymentMode.ClearSelection();
            txtRemark.Text = string.Empty;
            btnSave.Enabled = false;
            ViewState["POItem"] = null;
        }
        #endregion

        //Supplier Selected Index Changed
        #region[Supplier Dropdown Index changed]

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindItemGrid();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        protected void gvCheckboxes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chkBxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkBxSelect");
                CheckBox chkBxHeader = (CheckBox)this.GrdItem.HeaderRow.FindControl("chkBxHeader");

                chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
            }
        }

        //Item Grid Bind
        #region[Item Category Grid Bind]

        private void BindItemGrid()
        {
            try
            {
                EWA_PurchaseOrder objEWA = new EWA_PurchaseOrder();
                BL_PurchaseOrder objBL = new BL_PurchaseOrder();
                objEWA.SupplierId = ddlSupplier.SelectedValue;
                objEWA.OrgId = orgId;
                DataSet ds = objBL.BindItemGrid_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdItem.DataSource = ds;
                    GrdItem.DataBind();
                    int columncount = GrdItem.Rows[0].Cells.Count;
                    GrdItem.Rows[0].Cells.Clear();
                    GrdItem.Rows[0].Cells.Add(new TableCell());
                    GrdItem.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdItem.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdItem.DataSource = ds;
                    GrdItem.DataBind();
                    ItemName1.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                    Category1.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                     Suppliername1.Text = ddlSupplier.SelectedItem.ToString();
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

        protected void GrdItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                BL_Item objBL = new BL_Item();
                GrdItem.PageIndex = e.NewPageIndex;

                GrdItem.DataSource = objBL.BindItemGrid_BL();
                GrdItem.DataBind();
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

                double GrandTot = 0;
                    foreach (GridViewRow row in GrdItem.Rows)
                    {
                        if (row != null)
                        {
                            TextBox txtQty = row.FindControl("txtQty") as TextBox;
                            TextBox txtRate = row.FindControl("txtRate") as TextBox;
                            Label lblTotalAmount = row.FindControl("lblTotalAmount") as Label;
                            CheckBox chkSelect = row.FindControl("chkBxSelect") as CheckBox;
                            double TotalAmt = 0.0;
                            if (chkSelect.Checked)
                            {
                                if ((!txtQty.Equals("") && txtQty != null) || (!txtRate.Equals("") && txtRate != null))
                                {
                                    double res;
                                    if ((double.TryParse(txtQty.Text, out res)) && (double.TryParse(txtRate.Text, out res)))
                                    {

                                        TotalAmt = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text));
                                    }
                                    else
                                    {
                                        msgBox.ShowMessage("Please enter numeric amount!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                        txtQty.Text = "";
                                        txtRate.Text = "";
                                    }
                                }
                                lblTotalAmount.Text = TotalAmt.ToString("###00.00");

                                GrandTot = GrandTot + TotalAmt;
                                var footlbl = GrdItem.FooterRow.FindControl("lblGrandTotal") as Label;
                                if (footlbl != null)
                                {
                                    footlbl.Text = GrandTot.ToString("###00.00");
                                    ViewState["GrandTotal"] = footlbl.Text;
                                }
                            }
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
        protected void txtQuantity_OnTextChanged(object sender, System.EventArgs e)
        {
            CalculateAmt();
        }
        protected void txtRate_OnTextChanged(object sender, System.EventArgs e)
        {
            CalculateAmt();
        }
        //Save Data
        #region SaveData

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EWA_PurchaseOrder objEWA = new EWA_PurchaseOrder();
            BL_PurchaseOrder objBL = new BL_PurchaseOrder();
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
                       // int count = GrdItem.Rows.Count;
                       // string[] Itemstock = new string[count];
                       // int i = 0;
                        
                       // foreach (GridViewRow gvrow in GrdItem.Rows)
                       // {
                       //     TextBox txtQty = new TextBox();
                       //     txtQty = gvrow.Cells[5].FindControl("txtQty") as TextBox;
                       //     CheckBox chk1 = (CheckBox)gvrow.FindControl("chkBxSelect");
                       //     if (chk1 != null && chk1.Checked)
                       //     {
                       //       Itemstock[i] = GrdItem.DataKeys[gvrow.RowIndex].Values["ItemName"].ToString();
                       //      // TextBox txtValueMain = GrdItem.Cells[1].FindControl("txtValue") as TextBox;

                       //         itemid = db.getDb_Value(" SELECT tblItem.ItemId FROM tblItem INNER JOIN tblItemSupplier ON tblItem.ItemId = tblItemSupplier.ItemId WHERE tblItem.OrgId = '" + orgId.ToString() + "' AND tblItem.ItemName = '" + Itemstock[i] + "' AND tblItemSupplier.SupplierId = '" + ddlSupplier.Text + "'");
                       //         //for stock maintain
                       //        itemname12 = db.getDbstatus_Value("SELECT tblItem.ItemName FROM tblItem INNER JOIN  tblItemSupplier ON tblItem.ItemId = tblItemSupplier.ItemId WHERE  (tblItem.OrgId = '" + orgId.ToString() + "') AND (tblItem.ItemName = '" + Itemstock[i] + "') AND (tblItemSupplier.SupplierId = '" + ddlSupplier.Text + "')");


                       //        stock = db.getDb_Value("select Stock from tblItem where OrgId='" + orgId.ToString() + "' and ItemName='" + itemname12 + "'");
                       //        float upstock = stock + Convert.ToInt32(txtQty.Text);
 
                       //         db.cnopen();
                       //         // db.insert("insert into tblItem (Stock,ItemName) values ('" + upstock + "','" + itemname12 + "' )");
                       //         db.insert("update tblItem set Stock='" + upstock + "' where OrgId='" + orgId.ToString() + "' and ItemName='" + Itemstock[i] + "'");
                       //         db.cnclose();
                 
                       //         i++;
                       //     }
                       //}
                     
                        //BindSupplierGrid();
                       // btnNew.Enabled = false;
                        btnSave.Enabled = false;
                        btnPrint.Enabled = true;
                        clear();
                        //GrdPurchaseOrder.DataSourceID = "SqlDataSource1";
                        GrdPurchaseOrder.DataBind();
                        GetPOCode();
                    }

                }
            }

            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }

        }

        #endregion

        //Perform Action
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                EWA_PurchaseOrder objEWA = new EWA_PurchaseOrder();
                BL_PurchaseOrder objBL = new BL_PurchaseOrder();
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.POId = Convert.ToInt32(ViewState["POId"].ToString());
                }
                objEWA.PODate =txtPODate.Text;
                objEWA.POCode = txtPOCode.Text.Trim();
                objEWA.SupplierId = ddlSupplier.SelectedValue;
                objEWA.GrandTotal = ViewState["GrandTotal"].ToString();
                objEWA.PaymentMode = ddlPaymentMode.SelectedItem.ToString();
                objEWA.DeliveryMode = ddlDeliveryMode.SelectedItem.ToString();
                objEWA.Remark = txtRemark.Text.Trim();

                objEWA.OrgId = orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                //int count = GrdItem.Rows.Count;
                //DataTable dt = new DataTable();
                //foreach (GridViewRow gvrow in GrdItem.Rows)
                //{
                //    CheckBox chk = (CheckBox)gvrow.FindControl("chkBxSelect");
                //    if (chk != null && chk.Checked)
                //    {

                //        if (ViewState["POItem"] == null)
                //        {

                //            dt.Columns.Add("ItemId");
                //            dt.Columns.Add("Quantity");
                //            dt.Columns.Add("Rate");
                //            DataRow rw = dt.NewRow();
                //            // rw["SupplierId"] = ddlPartyName.SelectedItem.Value.ToString();
                //            rw["ItemId"] = GrdItem.DataKeys[gvrow.RowIndex].Values["ItemId"].ToString();
                //            rw["Quantity"] = GrdItem.DataKeys[gvrow.RowIndex].Values["Quantity"].ToString();
                //            rw["Rate"] = GrdItem.DataKeys[gvrow.RowIndex].Values["Rate"].ToString();
                //            dt.Rows.Add(rw);
                //            ViewState["POItems"] = dt as DataTable;
                //        }
                //        else
                //        {
                //            int cnt = 0;
                //            dt = ViewState["POItems"] as DataTable;
                //            foreach (DataRow drow in dt.Rows)
                //            {
                //                if (!chk.Checked)
                //                {
                //                    cnt = 1;
                //                }
                //            }

                //            if (cnt == 0)
                //            {
                //                DataRow rw = dt.NewRow();
                //                rw["ItemId"] = GrdItem.DataKeys[gvrow.RowIndex].Values["ItemId"].ToString();
                //                rw["Quantity"] = GrdItem.DataKeys[gvrow.RowIndex].Values["Quantity"].ToString();
                //                rw["Rate"] = GrdItem.DataKeys[gvrow.RowIndex].Values["Rate"].ToString();
                //                dt.Rows.Add(rw);
                //                ViewState["POItem"] = dt as DataTable;
                //            }

                //        }

                //    }
               // }

           
                    DataTable dt = new DataTable();
                    int count = 0;

                    if (GrdItem.Rows[0].Cells[2].Text == "" || GrdItem.Rows[0].Cells[2].Text == "&nbsp;")
                    {
                        msgBox.ShowMessage("Please Select Supplier Items !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        return;
                    }

                    foreach (GridViewRow rw in GrdItem.Rows)
                    {
                        CheckBox chkItem = new CheckBox();
                        chkItem = rw.Cells[0].FindControl("chkBxSelect") as CheckBox;
                        if (chkItem.Checked)
                        {
                            TextBox txtQty = new TextBox();
                            TextBox txtRate = new TextBox();
                            Label lblTotalAmt=new Label();
                            txtQty = rw.Cells[5].FindControl("txtQty") as TextBox;
                            txtRate = rw.Cells[6].FindControl("txtRate") as TextBox;
                            lblTotalAmt=rw.Cells[7].FindControl("lblTotalAmount")as Label;
                            double chkout = 0;
                            if (txtQty.Text == "")
                            {
                                msgBox.ShowMessage("Please Enter Product Quantity !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                return;
                            }
                            else if (txtRate.Text == "")
                            {
                                msgBox.ShowMessage("Please Enter Product Rate !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                return;
                            }
                            else if (double.TryParse(txtQty.Text, out chkout) == false)
                            {
                                msgBox.ShowMessage("Please Enter Valid Quantity !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                return;
                            }
                            else if (double.TryParse(txtRate.Text, out chkout) == false)
                            {
                                msgBox.ShowMessage("Please Enter Valid Rate !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                return;
                            }

                            if (ViewState["POItem"] != null)
                            {
                                dt = ViewState["POItem"] as DataTable;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (rw.Cells[2].Text == dt.Rows[i][2].ToString())
                                    {
                                        msgBox.ShowMessage("This Item is Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                        return;
                                    }
                                }
                                dt.Rows.Add(0, GrdItem.DataKeys[rw.RowIndex].Value, txtQty.Text, txtRate.Text,lblTotalAmt.Text);
                               // dt.Rows.Add(0, GrdItem.DataKeys[rw.RowIndex].Value, rw.Cells[2].Text, rw.Cells[3].Text, rw.Cells[4].Text, txtQty.Text, txtRate.Text);
                            }
                            else
                            {
                                dt.Columns.Add("POId");
                                dt.Columns.Add("ItemId");
                                //dt.Columns.Add("ItemName");
                                //dt.Columns.Add("Category");
                               // dt.Columns.Add("Unit");
                                dt.Columns.Add("Qty");
                                dt.Columns.Add("Rate");
                                dt.Columns.Add("TotalAmt");
                                //dt.Rows.Add(0, GrdItem.DataKeys[rw.RowIndex].Value, rw.Cells[2].Text, rw.Cells[3].Text,rw.Cells[4].Text, txtQty.Text, txtRate.Text);
                                dt.Rows.Add(0, GrdItem.DataKeys[rw.RowIndex].Value, txtQty.Text, txtRate.Text,lblTotalAmt.Text);
                                ViewState["POItem"] = dt;



                                //ItemName1.Text = GrdItem.Rows[0].Cells[1].ToString();
                                //Category1.Text = GrdItem.Rows[0].Cells[2].ToString();
                            
                              
                                qty1.Text = txtQty.Text;
                                Rate1.Text = txtRate.Text;
                                Tamt1.Text = lblTotalAmt.Text;


                            }
                            count = count + 1;
                        }
                    }
                    if (count == 0)
                    {
                        msgBox.ShowMessage("Please Select Items !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        return;
                    }
                    else
                    {
                        //GrdSelectedItems.DataSource = dt;
                       // GrdSelectedItems.DataBind();
                        //if (ViewState["DSItems"] != null)
                        //{
                        //    DataSet dsItemsOrg = ViewState["DSItems"] as DataSet;
                        //    GrdItem.DataSource = dsItemsOrg;
                        //    GrdItem.DataBind();
                        //}
                        //CalculateAmt();
                        //Calculation();
                      //  GrdTax.Enabled = true;
                    }
               


                dt = ViewState["POItem"] as DataTable;

                DataSet ds = objBL.POAction_BL(objEWA, dt);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (strAction == "Save")
                    {
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();

                        Suppliername1.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                        ItemName1.Text = ds.Tables[0].Rows[0]["PODate"].ToString();
                        Tamt1.Text = ds.Tables[0].Rows[0]["GrandTotal"].ToString();
                        //lblPOCode.Text = ds.Tables[0].Rows[0]["POCode"].ToString();
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



        protected void btnPrint_Click(object sender, EventArgs e)
        {


            //try
            //{
            //    HttpContext.Current.Session.Remove("ds");
            //    //HttpContext.Current.Session.Add("ds", result);

            //    string url = "../../Forms/Reports/ReportViewer.aspx?ReportName=rptPurchaseQuotation";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //    //throw;
            //}
        }

        //Grid Index Changed
        #region GrdIndexChanged

        protected void GrdPurchaseOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //BL_Item objBL = new BL_Item();
                //GrdItem.PageIndex = e.NewPageIndex;

                //GrdItem.DataSource = objBL.BindItemGrid_BL();
                //GrdItem.DataBind();
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
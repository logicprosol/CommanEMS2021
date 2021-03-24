using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityWebApp.Inventory;
using System.Data;
using BusinessAccessLayer.Inventory;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Inventory
{
    public partial class AddItem : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
       
        private EWA_Item objEWA = new EWA_Item();
        private BL_Item objBL = new BL_Item();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        database db = new database();
        public static int orgId=0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                LoadForm();
                BindItemGrid();
                BindCategory();
                BindUnit();
            }
        }

        //Load Form
        #region[Load Form]

        private void LoadForm()
        {
            try
            {
                btnNew.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtItemName.Enabled = false;
                txtItemCode.Enabled = false;
                ddlCategory.Enabled = false;
                ddlUnit.Enabled = false;
                txtStock.Enabled = false;
                txtItemName.Text = "";
                txtItemName.Text = "";
                txtItemCode.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddlUnit.SelectedIndex = 0;
                txtStock.Text = "";
              

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
     

        private void BindCategory()
        {
            try
            {
                //EWA_Item objEWA = new EWA_Item();
                //BL_Item ObjBL = new BL_Item();
                ////objEWA.OrgId = orgId;
                //DataSet dsCategory = ObjBL.BindCategory_BL();
                //ddlCategory.DataSource = dsCategory;
                //ddlCategory.DataValueField = "CategoryId";
                //ddlCategory.DataTextField = "CategoryName";
                //ddlCategory.DataBind();
                //ddlCategory.Items.Insert(0, new ListItem("Select", "0"));

                if (ddlCategory.Items.Count <= 1)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT        CategoryId,CategoryName FROM            tblCategory   where OrgId='" + orgId.ToString() + "' "))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        ddlCategory.DataSource = cmd.ExecuteReader();
                        ddlCategory.DataValueField = "CategoryId";
                        ddlCategory.DataTextField = "CategoryName";                    
                        ddlCategory.DataBind();
                        cn.Close();
                    }

                    ddlCategory.Items.Insert(0, new ListItem("--Select Category--"));
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
      
        }
        private void BindUnit()
        {
            try
            {
                EWA_Item objEWA = new EWA_Item();
                BL_Item objBL = new BL_Item();
                //objEWA.OrgId = orgId;
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet dsUnit = objBL.BindUnit_BL(objEWA);
                ddlUnit.DataSource = dsUnit;
                ddlUnit.DataValueField = "UnitId";
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, "Select");


                //if (ddlCategory.Items.Count <= 1)
                //{
                //    using (SqlCommand cmd = new SqlCommand("     SELECT        UnitName, UnitId FROM            tblUnit   where OrgId='" + orgId.ToString() + "' "))
                //    {
                //        cmd.CommandType = CommandType.Text;
                //        cmd.Connection = cn;
                //        cn.Open();
                //        ddlCategory.DataSource = cmd.ExecuteReader();
                //        ddlCategory.DataValueField = "UnitId";
                //        ddlCategory.DataTextField = "UnitName";
                //        ddlCategory.DataBind();
                //        cn.Close();
                //    }

                //    ddlCategory.Items.Insert(0, new ListItem("--Select Unit--"));
                //}
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        //Get Item Code When Category Selected
        #region[Item Code On Category Change]

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtItemCode.Text = GetItemCode();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        protected void lnkCategory_Click(object sender, EventArgs e)
        {
            Session["MasterPopup"] = "CategoryMaster";
            PagePoup.ShowPage("../Inventory/AddCategory.aspx");

        }

        protected void lnkUnit_Click(object sender, EventArgs e)
        {
            Session["MasterPopup"] = "UnitMaster";
           // PagePoup.ShowPage("../Inventory/UnitMaster.aspx");
            PagePoup.ShowPage("../Inventory/AddUnit.aspx");
        }

        protected void btnHidden_Click(object sender, EventArgs e)
        {
            if (Session["MasterPopup"] != null)
            {
                if (Session["MasterPopup"].ToString() == "CategoryMaster")
                {
                    Session["MasterPopup"] = null;
                    BindCategory();
                }
                else if (Session["MasterPopup"].ToString() == "UnitMaster")
                {
                    Session["MasterPopup"] = null;
                    BindUnit();
                }
            }
        }

        //Item Grid Bind
        #region[Item Category Grid Bind]

        private void BindItemGrid()
        {
            try
            {
                //DataSet ds = objBL.BindItemGrid_BL();
                //if (ds.Tables[0].Rows.Count == 0 || ds == null)
                //{
                //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                //    GrdItem.DataSource = ds;
                //    GrdItem.DataBind();
                //    int columncount = GrdItem.Rows[0].Cells.Count;
                //    GrdItem.Rows[0].Cells.Clear();
                //    GrdItem.Rows[0].Cells.Add(new TableCell());
                //    GrdItem.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GrdItem.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{
                GrdItem.DataSource = db.Displaygrid("SELECT        tblItem.ItemId,tblItem.ItemName, tblItem.ItemCode, tblItem.CategoryId,tblCategory.CategoryName, tblItem.UnitId,tblUnit.UnitName, tblItem.Stock FROM            tblItem INNER JOIN  tblCategory ON tblItem.CategoryId = tblCategory.CategoryId INNER JOIN tblUnit ON tblItem.UnitId = tblUnit.UnitId  WHERE        tblItem.OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' "); 
                    GrdItem.DataBind();
                //}
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Data
        #region[Check Data]

        private int CheckData()
        {
            int i = 0;
            try
            {
                EWA_Item objEWA = new EWA_Item();
                BL_Item objBL = new BL_Item();
                objEWA.ItemName = txtItemName.Text.Trim();
                i = objBL.CheckDuplicateItem_BL(objEWA);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
          
            try
            {
                lock (this)
                {
                    if (txtItemName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Category Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        //ViewState["DocumentId"] = 0;
                        int chk = CheckData();
                        if (chk > 0)
                        {
                            msgBox.ShowMessage("Record Allready Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                        else
                        {
                            Action("Save");
                            BindItemGrid();
                            LoadForm();
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

        //Add New
        #region AddNew

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    btnSave.Enabled = true; ;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btnCancel.Enabled = true;
                    txtItemName.Enabled = true;
                    txtItemCode.Enabled = false;
                    ddlCategory.Enabled = true;
                    ddlUnit.Enabled = true;
                    txtStock.Enabled = true;
                    txtItemName.Text = "";
                    txtItemCode.Text = "";
                    ddlCategory.SelectedIndex =0;
                    ddlUnit.SelectedIndex =0;
                    txtStock.Text = "";

                    txtItemCode.Text = GetItemCode();

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

         //Get Generated Item Code
        #region[Get Item Code]

        private string GetItemCode()
        {
            try
            {
                EWA_Item objEWA = new EWA_Item();
                BL_Item objBL = new BL_Item();

                float CategoryId = db.getDb_Value("SELECT CategoryId FROM  tblCategory where OrgId='" + orgId.ToString() + "' ");



                objEWA.CategoryId = CategoryId.ToString();
                DataSet dsData = objBL.GetItemCode_BL(objEWA);
                string ItemCode = string.Empty;
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    ItemCode = dsData.Tables[0].Rows[0][0].ToString();
                }
                return ItemCode;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return "";
            }
        }
        #endregion
        //Cancel
        #region BtnCancelRegion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadForm();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
               
            }
        }

        #endregion

        //Clear Controls
        #region ClearControls

        private void ClearControls()
        {
            try
            {
                txtItemName.Text = "";

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

        //Item Category Link
        #region ItemItemLinkButtonClick

        protected void lnkBtnItemName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["ItemId"] = GrdItem.DataKeys[grdrow.RowIndex].Value.ToString();
                    //txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    txtItemName.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["ItemName"].ToString();
                    txtItemCode.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["ItemCode"].ToString();
                    ddlCategory.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["CategoryId"].ToString();
                    ddlUnit.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["UnitId"].ToString();
                    txtStock.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["Stock"].ToString();
                    callUpdate();
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

        public void callUpdate()
        {
            try
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnNew.Enabled = false;
                btnCancel.Enabled = true;
                txtItemName.Enabled = true;
                txtItemCode.Enabled = false;
                ddlCategory.Enabled = true;
                ddlUnit.Enabled = true;
                txtStock.Enabled = true;

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //UpdateData
        #region UpdateDocument

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                    BindItemGrid();
                    LoadForm();
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
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.ItemId = Convert.ToInt32(ViewState["ItemId"].ToString());
                }
                objEWA.ItemName = txtItemName.Text.Trim();
                objEWA.ItemCode = txtItemCode.Text.Trim();
                objEWA.CategoryId = ddlCategory.SelectedValue;
                objEWA.UnitId = ddlUnit.SelectedValue;
                objEWA.Stock = txtStock.Text.Trim();

                objEWA.OrgId = orgId;
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = "True";

                int flag = objBL.ItemAction_BL(objEWA);

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

        //Delete Item Category
        #region DeleteItemCategory

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                    BindItemGrid();
                    LoadForm();
                }
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
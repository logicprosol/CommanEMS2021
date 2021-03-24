using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Inventory
{
    public partial class Inventory_Home : System.Web.UI.Page
    {
        public static int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('inventor page load')", true);
}

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", msg, true);

        }

        #endregion

        //Page Links
        #region[Page Links]

        //Category
        protected void lbtnCategoryMaster_Click(object sender, EventArgs e)
        {
            try
            {
               Server.Transfer("AddCategory.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        //Unit
        protected void lbtnUnitMaster_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("AddUnit.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        //Items
        protected void lbtnItem_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("AddItem.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Supplier
      
        protected void lbtnSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("Supplier.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

       

        //Purchase Order
        protected void lbtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("PurchaseOrder.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Quality Control
        protected void lbtnQualityControl_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("QualityControl.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Stock Management
        protected void lbtnStockMgmt_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("StockView.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Settings
        protected void lbtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("ChangePassword.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

      
       

      

       
    }
}
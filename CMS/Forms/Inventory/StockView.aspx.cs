using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityWebApp.Inventory;
using BusinessAccessLayer.Inventory;

namespace CMS.Forms.Inventory
{
    public partial class StockView : System.Web.UI.Page
    {
        //Objects
        #region[Objects]

        private EWA_StockView objEWA = new EWA_StockView();
        private BL_StockView objBL = new BL_StockView();
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

            GrdStock.DataSource = db.Displaygrid("SELECT      tblItem.ItemCode,   tblItem.ItemName,tblCategory.CategoryName, tblItem.Stock,    tblUnit.UnitName as Unit FROM            tblItem INNER JOIN tblCategory ON tblItem.CategoryId = tblCategory.CategoryId INNER JOIN tblUnit ON tblItem.UnitId = tblUnit.UnitId WHERE        (tblItem.OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "')");
            GrdStock.DataBind();/*tblItem.UserId,*/
                //BindItemGrid();
            
        }

        //Item Grid Bind
        #region[Item Category Grid Bind]

        private void BindItemGrid()
        {
            try
            {
                DataSet ds = objBL.BindItemGrid_BL();
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdStock.DataSource = ds;
                    GrdStock.DataBind();
                    int columncount = GrdStock.Rows[0].Cells.Count;
                    GrdStock.Rows[0].Cells.Clear();
                    GrdStock.Rows[0].Cells.Add(new TableCell());
                    GrdStock.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdStock.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdStock.DataSource = ds;
                    GrdStock.DataBind();
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

        protected void GrdStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdStock.PageIndex = e.NewPageIndex;

                //GrdStock.DataSource = objBL.BindItemGrid_BL();
                GrdStock.DataBind();
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
                    //LinkButton lnkBtnId = (LinkButton)sender;
                    //GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    //ViewState["ItemId"] = GrdItem.DataKeys[grdrow.RowIndex].Value.ToString();
                    ////txtDocumentId.Text = GrdDocument.DataKeys[grdrow.RowIndex].Values["DocumentId"].ToString();
                    //txtItemName.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["ItemName"].ToString();
                    //txtItemCode.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["ItemCode"].ToString();
                    //ddlCategory.SelectedValue = GrdItem.DataKeys[grdrow.RowIndex].Values["CategoryId"].ToString();
                    //ddlUnit.SelectedValue = GrdItem.DataKeys[grdrow.RowIndex].Values["UnitId"].ToString();
                    //txtStock.Text = GrdItem.DataKeys[grdrow.RowIndex].Values["Stock"].ToString();
                    //callUpdate();
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

        protected void GrdStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (GrdStock.Rows.Count > 0)
            //{
            //    for (int i = 0; i < GrdStock.Rows.Count; i++)
            //    {
            //        GrdStock.Rows[i].Cells[2].Text = Decimal.Round(Decimal.Parse(GrdStock.Rows[i].Cells[2].Text), MidpointRounding.AwayFromZero).ToString();
            //               //Math.Round(GrdStock.Rows[i].Cells[2].Text);
            //    }
            //}
        }

    }
}
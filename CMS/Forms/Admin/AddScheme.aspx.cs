using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

//Add Scheme
namespace CMS.Forms.Admin
{
    public partial class AddScheme : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private string SchemeId;
        private EWA_Scheme ObjEWA;
        private BL_Scheme ObjBL;
        private DataSet ds = new DataSet();
        private DataView dvScheme = null;
        private decimal TotalAmount = 0;

        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    GetScheme();

                    lblresult.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Get Scheme
        #region[Get Scheme]

        public void GetScheme()
        {
            try
            {
                ObjEWA = new EWA_Scheme();
                ObjBL = new BL_Scheme();

                ObjEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());
                ObjEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);

                ds = ObjBL.GetScheme_BL(ObjEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dvScheme = new DataView(ds.Tables[0]);
                    ViewState["dvScheme"] = ds;

                    ddlScheme.DataTextField = "SchemeName";
                    ddlScheme.DataValueField = "SchemeId";
                    ddlScheme.DataSource = ds.Tables[0];
                    ddlScheme.DataBind();
                    ddlScheme.Items.Insert(0, "Select");
                    //BindGrantedAmount();
                    //BindGridView();
                }
                else
                {
                    //No data
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Bind Granted Amount
        #region[Bind Granted Amount]

        public void BindGrantedAmount()
        {
            try
            {
                //dvScheme = (DataView)ViewState["dvScheme"];
                DataSet ds = new DataSet();
                ds = ViewState["dvScheme"] as DataSet;
                dvScheme = new DataView(ds.Tables[0]);
                dvScheme.RowFilter = "SchemeName= '" + ddlScheme.SelectedItem.Text + "'";

                txtGrantedAmount.Text = dvScheme[0]["GrantedAmt"].ToString();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Bind Grid View
        #region[Bind Grid View]

        private void BindGridView()
        {
            try
            {
                EWA_Scheme ObjEWA = new EWA_Scheme();
                BL_Scheme ObjBL = new BL_Scheme();
                DataSet ds = new DataSet();
                SchemeId = ddlScheme.SelectedItem.Value;

                if (!SchemeId.Equals("Select"))
                {
                    ObjEWA.SchemeId = Convert.ToInt32(ddlScheme.SelectedItem.Value);

                    ObjEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);
                    ObjEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());

                    ds = ObjBL.BindScheme_BL(ObjEWA);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        GrdScheme.DataSource = ds.Tables[0];
                        GrdScheme.DataBind();
                    }
                    else
                    {
                        BindEmptyDataTable(ds);
                    }
                }
                else
                {
                    BindEmptyDataTable(ds);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Empty Data Table Overloded
        #region[Bind Empty Data Table Overloded]

        public void BindEmptyDataTable(DataSet ds)
        {
            try
            {
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdScheme.DataSource = ds;
                    GrdScheme.DataBind();
                    int columncount = GrdScheme.Rows[0].Cells.Count;
                    GrdScheme.Rows[0].Cells.Clear();
                    GrdScheme.Rows[0].Cells.Add(new TableCell());
                    GrdScheme.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdScheme.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdScheme.DataSource = ds;
                    GrdScheme.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Empty Data Table
        #region[Bind Empty Data Table]

        //public void BindEmptyDataTable(DataSet ds)
        //{
        //    try
        //    {
        //        if (ds.Tables[0].Rows.Count == 0 || ds == null)
        //        {
        //            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //            GrdScheme.DataSource = ds;
        //            GrdScheme.DataBind();
        //            int columncount = GrdScheme.Rows[0].Cells.Count;
        //            GrdScheme.Rows[0].Cells.Clear();
        //            GrdScheme.Rows[0].Cells.Add(new TableCell());
        //            GrdScheme.Rows[0].Cells[0].ColumnSpan = columncount;
        //            GrdScheme.Rows[0].Cells[0].Text = "No Records Found";
        //        }
        //        else
        //        {
        //            GrdScheme.DataSource = ds;
        //            GrdScheme.DataBind();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Scheme Index Changed
        #region[Scheme Index Changed]

        protected void ddlScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlScheme.SelectedItem.Text != "Select")
                {
                    BindGrantedAmount();
                    BindGridView();
                }
                else
                {
                    txtGrantedAmount.Text = "";
                    BindEmptyDataTable(ds);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Editing
        #region[Grid Feee Row Edit]

        protected void GrdScheme_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                lblresult.Text = "";
                if (!ddlScheme.SelectedItem.Text.Equals("Select"))
                {
                    GrdScheme.EditIndex = e.NewEditIndex;
                    SchemeId = ddlScheme.SelectedItem.Value;
                    Label lblFundName = (Label)GrdScheme.Rows[e.NewEditIndex].FindControl("lblFundName");
                    Label lblDistributedAmount = (Label)GrdScheme.Rows[e.NewEditIndex].FindControl("lblDistributedAmount");
                    ViewState["OldFundName"] = lblFundName.Text;
                    ViewState["OldDistributedAmount"] = lblDistributedAmount.Text;
                    BindGridView();
                }
                else
                    GrdScheme.EditIndex = -1;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Command
        #region[Grid Fee Row Command]

        protected void GrdScheme_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                EWA_Scheme ObjEWA = new EWA_Scheme();
                BL_Scheme ObjBL = new BL_Scheme();
                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox txtFundName = (TextBox)GrdScheme.FooterRow.FindControl("txtFooterFundName");
                    TextBox txtDistributedAmount = (TextBox)GrdScheme.FooterRow.FindControl("txtFooterDistributedAmount");

                    if ((Convert.ToDouble(ViewState["TotalAmount"].ToString()) + Convert.ToDouble(txtDistributedAmount.Text)) <= Convert.ToDouble(txtGrantedAmount.Text))
                    {
                        ObjEWA.SchemeId = Convert.ToInt32(ddlScheme.SelectedItem.Value);
                        ObjEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);
                        ObjEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());

                        ObjEWA.UserId = Session["UserCode"].ToString();

                        ObjEWA.FundName = txtFundName.Text;
                        // string str = txtDistributedAmount.Text;
                        ObjEWA.DistributedAmount = Convert.ToDouble(txtDistributedAmount.Text);

                        ObjEWA.Action = "Save";
                        ObjBL.InsertScheme_BL(ObjEWA);
                        BindGridView();
                        lblresult.ForeColor = Color.Green;
                        lblresult.Text = ObjEWA.FundName + " Details inserted successfully";
                    }
                    else
                    {
                        lblresult.ForeColor = Color.Red;
                        lblresult.Text = "Distributed amount should be less than granted amount.";
                    }

                    ////msgBox.ShowMessage("Particular added successfully !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Updating
        #region[Grid Fee Row Updating]

        protected void GrdScheme_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                EWA_Scheme ObjEWA = new EWA_Scheme();
                BL_Scheme ObjBL = new BL_Scheme();
                ObjEWA.Action = "Update";
                ObjEWA.SchemeId = Convert.ToInt32(ddlScheme.SelectedItem.Value);
                TextBox txtFundName = (TextBox)GrdScheme.Rows[e.RowIndex].FindControl("txtFundName");
                TextBox txtDistributedAmount = (TextBox)GrdScheme.Rows[e.RowIndex].FindControl("txtDistributedAmount");
                Label lblSchemeDetailsId = (Label)GrdScheme.Rows[e.RowIndex].FindControl("lblSchemeDetailsId");

                if ((Convert.ToDouble(ViewState["TotalAmount"].ToString()) + Convert.ToDouble(txtDistributedAmount.Text) - Convert.ToDouble(ViewState["OldDistributedAmount"].ToString())) <= Convert.ToDouble(txtGrantedAmount.Text))
                {
                    ObjEWA.SchemeDetailsId = Convert.ToInt32(lblSchemeDetailsId.Text);
                    ObjEWA.FundName = txtFundName.Text;
                    ObjEWA.DistributedAmount = Convert.ToDouble(txtDistributedAmount.Text);
                    ObjEWA.UserId = Session["UserCode"].ToString();

                    ObjBL.UpdateScheme_BL(ObjEWA);

                    GrdScheme.EditIndex = -1;
                    BindGridView();

                    lblresult.ForeColor = Color.Green;
                    lblresult.Text = ObjEWA.FundName + " Details Updated successfully";
                }
                else
                {
                    lblresult.ForeColor = Color.Red;
                    lblresult.Text = "Distributed amount should be less than granted amount.";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee row deleting
        #region[Grid Fee Row Deleting]

        protected void GrdScheme_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    EWA_Scheme ObjEWA = new EWA_Scheme();
                    BL_Scheme ObjBL = new BL_Scheme();
                    ObjEWA.Action = "Delete";
                    ObjEWA.SchemeId = Convert.ToInt32(ddlScheme.SelectedItem.Value);
                    Label lblSchemeDetailsId = (Label)GrdScheme.Rows[e.RowIndex].FindControl("lblSchemeDetailsId");

                    ObjEWA.SchemeDetailsId = Convert.ToInt32(lblSchemeDetailsId.Text);

                    ObjBL.DeleteScheme_BL(ObjEWA);
                    BindGridView();
                    lblresult.ForeColor = Color.Green;
                    lblresult.Text = ObjEWA.FundName + " Details Deleted successfully";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Clear Controls
        #region[Clear Controls]

        public void ClearControls()
        {
            try
            {
                ddlScheme.ClearSelection();
                txtGrantedAmount.Text = "";
                //BindEmptyDataTable();
                lblresult.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Canceling Edit
        #region[Grid Row Canceling Edit]

        protected void GrdScheme_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GrdScheme.EditIndex = -1;
                BindGridView();
                lblresult.Text = "";
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

        protected void GrdScheme_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal TotalExps = (decimal)DataBinder.Eval(e.Row.DataItem, "DistributedAmount");
                TotalAmount += TotalExps;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSummary = (Label)e.Row.FindControl("lblSummary");
                lblSummary.Text = String.Format("{0}", TotalAmount);
                ViewState["TotalAmount"] = TotalAmount;
            }
        }
    }
}
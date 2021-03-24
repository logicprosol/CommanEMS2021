using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Data;

namespace CMS.Forms.Admin
{
    public partial class SchemeMaster : System.Web.UI.Page
    {
public static int orgId;
        BL_Scheme objBL = new BL_Scheme();
        EWA_Scheme objEWA = new EWA_Scheme();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            if (!IsPostBack)
            {
                GrdSchemeBind();
                LoadForm();
            }

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; ;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtSchemeName.Enabled = true;
                txtGrantedAmt.Enabled = true;

                txtSchemeName.Text = "";
                txtGrantedAmt.Text = "";

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                lock (this)
                {
                    if (txtSchemeName.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter Scheme Name !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }

                    else
                    {
                        Action("SaveScheme");
                    }
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Perform Action for Subject
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "UpdateScheme" || strAction == "DeleteScheme")
                {
                    objEWA.SchemeId = Convert.ToInt32(ViewState["SchemeId"].ToString());
                }

                objEWA.SchemeName = txtSchemeName.Text;
                objEWA.SchemeAmount = Convert.ToDouble(txtGrantedAmt.Text);
                //Below Values Need to be pass from session

                objEWA.OrganizationId = Convert.ToInt32(Session["OrgId"]);
                objEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);
                objEWA.UserId = Session["UserCode"].ToString();
                objEWA.IsActive = true;

                int flag = objBL.SchemeAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "SaveScheme")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "UpdateScheme")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "DeleteScheme")
                    {
                        msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }

                    GrdSchemeBind();

                    LoadForm();
                }
                else
                {
                    if (strAction == "SaveScheme")
                    {
                        msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "UpdateScheme")
                    {
                        msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "DeleteScheme")
                    {
                        msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }
            }
            catch (Exception exp)
            {
                msgBox.ShowMessage("Enter Only Number in Granted Amount !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                 
            }
        }

        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                txtSchemeName.Enabled = false;
                txtGrantedAmt.Enabled = false;
                txtSchemeName.Text = "";
                txtGrantedAmt.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }



        #endregion

        //Subjects Grid Bind
        #region[Subject Grid Bind]

        private void GrdSchemeBind( )
        {
            try
            {
                EWA_Scheme objEWA = new EWA_Scheme();
                objEWA.OrganizationId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = objBL.SchemeGridBind_BL(objEWA);
                GrdScheme.DataSource = ds;
                GrdScheme.DataBind();
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("UpdateScheme");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }


        }

        protected void lnkBtnSchemeName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    //  ViewState["SubjectId"] = GrdScheme.DataKeys[grdrow.RowIndex].Values["SId"].ToString();
                    int SchemeId = Convert.ToInt32(GrdScheme.DataKeys[grdrow.RowIndex].Values["SchemeId"].ToString());
                    txtSchemeName.Text = GrdScheme.DataKeys[grdrow.RowIndex].Values["SchemeName"].ToString();
                    txtGrantedAmt.Text = GrdScheme.DataKeys[grdrow.RowIndex].Values["GrantedAmt"].ToString();

                    ViewState["SchemeId"] = SchemeId;

                    txtGrantedAmt.Enabled = true;
                    txtSchemeName.Enabled = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;




                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }


        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("DeleteScheme");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

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


                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grid.DataSource = dt;
                grid.DataBind();
                //grid.Columns[3].Visible = false;
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


    }
}
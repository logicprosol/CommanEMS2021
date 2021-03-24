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

namespace CMS.Forms.Admin
{
    public partial class AddHoliday : System.Web.UI.Page
    {


        //Objects
        #region[Objects]

        BL_Holiday objBL = new BL_Holiday();
        private BindControl ObjHelper = new BindControl();
        public static int orgId;

        DataSet ds = new DataSet();
        database db = new database();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgID"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    txtHolidayDate.Attributes.Add("Readonly","True");
                    LoadForm();
                    GrdHolidayBind();
                }
            }
        }

        //Load Form
        #region[Form Load]

        private void LoadForm()
        {
            try
            {
                btnNew.Visible = true;
                btnCancel.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtHolidayName.Enabled = false;
                txtHolidayDate.Enabled = false;
                txtHolidayName.Text = "";
                txtHolidayDate.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Call Update
        #region[Call Update]

        public void CallUpdate()
        {
            try
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnCancel.Visible = true;
                txtHolidayName.Enabled = true;
                txtHolidayDate.Enabled = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //New Button
        #region[NEw Button]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true; 
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                txtHolidayName.Enabled = true;
                txtHolidayDate.Enabled = true;
                txtHolidayName.Text = "";
                txtHolidayDate.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Cancel Button
        #region[Cancel Button]

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

        //Save Data
        #region[Save Data]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                   Action("Save");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Data
        #region[Update Holiday]

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Delete Holiday
        #region DeleteHoliday

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Delete");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for Holiday
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                EWA_Holiday objEWA = new EWA_Holiday();

                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete")
                {
                    objEWA.HolidayId = ViewState["HolidayId"].ToString();
                }
                objEWA.HolidayName = txtHolidayName.Text.Trim();
                objEWA.HolidayDate = txtHolidayDate.Text.Trim();
               
                objEWA.OrgId = orgId.ToString();

                int flag = objBL.HolidayAction_BL(objEWA);

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
                    GrdHolidayBind();
                    LoadForm();
                }
                else if (flag == -1)
                {
                    string msg ="Data is Already exist!!!";
                    msgBox.ShowMessage(msg, "Information", UserControls.MessageBox.MessageStyle.Information);

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



        //Holiday Grid Bind
        #region[Holiday Grid Bind]

        private void GrdHolidayBind()
        {
            try
            {

                EWA_Holiday objEWA = new EWA_Holiday();

                objEWA.Action = "GetHoliday";
                objEWA.OrgId = orgId.ToString();

                ds = objBL.HolidayGridBind_BL(objEWA);
                
                GrdHoliday.DataSource = ds;
                GrdHoliday.DataBind();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //HolidayLinkButtonClick
        #region HolidayLinkButtonClick

        protected void lnkBtnHolidayName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["HolidayId"] = GrdHoliday.DataKeys[grdrow.RowIndex].Values["HolidayId"].ToString();

                    txtHolidayName.Text = GrdHoliday.DataKeys[grdrow.RowIndex].Values["HolidayName"].ToString();
                    DateTime dt= Convert.ToDateTime(GrdHoliday.DataKeys[grdrow.RowIndex].Values["HolidayDate"].ToString());
                    txtHolidayDate.Text = dt.ToString("dd-MM-yyyy");

                    CallUpdate();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using EntityWebApp.HR;
using BusinessAccessLayer.HR;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.HR
{
    public partial class BasicPaySettings : System.Web.UI.Page
    {
        //Objects
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        #region[Objects]
        private BL_SalarySettings objBL = new BL_SalarySettings();
        private EWA_SalarySettings objEWA = new EWA_SalarySettings();
        database db = new database();
        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;
        #endregion


        // Page Load Code

        #region PageLoad

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
                    BindPayGroup();

                    
                }

         
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //saveData

        #region[Add New Pay Group Data]

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    Action("SalarySettingsSave");

                    // Load Bind Salary Heads;
                    BindSalaryHeads();
                    txtPBasicSalary.Text = string.Empty;
                    txtCategoryName.Text = string.Empty;
                    txtCategoryValue.Text = string.Empty;
                    DDL_PayGroup.ClearSelection();
                }
            }

            catch (Exception exp)
            {
                  GeneralErr(exp.Message.ToString());
            }
            
        }
        #endregion

        #region [Bind Salary Heads]

        private void BindSalaryHeads()
        {
          
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.PayGrpID = Convert.ToInt32(DDL_PayGroup.SelectedValue);
                objEWA.Action = "SalarySettingsSelect";
                DataSet ds = objBL.BL_BindSalaryHeads(objEWA);



                if (ds.Tables[1].Rows.Count == 0 || ds == null)
                {
                    txtPBasicSalary.Text = ds.Tables[0].Rows[0]["BasicSalary"].ToString();
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdSalaryHeads.DataSource = ds;
                    GrdSalaryHeads.DataBind();
                    int columncount = GrdSalaryHeads.Rows[0].Cells.Count;
                    GrdSalaryHeads.Rows[0].Cells.Clear();
                    GrdSalaryHeads.Rows[0].Cells.Add(new TableCell());
                    GrdSalaryHeads.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdSalaryHeads.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {


                    txtPBasicSalary.Text = ds.Tables[0].Rows[0]["BasicSalary"].ToString();
                    GrdSalaryHeads.DataSource = ds.Tables[1];
                    GrdSalaryHeads.DataBind();
                   
                    //foreach (GridViewRow row in GrdSalaryHeads.Rows)
                    //{
                    //    ImageButton btnimg = row.FindControl("ImgBtnRemove") as ImageButton;
                    //    btnimg.Visible = false;
                    //    break;
                    //}

    
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }


        }

        #endregion



        // Action Peroformed 

        //Perform Action for PayGroup 

        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.PayGrpID = 0;
                objEWA.Action = strAction;
                //float paygrpcontentId = Convert.ToInt32(db.getDb_Value("select PayGrpContentID from tblSalaryContentDetails where OrgId='" + orgId.ToString() + "'"));

                if (strAction == "SalarySettingsUpdate" || strAction == "SalarySettingsDelete" || strAction == "SalarySettingsSelect")
                {
                   
                    objEWA.PayGrpContentID = Convert.ToInt32(ViewState["PayGrpContentID"].ToString());
                   
                }
                else if (strAction == "SalarySettingsSave")
                {
                    objEWA.CategoryName = txtCategoryName.Text;
                    objEWA.CategoryValue = Convert.ToDouble(txtCategoryValue.Text);
                    objEWA.ValueType = rbtnValueType.SelectedValue.ToString();
                   
                   // objEWA.ValueOn = DDL_ValueOn.SelectedValue.ToString();
                    objEWA.ContentAction = rbtnContentType.SelectedValue.ToString();
                    objEWA.BasicSalary = Convert.ToDouble(txtPBasicSalary.Text);
                }
                
                objEWA.PayGrpID = Convert.ToInt32(DDL_PayGroup.SelectedValue);
             
                


                objEWA.OrgId = orgId;

                objEWA.UserId = Convert.ToInt32(Session["UserCode"]);
                objEWA.IsActive = true;


                int flag = objBL.SalaryHeads_BL(objEWA);


                if (flag > 0)
                {
                   // msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Record Saved Successfully')", true);


                    if (strAction == "SalarySettingsSave")
                    {
                        //    msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Record Saved Successfully')", true);
                    }
                    else if (strAction == "SalarySettingsUpdate")
                    {
                       // msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Updated", "alert('Record Updated Successfully')", true);
                    }
                    else if (strAction == "SalarySettingsDelete")
                    {
                        // msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Deleted", "alert('Record Deleted Successfully')", true);
                    }


                }
                else
                {
                    if (strAction == "SalarySettingsSave")
                    {
                       // msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save')", true);
                    }
                    else if (strAction == "SalarySettingsUpdate")
                    {
                       // msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update')", true);
                    }
                    else if (strAction == "SalarySettingsDelete")
                    {
                       // msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete')", true);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            finally
            {
                txtPayGroupName.Text = "";
                txtBasicSalary.Text = "";
            }
        }



        #endregion


        // Save /Update Delete /Cancle Methods

        #region [All Action Operation]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtPayGroupName.Enabled = true;
            txtBasicSalary.Enabled = true;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    ActionPayGroup("Save");
                    BindPayGroup();

                    txtPayGroupName.Text = "";
                    txtBasicSalary.Text = "";
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                        ActionPayGroup("Update");
                        BindPayGroup();
                        txtPayGroupName.Text = null;
                        txtBasicSalary.Text = null;
                        btnNew.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;
                    }
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
                    string rs= db.getDbstatus_Value("SELECT COUNT(EmpId) FROM tblEmployee WHERE PayGrpID='"+ Convert.ToInt32(ViewState["PayGrpID"].ToString()) + "'");
                    if (Convert.ToInt32(rs) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record Is in Use !!!')", true);
                    }
                    else
                    {
                        lock (this)
                        {
                            ActionPayGroup("Delete");
                            BindPayGroup();
                            txtPayGroupName.Text = null;
                            txtBasicSalary.Text = null;
                            btnNew.Enabled = true;
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                            btnUpdate.Enabled = false;
                        }
                    }
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
                lock (this)
                {
                    txtPayGroupName.Text = null;
                    txtBasicSalary.Text = null;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    //ActionPayGroup("Cancle");
                    //BindPayGroup();
                }
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform Action for PayGroup 

        #region[Perform Action]

        private void ActionPayGroup(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "Update" || strAction == "Delete" || strAction == "Select")
                {
                    objEWA.PayGrpID = Convert.ToInt32(ViewState["PayGrpID"].ToString());
                }

                objEWA.PayGrpName = txtPayGroupName.Text.Trim();
                objEWA.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);


                objEWA.OrgId = orgId;

                objEWA.UserId = Convert.ToInt32(Session["UserCode"]);
                objEWA.IsActive = true;

                int flag = objBL.SalaryContents_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                       // msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record Saved Successfully !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                        //msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record Updated Successfully !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                        //  msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record deleted Successfully !!!')", true);
                    }


                }
                else
                {
                    if (strAction == "Save")
                    {
                       // msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);
                    }
                    else if (strAction == "Update")
                    {
                        //msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Update !!!')", true);
                    }
                    else if (strAction == "Delete")
                    {
                        //msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Delete !!!')", true);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            finally 
            {
                txtPayGroupName.Text = "";
                txtBasicSalary.Text = "";
            }
        }

       

        #endregion

        // Link Button Click Events

        #region [Pay Group Events]

        protected void lnkBtnPayGrpName_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    //  ViewState["SubjectId"] = GrdScheme.DataKeys[grdrow.RowIndex].Values["SId"].ToString();
                    int PayGrpID = Convert.ToInt32(GrdPayGroupName.DataKeys[grdrow.RowIndex].Values["PayGrpID"].ToString());
                    txtPayGroupName.Text = GrdPayGroupName.DataKeys[grdrow.RowIndex].Values["PayGrpName"].ToString();
                    txtBasicSalary.Text = GrdPayGroupName.DataKeys[grdrow.RowIndex].Values["BasicSalary"].ToString();

                    ViewState["PayGrpID"] = PayGrpID;

                    txtPayGroupName.Enabled = true;
                    txtBasicSalary.Enabled = true;
                    btnSave.Enabled = false;
                    btnNew.Enabled = false;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Bind Pay Group

        #region [Bind Pay Group]

        private void BindPayGroup()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                DataSet ds = objBL.BL_BindPayGroup(objEWA);


                             
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdPayGroupName.DataSource = ds;
                    GrdPayGroupName.DataBind();
                    int columncount = GrdPayGroupName.Rows[0].Cells.Count;
                    GrdPayGroupName.Rows[0].Cells.Clear();
                    GrdPayGroupName.Rows[0].Cells.Add(new TableCell());
                    GrdPayGroupName.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdPayGroupName.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {


                    DDL_PayGroup.DataSource = ds.Tables[0];
                    DDL_PayGroup.DataTextField = "PayGrpName";
                    DDL_PayGroup.DataValueField = "PayGrpID";
                    DDL_PayGroup.DataBind();
                    DDL_PayGroup.Items.Insert(0, "Select");


                    GrdPayGroupName.DataSource = ds;
                    GrdPayGroupName.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
           

        }

        #endregion


        // Value Type Radio Button 

        #region [Value Changed]
        protected void rbtnValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnValueType.SelectedValue == "%")
            {
                //lblValueOn.Visible = true;
          //      DDL_ValueOn.Visible = true;

            }
            else if (rbtnValueType.SelectedValue == "RS")
            {
               // lblValueOn.Visible = false;
          //      DDL_ValueOn.Visible = false;

                //objEWA.CategoryValue = Convert.ToDouble(txtCategoryValue.Text);
            }

        }

        #endregion
        
        // Text Changed Events 


        #region [Text Changed Events]

        protected void txtCategoryValue_TextChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(txtCategoryValue.Text);


            if (rbtnValueType.SelectedValue == "%")
            {
                //lblValueOn.Visible = true;
              //  DDL_ValueOn.Visible = true;
                if (rbtnValueType.SelectedValue == "%" && value > 100)
                {
                    lblError.Visible = true;

                   // msgBox.ShowMessage("Plase Select Value Less 100 %", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Select Value Less 100 %')", true);
                }
                else if (rbtnValueType.SelectedValue == "%" && value < 100)
                {
                    lblError.Visible = false;
                    objEWA.ValueType = rbtnValueType.SelectedValue.ToString();

                    objEWA.CategoryValue = Convert.ToDouble(txtCategoryValue.Text);

                   // objEWA.ValueOn = DDL_ValueOn.SelectedValue.ToString();
                }
            }
            else if (rbtnValueType.SelectedValue == "RS")
            {
                //lblValueOn.Visible = false;
              //  DDL_ValueOn.Visible = false;

                objEWA.ValueType = rbtnValueType.SelectedValue.ToString();

                objEWA.CategoryValue = Convert.ToDouble(txtCategoryValue.Text);

            //    objEWA.ValueOn = DDL_ValueOn.SelectedValue.ToString();
            }
        }

        #endregion

        //General Message

        #region[General Message]

        protected void GeneralErr(String msg)
        {
            // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('"+msg+"')", true);

        }

        #endregion

        protected void DDL_PayGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSalaryHeads();
           
        }

       

        protected void GrdSalaryHeads_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.PayGrpID = Convert.ToInt32(DDL_PayGroup.SelectedValue);
                GrdSalaryHeads.PageIndex = e.NewPageIndex;
                DataSet ds = objBL.BL_BindSalaryHeads(objEWA);
                GrdSalaryHeads.DataSource = ds;
                GrdSalaryHeads.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }



        protected void ImgBtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    ImageButton lnkBtnId = (ImageButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                   
                    int PayGrpContentID = Convert.ToInt32(GrdSalaryHeads.DataKeys[grdrow.RowIndex].Values["PayGrpContentID"].ToString());
                   

                    ViewState["PayGrpContentID"] = PayGrpContentID;

                    Action("SalarySettingsDelete");

                    // Load Bind Salary Heads;
                    BindSalaryHeads();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessAccessLayer.HR;
using EntityWebApp.HR;
using DataAccessLayer;

namespace CMS.Forms.HR
{
    public partial class ApplyPayScale : System.Web.UI.Page
    {
        database db = new database();

        //Objects

        #region[Objects]
        private BL_SalarySettings objBL = new BL_SalarySettings();
        private EWA_SalarySettings objEWA = new EWA_SalarySettings();

        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;


        #endregion

        // Page Load

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
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
            
            int AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);

            
        }

        #endregion


        #region [Bind Pay Group]

        private void BindPayGroup()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                DataSet ds = objBL.BL_BindPayGroup(objEWA);


                DDL_PayGroup.DataSource = ds;
                DDL_PayGroup.DataTextField = "PayGrpName";
                DDL_PayGroup.DataValueField = "PayGrpID";
                DDL_PayGroup.DataBind();
                DDL_PayGroup.Items.Insert(0, "Select");


            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }


        }

        #endregion


        //Show Empty Grid
        #region[Show Empty Grid]

        private void ShowEmptyGridView(DataSet ds)
        {
            try
            {

                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GrdAssinedPayGroup.DataSource = ds;
                GrdAssinedPayGroup.DataBind();
                int columncount = GrdAssinedPayGroup.Rows[0].Cells.Count;
                GrdAssinedPayGroup.Rows[0].Cells.Clear();
                GrdAssinedPayGroup.Rows[0].Cells.Add(new TableCell());
                GrdAssinedPayGroup.Rows[0].Cells[0].ColumnSpan = columncount;
                GrdAssinedPayGroup.Rows[0].Cells[0].Text = "No Records Found";
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

        // Pay Group Selected Index changed

        #region [Pay Group]
        protected void DDL_PayGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmployeeList();

        }
        #endregion


        // Bind Employee List
        #region [Bind Employee List]

        private void BindEmployeeList()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.Action = "SelectEmployee";
                objEWA.PayGrpID = Convert.ToInt32(DDL_PayGroup.SelectedValue);

                DataSet ds = objBL.BL_BindEmployeeList(objEWA);



                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdAssinedPayGroup.DataSource = ds.Tables[0];
                    GrdAssinedPayGroup.DataBind();
                    int columncount = GrdAssinedPayGroup.Rows[0].Cells.Count;
                    GrdAssinedPayGroup.Rows[0].Cells.Clear();
                    GrdAssinedPayGroup.Rows[0].Cells.Add(new TableCell());
                    GrdAssinedPayGroup.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdAssinedPayGroup.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {

                    GrdAssinedPayGroup.DataSource = ds.Tables[0];
                    GrdAssinedPayGroup.DataBind();
                }
                if (ds.Tables[1].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdNotAssined.DataSource = ds.Tables[0];
                    GrdNotAssined.DataBind();
                    int columncount = GrdNotAssined.Rows[0].Cells.Count;
                    GrdNotAssined.Rows[0].Cells.Clear();
                    GrdNotAssined.Rows[0].Cells.Add(new TableCell());
                    GrdNotAssined.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdNotAssined.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    GrdNotAssined.DataSource = ds.Tables[1];
                    GrdNotAssined.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Delete Button Code

        #region [Pay Group Events]

        protected void ImgBtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    lock (this)
                    {
                        ImageButton lnkBtnId = (ImageButton)sender;
                        GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                        //  ViewState["SubjectId"] = GrdScheme.DataKeys[grdrow.RowIndex].Values["SId"].ToString();
                        int PayGrpID = 0;// Convert.ToInt32(GrdAssinedPayGroup.DataKeys[grdrow.RowIndex].Values["PayGrpID"].ToString());

                        int UserCode = Convert.ToInt32(GrdAssinedPayGroup.DataKeys[grdrow.RowIndex].Values["UserCode"].ToString());

                        ViewState["PayGrpID"] = PayGrpID;
                        ViewState["UserCode"] = UserCode;

                        Action("DeletePayScale");
                        BindEmployeeList();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region [Pay Group Events]

        protected void lnkbtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;

                    int PayGrpID = Convert.ToInt32(DDL_PayGroup.SelectedValue);
                        //Convert.ToInt32(GrdAssinedPayGroup.DataKeys[grdrow.RowIndex].Values["PayGrpID"].ToString());

                    int UserCode = Convert.ToInt32(GrdNotAssined.DataKeys[grdrow.RowIndex].Values["UserCode"].ToString());

                    ViewState["PayGrpID"] = PayGrpID;
                    ViewState["UserCode"] = UserCode;

                    Action("UpdatePayScale");
                    BindEmployeeList();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                if (strAction == "UpdatePayScale" || strAction == "DeletePayScale" || strAction == "SelectPayScale")
                {



                    objEWA.PayGrpID = Convert.ToInt32(ViewState["PayGrpID"].ToString());
                    objEWA.UserCode = Convert.ToString(ViewState["UserCode"].ToString());



                    //if (strAction == "DeletePayScale")
                    //{

                    //    string a = db.getDbstatus_Value("select EmpId from tblEmployee where UserCode='" + Convert.ToString(ViewState["UserCode"].ToString()) + "'").ToString();


                    //    db.cnopen();
                    //    db.insert("delete tblEmployee where EmpId='" + a.ToString() + "' ");
                    //    db.cnclose();
                    //}
                    //msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());

                    objEWA.UserId = Convert.ToInt32(Session["UserCode"]);
                    objEWA.IsActive = true;

                    int flag = objBL.BL_UpdatePayScale(objEWA);

                    if (flag > 0)
                    {
                        if (strAction == "SavePayScale")
                        {
                            msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                        else if (strAction == "UpdatePayScale")
                        {
                            msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                        else if (strAction == "DeletePayScale")
                        {
                            msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                        }


                    }
                    else
                    {
                        if (strAction == "SalarySettingsSave")
                        {
                            msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        }
                        else if (strAction == "SalarySettingsUpdate")
                        {
                            msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        }
                        else if (strAction == "SalarySettingsDelete")
                        {
                            msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
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

        protected void GrdAssinedPayGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        { 
            GrdAssinedPayGroup.PageIndex = e.NewPageIndex;
            BindEmployeeList();
        }

        protected void GrdNotAssined_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdNotAssined.PageIndex = e.NewPageIndex;
            BindEmployeeList();
            
        }
    }
}
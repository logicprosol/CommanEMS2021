using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using BusinessAccessLayer.HR;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Faculty;
using EntityWebApp.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.HR
{
    public partial class StaffViewLeaveHistory : System.Web.UI.Page
    {
        #region[Objects]
        private BL_SalarySettings objBL = new BL_SalarySettings();
        private EWA_SalarySettings objEWA = new EWA_SalarySettings();

        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            orgId = Convert.ToInt32(Session["OrgId"]);
            int AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);
            ViewState["OrgID"] = orgId.ToString();
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                BindDepartment();

            }
        }

        //Bind Department
        #region[Bind Department]

        private void BindDepartment()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindDepartment_BL(objEWA);

                DDL_Department.DataSource = ds;
                DDL_Department.DataTextField = "DepartmentName";
                DDL_Department.DataValueField = "DepartmentId";
                DDL_Department.DataBind();
                DDL_Department.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "Select"));

                
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Faculty Type Index Changed
        #region[Faculty Type Index Changed]

        protected void rbtnFacultyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnFacultyType.SelectedItem.Value != null)
                {
                    BindDesignation();
                }
                // ShowEmptyGridView(grdEarning);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[Bind Design]

        private void BindDesignation()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.DepartmentId = DDL_Department.SelectedValue.ToString();
                objEWA.DesignationTypeId = rbtnFacultyType.SelectedItem.Value;

                //RadioButtonList rbtnList = Page.FindControl("rbtnFacultyType") as RadioButtonList;

                //string str= rbtnList.SelectedValue;

                DataSet ds = objBL.BindDesignation_BL(objEWA);

                DDL_Designation.DataSource = ds;
                DDL_Designation.DataTextField = "DesignationName";
                DDL_Designation.DataValueField = "DesignationId";
                DDL_Designation.DataBind();
                DDL_Designation.Items.Insert(0, "Select");
                DDL_Designation.SelectedIndex = 0;
                DDL_Designation.DataSource = null;
                DDL_Designation.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Designation Index Changed
        #region[Designation Index Changed]

        protected void DDL_Designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindEmolyeeList();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void BindEmolyeeList()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.DesignationId = DDL_Designation.SelectedValue.ToString();
                objEWA.DepartmentId = DDL_Department.SelectedValue.ToString();
                objEWA.DesignationTypeId = rbtnFacultyType.SelectedValue.ToString();

                DataSet ds = objBL.BindFacultyName(objEWA);


                DDL_EmoloyeeName.DataSource = ds;
                DDL_EmoloyeeName.DataTextField = "EmpName";
                DDL_EmoloyeeName.DataValueField = "UserCode";
                //ViewState["PayGrpID"] = "PayGrpID";
                DDL_EmoloyeeName.DataBind();
                DDL_EmoloyeeName.Items.Insert(0, "Select");
                DDL_EmoloyeeName.SelectedIndex = 0;
                //DDL_EmoloyeeName.DataSource = null;
                //DDL_EmoloyeeName.DataBind();

                //if (ds.Tables[0].Rows[0]["PayGrpID"].ToString() != "")
                //{
                //    PayGroupID = Convert.ToInt32(ds.Tables[0].Rows[0]["PayGrpID"].ToString());
                //}
                //else
                //{
                //    PayGroupID = 0;
                //}

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region [Select Employee]
        protected void DDL_EmoloyeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindLeaveHistory();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        #endregion

        public void BindLeaveHistory()
        {
            try
            {
                BL_Leave ObjBL = new BL_Leave();
                EWA_Leave ObjEWA = new EWA_Leave();

                ObjEWA.OrgID = orgId;
                ObjEWA.UserCode = DDL_EmoloyeeName.SelectedValue;
                DataSet ds = ObjBL.BL_GetLeaveHistory(ObjEWA);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdStaffLeave.DataSource = ds;
                    grdStaffLeave.DataBind();
                }
                else
                {
                    grdStaffLeave.DataSource = null;
                    grdStaffLeave.DataBind();
                    msgBox.ShowMessage("Recode not Found...!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception ext)
            {

            }
        }

        //General Message

        #region[General Message]

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void DDL_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbtnFacultyType.ClearSelection();
        }
    }
}
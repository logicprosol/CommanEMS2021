using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

namespace CMS.Forms.Admin
{
    public partial class Role : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_Role objBL = new BL_Role();
        private EWA_Role objEWA = new EWA_Role();
        private BindControl ObjHelper = new BindControl();
        public static int orgId;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
        orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

            if (!IsPostBack)
            {
                //GetRoleData();

                GrdAssinedRole.DataSource = EmptyGridView();
                GrdAssinedRole.DataBind();

                GrdEmployee.DataSource = EmptyGridView();
                GrdEmployee.DataBind();

                //ShowEmptyGridView(ds);
            }
        }

        #endregion

        //Get Role Data
        #region [Get Role Data]

        private void GetRoleData()
        {
            try
            {
                objEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());
                DataSet ds = objBL.GetRole_BL(objEWA);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Show Empty Grid
        #region[Show Empty Grid]

        private DataTable EmptyGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("User Code");
                dt.Columns.Add("Full Name");
                dt.Columns.Add("User Type");
                //dt.Rows.Add();
                return dt;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return null;
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

        //Role Changed
        #region[Role Changed]

        protected void DDL_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetAllRoleData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Get All Role Data
        #region[Get All Role Data]

        public void GetAllRoleData()
        {
            try
            {
                if (DDL_Role.SelectedItem.Text == "Select")
                {
                    GrdAssinedRole.DataSource = EmptyGridView();
                    GrdAssinedRole.DataBind();

                    GrdEmployee.DataSource = EmptyGridView();
                    GrdEmployee.DataBind();
                }
                else
                {
                    objEWA = new EWA_Role();
                    objEWA.UserType = DDL_Role.SelectedItem.Text;
                    objEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());
                    objEWA.IsActive = true;

                    DataSet ds = new DataSet();
                    ds = objBL.GetRole_BL(objEWA);

                    BindGrids(ds);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Bind Grids
        #region[Bind Grids]

        public void BindGrids(DataSet ds)
        {
            GrdAssinedRole.DataSource = ds.Tables[0];
            GrdAssinedRole.DataBind();

            GrdEmployee.DataSource = ds.Tables[1];
            GrdEmployee.DataBind();
        }

        #endregion

        //Update Events
        #region[Update Events]

        public void lbtnAdmin_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtnId = (LinkButton)sender;
                string role = lnkBtnId.Text;
                GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                string Uid = GrdEmployee.DataKeys[grdrow.RowIndex].Values["User Code"].ToString();
                UpdateRole(role, Uid);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Delete Role Click
        #region[Delete Role Event]

        public void ImgBtnRemove_OnClick(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    ImageButton ImgBtnId = (ImageButton)sender;
                    GridViewRow grdrow = ImgBtnId.NamingContainer as GridViewRow;
                    string Uid = GrdAssinedRole.DataKeys[grdrow.RowIndex].Values["User Code"].ToString();
                    string CurrentUid = Session["UserCode"].ToString();
                    if (CurrentUid != Uid)
                    {
                        DeleteRole(Uid);
                    }
                    else
                    {
                        GeneralErr("You can't change your role !!!");
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Update Role
        #region[Update Role]

        public void UpdateRole(string role, string Uid)
        {
            try
            {
                objEWA = new EWA_Role();
                objEWA.Action = "UpdateRole";
                objEWA.UserType = role;
                objEWA.UserId = Uid;
                objEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());

                objBL.UpdateRole_BL(objEWA);

                DDL_Role.ClearSelection();

                GrdAssinedRole.DataSource = EmptyGridView();
                GrdAssinedRole.DataBind();

                GrdEmployee.DataSource = EmptyGridView();
                GrdEmployee.DataBind();

                msgBox.ShowMessage("Role updated Successfully !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
                //GeneralErr("Role updated Successfully !!!");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Delete Role
        #region[Delete Role]

        public void DeleteRole(string Uid)
        {
            try
            {
                objEWA = new EWA_Role();
                objEWA.Action = "DeleteRole";

                objEWA.UserId = Uid;
                objEWA.OrganizationId = Convert.ToInt32(Session["OrgId"].ToString());

                objBL.DeleteRole_BL(objEWA);

                DDL_Role.ClearSelection();

                GrdAssinedRole.DataSource = EmptyGridView();
                GrdAssinedRole.DataBind();

                GrdEmployee.DataSource = EmptyGridView();
                GrdEmployee.DataBind();

                msgBox.ShowMessage("Role removed Successfully !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
                //GeneralErr("Role removed Successfully !!!");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Asigned Role Page iNdex Change
        #region[Asigned Role Page Index Change]

        protected void GrdAssinedRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdAssinedRole.PageIndex = e.NewPageIndex;
                GetAllRoleData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Employee Page Index Change
        #region[Employee Page Index Chnage]

        protected void GrdEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdEmployee.PageIndex = e.NewPageIndex;
                GetAllRoleData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion
    }
}
using System;
using System.Data;
using System.Web.UI.WebControls;
using DataAccessLayer;

//View Attendance
namespace CMS.Forms.Faculty
{
    public partial class ViewEmpAttendance : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private string[] param;
        public static int orgId = 0;
        private BindControl objCntrl = new BindControl();
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
}

        #endregion

        //Show Event
        #region[Show Event]

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                param = new string[4];
                param[0] = "@SelectedDate";
                param[1] = "01-" + txtDate.Text.ToString();
                param[2] = "@EnrollNo";
                param[3] = "10013";
                DataSet ds = new DataSet();
                ds = objCntrl.FillControl(param, "SP_ShowEmpAttendance");
                ViewState["EmpAtt"] = ds;
                GrdDeviceData.DataSource = ds;
                GrdDeviceData.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Device Data Changing
        #region[Device Data Changing]

        protected void GrdDeviceData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["EmpAtt"];
                GrdDeviceData.PageIndex = e.NewPageIndex;
                GrdDeviceData.DataSource = ds.Tables[0];
                GrdDeviceData.DataBind();
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
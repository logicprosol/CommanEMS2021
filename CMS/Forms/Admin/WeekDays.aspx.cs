using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;

//Week Days
namespace CMS.Forms.Admin
{
    public partial class WeekDays : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private EWA_WeekDay objEWA = new EWA_WeekDay();
        private BL_WeekDay objBL = new BL_WeekDay();
        private BindControl ObjHelper = new BindControl();
        public static int orgId;
        #endregion

        #region [Page Load]

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
                    //objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.OrgId = "7";
                    GrdDayBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Binding Day Grid
        #region[Day Grid Bind]

        private void GrdDayBind()
        {
            try
            {
                DataSet ds = objBL.DayGridBind_BL(objEWA);
                GrdDay.DataSource = ds;
                GrdDay.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Set Week Days
        #region[Set Week Day]

        protected void btnSetWeekDay_Click(object sender, EventArgs e)
        {
            try
            {
                int chk = CheckData();
                if (chk > 0)
                {
                    Action("Update");
                }
                else
                {
                    Action("SaveWeekDay");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save,Update Action performed on Week Day table
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                int flag = 0;
                if (strAction == "Update")
                {
                    int cnt = GrdDay.Rows.Count;
                    string[] Day = new string[cnt];
                    int j = 0;
                    foreach (GridViewRow gvrow in GrdDay.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                        if (chk != null && chk.Checked)
                        {
                            Day[j] = GrdDay.DataKeys[gvrow.RowIndex].Values["DayId"].ToString();
                            objEWA.DayId = Day[j];
                            //objEWA.OrgId = Session["OrgId"].ToString();
                            objEWA.OrgId = "7";
                        }
                        j++;
                    }
                }

                int count = GrdDay.Rows.Count;
                string[] DayId = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdDay.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                    if (chk != null && chk.Checked)
                    {
                        objEWA.Action = strAction;
                        DayId[i] = GrdDay.DataKeys[gvrow.RowIndex].Values["DayId"].ToString();
                        objEWA.DayId = DayId[i];
                        //objEWA.OrgId = Session["OrgId"].ToString();
                        objEWA.OrgId = "7";
                        objEWA.UserId = "1";
                        objEWA.IsActive = true;
                        flag = objBL.WeekDayAction_BL(objEWA);
                    }
                    else
                    {
                        objEWA.Action = strAction;
                        DayId[i] = GrdDay.DataKeys[gvrow.RowIndex].Values["DayId"].ToString();
                        objEWA.DayId = DayId[i];
                        //objEWA.OrgId = Session["OrgId"].ToString();
                        objEWA.OrgId = "7";
                        objEWA.UserId = "1";
                        objEWA.IsActive = false;
                        flag = objBL.WeekDayAction_BL(objEWA);
                    }
                    i++;
                }

                if (flag > 0)
                {
                    if (strAction == "SaveWeekDay")
                    {
                        msgBox.ShowMessage("Week Days Set Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Week Days Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                }
                else
                {
                    if (strAction == "SaveWeekDay")
                    {
                        msgBox.ShowMessage("Unable to  Set !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Status of CheckBox
        #region [Check Status]

        protected void OnDataBound(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = (DataSet)GrdDay.DataSource;
                for (int i = GrdDay.Rows.Count - 1; i >= 0; i--)
                {
                    GridViewRow row = GrdDay.Rows[i];
                    CheckBox chbox = (CheckBox)GrdDay.Rows[i].FindControl("checkbox");
                    string check = ds.Tables[0].Rows[i]["IsActive"].ToString();
                    if (check.Equals("True"))
                    {
                        chbox.Checked = true;
                    }
                    else
                    {
                        chbox.Checked = false;
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Check Existing Data For Update
        #region[Check Data]

        private int CheckData()
        {
            try
            {
                int flag = 0;
                int count = GrdDay.Rows.Count;
                string[] DayId = new string[count];
                int i = 0;
                foreach (GridViewRow gvrow in GrdDay.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                    if (chk != null && chk.Checked)
                    {
                        DayId[i] = GrdDay.DataKeys[gvrow.RowIndex].Values["DayId"].ToString();
                        objEWA.DayId = DayId[i];
                        //objEWA.OrgId = Session["OrgId"].ToString();
                        objEWA.OrgId = "7";
                        flag = objBL.CheckDuplicateOrg_BL(objEWA);
                    }
                    i++;
                }
                return flag;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
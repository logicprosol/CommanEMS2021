using System;
using System.Data;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp.Faculty;

//Apply Leave
namespace CMS
{
    public partial class ApplyLeave : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BindControl ObjHelper = new BindControl();
        private DataSet ds = new DataSet();
        private BL_Leave BLeave = new BL_Leave();
        private EWA_Leave ELeave = new EWA_Leave();
        public static int orgId = 0;
        #endregion

        //Page Load
        #region[Page LoAd]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
        orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }

    lblCurrentDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

                GetApplicationID();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Get Application Id
        #region[Get Application Id]

        private void GetApplicationID()
        {
            try
            {
                ELeave.OrgID = Convert.ToInt32(Session["OrgId"]);
                ds = BLeave.BL_GetApplication(ELeave);
                int ID = 0011; //Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                txtApplicationID.Text = Convert.ToString(ID + 1);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Submit
        #region[Submit]

        protected void btnSubmit0_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    SaveLeaveApplication("SaveLeaveApplication");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Application
        #region[Save Application]

        private void SaveLeaveApplication(string strAction)
        {
            try
            {
                ELeave.strAction = strAction;
                ELeave.ApplicationID = Convert.ToInt32(txtApplicationID.Text);
                ELeave.ApplicationDate = lblCurrentDate.Text;
                ELeave.OrgID = Convert.ToInt32(Session["OrgId"]);
                ELeave.UserCode = Convert.ToString(Session["UserCode"]);

                ELeave.LeaveTypeID = Convert.ToInt32(DDLSelectLeaveType.SelectedValue);
                ELeave.BalanceLeave = 5;// Convert.ToInt32(txtBalance.Text);

                ELeave.leaveCategory = rbtnHalfDay.SelectedValue;
                ELeave.subject = txtSubject.Text;
                ELeave.fromDate = txtFromDate.Text.ToString();
                ELeave.toDate = txtToDate.Text.ToString();
                ELeave.LeaveDays = Convert.ToInt32(TxtDays.Text);
                ELeave.reason = txtReason.Text;
                ELeave.LeaveStatus = "Pending";

                int flag = BLeave.BLSaveLeaveApplication(ELeave);
                msgBox.ShowMessage("You Applied  For  Successfully!!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                if (flag > 0)
                {
                    if (strAction == "SaveLeaveApplication")
                    {
                        msgBox.ShowMessage("You Applied  For  Successfully!!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        //string strSMS = null;
                        //string strEmail = null;

                        //msgBox.ShowMessage(strSMS, "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        //strEmail = SendEmails();
                        //msgBox.ShowMessage(strEmail, "Saved", UserControls.MessageBox.MessageStyle.Successfull);

                        //Response.Redirect("~/College_Home.aspx");
                    }
                    else if (strAction == "Update")
                    {
                        ///  msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Delete")
                    {
                        // msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Date Changed
        #region[Date Changed]

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dateString = txtFromDate.Text;//@"20/05/2012";
                DateTime date3 = DateTime.ParseExact(dateString, @"d/M/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                string dateString2 = txtToDate.Text;//@"20/05/2012";
                DateTime date4 = DateTime.ParseExact(dateString2, @"d/M/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

                DateTime myDate1 = date3;
                DateTime myDate2 = date4;
                TimeSpan difference = myDate2.Subtract(myDate1);

                double totalDays = difference.TotalDays;

                TxtDays.Text = totalDays.ToString();
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
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
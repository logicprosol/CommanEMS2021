using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Faculty;
using EntityWebApp.Faculty;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

//Leave Type
namespace CMS.Forms.Faculty
{
    public partial class LeaveApplication : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private EWA_LeaveApplication objEWA = new EWA_LeaveApplication();
        private BL_LeaveApplication objBL = new BL_LeaveApplication();
        public DataView dview;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        database db = new database();
        DataTable dt = new DataTable();
        public static int orgId = 0;
        #endregion

        //Page Load
        #region[Page Load]

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
                    txtFrom.Attributes.Add("Readonly", "Readonly");
                    txtTo.Attributes.Add("Readonly", "Readonly");
                    LeaveType();
                    GrdLeaveTypeBind();
                    string date1 = System.DateTime.Now.ToString("dd/MM/yyyy");
                    //DateTime dt2 = Convert.ToDateTime(lblApplicationDate.Text);
                    lblApplicationDate.Text = date1;
                    BindEmptyGrid();           
                    
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Bind Empty Grid
        #region[Bind Empty Grid]

        public void BindEmptyGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                GrdLeaveApplication.DataSource = dt;
                GrdLeaveApplication.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Clear Controls
        #region[Clear Controls]

        public void ClearControls()
        {
            try
            {
                BindEmptyGrid();
                txtFrom.Text = "";
                txtReason.Text = "";
                lblTotal.Text = "";
                txtTo.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Leave Type Bind
        #region[Leave Type Bind]

        private void GrdLeaveTypeBind()
        {
            try
            {
                objEWA.Action = "SelectLeaveData";
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.UserCode = Session["UserCode"].ToString();

                DataSet ds = objBL.LeaveBalanceGridBind_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["LeaveBalance"] = ds.Tables[0];

                    GrdLeaveType.DataSource = ds.Tables[0];
                    //GrdLeaveType.ShowHeader = false;
                    GrdLeaveType.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();

                    GrdLeaveType.DataSource = dt;
                    //GrdLeaveType.ShowHeader = false;
                    GrdLeaveType.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //TO text changed
        #region[To text Changed]

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    lblTotal.Text = ValidateDuration();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //From text Changed
        #region[From text changed]

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    lblTotal.Text = ValidateDuration();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Date Duration Validatioin
        #region[Date Valid Duration]

        protected string ValidateDuration()
        {
            try
            {
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    DateTime start = DateTime.ParseExact(txtFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //DateTime st=DateTime.Parse(
                    DateTime end = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    TimeSpan ts = end - start;

                    DateRows();

                    return (ts.TotalDays + 1).ToString();
                }
                return "0";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
                return "0";
            }
        }

        #endregion

        //Create Date Rows
        #region[Date Row]

        protected void DateRows()
        {
            try
            {
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    GrdLeaveApplication.DataSource = null;
                    GrdLeaveApplication.DataBind();
                    DataTable dtDate = new DataTable();
                    dtDate.Columns.Add("Date");
                    dtDate.Columns.Add("Full_Half");
                    dtDate.Columns.Add("LeaveType");

                    DateTime start = DateTime.ParseExact(txtFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //DateTime st=DateTime.Parse(
                    DateTime end = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    for (DateTime s = start; s <= end; s = s.AddDays(1))
                    {
                        dtDate.Rows.Add((s.ToString("dd/MM/yyyy")).Replace('-', '/'), "1", "0");
                    }

                    GrdLeaveApplication.DataSource = dtDate;
                    GrdLeaveApplication.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Calculate Total Datys
        #region[Total Days]

        protected void rbtnFullHalf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    double total = 0.0;
                    RadioButtonList rbtnFull = new RadioButtonList();
                    foreach (GridViewRow grw in GrdLeaveApplication.Rows)
                    {
                        rbtnFull = grw.Cells[1].FindControl("rbtFullHalf") as RadioButtonList;
                        double full = 0.0;
                        full = Convert.ToDouble(rbtnFull.SelectedValue.ToString());
                        if (full == 1.0)
                            total = 1 + total;
                        else if (full == 2.0)
                            total = 0.5 + total;
                    }
                    lblTotal.Text = total.ToString();
                }
            }
            catch (Exception exp)
            {
                //throw;
            }
        }

        #endregion

        //Save Event
        #region[Save Event]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    if (txtFrom.Text == "" || txtTo.Text == "")
                    {
                        msgBox.ShowMessage("Please Enter From Date or To Date !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    else
                    {
                        GridToDatatable(0);
                        DataTable dvLeaveDetails = (DataTable) ViewState["tempLeaveDetails"] as DataTable;

                        DateTime fromdate = DateTime.Parse(txtFrom.Text);
                        var datefrom = fromdate.Date.ToString("yyyy-MM-dd");
                        DateTime todate = DateTime.Parse(txtTo.Text);
                        var dateto = todate.Date.ToString("yyyy-MM-dd");

                        DateTime ApplicationDate = DateTime.Parse(lblApplicationDate.Text);
                        var _ApplicationDate = ApplicationDate.Date.ToString("yyyy-MM-dd");

                        SqlCommand cmd = new SqlCommand("SP_LeaveApplication", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Save");
                        cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"]));
                        cmd.Parameters.AddWithValue("@ApplicationDate", _ApplicationDate);
                        cmd.Parameters.AddWithValue("@UserCode", Session["UserCode"].ToString());
                        cmd.Parameters.AddWithValue("@FromDate", datefrom);
                        cmd.Parameters.AddWithValue("@ToDate", dateto);
                        cmd.Parameters.AddWithValue("@TotalLeave", Convert.ToDecimal(lblTotal.Text));
                        cmd.Parameters.AddWithValue("@Reason", txtReason.Text);
                        cmd.Parameters.AddWithValue("@LeaveStatus", "Pending");
                        cmd.Parameters.AddWithValue("@LeaveDetails", dvLeaveDetails);
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        cn.Close();

                        

                            //db.cnopen();
                            //db.insert("	INSERT INTO tblLeaveApplication (ApplicationDate,UserCode,FromDate,	ToDate,TotalLeave,		Reason,	OrgID,	LeaveStatus) values('" + lblApplicationDate.Text.Trim() + "','" + Session["UserCode"].ToString() + "','" + datefrom.ToString() + "','" + dateto.ToString() + "','" + lblTotal.Text.Trim() + "','" + txtReason.Text + "','" + Convert.ToInt32(Session["OrgId"].ToString()) + "','" + "waiting" + "')");
                            //db.cnclose();
                            clear();
                      msgBox.ShowMessage("Leave Apply Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);


                        //Action("Save");
                    //  Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Calculate Balance

        public void CalculateBalance()
        {
            DataView dvBalance = new DataView(ViewState["LeaveBalance"] as DataTable);

            DataView dvLeaveDetails = new DataView(ViewState["tempLeaveDetails"] as DataTable);
        }


        //Perform Action for Leave Application
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                objEWA.Action = strAction;
                //DateTime fromdate = new DateTime();
                //fromdate = Convert.ToDateTime(DateTime.ParseExact(txtFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture));

                //DateTime Todate = new DateTime();
                //Todate = Convert.ToDateTime(DateTime.ParseExact(txtTo.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture));

                string fromdate = txtFrom.Text;
                DateTime datefrom = DateTime.Parse(fromdate);
                datefrom.ToString("yyyy/dd/MM");
                string todate = txtTo.Text;
                DateTime Todate = DateTime.Parse(todate);
                Todate.ToString("yyyy/dd/MM");
                objEWA.UserCode = Session["UserCode"].ToString();
                objEWA.ApplicationDate = lblApplicationDate.Text.Trim();
                objEWA.FromDate = "2017-04-26 00:00:00.000";
                objEWA.ToDate = "2017-04-28 00:00:00.000";
                objEWA.TotalLeave = lblTotal.Text.Trim();
                objEWA.Reason = txtReason.Text.Trim();
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.LeaveStatus = "waiting";

                objEWA.dtLeaveDetails = ViewState["tempLeaveDetails"] as DataTable;
                int flag = objBL.LeaveApplicationAction_BL(objEWA);

                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }

                    ClearControls();
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
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Leave Application Row Data Bound
        #region[Leave Application Row Data Bound]

        protected void GrdLeaveApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        dview = new DataView((DataTable)ViewState["LeaveType"]);

            //        DropDownList ddlLeaveType = (DropDownList)e.Row.FindControl("ddlLeaveType");
            //        ddlLeaveType.DataSource = dview;
            //        ddlLeaveType.DataTextField = "LeaveCode";
            //        ddlLeaveType.DataValueField = "LeaveId";
            //        ddlLeaveType.DataBind();
            //        ddlLeaveType.Items.Insert(0, new ListItem("Select", "0"));

                    
            //    }
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message);
            //}
           


            

        }

        #endregion

        //Leave Type
        #region[Leave Type]

        public void LeaveType()
        {
            try
            {
                objEWA.Action = "SelectLeaveType";
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.UserCode = Session["UserCOde"].ToString();
                DataSet ds = objBL.LeaveBalanceGridBind_BL(objEWA);

                ViewState["LeaveType"] = ds.Tables[0];
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
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

        //Grid Date Data To DataTable
        #region[Grid To DataTable]

        protected void GridToDatatable(int LeaveId)
        {
            try
            {
                DataTable dtLeaveDetails = new DataTable();
                dtLeaveDetails.Columns.Add("LeaveId");
                dtLeaveDetails.Columns.Add("Date");
                dtLeaveDetails.Columns.Add("Full_Half");
                dtLeaveDetails.Columns.Add("Paid_Unpaid");
                Label lblDate = new Label();
                RadioButtonList rbtnFull = new RadioButtonList();
                DropDownList rbtnPaid = new DropDownList();
                foreach (GridViewRow grw in GrdLeaveApplication.Rows)
                {
                    lblDate = grw.Cells[0].FindControl("lblDate") as Label;
                    //string date1 = lblDate.Text;
                    DateTime dt = DateTime.ParseExact(lblDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string date = dt.ToString("yyyy/MM/dd");
                    rbtnFull = grw.Cells[1].FindControl("rbtFullHalf") as RadioButtonList;
                    string full = rbtnFull.SelectedValue.ToString();
                    //rbtnPaid = grw.Cells[1].FindControl("ddlLeaveType") as DropDownList;
                    string LeaveType = drpLeaveType.Text;

                    dtLeaveDetails.Rows.Add(LeaveId, date, full, LeaveType);
                }
                ViewState["tempLeaveDetails"] = dtLeaveDetails;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw;
            }
        }

        #endregion

        protected void GrdLeaveApplication_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrdLeaveApplication_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdLeaveApplication.PageIndex = e.NewPageIndex;
        }
        void clear()
        {
            txtFrom.Text = "";
            txtTo.Text = "";
          
            txtReason.Text = "";
            GrdLeaveApplication.DataSource = null;
            GrdLeaveApplication.DataBind();
        }

    }
}
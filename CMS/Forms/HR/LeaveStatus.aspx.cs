using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using BusinessAccessLayer.HR;
using EntityWebApp.HR;
using System.Web.Configuration;
using System.Net.Mail;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Text;

//Leave Type
namespace CMS.Forms.HR
{
    public partial class LeaveStatus : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private EWA_LeaveStatus objEWA = new EWA_LeaveStatus();
        private BL_LeaveStatus objBL = new BL_LeaveStatus();
        public DataView dview;
        database db = new database();
        float count = 0;
        string Email;
        string Name;
        string Status;
        string FromDate;
        string ToDate;
        public static int orgId = 0;
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

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
                    
                    //txtFrom.Attributes.Add("Readonly", "Readonly");
                    //txtTo.Attributes.Add("Readonly", "Readonly");
                    //LeaveType();
                    GrdLeaveData();
                    string date1 = System.DateTime.Now.ToString("dd/MM/yyyy");
                    //DateTime dt2 = Convert.ToDateTime(lblApplicationDate.Text);
                    lblApplicationDate.Text = date1;
                   //BindEmptyGrid();
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

        //public void BindEmptyGrid()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        GrdLeaveApplication.DataSource = dt;
        //        GrdLeaveApplication.DataBind();
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message);
        //    }
        //}

        #endregion

        //Clear Controls
        #region[Clear Controls]

        public void ClearControls()
        {
            try
            {
                GrdLeaveData();
                //BindEmptyGrid();
                //txtFrom.Text = "";
                txtReason.Text = "";
                ddlStatus.SelectedIndex = 0;
                //lblTotal.Text = "";
                //txtTo.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //Leave Type Bind
        #region[Leave Type Bind]

        private void GrdLeaveData()
        {
            try
            {
                
                GrdLeaveDetails.DataSource = db.Displaygrid("SELECT ApplicationId AS 'Id',FirstName + ' ' + MiddleName + ' ' + LastName + ' ' AS 'Name',lapp.UserCode AS 'User Code',			CONVERT(varchar(15), ApplicationDate,105) AS 'Application Date' ,CONVERT(varchar(15), FromDate,105) AS 'From Date',CONVERT(varchar(15), ToDate,105) AS 'To Date', lapp.Reason,TotalLeave AS 'Total Leave Days',LeaveStatus AS 'Leave Status',	lapp.OrgID AS 'Org Id' FROM tblLeaveApplication lapp INNER JOIN tblEmployee emp ON lapp.UserCode = emp.UserCode       WHERE lapp.OrgID = " + Session["OrgId"].ToString() + " and lapp.LeaveStatus = 'Pending' order by (Id)desc");
                GrdLeaveDetails.DataBind(); 

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //TO text changed
        //#region[To text Changed]

        //protected void txtTo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtFrom.Text != "" && txtTo.Text != "")
        //        {
        //            lblTotal.Text = ValidateDuration();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message);
        //    }
        //}

        //#endregion

        //From text Changed
        //#region[From text changed]

        //protected void txtFrom_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtFrom.Text != "" && txtTo.Text != "")
        //        {
        //            lblTotal.Text = ValidateDuration();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message);
        //    }
        //}

        //#endregion

        //Date Duration Validatioin
        //#region[Date Valid Duration]

        //protected string ValidateDuration()
        //{
        //    try
        //    {
        //        if (txtFrom.Text != "" && txtTo.Text != "")
        //        {
        //            DateTime start = DateTime.ParseExact(txtFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            //DateTime st=DateTime.Parse(
        //            DateTime end = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //            TimeSpan ts = end - start;

        //            DateRows();

        //            return (ts.TotalDays + 1).ToString();
        //        }
        //        return "0";
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message);
        //        return "0";
        //    }
        //}

        //#endregion

        //Create Date Rows
        //#region[Date Row]

        //protected void DateRows()
        //{
        //    try
        //    {
        //        if (txtFrom.Text != "" && txtTo.Text != "")
        //        {
        //            GrdLeaveApplication.DataSource = null;
        //            GrdLeaveApplication.DataBind();
        //            DataTable dtDate = new DataTable();
        //            dtDate.Columns.Add("Date");
        //            dtDate.Columns.Add("Full_Half");
        //            dtDate.Columns.Add("LeaveType");

        //            DateTime start = DateTime.ParseExact(txtFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            //DateTime st=DateTime.Parse(
        //            DateTime end = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //            for (DateTime s = start; s <= end; s = s.AddDays(1))
        //            {
        //                dtDate.Rows.Add((s.ToString("dd/MM/yyyy")).Replace('-', '/'), "1", "0");
        //            }

        //            GrdLeaveApplication.DataSource = dtDate;
        //            GrdLeaveApplication.DataBind();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message);
        //    }
        //}

        //#endregion

        //Calculate Total Datys
        //#region[Total Days]

        //protected void rbtnFullHalf_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lock (this)
        //        {
        //            double total = 0.0;
        //            RadioButtonList rbtnFull = new RadioButtonList();
        //            foreach (GridViewRow grw in GrdLeaveApplication.Rows)
        //            {
        //                rbtnFull = grw.Cells[1].FindControl("rbtFullHalf") as RadioButtonList;
        //                double full = 0.0;
        //                full = Convert.ToDouble(rbtnFull.SelectedValue.ToString());
        //                if (full == 1.0)
        //                    total = 1 + total;
        //                else if (full == 2.0)
        //                    total = 0.5 + total;
        //            }
        //            lblTotal.Text = total.ToString();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        //throw;
        //    }
        //}

        //#endregion

        //Save Event

        #region[Save Event]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    if (ddlStatus.SelectedValue == "0" || txtReason.Text == string.Empty)
                    {
                        msgBox.ShowMessage("Select status or Enter Reason !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        
                    }
                    else
                    {

                        Action("Save");
                    }
                    //}
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        ////for mail
        //#region SendeMailRegion

        //private string SendEmails()
        //{
        //    string stringResult = null;
        //    //string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
        //    //string password = Convert.ToString("logicpro@2017");

        //   string mailFrom = WebConfigurationManager.AppSettings["mail"];
        //   string password = WebConfigurationManager.AppSettings["password"];
        //    //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail


        //    string mailTo = Convert.ToString(txtEmail.Text);

        //    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
        //    email.To.Add(new System.Net.Mail.MailAddress(mailTo));
        //    email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

        //    email.Subject = "Staff Registration";
        //    email.SubjectEncoding = System.Text.Encoding.UTF8;
        //    email.Body = "Dear" + txtFirstName.Text + " " + txtLastName.Text + "  Your Registration is Successfully .  \n\n  Please Note Down Your Login Details  \n\n   UserName :" + txtUserName.Text + "\n \n   Password:" + txtPassword.Text + "\n\n Thank You For Registration !!:";// "Thanks for visiting our Hotel...Come again And Enjoy Your Service : \n\n    Your Total Reward Points Are :" + txtTotalReward.Text + " \n\n Thanks And Regards,\n\n " + companyNm+ "";

        //    //email.Body = "Dear " + txtFirstName.Text + "  " + txtLastName.Text + " Your Registration Submitted Successfully .  Please Note Down Your Login Details UserName : " + txtUserName.Text + " Password : " + txtPassword.Text.Trim() + " Thank You For Registraion !!";
        //    email.BodyEncoding = System.Text.Encoding.UTF8;
        //    email.Priority = System.Net.Mail.MailPriority.High;

        //    System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
        //    Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);//Add the Creddentials- use your own email id and password
        //    Smtp.Port = 587;   // Gmail works on this port
        //    Smtp.Host = "smtp.gmail.com";
        //    Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
        //    try
        //    {
        //        Smtp.Send(email);
        //        stringResult = "Email has been sent successfully...";
        //    }
        //    catch (Exception ex)
        //    {
        //        stringResult = ex.Message;
        //    }
        //    finally
        //    {
        //        Server.Transfer("Admin_Home.aspx");
        //    }
        //    return stringResult;
        //}

        //#endregion





        //Calculate Balance

        //public void CalculateBalance()
        //{
        //    DataView dvBalance = new DataView(ViewState["LeaveBalance"] as DataTable);

        //    DataView dvLeaveDetails = new DataView(ViewState["tempLeaveDetails"] as DataTable);
        //}


        //Perform Action for Leave Application
        #region[Perform Action]

        private void Action(string strAction)
        {
            try
            {
                count = 0;
                foreach (GridViewRow gvrow in GrdLeaveDetails.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    if (chk != null && chk.Checked)
                    {
                        
                        int id = Convert.ToInt32(GrdLeaveDetails.DataKeys[gvrow.RowIndex].Values["Id"].ToString());


                        SqlCommand cmd = new SqlCommand("SP_LeaveApplication", cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Action", "LeaveSanctioned");
                        cmd.Parameters.AddWithValue("@ApplicationID",id);
                        cmd.Parameters.AddWithValue("@OrgId",Convert.ToInt32(Session["OrgId"]));
                        cmd.Parameters.AddWithValue("@HRNote", txtReason.Text);
                        cmd.Parameters.AddWithValue("@LeaveStatus", ddlStatus.SelectedValue);
                        cn.Open();
                        int flag = cmd.ExecuteNonQuery();
                        cn.Close();
                        

                        //db.insert("update tblLeaveApplication set LeaveStatus='" + ddlStatus.SelectedValue.ToString() + "',HRNote='"+ txtReason.Text.Trim() + "' where ApplicationId='" + id + "'");
                        //objEWA.Action = strAction;

                        count++;

                        //string ucode = GrdLeaveDetails.DataKeys[gvrow.RowIndex].Values["User Code"].ToString();
                        //string Fromdate = GrdLeaveDetails.DataKeys[gvrow.RowIndex].Values["From Date"].ToString();
                        //string Todate = GrdLeaveDetails.DataKeys[gvrow.RowIndex].Values["To Date"].ToString();
                        //objEWA.UserCode = ucode.ToString();
                        //objEWA.ApplicationDate = lblApplicationDate.Text.Trim();

                        //objEWA.Reason = txtReason.Text.Trim();
                        //objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                        //objEWA.LeaveStatus = "waiting";
                        DataTable details = db.DbCon("select FirstName+' '+Middlename+' '+LastName as Name,Email,FromDate,TODATE,LeaveStatus Status,HRNote from tblLeaveApplication inner join " +
                            " tblEmployee on tblEmployee.UserCode=tblLeaveApplication.UserCode where ApplicationId=" + id + " and tblLeaveApplication.OrgId='" + Session["OrgId"].ToString() + "'");
                        //Email = db.getDbstatus_Value("select Email from tblEmployee where OrgId='" + Session["OrgId"].ToString() + "' and UserCode='" + ucode.ToString() + "'");
                        //Name = db.getDbstatus_Value("SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS   FullName from tblEmployee where OrgId='" + Session["OrgId"].ToString() + "' and UserCode='" + ucode.ToString() + "'");

                        
                        Email = details.Rows[0]["Email"].ToString();
                        Name = details.Rows[0]["Name"].ToString();
                        Status = details.Rows[0]["Status"].ToString();
                        FromDate = details.Rows[0]["FromDate"].ToString();
                        ToDate = details.Rows[0]["TODATE"].ToString();
                        string HRNote= details.Rows[0]["HRNote"].ToString();

                        SendEmails(FromDate, ToDate, Name, Email, Status,HRNote);

                        DataTable dt = db.DbCon("select * from Trailset1 where OrgId='" + Session["OrgId"].ToString() + "'");
                        DataTable dt1 = db.DbCon("select distinct md.UserCode, md.ApplicationId,TokenId,'Leave' as Subject, Reason as MessageContent,OrgName from tblUser inner join tblLeaveApplication md on md.UserCode = tblUser.UserCode inner join tblOrganization o on o.OrganizationId = tblUser.OrgId where  md.ApplicationId ='"+ id +"' AND md.OrgID = '" + Session["OrgId"].ToString() + "'");
                        
                        if (dt1.Rows.Count > 0 && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                SendPushNotification(dt1.Rows[i]["TokenId"].ToString(), "Leave " + Status, dt1.Rows[i]["OrgName"].ToString()
                             , dt.Rows[0]["SenderId"].ToString(), dt.Rows[0]["AppKey"].ToString());
                            }
                        }
                        //objEWA.dtLeaveDetails = ViewState["tempLeaveDetails"] as DataTable;

                        //count = db.getDb_Value("select  count(ApplicationId)   from  tblLeaveApplication where LeaveStatus='" + "waiting" + "' and   UserCode='" + objEWA.UserCode + "' and  OrgID='" + objEWA.OrgId + "'  ");
                        //if (count != 0)
                        //{
                        //    db.cnopen();
                        //    db.insert("update tblLeaveApplication set LeaveStatus='" + "Approved" + "' where UserCode='" + objEWA.UserCode + "' and  OrgID='" + objEWA.OrgId + "'");
                        //    //db.insert("insert into tbl_aproveleave values('" + objEWA.UserCode + "','" + System.DateTime.Now.ToString("dd/MM/yyyy") + "','" + txtFrom.Text + "','" + txtTo.Text + "','" + objEWA.TotalLeave + "','" + txtReason.Text + "','" + objEWA.OrgId + "','" + "Approved" + "')");
                        //    db.cnclose();
                        //}

                    }

                }
                if (count > 0)
                {
                    
                    msgBox.ShowMessage("Record Updated Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    
                    ClearControls();
                }
                else
                {
                    msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    
                }

                //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        //private void Action(string strAction)
        //{
        //    try
        //    {
        //        foreach (GridViewRow gvrow in GrdLeaveDetails.Rows)
        //        {
        //            CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
        //            if (chk != null && chk.Checked)
        //            {
        //                objEWA.Action = strAction;



        //                string ucode = GrdLeaveDetails.Rows[gvrow.RowIndex].Cells[9].Text;
        //                objEWA.UserCode = ucode.ToString();
        //                objEWA.ApplicationDate = lblApplicationDate.Text.Trim();
        //                objEWA.FromDate = txtFrom.Text.Trim();
        //                objEWA.ToDate = txtTo.Text.Trim();
        //                objEWA.TotalLeave = lblTotal.Text.Trim();
        //                objEWA.Reason = txtReason.Text.Trim();
        //                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
        //                objEWA.LeaveStatus = "waiting";

        //              Email = db.getDbstatus_Value("select Email from tblEmployee where OrgId='" + Session["OrgId"].ToString() + "' and UserCode='" + ucode.ToString() + "'");
        //              Name = db.getDbstatus_Value("SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS   FullName from tblEmployee where OrgId='" + Session["OrgId"].ToString() + "' and UserCode='" + ucode.ToString() + "'");

        //                objEWA.dtLeaveDetails = ViewState["tempLeaveDetails"] as DataTable;

        //                count = db.getDb_Value("select  count(ApplicationId)   from  tblLeaveApplication where LeaveStatus='" + "waiting" + "' and   UserCode='" + objEWA.UserCode + "' and  OrgID='" + objEWA.OrgId + "'  ");
        //                if (count != 0)
        //                {
        //                    db.cnopen();
        //                    db.insert("update tblLeaveApplication set LeaveStatus='" + "Approved" + "' where UserCode='" + objEWA.UserCode + "' and  OrgID='" + objEWA.OrgId + "'");
        //                    db.insert("insert into tbl_aproveleave values('" + objEWA.UserCode + "','" + System.DateTime.Now.ToString("dd/MM/yyyy") + "','" + txtFrom.Text + "','" + txtTo.Text + "','" + objEWA.TotalLeave + "','" + txtReason.Text + "','" + objEWA.OrgId + "','" + "Approved" + "')");
        //                    db.cnclose();
        //                }

        //            }

        //        }
        //            if (count > 0)
        //            {
        //                if (strAction == "Save")
        //                {
        //                    SendEmails();
        //                    msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);

        //                }
        //                else if (strAction == "Update")
        //                {
        //                    msgBox.ShowMessage("Record Updated Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
        //                }

        //                ClearControls();
        //            }
        //            else
        //            {
        //                if (strAction == "Save")
        //                {
        //                    msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //                }
        //                else if (strAction == "Update")
        //                {
        //                    msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
        //                }
        //            }

        //            //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        //        }

        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message);
        //    }
        //}

        #endregion


        private string SendEmails(string Fromdate, string Todate, string Name, string Email, string Status, string HRNote)
        {
            string stringResult = null;
            //string mailFrom = Convert.ToString("Schoolerp999@gmail.com");   //your own correct Gmail Address
            //string password = Convert.ToString("logicpro@2017");
            string mailFrom = WebConfigurationManager.AppSettings["mail"];
            string password = WebConfigurationManager.AppSettings["password"];
            //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

            string mailTo = Email.ToString();

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Leave "+ Status;
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body = "Dear "+Name+",\n Your Leave Is "+ Status + " From '"+ Fromdate + "' To '"+ Todate + "', \n   HR Note:"+ HRNote +"";
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);//Add the Creddentials- use your own email id and password
            Smtp.Port = 587;   // Gmail works on this port
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
            try
            {
                Smtp.Send(email);
                stringResult = "Email has been sent successfully...";
            }
            catch (Exception ex)
            {
                stringResult = ex.Message;
            }

            return stringResult;

        }

        private string SendPushNotification(string _deviceId, string _body, string _title, string SenderId, string AppKey)
        {
            string response;

            try
            {

                string serverKey = AppKey; // Something very long
                string senderId = SenderId;
                string deviceId = _deviceId; // Also something very long, 
                                             // got from android
                                             //string deviceId = "//topics/all";             // Use this to notify all devices, 
                                             // but App must be subscribed to 
                                             // topic notification
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = _body,
                        title = _title,
                        sound = "Enabled",
                        click_action = "7",
                        data = new
                        {
                            body = _body,
                            title = _title,
                            sound = "Enabled",
                            click_action = "7"
                        }
                    }

                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

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
                DataSet ds = objBL.LeaveDataBind_BL(objEWA);

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
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Grid Date Data To DataTable
        #region[Grid To DataTable]

        //protected void GridToDatatable(int LeaveId)
        //{
        //    try
        //    {
        //        DataTable dtLeaveDetails = new DataTable();
        //        dtLeaveDetails.Columns.Add("LeaveId");
        //        dtLeaveDetails.Columns.Add("Date");
        //        dtLeaveDetails.Columns.Add("Full_Half");
        //        dtLeaveDetails.Columns.Add("Paid_Unpaid");
        //        Label lblDate = new Label();
        //        RadioButtonList rbtnFull = new RadioButtonList();
        //        DropDownList rbtnPaid = new DropDownList();
        //        foreach (GridViewRow grw in GrdLeaveApplication.Rows)
        //        {
        //            lblDate = grw.Cells[0].FindControl("lblDate") as Label;
        //            //string date1 = lblDate.Text;
        //            DateTime dt = DateTime.ParseExact(lblDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            string date = dt.ToString("yyyy-MM-dd");
        //            rbtnFull = grw.Cells[1].FindControl("rbtFullHalf") as RadioButtonList;
        //            string full = rbtnFull.SelectedValue.ToString();
        //            rbtnPaid = grw.Cells[1].FindControl("ddlLeaveType") as DropDownList;
        //            string paid = rbtnPaid.SelectedValue.ToString();

        //            dtLeaveDetails.Rows.Add(LeaveId, date, full, paid);
        //        }
        //        ViewState["tempLeaveDetails"] = dtLeaveDetails;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //        //throw;
        //    }
        //}

        #endregion

        protected void GrdLeaveDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdLeaveDetails.PageIndex = e.NewPageIndex;
        }

        //protected void GrdLeaveApplication_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrdLeaveApplication.PageIndex = e.NewPageIndex;
        //}

        protected void GrdLeaveDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

   
    }
}
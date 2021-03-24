using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.HR;
using EntityWebApp.HR;
using DataAccessLayer;
using System.Data;
using EntityWebApp;
using BusinessAccessLayer;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace CMS.Forms.HR
{
    public partial class PostSalary : System.Web.UI.Page
    {

        //Objects

        #region[Objects]
        private BL_SalarySettings objBL = new BL_SalarySettings();
        private EWA_SalarySettings objEWA = new EWA_SalarySettings();

        private BindControl ObjHelper = new BindControl();
        public static int orgId;

        public static float PayGroupID;
        public static double txtBasicSalary = 0, txtGrossSalary = 0, txtDeductions = 0, txtNetSalary = 0;

        #endregion
        int OrgID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartment();
                CalendarExtender1.EndDate = DateTime.Today.Date;
            }
             OrgID = Convert.ToInt32(Session["OrgId"]);
            int AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);
            ViewState["OrgID"] = OrgID.ToString();
            if (OrgID == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
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

        // Bind Employee List
        #region [Bind Employee List]

        private void BindEmployeeList()
        {
            try
            {
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                objEWA.Action = "SelectEmployeeList";


                DataSet ds = objBL.BL_BindEmployeeList(objEWA);

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Show Empty Grid
        #region[Show Empty Grid]

        private void ShowEmptyGridView(GridView grid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(grid.Columns[0].HeaderText);
                dt.Columns.Add(grid.Columns[1].HeaderText);
                dt.Columns.Add(grid.Columns[2].HeaderText);

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grid.DataSource = dt;
                grid.DataBind();
                grid.Columns[2].Visible = false;
                grid.Rows[0].Cells[0].ColumnSpan = 2;
                foreach (GridViewRow row in grid.Rows)
                {
                    // row.Cells[1].Visible = false;vdcfd
                }
                grid.Rows[0].Cells[0].Text = "No Record found";
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
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Faculty Type Index Changed
        #region[Faculty Type Index Changed]

        protected void rbtnFacultyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Panel2.Visible = false;
                btnPostSalary.Visible = false;
                btnPrintSalarySlip.Visible = false;
                BindDesignation();
                // ShowEmptyGridView(grdEarning);
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
                Panel2.Visible = false;
                btnPostSalary.Visible = false;
                btnPrintSalarySlip.Visible = false;

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
                DDL_EmoloyeeName.DataSource = null;
                DDL_EmoloyeeName.DataBind();

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
                ViewState["UserCode"] = DDL_EmoloyeeName.SelectedValue;
                database db = new database();

              PayGroupID = db.getDb_Value("select PayGrpID from tblEmployee where UserCode='" + ViewState["UserCode"] + "'");

                if (PayGroupID > 0)
                {


                    BL_SalarySettings objBL = new BL_SalarySettings();
                    EWA_SalarySettings objEWA = new EWA_SalarySettings();
                    objEWA.Action = "GetPayDetails";
                    objEWA.OrgId = Convert.ToInt32(ViewState["OrgID"]);
                    objEWA.PayGrpID = Convert.ToInt32(PayGroupID);
                    
                    //int.Parse(PayGroupID).ToString();//Convert.ToInt32(ViewState["PayGrpID"]);
                    objEWA.UserCode = DDL_EmoloyeeName.SelectedValue;
                    objEWA.SalaryMonth = Convert.ToDateTime(txtMonth.Text).Month.ToString();
                    objEWA.PostedMonth = Convert.ToDateTime(txtMonth.Text).Month.ToString();
                    DataSet ds = objBL.GetSalarySettings(objEWA);


                    if(ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0)
                    {
                        Get_OrganizationDetails(Convert.ToInt32(ViewState["OrgID"]));
                        lblName.Text = ds.Tables[4].Rows[0][1].ToString();
                        lblDesignation.Text = DDL_Designation.SelectedItem.ToString();

                        lblName1.Text = ds.Tables[4].Rows[0][1].ToString();
                        lblDesignation1.Text = DDL_Designation.SelectedItem.ToString();
                        double GrossSalary = 0, Deductions = 0, NetSalary = 0, leaveDeductions=0;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Description");
                        dt.Columns.Add("Earnings");
                        dt.Columns.Add("Deductions");
                        DataRow dr;

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            dr = dt.NewRow();
                            dr[0] = "Basic Salary";
                            dr[1] = ds.Tables[3].Rows[0][0].ToString();
                            dr[2] = "";
                            dt.Rows.Add(dr);
                            txtBasicSalary = Convert.ToDouble(ds.Tables[3].Rows[0][0].ToString());
                            GrossSalary = GrossSalary + Convert.ToDouble(ds.Tables[3].Rows[0][0].ToString());
                        }

                        int i= 0;
                        while(ds.Tables[0].Rows.Count>i)
                        {
                            dr = dt.NewRow();
                            dr[0] = ds.Tables[0].Rows[i][0].ToString();
                            dr[1] = ds.Tables[0].Rows[i][1].ToString();
                            dr[2] = "";
                            GrossSalary = GrossSalary + Convert.ToDouble(ds.Tables[0].Rows[i][1].ToString());
                            i++;
                            dt.Rows.Add(dr);
                            
                        }

                        i = 0;
                        while (ds.Tables[1].Rows.Count > i)
                        {
                            dr = dt.NewRow();
                            dr[0] = ds.Tables[1].Rows[i][0].ToString();
                            dr[1] = "";
                            dr[2] = ds.Tables[1].Rows[i][1].ToString();
                            Deductions = Deductions + Convert.ToDouble(ds.Tables[1].Rows[i][1].ToString());
                            i++;
                            dt.Rows.Add(dr);
                            
                        }

                        int days = DateTime.DaysInMonth(Convert.ToDateTime(txtMonth.Text).Year, Convert.ToDateTime(txtMonth.Text).Month);
                        double leaveday = 0;

                        if (ds.Tables[2].Rows.Count > 0 && ds.Tables[2].Rows[0][0].ToString()!="")
                        {
                            leaveday = Convert.ToDouble(ds.Tables[2].Rows[0][0].ToString());
                            leaveDeductions = Convert.ToDouble((String.Format("{0:0.00}", (GrossSalary / days) * leaveday)).ToString());

                            
                            dr = dt.NewRow();
                            dr[0] = "Leave Deductions";
                            dr[1] = "";
                            dr[2] = leaveDeductions;
                            dt.Rows.Add(dr);
                            Deductions = Deductions + leaveDeductions;
                        }

                        lblWorkday.Text  = (days - leaveday).ToString();
                        lblAbsence.Text = leaveday.ToString();

                        lblWorkday1.Text = (days - leaveday).ToString();
                        lblAbsence1.Text = leaveday.ToString();

                        dr = dt.NewRow();
                        dr[0] = "Total";
                        dr[1] = GrossSalary;
                        dr[2] = Deductions;
                        dt.Rows.Add(dr);

                        NetSalary = GrossSalary - Deductions;

                        dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = "Net Salary";
                        dr[2] = NetSalary;
                        dt.Rows.Add(dr);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        GridView2.DataSource = dt;
                        GridView2.DataBind();

                        i = 0;
                        while(GridView1.Rows.Count>i)
                        {
                            GridView1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Center;
                            GridView1.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Center;

                            i++;
                        }

                        GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].BorderStyle = BorderStyle.None;
                        GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].Font.Bold = true;
                        GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].Font.Bold = true;
                        GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.DodgerBlue;

                        GridView1.Rows[GridView1.Rows.Count - 2].Cells[0].Font.Bold = true;
                        GridView1.Rows[GridView1.Rows.Count - 2].Cells[1].Font.Bold = true;
                        GridView1.Rows[GridView1.Rows.Count - 2].Cells[2].Font.Bold = true;
                        GridView1.Rows[GridView1.Rows.Count - 2].Cells[0].HorizontalAlign = HorizontalAlign.Center;

                        lblGross.Text = GrossSalary.ToString();
                        lblNet.Text = NetSalary.ToString();

                        txtGrossSalary = GrossSalary;
                        txtNetSalary = NetSalary;
                        txtDeductions = Deductions;


                        lblGross1.Text = GrossSalary.ToString();
                        lblNet1.Text = NetSalary.ToString();

                       

                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            lblPaymentDate.Text = DateTime.Now.Date.ToShortDateString();
                            lblBankName.Text = ds.Tables[4].Rows[0][0].ToString();
                            lblHolderName.Text  = ds.Tables[4].Rows[0][1].ToString();
                            lblAccountNumber.Text = ds.Tables[4].Rows[0][2].ToString();
                            lblBankBranch.Text = ds.Tables[4].Rows[0][3].ToString();

                            lblPaymentDate1.Text = DateTime.Now.Date.ToShortDateString();
                            lblBankName1.Text = ds.Tables[4].Rows[0][0].ToString();
                            lblHolderName1.Text = ds.Tables[4].Rows[0][1].ToString();
                            lblAccountNumber1.Text = ds.Tables[4].Rows[0][2].ToString();
                            lblBankBranch1.Text = ds.Tables[4].Rows[0][3].ToString();
                        }


                        Panel2.Visible = true;
                        btnPostSalary.Visible = true;
                        btnPrintSalarySlip.Visible = true;
                    }
                    else
                    {
                        GeneralErr("Record Not Found...!");
                    }

                  
                }
                else
                {
                    msgBox.ShowMessage("Please Apply Pay Scale...!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }

        #endregion

        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {
                BL_SuperAdmin objBL = new BL_SuperAdmin();
                EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

                DataSet ds = objBL.Get_OrganizationDetails(OrgID);
                
                lbl_CollegeName.Text = ds.Tables[0].Rows[0]["OrgName"].ToString();
                lbl_CollegeAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                lbl_CollegeName1.Text = ds.Tables[0].Rows[0]["OrgName"].ToString();
                lbl_CollegeAddress1.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                //Lbl_TrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();

            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw exp;
            }
        }

        //POST SALARY  
        private string SendPushNotification(string _deviceId, string _body, string _title, string SenderId, string AppKey)
        {
            string response;

            try
            {
                // From: https://console.firebase.google.com/project/x.y.z/settings/general/android:x.y.z

                // Projekt-ID: x.y.z
                // Web-API-Key: A...Y (39 chars)
                // App-ID: 1:...:android:...

                // From https://console.firebase.google.com/project/x.y.z/settings/
                // cloudmessaging/android:x,y,z
                // Server-Key: AAAA0...    ...._4

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
                        click_action = "6"
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
        #region [SALARY]
        protected void btnPostSalary_Click(object sender, EventArgs e)
        {


            BL_SalarySettings objBL = new BL_SalarySettings();
            EWA_SalarySettings objEWA = new EWA_SalarySettings();

            try
            {
                objEWA.EmployeeName = DDL_EmoloyeeName.SelectedItem.ToString();

                objEWA.UserCode = DDL_EmoloyeeName.SelectedValue.ToString();
                objEWA.Department = DDL_Department.SelectedItem.ToString();
                objEWA.Designation = DDL_Designation.SelectedItem.ToString();

                objEWA.SalaryMonth = txtMonth.Text.ToString();
                objEWA.PostedMonth = Convert.ToDateTime(txtMonth.Text).ToString();
                objEWA.BasicSalary = txtBasicSalary;

                objEWA.GorssSalary = txtGrossSalary;

                objEWA.TotalDeduction = txtDeductions;

                objEWA.LeaveDeduction = 0;//Convert.ToDouble(txtTotalLeave.Text);
                objEWA.NetSalary = txtNetSalary;
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                objEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);
                objEWA.Action = "SalarySlipSave";
                
                // CREATING DATA TABLE FOR GRID VIEW 

                DataTable DataSalaryEarning = new DataTable();
                
                DataSalaryEarning.Columns.Add("CategoryName");
                DataSalaryEarning.Columns.Add("ContentValue");
                DataSalaryEarning.Columns.Add("ContentAction");

                

                string CategoryName,ContentValue, ContentAction;

                //foreach (GridViewRow gvrow in GridView1.Rows)
                //{
                    
                //    CategoryName = GridView1.Rows[gvrow.RowIndex].Cells[0].Text;

                //    if (GridView1.Rows[gvrow.RowIndex].Cells[1].Text != null)
                //    {
                //        ContentValue = GridView1.Rows[gvrow.RowIndex].Cells[1].Text;
                //        DataSalaryEarning.Rows.Add(CategoryName, ContentValue, "Earning");
                //    }
                //    else
                //    {
                //        ContentValue = GridView1.Rows[gvrow.RowIndex].Cells[2].Text;
                //        DataSalaryEarning.Rows.Add(CategoryName, ContentValue, "Deduction");
                //    }
                //    i++;
                //}

                //foreach (GridViewRow gvrow in grdDeduction.Rows)
                //{

                //    CategoryName = grdDeduction.Rows[gvrow.RowIndex].Cells[1].Text;                     
                //    ContentValue = grdDeduction.Rows[gvrow.RowIndex].Cells[2].Text;

                //    DataSalaryEarning.Rows.Add(CategoryName, ContentValue,"Deduction");
                //    i++;
                //}


                int flag = objBL.SaveSalarySlip(objEWA, DataSalaryEarning);
                DataSet dss = new DataSet();
                DataSet dss1 = new DataSet();

                if (flag > 0)
                {
                    database db = new database();
                   
                    for(int i=0;(GridView1.Rows.Count - 2)>i;i++)
                    {

                        CategoryName = GridView1.Rows[i].Cells[0].Text;
                        string date = DateTime.Now.ToShortDateString();
                        if (GridView1.Rows[i].Cells[1].Text != "&nbsp;")
                        {

                            ContentValue = GridView1.Rows[i].Cells[1].Text;
                            ContentAction = "Earning";
                            
                            //db.insert("INSERT INTO tblPostSalaryContents (SalarySleepID,CategoryName,ContentValue,ContentAction,TransDate,AcademicYearId,IsActive) " +
                            //    "values('" + flag + "','" + CategoryName + "','" + ContentValue + "','" + ContentAction + "','" + date + "','" + Convert.ToInt32(Session["AcademicYearId"]) + "',1)");

                        }
                        else
                        {
                            ContentValue = GridView1.Rows[i].Cells[2].Text;
                            ContentAction = "Deduction";
                             //db.insert("INSERT INTO tblPostSalaryContents (SalarySleepID,CategoryName,ContentValue,ContentAction,TransDate,AcademicYearId,IsActive) " +
                            //    "values('" + flag + "','" + CategoryName + "','" + ContentValue + "','" + ContentAction + "','" + date + "','" + Convert.ToInt32(Session["AcademicYearId"]) + "',1)");

                        }
                        objEWA.ContentValue = ContentValue;
                        objEWA.ContentAction = ContentAction;
                        objEWA.SalarySleepID=flag.ToString();
                        objEWA.CategoryName = CategoryName;
                     dss1=   objBL.SaveSalaryContent(objEWA);

                    }
                    if (dss1.Tables[0].Rows.Count > 0)
                    {
                        if (dss1.Tables[0].Rows[0]["TokenId"].ToString() != "")
                        {
                            if (dss1.Tables[1].Rows[0]["SenderId"].ToString() != "")
                            {
                                SendPushNotification(dss1.Tables[0].Rows[0]["TokenId"].ToString(), dss1.Tables[0].Rows[0]["Subject"].ToString(), dss1.Tables[0].Rows[0]["OrgName"].ToString(), dss1.Tables[1].Rows[0]["SenderId"].ToString(), dss1.Tables[1].Rows[0]["AppKey"].ToString());
                            }
                        }
                    }


                    txtMonth.Text = string.Empty;
                    DDL_Department.ClearSelection();
                    rbtnFacultyType.ClearSelection();
                    DDL_Designation.ClearSelection();
                    DDL_EmoloyeeName.ClearSelection();
                    Panel2.Visible = false;
                    btnPostSalary.Visible = false;
                    btnPrintSalarySlip.Visible = false;

                    msgBox.ShowMessage("Salary Posted Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                }
                else
                {
                    if (objEWA.Action == "Save")
                    {
                        msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    if (objEWA.Action == "SalarySlipSave" && flag==0)
                    {
                        Panel2.Visible = false;
                        btnPostSalary.Visible = false;
                        btnPrintSalarySlip.Visible = false;
                        msgBox.ShowMessage("Salary already Posted !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    }
                    

                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }


        }


       
        #endregion

        protected void DDL_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            btnPostSalary.Visible = false;
            btnPrintSalarySlip.Visible = false;
            rbtnFacultyType.ClearSelection();
        }

        protected void btnPrintSalarySlip_Click(object sender, EventArgs e)
        {
            try
            {
                //string EmpCode = ViewState["UserCode"].ToString();
                //Session["EmpCode"] = ViewState["UserCode"].ToString();
                //Session["PayMonth"] = txtMonth.Text;

                //string url = "~/Forms/Reports/PrintSalarySlip.aspx?UserCode=" + EmpCode;
                //Response.Redirect(url,false);

                ExportGridToPDF();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void ExportGridToPDF()
        {

            string dt = System.DateTime.Now.ToString("MM/yyyy");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SalarySlip_" + Session["UserCode"].ToString() + "_" + dt + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            tbldata.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4,20f, 20f, 0f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }


    }
}
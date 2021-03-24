using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer.Admin;

//Pay Installments
namespace CMS.Forms.Admin
{
    public partial class CreateChallan : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        public static int orgId;
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        #endregion
        int OrgID = 0;
        //Page Load
        #region[Page Load]
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtReceiptDate.Attributes.Add("ReadOnly","True");
                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                orgId = Convert.ToInt32(Session["OrgId"]);
                if (!IsPostBack)
            {
                    txtAppDate_CalendarExtender.SelectedDate = DateTime.Today.Date;
                //OrgId = Session["OrgId"].ToString();
            }

                SqlCommand cmd1 = new SqlCommand("select Logo,OrgName from tblOrganization   where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'", cn);
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);
               // lblTrustName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
              //  lblTrustName1.Text = lblTrustName.Text;
                //string Photo = db.getDbstatus_Value("select Logo from tblOrganization  where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "' ");
                string Photo = ds1.Tables[0].Rows[0]["Logo"].ToString();


                //if (Photo != null && Photo != "")
                //{
                //    Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Logo"];

                //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                //    ImgTrust.ImageUrl = "data:image/png;base64," + base64String;
                //    ImgTrust1.ImageUrl = "data:image/png;base64," + base64String;
                //}
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

            
        }
        #endregion

        //Auto Complete
        #region[Auot Complete]
        [WebMethod]
        public static List<string> GetAutoCompleteData(string StudentNameId)
        {
            try
            {
                List<string> result = new List<string>();
                string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    //int OrgId = 1;
                    using (SqlCommand cmd = new SqlCommand("select DISTINCT FirstName,UserCode from tblStudent where FirstName LIKE '%'+@SearchText+'%' AND OrgId=" + orgId + "OR UserCode LIKE '%'+@SearchText+'%' AND OrgId=" + orgId, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@SearchText", StudentNameId);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            //result.Add(dr["FirstName"].ToString() +" - "+ dr["AdmissionId"].ToString());
                            result.Add(dr["UserCode"].ToString());
                            
                        }
                        if (result.Count == 0)
                        {
                            result.Add("No Result Found");
                        }
                        return result;
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        //Get Details
        #region[Get Details]
        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            txtStudentNameId.Text=txtStudentNameId.Text.Trim();
            try
            {
               int result= BindStudentGridData();
                if (result > 0)
                {
                    BindFeesPaidDetailsGrid();
                    btnSave.Visible = true;
                    btnGenerateReceipt.Enabled = false;
                    BindFeesPendingDetailsGrid();
                    Session["studentcode"] = lblStudentCode.Text;
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please check Student Code')", true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        private int BindStudentGridData()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();
                string strValue = txtStudentNameId.Text.Trim();
                lblStudentCode.Text = strValue;
                ViewState["StudentCode"] = strValue;
                Session["StudentReceiptCode"] = strValue;
                objEWA.OrgId = orgId;
                objEWA.StudentCode = strValue;

                DataSet ds = objBL.BindStudentDetails_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdStudent.DataSource = ds;
                    GrdStudent.DataBind();
                    int columncount = GrdStudent.Rows[0].Cells.Count;
                    GrdStudent.Rows[0].Cells.Clear();
                    GrdStudent.Rows[0].Cells.Add(new TableCell());
                    GrdStudent.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdStudent.Rows[0].Cells[0].Text = "No Records Found";
                    return ds.Tables[0].Rows.Count;
                }
                else
                {
                    GrdStudent.DataSource = ds;
                    GrdStudent.DataBind();
                   // lblCourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                    if (ds.Tables[0].Rows[0]["FeesId"].ToString() != null)
                    {
                        ViewState["FeesId"] = ds.Tables[0].Rows[0]["FeesId"].ToString();
                    }
                    else
                    {
                    }
                    return 1;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return 0;
            }
        }

        //StudentLinkButtonClick

        #region StudentLinkButtonClick

        protected void lnkBtnStudentName_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                // throw;
            }
        }

        #endregion StudentLinkButtonClick


        //StudentFeesPaidDetails



       
        private void BindFeesPaidDetailsGrid()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();
                string strValue = txtStudentNameId.Text;
                lblStudentCode.Text = strValue;

               
                objEWA.StudentCode = strValue;

                DataSet ds = objBL.BindStudentFeesPaidDetails_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdFeesPaidDetails.DataSource = ds;
                    GrdFeesPaidDetails.DataBind();
                    int columncount = GrdFeesPaidDetails.Rows[0].Cells.Count;
                    GrdFeesPaidDetails.Rows[0].Cells.Clear();
                    GrdFeesPaidDetails.Rows[0].Cells.Add(new TableCell());
                    GrdFeesPaidDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdFeesPaidDetails.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    DataView dView = ds.Tables[0].DefaultView;
                    dView.Sort= "ReceiptNo Desc";
                    GrdFeesPaidDetails.DataSource = dView;
                    GrdFeesPaidDetails.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //StudentFeesPendingDetails
        private void BindFeesPendingDetailsGrid()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();
                string strValue = txtStudentNameId.Text;
                lblStudentCode.Text = strValue;
                //if (ViewState["FeesId"] == null)
                //{
                //}

                //else
                //{
                //    objEWA.FeesId = ViewState["FeesId"].ToString();
                //}
                objEWA.StudentCode = strValue;

                DataSet ds = objBL.BindStudentFeesPendingDetails_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //GrdFeesDetails.DataSource = ds;
                    //GrdFeesDetails.DataBind();
                    //int columncount = GrdFeesDetails.Rows[0].Cells.Count;
                    //GrdFeesDetails.Rows[0].Cells.Clear();
                    //GrdFeesDetails.Rows[0].Cells.Add(new TableCell());
                    //GrdFeesDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    //GrdFeesDetails.Rows[0].Cells[0].Text = "No Records Found";
                    GrdFeesDetails.Visible = false;
                    btnSave.Visible = false;
                    btnGenerateReceipt.Visible = false;
                }
                else
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //if (!IsPostBack)
                    {
                        GrdFeesDetails.Visible = true;
                        Session["TotlAmt"] = ds.Tables[1].Rows[0]["TotalAmount"];
                        Session["TotlPendingAmt"] = ds.Tables[1].Rows[0]["TotalPendingAmount"];
                        GrdFeesDetails.DataSource = ds.Tables[0];
                        GrdFeesDetails.DataBind();

                        //foreach (GridViewRow row in GrdFeesDetails.Rows)
                        //{

                        //    DropDownList ddlremark = (DropDownList)row.FindControl("ddlremark");
                        //    ddlremark.DataSource = ds.Tables[1];
                        //    ddlremark.DataTextField = "Particular";
                        //    ddlremark.DataValueField = "Amount";
                        //    ddlremark.DataBind();
                        //    ddlremark.Items.Insert(0, new ListItem("All Fees", ds.Tables[0].Rows[0]["TotalAmount"].ToString()));
                        //    //ddlremark.DataBind();
                        //}

                    }
                    //if (Convert.ToDouble(ds.Tables[0].Rows[0]["TotalPendingAmount"]) == 0)
                    //{
                    //    btnSave.Enabled = false;
                    //}
                    //else
                    //{
                    //    btnSave.Enabled = true;
                    //}

                    btnSave.Visible = true;
                    btnGenerateReceipt.Visible = true;
                    // }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //StudentFeesInstallment
        protected void txtPaidAmount_OnTextChanged(object sender, System.EventArgs e)
            {
            double totalPaidAmount = 0.00;
            double PendingAmount = 0.00;

            foreach (GridViewRow row in GrdFeesDetails.Rows)
            {
                if (row != null)
                {
                        TextBox tbPayAmt = row.FindControl("txtPayamount") as TextBox;
                    Label lbTotalAmt = row.FindControl("lblTotalAmount") as Label;
                    Label lbTotalPendAmt = row.FindControl("lblTotalPendingAmount") as Label;
                    Label lbPaidAmt = row.FindControl("lblPaidAmount") as Label;
                    string txtPayAmt = tbPayAmt.Text.ToString();
                    if (txtPayAmt == "")
                        txtPayAmt = "0";
                    double _pendingAmt = Convert.ToDouble(lbTotalAmt.Text) - Convert.ToDouble(lbPaidAmt.Text);
                    if (Convert.ToDouble(txtPayAmt) > _pendingAmt)
                    {
                        //tbPayAmt.Text="0";
                        txtPayAmt = "0";
                    }
                        lbTotalPendAmt.Text = (_pendingAmt - Convert.ToDouble(txtPayAmt)).ToString();

                        CheckBox Particular = (CheckBox)row.FindControl("chkFees");
                    if (Particular.Checked)
                    {
                        if ((!txtPayAmt.Equals("") && txtPayAmt != null) && (!lbTotalAmt.Equals("") && lbTotalAmt != null))
                        {
                            double res;
                            if ((double.TryParse(txtPayAmt, out res)) && (double.TryParse(lbTotalAmt.Text, out res)))
                            {
                                if ((Convert.ToDouble(txtPayAmt)) <= (_pendingAmt))
                                {
                                    string _tbPayAmt = "0";
                                    if (tbPayAmt.Text != "")
                                        _tbPayAmt = tbPayAmt.Text;
                                    PendingAmount = _pendingAmt - Convert.ToDouble(_tbPayAmt);
                                    totalPaidAmount += Convert.ToDouble(txtPayAmt);
                                    lbltotalpay.Text = totalPaidAmount.ToString();
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please insert paid amount is less than amount!!!')", true);
                                    //msgBox.ShowMessage("Please insert paid amount is less than amount!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                    tbPayAmt.Text = "0";
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please enter numeric amount!!!')", true);
                                //msgBox.ShowMessage("Please enter numeric amount!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                tbPayAmt.Text = "0";
                            }
                        }
                    }
                    
                }
            }
        }
        private DataTable getFeesInfo()
        {

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new System.Data.DataColumn("feesDetailsId", typeof(decimal)));
            dt.Columns.Add(new System.Data.DataColumn("PaidAmount", typeof(decimal)));
            dt.Columns.Add(new System.Data.DataColumn("Particular", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PendingAmount", typeof(decimal)));
            foreach (GridViewRow row in GrdFeesDetails.Rows)
            {
                CheckBox Particular = (CheckBox)row.FindControl("chkFees");
                if (Particular.Checked)
                {
                    TextBox PaidAmount = (TextBox)row.FindControl("txtPayamount");
                    if( Convert.ToDouble( PaidAmount.Text)>0)
                    { 
                    Label PendingAmount = (Label)row.FindControl("lblTotalPendingAmount");
                    string feesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[2].ToString(); //(TextBox)row.FindControl("feesDetailsId");
                        if (feesDetailsId != "-1")
                        {
                            dr = dt.NewRow();
                            dr[0] = feesDetailsId;
                            dr[1] = PaidAmount.Text;
                            dr[2] = Particular.Text;
                            dr[3] = PendingAmount.Text;
                            dt.Rows.Add(dr); }
                    }
                    else
                    {
                        Label PendingAmount = (Label)row.FindControl("lblTotalPendingAmount");
                        string feesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[2].ToString(); //(TextBox)row.FindControl("feesDetailsId");
                        if (feesDetailsId != "-1")
                        {
                            dr = dt.NewRow();
                            dr[0] = feesDetailsId;
                            dr[1] = "0";
                            dr[2] = Particular.Text;
                            dr[3] = PendingAmount.Text;
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }

            return dt;
        }
        private DataTable getFeesInfo_Bus()
        {

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new System.Data.DataColumn("feesDetailsId", typeof(decimal)));
            dt.Columns.Add(new System.Data.DataColumn("PaidAmount", typeof(decimal)));
            dt.Columns.Add(new System.Data.DataColumn("Particular", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PendingAmount", typeof(decimal)));
            foreach (GridViewRow row in GrdFeesDetails.Rows)
            {
                CheckBox Particular = (CheckBox)row.FindControl("chkFees");
                if (Particular.Checked)
                {
                    TextBox PaidAmount = (TextBox)row.FindControl("txtPayamount");
                    if (Convert.ToDouble(PaidAmount.Text) > 0)
                    {
                        Label PendingAmount = (Label)row.FindControl("lblTotalPendingAmount");
                        string feesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[2].ToString(); //(TextBox)row.FindControl("feesDetailsId");
                        if (feesDetailsId == "-1")
                        {
                            dr = dt.NewRow();
                            dr[0] = feesDetailsId;
                            dr[1] = PaidAmount.Text;
                            dr[2] = Particular.Text;
                            dr[3] = PendingAmount.Text;
                            dt.Rows.Add(dr);
                        }

                    }
                    else
                    {
                        Label PendingAmount = (Label)row.FindControl("lblTotalPendingAmount");
                        string feesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[2].ToString(); //(TextBox)row.FindControl("feesDetailsId");
                        if (feesDetailsId == "-1")
                        {
                            dr = dt.NewRow();
                            dr[0] = feesDetailsId;
                            dr[1] = "0";
                            dr[2] = Particular.Text;
                            dr[3] = PendingAmount.Text;
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }

            return dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int txtFlag = 0;
                foreach (GridViewRow row in GrdFeesDetails.Rows)
                {
                    CheckBox Particular = (CheckBox)row.FindControl("chkFees");
                    if (Particular.Checked)
                    {
                        TextBox tbPayAmt = row.FindControl("txtPayamount") as TextBox;
                        Label lbTotalAmt = row.FindControl("lblTotalAmount") as Label;
                        Label lbTotalPendAmt = row.FindControl("lblTotalPendingAmount") as Label;
                        Label lbPaidAmt = row.FindControl("lblPaidAmount") as Label;
                        string txtPayAmt = tbPayAmt.Text.ToString();
                        if (txtPayAmt == "")
                            txtPayAmt = "0";
                        double _pendingAmt = Convert.ToDouble(lbTotalAmt.Text) - Convert.ToDouble(lbPaidAmt.Text);
                        if (Convert.ToDouble(txtPayAmt) > _pendingAmt)
                        {
                            txtFlag = 1;
                        }
                    }
                }

                if (txtFlag == 0)
                {
                    btnSave.Enabled = false;
                    EWA_PayFees objEWA = new EWA_PayFees();
                    BL_PayFees objBL = new BL_PayFees();
                    string strAction = "PayFeesInstallments";
                    objEWA.Action = strAction;
                    string StudentId1 = ViewState["StudentCode"].ToString();

                    foreach (GridViewRow row in GrdFeesDetails.Rows)
                    {

                        if (row != null)
                        {
                            //DropDownList ddlremark = row.FindControl("ddlremark") as DropDownList;
                            string FeesId = ViewState["FeesId"].ToString();

                            // TextBox txtParticular = (TextBox)GrdFeesDetails.Rows[0].FindControl("txtPayamount") as TextBox;

                            Label lbltotalAmt = row.FindControl("lblTotalAmount") as Label;

                            TextBox txtPayAmount = row.FindControl("txtPayamount") as TextBox;
                            if (txtPayAmount.Text == "")
                                txtPayAmount.Text = "0";
                            //Label lbltotalPaidAmt = footerRow.FindControl("lblTotalPaidAmount") as Label;
                            Label lblTotalPendingAmount = row.FindControl("lblTotalPendingAmount") as Label;
                            // do somthing with the text box textBox


                            decimal _pendingAmount = Convert.ToDecimal(Session["TotlPendingAmt"].ToString());
                            decimal totalAmt = Convert.ToDecimal(Session["TotlAmt"].ToString());
                            decimal totPaidAmount = Convert.ToDecimal(txtPayAmount.Text);
                            decimal totPendingAmount = Convert.ToDecimal(lblTotalPendingAmount.Text);
                            string UserId = Session["UserCode"].ToString();
                            //dtStudentFeesPaid.Rows.Add(StudentId, FeesId, FeesDetailsId, PaidAmount, ParticularAmount,UserId);
                            objEWA.StudentCode = ViewState["StudentCode"].ToString();
                            objEWA.FeesId = FeesId = ViewState["FeesId"].ToString();
                            objEWA.TotalAmount = totalAmt;
                            objEWA.TotalPaidAmount = totPaidAmount;
                            objEWA.TotalPendingAmount = _pendingAmount - totPaidAmount;
                            objEWA.UserId = UserId;
                            //objEWA.FeesDetailsId = ddlremark.SelectedValue.ToString();
                            DropDownList drppaymentmode = row.FindControl("ddlpaymentmode") as DropDownList;
                            objEWA.Paymentmode = drppaymentmode.Text;
                            //objEWA.remark = ddlremark.SelectedItem.Text;
                            //lblTypefees.Text = ddlremark.SelectedItem.Text;
                            //lblTypefeesAmount.Text = ddlremark.SelectedValue;

                            var todaysdate = DateTime.Today.Date.ToString("dd/MM/yyyy");

                            txtdate1.Text = todaysdate;
                            txtdate2.Text = todaysdate;
                            txtdate3.Text = todaysdate;
                            txtdate4.Text = todaysdate;

                            //lblDate1.Text = Convert.ToDateTime(txtReceiptDate.Text).ToString("dd/MM/yyyy");  //todaysdate;
                            objEWA.TransactionDate = Convert.ToDateTime(txtReceiptDate.Text);

                            //if (lblTypefees.Text == "All Fees" || lblTypefees.Text == "School Fees")
                            //{
                            //    imgClgLogo.Visible = true;
                            //    lblTrustName.Visible = true;
                            //}
                            //else
                            //{
                            //    imgClgLogo.Visible = false;
                            //    lblTrustName.Visible = false;
                            //}

                            //for print
                            StudentId1 = lblStudentCode.Text;
                            //TotalAmt1.Text = Convert.ToDecimal(lbltotalAmt.Text).ToString();
                            //float Totalpaid = db.getDb_Value("SELECT  sum(PaidAmount) FROM  tblStudentFeesPaid  where StudentId = " + txtStudentNameId.Text + " and feesdetailsid  = " + ddlremark.SelectedValue.ToString());


                            //PaidAmt1.Text = Convert.ToDecimal(txtPayAmount.Text).ToString();
                            //PendingAmt1.Text =(Convert.ToDecimal(lbltotalAmt.Text)- (Convert.ToDecimal(Totalpaid)+ Convert.ToDecimal(txtPayAmount.Text))).ToString(); //Convert.ToDecimal(lblTotalPendingAmount.Text).ToString();

                            //lblName.Text = db.getDbstatus_Value("SELECT        (FirstName + ' ' + MiddleName + ' ' + LastName) AS Name   FROM            tblStudent where UserCode='"+ StudentId1 + "'");
                            //lblName1.Text = lblName.Text;



                        }

                        //   msgBox.ShowMessage("Fees Installment Paid Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    DataTable co_br_cl = db.Displaygrid("SELECT     (FirstName + ' ' + MiddleName + ' ' + LastName) AS Name,co.CourseName,br.BranchName,cl.ClassName,GRNo,ay.AcademicYear  FROM            tblStudent  st  inner join tblCourse co ON co.CourseId=st.CourseId  inner join tblBranch br ON br.BranchId=st.BranchId  inner join tblClass cl ON cl.ClassId=st.ClassId inner join tblAcademicYear ay ON ay.AcademicYearId=st.AcademicYearId  where UserCode='" + StudentId1 + "'");

                    txtstudentname1.Text = co_br_cl.Rows[0]["Name"].ToString();
                    txtstudentname2.Text = txtstudentname1.Text;
                    txtstudentname3.Text = txtstudentname1.Text;
                    txtstudentname4.Text = txtstudentname1.Text;

                    string name= co_br_cl.Rows[0]["Name"].ToString();
                    string[] arrNM = name.Split(' ');

                    txtstudentname1.Text = arrNM[0];
                    txtstudentname2.Text = arrNM[0];
                    txtstudentname3.Text = arrNM[0];
                    txtstudentname4.Text = arrNM[0];

                    txtstudentname11.Text = "";
                    for (int i = 1; i < arrNM.Length; i++)
                    {
                        txtstudentname11.Text = txtstudentname11.Text + " " + arrNM[i];
                    }

                    txtstudentname12.Text = txtstudentname11.Text;
                    txtstudentname13.Text = txtstudentname11.Text;
                    txtstudentname14.Text = txtstudentname11.Text;


                    //lblCourse.Text = co_br_cl.Rows[0]["CourseName"].ToString();
                    // lblCourse1.Text = lblCourse.Text;

                    //lblAcademicYear.Text = co_br_cl.Rows[0]["AcademicYear"].ToString();
                    //lblAcademicYear1.Text = lblAcademicYear.Text;

                    txtacademicyear1.Text= co_br_cl.Rows[0]["AcademicYear"].ToString();
                    txtacademicyear2.Text = txtacademicyear1.Text;
                    txtacademicyear3.Text = txtacademicyear1.Text;
                    txtacademicyear4.Text = txtacademicyear1.Text;


                    //lblStd.Text = co_br_cl.Rows[0]["BranchName"].ToString();
                    //lblStd1.Text = lblStd.Text;

                    //lblDiv.Text = co_br_cl.Rows[0]["ClassName"].ToString();
                    //lblDiv1.Text = lblDiv.Text;

                    txtclass1.Text= co_br_cl.Rows[0]["BranchName"].ToString() + " (" + co_br_cl.Rows[0]["ClassName"].ToString() + ")";
                    txtclass2.Text = txtclass1.Text;
                    txtclass3.Text = txtclass1.Text;
                    txtclass4.Text = txtclass1.Text;

                    //lblGRNo.Text = co_br_cl.Rows[0]["GRNo"].ToString();
                    //lblGRNo1.Text = lblGRNo.Text;

                    txtrollno1.Text= co_br_cl.Rows[0]["GRNo"].ToString();
                    txtrollno2.Text = txtrollno1.Text;
                    txtrollno3.Text = txtrollno1.Text;
                    txtrollno4.Text = txtrollno1.Text;

                    txtcardno1.Text = co_br_cl.Rows[0]["GRNo"].ToString();
                    txtcardno2.Text = txtcardno1.Text;
                    txtcardno3.Text = txtcardno1.Text;
                    txtcardno4.Text = txtcardno1.Text;


                    DataTable dtFees = getFeesInfo();
                    DataTable dtFees_Bus = getFeesInfo_Bus();
                    if (dtFees.Rows.Count > 0 || dtFees_Bus.Rows.Count > 0)
                    {
                        int GroupReceiptNo = objBL.PayFeesInstallmentsAction_BL(objEWA, dtFees, dtFees_Bus);

                        if (GroupReceiptNo > 0)
                        {
                            if (strAction == "PayFeesInstallments")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees Installment Paid Successfully !!!')", true);
                            }

                            //ReceiptNo. Display
                            //lblReceiptNo.Text = GroupReceiptNo.ToString();
                            //lblReceiptNo1.Text = GroupReceiptNo.ToString();

                            string RN = "";
                            if(GroupReceiptNo<10)
                            {
                                RN = "00" + GroupReceiptNo.ToString();
                            }
                            else if (GroupReceiptNo < 100)
                            {
                                RN = "0" + GroupReceiptNo.ToString();
                            }
                            else
                            {
                                RN = GroupReceiptNo.ToString();
                            }

                            txtRN1.Text = RN;
                            txtRN2.Text = RN;
                            txtRN3.Text = RN;
                            txtRN4.Text = RN;
                            
                            float _tamount = db.getDb_Value("select  sum(Amount) from  tblFeesDetails  where FeesId =" + ViewState["FeesId"].ToString() + " ");
                            // lblTotalFees_Footer.Text = lblTotalFees_Footer1.Text = _tamount.ToString();

                            float _pamount = db.getDb_Value("select  isnull(sum(paidamount),0) from  tblstudentfeespaid  " +
                                " where studentid =" + txtStudentNameId.Text + "");

                            // lblPendingFees_Footer.Text = lblPendingFees_Footer1.Text = (_tamount - _pamount).ToString();

                            string RouteId = db.getDbstatus_Value("select isnull((select routeid from tblStudentRouteAssign where UserCode = " + txtStudentNameId.Text + "),0)");
                            float _pamount_bus = db.getDb_Value("select isnull((select sum(paidamount) from tblStudentBusFeesPaid   where  StudentId=" + txtStudentNameId.Text + "" +
                                "  and Studentrouteid=" + RouteId + "),0)");


                            float _tamount_bus = db.getDb_Value("select isnull((select amount from tblroute where RouteId=" + RouteId + "),0)");

                            _tamount = _tamount + _tamount_bus;
                            // lblTotalFees_Footer.Text = lblTotalFees_Footer1.Text = _tamount.ToString();
                            _pamount = _pamount + _pamount_bus;

                            //  lblPendingFees_Footer.Text = lblPendingFees_Footer1.Text = (_tamount - _pamount).ToString();
                            // lblTotalFees_Footer.Text = lblTotalFees_Footer1.Text = _tamount.ToString();

                            //Button Visible
                            lbltotalpay.Text = "0";
                            btnSave.Enabled = false;
                            btnGenerateReceipt.Enabled = true;
                            BindFeesPaidDetailsGrid();
                            // msgBox.ShowMessage("Fees Installment Paid Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);

                            GrdStudent.DataSource = null;
                            GrdStudent.DataBind();

                            GrdFeesDetails.DataSource = null;
                            GrdFeesDetails.DataBind();

                            GrdFeesPaidDetails.DataSource = null;
                            GrdFeesPaidDetails.DataBind();

                            
                            string query = "select remark Particular,'First/Second Term' Term,(select amount from tblfeesdetails where feesdetailsid=tblStudentFeesPaid.feesdetailsid) 'Total Fees',PaidAmount'Received Fees',PendingAmount 'Due Fees'" +
                    " from   tblStudentFeesPaid where studentid='" + StudentId1 + "' and GroupReceiptNo=" + GroupReceiptNo + "" +
                    "  union all " +
                    "select remark Particular,'First/Second Term' Term,TotalAmount 'Total Fees',PaidAmount'Received Fees',PendingAmount 'Due Fees'" +
                    " from   tblStudentBusFeesPaid where studentid='" + StudentId1 + "' and ReceiptNo=" + GroupReceiptNo + "";

                            DataTable gridDT = db.Displaygrid(query);
                            DataTable gridDT1 = new DataTable();

                            //gridDT1.Columns.Add("Particular");
                            //gridDT1.Columns.Add("Term");
                            //gridDT1.Columns.Add("Total Fees");
                            //gridDT1.Columns.Add("Received Fees");
                            //gridDT1.Columns.Add("Due Fees");

                            string[] arrFee = new string[7];
                            double OtherFee = 0.00, RF = 0.00, DRF = 0.00;
                            //DataRow dr;
                            for (int i = 0; i < gridDT.Rows.Count; i++)
                            {
                                //dr = gridDT1.NewRow();

                                //dr[0] = gridDT.Rows[i]["Particular"].ToString();
                                //dr[1] = gridDT.Rows[i]["Term"].ToString();
                                //dr[2] = gridDT.Rows[i]["Total Fees"].ToString();
                                //dr[3] = gridDT.Rows[i]["Received Fees"].ToString();
                                //dr[4] = gridDT.Rows[i]["Due Fees"].ToString();
                                DRF= Convert.ToDouble(gridDT.Rows[i]["Received Fees"].ToString());
                                switch (gridDT.Rows[i]["Particular"].ToString())
                                {
                                    case "Tuition Fee":
                                        txt11.Text = DRF.ToString();  // String.Format("{0:0.00}", DRF); 
                                        break;
                                    case "Interium Fee":
                                        txt12.Text = DRF.ToString();  // String.Format("{0:0.00}", DRF); 
                                        break;
                                    case "Development Fee":
                                        txt13.Text = DRF.ToString();  // String.Format("{0:0.00}", DRF); 
                                        break;
                                    case "University Fee":
                                        txt14.Text = DRF.ToString();  // String.Format("{0:0.00}", DRF); 
                                        break;
                                    case "Miscellneous Fee":
                                        txt15.Text = DRF.ToString();  // String.Format("{0:0.00}", DRF); 
                                        break;
                                    case "Deposit":
                                        txt16.Text = DRF.ToString();  // String.Format("{0:0.00}", DRF); 
                                        break;
                                    default:
                                        OtherFee= OtherFee + Convert.ToDouble(gridDT.Rows[i]["Received Fees"].ToString());
                                        break;
                                }

                                //TF = TF + Convert.ToDouble(gridDT.Rows[i]["Total Fees"].ToString());
                                RF = RF + Convert.ToDouble(gridDT.Rows[i]["Received Fees"].ToString());
                                //DF = DF + Convert.ToDouble(gridDT.Rows[i]["Due Fees"].ToString());

                                //gridDT1.Rows.Add(dr);
                            }

                            txt17.Text = OtherFee.ToString();  //String.Format("{0:0.00}", OtherFee); 
                            //dr = gridDT1.NewRow();

                            //dr[0] = "Total";
                            //dr[1] = "";
                            //dr[2] = TF;
                            //dr[3] = RF;
                            //dr[4] = DF;

                            //gridDT1.Rows.Add(dr);

                            //for(int i=0;i< arrFee.Length;i++)
                            //{
                            //    TextBox txt = (TextBox) pnlContents.FindControl("txt1" + (i + 1));
                            //    txt.Text = arrFee[i];
                            //}

                            txt21.Text = txt11.Text;
                            txt22.Text = txt12.Text;
                            txt23.Text = txt13.Text;
                            txt24.Text = txt14.Text;
                            txt25.Text = txt15.Text;
                            txt26.Text = txt16.Text;
                            txt27.Text = txt17.Text;

                            txt31.Text = txt11.Text;
                            txt32.Text = txt12.Text;
                            txt33.Text = txt13.Text;
                            txt34.Text = txt14.Text;
                            txt35.Text = txt15.Text;
                            txt36.Text = txt16.Text;
                            txt37.Text = txt17.Text;

                            txt41.Text = txt11.Text;
                            txt42.Text = txt12.Text;
                            txt43.Text = txt13.Text;
                            txt44.Text = txt14.Text;
                            txt45.Text = txt15.Text;
                            txt46.Text = txt16.Text;
                            txt47.Text = txt17.Text;


                            txttotal1.Text = RF.ToString();  // String.Format("{0:0.00}", RF);
                            txttotal2.Text = txttotal1.Text;
                            txttotal3.Text = txttotal1.Text;
                            txttotal4.Text = txttotal1.Text;


                            txtsumRS1.Text = RF.ToString();  // String.Format("{0:0.00}", RF);
                            txtsumRS2.Text = txtsumRS1.Text;
                            txtsumRS3.Text = txtsumRS1.Text;
                            txtsumRS4.Text = txtsumRS1.Text;

                            string RFWORD= ConvertToWords(RF.ToString());
                            string[] arrRF = RFWORD.Split(' ');

                            txtsumRSword1.Text = arrRF[0];
                            txtsumRSword2.Text = arrRF[0];
                            txtsumRSword3.Text = arrRF[0];
                            txtsumRSword4.Text = arrRF[0];

                            txtsumRSword11.Text = "";
                            for (int i=1;i<arrRF.Length;i++)
                            {
                                txtsumRSword11.Text = txtsumRSword11.Text + " " + arrRF[i];
                            }

                            txtsumRSword12.Text = txtsumRSword11.Text;
                            txtsumRSword13.Text = txtsumRSword11.Text;
                            txtsumRSword14.Text = txtsumRSword11.Text;


                            //gridHistory.DataSource = gridDT1;
                            //gridHistory.DataBind();

                            //gridHistory1.DataSource = gridDT1;
                            //gridHistory1.DataBind();

                            //gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[0].Font.Bold = true;
                            //gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[2].Font.Bold = true;
                            //gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[3].Font.Bold = true;
                            //gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[4].Font.Bold = true;

                            //gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[0].Font.Bold = true;
                            //gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[2].Font.Bold = true;
                            //gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[3].Font.Bold = true;
                            //gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[4].Font.Bold = true;

                        }


                        else
                        {
                            if (strAction == "Save")
                            {
                                // msgBox.ShowMessage("Unable to  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Unable to  Save !!!')", true);
                            }

                        }
                        //GrdFeesPaidDetails.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Try Again for valid Fees Installment!!!')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Pay fee less than Pending Fees!!!')", true);
                }

            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            //EWA_PayFees objEWA = new EWA_PayFees();
            //DL_PayFees objDL = new DL_PayFees();
            //objEWA.StudentCode = ViewState["StudentCode"].ToString();
            //DataSet ds = objDL.BindPaidReceiptReport(objEWA);
            try
            {
                string StudCode = ViewState["StudentCode"].ToString();

                Response.Redirect("~/Forms/Reports/PrintFeesReceipt.aspx?Code=" + StudCode);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayInstallmentFees.aspx");
        }
        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }



        #endregion

        protected void gridHistory_DataBound(object sender, EventArgs e)
        {
            //if (gridHistory.Rows.Count > 0)
            //{
            //    for (int i = 0; i < gridHistory.Rows.Count; i++)
            //    {
            //        //gridHistory.Rows[i].Cells[3].Text = Convert.ToDateTime(gridHistory.Rows[i].Cells[3].Text).ToShortDateString();
            //    }
            //}
        }


        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        private static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents    
                        endStr = "Paisa " + endStr;//Cents    
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }

        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }

        protected void GrdFeesPaidDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdFeesPaidDetails.PageIndex = e.NewPageIndex;
            BindFeesPaidDetailsGrid();
        }

        protected void ddlremark_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlremark = (DropDownList)sender;

            //Label1.Text = ddlremark.SelectedItem.Value;
            if (ddlremark.SelectedItem.Value != "0")
            {
                float amount = db.getDb_Value("select  Amount from  tblFeesDetails  where FeesDetailsId =" + ddlremark.SelectedItem.Value + " ");

                DataTable dt = db.Displaygrid("select tblstudentfeesPaid.FeesId,"+ amount + " Amount," + amount + "-sum(PaidAmount)PendingAmt " +
                " from tblstudentfeesPaid" +
                " where studentid ="+txtStudentNameId.Text+" and isnull(tblstudentfeesPaid.FeesDetailsId,0) =" + ddlremark.SelectedItem.Value + " " +
                " group by tblstudentfeesPaid.FeesDetailsId, tblstudentfeesPaid.FeesId");

                GridViewRow row = (GridViewRow)ddlremark.NamingContainer;


                Label lblAmount = (Label)row.FindControl("lblTotalAmount") as Label;
                Label lblTotalPendingAmount = (Label)row.FindControl("lblTotalPendingAmount") as Label;
                if (dt.Rows.Count > 0)
                {
                    lblAmount.Text = dt.Rows[0]["Amount"].ToString();
                    lblTotalPendingAmount.Text = dt.Rows[0]["PendingAmt"].ToString();
                }
                else
                {
                    lblAmount.Text = amount.ToString();
                    lblTotalPendingAmount.Text = amount.ToString();
                }
            }
            else
            {

                GridViewRow row = (GridViewRow)ddlremark.NamingContainer;


                Label lblAmount = (Label)row.FindControl("lblTotalAmount") as Label;
                Label lblTotalPendingAmount = (Label)row.FindControl("lblTotalPendingAmount") as Label;
                lblAmount.Text = GrdFeesDetails.DataKeys[row.RowIndex].Values[0].ToString();
                lblTotalPendingAmount.Text = GrdFeesDetails.DataKeys[row.RowIndex].Values[1].ToString();
            }
        }

        protected void ddlremark_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GrdFeesDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                Label lblTotalAmount = e.Row.FindControl("lblTotalAmount") as Label;
                Label lblPaidAmount = e.Row.FindControl("lblPaidAmount") as Label;
                //TextBox txtPayamount = e.Row.FindControl("txtPayamount") as TextBox;
                //CheckBox chkFees = e.Row.FindControl("chkFees") as CheckBox;
                if (Convert.ToDouble(lblPaidAmount.Text) == Convert.ToDouble(lblTotalAmount.Text))
                {
                    e.Row.Enabled = false;
                    //txtPayamount.Enabled = false;
                    //chkFees.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;
                    //txtPayamount.Enabled = true;
                    //chkFees.Enabled = true;
                }
            }
        }
        
    }
}
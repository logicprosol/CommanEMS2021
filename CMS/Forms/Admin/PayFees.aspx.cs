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
using System.Net.Mail;
using System.Web.Configuration;
using System.Globalization;

//Pay Fee

namespace CMS.Forms.Admin
{
    public partial class PayFees : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        public static int orgId;
        public static int acadmicYear;
        decimal totPaidAmount;
        Label userpass = new Label();
        string addid;
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                lblDate1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (Session["OrgId"].ToString() =="" || Session["OrgId"]==null || Session["OrgId"] == "0")
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    orgId =Convert.ToInt32( Session["OrgId"].ToString());
                    btnSave.Visible = false;
                    btnGenerateReceipt.Visible = false;
                    acadmicYear = Convert.ToInt32(ddlAcademicYearId.SelectedValue);// Convert.ToInt32(Session["AcademicYearId"]);
                    
                }
                SqlCommand cmd1 = new SqlCommand("select Logo,OrgName from tblOrganization   where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'", cn);
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);
                lblTrustName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
                lblTrustName1.Text = lblTrustName.Text;
                //string Photo = db.getDbstatus_Value("select Logo from tblOrganization  where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "' ");
                string Photo = ds1.Tables[0].Rows[0]["Logo"].ToString();


                if (Photo != null && Photo != "")
                {
                    Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Logo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    ImgTrust.ImageUrl = "data:image/png;base64," + base64String;
                    ImgTrust1.ImageUrl = "data:image/png;base64," + base64String;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Auto Complete Data
        #region[Auto Complete Data]

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
                    using (SqlCommand cmd = new SqlCommand("select DISTINCT FirstName,AdmissionId from tblAdmissionDetails where FirstName LIKE '%'+@SearchText+'%' AND Status='Pending for pay' AND OrgId=" + orgId + "OR AdmissionId LIKE '%'+@SearchText+'%'AND Status='Pending for pay' AND OrgId=" + orgId, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@SearchText", StudentNameId);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            //result.Add(dr["FirstName"].ToString() +" - "+ dr["AdmissionId"].ToString());
                            result.Add(dr["AdmissionId"].ToString());
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
        #region[get Datails]

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            try
            {
                float count = 0;
                txtStudentNameId.Text = txtStudentNameId.Text.Trim();
                count = db.getDb_Value("select isnull(count(StudentId),0) from   tblStudent where AdmissionId='" + txtStudentNameId.Text + "' ");
                if (count != 0 && count != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Addmission Already Completed !!!')", true);
                    
                    btnSave.Visible = false;
                    btnGenerateReceipt.Visible = false;
                }
                else
                {
                    
                    acadmicYear = Convert.ToInt32(ddlAcademicYearId.SelectedValue);
                    BindStudentGridData();
                    count = 0;
                    count = db.getDb_Value("select count(*) from tblFeesDetails inner join tblFees on tblFeesDetails.FeesId=tblFees.FeesId inner join tblAdmissionDetails on tblAdmissionDetails .Courseid=tblFees.CourseId and  tblAdmissionDetails.branchid=tblFees.branchid and tblAdmissionDetails .classid=tblFees.classid and tblAdmissionDetails .FeesCategory=tblFees.castecategoryid and  tblAdmissionDetails.orgid=tblFees.orgid and tblFees.academicyearid=" + ddlAcademicYearId.SelectedValue+" where tblAdmissionDetails.AdmissionID='"+txtStudentNameId.Text.Trim()+"'");
                    if (count != 0 && count != null)
                    {
                        GrdFeesDetails.Visible = true;
                        BindFeesDetailsGrid();
                        btnSave.Visible = true;
                        btnGenerateReceipt.Visible = false;
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnGenerateReceipt.Visible = false;
                        GrdFeesDetails.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Add Fees!!!')", true);
                        //msgBox.ShowMessage("Add Fees!!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                    }

                }
                //btnSave.Visible = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Fee Details
        #region[Bind Fee Details]

        private void BindFeesDetailsGrid()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();
                string strValue = txtStudentNameId.Text;
                    //Page.Request.Form["_name"].ToString();
                lblAdmissionId.Text = strValue;
                if (ViewState["FeesId"] == null)
                {
                    //objEWA.FeesId = ViewState["FeesId"].ToString();
                }

                else
                {
                    objEWA.FeesId = ViewState["FeesId"].ToString();
                }
                objEWA.AdmissionId = strValue;
                objEWA.AcadmicYearId = Convert.ToInt32(ddlAcademicYearId.SelectedValue.ToString());
                DataSet ds = objBL.BindStudentFeesDetails_BL(objEWA);
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
                    msgBox.ShowMessage("Please Create a fee group for Caste Category!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    GrdFeesDetails.Visible = false;
                    btnSave.Visible = false;
                }
                else
                {
                    GrdFeesDetails.DataSource = ds;
                    GrdFeesDetails.DataBind();
                    //TotalFees1.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                    //string paid = db.getDbstatus_Value("SELECT        tblStudentFeesPaid.PaidAmount FROM            tblStudentFeesPaid INNER JOIN tblStudent ON tblStudentFeesPaid.StudentId = tblStudent.UserCode    WHERE        (tblStudent.AdmissionId = '" + objEWA.AdmissionId + "') and   (tblStudent.OrgId  = '" + Convert.ToInt32(Session["OrgId"]) + "')  ");
                    //PaidFees1.Text = paid.ToString();
                     //PaidFees1.Text = totPaidAmount.ToString();
                    //btnSave.Visible = true;
                   // btnGenerateReceipt.Visible = true;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //double totalAmount = 0.00;
        //double totalPaidAmount = 0.00;

        //Fee Details
        #region[Fee Details]

        protected void GrdFeesDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        totalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            //        //totalPaidAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Paid Amount"));

            //    }
            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
            //        lblTotalAmount.Text = totalAmount.ToString();
            //        //Label lblTotalPaidAmount = (Label)e.Row.FindControl("lblTotalPaidAmount");
            //       // lblTotalPaidAmount.Text = totalPaidAmount.ToString();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }

        #endregion

        //Paid Amount
        #region[Paid Amount]

        protected void txtPaidAmount_OnTextChanged(object sender, System.EventArgs e)
        {
            try
            {
                double totalPaidAmount = 0.00;
                double PendingAmount = 0.00;
                if (ddlAcademicYearId.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Select Academic year')", true);
                    return;
                }
                foreach (GridViewRow row in GrdFeesDetails.Rows)
                {
                    if (row != null)
                    {
                        TextBox tbPayAmt = row.FindControl("txtPayamount") as TextBox;
                        Label lbTotalAmt = row.FindControl("lblTotalAmount") as Label;
                        Label lbTotalPendAmt = row.FindControl("lblTotalPendingAmount") as Label;
                        string txtPayAmt = tbPayAmt.Text.ToString();

                        if ((!txtPayAmt.Equals("") && txtPayAmt != null) && (!lbTotalAmt.Equals("") && lbTotalAmt != null))
                        {
                            double res;
                            if ((double.TryParse(txtPayAmt, out res)) && (double.TryParse(lbTotalAmt.Text, out res)))
                            {
                                if ((Convert.ToDouble(txtPayAmt)) <= (Convert.ToDouble(lbTotalAmt.Text)))
                                {
                                    PendingAmount = Convert.ToDouble(lbTotalAmt.Text) - Convert.ToDouble(tbPayAmt.Text);
                                    totalPaidAmount += Convert.ToDouble(txtPayAmt);
                                    lbltotalpay.Text = totalPaidAmount.ToString();
                                }
                                else
                                {
                                    msgBox.ShowMessage("Please insert paid amount is less than amount!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                    tbPayAmt.Text = "";
                                }
                            }
                            else
                            {
                                msgBox.ShowMessage("Please enter numeric amount!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                                tbPayAmt.Text = "";
                            }
                        }
                        lbTotalPendAmt.Text = Convert.ToString(PendingAmount);
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Student Grid Data
        #region[Bind Student Grid Data]

        private void BindStudentGridData()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();
                string strValue = txtStudentNameId.Text.Trim();
                    //Page.Request.Form["_name"].ToString();
                lblAdmissionId.Text = strValue;
               // Session["StudentReceiptCode"] = strValue;
                objEWA.OrgId = orgId;
                objEWA.AdmissionId = strValue;
                 addid = objEWA.AdmissionId;
                objEWA.AcadmicYearId = acadmicYear;
                DataSet ds = objBL.BindStudentData_BL(objEWA);

                if (ds.Tables.Count == 0 || ds == null)
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //GrdStudent.DataSource = ds;
                    //GrdStudent.DataBind();
                    //int columncount = GrdStudent.Rows[0].Cells.Count;
                    //GrdStudent.Rows[0].Cells.Clear();
                    //GrdStudent.Rows[0].Cells.Add(new TableCell());
                    //GrdStudent.Rows[0].Cells[0].ColumnSpan = columncount;
                    //GrdStudent.Rows[0].Cells[0].Text = "No Records Found";
                    //msgBox.ShowMessage("Please Create a fee group for Caste Category!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Create a fee group for Caste Category')", true);
                    GrdFeesDetails.Visible = false;
                    btnSave.Visible = false;
                    btnGenerateReceipt.Visible = false;
                }
                else
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "-1")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please check AdmissionID')", true);
                        GrdFeesDetails.Visible = false;
                        btnSave.Visible = false;
                        btnGenerateReceipt.Visible = false;
                    }
                    else
                    { 
                        GrdStudent.DataSource = ds;
                        GrdStudent.DataBind();


                        //for Print code 
                        //Studentname1.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                        //Course1.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                        //Branch1.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        //class1.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();


                        //string usercod = db.getDbstatus_Value("SELECT        Whe.StudentId FROM            tblStudentFeesPaid AS Whe INNER JOIN tblStudent ON Whe.StudentId = tblStudent.UserCode WHERE        (tblStudent.OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "  ')");
                        //WHERE         (tblStudent.OrgId  = '" + Convert.ToInt32(Session["OrgId"]) + "') AND (tblStudentFeesPaid.StudentId='" + objEWA.AdmissionId + "')            

                        //if (PaidFees1.Text != "0")
                        //{
                        //    string paid = db.getDbstatus_Value("SELECT        tblStudentFeesPaid.PaidAmount FROM            tblStudentFeesPaid INNER JOIN tblStudent ON tblStudentFeesPaid.StudentId = tblStudent.UserCode    WHERE        (tblStudent.AdmissionId = '" + objEWA.AdmissionId + "') and   (tblStudent.OrgId  = '" + Convert.ToInt32(Session["OrgId"]) + "')  ");
                        //    PaidFees1.Text = paid.ToString();
                        //}

                        //PaidFees1.Text = "0";
                        // TotalFees1.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        // PaidFees1.Text = txtPayamount.Text;

                        GrdFeesDetails.Visible = true;
                        btnSave.Visible = true;
                        btnGenerateReceipt.Visible = true;

                        if (ds.Tables[0].Rows[0]["FeesId"].ToString() != null)
                        {
                            ViewState["FeesId"] = ds.Tables[0].Rows[0]["FeesId"].ToString();
                        }
                        else
                        {
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

        #endregion

        //Save Button
        #region[Save Button]

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Save Student

                //Added by Ashwini 6-oct-2020
                foreach (GridViewRow row in GrdFeesDetails.Rows)
                {
                    CheckBox Particular = (CheckBox)row.FindControl("chkFees");
                    if (Particular.Checked)
                    {
                        TextBox txtPayFees = row.FindControl("txtPayamount") as TextBox;
                        Label lblPendingAmt = row.FindControl("lblTotalPendingAmount") as Label;
                        Label lblTotalAmt = row.FindControl("lblTotalAmount") as Label;
                        string lblpendingAmt1 = lblPendingAmt.Text;
                        string txtpayFees = txtPayFees.Text;
                        double dblPendAmt = lblpendingAmt1 != "" ? Convert.ToDouble(lblpendingAmt1) : 0;
                        double dblpayfees = txtpayFees != "" ? Convert.ToDouble(txtpayFees) : 0;
                        double dbltotalAmt = lblTotalAmt.Text != "" ? Convert.ToDouble(lblTotalAmt.Text) : 0;

                        if (dblpayfees <= 0)
                        {
                            // ShwMsg.Visible = true;
                            // ShwMsg.ForeColor = System.Drawing.Color.Red;
                            //  ShwMsg.Text = "Please Enter Pay Fees Amount !!!";
                            msgBox.ShowMessage("Please insert paid amount !!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            txtPayFees.Focus();
                            return;
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Pay Fees Amount !!!')", true);

                        }
                        if (dblPendAmt < dblpayfees && dbltotalAmt < dblpayfees)
                        {
                            //ShwMsg.Visible = true;
                            //ShwMsg.ForeColor = System.Drawing.Color.Red;
                            // ShwMsg.Text = "Please Enter Valid Pay Fees !!!";
                            // txtPayFees.Focus();
                            msgBox.ShowMessage("Please insert paid amount is less than amount!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            txtPayFees.Text = "";
                            return;
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Pay Fees Amount !!!')", true);

                        }
                    }

                }
                GetStudentCode();
                SaveStudentAdmissionDetails();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //get Student Code
        #region[Get Student Code]

        private void GetStudentCode()
        {
            try
            {
                EWA_Student objEWA = new EWA_Student();
                BL_Student objBL = new BL_Student();
                objEWA.OrgId = orgId;
                DataSet Studentds = objBL.GetStudentCode_BL(objEWA);
                string StudentId = Studentds.Tables[0].Rows[0][0].ToString();
                ViewState["StudentCode"] = StudentId;
                Session["StudentReceiptCode"] = ViewState["StudentCode"];
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Save Stu Admission Details
        #region[Save Student Addmission Details]

        private void SaveStudentAdmissionDetails()
        {
            try
            {
                EWA_Student objEWA = new EWA_Student();
                BL_Student objBL = new BL_Student();
                objEWA.AdmissionID = lblAdmissionId.Text;
                DataSet StudentDetailsDs = objBL.GetStudentAdmissionDetails_BL(objEWA);

                //string UserCode = ViewState["StudentCode"].ToString();
                //string StudentCode = objEWA.OrgId + StudentId;
                string strAction = "Save";
                objEWA.Action = strAction;
                objEWA.UserCode = ViewState["StudentCode"].ToString();
                objEWA.AdmissionID = StudentDetailsDs.Tables[0].Rows[0]["AdmissionId"].ToString();
                objEWA.OrgId = orgId;
                objEWA.AdmissionDate = System.DateTime.Now.Date;
                objEWA.CourseId = StudentDetailsDs.Tables[0].Rows[0]["CourseId"].ToString();
                objEWA.BranchId = StudentDetailsDs.Tables[0].Rows[0]["BranchId"].ToString();
                objEWA.FirstName = StudentDetailsDs.Tables[0].Rows[0]["FirstName"].ToString();
                objEWA.MiddleName = StudentDetailsDs.Tables[0].Rows[0]["MiddleName"].ToString();
                objEWA.LastName = StudentDetailsDs.Tables[0].Rows[0]["LastName"].ToString();
                objEWA.Gender = StudentDetailsDs.Tables[0].Rows[0]["Gender"].ToString();
                objEWA.BirthDate = Convert.ToDateTime(StudentDetailsDs.Tables[0].Rows[0]["BirthDate"]);
                objEWA.BirthPlace = StudentDetailsDs.Tables[0].Rows[0]["BirthPlace"].ToString();

                //ContactDetails

                #region ContactDetailsRegion

                objEWA.Address = StudentDetailsDs.Tables[0].Rows[0]["Address1"].ToString();
                objEWA.Country = StudentDetailsDs.Tables[0].Rows[0]["Country"].ToString();
                objEWA.State = StudentDetailsDs.Tables[0].Rows[0]["State"].ToString();
                objEWA.District = StudentDetailsDs.Tables[0].Rows[0]["District"].ToString();
                objEWA.Taluka = StudentDetailsDs.Tables[0].Rows[0]["Taluka"].ToString();
                objEWA.City = StudentDetailsDs.Tables[0].Rows[0]["City"].ToString();
                objEWA.PinCode = StudentDetailsDs.Tables[0].Rows[0]["Pin_Code"].ToString();
                objEWA.Mobile = StudentDetailsDs.Tables[0].Rows[0]["Mobile"].ToString().Trim();
                objEWA.EMail = StudentDetailsDs.Tables[0].Rows[0]["EMail"].ToString().Trim();

                #endregion ContactDetailsRegion

                //OtherDetails

                #region OtherDetailsRegion

                objEWA.Nationality = StudentDetailsDs.Tables[0].Rows[0]["Nationality"].ToString();
               // objEWA.MotherTongue = StudentDetailsDs.Tables[0].Rows[0]["MotherTongue"].ToString();
                //objEWA.MaritalStatus = StudentDetailsDs.Tables[0].Rows[0]["MarriedStatus"].ToString();
                objEWA.BloodGroup = StudentDetailsDs.Tables[0].Rows[0]["BloodGroup"].ToString();
                objEWA.Religion = StudentDetailsDs.Tables[0].Rows[0]["Religion"].ToString();
                objEWA.CasteCategoryId = StudentDetailsDs.Tables[0].Rows[0]["CasteCategoryId"].ToString();
                //objEWA.Caste = StudentDetailsDs.Tables[0].Rows[0]["Caste"].ToString();
                objEWA.Subcaste = StudentDetailsDs.Tables[0].Rows[0]["SubCaste"].ToString();
                objEWA.Handicaped = StudentDetailsDs.Tables[0].Rows[0]["Handicap"].ToString();
                //objEWA.ConveyanceUse = StudentDetailsDs.Tables[0].Rows[0]["ConveyanceUse"].ToString();

                //objEWA.SportId = StudentDetailsDs.Tables[0].Rows[0]["SportId"].ToString();
                objEWA.AdharNo = StudentDetailsDs.Tables[0].Rows[0]["AdharNo"].ToString();
                #endregion 

                //Parent Tab

                #region ParentInfoRegion

                objEWA.ParentName = StudentDetailsDs.Tables[0].Rows[0]["ParentName"].ToString();
                objEWA.MotherName = StudentDetailsDs.Tables[0].Rows[0]["MotherName"].ToString();
                //objEWA.ParentAddress = StudentDetailsDs.Tables[0].Rows[0]["ParentAddress1"].ToString();
                //objEWA.ParentCountry = StudentDetailsDs.Tables[0].Rows[0]["ParentCountry"].ToString();
                //objEWA.ParentState = StudentDetailsDs.Tables[0].Rows[0]["ParentState"].ToString();
                //objEWA.ParentDistrict = StudentDetailsDs.Tables[0].Rows[0]["ParentDistrict"].ToString();
                //objEWA.ParentTaluka = StudentDetailsDs.Tables[0].Rows[0]["ParentTaluka"].ToString();
                //objEWA.ParentCity = StudentDetailsDs.Tables[0].Rows[0]["ParentCity"].ToString();
                //objEWA.ParentPinCode = StudentDetailsDs.Tables[0].Rows[0]["ParentPinCode"].ToString();
                //objEWA.ParentMobile = StudentDetailsDs.Tables[0].Rows[0]["ParentMobile"].ToString().Trim();
                //objEWA.ParentEmail = StudentDetailsDs.Tables[0].Rows[0]["ParentEmail"].ToString().Trim();
                //objEWA.ParentProfession = StudentDetailsDs.Tables[0].Rows[0]["ParentProfession"].ToString();
               // objEWA.AnnualIncome = StudentDetailsDs.Tables[0].Rows[0]["AnnualIncome"].ToString();

                #endregion 

                //Gurdian Tab

                #region GuardianDetailsRegion

                //objEWA.ResidentType = StudentDetailsDs.Tables[0].Rows[0]["ResidentType"].ToString();
                ////objEWA.ResidanceState = StudentDetailsDs.Tables[0].Rows[0]["ResidanceState"].ToString();
                //objEWA.GuardianName = StudentDetailsDs.Tables[0].Rows[0]["GuardianName"].ToString();
                objEWA.Relation = StudentDetailsDs.Tables[0].Rows[0]["Relation"].ToString();
                //objEWA.GuardianAddress = StudentDetailsDs.Tables[0].Rows[0]["GuardianAddress1"].ToString();
                //objEWA.GuardianCountry = StudentDetailsDs.Tables[0].Rows[0]["GuardianCountry"].ToString();
                //objEWA.GuardianState = StudentDetailsDs.Tables[0].Rows[0]["GuardianState"].ToString();
                //objEWA.GuardianDistrict = StudentDetailsDs.Tables[0].Rows[0]["GuardianDistrict"].ToString();
                //objEWA.GuardianTaluka = StudentDetailsDs.Tables[0].Rows[0]["GuardianTaluka"].ToString();
                //objEWA.GuardianCity = StudentDetailsDs.Tables[0].Rows[0]["GuardianCity"].ToString();
                //objEWA.GuardianPinCode = StudentDetailsDs.Tables[0].Rows[0]["GuardianName"].ToString();
                //objEWA.GuardianMobile = StudentDetailsDs.Tables[0].Rows[0]["GuardianMobile"].ToString();
                //objEWA.GuardianEmail = StudentDetailsDs.Tables[0].Rows[0]["GuardianEmail"].ToString();

                #endregion 

                //Previous History

                #region PreviousAcademicRegion

                //objEWA.LastClass = StudentDetailsDs.Tables[0].Rows[0]["LastClass"].ToString();
                objEWA.LastInstitute = StudentDetailsDs.Tables[0].Rows[0]["LastInstitute"].ToString();
                objEWA.QualifiedExam = StudentDetailsDs.Tables[0].Rows[0]["QualifiedExam"].ToString();
                //objEWA.Board = StudentDetailsDs.Tables[0].Rows[0]["Board"].ToString();
                //objEWA.SeatNo = StudentDetailsDs.Tables[0].Rows[0]["SeatNo"].ToString();
                //objEWA.PassingMonth = StudentDetailsDs.Tables[0].Rows[0]["PassingMonth"].ToString();
                //objEWA.PassingYear = StudentDetailsDs.Tables[0].Rows[0]["PassingYear"].ToString();
                //objEWA.Percentage = StudentDetailsDs.Tables[0].Rows[0]["Percentage"].ToString();
                //objEWA.Result = StudentDetailsDs.Tables[0].Rows[0]["Result"].ToString();
                
               // objEWA.Eligibility = StudentDetailsDs.Tables[0].Rows[0]["Eligibility"].ToString();

                //objEWA.Gap = StudentDetailsDs.Tables[0].Rows[0]["Gap"].ToString();
                //objEWA.TcNo = StudentDetailsDs.Tables[0].Rows[0]["TcNo"].ToString();
                
               // objEWA.FeesConcession = StudentDetailsDs.Tables[0].Rows[0]["FeesConcession"].ToString();
               // objEWA.ConcessionType = StudentDetailsDs.Tables[0].Rows[0]["ConcessionType"].ToString();

                #endregion 

                //Account Details

                #region BankDetailsRegion

                //objEWA.BankName = StudentDetailsDs.Tables[0].Rows[0]["BankName"].ToString();
                //objEWA.BankBranch = StudentDetailsDs.Tables[0].Rows[0]["Branch"].ToString();
                //objEWA.IFSCCode = StudentDetailsDs.Tables[0].Rows[0]["IFSCCode"].ToString();
                //objEWA.BankAccountNo = StudentDetailsDs.Tables[0].Rows[0]["BankAccountNo"].ToString();
                

                #endregion BankDetailsRegion
                //float id = db.getDb_Value("select AcademicYearId from tblAcademicYear where IsCurrentYear='" + "True " + "' and  OrgId='" + Convert.ToString(objEWA.OrgId) + "'");
                objEWA.Status = "Admission Completed";
                objEWA.AcademicYearId = ddlAcademicYearId.SelectedValue.ToString();
                objEWA.IsActive = true;

                //Insert data into StudentClassDiv Table
                objEWA.ClassId = StudentDetailsDs.Tables[0].Rows[0]["ClassId"].ToString();

                //Insert data into User Table
                objEWA.UserType = "Student";
                //Duplication Problem
                // objEWA.UserName = StudentDetailsDs.Tables[0].Rows[0]["UserName"].ToString();
                //Save Student Unique User Name
                objEWA.UserName = ViewState["StudentCode"].ToString();
                objEWA.Password = StudentDetailsDs.Tables[0].Rows[0]["AdmissionId"].ToString();
                objEWA.Role = "Student";



                userpass.Text = objEWA.Password;

                //StudentFeesDetails

                //DataTable dtStudentFeesPaid = new DataTable();
                //dtStudentFeesPaid.Columns.Add("StudentId");
                //dtStudentFeesPaid.Columns.Add("FeesId");
                //dtStudentFeesPaid.Columns.Add("FeesDetailsId");
                //dtStudentFeesPaid.Columns.Add("PaidAmount");
                //dtStudentFeesPaid.Columns.Add("PendingAmount");
                //dtStudentFeesPaid.Columns.Add("UserId");

                string studId=string.Empty;
                string FeesId=string.Empty;
                string User=string.Empty;
                decimal totalAmt=0;
                decimal totPaidAmount=0;
                decimal totPendingAmount=0;
                int Feesdetailsid=0;
                string UserId=string.Empty;
                DateTime currentDate = System.DateTime.Now.Date;
                decimal FinalTotalAmt = 0;
                foreach (GridViewRow row in GrdFeesDetails.Rows)
                {
                    if (row != null)
                    {
                         studId= ViewState["StudentCode"].ToString();
                         FeesId = ViewState["FeesId"].ToString();
                         User = Session["UserCode"].ToString();
                      
                        CheckBox ddlremark = row.FindControl("ddlremark") as CheckBox;
                        // TextBox txtParticular = (TextBox)GrdFeesDetails.Rows[0].FindControl("txtPayamount") as TextBox;
                        Label lbltotalAmt = row.FindControl("lblTotalAmount") as Label;
                        Label lblFeesdetailsid= row.FindControl("lblFeesDetailId") as Label;
                        TextBox txtPayAmount = row.FindControl("txtPayamount") as TextBox;
                        //Label lbltotalPaidAmt = footerRow.FindControl("lblTotalPaidAmount") as Label;
                        Label lblTotalPendingAmount = row.FindControl("lblTotalPendingAmount") as Label;
                        // do somthing with the text box textBox
                        // string FeesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[0].ToString();
                        // totalAmt = Convert.ToDecimal(lbltotalAmt.Text);
                        FinalTotalAmt= FinalTotalAmt + Convert.ToDecimal(lbltotalAmt.Text);
                        totPaidAmount = Convert.ToDecimal(txtPayAmount.Text);
                         totPendingAmount = Convert.ToDecimal(lblTotalPendingAmount.Text);
                         Feesdetailsid = Convert.ToInt32(lblFeesdetailsid.Text);
                         UserId = Session["UserCode"].ToString();
                        //dtStudentFeesPaid.Rows.Add(StudentId, FeesId, FeesDetailsId, PaidAmount, ParticularAmount,UserId);
                        objEWA.UserCode = ViewState["StudentCode"].ToString();
                        objEWA.FeesId = FeesId = ViewState["FeesId"].ToString();
                        objEWA.TotalAmount = totalAmt;
                        objEWA.TotalPaidAmount = totPaidAmount;
                        objEWA.TotalPendingAmount = totPendingAmount;
                        objEWA.UserId = UserId;
                        //objEWA.FeesDetailsId = ddlremark.SelectedValue.ToString();
                    }

                }
                //Added by Ashwini 25-sep-2020
                //
                db.insert("INSERT INTO [dbo].[tblStudentFeesPaid] ([StudentId],[FeesId],[TotalAmount],[PaidAmount],[PendingAmount],[UserId],[TransDate],[FeesDetailsId],[GroupReceiptNo]) VALUES ('" + studId + "','" + FeesId + "','" + FinalTotalAmt + "',0,'" + FinalTotalAmt + "','" + UserId + "','" + currentDate + "','" + Feesdetailsid + "',0 )");
                //

                DataTable dtFees = getFeesInfo();

                if (dtFees.Rows.Count > 0)
                {
                    if (Session["StudFees"] != null)
                    {
                        if (Session["StudFees"].ToString() == (objEWA.FeesId + objEWA.UserCode))
                        {
                            //msgBox.ShowMessage("Record already present !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Admission Completed Successfully ')", true);

                            return;
                        }
                    }
                    else
                    {
                        Session["StudFees"] = (objEWA.FeesId + objEWA.UserCode);
                    }

                    int GroupReceiptNo = objBL.Action_BL(objEWA, dtFees);//objBL.Action_BL(objEWA);

                    if (GroupReceiptNo > 0)
                    {
                        if (strAction == "Save")
                        {
                            // SendEmails();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Admission Completed Successfully !!!')", true);

                        }

                        //lblTrustName.Text= db.getDbstatus_Value("select OrgName from tblOrganization where  OrganizationId='" + orgId.ToString() + "'");


                        lblReceiptNo.Text = GroupReceiptNo.ToString();
                        lblReceiptNo1.Text = GroupReceiptNo.ToString();


                        float _tamount = db.getDb_Value("select  sum(Amount) from  tblFeesDetails  where FeesId =" + ViewState["FeesId"].ToString() + " ");
                       // lblTotalFees_Footer.Text = lblTotalFees_Footer1.Text = _tamount.ToString();

                        float _pamount = db.getDb_Value("select  isnull(sum(paidamount),0) from  tblstudentfeespaid  " +
                            " where studentid =(select usercode from tblstudent where admissionid='" + txtStudentNameId.Text + "')");

                       // lblPendingFees_Footer.Text = lblPendingFees_Footer1.Text = (_tamount - _pamount).ToString();


                        SqlCommand cmd1 = new SqlCommand("select Logo,OrgName from tblOrganization where OrganizationId='" + orgId.ToString() + "'", cn);
                        SqlDataAdapter adp1 = new SqlDataAdapter();
                        DataSet ds1 = new DataSet();
                        adp1.SelectCommand = cmd1;
                        adp1.Fill(ds1);
                        //  lblTrustName.Text = ds1.Tables[0].Rows[0]["OrgName"].ToString();
                        //  lblTrustName1.Text = lblTrustName.Text;
                        //string Photo = db.getDbstatus_Value("select Logo from tblOrganization");



                        //if (Photo != null && Photo != "")
                        //{
                        //    Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["Logo"];

                        //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        //    imgClgLogo.ImageUrl = "data:image/png;base64," + base64String;
                        //}
                        //Button Visible
                        lbltotalpay.Text = "0";
                        btnSave.Visible = false;
                        btnGenerateReceipt.Visible = true;
                        GrdFeesDetails.DataSource = null;
                        GrdFeesDetails.DataBind();
                        GrdStudent.DataSource = null;
                        GrdStudent.DataBind();
                        DataTable co_br_cl = db.Displaygrid("SELECT     (FirstName + ' ' + MiddleName + ' ' + LastName) AS Name,co.CourseName,br.BranchName," +
                            " cl.ClassName,GRNo FROM  tblAdmissionDetails  st  inner join tblCourse co ON co.CourseId=st.CourseId  " +
                            " inner join tblBranch br ON br.BranchId=st.BranchId  inner join tblClass cl ON cl.ClassId=st.ClassId " +
                            " where admissionid='" + txtStudentNameId.Text + "'");

                        lblName.Text = co_br_cl.Rows[0]["Name"].ToString();
                        lblName1.Text = lblName.Text;

                        lblCourse.Text = co_br_cl.Rows[0]["CourseName"].ToString();
                        lblCourse1.Text = lblCourse.Text;

                        lblAcademicYear.Text = ddlAcademicYearId.SelectedItem.Text;
                        lblAcademicYear1.Text = lblAcademicYear.Text;

                        lblStd.Text = co_br_cl.Rows[0]["BranchName"].ToString();
                        lblStd1.Text = lblStd.Text;

                        lblDiv.Text = co_br_cl.Rows[0]["ClassName"].ToString();
                        lblDiv1.Text = lblDiv.Text;

                        lblGRNo.Text = co_br_cl.Rows[0]["GRNo"].ToString();
                        lblGRNo1.Text = lblGRNo.Text;




                        //string query = "select remark Particular,'First/Second Term' Term,(select amount from tblfeesdetails where feesid=tblstudentfeespaid.FeesId " +
                        //    "and FeesDetailsId=tblStudentFeesPaid.FeesDetailsId )'Total Fees',sum(paidamount) 'Received Fees',(select amount from tblfeesdetails where feesid=tblstudentfeespaid.FeesId " +
                        //    "and FeesDetailsId=tblStudentFeesPaid.FeesDetailsId )-sum(paidamount) as 'Due Fees' from tblstudentfeespaid " +
                        //    "where studentid=(select usercode from tblstudent where admissionid='" + txtStudentNameId.Text + "') and FeesId=" + ViewState["FeesId"].ToString() + " " +
                        //    "and GroupReceiptNo=" + GroupReceiptNo + " group by remark,FeesId,FeesDetailsId";

                        string query = "select remark Particular,'First/Second Term' Term,(select amount from tblfeesdetails where feesdetailsid=tblStudentFeesPaid.feesdetailsid) 'Total Fees',PaidAmount'Received Fees',PendingAmount 'Due Fees' " +
                            " from tblStudentFeesPaid where studentid = (select usercode from tblstudent where admissionid='" + txtStudentNameId.Text + "')" +
                            " and GroupReceiptNo =" + GroupReceiptNo + "";

                        DataTable gridDT = db.Displaygrid(query);
                        DataTable gridDT1 = new DataTable();

                        gridDT1.Columns.Add("Particular");
                        gridDT1.Columns.Add("Term");
                        gridDT1.Columns.Add("Total Fees");
                        gridDT1.Columns.Add("Received Fees");
                        gridDT1.Columns.Add("Due Fees");

                        double TF = 0.00, RF = 0.00, DF = 0.00;
                        DataRow dr;
                        for (int i = 0; i < gridDT.Rows.Count; i++)
                        {
                            dr = gridDT1.NewRow();

                            dr[0] = gridDT.Rows[i]["Particular"].ToString();
                            dr[1] = gridDT.Rows[i]["Term"].ToString();
                            dr[2] = gridDT.Rows[i]["Total Fees"].ToString();
                            dr[3] = gridDT.Rows[i]["Received Fees"].ToString();
                            dr[4] = gridDT.Rows[i]["Due Fees"].ToString();

                            TF = TF + Convert.ToDouble(gridDT.Rows[i]["Total Fees"].ToString());
                            RF = RF + Convert.ToDouble(gridDT.Rows[i]["Received Fees"].ToString());
                            DF = DF + Convert.ToDouble(gridDT.Rows[i]["Due Fees"].ToString());

                            gridDT1.Rows.Add(dr);
                        }

                        dr = gridDT1.NewRow();

                        dr[0] = "Total";
                        dr[1] = "";
                        dr[2] = TF;
                        dr[3] = RF;
                        dr[4] = DF;

                        gridDT1.Rows.Add(dr);


                        gridHistory.DataSource = gridDT1;
                        gridHistory.DataBind();

                        gridHistory1.DataSource = gridDT1;
                        gridHistory1.DataBind();

                        gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[0].Font.Bold = true;
                        gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[2].Font.Bold = true;
                        gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[3].Font.Bold = true;
                        gridHistory.Rows[gridDT1.Rows.Count - 1].Cells[4].Font.Bold = true;

                        gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[0].Font.Bold = true;
                        gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[2].Font.Bold = true;
                        gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[3].Font.Bold = true;
                        gridHistory1.Rows[gridDT1.Rows.Count - 1].Cells[4].Font.Bold = true;

                    }
                    else
                    {
                        if (strAction == "Save")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Critical", "alert('Unable to  Save !!!')", true);

                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Try Again for valid Fees!!!')", true);

                }

            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
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
                    if (Convert.ToDouble(PaidAmount.Text) > 0)
                    {
                        Label PendingAmount = (Label)row.FindControl("lblTotalPendingAmount");
                        string feesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[1].ToString(); //(TextBox)row.FindControl("feesDetailsId");

                        dr = dt.NewRow();
                        dr[0] = feesDetailsId;
                        dr[1] = PaidAmount.Text;
                        dr[2] = Particular.Text;
                        dr[3] = PendingAmount.Text;
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        Label PendingAmount = (Label)row.FindControl("lblTotalPendingAmount");
                        string feesDetailsId = GrdFeesDetails.DataKeys[row.RowIndex].Values[1].ToString(); //(TextBox)row.FindControl("feesDetailsId");

                        dr = dt.NewRow();
                        dr[0] = feesDetailsId;
                        dr[1] = "0";
                        dr[2] = Particular.Text;
                        dr[3] = PendingAmount.Text;
                        dt.Rows.Add(dr);
                    }
                }
                
            }

            return dt;
        }
        #endregion
        private string SendEmails()
        {
            database db = new database();
            string mail = db.getDbstatus_Value("select ParentEMail from tblAdmissionDetails where  AdmissionID='" + lblAdmissionId.Text + "'");
            string stringResult = null;
            //string mailFrom = WebConfigurationManager.AppSettings["mail"];
            //string password = WebConfigurationManager.AppSettings["password"];
            string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
            string password = Convert.ToString("logicpro@2017");
            //string mailTo = Convert.ToString("demo.demo@deiontech.com";  //Email Address to whom you want to send the mail

            string mailTo = Convert.ToString(mail.ToString());

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            email.To.Add(new System.Net.Mail.MailAddress(mailTo));
            email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

            email.Subject = "Admission Process";
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            email.Body ="Hello Dear Your Admission is Completed..!\n Please Note Down Your USERNAME:" + ViewState["StudentCode"].ToString() + " And \n Password :" + userpass.Text +"\n  Please Download This app  " + " https://play.google.com/store/apps/details?id=com.bgps.pocketschool";
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

        //New button
        #region[New Button]

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PayFees.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //To Generate Receipt
        #region GenerateReceiptRegion

        protected void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("../Reports/PrintFeesReceipt.aspx");
                string StudCode = ViewState["StudentCode"].ToString();

                Response.Redirect("~/Forms/Reports/PrintFeesReceipt.aspx?Code=" + StudCode);
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



        protected void btnGenerateReceipt_Click1(object sender, EventArgs e)
        {

           // string usercod = db.getDbstatus_Value("SELECT        Whe.StudentId FROM            tblStudentFeesPaid AS Whe INNER JOIN tblStudent ON Whe.StudentId = tblStudent.UserCode WHERE        (tblStudent.OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "') ORDER BY Whe.StudentId DESC");
            //string paid = db.getDbstatus_Value("SELECT        tblStudentFeesPaid.PaidAmount FROM            tblStudentFeesPaid INNER JOIN tblStudent ON tblStudentFeesPaid.StudentId = tblStudent.UserCode    WHERE        (tblStudent.UserCode = '" + usercod + "') and   (tblStudent.OrgId  = '" + Convert.ToInt32(Session["OrgId"]) + "')  ");
            //PaidFees1.Text = paid.ToString();

           // string Amt = db.getDbstatus_Value("SELECT Amount FROM  tblfeesdetails where feesDetailsid=(select feesDetailsid from tblStudentFeesPaid where studentid= " + usercod + ")  ");
            //TotalFees1.Text = Amt.ToString();
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "PrintPanel()", true);


            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>PrintPanel();</script>", false);
        }

        protected void ddlremark_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList ddlremark = (CheckBoxList)sender;

            //Label1.Text = ddlremark.SelectedItem.Value;
            if (ddlremark.SelectedItem.Value != "0")
            {
                
                float amount = db.getDb_Value("select  Amount from  tblFeesDetails  where FeesDetailsId =" + ddlremark.SelectedItem.Value + " ");

                //DataTable dt = db.Displaygrid("select tblstudentfeesPaid.FeesId," + amount + " Amount," + amount + "-sum(PaidAmount)PendingAmt " +
                //" from tblstudentfeesPaid where studentid =" + txtStudentNameId.Text + " and isnull(tblstudentfeesPaid.FeesDetailsId,0) ="
                //+ ddlremark.SelectedItem.Value + " " +
                //" group by tblstudentfeesPaid.FeesDetailsId, tblstudentfeesPaid.FeesId");

                GridViewRow row = (GridViewRow)ddlremark.NamingContainer;


                Label lblAmount = (Label)row.FindControl("lblTotalAmount") as Label;
                Label lblTotalPendingAmount = (Label)row.FindControl("lblTotalPendingAmount") as Label;
                //if (dt.Rows.Count > 0)
                //{
                //    lblAmount.Text = dt.Rows[0]["Amount"].ToString();
                //    lblTotalPendingAmount.Text = dt.Rows[0]["PendingAmt"].ToString();
                //}
                //else
                {
                    lblAmount.Text = amount.ToString();
                    lblTotalPendingAmount.Text = amount.ToString();
                }
            }
            else
            {
                float amount = db.getDb_Value("select  sum(Amount) from  tblFeesDetails  where FeessId =" + ViewState["FeesId"].ToString() + " ");
                GridViewRow row = (GridViewRow)ddlremark.NamingContainer;


                Label lblAmount = (Label)row.FindControl("lblTotalAmount") as Label;
                Label lblTotalPendingAmount = (Label)row.FindControl("lblTotalPendingAmount") as Label;

                lblAmount.Text = GrdFeesDetails.DataKeys[row.RowIndex].Values[0].ToString();

                lblTotalPendingAmount.Text = (Convert.ToDecimal(lblAmount.Text) - Convert.ToDecimal(amount)).ToString();//GrdFeesDetails.DataKeys[row.RowIndex].Values[1].ToString();
            }
        }
    }
}
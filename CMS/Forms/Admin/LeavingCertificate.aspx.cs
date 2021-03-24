using System;
using System.Data;
using System.Web.UI;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.Web.UI.WebControls;

//Leaving Certificate
namespace CMS.Forms.Admin
{
    public partial class LeavingCertificate : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private EWA_LC objEWA = new EWA_LC();
        private BL_LC objBAL = new BL_LC();
        database db = new database();
        string address;
        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"]);
                    lblIssuedDate.Visible = false;
                    chkDuplicateCopy.Visible = false;
                    PnlStudentLeavingCertificate.Visible = false;
                    btnPrintLC.Visible = false;
                    panDetails.Visible = false;
                    panPrint.Visible = false;
                    txtReadOnly();

                    if (objEWA.OrgId == null)
                    {
                        Response.Redirect("~/LeavingCertificate.aspx");
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion

        //On Create Button Create Student Leaving Certificate
        #region[Create Leaving Certificate]

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                panDetails.Visible = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Get Student Information
        #region[Get Student Information]

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //ddlStudentId.Items.Insert(0, "Select");
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            btnUpdate.Enabled = true;
            txtStudentName.ReadOnly = false;
            txtStudentCaste.ReadOnly = false;
            txtNationality.ReadOnly = false;
            txtBirthPlace.ReadOnly = false;
            txtDOB.ReadOnly = false;
            txtLastSchoolAttended.ReadOnly = false;
            txtDateOfAdmission.ReadOnly = false;
            txtYearOfStudying.ReadOnly = false;
            btnPrint.Enabled = true;
            //panDetails.Visible = true;

            EWA_LC objEWA = new EWA_LC();
            BL_LC objBL = new BL_LC();

            try
            {
                if (txtStudentId.Text != "")
                {
                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.AcademicYearId = 1;
                    objEWA.StudentId = txtStudentId.Text;

                    DataSet dsUpdate = objBAL.BL_CheckDuplicateRecord(objEWA);
                    if (dsUpdate.Tables[0].Rows.Count > 0)
                    {
                        panDetails.Visible = true;
                        ViewState["StudentData"] = dsUpdate;
                        ClearControl();
                        txtStudentName.Text = dsUpdate.Tables[0].Rows[0]["StudentName"].ToString();
                        txtStudentCaste.Text = dsUpdate.Tables[0].Rows[0]["Caste"].ToString();
                        txtNationality.Text = dsUpdate.Tables[0].Rows[0]["Nationality"].ToString();
                        txtBirthPlace.Text = dsUpdate.Tables[0].Rows[0]["BirthPlace"].ToString();
                        txtDOB.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                        txtLastSchoolAttended.Text = dsUpdate.Tables[0].Rows[0]["LastSchoolAttended"].ToString();
                        txtDateOfAdmission.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DateOfAdmission"].ToString()).ToString("dd/MM/yyyy");
                        txtYearOfStudying.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");

                        txtTodayDate.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                        txtDateOfLeaving.Text = DateTime.Parse(dsUpdate.Tables[0].Rows[0]["DateOfLeaving"].ToString()).ToString("dd/MM/yyyy");
                        ddlProgress.Items.FindByText(dsUpdate.Tables[0].Rows[0]["Progress"].ToString()).Selected = true;

                        ddlBehaviour.Items.FindByText(dsUpdate.Tables[0].Rows[0]["Behaviour"].ToString()).Selected = true; txtReaseon.Text = dsUpdate.Tables[0].Rows[0]["Reaseon"].ToString();
                        txtRemarks.Text = dsUpdate.Tables[0].Rows[0]["Remarks"].ToString();

                        ViewState["ApplicationId"] = dsUpdate.Tables[0].Rows[0]["ApplicationId"].ToString();
                        ViewState["UserCode"] = dsUpdate.Tables[0].Rows[0]["UserCode"].ToString();

                        lblIssuedDate.Text = "Issued On : " + DateTime.Parse(dsUpdate.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                        lblIssuedDate.Visible = true;
                        chkDuplicateCopy.Visible = true;
                        btnPrint.Enabled = true;
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        DataSet ds = objBL.BL_GetStudentInformation(objEWA);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            panDetails.Visible = true;
                            ControlVisible();
                            ClearControl();
                            txtStudentName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                            txtStudentCaste.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                            txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                            txtBirthPlace.Text = ds.Tables[0].Rows[0]["BirthPlace"].ToString();
                            txtDOB.Text = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDate"].ToString()).ToString("dd/MM/yyyy");
                            txtLastSchoolAttended.Text = ds.Tables[0].Rows[0]["LastInstitute"].ToString();
                            txtDateOfAdmission.Text = DateTime.Parse(ds.Tables[0].Rows[0]["AdmissionDate"].ToString()).ToString("dd/MM/yyyy");
                            txtYearOfStudying.Text = DateTime.Parse(ds.Tables[0].Rows[0]["AdmissionDate"].ToString()).ToString("dd/MM/yyyy");

                            btnUpdate.Enabled = false;
                            lblIssuedDate.Visible = false;
                            btnPrint.Enabled = false;
                        }
                        else
                        {
                            panDetails.Visible = false;
                            //GeneralErr("Please Check Student Id!!!");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Check Student Id!!!')", true);
                        }
                    }
                }
                else
                {
                   // GeneralErr("Please Enter Student Id!!!");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Enter Student Id!!!')", true);
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        //Clears TextBox
        #region[ClearControl]

        public void ClearControl()
        {
            //txtStudentId.Text = "";
            txtTodayDate.Text = "";
            txtStudentName.Text = "";
            txtStudentCaste.Text = "";
            txtNationality.Text = "";
            txtBirthPlace.Text = "";
            txtDOB.Text = "";
            txtLastSchoolAttended.Text = "";
            ddlProgress.ClearSelection();
            ddlBehaviour.ClearSelection();
            txtDateOfAdmission.Text = "";
            txtYearOfStudying.Text = "";
            txtDateOfLeaving.Text = "";
            txtReaseon.Text = "";
            txtRemarks.Text = "";
        }

        #endregion

        //Visible All Textbox
        #region[Visible]

        public void ControlVisible()
        {
            //lblStudentId.Visible = true;
            //ddlStudentId.Visible = true;
            lblStudentName.Visible = true;
            txtStudentName.Visible = true;
            lblStudentCaste.Visible = true;
            txtStudentCaste.Visible = true;
            lblNationality.Visible = true;
            txtNationality.Visible = true;
            lblBirthPlace.Visible = true;
            txtBirthPlace.Visible = true;
            lblDOB.Visible = true;
            txtDOB.Visible = true;
            lblLastSchoolAttended.Visible = true;
            txtLastSchoolAttended.Visible = true;
            lblDateOfAdmission.Visible = true;
            txtDateOfAdmission.Visible = true;
            lblProgress.Visible = true;
            ddlProgress.Visible = true;
            lblBehaviour.Visible = true;
            ddlBehaviour.Visible = true;
            lblDateOfLeaving.Visible = true;
            txtDateOfLeaving.Visible = true;
            lblYearOfStudying.Visible = true;
            txtYearOfStudying.Visible = true;
            lblReason.Visible = true;
            txtReaseon.Visible = true;
            lblRemarks.Visible = true;
            txtRemarks.Visible = true;
            lblApplicationDate.Visible = true;
            txtTodayDate.Visible = true;
            btnSave.Visible = true;
            btnClear.Visible = true;
        }

        #endregion

        //To Perform To Save Data Leaving Cerificate
        #region Save LC

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Action("Save");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Perform To Action for Save Student Leaving Certificate
        #region[Save Action Perform]

        protected void Action(String strAction)
        {
            try
            {
                EWA_LC objEWA = new EWA_LC();
                BL_LC objBAL = new BL_LC();

                try
                {
                    //ViewState["StudentId"] = txtStudentId.Text;
                    objEWA.Action = strAction;
                    objEWA.StudentId = txtStudentId.Text;
                    objEWA.AcademicYearId = Convert.ToInt32(Session["AcademicYearId"].ToString());
                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.TodayDate = Convert.ToDateTime(txtTodayDate.Text);
                    objEWA.FullName = txtStudentName.Text;
                    objEWA.Caste = txtStudentCaste.Text;
                    objEWA.Nationality = txtNationality.Text;
                    objEWA.BirthPlace = txtBirthPlace.Text;
                    objEWA.DOB = Convert.ToDateTime(txtDOB.Text);
                    objEWA.LastSchoolAttended = txtLastSchoolAttended.Text;
                    objEWA.DateOfAdmission = Convert.ToDateTime(txtDateOfAdmission.Text);
                    objEWA.Progress = ddlProgress.SelectedValue.ToString();
                    objEWA.Behaviour = ddlBehaviour.SelectedValue.ToString();
                    txtDateOfLeaving.ReadOnly = true;
                    objEWA.DateOfLeaving = Convert.ToDateTime(txtDateOfLeaving.Text);
                    txtDateOfLeaving.ReadOnly = true;
                    objEWA.YearStudying = Convert.ToDateTime(txtYearOfStudying.Text);
                    objEWA.Reaseon = txtReaseon.Text;
                    objEWA.Remarks = txtRemarks.Text;

                    objEWA.OrgId = Session["OrgId"].ToString();

                    int flag = objBAL.BL_SaveUpdateLC(objEWA);

                    if (flag > 0)
                    {
                        ClearControl();
                        if (strAction == "Save")
                        {
                            msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                        else if (strAction == "Update")
                        {
                            msgBox.ShowMessage("Record Updated Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        }
                    }
                    else
                    {
                        if (strAction == "Save")
                        {
                            msgBox.ShowMessage("Unable to  Saved !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        }
                        else if (strAction == "Update")
                        {
                            msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                        }
                    }
                }

                catch (Exception exp)
                {
                    throw exp;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Clear the All Textboxes
        #region Clear

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
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

        //Print Leaving Certificate
        #region[Print LC]

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PnlStudentLeavingCertificate.Visible = true;
                panDetails.Visible = false;
                GetStudentRecordPrint(Convert.ToInt64(txtStudentId.Text));
                btnPrintLC.Visible = true;
                panPrint.Visible = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update
        #region[Update LC]

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    Action("Update");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //On txtstudentId change Event Bind Student Id and Name
        #region[Get Student ID]

        protected void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[Bind Student Id and Name]
        #endregion

        // Get Student Record from Id Wise
        #region[Get Student Record]

        private void GetStudentRecord(long StudentId)
        {
            try
            {
                try
                {
                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.AcademicYearId = 1;//Convert.ToInt32(Session["AcademicYearId"]);

                    objEWA.Usercode = StudentId.ToString();

                    DataSet ds = objBAL.BL_StudentGetRecord(objEWA);

                    //tblLeavingCertificate
                    txtStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                    txtStudentCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    txtBirthPlace.Text = ds.Tables[0].Rows[0]["BirthPlace"].ToString();
                    txtDOB.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                    txtLastSchoolAttended.Text = ds.Tables[0].Rows[0]["LastSchoolAttended"].ToString();
                    txtDateOfAdmission.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfAdmission"].ToString()).ToString("dd/MM/yyyy");

                    ddlProgress.Items.FindByText(ds.Tables[0].Rows[0]["Progress"].ToString()).Selected = true;

                    ddlBehaviour.Items.FindByText(ds.Tables[0].Rows[0]["Behaviour"].ToString()).Selected = true;

                    txtDateOfLeaving.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DateOFLeaving"].ToString()).ToString("dd/MM/yyyy");
                    txtYearOfStudying.Text = DateTime.Parse(ds.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");
                    txtReaseon.Text = ds.Tables[0].Rows[0]["Reaseon"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    txtTodayDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                }

                catch (Exception)
                {
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Get Student Record from Id Wise print
        #region[Get Student Record]

        private void GetStudentRecordPrint(long StudentId)
        {
            try
            {
                try
                {

                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.AcademicYearId = 1;//Convert.ToInt32(Session["AcademicYearId"]);

                    objEWA.Usercode = StudentId.ToString();

                    DataSet ds = objBAL.BL_StudentGetRecord(objEWA);

                    //tblOrganization
                    lblTrustName.Text = ds.Tables[1].Rows[0]["TrustName"].ToString();
                    lblCollageFullName.Text = ds.Tables[1].Rows[0]["OrgName"].ToString();

                    //address = db.getDbstatus_Value(" select Address from tblOrganization where OrganizationId='" + Session["OrgId"].ToString() + "'");
                    //lblAddress.Text = address.ToString();
                    lblAddress.Text = ds.Tables[1].Rows[0]["Address"].ToString();
                    lblCollageName.Text = ds.Tables[1].Rows[0]["OrgName"].ToString();
                    lblCollageAddress.Text = lblAddress.Text;

                    //for Collage Logo
                    string Photo = ds.Tables[1].Rows[0]["Logo"].ToString();

                    if (Photo != null && Photo != "")
                    {
                        Byte[] bytes = (Byte[])ds.Tables[1].Rows[0]["Logo"];

                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        imgClgLogo.ImageUrl = "data:image/png;base64," + base64String;
                    }

                    
                    //tblLeavingCertificate
                    lblGRNO.Text = lblGRNO.Text + ds.Tables[1].Rows[0]["GRNo"].ToString();
                    if (lblGRNO.Text == "0")
                    {
                        lblGRNO.Visible = false;
                    }
                    else
                    {
                        lblGRNO.Visible = true;
                    }
                    lblNo.Text = lblNo.Text + ds.Tables[0].Rows[0]["ApplicationId"].ToString();
                    //lblTodayDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                    txtTodayDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["TodayDate"].ToString()).ToString("dd/MM/yyyy");
                    //lblStudnetNameLC.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();

                    //Set UserCode
                    Bind_Number(StudentId.ToString().Trim(), "lblstudId", 7);

                    //set Aadhar Number
                    Bind_Number(ds.Tables[1].Rows[0]["AdharNo"].ToString().Trim(), "lblaadharno", 12);

                    lblStudnetName_Fname.Text = ds.Tables[1].Rows[0]["FirstName"].ToString();
                    lblStudnetName_Mname.Text = ds.Tables[1].Rows[0]["MiddleName"].ToString();
                    lblStudnetName_Lname.Text = ds.Tables[1].Rows[0]["LastName"].ToString();
                    lblMoname.Text = ds.Tables[1].Rows[0]["MotherName"].ToString();

                    txtStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();


                    lblMoTongue.Text = ds.Tables[1].Rows[0]["MotherTongue"].ToString();
                    lblNationalityLC.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();

                    lblReligion.Text = ds.Tables[1].Rows[0]["Religion"].ToString();
                    lblStudentCasteLC.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    txtStudentCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    lblSubCaste.Text = ds.Tables[1].Rows[0]["SubCaste"].ToString();

                    lblBirthPlaceLC.Text = ds.Tables[0].Rows[0]["BirthPlace"].ToString();
                    txtBirthPlace.Text = ds.Tables[0].Rows[0]["BirthPlace"].ToString();

                    lblTaluka.Text = ds.Tables[1].Rows[0]["Taluka"].ToString();
                    lblDist.Text = ds.Tables[1].Rows[0]["District"].ToString();
                    lblState.Text = ds.Tables[1].Rows[0]["State"].ToString();
                    lblCountry.Text = ds.Tables[1].Rows[0]["County"].ToString();


                    //lblDOBLC.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                    txtDOB.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");

                    // Date Formate For Date Of Birth 
                    DateToFormate(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()), "lblDOB");

                    lblDOBinWords.Text = DateToText(Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()));

                    lblLastSchoolLC.Text = ds.Tables[0].Rows[0]["LastSchoolAttended"].ToString();
                    txtLastSchoolAttended.Text = ds.Tables[0].Rows[0]["LastSchoolAttended"].ToString();

                    // Date Formate For DateOfAdmission 
                    DateToFormate(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfAdmission"].ToString()), "lblDateofAdmission");

                    //lblstd.Text= ds.Tables[1].Rows[0]["std"].ToString();
                    txtDateOfAdmission.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfAdmission"].ToString()).ToString("dd/MM/yyyy");

                    lblProgressLC.Text = ds.Tables[0].Rows[0]["Progress"].ToString();
                    ddlProgress.SelectedValue = ds.Tables[0].Rows[0]["Progress"].ToString();
                    //lblBehaviourLC.Text = ds.Tables[0].Rows[0]["Behaviour"].ToString();
                    ddlBehaviour.SelectedValue = ds.Tables[0].Rows[0]["Behaviour"].ToString();
                    lblConductLC.Text = "-";

                    // Date Formate For Date Of Leaving 
                    DateToFormate(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOFLeaving"].ToString()), "lblDateOFLeaving");

                    // lblDateOFLeavingLC.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DateOFLeaving"].ToString()).ToString("dd/MM/yyyy");
                    txtDateOfLeaving.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DateOFLeaving"].ToString()).ToString("dd/MM/yyyy");

                    lblstd_since.Text = ds.Tables[1].Rows[0]["std"].ToString() + "  " + DateTime.Parse(ds.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");
                    //lblYearOfStudyingLC.Text = DateTime.Parse(ds.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");
                    txtYearOfStudying.Text = DateTime.Parse(ds.Tables[0].Rows[0]["YearStudying"].ToString()).ToString("dd/MM/yyyy");


                    lblReaseonLC.Text = ds.Tables[0].Rows[0]["Reaseon"].ToString();
                    txtReaseon.Text = ds.Tables[0].Rows[0]["Reaseon"].ToString();
                    lblRemarksLC.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }

                catch (Exception ex)
                {
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[Date in Words]

        public static string DateToText(DateTime dt)
        {
            string[] ordinals =
            {
           "First",
           "Second",
           "Third",
           "Fourth",
           "Fifth",
           "Sixth",
           "Seventh",
           "Eighth",
           "Ninth",
           "Tenth",
           "Eleventh",
           "Twelfth",
           "Thirteenth",
           "Fourteenth",
           "Fifteenth",
           "Sixteenth",
           "Seventeenth",
           "Eighteenth",
           "Nineteenth",
           "Twentieth",
           "Twenty First",
           "Twenty Second",
           "Twenty Third",
           "Twenty Fourth",
           "Twenty Fifth",
           "Twenty Sixth",
           "Twenty Seventh",
           "Twenty Eighth",
           "Twenty Ninth",
           "Thirtieth",
           "Thirty First"
        };

            int day = dt.Day;
            int month = dt.Month;
            int year = dt.Year;
            DateTime dtm = new DateTime(1, month, 1);
            string date;


            date = ordinals[day - 1] + " of " + dtm.ToString("MMMM") + " " + NumberToText(year);


            return date;
        }

        public static string NumberToText(int number)
        {

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i < first) sb.Append("and");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        #endregion

        #region [set Date]

        public void DateToFormate(DateTime dt, string lblformate)
        {
            string Day = dt.Day.ToString();
            string Month = dt.Month.ToString();
            string Year = dt.Year.ToString();
            int i = 1;
            char[] d = Day.ToCharArray();
            for (int j = 0; j < d.Length; j++)
            {
                if (d.Length == 1)
                {
                    Label dob1 = (Label)PnlStudentLeavingCertificate.FindControl(lblformate + "_D1");
                    dob1.Text = "0";
                    i++;
                }
                string lbl = lblformate + "_D" + i;
                Label dob = (Label)PnlStudentLeavingCertificate.FindControl(lbl);
                dob.Text = d[j].ToString();
                i++;
            }

            i = 1;
            d = Month.ToCharArray();
            for (int j = 0; j < d.Length; j++)
            {
                if (d.Length == 1)
                {
                    Label dob1 = (Label)PnlStudentLeavingCertificate.FindControl(lblformate + "_M1");
                    dob1.Text = "0";
                    i++;
                }
                string lbl = lblformate + "_M" + i;
                Label dob = (Label)PnlStudentLeavingCertificate.FindControl(lbl);
                dob.Text = d[j].ToString();
                i++;
            }

            i = 1;
            d = Year.ToCharArray();
            for (int j = 0; j < d.Length; j++)
            {
                string lbl = lblformate + "_Y" + i;
                Label dob = (Label)PnlStudentLeavingCertificate.FindControl(lbl);
                dob.Text = d[j].ToString();
                i++;
            }
        }

        #endregion

        #region [set Aadar Number && UserCode]

        public void Bind_Number(string str, string lblformate, int len)
        {

            int i = 1;
            char[] d = str.ToCharArray();
            for (int j = 0; j < len; j++)
            {
                if (d.Length < len && d.Length <= j)
                {
                    Label dob1 = (Label)PnlStudentLeavingCertificate.FindControl(lblformate + i);
                    dob1.Text = "0";
                    i++;
                }
                else
                {
                    string lbl = lblformate + i;
                    Label dob = (Label)PnlStudentLeavingCertificate.FindControl(lbl);
                    dob.Text = d[j].ToString();
                    i++;
                }
            }
        }

        #endregion

        //Check Duplicate Copy
        #region[on Check Duplicate Copy]

        protected void chkDuplicateCopy_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDuplicateCopy.Checked==true)
            {
            //lblDuplicateCopy.Visible = true;
            }
            else
            {
                //lblDuplicateCopy.Visible = false;
            }
        }

        #endregion

        //Check Blank TextBox
        #region[Valid Control]

        public bool ValidData()
        {
            if (txtTodayDate.Text == "")
            {
                msgBox.ShowMessage("Please Enter Date!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtStudentName.Text == "")
            {
                msgBox.ShowMessage("Please Enter Student Name!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtStudentCaste.Text == "")
            {
                msgBox.ShowMessage("Please Enter Student Cast!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return true;
            }

            if (txtNationality.Text == "")
            {
                msgBox.ShowMessage("Please Enter Nationality!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtBirthPlace.Text == "")
            {
                msgBox.ShowMessage("Please Enter Student Birth Place!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtDOB.Text == "")
            {
                msgBox.ShowMessage("Please Enter Date of Birth!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtLastSchoolAttended.Text == "")
            {
                msgBox.ShowMessage("Please Enter Last School Attended!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtDateOfAdmission.Text == "")
            {
                msgBox.ShowMessage("Please Enter Date of Admission!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (ddlProgress.SelectedValue == "Select")
            {
                msgBox.ShowMessage("Please Select Progress!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (ddlBehaviour.SelectedValue == "Select")
            {
                msgBox.ShowMessage("Please select Behaviour!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtDateOfLeaving.Text == "")
            {
                msgBox.ShowMessage("Please Enter Date of Leaving!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtYearOfStudying.Text == "")
            {
                msgBox.ShowMessage("Please Enter Year of Studying!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtReaseon.Text == "")
            {
                msgBox.ShowMessage("Please Enter Reaseon!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                return false;
            }

            if (txtRemarks.Text == "")
            {
                msgBox.ShowMessage("Please Enter Remarks!!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
            }
            return true;
        }

        #endregion

        public void txtReadOnly()
        {
            txtStudentName.ReadOnly = true;
            txtStudentCaste.ReadOnly = true;
            txtNationality.ReadOnly = true;
            txtBirthPlace.ReadOnly = true;
            txtDOB.ReadOnly = true;
            txtLastSchoolAttended.ReadOnly = true;
            txtDateOfAdmission.ReadOnly = true;
            txtYearOfStudying.ReadOnly = true;


        }
    }
}
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
using EntityWebApp;
using BusinessAccessLayer;

namespace CMS.Forms.Admin
{
    public partial class PayPreviousyearFees : System.Web.UI.Page
    {
        #region[Objects]
        public static int orgId;
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        EWA_Common objEWA = new EWA_Common();
        BL_Common objBL = new BL_Common();

        #endregion
        int OrgID = 0;
        string CourseId;
        string BranchId;
        string ClassId;
        string AcademicId;
        string studentId;
        private DataView dvBranch = null;
        private DataView dvClass = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                txtReceiptDate.Attributes.Add("ReadOnly", "True");
                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                orgId = Convert.ToInt32(Session["OrgId"]);
                if (!IsPostBack)
                {
                    BindCourse();
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
        private void BindCourse()
        {
            try
            {

                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];

                ddlCourse.Items.Clear();
                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));

                DDLAcademicYear.Items.Clear();
                DDLAcademicYear.DataSource = ds.Tables[7];
                DDLAcademicYear.DataTextField = "AcademicYear";
                DDLAcademicYear.DataValueField = "AcademicYearId";
                DDLAcademicYear.DataBind();
                DDLAcademicYear.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlStudentname.Items.Clear();
                ddlStudentname.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }
        protected void btnGetDetails_Click(object sender, EventArgs e)
        {

            if (txtStudentNameId.Text == "" || txtStudentNameId.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Select Student Name')", true);
            }
            txtStudentNameId.Text = txtStudentNameId.Text.Trim();
            TxtPayAmt.Text = "";
            try
            {
                div1.Visible = true;
                GetPaidPreviousFee();
                StudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void GetPaidPreviousFee()
        {
            EWA_PayFees objEWA = new EWA_PayFees();
            BL_PayFees objBL = new BL_PayFees();
            bindvariable();
            lblStudentCode.Text = txtStudentNameId.Text;
            objEWA.StudentCode = studentId;
            objEWA.CourseId = CourseId;
            objEWA.ClassId = ClassId;
            objEWA.BranchId = BranchId;
            objEWA.AcadmicYearId = Convert.ToInt32(AcademicId);
            DataSet DsFeesPaidData = objBL.GetDataStudentFeesPaid(objEWA);
            if (DsFeesPaidData.Tables.Count >= 0)
            {
                if (DsFeesPaidData.Tables[0].Rows.Count != 0)
                {
                    GrdFeesPaidDetails.DataSource = DsFeesPaidData.Tables[0];
                    GrdFeesPaidDetails.DataBind();
                }
            }
        }

        protected void StudentData()
        {
            bindvariable();
            EWA_PayFees objEWA = new EWA_PayFees();
            BL_PayFees objBL = new BL_PayFees();
            lblStudentCode.Text = txtStudentNameId.Text;
            objEWA.StudentCode = studentId;
            objEWA.CourseId = CourseId;
            objEWA.ClassId = ClassId;
            objEWA.BranchId = BranchId;
            objEWA.AcadmicYearId = Convert.ToInt32(AcademicId);
            DataSet DsFeesPaidData = objBL.GetDataStudent(objEWA);
            if (DsFeesPaidData.Tables.Count >= 0)
            {
                if (DsFeesPaidData.Tables[0].Rows.Count != 0)
                {
                    lblStudentNameevalue.Text = DsFeesPaidData.Tables[0].Rows[0]["StudentName"].ToString();
                    lblTotalAmountvalue.Text = DsFeesPaidData.Tables[0].Rows[0]["TotalAmount"].ToString();
                    lblPaidAmountValue.Text = DsFeesPaidData.Tables[0].Rows[0]["PaidAmount"].ToString();
                    decimal TotalAmt = Convert.ToDecimal(lblTotalAmountvalue.Text);
                    decimal paidAmt = Convert.ToDecimal(lblPaidAmountValue.Text);
                    LblPendingAmtvalue.Text = (TotalAmt - paidAmt).ToString();
                }
            }
        }
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
        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        private void BindBranch()
        {
            try
            {
                dvBranch = new DataView(ViewState["dvBranch"] as DataTable);
                dvBranch.RowFilter = "[CourseId] = " + ddlCourse.SelectedValue + "";
                ddlBranch.DataSource = dvBranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));
                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
                ddlStudentname.Items.Clear();
                ddlStudentname.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        private void BindClass()
        {
            try
            {
                dvClass = new DataView(ViewState["dvClass"] as DataTable);
                dvClass.RowFilter = "[BranchId] = " + ddlBranch.SelectedValue + "";
                ddlClass.DataSource = dvClass;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        public void BindStudentName()
        {
            string CourseId = ddlCourse.SelectedValue;
            string BranchId = ddlBranch.SelectedValue;
            string ClassId = ddlClass.SelectedValue;
            string AcademicYearId = DDLAcademicYear.SelectedValue;

            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_getStudentForPayFeesPrevious";
            cmd.Connection = cn;

            cmd.Parameters.AddWithValue("@CourseId", CourseId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@ClassId", ClassId);
            cmd.Parameters.AddWithValue("@AcademicYear", AcademicYearId);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlStudentname.DataSource = ds;
                ddlStudentname.DataTextField = "studentname";
                ddlStudentname.DataValueField = "StudentId";
                ddlStudentname.DataBind();
                ddlStudentname.Items.Insert(0, new ListItem("---Select---", "0"));
            }


        }
        protected void DDLAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlStudentname.Items.Clear();
                BindStudentName();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        protected void ddlStudentname_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStudentNameId.Text = ddlStudentname.SelectedValue;
            txtStudentNameId.Enabled = false;
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bindvariable();
           if (Convert.ToDecimal(LblPendingAmtvalue.Text)< Convert.ToDecimal(TxtPayAmt.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Enter Valid Pay Amount')", true);
                return;
            }
            if (Convert.ToDecimal(TxtPayAmt.Text)==0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Enter Valid Pay Amount')", true);
                return;
            }
            Label feesId = new Label();
            for (int i = 0; i < GrdFeesPaidDetails.Rows.Count; i++)
            {
                feesId = (Label)GrdFeesPaidDetails.Rows[i].Cells[0].FindControl("lblFeesID");
            }
            decimal PaidAmt = Convert.ToDecimal(lblPaidAmountValue.Text) + Convert.ToDecimal(TxtPayAmt.Text);
            decimal PendingAmt = Convert.ToDecimal(lblTotalAmountvalue.Text) - PaidAmt;
            string TransDate1 = DateTime.Now.Date.ToString("dd/MMM/yyyy");
           
                int UserID1 = Convert.ToInt32(Session["UserCode"].ToString());
            db.insert("INSERT INTO [tblPreviousYearFees] ( [CourseId],[BranchId],[ClassId],[AcademicYearId],[StudentId],[TotalAmount],[PaidAmount],[pendingAmount],[PayAmount],[CurrentDate],[FeesID],[UserId]) VALUES ('" + ddlCourse.SelectedValue + "','" + ddlBranch.SelectedValue + "','" + ddlClass.SelectedValue + "','" + DDLAcademicYear.SelectedValue + "','" + ddlStudentname.SelectedValue + "','" + lblTotalAmountvalue.Text + "','" + PaidAmt.ToString() + "','" + PendingAmt.ToString() + "','" + TxtPayAmt.Text + "','" + TransDate1 + "','" + feesId.Text + "','" + UserID1 + "')");

            string StudentId1 = ddlStudentname.SelectedValue;
            GetPaidPreviousFee();
            ClearAll();
            //-----------------for Print Slip
           
            
           
            var todaysdate = DateTime.Today.Date.ToString("dd/MM/yyyy");
            txtdate1.Text = todaysdate;
            StudentId1 = lblStudentCode.Text;
            string UserId = Session["UserCode"].ToString();
            string FeesId = feesId.Text;

            DataTable co_br_cl = db.Displaygrid("SELECT     (FirstName + ' ' + MiddleName + ' ' + LastName) AS Name,co.CourseName,br.BranchName,cl.ClassName,GRNo,ay.AcademicYear  FROM  tblStudent  st  inner join tblCourse co ON co.CourseId=st.CourseId  inner join tblBranch br ON br.BranchId=st.BranchId  inner join tblClass cl ON cl.ClassId=st.ClassId inner join tblAcademicYear ay ON ay.AcademicYearId=st.AcademicYearId  where UserCode='" + StudentId1 + "'");
            DataTable co_br_cl1 = db.Displaygrid("SELECT     (FirstName + ' ' + MiddleName + ' ' + LastName) AS Name,co.CourseName,br.BranchName,cl.ClassName,GRNo,ay.AcademicYear  FROM            tblStudent  st  inner join tblCourse co ON co.CourseId=st.CourseId  inner join tblBranch br ON br.BranchId=st.BranchId  inner join tblClass cl ON cl.ClassId=st.ClassId inner join tblAcademicYear ay ON ay.AcademicYearId=st.AcademicYearId  where UserCode='" + StudentId1 + "'");


            lblCourse.Text = co_br_cl1.Rows[0]["CourseName"].ToString();
            lblCourse1.Text = lblCourse.Text;

            lblAcademicYear1.Text = co_br_cl1.Rows[0]["AcademicYear"].ToString();
            Label34.Text = lblAcademicYear1.Text;


            lblStd1.Text= ddlClass.SelectedItem.Text;
            lblDiv1.Text = ddlBranch.SelectedItem.Text;
            lblGRNo1.Text= co_br_cl.Rows[0]["GRNo"].ToString();
            lblReceiptNo1.Text = co_br_cl.Rows[0]["Name"].ToString();
            lblDate1.Text= Convert.ToDateTime(txtReceiptDate.Text).ToString("dd/MM/yyyy");
            string name = co_br_cl.Rows[0]["Name"].ToString();
            string[] arrNM = name.Split(' ');
            lblPrevious1.Text = TxtPayAmt.Text;
            lblPrevious111.Text= TxtPayAmt.Text;
            Label8.Text= co_br_cl.Rows[0]["Name"].ToString();
            Label10.Text= Convert.ToDateTime(txtReceiptDate.Text).ToString("dd/MM/yyyy");
            Label12.Text= ddlClass.SelectedItem.Text;
            Label14.Text= ddlBranch.SelectedItem.Text;
            Label17.Text= co_br_cl.Rows[0]["GRNo"].ToString();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            TxtPayAmt.Text = "";

        }

        protected void ClearAll()
        {
            div1.Visible = false;
            btnGenerateReceipt.Visible = true;


        }
        protected void bindvariable()
        {
            CourseId = ddlCourse.SelectedValue;
            BranchId = ddlBranch.SelectedValue;
            ClassId = ddlClass.SelectedValue;
            AcademicId = DDLAcademicYear.SelectedValue;
            studentId = ddlStudentname.SelectedValue;
        }

        protected void GrdFeesPaidDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // string FeesId = GrdFeesPaidDetails.DataKeys[e.Row.RowIndex].Values[0].ToString();
                for (int i = 0; i <= GrdFeesPaidDetails.Rows.Count; i++)
                {
                    Label lbl = (Label)e.Row.FindControl("lblPendingAmt");
                    // Label lbl1 = (Label)GrdFeesPaidDetails.Rows[i]["pendingAmount"].FindControl("lblPendingAmt");
                    if (lbl.Text == "0.00")
                    {
                        e.Row.BackColor = System.Drawing.Color.Green;
                        e.Row.ForeColor = System.Drawing.Color.White;
                    }
                }

            }

        }
    }
}
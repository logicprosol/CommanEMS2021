using BusinessAccessLayer;
using BusinessAccessLayer.HR;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.HR;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Faculty
{
    public partial class ViewSalarySlip : System.Web.UI.Page
    {

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
             OrgID = Convert.ToInt32(Session["OrgId"]);
            //int AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);
            ViewState["OrgID"] = OrgID.ToString();
            if (OrgID == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                txtMonth.Attributes.Add("ReadOnly","True");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["UserCode"] = Session["UserCode"].ToString();

                BL_SalarySettings objBL = new BL_SalarySettings();
                EWA_SalarySettings objEWA = new EWA_SalarySettings();
                objEWA.Action = "StaffGetSalary_Details";
                objEWA.OrgId = Convert.ToInt32(ViewState["OrgID"]);
                objEWA.PayGrpID = 0;
                objEWA.UserCode = Session["UserCode"].ToString();
                objEWA.SalaryMonth = Convert.ToDateTime(txtMonth.Text).Month.ToString();
                objEWA.PostedMonth = txtMonth.Text;
                DataSet ds = objBL.GetSalarySettings(objEWA);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0 && ds.Tables[2].Rows.Count > 0 && ds.Tables[3].Rows.Count > 0)
                {

                    lbl_CollegeName.Text= ds.Tables[3].Rows[0]["OrgName"].ToString();
                    lbl_CollegeAddress.Text= ds.Tables[3].Rows[0]["Address"].ToString();
                    lbl_Number.Text= ds.Tables[3].Rows[0]["PhoneNo"].ToString();
                    lbl_website.Text= ds.Tables[3].Rows[0]["Website"].ToString();

                    lbl_CollegeName1.Text = lbl_CollegeName.Text;
                    lbl_CollegeAddress1.Text = ds.Tables[3].Rows[0]["Address"].ToString();
                    lbl_Number1.Text = ds.Tables[3].Rows[0]["PhoneNo"].ToString();
                    lbl_website1.Text = ds.Tables[3].Rows[0]["Website"].ToString();

                    lblmonthyear.Text = Convert.ToDateTime(txtMonth.Text).ToString("MMMM") + " " + Convert.ToDateTime(txtMonth.Text).Year.ToString();
                    lblName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                    lblDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();

                    lblName1.Text = lblName.Text;
                    lblmonthyear1.Text = lblmonthyear.Text;
                    lblDesignation1.Text = lblDesignation.Text;

                    lblGross.Text = ds.Tables[0].Rows[0]["GorssSalary"].ToString();
                    lblNet.Text = ds.Tables[0].Rows[0]["NetSalary"].ToString();
                    lblGross1.Text = lblGross.Text;
                    lblNet1.Text = lblNet.Text;


                    lblPaymentDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TransDate"].ToString()).ToString("dd-MM-yyyy");
                    lblBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    lblHolderName.Text = lblName.Text;
                    lblAccountNumber.Text = ds.Tables[0].Rows[0]["BankAccountNumber"].ToString();
                    lblBankBranch.Text = ds.Tables[0].Rows[0]["BankBranchName"].ToString();

                    lblPaymentDate1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TransDate"].ToString()).ToString("dd-MM-yyyy");
                    lblBankName1.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    lblHolderName1.Text = lblName.Text;
                    lblAccountNumber1.Text = ds.Tables[0].Rows[0]["BankAccountNumber"].ToString();
                    lblBankBranch1.Text = ds.Tables[0].Rows[0]["BankBranchName"].ToString();


                    int days = DateTime.DaysInMonth(Convert.ToDateTime(txtMonth.Text).Year, Convert.ToDateTime(txtMonth.Text).Month);
                    double leaveday = 0;
                    lblWorkday.Text = days.ToString();
                    lblAbsence.Text = "0";

                    lblWorkday1.Text = days.ToString();
                    lblAbsence1.Text = "0";
                    if (ds.Tables[2].Rows.Count > 0 && ds.Tables[2].Rows[0][0].ToString() != "")
                    {
                        leaveday = Convert.ToDouble(ds.Tables[2].Rows[0][0].ToString());
                        lblWorkday.Text = String.Format("{0:0.00}", (days - leaveday)).ToString();
                        lblAbsence.Text = leaveday.ToString();
                        lblWorkday1.Text = String.Format("{0:0.00}", (days - leaveday)).ToString();
                        lblAbsence1.Text = leaveday.ToString();
                    }

                   


                    DataTable dt = new DataTable();
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Earnings");
                    dt.Columns.Add("Deductions");
                    DataRow dr;


                    int i = 0;
                    while (ds.Tables[1].Rows.Count > i)
                    {
                        
                        if (ds.Tables[1].Rows[i]["ContentAction"].ToString() == "Earning")
                        {
                            dr = dt.NewRow();
                            dr[0] = ds.Tables[1].Rows[i]["CategoryName"].ToString();
                            dr[1] = ds.Tables[1].Rows[i]["ContentValue"].ToString();
                            dr[2] = "";
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr = dt.NewRow();
                            dr[0] = ds.Tables[1].Rows[i]["CategoryName"].ToString();
                            dr[1] = ""; 
                            dr[2] = ds.Tables[1].Rows[i]["ContentValue"].ToString();
                            dt.Rows.Add(dr);
                        }
                        
                        i++;
                    }



                    dr = dt.NewRow();
                    dr[0] = "Total";
                    dr[1] = lblGross.Text;
                    dr[2] = ds.Tables[0].Rows[0]["TotalDeduction"].ToString();
                    dt.Rows.Add(dr);
                    

                    dr = dt.NewRow();
                    dr[0] = "";
                    dr[1] = "Net Salary";
                    dr[2] = lblNet.Text;
                    dt.Rows.Add(dr);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    i = 0;
                    while (GridView1.Rows.Count > i)
                    {
                        GridView1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Center;
                        GridView1.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Center;

                        i++;
                    }

                    GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].BorderStyle = BorderStyle.None;
                    GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].Font.Bold = true;
                    GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].Font.Bold = true;
                    GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.DeepSkyBlue;
                    GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.DeepSkyBlue;


                    Panel2.Visible = true;
                    btnPrintSalarySlip.Visible = true;
                }
                else
                {
                    Panel2.Visible = false;
                    btnPrintSalarySlip.Visible = false;
                    msgBox.ShowMessage("Salary not posted yet...!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //protected void btnShow_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ViewState["UserCode"] = Session["UserCode"].ToString();
        //        database db = new database();

            //        PayGroupID = db.getDb_Value("select PayGrpID from tblEmployee where UserCode='" + ViewState["UserCode"] + "'");

            //        if (PayGroupID > 0)
            //        {

            //            //txtDeductions.Text = "";
            //            //txtGrossSalary.Text = "";
            //            //txtNetSalary.Text = "";
            //            //txtTotalLeave.Text = "";
            //            //txtBasicSalary.Text = "";

            //            BL_SalarySettings objBL = new BL_SalarySettings();
            //            EWA_SalarySettings objEWA = new EWA_SalarySettings();
            //            objEWA.Action = "GetSalary_Details";
            //            objEWA.OrgId = Convert.ToInt32(ViewState["OrgID"]);
            //            objEWA.PayGrpID = Convert.ToInt32(PayGroupID);

            //            //int.Parse(PayGroupID).ToString();//Convert.ToInt32(ViewState["PayGrpID"]);
            //            objEWA.UserCode = Session["UserCode"].ToString();
            //            objEWA.SalaryMonth = Convert.ToDateTime(txtMonth.Text).Month.ToString();
            //            objEWA.PostedMonth = txtMonth.Text;
            //            DataSet ds = objBL.GetSalarySettings(objEWA);

            //            if (ds.Tables.Count != 0)
            //        { 
            //            if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0)
            //            {
            //                Get_OrganizationDetails(Convert.ToInt32(ViewState["OrgID"]));
            //                lblName.Text = ds.Tables[4].Rows[0][1].ToString();
            //                lblmonthyear.Text = Convert.ToDateTime(txtMonth.Text).ToString("MMMM") + " " + Convert.ToDateTime(txtMonth.Text).Year.ToString();
            //                lblDesignation.Text = db.getDbstatus_Value("SELECT deg.DesignationName FROM tblDesignation deg INNER JOIN tblEmpAssignDeptDes EAD ON EAD.DesignationId = deg.DesignationId WHERE UserCode = '" + Session["UserCode"].ToString() + "'");

            //                    lblName1.Text = lblName.Text;
            //                    lblmonthyear1.Text = lblmonthyear.Text;
            //                    lblDesignation1.Text = lblDesignation.Text;

            //                    double GrossSalary = 0, Deductions = 0, NetSalary = 0, leaveDeductions = 0;
            //                DataTable dt = new DataTable();
            //                dt.Columns.Add("Description");
            //                dt.Columns.Add("Earnings");
            //                dt.Columns.Add("Deductions");
            //                DataRow dr;

            //                if (ds.Tables[3].Rows.Count > 0)
            //                {
            //                    dr = dt.NewRow();
            //                    dr[0] = "Basic Salary";
            //                    dr[1] = ds.Tables[3].Rows[0][0].ToString();
            //                    dr[2] = "";
            //                    dt.Rows.Add(dr);
            //                    txtBasicSalary = Convert.ToDouble(ds.Tables[3].Rows[0][0].ToString());
            //                    GrossSalary = GrossSalary + Convert.ToDouble(ds.Tables[3].Rows[0][0].ToString());
            //                }

            //                int i = 0;
            //                while (ds.Tables[0].Rows.Count > i)
            //                {
            //                    dr = dt.NewRow();
            //                    dr[0] = ds.Tables[0].Rows[i][0].ToString();
            //                    dr[1] = ds.Tables[0].Rows[i][1].ToString();
            //                    dr[2] = "";
            //                    GrossSalary = GrossSalary + Convert.ToDouble(ds.Tables[0].Rows[i][1].ToString());
            //                    i++;
            //                    dt.Rows.Add(dr);

            //                }

            //                i = 0;
            //                while (ds.Tables[1].Rows.Count > i)
            //                {
            //                    dr = dt.NewRow();
            //                    dr[0] = ds.Tables[1].Rows[i][0].ToString();
            //                    dr[1] = "";
            //                    dr[2] = ds.Tables[1].Rows[i][1].ToString();
            //                    Deductions = Deductions + Convert.ToDouble(ds.Tables[1].Rows[i][1].ToString());
            //                    i++;
            //                    dt.Rows.Add(dr);

            //                }

            //                int days = DateTime.DaysInMonth(Convert.ToDateTime(txtMonth.Text).Year, Convert.ToDateTime(txtMonth.Text).Month);
            //                double leaveday = 0;

            //                if (ds.Tables[2].Rows.Count > 0 && ds.Tables[2].Rows[0][0].ToString() != "")
            //                {
            //                    leaveday = Convert.ToDouble(ds.Tables[2].Rows[0][0].ToString());
            //                    leaveDeductions = Convert.ToDouble((String.Format("{0:0.00}", (GrossSalary / days) * leaveday)).ToString());


            //                    dr = dt.NewRow();
            //                    dr[0] = "Leave Deductions";
            //                    dr[1] = "";
            //                    dr[2] = leaveDeductions;
            //                    dt.Rows.Add(dr);
            //                    Deductions = Deductions + leaveDeductions;
            //                }

            //                lblWorkday.Text = (days - leaveday).ToString();
            //                lblAbsence.Text = leaveday.ToString();

            //                    lblWorkday1.Text = lblWorkday.Text;
            //                    lblAbsence1.Text = lblAbsence.Text;

            //                    dr = dt.NewRow();
            //                dr[0] = "Total";
            //                dr[1] = GrossSalary;
            //                dr[2] = Deductions;
            //                dt.Rows.Add(dr);

            //                NetSalary = GrossSalary - Deductions;

            //                dr = dt.NewRow();
            //                dr[0] = "";
            //                dr[1] = "Net Salary";
            //                dr[2] = NetSalary;
            //                dt.Rows.Add(dr);

            //                GridView1.DataSource = dt;
            //                GridView1.DataBind();

            //                    GridView2.DataSource = dt;
            //                    GridView2.DataBind();

            //                    i = 0;
            //                while (GridView1.Rows.Count > i)
            //                {
            //                    GridView1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //                    GridView1.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Center;

            //                    i++;
            //                }

            //                GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].BorderStyle = BorderStyle.None;
            //                GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].Font.Bold = true;
            //                GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].Font.Bold = true;
            //                GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.DeepSkyBlue;
            //                GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.DeepSkyBlue;

            //                //GridView1.Rows[GridView1.Rows.Count - 2].Cells[0].Font.Bold = true;
            //                //GridView1.Rows[GridView1.Rows.Count - 2].Cells[1].Font.Bold = true;
            //                //GridView1.Rows[GridView1.Rows.Count - 2].Cells[2].Font.Bold = true;
            //                //GridView1.Rows[GridView1.Rows.Count - 2].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            //                lblGross.Text = GrossSalary.ToString();
            //                lblNet.Text = NetSalary.ToString();

            //                    lblGross1.Text = GrossSalary.ToString();
            //                    lblNet1.Text = NetSalary.ToString();

            //                    txtGrossSalary = GrossSalary;
            //                txtNetSalary = NetSalary;
            //                txtDeductions = Deductions;

            //                if (ds.Tables[4].Rows.Count > 0)
            //                {
            //                    lblPaymentDate.Text = DateTime.Now.Date.ToShortDateString();
            //                    lblBankName.Text = ds.Tables[4].Rows[0][0].ToString();
            //                    lblHolderName.Text = ds.Tables[4].Rows[0][1].ToString();
            //                    lblAccountNumber.Text = ds.Tables[4].Rows[0][2].ToString();
            //                    lblBankBranch.Text = ds.Tables[4].Rows[0][3].ToString();

            //                        lblPaymentDate1.Text = DateTime.Now.Date.ToShortDateString();
            //                        lblBankName1.Text = ds.Tables[4].Rows[0][0].ToString();
            //                        lblHolderName1.Text = ds.Tables[4].Rows[0][1].ToString();
            //                        lblAccountNumber1.Text = ds.Tables[4].Rows[0][2].ToString();
            //                        lblBankBranch1.Text = ds.Tables[4].Rows[0][3].ToString();
            //                    }


            //                Panel2.Visible = true;
            //                btnPrintSalarySlip.Visible = true;
            //            }
            //        }
            //        else
            //        {
            //                Panel2.Visible = false;
            //                btnPrintSalarySlip.Visible = false;
            //                msgBox.ShowMessage("Salary not posted yet...!", "Information", UserControls.MessageBox.MessageStyle.Information);
            //            }

            //        }
            //        else
            //        {
            //            msgBox.ShowMessage("Please Apply Pay Scale...!", "Information", UserControls.MessageBox.MessageStyle.Information);

            //        }
            //    }
            //    catch (Exception exp)
            //    {
            //        GeneralErr(exp.Message.ToString());
            //    }
            //}



            //General Message

            #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
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
                lbl_Number.Text= ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                lbl_website.Text= ds.Tables[0].Rows[0]["Website"].ToString();

                lbl_CollegeName1.Text = ds.Tables[0].Rows[0]["OrgName"].ToString();
                lbl_CollegeAddress1.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                lbl_Number1.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                lbl_website1.Text = ds.Tables[0].Rows[0]["Website"].ToString();
                //Lbl_TrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();

            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw exp;
            }
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
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 0f, 0f);
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
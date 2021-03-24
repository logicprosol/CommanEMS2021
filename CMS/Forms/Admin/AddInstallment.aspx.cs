using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Data.SqlClient;
using System.Configuration;
namespace CMS.Forms.Admin
{
    public partial class AddInstallment : System.Web.UI.Page
    {
        EWA_Common ObjEWA = new EWA_Common();
        BL_Common ObjBL = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnblControls();
                bindClass();
                bindAcademicYear();
                GetInstallmentData();
            }
        }
        public void GetInstallmentData()
        {
            ObjEWA.OrgId = Session["OrgId"].ToString();
            DataSet ds = ObjBL.GetInstallmentData(ObjEWA);
            GRDinstallments.DataSource = ds;
            GRDinstallments.DataBind();
        }
        public void bindClass()
        {
            try
            {
                ObjEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = ObjBL.BindClassForinstallments(ObjEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlCourse.DataSource = ds;
                    ddlCourse.DataTextField = "class";
                    ddlCourse.DataValueField = "ClassId";
                    ddlCourse.DataBind();
                    ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
                    // disbleControls();
                }


            }
            catch (Exception exp)
            {
                throw;
            }
        }
        public void bindAcademicYear()
        {
            try
            {
                ObjEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = ObjBL.BindAcademicYear(ObjEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlAcademicYear.DataSource = ds;
                    ddlAcademicYear.DataTextField = "AcademicYear";
                    ddlAcademicYear.DataValueField = "AcademicYearId";
                    ddlAcademicYear.DataBind();
                    disbleControls();
                }
                else
                    ddlAcademicYear.Items.Clear();
                    ddlAcademicYear.Items.Insert(0, new ListItem("Select", "0"));
                    ddlAcademicYear.SelectedIndex = 0;
                    disbleControls();
            }
            catch (Exception exp)
            {
                throw;
            }
        }
        public void EnblControls()
        {
            txtinstallmentno.Enabled = false;
            txtInstallmentAmt.Enabled = false;
            txtFromdate.Enabled = false;
            TxtToDate.Enabled = false;
            ddlCourse.Enabled = false;
            ddlAcademicYear.Enabled = false;
        }
        public void disbleControls()
        {
            txtinstallmentno.Enabled = true;
            txtInstallmentAmt.Enabled = true;
            txtFromdate.Enabled = true;
            TxtToDate.Enabled = true;
            ddlCourse.Enabled = true;
            ddlAcademicYear.Enabled = true;
        }
        public void clear()
        {
            ddlCourse.SelectedIndex = 0;
            ddlAcademicYear.SelectedIndex = 0;
            txtinstallmentno.Text = "";
            txtInstallmentAmt.Text = "";
            txtFromdate.Text = "";
            TxtToDate.Text = "";
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            clear();
            disbleControls();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtFromdate.Text);
            DateTime date1 = Convert.ToDateTime(TxtToDate.Text);
            if (date > date1)
            {
                msgBox.ShowMessage("Please Select To date is large Than From Date !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                TxtToDate.Text = "";
                return;
            }
            if(txtinstallmentno.Text=="")
            {
                msgBox.ShowMessage("Please Enter Installment Number !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
               
                return;
            }
            if (txtInstallmentAmt.Text == "")
            {
                msgBox.ShowMessage("Please Enter Installment Amount !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
               
                return;
            }
            if (txtFromdate.Text == "")
            {
                msgBox.ShowMessage("Please Enter From Date !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
               
                return;
            }
            if (TxtToDate.Text == "")
            {
                msgBox.ShowMessage("Please Enter To Date !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                
                return;
            }
            if(ddlCourse.SelectedValue=="")
            {
                msgBox.ShowMessage("Please Select Class !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                
                return;
            }
            if (ddlAcademicYear.SelectedValue == "")
            {
                msgBox.ShowMessage("Please Select Academic Year !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);

                return;
            }
            DataSet ds = new DataSet();
            ObjEWA.Action = "SaveInstallments";
            ObjEWA.OrgId1 = Session["OrgId"].ToString();
            ObjEWA.Class = ddlCourse.SelectedValue;
            ObjEWA.AcademicYearId = ddlAcademicYear.SelectedValue;
            ObjEWA.installmentNo = txtinstallmentno.Text;
            ObjEWA.installmentAmt = Convert.ToDecimal(txtInstallmentAmt.Text);
            ObjEWA.fromdate = txtFromdate.Text;
            ObjEWA.todate = TxtToDate.Text;
            ds = ObjBL.SaveInstallment(ObjEWA);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    GetInstallmentData();
                    btnNew.Enabled = true;
                }
                else
                {
                    msgBox.ShowMessage("Installment No Already Exists Use Another one !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            else
            {
                msgBox.ShowMessage("Sorry Something is Wrong !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
            }
        }
        protected void lnkAmount_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkSlot = (LinkButton)sender;
                GridViewRow grdRow = (GridViewRow)lnkSlot.NamingContainer;
                ViewState["InstallmentId"] = GRDinstallments.DataKeys[grdRow.RowIndex].Values["InstallmentId"].ToString();
                ddlCourse.SelectedValue = GRDinstallments.DataKeys[grdRow.RowIndex].Values["ClassId"].ToString();
                txtinstallmentno.Text = GRDinstallments.DataKeys[grdRow.RowIndex].Values["InstallmentNo"].ToString();
                ddlAcademicYear.SelectedValue = GRDinstallments.DataKeys[grdRow.RowIndex].Values["AcademicYearId"].ToString();
                txtFromdate.Text = GRDinstallments.DataKeys[grdRow.RowIndex].Values["FromDate"].ToString();
                TxtToDate.Text = GRDinstallments.DataKeys[grdRow.RowIndex].Values["ToDate"].ToString();
                txtInstallmentAmt.Text = GRDinstallments.DataKeys[grdRow.RowIndex].Values["InstallmentAmt"].ToString();
                btnsave.Enabled = false;
                btnNew.Enabled = false;

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ObjEWA.Action = "UpdateInstallments";
            ObjEWA.OrgId1 = Session["OrgId"].ToString();
            ObjEWA.Class = ddlCourse.SelectedValue;
            ObjEWA.AcademicYearId = ddlAcademicYear.SelectedValue;
            ObjEWA.installmentNo = txtinstallmentno.Text;
            ObjEWA.installmentAmt = Convert.ToDecimal(txtInstallmentAmt.Text);
            ObjEWA.fromdate = txtFromdate.Text;
            ObjEWA.todate = TxtToDate.Text;
            ObjEWA.installmentId = ViewState["InstallmentId"].ToString();
            ds = ObjBL.SaveInstallment(ObjEWA);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    msgBox.ShowMessage("Record Update Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    GetInstallmentData();
                    btnNew.Enabled = true;

                }
                else
                {
                    msgBox.ShowMessage("Installment No Already Exists Use Another one !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            else
            {
                msgBox.ShowMessage("Sorry Something is Wrong !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
            }
        }
        protected void Btndelete_Click(object sender, EventArgs e)
        {
            ObjEWA.installmentId = ViewState["InstallmentId"].ToString();
            DataSet ds = ObjBL.Deleteinstallment(ObjEWA);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    msgBox.ShowMessage("Record Deleted Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    GetInstallmentData();
                }
            }
        }

        protected void TxtToDate_TextChanged(object sender, EventArgs e)
        {
            DateTime date =Convert.ToDateTime(txtFromdate.Text);
            DateTime date1 = Convert.ToDateTime(TxtToDate.Text);
            if(date>date1)
            {
                msgBox.ShowMessage("Please Select To date is large Than From Date !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
            }
        }
    }
}
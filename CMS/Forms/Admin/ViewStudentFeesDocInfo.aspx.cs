using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Common;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using EntityWebApp.Admin;
using BusinessAccessLayer.Admin;
using System.Configuration;

namespace CMS.Forms.Admin
{
    public partial class ViewStudentFeesDocInfo : System.Web.UI.Page
    {
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        private BindControl ObjHelper = new BindControl();
        string [] parm;
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            DataTable gridDT = new DataTable();

            
            gridHistory.DataSource = gridDT;
            gridHistory.DataBind();

            gridHistory1.DataSource = gridDT;
            gridHistory1.DataBind();

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
        protected void GrdFeesPaidDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFees.PageIndex = e.NewPageIndex;
            BindFeesPaidDetailsGrid();
        }
        private void BindFeesPaidDetailsGrid()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();
                string strValue = txtStudentId.Text;
                txtStudentId.Text = strValue;

                
                objEWA.StudentCode = strValue;

                DataSet ds = objBL.BindStudentFeesPaidDetails_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    grdFees.DataSource = ds;
                    grdFees.DataBind();
                    int columncount = grdFees.Rows[0].Cells.Count;
                    grdFees.Rows[0].Cells.Clear();
                    grdFees.Rows[0].Cells.Add(new TableCell());
                    grdFees.Rows[0].Cells[0].ColumnSpan = columncount;
                    grdFees.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    grdFees.DataSource = ds;
                    grdFees.DataBind();
                }
            }
            catch (Exception exp)
            {
                
            }
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
            BindData();
            //txtStudentId.Text = txtStudentId.Text.Trim();
            //string[] param = new string[6];
            //param[0] = "@Action";
            //param[1] = "GetStudentInfo";
            //param[2] = "@StudentId";
            //param[3] = txtStudentId.Text;
            //param[4] = "@OrgId";
            //param[5] = Session["OrgId"].ToString();
            
            //DataSet ds = new DataSet();
            //ds = ObjHelper.FillControl(param, "Sp_StudentInfo");

            //if(ds.Tables[0].Rows.Count > 0)
            //{
            //    txtName.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            //    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            //    txtParrentNo.Text = ds.Tables[0].Rows[0]["ParentMobile"].ToString();
            //    txtAdmissionDate.Text = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();

            //    DataView dView = ds.Tables[1].DefaultView;
            //    dView.Sort = "ReceiptNo Desc";

            //    grdFees.DataSource = dView;
            //    grdFees.DataBind();

            //    grdDoc.DataSource = ds.Tables[2];
            //    grdDoc.DataBind();
            //}
            //else
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Check Student Id!!!')", true);

        }
        protected void gridHistory_DataBound(object sender, EventArgs e)
        {
            if (gridHistory.Rows.Count > 0)
            {
                for (int i = 0; i < gridHistory.Rows.Count; i++)
                {
                    //gridHistory.Rows[i].Cells[3].Text = Convert.ToDateTime(gridHistory.Rows[i].Cells[3].Text).ToShortDateString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void lnkBtnStudentName_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string ReceiptNO = grdFees.DataKeys[gvr.RowIndex].Values[0].ToString();
            string FeesID = grdFees.DataKeys[gvr.RowIndex].Values[1].ToString();
            string TransDate = grdFees.DataKeys[gvr.RowIndex].Values[2].ToString();

            lblReceiptNo.Text = ReceiptNO;
            lblReceiptNo1.Text = ReceiptNO;
            Label1.Text = txtName.Text;

            lblDate.Text = TransDate;  //todaysdate;
            lblDate1.Text = TransDate; //todaysdate;

            float _tamount = db.getDb_Value("select  sum(Amount) from  tblFeesDetails  where FeesId =" + FeesID + " ");
                       

            float _pamount = db.getDb_Value("select  isnull(sum(paidamount),0) from  tblstudentfeespaid  " +
                            " where studentid =" + txtStudentId.Text + "");

            lblReceiptNo.Text = ReceiptNO;
            lblReceiptNo1.Text = ReceiptNO;
            Label1.Text = txtName.Text;

            string RouteId = db.getDbstatus_Value("select isnull((select routeid from tblStudentRouteAssign where UserCode = " + txtStudentId.Text + "),0)");
            float _pamount_bus = db.getDb_Value("select isnull((select sum(paidamount) from tblStudentBusFeesPaid   where  StudentId=" + txtStudentId.Text + "" +
                "  and Studentrouteid=" + RouteId + "),0)");


            float _tamount_bus = db.getDb_Value("select isnull((select amount from tblroute where RouteId=" + RouteId + "),0)");

            _tamount = _tamount + _tamount_bus;
            lblTotalFees_Footer.Text = lblTotalFees_Footer1.Text = _tamount.ToString();
            _pamount = _pamount + _pamount_bus;

            lblPendingFees_Footer.Text = lblPendingFees_Footer1.Text = (_tamount - _pamount).ToString();

            string query = "select remark Particular,'First/Second Term' Term,(select amount from tblfeesdetails where feesdetailsid=tblStudentFeesPaid.feesdetailsid) 'Total Fees',PaidAmount'Received Fees',PendingAmount 'Due Fees'" +
                " from   tblStudentFeesPaid where studentid='" + txtStudentId.Text + "' and GroupReceiptNo=" + ReceiptNO + "" +
                "  union all " +
                "select remark Particular,'First/Second Term' Term,TotalAmount 'Total Fees',PaidAmount'Received Fees',PendingAmount 'Due Fees'" +
                " from   tblStudentBusFeesPaid where studentid='" + txtStudentId.Text + "' and ReceiptNo=" + ReceiptNO + "";
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


            DataTable co_br_cl = db.Displaygrid("SELECT     (FirstName + ' ' + MiddleName + ' ' + LastName) AS Name,co.CourseName," +
               " br.BranchName,cl.ClassName,GRNo,ay.AcademicYear  FROM  tblStudent  st  inner join tblCourse co ON co.CourseId=st.CourseId " +
               " inner join tblBranch br ON br.BranchId=st.BranchId  inner join tblClass cl ON cl.ClassId=st.ClassId" +
               " inner join tblAcademicYear ay ON ay.AcademicYearId=st.AcademicYearId  where UserCode='" + txtStudentId.Text + "'");
           
            //Added by Ashwini 23-sep-2020
            DataTable dtClassdtls = db.Displaygrid("select tblcourse.Coursename as CourseName,tblclass.ClassName as ClassName,tblBranch.Branchname as BranchName,tblAcademicYear.AcademicYear as AcademicYear from tblFees left join tblcourse on tblcourse.CourseId=tblFees.CourseId left join tblclass on tblclass.ClassId=tblFees.classId left join tblBranch on tblBranch.BranchId = tblFees.BranchId left join tblAcademicYear on tblAcademicYear.AcademicYearId = tblFees.AcademicYearId where FeesId ='" + FeesID + "'");
            lblCourse.Text = co_br_cl.Rows[0]["CourseName"].ToString();
            lblCourse1.Text = lblCourse.Text;
            lblStd.Text = co_br_cl.Rows[0]["BranchName"].ToString();
            lblStd1.Text = lblStd.Text;
            lblDiv.Text = co_br_cl.Rows[0]["ClassName"].ToString();
            lblDiv1.Text = lblDiv.Text;
            lblAcademicYear.Text = co_br_cl.Rows[0]["AcademicYear"].ToString();
            lblAcademicYear1.Text = lblAcademicYear.Text;
            //


            lblName.Text = co_br_cl.Rows[0]["Name"].ToString();
            lblName1.Text = lblName.Text;

           // lblCourse.Text = co_br_cl.Rows[0]["CourseName"].ToString();
           // lblCourse1.Text = lblCourse.Text;

            //lblAcademicYear.Text = co_br_cl.Rows[0]["AcademicYear"].ToString();
            //lblAcademicYear1.Text = lblAcademicYear.Text;

           // lblStd.Text = co_br_cl.Rows[0]["BranchName"].ToString();
           // lblStd1.Text = lblStd.Text;

           // lblDiv.Text = co_br_cl.Rows[0]["ClassName"].ToString();
           // lblDiv1.Text = lblDiv.Text;

            lblGRNo.Text = co_br_cl.Rows[0]["GRNo"].ToString();
            lblGRNo1.Text = lblGRNo.Text;

            MessagePopUp.Show();
        }

        protected void lnkBtnDelete_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {

                LinkButton btn = (LinkButton)sender;

                //Get the row that contains this button
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                string ReceiptNO = grdFees.DataKeys[gvr.RowIndex].Values[0].ToString();

                string[] param = new string[4];
                param[0] = "@Action";
                param[1] = "DeleteFeesReceipt";
                param[2] = "@ReceiptNo";
                param[3] = ReceiptNO;
                
                int rs = ObjHelper.ExecuteQueryForBackup(param, "Sp_StudentInfo");

                if(rs>0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Fees Receipt Delete Successfully..!!!')", true);
                    BindData();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Unable to  Delete..!!!')", true);
                }
                
                
            }
            
        }

        public void BindData()
        {
            txtStudentId.Text = txtStudentId.Text.Trim();
            string[] param = new string[6];
            param[0] = "@Action";
            param[1] = "GetStudentInfo";
            param[2] = "@StudentId";
            param[3] = txtStudentId.Text;
            param[4] = "@OrgId";
            param[5] = Session["OrgId"].ToString();

            DataSet ds = new DataSet();
            ds = ObjHelper.FillControl(param, "Sp_StudentInfo");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtParrentNo.Text = ds.Tables[0].Rows[0]["ParentMobile"].ToString();
                txtAdmissionDate.Text = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();

                DataView dView = ds.Tables[1].DefaultView;
                dView.Sort = "ReceiptNo Desc";

                grdFees.DataSource = dView;
                grdFees.DataBind();

                grdDoc.DataSource = ds.Tables[2];
                grdDoc.DataBind();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Please Check Student Id!!!')", true);

        }


    }
}
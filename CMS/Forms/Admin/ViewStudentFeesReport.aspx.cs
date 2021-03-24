using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class ViewStudentFeesReport : System.Web.UI.Page
    {
        public static int orgId;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
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
                    BindAcademicYear();
                    BindCourse();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #region

        private void BindAcademicYear()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindAcademicYear_BL(objEWA);

                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "AcademicYear";
                ddlAcademicYear.DataValueField = "AcademicYearId";
                ddlAcademicYear.DataBind();
                ddlAcademicYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region

        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

                ddlBranch.Items.Clear();
                ddlClass.Items.Clear();
                ddlBranch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
                ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        #region[Bind Branch]

        private void BindBranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlBranch.DataSource = ds;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataBind();
                }
                else
                    ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));


                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion 

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

        #region[Bind Class]

        private void BindClass()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                if (!objEWA.BranchId.Equals("Select"))
                {
                    DataSet ds = objBL.BindClass_BL(objEWA);

                    ddlClass.DataSource = ds;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ddlClass.DataTextField = "ClassName";
                        ddlClass.DataValueField = "ClassId";
                        ddlClass.DataBind();
                    }
                    else
                        ddlClass.Items.Clear();
                }
                else
                    ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void GeneralErr(String msg)
        {
            //Response.Write("<script>alert('" + msg + "')</script>");
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if(ddlCourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Select Course!!');", true);
                return;
            }
            if (ddlBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Select Branch!!');", true);
                return;
            }
            if (ddlClass.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Select Class!!');", true);
                return;
            }
            if (ddlAcademicYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Select AcademicYear!!');", true);
                return;
            }
            BindGrid1();
        }

        private void BindGrid1()
        {
            try
            {
                Session["class"] = "";
                Session["strquery"] = "";

                if (ddlCourse.SelectedValue != "0")
                {
                    Session["strquery"] = "  tblCourse.CourseId = '" + ddlCourse.SelectedValue + "'"; ;
                }

                if (ddlBranch.SelectedValue != "0")
                {
                    Session["class"] = ddlBranch.SelectedValue;
                    Session["strquery"] = Session["strquery"].ToString() + " And tblBranch.BranchId = '" + ddlBranch.SelectedValue + "'";
                 }

                if (ddlClass.SelectedValue != "0")
                {
                    Session["class"] = Session["class"] + " (" + ddlClass.SelectedItem.ToString() + ")";
                    Session["strquery"] = Session["strquery"].ToString() + " And tblClass.ClassId = '" + ddlClass.SelectedValue + "'";
                }

                if (ddlAcademicYear.SelectedValue != "0")
                {
                    Session["AcademicYearId"] = " AY.AcademicYearId = '" + ddlAcademicYear.SelectedValue + "'";
                }
                
                //Session["class"] = ddlBranch.SelectedItem.ToString() + " (" + ddlClass.SelectedItem.ToString() + ")";
                string query = "";

                if (Session["strquery"].ToString() == "")
                {
                    //query = "with AllData as(SELECT  tblStudent.UserCode," +
                    //" (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,(tblBranch.branchname +'('+tblClass.className+')')Class ,Convert(decimal(18,2),max(tblStudentFeesPaid.TotalAmount)) Total, " +
                    //" Convert(decimal(18,2),sum(tblStudentFeesPaid.PaidAmount)) Paid, Convert(decimal(18,2),(max(tblStudentFeesPaid.TotalAmount)-sum(tblStudentFeesPaid.PaidAmount))) Pending" +
                    //" FROM  tblStudent INNER JOIN tblStudentFeesPaid ON tblStudent.UserCode = tblStudentFeesPaid.StudentId" +
                    // " INNER JOIN tblCourse ON tblStudent.CourseId = tblCourse.CourseId" +
                    // " INNER JOIN tblBranch ON tblStudent.BranchId = tblBranch.BranchId" +
                    // " INNER JOIN tblClass ON tblStudent.ClassId = tblClass.ClassId" +
                    // " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId" +
                    //" where  tblStudent.OrgId='" + orgId.ToString() + "' And " + Session["AcademicYearId"].ToString() + " group by UserCode,FirstName,MiddleName,LastName,tblBranch.branchname,tblClass.className" +
                    //" union all" +
                    //" SELECT  tblStudent.UserCode," +
                    //" (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,(tblBranch.branchname +'('+tblClass.className+')')Class ,isnull(Convert(decimal(18,2),(SELECT Amount From tblRoute where RouteId=(SELECT RouteId from tblStudentRouteAssign where UserCode=tblStudent.UserCode))),0) Total, " +
                    //" isnull(Convert(decimal(18,2),sum(tblStudentBusFeesPaid.PaidAmount)),0) Paid, isnull(Convert(decimal(18,2),(tblStudentBusFeesPaid.TotalAmount-sum(tblStudentBusFeesPaid.PaidAmount))),0) Pending FROM" +
                    //"  tblStudent INNER JOIN tblStudentBusFeesPaid ON tblStudent.UserCode = tblStudentBusFeesPaid.StudentId" +
                    // " INNER JOIN tblCourse ON tblStudent.CourseId = tblCourse.CourseId" +
                    // " INNER JOIN tblBranch ON tblStudent.BranchId = tblBranch.BranchId" +
                    // " INNER JOIN tblClass ON tblStudent.ClassId = tblClass.ClassId" +
                    // " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId" +
                    //" where tblStudent.OrgId='" + orgId.ToString() + "' And " + Session["AcademicYearId"].ToString() + " group by UserCode,FirstName,MiddleName,LastName,tblBranch.branchname,tblClass.className,TotalAmount)" +
                    //" select  UserCode,StudentName 'Student Name',Class,Sum(Total) 'Total Fees',Sum(Paid) 'Paid Fees',Sum(pending) 'Due Fees'" +
                    //" from AllData group by UserCode,StudentNAme,Class order by Class,UserCode";

                    query = "with AllData as(SELECT  tblStudent.UserCode as StudentCode," +

                       " (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName ,'School Fee ' FeesType ,Convert(decimal(18,2),max(tblStudentFeesPaid.TotalAmount)) Total, " +
                       " Convert(decimal(18,2),sum(tblStudentFeesPaid.PaidAmount)) Paid,(tblFeesCategory.FeesCategoryName) FeesCategory, Convert(decimal(18,2),(max(tblStudentFeesPaid.TotalAmount)-sum(tblStudentFeesPaid.PaidAmount))) Pending" +
                       " from tblFees INNER join tblStudentFeesPaid on  isnull(tblFees.FeesId,0)=isnull(tblStudentFeesPaid.FeesId,0) " +
                        " INNER join tblStudent ON isnull(tblStudent.UserCode,0) = isnull(tblStudentFeesPaid.StudentId,0)" +
                        " INNER JOIN tblCourse ON tblFees.CourseId = tblCourse.CourseId" +
                        " INNER JOIN tblBranch ON tblFees.BranchId = tblBranch.BranchId" +
                        " INNER JOIN tblClass ON tblFees.ClassId = tblClass.ClassId" +
                        " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId " +
                         " INNER JOIN tblFeesCategory ON tblFeesCategory.FeesCategoryId=tblFees.CasteCategoryId " +
                        " where tblStudent.OrgId='" + orgId.ToString() + "'And tblFees.AcademicYearId='" + ddlAcademicYear.SelectedValue + "' and tblFees.CourseId='" + ddlCourse.SelectedValue + "' and tblFees.ClassId='" + ddlClass.SelectedValue + "' and tblFees.BranchId='" + ddlBranch.SelectedValue + "'group by UserCode,FirstName,MiddleName,LastName,TotalAmount,tblBranch.branchname,FeesCategoryName" +
                       " union all" +
                       " SELECT  tblStudent.UserCode as StudentCode," +
                       " (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,'Bus Fee' as FeesType,isnull(Convert(decimal(18,2),(SELECT Amount From tblRoute where RouteId=(SELECT RouteId from tblStudentRouteAssign where UserCode=tblStudent.UserCode and courseId='"+ddlCourse.SelectedValue+"' and ClassId='"+ddlClass.SelectedValue+"' and BranchId='"+ddlBranch.SelectedValue+ "' and AcademicYearId='"+ddlAcademicYear.SelectedValue+"'))),0) Total, " +
                       " isnull(Convert(decimal(18,2),sum(tblStudentBusFeesPaid.PaidAmount)),0) Paid, (tblFeesCategory.FeesCategoryName) FeesCategory, isnull(Convert(decimal(18,2),(tblStudentBusFeesPaid.TotalAmount-sum(tblStudentBusFeesPaid.PaidAmount))),0) Pending FROM" +
                       "  tblStudent INNER JOIN tblStudentBusFeesPaid ON tblStudent.UserCode = tblStudentBusFeesPaid.StudentId" +
                       " Inner Join tblStudentRouteAssign ON tblStudentRouteAssign.studentRouteId=tblStudentBusFeesPaid.StudentRouteId" +
                        " INNER JOIN tblCourse ON tblStudent.CourseId = tblCourse.CourseId" +
                        " INNER JOIN tblBranch ON tblStudent.BranchId = tblBranch.BranchId" +
                        " INNER JOIN tblClass ON tblStudent.ClassId = tblClass.ClassId" +
                        " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId" +
                         " INNER JOIN tblFeesCategory ON tblFeesCategory.FeesCategoryId=tblStudent.FeesCategory " +
                       " where  AY.AcademicYearId= " + Session["AcademicYearId"].ToString() + " and tblStudentRouteAssign.CourseId='" + ddlCourse.SelectedValue + "' and tblStudentRouteAssign.ClassId='" + ddlClass.SelectedValue + "' and tblStudentRouteAssign.BranchId='" + ddlBranch.SelectedValue + "' group by UserCode,FirstName,MiddleName,LastName,tblBranch.branchname,TotalAmount,FeesCategoryName)" +
                       " select  StudentCode,StudentName 'Student Name',FeesCategory 'Fees Category' ,Sum(Total) 'Total Fees',Sum(Paid) 'Paid Fees',Sum(pending) 'Due Fees',FeesType 'FeesType'" +
                       " from AllData group by StudentCode,StudentNAme,FeesCategory,FeesType order by StudentCode";

                }
                else
                {
                    //query = "with AllData as(SELECT  tblStudent.UserCode," +
                    //" (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,(tblBranch.branchname +'('+tblClass.className+')')Class ,Convert(decimal(18,2),max(tblStudentFeesPaid.TotalAmount)) Total, " +
                    //" Convert(decimal(18,2),sum(tblStudentFeesPaid.PaidAmount)) Paid, Convert(decimal(18,2),(max(tblStudentFeesPaid.TotalAmount)-sum(tblStudentFeesPaid.PaidAmount))) Pending" +
                    //" FROM  tblStudent INNER JOIN tblStudentFeesPaid ON tblStudent.UserCode = tblStudentFeesPaid.StudentId" +
                    // " INNER JOIN tblCourse ON tblStudent.CourseId = tblCourse.CourseId" +
                    // " INNER JOIN tblBranch ON tblStudent.BranchId = tblBranch.BranchId" +
                    // " INNER JOIN tblClass ON tblStudent.ClassId = tblClass.ClassId" +
                    // " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId" +
                    //" where tblStudent.OrgId='" + orgId.ToString() + "' And " + Session["AcademicYearId"].ToString() + "  And " + Session["strquery"].ToString() + " group by UserCode,FirstName,MiddleName,LastName,tblBranch.branchname,tblClass.className" +
                    //" union all" +
                    //" SELECT  tblStudent.UserCode," +
                    //" (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName,(tblBranch.branchname +'('+tblClass.className+')')Class ,isnull(Convert(decimal(18,2),(SELECT Amount From tblRoute where RouteId=(SELECT RouteId from tblStudentRouteAssign where UserCode=tblStudent.UserCode))),0) Total, " +
                    //" isnull(Convert(decimal(18,2),sum(tblStudentBusFeesPaid.PaidAmount)),0) Paid, isnull(Convert(decimal(18,2),(tblStudentBusFeesPaid.TotalAmount-sum(tblStudentBusFeesPaid.PaidAmount))),0) Pending FROM" +
                    //"  tblStudent INNER JOIN tblStudentBusFeesPaid ON tblStudent.UserCode = tblStudentBusFeesPaid.StudentId" +
                    // " INNER JOIN tblCourse ON tblStudent.CourseId = tblCourse.CourseId" +
                    // " INNER JOIN tblBranch ON tblStudent.BranchId = tblBranch.BranchId" +
                    // " INNER JOIN tblClass ON tblStudent.ClassId = tblClass.ClassId" +
                    // " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId" +
                    //" where  tblStudent.OrgId='" + orgId.ToString() + "' And " + Session["AcademicYearId"].ToString() + "  And " + Session["strquery"].ToString() + " group by UserCode,FirstName,MiddleName,LastName,TotalAmount,tblBranch.branchname,tblClass.className)" +
                    //" select  UserCode,StudentName 'Student Name',Class,Sum(Total) 'Total Fees',Sum(Paid) 'Paid Fees',Sum(pending) 'Due Fees'" +
                    //" from AllData group by UserCode,StudentNAme,Class order by Class,UserCode";

                    query = "with AllData as(SELECT  tblStudent.UserCode as StudentCode," +
                    " (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName ,'School Fee ' FeesType,Convert(decimal(18,2),max(tblStudentFeesPaid.TotalAmount)) Total, " +
                    " Convert(decimal(18,2),sum(tblStudentFeesPaid.PaidAmount)) Paid,(tblFeesCategory.FeesCategoryName) FeesCategory, Convert(decimal(18,2),(max(tblStudentFeesPaid.TotalAmount)-sum(tblStudentFeesPaid.PaidAmount))) Pending" +
                    " from tblFees INNER join tblStudentFeesPaid on  isnull(tblFees.FeesId,0)=isnull(tblStudentFeesPaid.FeesId,0) " +
                     " INNER join tblStudent ON isnull(tblStudent.UserCode,0) = isnull(tblStudentFeesPaid.StudentId,0)" +
                     " INNER JOIN tblCourse ON tblFees.CourseId = tblCourse.CourseId" +
                     " INNER JOIN tblBranch ON tblFees.BranchId = tblBranch.BranchId" +
                     " INNER JOIN tblClass ON tblFees.ClassId = tblClass.ClassId" +
                      " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudent.AcademicYearId " +
                      "INNER JOIN tblFeesCategory ON tblFeesCategory.FeesCategoryId=tblFees.CasteCategoryId" +
                   " where tblFees.OrgId='" + orgId.ToString() + "' And tblFees.AcademicYearId='" + ddlAcademicYear.SelectedValue + "' and tblFees.CourseId='" + ddlCourse.SelectedValue + "' and tblFees.ClassId='" + ddlClass.SelectedValue + "' and tblFees.BranchId='" + ddlBranch.SelectedValue + "'group by tblStudent.UserCode,FirstName,MiddleName,LastName,TotalAmount,tblBranch.branchname,FeesCategoryName" +
                    " union all" +
                    " SELECT  tblStudent.UserCode as StudentCode," +
                    " (tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName) as StudentName ,'Bus Fee' as FeesType,isnull(Convert(decimal(18,2),(SELECT Amount From tblRoute where RouteId=(SELECT RouteId from tblStudentRouteAssign where UserCode=tblStudent.UserCode and courseId='"+ddlCourse.SelectedValue+"' and ClassId='"+ddlClass.SelectedValue+"' and BranchId='"+ddlBranch.SelectedValue+ "' and AcademicYearId='"+ddlAcademicYear.SelectedValue+"'))),0) Total, " +
                    " isnull(Convert(decimal(18,2),sum(tblStudentBusFeesPaid.PaidAmount)),0) Paid,(tblFeesCategory.FeesCategoryName) FeesCategory,  isnull(Convert(decimal(18,2),(tblStudentBusFeesPaid.TotalAmount-sum(tblStudentBusFeesPaid.PaidAmount))),0) Pending FROM" +
                    "  tblStudent INNER JOIN tblStudentBusFeesPaid ON tblStudent.UserCode = tblStudentBusFeesPaid.StudentId" +
                    " Inner Join tblStudentRouteAssign ON tblStudentRouteAssign.studentRouteId=tblStudentBusFeesPaid.StudentRouteId" +
                     " INNER JOIN tblCourse ON tblStudentRouteAssign.CourseId = tblCourse.CourseId" +
                     " INNER JOIN tblBranch ON tblStudentRouteAssign.BranchId = tblBranch.BranchId" +
                     " INNER JOIN tblClass ON tblStudentRouteAssign.ClassId = tblClass.ClassId" +
                     " INNER JOIN tblAcademicYear AY ON AY.AcademicYearId = tblStudentRouteAssign.AcademicYearId" +
                        //" INNER JOIN tblFees  ON tblFees.FeesId=tblStudentBusFeesPaid.BusFeesId" +
                        " INNER JOIN tblFeesCategory ON tblFeesCategory.FeesCategoryId=tblStudent.FeesCategory" +
                      " where tblStudent.OrgId='" + orgId.ToString() + "' And " + Session["AcademicYearId"].ToString() + " and tblStudentRouteAssign.CourseId='" + ddlCourse.SelectedValue + "' and tblStudentRouteAssign.ClassId='" + ddlClass.SelectedValue + "' and tblStudentRouteAssign.BranchId='" + ddlBranch.SelectedValue + "'group by tblStudent.UserCode,FirstName,MiddleName,LastName,TotalAmount,tblBranch.branchname,FeesCategoryName)" +
                    " select  StudentCode,StudentName 'Student Name',FeesCategory 'Fees Category',Sum(Total) 'Total Fees',Sum(Paid) 'Paid Fees',Sum(pending) 'Due Fees',FeesType 'FeesType'" +
                    " from AllData group by StudentCode,StudentNAme,FeesCategory,FeesType order by StudentCode";




                }

                Session["Staff"] = "StudentFeesStatus";
                Session["strquery1"] = query;

                database db = new database();
                DataTable dt = db.DisplaygridView(query);

                if (dt.Rows.Count > 0)
                {
                    Panel1.Visible = true;
                    btnExport.Visible = true;
                    //  lblStatus.Text = Session["class"].ToString();
                    // lblStatus.Text = ddlCourse.SelectedValue;
                    lblStatus.Text =":"+ddlCourse.SelectedItem.Text+" "+ddlBranch.SelectedItem.Text+" "+ddlClass.SelectedItem.Text+" ( "+ddlAcademicYear.SelectedItem.Text+" ) ";
                    Session["CourseName"] = lblStatus.Text;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    // lblStatus.Text = Session["class"].ToString();
                    lblStatus.Text =":"+ ddlCourse.SelectedItem.Text+" " + ddlBranch.SelectedItem.Text +" "+ ddlClass.SelectedItem.Text + " ( " + ddlAcademicYear.SelectedItem.Text + " ) ";
                    Session["CourseName"] = lblStatus.Text;
                    btnExport.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record not found !!!')", true);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../StudentFeesReport.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityWebApp;
using BusinessAccessLayer;
using System.Data;

namespace CMS.Forms.Admin
{
    public partial class StudentAdmissionList1 : System.Web.UI.Page
    {
        DataView dvBranch = null;
        DataView dvClass = null;
        DataView dvStudentData = null;
        int orgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
             orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
           
            if (!IsPostBack)
            {

                if (rblStatus.SelectedValue == "Pending")
                {
                    txtSearchStudname.Visible = false;
                    btnSearch.Visible = false;
                    lb1.Visible = false;
                }
                if (rblStatus.SelectedValue == "Cancel")
                {
                    txtSearchStudname.Visible = false;
                    btnSearch.Visible = false;
                    lb1.Visible = false;
                }
                if (rblStatus.SelectedValue == "Admission Completed")
                {
                    txtSearchStudname.Visible = true;
                    btnSearch.Visible = true;
                    lb1.Visible = true;
                }
                BindCourse();
            }
            

        }
        #region MyRegion
        
        #endregion

        public void rblStatusChanged()
        {
            string Status = rblStatus.SelectedItem.ToString();
            if (rblStatus.SelectedItem != null)
            {
                if (rblStatus.SelectedValue == "0")
                {
                    BindStudentList(Status);

                }
                else if (rblStatus.SelectedValue == "1")
                {
                    BindStudentList(Status);
                }
                else if (rblStatus.SelectedValue == "2")
                {
                    BindStudentList(Status);
                }
                else if (rblStatus.SelectedValue == "3")
                {
                    BindStudentList(Status);
                }
                else
                {
                    //GrdStudent.DataSource = ds.Tables[6];
                    //GrdStudent.DataBind();
                }
            }
        }

        public void BindStudentList(string rblStatus)
        {
            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.OrgId = Session["OrgId"].ToString();
            DataSet ds = objBL.BindCourses_BL(objEWA);
            ViewState["dvStudentData"] = ds.Tables[6];
            dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
            dvStudentData.RowFilter = "[Status] = '" + rblStatus + "'";
            GrdStudent.DataSource = dvStudentData;
            GrdStudent.DataBind();
            gvPrint.DataSource = dvStudentData;
            gvPrint.DataBind();

        }
       
        #region[Bind Course]

        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
      
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ViewState["dvBranch"] = ds.Tables[2];
                ViewState["dvClass"] = ds.Tables[3];
                //ViewState["dvStudentData"] = ds.Tables[6];

                ddlCourse.DataSource = ds.Tables[0];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("---Select---", "0"));

                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("---Select---", "0"));

                //GrdStudent.DataSource = ds.Tables[6];
                //GrdStudent.DataBind();
                //gvPrint.DataSource = ds.Tables[6];
                //gvPrint.DataBind();
                //ViewState["PrintData"] = ds.Tables[6]; 
                 //ViewState["dvStudentData_Completed"] = ds.Tables[8];
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Course Changed
        #region[Course Changed]

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

        #endregion

        //Bind Branch
        #region[Bind Branch]

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

                //GetStudentData();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Changed
        #region[Branch Changed]

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

        #endregion

        //Bind Class
        #region[Bind Class]

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
                //GetStudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Selected Class
        #region[Class Changed]

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //GetStudentData();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region GetStudentData Region
        private void GetStudentData()
        {
            string strQuery = null;
            if (rblStatus.SelectedValue == "Admission Completed")
            {
                dvStudentData = new DataView(ViewState["dvStudentData_Completed"] as DataTable);
                ViewState["PrintData"] = dvStudentData;
            }
            else
            {
                dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
                ViewState["PrintData"] = dvStudentData;
            }
            if (rblStatus.SelectedItem != null)
            {
                strQuery = "[Status] = '" + rblStatus.SelectedValue + "'";
            }
            if (ddlCourse.SelectedValue != "0")
            {
                if (rblStatus.SelectedItem != null)
                {
                    strQuery = "[CourseId] = " + ddlCourse.SelectedValue + " And [Status] = '" + rblStatus.SelectedValue + "'";
                }
                else
                {
                    strQuery = "[CourseId] = " + ddlCourse.SelectedValue + "";
                }
            }
            if (ddlBranch.SelectedValue != "0")
            {
                strQuery = strQuery + " And [BranchId] = " + ddlBranch.SelectedValue + "";
            }
            if (ddlClass.SelectedValue != "0")
            {
                strQuery = strQuery + " And [ClassId] = " + ddlClass.SelectedValue + "";
            }

            dvStudentData.RowFilter = strQuery;
            GrdStudent.DataSource = dvStudentData;
            GrdStudent.DataBind();


            gvPrint.DataSource = dvStudentData;
            gvPrint.DataBind();
            ViewState["PrintableData"] = strQuery;

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

        #region Print Region
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //if (ViewState["PrintableData"] != null)
            //{
            //    if (rblStatus.SelectedValue == "Admission Completed")
            //    {
            //        dvStudentData = new DataView(ViewState["dvStudentData_Completed"] as DataTable);
            //    }
            //    else{

            //        dvStudentData = new DataView(ViewState["dvStudentData"] as DataTable);
            //    }
            //    dvStudentData.RowFilter = ViewState["PrintableData"].ToString();
            //    dt = dvStudentData.ToTable();
            //}
            //else
            //{
            //    dt = ViewState["PrintData"] as DataTable;
            //}         
            dt = ViewState["PrintData"] as DataTable;
            DataSet ReportData = new DataSet();
            ReportData.Tables.Add(dt);
            HttpContext.Current.Session.Remove("ReportData");
            HttpContext.Current.Session.Add("ReportData", ReportData);
            gvPrint.DataSource = dt;
            gvPrint.DataBind();
            //Response.Redirect("~/Forms/Reports/ReportViewer.aspx?ReportName=crStudentAdmissionList");
            string url = "/Forms/Reports/ReportViewer.aspx?ReportName=crStudentAdmissionList";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "reportScript", "ReportOpen('" + url + "');", true);
        }
        #endregion
      
        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion CreateAccouncement Code

        protected void GrdStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "100px");
            }
        }

        protected void gvPrint_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[11].Visible = false;

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                //GetStudentData();

                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = ddlCourse.SelectedValue;
                objEWA.BranchId = ddlBranch.SelectedValue;
                objEWA.ClassId = ddlClass.SelectedValue;
                objEWA.Status = rblStatus.SelectedValue;
                DataSet ds = objBL.Bind_AdmissionCompleted_BL(objEWA);
                GrdStudent.DataSource = ds.Tables[0];
                GrdStudent.DataBind();
                gvPrint.DataSource = ds.Tables[0];
                gvPrint.DataBind();
                //ViewState["PrintData"]= ds.Tables[0];
              
            }
            catch (Exception ex) { }
        }
        //Added by Ashwini 23-Oct-2020
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            EWA_Common objEWA = new EWA_Common();
            BL_Common objBL = new BL_Common();
            objEWA.student = txtSearchStudname.Text;
            DataSet ds = objBL.GetStudentWiseData(objEWA);
            GrdStudent.DataSource = ds;
            GrdStudent.DataBind();
        }

        protected void rblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem li in rblStatus.Items)
            {
                if (li.Selected == true)
                {
                    if (li.Value == "Pending")
                    {
                        txtSearchStudname.Visible = false;
                        btnSearch.Visible = false;
                        lb1.Visible = false;
                    }
                    if (li.Value == "Cancel")
                    {
                        txtSearchStudname.Visible = false;
                        btnSearch.Visible = false;
                        lb1.Visible = false;
                    }
                    if (li.Value == "Admission Completed")
                    {
                        txtSearchStudname.Visible = true;
                        btnSearch.Visible = true;
                        lb1.Visible = true;
                    }
                }
            }
        }
    }
}
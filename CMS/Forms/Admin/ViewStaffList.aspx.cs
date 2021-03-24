using System;
using System.Data;
using BusinessAccessLayer;
using EntityWebApp;
using System.IO;
using System.Web.UI;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;

//View Staff
namespace CMS.Forms.Admin
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        //Page Load
        int OrgID = 0;
        #region[Page Load]


        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                 OrgID = Convert.ToInt32(Session["OrgId"]);
                int AcademicYearId = Convert.ToInt32(Session["AcadmicYear"]);

                if (OrgID == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    BindCourse();

                }
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

                
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Staff Grid Data
        #region[Bind Staff Grid Data]

        private void BindStaffGridData()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Convert.ToString(Session["OrgId"]);
                objEWA.CourseId = ddlCourse.SelectedValue;
                //objEWA.DesignationId = ddlDesignation.SelectedItem.ToString();
                // objEWA.DepartmentId = ddlDepartment.SelectedItem.ToString();
                DataSet ds = objBL.BindStaffList_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    GrdStaff.DataSource = ds;
                    GrdStaff.DataBind();
                    btnDownload.Visible = true;
                }
                else
                {
                    GrdStaff.DataSource = null;
                    GrdStaff.DataBind();
                    btnDownload.Visible = false;
                }
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

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStaffGridData();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string str = "SELECT  e.UserCode,(FirstName + ' ' + MiddleName + ' ' + LastName) StaffName, " +
                "tblDesignation.DesignationName,tblDepartment.DepartmentName,tblDesignationType.DesignationType, "+
                        "Convert(varchar(10), DOB, 103)DOB,Mobile,Email,Convert(varchar(10),DateOfJoining, 103)DateOfJoining " +
                        "from tblEmployee e INNER Join tblEmpAssignSubject ea ON ea.UserCode = e.UserCode " +
                        "INNER JOIN tblEmpAssignDeptDes on tblEmpAssignDeptDes.UserCode=e.UserCode" +
                        " INNER JOIN tblDesignation on tblDesignation.DesignationId=tblEmpAssignDeptDes.DesignationId" +
                        "  INNER JOIN tblDepartment on tblDepartment.DepartmentId=tblEmpAssignDeptDes.DepartmentId" +
                        "  INNER JOIN tblDesignationType on tblDesignationType.DesignationTypeId=tblEmpAssignDeptDes.DesignationTypeId" +
                        " where ea.Courseid = "+ ddlCourse.SelectedValue +" AND e.OrgId = "+ Session["OrgId"].ToString() +
                        " group by e.UserCode,FirstName,MiddleName,LastName,DOB,Mobile,Email,DateOfJoining,  tblDesignation.DesignationName,tblDepartment.DepartmentName,tblDesignationType.DesignationType";

            Session["strquery1"] = str;
            Session["Course"] = ddlCourse.SelectedItem;
            Session["Staff"] = "StaffList";

            Response.Redirect("~/StudentFeesReport.aspx");
            //ExportGridToPDF();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        

        private void ExportGridToPDF()
        {
            try
            {

                string dt = System.DateTime.Now.ToString("MM/yyyy");
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=StaffList" + dt + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                Panel1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                //GrdStaff.AllowPaging = true;
                //GrdStaff.DataBind();
            }
            catch(Exception exs)
            {

            }
        }
    }
}
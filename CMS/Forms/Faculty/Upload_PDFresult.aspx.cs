using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using EntityWebApp.Faculty;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Faculty
{
    public partial class Upload_PDFresult : System.Web.UI.Page
    {
        //Objects

        #region[Objects]
        

        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;
        #endregion

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
                    try
                    {
                        BindCourse();
                        BindAcademinYear();
                    }
                    catch (Exception exp)
                    {

                    }
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
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

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        #region[Bind Academin Year]

        private void BindAcademinYear()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindAcademicYear_BL(objEWA);

                ddlAcademicyear.DataSource = ds;
                ddlAcademicyear.DataTextField = "AcademicYear";
                ddlAcademicyear.DataValueField = "AcademicYearId";
                ddlAcademicyear.DataBind();
                ddlAcademicyear.Items.Insert(0, new ListItem("Select", "0"));
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
                ddlBranch.Items.Insert(0, new ListItem("Select", "0"));

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
                ddlClass.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        #region[Bind GrdResult]

        private void BindGrdResult()
        {
            try
            {
                BL_UploadResult objBL = new BL_UploadResult();
                EWA_UploadResult objEWA = new EWA_UploadResult();
                objEWA.Action = "FatchResultPDF";
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                DataSet ds = objBL.FatchResultPDF_BL(objEWA);
                
                grdResults.DataSource = ds;
                grdResults.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void BindGrdResult1()
        {
            try
            {
                BL_UploadResult objBL = new BL_UploadResult();
                EWA_UploadResult objEWA = new EWA_UploadResult();
                objEWA.Action = "FatchResultPDF1";
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.AcademinYear = ddlAcademicyear.SelectedValue.ToString();
                DataSet ds = objBL.FatchResultPDF_BL1(objEWA);

                grdResults.DataSource = ds;
                grdResults.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion


        #region[btn Upload]

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {

                string fileEXT = Path.GetExtension(FileUpload1.FileName);
                if (fileEXT.CompareTo(".pdf") == 0 || fileEXT.CompareTo(".PDF") == 0)
                {
                    BL_UploadResult objBL = new BL_UploadResult();
                    EWA_UploadResult objEWA = new EWA_UploadResult();

                    objEWA.Action = "UploadResultPDF";
                    objEWA.TestName = txtTestName.Text;
                    objEWA.OrgId = Session["OrgId"].ToString();
                    objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                    objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                    objEWA.ClassId = ddlClass.SelectedValue.ToString();
                    objEWA.AcademinYear = ddlAcademicyear.SelectedValue.ToString();
                    int fileLengthInKB = 0;
                    if (FileUpload1.HasFile)
                    {
                        int length = FileUpload1.PostedFile.ContentLength;
                        objEWA.UploadedFile = new byte[length];
                        objEWA.FileName = FileUpload1.PostedFile.FileName.ToString();
                        objEWA.ContentType = FileUpload1.PostedFile.ContentType;
                        fileLengthInKB = FileUpload1.PostedFile.ContentLength / 1024;
                        HttpPostedFile file = FileUpload1.PostedFile;
                        file.InputStream.Read(objEWA.UploadedFile, 0, length);
                    }

                    if (fileLengthInKB > 1024)
                    {
                        msgBox.ShowMessage("Document should be less than or equal to 1MB !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else
                    {
                        int flag = objBL.InsertUploadResultPDF_BL(objEWA);

                        msgBox.ShowMessage("Result PDF Upload Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        clear();
                        BindGrdResult();
                    }
                }
                else
                {
                    msgBox.ShowMessage("Please choose .pdf file only.", "Information", CMS.UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception ex)
            {
                msgBox.ShowMessage("Unable to Save !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
            }

        }

        #endregion

        public void clear()
        {
            //ddlCourse.ClearSelection();
            //ddlBranch.ClearSelection();
            //ddlClass.ClearSelection();
            //ddlAcademicyear.ClearSelection();
            txtTestName.Text = "";
            FileUpload1.Attributes.Clear();
        }

        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
            //Response.Write("<script>alert('" + msg + "')</script>");
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlAcademicyear.SelectedValue == "0")
            {
                BindGrdResult();
            }
            else
            {
                BindGrdResult1();
            }
        }


        //lnkBtnDelete_Click
        #region lnkBtnDelete_Click

        protected void lnkBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["TestId"] = grdResults.DataKeys[grdrow.RowIndex].Values["TestId"].ToString();

                    BL_UploadResult objBL = new BL_UploadResult();
                    EWA_UploadResult objEWA = new EWA_UploadResult();

                    objEWA.Action = "DeleteResultPDF";
                    objEWA.TestId = ViewState["TestId"].ToString();

                    int flag= objBL.DeleteUploadResultPDF_BL(objEWA);

                    msgBox.ShowMessage("Delete Successfully !!!", "Delete", UserControls.MessageBox.MessageStyle.Successfull);
                    BindGrdResult();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlAcademicyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrdResult1();
        }
    }
}
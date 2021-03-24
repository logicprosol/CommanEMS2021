using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using EntityWebApp;
using EntityWebApp.Faculty;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Student
{
    public partial class ViewAnnualResult : System.Web.UI.Page
    {
        public static int orgId,CourseId,BranchId,ClassId,StudentId;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgID"]);
                StudentId = Convert.ToInt32(Session["UserCode"].ToString());
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    
                    Get_OrganizationDetails(orgId);
                    FatchStudent();
                    BindSemester();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        private void Get_OrganizationDetails(int OrgID)
        {
            try
            {
                BL_SuperAdmin objBL = new BL_SuperAdmin();
                EWA_SuperAdmin objEWA = new EWA_SuperAdmin();

                DataSet ds = objBL.Get_OrganizationDetails(OrgID);

                string StaffPhoto = ds.Tables[0].Rows[0]["Logo"].ToString();
                if (StaffPhoto != null && StaffPhoto != "")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    ImageButton_logo.ImageUrl = "data:image/png;base64," + base64String;
                }

                lbl_CollegeName.Text = ds.Tables[0].Rows[0]["OrgName"].ToString();
                lbl_CollegeAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                //Lbl_TrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();

            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                //throw exp;
            }
        }

        #region[Fatch Student]

        private void FatchStudent()
        {
            try
            {
                EWA_UploadResult objEWA = new EWA_UploadResult();
                BL_UploadResult objBL = new BL_UploadResult();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserCode = Session["UserCode"].ToString();

                DataSet ds = objBL.FatchStudent_BL(objEWA);


                if (ds.Tables[0].Rows.Count != 0)
                {
                    lblName.Text = ds.Tables[0].Rows[0][1].ToString();
                    lblCourse.Text = ds.Tables[0].Rows[0][2].ToString();
                    lblBranch.Text = ds.Tables[0].Rows[0][3].ToString();
                    lblClass.Text = ds.Tables[0].Rows[0][4].ToString();
                    CourseId = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
                    BranchId = Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString());
                    ClassId = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        
        #endregion

        #region[Bind Semester]

        private void BindSemester()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                //objEWA.OrgId = Session["OrgId"].ToString();
                //objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                //objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ClassId.ToString(); ;
                DataSet ds = objBL.BindSemester_BL(objEWA);

                ddlSemester.DataSource = ds;
                if (ds.Tables[0].Rows.Count != 0)
                {
                    
                    ddlSemester.DataTextField = "SemesterName";
                    ddlSemester.DataValueField = "SemesterId";
                    ddlSemester.DataBind();
                }
                else
                    ddlSemester.Items.Clear();

                ddlSemester.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            FatchTest();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }

        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            FatchResult();
        }

        #region[Fatch Test]

        private void FatchTest()
        {
            try
            {
                EWA_UploadResult objEWA = new EWA_UploadResult();
                BL_UploadResult objBL = new BL_UploadResult();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = CourseId.ToString();
                objEWA.BranchId = BranchId.ToString();
                objEWA.ClassId = ClassId.ToString();
                objEWA.SemesterId = ddlSemester.SelectedValue.ToString();

                DataSet ds = objBL.FatchTest_BL(objEWA);

                ddlTest.DataSource = ds;
                if (ds.Tables[0].Rows.Count != 0)
                {
                    
                    ddlTest.DataTextField = "TestName";
                    ddlTest.DataValueField = "TestId";
                    ddlTest.DataBind();
                }
                else
                    ddlTest.Items.Clear();

                ddlTest.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        #region[Fatch Result]

        private void FatchResult()
        {
            try
            {
                EWA_UploadResult objEWA = new EWA_UploadResult();
                BL_UploadResult objBL = new BL_UploadResult();
                objEWA.TestId = ddlTest.SelectedValue.ToString();
                objEWA.UserCode = Session["UserCode"].ToString();

                DataSet ds = objBL.FatchResult_BL(objEWA);
                

                if (ds.Tables[0].Rows.Count != 0)
                {
                    lblSemester.Text = ddlSemester.SelectedItem.ToString();
                    //GridView1.DataSource = ds.Tables[0];
                    //GridView1.DataBind();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Subject");
                    dt.Columns.Add("Out Of Marks");
                    dt.Columns.Add("Obtain Marks");


                    DataRow dr;

                    int i = 0,totalobtain=0,totaloutof=0,rs=0;
                    while(ds.Tables[0].Rows.Count > i)
                    {
                        dr = dt.NewRow();
                        dr[0] = ds.Tables[0].Rows[i][0].ToString();
                        dr[1] = ds.Tables[0].Rows[i][2].ToString();
                        dr[2] = ds.Tables[0].Rows[i][1].ToString();

                        totalobtain = totalobtain + Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                        totaloutof = totaloutof + Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());

                        if ((ds.Tables[0].Rows[i][3].ToString()).ToUpper() != "PASS")
                        {
                            rs = 1;
                        }
                        i++;
                        dt.Rows.Add(dr);
                    }

                    dr = dt.NewRow();
                    dr[0] = "TOTAL";
                    dr[1] = totaloutof;
                    dr[2] = totalobtain;
                    dt.Rows.Add(dr);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    
                    float per = (totalobtain * 100) / totaloutof;
                    lblPersentage.Text = per.ToString() + " %";

                    if (rs == 0)
                        lblResult.Text = "PASS";
                    else
                        lblResult.Text = "FAILED";

                    GridView1.Rows[GridView1.Rows.Count - 1].Font.Bold = true;
                    i = 0;
                    while(GridView1.Rows.Count>i)
                    {
                        GridView1.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Center;
                        GridView1.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Center;
                        i++;
                    }

                    Panel2.Visible = true;
                }
                else
                    GeneralErr("Record Not Found...!");

            
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
            //Response.Write("<script>alert('" + msg + "')</script>");
        }

        private void ExportGridToPDF()
        {
           
            string dt = System.DateTime.Now.ToString("MM/yyyy");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Result_" + Session["UserCode"].ToString() +"_" +dt + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel2.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
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
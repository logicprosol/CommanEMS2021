using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using EntityWebApp.Faculty;
using BusinessAccessLayer.Faculty;

namespace Forms.Faculty
{
    public partial class Upload_result : System.Web.UI.Page
    {

        //Objects

        #region[Objects]
        private BL_Subject objBL = new BL_Subject();
        private EWA_Subject objEWA = new EWA_Subject();

        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;
        #endregion

        //Page Load
        #region[Page Load]

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
                        //GrdSubjectBind();
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
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
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

        //#region[Bind Semester]

        //private void BindSemester()
        //{
        //    try
        //    {
        //        EWA_Common objEWA = new EWA_Common();
        //        BL_Common objBL = new BL_Common();
        //        //objEWA.OrgId = Session["OrgId"].ToString();
        //        //objEWA.CourseId = ddlCourse.SelectedValue.ToString();
        //        //objEWA.BranchId = ddlBranch.SelectedValue.ToString();
        //        objEWA.ClassId = ddlClass.SelectedValue.ToString();
        //        DataSet ds = objBL.BindSemester_BL(objEWA);

        //        ddlSemester.DataSource = ds;
        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            ddlSemester.DataTextField = "SemesterName";
        //            ddlSemester.DataValueField = "SemesterId";
        //            ddlSemester.DataBind();
        //        }
        //        else
        //            ddlSemester.Items.Clear();

        //        ddlSemester.Items.Insert(0, new ListItem("Select", "0"));

        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        //#endregion



        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                BindUploadResult();
            }
            catch(Exception ex)
            { }

            //if (FileUpload1.HasFile)
            //{
            //    ChooseFile();
            //    BindUploadResult();



                //database db = new database();
                //string email = db.getDbstatus_Value("select tblEmployee.Email from tblEmployee inner join tblUser on tblEmployee.UserCode=tblUser.UserCode where tblUser.Role='Admin' and tblUser.OrgId='" + Session["OrgId"] + "' "); 
                //string to = "logicprosol@gmail.com";
                //string from = "Schoolerp999@gmail.com";
                //string subject = "Upload Result";
                //string body = "Hi Please Upload result Find with Attchment";
                //using (MailMessage mm = new MailMessage("Schoolerp999@gmail.com", email))
                //{
                //    mm.Subject = "Upload Result";
                //    mm.Body = "Hi Please Upload result Find with Attchment";
                //    if (FileUpload1.HasFile)
                //    {
                //        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //        mm.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileName));
                //    }
                //    mm.CC.Add (new MailAddress(email.ToString())); 
                //    mm.IsBodyHtml = false;
                //    SmtpClient smtp = new SmtpClient();
                //    smtp.Host = "smtp.gmail.com";
                //    smtp.EnableSsl = true;
                //    NetworkCredential NetworkCred = new NetworkCredential("Schoolerp999@gmail.com", "logicpro@2017");
                //    smtp.UseDefaultCredentials = true;
                //    smtp.Credentials = NetworkCred;
                //    smtp.Port = 587;
                //    smtp.Send(mm);
                //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                //}
            //}
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    con.Open();
                    DataTable dtExcelSchema;
                    dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();

                    
                    OleDbCommand dbCommand = new OleDbCommand("select * from ["+ sheetName +"]", con);
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter(dbCommand); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch(Exception ex) { }
            }
            return dtexcel;
        }

        //private void ChooseFile()
        //{
        //    string filePath = string.Empty;
        //    string fileExt = string.Empty;
        //    string folderPath = Server.MapPath("~/Upload/");
        //    //Check whether Directory (Folder) exists.
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(folderPath);
        //    }
        //    //folderPath = folderPath + Path.GetFileName(FileUpload1.FileName);
        //    //Save the File to the Directory (Folder).
        //    FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));
        //    //OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
        //    if (FileUpload1.HasFile)// file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
        //    {
        //        filePath = folderPath + Path.GetFileName(FileUpload1.FileName);//file.FileName; //get the path of the file  
        //        fileExt = Path.GetExtension(filePath); //get the file extension  
        //        if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
        //        {
        //            try
        //            {
        //                DataTable dtExcel = new DataTable();
        //                dtExcel = ReadExcel(filePath, fileExt); //read excel file  
                        
        //                GridView1.DataSource = dtExcel;
        //                GridView1.DataBind();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message.ToString());
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
        //        }

        //        if(File.Exists(filePath))
        //        {
        //            File.Delete(filePath);
        //        }
                
        //    }
        //}

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
            //Response.Write("<script>alert('" + msg + "')</script>");
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindSemester();
        }

        public void BindUploadResult()
        {
            try
            {
                database db = new database();
                EWA_UploadResult objEWA1 = new EWA_UploadResult();
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                //objEWA.SemesterId = ddlSemester.SelectedValue.ToString();

                DataSet ds = objBL.BindResultFormat_BL(objEWA);

                
                int row = 0,rs=0;
                if (grdResultFormat.Rows.Count > row && ds.Tables[0].Rows.Count > 0)
                {
                    EWA_UploadResult objEWA2 = new EWA_UploadResult();

                    objEWA2.Action = "InsertUploadTest";
                    objEWA2.TestName = txtTestName.Text;
                    objEWA2.TotalMark = txtTotalMarks.Text;
                    objEWA2.OrgId = Session["OrgId"].ToString();
                    objEWA2.BranchId = ddlBranch.SelectedValue.ToString();
                    objEWA2.CourseId = ddlCourse.SelectedValue.ToString();
                    objEWA2.ClassId = ddlClass.SelectedValue.ToString();
                    objEWA2.SemesterId = null;
                    objEWA2.Status = "1";

                    rs = InsertUploadTest(objEWA2);
                }
                else
                {
                    GeneralErr("Record Not Found...!");
                }

                while (grdResultFormat.Rows.Count > row && ds.Tables[1].Rows.Count > row )
                {
                    int countColumn = grdResultFormat.Rows[0].Cells.Count;
                    EWA_UploadResult objEWA3 = new EWA_UploadResult();
                    objEWA3.Action = "InsertUploadResult";
                    objEWA3.TestId = db.getDbstatus_Value("SELECT MAX(TestId) FROM tblUploadTest");
                    objEWA3.UserCode = grdResultFormat.Rows[row].Cells[0].Text;
                  //  TextBox txtResult = (TextBox)grdResultFormat.Rows[row].Cells[countColumn - 1].FindControl("txt" + (countColumn - 1));


                    TextBox txtResult = (TextBox)grdResultFormat.Rows[row].FindControl("Textresult");
                    if (txtResult.Text == "")
                        objEWA3.Result = "-";
                    else
                        objEWA3.Result = txtResult.Text;
                    

                    //TextBox txtResult = (TextBox)grdResultFormat.Rows[row].FindControl("txt3");
                    //if (txtResult.Text == "")
                    //    objEWA3.Result = "-";
                    //else
                    //    objEWA3.Result = txtResult.Text;
                    


                    rs = InsertUploadResult(objEWA3);

                    string id= db.getDbstatus_Value("SELECT MAX(ResultId) FROM tblUploadResult"); 
                    int i = 0, j = 2;
                    while (ds.Tables[0].Rows.Count > i && (countColumn-1) > j)
                    {
                        //if (grdResultFormat.Rows[0].Cells[j].Text == ds.Tables[0].Rows[i][1].ToString())
                        //{
                            EWA_UploadResult objEWA4 = new EWA_UploadResult();
                            objEWA4.Action = "InsertUploadMark";
                            objEWA4.ResultId = id;
                            objEWA4.SubjectId = ds.Tables[0].Rows[i][0].ToString();

                            TextBox txtmark = (TextBox)grdResultFormat.Rows[row].Cells[j].FindControl("txt" + j);
                     //   TextBox txtmark = (TextBox)grdResultFormat.Rows[row].Cells[j].FindControl("txt" + j);
                        if (txtmark.Text==null)
                                objEWA4.Mark = "0";
                            else
                                objEWA4.Mark = txtmark.Text;

                            TextBox txtOutofmark = (TextBox)grdResultFormat.Rows[row].Cells[j+1].FindControl("txt" + j+1);
                            if (txtOutofmark.Text == null)
                                objEWA4.Outofmark = "0";
                            else
                                objEWA4.Outofmark = txtOutofmark.Text;

                            rs = InsertUploadMark(objEWA4);
                        //}
                        i++;
                        j = j + 2;
                    }
                    row++;
                }

                if(rs>0)
                {
                    //GeneralErr("Successfully Result Upload");
                    msgBox.ShowMessage("Successfull Result Upload", "Successfull", CMS.UserControls.MessageBox.MessageStyle.Successfull);
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        
        public int InsertUploadTest(EWA_UploadResult objEWA1)
        {
            BL_UploadResult objBL = new BL_UploadResult();
            int rs=objBL.InsertUploadTest_BL(objEWA1);
            return rs;
        }

        public int InsertUploadResult(EWA_UploadResult objEWA1)
        {
            BL_UploadResult objBL = new BL_UploadResult();
            int rs = objBL.InsertUploadResult_BL(objEWA1);
            return rs;
        }

        public int InsertUploadMark(EWA_UploadResult objEWA1)
        {
            BL_UploadResult objBL = new BL_UploadResult();
            int rs = objBL.InsertUploadMark_BL(objEWA1);
            return rs;
        }


        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                grdResultFormat.Columns.Clear();

                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                //objEWA.SemesterId = ddlSemester.SelectedValue.ToString();

                DataSet ds = objBL.BindResultFormat_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {


                    BoundField bfield = new BoundField();
                    bfield.HeaderText = "UserCode";
                    bfield.DataField = "UserCode";
                    grdResultFormat.Columns.Add(bfield);

                    bfield = new BoundField();
                    bfield.HeaderText = "Student Name";
                    bfield.DataField = "StudentName";
                    grdResultFormat.Columns.Add(bfield);

                    TemplateField tfield = new TemplateField();
                    int i = 0;
                    while (ds.Tables[0].Rows.Count > i)
                    {

                        tfield = new TemplateField();
                        tfield.HeaderText = ds.Tables[0].Rows[i][1].ToString();
                        tfield.ItemTemplate = new TextColumn();
                        grdResultFormat.Columns.Add(tfield);

                        tfield = new TemplateField();
                        tfield.HeaderText = ds.Tables[0].Rows[i][1].ToString().Substring(0, 3) + " Total";
                        tfield.ItemTemplate = new TextColumn();
                        grdResultFormat.Columns.Add(tfield);
                        
                        i++;
                    }
                    tfield = new TemplateField();
                    tfield.HeaderText = "Result";
                    tfield.ItemTemplate = new TextresultColumn();
                    grdResultFormat.Columns.Add(tfield);

                    grdResultFormat.AutoGenerateColumns = false;
                   

                    //DataTable dt = new DataTable();

                    //dt.Columns.Add("UserCode");
                    //dt.Columns.Add("Student Name");
                    //int i = 0;
                    //while (ds.Tables[0].Rows.Count > i)
                    //{
                    //    dt.Columns.Add(ds.Tables[0].Rows[i][1].ToString() );
                    //    dt.Columns.Add((ds.Tables[0].Rows[i][1].ToString()).Substring(0, 3) + " Total" );
                    //    i++;
                    //}
                    //dt.Columns.Add("Result");

                    //i = 0;
                    //while (ds.Tables[1].Rows.Count > i)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    dr[0] = ds.Tables[1].Rows[i][0].ToString();
                    //    dr[1] = ds.Tables[1].Rows[i][1].ToString();
                        
                    //    i++;
                    //    dt.Rows.Add(dr);

                    //}


                    grdResultFormat.DataSource = ds.Tables[1];
                    grdResultFormat.DataBind();
                    grdResultFormat.CellPadding = 10;
                    if (grdResultFormat.Rows.Count < 0)
                        grdResultFormat.Rows[0].Cells[0].Text = "Record not found !!!";
                    //else
                    //{
                    //    for(i=0; grdResultFormat.Rows.Count>i;i++)
                    //    {
                    //        int j;
                    //        for (j=2;(grdResultFormat.Rows[i].Cells.Count-1)>j;j++)
                    //        {
                    //            TextBox txt = new TextBox();
                    //            txt.Width = 30;
                    //            txt.MaxLength = 3;
                    //            txt.ID = "txt" + j;
                                
                    //            grdResultFormat.Rows[i].Cells[j].Controls.Add(txt);
                    //        }
                    //        TextBox txt1 = new TextBox();
                    //        txt1.Width = 60;
                    //        txt1.ID = "txt" + j;
                    //        grdResultFormat.Rows[i].Cells[j].Controls.Add(txt1);
                    //    }

                    //}

                    //export();

                    Panel1.Visible = true;
                    btnUpload.Visible = true;

                }
                else
                {
                    Panel1.Visible = false;
                    btnUpload.Visible = false;
                    GeneralErr("Not Found Recoder...!");
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

        }


        //protected void btnGo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        EWA_Common objEWA = new EWA_Common();
        //        BL_Common objBL = new BL_Common();
        //        objEWA.OrgId = Session["OrgID"].ToString();
        //        objEWA.BranchId = ddlBranch.SelectedValue.ToString();
        //        objEWA.CourseId = ddlCourse.SelectedValue.ToString();
        //        objEWA.ClassId = ddlClass.SelectedValue.ToString();
        //        //objEWA.SemesterId = ddlSemester.SelectedValue.ToString();

        //        DataSet ds = objBL.BindResultFormat_BL(objEWA);

        //        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
        //        {


        //            BoundField bfield = new BoundField();
        //            bfield.HeaderText = "UserCode";
        //            bfield.DataField = "UserCode";
        //            grdResultFormat.Columns.Add(bfield);

        //            bfield = new BoundField();
        //            bfield.HeaderText = "Student Name";
        //            bfield.DataField = "StudentName";
        //            grdResultFormat.Columns.Add(bfield);

        //            TemplateField tfield = new TemplateField();
        //            int i = 0;
        //            while (ds.Tables[0].Rows.Count > i)
        //            {

        //                tfield = new TemplateField();
        //                tfield.HeaderText = ds.Tables[0].Rows[i][1].ToString();
        //                grdResultFormat.Columns.Add(tfield);

        //                tfield = new TemplateField();
        //                tfield.HeaderText = ds.Tables[0].Rows[i][1].ToString().Substring(0, 3) + " Total";
        //                grdResultFormat.Columns.Add(tfield);

        //                i++;
        //            }
        //            tfield = new TemplateField();
        //            tfield.HeaderText = "Result";
        //            grdResultFormat.Columns.Add(tfield);




                    //DataTable dt = new DataTable();

                    //dt.Columns.Add("UserCode");
                    //dt.Columns.Add("Student Name");
                    //int i = 0;
                    //while (ds.Tables[0].Rows.Count > i)
                    //{
                    //    dt.Columns.Add(ds.Tables[0].Rows[i][1].ToString() );
                    //    dt.Columns.Add((ds.Tables[0].Rows[i][1].ToString()).Substring(0, 3) + " Total" );
                    //    i++;
                    //}
                    //dt.Columns.Add("Result");

                    //i = 0;
                    //while (ds.Tables[1].Rows.Count > i)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    dr[0] = ds.Tables[1].Rows[i][0].ToString();
                    //    dr[1] = ds.Tables[1].Rows[i][1].ToString();
                        
                    //    i++;
                    //    dt.Rows.Add(dr);

                    //}


                    //grdResultFormat.DataSource = ds.Tables[1];
                    //grdResultFormat.DataBind();
                    //grdResultFormat.CellPadding = 10;
                    //if (ds.Tables[1].Rows.Count < 0)
                    //    grdResultFormat.Rows[0].Cells[0].Text = "Record not found !!!";
                    //else
                    //{
                    //    for(i=0; grdResultFormat.Rows.Count>i;i++)
                    //    {
                    //        int j;
                    //        for (j=2;(grdResultFormat.Rows[i].Cells.Count-1)>j;j++)
                    //        {
                    //            TextBox txt = new TextBox();
                    //            txt.Width = 30;
                    //            txt.MaxLength = 3;
                    //            txt.ID = "txt" + j;
                                
                    //            grdResultFormat.Rows[i].Cells[j].Controls.Add(txt);
                    //        }
                    //        TextBox txt1 = new TextBox();
                    //        txt1.Width = 60;
                    //        txt1.ID = "txt" + j;
                    //        grdResultFormat.Rows[i].Cells[j].Controls.Add(txt1);
                    //    }

                    //}

                    //export();

        //            Panel1.Visible = true;
        //            btnUpload.Visible = true;

        //        }
        //        else
        //        {
        //            Panel1.Visible = false;
        //            btnUpload.Visible = false;
        //            GeneralErr("Not Found Recoder...!");
        //        }

        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }

        //}

    }


    class TextColumn : ITemplate
    {
        public void InstantiateIn(System.Web.UI.Control container)
        {
            TextBox txt = new TextBox();
            txt.Width = 30;
            txt.MaxLength = 3;
            txt.ID = "txt";
            container.Controls.Add(txt);
        }
    }

    class TextresultColumn : ITemplate
    {
        public void InstantiateIn(System.Web.UI.Control container)
        {
            DropDownList ddresult = new DropDownList();
            ddresult.Width = 80;
            ddresult.Items.Add(new ListItem("Select", "0"));
            ddresult.Items.Add(new ListItem("Pass", "1"));
            ddresult.Items.Add(new ListItem("Failed", "2"));
            ddresult.Items.Add(new ListItem("Absent", "3"));
            container.Controls.Add(ddresult);
        }
    }



    //class TextColumn : ITemplate
    //{
    //    public void InstantiateIn(System.Web.UI.Control container)
    //    {
    //        TextBox txt = new TextBox();
    //        txt.Width = 30;
    //        txt.MaxLength = 3;
    //        txt.ID = "txt";
    //        container.Controls.Add(txt);
    //    }
    //}
    
}
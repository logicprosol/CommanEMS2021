using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EntityWebApp;
using BusinessAccessLayer;
using DataAccessLayer;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System.IO;

namespace CMS.Forms.Faculty
{
    public partial class AddQuestion : System.Web.UI.Page
    {
        public static int orgId=0;
        database db = new database();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        string id;
        BL_AddTest BAL_AddTest = new BL_AddTest();
        EWA_AddTest Obj_AddTest = new EWA_AddTest();

        BL_AddQuestions BL_AddQuestions = new BL_AddQuestions();
        EWA_AddQuestions Obj_AddQuestions = new EWA_AddQuestions();
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                //if (Request.QueryString["queId"] != null)
                //{
                //    id = Request.QueryString["queId"].ToString();
                //}

                if(!IsPostBack)
                {
                    if (Request.QueryString["queId"] == null)
                    {
                        BindCourse();
                        disable();
                        ddlPattern.ClearSelection();
                        ddlUnitType.Text = "";
                        ddlClass.ClearSelection();
                        drpSubject.ClearSelection();
                        ddlCourse.ClearSelection();
                        ddlBranch.ClearSelection();
                        Button1.Enabled = false;
                        btnSave.Enabled = false;
                        //btnupdate.Enabled = false;
                        btnCancel.Enabled = false;
                        Image1.Visible = false;
                    }
                }

                btnSave.Visible = true;
                
                //btndelete.Visible = false;
                //btnupdate.Visible = false;


                if (Request.QueryString["queId"] != null)
                {
                    if (!IsPostBack)
                    {

                        ddlPattern.Enabled = false;
                        ddlUnitType.Enabled = false;
                        ddlCourse.Enabled = false;
                        ddlBranch.Enabled = false;
                        ddlClass.Enabled = false;
                        drpSubject.Enabled = false;
                        btnSave.Enabled = false;
                        //btnupdate.Enabled = true;
                        enable();

                        id = Request.QueryString["queId"].ToString();
                        //SqlCommand cmd1 = new SqlCommand(" SELECT        queId, pattern, unitType, answer, question, SubjectName, OrgId, class, optD, optB, optA, optC  FROM            tblAddQuestion WHERE ([queId] = '" + id.ToString() + "')", cn);
                        //SqlCommand cmd1 = new SqlCommand("SELECT  tblLibAddBook.BookName, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblStudent.FirstName, tblLibAddGroup.GroupName FROM            tblLibAddBook INNER JOIN                          tblLibIssueBook ON tblLibAddBook.BookId = tblLibIssueBook.BookId INNER JOIN                          tblLibAddGroup ON tblLibAddBook.GroupId = tblLibAddGroup.GroupId AND tblLibIssueBook.GroupId = tblLibAddGroup.GroupId INNER JOIN                          tblStudent ON tblLibIssueBook.StudentId = tblStudent.StudentId WHERE        (tblLibIssueBook.StudentId = '" + id.ToString()+ "') ", cn);
                        SqlCommand cmd1 = new SqlCommand("sp_Insert_TestDetails", cn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@Action", "Fetch_Question_ById");
                        cmd1.Parameters.AddWithValue("@QuestionId",id);

                        SqlDataAdapter adp1 = new SqlDataAdapter();
                        DataSet ds1 = new DataSet();
                        adp1.SelectCommand = cmd1;
                        adp1.Fill(ds1);


                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            btnSave.Visible = false;
                            //btndelete.Visible = true;
                            //btnupdate.Visible = true;
                            //ddlPattern.SelectedItem.Text = ds1.Tables[0].Rows[0]["pattern"].ToString();
                            //ddlUnitType.Text = ds1.Tables[0].Rows[0]["unitType"].ToString();
                            txtAnswe.Text = ds1.Tables[0].Rows[0]["Answer"].ToString();
                            txtQuestion.Text = ds1.Tables[0].Rows[0]["Question"].ToString();
                            txtA.Text = ds1.Tables[0].Rows[0]["optA"].ToString();
                            txtB.Text = ds1.Tables[0].Rows[0]["optB"].ToString();
                            txtC.Text = ds1.Tables[0].Rows[0]["optC"].ToString();
                            txtD.Text = ds1.Tables[0].Rows[0]["optD"].ToString();
                            if (ds1.Tables[0].Rows[0]["IsImgQuestion"].ToString()=="1")
                            {
                                
                                chkImageQuestion.Checked = true;
                            }
                            else
                            {
                                chkImageQuestion.Checked = false;
                            }

                            
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                string ImgQuestion = ds1.Tables[0].Rows[0]["ImgQuestion"].ToString();
                                if (ds1.Tables[0].Rows[0]["IsImgQuestion"].ToString() == "True")
                                {
                                    if (ImgQuestion != null && ImgQuestion != "")
                                    {
                                        Byte[] bytes = (Byte[])ds1.Tables[0].Rows[0]["ImgQuestion"];

                                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                        Image1.ImageUrl = "data:image/png;base64," + base64String;
                                        Image1.Visible = true;
                                    }
                                }
                                else
                                {
                                    Image1.Visible = false;
                                }
                            }
                            //ddlClass.SelectedItem.Text = ds1.Tables[0].Rows[0]["class"].ToString();
                            //drpSubject.SelectedValue = ds1.Tables[0].Rows[0]["SubjectName"].ToString();
                        }
                        else
                        {

                            btnSave.Visible = true;
                            //btndelete.Visible = false;
                            //btnupdate.Visible = false;
                        }
                    }
                }



                orgId = Convert.ToInt32(Session["OrgId"]);
                lblQuesid1.Text = db.getDbstatus_Value("select max(queId+1) from tblAddQuestion where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");


                //bind class

            }
            //bind subject
            //DataTable dt1 = new DataTable();
            //SqlCommand cmd_1 = new SqlCommand("sp_Insert_TestDetails", cn);
            //cmd_1.CommandType = CommandType.StoredProcedure;
            //cmd_1.Parameters.AddWithValue("@Action", "Fetch_Question_For_Update");
            ////cmd_1.Parameters.AddWithValue("@CourseId", ddlCourse.SelectedValue);
            ////cmd_1.Parameters.AddWithValue("@BranchId",ddlBranch.SelectedValue);
            ////cmd_1.Parameters.AddWithValue("@ClassId", ddlClass.SelectedValue);
            //cmd_1.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
            //SqlDataAdapter adp_1 = new SqlDataAdapter(cmd_1);
            //adp_1.Fill(dt1);
           
            //grdViewQuestion.DataSource = dt1;
            //// grdViewQuestion.DataSource = db.Displaygrid("SELECT        queId, pattern, unitType, class, question, answer, SubjectName  FROM            tblAddQuestion WHERE        (OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "') ORDER BY queId DESC");
            //grdViewQuestion.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //db.cnopen();
            //db.insert("insert into tblAddQuestion values('" + ddlPattern.Text + "','" + ddlUnitType.Text + "','" + txtQuestion.Text + "','" + txtAnswe.Text + "','" + txtA.Text + "','" + txtB.Text + "','" + txtC.Text + "','" + txtD.Text + "','" + Convert.ToInt32(Session["OrgId"]) + "','" + ddlClass.SelectedValue.ToString() + "','" + drpSubject.SelectedValue.ToString() + "')");
            //db.cnclose();
            Obj_AddQuestions.Action = "AddQuestion";
            

            if (ImgUpload.HasFile)
            {
                string fileName = ImgUpload.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);
                string fileMimeType = ImgUpload.PostedFile.ContentType;
                int fileLengthInKB = ImgUpload.PostedFile.ContentLength / 1024;

                string[] matchExtension = { ".jpg", ".png", ".gif" };
                string[] matchMimeType = { "image/jpeg", "image/png", "image/gif" };

                if (matchExtension.Contains(fileExtension) && matchMimeType.Contains(fileMimeType))
                {
                    if (fileLengthInKB < 1024)
                    {
                        int length = ImgUpload.PostedFile.ContentLength;
                        Obj_AddQuestions.ImgQuestion = new byte[length];
                        
                        HttpPostedFile img1 = ImgUpload.PostedFile;
                        img1.InputStream.Read(Obj_AddQuestions.ImgQuestion, 0, length);
                    }
                    else
                    {
                        //Please choose a file less than 1MB
                    }
                }
                else
                {
                    //Please choose only jpg, png or gif file.
                }
            }
            else if(txtQuestion.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Either add question OR Select Image as question OR Both  !!! ')", true);

                //msgBox.ShowMessage("Either add question OR Select Image as question OR Both !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                return;
            }

          
            if (chkImageQuestion.Checked)
            {
                Obj_AddQuestions.IsImgQuestion = 1;
            }
            else
            {
                Obj_AddQuestions.IsImgQuestion = 0;
            }

            Obj_AddQuestions.Question = txtQuestion.Text;
            Obj_AddQuestions.Answer =txtAnswe.Text;
            Obj_AddQuestions.optA = txtA.Text;
            Obj_AddQuestions.optB = txtB.Text;
            Obj_AddQuestions.optC = txtC.Text;
            Obj_AddQuestions.optD = txtD.Text;
            Obj_AddQuestions.TestId = Convert.ToInt32(ViewState["TestId"].ToString());
            Obj_AddQuestions.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
           
            int QuestioId = BL_AddQuestions.AddQuestions(Obj_AddQuestions);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Question Added  successfully  !!! ')", true);

            //msgBox.ShowMessage("Question added successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);


           // SqlDataSource2.DataBind();
            //GridView1.DataBind();

            btnSave.Visible = true;
            //btnupdate.Visible = false;
            //btndelete.Visible = false;
            clear();
        }
        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
        public void clear()
        {
            //ddlPattern.ClearSelection();
            //ddlUnitType.ClearSelection();
            //ddlClass.ClearSelection();
            //drpSubject.ClearSelection();
            txtQuestion.Text = "";
            txtAnswe.ClearSelection();
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            chkImageQuestion.Checked = false;

            //txtQuestion.Enabled = false;
            //txtAnswe.Enabled = false;
            //txtA.Enabled = false;
            //txtB.Enabled = false;
            //txtC.Enabled = false;
            //txtD.Enabled = false;
            //ddlPattern.Enabled = true;
            //ddlUnitType.Enabled = true;
            //ddlCourse.Enabled = true;
            //ddlBranch.Enabled = true;
            //ddlClass.Enabled = true;
            //drpSubject.Enabled = true;

        }
        
        
        public void enable()
        {
            txtQuestion.Enabled = true;
            txtAnswe.Enabled = true;
            txtA.Enabled = true;
            txtB.Enabled = true;
            txtC.Enabled = true;
            txtD.Enabled = true;
            chkImageQuestion.Enabled = true;
            ImgUpload.Enabled = true;

            ddlPattern.Enabled = false;
            ddlUnitType.Enabled = false;
            ddlCourse.Enabled = false;
            ddlBranch.Enabled = false;
            ddlClass.Enabled = false;
            drpSubject.Enabled = false;

        }
        public void disable()
        {
            txtQuestion.Enabled = false;
            txtAnswe.Enabled = false;
            txtA.Enabled = false;
            txtB.Enabled = false;
            txtC.Enabled = false;
            txtD.Enabled = false;
            chkImageQuestion.Enabled = false;
            ImgUpload.Enabled = false;

            ddlPattern.Enabled = true;
            ddlUnitType.Enabled = true;
            ddlCourse.Enabled = true;
            ddlBranch.Enabled = true;
            ddlClass.Enabled = true;
            drpSubject.Enabled = true;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Visible = true;
            //btnupdate.Visible = false;
            //btndelete.Visible = false;
        }
        //protected void grdViewQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdViewQuestion.PageIndex = e.NewPageIndex;
        //}
        protected void btndelete_Click(object sender, EventArgs e)
        {


            Obj_AddQuestions.Action = "UpdateQuestion";
            Obj_AddQuestions.Id = Convert.ToInt32(Request.QueryString["queId"]);
            int QuestioId = BL_AddQuestions.AddQuestions(Obj_AddQuestions);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Question Deleted successfully  !!! ')", true);

          //  msgBox.ShowMessage("Question Deleted  successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
           // grdViewQuestion.DataBind();
            clear();
            Image1.Visible = false;
            btnSave.Visible = true;
            //btnupdate.Visible = false;
            //btndelete.Visible = false;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Obj_AddQuestions.Action = "UpdateQuestion";
            Obj_AddQuestions.Question = txtQuestion.Text;

            if (ImgUpload.HasFile)
            {
                string fileName = ImgUpload.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);
                string fileMimeType = ImgUpload.PostedFile.ContentType;
                int fileLengthInKB = ImgUpload.PostedFile.ContentLength / 1024;

                string[] matchExtension = { ".jpg", ".png", ".gif" };
                string[] matchMimeType = { "image/jpeg", "image/png", "image/gif" };

                if (matchExtension.Contains(fileExtension) && matchMimeType.Contains(fileMimeType))
                {
                    if (fileLengthInKB > 1024)
                    {
                        int length = ImgUpload.PostedFile.ContentLength;
                        Obj_AddQuestions.ImgQuestion = new byte[length];

                        HttpPostedFile img1 = ImgUpload.PostedFile;
                        img1.InputStream.Read(Obj_AddQuestions.ImgQuestion, 0, length);
                    }
                    else
                    {
                        //Please choose a file less than 1MB
                    }
                }
                else
                {
                    //Please choose only jpg, png or gif file.
                }
            }
            else
            {
                //Please choose a file.
            }


            if (chkImageQuestion.Checked)
            {
                Obj_AddQuestions.IsImgQuestion = 1;
            }
            else
            {
                Obj_AddQuestions.IsImgQuestion = 0;
            }

            Obj_AddQuestions.Answer = txtAnswe.Text;
            Obj_AddQuestions.optA = txtA.Text;
            Obj_AddQuestions.optB = txtB.Text;
            Obj_AddQuestions.optC = txtC.Text;
            Obj_AddQuestions.optD = txtD.Text;
       //     Obj_AddQuestions.TestId = Convert.ToInt32(ViewState["TestId"].ToString());
            Obj_AddQuestions.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
            Obj_AddQuestions.Id =Convert.ToInt32( Request.QueryString["queId"]);
            int QuestioId = BL_AddQuestions.AddQuestions(Obj_AddQuestions);

            //if (QuestioId > 0)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Question Updated  successfully  !!! ')", true);

            //msgBox.ShowMessage("Question Updated  successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
            // grdViewQuestion.DataBind();
            Image1.Visible = false;
            clear();
            btnSave.Visible = true;
            //btnupdate.Visible = false;
            //btndelete.Visible = false;

        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clear();

        }

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

        #region[Bind Game]

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

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTest.SelectedIndex > 0)
                {
                    enable();
                    Button1.Enabled = false;
                    btnSave.Enabled = true;
                    //btnupdate.Enabled = true;
                    btnCancel.Enabled = true;
                    //Obj_AddTest.Action = "AddTest";
                    //Obj_AddTest.TestName = ddlUnitType.Text;
                    //Obj_AddTest.CourseId =Convert.ToInt32( ddlCourse.SelectedValue);
                    //Obj_AddTest.BranchId =Convert.ToInt32( ddlBranch.SelectedValue);
                    //Obj_AddTest.ClassId =Convert.ToInt32( ddlClass.SelectedValue);
                    //Obj_AddTest.TestMarks = txtmarks.Text;
                    //Obj_AddTest.TestDate =  txt_Date.Text;
                    //Obj_AddTest.SubjectId =Convert.ToInt32( drpSubject.SelectedValue);
                    //Obj_AddTest.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                    //Obj_AddTest.IsActive = 1;
                    //int TestId=  BAL_AddTest.AddTest(Obj_AddTest);
                    ViewState["TestId"] = ddlTest.SelectedValue;//TestId;
                }
                else
                {
                    disable();
                }
            }
            catch (Exception ex) { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            disable();
            ddlPattern.ClearSelection();
            ddlUnitType.Text="";
            ddlClass.ClearSelection();
            drpSubject.ClearSelection();
            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            Button1.Enabled = false;
            btnSave.Enabled = false;
            //btnupdate.Enabled = false;
            btnCancel.Enabled = false;
            Image1.Visible = false;
        }

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    try
        //    {
        //        string Id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();


        //        GridViewRow row = GridView1.Rows[e.RowIndex];


        //        TextBox Question = (TextBox)row.FindControl("Question");
        //        TextBox optA = (TextBox)row.FindControl("optA");
        //        TextBox optB = (TextBox)row.FindControl("optB");
        //        TextBox optC = (TextBox)row.FindControl("optC");
        //        TextBox optD = (TextBox)row.FindControl("optD");
        //        DropDownList ddlAnswer = (DropDownList)row.FindControl("ddlAnswer");
        //        FileUpload FileUpload1 = (FileUpload)row.FindControl("FileUpload1");
        //        string query;
        //        byte[] bytes;
        //        if (FileUpload1.HasFile)
        //        {
        //            //SqlDataSource2.UpdateCommand = "UPDATE [tblQuestion] SET [Question] = @Question, [ImgQuestion] = @ImgQuestion, [optA] = @optA, [optB] = @optB," +
        //            //                                            "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE[Id] = @Id";
        //             query = "UPDATE [tblQuestion] SET [Question] = @Question, [ImgQuestion] = @ImgQuestion, [optA] = @optA, [optB] = @optB, " +
        //                                                        "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE [Id] = @Id";
        //            using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
        //            {
        //                bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
        //            }

        //        }
        //        else
        //        {
        //            //SqlDataSource2.UpdateCommand = "UPDATE [tblQuestion] SET [Question] = @Question,  [optA] = @optA, [optB] = @optB," +
        //            //                                            "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE[Id] = @Id";
        //            query = "UPDATE [tblQuestion] SET [Question] = @Question,  [optA] = @optA, [optB] = @optB, " +
        //                                                        "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE [Id] = @Id";
        //            bytes = null;
        //        }
                

        //        using (cn)
        //        {
                    
        //            using (SqlCommand cmd = new SqlCommand(query, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@Question", Question.Text);
        //                if (bytes!=null)
        //                {
        //                    cmd.Parameters.AddWithValue("@ImgQuestion", bytes);
        //                }
        //                cmd.Parameters.AddWithValue("@optA", optA.Text);
        //                cmd.Parameters.AddWithValue("@optB", optB.Text);
        //                cmd.Parameters.AddWithValue("@optC", optC.Text);
        //                cmd.Parameters.AddWithValue("@optD", optD.Text);
        //                cmd.Parameters.AddWithValue("@Answer", ddlAnswer.SelectedValue);
        //                cmd.Parameters.AddWithValue("@Id", Id);
        //                cn.Open();
        //                cmd.ExecuteNonQuery();
        //                cn.Close();
        //                Response.Redirect(Request.Url.AbsoluteUri);
        //            }
        //        }
        //        SqlDataSource2.Update();
              
        //        GridView1.EditIndex = -1;
        //        GridView1.DataBind();

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            DataRowView dr = (DataRowView)e.Row.DataItem;
        //            var ss = dr["ImgQuestion"].ToString();
        //            if (ss!="")
        //            {
        //                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["ImgQuestion"]);
        //                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
        //            }
        //            else
        //                (e.Row.FindControl("Image1") as Image).Visible = false;
        //        }
        //        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        //        {
        //            int rowIndex = e.Row.RowIndex;

        //            string _Answer = (string)GridView1.DataKeys[rowIndex].Values["Answer"].ToString();
                    

        //            DropDownList ddlAnswer = (DropDownList)e.Row.FindControl("ddlAnswer");
        //            ddlAnswer.SelectedValue = _Answer;
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTest.SelectedIndex > 0)
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
            }
        }

        protected void ddlTest_DataBound(object sender, EventArgs e)
        {
            if (ddlTest.SelectedIndex > 0)
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
            }
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if(drpSubject.SelectedIndex>0)
            if (e.AffectedRows <= 1)
            {
              //  msgBox.ShowMessage("Please add Test first!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Please add Test first !!! ')", true);

                }
        }

        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
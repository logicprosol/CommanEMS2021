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

namespace CMS
{
    public partial class ViewTestQuestions : System.Web.UI.Page
    {
        public static int orgId = 0;
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

                if (!IsPostBack)
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
                    }
                }


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
                        enable();
                    }
                }
            }
        }

        public void enable()
        {
            ddlPattern.Enabled = false;
            ddlUnitType.Enabled = false;
            ddlCourse.Enabled = false;
            ddlBranch.Enabled = false;
            ddlClass.Enabled = false;
            drpSubject.Enabled = false;

        }
        public void disable()
        {
            ddlPattern.Enabled = true;
            ddlUnitType.Enabled = true;
            ddlCourse.Enabled = true;
            ddlBranch.Enabled = true;
            ddlClass.Enabled = true;
            drpSubject.Enabled = true;
        }
        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string Id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();


                GridViewRow row = GridView1.Rows[e.RowIndex];


                TextBox Question = (TextBox)row.FindControl("Question");
                TextBox optA = (TextBox)row.FindControl("optA");
                TextBox optB = (TextBox)row.FindControl("optB");
                TextBox optC = (TextBox)row.FindControl("optC");
                TextBox optD = (TextBox)row.FindControl("optD");
                DropDownList ddlAnswer = (DropDownList)row.FindControl("ddlAnswer");
                FileUpload FileUpload1 = (FileUpload)row.FindControl("FileUpload1");
                string query="";
                byte[] bytes=null;
                if (FileUpload1 != null)
                {
                    if (FileUpload1.HasFile)
                    {
                        //SqlDataSource2.UpdateCommand = "UPDATE [tblQuestion] SET [Question] = @Question, [ImgQuestion] = @ImgQuestion, [optA] = @optA, [optB] = @optB," +
                        //                                            "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE[Id] = @Id";
                        query = "UPDATE [tblQuestion] SET [Question] = @Question, [ImgQuestion] = @ImgQuestion, [optA] = @optA, [optB] = @optB, " +
                                                                   "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE [Id] = @Id";
                        using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                        {
                            bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        }

                    }
                }
                else
                {
                    //SqlDataSource2.UpdateCommand = "UPDATE [tblQuestion] SET [Question] = @Question,  [optA] = @optA, [optB] = @optB," +
                    //                                            "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE[Id] = @Id";
                    query = "UPDATE [tblQuestion] SET [Question] = @Question,  [optA] = @optA, [optB] = @optB, " +
                                                                "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE [Id] = @Id";
                    bytes = null;
                }


                using (cn)
                {

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Question", Question.Text);
                        if (bytes != null)
                        {
                            cmd.Parameters.AddWithValue("@ImgQuestion", bytes);
                        }
                        cmd.Parameters.AddWithValue("@optA", optA.Text);
                        cmd.Parameters.AddWithValue("@optB", optB.Text);
                        cmd.Parameters.AddWithValue("@optC", optC.Text);
                        cmd.Parameters.AddWithValue("@optD", optD.Text);
                        cmd.Parameters.AddWithValue("@Answer", ddlAnswer.SelectedValue);
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    // Response.Redirect("ViewTestQuestions.aspx");
                    }
                }
                // SqlDataSource2.Update();
                // GridView1.EditIndex = -1;
                // GridView1.DataBind();
                SqlDataSource2.DataBind();
                GridView1.EditIndex = -1;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    var ss = dr["ImgQuestion"].ToString();
                    if (ss != "")
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["ImgQuestion"]);
                        (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
                    }
                    else
                        (e.Row.FindControl("Image1") as Image).Visible = false;
                }
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    int rowIndex = e.Row.RowIndex;

                    string _Answer = (string)GridView1.DataKeys[rowIndex].Values["Answer"].ToString();


                    DropDownList ddlAnswer = (DropDownList)e.Row.FindControl("ddlAnswer");
                    ddlAnswer.SelectedValue = _Answer;
                }
            }
            catch (Exception ex)
            { }
        }
        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
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
        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (drpSubject.SelectedIndex > 0)
                if (e.AffectedRows <= 1)
                {
                    //  msgBox.ShowMessage("Please add Test first!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Please add Test first !!! ')", true);

                }
        }
    }
}
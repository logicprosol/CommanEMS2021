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

namespace CMS.Forms.Faculty
{
    public partial class AddTest : System.Web.UI.Page
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
            if (orgId== 0)
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
                    txt_Date.Attributes.Add("ReadOnly", "True");
                    disable();
                    BindCourse();

                }

                
            }

            

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
            ddlPattern.ClearSelection();
            ddlUnitType.Text="";
            ddlClass.ClearSelection();
            drpSubject.ClearSelection();
            txt_Date.Text = "";
            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            ddlClass.ClearSelection();
            drpSubject.ClearSelection();
            txtmarks.Text = "";

        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
        }
        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSubject.SelectedIndex > 0)
            {
                Button1.Enabled = true;
            }
            else {
                Button1.Enabled = false;
            }
        }
        public void disable()
        {
           
            ddlPattern.Enabled = false;
            ddlUnitType.Enabled = false;
            ddlCourse.Enabled = false;
            ddlBranch.Enabled = false;
            ddlClass.Enabled = false;
            drpSubject.Enabled = false;

        }
        public void enable()
        {
            ddlPattern.Enabled = true;
            ddlUnitType.Enabled = true;
            ddlCourse.Enabled = true;
            ddlBranch.Enabled = true;
            ddlClass.Enabled = true;
            drpSubject.Enabled = true;
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

        #region[Bind Subject]

        private void BindSubject()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserCode = Session["Username"].ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                // if (!objEWA.ClassId.Equals("Select"))
                {
                    DataSet ds = objBL.BindAssigned_Subject_BL(objEWA);

                    drpSubject.DataSource = ds;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        drpSubject.DataTextField = "SubjectName";
                        drpSubject.DataValueField = "SubjectId";
                        drpSubject.DataBind();
                    }
                    else
                    {
                        drpSubject.Items.Clear();
                    }
                }
                //else
                //{
                //    drpSubject.Items.Clear();
                //}
                drpSubject.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                enable();
                Button1.Enabled = false;
                Obj_AddTest.Action = "AddTest";
                Obj_AddTest.TestName = ddlUnitType.Text;
                Obj_AddTest.CourseId =Convert.ToInt32( ddlCourse.SelectedValue);
                Obj_AddTest.BranchId =Convert.ToInt32( ddlBranch.SelectedValue);
                Obj_AddTest.ClassId =Convert.ToInt32( ddlClass.SelectedValue);
                Obj_AddTest.TestMarks = txtmarks.Text;
                Obj_AddTest.TestDate =  txt_Date.Text;
                Obj_AddTest.SubjectId =Convert.ToInt32( drpSubject.SelectedValue);
                Obj_AddTest.OrgId = Convert.ToInt32(Session["OrgId"].ToString());
                Obj_AddTest.IsActive = 1;
                Obj_AddTest.PerQuestionMark =txtPerQmark.Text;
                int TestId=  BAL_AddTest.AddTest(Obj_AddTest);
                // ViewState["TestId"] = TestId;
                if (TestId > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Test added successfully !!! ')", true);
                    //msgBox.ShowMessage("Test added successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    disable();
                    clear();
                }
                if (TestId == -1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record already exists!!! ')", true);
                    //msgBox.ShowMessage("Record already exists!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                }
            }
            catch (Exception ex) { }
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            enable();
            ddlPattern.ClearSelection();
            ddlUnitType.Text="";
            ddlClass.ClearSelection();
            drpSubject.ClearSelection();
            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            Button1.Enabled = false;
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try { }
            catch (Exception ex)
            { }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //check if is in edit mode
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        DataRowView drv = e.Row.DataItem as DataRowView;

                        //TextBox CourseId = (TextBox)e.Row.FindControl("CourseId");
                        //TextBox BranchId = (TextBox)e.Row.FindControl("BranchId");
                        //TextBox ClassId = (TextBox)e.Row.FindControl("ClassId");

                        //string _CourseId = CourseId.Text;
                        //string _BranchId = BranchId.Text;
                        //string _ClassId = ClassId.Text;

                        ////Get Subcategories list based on selected product's category and bind it to
                        ////subcategory dropdown
                        //ddlSubCategories.DataTextField = "SubCategoryName";
                        //ddlSubCategories.DataValueField = "ProductSubcategoryID";
                        //ddlSubCategories.DataSource = 
                        //ddlSubCategories.DataBind();
                        //ddlSubCategories.SelectedValue = drv["ProductSubCategoryID"].ToString();
                        int rowIndex = e.Row.RowIndex;

                        string _CourseId = (string)GridView1.DataKeys[rowIndex].Values["CourseId"].ToString();
                        string _BranchId = (string)GridView1.DataKeys[rowIndex].Values["BranchId"].ToString(); //["BranchId"];
                        string _ClassId = (string)GridView1.DataKeys[rowIndex].Values["ClassId"].ToString();
                        string _SubjectId = (string)GridView1.DataKeys[rowIndex].Values["SubjectId"].ToString();

                        DropDownList ddlBranchGrid = (DropDownList)e.Row.FindControl("ddlBranchGrid");
                        //Bind categories data to dropdownlist
                        ddlBranchGrid.DataTextField = "BranchName";
                        ddlBranchGrid.DataValueField = "BranchId";
                        DataTable dt = BindBranch_Grid(_CourseId);

                        ddlBranchGrid.DataSource = dt;
                        ddlBranchGrid.DataBind();
                        //set the selected value of the dropdown to selected product's category
 //ddlBranchGrid.Items.Insert(0, new ListItem("Select", "0"));
                        ddlBranchGrid.SelectedValue = _BranchId;

                        DropDownList ddlClassGrid = (DropDownList)e.Row.FindControl("ddlClassGrid");
                        //Bind categories data to dropdownlist
                        ddlClassGrid.DataTextField = "ClassName";
                        ddlClassGrid.DataValueField = "ClassId";
                        ddlClassGrid.DataSource = BindClass_Grid(_BranchId);
                        ddlClassGrid.DataBind();
                        //set the selected value of the dropdown to selected product's category
 //ddlClassGrid.Items.Insert(0, new ListItem("Select", "0"));
                        ddlClassGrid.SelectedValue = _ClassId;

                        DropDownList ddlsubjectGrid = (DropDownList)e.Row.FindControl("ddlsubjectGrid");
                        //Bind categories data to dropdownlist
                        ddlsubjectGrid.DataTextField = "SubjectName";
                        ddlsubjectGrid.DataValueField = "SubjectId";
                        ddlsubjectGrid.DataSource = BindSubject_Grid( _CourseId, _BranchId, _ClassId);
                        ddlsubjectGrid.DataBind();
                        //set the selected value of the dropdown to selected product's category
 //ddlsubjectGrid.Items.Insert(0, new ListItem("Select", "0"));
                        ddlsubjectGrid.SelectedValue = _SubjectId;

                       
                       
                       
                    }
                }
            }
            catch (Exception ex) { }

        }

        protected void ddlCourseGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((DropDownList)sender).NamingContainer;

                //get reference to the categories & subcategories dropdownlist
                DropDownList ddlCourseGrid = (DropDownList)gvrow.FindControl("ddlCourseId");
                DropDownList ddlBranchGrid = (DropDownList)gvrow.FindControl("ddlBranchGrid");
                DropDownList ddlClassGrid = (DropDownList)gvrow.FindControl("ddlClassGrid");
                DropDownList ddlsubjectGrid = (DropDownList)gvrow.FindControl("ddlsubjectGrid");
                //Bind categories data to dropdownlist
                ddlBranchGrid.DataTextField = "BranchName";
                ddlBranchGrid.DataValueField = "BranchId";
                DataTable dt=new DataTable();
                ddlBranchGrid.DataSource = dt;
                ddlBranchGrid.DataBind();

                ddlClassGrid.DataSource = dt;
                ddlClassGrid.DataBind();

                ddlsubjectGrid.DataSource = dt;
                ddlsubjectGrid.DataBind();

                dt = BindBranch_Grid(ddlCourseGrid.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    ddlBranchGrid.DataSource = dt;
                    ddlBranchGrid.DataBind();

                    ddlBranchGrid.Items.Insert(0, new ListItem("Select", "0"));
                    //Bind categories data to dropdownlist
                    ddlClassGrid.DataTextField = "ClassName";
                    ddlClassGrid.DataValueField = "ClassId";
                    dt= BindClass_Grid(ddlBranchGrid.SelectedValue);
                   
                    if (dt.Rows.Count > 0)
                    {
                        ddlClassGrid.DataSource = dt;
                        ddlClassGrid.DataBind();
                        ddlClassGrid.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    
                   

                    ddlsubjectGrid.DataTextField = "SubjectName";
                    ddlsubjectGrid.DataValueField = "SubjectId";
                    dt= BindSubject_Grid(ddlCourseGrid.SelectedValue, ddlBranchGrid.SelectedValue, ddlClassGrid.SelectedValue);
                    
                    if (dt.Rows.Count > 0)
                    {
                        ddlsubjectGrid.DataSource = dt;
                        ddlsubjectGrid.DataBind();
                        ddlsubjectGrid.Items.Insert(0, new ListItem("Select", "0"));
                    }
                
                }
                else
                {
                    ddlBranchGrid.DataSource = dt;
                    ddlBranchGrid.DataBind();

                    ddlClassGrid.DataSource = dt;
                    ddlClassGrid.DataBind();

                    ddlsubjectGrid.DataSource = dt;
                    ddlsubjectGrid.DataBind();
                }
               
                //set the selected value of the dropdown to selected product's category
                // ddlBranchGrid.SelectedValue = _ClassId;
            }
            catch (Exception ex) { }
        }

        protected void ddlBranchGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((DropDownList)sender).NamingContainer;

                //get reference to the categories & subcategories dropdownlist
                DropDownList ddlCourseGrid = (DropDownList)gvrow.FindControl("ddlCourseId");
                DropDownList ddlBranchGrid = (DropDownList)gvrow.FindControl("ddlBranchGrid");
                DropDownList ddlClassGrid = (DropDownList)gvrow.FindControl("ddlClassGrid");
                DropDownList ddlsubjectGrid = (DropDownList)gvrow.FindControl("ddlsubjectGrid");

                //Bind categories data to dropdownlist
                ddlClassGrid.DataTextField = "ClassName";
                ddlClassGrid.DataValueField = "ClassId";
                DataTable dt = new DataTable();

                ddlClassGrid.DataSource = dt;
                ddlClassGrid.DataBind();

                ddlsubjectGrid.DataSource = dt;
                ddlsubjectGrid.DataBind();

                dt = BindClass_Grid(ddlBranchGrid.SelectedValue);
                
                    
                if (dt.Rows.Count > 0)
                {
                    ddlClassGrid.DataSource = dt;
                    ddlClassGrid.DataBind();
                    ddlClassGrid.Items.Insert(0, new ListItem("Select", "0"));
                }

                ddlsubjectGrid.DataTextField = "SubjectName";
                ddlsubjectGrid.DataValueField = "SubjectId";
                dt= BindSubject_Grid(ddlCourseGrid.SelectedValue, ddlBranchGrid.SelectedValue, ddlClassGrid.SelectedValue);
                ddlsubjectGrid.DataSource = dt;
                ddlsubjectGrid.DataBind();

                if (dt.Rows.Count > 0)
                {
                    ddlsubjectGrid.Items.Insert(0, new ListItem("Select", "0"));
                }


            }
            catch (Exception ex) { }
        }
        protected void ddlclassGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((DropDownList)sender).NamingContainer;

                //get reference to the categories & subcategories dropdownlist

                DropDownList ddlCourseGrid = (DropDownList)gvrow.FindControl("ddlCourseId");
                DropDownList ddlBranchGrid = (DropDownList)gvrow.FindControl("ddlBranchGrid");
                DropDownList ddlClassGrid = (DropDownList)gvrow.FindControl("ddlClassGrid");
                DropDownList ddlsubjectGrid = (DropDownList)gvrow.FindControl("ddlsubjectGrid");
                DataTable dt = new DataTable();
                
                ddlsubjectGrid.DataSource = dt;
                ddlsubjectGrid.DataBind();

                dt = BindSubject_Grid(ddlCourseGrid.SelectedValue, ddlBranchGrid.SelectedValue, ddlClassGrid.SelectedValue);
                ddlsubjectGrid.DataTextField = "SubjectName";
                ddlsubjectGrid.DataValueField = "SubjectId";
                ddlsubjectGrid.DataSource = dt;
                ddlsubjectGrid.DataBind();
                //if (dt.Rows.Count > 0)
                //{
                //    ddlsubjectGrid.Items.Insert(0, new ListItem("Select", "0"));
                //}

            }
            catch (Exception ex) { }
        }
        private DataTable BindBranch_Grid(string courseid)
        {
            DataSet ds=new DataSet();
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = courseid;

                 ds = objDL.BindBranch_DL(objEWA);
               

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            return ds.Tables[0];
        }

        private DataTable BindClass_Grid( string branchid)
        {
            DataSet ds = new DataSet();
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = branchid;
                if (!objEWA.BranchId.Equals("Select"))
                {
                    ds = objBL.BindClass_BL(objEWA);

                }   

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            return ds.Tables[0];
        }

        private DataTable BindSubject_Grid(string courseid,string branchid, string classid)
        {
            DataSet ds = new DataSet();
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.UserCode = Session["Username"].ToString();
                objEWA.CourseId = courseid;// ddlCourse.SelectedValue;
                objEWA.BranchId = branchid;// ddlBranch.SelectedValue;
                objEWA.ClassId = classid;// ddlClass.SelectedValue;
                //if (!objEWA.ClassId.Equals("Select"))
                {
                    ds = objBL.BindAssigned_Subject_BL(objEWA);

                }
               

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            return ds.Tables[0];
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string TestId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();


                GridViewRow row = GridView1.Rows[e.RowIndex];


                TextBox TestName = (TextBox)row.FindControl("TestName");
                TextBox TestDate = (TextBox)row.FindControl("TestDate");
                 TextBox PassMarks = (TextBox)row.FindControl("PassMarks");


                DropDownList ddlCourseGrid = (DropDownList)row.FindControl("ddlCourseId");
                DropDownList ddlBranchGrid = (DropDownList)row.FindControl("ddlBranchGrid");
                DropDownList ddlClassGrid = (DropDownList)row.FindControl("ddlClassGrid");
                DropDownList ddlsubjectGrid = (DropDownList)row.FindControl("ddlsubjectGrid");

                //update 

                //SqlDataSource1.UpdateParameters["TestName"].DefaultValue =  TestName.Text;
                //SqlDataSource1.UpdateParameters["TestDate"].DefaultValue = TestDate.Text;
                //SqlDataSource1.UpdateParameters["PassMarks"].DefaultValue = PassMarks.Text;

                //SqlDataSource1.UpdateParameters["CourseId"].DefaultValue = ddlCourseGrid.SelectedValue;
                //SqlDataSource1.UpdateParameters["BranchId"].DefaultValue = ddlBranchGrid.SelectedValue;
                //SqlDataSource1.UpdateParameters["ClassId"].DefaultValue = ddlClassGrid.SelectedValue;
                //SqlDataSource1.UpdateParameters["TestId"].DefaultValue = TestId;



                //SqlDataSource1.UpdateParameters.Add("TestName", TestName.Text);
                //SqlDataSource1.UpdateParameters.Add("TestDate", TestDate.Text);
                //SqlDataSource1.UpdateParameters.Add("PassMarks", PassMarks.Text);

                //SqlDataSource1.UpdateParameters.Add("CourseId", ddlCourseGrid.SelectedValue);
                //SqlDataSource1.UpdateParameters.Add("BranchId", ddlBranchGrid.SelectedValue);
                //SqlDataSource1.UpdateParameters.Add("ClassId", ddlClassGrid.SelectedValue);

                //SqlDataSource1.UpdateParameters.Add("TestId", TestId);

                using (cn)
                {
                    string query = "UPDATE [tblTest] SET [TestName] = @TestName, [CourseId] = @CourseId, [BranchId] = @BranchId, [ClassId] = @ClassId," +
                                              "[PassMarks] = @PassMarks, [TestDate] =Convert(date, @TestDate,103),[SubjectId]=@SubjectId WHERE [TestId] = @TestId";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@TestName", TestName.Text);
                        cmd.Parameters.AddWithValue("@TestDate", TestDate.Text);
                        cmd.Parameters.AddWithValue("@PassMarks", PassMarks.Text);

                        cmd.Parameters.AddWithValue("@CourseId",Convert.ToInt32( ddlCourseGrid.SelectedValue));
                        cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(ddlBranchGrid.SelectedValue));
                        cmd.Parameters.AddWithValue("@ClassId", Convert.ToInt32(ddlClassGrid.SelectedValue));
                        cmd.Parameters.AddWithValue("@SubjectId", Convert.ToInt32(ddlsubjectGrid.SelectedValue));
                        cmd.Parameters.AddWithValue("@TestId", Convert.ToInt32(TestId));
                         cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
                SqlDataSource1.Update();

                GridView1.EditIndex = -1;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        
    }
}
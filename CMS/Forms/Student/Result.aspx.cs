using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer.Student;
using DataAccessLayer;
using EntityWebApp.Admin;
using EntityWebApp.Student;
namespace Forms.Student
{
    public partial class Result : System.Web.UI.Page
    {
        private BindControl ObjHelper = new BindControl();
        DataSet ds = new DataSet();
        BL_StudentProfile objBAL = new BL_StudentProfile();
        EWA_StudentProfile objEWA = new EWA_StudentProfile();
        database db = new database();
        int OrgId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            OrgId = Convert.ToInt32(Session["OrgId"]);

            if (OrgId == 0)
            {

                Response.Redirect("~/College_Home.aspx");
            }
            if (!IsPostBack)
            {

                objEWA.OrgId = Session["OrgId"].ToString();

                //objEWA.StudentUID = "1/2014/000016";//(int)Session["StudentID"];
                //objEWA.UserCode = Session["UserCode"].ToString();


                ShowStudentProfile(objEWA);
                GridView2.DataSource = db.Displaygrid("select * from  Result  where UserCode='" + objEWA.UserCode.ToString() + "' ");
                GridView2.DataBind();
            
        }
            
        }
        private void ShowStudentProfile(EWA_StudentProfile objEWA)
        {
            DataSet ds;
            try
            {

                objEWA.UserCode = Session["UserCode"].ToString();
                objEWA.OrgId = Session["OrgId"].ToString();
                ds = objBAL.BL_ShowStudentProfile(objEWA);

                //variable declare

                //For Name
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    string MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                    string LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    string FullName = FirstName + " " + MiddleName + " " + LastName;
                
                //Personal Information


                lblstud.Text = FullName.ToString();

              

            

                //Academic Information
                lblCourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                lblBranch.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                lblclassname.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                //lblDivision.Text = ds.Tables[0].Rows[0]["DivisionName"].ToString();
               }

            }
            catch (Exception exp)
            {
                
            }
        }

    }
}
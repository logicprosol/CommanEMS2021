using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessAccessLayer.Student;
using DataAccessLayer;
using EntityWebApp.Admin;
using EntityWebApp.Student;
using System.Data.SqlClient;
using System.Configuration;

namespace General_Information
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        //Object Declaration
        #region Objects
        private BindControl ObjHelper = new BindControl();
        public static int orgId=0;
        DataSet ds = new DataSet();
        database db = new database();
        BL_StudentProfile objBAL = new BL_StudentProfile();
        EWA_StudentProfile objEWA = new EWA_StudentProfile();
        string country;
        string state,city;
        #endregion
     
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    objEWA.OrgId = Session["OrgId"].ToString();

                    //objEWA.StudentUID = "1/2014/000016";//(int)Session["StudentID"];
                    //objEWA.UserCode = Session["UserCode"].ToString();

                    //if (objEWA.OrgId == null)
                    //{
                    //    Response.Redirect("~/College_Home.aspx");
                    //}
                    ShowStudentProfile(objEWA);

                }
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
                string FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                string MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                string LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                string FullName=FirstName+" "+MiddleName+" "+LastName;               

                //Personal Information
                

                ViewState["UserCode"] = ds.Tables[0].Rows[0]["UserCode"].ToString();
                //Personal Information
                //For Id
                lblRollNo.Text = ds.Tables[0].Rows[0]["RollNo"].ToString();
                lblGRNO.Text = ds.Tables[0].Rows[0]["GRNo"].ToString();
                lblStudentName.Text = FullName;
                lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                lblBirthDate.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                lblBloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                lblMobileNo.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lblStudentEmail.Text = ds.Tables[0].Rows[0]["EMail"].ToString();
                             
                lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
              
                lblHandicaped.Text=ds.Tables[0].Rows[0]["Handicap"].ToString();
                lblReligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString();                
                lblCasteCategory.Text=ds.Tables[0].Rows[0]["CasteCategoryName"].ToString();               
                lblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();          
                lblSubCaste.Text = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                byte[] btImage = null;
                var _photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                if (ds.Tables[0].Rows[0]["Photo"] == null || _photo == "")
                {
                }
                else
                {
                    btImage = (byte[])ds.Tables[0].Rows[0]["Photo"];
                    string base64String = Convert.ToBase64String(btImage, 0, btImage.Length);
                    img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                    img_StudentImage.Visible = true;
                }


                //lblCourse.Text = db.getDbstatus_Value("SELECT        tblCourse.CourseName FROM            tblCourse INNER JOIN tblStudent ON tblCourse.CourseId = tblStudent.CourseId  WHERE        (tblCourse.OrgId = '" + Session["OrgId"].ToString() + "') AND (tblStudent.UserCode = '" + Session["UserCode"].ToString() + "')");
              //  lblCourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString(); //db.getDbstatus_Value("SELECT        tblCourse.CourseName FROM            tblCourse INNER JOIN tblStudent ON tblCourse.CourseId = tblStudent.CourseId  WHERE        (tblCourse.OrgId = '" + Session["OrgId"].ToString() + "') AND (tblStudent.UserCode = '" + Session["UserCode"].ToString() + "')");


                //Contact Information
                lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();


                //country= db.getDbstatus_Value("SELECT Country.County FROM  Country INNER JOIN tblStudent ON Country.CountryId = tblStudent.Country WHERE tblStudent.UserCode = '"+Session["UserCode"].ToString()+"' ");

                lblStudentCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();// country.ToString();

                //state = db.getDbstatus_Value("SELECT countryState.State FROM tblStudent INNER JOIN countryState ON tblStudent.State = countryState.StateId AND tblStudent.Country = countryState.CountryId WHERE  tblStudent.UserCode = '" + Session["UserCode"].ToString() + "'");

                lblStudentState.Text = ds.Tables[0].Rows[0]["State"].ToString();//state.ToString();

                lblStudentDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                lblStudentTaluka.Text = ds.Tables[0].Rows[0]["Taluka"].ToString();

               //city = db.getDbstatus_Value("     select City from  tblStudent WHERE UserCode = '" + Session["UserCode"].ToString() + "'");
              //  city = db.getDbstatus_Value("SELECT stateCity.City FROM  stateCity INNER JOIN tblStudent ON Country.CityId = tblStudent.City WHERE tblStudent.UserCode = '" + Session["UserCode"].ToString() + "' ");

               // lblStudentCity.Text = city.ToString();
                lblStudentCity.Text = ds.Tables[0].Rows[0]["City"].ToString(); //city.ToString();

                //lblStudentPinCode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                lblBirthPlace.Text = ds.Tables[0].Rows[0]["BirthPlace"].ToString();
                //Parent Information                
                lblParentName.Text = ds.Tables[0].Rows[0]["ParentName"].ToString();
                lblMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
               
                //lblParentMobileNo.Text = ds.Tables[0].Rows[0]["ParentMobile"].ToString();
                //lblParentAddress.Text = ds.Tables[0].Rows[0]["ParentAddress"].ToString();
                //lblParentCountry.Text = ds.Tables[0].Rows[0]["ParentCountry"].ToString();
                //lblParentState.Text = ds.Tables[0].Rows[0]["ParentState"].ToString();
                //lblParentDistrict.Text = ds.Tables[0].Rows[0]["ParentDistrict"].ToString();
                //lblParentTaluka.Text = ds.Tables[0].Rows[0]["ParentTaluka"].ToString();
                //lblParentCity.Text = ds.Tables[0].Rows[0]["ParentCity"].ToString();
                //lblParentPinCode.Text = ds.Tables[0].Rows[0]["ParentPinCode"].ToString();
                //lblParentMobileNo.Text = ds.Tables[0].Rows[0]["ParentMobile"].ToString();
                //lblParentEmail.Text = ds.Tables[0].Rows[0]["ParentEMail"].ToString();


                //Education Information
                
                //lblLastClass.Text = ds.Tables[0].Rows[0]["LastClass"].ToString();
                //lblLastInstitute.Text = ds.Tables[0].Rows[0]["LastInstitute"].ToString();
                lblQualifiedExam.Text = ds.Tables[0].Rows[0]["QualifiedExam"].ToString();
               
                //lblSeatNo.Text = ds.Tables[0].Rows[0]["SeatNo"].ToString();
                //lblPassingMonth.Text = ds.Tables[0].Rows[0]["PassingMonth"].ToString();
                //lblPassingYear.Text = ds.Tables[0].Rows[0]["PassingYear"].ToString();
                //lblPercentage.Text = ds.Tables[0].Rows[0]["Percentage"].ToString();
                //lblResult.Text = ds.Tables[0].Rows[0]["Result"].ToString();

                //Academic Information
                lblCourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                lblBranch.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                lblClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                //lblDivision.Text = ds.Tables[0].Rows[0]["DivisionName"].ToString();
                lblAcademicYear.Text = ds.Tables[0].Rows[0]["AcademicYear"].ToString();

               
                //lblSport.Text = ds.Tables[0].Rows[0]["SportName"].ToString();
                //lblLevelPlayed.Text = ds.Tables[0].Rows[0]["AdharNo"].ToString();
                lblAdharNo.Text = ds.Tables[0].Rows[0]["AdharNO"].ToString();
                //Other Information
                // lblIFSCCode.Text = ds.Tables[0].Rows[0]["IFSCCode"].ToString();

                //if (ds.Tables[0].Rows[0]["Signature"] == null)
                //{
                //}
                //else
                //{

                //    byte[] btSign = null;
                //    btSign = (byte[])ds.Tables[0].Rows[0]["Signature"];
                //    string base64String = Convert.ToBase64String(btSign, 0, btSign.Length);
                //    img_StudentSign.ImageUrl = "data:image/png;base64," + base64String;
                //    img_StudentSign.Visible = true;
                //}


                //string Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString();

                //if (Photo1 != null && Photo1 != "")
                //{
                //    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                //    img_StudentImage.ImageUrl = "data:image/png;base64," + base64String;
                //    img_StudentImage.Visible = true;
                //}


            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
                //msgBox.ShowMessage("Proper Inserted Data Or Photo Properly  !!!", "Saved", CMS.UserControls.MessageBox.MessageStyle.Successfull);
               // msgBox.ShowMessage("Improper Data  !!!", "Saved", CMS.UserControls.MessageBox.MessageStyle.Successfull);

            }
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
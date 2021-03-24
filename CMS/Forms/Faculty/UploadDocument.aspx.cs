 using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Faculty;
using System.Data.SqlClient;
using System.Configuration;

//Upload Document
namespace CMS.Forms.Faculty
{
    public partial class UploadDocument : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        //Page Load
        #region[Page Load]
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindCourse(ddlCourse);
                    //rbtnPurpose.SelectedIndex = -1;
                    DDSubject.Visible = true;
                    txtSubject.Visible = false;
                    rfvDDSubject.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Bind Course
        #region[Bind Course]
        private void BindCourse(DropDownList ddlCourse)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();// Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "-1"));
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
                BindBranch(ddlCourse);
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
                BindClass(ddlBranch);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion
          
        //Bind Branch
        #region[Bind Branch]
        private void BindBranch(DropDownList ddlCourse)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();

                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);

                ddlBranch.DataSource = ds;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("Select", "-1"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Bind Class
        #region[Bind Class]
        private void BindClass(DropDownList ddlBranch)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.OrgId = Session["OrgId"].ToString();// Session["OrgId"].ToString();
                DataSet ds = objBL.BindClass_BL(objEWA);

                ddlClass.DataSource = ds;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("Select", "-1"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        //Send 
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                EWA_UploadDocument ObjEWA = new EWA_UploadDocument();
                BL_UploadDocument ObjBL = new BL_UploadDocument();

                ObjEWA.Action = "FetchStudent";
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.CourseId = ddlCourse.SelectedValue.ToString();
                ObjEWA.BranchId = ddlBranch.SelectedValue.ToString();
                ObjEWA.ClassId = ddlClass.SelectedValue.ToString();
               //ObjEWA.DivisionId = ddlDivision.SelectedValue.ToString();
               SqlCommand cmd1 = new SqlCommand("	SELECT s.UserCode as 'StudentId' FROM tblStudent s where s.CourseId='" + ddlCourse.SelectedValue.ToString() + "' and s.ClassId='" + ddlClass.SelectedValue.ToString() +
                   "' and s.BranchId='" + ddlBranch.SelectedValue.ToString() + "' and OrgId='"+ Session["OrgId"].ToString()+"'", cn);
               SqlDataAdapter adp1 = new SqlDataAdapter();
               DataSet ds1 = new DataSet();
               adp1.SelectCommand = cmd1;
               adp1.Fill(ds1);
         //       DataSet ds = ObjBL.StudentBind_BL(ObjEWA);
                if (ds1 == null)
                {
                    return;
                }
                ObjEWA.StudentDataTable = ds1.Tables[0];
                ObjEWA.Action = "SaveUploadDocument";
                ObjEWA.FacultyId = Session["UserCode"].ToString();
                ObjEWA.MessageContent = txtMessage.Text;
                ObjEWA.UploadPurpose = Convert.ToInt32(rbtnPurpose.SelectedValue);

                if (rbtnPurpose.SelectedItem.Text.Equals("Home Work/Assignment"))
                {
                    ObjEWA.Subject = DDSubject.SelectedValue.ToString();
                }
                else
                {
                    ObjEWA.Subject = txtSubject.Text;

                }
                int fileLengthInKB=0;
                if (flpUploadFile.HasFile)
                {
                    int length = flpUploadFile.PostedFile.ContentLength;
                    ObjEWA.Data = new byte[length];
                    ObjEWA.FileName = flpUploadFile.PostedFile.FileName.ToString();
                    ObjEWA.ContentType = flpUploadFile.PostedFile.ContentType;
                     fileLengthInKB = flpUploadFile.PostedFile.ContentLength / 1024;
                    HttpPostedFile file = flpUploadFile.PostedFile;
                    file.InputStream.Read(ObjEWA.Data, 0, length);
                }
                else
                {
                    ObjEWA.Data = null;
                    ObjEWA.FileName = "";
                    ObjEWA.ContentType = "";
                }
                if (fileLengthInKB > 1024)
                {
                    msgBox.ShowMessage("Document should be less than or equal to 1MB !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);

                }
                else
                {
                    int flag = ObjBL.UploadDocument_BL(ObjEWA);
                    msgBox.ShowMessage("Document Upload Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    clear();
                }

               
            }
            catch (Exception ex)
            {
                msgBox.ShowMessage("Unable to Save !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindDivision();
            BindSubject();
        }

        private void BindDivision()
        {
            //EWA_Common objEWA = new EWA_Common();
            //BL_Common objBL = new BL_Common();
            //objEWA.ClassId = ddlClass.SelectedValue.ToString();
            //if (!objEWA.ClassId.Equals("Select"))
            //{
            //    DataSet ds = objBL.BindDivision_BL(objEWA);

            //    ddlDivision.DataSource = ds;
            //    ddlDivision.DataTextField = "DivisionName";
            //    ddlDivision.DataValueField = "DivisionId";
            //    ddlDivision.DataBind();
            //}
            //else
            //{

            //    ddlDivision.Items.Clear();
            //}
            //ddlDivision.Items.Insert(0, new ListItem("Select", "Select"));

        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        public void clear()
        {
            ddlCourse.ClearSelection();
            ddlBranch.ClearSelection();
            ddlClass.ClearSelection();
            ddlDivision.ClearSelection();
            //rbtnPurpose.ClearSelection();
            DDSubject.ClearSelection();
            txtSubject.Text = "";
            txtMessage.Text = "";
        }

        protected void rbtnPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnPurpose.SelectedItem.Text.Equals("Home Work"))
            {
                txtSubject.Visible = false;
                rfvtxtSubject.Enabled = false;
                DDSubject.Visible = true;
                rfvDDSubject.Enabled = true;
            }
            else
            {
                DDSubject.Visible = false;
                rfvDDSubject.Enabled = false;
                txtSubject.Visible = true;
                rfvtxtSubject.Enabled = true;
            }
                
        }

        public void BindSubject()
        {
            
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                //objEWA.DivisionId = ddlDivision.SelectedValue.ToString();
                objEWA.UserCode = Session["Username"].ToString();

                DataSet ds = objDL.FetchSubject_DL(objEWA);
                DDSubject.Items.Clear();
                DDSubject.DataSource = ds;
                DDSubject.DataTextField = "SubjectName";
                DDSubject.DataValueField = "SubjectId";
                DDSubject.DataBind();
                DDSubject.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindSubject();
        }
    }
}
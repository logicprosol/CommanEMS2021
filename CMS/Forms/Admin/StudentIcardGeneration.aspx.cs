

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;

//Admin ID Card Generation
namespace CMS.Forms.Admin
{
    public partial class AdminIcardGeneration : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BindControl ObjHelper = new BindControl();
        private DataSet ds = new DataSet();
        private BL_StudentView objBAL = new BL_StudentView();
        private EWA_StudentView objEWA = new EWA_StudentView();
        #endregion
        int OrgID = 0;
        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                OrgID = Convert.ToInt32(Session["OrgId"]);
                if (OrgID == 0)
                {
                    Response.Redirect("./CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    
 objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                    ddlCourseBind();

                   

                   
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Bind Course

        #region Bind Course

        private void ddlCourseBind()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = new DataSet();
                ds = objBL.BindCourses_BL(objEWA);
                ddlcourse.DataSource = ds.Tables[0];
                ddlcourse.DataTextField = "CourseName";
                ddlcourse.DataValueField = "CourseId";
                ddlcourse.DataBind();
                ddlcourse.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion Bind Course

        

        //Bind Grid
        #region[Bind grid]

        private void BindGrid()
        {
            try
            {
                BL_StudentView objBAL = new BL_StudentView();
                EWA_StudentView objEWA = new EWA_StudentView();

                objEWA.CourseId = ddlcourse.SelectedValue.Trim();
                objEWA.BranchId = ddlbranch.SelectedValue.Trim();
                objEWA.ClassId = ddlclass.SelectedValue.Trim();

                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                DataSet ds = new DataSet();

                ds = objBAL.BL_StudentIcard(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    database db = new database();
                   // grdIcard.DataSource = db.Displaygrid("SELECT        tblStudent.UserCode, tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName AS FullName FROM            tblStudent INNER JOIN                         tblClass ON tblStudent.BranchId = tblClass.BranchId WHERE        (tblStudent.OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "') AND (tblStudent.CourseId = '" + ddlcourse.SelectedValue.Trim() + "') AND (tblStudent.BranchId = '" + ddlbranch.SelectedValue.Trim() + "') AND (tblClass.ClassId = '" + ddlclass.SelectedValue.Trim() + "')");
                   grdIcard.DataSource = ds.Tables[0];
                    grdIcard.DataBind();

                btnPrintLoad.Visible = true;
                }
                else
                {

                    grdIcard.DataSource = null;
                    grdIcard.DataBind();

                    btnPrintLoad.Visible = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Get Branch
        #region[Get Branch]

        private void Getbranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.CourseId = ddlcourse.SelectedValue;
                DataSet ds = new DataSet();
                ds = objBL.BindBranches_BL(objEWA);
                ddlbranch.DataSource = ds.Tables[0];
                ddlbranch.DataTextField = "BranchName";
                ddlbranch.DataValueField = "BranchId";
                ddlbranch.DataBind();
                ddlbranch.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Get Class
        #region[Get Class]

        private void Getclass()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.BranchId = ddlbranch.SelectedValue;
                DataSet ds = new DataSet();
                ds = objBL.BindClass_BL(objEWA);
                ddlclass.DataSource = ds.Tables[0];
                ddlclass.DataTextField = "ClassName";
                ddlclass.DataValueField = "ClassId";
                ddlclass.DataBind();
                ddlclass.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Get Division
        #region[Get Division]

        private void Getdivision()
        {
         
        }

        #endregion

       

        //Page Indext Created
        #region[Grd Index Changed]

        protected void grdIcard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                BL_StudentView objBAL = new BL_StudentView();
                EWA_StudentView objEWA = new EWA_StudentView();

                objEWA.CourseId = ddlcourse.SelectedValue.Trim();

                objEWA.ClassId = ddlclass.SelectedValue.Trim();
                objEWA.BranchId = ddlbranch.SelectedValue.Trim();
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                DataSet ds = new DataSet();

                ds = objBAL.BL_StudentIcard(objEWA);
          

                grdIcard.DataSource = ds;
                grdIcard.DataBind();
                grdIcard.PageIndex = e.NewPageIndex;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        //Course Index Changed
        #region[Course Index Changed]

        protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Getbranch();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Index Changed
        #region[Branch Index Changed]

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Getclass();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Class Index Changed
        #region[Class Index Chnaged]

        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Getdivision();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Go Event
         #region[Go Event]

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrintLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                dt.Columns.Add("imgClgLogo");
                dt.Columns.Add("CollageFullName");
                dt.Columns.Add("Stud");
                dt.Columns.Add("Name");
                dt.Columns.Add("StudentId");
                dt.Columns.Add("DOB");
                dt.Columns.Add("bloodGroup");
                dt.Columns.Add("Stream");
                dt.Columns.Add("Conctact");
                dt.Columns.Add("AdharCard");
                dt.Columns.Add("CurrentAddress"); 
                dt.Columns.Add("Sign"); 


                dt1.Columns.Add("imgClgLogo");
                dt1.Columns.Add("CollageFullName");
                dt1.Columns.Add("Stud");
                dt1.Columns.Add("Name");
                dt1.Columns.Add("StudentId");
                dt1.Columns.Add("DOB");
                dt1.Columns.Add("bloodGroup");
                dt1.Columns.Add("Stream");
                dt1.Columns.Add("Conctact");
                dt1.Columns.Add("AdharCard");
                dt1.Columns.Add("CurrentAddress");
                dt1.Columns.Add("Sign");


                dt2.Columns.Add("imgClgLogo");
                dt2.Columns.Add("CollageFullName");
                dt2.Columns.Add("Stud");
                dt2.Columns.Add("Name");
                dt2.Columns.Add("StudentId");
                dt2.Columns.Add("DOB");
                dt2.Columns.Add("bloodGroup");
                dt2.Columns.Add("Stream");
                dt2.Columns.Add("Conctact");
                dt2.Columns.Add("AdharCard");
                dt2.Columns.Add("CurrentAddress");
                dt2.Columns.Add("Sign");


                int flag = 0, i = 1 ;
                foreach (GridViewRow gvrow in grdIcard.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");


                    if (chk != null && chk.Checked)
                    {
                        DataRow dr;

                        if (i % 3 == 0)
                        {
                            dr = dt2.NewRow();
                        }
                        else if (i % 2 != 0)
                        {
                            dr = dt.NewRow();
                        }
                        else
                        {
                            dr = dt1.NewRow();
                        }

                        flag = 1;
                        objEWA.OrgId = OrgID;
                        objEWA.StudentID = Convert.ToInt32(grdIcard.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString());

                        ds = objBAL.BL_StudentViewId(objEWA);

                        string DateofBirth = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                        DateTime DOB = Convert.ToDateTime(DateofBirth);

                        string Photo = ds.Tables[0].Rows[0]["Logo"].ToString();
                        string ImageUrl1 = null;
                        if (Photo != null && Photo != "")
                        {
                            Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            ImageUrl1 = "data:image/png;base64," + base64String;
                        }

                        //for student photo
                        string Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString();
                        string ImageUrl2 = null;
                        if (Photo1 != null && Photo1 != "")
                        {
                            Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            ImageUrl2 = "data:image/png;base64," + base64String;
                        }

                        dr[0] = ImageUrl1;
                        dr[1] = ds.Tables[0].Rows[0]["OrgName"].ToString();
                        dr[2] = ImageUrl2;
                        dr[3] = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["MiddleName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
                        dr[4] = ds.Tables[0].Rows[0]["UserCOde"].ToString();
                        dr[5] = DOB.ToString("dd-MMM-yyyy");
                        dr[6] = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                        dr[7] = ddlbranch.SelectedItem.ToString() + " " + ddlclass.SelectedItem.ToString();
                        dr[8] = ds.Tables[0].Rows[0]["Mobile"].ToString();
                        dr[9] = ds.Tables[0].Rows[0]["AdharNo"].ToString();
                        dr[10] = ds.Tables[0].Rows[0]["Address1"].ToString();
                        dr[11] = "../../Sign/" + OrgID+ ".png";

                        if (i % 3 == 0)
                        {
                            dt2.Rows.Add(dr);
                        }
                        else if (i % 2 != 0)
                        {
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dt1.Rows.Add(dr);
                        }

                        i++;
                    }
                }

                if(flag>0)
                {
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();

                    Repeater2.DataSource = dt1;
                    Repeater2.DataBind();

                    Repeater3.DataSource = dt2;
                    Repeater3.DataBind();

                    btnPrint.Visible = true;
                    //  pnlContents.Visible = true;
                }
                else
                {
                    Repeater1.DataSource = null;
                    Repeater1.DataBind();

                    Repeater2.DataSource = null;
                    Repeater2.DataBind();

                    Repeater3.DataSource = null;
                    Repeater3.DataBind();

                    btnPrint.Visible = false;
                    // pnlContents.Visible = false;

                    msgBox.ShowMessage("Atlist One student select..!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
    }
}
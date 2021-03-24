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

namespace CMS.Forms.Admin
{
    public partial class idcardmarathi : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BindControl ObjHelper = new BindControl();
        private DataSet ds = new DataSet();
        private BL_StudentView objBAL = new BL_StudentView();
        private EWA_StudentView objEWA = new EWA_StudentView();
        public static int orgId;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
        orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                if (!IsPostBack)
                {
                    ddlCourseBind();

                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                    if (objEWA.OrgId == 0)
                    {
                        Response.Redirect("~/College_Home.aspx");
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
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

        // Bind Student I-Card Data

        #region Student I Card

        private void StudentViewId(int OrgID, long StudentID)
        {
            DataSet ds;
            try
            {
                objEWA.OrgId = OrgID;
                objEWA.StudentID = StudentID;
                pnlContents.Visible = true;

                ds = objBAL.BL_StudentViewId(objEWA);

                //  lblTrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();
                lblCollageFullName.Text = ds.Tables[0].Rows[0]["OrgName"].ToString();

                lbldate.Text = Convert.ToString(Session["AcademicYear"]);

                string strFirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                string strMiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                string strLastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                //  string fullname = strFirstName + ' ' + "" + ' ' + strMiddleName + ' ' + "" + ' ' + strLastName;
                string strFullName = strFirstName + ' ' + "" + ' ' + strMiddleName + ' ' + "" + ' ' + strLastName;
                lblName.Text = strFullName;

                lblStudentId.Text = ds.Tables[0].Rows[0]["UserCOde"].ToString();
                string DateofBirth = ds.Tables[0].Rows[0]["BirthDate"].ToString();

                DateTime DOB = Convert.ToDateTime(DateofBirth);

                lblDOB.Text = DOB.ToShortDateString();

                lblStream.Text = ddlclass.SelectedItem.ToString();
                lblCourse.Text = ddlcourse.SelectedItem.ToString();

                lblCurrentAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                //Permanent address.
                //  lblPermanentAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                //lblEmail.Text = ds.Tables[0].Rows[0]["EMail"].ToString();
                lblbloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                lblParentConctact.Text = ds.Tables[0].Rows[0]["ParentMobile"].ToString();


                lblAdharCard.Text = ds.Tables[0].Rows[0]["LevelPlayed"].ToString();

                string Photo = ds.Tables[0].Rows[0]["Logo"].ToString();

                if (Photo != null && Photo != "")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgClgLogo.ImageUrl = "data:image/png;base64," + base64String;
                }

                //for student photo
                string Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString();

                if (Photo1 != null && Photo1 != "")
                {
                    Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgStud.ImageUrl = "data:image/png;base64," + base64String;
                }

                // BAR CODE GENERATOR CODE

                string barCode = ds.Tables[0].Rows[0]["UserCOde"].ToString();

                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);//bitMap.Width, bitMap.Height);
                        graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();

                        Convert.ToBase64String(byteImage);
                        //  imgBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                    // imgBarcode.Controls.Add(imgBarCode);
                }

                // END OF BARCODE CODE
            }

            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion 

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

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                database db = new database();
                grdIcard.DataSource = db.Displaygrid("SELECT        tblStudent.UserCode, tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName AS FullName FROM            tblStudent INNER JOIN                         tblClass ON tblStudent.BranchId = tblClass.BranchId WHERE        (tblStudent.OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "') AND (tblStudent.CourseId = '" + ddlcourse.SelectedValue.Trim() + "') AND (tblStudent.BranchId = '" + ddlbranch.SelectedValue.Trim() + "') AND (tblClass.ClassId = '" + ddlclass.SelectedValue.Trim() + "')");
                //   grdIcard.DataSource = ds.Tables[0];
                grdIcard.DataBind();
                // }
                //else
                //{
                //    DataTable dt = new DataTable();

                //    dt.Columns.Add("UserCode");
                //    dt.Columns.Add("FullName");
                //    //dt.Rows.Add();
                //    //dt.Rows.Add();
                //    //dt.Rows.Add();
                //    grdIcard.DataSource = dt;
                //    grdIcard.DataBind();
                //}
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

        //Grid View Index changed
        #region[Grid View Index Changed]

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow grdrow = btn.NamingContainer as GridViewRow;
                long StudentID = Convert.ToInt64(grdIcard.DataKeys[grdrow.RowIndex].Values[0].ToString());

                int OrgID = Convert.ToInt32(Session["OrgId"]);

                StudentViewId(OrgID, StudentID);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
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

        //View Event
        #region[View Event]

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Visible = true;
                Button btn = (Button)sender;
                GridViewRow grdrow = btn.NamingContainer as GridViewRow;
                long StudentID = Convert.ToInt64(grdIcard.DataKeys[grdrow.RowIndex].Values[0].ToString());

                int OrgID = Convert.ToInt32(Session["OrgId"]);

                StudentViewId(OrgID, StudentID);
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
    }
}
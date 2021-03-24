using BusinessAccessLayer.Faculty;
using DataAccessLayer;
using EntityWebApp.Faculty;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Student
{
    public partial class ViewAnnualResultPDF : System.Web.UI.Page
    {

        //Objects

        #region[Objects]


        private BindControl ObjHelper = new BindControl();
        database db = new database();
        public static int orgId=0;
        #endregion

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
                        
                        FatchCourseBranchClass();
                        BindGrdResult();
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


        #region[Fatch Course Branch Class]

        private void FatchCourseBranchClass()
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
                    Session["CourseId"]  = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
                    Session["BranchId"]  = Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString());
                    Session["ClassId"]  = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
                }
            }
            catch (Exception exp)
            {
               // GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        #region[Bind GrdResult]

        private void BindGrdResult()
        {
            try
            {
                BL_UploadResult objBL = new BL_UploadResult();
                EWA_UploadResult objEWA = new EWA_UploadResult();
                objEWA.Action = "FatchResultPDF";
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.CourseId = Session["CourseId"].ToString();
                objEWA.BranchId = Session["BranchId"].ToString();
                objEWA.ClassId = Session["ClassId"].ToString();

                DataSet ds = objBL.FatchResultPDF_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblNodata.Visible = false;
                    grdResults.Visible = true;

                    grdResults.DataSource = ds;
                    grdResults.DataBind();
                }
                else
                {
                    DataTable dt=new DataTable();
                    grdResults.DataSource = dt;
                    grdResults.DataBind();
                    lblNodata.Visible = true;
                    //grdResults.Visible = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion


        //lnkBtnDownload_Click
        #region lnkBtnDownload_Click

        protected void lnkBtnDownload_Click(object sender, EventArgs e)
        {
            //try
            //{
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                string  TestId= grdResults.DataKeys[grdrow.RowIndex].Values["TestId"].ToString();
                DataTable ddt = db.DisplaygridView("select UploadedFile from tblUploadResultPDF where TestId="+ TestId);

                byte[] bytes;
                    string fileName, contentType;
                    
                    bytes = (byte[])ddt.Rows[0]["UploadedFile"];
                    contentType = grdResults.DataKeys[grdrow.RowIndex].Values["ContentType"].ToString(); 
                    fileName = grdResults.DataKeys[grdrow.RowIndex].Values["FileName"].ToString();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = contentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();

                    msgBox.ShowMessage("Download Successfully !!!", "Download", UserControls.MessageBox.MessageStyle.Successfull);
                    
                }
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }

        #endregion



        protected void GeneralErr(String msg)
        {
           // msgBox.ShowMessage(msg, "Critical", CMS.UserControls.MessageBox.MessageStyle.Critical);
            //Response.Write("<script>alert('" + msg + "')</script>");
        }
    }
}
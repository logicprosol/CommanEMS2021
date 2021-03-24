using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CMS.Forms.Faculty
{
    public partial class ResultFormatDownload : System.Web.UI.Page
    {
        public static int orgId=0;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
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
                    //if (Request.QueryString["ID"] == "1")
                    //{
                    //    msgBox.ShowMessage("Downloaded Successfully in '" + Request.QueryString["path"] + "' !", "Information", UserControls.MessageBox.MessageStyle.Critical);
                    //}
                    BindCourse();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
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

        #region[Bind Semester]

        private void BindSemester()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                //objEWA.OrgId = Session["OrgId"].ToString();
                //objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                //objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                DataSet ds = objBL.BindSemester_BL(objEWA);

                ddlSemester.DataSource = ds;
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlSemester.DataTextField = "SemesterName";
                    ddlSemester.DataValueField = "SemesterId";
                    ddlSemester.DataBind();
                }
                else
                    ddlSemester.Items.Clear();
            
                ddlSemester.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion
        
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {

                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.SemesterId = ddlSemester.SelectedValue.ToString();

                DataSet ds = objBL.BindResultFormat_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("UserCode");
                    dt.Columns.Add("Student Name");
                    int i = 0;
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        dt.Columns.Add(ds.Tables[0].Rows[i][1].ToString());
                        i++;
                    }

                    i = 0;
                    while (ds.Tables[1].Rows.Count > i)
                    {

                        DataRow dr = dt.NewRow();
                        dr[0] = ds.Tables[1].Rows[i][0].ToString();
                        dr[1] = ds.Tables[1].Rows[i][1].ToString();
                        i++;
                        dt.Rows.Add(dr);
                    }

                    grdResultFormat.DataSource = dt;
                    grdResultFormat.DataBind();
                    grdResultFormat.CellPadding = 10;
                    if (dt.Rows.Count < 0)
                        grdResultFormat.Rows[0].Cells[0].Text = "Record not found !!!";

                    //export();

                    
                }
                else
                {
                    GeneralErr("Not Found Recoder...!");
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

            if (grdResultFormat.Rows.Count > 0)
            {
                Session["CourseId"] = ddlCourse.SelectedValue.ToString();
                Session["BranchId"] = ddlBranch.SelectedValue.ToString();
                Session["ClassId"] = ddlClass.SelectedValue.ToString();
                Session["SemesterId"] = ddlSemester.SelectedValue.ToString();

                //Response.Redirect("~/ResultFormat.aspx");
                BindGrid();

            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSemester();
        }

        public void export()
        {
            string dt = System.DateTime.Now.ToString("MM/yyyy");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ResultFormat" + dt + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdResultFormat.AllowPaging = false;
                //this.BindGrid();

                grdResultFormat.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdResultFormat.HeaderRow.Cells)
                {
                    cell.BackColor = grdResultFormat.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdResultFormat.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdResultFormat.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdResultFormat.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdResultFormat.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
            //Response.Write("<script>alert('" + msg + "')</script>");
        }

        private void BindGrid()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                objEWA.BranchId = Session["BranchId"].ToString();
                objEWA.CourseId = Session["CourseId"].ToString();
                objEWA.ClassId = Session["ClassId"].ToString();
                objEWA.SemesterId = Session["SemesterId"].ToString();

                DataSet ds = objBL.BindResultFormat_BL(objEWA);

                ExcelExport(ds);

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        public void ExcelExport(DataSet ds)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                workSheet.Cells[1, 1].Value = "UserCode";
                workSheet.Cells[1, 2].Value = "Student Name";
                int i = 0, j = 3;
                while (ds.Tables[0].Rows.Count > i)
                {
                    workSheet.Cells[1, j].Value = ds.Tables[0].Rows[i][1].ToString();
                    workSheet.Cells[1, j + 1].Value = (ds.Tables[0].Rows[i][1].ToString()).Substring(0, 3) + " Total";
                    i++;
                    j = j + 2;
                }

                workSheet.Cells[1, j].Value = "Total Marks";
                workSheet.Cells[1, j + 1].Value = "Result";
                j = j + 2;
                i = 0;
                int recordIndex = 2;
                while (ds.Tables[1].Rows.Count > i)
                {

                    workSheet.Cells[recordIndex, 1].Value = ds.Tables[1].Rows[i][0].ToString();
                    workSheet.Cells[recordIndex, 2].Value = ds.Tables[1].Rows[i][1].ToString();
                    i++; recordIndex++;
                }

                i = 1;
                while (j >= i)
                {
                    
                    workSheet.Column(i).AutoFit();
                    i++;
                }
                string dt1 = System.DateTime.Now.ToString("MM/yyyy");
                string excelName = "ResultFormat_" + ddlBranch.SelectedItem.ToString() + "_" + ddlClass.SelectedItem.ToString() + "_" + ddlSemester.SelectedItem.ToString() + ".xls";
                workSheet.Protection.IsProtected = false;
                workSheet.Protection.AllowSelectLockedCells = false;
                string folderPath = "C:/Users/MyFiles/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string _path = folderPath + "ResultFormat_" + ddlBranch.SelectedItem.ToString() + "_" + ddlClass.SelectedItem.ToString() + "_" + ddlSemester.SelectedItem.ToString() + ".xls";// + excelName;
                excel.SaveAs(new FileInfo(_path));
                
                

                string path = folderPath + "ResultFormat_" + ddlBranch.SelectedItem.ToString() + "_" + ddlClass.SelectedItem.ToString() + "_" + ddlSemester.SelectedItem.ToString() + ".xls";
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                string Outgoingfile = "ResultFormat.xlsx";
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Outgoingfile);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.WriteFile(file.FullName);

                    
                }
                else
                {
                    Response.Write("This file does not exist.");
                }


                msgBox.ShowMessage("Downloaded Successfully in '" + _path + "' !", "Information", UserControls.MessageBox.MessageStyle.Information);
                
            }
            else
            {
                GeneralErr("Not Found Recoder...!");
            }

            
        }
    }
}
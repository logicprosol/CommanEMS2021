using BusinessAccessLayer;
using EntityWebApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace CMS
{
    public partial class ResultFormat1 : System.Web.UI.Page
    {
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (orgId.ToString() == null)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                orgId = Convert.ToInt32(Session["orgID"].ToString());
                if (!IsPostBack)
                {
                    BindGrid();
                    export();
                }
            }
        }

        private void BindGrid()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgID"].ToString();
                objEWA.BranchId = Session["BranchId"].ToString();
                objEWA.CourseId = Session["CourseId"].ToString();
                objEWA.ClassId = Session["ClassId"].ToString();
                objEWA.SemesterId = Session["SemesterId"].ToString();

                DataSet ds = objBL.BindResultFormat_BL(objEWA);

                //ExcelExport(ds);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("UserCode", typeof(string));
                    dt.Columns.Add("Student Name", typeof(string));
                    int i = 0;
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        dt.Columns.Add(ds.Tables[0].Rows[i][1].ToString(), typeof(string));
                        dt.Columns.Add((ds.Tables[0].Rows[i][1].ToString()).Substring(0, 3) + "_Tot", typeof(string));
                        i++;
                    }

                    dt.Columns.Add("Total Marks", typeof(string));
                    dt.Columns.Add("Result", typeof(string));

                    i = 0;
                    while (ds.Tables[1].Rows.Count > i)
                    {

                        DataRow dr = dt.NewRow();
                        dr[0] = ds.Tables[1].Rows[i][0].ToString();
                        dr[1] = ds.Tables[1].Rows[i][1].ToString();
                        i++;
                        dt.Rows.Add(dr);
                    }

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.CellPadding = 10;
                    if (dt.Rows.Count < 0)
                        GridView1.Rows[0].Cells[0].Text = "Record not found !!!";

                    export();

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
        }

        public void export()
        {
            if (GridView1.Rows.Count > 0)
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
                    GridView1.AllowPaging = false;
                    //BindGrid();

                    GridView1.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in GridView1.HeaderRow.Cells)
                    {
                        cell.BackColor = GridView1.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = GridView1.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    GridView1.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                    
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

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
                string excelName = "ResultFormat"+ dt1+".xls";
                workSheet.Protection.IsProtected = false;
                workSheet.Protection.AllowSelectLockedCells = false;
                string folderPath = "C:/Users/MyFiles/";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string _path = folderPath + "ResultFormat.xls";// + excelName;
                excel.SaveAs(new FileInfo(_path));
                Response.Redirect("ResultFormatDownload?ID=1 &path="+ _path);
                // excel.SaveAs(new FileInfo(_path));
                //excel.Save();

                //using (var memoryStream = new MemoryStream())
                //{
                //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //    Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xlsx");
                //    excel.SaveAs(memoryStream);
                //    memoryStream.WriteTo(Response.OutputStream);
                //    Response.Flush();
                //    Response.End();
                //}
            }
            else
            {
                GeneralErr("Not Found Recoder...!");
            }





            //workSheet.Cells[1, 1].Value = "S.No";
            //workSheet.Cells[1, 2].Value = "Id";
            //workSheet.Cells[1, 3].Value = "Name";
            //workSheet.Cells[1, 4].Value = "Address";

            //Body of table  
            //  
            //int recordIndex = 2;
            //foreach (var student in students)
            //{
            //    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
            //    workSheet.Cells[recordIndex, 2].Value = student.Id;
            //    workSheet.Cells[recordIndex, 3].Value = student.Name;
            //    workSheet.Cells[recordIndex, 4].Value = student.Address;
            //    recordIndex++;
            //}
            //workSheet.Column(1).AutoFit();
            //workSheet.Column(2).AutoFit();
            //workSheet.Column(3).AutoFit();
            //workSheet.Column(4).AutoFit();

        }

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
            Response.Write("<script>alert('" + msg + "')</script>");
        }
    }
}
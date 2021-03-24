using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    
    public partial class downloadidcarddata : System.Web.UI.Page
    {
        public static int orgId;
        database db = new database();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

    grdnew.DataSource = db.Displaygrid("SELECT UserCode,FirstName +' '+ MiddleName +' ' +LastName AS StudentName, 		CourseName,BranchName,TCL.ClassName,TD.DivisionName,TS.Address ,TS.Mobile ,TS.AdharNo  		FROM tblStudent TS 		INNER JOIN tblCourse TC ON TC.CourseId=TS.CourseId 		INNER JOIN tblBranch TB ON TB.BranchId=TS.BranchId  		INNER JOIN  tblClass TCL ON TCL.ClassId=TS.ClassId  		INNER JOIN tblAcademicYear AY ON AY.AcademicYearId=TS.AcademicYearId  		WHERE TS.OrgId='"+Session["OrgId"]+"'");
            grdnew.DataBind();
            export();


      //  grdpassword.DataSource = db.Displaygrid  ("SELECT        tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName AS StudentName, tblStudent.UserCode, tblUser.UserName, tblUser.Password FROM            tblStudent INNER JOIN                          tblUser ON tblStudent.UserCode = tblUser.UserCode where Role='Student' and OrgId='22' ");
      //.DataBind();
        }

        public void export()
        {
            string dt = System.DateTime.Now.ToString("MM-yyyy");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=StaffSalaryReport" + dt + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw1 = new HtmlTextWriter(sw);

                //To Export all pages
                grdnew.AllowPaging = false;
            
                grdnew.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdnew.HeaderRow.Cells)
                {
                    cell.BackColor = grdnew.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdnew.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdnew.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdnew.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                // GridView1.RenderControl(hw);
                grdnew.RenderControl(hw1);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}
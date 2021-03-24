using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;
using EntityWebApp;
using BusinessAccessLayer;
using DataAccessLayer;

namespace CMS.Forms.SuperAdmin
{
    public partial class UploadStudentList : System.Web.UI.Page
    {string CS = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BindGridview();
                AddCollegeToDropDown();
                //BindCourse();
            }
        }

        private void BindGridview()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (con)
                    {
                        GridView1.DataSource = cmd.ExecuteReader();
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId =DDL_SelectCollege.SelectedValue;
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                
            }
        }
        private void AddCollegeToDropDown()
        {

            try
            {
                EWA_SuperAdmin clas1 = new EWA_SuperAdmin();
                BL_SuperAdmin bcls = new BL_SuperAdmin();

                DataSet ds = bcls.AddCollegeToDropDown();

                
                DDL_SelectCollege.DataSource = ds.Tables[0];
                DDL_SelectCollege.DataTextField = "OrgLabel";
                DDL_SelectCollege.DataValueField = "OrganizationId";
                DDL_SelectCollege.DataBind();
                DDL_SelectCollege.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook  
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet4$]", con);
                        DataTable _dataTable = new DataTable();
                        con.Open();
                        using (con)
                        {
                            // Create DbDataReader to Data Worksheet  
                            DbDataReader dr = cmd.ExecuteReader();
                           
                            _dataTable.Load(dr);
                        }
                        con.Close();
                        foreach (DataRow ddr in _dataTable.Rows)
                        {
                            ddr["CourseId"] = ddlCourse.SelectedValue;
                            ddr["BranchId"] = ddlBranch.SelectedValue;
                            ddr["ClassId"] = ddlClass.SelectedValue;
                            ddr["OrgId"] = DDL_SelectCollege.SelectedValue;
                        }
                        
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "tblAdmissionDetails";
                        bulkInsert.WriteToServer(_dataTable);
                 
                        BindGridview();
                        lblMessage.Text = "Your file uploaded successfully";
                        msgBox.ShowMessage("Your file uploaded successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        GridView1.DataSource = _dataTable;
                        GridView1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Your file not uploaded";
                    msgBox.ShowMessage("Your file not uploaded !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }
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
               
            }
        }
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
               
            }
        }

        protected void DDL_SelectCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCourse();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dal;
using Entity;

namespace CMS.Forms.Library
{
    public partial class Return_Book : System.Web.UI.Page
    {
        public static int orgId=0;
        DataSet ds = new DataSet();
        database db = new database();
        Label bookid = new Label();
        Label studid = new Label();
        Label grpid = new Label();
        Label author = new Label();
        int studid1 = 0;
        clse_returnbook clse = new clse_returnbook();
        clsd clsd = new clsd();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            try
            {

                orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                   Response.Redirect("~/CMSHome.aspx");
                }
                else
                {
                    searchdata.Value = orgId.ToString();
                   // gvbook.DataBind();
                    if (Request.QueryString["Id"] != null)
                    {
                        if (!IsPostBack)
                        {

                          
                            string id = Request.QueryString["Id"].ToString();
                            SqlCommand cmd1 = new SqlCommand(" SELECT tblLibIssueBook.IssueId, tblLibAddBook.BookName, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblLibIssueBook.barcode, tblStudent.UserCode, tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName AS Name, tblLibAddGroup.GroupName, tblLibAddBook.Author FROM tblLibAddBook INNER JOIN tblLibIssueBook ON tblLibAddBook.BookId = tblLibIssueBook.BookId INNER JOIN tblLibAddGroup ON tblLibAddBook.GroupId = tblLibAddGroup.GroupId AND tblLibIssueBook.GroupId = tblLibAddGroup.GroupId INNER JOIN tblStudent ON tblLibIssueBook.StudentId = tblStudent.UserCode WHERE (tblLibIssueBook.IssueId = '" + id.ToString() + "') ", cn);
                            //SqlCommand cmd1 = new SqlCommand("SELECT  tblLibAddBook.BookName, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblStudent.FirstName, tblLibAddGroup.GroupName FROM            tblLibAddBook INNER JOIN                          tblLibIssueBook ON tblLibAddBook.BookId = tblLibIssueBook.BookId INNER JOIN                          tblLibAddGroup ON tblLibAddBook.GroupId = tblLibAddGroup.GroupId AND tblLibIssueBook.GroupId = tblLibAddGroup.GroupId INNER JOIN                          tblStudent ON tblLibIssueBook.StudentId = tblStudent.UserCode WHERE        (tblLibIssueBook.StudentId = '" + id.ToString()+ "') ", cn);
                            SqlDataAdapter adp1 = new SqlDataAdapter();
                            DataSet ds1 = new DataSet();
                            adp1.SelectCommand = cmd1;
                            adp1.Fill(ds1);
                            txtBarcode.Text = ds1.Tables[0].Rows[0]["barcode"].ToString();
                            txtBookName.Text = ds1.Tables[0].Rows[0]["BookName"].ToString();
                            txtGroupName.Text = ds1.Tables[0].Rows[0]["GroupName"].ToString();
                            txtAuthor.Text = ds1.Tables[0].Rows[0]["Author"].ToString();
                            txtIssueDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["IssueDate"]).ToShortDateString();
                            txtDueDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["DueDate"]).ToShortDateString();
                            txtIssueTo.Text = ds1.Tables[0].Rows[0]["UserCode"].ToString();
                            txtIssueName.Text = ds1.Tables[0].Rows[0]["Name"].ToString();
                            lblIssueId.Text= ds1.Tables[0].Rows[0]["IssueId"].ToString();
                            btnDelete.Enabled = true;
                    
                        }
                
                    }
                   
                }
            }
            catch(Exception ex)
            {
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found')", true);

            }
        }

        protected void txtIssueTo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
            txtBarcode.Focus();

            if (txtBarcode.Text != null)
            {
                //SqlCommand cmd1 = new SqlCommand("SELECT tblLibIssueBook.IssueId, tblLibIssueBook.GroupId, tblLibIssueBook.BookId, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblStudent.UserCode,tblLibIssueBook.StudentId , (tblStudent.FirstName +' ' + tblStudent.MiddleName  + ' '+tblStudent.LastName)Firstname FROM tblLibIssueBook INNER JOIN tblStudent ON tblLibIssueBook.StudentId = tblStudent.UserCode   where barcode='" + txtBarcode.Text + "'", cn);
                //SqlDataAdapter adp1 = new SqlDataAdapter();
                //DataSet ds1 = new DataSet();
                //adp1.SelectCommand = cmd1;
                //adp1.Fill(ds1);

                //    studid1= Convert.ToInt32(ds1.Tables[0].Rows[0]["IssueId"].ToString());
                //    bookid.Text = ds1.Tables[0].Rows[0]["BookId"].ToString();
                //grpid.Text = ds1.Tables[0].Rows[0]["GroupId"].ToString();
                //bookid.Text = ds1.Tables[0].Rows[0]["BookId"].ToString();
                //txtIssueDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["IssueDate"]).ToShortDateString();
                //txtDueDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["DueDate"]).ToShortDateString();
                //txtIssueTo.Text = ds1.Tables[0].Rows[0]["UserCode"].ToString();
                //    txtIssueName.Text = ds1.Tables[0].Rows[0]["Firstname"].ToString();
                //    //  string name = db.getDbstatus_Value("SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS StdName FROM  tblStudent   WHERE  OrgId='" + orgId.ToString() + "' and StudentId='"++"'");



                //    string abc = db.getDbstatus_Value("select BookName from  tblLibAddBook where BookId='" + bookid.Text + "'");
                //txtBookName.Text = abc.ToString();
                //string author = db.getDbstatus_Value("select Author from  tblLibAddBook where BookId='" + bookid.Text + "'");
                //txtAuthor.Text = author.ToString();
                //string xyz = db.getDbstatus_Value("select GroupName from tblLibAddGroup where GroupId='" + grpid.Text + "' ");
                //txtGroupName.Text = xyz.ToString();

                hdnbarcode.Value = txtBarcode.Text;

                // hdnfirstname.Value = txtIssueName.Text;
                gvbook.DataSource = db.Displaygrid("SELECT  tblLibIssueBook.IssueId,      tblLibAddBook.BookName, tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName as Name, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblLibIssueBook.barcode, tblLibIssueBook.StudentId FROM            tblLibIssueBook INNER JOIN                          tblLibAddBook ON tblLibIssueBook.BookId = tblLibAddBook.BookId INNER JOIN                         tblStudent ON tblLibIssueBook.StudentId = tblStudent.UserCode WHERE        (tblLibIssueBook.barcode = '" + txtBarcode.Text + "')");
                gvbook.DataSourceID = null;
                gvbook.DataBind();
            }
            }
                catch(Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found')", true);

                }
        }

        protected void txtDueDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string b = lblIssueId.Text;
                db.cnopen();
                float biikiddd = db.getDb_Value("select BookId from tblLibAddBook where barcode ='" + txtBarcode.Text + "' and OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");
                float stock = db.getDb_Value("select qty from  tblLibAddBook where BookId='" + biikiddd.ToString() + "' and OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");
                float newstock = stock + 1;
                db.insert("update tblLibAddBook  set  qty='" + newstock + " '  where BookId ='" + biikiddd.ToString() + "' and  OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");
                db.insert("delete tblLibIssueBook where IssueId='" + b.ToString() + "'and barcode='" + txtBarcode.Text + "' ");

                db.cnclose();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Book Returned Successfully')", true);
                clear();
                gvbook.DataBind();

              
            }
            catch(Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found')", true);

            }
           
           // Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            txtBarcode.Text = "";
            txtGroupName.Text = "";
            txtIssueTo.Text = "";
            txtBookName.Text = "";
            txtIssueName.Text = "";
            txtAuthor.Text = "";
            txtIssueDate.Text = "";
            txtDueDate.Text = "";

        }

        protected void gvbook_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gvbook.Rows.Count > 0)
            {
                for (int i = 0; i < gvbook.Rows.Count; i++)
                {
                    gvbook.Rows[i].Cells[3].Text = Convert.ToDateTime(gvbook.Rows[i].Cells[3].Text).ToShortDateString();
                    gvbook.Rows[i].Cells[4].Text = Convert.ToDateTime(gvbook.Rows[i].Cells[4].Text).ToShortDateString();

                }
            }
        }


    }
}
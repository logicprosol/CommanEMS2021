using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace CMS.Forms.Library
{
    public partial class BookShow : System.Web.UI.Page
    {
       
        public static int orgId=0;
        DataSet ds = new DataSet();
        database db = new database();
        Label bookid = new Label();
        Label studid=new Label();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            if (!IsPostBack)
            {
                txtIssueDate.Attributes.Add("ReadOnly","True");
                txtDueDate.Attributes.Add("ReadOnly", "True");
                txtIssueDate_CalendarExtender.SelectedDate = DateTime.Today.Date;
            }

        }

        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();

            try{

            //FETCH DATA 
                if (txtBarcode.Text != null)
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT BookId, GroupId,PublishingYear,BookName,Edition,Author,Price,Publisher FROM tblLibAddBook where OrgId='" + orgId.ToString() + "'and barcode='" + txtBarcode.Text + "'", cn);
                    SqlDataAdapter adp1 = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();
                    adp1.SelectCommand = cmd1;
                    adp1.Fill(ds1);
                    txtGroupName.Text = ds1.Tables[0].Rows[0]["GroupId"].ToString();
                    txtPublishYear.Text = ds1.Tables[0].Rows[0]["PublishingYear"].ToString();
                    txtBookName.Text = ds1.Tables[0].Rows[0]["BookName"].ToString();
                    txtEdition.Text = ds1.Tables[0].Rows[0]["Edition"].ToString();
                    txtAuthor.Text = ds1.Tables[0].Rows[0]["Author"].ToString();
                    txtPrice.Text = ds1.Tables[0].Rows[0]["Price"].ToString();
                    txtPublisher.Text = ds1.Tables[0].Rows[0]["Publisher"].ToString();

                    float stock = db.getDb_Value("select qty from  tblLibAddBook where BookId='" + ds1.Tables[0].Rows[0]["BookId"].ToString() + "' and OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");
                    lblstock.Text = stock.ToString();
                }
         //  bookid.Text = ds1.Tables[0].Rows[0]["BookId"].ToString();
            }
            catch(Exception ex)
            {
                msgBox.ShowMessage("Barcode Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
            }
        }

        protected void txtIssueTo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtIssueTo.Text != null)
                {
                    SqlCommand cmd1 = new SqlCommand("  SELECT FirstName + ' ' + MiddleName + ' ' + LastName StdName FROM tblStudent   WHERE (UserCode = '" + txtIssueTo.Text + "') and OrgId='"+orgId.ToString()+"'", cn);
                    SqlDataAdapter adp1 = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();
                    adp1.SelectCommand = cmd1;
                    adp1.Fill(ds1);
                    txtIssueName.Text = ds1.Tables[0].Rows[0]["StdName"].ToString();


                }
            }
            catch(Exception ex)
            {
                msgBox.ShowMessage("Record Not Found!!!", "Information", UserControls.MessageBox.MessageStyle.Information);
            }
        }


        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                float b = db.getDb_Value("select BookId from  tblLibAddBook where OrgId='" + orgId.ToString() + "'and barcode='" + txtBarcode.Text + "'");
                bookid.Text = b.ToString();


                //string booknam = db.getDbstatus_Value("select BookName from tblLibAddBook where BookId='" + bookid.Text + "'");

                //float a = db.getDb_Value("select StudentId from tblStudent where UserCode='" + txtIssueTo.Text + "' and OrgId='"+orgId.ToString()+"'");
                //studid.Text = a.ToString();   

                string status = db.getDbstatus_Value("select count(*) from tblLibIssueBook where StudentId='" + txtIssueTo.Text + "' and BookId='" + bookid.Text + "'");
                if (Convert.ToInt32(status) == 0)
                {
                    db.cnopen();
                 db.insert("insert into tblLibIssueBook values('" + txtGroupName.Text + "','" + bookid.Text + "','" + txtIssueTo.Text + "','" + DateTime.Now.Date + "','" + txtDueDate.Text + "','" + orgId.ToString() + "','" + Convert.ToInt32(Session["UserCode"].ToString()) + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "','" + "True" + "','" + 1 + "','" + txtBarcode.Text + "')");
                
                    float getoldstock = float.Parse(lblstock.Text);
                    float newstock = getoldstock - 1;

                    db.insert("update tblLibAddBook  set  qty='" + newstock + " '  where BookId ='" + bookid.Text + "' and  OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");
                    db.cnclose();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Book Issued Successfully')", true);

                    clear();
                    GrdBook.DataSource = db.Displaygrid("SELECT        tblStudent.UserCode, tblLibAddBook.BookName, tblLibAddBook.barcode, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblLibIssueBook.IssueId  FROM            tblLibIssueBook INNER JOIN                          tblLibAddBook ON tblLibIssueBook.BookId = tblLibAddBook.BookId INNER JOIN                          tblStudent ON tblLibAddBook.OrgId = tblStudent.OrgId AND tblLibIssueBook.StudentId = tblStudent.StudentId WHERE   tblLibIssueBook.OrgId = '" + orgId.ToString() + "'  ORDER BY tblLibIssueBook.IssueId DESC");
                    GrdBook.DataBind();
                }
                else if (Convert.ToInt32( status )> 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Book already Issued ')", true);
                }

                
            }
            catch (Exception ex) { }
            


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
            txtPublisher.Text = "";
            txtPublishYear.Text = "";
            txtPrice.Text = "";
            txtEdition.Text = "";
            lblstock.Text = "";

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void GrdBook_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GrdBook.Rows.Count > 0)
            {
                for (int i = 0; i < GrdBook.Rows.Count; i++)
                {
                    GrdBook.Rows[i].Cells[3].Text = Convert.ToDateTime(GrdBook.Rows[i].Cells[3].Text).ToShortDateString();
                    GrdBook.Rows[i].Cells[4].Text = Convert.ToDateTime(GrdBook.Rows[i].Cells[4].Text).ToShortDateString();

                }
            }
        }

        protected void GrdBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdBook.DataSource = db.Displaygrid("SELECT        tblStudent.UserCode, tblLibAddBook.BookName, tblLibAddBook.barcode, tblLibIssueBook.IssueDate, tblLibIssueBook.DueDate, tblLibIssueBook.IssueId  FROM            tblLibIssueBook INNER JOIN                          tblLibAddBook ON tblLibIssueBook.BookId = tblLibAddBook.BookId INNER JOIN                          tblStudent ON tblLibAddBook.OrgId = tblStudent.OrgId AND tblLibIssueBook.StudentId = tblStudent.StudentId WHERE   tblLibIssueBook.OrgId = '" + orgId.ToString() + "'  ORDER BY tblLibIssueBook.IssueId DESC");
                GrdBook.DataBind();
                GrdBook.PageIndex = e.NewPageIndex;
            }
            catch (Exception ex) { }
        }
    }
}
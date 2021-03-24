using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Library;
using EntityWebApp.Library;
using System.Data;

namespace CMS.Forms.Library
{
    public partial class IssueBook : System.Web.UI.Page
    {
        BL_IssueBook objBL = new BL_IssueBook();
        EWA_IssueBook objEWA = new EWA_IssueBook();
        DataSet ds = new DataSet();
        database db = new database();
        int orgId=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            if (!IsPostBack)
            {              
                
                DisableCntrl();
                GetBookGroup();
                GetIsueeBook();
            }
        }

        private void GetIsueeBook()
        {
            try
            {
                ds = new DataSet();
                objBL = new BL_IssueBook();
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                ds = objBL.GetIsueeBook_BL(objEWA);
                if (ds != null)
                {
                    GrdBook.DataSource = ds;
                    GrdBook.DataBind();
                }
                GrdBook.EmptyDataText = "Record Not Found ";
                GrdBook.DataBind();

            }
            catch (Exception ex)
            {
                

            }
        }

        private void EnableCntrl()
        {
            ddlBookName.Enabled = true;
            ddlGroupName.Enabled = true;

            txtIssueTo.Enabled = true;
            txtIssueDate.Enabled = true;
            txtDueDate.Enabled = true;


            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DisableCntrl()
        {
            ddlBookName.Enabled = false;
            ddlGroupName.Enabled = false;
            txtAuthor.Enabled = false;
            txtPublisher.Enabled = false;
            txtPublishYear.Enabled = false;
            txtEdition.Enabled = false;
            txtPrice.Enabled = false;

            txtIssueTo.Enabled = false;
            txtIssueName.Enabled = false;
            txtIssueDate.Enabled = false;
            txtDueDate.Enabled = false;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ClearCntrl()
        {
            ddlGroupName.SelectedIndex = -1;
            ddlBookName.SelectedIndex = -1;
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtPublishYear.Text = "";
            txtEdition.Text = "";
            txtPrice.Text = "";

            txtIssueTo.Text = "";
            txtIssueName.Text = "";
            txtIssueDate.Text = "";
            txtDueDate.Text = "";
        }

        private void GetBookGroup()
        {
            try
            {
                ds = new DataSet();
                objBL = new BL_IssueBook();
                objEWA.OrgId = Convert.ToInt32(orgId.ToString());
                ds = objBL.GetBookGroup_BL(objEWA);
                ddlGroupName.DataSource = ds;
                ddlGroupName.DataTextField = "GroupCode";
                ddlGroupName.DataValueField = "GroupId";
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {

            }
        }

        private void GetBook()
        {
            try
            {
                ds = new DataSet();
                objBL = new BL_IssueBook();
                objEWA = new EWA_IssueBook();
                objEWA.GroupId = Convert.ToInt32(ddlGroupName.SelectedValue.ToString());
                ds = objBL.GetBook_BL(objEWA);
                ddlBookName.DataSource = ds;
                ddlBookName.DataValueField = "BookId";
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {

            }
        }

        private void GetBookInfo()
        {
            try
            {
                ds = new DataSet();
                objBL = new BL_IssueBook();
                objEWA = new EWA_IssueBook();
                objEWA.BookId = Convert.ToInt32(ddlBookName.SelectedValue.ToString());
                ds = objBL.GetBookInfo_BL(objEWA);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAuthor.Text = ds.Tables[0].Rows[0]["Author"].ToString();
                    txtPublisher.Text = ds.Tables[0].Rows[0]["Publisher"].ToString();
                    txtPublishYear.Text = ds.Tables[0].Rows[0]["PublishingYear"].ToString();
                    txtEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    float stock = db.getDb_Value("select qty from  tblLibAddBook where BookId='" + objEWA.BookId + "' and OrgId='" + Convert.ToInt32(Session["OrgId"]) + "'");
                    lblstock.Text=stock.ToString();
                }
                else
                {
                    txtAuthor.Text = "";
                    txtPublisher.Text = "";
                    txtPublishYear.Text = "";
                    txtEdition.Text = "";
                    txtPrice.Text = "";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Action(string strAction)
        {
            try
            {
                objEWA = new EWA_IssueBook();
                objEWA.Action = strAction;
                objEWA.IssueId = Convert.ToInt32(ViewState["IssueId"].ToString());
                objEWA.BookId = Convert.ToInt32(ddlBookName.SelectedValue.ToString());
                objEWA.GroupId = Convert.ToInt32(ddlGroupName.SelectedValue.ToString());
                objEWA.StudentId = Convert.ToInt32(ViewState["StudentId"].ToString());
                objEWA.IssueDate = txtIssueDate.Text.ToString(); //System.Data.SqlTypes.SqlDateTime.Parse(txtIssueDate.Text).ToString();
                objEWA.DueDate = txtDueDate.Text.ToString(); //System.Data.SqlTypes.SqlDateTime.Parse(txtDueDate.Text).ToString();
                objEWA.OrgId = orgId;
                objEWA.UserId = Convert.ToInt32(Session["UserCode"].ToString());
                objEWA.IsActive = "true";

                //if (CheckBookName(objEWA) > 0)
                //{
                //    msgBox.ShowMessage("Record Already Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                //    return;
                //}

                int flag = objBL.IssueBookAction_BL(objEWA);
                if (flag > 0)
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("Record Saved Successfully !!!", "Saved", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Record Updated Successfully !!!", "Updated", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Record Deleted Successfully !!!", "Deleted", UserControls.MessageBox.MessageStyle.Successfull);
                    }
                    ClearCntrl();
                    DisableCntrl();
                    GetIsueeBook();
                }
                else
                {
                    if (strAction == "Save")
                    {
                        msgBox.ShowMessage("already exists cann't  Save !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "Update")
                    {
                        msgBox.ShowMessage("Unable to  Update !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                    else if (strAction == "Delete")
                    {
                        msgBox.ShowMessage("Unable to  Delete !!!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBook();
            GetBookInfo();
        }

        protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBookInfo();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearCntrl();
            EnableCntrl();
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ViewState["IssueId"] = 0;
            Action("Save");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Delete");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCntrl();
            DisableCntrl();
            btnNew.Enabled = true;
        }

        protected void txtIssueTo_TextChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            objBL = new BL_IssueBook();
            objEWA = new EWA_IssueBook();
            objEWA.StudentCode = txtIssueTo.Text.ToString();
            ds = objBL.GetStudentInfo_BL(objEWA);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["StudentId"] = ds.Tables[0].Rows[0]["StudentId"].ToString();
                txtIssueName.Text = ds.Tables[0].Rows[0]["StdName"].ToString();
            }
            else
            {
                ViewState["StudentId"] = "0";
                txtIssueName.Text = "";
            }

        }
    }
}
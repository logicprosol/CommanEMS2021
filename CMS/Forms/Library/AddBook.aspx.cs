using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Library;
using EntityWebApp.Library;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OnBarcode.Barcode;
using iTextSharp.text.pdf;
using System.IO;

namespace CMS.Forms.Library
{
    public partial class AddBook : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        BL_AddBook objBL = new BL_AddBook();
        EWA_AddBook objEWA = new EWA_AddBook();
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
               
                
              GetBook();
              GetBookGroup();
               DisableCntrl();
            }
            else
            {
                if (ddlGroupName.Items.Count <= 1)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT GroupName,GroupId FROM tblLibAddGroup  where OrgId='" + orgId.ToString() + "' "))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        ddlGroupName.DataSource = cmd.ExecuteReader();
                        ddlGroupName.DataTextField = "GroupName";
                        ddlGroupName.DataValueField = "GroupId";
                        ddlGroupName.DataBind();
                        cn.Close();
                    }

                    ddlGroupName.Items.Insert(0, new ListItem("--Select Group Name--"));
                }
            }
        }

        private void GetBook()
        {
            try
            {

                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                ds = objBL.GetBook_BL(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrdBook.DataSource = ds;
                    GrdBook.DataBind();

                    btnPrint.Visible = true;
                }
                else
                {
                    GrdBook.DataSource = ds;
                    GrdBook.DataBind();

                    btnPrint.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GetBookGroup()
        {
            try
            {
                ds = objBL.GetBookGroup_BL();
                ddlGroupName.DataSource = ds;
                ddlGroupName.DataTextField = "GroupCode";
                ddlGroupName.DataValueField = "GroupId";
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception)
            {
            }
        }

        private void EnableCntrl()
        {
            txtBookName.Enabled = true;
            ddlGroupName.Enabled = true;
            txtAuthor.Enabled = true;
            txtPublisher.Enabled = true;
            txtPublishYear.Enabled = true;
            txtEdition.Enabled = true;
            txtPrice.Enabled = true;
            txtBarcode.Enabled = true;
            txtquntity.Enabled = true;

            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DisableCntrl()
        {
            txtBookName.Enabled = false;
            ddlGroupName.Enabled = false;
            txtAuthor.Enabled = false;
            txtPublisher.Enabled = false;
            txtPublishYear.Enabled = false;
            txtEdition.Enabled = false;
            txtPrice.Enabled = false;
            txtBarcode.Enabled = false;
            txtquntity.Enabled = false;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ClearCntrl()
        {
            txtBookName.Text = "";
            ddlGroupName.SelectedIndex = -1;
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtPublishYear.Text = "";
            txtEdition.Text = "";
            txtPrice.Text = "";
            txtquntity.Text = "";
            txtBarcode.Text = "";
        }

        
        private int CheckBookName(EWA_AddBook objEWA)
        {
            int cnt = objBL.CheckBookName_BL(objEWA);
            return cnt;
        }

        private void Action(string strAction)
        {
            try
            {
                objEWA = new EWA_AddBook();
                objEWA.Action = strAction;
                objEWA.BookId = Convert.ToInt32(ViewState["BookId"].ToString());
                objEWA.BookName = txtBookName.Text.ToString();
                objEWA.BookCode = Convert.ToString(ViewState["BookCode"]).ToString();
                objEWA.GroupId = Convert.ToInt32(ddlGroupName.SelectedValue.ToString());
                objEWA.Author = txtAuthor.Text.ToString();
                objEWA.Publisher = txtPublisher.Text.ToString();
                objEWA.barcode = txtBarcode.Text;
                objEWA.PublishingYear = txtPublishYear.Text.ToString();
                objEWA.Edition = txtEdition.Text.ToString();
                objEWA.Price = Convert.ToDouble(txtPrice.Text.ToString());
                objEWA.OrgId = orgId;
                objEWA.UserId = Convert.ToInt32(Session["UserCode"].ToString());
                objEWA.IsActive = "true";
                objEWA.qty = Convert.ToInt32(txtquntity.Text);

                if (strAction == "Save" || strAction == "Update")
                {
                    if (CheckBookName(objEWA) > 0)
                    {
                        msgBox.ShowMessage("Record Already Exist !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        return;
                    }

                }
                int flag = objBL.BookAction_BL(objEWA);
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
                    GetBook();   
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

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearCntrl();
            EnableCntrl();
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtquntity.Enabled = true;
            txtBarcode.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ViewState["BookId"] = 0;
            ViewState["BookCode"] = "";
            Action("Save");
            //try
            //{
            //    db.cnopen();
            //    db.insert("insert into tblLibAddBook (BookCode,BookName,PublishingYear,GroupId,Edition,Author,Price,Publisher,barcode,OrgId) values ('" + Convert.ToString(ViewState["BookCode"]).ToString() + "','" + txtBookName.Text + "','" + txtPublishYear.Text + "','" + ddlGroupName.Text + "','" + txtEdition.Text + "','" + txtAuthor.Text + "','" + txtPrice.Text + "','" + txtPublisher.Text + "','" + txtBarcode.Text + "','" + orgId.ToString() + "') ");
            //    db.cnclose();
            //    GrdBook.DataBind();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Succefully')", true);
            //    // clear();
            //}


            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
        }


        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                Action("Update");
            }
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

        protected void lnkBookName_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBookCode = (LinkButton)sender;
                GridViewRow grdRow = (GridViewRow)lnkBookCode.NamingContainer;
                ViewState["BookId"] = GrdBook.DataKeys[grdRow.RowIndex].Values["BookId"].ToString();
                ViewState["BookCode"] = GrdBook.DataKeys[grdRow.RowIndex].Values["BookCode"].ToString();
                txtBookName.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["BookName"].ToString();
                ddlGroupName.SelectedValue = GrdBook.DataKeys[grdRow.RowIndex].Values["GroupId"].ToString();
                txtAuthor.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["Author"].ToString();
                txtPublisher.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["Publisher"].ToString();
                txtPublishYear.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["PublishingYear"].ToString();
                txtEdition.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["Edition"].ToString();
                txtPrice.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["Price"].ToString();
                txtBarcode.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["barcode"].ToString();
                txtquntity.Text = GrdBook.DataKeys[grdRow.RowIndex].Values["qty"].ToString();  //qty

                EnableCntrl();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void lnkBarodeGerator_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBookCode = (LinkButton)sender;
                GridViewRow grdRow = (GridViewRow)lnkBookCode.NamingContainer;
                var BarcodeValue = GrdBook.DataKeys[grdRow.RowIndex].Values["barcode"].ToString();
                GenerateBacode(BarcodeValue, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+BarcodeValue+"_barcode.png");

                msgBox.ShowMessage("Generated Bacode Successfull..!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);

            }
            catch (Exception ex)
            {

            }
        }
        private void GenerateBacode(string _data, string _filename)
        {
            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE39;
            barcode.Data = _data;
            barcode.drawBarcode(_filename);
        }

        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
     
        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/BookReport.aspx");
        }
        
    }
}
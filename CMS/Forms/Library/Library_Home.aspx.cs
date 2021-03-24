using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Library
{
    public partial class Library_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orgId;
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Page Links
        #region[Page Links]

        //Add Books
        protected void lbtnAddBooks_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddBook.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Add Book Groups
        protected void lbtnAddBookGroup_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddBookGroup.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        //Issue Books
        protected void lbtnIssueBooks_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BookShow.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        #endregion

        protected void lbtnIssueBooks0_Click(object sender, EventArgs e)
        {

            try
            {
                Response.Redirect("Return_Book.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
    }
}
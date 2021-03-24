using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.UserControls
{
    public partial class MessageBox : System.Web.UI.UserControl
    {
        
        public enum MessageStyle
        {
            Critical,
            Information,
            Successfull,
            Confirm,
            Question
        }

        public enum MessageType
        {
            OkOnly,
            YesNo
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnOk.OnClientClick = String.Format("fnClickOK('{0}','{1}')", btnOk.UniqueID, "");
            btnYes.Visible = false;
            btnOk.Focus();
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
            lblCaption.Text = "";
            tdCaption.Visible = false;
            mpext.Show();
        }

        public void ShowMessage(string Message, string Caption)
        {
            lblMessage.Text = Message;
            lblCaption.Text = Caption;
            btnOk.Text = "Ok";
            tdCaption.Visible = true;
            mpext.Show();
        }

        public void ShowMessage(string Message, string Caption, MessageStyle msg_style)
        {
            lblMessage.Text = Message;
            lblCaption.Text = Caption;
            btnOk.Text = "Ok";
            if (msg_style == MessageStyle.Information)
                imgInfo.ImageUrl = "~/images/msg_information.png";
            else if (msg_style == MessageStyle.Critical)
                imgInfo.ImageUrl = "~/images/msg_critical.png";
            else if (msg_style == MessageStyle.Successfull)
                imgInfo.ImageUrl = "~/images/msg_success.png";
            else if (msg_style == MessageStyle.Question)
                imgInfo.ImageUrl = "~/images/msg_question.png";

            tdCaption.Visible = true;
            mpext.Show();
        }

        public void ShowMessage(string Message, string Caption, MessageStyle msg_style, MessageType msg_type)
        {
            lblMessage.Text = Message;
            lblCaption.Text = Caption;
            if (msg_style == MessageStyle.Information)
                imgInfo.ImageUrl = "~/images/msg_information.png";
            else if (msg_style == MessageStyle.Critical)
                imgInfo.ImageUrl = "~/images/msg_critical.png";
            else if (msg_style == MessageStyle.Successfull)
                imgInfo.ImageUrl = "~/images/msg_success.png";
            else if (msg_style == MessageStyle.Question)
                imgInfo.ImageUrl = "~/images/msg_question.png";

            if (msg_type == MessageType.OkOnly)
            {
                btnYes.Visible = false; btnOk.Text = "Ok";
            }
            else if (msg_type == MessageType.YesNo)
            {
                btnYes.Visible = true; btnOk.Text = "No";
            }

            tdCaption.Visible = true;
            mpext.Show();
        }

        private void Hide()
        {
            lblMessage.Text = "";
            lblCaption.Text = "";
            mpext.Hide();
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            OnOkButtonPressed(e);
        }

        public delegate void OkButtonPressedHandler(object sender, EventArgs args);

        public event OkButtonPressedHandler OkButtonPressed;

        protected virtual void OnOkButtonPressed(EventArgs e)
        {
            if (OkButtonPressed != null)
                OkButtonPressed(btnOk, e);
        }
    }
}
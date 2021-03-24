using System;
using BusinessAccessLayer;
using EntityWebApp;
using System.Data;

//Change Password
namespace CMS.Forms.Student
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        //Object
        #region[Objects]
        private EWA_ChangePassword objEWA = new EWA_ChangePassword();
        private BL_ChangePassword objBL = new BL_ChangePassword();
        public static int orgId = 0;
        #endregion

        //Page Load
        #region[Page Page]

        protected void Page_Load(object sender, EventArgs e)
        {
            
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
}

        #endregion

        //Change Password
        #region[Change Password]

        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if (txtOldPassword.Text == "" && txtNewPassword.Text == "" && txtConfirmPassword.Text == "")
                {
                    GeneralErr("All fiels are mendatory !!!");
                }
                else if (txtConfirmPassword.Text == txtNewPassword.Text)
                {
                    objEWA.UserCode = Session["UserCode"].ToString();
                    objEWA.OldPassword = txtOldPassword.Text;
                    objEWA.NewPassword = txtNewPassword.Text;
                    ds = objBL.ChangePassword(objEWA);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int ErrorCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        if (ErrorCode == 0)
                        {
                            GeneralErr("Data Not Updated !!!");
                        }
                        else if (ErrorCode == -1)
                        {
                            GeneralErr("Please enter correct password !!!");
                        }
                        else
                        {
                            msgBox.ShowMessage("Password updated Successfully !!!", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
                            
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    GeneralErr("Confirm Pasword And New Password Mismatch !!!");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message);
            }
        }

        #endregion
        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
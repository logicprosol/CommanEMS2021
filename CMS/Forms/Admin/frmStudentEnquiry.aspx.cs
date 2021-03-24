using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp.Admin;
using System.Net.Mail;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using EntityWebApp;
using BusinessAccessLayer;

namespace CMS.Forms.Admin
{
    public partial class frmStudentEnquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Write(Request.RawUrl.ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(TxtFirstName.Text=="" || TxtFirstName.Text==string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Child First Name')", true);
                TxtFirstName.Focus();
                return;
            }
            if (TxtLastName.Text == "" || TxtLastName.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Child Last Name')", true);
                TxtLastName.Focus();
                return;
            }

            if (TxtMiddleName.Text == "" || TxtMiddleName.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Child Middle Name')", true);
                TxtMiddleName.Focus();
                return;
            }
            if (TxtDOB.Text == "" || TxtDOB.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Child Date Of Birth')", true);
                TxtMiddleName.Focus();
                return;
            }
            if (TxtAdmissionDate.Text == "" || TxtAdmissionDate.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Enquiry Date for Admission ')", true);
                TxtAdmissionDate.Focus();
                return;
            }
            if (TxtAddress.Text == "" || TxtAddress.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Address')", true);
                TxtAddress.Focus();
                return;
            }
            if (TxtStandard.Text == "" || TxtStandard.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Child Standard')", true);
                TxtStandard.Focus();
                return;
            }
            if (TxtWhatsupNumber.Text == "" || TxtWhatsupNumber.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('please Enter Whats app Number For Contact')", true);
                TxtWhatsupNumber.Focus();
                return;
            }


            EWA_Admission objEWA = new EWA_Admission();
            BL_Admission objBAL = new BL_Admission();


            objEWA.FirstName = TxtFirstName.Text;
            objEWA.LastName = TxtLastName.Text;
            objEWA.MiddleName = TxtMiddleName.Text;
            objEWA.ParentEmail = TxtEmail.Text;
            objEWA.MobileNo = TxtWhatsupNumber.Text;
            objEWA.BirthDate = TxtDOB.Text;
            objEWA.ApplicationDate = TxtAdmissionDate.Text;
            objEWA.Branch1 = TxtStandard.Text;
            objEWA.AddressLine1 = TxtAddress.Text;
            int flag = objBAL.InsertEnquiryInfo(objEWA);
            if (flag > 0)
            {
                Clear();
                msgBox.ShowMessage("Form Submitted  Successfully", "Saved", UserControls.MessageBox.MessageStyle.Successfull);

            }
            else
            {
                msgBox.ShowMessage("Some Problem Occured....", "Critical", UserControls.MessageBox.MessageStyle.Critical);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            TxtFirstName.Text = string.Empty;
            TxtLastName.Text = string.Empty;
            TxtMiddleName.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtAddress.Text = string.Empty;
            TxtAdmissionDate.Text = string.Empty;
            TxtDOB.Text = string.Empty;
            TxtStandard.Text = string.Empty;
            TxtWhatsupNumber.Text = string.Empty;
        }
    }
}
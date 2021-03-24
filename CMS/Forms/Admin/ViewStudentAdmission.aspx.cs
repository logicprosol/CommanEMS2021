using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Web;
using System.Text;

//View Student Addmission
namespace CMS.Forms.Admin
{
    public partial class ViewStudentAdmission : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_Admission objBAL = new BL_Admission();
        private EWA_Admission objEWA = new EWA_Admission();
        private DataSet ds;
        public static int orgID;

        private BindControl ObjHelper = new BindControl();
        #endregion
        //Page Load

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgID = Convert.ToInt32(Session["OrgId"]);
                    if (orgID == 0)
                    {
                        Response.Redirect("~/CMSHome.aspx");
                    }
                if (!IsPostBack)
                {
                    
                    BindDropDownData(orgID);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion PageLoad

        //Bind Drop Down
        #region[Bind Drop Down]

        protected void BindDropDownData(int orgID)
        {
            try
            {
                BL_Common objBL = new BL_Common();
                EWA_Common objEWA = new EWA_Common();

                objEWA.OrgId = Convert.ToString(orgID);

                ds = objBL.BindCourses_BL(objEWA);

                ddl_Course.DataSource = ds;
                ddl_Course.DataTextField = "CourseName";
                ddl_Course.DataValueField = "CourseId";
                ddl_Course.DataBind();
                ddl_Course.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Index Changed
        #region[Course Index Changed]

        protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.CourseId = ddl_Course.SelectedValue.ToString();

                ds = objBL.BindBranches_BL(objEWA);

                ddl_Branch.DataSource = ds;
                ddl_Branch.DataTextField = "BranchName";
                ddl_Branch.DataValueField = "BranchId";
                ddl_Branch.DataBind();
                ddl_Branch.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Index Changed
        #region[Branch Index Changed]

        protected void ddl_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddl_Branch.SelectedValue.ToString();

                ds = objBL.BindClass_BL(objEWA);

                ddl_Class.DataSource = ds;
                ddl_Class.DataTextField = "ClassName";
                ddl_Class.DataValueField = "ClassId";
                ddl_Class.DataBind();
                ddl_Class.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Grid View Data
        #region[Bind Grid View Data]

        private void BindGridviewData(int orgID,string AdmissionStatus )
        {
            try
            {
                objEWA.OrgID = orgID;
                objEWA.Course = ddl_Course.SelectedValue;
                objEWA.Branch1 = ddl_Branch.SelectedValue;
                objEWA.ClassId = ddl_Class.SelectedValue;
                objEWA.FromDate = txtFromDate.Text.ToString();
                objEWA.ToDate = txtToDate.Text.ToString();

                ds = new DataSet();
                ds = objBAL.SelectStudentAdmission(objEWA);

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    grdPendingAdmission.DataSource = ds;
                    grdPendingAdmission.DataBind();
                    int columncount = grdPendingAdmission.Rows[0].Cells.Count;
                    grdPendingAdmission.Rows[0].Cells.Clear();
                    grdPendingAdmission.Rows[0].Cells.Add(new TableCell());
                    grdPendingAdmission.Rows[0].Cells[0].ColumnSpan = columncount;
                    grdPendingAdmission.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    grdPendingAdmission.DataSource = ds;
                    grdPendingAdmission.DataBind();
                    
                }
                BtnApprove.Visible = true;
                btnGO.Visible = true;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Go Event
        #region[Go Event]

        protected void btnGO_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    BindGridviewData(orgID);
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            directSearch();

        }

        #endregion


        public void directSearch()
        {
            try
         {
            database db=new database();
            int flag = 0;
                //Commented And Added By Ashwini More 7-Oct-2020-------------------------------------------------------------------------------//

                //string qury = "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.EMail, " +
                //        "case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId "+
                //        " where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" + ddlAcademicYearId.SelectedValue+")> 0 then '' else 'Add fees' end as Status" +
                //        " FROM tblAdmissionDetails A where A.OrgId='" + orgID.ToString() + "' and   A.Status='"+"Pending"+"' and ";

                string qury = "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.Mobile,A.EMail," +
                    "tblCourse.CourseName+' - '+tblBranch.BranchName+' - '+tblClass.ClassName as class," +
                    "tblFeesCategory.FeesCategoryName as Category," +
                  " case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId " +
                  " where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" + ddlAcademicYearId.SelectedValue + ")> 0 then '' else 'Add fees' end as Status" +
                  " FROM tblAdmissionDetails A "+
                  " INNER JOIN tblCourse on tblCourse.CourseId=A.CourseId" +
                  " INNER JOIN tblClass on tblClass.ClassId=A.ClassId" +
                  " INNER JOIN TblBranch on TblBranch.BranchId=A.BranchId" +
                  " INNER JOIN tblFeesCategory on tblFeesCategory.FeesCategoryId=A.FeesCategory" +
                  " where A.OrgId='" + orgID.ToString() + "' and   A.Status='" + "Pending" + "' and ";
                //-------------------------------------------------------------------------------------------------------------------------------//

              if (ddl_Course.Text != "Select")
             {
                if (flag != 0)
                {
                    qury += "and ";
                }
                qury += "(A.CourseId='" + ddl_Course.SelectedValue.ToString() + "')";
                flag++;
            }
            if (ddl_Branch.Text != "Select")
            {
                if (flag != 0)
                {
                    qury += "and";
                }
                qury += "(A.BranchId ='"+ddl_Branch.SelectedValue.ToString()+"')";
                flag++;
            }
            if (ddl_Class.Text != "Select")
            {
                if(flag!=0)
                {
                    qury += "and";
                }
                qury += "(A.ClassId = '"+ddl_Class.SelectedValue.ToString()+"')";
                flag++;
            }
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    if (flag != 0)
                    {
                        qury += "and";
                    }
                    // ApplicationDate BETWEEN convert(varchar(10),(CONVERT(Date, @FromDate,103)),121) AND CONVERT(varchar(10), (CONVERT(date, @ToDate, 103)),121)
                    qury += "( A.ApplicationDate BETWEEN (CONVERT(Date, '" + txtFromDate.Text + "',103)) AND  CONVERT(varchar(10), (CONVERT(date, '" + txtToDate.Text + "',103)),121))";
                    flag++;
                }
                else if (txtFromDate.Text != "" )
                {
                    if (flag != 0)
                    {
                        qury += "and";
                    }
                    // ApplicationDate BETWEEN convert(varchar(10),(CONVERT(Date, @FromDate,103)),121) AND CONVERT(varchar(10), (CONVERT(date, @ToDate, 103)),121)
                    qury += "( A.ApplicationDate >= (CONVERT(Date, '" + txtFromDate.Text + "',103)))";
                    flag++;
                }
                else if ( txtToDate.Text != "")
                {
                    if (flag != 0)
                    {
                        qury += "and";
                    }
                    // ApplicationDate BETWEEN convert(varchar(10),(CONVERT(Date, @FromDate,103)),121) AND CONVERT(varchar(10), (CONVERT(date, @ToDate, 103)),121)
                    qury += "( A.ApplicationDate <= CONVERT(varchar(10), (CONVERT(date, '" + txtToDate.Text + "',103)),121))";
                    flag++;
                }


                if (flag == 0)
                {
                    //Commented And Added By Ashwini 7-Oct-2020-------------------------------------------------------------------------------//

                    // qury=  "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.EMail, " +
                    //"case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId " +
                    //" where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" +
                    //" "+ ddlAcademicYearId.SelectedValue + ")> 0 then '' else 'Add fees' end as Status" +
                    //" FROM tblAdmissionDetails A where A.OrgId='" + orgID.ToString() + "' and   A.Status='" + "Pending" + "'";

                     qury = "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.Mobile," +
                    "(tblCourse.CourseName+' - '+tblBranch.BranchName+' - '+tblClass.ClassName) as Class," +
                    "tblFeesCategory.FeesCategoryName as Category," +
                  "case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId " +
                  " where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" + ddlAcademicYearId.SelectedValue + ")> 0 then '' else 'Add fees' end as Status" +
                  " FROM tblAdmissionDetails A " +
                  " INNER JOIN tblCourse on tblCourse.CourseId=A.CourseId" +
                  " INNER JOIN tblClass on tblClass.ClassId=A.ClassId" +
                  " INNER JOIN TblBranch on TblBranch.BranchId=A.BranchId" +
                  " INNER JOIN tblFeesCategory on tblFeesCategory.FeesCategoryId=A.FeesCategory" +
                  " where A.OrgId='" + orgID.ToString() + "' and   A.Status='" + "Pending" + "' ";

                    //------------------------------------------------------------------------------------------------------------------//
                    //grdPendingAdmission.DataSource = db.Displaygrid("SELECT AdmissionID,AdmissionType,FirstName +' '+ MiddleName + ' '+ LastName as StudentName,EMail FROM tblAdmissionDetails where OrgId='" + orgID.ToString() + "' and Status='" + "Pending" + "' ");
                }
                
                    grdPendingAdmission.DataSource = db.Displaygrid(qury);

                


                //grdPendingAdmission.DataSourceID = db.Displaygrid(qury).ToString();
                grdPendingAdmission.DataBind();

                //serial_no();

            }
            catch (Exception ex)
            {
            }
        }


        //Approve Event
        #region[Approve Event]

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                string strAction = "UpdateAdmissionStatus";
                int i = 0;
                int count = grdPendingAdmission.Rows.Count;
                string[] AdmissionID = new string[count];
                string[] EmailID = new string[count];
                string[] StudentName = new string[count];

                foreach (GridViewRow gvrow in grdPendingAdmission.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                    if (chk != null && chk.Checked)
                    {
               //---------Commented and Added by Ashwini 8-oct-2020----------------------------------------------------------------------
                        //AdmissionID[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[0].Text;
                        //StudentName[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[1].Text;
                        //EmailID[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[2].Text;


                        AdmissionID[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[1].Text;
                        StudentName[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[2].Text;
                        EmailID[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[6].Text;
            //--------------------------------------------------------------------------------------------------------------------------

                        //grdPendingAdmission.DataKeys[gvrow.RowIndex].Values["AdmissionID"].ToString();
                        //grdPendingAdmission.DataKeys[gvrow.RowIndex].Values["EMail"].ToString();
                        UpdateAdmissionDetails(AdmissionID[i], StudentName[i], EmailID[i], strAction, "Admission Completed","Completed");
                        i++;
                    }
                }
                //BindGridviewData(orgID,"Completed");
                directSearch();
                //msgBox.ShowMessage("Admission Confirmed Successfully !!!", "Save", UserControls.MessageBox.MessageStyle.Successfull);


                //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Update Addmission Details
        #region[Update Admission Details]

        private void UpdateAdmissionDetails(string AdmissionID, string StudentName, string EMail, string strAction, string Status,string ShwoMessage)
        {
            try
            {
                objEWA.TransationAction = strAction.ToString();

                objEWA.OrgID = Convert.ToInt32(Session["OrgId"]);
                objEWA.AdmissionID = AdmissionID;
                objEWA.E_Mail = EMail;
                objEWA.Status = Status;
                objEWA.AcademicYearID = ddlAcademicYearId.SelectedValue;
                int flag = objBAL.UpdateAdmissionStatus(objEWA);

                if (flag > 0)
                {
                    if (strAction == "UpdateAdmissionStatus")
                    {
                        
                        string strSMS = null;
                        string strEmail = null;
                        msgBox.ShowMessage("Admission " + ShwoMessage + " Successfully !!!", "Information", UserControls.MessageBox.MessageStyle.Successfull);
                        //strEmail = SendEmails(StudentName, EMail,Status);

                        //Response.Redirect("~/College_Home.aspx");
                    }
                }
                else if(flag==0)
                {
                    msgBox.ShowMessage("Add fees For this Fees Category !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
                else
                    msgBox.ShowMessage("Admission Canceled !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
            }
            catch (Exception exp)
            {
                Response.Redirect("~/CMSHome.aspx");
                // GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        // Send EMail

        #region SendeMailRegion

        private string SendEmails(string StudentName, string Email,string Status)
        {
            try
            {
                string stringResult = null;
                string mailFrom = Convert.ToString("schoolerp999@gmail.com");   //your own correct Gmail Address
                string password = Convert.ToString("logicpro@2017");
                //string mailTo = Convert.ToString("demo.demo@deiontech.com");       //Email Address to whom you want to send the mail

                string mailTo = Convert.ToString(Email);

                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                email.To.Add(new System.Net.Mail.MailAddress(mailTo));
                email.From = new System.Net.Mail.MailAddress(mailFrom, "LogicPro Solutions College ERP", System.Text.Encoding.UTF8);

                if (Status == "Pending for pay fees")
                    email.Subject = "Admission Confirmation ";  
                else
                    email.Subject = "Admission Cancel ";
                
                email.SubjectEncoding = System.Text.Encoding.UTF8;

                if (Status == "Pending for pay fees")
                    email.Body = "Dear " + StudentName + "\n Your Admission Confirm Successfully !!\nPlease Pay your Fees In Next Working 5 Days ,\nThank You For Registraion !!";
                else
                    email.Body = "Dear " + StudentName + " Your Admission Cancelled !!!\n Thank You For Registraion !!";
                
                email.BodyEncoding = System.Text.Encoding.UTF8;
                email.Priority = System.Net.Mail.MailPriority.High;

                System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);//Add the Creddentials- use your own email id and password
                Smtp.Port = 587;   // Gmail works on this port
                Smtp.Host = "smtp.gmail.com";
                Smtp.EnableSsl = true;     //Gmail works on Server Secured Layer
                try
                {
                    Smtp.Send(email);
                    stringResult = "Email has been sent successfully...";
                }
                catch (Exception ex)
                {
                    stringResult = ex.Message;
                }
                finally
                {
                    // Response.Redirect("~/CMSHome.aspx");
                }
                return stringResult;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return null;
            }
        }

        #endregion SendeMailRegion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void BtnDeny_Click(object sender, EventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    string strAction = "UpdateAdmissionStatus";
                    int i = 0;
                    int count = grdPendingAdmission.Rows.Count;
                    string[] AdmissionID = new string[count];
                    string[] EmailID = new string[count];
                    string[] StudentName = new string[count];

                    foreach (GridViewRow gvrow in grdPendingAdmission.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("chkbox");
                        if (chk != null && chk.Checked)
                        {
                            AdmissionID[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[0].Text;
                            StudentName[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[1].Text;
                            EmailID[i] = grdPendingAdmission.Rows[gvrow.RowIndex].Cells[2].Text;
                            //grdPendingAdmission.DataKeys[gvrow.RowIndex].Values["AdmissionID"].ToString();
                            //grdPendingAdmission.DataKeys[gvrow.RowIndex].Values["EMail"].ToString();
                            UpdateAdmissionDetails(AdmissionID[i], StudentName[i], EmailID[i], strAction, "Cancel","Canceled");
                            i++;
                        }
                    }
                    //BindGridviewData(orgID, "Cancel");
                    directSearch();
                    //msgBox.ShowMessage("Admission Cancelled Successfully !!!", "Save", UserControls.MessageBox.MessageStyle.Successfull);
                    //  msgBox.ShowMessage("Admission  Confirm Successfully   !!!", "Save", UserControls.MessageBox.MessageStyle.Successfull);
                }
            }
            catch (Exception exp)
            {
                //GeneralErr(exp.Message.ToString());
            }
        }
        //Added by Ashwini 7-oct-2020
        protected void AddFees_Click(object sender, EventArgs e)
        {
            // string pageurl = "AddFees.aspx";
            // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('AddFees.aspx','_newtab');", true);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('AddFees.aspx' ,'_blank');", true);
            // Response.Redirect("AddFees.aspx");
        }
    }
}
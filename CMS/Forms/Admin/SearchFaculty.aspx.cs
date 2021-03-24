using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using System.Web;
using System.Web.UI;


//Add this Namespaces
using EntityWebApp;
using EntityWebApp.Admin;

//Search Faculty
namespace CMS.Forms.Admin
{
    public partial class SearchFaculty1 : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BindControl ObjHelper = new BindControl();
        private DataSet ds = new DataSet();

        public static int orgID;
        private BL_StaffView objBL = new BL_StaffView();
        private EWA_StaffView objEWA = new EWA_StaffView();
        #endregion

        //Page Load
        #region[Page Load]

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
                    objEWA.OrgId = orgID;

                    GetDepartment();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Dept
        #region Bind  Department

        private void GetDepartment()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = new DataSet();
                ds = objBL.BindDepartment_BL(objEWA);

                ddlDepartment.DataSource = ds.Tables[0];
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Designation
        #region Designation

        private void GetDesignation()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.DepartmentId = ddlDepartment.SelectedValue;

                DataSet ds = new DataSet();
                ds = objBL.BindDesignation_BL(objEWA);
                ddlDesignation.DataSource = ds;
                ddlDesignation.DataTextField = "DesignationName";

                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Department
        #region[Department]

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetDesignation();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Go Button
        #region[Go Button]

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //  BindFacultyGrid();
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
           select_qry();
        }

        #endregion

        void select_qry()
        {
            try
            {
                database db=new database();
                int flag = 0;
                // string qry = "SELECT   PaymentMaster.date as Date, PaymentDetails.paidBills as [Bill No], PaymentMaster.supplierName as [Supplier Name], PaymentMaster.grandTotal as [Grand Total], PaymentMaster.paidAmt as [Paid Amount], PaymentMaster.dueAmt as [Balance Amount],PaymentDetails.paymentType as [Payment Mode], PaymentDetails.bankName as [Bank Name], PaymentDetails.chequeNo as [Cheque No], PaymentDetails.chequeDate as [Cheque Date], PaymentDetails.chequeStatus as [Cheque Status] FROM            PaymentDetails INNER JOIN  PaymentMaster ON PaymentDetails.billNo = PaymentMaster.billNo AND PaymentDetails.voucherNo = PaymentMaster.voucherNo where PaymentMaster.paidAmt<>0 and  ";
                string qry = "    SELECT        tblEmpAssignDeptDes.UserCode, tblEmployee.FirstName + ' ' + tblEmployee.LastName AS FullName, tblDepartment.DepartmentName,    tblDesignation.DesignationName,tblEmployee.IsActive FROM            tblEmpAssignDeptDes INNER JOIN  tblEmployee ON tblEmpAssignDeptDes.OrgId = tblEmployee.OrgId AND tblEmpAssignDeptDes.UserCode = tblEmployee.UserCode INNER JOIN  tblDepartment ON tblEmpAssignDeptDes.DepartmentId = tblDepartment.DepartmentId INNER JOIN  tblDesignation ON tblEmpAssignDeptDes.DesignationId = tblDesignation.DesignationId where  tblEmployee.OrgId='" + orgID.ToString() + "' and ";
                if (ddlDepartment.Text != "Select")
                {
                    if (flag != 0)
                    {
                        qry += "and ";
                    }
                    qry += " (   tblEmpAssignDeptDes.DepartmentId='" + ddlDepartment.SelectedValue.ToString() + "') ";
                    flag++;
                }

                if (ddlDesignation.Text != "Select")
                {
                    if (flag != 0)
                    {
                        qry += "and ";
                    }
                    qry += "  tblEmpAssignDeptDes.DesignationId='" + ddlDesignation.SelectedValue.ToString() + "'";
                    flag++;
                }

                DataTable dt = new DataTable(); 
                if (flag == 0)
                    dt = db.Displaygrid("   SELECT        tblEmpAssignDeptDes.UserCode, tblEmployee.FirstName + ' ' + tblEmployee.LastName AS FullName, tblDepartment.DepartmentName,    tblDesignation.DesignationName,tblEmployee.IsActive FROM            tblEmpAssignDeptDes INNER JOIN  tblEmployee ON tblEmpAssignDeptDes.OrgId = tblEmployee.OrgId AND tblEmpAssignDeptDes.UserCode = tblEmployee.UserCode INNER JOIN  tblDepartment ON tblEmpAssignDeptDes.DepartmentId = tblDepartment.DepartmentId INNER JOIN  tblDesignation ON tblEmpAssignDeptDes.DesignationId = tblDesignation.DesignationId where  tblEmployee.OrgId='" + orgID.ToString() + "'");
                
                else
                {
                    dt = db.Displaygrid(qry);
                }


                //   grdSearchFaculty.DataSourceID = db.Displaygrid(qry).ToString();
                if (dt.Rows.Count > 0)
                {
                    grd.Columns[4].Visible = true;

                    grd.DataSource = dt;
                    grd.DataBind();

                    grd.Columns[4].Visible = false;
                }
                else
                {
                    grd.DataSource = dt;
                    grd.DataBind();
                    GeneralErr("Record Not Found...!");
                    //Response.Write("<script>alert('Record Not Found...!')</script>");
                }

                //serial_no();

            }
            catch (Exception ex)
            {
            }
        }

        #region ViewLinkButtonClick

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    //ViewState["StudentUserCode"]
                    Session["EmpUserCode"] = grd.DataKeys[grdrow.RowIndex].Values["UserCode"].ToString();

                    //Response.Write("<script>javascript:window.open('AdminViewStudentProfile.aspx','_blank');</script>");
                    Response.Redirect("AdminViewFacultyProfile.aspx");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                // throw;
            }
        }

        #endregion


        #region DeleteLinkButtonClick

        protected void lnkBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    //ViewState["StudentUserCode"]
                    //Session["EmpUserCode1"] = grd.DataKeys[grdrow.RowIndex].Values["UserCode"].ToString();

                    EWA_StaffView objEWA = new EWA_StaffView();
                    BL_StaffView objBAL = new BL_StaffView();
                    string msgact = "";
                    objEWA.Action = "DeleteProfile";
                    objEWA.StaffID = Convert.ToInt32(grd.DataKeys[grdrow.RowIndex].Values["UserCode"].ToString());
                    objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                    if(Convert.ToBoolean(grd.DataKeys[grdrow.RowIndex].Values["IsActive"].ToString()))
                    {
                        objEWA.IsActive = 0;
                        msgact = "Deactivate";
                    }
                    else
                    {
                        objEWA.IsActive = 1;
                        msgact = "activate";
                    }
                    

                    int result = objBAL.DeleteFaculty_BL(objEWA);

                    if (result > 0)
                    {
                        msgBox.ShowMessage("Faculty is "+ msgact +"..! ", "Successfull", UserControls.MessageBox.MessageStyle.Successfull);
                        select_qry();
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                // throw;
            }
        }

        #endregion


        //Bind Faculty grid
        #region[Bind Faculty Grid]

        private void BindFacultyGrid()
        {
            try
            {
                EWA_StaffView objEWA = new EWA_StaffView();
                BL_StaffView objBAL = new BL_StaffView();

                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);

                objEWA.DepartmentId = ddlDepartment.SelectedValue;
                objEWA.Designation = ddlDesignation.SelectedValue;

                DataSet ds = new DataSet();

                ds = objBAL.FacultyView_BL(objEWA);

                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    grdSearchFaculty.DataSource = ds;
                    grdSearchFaculty.DataBind();
                    int columncount = grdSearchFaculty.Rows[0].Cells.Count;
                    grdSearchFaculty.Rows[0].Cells.Clear();
                    grdSearchFaculty.Rows[0].Cells.Add(new TableCell());
                    grdSearchFaculty.Rows[0].Cells[0].ColumnSpan = columncount;
                    grdSearchFaculty.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    grdSearchFaculty.DataSource = ds.Tables[0];
                    grdSearchFaculty.DataBind();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Facluty Index Changed
        #region[Faculty Index Changed]

        protected void grdSearchFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow grdrow = btn.NamingContainer as GridViewRow;
                long EmpCode = Convert.ToInt64(grdSearchFaculty.DataKeys[grdrow.RowIndex].Values[0].ToString());

                Session["EmpCode"] = EmpCode;
                int OrgID = Convert.ToInt32(Session["OrgId"]);


                Response.Redirect("~/ViewFacultyProfile.aspx");

                //ShowSearchFaculty(OrgID, EmpCode);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //View Event
        #region[View event]

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow grdrow = btn.NamingContainer as GridViewRow;
                long EmpCode = Convert.ToInt64(grdSearchFaculty.DataKeys[grdrow.RowIndex].Values[0].ToString());

                Session["UserCode"] = EmpCode;
                int OrgID = Convert.ToInt32(Session["OrgId"]);

                btn.Attributes.Add("onclick", "popWin()");
                // Response.Redirect("~/ViewFacultyProfile.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Commented
        #region[Commented]
        //private void ShowSearchFaculty(int OrgID, long EmpCode)
        //{
        //    try
        //    {
        //        DataSet ds;

        //            objEWA.OrgId = OrgID;
        //            objEWA.StaffID = EmpCode;

        //            ds = objBL.BL_ViewFacultyData(objEWA);

        //            Response.Redirect("~/ViewFacultyProfile.aspx");

        //            string strFirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
        //            string strMiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
        //            string strLastName = ds.Tables[0].Rows[0]["LastName"].ToString();

        //            concatinate the FullName
        //            string strFullName = strFirstName + ' ' + strMiddleName + ' ' + strLastName;
        //            lblStaffName.Text = strFullName;

        //            lblEmpCode.Text = ds.Tables[0].Rows[0]["UserCode"].ToString();
        //            lblDepartment.Text = ddlDepartment.SelectedItem.ToString();
        //            lblDesignation.Text = ddlDesignation.SelectedItem.ToString();

        //            lblMotherName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
        //            lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();

        //            string DateOfBirth = ds.Tables[0].Rows[0]["DOB"].ToString();

        //            DateTime DOB = Convert.ToDateTime(DateOfBirth);

        //            lblDBO.Text = DOB.ToShortDateString();

        //            lblBloodGroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
        //            lblMaritalStatus.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

        //            for Faculty photo
        //            string Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString();

        //            if (Photo1 != null && Photo1 != "")
        //            {
        //                Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

        //                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //                imgStaff.ImageUrl = "data:image/png;base64," + base64String;

        //            }
        //            Conatact Information
        //            lblPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
        //            lblPresentCountry.Text = ds.Tables[0].Rows[0]["PresentCountry"].ToString();
        //            lblPresentState.Text = ds.Tables[0].Rows[0]["PresentState"].ToString();
        //            lblPresentCity.Text = ds.Tables[0].Rows[0]["PresentCity"].ToString();
        //            lblPresentPinCode.Text = ds.Tables[0].Rows[0]["PresentPinCode"].ToString();
        //            lblPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
        //            lblPermanentCountry.Text = ds.Tables[0].Rows[0]["PermanentCountry"].ToString();
        //            lblPermanentState.Text = ds.Tables[0].Rows[0]["PermanentState"].ToString();
        //            lblPermanentCity.Text = ds.Tables[0].Rows[0]["PermanentCity"].ToString();
        //            lblPermanentPinCode.Text = ds.Tables[0].Rows[0]["PermanentPinCode"].ToString();
        //            lblPhoneNumber.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
        //            lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
        //            lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
        //            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        //            lblCasteCategory.Text = ds.Tables[0].Rows[0]["CasteCategory"].ToString();
        //            lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
        //            lblWebsiteBlog.Text = ds.Tables[0].Rows[0]["WebsiteBlog"].ToString();
        //            lblPanCardNo.Text = ds.Tables[0].Rows[0]["PanCardNo"].ToString();
        //            lblDateOfJoining.Text = ds.Tables[0].Rows[0]["DateOfJoining"].ToString();

        //            Education Qualification
        //            lblUGDegree.Text = ds.Tables[0].Rows[0]["UGDegree"].ToString();
        //            lblPGDegree.Text = ds.Tables[0].Rows[0]["PGDegree"].ToString();
        //            lblDoctorateDegree.Text = ds.Tables[0].Rows[0]["DoctorateDegree"].ToString();
        //            lblOtherQualification.Text = ds.Tables[0].Rows[0]["OtherQualification"].ToString();
        //            lblSpecialization.Text = ds.Tables[0].Rows[0]["Specialization"].ToString();
        //            lblTeachingExperience.Text = ds.Tables[0].Rows[0]["TeachingExperience"].ToString();
        //            lblIndustrialExperience.Text = ds.Tables[0].Rows[0]["IndustrialExperience"].ToString();
        //            lblResearchExperience.Text = ds.Tables[0].Rows[0]["ResearchExperience"].ToString();
        //            lblNationalPublication.Text = ds.Tables[0].Rows[0]["NationalPublication"].ToString();
        //            lblInternationalPublication.Text = ds.Tables[0].Rows[0]["InternationalPublication"].ToString();
        //            lblBookPublished.Text = ds.Tables[0].Rows[0]["BookPublished"].ToString();
        //            lblPatents.Text = ds.Tables[0].Rows[0]["Patents"].ToString();

        //            Other Information
        //            lblPFNumber.Text = ds.Tables[0].Rows[0]["PFNumber"].ToString();
        //            lblBankAccountNumber.Text = ds.Tables[0].Rows[0]["BankAccountNumber"].ToString();
        //            lblBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
        //            lblBankBranchName.Text = ds.Tables[0].Rows[0]["BankBranchName"].ToString();
        //            lblBankIFSCCode.Text = ds.Tables[0].Rows[0]["BankIFSCCode"].ToString();

        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }

        //}
        #endregion

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Designation Index Changed
        #region[Designation Index Changed]

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ds.Tables[0].Rows.Count == 0 || ds == null)
            //{
            //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //    grdSearchFaculty.DataSource = ds;
            //    grdSearchFaculty.DataBind();
            //    int columncount = grdSearchFaculty.Rows[0].Cells.Count;
            //    grdSearchFaculty.Rows[0].Cells.Clear();
            //    grdSearchFaculty.Rows[0].Cells.Add(new TableCell());
            //    grdSearchFaculty.Rows[0].Cells[0].ColumnSpan = columncount;
            //    grdSearchFaculty.Rows[0].Cells[0].Text = "No Records Found";
            //}
        }

        #endregion

        protected void grdSearchFaculty_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow grdrow = btn.NamingContainer as GridViewRow;
                long EmpCode = Convert.ToInt64(grdSearchFaculty.DataKeys[grdrow.RowIndex].Values[0].ToString());

                Session["UserCode"] = EmpCode;
                int OrgID = Convert.ToInt32(Session["OrgId"]);

                btn.Attributes.Add("onclick", "popWin()");
                // Response.Redirect("~/ViewFacultyProfile.aspx");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow grdrow = btn.NamingContainer as GridViewRow;
                long EmpCode = Convert.ToInt64(grdSearchFaculty.DataKeys[grdrow.RowIndex].Values[0].ToString());

                Session["UserCode"] = EmpCode;
                int OrgID = Convert.ToInt32(Session["OrgId"]);

                btn.Attributes.Add("onclick", "popWin()");
              // Response.Redirect(@"~/ViewFacultyProfile.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "openWindow(); window.location.href='" + Request.ApplicationPath + "?waiterNm=" + EmpCode + "';", true);
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton linkbnt = (LinkButton)e.Row.FindControl("lnkBtnDelete");

                    if (e.Row.Cells[5].Text == "True")
                    {
                        linkbnt.Text = "Deactivate";
                    }
                    else
                    {
                        linkbnt.Text = "Activate";
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        
    }
}
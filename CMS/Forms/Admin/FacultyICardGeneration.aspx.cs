using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//For Barcode
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
//Add this Namespaces
using EntityWebApp;
using EntityWebApp.Admin;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using System.Data;

namespace CMS.Forms.Admin
{
    public partial class FacultyICardGeneration : System.Web.UI.Page
    {
        BindControl ObjHelper = new BindControl();
        DataSet ds = new DataSet();

        public static string OrgId;
        BL_StaffView objBAL = new BL_StaffView();
        EWA_StaffView objEWA = new EWA_StaffView();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    OrgId = Convert.ToString(Session["OrgId"]);

                    if (OrgId == "")
                    {
                        Response.Redirect("~/CMSHome.aspx");

                    }

                    if (!IsPostBack)
                    {

                        objEWA.OrgId = Convert.ToInt32(OrgId);
                        GetDepartment();

                    }
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #region Bind Department
        private void GetDepartment()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = (OrgId.ToString());
              //  objEWA.OrgId = "1";
                //objEWA.OrgId = Session["OrgId"].ToString();
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

        #region Bind Designation
        private void GetDesignation()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();

                objEWA.DepartmentId = ddlDepartment.SelectedValue;

                DataSet ds = new DataSet();
                ds = objBL.BindDesignation_BL(objEWA);

                ddlDesignation.DataSource = ds.Tables[0];
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

        #region Call to Designation method
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

        #region Go Button
        protected void btnGo_Click(object sender, EventArgs e)
        {

            Panel3.Visible = true;
            BL_StaffView objBAL = new BL_StaffView();
            EWA_StaffView objEWA = new EWA_StaffView();
            try
            {
                objEWA.Designation = ddlDesignation.SelectedValue;
                objEWA.DepartmentId = ddlDepartment.SelectedValue;
                objEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = new DataSet();

                ds = objBAL.BL_GetFacultyIcardData(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdIcard.DataSource = ds.Tables[0];
                    grdIcard.DataBind();
                    btnPrintLoad.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    //dt.Columns.Add("UserCode");
                    //dt.Columns.Add("FullName");
                    //dt.Rows.Add();
                    //dt.Rows.Add();
                    grdIcard.DataSource = dt;
                    grdIcard.DataBind();
                    btnPrintLoad.Visible = false;
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
            
        }
        #endregion
        
        //General Message
        #region[General Message]
        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }
        #endregion

        protected void btnPrintLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                dt.Columns.Add("imgClgLogo");
                dt.Columns.Add("CollageFullName");
                dt.Columns.Add("Faculty");
                dt.Columns.Add("Name");
                dt.Columns.Add("FacultyId");
                dt.Columns.Add("DOB");
                dt.Columns.Add("bloodGroup");
                dt.Columns.Add("Designation");
                dt.Columns.Add("MobileNo");
                dt.Columns.Add("Email");
                dt.Columns.Add("CurrentAddress");
                dt.Columns.Add("Sign");
                
                dt1.Columns.Add("imgClgLogo");
                dt1.Columns.Add("CollageFullName");
                dt1.Columns.Add("Faculty");
                dt1.Columns.Add("Name");
                dt1.Columns.Add("FacultyId");
                dt1.Columns.Add("DOB");
                dt1.Columns.Add("bloodGroup");
                dt1.Columns.Add("Designation");
                dt1.Columns.Add("MobileNo");
                dt1.Columns.Add("Email");
                dt1.Columns.Add("CurrentAddress");
                dt1.Columns.Add("Sign");
                
                dt2.Columns.Add("imgClgLogo");
                dt2.Columns.Add("CollageFullName");
                dt2.Columns.Add("Faculty");
                dt2.Columns.Add("Name");
                dt2.Columns.Add("FacultyId");
                dt2.Columns.Add("DOB");
                dt2.Columns.Add("bloodGroup");
                dt2.Columns.Add("Designation");
                dt2.Columns.Add("MobileNo");
                dt2.Columns.Add("Email");
                dt2.Columns.Add("CurrentAddress");
                dt2.Columns.Add("Sign");
                
                int flag = 0, i = 1;
                foreach (GridViewRow gvrow in grdIcard.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");


                    if (chk != null && chk.Checked)
                    {
                        DataRow dr;

                        if (i % 3 == 0)
                        {
                            dr = dt2.NewRow();
                        }
                        else if (i % 2 != 0)
                        {
                            dr = dt.NewRow();
                        }
                        else
                        {
                            dr = dt1.NewRow();
                        }

                        flag = 1;
                        objEWA.OrgId = Convert.ToInt32(Session["OrgId"]); ;
                        objEWA.EmpCode = grdIcard.DataKeys[gvrow.RowIndex].Values["UserCode"].ToString();
                        ds = objBAL.FacultyIcard_BL(objEWA);

                        string strFirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        string strMiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                        string strLastName = ds.Tables[0].Rows[0]["LastName"].ToString();

                        //concatinate the FullName
                        string strFullName = strFirstName + ' ' + strMiddleName + ' ' + strLastName;
                        
                        string DateOfBirth = ds.Tables[0].Rows[0]["DOB"].ToString();
                        DateTime DOB = Convert.ToDateTime(DateOfBirth);

                        //for Collage Logo
                        string Photo = ds.Tables[0].Rows[0]["Logo"].ToString();
                        string ImageUrl1 = null;
                        if (Photo != null && Photo != "")
                        {
                            Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Logo"];

                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            ImageUrl1 = "data:image/png;base64," + base64String;
                        }

                        //for Faculty photo
                        string Photo1 = ds.Tables[0].Rows[0]["Photo"].ToString();
                        string ImageUrl2 = null;
                        if (Photo1 != null && Photo1 != "")
                        {
                            Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["Photo"];

                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            ImageUrl2 = "data:image/png;base64," + base64String;
                        }

                        dr[0] = ImageUrl1;
                        dr[1] = ds.Tables[0].Rows[0]["OrgName"].ToString();
                        dr[2] = ImageUrl2;
                        dr[3] = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["MiddleName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
                        dr[4] = ds.Tables[0].Rows[0]["UserCode"].ToString();
                        dr[5] = DOB.ToString("dd-MMM-yyyy");
                        dr[6] = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                        dr[7] = ddlDesignation.SelectedItem.ToString();
                        dr[8] = ds.Tables[0].Rows[0]["Mobile"].ToString();
                        dr[9] = ds.Tables[0].Rows[0]["Email1"].ToString();
                        dr[10] = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                        dr[11] = "../../Sign/" + objEWA.OrgId + ".png";

                        if (i % 3 == 0)
                        {
                            dt2.Rows.Add(dr);
                        }
                        else if (i % 2 != 0)
                        {
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dt1.Rows.Add(dr);
                        }

                        i++;
                    }
                }

                if (flag > 0)
                {
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();

                    Repeater2.DataSource = dt1;
                    Repeater2.DataBind();

                    Repeater3.DataSource = dt2;
                    Repeater3.DataBind();

                    btnPrint.Visible = true;
                    pnlContents.Visible = true;
                }
                else
                {
                    Repeater1.DataSource = null;
                    Repeater1.DataBind();

                    Repeater2.DataSource = null;
                    Repeater2.DataBind();

                    Repeater3.DataSource = null;
                    Repeater3.DataBind();

                    btnPrint.Visible = false;
                    pnlContents.Visible = false;

                    msgBox.ShowMessage("Atlist One Faculty select..!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

    }
}
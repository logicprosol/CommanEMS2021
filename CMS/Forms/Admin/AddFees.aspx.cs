using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Data.SqlClient;
using System.Configuration;

//Add Fee
namespace CMS.Forms.Admin
{
    public partial class AddFees : System.Web.UI.Page
    {
        //Objects

        #region[Objects]
        private string feesId;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        #endregion

        //Page Load
        #region[Page Load]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
                if (!IsPostBack)
                {
                    EWA_Common ObjEWA = new EWA_Common();
                    BL_Common ObjBL = new BL_Common();
                    //Session OrgId;
                    ObjEWA.OrgId = Session["OrgId"].ToString();

                    DataSet ds = ObjBL.BindCourses_BL(ObjEWA);
                  //  ObjEWA.CourseId = ObjEWA.CourseId;
                    ddlCourse.DataSource = ds;
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataValueField = "CourseId";
                    ddlCourse.DataBind();
                    ddlCourse.Items.Insert(0, new ListItem("Select", "Select"));

                    //Session OrgId;
                    ObjEWA.OrgId = Session["OrgId"].ToString();


                    //DataSet ds1 = ObjBL.BindCasteCategory_BL(ObjEWA);
                    Bind_ddlFeesCategory();
                    //cn.Open();
                    //SqlCommand cmd1 = new SqlCommand("SELECT CourseId,CourseName FROM tblCourse WHERE OrgId='" + ddlCourse.SelectedValue + "'", cn);
                    //SqlDataReader dr1 = cmd1.ExecuteReader();
                    //ddlCourse.DataSource = dr1;
                    //ddlCourse.Items.Clear();

                    //ddlCourse.DataTextField = "CourseName";
                    //ddlCourse.DataValueField = "CourseId";
                    //ddlCourse.DataBind();
                    //cn.Close();

                    //ddlCourse.Items.Insert(0, new ListItem("--Please Select Course--", "0"));





                    // cn.Open();
                    // SqlCommand cmd = new SqlCommand("SELECT CasteCategoryId,CasteCategoryName FROM tblCasteCategory where OrgId='" + orgId.ToString() + "'", cn);
                    // SqlDataReader dr = cmd.ExecuteReader();
                    // ddlCastCategory.DataSource = dr;
                    //// ddlCastCategory.DataSource = ds1;
                    // ddlCastCategory.DataTextField = "CasteCategoryName";
                    // ddlCastCategory.DataValueField = "CasteCategoryId";
                    // ddlCastCategory.DataBind();
                    // ddlCastCategory.Items.Insert(0, "Select");
                    // dr.Close();



                    BindGridView("Empty");
                    lblresult.Text = "";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Index Changed
        #region[Course Index Changed]

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBranch();
                BindEmptyDataTable();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Branch
        #region[Bind Branch]

        protected void BindBranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                if (!objEWA.CourseId.Equals("Select"))
                {
                    DataSet ds = objDL.BindBranch_DL(objEWA);

                    ddlBranch.DataSource = ds;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, "Select");
                }
                else
                {
                    ddlBranch.Items.Clear();
                    ddlBranch.Items.Insert(0, "Select");
                }
                BindClass();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Class Index Changed
        #region[Class Index Changed]

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ddlClass.SelectedItem.Text.Equals("Select"))
                {
                    BindAcademicYear();
                    ddlCastCategory.SelectedIndex = 0;


                }
                else
                {
                    
                    
                    BindEmptyDataTable();
                    ddlCastCategory.SelectedIndex = 0;
                }
               
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Academic Year
        #region[Bind Academic Year]

        protected void BindAcademicYear()
        {
            try
            {
                EWA_AcademicYear ObjEWA = new EWA_AcademicYear();
                BL_Fees ObjBL = new BL_Fees();

                ObjEWA.OrgId = Convert.ToInt32(Session["OrgId"]);
                DataSet ds = ObjBL.BindAcademicYear_BL(ObjEWA);
                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "AcademicYear";
                ddlAcademicYear.DataValueField = "AcademicYearId";
                ddlAcademicYear.DataBind();
                ddlAcademicYear.Items.Insert(0, new ListItem("Select", "0"));
                BindEmptyDataTable();

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        public void Bind_ddlFeesCategory()
        {
            cn.Close();
            cn.Open();
            // SqlCommand cmd = new SqlCommand("select FeesCategoryName,FeesCategoryId from tblFeesCategory where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' And AcademicYearId = '" + ddlAcademicYear.SelectedValue + "' ", cn);
            SqlCommand cmd = new SqlCommand("select FeesCategoryName,FeesCategoryId from tblFeesCategory where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' ", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlCastCategory.DataSource = dr;
            ddlCastCategory.Items.Clear();

            ddlCastCategory.DataTextField = "FeesCategoryName";
            ddlCastCategory.DataValueField = "FeesCategoryId";
            ddlCastCategory.DataBind();
            cn.Close();

            ddlCastCategory.Items.Insert(0, new ListItem("Select", "0"));
        }

        //Caste Category Index Changed
        #region[Caste Category Index Changed]

        protected void ddlCastCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Fees ObjEWA = new EWA_Fees();
                BL_Fees ObjBL = new BL_Fees();
                ObjEWA.OrgId = Session["OrgId"].ToString();
                ObjEWA.CourseId = ddlCourse.SelectedValue;
                ObjEWA.ClassId = ddlClass.SelectedValue;
                ObjEWA.CasteCategoryId = ddlCastCategory.SelectedValue;

                ObjEWA.AcademicYear = ddlAcademicYear.SelectedValue;

                if (!ObjEWA.CasteCategoryId.Equals("Select"))
                {
                    DataSet ds = ObjBL.GetFeesId_BL(ObjEWA);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        feesId = ds.Tables[0].Rows[0]["FeesId"].ToString();
                        ViewState["FeesId"] = feesId;
                        ObjEWA.OrgId = Session["OrgId"].ToString();
                        BindGridView(feesId);
                    }
                    else
                    {
                        ObjEWA.OrgId = Session["OrgId"].ToString();
                        ObjEWA.CourseId = ddlCourse.SelectedValue;
                        ObjEWA.BranchId = ddlBranch.SelectedValue;
                        ObjEWA.ClassId = ddlClass.SelectedValue;

                        ObjEWA.AcademicYear = ddlAcademicYear.SelectedValue;

                        ObjEWA.CasteCategoryId = ddlCastCategory.SelectedValue;
                        ObjEWA.Action = "Save";
                        ObjBL.AddNewFees_BL(ObjEWA);
                        ds = ObjBL.GetFeesId_BL(ObjEWA);
                        feesId = ds.Tables[0].Rows[0]["FeesId"].ToString();
                        ViewState["FeesId"] = feesId;
                        BindGridView("Empty");
                    }
                }
                else
                {
                    BindEmptyDataTable();
                }
                lblresult.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Grid View
        #region[Bind Grid View]

        private void BindGridView(string feesId)
        {
            try
            {
                EWA_Fees ObjEWA = new EWA_Fees();
                BL_Fees ObjBL = new BL_Fees();

                if (!feesId.Equals("Empty"))
                {
                    ObjEWA.FeesId = feesId;
                    DataSet ds = ObjBL.BindGridView_BL(ObjEWA);

                    if (ds != null)
                    {
                        GrdFees.DataSource = ds;
                        GrdFees.DataBind();
                    }
                    else
                    {
                        BindEmptyDataTable();
                    }
                }
                else
                {
                    BindEmptyDataTable();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Empty Data Table
        #region[Bind Empty Data Table]

        public void BindEmptyDataTable()
        {
            try
            {
                DataTable dtMenu = new DataTable(); //declaringa datatable
                // DataColumn dcMenuID = new DataColumn("SrNo", typeof(System.String));
                // dtMenu.Columns.Add(dcMenuID);// Adding column to the datatable
                DataColumn dcMenuParticular = new DataColumn("Particular", typeof(System.String));

                //creating a column in the same
                //Name of column available in the sql server
                dtMenu.Columns.Add(dcMenuParticular);// Adding column to the datatable
                DataColumn dcMenuAmount = new DataColumn("Amount", typeof(System.String));
                dtMenu.Columns.Add(dcMenuAmount);
                DataColumn dcMenuFeesDetailsId = new DataColumn("FeesDetailsId", typeof(System.Int32));
                dtMenu.Columns.Add(dcMenuFeesDetailsId);
                DataRow datatRow = dtMenu.NewRow();

                //Inserting a new row,datatable .newrow creates a blank row
                dtMenu.Rows.Add(datatRow);//adding row to the datatable

                GrdFees.DataSource = dtMenu;
                GrdFees.DataBind();
                GrdFees.Rows[0].Cells[0].ColumnSpan = GrdFees.Columns.Count;
                GrdFees.Rows[0].Cells[GrdFees.Columns.Count - 1].Visible = false;
                GrdFees.Rows[0].Cells[GrdFees.Columns.Count - 2].Visible = false;
                GrdFees.Rows[0].Cells[GrdFees.Columns.Count - 3].Visible = false;
                GrdFees.Rows[0].Cells[0].Text = "NO PARTICULARS FOUND";
                GrdFees.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                lblresult.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Editing
        #region[Grid Feee Row Edit]

        protected void GrdFees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                lblresult.Text = "";
                if (!ddlCastCategory.SelectedItem.Text.Equals("Select"))
                {
                    GrdFees.EditIndex = e.NewEditIndex;
                    feesId = ViewState["FeesId"].ToString();
                    Label lblParticular = (Label)GrdFees.Rows[e.NewEditIndex].FindControl("lblPerticular");
                    Label lblAmount = (Label)GrdFees.Rows[e.NewEditIndex].FindControl("lblAmount");
                    ViewState["OldParticular"] = lblParticular.Text;
                    ViewState["OldAmount"] = lblAmount.Text;
                    BindGridView(feesId);
                }
                else
                    GrdFees.EditIndex = -1;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Command
        #region[Grid Fee Row Command]

        protected void GrdFees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                EWA_Fees ObjEWA = new EWA_Fees();
                BL_Fees ObjBL = new BL_Fees();
                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox txtParticular = (TextBox)GrdFees.FooterRow.FindControl("txtFooterPerticular");
                    TextBox txtAmount = (TextBox)GrdFees.FooterRow.FindControl("txtFooterAmount");

                    ObjEWA.FeesId = ViewState["FeesId"].ToString();
                    ObjEWA.Particular = txtParticular.Text;
                    ObjEWA.Amount = txtAmount.Text;
                    ObjEWA.Action = "Save";
                    ObjBL.AddNewRow_BL(ObjEWA);
                    BindGridView(ObjEWA.FeesId);
                    lblresult.ForeColor = Color.Green;
                    lblresult.Text = ObjEWA.Particular + " Details inserted successfully";

                    //msgBox.ShowMessage("Particular added successfully !!!", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Updating
        #region[Grid Fee Row Updating]

        protected void GrdFees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                EWA_Fees ObjEWA = new EWA_Fees();
                BL_Fees ObjBL = new BL_Fees();
                ObjEWA.Action = "UpdateParticular";
                ObjEWA.FeesId = ViewState["FeesId"].ToString();
                TextBox txtParticular = (TextBox)GrdFees.Rows[e.RowIndex].FindControl("txtPerticular");
                TextBox txtAmount = (TextBox)GrdFees.Rows[e.RowIndex].FindControl("txtAmount");
                string FeesDetailsId = GrdFees.DataKeys[e.RowIndex].Values["FeesDetailsId"].ToString();

                ObjEWA.FeesDetalsId = FeesDetailsId;
                ObjEWA.Particular = txtParticular.Text;
                ObjEWA.Amount = txtAmount.Text;
                ObjEWA.OldParticular = ViewState["OldParticular"].ToString();
                ObjEWA.OldAmount = ViewState["OldAmount"].ToString();
                int result=ObjBL.UpdateParticular_BL(ObjEWA);

                GrdFees.EditIndex = -1;
                BindGridView(ObjEWA.FeesId);

                
                if (result > 0)
                {
                    lblresult.ForeColor = Color.Green;
                    lblresult.Text = ObjEWA.Particular + " Details Updated successfully";
                }
                else
                {
                    lblresult.ForeColor = Color.Red;
                    lblresult.Text = ObjEWA.OldParticular + " Details is in use. Not updated.";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee row deleting
        #region[Grid Fee Row Deleting]

        protected void GrdFees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    EWA_Fees ObjEWA = new EWA_Fees();
                    BL_Fees ObjBL = new BL_Fees();
                    ObjEWA.Action = "DeleteParticular";
                    ObjEWA.FeesId = ViewState["FeesId"].ToString();
                    Label lblParticular = (Label)GrdFees.Rows[e.RowIndex].FindControl("lblPerticular");
                    ObjEWA.Particular = lblParticular.Text;
                    string FeesDetailsId = GrdFees.DataKeys[e.RowIndex].Values["FeesDetailsId"].ToString();
                    ObjEWA.FeesDetalsId = FeesDetailsId;

                    ObjBL.DeleteParticular_BL(ObjEWA);
                    BindGridView(ObjEWA.FeesId);
                    lblresult.ForeColor = Color.Green;
                    lblresult.Text = ObjEWA.Particular + " Details Deleted successfully";
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Clear Controls
        #region[Clear Controls]

        public void ClearControls(string eventControl)
        {
            try
            {
                if (eventControl.Equals("Course"))
                {
                    ddlClass.SelectedValue = "Select";

                    //         txtAcademicYear.Text = "";

                    ddlCastCategory.SelectedValue = "Select";
                }
                if (eventControl.Equals("Class"))
                {
                    ddlCastCategory.SelectedValue = "Select";
                }
                BindEmptyDataTable();
                lblresult.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Grid Fee Row Canceling Edit
        #region[Grid Row Canceling Edit]

        protected void GrdFees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GrdFees.EditIndex = -1;
                BindGridView(ViewState["FeesId"].ToString());
                lblresult.Text = "";
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Index Changed
        #region[Branch Index changed]

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindClass();
                BindEmptyDataTable();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Class
        #region[Bind Class]

        private void BindClass()
        {
            try
            {
                EWA_Common ObjEWA = new EWA_Common();
                BL_Common ObjBL = new BL_Common();

                ObjEWA.BranchId = ddlBranch.SelectedValue.ToString();
                if (!ObjEWA.BranchId.Equals("Select"))
                {
                    DataSet ds = ObjBL.BindClass_BL(ObjEWA);

                    ddlClass.DataSource = ds;
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ClassId";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, "Select");
                }
                else
                {
                    ddlClass.Items.Clear();
                    ddlClass.Items.Insert(0, "Select");
                }
                ddlAcademicYear.SelectedIndex = 0;
                ddlCastCategory.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Clear Controls
        #region[Clear Controls]

        private void ClearControl(DropDownList ddlControl)
        {
            try
            {
                if (ddlControl == ddlCourse)
                {
                    BindBranch();
                    BindClass();
                    BindEmptyDataTable();
                }

                if (ddlControl == ddlBranch)
                {
                    BindClass();
                    BindEmptyDataTable();
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
           // msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        //Academic Year Index Changed
        #region[Academic Year Index Change]

        protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Bind_ddlFeesCategory();
                BindEmptyDataTable();
                ddlCastCategory.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void imgbtnAdd1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("AddInstallment.aspx");
        }

        #endregion

        //#region Gridview row bound event
        //protected void GrdFees_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.Cells[1].Text == "")
        //        e.Row.Visible = false;
        //}
        //#endregion
    }
}
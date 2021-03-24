using BusinessAccessLayer;
using DataAccessLayer;
using EntityWebApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Faculty
{
    public partial class AssignRollNo : System.Web.UI.Page
    {
        public static int orgId = 0;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                if (!IsPostBack)
                {
                    BindCourse();
                    
                    ddlBranches.Items.Insert(0, new ListItem("Select", "0"));
                    ddlClasses.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            catch (Exception exp)
            {

            }
        }
        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourses.DataSource = ds;
                ddlCourses.DataTextField = "CourseName";
                ddlCourses.DataValueField = "CourseId";
                ddlCourses.DataBind();
                ddlCourses.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                
            }
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }
        private void BindBranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourses.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlBranches.DataSource = ds;
                    ddlBranches.DataTextField = "BranchName";
                    ddlBranches.DataValueField = "BranchId";
                    ddlBranches.DataBind();
                }
                else
                    ddlBranches.Items.Clear();
                ddlBranches.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
               
            }
        }
        private void BindClass()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranches.SelectedValue.ToString();
                if (!objEWA.BranchId.Equals("Select"))
                {
                    DataSet ds = objBL.BindClass_BL(objEWA);

                    ddlClasses.DataSource = ds;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ddlClasses.DataTextField = "ClassName";
                        ddlClasses.DataValueField = "ClassId";
                        ddlClasses.DataBind();
                    }
                    else
                        ddlClasses.Items.Clear();
                }
                else
                    ddlClasses.Items.Clear();
                ddlClasses.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                
            }
        }

        protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridBind();
                //grdAttendance.DataSourceID = "sqldataSource2";
                //grdAttendance.DataBind();
            }
            catch { }
        }

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    try {
        //        GridView1.EditIndex = e.NewEditIndex;
        //        string AdmissionID = (string)GridView1.DataKeys[e.NewEditIndex].Values["AdmissionID"].ToString();
        //        GridViewRow row = GridView1.Rows[e.NewEditIndex];


        //        TextBox RollNo = (TextBox)row.FindControl("txtRollNo");
        //        DataSet ds = new DataSet();
        //        using (cn)
        //        {

        //            string query1 = "Select Count(*) From [tbladmissiondetails] WHERE [RollNo] = @RollNo AND OrgId=@OrgId And ClassId=@ClassId";
        //            using (SqlCommand cmd = new SqlCommand(query1, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@RollNo", RollNo.Text);
        //                cmd.Parameters.AddWithValue("@OrgId", orgId);
        //                cmd.Parameters.AddWithValue("@ClassId", ddlClasses.SelectedValue.ToString());

        //                cn.Open();
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //                cn.Close();
        //                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully!')", true);
        //                //Response.Redirect(Request.Url.AbsoluteUri);
        //            }
        //            if (ds.Tables[0].Rows[0][0].ToString() == "0")
        //            {
        //                string query = "UPDATE [tbladmissiondetails] SET [RollNo] = @RollNo WHERE [AdmissionID] = @AdmissionID";
        //                using (SqlCommand cmd = new SqlCommand(query, cn))
        //                {
        //                    cmd.Parameters.AddWithValue("@RollNo", RollNo.Text);
        //                    cmd.Parameters.AddWithValue("@AdmissionID", AdmissionID);

        //                    cn.Open();
        //                    cmd.ExecuteNonQuery();
        //                    cn.Close();
        //                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully!')", true);
        //                    //Response.Redirect(Request.Url.AbsoluteUri);
        //                }
                        
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('RollNo is already exist')", true);
        //            }
                    
        //        }
        //        //SqlDataSource1.Update();
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable DataStudentClassAttendance = new DataTable();
            //    DataStudentClassAttendance.Columns.Add("SAdmissionID");
            //    DataStudentClassAttendance.Columns.Add("SRollNo");
            //    string _AttendanceID, _RollNo;
            //    foreach (GridViewRow gvrow in GridView1.Rows)
            //    {

            //        TextBox RollNo = (TextBox)GridView1.Rows[gvrow.RowIndex].FindControl("txtRollNo");
            //        string AttendanceID = (string)GridView1.DataKeys[gvrow.RowIndex].Values["AdmissionID"].ToString();
            //        //Label AttendanceID = (Label)GridView1.Rows[gvrow.RowIndex].FindControl("LblAdmissionID");

            //        _AttendanceID = RollNo.Text;
            //        _RollNo = AttendanceID;

            //        DataStudentClassAttendance.Rows.Add( _RollNo, _AttendanceID);
                   
            //    }

               

            //    using (cn)
            //    {
            //        string query = "SP_StudentAttendance";
            //        using (SqlCommand cmd = new SqlCommand("SP_StudentAttendance", cn))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@Action", "UpdateStudentRollNo");
            //            cmd.Parameters.AddWithValue("@UpdateStudentRollNo", DataStudentClassAttendance);
            //            cmd.Parameters.AddWithValue("@OrgID",Convert.ToInt32( Session["OrgId"]));

            //            cn.Open();
            //            cmd.ExecuteNonQuery();
            //            cn.Close();
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully!')", true);
            //            //Response.Redirect(Request.Url.AbsoluteUri);
            //        }
            //    }
            //    //SqlDataSource1.Update();

            //    GridView1.EditIndex = -1;
            //    GridView1.DataBind();
                
            //}
            //catch (Exception ex)
            //{

            //}
        }

        public void GridBind()
        {
            try
            {
                using (cn)
                {

                    string query1 = "SELECT [AdmissionID], [FirstName]+' '+ [MiddleName]+' '+ [LastName] Name,  RollNo  FROM[tblStudent] WHERE(([CourseId] = @CourseId) AND([BranchId] = @BranchId) AND([ClassId] = @ClassId) AND([OrgID] = @OrgID)) and Status = 'Admission Completed' Order By[RollNo]";
                    using (SqlCommand cmd = new SqlCommand(query1, cn))
                    {
                        DataSet ds = new DataSet();
                        cmd.Parameters.AddWithValue("@CourseId", ddlCourses.SelectedValue);
                        cmd.Parameters.AddWithValue("@BranchId", ddlBranches.SelectedValue);
                        cmd.Parameters.AddWithValue("@ClassId", ddlClasses.SelectedValue);
                        cmd.Parameters.AddWithValue("@OrgId", orgId);

                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        cn.Close();

                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully!')", true);
                        //Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
            }
            catch(Exception ex)
            { }
        }

        //EditLinkButtonClick
        #region EditLinkButtonClick

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["AdmissionID"] = GridView2.DataKeys[grdrow.RowIndex].Values["AdmissionID"].ToString();
                    ViewState["RollNo"] = GridView2.DataKeys[grdrow.RowIndex].Values["RollNo"].ToString();

                    Label lblrono=(Label)GridView2.Rows[grdrow.RowIndex].Cells[1].FindControl("lblRollNo");
                    lblrono.Visible = false;

                    TextBox txtRollNo = (TextBox)GridView2.Rows[grdrow.RowIndex].Cells[1].FindControl("txtRollNo");
                    txtRollNo.Visible = true;
                    //TextBox txtRollNo = new TextBox();
                    //txtRollNo.Text = ViewState["RollNo"].ToString();
                    //GridView1.Rows[grdrow.RowIndex].Cells[1].Controls.Add(txtRollNo);

                    LinkButton lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnEdit");
                    lnkBtnId2.Visible = false;
                    lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnUpdate");
                    lnkBtnId2.Visible = true;
                    lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnCancel");
                    lnkBtnId2.Visible = true;
                    
                }
            }
            catch (Exception exp)
            {
                
            }
        }

        #endregion

        //UpdateLinkButtonClick
        #region UpdateLinkButtonClick

        protected void lnkbtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    ViewState["AdmissionID"] = GridView2.DataKeys[grdrow.RowIndex].Values["AdmissionID"].ToString();
                    ViewState["RollNo"] = GridView2.DataKeys[grdrow.RowIndex].Values["RollNo"].ToString();


                    TextBox txtRollNo = (TextBox)GridView2.Rows[grdrow.RowIndex].Cells[1].FindControl("txtRollNo");


                    string RollNo = txtRollNo.Text;
                    string AdmissionID = ViewState["AdmissionID"].ToString();
                    DataSet ds = new DataSet();
                    using (cn)
                    {

                        //string query1 = "Select Count(*) From [tbladmissiondetails] WHERE [RollNo] = @RollNo AND OrgId=@OrgId And ClassId=@ClassId";
                        //using (SqlCommand cmd = new SqlCommand(query1, cn))
                        //{
                        //    cmd.Parameters.AddWithValue("@RollNo", RollNo);
                        //    cmd.Parameters.AddWithValue("@OrgId", orgId);
                        //    cmd.Parameters.AddWithValue("@ClassId", ddlClasses.SelectedValue.ToString());

                        //    cn.Open();
                        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //    da.Fill(ds);
                        //    cn.Close();
                        //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully!')", true);
                        //    //Response.Redirect(Request.Url.AbsoluteUri);
                        //}
                        //if (ds.Tables[0].Rows[0][0].ToString() == "0")
                        //{
                            string query = "UPDATE [tbladmissiondetails] SET [RollNo] = @RollNo WHERE [AdmissionID] = @AdmissionID";
                            using (SqlCommand cmd = new SqlCommand(query, cn))
                            {
                                cmd.Parameters.AddWithValue("@RollNo", RollNo);
                                cmd.Parameters.AddWithValue("@AdmissionID", AdmissionID);

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('Record updated Successfully!')", true);
                                //Response.Redirect(Request.Url.AbsoluteUri);
                            }


                            Label lblrono = (Label)GridView2.Rows[grdrow.RowIndex].Cells[1].FindControl("lblRollNo");
                            lblrono.Text = RollNo;
                            lblrono.Visible = true;

                            txtRollNo.Visible = false;

                            LinkButton lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnEdit");
                            lnkBtnId2.Visible = true;
                            lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnUpdate");
                            lnkBtnId2.Visible = false;
                            lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnCancel");
                            lnkBtnId2.Visible = false;

                            GridBind();
                        //}
                        //else
                        //{

                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Information", "alert('RollNo is already exist')", true);
                        //}

                    }

                }
            }
            catch (Exception exp)
            {

            }
        }

        #endregion

        //CancelLinkButtonClick
        #region CancelLinkButtonClick

        protected void lnkbtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    
                    Label lblrono = (Label)GridView2.Rows[grdrow.RowIndex].Cells[1].FindControl("lblRollNo");
                    lblrono.Visible = true;

                    TextBox txtRollNo = (TextBox)GridView2.Rows[grdrow.RowIndex].Cells[1].FindControl("txtRollNo");
                    txtRollNo.Text = lblrono.Text;
                    txtRollNo.Visible = false;
                    //TextBox txtRollNo = new TextBox();
                    //txtRollNo.Text = ViewState["RollNo"].ToString();
                    //GridView1.Rows[grdrow.RowIndex].Cells[1].Controls.Add(txtRollNo);

                    LinkButton lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnEdit");
                    lnkBtnId2.Visible = true;
                    lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnUpdate");
                    lnkBtnId2.Visible = false;
                    lnkBtnId2 = (LinkButton)GridView2.Rows[grdrow.RowIndex].Cells[2].FindControl("btnCancel");
                    lnkBtnId2.Visible = false;

                }
            }
            catch (Exception exp)
            {

            }
        }

        #endregion

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    try
        //    {
        //        string AdmissionID = (string)GridView1.DataKeys[e.RowIndex].Values["AdmissionID"].ToString();
        //        GridViewRow row = GridView1.Rows[e.RowIndex];


        //        TextBox RollNo = (TextBox)row.FindControl("RollNo");

        //        using (cn)
        //        {
        //            string query = "UPDATE [tbladmissiondetails] SET [RollNo] = @RollNo WHERE [AdmissionID] = @AdmissionID";
        //            using (SqlCommand cmd = new SqlCommand(query, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@RollNo", RollNo.Text);
        //                cmd.Parameters.AddWithValue("@AdmissionID", AdmissionID);

        //                cn.Open();
        //                cmd.ExecuteNonQuery();
        //                cn.Close();
        //                Response.Redirect(Request.Url.AbsoluteUri);
        //            }
        //        }
        //        SqlDataSource1.Update();

        //        GridView1.EditIndex = -1;
        //        GridView1.DataBind();

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}
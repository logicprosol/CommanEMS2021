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

namespace CMS.Forms.Trustee
{
    public partial class StudentTimeTables : System.Web.UI.Page
    {
        public static int orgId=0;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
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
                    string query = "select OrganizationId, OrgName  from tblOrganization";// where OrganizationId='" + Convert.ToInt32(Session["OrgId"]) + "'";
                    DataTable dt = GetData(query);
                    ddlorganization.DataSource = dt;
                    ddlorganization.DataTextField = "OrgName";
                    ddlorganization.DataValueField = "OrganizationId";
                    ddlorganization.DataBind();
                    ddlorganization.Items.Insert(0, new ListItem("Select", ""));
                    BindCourse();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection constr1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                using (SqlConnection con = (constr1))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }

                }
            }
            catch (Exception ex) { }
            return dt;
        }

        #region

        private void BindCourse()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindCourses_BL(objEWA);

                ddlCourse.DataSource = ds;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        #region[Bind Branch]

        private void BindBranch()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                DL_Common objDL = new DL_Common();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();

                DataSet ds = objDL.BindBranch_DL(objEWA);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlBranch.DataSource = ds;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchId";
                    ddlBranch.DataBind();
                }
                else
                    ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion 

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

        #region[Bind Game]

        private void BindClass()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                if (!objEWA.BranchId.Equals("Select"))
                {
                    DataSet ds = objBL.BindClass_BL(objEWA);

                    ddlClass.DataSource = ds;
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ddlClass.DataTextField = "ClassName";
                        ddlClass.DataValueField = "ClassId";
                        ddlClass.DataBind();
                    }
                    else
                        ddlClass.Items.Clear();
                }
                else
                    ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = ddlorganization.SelectedValue;//Session["OrgId"].ToString();
                objEWA.BranchId = ddlBranch.SelectedValue.ToString();
                objEWA.CourseId = ddlCourse.SelectedValue.ToString();
                objEWA.ClassId = ddlClass.SelectedValue.ToString();
                objEWA.date = Convert.ToDateTime(txtDate.Text.ToString()).ToShortDateString();

                DataSet ds = objBL.BindTimeTable_BL(objEWA);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bindGridView(ds);
                }
                else
                {
                    msgBox.ShowMessage("Record not found", "Information", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        public void bindGridView(DataSet ds)
        {

            DataTable dt = new DataTable();
            dt = Filldata(ds);

            grdTimeTable.DataSource = dt;
            grdTimeTable.DataBind();
            grdTimeTable.CellPadding = 10;
            if(dt.Rows.Count <0)
                grdTimeTable.Rows[0].Cells[0].Text = "Record not found !!!";

        }

        public DataTable Filldata(DataSet ds)
        {

            DataTable dt = new DataTable();
            
            dt.Columns.Add("Period");
            dt.Columns.Add("Mon");
            dt.Columns.Add("Tue");
            dt.Columns.Add("Wed");
            dt.Columns.Add("Thu");
            dt.Columns.Add("Fri");
            dt.Columns.Add("Sat");
            

            if (ds.Tables[0].Rows.Count > 0)
            {
                
                int i = 0, l = 0, sat = 0, day = 2;
                while (ds.Tables[0].Rows.Count > i || ds.Tables[1].Rows.Count > sat)
                {

                    DataRow dr = dt.NewRow();
                    dr[0] = ++l;
                    if (ds.Tables[0].Rows.Count > i)
                    {
                        string Time = ds.Tables[0].Rows[i][0].ToString();
                        int j = 0;
                        while (ds.Tables[0].Rows.Count > j)
                        {

                            if (ds.Tables[0].Rows[j][0].ToString() == Time)
                            {
                                while (day < 7)
                                {
                                    if (ds.Tables[0].Rows[j][5].ToString() == day.ToString())
                                    {
                                        dr[day - 1] = ds.Tables[0].Rows[j][2].ToString() + "\n(" + ds.Tables[0].Rows[j][3].ToString() + ")";
                                        
                                        //TimetableDetails Details = new TimetableDetails();
                                        //Details.Subject = ds.Tables[0].Rows[j][2].ToString();
                                        //Details.Day = ds.Tables[0].Rows[j][1].ToString();
                                        //Details.Teacher = ds.Tables[0].Rows[j][3].ToString();
                                        //Details.HomeWork = ds.Tables[0].Rows[j][4].ToString();
                                        //Detailslist.Add(Details);
                                        i++; day++;
                                        break;
                                    }
                                    else
                                    {
                                        dr[day - 1] = " - " + "\n" + " - ";
                                    }
                                    day++;
                                }
                            }
                            j++;
                        }
                    }

                    while (day < 7)
                    {
                        dr[day - 1] = " - " + '\n' + " - ";
                        day++;
                    }

                    if (ds.Tables[1].Rows.Count > sat && day == 7)
                    {
                        dr[day - 1] = ds.Tables[1].Rows[sat][2].ToString() + "\n(" + ds.Tables[1].Rows[sat][3].ToString() + ")";
                        
                        sat++; day = 2;
                    }
                    else if (day == 7)
                    {
                        dr[day - 1] = " - " + "\n" + " - ";
                        day = 2;
                    }


                    dt.Rows.Add(dr);
                }
                
            }
            return dt;
        }
    }
}
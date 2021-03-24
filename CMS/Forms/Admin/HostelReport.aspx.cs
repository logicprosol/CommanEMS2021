using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using DataAccessLayer;
using System.Configuration;
using System.Data.Common;
using Entity;
using dal;

namespace CMS.Forms.Admin
{
    public partial class HostelReport : System.Web.UI.Page
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        DataSet ds = new DataSet();
        database db = new database();
        private BL_AcademicYear objBL = new BL_AcademicYear();
        private EWA_AcademicYear objEWA = new EWA_AcademicYear();
        public static int orgId;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {


             
                //db.cnopen();
                //db.insert("update HostelRoom set Status='" + "Empty" + "' where Status='" + DBNull.Value + "'  ");
                //db.cnclose();


                //Bind  Hostel NAME
                if (ddlHostel.Items.Count <= 1)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Hostel_id,Hostel_name FROM AddHostel  where OrgId='" + orgId.ToString() + "' "))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cn;
                        cn.Open();
                        ddlHostel.DataSource = cmd.ExecuteReader();
                        ddlHostel.DataTextField = "Hostel_name";
                        ddlHostel.DataValueField = "Hostel_id";
                        ddlHostel.DataBind();
                        cn.Close();
                    }

                    ddlHostel.Items.Insert(0, new ListItem("--Select Hostel--"));
                }
              
            }

        }

       

        protected void ddlHostel_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("sp_HostelAdmission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId",Convert.ToInt32( Session["OrgId"]));
                cmd.Parameters.AddWithValue("@HostelId", Convert.ToInt32(ddlHostel.SelectedValue));
                cmd.Parameters.AddWithValue("@Action", "HostelReport");
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cn.Close();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    lblHostelName.Text = ds.Tables[0].Rows[0]["Hostel"].ToString();
                    lblOrgName.Text = ds.Tables[2].Rows[0]["OrgName"].ToString();

                    gvhostelInfo.DataSource = ds.Tables[1];
                    gvhostelInfo.DataBind();
                    btnPrint.Visible = true;
                    pnlContents1.Visible = true;
                }
                else
                {
                    pnlContents1.Visible = false;
                    btnPrint.Visible = false;
                    gvhostelInfo.DataSource = null;
                    gvhostelInfo.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found..!')", true);
                    //MsgBox.ShowMessage("Record Not Found..!", "Critical", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            catch (Exception ex) { }


            }
    }
}
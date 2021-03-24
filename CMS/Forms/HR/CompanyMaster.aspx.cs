using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using Entity;
using dal;

namespace CMS.Forms.HR
{
    public partial class CompanyMaster : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        DataSet ds = new DataSet();
        database db = new database();
        public static int orgId=0;
        clse_companymaster clse = new clse_companymaster();
        clsd clsd = new clsd();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            orgId = Convert.ToInt32(Session["OrgId"]);
            if (orgId == 0)
            {
                Response.Redirect("~/CMSHome.aspx");
            }
            else
            {
                hdnid.Value = orgId.ToString();
                gvcompany.DataSource = db.Displaygrid("select * from tblCompanyPlacementMaster where OrgId='" + Convert.ToInt32(Session["OrgId"]).ToString() + "'");
                gvcompany.DataBind();
                if (Request.QueryString["Company_id"] != null)
                {
                    if (!IsPostBack)
                    {

                        clse.Company_id = int.Parse(Request.QueryString["Company_id"].ToString());
                        ds = clsd.COMPANY(clse);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtCompanyName.Text = ds.Tables[0].Rows[0]["Company_Name"].ToString();
                            txtCompanyAddress.Text = ds.Tables[0].Rows[0]["Company_Address"].ToString();
                            txtCompanyEmail.Text = ds.Tables[0].Rows[0]["Company_email"].ToString();
                            txtMobileNumber.Text = ds.Tables[0].Rows[0]["Company_mob"].ToString();
                            txtContactPerson.Text = ds.Tables[0].Rows[0]["Contact_Person"].ToString();
                            txtwebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
                            txtCriteria.Text= ds.Tables[0].Rows[0]["Criteria"].ToString();
                            hdbId.Value = (clse.Company_id).ToString();
                        }
                        else
                        {
                            //btnsave.Visible = true;
                            //btnupdate.Visible = false;
                            //btndelete.Visible = false;
                        }
                    }
                 }
             }
         }

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {

            float count = db.getDb_Value("select count(Company_Name)  from   tblCompanyPlacementMaster where Company_Name='" + txtCompanyName.Text + "' ");
           if(count==0)
           {
            db.cnopen();
            db.insert("insert into tblCompanyPlacementMaster (Company_Name,Company_Address,Company_email,Company_mob,Contact_Person,OrgId,Website,Criteria)" +
                "values('" + txtCompanyName.Text + "','" + txtCompanyAddress.Text + "','" + txtCompanyEmail.Text + "','" + txtMobileNumber.Text + "'," +
                "'" + txtContactPerson.Text + "','" + orgId.ToString() + "','" + txtwebsite.Text + "','" + txtCriteria.Text + "') ");
            db.cnclose();
            gvcompany.DataSource = db.Displaygrid("select * from tblCompanyPlacementMaster where OrgId='" + Convert.ToInt32(Session["OrgId"]).ToString() + "'");
            gvcompany.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted successfully')", true);
            clear();

          //  Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
           }
           else
           {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Comapny Name Already exist')", true);
           }
            
            //gvcompany.DataSource = db.Displaygrid("SELECT Company_id, Company_Name, Company_email, Company_mob, Contact_Person FROM tblCompanyPlacementMaster");
            //gvcompany.DataBind();
        }

        void clear()
        {
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtCompanyEmail.Text = "";
            txtMobileNumber.Text = "";
            txtContactPerson.Text = "";
            txtwebsite.Text = "";
            txtCriteria.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] confirmValue = Request.Form["confirm_value"].Split(',');
                //if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    //float count = db.getDb_Value("select count(Company_Name)  from   tblCompanyPlacementMaster where Company_Name='" + txtCompanyName.Text + "' ");
                    //if (count == 0)
                    //{
                    db.cnopen();
                    db.insert("update tblCompanyPlacementMaster set  Company_Name='" + txtCompanyName.Text + "',Company_Address='" + txtCompanyAddress.Text + "'," +
                        "Company_email='" + txtCompanyEmail.Text + "',Company_mob='" + txtMobileNumber.Text + "', Contact_Person='" + txtContactPerson.Text + "'" +
                        ", Website='" + txtwebsite.Text + "',Criteria='" + txtCriteria.Text + "' where Company_id ='" + hdbId.Value + "'");
                    db.cnclose();
                    gvcompany.DataSource = db.Displaygrid("select * from tblCompanyPlacementMaster where OrgId='" + Convert.ToInt32(Session["OrgId"]).ToString() + "'");
                    gvcompany.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated successfully')", true);
                    clear();
                    // }
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Comapny Name Already exist')", true);
                    //}
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] confirmValue = Request.Form["confirm_value"].Split(',');
            if (confirmValue[confirmValue.Length - 1] == "Yes")
            {
                db.cnopen();
                db.insert("delete from tblCompanyPlacementMaster where Company_id='" + hdbId.Value + "'");
                db.cnclose();
                gvcompany.DataSource = db.Displaygrid("select * from tblCompanyPlacementMaster where OrgId='" + Convert.ToInt32(Session["OrgId"]).ToString() + "'");
                gvcompany.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully')", true);
                clear();
            }
        }

    }
}
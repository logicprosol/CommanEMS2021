using System;
using System.Data;
using BusinessAccessLayer;
using EntityWebApp;
using System.IO;
using System.Web.UI;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Admin
{
    public partial class ViewFees : System.Web.UI.Page
    {
        database db = new database();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindData();
            }
        }
        private void bindData()
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.OrgId = Session["OrgId"].ToString();
                DataSet ds = objBL.BindFeeStructure(objEWA);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    GRDFee.DataSource = ds;
                    GRDFee.DataBind();

                }
                else
                {
                    GRDFee.DataSource = null;
                    GRDFee.DataBind();

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        protected void GRDFee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowParticular")
            {
                int RowFeesId = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();
                cn.Close();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("select FeesDetailsId,FeesId,Particular,Amount from tblFeesDetails where feesId='" + RowFeesId + "'", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GRDFeedeatils.DataSource = ds;
                        GRDFeedeatils.DataBind();
                    }
                    DivFeesShow.Visible = true;
                    GRDFeedeatils.Visible = true;


                }
            }
        }

        protected void btnDivFeesCancel_Click(object sender, EventArgs e)
        {
            GRDFeedeatils.Visible = false;
            DivFeesShow.Visible = false;
        }

        protected void GRDFee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRDFee.PageIndex = e.NewPageIndex;
            bindData();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}
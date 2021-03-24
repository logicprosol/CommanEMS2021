using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;

//View Fee Details
namespace CMS.Forms.Student
{
    public partial class ViewFeesDetails : System.Web.UI.Page
    {
        //Page Load
        #region[Page Load]
public static int orgId = 0;
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
                    BindFeesPaidDetailsGrid();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //StudentFeesPaidDetails
        #region[Fee Paid Details]

        private void BindFeesPaidDetailsGrid()
        {
            try
            {
                EWA_PayFees objEWA = new EWA_PayFees();
                BL_PayFees objBL = new BL_PayFees();

                objEWA.StudentCode = Session["UserCode"].ToString();

                DataSet ds = objBL.BindStudentFeesPaidDetails_BL(objEWA);
                if (ds.Tables[0].Rows.Count == 0 || ds == null)
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GrdFeesPaidDetails.DataSource = ds;
                    GrdFeesPaidDetails.DataBind();
                    int columncount = GrdFeesPaidDetails.Rows[0].Cells.Count;
                    GrdFeesPaidDetails.Rows[0].Cells.Clear();
                    GrdFeesPaidDetails.Rows[0].Cells.Add(new TableCell());
                    GrdFeesPaidDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    GrdFeesPaidDetails.Rows[0].Cells[0].Text = "No Records Found";
                }
                else
                {
                    DataView dv = ds.Tables[0].DefaultView;
                    dv.Sort = "ReceiptNo desc";
                    GrdFeesPaidDetails.DataSource = dv;
                    GrdFeesPaidDetails.DataBind();
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
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
    }
}
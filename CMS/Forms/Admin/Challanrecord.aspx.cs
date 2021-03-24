using BusinessAccessLayer.Admin;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class Challanrecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Getdata();
                
            }

        }
        private void Getdata()
        {
            try
            {
                EWA_Challanrecord objEWA = new EWA_Challanrecord();
                BL_Challanrecord objBL = new BL_Challanrecord();

                DataSet ds = new DataSet();
                ds = objBL.BL_Challanrec(objEWA);
              
                // objEWA.GroupReceiptNo = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid.DataSource = ds.Tables[0];
                    grid.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

     

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EWA_Challanrecord objEWA = new EWA_Challanrecord();
            BL_Challanrecord objBL = new BL_Challanrecord();

            Button btn1 = ((Button)grid.FindControl("btnapprove"));

            if (e.CommandName == "Approve")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = grid.Rows[rowIndex];

                //Fetch value of Name.
                string GroupReceiptNo = row.Cells[1].Text;

                //Fetch value of Country
                string StudentId = row.Cells[2].Text;
                string StudentName = row.Cells[3].Text;
                string TotalAmount = row.Cells[4].Text;
                string PaidAmount = row.Cells[5].Text;
                string PendingAmount = row.Cells[6].Text;

                objEWA.GroupReceiptNo = GroupReceiptNo.ToString();
                objEWA.StudentId = StudentId.ToString();
                objEWA.StudentName = StudentName.ToString();
                objEWA.TotalAmount = TotalAmount.ToString();
                objEWA.PaidAmount = PaidAmount.ToString();
                objEWA.PendingAmount = PendingAmount.ToString();
                //objEWA.Status = Status.ToString();
                // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('GroupReceiptNo: " + GroupReceiptNo + "\\nStudentId: " + StudentId + "\\nStudentName: " + StudentName + "\\nTotalAmount: " + TotalAmount + "\\nPaidAmount: " + PaidAmount + "\\nPendingAmount: " + PendingAmount + "\\nStatus: " + Status + "');", true);

                DataSet ds = new DataSet();
                ds = objBL.BL_ChallanByadmin(objEWA);

             
                if (objEWA.GroupReceiptNo!=null)
                {
                    //btn1.Enabled = false;
                }
            }
            }

        protected void btnNew_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Challanrecord.aspx");
       
         }

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        if (!string.IsNullOrEmpty(txtChallanrepNo.Text.Trim()))
                        {
                            EWA_Challanrecord objEWA = new EWA_Challanrecord();
                            BL_Challanrecord objBL = new BL_Challanrecord();

                            cmd.Parameters.AddWithValue("@GroupReceiptNo", txtChallanrepNo.Text.Trim());
                            string GroupReceiptNo = txtChallanrepNo.Text;
                           objEWA.GroupReceiptNo = GroupReceiptNo.ToString();

                            DataSet ds = new DataSet();
                            ds = objBL.BL_ChallanBySearchRep(objEWA);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                grid.DataSource = ds.Tables[0];
                                grid.DataBind();
                            }

                        }
                    }
                }
             }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        protected void Search(object sender, EventArgs e)
        {
            this.Getdata();
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid.PageIndex = e.NewPageIndex;
            this.Getdata();
        }
    }
    }

using BusinessAccessLayer.HR;
using EntityWebApp.HR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.HR
{
    public partial class ChallanRecAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetData();
            }
        }
        protected void GetData()
        {
            try
            {
                EWA_ChallanRecAdmin objEWA = new EWA_ChallanRecAdmin();
                BL_ChallanRecAdmin objBL = new BL_ChallanRecAdmin();

                DataSet ds = new DataSet();
                ds = objBL.BL_ChallanRecAdminhr(objEWA);
                {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grid.DataSource = ds.Tables[0];
                            grid.DataBind();
                        }
                   
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
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
                            EWA_ChallanRecAdmin objEWA = new EWA_ChallanRecAdmin();
                            BL_ChallanRecAdmin objBL = new BL_ChallanRecAdmin();


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
            catch (Exception)
            {

                throw;
            }

        }  
            

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EWA_ChallanRecAdmin objEWA = new EWA_ChallanRecAdmin();
            BL_ChallanRecAdmin objBL = new BL_ChallanRecAdmin();

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
               
                // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('GroupReceiptNo: " + GroupReceiptNo + "\\nStudentId: " + StudentId + "\\nStudentName: " + StudentName + "\\nTotalAmount: " + TotalAmount + "\\nPaidAmount: " + PaidAmount + "\\nPendingAmount: " + PendingAmount + "\\nStatus: " + Status + "');", true);

                DataSet ds = new DataSet();
                ds = objBL.BL_Challanhr(objEWA);               
             
               
              

            }
           
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChallanRecAdmin.aspx");
        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "someValue") //Here is the condition!
                {
                    //   
                    //Change the cell color.
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    //
                    //Change the back color.
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;

                }
            }
        }

        }
        
    }

        
    


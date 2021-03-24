using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class EditphotosStudent : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState != DataControlRowState.Edit))
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    var ss = dr["Photo"].ToString();
                    if (ss != "")
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Photo"]);
                        (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
                    }
                    //else
                    //    (e.Row.FindControl("Image1") as Image).Visible = false;
                }
                
            }
            catch (Exception ex)
            { }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string ApplicationId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
                
                GridViewRow row = GridView1.Rows[e.RowIndex];

                FileUpload FileUpload1 = (FileUpload)row.FindControl("FileUpload1");
                TextBox txtFirstName = (TextBox)row.FindControl("txtFirstName");
                TextBox txtMiddleName = (TextBox)row.FindControl("txtMiddleName");
                TextBox txtLastName = (TextBox)row.FindControl("txtLastName");
               

                string query="";
                byte[] bytes=null;
                if (FileUpload1.HasFile)
                {
                    //SqlDataSource2.UpdateCommand = "UPDATE [tblQuestion] SET [Question] = @Question, [ImgQuestion] = @ImgQuestion, [optA] = @optA, [optB] = @optB," +
                    //                                            "[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE[Id] = @Id";

                    using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    }
                    query = "UPDATE[tblAdmissionDetails] SET [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName, [Photo] = @Photo WHERE [ApplicationId] = @ApplicationId";
                }
                else
                    query = "UPDATE [tblAdmissionDetails] SET  [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName WHERE [ApplicationId] = @ApplicationId";

                using (cn)
                    {

                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {

                            if (bytes != null)
                            {
                                cmd.Parameters.AddWithValue("@Photo", bytes);
                            }

                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                    }
                    SqlDataSource2.Update();
                    GridView1.EditIndex = -1;
                    GridView1.DataBind();
                
            }
            catch (Exception ex)
            {

            }
        }
       
    }
}
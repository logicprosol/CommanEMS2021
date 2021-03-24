using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityWebApp.Faculty;
using BusinessAccessLayer.Faculty;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Student
{
    public partial class ViewUploadDocument : System.Web.UI.Page
    {
        bool flag;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        EWA_UploadDocument ObjEWA = new EWA_UploadDocument();
        BL_UploadDocument ObjBL = new BL_UploadDocument();
        int rowindex=0;
        int orgId = 0;
        // Page Load
        #region [Page Load]
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 orgId = Convert.ToInt32(Session["OrgId"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }

            if (!IsPostBack)
            {
                Initialize();
                ShowEmptyGridView(GrdUploadDocument);
                BindGridView();

            }

        }
        #endregion
        //  Show Empty GridView Function

       
        #region [Show Empty Grid Function]

        private void ShowEmptyGridView(GridView grid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UploadDocReceiptId");
            dt.Columns.Add(grid.Columns[0].HeaderText);
            dt.Columns.Add(grid.Columns[1].HeaderText);
            dt.Columns.Add(grid.Columns[2].HeaderText);
            dt.Columns.Add(grid.Columns[3].HeaderText);
            dt.Columns.Add("Subject");
            dt.Columns.Add("MessageContent");
            dt.Columns.Add("UploadDocId");
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            grid.DataSource = dt;
            grid.DataBind();
            grid.Columns[3].Visible = false;
            grid.Rows[0].Cells[0].ColumnSpan = 3;
            foreach (GridViewRow row in grid.Rows)
            {
                row.Cells[1].Visible = false;
                row.Cells[2].Visible = false; 
                row.Cells[3].Visible = false;
                
            }
            grid.Rows[0].Cells[0].Text = "Record not found !!!";
        }

        #endregion

        // Intialize Upload document panel

        #region [Initialize Upload document Panel]
        
        private void Initialize()
        {
           
            lblDocumentSubject.Text = "No Document Selected";
            lblDocumentMessage.Text = "Message Not Found";
            lnkDownload.Text = "File Not Found";
        }
        
        #endregion

        // General Message

        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        // Bind Data to GridView on radio button selection

        #region [Bind data to grid]

        protected void rbtnPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindGridView();
        }

        #endregion

        // Bind Gridview

        #region [Bind GridView]
        private void BindGridView()
        {
            try
            {
                //EWA_UploadDocument ObjEWA = new EWA_UploadDocument();
                //BL_UploadDocument ObjBL = new BL_UploadDocument();

                ObjEWA.Action = "FetchUploadDocument";
                ObjEWA.UploadPurpose =  Convert.ToInt32(rbtnPurpose.SelectedValue);
                
                ObjEWA.StudentId = Session["UserCode"].ToString();
               lblTitle.Text = rbtnPurpose.SelectedItem.ToString();
                DataSet ds1 = ObjBL.BindUploadDocument_BL(ObjEWA);
                //SqlCommand cmd1 = new SqlCommand("	Select udr.UploadDocReceiptId,up.FileName as 'DocumentName',emp.FirstName+' '+emp.LastName as 'SenderName',Convert(varchar(2),DATEPART(day, up.Date)) + '/'+ Convert(varchar(2),DATEPART(MONTH, up.Date)) + '/' + Convert(varchar(4),DATEPART(year, up.Date))as 'Date',[Subject],MessageContent,ContentType,UploadedFile from tblUploadDocument up,tblEmployee emp,tblUploadDocumentRecipient udr where   CONVERT(VARCHAR(50),up.SenderId )=emp.UserCode and udr.UploadDocId=up.UploadDocId  and udr.StudentId='" + ObjEWA.StudentId + "'  and up.UploadDocId  IN(Select UploadDocId from tblUploadDocumentRecipient where StudentId='" + Session["UserCode"].ToString() + "') and up.DocumentPurpose='" + ObjEWA.UploadPurpose + "' order by up.Date desc ", cn);
                //SqlDataAdapter adp1 = new SqlDataAdapter();
                //DataSet ds1 = new DataSet();
                //adp1.SelectCommand = cmd1;
                //adp1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count != 0)
                {
                    GrdUploadDocument.DataSource = ds1.Tables[0];
                    GrdUploadDocument.DataBind();
                    GrdUploadDocument.Columns[3].Visible = true;
                }
                else
                {
                    ShowEmptyGridView(GrdUploadDocument);
                }
                //Initialize();
                
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        //Link view Btn Event
        #region[Link view Btn Event]

        protected void linkbtnView_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                  
                    
                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    if (GrdUploadDocument.DataKeys[grdrow.RowIndex].Values["Subject"] == null)
                    {
                        lblDocumentSubject.Text = "";
                    }
                    else
                    {
                        lblDocumentSubject.Text = GrdUploadDocument.DataKeys[grdrow.RowIndex].Values["Subject"].ToString() != "" ? GrdUploadDocument.DataKeys[grdrow.RowIndex].Values["Subject"].ToString() : "";

                    }
                    lblDocumentMessage.Text = GrdUploadDocument.DataKeys[grdrow.RowIndex].Values["MessageContent"].ToString();
                    lnkDownload.Text = GrdUploadDocument.DataKeys[grdrow.RowIndex].Values["DocumentName"].ToString();
                    ViewState["rowindex"] = grdrow.RowIndex;                    

                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void GrdUploadDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string[] confirmValue = Request.Form["confirm_value"].Split(',');
                if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    EWA_UploadDocument ObjEWA = new EWA_UploadDocument();
                    BL_UploadDocument ObjBL = new BL_UploadDocument();

                    ObjEWA.Action = "DeleteUploadDocument";
                    ObjEWA.UploadDocReceiptId = GrdUploadDocument.DataKeys[e.RowIndex].Values["UploadDocReceiptId"].ToString();
                    ObjBL.DeleteUploadDocument_BL(ObjEWA);
                    BindGridView();
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string contenttype,filename;
        
                //contenttype = GrdUploadDocument.DataKeys[rowindex].Values["ContentType"].ToString();
                //filename=GrdUploadDocument.DataKeys[rowindex].Values["DocumentName"].ToString();
                
                //Response.ContentType = contenttype;
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                ////byte[] data = (byte[])GrdUploadDocument.DataKeys[rowindex].Values["UploadedFile"];
                //Response.BinaryWrite(data);
                //Response.End();


                rowindex = Convert.ToInt32(ViewState["rowindex"]);
                byte[] data = (byte[])GrdUploadDocument.DataKeys[rowindex].Values["UploadedFile"];
                contenttype = GrdUploadDocument.DataKeys[rowindex].Values["ContentType"].ToString();
                filename = GrdUploadDocument.DataKeys[rowindex].Values["DocumentName"].ToString();
                
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contenttype;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(data);
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {

            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(ViewState["rowindex"]);
            byte[] bytes;
            string fileName, contentType;
           // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (cn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_UploadDocument";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetDownloadFile");
                    cmd.Parameters.AddWithValue("@UploadDocId", GrdUploadDocument.DataKeys[rowindex].Values["UploadDocId"].ToString());
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            bytes = (byte[])sdr["UploadedFile"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["FileName"].ToString();

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.ContentType = contentType;
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                            Response.BinaryWrite(bytes);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    cn.Close();
                }
            }

            
        }

    }
}
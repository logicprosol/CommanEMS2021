using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BusinessAccessLayer.Faculty;
using DataAccessLayer.Faculty;
using EntityWebApp.Faculty;
using System.Configuration;
using System.Text.RegularExpressions;

//View Announcement
namespace CMS.Forms.Student
{
    public partial class ViewAnnouncement : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        string strCon = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private DataSet ds, dsAttachment;
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        private static DataSet dsGrdViewAnnouncement;
     public static int orgId = 0;
        #endregion

        //Page Load
        #region[Page Load]

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
                    BindGridData();           
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        protected void BindGridData()
        {

            EWA_Messages objEWA = new EWA_Messages();
            BL_Messages objBL = new BL_Messages();

            objEWA.OrgId = Session["OrgId"].ToString();
            objEWA.StudentId = Session["UserCode"].ToString();
            objEWA.Action = "FetchStudentMessage";
            ds = objBL.BindGrdViewAnnouncement_BL(objEWA);




            //SqlCommand cmd1 = new SqlCommand("	SELECT DISTINCT                           ms.MessageId, er.FirstName + ' ' + er.MiddleName + ' ' + er.LastName AS 'Sender', ms.Subject, CONVERT(varchar, md.SendDate, 107) AS 'SendDate',                           ms.MessageContent, md.StudentUserCode  FROM            tblMessageSave AS ms INNER JOIN                          tblEmployee AS er ON ms.StaffUserCode = er.UserCode INNER JOIN                          tblMessageDetails AS md ON ms.MessageId = md.MessageId WHERE        (ms.MessageId IN                              (SELECT        MessageId                                FROM            tblMessageDetails                                WHERE        (StudentUserCode = '" + objEWA.StudentId + "'))) AND (ms.OrgId = '" + objEWA.OrgId + "') AND (md.StudentUserCode = '" + objEWA.StudentId + "')   order by (MessageId) desc", cn);
            //SqlDataAdapter adp1 = new SqlDataAdapter();
            //DataSet ds1 = new DataSet();
            //adp1.SelectCommand = cmd1;
            //adp1.Fill(ds1);






            if (ds.Tables[0].Rows.Count == 0)
            {
                GrdViewAnnouncement.DataSource = ReturnEmptyDataTable();
                GrdViewAnnouncement.DataBind();
                GrdViewAnnouncement.Columns[3].Visible = false;
                GrdViewAnnouncement.Rows[0].Cells[0].ColumnSpan = 3;
                GrdViewAnnouncement.Rows[0].Cells[1].Visible = false;
                GrdViewAnnouncement.Rows[0].Cells[2].Visible = false;
                
                lblNoMessageFound.Visible = true;
            }
            else
            {
                GrdViewAnnouncement.DataSource = ds;
                GrdViewAnnouncement.DataBind();
                dsGrdViewAnnouncement = ds.Copy();
            }
        }

        //LinkBtn Event
        #region[Link Btn Event]

        protected void linkbtnView_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    //EWA_Messages ObjEWA = new EWA_Messages();
                    DL_Messages ObjDL = new DL_Messages();

                    LinkButton lnkBtnId = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
                    string MessageId = GrdViewAnnouncement.DataKeys[grdrow.RowIndex].Values["MessageId"].ToString();
                    //ObjEWA.MessageId = MessageId;
                    //ObjEWA.Action = "FetchAttachment";
                    //dsAttachment = ObjDL.FetchAttachment(ObjEWA);
                    //GrdAttachement.DataSource = dsAttachment;
                    //GrdAttachement.DataBind();
                    lblFrom.Text = GrdViewAnnouncement.DataKeys[grdrow.RowIndex].Values["Sender"].ToString();
                    lblSubject.Text = GrdViewAnnouncement.DataKeys[grdrow.RowIndex].Values["Subject"].ToString();
                    txtMessage.Text = GrdViewAnnouncement.DataKeys[grdrow.RowIndex].Values["MessageContent"].ToString();
                    txtMessage.Enabled = false;
                    MessagePopUp.Show();
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Announcement Changed
        #region[Announcement Changed]

        protected void GrdViewAnnouncement_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        //Download File
        #region[Download File]

        //protected void DownloadFile(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton lnkBtnId = (LinkButton)sender;
        //        GridViewRow grdrow = lnkBtnId.NamingContainer as GridViewRow;
        //        int fileid = Convert.ToInt32(GrdAttachement.DataKeys[grdrow.RowIndex].Values["FileId"].ToString());

        //        using (SqlConnection con = new SqlConnection(strCon))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "select FileName,ContentType,Data from tblAttachment where FileId=@Id";
        //                cmd.Parameters.AddWithValue("@id", fileid);
        //                cmd.Connection = con;
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                if (dr.Read())
        //                {
        //                    Response.ContentType = dr["ContentType"].ToString();
        //                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["FileName"] + "\"");
        //                    Response.BinaryWrite((byte[])dr["Data"]);
        //                    Response.End();
        //                }
        //            }
        //        }
        //        MessagePopUp.Show();
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Return Empty DataTable
        #region[Return Empty DataTable]

        public DataTable ReturnEmptyDataTable()
        {
            try
            {
                DataTable dtMenu = new DataTable(); //declaringa datatable
                // DataColumn dcMenuID = new DataColumn("SrNo", typeof(System.String));

                DataColumn dcMessageId = new DataColumn("MessageId", typeof(System.String));
                dtMenu.Columns.Add(dcMessageId);// Adding column to the datatable

                DataColumn dcUserCode = new DataColumn("StudentUserCode", typeof(System.String));
                dtMenu.Columns.Add(dcUserCode);// Adding column to the datatable

                // dtMenu.Columns.Add(dcMenuID);// Adding column to the datatable

                DataColumn dcFrom = new DataColumn("Sender", typeof(System.String));
                dtMenu.Columns.Add(dcFrom);// Adding column to the datatable

                //creating a column in the same
                //Name of column available in the sql server
                DataColumn dcSubject = new DataColumn("Subject", typeof(System.String));
                dtMenu.Columns.Add(dcSubject);

                //Date of column available in the sql server
                DataColumn dcDate = new DataColumn("SendDate", typeof(System.String));
                dtMenu.Columns.Add(dcDate);

                //Date of column available in the sql server
                DataColumn dcMessageContent = new DataColumn("MessageContent", typeof(System.String));
                dtMenu.Columns.Add(dcMessageContent);

                DataRow datatRow = dtMenu.NewRow();

                datatRow["MessageId"] = "No Message found";
                //Inserting a new row,datatable .newrow creates a blank row
                dtMenu.Rows.Add(datatRow);//adding row to the datatable
                return dtMenu;
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
                return null;
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

        protected void GrdViewAnnouncement_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdViewAnnouncement.PageIndex = e.NewPageIndex;
                GrdViewAnnouncement.DataSource = dsGrdViewAnnouncement;
                GrdViewAnnouncement.DataBind();
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }


        protected void GrdViewAnnouncement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //string[] confirmValue = Request.Form["confirm_value"].Split(',');
                //if (confirmValue[confirmValue.Length - 1] == "Yes")
                {
                    EWA_Messages ObjEWA = new EWA_Messages();
                    DL_Messages ObjDL = new DL_Messages();

                    ObjEWA.Action = "DeleteStudentCreateAnnouncement";
                    ObjEWA.SenderId = GrdViewAnnouncement.DataKeys[e.RowIndex].Values["StudentUserCode"].ToString();
                    ObjEWA.MessageId = GrdViewAnnouncement.DataKeys[e.RowIndex].Values["MessageId"].ToString();

                    ObjDL.DeleteSenderDetails(ObjEWA);
                    BindGridData();
                }

            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }
        //Added by Ashwini more 19-nov-2020.....................................................................

        protected void GrdViewAnnouncement_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                string URL1 = rowView["Subject"].ToString();
               // string pattern = @"/\b(http|https)\:\/\/(www\.)?[a-z]+\.[a-z]{2,3}\b/g";
                //Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                //var m = r.Match(URL1);

                if(URL1.StartsWith("https://www") || URL1.StartsWith("http://www"))
                {
                    LinkButton lnkbtnSubject = (LinkButton)e.Row.FindControl("lnkbtnSubjectView");
                    lnkbtnSubject.Visible = true;
                }
                else
                {
                    Label lblSubjectView = (Label)e.Row.FindControl("lblSubjectView");
                    lblSubjectView.Visible = true;
                }
            }

        }
        //..............................................................................................
        //Added by Ashwini more 19-nov-2020
        protected void lnkbtnSubjectView_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string URL = GrdViewAnnouncement.DataKeys[row.RowIndex].Values["Subject"].ToString();
           // Response.Redirect(URL);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open ( '"+ URL + "' ,'_blank');", true);
        }
        //..................................................................................................
        protected void clear()
        {


        }




    }
}
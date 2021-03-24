using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.Admin;
//

namespace CMS.Forms.Admin
{
    public partial class BackUpAndRestore : System.Web.UI.Page
    {
        
            //Objects
            //#region[Objects]
            //private string[] PrmList;
            //private Classes.HelperClass.HelperClass ObjHelper = new Classes.HelperClass.HelperClass();
            //#endregion
public static int orgId;
            //Page Load
            #region[Page Load]

            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                
                orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

                    if (!IsPostBack)
                    {
                        ViewState["BackupName"] = null;
                        GetBackupList();
                    }
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                }
            }

            #endregion

            //Get Backup List
            #region[Get Backup List]

            private void GetBackupList()
            {
                try
                {
                    //PrmList = new string[2];
                    //PrmList[0] = "@Action";
                    //PrmList[1] = "GetBackupList";
                    //DataSet ds = ObjHelper.BindControl("GETDATABACKUP", PrmList);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    GrdBackupList.DataSource = ds.Tables[0];
                    //    GrdBackupList.DataBind();
                    //}
                    //else
                    //{
                    //    DataTable dt = new DataTable();
                    //    dt.Columns.Add("ExFileName");
                    //    dt.Rows.Add();
                    //    dt.Rows.Add();
                    //    dt.Rows.Add();
                    //    GrdBackupList.DataSource = dt;
                    //    GrdBackupList.DataBind();
                    //}
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                }
            }

            #endregion

            //Link Button Backup List Event
            #region[Link Button Backup list Event]

            protected void lnkBtnBackupList_Click(object sender, EventArgs e)
            {
                try
                {
                    LinkButton lnkBtnBackupList = (LinkButton)sender;
                    GridViewRow grdrow = lnkBtnBackupList.NamingContainer as GridViewRow;
                    lnkBtnBackupList = grdrow.Cells[0].FindControl("lnkBtnBackupList") as LinkButton;
                    ViewState["BackupName"] = lnkBtnBackupList.Text;
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                }
            }

            #endregion

            //Ok Button event
            #region[Ok Button Event]

            protected void BtnOk_Click(object sender, EventArgs e)
            {
                try
                {
                    if (DDLDBAction.SelectedValue == "1")
                    {
                        DL_DbBackup objDL = new DL_DbBackup();
                        int res = objDL.GetDBBackup();
                        if (res > 0)
                        {
                            MsgBox.ShowMessage("Backup Database successfully processed !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                            GetBackupList();
                        }
                        else
                        {
                            MsgBox.ShowMessage("Unable To Backup !!!", "Information", UserControls.MessageBox.MessageStyle.Information);
                        }
                    }
                }

                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                    //throw ex;
                }
            }

            #endregion

            //Grid Result Page Index Changing
            #region[Grid Result Page Index Changing]

            protected void gridResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                try
                {
                    GrdBackupList.PageIndex = e.NewPageIndex;
                    GetBackupList();
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                    //throw;
                }
            }

            #endregion

            //General Message
            #region[General Message]

            protected void GeneralErr(String msg)
            {
              //  MsgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
            }

            #endregion

            //Clear Controls
            #region[Clear Controls]

            private void ClearControls()
            {
                try
                {
                    DDLDBAction.SelectedValue = "1";
                    ViewState["BackupName"] = null;
                }
                catch (Exception exp)
                {
                    GeneralErr(exp.Message.ToString());
                }
            }

            #endregion
        }
    }

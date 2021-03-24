/*----------------------------------------------*/
//Author : Mudassar Khan
//Article: Export GridView displaying Images from database to Word, Excel and PDF Formats
//WebSite: http://www.aspsnippets.com
/*----------------------------------------------*/

using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    public static int orgId;
protected void Page_Load(object sender, EventArgs e)
{
        
    orgId = Convert.ToInt32(Session["OrgID"]);
                if (orgId == 0)
                {
                    Response.Redirect("~/CMSHome.aspx");
                }

    if (Request.QueryString["ImageID"] != null)
    {
        string strQuery = "select FirstName, ApplicationId, Photo from tblAdmissionDetails where ApplicationId=@id";
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["ImageID"]);
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        DataTable dt = new DataTable(); 
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
        }
        catch
        {
            dt = null;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
        if (dt != null)
        {
            string phpto = dt.Rows[0]["Photo"].ToString();
            if(phpto!="")
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Photo"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["FirstName"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["FirstName"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
}
    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }
}

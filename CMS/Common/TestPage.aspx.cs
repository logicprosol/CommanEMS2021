using System;
using System.Data;
using System.Web.UI;

namespace CMS.Common
{
    public partial class TestPage : System.Web.UI.Page
    {
        public static DataSet ds;

        //CommonClass objCC = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("XMLFile.xml"));
                BindCountry();
                //objCC.BindCountry();
            }
        }

        public void BindCountry()
        {
            DdlCountry.DataTextField = "name";
            DdlCountry.DataValueField = "id";
            DdlCountry.DataSource = ds.Tables["Country"];
            DdlCountry.DataBind();
            BindState(DdlCountry.SelectedValue);
        }

        public void BindState(string cid)
        {
            DdlState.DataTextField = "name";
            DdlState.DataValueField = "id";
            DataView dv = new DataView(ds.Tables["State"]);
            dv.RowFilter = "cid = " + cid;
            DdlState.DataSource = dv.ToTable();
            DdlState.DataBind();
            BindCity(DdlState.SelectedValue);
        }

        public void BindCity(string sid)
        {
            DdlCity.DataTextField = "name";
            DdlCity.DataValueField = "id";
            DataView dv = new DataView(ds.Tables["City"]);
            dv.RowFilter = "sid = " + sid;
            DdlCity.DataSource = dv.ToTable();
            DdlCity.DataBind();
        }

        protected void DdlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState(DdlCountry.SelectedValue);
        }

        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity(DdlState.SelectedValue);
        }

        protected void chkSameasAbove_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
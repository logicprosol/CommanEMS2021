using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;

namespace CMS.Handler
{
    /// <summary>
    /// Summary description for Image_Handler
    /// </summary>
    public class Image_Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            try
            {

                College_Logo(context);
                
            }
            catch (Exception exp)
            {
               // throw exp;
            }
        }

        private void College_Logo(HttpContext context)
        {
            
            int OrgID = Convert.ToInt32(context.Request.QueryString["OrgID"]);
            BindControl ObjBind = new BindControl();
            DataSet ds = new DataSet();
            string[] parmaList = new string[4];
            parmaList[0] = "@Action";
            parmaList[1] = "GetCollegeLogo";
            parmaList[2] = "@OrgID";
            parmaList[3] = Convert.ToString(OrgID);
            ds = ObjBind.FillControl(parmaList, "SelectCollegeImage");
            context.Response.BinaryWrite((Byte[])ds.Tables[0].Rows[0][0]);            
            context.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
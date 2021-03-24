using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

namespace BusinessAccessLayer.Admin
{
    public class BL_SendSMS
    {

        // Bind Courses BindClass_BL
        #region[Bind Courses]

        public DataSet BindCourses_BL(EWA_SendSMS objEWA)
        {
            try
            {
                DL_SendSMS objDL = new DL_SendSMS();
                DataSet ds = objDL.BindCourses_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion
    }
}

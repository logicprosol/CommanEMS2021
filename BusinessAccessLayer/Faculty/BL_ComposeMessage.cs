using System.Data;
using DataAccessLayer.Faculty;
using System;

//Faculty
namespace BusinessAccessLayer.Faculty
{
    public class BL_ComposeMessage
    {
        //Bind Grid Data
        #region[Bind Grid Data]
        public DataSet BindGridData_BL(EntityWebApp.Faculty.EWA_ComposeMessage ObjEWA)
        {
            try
            {
                DataSet ds;
                DL_ComposeMessage ObjDL = new DL_ComposeMessage();
                ds = ObjDL.BindGridData_DL(ObjEWA);
                return ds;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
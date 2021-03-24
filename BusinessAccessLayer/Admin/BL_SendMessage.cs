using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Send Message
namespace BusinessAccessLayer.Admin
{
    public class BL_SendMessage
    {
        //Objects
        #region[Objects]
        private DL_SendMessage objDL = new DL_SendMessage();
        #endregion

        //To Bind EmployeeGridBind
        #region[Employee Grid Bind]

        public DataSet EmployeeGridBind_BL(EWA_SendMessage objEWA)
        {
            try
            {
                DataSet ds = objDL.BindEmployeeGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //To Bind StudentGridBind
        #region[Student Grid Bind]

        public DataSet StudentGridBind_BL(EWA_SendMessage objEWA)
        {
            try
            {
                DataSet ds = objDL.BindStudentGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion

        //To Bind ParentGridBind
        #region[Parent Grid Bind]

        public DataSet ParentGridBind_BL(EWA_SendMessage objEWA)
        {
            try
            {
                DataSet ds = objDL.BindParentGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
            }
        }

        #endregion
    }
}
using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Subjets
namespace BusinessAccessLayer.Admin
{
    public class BL_Subject
    {
        //Objetcs
        #region[Objects]
        private DL_Subject objDL = new DL_Subject();
        #endregion

        //Insert Update Delete operaeion on Subject Table
        #region[Action Performed For Subject]

        public int SubjectAction_BL(EWA_Subject objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                int flag = objDL.SubjectAction_DL(objEWA);
                return flag;
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

        //To Call Subjects Grid Bind
        #region[Subjects Grid Bind]

        public System.Data.DataSet SubjectGridBind_BL(EWA_Subject objEWA)
        {
            try
            {
                DL_Subject objDL = new DL_Subject();
                DataSet ds = objDL.BindSubjectGrid_DL(objEWA);
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
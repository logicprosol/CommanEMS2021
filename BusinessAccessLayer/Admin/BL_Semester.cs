using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Semester
namespace BusinessAccessLayer.Admin
{
    public class BL_Semester
    {
        //Objects
        #region[Objects]
        private DL_Semester objDL = new DL_Semester();
        #endregion

        //Insert Update Delete operaeion on Subject Table
        #region[Action Performed For Semester]

        public int SemesterAction_BL(EWA_Semester objEWA)
        {
            try
            {
                int flag = objDL.SemesterAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call Semester Grid Bind
        #region[Semester Grid Bind]

        public System.Data.DataSet SemesterGridBind_BL(EWA_Semester objEWA)
        {
            try
            {
                DL_Semester objDL = new DL_Semester();
                DataSet ds = objDL.BindSemesterGrid_DL(objEWA);
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

        //To Check Duplicate Data Of Patterns
        #region[Check Duplicate Patterns]

        public int CheckDuplicatePatterns_BL(EWA_Semester objEWA)
        {
            try
            {
                DL_Semester objDL = new DL_Semester();
                int i = objDL.CheckDuplicatePatterns_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
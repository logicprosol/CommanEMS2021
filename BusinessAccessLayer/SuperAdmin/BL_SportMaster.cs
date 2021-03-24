using System;
using System.Data;
using DataAccessLayer.SuperAdmin;
using EntityWebApp.SuperAdmin;

//Sport
namespace BusinessAccessLayer.SuperAdmin
{
    public class BL_SportMaster
    {
        //ActionPerformed For Sport
        #region [ActionPerformed For Department]

        public int SportAction_BL(EWA_SportMaster objEWA)
        {
            //  DL_Documents objDL = new DL_Documents();
            try
            {
                DL_SportMaster objDL = new DL_SportMaster();
                int flag = objDL.SportAction_DL(objEWA);

                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call DepartmentGridBind
        #region [Department Grid Bind]

        public DataSet SportGridBind_BL()
        {
            try
            {
                DL_SportMaster objDL = new DL_SportMaster();
                DataSet ds = objDL.BindSportGrid_DL();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Check Duplicate for sport
        #region[Check Duplicate sport]

        public int CheckDuplicateSport_BL(EWA_SportMaster objEWA)
        {
            try
            {
                DL_SportMaster objDL = new DL_SportMaster();
                int i = objDL.CheckDuplicateSport_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Department
        #region[Bind Department]

        public DataSet BindSport_BL(int OrgId)
        {
            try
            {
                DL_SportMaster objDL = new DL_SportMaster();
                DataSet ds = objDL.BindDepartment_DL(OrgId);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
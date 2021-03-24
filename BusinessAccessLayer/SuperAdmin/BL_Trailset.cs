using DataAccessLayer.SuperAdmin;
using EntityWebApp.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.SuperAdmin
{
    public class BL_Trailset
    {
        //To Call Country Grid Bind
        #region[Country Grid Bind]

        public DataSet Bind_DDLOrganization_BL(EWA_Trailset objEWA)
        {
            try
            {
                DL_Trailset objDL = new DL_Trailset();
                DataSet ds = objDL.Bind_DDLOrganization_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To CheckOrganization
        #region[Check Organization]

        public int CheckOrganization_BL(EWA_Trailset objEWA)
        {
            try
            {
                DL_Trailset objDL = new DL_Trailset();
                int ds = objDL.CheckOrganization_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Bind Grd
        #region[Bind Grd]

        public int TrailsetAction_BL(EWA_Trailset objEWA)
        {
            try
            {
                DL_Trailset objDL = new DL_Trailset();
                int ds = objDL.TrailsetAction_DL(objEWA);
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

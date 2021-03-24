using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Inventory;
using EntityWebApp.Inventory;

namespace BusinessAccessLayer.Inventory
{
    public class BL_Unit
    {
        //Objects

        #region [Objects]

        private DL_Unit objDL = new DL_Unit();

        #endregion [Objects]

        //Action Performed
        #region[ActionPerformed For ItemUnit]

        public int UnitAction_BL(EWA_Unit objEWA)
        {

            try
            {
                DL_Unit objDL = new DL_Unit();
                int flag = objDL.UnitAction_DL(objEWA);
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }
           
        }

        #endregion

        //Item UnitGrid Bind
        #region[Item UnitGrid Bind]

        public DataSet UnitGridBind_BL(EWA_Unit objEWA)
        {
            try
            {
                DL_Unit objDL = new DL_Unit();
                DataSet ds = objDL.BindUnitGrid_DL(objEWA);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        #endregion

        //Check Duplicate  Item Unit
        #region[Check Duplicate Item Unit]

        public int CheckDuplicateUnit_BL(EWA_Unit objEWA)
        {
            try
            {
                DL_Unit objDL = new DL_Unit();
                int i = objDL.CheckDuplicateUnit_DL(objEWA);
                return i;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion
    }
}

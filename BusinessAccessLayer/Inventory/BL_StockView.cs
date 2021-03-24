using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Inventory;

namespace BusinessAccessLayer.Inventory
{
    public class BL_StockView
    {
        //Item Grid Bind
        #region[Item Grid Bind]

        public DataSet BindItemGrid_BL()
        {
            try
            {
                DL_StockView objDL = new DL_StockView();
                DataSet ds = objDL.BindItemGrid_DL();
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

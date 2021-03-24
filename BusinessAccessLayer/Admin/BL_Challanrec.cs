using BusinessAccessLayer.Admin;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Admin
{
    public class BL_Challanrecord
    {
        DL_Challanrecord objDL = new DL_Challanrecord();
        public DataSet BL_Challanrec(EWA_Challanrecord objEWA)
        {
            try
            {
                return objDL.DL_Challan(objEWA);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet BL_ChallanByadmin(EWA_Challanrecord objEWA)
        {
            try
            {
                return objDL.DL_ChallanByadmin(objEWA);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet BL_ChallanBySearchRep(EWA_Challanrecord objEWA)
        {
            try
            {
                return objDL.DL_ChallanBySearchRep(objEWA);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

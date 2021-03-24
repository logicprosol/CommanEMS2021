using DataAccessLayer.HR;
using EntityWebApp.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.HR
{
  public class BL_ChallanRecAdmin
    {
        DL_ChallanRecAdmin objDL = new DL_ChallanRecAdmin();
        public DataSet BL_ChallanRecAdminhr(EWA_ChallanRecAdmin objEWA)
        {
            try
            {
                return objDL.DL_ChallanByAdmin(objEWA);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet BL_Challanhr(EWA_ChallanRecAdmin objEWA)
        {
            try
            {
                return objDL.DL_ChallanByHr(objEWA);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet BL_ChallanBySearchRep(EWA_ChallanRecAdmin objEWA)
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

using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;
using EntityWebApp;

namespace BusinessAccessLayer.Admin
{
    public class BL_TimeTableCreation
    {
        DL_TimeTableCreation objDL = new DL_TimeTableCreation();

        public int TimeTableCreationAction_BL(EWA_TimeTableCreation objEWA)
        {
            try
            {
                int flag = objDL.TimeTableCreationAction_DL(objEWA);
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }


        public DataSet Employeetest(EWA_TimeTableCreation objEWA2)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.CheckEmployeeExists(objEWA2);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }






        public DataSet GetDays()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.GetDays();
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }

        public DataSet GetTimeSlot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.GetTimeSlot();
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }

        public DataSet GetEmpSub(EWA_TimeTableCreation objEWA)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.GetEmpSub(objEWA);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }


        public DataSet GetTimeTable(EWA_TimeTableCreation objEWA)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.GetTimeTable(objEWA);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDL = null;
            }
        }

        public DataSet CheckTimeTable(EWA_TimeTableCreation objEWA)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.CheckTimeTable(objEWA);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDL = null;
            }

        }


        public DataSet CheckTimeTable1(EWA_TimeTableCreation objEWA)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objDL.CheckTimeTable1(objEWA);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDL = null;
            }

        }




    }
}

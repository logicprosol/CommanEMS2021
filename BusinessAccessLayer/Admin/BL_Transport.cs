using System;
using System.Data;
using DataAccessLayer.Admin;
using EntityWebApp.Admin;

//Transport
namespace BusinessAccessLayer.Admin
{
    public class BL_Transport
    {
        #region[Objects]
        private DL_Transport objDL = new DL_Transport();

        public DataSet ddlBoardBind_BL(EWA_Transport objEWA)
        {
            try
            {
               
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.ddlBoardBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operaeion on Route Table
        #region[Action Performed For Route]

        public int RouteAction_BL(EWA_Transport objEWA)
        {
            int flag;
            try
            {
                DL_Transport objDL = new DL_Transport();
                flag = objDL.RouteAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call RouteGridBind
        #region[Route Grid Bind]

        public DataSet RouteGridBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.BindRouteGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Check Duplicate Data Of Route
        #region[Check Duplicate Route]

        public int CheckDuplicateRoute_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                int i = objDL.CheckDuplicateRoute_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operaeion on Vehicle Table
        #region[Action Performed For Vehicle]

        public int VehicleAction_BL(EWA_Transport objEWA)
        {
            int flag;
            try
            {
                DL_Transport objDL = new DL_Transport();
                flag = objDL.VehicleAction_DL(objEWA);
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

        //To Call VehicleGridBind
        #region VehicleGridBind

        public DataSet VehicleGridBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.BindVehicleGrid_DL(objEWA);
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

        //To Check Duplicate Data Of Vehicle
        #region[Check Duplicate Vehicle]

        public int CheckDuplicateVehicle_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                int i = objDL.CheckDuplicateVehicle_DL(objEWA);
                return i;
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

        //Insert Update Delete operaeion on Board Table
        #region[My Region]

        public DataSet ddlRouteBind_BL(EWA_Transport objEWA)
        {
            try
            {
               // EWA_Transport objEWA = new EWA_Transport();
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.ddlRouteBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Action Performed For Board
        #region[ActionPerformed For Board]

        public int BoardAction_BL(EWA_Transport objEWA)
        {
            int flag;
            try
            {
                DL_Transport objDL = new DL_Transport();
                flag = objDL.BoardAction_DL(objEWA);
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

        //To Call Board Grid Bind
        #region[Board Grid Bind]

        public DataSet BoardGridBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.BindBoardGrid_DL(objEWA);
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

        //To Check Duplicate Data Of Board
        #region[Check Duplicate Board]

        public int CheckDuplicateBoard_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                int i = objDL.CheckDuplicateBoard_DL(objEWA);
                return i;
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

        //Insert Update Delete operaeion on DriverInfo Table
        #region[Action Performed For Driver Info]

        public int DriverInfoAction_BL(EWA_Transport objEWA)
        {
            int flag;
            try
            {
                DL_Transport objDL = new DL_Transport();
                flag = objDL.DriverInfoAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Call Driver Info Grid Bind
        #region[Driver Info Grid Bind]

        public DataSet DriverInfoGridBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.BindDriverInfoGrid_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //To Check Duplicate Data Of DriverInfo
        #region[Check Duplicate Driver Info]

        public int CheckDuplicateDriverInfo_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                int i = objDL.CheckDuplicateDriverInfo_DL(objEWA);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //No Implementation
        #region[No Implementation]

        public int Action_BL(EWA_Transport objEWA)
        {
            throw new NotImplementedException();
        }

        public int CheckDuplicateVehical_BL(EWA_Transport objEWA)
        {
            throw new NotImplementedException();
        }

        #endregion

        //AllotDriverToBus_BL
        #region[Allot Driver To Bus]

        public DataSet ddlDriverBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.ddlDriverBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Vehicle Bind Data
        #region[Vehicle Bind Data]

        public DataSet ddlVehicleBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.ddlVehicleBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert Update Delete operaeion on DriverInfo Table
        public int AllotDriverAction_BL(EWA_Transport objEWA)
        {
            int flag;
            try
            {
                DL_Transport objDL = new DL_Transport();
                flag = objDL.AllotDriverAction_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public DataSet AllotDriverGridBind_BL(EWA_Transport objEWA)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                DataSet ds = objDL.AllotDriverGridBind_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        //Insert Delete operaeion on Assign Route For Student 
        public void AssignRouteAction_BL(EWA_Transport objEWA, string[] UserCode)
        {
            try
            {
                DL_Transport objDL = new DL_Transport();
                objDL.AssignRouteAction_DL(objEWA, UserCode);
                
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
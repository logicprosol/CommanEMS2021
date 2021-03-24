using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Admin;

//Transport
namespace DataAccessLayer.Admin
{
    public class DL_Transport
    {
        //Objects

        #region DeclareObjects

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();

        #endregion DeclareObjects

        //To Perform Insert,Update,Delete and Search Actions On RoutsInfo Table
        #region[Perform Actions On Route]

        public int RouteAction_DL(EWA_Transport objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Route", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@RouteId", objEWA.RouteId);
                cmd.Parameters.AddWithValue("@Route", objEWA.Route);
                cmd.Parameters.AddWithValue("@RouteTitle", objEWA.RouteTitle);
                cmd.Parameters.AddWithValue("@Amount", objEWA.Amount);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        #endregion

        //To Bind RouteGrid
        #region[Bind Route Grid]

        public DataSet BindRouteGrid_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";

                prmList[2] = "@orgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Route");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RouteId");
                    dt.Columns.Add("Route");
                    dt.Columns.Add("RouteTitle");
                    dt.Columns.Add("Amount");

                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Check Duplicate Route
        #region[Check Duplicate Route]

        public int CheckDuplicateRoute_DL(EWA_Transport objEWA)
        {
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@Route";
                prmList[3] = objEWA.@Route;

                prmList[4] = "@orgId";
                prmList[5] = Convert.ToString(objEWA.OrgId);

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Route");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Board Table
        #region[Route Bind]

        public DataSet ddlRouteBind_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchRoutes";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Board");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //Perform Action on Board
        #region[Perform Actions On Board]

        public int BoardAction_DL(EWA_Transport objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Board", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", objEWA.ActionB);
                cmd.Parameters.AddWithValue("@BoardId", objEWA.BoardId);
                cmd.Parameters.AddWithValue("@RouteId", objEWA.RouteId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@BoardTitle", objEWA.BoardTitle);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        #endregion

        //To Bind BoardGrid
        #region[Bind Board Grid]

        public DataSet BindBoardGrid_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2]="@OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Board");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BoardId");
                    dt.Columns.Add("RouteId");
                    dt.Columns.Add("BoardTitle");
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Check Duplicate Board
        public int CheckDuplicateBoard_DL(EWA_Transport objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@BoardTitle";
                prmList[3] = objEWA.BoardTitle;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Board");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                //GeneralErr(exp.Message.ToString());
                throw;
                //return 1;
            }
        }

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Vehicle Table
        #region[ddl Board Bind]

        public DataSet ddlBoardBind_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchBoard";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Vehicle");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Performs Actions On Vehicle
        #region[Perform Actions On Vehicle]

        public int VehicleAction_DL(EWA_Transport objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_Vehicle", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@VehicleId", objEWA.VehicleId);
                cmd.Parameters.AddWithValue("@VehicleType", objEWA.VehicleType);
                cmd.Parameters.AddWithValue("@VehicleNumber", objEWA.VehicleNumber);
                cmd.Parameters.AddWithValue("@VehicleModel", objEWA.VehicleModel);
                cmd.Parameters.AddWithValue("@VehicleCapacity", objEWA.VehicleCapacity);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@BoardId", objEWA.BoardId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        #endregion

        //To Bind VehicleGrid
        #region[Bind Vehicle Grid]

        public DataSet BindVehicleGrid_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_Vehicle");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("VehicleId");
                    dt.Columns.Add("VehicleType");
                    dt.Columns.Add("VehicleNumber");
                    dt.Columns.Add("VehicleModel");
                    dt.Columns.Add("VehicleCapacity");
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    //return dsCode;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Check Duplicates
        #region[Check Duplicate Record]

        public int CheckDuplicateVehicle_DL(EWA_Transport objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@VehicleNumber";
                prmList[3] = objEWA.@VehicleNumber;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_Vehicle");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On DriverInfo Table
        #region[Perform Actions On Driver Info]

        public int DriverInfoAction_DL(EWA_Transport objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_DriverInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DriverId", objEWA.DriverId);
                cmd.Parameters.AddWithValue("@Name", objEWA.Name);
                cmd.Parameters.AddWithValue("@Address", objEWA.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", objEWA.PhoneNo);
                cmd.Parameters.AddWithValue("@LicenseId", objEWA.LicenseId);
                cmd.Parameters.AddWithValue("@LicenseType", objEWA.LicenseType);
                cmd.Parameters.AddWithValue("@UploadImage", objEWA.UploadImage);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        #endregion

        //To Bind DriverInfoGrid
        #region[Bind Driver Info Grid]

        public DataSet BindDriverInfoGrid_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_DriverInfo");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DriverId");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("PhoneNo");
                    dt.Columns.Add("LicenseId");
                    dt.Columns.Add("LicenseType");
                    dt.Columns.Add("UploadImage");
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To Check Duplicate Driver Info
        #region[Check Duplicate Driver Info]

        public int CheckDuplicateDriverInfo_DL(EWA_Transport objEWA)
        {
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "CheckData";

                prmList[2] = "@LicenseId";
                prmList[3] = objEWA.@LicenseId;

                DataSet dsData = ObjHelper.FillControl(prmList, "SP_DriverInfo");
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //To Perform Insert,Update,Delete and Search Actions On Allot Table
        #region[ddl Driver Data Bind Region]

        public DataSet ddlDriverBind_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchDriver";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_DriverInfo");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Vehicle Data Bind Region
        #region[ddl Vehicle Data Bind Region]

        public DataSet ddlVehicleBind_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "FetchVehicle";
                prmList[2] = "@OrgId";
                prmList[3] = Convert.ToString(objEWA.OrgId);

                ds = ObjHelper.FillControl(prmList, "SP_Vehicle");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Perform Action On Driver Info
        #region[Perform Actions On Allot Driver Info]

        public int AllotDriverAction_DL(EWA_Transport objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_AllotDriver", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@DriverId", objEWA.DriverId);
                cmd.Parameters.AddWithValue("@VehicleId", objEWA.VehicleId);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);
                con.Open();
                int flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;
            }
            catch (Exception ex)
            {
                int err = ((System.Data.SqlClient.SqlException)(ex)).Number;
                if (err == 547 && objEWA.Action == "Delete")
                {
                    throw new SystemException("Record is in use !!!");
                }
                else
                {
                    throw ex;
                }
            }
        }

        #endregion

        //Driver Grid Bind
        #region[Driver Grid Bind]

        public DataSet AllotDriverGridBind_DL(EWA_Transport objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "SelectData";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_AllotDriver");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DriverId");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("VehicleNo");
                    dt.Rows.Add();
                    dt.Rows.Add();
                    dt.Rows.Add();
                    return ds;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion

        //Insert Delete operaeion on Assign Route For Student 
        #region[Insert Delete operaeion on Assign Route For Student ]

        public void AssignRouteAction_DL(EWA_Transport objEWA, string[] UserCode)
        {
            try
            {
                cmd = new SqlCommand("SP_Route", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                foreach (string studentIdstr in UserCode)
                {
                    DataSet ds = new DataSet();
                    if (studentIdstr != "")
                    {
                        cmd.Parameters.AddWithValue("@Action", objEWA.ActionV);
                        cmd.Parameters.AddWithValue("@RouteId", objEWA.RouteId);
                        cmd.Parameters.AddWithValue("@UserCode", studentIdstr);
                        // Added by Ashwini 30-sep-2020
                        cmd.Parameters.AddWithValue("@CourseId", objEWA.CourseId);
                        cmd.Parameters.AddWithValue("@ClassId", objEWA.ClassId);
                        cmd.Parameters.AddWithValue("@BranchID", objEWA.BranchId);
                        cmd.Parameters.AddWithValue("@AcademicYear", objEWA.AcademicYear);
                        //
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        
                        cmd.Parameters.Clear();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}
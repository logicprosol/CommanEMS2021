using System;
using System.Data;
using DataAccessLayer.Admin;

//Add this Namespaces
using EntityWebApp.Admin;

//Staff View
namespace BusinessAccessLayer.Admin
{
    public class BL_StaffView
    {
        //Objects
        #region[Objects]
        private DL_StaffView objDAL = new DL_StaffView();
        #endregion

        #region[Commented]
        //#region StaffView
        //public DataSet BL_StaffViewId(EWA_StaffView objEWA)
        //{
        //    try
        //    {
        //        DL_StaffView objDL = new DL_StaffView();
        //        DataSet ds = objDL.DL_ShowStaffViewProfile(objEWA);
        //        return ds;
        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //    }
        //}
        //#endregion

       
        public DataSet FacultyIcard_BL(EWA_StaffView objEWA)
        {
           try
            {
                DL_StaffView objDL = new DL_StaffView();
                DataSet ds = objDL.FacultyIcard_DL(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Faculty View
        #region StaffView

        public DataSet FacultyView_BL(EWA_StaffView objEWA)
        {
            try
            {
                DL_StaffView objDL = new DL_StaffView();
                DataSet ds = objDL.DL_BindFacultyData(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Delete Faculty
        #region[Delete Faculty]

        public int DeleteFaculty_BL(EWA_StaffView objEWA)
        {
            try
            {
                DL_StaffView ObjDL = new DL_StaffView();
                return ObjDL.DeleteFaculty_DL(objEWA);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        //Faculty Data
        #region StaffView

        public DataSet BL_ViewFacultyData(EWA_StaffView objEWA)
        {
            try
            {
                DL_StaffView objDL = new DL_StaffView();
                DataSet ds = objDL.DL_FacultyData(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion



        #region StaffIcard 

        public DataSet BL_GetFacultyIcardData(EWA_StaffView objEWA)
        {
            try
            {
                DL_StaffView objDL = new DL_StaffView();
                DataSet ds = objDL.DL_GetFacultyIcardData(objEWA);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region[Commented]
        //#region Editing record
        //public DataSet FacultyViewf_BL(EWA_StaffView objEWA)
        //{
        //    try
        //    {
        //        DL_StaffView objDL = new DL_StaffView();
        //        DataSet ds = objDL.DL_ShowStaffViewProfilef(objEWA);
        //        return ds;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }
        //}
        //#endregion

        //#region Editing record
        //public DataSet BL_StaffViewIdf(EWA_StaffView objEWA)
        //{
        //    try
        //    {
        //        DL_StaffView objDL = new DL_StaffView();
        //        DataSet ds = objDL.FacultyIcardf_DL(objEWA);
        //        return ds;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //}
        //#endregion
        #endregion

        //Update Faculty
        #region Editing record

        public int BL_UpdateFaculty(EWA_StaffView objEWA)
        {
            try
            {
                DL_StaffView objDL = new DL_StaffView();
                int flag = 0;// = objDL.UpdateFaculty_DL(objEWA);
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Bind Faculty GrdId Grd_BL
        //#region Bind Faculty GrdId
        //public DataSet FacultyIcard_BL(EWA_StaffView objEWA)
        //{
        //    DL_StaffView objDAL = new DL_StaffView();
        //    DataSet ds = objDAL.FacultyIcard_DL(objEWA);
        //    return ds;
        //}
        //#endregion


    }
}
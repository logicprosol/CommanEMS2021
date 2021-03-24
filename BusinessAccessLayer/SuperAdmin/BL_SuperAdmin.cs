using System;
using System.Data;
using DataAccessLayer;
using EntityWebApp;

//Super Admin BAL
namespace BusinessAccessLayer
{
    public class BL_SuperAdmin
    {
        //Get org Id

        #region [Get Organization ID]

        public int Get_orgID()
        {
            try
            {
                DL_SuperAdmin dcls1 = new DL_SuperAdmin();
                int orgID = dcls1.Get_OrgID();

                return orgID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Get Organization ID]

        //Add college to dropdown
        #region[Add College To dropdown]

        public DataSet AddCollegeToDropDown()
        {
            try
            {
                DL_SuperAdmin objDL = new DL_SuperAdmin();
                DataSet ds = objDL.AddCollegeToDropDown();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Get Org Code
        #region[Get Org Code]

        public int Get_orgCode()
        {
            try
            {
                DL_SuperAdmin dcls1 = new DL_SuperAdmin();
                int orgCode = dcls1.Get_OrgID();

                return orgCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Insert College Registration
        #region[Insert College Registration]

        public void insertNew_College_RegistrationBLL(EWA_SuperAdmin objEWA)
        {
            DL_SuperAdmin objDL = new DL_SuperAdmin();
            try
            {
                objDL.insertNew_College_RegistrationDLL(objEWA);
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

        //Update College Data
        #region[Update College Data]

        public void Update_College_Data(EWA_SuperAdmin objEWA)
        {
            DL_SuperAdmin objDL = new DL_SuperAdmin();
            try
            {
                objDL.Update_College_Data(objEWA);
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

        //Get Org Details
        #region[get Org Details]

        public DataSet Get_OrganizationDetails(int orgID)
        {
            try
            {
                DL_SuperAdmin objDL = new DL_SuperAdmin();
                DataSet ds = objDL.Get_OrganizationDetails(orgID);
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
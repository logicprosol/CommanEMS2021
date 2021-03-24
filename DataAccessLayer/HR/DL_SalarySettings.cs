using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntityWebApp.HR;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

namespace DataAccessLayer.HR
{
    public class DL_SalarySettings
    {
        //Objects
        #region[Declare Objects]
        EWA_SalarySettings objEWA = new EWA_SalarySettings();
        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;

        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        #endregion

        public int SalaryContents_DL(EWA_SalarySettings objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SalarySettings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@PayGrpID", objEWA.PayGrpID);
                cmd.Parameters.AddWithValue("@PayGrpName", objEWA.PayGrpName);
                cmd.Parameters.AddWithValue("@BasicSalary", objEWA.BasicSalary); 
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);        
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        public DataSet DL_BindPayGroup(EWA_SalarySettings objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = "Select";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_SalarySettings");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Salary Heads And Settings

        #region SalaryHeads

        public int SalaryHeads_DL(EWA_SalarySettings objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SalarySettings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
               cmd.Parameters.AddWithValue("@PayGrpContentID", objEWA.PayGrpContentID);
                cmd.Parameters.AddWithValue("@PayGrpID", objEWA.PayGrpID);
                cmd.Parameters.AddWithValue("@CategoryName", objEWA.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryValue", objEWA.CategoryValue);
                cmd.Parameters.AddWithValue("@ValueType", objEWA.ValueType);
                //cmd.Parameters.AddWithValue("@ValueOn", objEWA.ValueOn);
                cmd.Parameters.AddWithValue("@ContentAction", objEWA.ContentAction);
                cmd.Parameters.AddWithValue("@BasicSalary", objEWA.BasicSalary);


                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        public DataSet DL_BindSalaryHeads(EWA_SalarySettings objEWA)
        {
            DataSet ds = null;
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "SalarySettingsSelect";
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@PayGrpID";
                prmList[5] = objEWA.PayGrpID.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_SalarySettings");
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

        public DataSet DL_BindEmployeeList(EWA_SalarySettings objEWA)
        {
            DataSet ds = null;
            try
            {
                //dff
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@PayGrpID";
                prmList[5] = objEWA.PayGrpID.ToString();

                ds = ObjHelper.FillControl(prmList, "SP_SalarySettings");
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



        public int DL_UpdatePayScale(EWA_SalarySettings objEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SalarySettings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);            
                cmd.Parameters.AddWithValue("@PayGrpID", objEWA.PayGrpID);                
                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserId", objEWA.UserId);
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

        public DataSet DL_GetSalarySettings(EWA_SalarySettings objEWA)
        {
            DataSet ds = null;
            try
            {
                //dff
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId.ToString();
                prmList[4] = "@PayGrpID";
                prmList[5] = objEWA.PayGrpID.ToString();
                prmList[6] = "@UserCode";
                prmList[7] = objEWA.UserCode;
                prmList[8] = "@SalaryMonth";
                prmList[9] = objEWA.SalaryMonth;
                prmList[10] = "@PostedMonth";
                prmList[11] = objEWA.PostedMonth;

                ds = ObjHelper.FillControl(prmList, "SP_SalarySettings");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    return ds;
                //}
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        // Save Salary Sleep   pagefd   \
        //

        public int DL_SaveSalarySlip(EWA_SalarySettings objEWA, DataTable Earnings)
        {
            try
            {
                cmd = new SqlCommand("SP_SalarySettings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", objEWA.Action);
                cmd.Parameters.AddWithValue("@UserCode", objEWA.UserCode);

                
                cmd.Parameters.AddWithValue("@EmployeeName", objEWA.EmployeeName);

                cmd.Parameters.AddWithValue("@Department", objEWA.Department);
                cmd.Parameters.AddWithValue("@Designation", objEWA.Designation);  
                cmd.Parameters.AddWithValue("@SalaryMonth", objEWA.SalaryMonth);
                cmd.Parameters.AddWithValue("@BasicSalary", objEWA.BasicSalary);
                cmd.Parameters.AddWithValue("@GorssSalary", objEWA.GorssSalary);
                cmd.Parameters.AddWithValue("@TotalDeduction", objEWA.TotalDeduction);
                cmd.Parameters.AddWithValue("@LeaveDeduction", objEWA.LeaveDeduction);
                //cmd.Parameters.AddWithValue("@GorssSalary", objEWA.GorssSalary);
                cmd.Parameters.AddWithValue("@NetSalary", objEWA.NetSalary);
                cmd.Parameters.AddWithValue("@AcademicYearId", objEWA.AcademicYearId);

                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue("@IsActive", objEWA.IsActive);


                //SqlParameter tblvaluetype = cmd.Parameters.AddWithValue("@SalaryContents", Earnings);  //Passing table value parameter
                //tblvaluetype.SqlDbType = SqlDbType.Structured;

              

                con.Open();
                int flag =Convert.ToInt32( cmd.ExecuteScalar().ToString());
                con.Close();
                return flag;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        private string SendPushNotification(string _deviceId, string _body, string _title, string SenderId, string AppKey)
        {
            string response;

            try
            {
                // From: https://console.firebase.google.com/project/x.y.z/settings/general/android:x.y.z

                // Projekt-ID: x.y.z
                // Web-API-Key: A...Y (39 chars)
                // App-ID: 1:...:android:...

                // From https://console.firebase.google.com/project/x.y.z/settings/
                // cloudmessaging/android:x,y,z
                // Server-Key: AAAA0...    ...._4

                string serverKey = AppKey; // Something very long
                string senderId = SenderId;
                string deviceId = _deviceId; // Also something very long, 
                                             // got from android
                                             //string deviceId = "//topics/all";             // Use this to notify all devices, 
                                             // but App must be subscribed to 
                                             // topic notification
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = _body,
                        title = _title,
                        sound = "Enabled",
                        click_action = "6"
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
        public DataSet DL_SaveSalaryContent(EWA_SalarySettings objEWA)
        {
            DataSet dss = new DataSet();
            try
            {
               
                cmd = new SqlCommand("SP_SalarySettings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "Get_TrialSetValues");
                cmd.Parameters.AddWithValue("@SalarySleepID", objEWA.SalarySleepID);
                
                cmd.Parameters.AddWithValue("@CategoryName", objEWA.CategoryName);

                cmd.Parameters.AddWithValue("@ContentValue1", objEWA.ContentValue);

                cmd.Parameters.AddWithValue("@ContentAction", objEWA.ContentAction);
               
                cmd.Parameters.AddWithValue("@OrgId", objEWA.OrgId);
              
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dss);
                con.Close();
                return dss; 
                
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        // Bind Salary Slip Report
        #region[Salary Slip Report]
        public DataSet BindSalarySlipReport(EWA_SalarySettings objEWA)

        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "PrintPaySlip";
                prmList[2] = "@UserCode";
                prmList[3] = objEWA.UserCode;
                prmList[4] = "@SalaryMonth";
                prmList[5] = objEWA.SalaryMonth;

                ds = ObjHelper.FillControl(prmList, "SP_SalarySettings");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

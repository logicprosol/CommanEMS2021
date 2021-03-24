using EntityWebApp.Faculty;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace DataAccessLayer.Faculty
{
   
    public class DL_UploadResult
    {
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private string[] prmList = null;
        private BindControl ObjHelper = new BindControl();

        #region[Bind UploadTest]

        public int InsertUploadTest_DL(EWA_UploadResult objEWA)
        {
            int flag = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UploadResult", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objEWA.Action);
                cmd.Parameters.AddWithValue(@"TestName", objEWA.TestName);
                cmd.Parameters.AddWithValue(@"CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue(@"BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue(@"ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue(@"SemesterId", objEWA.SemesterId);
                cmd.Parameters.AddWithValue(@"OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue(@"TotalMark", objEWA.TotalMark);
                cmd.Parameters.AddWithValue(@"Status", objEWA.Status);

                flag = cmd.ExecuteNonQuery();

                return flag;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region[Bind UploadResult]

        public int InsertUploadResult_DL(EWA_UploadResult objEWA)
        {
            int flag = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UploadResult", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objEWA.Action);
                cmd.Parameters.AddWithValue(@"TestId", objEWA.TestId);
                cmd.Parameters.AddWithValue(@"UserCode", objEWA.UserCode);
                cmd.Parameters.AddWithValue(@"Result", objEWA.Result);

                flag = cmd.ExecuteNonQuery();

                return flag;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region[Bind UploadMark]

        public int InsertUploadMark_DL(EWA_UploadResult objEWA)
        {
            int flag = 0;
            try
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("SP_UploadResult", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objEWA.Action);
                cmd.Parameters.AddWithValue(@"ResultId", objEWA.ResultId);
                cmd.Parameters.AddWithValue(@"SubjectId", objEWA.SubjectId);
                cmd.Parameters.AddWithValue(@"Mark", objEWA.Mark);
                cmd.Parameters.AddWithValue(@"OutofMark", objEWA.Outofmark);

                flag = cmd.ExecuteNonQuery();
                
                return flag;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        // Fatch Student
        #region[Fatch Student]

        public DataSet FatchStudent_DL(EWA_UploadResult ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchStudent";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@UserCode";
                prmList[5] = ObjEWA.UserCode;

                ds = ObjHelper.FillControl(prmList, "SP_UploadResult");
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

        // Fatch Test
        #region[Fatch Test]

        public DataSet FatchTest_DL(EWA_UploadResult ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = "FetchTest";
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                prmList[10] = "@SemesterId";
                prmList[11] = ObjEWA.SemesterId;


                ds = ObjHelper.FillControl(prmList, "SP_UploadResult");
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

        // Fatch Result
        #region[Fatch Result]

        public DataSet FatchResult_DL(EWA_UploadResult ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[6];
                prmList[0] = "@Action";
                prmList[1] = "FetchResult";
                prmList[2] = "@TestId";
                prmList[3] = ObjEWA.TestId;
                prmList[4] = "@UserCode";
                prmList[5] = ObjEWA.UserCode;


                ds = ObjHelper.FillControl(prmList, "SP_UploadResult");
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
                        click_action = "4"
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
        #region[Bind UploadResult]

        public int InsertUploadResultPDF_DL(EWA_UploadResult objEWA)
        {
            DataSet dss = new DataSet();
            int flag = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UploadResult", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objEWA.Action);
                cmd.Parameters.AddWithValue(@"TestName", objEWA.TestName);
                cmd.Parameters.AddWithValue(@"OrgId", objEWA.OrgId);
                cmd.Parameters.AddWithValue(@"CourseId", objEWA.CourseId);
                cmd.Parameters.AddWithValue(@"BranchId", objEWA.BranchId);
                cmd.Parameters.AddWithValue(@"ClassId", objEWA.ClassId);
                cmd.Parameters.AddWithValue(@"AcademinYear", objEWA.AcademinYear);
                cmd.Parameters.AddWithValue(@"FileName", objEWA.FileName);
                cmd.Parameters.AddWithValue(@"ContentType", objEWA.ContentType);
                cmd.Parameters.AddWithValue(@"UploadedFile", objEWA.UploadedFile);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dss);
                con.Close();

                if (dss.Tables[0].Rows.Count > 0)
                {
                    int i = 0;
                    while (dss.Tables[0].Rows.Count > i)
                    {
                        if (dss.Tables[0].Rows[i]["TokenId"].ToString() != "" && dss.Tables[0].Rows[i]["TokenId"].ToString() != "null" && dss.Tables[1].Rows[0]["SenderId"].ToString() != "")
                        {
                            SendPushNotification(dss.Tables[0].Rows[i]["TokenId"].ToString(), dss.Tables[0].Rows[i]["Subject"].ToString(), dss.Tables[0].Rows[i]["OrgName"].ToString(), dss.Tables[1].Rows[0]["SenderId"].ToString(), dss.Tables[1].Rows[0]["AppKey"].ToString());
                        }
                        i++;
                    }
                }

                return 1;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        // Fatch ResultPDF
        #region[Fatch ResultPDF]

        public DataSet FatchResultPDF_DL(EWA_UploadResult ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[10];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;


                ds = ObjHelper.FillControl(prmList, "SP_UploadResult");
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
        public DataSet FatchResultPDF_DL1(EWA_UploadResult ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[12];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = ObjEWA.OrgId;
                prmList[4] = "@CourseId";
                prmList[5] = ObjEWA.CourseId;
                prmList[6] = "@BranchId";
                prmList[7] = ObjEWA.BranchId;
                prmList[8] = "@ClassId";
                prmList[9] = ObjEWA.ClassId;
                prmList[10] = "@AcademinYear";
                prmList[11] = ObjEWA.AcademinYear;

                ds = ObjHelper.FillControl(prmList, "SP_UploadResult");
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

        #region[Delete UploadResult]

        public int DeleteUploadResultPDF_DL(EWA_UploadResult objEWA)
        {
            int flag = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UploadResult", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"Action", objEWA.Action);
                cmd.Parameters.AddWithValue(@"TestId", objEWA.TestId);

                flag = cmd.ExecuteNonQuery();

                return flag;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}

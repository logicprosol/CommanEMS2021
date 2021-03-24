using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using EntityWebApp.Faculty;

//Upload Document
namespace DataAccessLayer.Faculty
{
    public class DL_UploadDocument
    {
        //Objects
        #region[Objects]
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());
        private SqlCommand cmd = null;


        //SqlTransaction sqlTransaction;
        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        private DataSet ds = null;
        #endregion

        //Student Bind
        #region[Student Bind]

        public DataSet StudentBind_DL(EWA_UploadDocument ObjEWA)
        {
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
                prmList[8] = "@DivisionId";
                prmList[9] = ObjEWA.DivisionId;

                ds = ObjHelper.FillControl(prmList, "SP_UploadDocument");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                } return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Upload Documnet
        #region[Upload Document]

        public int UploadDocument_DL(EWA_UploadDocument ObjEWA)
        {
            DataSet dss = new DataSet();
            int flag = 0;
            try
            {
                cmd = new SqlCommand("SP_UploadDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@OrgId", ObjEWA.OrgId);
                cmd.Parameters.AddWithValue("@UserCode", ObjEWA.FacultyId);
                cmd.Parameters.AddWithValue("@CourseId", ObjEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", ObjEWA.BranchId);
                cmd.Parameters.AddWithValue("@ClassId", ObjEWA.ClassId);
                cmd.Parameters.AddWithValue("@Subject", ObjEWA.Subject);
                cmd.Parameters.AddWithValue("@MessageContent", ObjEWA.MessageContent);
                cmd.Parameters.AddWithValue("@ContentType", ObjEWA.ContentType);
                cmd.Parameters.AddWithValue("@FileName", ObjEWA.FileName);
                cmd.Parameters.AddWithValue("@Data", ObjEWA.Data);
                cmd.Parameters.AddWithValue("@UploadPurpose", ObjEWA.UploadPurpose);
                //cmd.Parameters.AddWithValue("@DivisionId", ObjEWA.DivisionId);
                cmd.Parameters.AddWithValue("@StudentDataTable", ObjEWA.StudentDataTable);

                con.Open();
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
            catch (Exception )
            {
                throw;
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
                        click_action = "2"
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

        public DataSet BindUploadDocument_DL(EWA_UploadDocument ObjEWA)
        {
            try
            {
                prmList = new string[4];
               // prmList[0] = "@Action";
               // prmList[1] = ObjEWA.Action;
                prmList[0] = "@StudentId";
                prmList[1] = ObjEWA.StudentId;
                prmList[2] = "@UploadPurpose";
                prmList[3] = ObjEWA.UploadPurpose.ToString();
               

                ds = ObjHelper.FillControl(prmList, "SP_UploadDocument11");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                } return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUploadDocument_DL(EWA_UploadDocument ObjEWA)
        {
            int flag;
            try
            {
                cmd = new SqlCommand("SP_UploadDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@UploadDocReceiptId", ObjEWA.UploadDocReceiptId);
                con.Open();
                flag = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
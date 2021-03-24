using System;
using System.Data;
using System.Data.SqlClient;
using EntityWebApp.Faculty;

using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Text;
//Message
namespace DataAccessLayer.Faculty
{
    public class DL_Messages
    {
        //Objects
        #region[Objects]

        //To Fetch the Connection String From Static Class ConnectionString
        private SqlConnection con = new SqlConnection(ConnectionString.consstr());

        private SqlCommand cmd = null;
        //SqlTransaction sqlTransaction;

        private string[] prmList = null;

        private BindControl ObjHelper = new BindControl();
        #endregion

        //Get Message Id
        #region[Get Message Id]

        public DataSet Get_MessageId()
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[2];
                prmList[0] = "@Action";
                prmList[1] = "GetMaxMessageId";

                ds = ObjHelper.FillControl(prmList, "SP_SendMessage");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                //GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        //Save Student Message
        #region[Save Student Message]

        public string SaveStudentMessage_DL(EWA_Messages ObjEWA)
        {
            try
            {
                string messageid = "0";
                cmd = new SqlCommand("SP_SendMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@OrgId", ObjEWA.OrgId);
                cmd.Parameters.AddWithValue("@MessageId", ObjEWA.MessageId);
                cmd.Parameters.AddWithValue("@StaffUserCode", ObjEWA.FacultyId);
                cmd.Parameters.AddWithValue("@ClassId", ObjEWA.CLassId);
                cmd.Parameters.AddWithValue("@CourseId", ObjEWA.CourseId);
                cmd.Parameters.AddWithValue("@BranchId", ObjEWA.BranchId);
                cmd.Parameters.AddWithValue("@DepartmentId", ObjEWA.DepartmentId);
                cmd.Parameters.AddWithValue("@DesignationId", ObjEWA.DesignationId);
                cmd.Parameters.AddWithValue("@Subject", ObjEWA.Subject);
                cmd.Parameters.AddWithValue("@MessageContent", ObjEWA.MessageContent);
                //cmd.Parameters.AddWithValue("@FileAttachment1", ObjEWA.AttachmentOne);
                //cmd.Parameters.AddWithValue("@FileAttachment2", ObjEWA.AttachmentTwo);
                //cmd.Parameters.AddWithValue("@FileAttachment3", ObjEWA.AttachmentThree);
                con.Open();
                messageid = cmd.ExecuteScalar().ToString();

                con.Close();
                return messageid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Send Student Message
        #region[Send Student Message]
            DataSet ds = new DataSet();
        public void SendStudentMessage_DL(EWA_Messages ObjEWA, string[] StudentUserCode)
        {
            try
            {
                DataSet ds = new DataSet();
                cmd = new SqlCommand("SP_SendMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                foreach (string studentUserCodestr in StudentUserCode)
                {
                    ds = new DataSet();
                    if (studentUserCodestr != "")
                    {
                        cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                        cmd.Parameters.AddWithValue("@MessageId", ObjEWA.MessageId);
                        cmd.Parameters.AddWithValue("@StudentUserCode", studentUserCodestr);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["TokenId"].ToString() != "")
                            {
                                if (ds.Tables[1].Rows[0]["SenderId"].ToString() != "")
                                {
                                    string click_action = "100";
                                    SendPushNotification(ds.Tables[0].Rows[0]["TokenId"].ToString(), ds.Tables[0].Rows[0]["Subject"].ToString(), ds.Tables[0].Rows[0]["OrgName"].ToString(), ds.Tables[1].Rows[0]["SenderId"].ToString(), ds.Tables[1].Rows[0]["AppKey"].ToString(), click_action);
                                }
                            }
                        }
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

         private string SendPushNotification(string _deviceId, string _body, string _title, string SenderId, string AppKey,string click_action)
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
                        click_action = click_action
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

        #endregion

        //Save Staff Message
        #region[Save Staff Message]

        public string SaveStaffMessage_DL(EWA_Messages ObjEWA)
        {
            try
            {
                string flag = "0";
                cmd = new SqlCommand("SP_SendMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@OrgId", ObjEWA.OrgId);
                cmd.Parameters.AddWithValue("@MessageId", ObjEWA.MessageId);
                cmd.Parameters.AddWithValue("@StaffUserCode", ObjEWA.FacultyId);
                cmd.Parameters.AddWithValue("@DepartmentId", ObjEWA.DepartmentId);
                cmd.Parameters.AddWithValue("@DesignationId", ObjEWA.DesignationId);
                cmd.Parameters.AddWithValue("@Subject", ObjEWA.Subject);
                cmd.Parameters.AddWithValue("@MessageContent", ObjEWA.MessageContent);
                //cmd.Parameters.AddWithValue("@FileAttachment1", ObjEWA.Data);
                //cmd.Parameters.AddWithValue("@FileAttachment2", ObjEWA.Data);
                //cmd.Parameters.AddWithValue("@FileAttachment3", ObjEWA.Data);
                con.Open();
                 flag =cmd.ExecuteScalar().ToString();

                con.Close();
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Send Staff Message
        #region[Send Staff Message]

        public void SendStaffMessage_DL(EWA_Messages ObjEWA, string[] StaffId)
        {
            try
            {
                cmd = new SqlCommand("SP_SendMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                foreach (string staffIdstr in StaffId)
                {
                    ds = new DataSet();
                    if (staffIdstr != "")
                    {
                        cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                        cmd.Parameters.AddWithValue("@MessageId", ObjEWA.MessageId);
                        cmd.Parameters.AddWithValue("@StaffUserCode", staffIdstr);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["TokenId"].ToString() != "")
                            {
                                if (ds.Tables[1].Rows[0]["SenderId"].ToString() != "")
                                {
                                    string click_action = "200";
                                    SendPushNotification(ds.Tables[0].Rows[0]["TokenId"].ToString(), ds.Tables[0].Rows[0]["Subject"].ToString(), ds.Tables[0].Rows[0]["OrgName"].ToString(), ds.Tables[1].Rows[0]["SenderId"].ToString(), ds.Tables[1].Rows[0]["AppKey"].ToString(),click_action);
                                }
                            }
                        }
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

        //Bind Grid Announcement
        #region[Bind Grid Announcement]

        public DataSet BindGrdViewAnnouncement_DL(EWA_Messages objEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[8];
                prmList[0] = "@Action";
                prmList[1] = objEWA.Action;
                prmList[2] = "@OrgId";
                prmList[3] = objEWA.OrgId;
                prmList[4] = "@StudentUserCode";
                prmList[5] = objEWA.StudentId;
                prmList[6] = "@StaffUserCode";
                prmList[7] = objEWA.FacultyId;

                ds = ObjHelper.FillControl(prmList, "SP_SendMessage");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                //GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion
        

        //Save Attachment
        #region[Save Attachment]

        public void SaveAttachment_DL(EWA_Messages ObjEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SendMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@Action", "SaveAttachment");

                cmd.Parameters.AddWithValue("@MessageId", ObjEWA.MessageId);
                cmd.Parameters.AddWithValue("@ContentType", ObjEWA.ContentType);
                cmd.Parameters.AddWithValue("@FileName", ObjEWA.FileName);
                cmd.Parameters.AddWithValue("@Data", ObjEWA.Data);
                int flag = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        //Fetch Attachment
        #region[Fetch Attchment]

        public DataSet FetchAttachment(EWA_Messages ObjEWA)
        {
            DataSet ds = new DataSet();
            try
            {
                prmList = new string[4];
                prmList[0] = "@Action";
                prmList[1] = ObjEWA.Action;
                prmList[2] = "@MessageId";
                prmList[3] = ObjEWA.MessageId;

                ds = ObjHelper.FillControl(prmList, "SP_SendMessage");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                //GeneralErr(exp.Message.ToString());
                throw;
            }
        }

        #endregion

        public void DeleteSenderDetails(EWA_Messages ObjEWA)
        {
            try
            {
                cmd = new SqlCommand("SP_SendMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@Action", ObjEWA.Action);
                cmd.Parameters.AddWithValue("@MessageId", ObjEWA.MessageId);
                cmd.Parameters.AddWithValue("@StaffUserCode", ObjEWA.SenderId);
                cmd.Parameters.AddWithValue("@StudentUserCode", ObjEWA.SenderId);
                int flag = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
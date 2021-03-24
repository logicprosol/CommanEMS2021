using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Design; 
namespace CMS.Forms.Student
{
    public partial class Start_Exam : System.Web.UI.Page
    {
        public static int orgId;
        int nextQues;
        int count = 0;
        int a=0 ;
        string pattern;
        string answer;
        string result;
        string studAnswer;
        string statu="false";
        string usercode;
        string patt;
        float count1;
        database db = new database();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                usercode = Convert.ToString(Session["UserName"]);
                string patterrn = CreateRandomPassword(1);
               
        orgId = Convert.ToInt32(Session["OrgId"]);
                        if (orgId == 0)
                        {
                            Response.Redirect("~/CMSHome.aspx");
                        }
                if (!IsPostBack)
                {
                    btnPrvious.Enabled = false;
                    btnNext.Enabled = false;
                    btnCancel.Enabled = false;
                    pnlShow.Visible = false;

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "sp_Insert_TestDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    DataSet ds = new DataSet();
                    using (cn)
                    {
                       
                        // cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Action", "Get_Subject_Details");
                        cmd.Parameters.AddWithValue("@UserName", usercode);
                        cmd.Parameters.AddWithValue("@OrgId", orgId);
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(ds);
                        }

                        
                        drpSubject.DataSource = ds.Tables[0];
                        drpSubject.DataTextField = "SubjectName";
                        drpSubject.DataValueField = "SubjectId";
                        drpSubject.DataBind();
                        drpSubject.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
              


                string a = db.getDbstatus_Value("SELECT  CL.ClassName  FROM  tblStudent AS S  INNER JOIN  tblClass AS CL ON CL.ClassId = S.ClassId WHERE S.UserCode= '" + usercode.ToString() + "' ");
                Session["class"]= a.ToString();

                //string a1 = db.getDbstatus_Value("SELECT  CL.ClassId  FROM  tblStudent AS S INNER JOIN  tblStudentClassDiv AS CD ON CD.StudentId = S.UserCode INNER JOIN  tblClass AS CL ON CL.ClassId = CD.ClassId WHERE S.UserCode= '" + usercode.ToString() + "' ");
                //Session["classId"] = a1.ToString();

                lblclass1.Text = Session["class"].ToString();


                //float count1 = db.getDb_Value(" select count(id) from tblSavePattern where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and UserCode='" + usercode.ToString() + "' ");
                //if (count1 == 0)
                //{

                //    db.cnopen();
                //    db.insert("insert into tblSavePattern values ('" + usercode.ToString() + "','" + patterrn.ToString() + "','" + Convert.ToInt32(Session["OrgId"]) + "','" + "abc" + "') ");
                
                //    db.cnclose();
                //}

                //string pattern = Convert.ToString(Session["pattern"]);
               
                


            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found')", true);

            }

           
        }
    
        protected void btnNext_Click(object sender, EventArgs e)
        {

            savedata((Convert.ToInt32(lblQuesid1.Text) + 1), "Next");
          //  btnPrvious.Enabled = true;
     }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {

            savedata((Convert.ToInt32(lblQuesid1.Text) - 1),"Previous");

           // btnNext.Enabled = true;

        }

        public void savedata(int QuestionID,string BtnStatus)
        {
            if (rdoA.Checked == true)
            {
                rdoA.Text = "Option A";
                answer = rdoA.Text;

            }
            else if (rdoB.Checked == true)
            {
                rdoB.Text = "Option B";
                answer = rdoB.Text;

            }
            else if (rdoC.Checked == true)
            {
                rdoC.Text = "Option C";
                answer = rdoC.Text;

            }
            else if (rdoD.Checked == true)
            {
                rdoD.Text = "Option D";
                answer = rdoD.Text;

            }

            if (rdoA.Checked == true || rdoB.Checked == true || rdoC.Checked == true || rdoD.Checked == true || (BtnStatus== "Previous"))
            {
                DataTable table_Result =  (DataTable) ViewState["table_Result"] as DataTable;

                if (table_Result.Rows.Count > 0)
                {
                    //if (table_Result.Rows.Contains(lblQuesid1.Text))
                    {
                        int IsFound = 0;
                        foreach (DataRow dr in table_Result.Rows)
                        {
                            string  que = dr["QuestionId"].ToString();
                            if (dr["QuestionId"].ToString() == lblQuesid1.Text)
                            {
                                dr["Answer"] = answer;
                                ViewState["table_Result"] = table_Result;
                                IsFound = 1;
                                break;
                            }

                        }
                        if(IsFound==0)
                        {
                            if(Session["UserName"]!=null && (ddlUnitTest.SelectedValue!=null || ddlUnitTest.SelectedValue!="") && lblQuesid1.Text!="" && answer!="" && Session["OrgId"]!=null)
                            table_Result.Rows.Add(Session["UserName"], ddlUnitTest.SelectedValue, lblQuesid1.Text, answer, Session["OrgId"]);
                            ViewState["table_Result"] = table_Result;
                        }
                    }
                }
                else
                {
                    table_Result.Rows.Add(Session["UserName"], ddlUnitTest.SelectedValue, lblQuesid1.Text, answer, Session["OrgId"]);
                    ViewState["table_Result"] = table_Result;
                }
                
                
                if (Convert.ToInt32(lblQuesid1.Text) <= Convert.ToInt32(ViewState["QuestionCount"]))
                {
                    ClearChckBoxes();
                    showdata(QuestionID);
                    
                }
                if (Convert.ToInt32(lblQuesid1.Text) == Convert.ToInt32(ViewState["QuestionCount"]))
                {
                    btnNext.Enabled = false;
                    btnPrvious.Enabled = true;
                    btnCancel.Enabled = true;
                }

                if (Convert.ToInt32(lblQuesid1.Text) == 1)
                {
                    btnNext.Enabled = true;
                    btnPrvious.Enabled = false;
                    btnCancel.Enabled = true;
                }
                if (Convert.ToInt32(lblQuesid1.Text) > 1 && (Convert.ToInt32(lblQuesid1.Text) != Convert.ToInt32(ViewState["QuestionCount"])))
                {
                    btnNext.Enabled = true;
                    btnPrvious.Enabled = true;
                    btnCancel.Enabled = true;
                }
                //patt = db.getDbstatus_Value("select Pattern from tblSavePattern WHERE OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "' and UserCode='" + usercode.ToString() + "'");
                //result = db.getDbstatus_Value("SELECT answer FROM  tblAddQuestion WHERE OrgId = '" + Convert.ToInt32(Session["OrgId"]) + "' AND pattern LIKE '" + patt.ToString() + "' AND queId = '" + lblQuesid1.Text + "'  ");


                //if (answer == result)
                //{
                //    statu = "TRUE";
                //}
                //else
                //{
                //    statu = "FALSE";

                //}

                //db.insert("insert into tblOnlineResult values ('" + patt.ToString() + "','" + lblQuesid1.Text + "','" + answer + "','" + Convert.ToInt32(Session["OrgId"]) + "','" + statu + "','" + usercode.ToString() + "','" + ddlUnitTest.SelectedValue.ToString() + "','" + drpSubject.Text + "')");

                //db.cnclose();
                //try
                //{
                //    //if (count1 != 0)
                //    //{
                //    float count = db.getDb_Value("select queId from tblAddQuestion where OrgId= ('" + Convert.ToInt32(Session["OrgId"]) + "' )and  (pattern like '" + patt.ToString() + "') and ( queId >'" + lblQuesid1.Text + "') and unitType=('" + ddlUnitTest.Text + "') and class=('" + Session["classId"].ToString() + "') and SubjectName=('" + drpSubject.SelectedValue.ToString() + "' )");
                //    a = Convert.ToInt32(count);

                //    float count1 = db.getDb_Value("select Max(queId) from tblAddQuestion where OrgId= ('" + Convert.ToInt32(Session["OrgId"]) + "' )and  (pattern like '" + patt.ToString() + "')  and unitType=('" + ddlUnitTest.Text + "') and class=('" + Session["classId"].ToString() + "') and SubjectName=('" + drpSubject.SelectedValue.ToString() + "' )");
                //    int max = Convert.ToInt32(count1);

                //    if (a<= max)
                //    {
                //        showdata();
                //        rdoA.Checked = false;
                //        rdoB.Checked = false;
                //        rdoC.Checked = false;
                //        rdoD.Checked = false;
                //        if (a == max)
                //        {
                //            btnNext.Enabled = false;
                //            btnCancel.Enabled = true;
                //        }

                //    }

                //    //else if (count.ToString() == lblQuesid1.Text)
                //    //{
                //    //    Response.Redirect("~/Forms/Student/abcdREsult.aspx");
                //    //}
                //    else
                //    {

                //        Response.Redirect("~/Forms/Student/abcdREsult.aspx");

                //        btnCancel.Enabled = true;
                //    }
                //    //}
                //    //else
                //    //{
                //    //    float count = db.getDb_Value(" select count(Status) from tblOnlineResult where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and pattern like '" + pattern.ToString() + "' and Status='" + "TRUE" + "' and  UserCode='" + Convert.ToString(Session["UserName"]) + "' and unitType='" + ddlUnitTest.Text + "' ");
                //    //    Response.Write("<script>alert('" + count.ToString() + "');</script>");

                //  }
                // }
                //catch (Exception ex)
                //{
                //    Response.Redirect("~/Forms/Student/abcdREsult.aspx");
                //    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Test Finished Click On Finshed for Result')", true);

                //}

            }
            else
            {
                msgBox.ShowMessage("Please Select One Answer !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Please Select One Answer')", true);

            }
        }
        private void ClearChckBoxes()
        {
            rdoA.Checked = false;
            rdoB.Checked = false;
            rdoC.Checked = false;
            rdoD.Checked = false;
        }

        public void showdata(int QuestionId)
        {
            //SqlCommand cmd = new SqlCommand("SELECT queId,question,optA,optB,optC,optD FROM  tblAddQuestion where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and  queId='" + a + "' and pattern='" + patt.ToString() + "' and unitType='" + ddlUnitTest.Text + "' and class='" + Session["classId"].ToString() + "' and SubjectName='" + drpSubject.SelectedValue.ToString()  + "'  ", cn);
            //DataSet ds = new DataSet();
            //SqlDataAdapter adp = new SqlDataAdapter();
            //adp.SelectCommand = cmd;

            SqlCommand cmd = new SqlCommand("sp_Insert_TestDetails", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"]));
            cmd.Parameters.AddWithValue("@TestId", ddlUnitTest.SelectedValue);
            cmd.Parameters.AddWithValue("@QuestionId", QuestionId);
            cmd.Parameters.AddWithValue("@SubjectId", drpSubject.SelectedValue);
            cmd.Parameters.AddWithValue("@Action", "Fetch_Questions_ByQuestionId");

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (lblQuesid1.Text == "")
                {
                    string ImgQuestion = ds.Tables[0].Rows[0]["ImgQuestion"].ToString();
                    if (ds.Tables[0].Rows[0]["IsImgQuestion"].ToString() == "True")
                    {
                        if (ImgQuestion != null && ImgQuestion != "")
                        {
                            Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["ImgQuestion"];

                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            Image1.ImageUrl = "data:image/png;base64," + base64String;
                            Image1.Visible = true;
                        }
                    }
                    else
                    {
                        Image1.Visible = false;
                    }

                    lblQuesid1.Text = ds.Tables[0].Rows[0]["QuestionId"].ToString();
                    //LBLpATTERN.Text = ds.Tables[0].Rows.Count.ToString(); //pattern.ToString();
                    lblquestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();
                    lblA.Text = ds.Tables[0].Rows[0]["optA"].ToString();
                    lblB.Text = ds.Tables[0].Rows[0]["optB"].ToString();
                    lblC.Text = ds.Tables[0].Rows[0]["optC"].ToString();
                    lblD.Text = ds.Tables[0].Rows[0]["optD"].ToString();

                    
                    if (Convert.ToInt32(lblQuesid1.Text) == Convert.ToInt32(ViewState["QuestionCount"]))
                    {
                        btnNext.Enabled = false;
                        btnPrvious.Enabled = true;
                        btnCancel.Enabled = true;
                    }

                     if (Convert.ToInt32(lblQuesid1.Text) == 1)
                    {
                        btnNext.Enabled = true;
                        btnPrvious.Enabled = false;
                        btnCancel.Enabled = true;
                    }

                    if (Convert.ToInt32(lblQuesid1.Text) > 1 && (Convert.ToInt32(lblQuesid1.Text) != Convert.ToInt32(ViewState["QuestionCount"])))
                    {
                        btnNext.Enabled = true;
                        btnPrvious.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                }
                DataTable table_Result = (DataTable)ViewState["table_Result"] as DataTable;
                if (table_Result.Rows.Count > 0)
                {
                    //if (table_Result.Rows.Contains(lblQuesid1.Text))
                    {
                        
                        foreach (DataRow dr in table_Result.Rows)
                        {
                            string que = dr["QuestionId"].ToString();
                            if (dr["QuestionId"].ToString() == QuestionId.ToString())
                            {
                                
                                if (dr["Answer"].ToString()== "Option A")
                                {
                                    rdoA.Text = "Option A";
                                    rdoA.Checked = true;

                                }
                                else if (dr["Answer"].ToString() == "Option B")
                                {
                                    rdoB.Text = "Option B";
                                    rdoB.Checked = true;

                                }
                                else if (dr["Answer"].ToString() == "Option C")
                                {
                                    rdoC.Text = "Option C";
                                    rdoC.Checked = true;

                                }
                                else if (dr["Answer"].ToString() == "Option D")
                                {
                                    rdoD.Text = "Option D";
                                    rdoD.Checked = true;

                                }
                               break;
                            }

                        }
                        
                    }
                }
            }

            //adp.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    lblQuesid1.Text = ds.Tables[0].Rows[0]["queId"].ToString();
            //    //LBLpATTERN.Text = ds.Tables[0].Rows[0]["pattern"].ToString();
            //    lblquestion.Text = ds.Tables[0].Rows[0]["question"].ToString();
            //    lblA.Text = ds.Tables[0].Rows[0]["optA"].ToString();
            //    lblB.Text = ds.Tables[0].Rows[0]["optB"].ToString();
            //    lblC.Text = ds.Tables[0].Rows[0]["optC"].ToString();
            //    lblD.Text = ds.Tables[0].Rows[0]["optD"].ToString();
            //}
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            if (rdoA.Checked == true)
            {
                rdoA.Text = "Option A";
                answer = rdoA.Text;

            }
            else if (rdoB.Checked == true)
            {
                rdoB.Text = "Option B";
                answer = rdoB.Text;

            }
            else if (rdoC.Checked == true)
            {
                rdoC.Text = "Option C";
                answer = rdoC.Text;

            }
            else if (rdoD.Checked == true)
            {
                rdoD.Text = "Option D";
                answer = rdoD.Text;

            }
            //savedata();
            if (ViewState["table_Result"] != null)
            {
                DataTable table_Result = (DataTable)ViewState["table_Result"] as DataTable;
                if (rdoA.Checked == true || rdoB.Checked == true || rdoC.Checked == true || rdoD.Checked == true)
                {
                    int IsFound = 0;
                    foreach (DataRow dr in table_Result.Rows)
                    {
                        string que = dr["QuestionId"].ToString();
                        if (dr["QuestionId"].ToString() == lblQuesid1.Text)
                        {
                            dr["Answer"] = answer;
                            IsFound = 1;
                            break;
                        }

                    }
                    if (IsFound == 0)
                    {
                        if (Session["UserName"] != null && (ddlUnitTest.SelectedValue != null || ddlUnitTest.SelectedValue != "") && lblQuesid1.Text != "" && answer != "" && Session["OrgId"] != null)
                            table_Result.Rows.Add(Session["UserName"], ddlUnitTest.SelectedValue, lblQuesid1.Text, answer, Session["OrgId"]);
                        ViewState["table_Result"] = table_Result;
                    }
                   

                    SqlCommand cmd = new SqlCommand("sp_SaveOnlineResult", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SaveOnlineExamResult", table_Result);
                cn.Open();
                int a=cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    ViewState["table_Result"] = null;
                    ViewState["QuestionCount"] = null;
                    Response.Redirect("~/Forms/Student/onlineResult.aspx");
                }
                }
                else
                {
                    msgBox.ShowMessage("Please Select One Answer !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                    return;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Please Select One Answer')", true);

                }

                
            }

            
           
                

           
            //float count = db.getDb_Value(" select count(Status) from tblOnlineResult where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and pattern like '" + pattern.ToString() + "' and Status='" + "TRUE" + "' and  UserCode='" + Convert.ToString(Session["UserName"]) + "' and unitType='"+ddlUnitTest.Text+"' ");

            // btnNext.Enabled = false;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your result is:-')", true);
            //Response.Write("<script>alert('" + count.ToString() + "');</script>");
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert( " + Session["count"] + ");", true);

            //db.cnopen();
            //db.getDbstatus_Value("select queId FROM  tblAddQuestion where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and pattern like 'A%'");
            //db.cnclose();
        }

        //for pattern
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "ABCD";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
           // db.cnopen();
           //// db.insert("insert into tblOnlineResult values ('" + pattern.ToString() + "','" + lblQuesid1.Text + "','" + rdoA.Text + "','" + rdoB.Text + "','" + rdoC.Text + "','" + rdoD.Text + "','" + Convert.ToInt32(Session["OrgId"]) + "')");
           // if (rdoA.Checked==true)
           // {
           //     rdoA.Text = "A";
           //     answer=rdoA.Text;
           // }
           // else if (rdoB.Checked == true)
           // {
           //     rdoB.Text = "B";
           //      answer=rdoB.Text;
           // }
           // else if (rdoC.Checked == true)
           // {
           //     rdoC.Text = "C";
           //     answer=rdoC.Text;
           // }
           // else
           // {
           //     rdoD.Text = "D";
           //     answer=rdoD.Text;
           // }

           // result = db.getDbstatus_Value("select answer FROM  tblAddQuestion where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and pattern like '" + pattern.ToString() + "' and queId= '" + lblQuesid1.Text + "' ");
           // if (answer == result)
           // {
           //     statu = "TRUE";
           // }
           // else
           // {
           //     statu = "FALSE";
                 
           // }

           // db.insert("insert into tblOnlineResult values ('" + pattern.ToString() + "','" + lblQuesid1.Text + "','" + answer + "','" + Convert.ToInt32(Session["OrgId"]) + "','" + statu + "')");

           // db.cnclose();
        }

        protected void rdoA_CheckedChanged(object sender, EventArgs e)
        {
          //  btnNext.Enabled = true;
        }

        

        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_Insert_TestDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                DataSet ds = new DataSet();
                using (cn)
                {

                    // cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Action", "Get_Test_Details");
                    cmd.Parameters.AddWithValue("@UserName", usercode);
                    cmd.Parameters.AddWithValue("@SubjectId", drpSubject.SelectedValue);
                    cmd.Parameters.AddWithValue("@OrgId", Session["OrgId"]);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(ds);
                    }

                    ddlUnitTest.DataSource = ds.Tables[0];
                    ddlUnitTest.DataTextField = "TestName";
                    ddlUnitTest.DataValueField = "TestId";
                    ddlUnitTest.DataBind();
                    ddlUnitTest.Items.Insert(0, new ListItem("Select", "0"));

                   

                }
            }
            catch (Exception ex) { }
        }

        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            try
            {
                ClearChckBoxes();
                btnNext.Enabled = true;
                btnPrvious.Enabled = false;
                ddlUnitTest.Text = ddlUnitTest.SelectedValue.ToString();

                Session["testtype"] = ddlUnitTest.Text;
                Session["subject"] = drpSubject.Text;

                DataTable table_Result = new DataTable();
                table_Result.Columns.Add("UserCode", typeof(string));
                table_Result.Columns.Add("TestId", typeof(int));
                table_Result.Columns.Add("QuestionId", typeof(int));
                table_Result.Columns.Add("Answer", typeof(string));
                table_Result.Columns.Add("OrgId", typeof(int));

                ViewState["table_Result"] = table_Result;

                //pattern = db.getDbstatus_Value("select Pattern from tblSavePattern where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and UserCode='" + usercode.ToString() + "'");
                //SqlCommand cmd = new SqlCommand("SELECT queId,question,optA,optB,optC,optD FROM  tblAddQuestion where OrgId='" + Convert.ToInt32(Session["OrgId"]) + "' and pattern='" + pattern.ToString() + "' and unitType='" + ddlUnitTest.Text + "' and class='" + Session["classId"].ToString() + "'  and SubjectName='" + drpSubject.SelectedValue.ToString() + "' ", cn);

                SqlCommand cmd = new SqlCommand("sp_Insert_TestDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"]));
                cmd.Parameters.AddWithValue("@TestId", ddlUnitTest.SelectedValue);
                cmd.Parameters.AddWithValue("@SubjectId", drpSubject.SelectedValue);
                cmd.Parameters.AddWithValue("@Action", "Fetch_Questions");
                
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //adp.SelectCommand = cmd;
                adp.Fill(ds);
                //FormView1.DataSource = ds.Tables[0];
                //FormView1.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlShow.Visible = true;
                    ViewState["QuestionCount"] = ds.Tables[0].Rows.Count;
                    if (Convert.ToInt32(ViewState["QuestionCount"]) == 1)
                    {
                        btnNext.Enabled = false;
                        btnPrvious.Enabled = false;
                        btnCancel.Enabled = true;
                    }
                    //if (lblQuesid1.Text == "")
                    {
                        string ImgQuestion = ds.Tables[0].Rows[0]["ImgQuestion"].ToString();
                        //if (ds.Tables[0].Rows[0]["IsImgQuestion"].ToString() == "True")
                        //{
                            if (ImgQuestion != null && ImgQuestion != "")
                            {
                                Byte[] bytes = (Byte[])ds.Tables[0].Rows[0]["ImgQuestion"];

                                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                Image1.ImageUrl = "data:image/png;base64," + base64String;
                                Image1.Visible = true;
                            }
                        //}
                            else
                            {
                                Image1.Visible = false;
                            }

                        lblQuesid1.Text = ds.Tables[0].Rows[0]["QuestionId"].ToString();
                        LBLpATTERN.Text = ds.Tables[0].Rows.Count.ToString(); //pattern.ToString();
                        lblquestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();
                        lblA.Text = ds.Tables[0].Rows[0]["optA"].ToString();
                        lblB.Text = ds.Tables[0].Rows[0]["optB"].ToString();
                        lblC.Text = ds.Tables[0].Rows[0]["optC"].ToString();
                        lblD.Text = ds.Tables[0].Rows[0]["optD"].ToString();
                    }
                }
                else
                {
                    pnlShow.Visible = false;
                    msgBox.ShowMessage("Record Not Found for selected exam!!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
                }
            }
            catch (Exception ex)
            {
                msgBox.ShowMessage("Record Not Found !!!", "Saved", UserControls.MessageBox.MessageStyle.Critical);
            }
        }

        protected void ddlUnitTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnitTest.SelectedIndex > 0)
            {
                btnStartExam.Enabled = true;
            }
            else
            {
                btnStartExam.Enabled = false;
            }
        }

        //protected void FormView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        //{
        //    try 
        //    {
        //        FormView1.PageIndex = e.NewPageIndex;
        //        SqlCommand cmd = new SqlCommand("sp_Insert_TestDetails", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"]));
        //        cmd.Parameters.AddWithValue("@TestId", ddlUnitTest.SelectedValue);
        //        cmd.Parameters.AddWithValue("@Action", "Fetch_Questions");

        //        DataSet ds = new DataSet();
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        //adp.SelectCommand = cmd;
        //        adp.Fill(ds);
        //        FormView1.DataSource = ds.Tables[0];
        //        FormView1.DataBind();

        //    }
        //    catch (Exception ex) { }
        //}
    }
}
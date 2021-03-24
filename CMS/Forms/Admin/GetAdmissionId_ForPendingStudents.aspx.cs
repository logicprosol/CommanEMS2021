using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using BusinessAccessLayer.Admin;
using DataAccessLayer;
using EntityWebApp;
using EntityWebApp.Admin;
using System.Web;

//View Student Addmission
namespace CMS.Forms.Admin
{
    public partial class GetAdmissionId_ForPendingStudents : System.Web.UI.Page
    {
        //Objects
        #region[Objects]
        private BL_Admission objBAL = new BL_Admission();
        private EWA_Admission objEWA = new EWA_Admission();
        private DataSet ds;
        public static int orgID;

        private BindControl ObjHelper = new BindControl();
        #endregion
        //Page Load

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    orgID = Convert.ToInt32(Session["OrgId"]);
                    if (orgID == 0)
                    {
                        Response.Redirect("~/CMSHome.aspx");
                    }
                    BindDropDownData(orgID);
                }
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion PageLoad

        //Bind Drop Down
        #region[Bind Drop Down]

        protected void BindDropDownData(int orgID)
        {
            try
            {
                BL_Common objBL = new BL_Common();
                EWA_Common objEWA = new EWA_Common();

                objEWA.OrgId = Convert.ToString(orgID);

                ds = objBL.BindCourses_BL(objEWA);

                ddl_Course.DataSource = ds;
                ddl_Course.DataTextField = "CourseName";
                ddl_Course.DataValueField = "CourseId";
                ddl_Course.DataBind();
                ddl_Course.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Course Index Changed
        #region[Course Index Changed]

        protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.CourseId = ddl_Course.SelectedValue.ToString();

                ds = objBL.BindBranches_BL(objEWA);

                ddl_Branch.DataSource = ds;
                ddl_Branch.DataTextField = "BranchName";
                ddl_Branch.DataValueField = "BranchId";
                ddl_Branch.DataBind();
                ddl_Branch.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Branch Index Changed
        #region[Branch Index Changed]

        protected void ddl_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EWA_Common objEWA = new EWA_Common();
                BL_Common objBL = new BL_Common();
                objEWA.BranchId = ddl_Branch.SelectedValue.ToString();

                ds = objBL.BindClass_BL(objEWA);

                ddl_Class.DataSource = ds;
                ddl_Class.DataTextField = "ClassName";
                ddl_Class.DataValueField = "ClassId";
                ddl_Class.DataBind();
                ddl_Class.Items.Insert(0, "Select");
            }
            catch (Exception exp)
            {
                GeneralErr(exp.Message.ToString());
            }
        }

        #endregion

        //Bind Grid View Data
        #region[Bind Grid View Data]

        //private void BindGridviewData(int orgID,string AdmissionStatus )
        //{
        //    try
        //    {
        //        objEWA.OrgID = orgID;
        //        objEWA.Course = ddl_Course.SelectedValue;
        //        objEWA.Branch1 = ddl_Branch.SelectedValue;
        //        objEWA.ClassId = ddl_Class.SelectedValue;
        //        objEWA.FromDate = txtFromDate.Text.ToString();
        //        objEWA.ToDate = txtToDate.Text.ToString();

        //        ds = new DataSet();
        //        ds = objBAL.SelectStudentAdmission(objEWA);

        //        if (ds.Tables[0].Rows.Count == 0 || ds == null)
        //        {
        //            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //            grdPendingAdmission.DataSource = ds;
        //            grdPendingAdmission.DataBind();
        //            int columncount = grdPendingAdmission.Rows[0].Cells.Count;
        //            grdPendingAdmission.Rows[0].Cells.Clear();
        //            grdPendingAdmission.Rows[0].Cells.Add(new TableCell());
        //            grdPendingAdmission.Rows[0].Cells[0].ColumnSpan = columncount;
        //            grdPendingAdmission.Rows[0].Cells[0].Text = "No Records Found";
        //        }
        //        else
        //        {
        //            grdPendingAdmission.DataSource = ds;
        //            grdPendingAdmission.DataBind();
                    
        //        }
                
        //        btnGO.Visible = true;
        //    }
        //    catch (Exception exp)
        //    {
        //        GeneralErr(exp.Message.ToString());
        //    }
        //}

        #endregion

        //Go Event
        #region[Go Event]

        protected void btnGO_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    BindGridviewData(orgID);
            //}
            //catch (Exception exp)
            //{
            //    GeneralErr(exp.Message.ToString());
            //}
            directSearch();

        }

        #endregion


        public void directSearch()
        {
            try
         {
            database db=new database();
            int flag = 0;
             //----Commnented And Added By Ashwini-7-oct-2020----------------------------------------------------------------------------------
            //string qury = "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.EMail, " +
            //        "case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId "+
            //        " where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId ="+
            //        " (select AcademicYearId from tblAcademicYear where IsCurrentYear = 1 and OrgId="+ orgID.ToString() + "))> 0 then '' else 'Add fees' end as Status" +
            //        " FROM tblAdmissionDetails A where A.OrgId='" + orgID.ToString() + "' and   A.Status='"+"Pending"+"' and ";

                string qury = "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.Mobile, " +
                     "tblCourse.CourseName+' - '+tblBranch.BranchName+' - '+tblClass.ClassName as class," +
                         "tblFeesCategory.FeesCategoryName as Category," +
                  "case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId " +
                  " where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" +
                  " (select AcademicYearId from tblAcademicYear where IsCurrentYear = 1 and OrgId=" + orgID.ToString() + "))> 0 then '' else 'Add fees' end as Status" +
                  " FROM tblAdmissionDetails A "+
                  " INNER JOIN tblCourse on tblCourse.CourseId=A.CourseId" +
                " INNER JOIN tblClass on tblClass.ClassId=A.ClassId" +
                " INNER JOIN TblBranch on TblBranch.BranchId=A.BranchId" +
                " INNER JOIN tblFeesCategory on tblFeesCategory.FeesCategoryId=A.FeesCategory" +
                 " where A.OrgId='" + orgID.ToString() + "' and   A.Status='" + "Pending" + "' and ";
//-------------------------------------------------------------------------------------------------------------------------------------------//
                if (ddl_Course.Text != "Select")
            {
                if (flag != 0)
                {
                    qury += "and ";
                }
                qury += "(A.CourseId='" + ddl_Course.SelectedValue.ToString() + "')";
                flag++;
            }
            if (ddl_Branch.Text != "Select")
            {
                if (flag != 0)
                {
                    qury += "and";
                }
                qury += "(A.BranchId ='"+ddl_Branch.SelectedValue.ToString()+"')";
                flag++;
            }
            if (ddl_Class.Text != "Select")
            {
                if(flag!=0)
                {
                    qury += "and";
                }
                qury += "(A.ClassId = '"+ddl_Class.SelectedValue.ToString()+"')";
                flag++;
            }
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    if (flag != 0)
                    {
                        qury += "and";
                    }
                    // ApplicationDate BETWEEN convert(varchar(10),(CONVERT(Date, @FromDate,103)),121) AND CONVERT(varchar(10), (CONVERT(date, @ToDate, 103)),121)
                    qury += "( A.ApplicationDate BETWEEN (CONVERT(Date, '" + txtFromDate.Text + "',103)) AND  CONVERT(varchar(10), (CONVERT(date, '" + txtToDate.Text + "',103)),121))";
                    flag++;
                }
                else if (txtFromDate.Text != "" )
                {
                    if (flag != 0)
                    {
                        qury += "and";
                    }
                    // ApplicationDate BETWEEN convert(varchar(10),(CONVERT(Date, @FromDate,103)),121) AND CONVERT(varchar(10), (CONVERT(date, @ToDate, 103)),121)
                    qury += "( A.ApplicationDate >= (CONVERT(Date, '" + txtFromDate.Text + "',103)))";
                    flag++;
                }
                else if ( txtToDate.Text != "")
                {
                    if (flag != 0)
                    {
                        qury += "and";
                    }
                    // ApplicationDate BETWEEN convert(varchar(10),(CONVERT(Date, @FromDate,103)),121) AND CONVERT(varchar(10), (CONVERT(date, @ToDate, 103)),121)
                    qury += "( A.ApplicationDate <= CONVERT(varchar(10), (CONVERT(date, '" + txtToDate.Text + "',103)),121))";
                    flag++;
                }


                if (flag == 0)
                {

 //------------------  Commented And Added By Ashwini ---7-oct-2020--------------------------------------------------------------------------//
                   // qury=  "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.EMail, " +
                   //"case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId " +
                   //" where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" +
                   //" (select AcademicYearId from tblAcademicYear where IsCurrentYear = 1 and OrgId="+ orgID.ToString() + "))> 0 then '' else 'Add fees' end as Status" +
                   //" FROM tblAdmissionDetails A where A.OrgId='" + orgID.ToString() + "' and   A.Status='" + "Pending" + "'";

                     qury = "SELECT A.AdmissionID,A.AdmissionType,A.FirstName +' '+ A.MiddleName + ' '+ A.LastName as StudentName,A.Mobile, " +
                   "tblCourse.CourseName+' - '+tblBranch.BranchName+' - '+tblClass.ClassName as class," +
                       "tblFeesCategory.FeesCategoryName as Category," +
                "case when(select count(*) from tblFees inner join tblFeesDetails  on tblFees.FeesId = tblFeesDetails.FeesId " +
                " where tblFees.ClassId = A.ClassId and tblFees.CasteCategoryId = A.FeesCategory and AcademicYearId =" +
                " (select AcademicYearId from tblAcademicYear where IsCurrentYear = 1 and OrgId=" + orgID.ToString() + "))> 0 then '' else 'Add fees' end as Status" +
                " FROM tblAdmissionDetails A " +
                " INNER JOIN tblCourse on tblCourse.CourseId=A.CourseId" +
              " INNER JOIN tblClass on tblClass.ClassId=A.ClassId" +
              " INNER JOIN TblBranch on TblBranch.BranchId=A.BranchId" +
              " INNER JOIN tblFeesCategory on tblFeesCategory.FeesCategoryId=A.FeesCategory" +
               " where A.OrgId='" + orgID.ToString() + "' and   A.Status='" + "Pending" + "'";
//-------------------------------------------------------------------------------------------------------------------------------------------//
                    //grdPendingAdmission.DataSource = db.Displaygrid("SELECT AdmissionID,AdmissionType,FirstName +' '+ MiddleName + ' '+ LastName as StudentName,EMail FROM tblAdmissionDetails where OrgId='" + orgID.ToString() + "' and Status='" + "Pending" + "' ");
                }
                
                    grdPendingAdmission.DataSource = db.Displaygrid(qury);

                


                //grdPendingAdmission.DataSourceID = db.Displaygrid(qury).ToString();
                grdPendingAdmission.DataBind();

                //serial_no();

            }
            catch (Exception ex)
            {
            }
        }


       
      

      

       

        //General Message
        #region[General Message]

        protected void GeneralErr(String msg)
        {
            //msgBox.ShowMessage(msg, "Critical", UserControls.MessageBox.MessageStyle.Critical);
        }

        #endregion
        //Added by Ashwini 7-oct-2020
        protected void AddFees_Click(object sender, EventArgs e)
        {
            // Response.Redirect("AddFees.aspx");
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('AddFees.aspx' ,'_blank');", true);
        }

        protected void btnPayFeeForgetAdmission_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('PayFees.aspx' ,'_blank');", true);
        }
    }
}
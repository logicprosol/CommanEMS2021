using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS.Forms.Student
{
    public partial class Timetable_Student : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SP_TimeTableCreationAction", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Action", "TimeTable_For_Student");
                cmd1.Parameters.AddWithValue("@OrgId", Convert.ToInt32(Session["OrgId"].ToString()));
                cmd1.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserCode"].ToString()));
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                adp1.SelectCommand = cmd1;
                adp1.Fill(ds1);


                if (ds1.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = Filldata(ds1);
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex) { }
        }
        public DataTable Filldata(DataSet ds)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Period");
            dt.Columns.Add("Mon");
            dt.Columns.Add("Tue");
            dt.Columns.Add("Wed");
            dt.Columns.Add("Thus");
            dt.Columns.Add("Fri");
            dt.Columns.Add("Sat");


            if (ds.Tables[0].Rows.Count > 0)
            {

                int i = 0, l = 0, sat = 0, day = 2;
                while (ds.Tables[0].Rows.Count > i || ds.Tables[1].Rows.Count > sat)
                {

                    DataRow dr = dt.NewRow();
                    dr[0] =Convert.ToDateTime( ds.Tables[0].Rows[i][0].ToString()).ToShortTimeString();// ++l;
                    if (ds.Tables[0].Rows.Count > i)
                    {
                        string Time = ds.Tables[0].Rows[i][0].ToString();
                        int j = 0;
                        while (ds.Tables[0].Rows.Count > j)
                        {

                            if (ds.Tables[0].Rows[j][0].ToString() == Time)
                            {
                                while (day < 7)
                                {
                                    if (ds.Tables[0].Rows[j][5].ToString() == day.ToString())
                                    {
                                        if (ds.Tables[0].Rows.Count > (j+1) )
                                        {
                                            string d = ds.Tables[0].Rows[j + 1]["DayId"].ToString();
                                            string t = ds.Tables[0].Rows[j + 1]["Time"].ToString();

                                            if (d == day.ToString() && t == Time)
                                            {
                                                dr[day - 1] = ds.Tables[0].Rows[j][2].ToString() + " / " + ds.Tables[0].Rows[j + 1][2].ToString();
                                                j++; i++;
                                            }
                                            else
                                            {
                                                //dr[day - 1] = ds.Tables[0].Rows[j][2].ToString() + "\n(" + ds.Tables[0].Rows[j][3].ToString() + ")";
                                                dr[day - 1] = ds.Tables[0].Rows[j][2].ToString();
                                                //TimetableDetails Details = new TimetableDetails();
                                                //Details.Subject = ds.Tables[0].Rows[j][2].ToString();
                                                //Details.Day = ds.Tables[0].Rows[j][1].ToString();
                                                //Details.Teacher = ds.Tables[0].Rows[j][3].ToString();
                                                //Details.HomeWork = ds.Tables[0].Rows[j][4].ToString();
                                                //Detailslist.Add(Details);
                                            }
                                            i++; day++;
                                            break;
                                        }
                                        else
                                        {
                                            //dr[day - 1] = ds.Tables[0].Rows[j][2].ToString() + "\n(" + ds.Tables[0].Rows[j][3].ToString() + ")";
                                            dr[day - 1] = ds.Tables[0].Rows[j][2].ToString();
                                            //TimetableDetails Details = new TimetableDetails();
                                            //Details.Subject = ds.Tables[0].Rows[j][2].ToString();
                                            //Details.Day = ds.Tables[0].Rows[j][1].ToString();
                                            //Details.Teacher = ds.Tables[0].Rows[j][3].ToString();
                                            //Details.HomeWork = ds.Tables[0].Rows[j][4].ToString();
                                            //Detailslist.Add(Details);
                                            i++; day++;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        dr[day - 1] = " - " + "\n" + " - ";
                                    }
                                    day++;
                                }
                            }
                            j++;
                        }
                    }

                    while (day < 7)
                    {
                        dr[day - 1] = " - " + '\n' + " - ";
                        day++;
                    }

                    if (ds.Tables[1].Rows.Count > sat && day == 7)
                    {
                        if (ds.Tables[1].Rows.Count > (sat + 1))
                        {
                            string Time = ds.Tables[1].Rows[sat][0].ToString();
                            if (ds.Tables[1].Rows[sat + 1][0].ToString() == Time)
                            {
                                dr[day - 1] = ds.Tables[1].Rows[sat][2].ToString()  + " / " + ds.Tables[1].Rows[sat + 1][2].ToString() ;
                                sat++;
                            }
                            else
                            {
                                dr[day - 1] = ds.Tables[1].Rows[sat][2].ToString();// + "\n(" + ds.Tables[1].Rows[sat][3].ToString() + ")";
                            }

                            sat++; day = 2;
                        }
                        else
                        {
                            dr[day - 1] = ds.Tables[1].Rows[sat][2].ToString();// + "\n(" + ds.Tables[1].Rows[sat][3].ToString() + ")";
                            sat++; day = 2;
                        }
                    }
                    else if (day == 7)
                    {
                        dr[day - 1] = " - " + "\n" + " - ";
                        day = 2;
                    }


                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
    }
}
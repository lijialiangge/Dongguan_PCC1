using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Eaton_DG_PCC.BigScreen;

namespace Eaton_DG_PCC.Model
{
    public class DB_Overall_Situation
    {
        public static string SqlCon = @"Data Source=ANDYLI\SQLEXPRESS;Initial Catalog=PCTron;User ID=sa;Password=ok;";
        string Now_Months = DateTime.Now.Month.ToString();
        string Last_Months = DateTime.Now.AddMonths(-1).Month.ToString();
        
        /// <summary>
        /// 查询上月基本信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Select_Device_Information_Last_Month> Select_Device_Information_Last_Months(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                List <Select_Device_Information_Last_Month> u1 = new List<Select_Device_Information_Last_Month>(); //新建一个对象

                String Last_Months_Add = Last_Months.PadLeft(2, '0');
                String Monthly_Test_Output = "Monthly_Test_Output" + Last_Months_Add;
                String Monthly_Test_NG = "Monthly_Test_NG" + Last_Months_Add;

                while (dr.Read())//遍历dr
                {
                    Select_Device_Information_Last_Month u0 = new Select_Device_Information_Last_Month(); //新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Monthly_Test_Output = Convert.ToInt32(dr[Monthly_Test_Output]);
                    u0.Monthly_Test_NG = Convert.ToInt32(dr[Monthly_Test_NG]);
                    u0.Last_Month_Runing_Time = Convert.ToInt32(dr["Last_Month_Runing_Time"]);
                    u0.Last_Month_Ready_Time = Convert.ToInt32(dr["Last_Month_Ready_Time"]);
                    u0.Last_Month_Alarm_Time = Convert.ToInt32(dr["Last_Month_Alarm_Time"]);
                    u0.Last_Month_Alarm_Times = Convert.ToInt32(dr["Last_Month_Alarm_Times"]);
                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询实时数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Select_Real_Time_Progress> Select_Real_Time_Progresss(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Select_Real_Time_Progress> u1 = new List<Select_Real_Time_Progress>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Select_Real_Time_Progress u0 = new Select_Real_Time_Progress();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Now_Order = dr["PO"].ToString();
                    u0.Now_Model = dr["Now_Model"].ToString();

                    u0.Plan_Output = Convert.ToInt32(dr["Plan_Output"]);
                    u0.Now_NG = Convert.ToInt32(dr["Now_NG"]);
                    u0.Now_Output = Convert.ToInt32(dr["Now_Output"]);
                    u0.Now_NG = Convert.ToInt32(dr["Now_NG"]);
                    u0.Done_Ratio = Convert.ToString(dr["Done_Ratio"]);
                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询统计数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public Select_Statistical_data Select_Statistical_datas(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                Select_Statistical_data u1 = new Select_Statistical_data(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u1.All = Convert.ToInt32(dr["All"]);
                    u1.Online = Convert.ToInt32(dr["Online"]);
                    u1.Offline = Convert.ToInt32(dr["Offline"]);
                    u1.Null = Convert.ToInt32(dr["Null"]);
                    u1.Run = Convert.ToInt32(dr["Run"]);
                    u1.Alarm = Convert.ToInt32(dr["Alarm"]);
                    u1.Ready = Convert.ToInt32(dr["Ready"]);
                    u1.Maintenance_advance = Convert.ToInt32(dr["Maintenance_advance"]);
                    u1.Maintenance_completed = Convert.ToInt32(dr["Maintenance_completed"]);
                    u1.Maintenance_expired = Convert.ToInt32(dr["Maintenance_expired"]);
                    u1.Maintenance_count = u1.Maintenance_advance + u1.Maintenance_completed;

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询上月Output和NG的Top5数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Select_Top10_Last_Month_Output_NG> Select_Top10_Last_Month_Output_NGs(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List <Select_Top10_Last_Month_Output_NG> u1 = new List<Select_Top10_Last_Month_Output_NG>(); //新建一个对象
                String Last_Months_Add = Last_Months.PadLeft(2, '0');
                String Monthly_Test_Output = "Monthly_Test_Output" + Last_Months_Add;
                String Monthly_Test_NG = "Monthly_Test_NG" + Last_Months_Add;

                while (dr.Read())//遍历dr
                {
                    Select_Top10_Last_Month_Output_NG  u0 = new Select_Top10_Last_Month_Output_NG();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Monthly_Test_Output = Convert.ToInt32(dr[Monthly_Test_Output])/1000;
                    u0.Monthly_Test_NG = Convert.ToInt32(dr[Monthly_Test_NG])/1000;
                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询上月Run和Alarm的Top10数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Select_Top10_Last_Month_Run_Alarm> Select_Top10_Last_Month_Run_Alarms(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List <Select_Top10_Last_Month_Run_Alarm> u1 = new List<Select_Top10_Last_Month_Run_Alarm>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Select_Top10_Last_Month_Run_Alarm  u0 = new Select_Top10_Last_Month_Run_Alarm();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Last_Month_Runing_Time = Convert.ToInt32(dr["Last_Month_Runing_Time"]);
                    u0.Last_Month_Alarm_Time = Convert.ToInt32(dr["Last_Month_Alarm_Time"]);
                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询上月报警次数Top5的数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Select_Top5_Alarm_times> Select_Top5_Alarm_timess(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                List<Select_Top5_Alarm_times> u1 = new List<Select_Top5_Alarm_times>(); //新建一个对象
                


                while (dr.Read())//遍历dr
                {
                    Select_Top5_Alarm_times u0 = new Select_Top5_Alarm_times(); //新建一个对象
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Last_Month_Alarm_Times = Convert.ToInt32(dr["Last_Month_Alarm_Times"]);
                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询实时数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Select_Top5_NG> Select_Top5_NGs(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Select_Top5_NG> u1 = new List<Select_Top5_NG>(); //新建一个对象
                String Last_Months_Add = Last_Months.PadLeft(2, '0');
                String Monthly_Test_NG_Ratio = "Monthly_Test_NG_Ratio" + Last_Months_Add;
                while (dr.Read())//遍历dr
                {
                    Select_Top5_NG u0 = new Select_Top5_NG(); //新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Monthly_Test_NG_Ratio = Convert.ToInt32(dr[Monthly_Test_NG_Ratio]);
                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Eaton_DG_PCC.Model.DRAQ127;
using Eaton_DG_PCC.Models;
using Eaton_DG_PCC.Model.PCC;

namespace Eaton_DG_PCC.Model
{

    public class Dbs
    {
        ArrayList arraylist = new ArrayList();
        //public static string SqlCon1 = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["PCTronEntities"]);
        //PHP-ServerPC
        //public static string SqlCon = @"Data Source=test-PC\AndyLi;Initial Catalog=PCTron;User ID=sa;Password=ok;";

        //AndyPC DRAQ127ConnectionString
        //public static string SqlCon = @"Data Source=.;Initial Catalog=PCTron;User ID=sa;Password=ok;";
        public static string SqlCon_Server = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionString"]);

        public static string SqlCon_LocalServer = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["LocalServerConnectionString"]);



        //public static string SqlCon = @"Data Source=.;Initial Catalog=DRAQ127;User ID=sa;Password=ok;";


        /// <summary>
        /// 查询单个设备所有详细信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Record_of_Spare_Parts> Select_Record_of_Spare_Parts(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Record_of_Spare_Parts> u1 = new List<Record_of_Spare_Parts>(); //新建一个User类的集合
                
                while (dr.Read())//遍历dr
                {
                    Record_of_Spare_Parts u0 = new Record_of_Spare_Parts(); //临时User类变量u0

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.Replace_Date = dr["Replace_Date"].ToString();
                    u0.Replace_content = dr["Replace_content"].ToString();
                    u0.Operator = dr["Operator"].ToString();
                    u0.Telephone = dr["Telephone"].ToString();


                    //u0.Id = int.Parse(dr["Id"].ToString());
                    //u0.cdt = DateTime.Parse(dr["cdt"].ToString());

                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询一共有多少个设备
        /// </summary>
        /// <returns>用户类集合</returns>

        public List<RealTimePlantData> DeviceSimpleInfo(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_LocalServer))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句


                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<RealTimePlantData> u1 = new List<RealTimePlantData>(); //新建一个User类的集合

                while (dr.Read())//遍历dr
                {
                    RealTimePlantData u0 = new RealTimePlantData(); //临时User类变量u0

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.ID = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["LineID"] != DBNull.Value)
                    {
                        u0.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["RecordTime"] != DBNull.Value)
                    {
                        u0.RecordTime = Convert.ToString(dr["RecordTime"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u0.ProductID = Convert.ToString(dr["ProductID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["DutTotalNum"] != DBNull.Value)
                    {
                        u0.DutTotalNum = Convert.ToInt32(dr["DutTotalNum"]);
                    }
                    if (dr["DutPassNum"] != DBNull.Value)
                    {
                        u0.DutPassNum = Convert.ToInt32(dr["DutPassNum"]);
                    }
                    if (dr["DutFailNum"] != DBNull.Value)
                    {
                        u0.DutFailNum = Convert.ToInt32(dr["DutFailNum"]);
                    }

                    if (dr["DutFailRate"] != DBNull.Value)
                    {
                        u0.DutFailRate = Convert.ToDouble(dr["DutFailRate"]);
                    }
                    if (dr["cap"] != DBNull.Value)
                    {
                        u0.cap = Convert.ToInt32(dr["cap"]);
                    }
                    if (dr["ESR"] != DBNull.Value)
                    {
                        u0.ESR = Convert.ToInt32(dr["ESR"]);
                    }
                    if (dr["Voltage"] != DBNull.Value)
                    {
                        u0.Voltage = Convert.ToInt32(dr["Voltage"]);
                    }
                    if (dr["HaltNum"] != DBNull.Value)
                    {
                        u0.HaltNum = Convert.ToInt32(dr["HaltNum"]);
                    }
                    if (dr["HaltTime"] != DBNull.Value)
                    {
                        u0.HaltTime = Convert.ToInt32(dr["HaltTime"]);
                    }
                    if (dr["DevStatus"] != DBNull.Value)
                    {
                        u0.DevStatus = Convert.ToInt32(dr["DevStatus"]);
                    }
                    if (dr["DeviceUseRate"] != DBNull.Value)
                    {
                        u0.DeviceUseRate = Convert.ToString(dr["DeviceUseRate"]);
                    }

                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询各种保养状态数量
        /// </summary>
        /// <returns>用户类集合</returns>

        public Maintain_Status Select_Maintain_Status(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                //List<Maintain_Status> u1 = new List<Maintain_Status>(); //新建一个User类的集合
                Maintain_Status u0 = new Maintain_Status(); //临时User类变量u0
                while (dr.Read())//遍历dr
                {
                   

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                   
                    u0.Maintenance_has_expired = Convert.ToInt32(dr["Maintenance_has_expired"]);
                    u0.Already_maintained = Convert.ToInt32(dr["Already_maintained"]);
                    u0.Maintenance_in_advance = Convert.ToInt32(dr["Maintenance_in_advance"]);
                    //u0.Test99 = dr["Test99"].ToString();

                    //u0.Id = int.Parse(dr["Id"].ToString());
                    //u0.cdt = DateTime.Parse(dr["cdt"].ToString());

                    //u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }


        /// <summary>
        /// 查询单个对象所有详细信息-单个对象
        /// </summary>
        /// <returns>用户类集合</returns>
        public AllStatus DeviceAllStatus(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_LocalServer))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                AllStatus u1 = new AllStatus(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["ID"] != DBNull.Value)
                    {
                        u1.ID = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["LineID"] != DBNull.Value)
                    {
                        u1.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["RecordTime"] != DBNull.Value)
                    {
                        u1.RecordTime = Convert.ToString(dr["RecordTime"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u1.ProductID = Convert.ToString(dr["ProductID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u1.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["DutTotalNum"] != DBNull.Value)
                    {
                        u1.DutTotalNum = Convert.ToInt32(dr["DutTotalNum"]);
                    }
                    if (dr["DutPassNum"] != DBNull.Value)
                    {
                        u1.DutPassNum = Convert.ToInt32(dr["DutPassNum"]);
                    }
                    if (dr["DutFailNum"] != DBNull.Value)
                    {
                        u1.DutFailNum = Convert.ToInt32(dr["DutFailNum"]);
                    }

                    if (dr["DutFailRate"] != DBNull.Value)
                    {
                        u1.DutFailRate = (1-Convert.ToDouble(dr["DutFailRate"]))*100;
                    }
                    if (dr["cap"] != DBNull.Value)
                    {
                        u1.cap = Convert.ToInt32(dr["cap"]);
                    }
                    if (dr["ESR"] != DBNull.Value)
                    {
                        u1.ESR = Convert.ToInt32(dr["ESR"]);
                    }
                    if (dr["Voltage"] != DBNull.Value)
                    {
                        u1.Voltage = Convert.ToInt32(dr["Voltage"]);
                    }
                    if (dr["HaltNum"] != DBNull.Value)
                    {
                        u1.HaltNum = Convert.ToInt32(dr["HaltNum"]);
                    }
                    if (dr["HaltTime"] != DBNull.Value)
                    {
                        u1.HaltTime = Convert.ToInt32(dr["HaltTime"])/60;
                    }
                    if (dr["DevStatus"] != DBNull.Value)
                    {
                        u1.DevStatus = Convert.ToInt32(dr["DevStatus"]);
                    }
                    if (dr["DeviceUseRate"] != DBNull.Value)
                    {
                        u1.DeviceUseRate = Convert.ToString(dr["DeviceUseRate"]);
                    }


                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询FAQ某个问题
        /// </summary>
        /// <returns>用户类集合</returns>
        public Basic_Faq Select_Basic_Faq(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                Basic_Faq u0 = new Basic_Faq();//新建一个对象


                while (dr.Read())//遍历dr
                {

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.ID = Convert.ToInt32(dr["ID"]);
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Ts = dr["Ts"].ToString();

                    u0.Owner = dr["Owner"].ToString();
                    u0.Problem = dr["Problem"].ToString();
                    u0.Answer = dr["Answer"].ToString();


                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }

        /// <summary>
        /// 查询FAQ所有问题
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Basic_Faq> Select_Basic_Faq_List(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                List<Basic_Faq> u1 = new List<Basic_Faq>(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    Basic_Faq u0 = new Basic_Faq(); //新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.ID = Convert.ToInt32(dr["ID"]);
                    u0.DeviceId = dr["DeviceId"].ToString();
                    u0.Ts = dr["Ts"].ToString();

                    u0.Owner = dr["Owner"].ToString();
                    u0.Problem = dr["Problem"].ToString();
                    u0.Answer = dr["Answer"].ToString();

                    u1.Add(u0);

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }




        /// <summary>
        /// 查询历史订单
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Order> SelectHistoryOrder(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Order> u1 = new List<Order>(); //新建一个User类的集合

                while (dr.Read())//遍历dr
                {
                    Order u0 = new Order(); //临时User类变量u0

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.OrderID = dr["Test4"].ToString();
                    u0.BeginTime = dr["Ts"].ToString();
                    u0.Plan_Output = dr["Test1"].ToString();
                    u0.Output = dr["Test2"].ToString();
                    u0.NG = dr["Test3"].ToString();
                    u0.EndTime = dr["Test5"].ToString();

                    //u0.Test99 = dr["Test99"].ToString();

                    //u0.Id = int.Parse(dr["Id"].ToString());
                    //u0.cdt = DateTime.Parse(dr["cdt"].ToString());

                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询报警历史信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Alarm_Info> SelectHistoryAlarm(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Alarm_Info> u1 = new List<Alarm_Info>(); //新建一个User类的集合

                while (dr.Read())//遍历dr
                {
                    Alarm_Info u0 = new Alarm_Info(); //临时User类变量u0

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.AlarmID = dr["AlarmID"].ToString();
                    u0.BeginTime = dr["BeginTime"].ToString();
                    u0.Alarm_Station = dr["Alarm_Station"].ToString();
                    u0.Alarm_Content = dr["Alarm_Content"].ToString();
                    u0.Alarm_Level = dr["Alarm_Level"].ToString();
                    u0.EndTime = dr["EndTime"].ToString();

                    //u0.Test99 = dr["Test99"].ToString();

                    //u0.Id = int.Parse(dr["Id"].ToString());
                    //u0.cdt = DateTime.Parse(dr["cdt"].ToString());

                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询一共有多少个设备
        /// </summary>
        /// <returns>用户类集合</returns>

        public List<Spare_Parts_Info> select_Address(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句


                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Spare_Parts_Info> u1 = new List<Spare_Parts_Info>(); //新建一个User类的集合

                while (dr.Read())//遍历dr
                {
                    Spare_Parts_Info u0 = new Spare_Parts_Info(); //临时User类变量u0

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.Address = dr["Address"].ToString();
                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询备件所有信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Spare_Parts_Info> SelectSparePartsAll(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Spare_Parts_Info> u1 = new List<Spare_Parts_Info>(); //新建一个User类的集合

                while (dr.Read())//遍历dr
                {
                    Spare_Parts_Info u0 = new Spare_Parts_Info(); //临时User类变量u0

                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.Real_id = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["Address"] != DBNull.Value)
                    {
                        u0.Address = dr["Address"].ToString();
                    }
                    if (dr["Num"] != DBNull.Value)
                    {
                        u0.Num = dr["Num"].ToString();
                    }
                    if (dr["Name"] != DBNull.Value)
                    {
                        u0.Name = dr["Name"].ToString();
                    }
                    if (dr["Model"] != DBNull.Value)
                    {
                        u0.Model = dr["Model"].ToString();
                    }
                    if (dr["Stock_Quantity"] != DBNull.Value)
                    {
                        u0.Stock_Quantity = Convert.ToInt32(dr["Stock_Quantity"]);
                    }
                    if (dr["Unit"] != DBNull.Value)
                    {
                        u0.Unit = dr["Unit"].ToString();
                    }
                    if (dr["Safety_Stock"] != DBNull.Value)
                    {
                        u0.Safety_Stock = Convert.ToInt32(dr["Safety_Stock"]);
                    }
                    if (dr["Supplier"] != DBNull.Value)
                    {
                        u0.Supplier = dr["Supplier"].ToString();
                    }
                    if (dr["Contacts"] != DBNull.Value)
                    {
                        u0.Contacts = dr["Contacts"].ToString();
                    }
                    if (dr["Phone"] != DBNull.Value)
                    {
                        u0.Phone = dr["Phone"].ToString();
                    }
                    if (dr["Mark"] != DBNull.Value)
                    {
                        u0.Mark = dr["Mark"].ToString();
                    }


                    //old
                    //u0.Spare_Parts_Name = dr["Spare_Parts_Name"].ToString();
                    //u0.Spare_Parts_Num = dr["Spare_Parts_Num"].ToString();
                    //u0.Supplier = dr["Supplier"].ToString();
                    //u0.Contacts = dr["Contacts"].ToString();
                    //u0.Phone = dr["Phone"].ToString();
                    //u0.Area_Code = dr["Area_Code"].ToString();
                    //u0.Specifications = dr["Specifications"].ToString();
                    //u0.Remark = dr["Remark"].ToString();
                    //u0.Test99 = dr["Test99"].ToString();
                    //u0.Id = int.Parse(dr["Id"].ToString());
                    //u0.cdt = DateTime.Parse(dr["cdt"].ToString());

                    u1.Add(u0);//把有数据的u0加入到User类的集合
                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询单个备件信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Spare_Parts_Info SelectSparePartsOne(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                Spare_Parts_Info u0 = new Spare_Parts_Info(); //临时User类变量u0

                while (dr.Read())//遍历dr
                {

                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.Real_id = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["Address"] != DBNull.Value)
                    {
                        u0.Address = dr["Address"].ToString();
                    }
                    if (dr["Num"] != DBNull.Value)
                    {
                        u0.Num = dr["Num"].ToString();
                    }
                    if (dr["Name"] != DBNull.Value)
                    {
                        u0.Name = dr["Name"].ToString();
                    }
                    if (dr["Model"] != DBNull.Value)
                    {
                        u0.Model = dr["Model"].ToString();
                    }
                    if (dr["Stock_Quantity"] != DBNull.Value)
                    {
                        u0.Stock_Quantity = Convert.ToInt32(dr["Stock_Quantity"]);
                    }
                    if (dr["Unit"] != DBNull.Value)
                    {
                        u0.Unit = dr["Unit"].ToString();
                    }
                    if (dr["Safety_Stock"] != DBNull.Value)
                    {
                        u0.Safety_Stock = Convert.ToInt32(dr["Safety_Stock"]);
                    }
                    if (dr["Supplier"] != DBNull.Value)
                    {
                        u0.Supplier = dr["Supplier"].ToString();
                    }
                    if (dr["Contacts"] != DBNull.Value)
                    {
                        u0.Contacts = dr["Contacts"].ToString();
                    }
                    if (dr["Phone"] != DBNull.Value)
                    {
                        u0.Phone = dr["Phone"].ToString();
                    }
                    if (dr["Mark"] != DBNull.Value)
                    {
                        u0.Mark = dr["Mark"].ToString();
                    }


                    //old
                    //u0.Spare_Parts_Name = dr["Spare_Parts_Name"].ToString();
                    //u0.Spare_Parts_Num = dr["Spare_Parts_Num"].ToString();
                    //u0.Supplier = dr["Supplier"].ToString();
                    //u0.Contacts = dr["Contacts"].ToString();
                    //u0.Phone = dr["Phone"].ToString();
                    //u0.Area_Code = dr["Area_Code"].ToString();
                    //u0.Specifications = dr["Specifications"].ToString();
                    //u0.Remark = dr["Remark"].ToString();
                    //u0.Test99 = dr["Test99"].ToString();
                    //u0.Id = int.Parse(dr["Id"].ToString());
                    //u0.cdt = DateTime.Parse(dr["cdt"].ToString());

                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }


        /// <summary>
        /// 查询-单个User信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public User Select_UserInfo(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                User u0 = new User(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.UserName = dr["UserName"].ToString();
                    u0.Password = dr["PassWord"].ToString();
                    u0.RoleNum = dr["RoleNum"].ToString();
                    //u0.RoleName = dr["RoleName"].ToString();
                    u0.RealName = dr["RealName"].ToString();
                    u0.Email = dr["Email"].ToString();
                    u0.Phone = dr["Phone"].ToString();
                    //u0.CreateTime = dr["CreateTime"].ToString();
                    //u0.LoginCount = Convert.ToInt32(dr["LoginCount"]);
                    //u0.Picture = dr["Picture"].ToString();
                    //u0.UpdateTime = dr["UpdateTime"].ToString();
                    u0.DepartNum = dr["DepartNum"].ToString();
                    //u0.DepartName = dr["DepartName"].ToString();
                    u0.Remark = dr["Remark"].ToString();

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }


        /// <summary>
        /// 查询-All-User信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<User> Select_UserInfoAll(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<User> u1 = new List<User>(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    User u0 = new User(); //新建一个User类的集合
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.ID = Convert.ToInt32(dr["ID"]);
                    u0.UserName = dr["UserName"].ToString();
                    u0.Password = dr["PassWord"].ToString();
                    u0.RoleNum = dr["RoleNum"].ToString();
                    u0.RoleName = dr["RoleName"].ToString();
                    u0.RealName = dr["RealName"].ToString();
                    u0.Email = dr["Email"].ToString();
                    u0.Phone = dr["Phone"].ToString();
                    //u0.CreateTime = dr["CreateTime"].ToString();
                    //u0.LoginCount = Convert.ToInt32(dr["LoginCount"]);
                    //u0.Picture = dr["Picture"].ToString();
                    //u0.UpdateTime = dr["UpdateTime"].ToString();
                    u0.DepartNum = dr["DepartNum"].ToString();
                    u0.DepartName = dr["DepartName"].ToString();
                    u0.Remark = dr["Remark"].ToString();
                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询某个UserInfo
        /// </summary>
        /// <returns>用户类集合</returns>
        public User Select_Role_Info(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                User u0 = new User();//新建一个对象


                while (dr.Read())//遍历dr
                {

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.ID = Convert.ToInt32(dr["ID"]);
                    u0.UserName = dr["UserName"].ToString();
                    u0.Password = dr["Password"].ToString();
                    u0.RoleNum = dr["RoleNum"].ToString();
                    u0.RoleName = dr["RoleName"].ToString();
                    u0.RealName = dr["RealName"].ToString();
                    u0.Phone = dr["Phone"].ToString();
                    u0.DepartNum = dr["DepartNum"].ToString();
                    u0.DepartName = dr["DepartName"].ToString();


                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }


        /// <summary>
        /// 查询部门All信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Depart_Info> Select_DepartInfoAll(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Depart_Info> u1 = new List<Depart_Info>(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    Depart_Info u0 = new Depart_Info(); //新建一个User类的集合
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.ID = Convert.ToInt32(dr["ID"]);

                    u0.DepartNum = dr["DepartNum"].ToString();
                    u0.DepartName = dr["DepartName"].ToString();
                    u0.Remark = dr["Remark"].ToString();
                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询角色All信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Role_Info> Select_RoleInfoAll(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Role_Info> u1 = new List<Role_Info>(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    Role_Info u0 = new Role_Info(); //新建一个User类的集合
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u0.ID = Convert.ToInt32(dr["ID"]);

                    u0.RoleNum = dr["RoleNum"].ToString();
                    u0.RoleName = dr["RoleName"].ToString();
                    u0.Remark = dr["Remark"].ToString();
                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询每天Output共31天
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Daily_Output_Model> Select_Daily_Data(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Daily_Output_Model> u1 = new List<Daily_Output_Model>(); //新建一个User类的集合
                while (dr.Read())//遍历dr
                {
                    Daily_Output_Model u0 = new Daily_Output_Model();//新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    
                    if (!dr.IsDBNull(1))
                    {
                        u0.Model = dr.GetString(1);
                    }
                    if (!dr.IsDBNull(2))
                    {
                        u0.Day1 = dr.GetInt32(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        u0.Day2 = dr.GetInt32(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        u0.Day3 = dr.GetInt32(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        u0.Day4 = dr.GetInt32(5);
                    }
                    if (!dr.IsDBNull(6))
                    {
                        u0.Day5 = dr.GetInt32(6);
                    }
                    if (!dr.IsDBNull(7))
                    {
                        u0.Day6 = dr.GetInt32(7);
                    }
                    if (!dr.IsDBNull(8))
                    {
                        u0.Day7 = dr.GetInt32(8);
                    }
                    if (!dr.IsDBNull(9))
                    {
                        u0.Day8 = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        u0.Day9 = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        u0.Day10 = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        u0.Day11 = dr.GetInt32(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        u0.Day12 = dr.GetInt32(13);
                    }
                    if (!dr.IsDBNull(14))
                    {
                        u0.Day13 = dr.GetInt32(14);
                    }
                    if (!dr.IsDBNull(15))
                    {

                        u0.Day14 = dr.GetInt32(15);
                    }
                    if (!dr.IsDBNull(16))
                    {
                        u0.Day15 = dr.GetInt32(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        u0.Day16 = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        u0.Day17 = dr.GetInt32(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        u0.Day18 = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        u0.Day19 = dr.GetInt32(20);
                    }
                    if (!dr.IsDBNull(21))
                    {
                        u0.Day20 = dr.GetInt32(21);
                    }
                    if (!dr.IsDBNull(22))
                    {
                        u0.Day21 = dr.GetInt32(22);
                    }
                    if (!dr.IsDBNull(23))
                    {
                        u0.Day22 = dr.GetInt32(23);
                    }
                    if (!dr.IsDBNull(24))
                    {
                        u0.Day23 = dr.GetInt32(24);
                    }
                    if (!dr.IsDBNull(25))
                    {
                        u0.Day24 = dr.GetInt32(25);
                    }
                    if (!dr.IsDBNull(26))
                    {
                        u0.Day25 = dr.GetInt32(26);
                    }
                    if (!dr.IsDBNull(27))
                    {

                        u0.Day26 = dr.GetInt32(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        u0.Day27 = dr.GetInt32(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        u0.Day28 = dr.GetInt32(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        u0.Day29 = dr.GetInt32(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        u0.Day30 = dr.GetInt32(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        u0.Day31 = dr.GetInt32(32);
                    }
                    


                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询每天NG共31天
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Daily_NG_Model> Select_Daily_Data_NG(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Daily_NG_Model> u1 = new List<Daily_NG_Model>(); //新建一个User类的集合
                while (dr.Read())//遍历dr
                {
                    Daily_NG_Model u0 = new Daily_NG_Model();//新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    u0.Model = dr["Model"].ToString();

                    u0.Day1 = Convert.ToInt32(dr["Day1"]);
                    u0.Day2 = Convert.ToInt32(dr["Day2"]);
                    u0.Day3 = Convert.ToInt32(dr["Day3"]);
                    u0.Day4 = Convert.ToInt32(dr["Day4"]);
                    u0.Day5 = Convert.ToInt32(dr["Day5"]);
                    u0.Day6 = Convert.ToInt32(dr["Day6"]);
                    u0.Day7 = Convert.ToInt32(dr["Day7"]);
                    u0.Day8 = Convert.ToInt32(dr["Day8"]);
                    u0.Day9 = Convert.ToInt32(dr["Day9"]);
                    u0.Day10 = Convert.ToInt32(dr["Day10"]);

                    u0.Day11 = Convert.ToInt32(dr["Day11"]);
                    u0.Day12 = Convert.ToInt32(dr["Day12"]);
                    u0.Day13 = Convert.ToInt32(dr["Day13"]);
                    u0.Day14 = Convert.ToInt32(dr["Day14"]);
                    u0.Day15 = Convert.ToInt32(dr["Day15"]);
                    u0.Day16 = Convert.ToInt32(dr["Day16"]);
                    u0.Day17 = Convert.ToInt32(dr["Day17"]);
                    u0.Day18 = Convert.ToInt32(dr["Day18"]);
                    u0.Day19 = Convert.ToInt32(dr["Day19"]);
                    u0.Day20 = Convert.ToInt32(dr["Day20"]);

                    u0.Day21 = Convert.ToInt32(dr["Day21"]);
                    u0.Day22 = Convert.ToInt32(dr["Day22"]);
                    u0.Day23 = Convert.ToInt32(dr["Day23"]);
                    u0.Day24 = Convert.ToInt32(dr["Day24"]);
                    u0.Day25 = Convert.ToInt32(dr["Day25"]);
                    u0.Day26 = Convert.ToInt32(dr["Day26"]);
                    u0.Day27 = Convert.ToInt32(dr["Day27"]);
                    u0.Day28 = Convert.ToInt32(dr["Day28"]);
                    u0.Day29 = Convert.ToInt32(dr["Day29"]);
                    u0.Day30 = Convert.ToInt32(dr["Day30"]);

                    u0.Day31 = Convert.ToInt32(dr["Day31"]);
                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }



        /// <summary>
        /// 查询每月Output共12月
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Monthly_Output_PCTron> Select_Monthly_Data_Output(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Monthly_Output_PCTron> u1 = new List<Monthly_Output_PCTron>(); //新建一个User类的集合
                while (dr.Read())//遍历dr
                {
                    Monthly_Output_PCTron u0 = new Monthly_Output_PCTron();//新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    u0.Model = dr["Model"].ToString();

                    u0.Month1 = Convert.ToInt32(dr["Month1"]);
                    u0.Month2 = Convert.ToInt32(dr["Month2"]);
                    u0.Month3 = Convert.ToInt32(dr["Month3"]);
                    u0.Month4 = Convert.ToInt32(dr["Month4"]);
                    u0.Month5 = Convert.ToInt32(dr["Month5"]);
                    u0.Month6 = Convert.ToInt32(dr["Month6"]);
                    u0.Month7 = Convert.ToInt32(dr["Month7"]);
                    u0.Month8 = Convert.ToInt32(dr["Month8"]);
                    u0.Month9 = Convert.ToInt32(dr["Month9"]);
                    u0.Month10 = Convert.ToInt32(dr["Month10"]);

                    u0.Month11 = Convert.ToInt32(dr["Month11"]);
                    u0.Month12 = Convert.ToInt32(dr["Month12"]);

                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询每月NG共12月
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Monthly_NG_PCTron> Select_Monthly_Data_NG(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Monthly_NG_PCTron> u1 = new List<Monthly_NG_PCTron>(); //新建一个User类的集合
                while (dr.Read())//遍历dr
                {
                    Monthly_NG_PCTron u0 = new Monthly_NG_PCTron();//新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    u0.Model = dr["Model"].ToString();

                    u0.Month1 = Convert.ToInt32(dr["Month1"]);
                    u0.Month2 = Convert.ToInt32(dr["Month2"]);
                    u0.Month3 = Convert.ToInt32(dr["Month3"]);
                    u0.Month4 = Convert.ToInt32(dr["Month4"]);
                    u0.Month5 = Convert.ToInt32(dr["Month5"]);
                    u0.Month6 = Convert.ToInt32(dr["Month6"]);
                    u0.Month7 = Convert.ToInt32(dr["Month7"]);
                    u0.Month8 = Convert.ToInt32(dr["Month8"]);
                    u0.Month9 = Convert.ToInt32(dr["Month9"]);
                    u0.Month10 = Convert.ToInt32(dr["Month10"]);

                    u0.Month11 = Convert.ToInt32(dr["Month11"]);
                    u0.Month12 = Convert.ToInt32(dr["Month12"]);

                    u1.Add(u0);
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询实时报警信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Alarm_Messages> Alarm_real_time(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                List<Alarm_Messages> u1 = new List<Alarm_Messages>(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    Alarm_Messages u0 = new Alarm_Messages(); //新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    //if (dr["rownumber"] != DBNull.Value)
                    //{
                    //    u0.rownumber = Convert.ToInt64(dr["rownumber"]);
                    //}
                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.ID = Convert.ToInt32(dr["ID"]);

                    }
                    if (dr["LineID"] != DBNull.Value)
                    {
                        u0.LineID = dr["LineID"].ToString();
                    }
                    if (dr["StationID"] != DBNull.Value)
                    { 
                        u0.StationID = Convert.ToInt32(dr["StationID"]);
                    }
                    if (dr["WarnTime"] != DBNull.Value)
                    { 
                        u0.WarnTime = Convert.ToDateTime(dr["WarnTime"]);
                    }
                    if (dr["NormalTime"] != DBNull.Value)
                    {
                        u0.NormalTime = Convert.ToDateTime(dr["NormalTime"]);
                    }
                    if (dr["WarnID"] != DBNull.Value)
                    { 
                        u0.WarnID = dr["WarnID"].ToString();
                    }
                    if (dr["WarnExplain"] != DBNull.Value)
                    {
                        u0.WarnExplain = dr["WarnExplain"].ToString();
                    }
                    if (dr["Duration"] != DBNull.Value)
                    { 
                        u0.Duration = Convert.ToInt32(dr["Duration"]);
                    }
                    if (dr["IfCure"] != DBNull.Value)
                    { 
                        u0.IfCure = Convert.ToInt32(dr["IfCure"]);
                    }
                    

                    u1.Add(u0);

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        public List<Alarm_Messages> History_Alarm(string Alarm_SqlCon, String str)
        {
            using (SqlConnection conn = new SqlConnection(Alarm_SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                List<Alarm_Messages> u1 = new List<Alarm_Messages>(); //新建一个User类的集合


                while (dr.Read())//遍历dr
                {
                    Alarm_Messages u0 = new Alarm_Messages(); //新建一个对象

                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (dr["rownumber"] != DBNull.Value)
                    {
                        u0.rownumber = Convert.ToInt64(dr["rownumber"]);
                    }
                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.ID = Convert.ToInt32(dr["ID"]);

                    }
                    if (dr["LineID"] != DBNull.Value)
                    {
                        u0.LineID = dr["LineID"].ToString();
                    }
                    if (dr["StationID"] != DBNull.Value)
                    {
                        u0.StationID = Convert.ToInt32(dr["StationID"]);
                    }
                    if (dr["WarnTime"] != DBNull.Value)
                    {
                        u0.WarnTime = Convert.ToDateTime(dr["WarnTime"]);
                    }
                    if (dr["NormalTime"] != DBNull.Value)
                    {
                        u0.NormalTime = Convert.ToDateTime(dr["NormalTime"]);
                    }
                    if (dr["WarnID"] != DBNull.Value)
                    {
                        u0.WarnID = dr["WarnID"].ToString();
                    }
                    if (dr["WarnExplain"] != DBNull.Value)
                    {
                        u0.WarnExplain = dr["WarnExplain"].ToString();
                    }
                    if (dr["Duration"] != DBNull.Value)
                    {
                        u0.Duration = Convert.ToInt32(dr["Duration"]);
                    }
                    if (dr["IfCure"] != DBNull.Value)
                    {
                        u0.IfCure = Convert.ToInt32(dr["IfCure"]);
                    }

                    u1.Add(u0);

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询单个对象所有详细信息-单个对象
        /// </summary>
        /// <returns>用户类集合</returns>
        public RealTimePlantData Sel_RealTimePlantData(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_LocalServer))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                RealTimePlantData u1 = new RealTimePlantData(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["ID"] != DBNull.Value)
                    {
                        u1.ID = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["LineID"] != DBNull.Value)
                    {
                        u1.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["RecordTime"] != DBNull.Value)
                    {
                        u1.RecordTime = Convert.ToString(dr["RecordTime"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u1.ProductID = Convert.ToString(dr["ProductID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u1.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["DutTotalNum"] != DBNull.Value)
                    {
                        u1.DutTotalNum = Convert.ToInt32(dr["DutTotalNum"]);
                    }
                    if (dr["DutPassNum"] != DBNull.Value)
                    {
                        u1.DutPassNum = Convert.ToInt32(dr["DutPassNum"]);
                    }
                    if (dr["DutFailNum"] != DBNull.Value)
                    {
                        u1.DutFailNum = Convert.ToInt32(dr["DutFailNum"]);
                    }

                    if (dr["DutFailRate"] != DBNull.Value)
                    {
                        u1.DutFailRate = Convert.ToDouble(dr["DutFailRate"]);
                    }
                    if (dr["cap"] != DBNull.Value)
                    {
                        u1.cap = Convert.ToInt32(dr["cap"]);
                    }
                    if (dr["ESR"] != DBNull.Value)
                    {
                        u1.ESR = Convert.ToInt32(dr["ESR"]);
                    }
                    if (dr["Voltage"] != DBNull.Value)
                    {
                        u1.Voltage = Convert.ToInt32(dr["Voltage"]);
                    }
                    if (dr["HaltNum"] != DBNull.Value)
                    {
                        u1.HaltNum = Convert.ToInt32(dr["HaltNum"]);
                    }
                    if (dr["HaltTime"] != DBNull.Value)
                    {
                        u1.HaltTime = Convert.ToInt32(dr["HaltTime"]);
                    }
                    if (dr["DevStatus"] != DBNull.Value)
                    {
                        u1.DevStatus = Convert.ToInt32(dr["DevStatus"]);
                    }
                    if (dr["DeviceUseRate"] != DBNull.Value)
                    {
                        u1.DeviceUseRate = Convert.ToString(dr["DeviceUseRate"]);
                    }


                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }





        /// <summary>
        /// 执行sql语句，返回受影响的行数-select
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(SqlCon_Server);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            try
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行sql语句，返回受影响的行数-select
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteScalar_Alarm(string SqlCon_PCC,string sql)
        {
            SqlConnection conn = new SqlConnection(SqlCon_PCC);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            try
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        

        /// <summary>
        /// 将List内每一条插入语句插入到表
        /// </summary>
        /// <param name="SQLStringList"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand { Connection = conn };
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }

        public DataTable GetTable(string strSQL)
        {
            return GetTable(strSQL, null);
        }
        public DataTable GetTable(string strSQL, SqlParameter[] pas)
        {
            return GetTable(strSQL, pas, CommandType.Text);
        }
        /// <summary>
        /// 执行查询，返回DataTable对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataTable对象</returns>
        public DataTable GetTable(string strSQL, SqlParameter[] pas, CommandType cmdtype)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(SqlCon_Server))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
            }
            return dt;
        }

        public int ExecuteNonQuery_NetworkStatus(string safeSql)
        {
            using (SqlConnection Connection = new SqlConnection(SqlCon_Server))
            {
                Connection.Open();
                SqlTransaction trans = Connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(safeSql, Connection);
                    cmd.Transaction = trans;

                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {

                    return 0;
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行sql语句，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(SqlCon_Server);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
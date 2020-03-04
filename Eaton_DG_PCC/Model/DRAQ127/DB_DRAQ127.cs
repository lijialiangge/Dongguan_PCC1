using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Eaton_DG_PCC.Model.DRAQ127;
using Eaton_DG_PCC.Model.PCC;

namespace Eaton_DG_PCC.Model
{
    public class DB_DRAQ127
    {
        //public static string SqlCon = @"Data Source=ANDYLI\SQLEXPRESS;Initial Catalog=DRAQ127;User ID=sa;Password=ok;";
        public static string SqlCon_PCC1 = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["PCC1ConnectionString"]);


        /// <summary>
        /// 查询OEE报表
        /// </summary>
        /// <returns>OEE集合</returns>
        public List<OEE> oee(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<OEE> u1 = new List<OEE>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    OEE u0 = new OEE();
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
                        u0.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u0.ProductID = Convert.ToString(dr["ProductID"]);
                    }
                    if (dr["InputTime"] != DBNull.Value)
                    {
                        u0.InputTime = Convert.ToDateTime(dr["InputTime"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["TraySN"] != DBNull.Value)
                    {
                        u0.TraySN = Convert.ToString(dr["TraySN"]);
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

                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询PO报表
        /// </summary>
        /// <returns>PO集合</returns>
        public List<PO> po(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<PO> u1 = new List<PO>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    PO u0 = new PO();
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
                        u0.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["StationID"] != DBNull.Value)
                    {
                        u0.StationID = Convert.ToString(dr["StationID"]);
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
                    



                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询Daily_Output报表
        /// </summary>
        /// <returns>Daily_Output集合</returns>
        public List<Daily_Output> daily_output(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Daily_Output> u1 = new List<Daily_Output>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Daily_Output u0 = new Daily_Output();
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
                        u0.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["RecordTime"] != DBNull.Value)
                    {
                        u0.RecordTime = Convert.ToDateTime(dr["RecordTime"]);
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
                        u0.DutFailRate = Convert.ToInt32(dr["DutFailRate"]);
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
        /// 查询Monthly_Output报表
        /// </summary>
        /// <returns>Monthly_Output集合</returns>
        public List<Monthly_Output> month_output(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Monthly_Output> u1 = new List<Monthly_Output>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Monthly_Output u0 = new Monthly_Output();
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
                        u0.LineID = Convert.ToString(dr["LineID"]);
                    }
                    if (dr["UpdateTime"] != DBNull.Value)
                    {
                        u0.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
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
                        u0.DutFailRate = Convert.ToInt32(dr["DutFailRate"]);
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


                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }


        /// <summary>
        /// 查询Cap_Output报表
        /// </summary>
        /// <returns>Cap_Output集合</returns>
        public List<Cap> Cap_output(string SqlCon_PCC, String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Cap> u1 = new List<Cap>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Cap u0 = new Cap();
                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["rownumber"] != DBNull.Value)
                    {
                        u0.rownumber = Convert.ToInt64(dr["rownumber"]);
                    }
                    if (dr["DutID"] != DBNull.Value)
                    {
                        u0.DutID = Convert.ToInt32(dr["DutID"]);
                    }
                    if (dr["InputTime"] != DBNull.Value)
                    {
                        u0.InputTime = Convert.ToDateTime(dr["InputTime"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u0.ProductID = Convert.ToInt32(dr["ProductID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["TraySN"] != DBNull.Value)
                    {
                        u0.TraySN = Convert.ToString(dr["TraySN"]);
                    }
                    if (dr["Position"] != DBNull.Value)
                    {
                        u0.Position = Convert.ToInt32(dr["Position"]);
                    }
                    if (dr["State"] != DBNull.Value)
                    {
                        u0.State = Convert.ToString(dr["State"]);
                    }
                    if (dr["CapValue"] != DBNull.Value)
                    {
                        u0.CapValue = Convert.ToDouble(dr["CapValue"]);
                    }
                    if (dr["ResValue"] != DBNull.Value)
                    {
                        u0.ResValue = Convert.ToDouble(dr["ResValue"]);
                    }
                    if (dr["OutputTime"] != DBNull.Value)
                    {
                        u0.OutputTime = Convert.ToDateTime(dr["OutputTime"]);
                    }


                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }

        /// <summary>
        /// 查询ESR_Output报表
        /// </summary>
        /// <returns>Cap_Output集合</returns>
        public List<ESR> ESR_output(string SqlCon_PCC, String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<ESR> u1 = new List<ESR>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    ESR u0 = new ESR();
                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["rownumber"] != DBNull.Value)
                    {
                        u0.rownumber = Convert.ToInt64(dr["rownumber"]);
                    }
                    if (dr["DutID"] != DBNull.Value)
                    {
                        u0.DutID = Convert.ToInt32(dr["DutID"]);
                    }
                    if (dr["InputTime"] != DBNull.Value)
                    {
                        u0.InputTime = Convert.ToDateTime(dr["InputTime"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u0.ProductID = Convert.ToInt32(dr["ProductID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["TraySN"] != DBNull.Value)
                    {
                        u0.TraySN = Convert.ToString(dr["TraySN"]);
                    }
                    if (dr["Position"] != DBNull.Value)
                    {
                        u0.Position = Convert.ToInt32(dr["Position"]);
                    }
                    if (dr["State"] != DBNull.Value)
                    {
                        u0.State = Convert.ToString(dr["State"]);
                    }
                    if (dr["EqualRes"] != DBNull.Value)
                    {
                        u0.EqualRes = Convert.ToDouble(dr["EqualRes"]);
                    }
                    if (dr["OutputTime"] != DBNull.Value)
                    {
                        u0.OutputTime = Convert.ToDateTime(dr["OutputTime"]);
                    }


                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }



        /// <summary>
        /// 查询Voltage_Output报表
        /// </summary>
        /// <returns>Voltage_Output集合</returns>
        public List<Voltage> Voltage_output(string SqlCon_PCC, String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Voltage> u1 = new List<Voltage>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Voltage u0 = new Voltage();
                    //把查询的当前记录各字段值赋值给对于的u0的属性

                    if (dr["rownumber"] != DBNull.Value)
                    {
                        u0.rownumber = Convert.ToInt64(dr["rownumber"]);
                    }
                    if (dr["DutID"] != DBNull.Value)
                    {
                        u0.DutID = Convert.ToInt32(dr["DutID"]);
                    }
                    if (dr["InputTime"] != DBNull.Value)
                    {
                        u0.InputTime = Convert.ToDateTime(dr["InputTime"]);
                    }
                    if (dr["ProductID"] != DBNull.Value)
                    {
                        u0.ProductID = Convert.ToInt32(dr["ProductID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.DutMode = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["TraySN"] != DBNull.Value)
                    {
                        u0.TraySN = Convert.ToString(dr["TraySN"]);
                    }
                    if (dr["Position"] != DBNull.Value)
                    {
                        u0.Position = Convert.ToInt32(dr["Position"]);
                    }
                    if (dr["State"] != DBNull.Value)
                    {
                        u0.State = Convert.ToString(dr["State"]);
                    }
                    if (dr["ResidueVol"] != DBNull.Value)
                    {
                        u0.ResidueVol = Convert.ToDouble(dr["ResidueVol"]);
                    }
                    if (dr["EndVol"] != DBNull.Value)
                    {
                        u0.EndVol = Convert.ToDouble(dr["EndVol"]);
                    }
                    if (dr["OutputTime"] != DBNull.Value)
                    {
                        u0.OutputTime = Convert.ToDateTime(dr["OutputTime"]);
                    }


                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }



        /// <summary>
        /// 查询单站大屏Top5_Now_Mode信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<NowModelTop5> Top5_Now_Model(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC1))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<NowModelTop5> u1 = new List<NowModelTop5>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    NowModelTop5 u0 = new NowModelTop5();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }




        /// <summary>
        ///查询最近生产的5种型号每月产量Top 5 Monthly Output
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Monthly_OutputAndNG> select_top5_monthly_output(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<Monthly_OutputAndNG> u1 = new List<Monthly_OutputAndNG>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    Monthly_OutputAndNG u0 = new Monthly_OutputAndNG();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.ID = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.Model = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["Month1Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly01 = Convert.ToInt32(dr["Month1Out"]);
                    }
                    if (dr["Month2Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly02 = Convert.ToInt32(dr["Month2Out"]);
                    }
                    if (dr["Month3Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly03 = Convert.ToInt32(dr["Month3Out"]);
                    }
                    if (dr["Month4Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly04 = Convert.ToInt32(dr["Month4Out"]);
                    }
                    if (dr["Month5Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly05 = Convert.ToInt32(dr["Month5Out"]);
                    }
                    if (dr["Month6Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly06 = Convert.ToInt32(dr["Month6Out"]);
                    }
                    if (dr["Month7Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly07 = Convert.ToInt32(dr["Month7Out"]);
                    }
                    if (dr["Month8Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly08 = Convert.ToInt32(dr["Month8Out"]);
                    }
                    if (dr["Month9Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly09 = Convert.ToInt32(dr["Month9Out"]);
                    }
                    if (dr["Month10Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly10 = Convert.ToInt32(dr["Month10Out"]);
                    }
                    if (dr["Month11Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly11 = Convert.ToInt32(dr["Month11Out"]);
                    }
                    if (dr["Month12Out"] != DBNull.Value)
                    {
                        u0.Output_Monthly12 = Convert.ToInt32(dr["Month12Out"]);
                    }
                    if (dr["Month1NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly01 = Convert.ToInt32(dr["Month1NG"]);
                    }
                    if (dr["Month2NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly02 = Convert.ToInt32(dr["Month2NG"]);
                    }
                    if (dr["Month3NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly03 = Convert.ToInt32(dr["Month3NG"]);
                    }
                    if (dr["Month4NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly04 = Convert.ToInt32(dr["Month4NG"]);
                    }
                    if (dr["Month5NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly05 = Convert.ToInt32(dr["Month5NG"]);
                    }
                    if (dr["Month6NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly06 = Convert.ToInt32(dr["Month6NG"]);
                    }
                    if (dr["Month7NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly07 = Convert.ToInt32(dr["Month7NG"]);
                    }
                    if (dr["Month8NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly08 = Convert.ToInt32(dr["Month8NG"]);
                    }
                    if (dr["Month9NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly09 = Convert.ToInt32(dr["Month9NG"]);
                    }
                    if (dr["Month10NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly10 = Convert.ToInt32(dr["Month10NG"]);
                    }
                    if (dr["Month11NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly11 = Convert.ToInt32(dr["Month11NG"]);
                    }
                    if (dr["Month12NG"] != DBNull.Value)
                    {
                        u0.NG_Monthly12 = Convert.ToInt32(dr["Month12NG"]);
                    }
                    if (dr["Month1Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly01 = Convert.ToInt32(dr["Month1Cap"]);
                    }
                    if (dr["Month2Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly02 = Convert.ToInt32(dr["Month2Cap"]);
                    }
                    if (dr["Month3Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly03 = Convert.ToInt32(dr["Month3Cap"]);
                    }
                    if (dr["Month4Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly04 = Convert.ToInt32(dr["Month4Cap"]);
                    }
                    if (dr["Month5Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly05 = Convert.ToInt32(dr["Month5Cap"]);
                    }
                    if (dr["Month6Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly06 = Convert.ToInt32(dr["Month6Cap"]);
                    }
                    if (dr["Month7Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly07 = Convert.ToInt32(dr["Month7Cap"]);
                    }
                    if (dr["Month8Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly08 = Convert.ToInt32(dr["Month8Cap"]);
                    }
                    if (dr["Month9Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly09 = Convert.ToInt32(dr["Month9Cap"]);
                    }
                    if (dr["Month10Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly10 = Convert.ToInt32(dr["Month10Cap"]);
                    }
                    if (dr["Month11Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly11 = Convert.ToInt32(dr["Month11Cap"]);
                    }
                    if (dr["Month12Cap"] != DBNull.Value)
                    {
                        u0.Cap_Monthly12 = Convert.ToInt32(dr["Month12Cap"]);
                    }
                    if (dr["Month1ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly01 = Convert.ToInt32(dr["Month1ESR"]);
                    }
                    if (dr["Month2ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly02 = Convert.ToInt32(dr["Month2ESR"]);
                    }
                    if (dr["Month3ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly03 = Convert.ToInt32(dr["Month3ESR"]);
                    }
                    if (dr["Month4ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly04 = Convert.ToInt32(dr["Month4ESR"]);
                    }
                    if (dr["Month5ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly05 = Convert.ToInt32(dr["Month5ESR"]);
                    }
                    if (dr["Month6ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly06 = Convert.ToInt32(dr["Month6ESR"]);
                    }
                    if (dr["Month7ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly07 = Convert.ToInt32(dr["Month7ESR"]);
                    }
                    if (dr["Month8ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly08 = Convert.ToInt32(dr["Month8ESR"]);
                    }
                    if (dr["Month9ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly09 = Convert.ToInt32(dr["Month9ESR"]);
                    }
                    if (dr["Month10ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly10 = Convert.ToInt32(dr["Month10ESR"]);
                    }
                    if (dr["Month11ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly11 = Convert.ToInt32(dr["Month11ESR"]);
                    }
                    if (dr["Month12ESR"] != DBNull.Value)
                    {
                        u0.ESR_Monthly12 = Convert.ToInt32(dr["Month12ESR"]);
                    }
                    if (dr["Month1Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly01 = Convert.ToInt32(dr["Month1Voltage"]);
                    }
                    if (dr["Month2Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly02 = Convert.ToInt32(dr["Month2Voltage"]);
                    }
                    if (dr["Month3Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly03 = Convert.ToInt32(dr["Month3Voltage"]);
                    }
                    if (dr["Month4Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly04 = Convert.ToInt32(dr["Month4Voltage"]);
                    }
                    if (dr["Month5Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly05 = Convert.ToInt32(dr["Month5Voltage"]);
                    }
                    if (dr["Month6Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly06 = Convert.ToInt32(dr["Month6Voltage"]);
                    }
                    if (dr["Month7Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly07 = Convert.ToInt32(dr["Month7Voltage"]);
                    }
                    if (dr["Month8Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly08 = Convert.ToInt32(dr["Month8Voltage"]);
                    }
                    if (dr["Month9Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly09 = Convert.ToInt32(dr["Month9Voltage"]);
                    }
                    if (dr["Month10Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly10 = Convert.ToInt32(dr["Month10Voltage"]);
                    }
                    if (dr["Month11Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly11 = Convert.ToInt32(dr["Month11Voltage"]);
                    }
                    if (dr["Month12Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Monthly12 = Convert.ToInt32(dr["Month12Voltage"]);
                    }



                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }





        /// <summary>
        /// 查询最近生产的5种型号每天产量Top 5 Monthly Output
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<EveryDay_OutputAndNG> select_top5_daily_output(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<EveryDay_OutputAndNG> u1 = new List<EveryDay_OutputAndNG>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    EveryDay_OutputAndNG u0 = new EveryDay_OutputAndNG();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (dr["ID"] != DBNull.Value)
                    {
                        u0.ID = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["DutMode"] != DBNull.Value)
                    {
                        u0.Model = Convert.ToString(dr["DutMode"]);
                    }
                    if (dr["Day1Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday01 = Convert.ToInt32(dr["Day1Out"]);
                    }
                    if (dr["Day2Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday02 = Convert.ToInt32(dr["Day2Out"]);
                    }
                    if (dr["Day3Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday03 = Convert.ToInt32(dr["Day3Out"]);
                    }
                    if (dr["Day4Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday04 = Convert.ToInt32(dr["Day4Out"]);
                    }
                    if (dr["Day5Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday05 = Convert.ToInt32(dr["Day5Out"]);
                    }
                    if (dr["Day6Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday06 = Convert.ToInt32(dr["Day6Out"]);
                    }
                    if (dr["Day7Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday07 = Convert.ToInt32(dr["Day7Out"]);
                    }
                    if (dr["Day8Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday08 = Convert.ToInt32(dr["Day8Out"]);
                    }
                    if (dr["Day9Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday09 = Convert.ToInt32(dr["Day9Out"]);
                    }
                    if (dr["Day10Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday10 = Convert.ToInt32(dr["Day10Out"]);
                    }
                    if (dr["Day11Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday11 = Convert.ToInt32(dr["Day11Out"]);
                    }
                    if (dr["Day12Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday12 = Convert.ToInt32(dr["Day12Out"]);
                    }
                    if (dr["Day13Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday13 = Convert.ToInt32(dr["Day13Out"]);
                    }
                    if (dr["Day14Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday14 = Convert.ToInt32(dr["Day14Out"]);
                    }
                    if (dr["Day15Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday15 = Convert.ToInt32(dr["Day15Out"]);
                    }
                    if (dr["Day16Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday16 = Convert.ToInt32(dr["Day16Out"]);
                    }
                    if (dr["Day17Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday17 = Convert.ToInt32(dr["Day17Out"]);
                    }
                    if (dr["Day18Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday18 = Convert.ToInt32(dr["Day18Out"]);
                    }
                    if (dr["Day19Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday19 = Convert.ToInt32(dr["Day19Out"]);
                    }
                    if (dr["Day20Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday20 = Convert.ToInt32(dr["Day20Out"]);
                    }
                    if (dr["Day21Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday21 = Convert.ToInt32(dr["Day21Out"]);
                    }
                    if (dr["Day22Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday22 = Convert.ToInt32(dr["Day22Out"]);
                    }
                    if (dr["Day23Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday23 = Convert.ToInt32(dr["Day23Out"]);
                    }
                    if (dr["Day24Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday24 = Convert.ToInt32(dr["Day24Out"]);
                    }
                    if (dr["Day25Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday25 = Convert.ToInt32(dr["Day25Out"]);
                    }
                    if (dr["Day26Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday26 = Convert.ToInt32(dr["Day26Out"]);
                    }
                    if (dr["Day27Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday27 = Convert.ToInt32(dr["Day27Out"]);
                    }
                    if (dr["Day28Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday28 = Convert.ToInt32(dr["Day28Out"]);
                    }
                    if (dr["Day29Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday29 = Convert.ToInt32(dr["Day29Out"]);
                    }
                    if (dr["Day30Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday30 = Convert.ToInt32(dr["Day30Out"]);
                    }
                    if (dr["Day31Out"] != DBNull.Value)
                    {
                        u0.Output_Everyday31 = Convert.ToInt32(dr["Day31Out"]);
                    }

                    if (dr["Day1NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday01 = Convert.ToInt32(dr["Day1NG"]);
                    }
                    if (dr["Day2NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday02 = Convert.ToInt32(dr["Day2NG"]);
                    }
                    if (dr["Day3NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday03 = Convert.ToInt32(dr["Day3NG"]);
                    }
                    if (dr["Day4NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday04 = Convert.ToInt32(dr["Day4NG"]);
                    }
                    if (dr["Day5NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday05 = Convert.ToInt32(dr["Day5NG"]);
                    }
                    if (dr["Day6NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday06 = Convert.ToInt32(dr["Day6NG"]);
                    }
                    if (dr["Day7NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday07 = Convert.ToInt32(dr["Day7NG"]);
                    }
                    if (dr["Day8NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday08 = Convert.ToInt32(dr["Day8NG"]);
                    }
                    if (dr["Day9NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday09 = Convert.ToInt32(dr["Day9NG"]);
                    }
                    if (dr["Day10NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday10 = Convert.ToInt32(dr["Day10NG"]);
                    }
                    if (dr["Day11NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday11 = Convert.ToInt32(dr["Day11NG"]);
                    }
                    if (dr["Day12NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday12 = Convert.ToInt32(dr["Day12NG"]);
                    }
                    if (dr["Day13NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday13 = Convert.ToInt32(dr["Day13NG"]);
                    }
                    if (dr["Day14NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday14 = Convert.ToInt32(dr["Day14NG"]);
                    }
                    if (dr["Day15NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday15 = Convert.ToInt32(dr["Day15NG"]);
                    }
                    if (dr["Day16NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday16 = Convert.ToInt32(dr["Day16NG"]);
                    }
                    if (dr["Day17NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday17 = Convert.ToInt32(dr["Day17NG"]);
                    }
                    if (dr["Day18NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday18 = Convert.ToInt32(dr["Day18NG"]);
                    }
                    if (dr["Day19NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday19 = Convert.ToInt32(dr["Day19NG"]);
                    }
                    if (dr["Day20NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday20 = Convert.ToInt32(dr["Day20NG"]);
                    }
                    if (dr["Day21NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday21 = Convert.ToInt32(dr["Day21NG"]);
                    }
                    if (dr["Day22NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday22 = Convert.ToInt32(dr["Day22NG"]);
                    }
                    if (dr["Day23NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday23 = Convert.ToInt32(dr["Day23NG"]);
                    }
                    if (dr["Day24NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday24 = Convert.ToInt32(dr["Day24NG"]);
                    }
                    if (dr["Day25NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday25 = Convert.ToInt32(dr["Day25NG"]);
                    }
                    if (dr["Day26NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday26 = Convert.ToInt32(dr["Day26NG"]);
                    }
                    if (dr["Day27NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday27 = Convert.ToInt32(dr["Day27NG"]);
                    }
                    if (dr["Day28NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday28 = Convert.ToInt32(dr["Day28NG"]);
                    }
                    if (dr["Day29NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday29 = Convert.ToInt32(dr["Day29NG"]);
                    }
                    if (dr["Day30NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday30 = Convert.ToInt32(dr["Day30NG"]);
                    }
                    if (dr["Day31NG"] != DBNull.Value)
                    {
                        u0.NG_Everyday31 = Convert.ToInt32(dr["Day31NG"]);
                    }

                    if (dr["Day1Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday01 = Convert.ToInt32(dr["Day1Cap"]);
                    }
                    if (dr["Day2Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday02 = Convert.ToInt32(dr["Day2Cap"]);
                    }
                    if (dr["Day3Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday03 = Convert.ToInt32(dr["Day3Cap"]);
                    }
                    if (dr["Day4Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday04 = Convert.ToInt32(dr["Day4Cap"]);
                    }
                    if (dr["Day5Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday05 = Convert.ToInt32(dr["Day5Cap"]);
                    }
                    if (dr["Day6Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday06 = Convert.ToInt32(dr["Day6Cap"]);
                    }
                    if (dr["Day7Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday07 = Convert.ToInt32(dr["Day7Cap"]);
                    }
                    if (dr["Day8Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday08 = Convert.ToInt32(dr["Day8Cap"]);
                    }
                    if (dr["Day9Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday09 = Convert.ToInt32(dr["Day9Cap"]);
                    }
                    if (dr["Day10Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday10 = Convert.ToInt32(dr["Day10Cap"]);
                    }
                    if (dr["Day11Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday11 = Convert.ToInt32(dr["Day11Cap"]);
                    }
                    if (dr["Day12Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday12 = Convert.ToInt32(dr["Day12Cap"]);
                    }
                    if (dr["Day13Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday13 = Convert.ToInt32(dr["Day13Cap"]);
                    }
                    if (dr["Day14Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday14 = Convert.ToInt32(dr["Day14Cap"]);
                    }
                    if (dr["Day15Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday15 = Convert.ToInt32(dr["Day15Cap"]);
                    }
                    if (dr["Day16Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday16 = Convert.ToInt32(dr["Day16Cap"]);
                    }
                    if (dr["Day17Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday17 = Convert.ToInt32(dr["Day17Cap"]);
                    }
                    if (dr["Day18Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday18 = Convert.ToInt32(dr["Day18Cap"]);
                    }
                    if (dr["Day19Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday19 = Convert.ToInt32(dr["Day19Cap"]);
                    }
                    if (dr["Day20Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday20 = Convert.ToInt32(dr["Day20Cap"]);
                    }
                    if (dr["Day21Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday21 = Convert.ToInt32(dr["Day21Cap"]);
                    }
                    if (dr["Day22Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday22 = Convert.ToInt32(dr["Day22Cap"]);
                    }
                    if (dr["Day23Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday23 = Convert.ToInt32(dr["Day23Cap"]);
                    }
                    if (dr["Day24Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday24 = Convert.ToInt32(dr["Day24Cap"]);
                    }
                    if (dr["Day25Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday25 = Convert.ToInt32(dr["Day25Cap"]);
                    }
                    if (dr["Day26Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday26 = Convert.ToInt32(dr["Day26Cap"]);
                    }
                    if (dr["Day27Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday27 = Convert.ToInt32(dr["Day27Cap"]);
                    }
                    if (dr["Day28Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday28 = Convert.ToInt32(dr["Day28Cap"]);
                    }
                    if (dr["Day29Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday29 = Convert.ToInt32(dr["Day29Cap"]);
                    }
                    if (dr["Day30Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday30 = Convert.ToInt32(dr["Day30Cap"]);
                    }
                    if (dr["Day31Cap"] != DBNull.Value)
                    {
                        u0.Cap_Everyday31 = Convert.ToInt32(dr["Day31Cap"]);
                    }

                    if (dr["Day1ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday01 = Convert.ToInt32(dr["Day1ESR"]);
                    }
                    if (dr["Day2ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday02 = Convert.ToInt32(dr["Day2ESR"]);
                    }
                    if (dr["Day3ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday03 = Convert.ToInt32(dr["Day3ESR"]);
                    }
                    if (dr["Day4ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday04 = Convert.ToInt32(dr["Day4ESR"]);
                    }
                    if (dr["Day5ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday05 = Convert.ToInt32(dr["Day5ESR"]);
                    }
                    if (dr["Day6ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday06 = Convert.ToInt32(dr["Day6ESR"]);
                    }
                    if (dr["Day7ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday07 = Convert.ToInt32(dr["Day7ESR"]);
                    }
                    if (dr["Day8ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday08 = Convert.ToInt32(dr["Day8ESR"]);
                    }
                    if (dr["Day9ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday09 = Convert.ToInt32(dr["Day9ESR"]);
                    }
                    if (dr["Day10ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday10 = Convert.ToInt32(dr["Day10ESR"]);
                    }
                    if (dr["Day11ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday11 = Convert.ToInt32(dr["Day11ESR"]);
                    }
                    if (dr["Day12ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday12 = Convert.ToInt32(dr["Day12ESR"]);
                    }
                    if (dr["Day13ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday13 = Convert.ToInt32(dr["Day13ESR"]);
                    }
                    if (dr["Day14ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday14 = Convert.ToInt32(dr["Day14ESR"]);
                    }
                    if (dr["Day15ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday15 = Convert.ToInt32(dr["Day15ESR"]);
                    }
                    if (dr["Day16ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday16 = Convert.ToInt32(dr["Day16ESR"]);
                    }
                    if (dr["Day17ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday17 = Convert.ToInt32(dr["Day17ESR"]);
                    }
                    if (dr["Day18ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday18 = Convert.ToInt32(dr["Day18ESR"]);
                    }
                    if (dr["Day19ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday19 = Convert.ToInt32(dr["Day19ESR"]);
                    }
                    if (dr["Day20ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday20 = Convert.ToInt32(dr["Day20ESR"]);
                    }
                    if (dr["Day21ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday21 = Convert.ToInt32(dr["Day21ESR"]);
                    }
                    if (dr["Day22ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday22 = Convert.ToInt32(dr["Day22ESR"]);
                    }
                    if (dr["Day23ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday23 = Convert.ToInt32(dr["Day23ESR"]);
                    }
                    if (dr["Day24ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday24 = Convert.ToInt32(dr["Day24ESR"]);
                    }
                    if (dr["Day25ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday25 = Convert.ToInt32(dr["Day25ESR"]);
                    }
                    if (dr["Day26ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday26 = Convert.ToInt32(dr["Day26ESR"]);
                    }
                    if (dr["Day27ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday27 = Convert.ToInt32(dr["Day27ESR"]);
                    }
                    if (dr["Day28ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday28 = Convert.ToInt32(dr["Day28ESR"]);
                    }
                    if (dr["Day29ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday29 = Convert.ToInt32(dr["Day29ESR"]);
                    }
                    if (dr["Day30ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday30 = Convert.ToInt32(dr["Day30ESR"]);
                    }
                    if (dr["Day31ESR"] != DBNull.Value)
                    {
                        u0.ESR_Everyday31 = Convert.ToInt32(dr["Day31ESR"]);
                    }

                    if (dr["Day1Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday01 = Convert.ToInt32(dr["Day1Voltage"]);
                    }
                    if (dr["Day2Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday02 = Convert.ToInt32(dr["Day2Voltage"]);
                    }
                    if (dr["Day3Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday03 = Convert.ToInt32(dr["Day3Voltage"]);
                    }
                    if (dr["Day4Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday04 = Convert.ToInt32(dr["Day4Voltage"]);
                    }
                    if (dr["Day5Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday05 = Convert.ToInt32(dr["Day5Voltage"]);
                    }
                    if (dr["Day6Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday06 = Convert.ToInt32(dr["Day6Voltage"]);
                    }
                    if (dr["Day7Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday07 = Convert.ToInt32(dr["Day7Voltage"]);
                    }
                    if (dr["Day8Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday08 = Convert.ToInt32(dr["Day8Voltage"]);
                    }
                    if (dr["Day9Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday09 = Convert.ToInt32(dr["Day9Voltage"]);
                    }
                    if (dr["Day10Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday10 = Convert.ToInt32(dr["Day10Voltage"]);
                    }
                    if (dr["Day11Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday11 = Convert.ToInt32(dr["Day11Voltage"]);
                    }
                    if (dr["Day12Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday12 = Convert.ToInt32(dr["Day12Voltage"]);
                    }
                    if (dr["Day13Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday13 = Convert.ToInt32(dr["Day13Voltage"]);
                    }
                    if (dr["Day14Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday14 = Convert.ToInt32(dr["Day14Voltage"]);
                    }
                    if (dr["Day15Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday15 = Convert.ToInt32(dr["Day15Voltage"]);
                    }
                    if (dr["Day16Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday16 = Convert.ToInt32(dr["Day16Voltage"]);
                    }
                    if (dr["Day17Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday17 = Convert.ToInt32(dr["Day17Voltage"]);
                    }
                    if (dr["Day18Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday18 = Convert.ToInt32(dr["Day18Voltage"]);
                    }
                    if (dr["Day19Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday19 = Convert.ToInt32(dr["Day19Voltage"]);
                    }
                    if (dr["Day20Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday20 = Convert.ToInt32(dr["Day20Voltage"]);
                    }
                    if (dr["Day21Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday21 = Convert.ToInt32(dr["Day21Voltage"]);
                    }
                    if (dr["Day22Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday22 = Convert.ToInt32(dr["Day22Voltage"]);
                    }
                    if (dr["Day23Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday23 = Convert.ToInt32(dr["Day23Voltage"]);
                    }
                    if (dr["Day24Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday24 = Convert.ToInt32(dr["Day24Voltage"]);
                    }
                    if (dr["Day25Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday25 = Convert.ToInt32(dr["Day25Voltage"]);
                    }
                    if (dr["Day26Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday26 = Convert.ToInt32(dr["Day26Voltage"]);
                    }
                    if (dr["Day27Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday27 = Convert.ToInt32(dr["Day27Voltage"]);
                    }
                    if (dr["Day28Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday28 = Convert.ToInt32(dr["Day28Voltage"]);
                    }
                    if (dr["Day29Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday29 = Convert.ToInt32(dr["Day29Voltage"]);
                    }
                    if (dr["Day30Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday30 = Convert.ToInt32(dr["Day30Voltage"]);
                    }
                    if (dr["Day31Voltage"] != DBNull.Value)
                    {
                        u0.Vol_Everyday31 = Convert.ToInt32(dr["Day31Voltage"]);
                    }


                    u1.Add(u0);//把有数据的u0加入到User类的集合

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
        public  int ExecuteScalar(string SqlCon_PCC,string sql)
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

        


    }
}
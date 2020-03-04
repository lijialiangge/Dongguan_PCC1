using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Eaton_DG_PCC.Model.DRAQ127;
using Eaton_DG_PCC.Models;
using Eaton_DG_PCC.Model.PCC;

namespace Eaton_DG_PCC.Model
{
    public class DB_Single_station
    {
        //public static string SqlCon_All = @"Data Source=ANDYLI\SQLEXPRESS;Initial Catalog=DRAQ127;User ID=sa;Password=ok;";
        
        public static string SqlCon_All = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionString"]);
        public static string SqlCon_PCC1 = ConfigurationManager.ConnectionStrings["PCC1ConnectionString"].ToString();


        /// <summary>
        /// 查询单站大屏Top5_Now_Mode_Output信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<NowModelTop5Output> Top5_Output(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC1))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<NowModelTop5Output> u1 = new List<NowModelTop5Output>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    NowModelTop5Output u0 = new NowModelTop5Output();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (!dr.IsDBNull(0))
                    {
                        u0.years = dr.GetInt32(0);
                    }
                    if (!dr.IsDBNull(1))
                    {
                        u0.months = dr.GetInt32(1);
                    }
                    if (!dr.IsDBNull(2))
                    {
                        u0.days = dr.GetInt32(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        u0.Output_Model1 = dr.GetInt32(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        u0.Output_Model2 = dr.GetInt32(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        u0.Output_Model3 = dr.GetInt32(5);
                    }
                    if (!dr.IsDBNull(6))
                    {
                        u0.Output_Model4 = dr.GetInt32(6);
                    }
                    if (!dr.IsDBNull(7))
                    {
                        u0.Output_Model5 = dr.GetInt32(7);
                    }
                  
                    u1.Add(u0);//把有数据的u0加入到User类的集合

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }



        /// <summary>
        /// 查询单站大屏Output and NG信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public Models.Monthly_Output_Model Monthly_OutputAndNGs(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC1))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                Models.Monthly_Output_Model u0 = new Models.Monthly_Output_Model(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性


                    if (!dr.IsDBNull(0))
                    {
                        u0.ID = dr.GetInt32(0);
                    }
                    if (!dr.IsDBNull(1))
                    {
                        u0.Ts = dr.GetDateTime(1);
                    }
                    if (!dr.IsDBNull(2))
                    {
                        u0.Years = dr.GetInt32(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        u0.Months = dr.GetInt32(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        u0.Days = dr.GetInt32(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        u0.Q127_100 = dr.GetInt32(5);
                    }
                    if (!dr.IsDBNull(6))
                    {
                        u0.Q127_150 = dr.GetInt32(6);
                    }
                    if (!dr.IsDBNull(7))
                    {
                        u0.Q127_220 = dr.GetInt32(7);
                    }
                    if (!dr.IsDBNull(8))
                    {
                        u0.Q127_330 = dr.GetInt32(8);
                    }
                    if (!dr.IsDBNull(9))
                    {
                        u0.Q127_470 = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        u0.A127_R47 = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        u0.A127_1R0 = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        u0.A127_1R5 = dr.GetInt32(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        u0.A127_2R2 = dr.GetInt32(13);
                    }
                    if (!dr.IsDBNull(14))
                    {
                        u0.A127_3R3 = dr.GetInt32(14);
                    }
                    if (!dr.IsDBNull(15))
                    {

                        u0.A127_4R7 = dr.GetInt32(15);
                    }
                    if (!dr.IsDBNull(16))
                    {
                        u0.A127_6R8 = dr.GetInt32(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        u0.A127_8R2 = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        u0.A127_100 = dr.GetInt32(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        u0.A127_150 = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        u0.A127_220 = dr.GetInt32(20);
                    }
                    if (!dr.IsDBNull(21))
                    {
                        u0.A127_330 = dr.GetInt32(21);
                    }
                    if (!dr.IsDBNull(22))
                    {
                        u0.A127_470 = dr.GetInt32(22);
                    }
                    if (!dr.IsDBNull(23))
                    {
                        u0.A127_680 = dr.GetInt32(23);
                    }
                    if (!dr.IsDBNull(24))
                    {
                        u0.A127_820 = dr.GetInt32(24);
                    }
                    if (!dr.IsDBNull(25))
                    {
                        u0.A127_101 = dr.GetInt32(25);
                    }
                    if (!dr.IsDBNull(26))
                    {
                        u0.A127_151 = dr.GetInt32(26);
                    }
                    if (!dr.IsDBNull(27))
                    {

                        u0.A127_221 = dr.GetInt32(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        u0.A127_331 = dr.GetInt32(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        u0.A127_471 = dr.GetInt32(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        u0.A127_681 = dr.GetInt32(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        u0.A127_821 = dr.GetInt32(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        u0.A127_102 = dr.GetInt32(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        u0.A125_R47 = dr.GetInt32(33);
                    }
                    if (!dr.IsDBNull(34))
                    {
                        u0.A125_1R0 = dr.GetInt32(34);
                    }
                    if (!dr.IsDBNull(35))
                    {
                        u0.A125_1R5 = dr.GetInt32(35);
                    }
                    if (!dr.IsDBNull(36))
                    {
                        u0.A125_2R2 = dr.GetInt32(36);
                    }
                    if (!dr.IsDBNull(37))
                    {

                        u0.A125_3R3 = dr.GetInt32(37);
                    }
                    if (!dr.IsDBNull(38))
                    {
                        u0.A125_4R7 = dr.GetInt32(38);
                    }
                    if (!dr.IsDBNull(39))
                    {
                        u0.A125_6R8 = dr.GetInt32(39);
                    }
                    if (!dr.IsDBNull(40))
                    {
                        u0.A125_8R2 = dr.GetInt32(40);
                    }
                    if (!dr.IsDBNull(41))
                    {
                        u0.A125_100 = dr.GetInt32(41);
                    }
                    if (!dr.IsDBNull(42))
                    {
                        u0.A125_150 = dr.GetInt32(42);
                    }
                    if (!dr.IsDBNull(43))
                    {
                        u0.A125_220 = dr.GetInt32(43);
                    }
                    if (!dr.IsDBNull(44))
                    {
                        u0.A125_330 = dr.GetInt32(44);
                    }
                    if (!dr.IsDBNull(45))
                    {
                        u0.A125_470 = dr.GetInt32(45);
                    }
                    if (!dr.IsDBNull(46))
                    {
                        u0.A125_680 = dr.GetInt32(46);
                    }
                    if (!dr.IsDBNull(47))
                    {


                        u0.A125_820 = dr.GetInt32(47);
                    }
                    if (!dr.IsDBNull(48))
                    {
                        u0.A125_101 = dr.GetInt32(48);
                    }
                    if (!dr.IsDBNull(49))
                    {

                        u0.A125_151 = dr.GetInt32(49);
                    }
                    if (!dr.IsDBNull(50))
                    {
                        u0.A125_221 = dr.GetInt32(50);
                    }
                    if (!dr.IsDBNull(51))
                    {
                        u0.A125_331 = dr.GetInt32(51);
                    }
                    if (!dr.IsDBNull(52))
                    {
                        u0.A125_471 = dr.GetInt32(52);
                    }
                    if (!dr.IsDBNull(53))
                    {
                        u0.A125_681 = dr.GetInt32(53);
                    }
                    if (!dr.IsDBNull(54))
                    {
                        u0.A125_821 = dr.GetInt32(54);
                    }
                    if (!dr.IsDBNull(55))
                    {
                        u0.A125_102 = dr.GetInt32(55);
                    }
                    if (!dr.IsDBNull(56))
                    {
                        u0.A124_R47 = dr.GetInt32(56);
                    }
                    if (!dr.IsDBNull(57))
                    {

                        u0.A124_1R0 = dr.GetInt32(57);
                    }
                    if (!dr.IsDBNull(58))
                    {
                        u0.A124_1R5 = dr.GetInt32(58);
                    }
                    if (!dr.IsDBNull(59))
                    {
                        u0.A124_2R2 = dr.GetInt32(59);
                    }
                    if (!dr.IsDBNull(60))
                    {
                        u0.A124_3R3 = dr.GetInt32(60);
                    }
                    if (!dr.IsDBNull(61))
                    {
                        u0.A124_4R7 = dr.GetInt32(61);
                    }
                    if (!dr.IsDBNull(62))
                    {
                        u0.A124_6R8 = dr.GetInt32(62);
                    }
                    if (!dr.IsDBNull(63))
                    {
                        u0.A124_8R2 = dr.GetInt32(63);
                    }
                    if (!dr.IsDBNull(64))
                    {
                        u0.A124_100 = dr.GetInt32(64);
                    }
                    if (!dr.IsDBNull(65))
                    {
                        u0.A124_150 = dr.GetInt32(65);
                    }
                    if (!dr.IsDBNull(66))
                    {
                        u0.A124_220 = dr.GetInt32(66);
                    }
                    if (!dr.IsDBNull(67))
                    {

                        u0.A124_330 = dr.GetInt32(67);
                    }
                    if (!dr.IsDBNull(68))
                    {
                        u0.A124_470 = dr.GetInt32(68);
                    }
                    if (!dr.IsDBNull(69))
                    {
                        u0.A124_680 = dr.GetInt32(69);
                    }
                    if (!dr.IsDBNull(70))
                    {
                        u0.A124_820 = dr.GetInt32(70);
                    }
                    if (!dr.IsDBNull(71))
                    {
                        u0.A124_101 = dr.GetInt32(71);
                    }
                    if (!dr.IsDBNull(72))
                    {
                        u0.A124_151 = dr.GetInt32(72);
                    }
                    if (!dr.IsDBNull(73))
                    {
                        u0.A124_221 = dr.GetInt32(73);
                    }
                    if (!dr.IsDBNull(74))
                    {
                        u0.A124_331 = dr.GetInt32(74);
                    }
                    if (!dr.IsDBNull(75))
                    {
                        u0.A124_471 = dr.GetInt32(75);
                    }
                    if (!dr.IsDBNull(76))
                    {
                        u0.A124_681 = dr.GetInt32(76);
                    }
                    if (!dr.IsDBNull(77))
                    {

                        u0.A124_821 = dr.GetInt32(77);
                    }
                    if (!dr.IsDBNull(78))
                    {
                        u0.A124_102 = dr.GetInt32(78);
                    }
                    if (!dr.IsDBNull(79))
                    {
                        u0.Q127_100_NG = dr.GetInt32(79);
                    }
                    if (!dr.IsDBNull(80))
                    {
                        u0.Q127_150_NG = dr.GetInt32(80);
                    }
                    if (!dr.IsDBNull(81))
                    {
                        u0.Q127_220_NG = dr.GetInt32(81);
                    }
                    if (!dr.IsDBNull(82))
                    {
                        u0.Q127_330_NG = dr.GetInt32(82);
                    }
                    if (!dr.IsDBNull(83))
                    {
                        u0.Q127_470_NG = dr.GetInt32(83);
                    }
                    if (!dr.IsDBNull(84))
                    {
                        u0.A127_R47_NG = dr.GetInt32(84);
                    }
                    if (!dr.IsDBNull(85))
                    {
                        u0.A127_1R0_NG = dr.GetInt32(85);
                    }
                    if (!dr.IsDBNull(86))
                    {
                        u0.A127_1R5_NG = dr.GetInt32(86);
                    }
                    if (!dr.IsDBNull(87))
                    {

                        u0.A127_2R2_NG = dr.GetInt32(87);
                    }
                    if (!dr.IsDBNull(88))
                    {
                        u0.A127_3R3_NG = dr.GetInt32(88);
                    }
                    if (!dr.IsDBNull(89))
                    {
                        u0.A127_4R7_NG = dr.GetInt32(89);
                    }
                    if (!dr.IsDBNull(90))
                    {
                        u0.A127_6R8_NG = dr.GetInt32(90);
                    }
                    if (!dr.IsDBNull(91))
                    {
                        u0.A127_8R2_NG = dr.GetInt32(91);
                    }
                    if (!dr.IsDBNull(92))
                    {
                        u0.A127_100_NG = dr.GetInt32(92);
                    }
                    if (!dr.IsDBNull(93))
                    {
                        u0.A127_150_NG = dr.GetInt32(93);
                    }
                    if (!dr.IsDBNull(94))
                    {
                        u0.A127_220_NG = dr.GetInt32(94);
                    }
                    if (!dr.IsDBNull(95))
                    {
                        u0.A127_330_NG = dr.GetInt32(95);
                    }
                    if (!dr.IsDBNull(96))
                    {
                        u0.A127_470_NG = dr.GetInt32(96);
                    }
                    if (!dr.IsDBNull(97))
                    {

                        u0.A127_680_NG = dr.GetInt32(97);
                    }
                    if (!dr.IsDBNull(98))
                    {
                        u0.A127_820_NG = dr.GetInt32(98);
                    }
                    if (!dr.IsDBNull(99))
                    {
                        u0.A127_101_NG = dr.GetInt32(99);
                    }
                    if (!dr.IsDBNull(100))
                    {
                        u0.A127_151_NG = dr.GetInt32(100);
                    }
                    if (!dr.IsDBNull(101))
                    {

                        u0.A127_221_NG = dr.GetInt32(101);
                    }
                    if (!dr.IsDBNull(102))
                    {
                        u0.A127_331_NG = dr.GetInt32(102);
                    }
                    if (!dr.IsDBNull(103))
                    {
                        u0.A127_471_NG = dr.GetInt32(103);
                    }
                    if (!dr.IsDBNull(104))
                    {
                        u0.A127_681_NG = dr.GetInt32(104);
                    }
                    if (!dr.IsDBNull(105))
                    {
                        u0.A127_821_NG = dr.GetInt32(105);
                    }
                    if (!dr.IsDBNull(106))
                    {
                        u0.A127_102_NG = dr.GetInt32(106);
                    }
                    if (!dr.IsDBNull(107))
                    {
                        u0.A125_R47_NG = dr.GetInt32(107);
                    }
                    if (!dr.IsDBNull(108))
                    {
                        u0.A125_1R0_NG = dr.GetInt32(108);
                    }
                    if (!dr.IsDBNull(109))
                    {


                        u0.A125_1R5_NG = dr.GetInt32(109);
                    }
                    if (!dr.IsDBNull(110))
                    {
                        u0.A125_2R2_NG = dr.GetInt32(110);
                    }
                    if (!dr.IsDBNull(111))
                    {
                        u0.A125_3R3_NG = dr.GetInt32(111);
                    }
                    if (!dr.IsDBNull(112))
                    {
                        u0.A125_4R7_NG = dr.GetInt32(112);
                    }
                    if (!dr.IsDBNull(113))
                    {
                        u0.A125_6R8_NG = dr.GetInt32(113);
                    }
                    if (!dr.IsDBNull(114))
                    {
                        u0.A125_8R2_NG = dr.GetInt32(114);
                    }
                    if (!dr.IsDBNull(115))
                    {

                        u0.A125_100_NG = dr.GetInt32(115);
                    }
                    if (!dr.IsDBNull(116))
                    {
                        u0.A125_150_NG = dr.GetInt32(116);
                    }
                    if (!dr.IsDBNull(117))
                    {
                        u0.A125_220_NG = dr.GetInt32(117);
                    }
                    if (!dr.IsDBNull(118))
                    {
                        u0.A125_330_NG = dr.GetInt32(118);
                    }
                    if (!dr.IsDBNull(119))
                    {
                        u0.A125_470_NG = dr.GetInt32(119);
                    }
                    if (!dr.IsDBNull(120))
                    {
                        u0.A125_680_NG = dr.GetInt32(120);
                    }
                    if (!dr.IsDBNull(121))
                    {
                        u0.A125_820_NG = dr.GetInt32(121);
                    }
                    if (!dr.IsDBNull(122))
                    {
                        u0.A125_101_NG = dr.GetInt32(122);
                    }
                    if (!dr.IsDBNull(123))
                    {
                        u0.A125_151_NG = dr.GetInt32(123);
                    }
                    if (!dr.IsDBNull(124))
                    {
                        u0.A125_221_NG = dr.GetInt32(124);
                    }
                    if (!dr.IsDBNull(125))
                    {

                        u0.A125_331_NG = dr.GetInt32(125);
                    }
                    if (!dr.IsDBNull(126))
                    {
                        u0.A125_471_NG = dr.GetInt32(126);
                    }
                    if (!dr.IsDBNull(127))
                    {
                        u0.A125_681_NG = dr.GetInt32(127);
                    }
                    if (!dr.IsDBNull(128))
                    {
                        u0.A125_821_NG = dr.GetInt32(128);
                    }
                    if (!dr.IsDBNull(129))
                    {
                        u0.A125_102_NG = dr.GetInt32(129);
                    }
                    if (!dr.IsDBNull(130))
                    {
                        u0.A124_R47_NG = dr.GetInt32(130);
                    }
                    if (!dr.IsDBNull(131))
                    {
                        u0.A124_1R0_NG = dr.GetInt32(131);
                    }
                    if (!dr.IsDBNull(132))
                    {
                        u0.A124_1R5_NG = dr.GetInt32(132);
                    }
                    if (!dr.IsDBNull(133))
                    {
                        u0.A124_2R2_NG = dr.GetInt32(133);
                    }
                    if (!dr.IsDBNull(134))
                    {
                        u0.A124_3R3_NG = dr.GetInt32(134);
                    }
                    if (!dr.IsDBNull(135))
                    {

                        u0.A124_4R7_NG = dr.GetInt32(135);
                    }
                    if (!dr.IsDBNull(136))
                    {
                        u0.A124_6R8_NG = dr.GetInt32(136);
                    }
                    if (!dr.IsDBNull(137))
                    {
                        u0.A124_8R2_NG = dr.GetInt32(137);
                    }
                    if (!dr.IsDBNull(138))
                    {
                        u0.A124_100_NG = dr.GetInt32(138);
                    }
                    if (!dr.IsDBNull(139))
                    {
                        u0.A124_150_NG = dr.GetInt32(139);
                    }
                    if (!dr.IsDBNull(140))
                    {
                        u0.A124_220_NG = dr.GetInt32(140);
                    }
                    if (!dr.IsDBNull(141))
                    {
                        u0.A124_330_NG = dr.GetInt32(141);
                    }
                    if (!dr.IsDBNull(142))
                    {
                        u0.A124_470_NG = dr.GetInt32(142);
                    }
                    if (!dr.IsDBNull(143))
                    {

                        u0.A124_680_NG = dr.GetInt32(143);
                    }
                    if (!dr.IsDBNull(144))
                    {
                        u0.A124_820_NG = dr.GetInt32(144);
                    }
                    if (!dr.IsDBNull(145))
                    {
                        u0.A124_101_NG = dr.GetInt32(145);
                    }
                    if (!dr.IsDBNull(146))
                    {
                        u0.A124_151_NG = dr.GetInt32(146);
                    }
                    if (!dr.IsDBNull(147))
                    {
                        u0.A124_221_NG = dr.GetInt32(147);
                    }
                    if (!dr.IsDBNull(148))
                    {
                        u0.A124_331_NG = dr.GetInt32(148);
                    }
                    if (!dr.IsDBNull(149))
                    {
                        u0.A124_471_NG = dr.GetInt32(149);
                    }
                    if (!dr.IsDBNull(150))
                    {
                        u0.A124_681_NG = dr.GetInt32(150);
                    }
                    if (!dr.IsDBNull(151))
                    {
                        u0.A124_821_NG = dr.GetInt32(151);
                    }
                    if (!dr.IsDBNull(152))
                    {
                        u0.A124_102_NG = dr.GetInt32(152);
                    }

                   
                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }





        /// <summary>
        /// 查询单站大屏Output and NG信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public Monthly_Order_Info Monthly_Order_Infos(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC1))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                Monthly_Order_Info u1 = new Monthly_Order_Info(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u1.ID = Convert.ToInt32(dr["ID"]);
                    u1.Ts = dr["Ts"].ToString();
                    u1.Years = dr["Years"].ToString();
                    u1.Months = dr["Months"].ToString();
                    u1.days = dr["days"].ToString();
                    u1.Orders = dr["Orders"].ToString();
                    u1.Model = dr["Model"].ToString();
                    u1.Plan_Output = dr["Plan_Output"].ToString();
                    u1.Output = dr["Output"].ToString();
                    u1.NG = dr["NG"].ToString();
                    u1.Done_Ratio = dr["Done_Ratio"].ToString();
                    u1.User_Hours = dr["User_Hours"].ToString();

                    u1.NG_Type1 = dr["NG_Type1"].ToString();
                    u1.NG_Type2 = dr["NG_Type2"].ToString();
                    u1.NG_Type3 = dr["NG_Type3"].ToString();
                    u1.NG_Type4 = dr["NG_Type4"].ToString();
                    u1.NG_Type5 = dr["NG_Type5"].ToString();
                    u1.NG_Type6 = dr["NG_Type6"].ToString();
                    u1.NG_Type7 = dr["NG_Type7"].ToString();
                    u1.NG_Type8 = dr["NG_Type8"].ToString();
                    u1.NG_Type9 = dr["NG_Type9"].ToString();
                    u1.NG_Type10 = dr["NG_Type10"].ToString();


                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }



        /// <summary>
        /// 查询单站大屏Output and NG信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<DayInfoHistory> Monthly_Order_Infos_List(string SqlCon_PCC,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                List<DayInfoHistory> u1 = new List<DayInfoHistory>(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    DayInfoHistory u0 = new DayInfoHistory();
                    //把查询的当前记录各字段值赋值给对于的u0的属性
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
                        u0.UpdateTime = Convert.ToString(dr["UpdateTime"]);
                    }
                    if (dr["RecordTime"] != DBNull.Value)
                    {
                        u0.RecordTime = Convert.ToString(dr["RecordTime"]);
                    }
                    if (dr["LastRecordTime"] != DBNull.Value)
                    {
                        u0.LastRecordTime = Convert.ToString(dr["LastRecordTime"]);
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
                        u0.DutFailRate = (1 - Convert.ToDouble(dr["DutFailRate"])) * 100;
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
        /// 查询备件更换记录
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Record_of_Spare_Parts> Select_Record_of_Spare_Parts( String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC1))
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
        /// 查询实时数据
        /// </summary>
        /// <returns>用户类集合</returns>
        public Select_Real_Time_Data Select_Real_Time_Datas(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_All))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                Select_Real_Time_Data u1 = new Select_Real_Time_Data(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    u1.PO = dr["PO"].ToString();
                    u1.Now_Model = dr["Now_Model"].ToString();
                    u1.Now_Output = Convert.ToInt32(dr["Now_Output"]);
                    u1.Now_NG = Convert.ToInt32(dr["Now_NG"]);
                    u1.Total_alarm_times = Convert.ToInt32(dr["Total_alarm_times"]);
                    u1.Total_running_days = Convert.ToInt32(dr["Total_running_days"]);
                    u1.Total_alarm_time = Convert.ToInt32(dr["Total_alarm_time"]);
                    u1.OEE = dr["OEE"].ToString();
                    u1.UPH = Convert.ToInt32(dr["UPH"]);
                    u1.PLCRunStatus = dr["PLCRunStatus"].ToString();
                    u1.Maintain_Status = dr["Maintain_Status"].ToString();
                    u1.Plan_Output= Convert.ToInt32(dr["Plan_Output"]);
                    u1.Total_Reel = Convert.ToInt32(dr["Total_Reel"]);
                    u1.Current_Reel = Convert.ToInt32(dr["Current_Reel"]);
                    u1.Done_Ratio = dr["Done_Ratio"].ToString();
                    u1.User_time= Convert.ToInt32(dr["User_time"]);

                    u1.CurrentPN_MarkNG = Convert.ToInt32(dr["CurrentPN_MarkNG"]);
                    u1.CurrentPN_ImpulseNG = Convert.ToInt32(dr["CurrentPN_ImpulseNG"]);
                    u1.CurrentPN_HipotNG = Convert.ToInt32(dr["CurrentPN_HipotNG"]);
                    u1.CurrentPN_OCLNG = Convert.ToInt32(dr["CurrentPN_OCLNG"]);
                    u1.CurrentPN_DCRNG = Convert.ToInt32(dr["CurrentPN_DCRNG"]);
                    u1.CurrentPN_CCDNG = Convert.ToInt32(dr["CurrentPN_CCDNG"]);


                    u1.NG_Station1 = Convert.ToInt32(dr["NG_Station1"]);
                    u1.NG_Station2 = Convert.ToInt32(dr["NG_Station2"]);
                    u1.NG_Station3 = Convert.ToInt32(dr["NG_Station3"]);
                    u1.NG_Station4 = Convert.ToInt32(dr["NG_Station4"]);
                    u1.NG_Station5 = Convert.ToInt32(dr["NG_Station5"]);
                    u1.NG_Station6 = Convert.ToInt32(dr["NG_Station6"]);
                    u1.NG_Station7 = Convert.ToInt32(dr["NG_Station7"]);
                    u1.NG_Station8 = Convert.ToInt32(dr["NG_Station8"]);
                    u1.NG_Station9 = Convert.ToInt32(dr["NG_Station9"]);
                    u1.NG_Station10 = Convert.ToInt32(dr["NG_Station10"]);

                    u1.NG_Station11 = Convert.ToInt32(dr["NG_Station11"]);
                    u1.NG_Station12 = Convert.ToInt32(dr["NG_Station12"]);
                    u1.NG_Station13 = Convert.ToInt32(dr["NG_Station13"]);
                    u1.NG_Station14 = Convert.ToInt32(dr["NG_Station14"]);
                    u1.NG_Station15 = Convert.ToInt32(dr["NG_Station15"]);
                    u1.NG_Station16 = Convert.ToInt32(dr["NG_Station16"]);
                    u1.NG_Station17 = Convert.ToInt32(dr["NG_Station17"]);
                    u1.NG_Station18 = Convert.ToInt32(dr["NG_Station18"]);
                    u1.NG_Station19 = Convert.ToInt32(dr["NG_Station19"]);
                    u1.NG_Station20 = Convert.ToInt32(dr["NG_Station20"]);

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }





        /// <summary>
        /// 查询单站大屏Monthly_Output_Model信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public Eaton_DG_PCC.Models.Monthly_Output_Model Monthly_Output_Models(String SqlCon,String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr

                Eaton_DG_PCC.Models.Monthly_Output_Model u0 = new Eaton_DG_PCC.Models.Monthly_Output_Model(); //新建一个对象


                while (dr.Read())//遍历dr
                {
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (!dr.IsDBNull(0))
                    {
                        u0.ID = dr.GetInt32(0);
                    }
                    if (!dr.IsDBNull(1))
                    {
                        u0.Ts = dr.GetDateTime(1);
                    }
                    if (!dr.IsDBNull(2))
                    {
                        u0.Years = dr.GetInt32(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        u0.Months = dr.GetInt32(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        u0.Days = dr.GetInt32(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        u0.Q127_100 = dr.GetInt32(5);
                    }
                    if (!dr.IsDBNull(6))
                    {
                        u0.Q127_150 = dr.GetInt32(6);
                    }
                    if (!dr.IsDBNull(7))
                    {
                        u0.Q127_220 = dr.GetInt32(7);
                    }
                    if (!dr.IsDBNull(8))
                    {
                        u0.Q127_330 = dr.GetInt32(8);
                    }
                    if (!dr.IsDBNull(9))
                    {
                        u0.Q127_470 = dr.GetInt32(9);
                    }
                    if (!dr.IsDBNull(10))
                    {
                        u0.A127_R47 = dr.GetInt32(10);
                    }
                    if (!dr.IsDBNull(11))
                    {
                        u0.A127_1R0 = dr.GetInt32(11);
                    }
                    if (!dr.IsDBNull(12))
                    {
                        u0.A127_1R5 = dr.GetInt32(12);
                    }
                    if (!dr.IsDBNull(13))
                    {
                        u0.A127_2R2 = dr.GetInt32(13);
                    }
                    if (!dr.IsDBNull(14))
                    {
                        u0.A127_3R3 = dr.GetInt32(14);
                    }
                    if (!dr.IsDBNull(15))
                    {

                        u0.A127_4R7 = dr.GetInt32(15);
                    }
                    if (!dr.IsDBNull(16))
                    {
                        u0.A127_6R8 = dr.GetInt32(16);
                    }
                    if (!dr.IsDBNull(17))
                    {
                        u0.A127_8R2 = dr.GetInt32(17);
                    }
                    if (!dr.IsDBNull(18))
                    {
                        u0.A127_100 = dr.GetInt32(18);
                    }
                    if (!dr.IsDBNull(19))
                    {
                        u0.A127_150 = dr.GetInt32(19);
                    }
                    if (!dr.IsDBNull(20))
                    {
                        u0.A127_220 = dr.GetInt32(20);
                    }
                    if (!dr.IsDBNull(21))
                    {
                        u0.A127_330 = dr.GetInt32(21);
                    }
                    if (!dr.IsDBNull(22))
                    {
                        u0.A127_470 = dr.GetInt32(22);
                    }
                    if (!dr.IsDBNull(23))
                    {
                        u0.A127_680 = dr.GetInt32(23);
                    }
                    if (!dr.IsDBNull(24))
                    {
                        u0.A127_820 = dr.GetInt32(24);
                    }
                    if (!dr.IsDBNull(25))
                    {
                        u0.A127_101 = dr.GetInt32(25);
                    }
                    if (!dr.IsDBNull(26))
                    {
                        u0.A127_151 = dr.GetInt32(26);
                    }
                    if (!dr.IsDBNull(27))
                    {

                        u0.A127_221 = dr.GetInt32(27);
                    }
                    if (!dr.IsDBNull(28))
                    {
                        u0.A127_331 = dr.GetInt32(28);
                    }
                    if (!dr.IsDBNull(29))
                    {
                        u0.A127_471 = dr.GetInt32(29);
                    }
                    if (!dr.IsDBNull(30))
                    {
                        u0.A127_681 = dr.GetInt32(30);
                    }
                    if (!dr.IsDBNull(31))
                    {
                        u0.A127_821 = dr.GetInt32(31);
                    }
                    if (!dr.IsDBNull(32))
                    {
                        u0.A127_102 = dr.GetInt32(32);
                    }
                    if (!dr.IsDBNull(33))
                    {
                        u0.A125_R47 = dr.GetInt32(33);
                    }
                    if (!dr.IsDBNull(34))
                    {
                        u0.A125_1R0 = dr.GetInt32(34);
                    }
                    if (!dr.IsDBNull(35))
                    {
                        u0.A125_1R5 = dr.GetInt32(35);
                    }
                    if (!dr.IsDBNull(36))
                    {
                        u0.A125_2R2 = dr.GetInt32(36);
                    }
                    if (!dr.IsDBNull(37))
                    {

                        u0.A125_3R3 = dr.GetInt32(37);
                    }
                    if (!dr.IsDBNull(38))
                    {
                        u0.A125_4R7 = dr.GetInt32(38);
                    }
                    if (!dr.IsDBNull(39))
                    {
                        u0.A125_6R8 = dr.GetInt32(39);
                    }
                    if (!dr.IsDBNull(40))
                    {
                        u0.A125_8R2 = dr.GetInt32(40);
                    }
                    if (!dr.IsDBNull(41))
                    {
                        u0.A125_100 = dr.GetInt32(41);
                    }
                    if (!dr.IsDBNull(42))
                    {
                        u0.A125_150 = dr.GetInt32(42);
                    }
                    if (!dr.IsDBNull(43))
                    {
                        u0.A125_220 = dr.GetInt32(43);
                    }
                    if (!dr.IsDBNull(44))
                    {
                        u0.A125_330 = dr.GetInt32(44);
                    }
                    if (!dr.IsDBNull(45))
                    {
                        u0.A125_470 = dr.GetInt32(45);
                    }
                    if (!dr.IsDBNull(46))
                    {
                        u0.A125_680 = dr.GetInt32(46);
                    }
                    if (!dr.IsDBNull(47))
                    {


                        u0.A125_820 = dr.GetInt32(47);
                    }
                    if (!dr.IsDBNull(48))
                    {
                        u0.A125_101 = dr.GetInt32(48);
                    }
                    if (!dr.IsDBNull(49))
                    {

                        u0.A125_151 = dr.GetInt32(49);
                    }
                    if (!dr.IsDBNull(50))
                    {
                        u0.A125_221 = dr.GetInt32(50);
                    }
                    if (!dr.IsDBNull(51))
                    {
                        u0.A125_331 = dr.GetInt32(51);
                    }
                    if (!dr.IsDBNull(52))
                    {
                        u0.A125_471 = dr.GetInt32(52);
                    }
                    if (!dr.IsDBNull(53))
                    {
                        u0.A125_681 = dr.GetInt32(53);
                    }
                    if (!dr.IsDBNull(54))
                    {
                        u0.A125_821 = dr.GetInt32(54);
                    }
                    if (!dr.IsDBNull(55))
                    {
                        u0.A125_102 = dr.GetInt32(55);
                    }
                    if (!dr.IsDBNull(56))
                    {
                        u0.A124_R47 = dr.GetInt32(56);
                    }
                    if (!dr.IsDBNull(57))
                    {

                        u0.A124_1R0 = dr.GetInt32(57);
                    }
                    if (!dr.IsDBNull(58))
                    {
                        u0.A124_1R5 = dr.GetInt32(58);
                    }
                    if (!dr.IsDBNull(59))
                    {
                        u0.A124_2R2 = dr.GetInt32(59);
                    }
                    if (!dr.IsDBNull(60))
                    {
                        u0.A124_3R3 = dr.GetInt32(60);
                    }
                    if (!dr.IsDBNull(61))
                    {
                        u0.A124_4R7 = dr.GetInt32(61);
                    }
                    if (!dr.IsDBNull(62))
                    {
                        u0.A124_6R8 = dr.GetInt32(62);
                    }
                    if (!dr.IsDBNull(63))
                    {
                        u0.A124_8R2 = dr.GetInt32(63);
                    }
                    if (!dr.IsDBNull(64))
                    {
                        u0.A124_100 = dr.GetInt32(64);
                    }
                    if (!dr.IsDBNull(65))
                    {
                        u0.A124_150 = dr.GetInt32(65);
                    }
                    if (!dr.IsDBNull(66))
                    {
                        u0.A124_220 = dr.GetInt32(66);
                    }
                    if (!dr.IsDBNull(67))
                    {

                        u0.A124_330 = dr.GetInt32(67);
                    }
                    if (!dr.IsDBNull(68))
                    {
                        u0.A124_470 = dr.GetInt32(68);
                    }
                    if (!dr.IsDBNull(69))
                    {
                        u0.A124_680 = dr.GetInt32(69);
                    }
                    if (!dr.IsDBNull(70))
                    {
                        u0.A124_820 = dr.GetInt32(70);
                    }
                    if (!dr.IsDBNull(71))
                    {
                        u0.A124_101 = dr.GetInt32(71);
                    }
                    if (!dr.IsDBNull(72))
                    {
                        u0.A124_151 = dr.GetInt32(72);
                    }
                    if (!dr.IsDBNull(73))
                    {
                        u0.A124_221 = dr.GetInt32(73);
                    }
                    if (!dr.IsDBNull(74))
                    {
                        u0.A124_331 = dr.GetInt32(74);
                    }
                    if (!dr.IsDBNull(75))
                    {
                        u0.A124_471 = dr.GetInt32(75);
                    }
                    if (!dr.IsDBNull(76))
                    {
                        u0.A124_681 = dr.GetInt32(76);
                    }
                    if (!dr.IsDBNull(77))
                    {

                        u0.A124_821 = dr.GetInt32(77);
                    }
                    if (!dr.IsDBNull(78))
                    {
                        u0.A124_102 = dr.GetInt32(78);
                    }
                    if (!dr.IsDBNull(79))
                    {
                        u0.Q127_100_NG = dr.GetInt32(79);
                    }
                    if (!dr.IsDBNull(80))
                    {
                        u0.Q127_150_NG = dr.GetInt32(80);
                    }
                    if (!dr.IsDBNull(81))
                    {
                        u0.Q127_220_NG = dr.GetInt32(81);
                    }
                    if (!dr.IsDBNull(82))
                    {
                        u0.Q127_330_NG = dr.GetInt32(82);
                    }
                    if (!dr.IsDBNull(83))
                    {
                        u0.Q127_470_NG = dr.GetInt32(83);
                    }
                    if (!dr.IsDBNull(84))
                    {
                        u0.A127_R47_NG = dr.GetInt32(84);
                    }
                    if (!dr.IsDBNull(85))
                    {
                        u0.A127_1R0_NG = dr.GetInt32(85);
                    }
                    if (!dr.IsDBNull(86))
                    {
                        u0.A127_1R5_NG = dr.GetInt32(86);
                    }
                    if (!dr.IsDBNull(87))
                    {

                        u0.A127_2R2_NG = dr.GetInt32(87);
                    }
                    if (!dr.IsDBNull(88))
                    {
                        u0.A127_3R3_NG = dr.GetInt32(88);
                    }
                    if (!dr.IsDBNull(89))
                    {
                        u0.A127_4R7_NG = dr.GetInt32(89);
                    }
                    if (!dr.IsDBNull(90))
                    {
                        u0.A127_6R8_NG = dr.GetInt32(90);
                    }
                    if (!dr.IsDBNull(91))
                    {
                        u0.A127_8R2_NG = dr.GetInt32(91);
                    }
                    if (!dr.IsDBNull(92))
                    {
                        u0.A127_100_NG = dr.GetInt32(92);
                    }
                    if (!dr.IsDBNull(93))
                    {
                        u0.A127_150_NG = dr.GetInt32(93);
                    }
                    if (!dr.IsDBNull(94))
                    {
                        u0.A127_220_NG = dr.GetInt32(94);
                    }
                    if (!dr.IsDBNull(95))
                    {
                        u0.A127_330_NG = dr.GetInt32(95);
                    }
                    if (!dr.IsDBNull(96))
                    {
                        u0.A127_470_NG = dr.GetInt32(96);
                    }
                    if (!dr.IsDBNull(97))
                    {

                        u0.A127_680_NG = dr.GetInt32(97);
                    }
                    if (!dr.IsDBNull(98))
                    {
                        u0.A127_820_NG = dr.GetInt32(98);
                    }
                    if (!dr.IsDBNull(99))
                    {
                        u0.A127_101_NG = dr.GetInt32(99);
                    }
                    if (!dr.IsDBNull(100))
                    {
                        u0.A127_151_NG = dr.GetInt32(100);
                    }
                    if (!dr.IsDBNull(101))
                    {

                        u0.A127_221_NG = dr.GetInt32(101);
                    }
                    if (!dr.IsDBNull(102))
                    {
                        u0.A127_331_NG = dr.GetInt32(102);
                    }
                    if (!dr.IsDBNull(103))
                    {
                        u0.A127_471_NG = dr.GetInt32(103);
                    }
                    if (!dr.IsDBNull(104))
                    {
                        u0.A127_681_NG = dr.GetInt32(104);
                    }
                    if (!dr.IsDBNull(105))
                    {
                        u0.A127_821_NG = dr.GetInt32(105);
                    }
                    if (!dr.IsDBNull(106))
                    {
                        u0.A127_102_NG = dr.GetInt32(106);
                    }
                    if (!dr.IsDBNull(107))
                    {
                        u0.A125_R47_NG = dr.GetInt32(107);
                    }
                    if (!dr.IsDBNull(108))
                    {
                        u0.A125_1R0_NG = dr.GetInt32(108);
                    }
                    if (!dr.IsDBNull(109))
                    {


                        u0.A125_1R5_NG = dr.GetInt32(109);
                    }
                    if (!dr.IsDBNull(110))
                    {
                        u0.A125_2R2_NG = dr.GetInt32(110);
                    }
                    if (!dr.IsDBNull(111))
                    {
                        u0.A125_3R3_NG = dr.GetInt32(111);
                    }
                    if (!dr.IsDBNull(112))
                    {
                        u0.A125_4R7_NG = dr.GetInt32(112);
                    }
                    if (!dr.IsDBNull(113))
                    {
                        u0.A125_6R8_NG = dr.GetInt32(113);
                    }
                    if (!dr.IsDBNull(114))
                    {
                        u0.A125_8R2_NG = dr.GetInt32(114);
                    }
                    if (!dr.IsDBNull(115))
                    {

                        u0.A125_100_NG = dr.GetInt32(115);
                    }
                    if (!dr.IsDBNull(116))
                    {
                        u0.A125_150_NG = dr.GetInt32(116);
                    }
                    if (!dr.IsDBNull(117))
                    {
                        u0.A125_220_NG = dr.GetInt32(117);
                    }
                    if (!dr.IsDBNull(118))
                    {
                        u0.A125_330_NG = dr.GetInt32(118);
                    }
                    if (!dr.IsDBNull(119))
                    {
                        u0.A125_470_NG = dr.GetInt32(119);
                    }
                    if (!dr.IsDBNull(120))
                    {
                        u0.A125_680_NG = dr.GetInt32(120);
                    }
                    if (!dr.IsDBNull(121))
                    {
                        u0.A125_820_NG = dr.GetInt32(121);
                    }
                    if (!dr.IsDBNull(122))
                    {
                        u0.A125_101_NG = dr.GetInt32(122);
                    }
                    if (!dr.IsDBNull(123))
                    {
                        u0.A125_151_NG = dr.GetInt32(123);
                    }
                    if (!dr.IsDBNull(124))
                    {
                        u0.A125_221_NG = dr.GetInt32(124);
                    }
                    if (!dr.IsDBNull(125))
                    {

                        u0.A125_331_NG = dr.GetInt32(125);
                    }
                    if (!dr.IsDBNull(126))
                    {
                        u0.A125_471_NG = dr.GetInt32(126);
                    }
                    if (!dr.IsDBNull(127))
                    {
                        u0.A125_681_NG = dr.GetInt32(127);
                    }
                    if (!dr.IsDBNull(128))
                    {
                        u0.A125_821_NG = dr.GetInt32(128);
                    }
                    if (!dr.IsDBNull(129))
                    {
                        u0.A125_102_NG = dr.GetInt32(129);
                    }
                    if (!dr.IsDBNull(130))
                    {
                        u0.A124_R47_NG = dr.GetInt32(130);
                    }
                    if (!dr.IsDBNull(131))
                    {
                        u0.A124_1R0_NG = dr.GetInt32(131);
                    }
                    if (!dr.IsDBNull(132))
                    {
                        u0.A124_1R5_NG = dr.GetInt32(132);
                    }
                    if (!dr.IsDBNull(133))
                    {
                        u0.A124_2R2_NG = dr.GetInt32(133);
                    }
                    if (!dr.IsDBNull(134))
                    {
                        u0.A124_3R3_NG = dr.GetInt32(134);
                    }
                    if (!dr.IsDBNull(135))
                    {

                        u0.A124_4R7_NG = dr.GetInt32(135);
                    }
                    if (!dr.IsDBNull(136))
                    {
                        u0.A124_6R8_NG = dr.GetInt32(136);
                    }
                    if (!dr.IsDBNull(137))
                    {
                        u0.A124_8R2_NG = dr.GetInt32(137);
                    }
                    if (!dr.IsDBNull(138))
                    {
                        u0.A124_100_NG = dr.GetInt32(138);
                    }
                    if (!dr.IsDBNull(139))
                    {
                        u0.A124_150_NG = dr.GetInt32(139);
                    }
                    if (!dr.IsDBNull(140))
                    {
                        u0.A124_220_NG = dr.GetInt32(140);
                    }
                    if (!dr.IsDBNull(141))
                    {
                        u0.A124_330_NG = dr.GetInt32(141);
                    }
                    if (!dr.IsDBNull(142))
                    {
                        u0.A124_470_NG = dr.GetInt32(142);
                    }
                    if (!dr.IsDBNull(143))
                    {

                        u0.A124_680_NG = dr.GetInt32(143);
                    }
                    if (!dr.IsDBNull(144))
                    {
                        u0.A124_820_NG = dr.GetInt32(144);
                    }
                    if (!dr.IsDBNull(145))
                    {
                        u0.A124_101_NG = dr.GetInt32(145);
                    }
                    if (!dr.IsDBNull(146))
                    {
                        u0.A124_151_NG = dr.GetInt32(146);
                    }
                    if (!dr.IsDBNull(147))
                    {
                        u0.A124_221_NG = dr.GetInt32(147);
                    }
                    if (!dr.IsDBNull(148))
                    {
                        u0.A124_331_NG = dr.GetInt32(148);
                    }
                    if (!dr.IsDBNull(149))
                    {
                        u0.A124_471_NG = dr.GetInt32(149);
                    }
                    if (!dr.IsDBNull(150))
                    {
                        u0.A124_681_NG = dr.GetInt32(150);
                    }
                    if (!dr.IsDBNull(151))
                    {
                        u0.A124_821_NG = dr.GetInt32(151);
                    }
                    if (!dr.IsDBNull(152))
                    {
                        u0.A124_102_NG = dr.GetInt32(152);
                    }

                }

                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u0;
            }
        }




        /// <summary>
        /// 查询单站大屏Output and NG信息
        /// </summary>
        /// <returns>用户类集合</returns>
        public List<Alarm_List> Get_Alarm_Info(String str)
        {
            using (SqlConnection conn = new SqlConnection(SqlCon_PCC1))
            {
                SqlCommand cmd = new SqlCommand(); //新建数据库操作类
                cmd.Connection = conn; //设置数据链接
                cmd.CommandText = str; //设置查询语句

                conn.Open(); //打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader(); //执行Reader查询，存入dr
                List<Alarm_List> u1 = new List<Alarm_List>();



                while (dr.Read())//遍历dr
                {
                    Alarm_real_time u0 = new Alarm_real_time(); //新建一个对象
                    //把查询的当前记录各字段值赋值给对于的u0的属性
                    if (!dr.IsDBNull(0))
                    {
                        u0.ID = dr.GetInt32(0);
                    }
                    if (!dr.IsDBNull(1))
                    {
                        u0.DeviceId = dr.GetString(1);
                    }

                    if (!dr.IsDBNull(4))
                    {
                        u0.Test1 = dr.GetString(4);
                        if (u0.Test1.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test1" });
                        }
                    }
                    if (!dr.IsDBNull(5))
                    {
                        u0.Test2 = dr.GetString(5);
                        if (u0.Test2.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test2" });
                        }
                    }
                    if (!dr.IsDBNull(6))
                    {
                        u0.Test3 = dr.GetString(6);
                        if (u0.Test3.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test3" });
                        }
                    }
                    if (!dr.IsDBNull(7))
                    {
                        u0.Test4 = dr.GetString(7);
                        if (u0.Test4.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test4" });
                        }
                    }
                    if (!dr.IsDBNull(8))
                    {
                        u0.Test5 = dr.GetString(8);
                        if (u0.Test5.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test5" });
                        }
                    }
                    if (!dr.IsDBNull(9))
                    {
                        u0.Test6 = dr.GetString(9);
                        if (u0.Test6.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test6" });
                        }
                    }
                    if (!dr.IsDBNull(10))
                    {
                        u0.Test7 = dr.GetString(10);
                        if (u0.Test7.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test7" });
                        }
                    }
                    if (!dr.IsDBNull(11))
                    {
                        u0.Test8 = dr.GetString(11);
                        if (u0.Test8.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test8" });
                        }
                    }
                    if (!dr.IsDBNull(12))
                    {
                        u0.Test9 = dr.GetString(12);
                        if (u0.Test9.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test9" });
                        }
                    }
                    if (!dr.IsDBNull(13))
                    {
                        u0.Test10 = dr.GetString(13);
                        if (u0.Test10.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test10" });
                        }
                    }
                    if (!dr.IsDBNull(14))
                    {
                        u0.Test11 = dr.GetString(14);
                        if (u0.Test11.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test11" });
                        }
                    }
                    if (!dr.IsDBNull(15))
                    {
                        u0.Test12 = dr.GetString(15);
                        if (u0.Test12.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test12" });
                        }
                    }
                    if (!dr.IsDBNull(16))
                    {
                        u0.Test13 = dr.GetString(16);
                        if (u0.Test13.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test13" });
                        }
                    }
                    if (!dr.IsDBNull(17))
                    {
                        u0.Test14 = dr.GetString(17);
                        if (u0.Test14.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test14" });
                        }
                    }
                    if (!dr.IsDBNull(18))
                    {
                        u0.Test15 = dr.GetString(18);
                        if (u0.Test15.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test15" });
                        }
                    }
                    if (!dr.IsDBNull(19))
                    {
                        u0.Test16 = dr.GetString(19);
                        if (u0.Test16.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test16" });
                        }
                    }
                    if (!dr.IsDBNull(20))
                    {
                        u0.Test17 = dr.GetString(20);
                        if (u0.Test17.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test17" });
                        }
                    }
                    if (!dr.IsDBNull(21))
                    {
                        u0.Test18 = dr.GetString(21);
                        if (u0.Test18.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test18" });
                        }
                    }
                    if (!dr.IsDBNull(22))
                    {
                        u0.Test19 = dr.GetString(22);
                        if (u0.Test19.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test19" });
                        }
                    }
                    if (!dr.IsDBNull(23))
                    {
                        u0.Test20 = dr.GetString(23);
                        if (u0.Test20.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test20" });
                        }
                    }
                    if (!dr.IsDBNull(24))
                    {
                        u0.Test21 = dr.GetString(24);
                        if (u0.Test21.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test21" });
                        }
                    }
                    if (!dr.IsDBNull(25))
                    {
                        u0.Test22 = dr.GetString(25);
                        if (u0.Test22.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test22" });
                        }
                    }
                    if (!dr.IsDBNull(26))
                    {
                        u0.Test23 = dr.GetString(26);
                        if (u0.Test23.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test23" });
                        }
                    }
                    if (!dr.IsDBNull(27))
                    {
                        u0.Test24 = dr.GetString(27);
                        if (u0.Test24.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test24" });
                        }
                    }
                    if (!dr.IsDBNull(28))
                    {
                        u0.Test25 = dr.GetString(28);
                        if (u0.Test25.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test25" });
                        }
                    }
                    if (!dr.IsDBNull(29))
                    {
                        u0.Test26 = dr.GetString(29);
                        if (u0.Test26.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test26" });
                        }
                    }
                    if (!dr.IsDBNull(30))
                    {
                        u0.Test27 = dr.GetString(30);
                        if (u0.Test27.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test27" });
                        }
                    }
                    if (!dr.IsDBNull(31))
                    {
                        u0.Test28 = dr.GetString(31);
                        if (u0.Test28.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test28" });
                        }
                    }
                    if (!dr.IsDBNull(32))
                    {
                        u0.Test29 = dr.GetString(32);
                        if (u0.Test29.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test29" });
                        }
                    }
                    if (!dr.IsDBNull(33))
                    {
                        u0.Test30 = dr.GetString(33);
                        if (u0.Test30.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test30" });
                        }
                    }
                    if (!dr.IsDBNull(34))
                    {
                        u0.Test31 = dr.GetString(34);
                        if (u0.Test31.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test31" });
                        }
                    }
                    if (!dr.IsDBNull(35))
                    {
                        u0.Test32 = dr.GetString(35);
                        if (u0.Test32.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test32" });
                        }
                    }
                    if (!dr.IsDBNull(36))
                    {
                        u0.Test33 = dr.GetString(36);
                        if (u0.Test33.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test33" });
                        }
                    }
                    if (!dr.IsDBNull(37))
                    {
                        u0.Test34 = dr.GetString(37);
                        if (u0.Test34.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test34" });
                        }
                    }
                    if (!dr.IsDBNull(38))
                    {
                        u0.Test35 = dr.GetString(38);
                        if (u0.Test35.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test35" });
                        }
                    }
                    if (!dr.IsDBNull(39))
                    {
                        u0.Test36 = dr.GetString(39);
                        if (u0.Test36.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test36" });
                        }
                    }
                    if (!dr.IsDBNull(40))
                    {
                        u0.Test37 = dr.GetString(40);
                        if (u0.Test37.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test37" });
                        }
                    }
                    if (!dr.IsDBNull(41))
                    {
                        u0.Test38 = dr.GetString(41);
                        if (u0.Test38.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test38" });
                        }
                    }
                    if (!dr.IsDBNull(42))
                    {
                        u0.Test39 = dr.GetString(42);
                        if (u0.Test39.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test39" });
                        }
                    }
                    if (!dr.IsDBNull(43))
                    {
                        u0.Test40 = dr.GetString(43);
                        if (u0.Test40.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test40" });
                        }
                    }
                    if (!dr.IsDBNull(44))
                    {
                        u0.Test41 = dr.GetString(44);
                        if (u0.Test41.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test41" });
                        }
                    }
                    if (!dr.IsDBNull(45))
                    {
                        u0.Test42 = dr.GetString(45);
                        if (u0.Test42.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test42" });
                        }
                    }
                    if (!dr.IsDBNull(46))
                    {
                        u0.Test43 = dr.GetString(46);
                        if (u0.Test43.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test43" });
                        }
                    }
                    if (!dr.IsDBNull(47))
                    {
                        u0.Test44 = dr.GetString(47);
                        if (u0.Test44.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test44" });
                        }
                    }
                    if (!dr.IsDBNull(48))
                    {
                        u0.Test45 = dr.GetString(48);
                        if (u0.Test45.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test45" });
                        }
                    }
                    if (!dr.IsDBNull(49))
                    {
                        u0.Test46 = dr.GetString(49);
                        if (u0.Test46.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test46" });
                        }
                    }
                    if (!dr.IsDBNull(50))
                    {
                        u0.Test47 = dr.GetString(50);
                        if (u0.Test47.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test47" });
                        }
                    }
                    if (!dr.IsDBNull(51))
                    {
                        u0.Test48 = dr.GetString(51);
                        if (u0.Test48.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test48" });
                        }
                    }
                    if (!dr.IsDBNull(52))
                    {
                        u0.Test49 = dr.GetString(52);
                        if (u0.Test49.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test49" });
                        }
                    }
                    if (!dr.IsDBNull(53))
                    {
                        u0.Test50 = dr.GetString(53);
                        if (u0.Test50.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test50" });
                        }
                    }
                    if (!dr.IsDBNull(54))
                    {
                        u0.Test51 = dr.GetString(54);
                        if (u0.Test51.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test51" });
                        }
                    }
                    if (!dr.IsDBNull(55))
                    {
                        u0.Test52 = dr.GetString(55);
                        if (u0.Test52.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test52" });
                        }
                    }
                    if (!dr.IsDBNull(56))
                    {
                        u0.Test53 = dr.GetString(56);
                        if (u0.Test53.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test53" });
                        }
                    }
                    if (!dr.IsDBNull(57))
                    {
                        u0.Test54 = dr.GetString(57);
                        if (u0.Test54.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test54" });
                        }
                    }
                    if (!dr.IsDBNull(58))
                    {
                        u0.Test55 = dr.GetString(58);
                        if (u0.Test55.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test55" });
                        }
                    }
                    if (!dr.IsDBNull(59))
                    {
                        u0.Test56 = dr.GetString(59);
                        if (u0.Test56.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test56" });
                        }
                    }
                    if (!dr.IsDBNull(60))
                    {
                        u0.Test57 = dr.GetString(60);
                        if (u0.Test57.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test57" });
                        }
                    }
                    if (!dr.IsDBNull(61))
                    {
                        u0.Test58 = dr.GetString(61);
                        if (u0.Test58.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test58" });
                        }
                    }
                    if (!dr.IsDBNull(62))
                    {
                        u0.Test59 = dr.GetString(62);
                        if (u0.Test59.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test59" });
                        }
                    }
                    if (!dr.IsDBNull(63))
                    {
                        u0.Test60 = dr.GetString(63);
                        if (u0.Test60.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test60" });
                        }
                    }
                    if (!dr.IsDBNull(64))
                    {
                        u0.Test61 = dr.GetString(64);
                        if (u0.Test61.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test61" });
                        }
                    }
                    if (!dr.IsDBNull(65))
                    {
                        u0.Test62 = dr.GetString(65);
                        if (u0.Test62.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test62" });
                        }
                    }
                    if (!dr.IsDBNull(66))
                    {
                        u0.Test63 = dr.GetString(66);
                        if (u0.Test63.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test63" });
                        }
                    }
                    if (!dr.IsDBNull(67))
                    {
                        u0.Test64 = dr.GetString(67);
                        if (u0.Test64.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test64" });
                        }
                    }
                    if (!dr.IsDBNull(68))
                    {
                        u0.Test65 = dr.GetString(68);
                        if (u0.Test65.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test65" });
                        }
                    }
                    if (!dr.IsDBNull(69))
                    {
                        u0.Test66 = dr.GetString(69);
                        if (u0.Test66.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test66" });
                        }
                    }
                    if (!dr.IsDBNull(70))
                    {
                        u0.Test67 = dr.GetString(70);
                        if (u0.Test67.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test67" });
                        }
                    }
                    if (!dr.IsDBNull(71))
                    {
                        u0.Test68 = dr.GetString(71);
                        if (u0.Test68.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test68" });
                        }
                    }
                    if (!dr.IsDBNull(72))
                    {
                        u0.Test69 = dr.GetString(72);
                        if (u0.Test69.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test69" });
                        }
                    }
                    if (!dr.IsDBNull(73))
                    {
                        u0.Test70 = dr.GetString(73);
                        if (u0.Test70.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test70" });
                        }
                    }
                    if (!dr.IsDBNull(74))
                    {
                        u0.Test71 = dr.GetString(74);
                        if (u0.Test71.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test71" });
                        }
                    }
                    if (!dr.IsDBNull(75))
                    {
                        u0.Test72 = dr.GetString(75);
                        if (u0.Test72.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test72" });
                        }
                    }
                    if (!dr.IsDBNull(76))
                    {
                        u0.Test73 = dr.GetString(76);
                        if (u0.Test73.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test73" });
                        }
                    }
                    if (!dr.IsDBNull(77))
                    {
                        u0.Test74 = dr.GetString(77);
                        if (u0.Test74.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test74" });
                        }
                    }
                    if (!dr.IsDBNull(78))
                    {
                        u0.Test75 = dr.GetString(78);
                        if (u0.Test75.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test75" });
                        }
                    }
                    if (!dr.IsDBNull(79))
                    {
                        u0.Test76 = dr.GetString(79);
                        if (u0.Test76.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test76" });
                        }
                    }
                    if (!dr.IsDBNull(80))
                    {
                        u0.Test77 = dr.GetString(80);
                        if (u0.Test77.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test77" });
                        }
                    }
                    if (!dr.IsDBNull(81))
                    {
                        u0.Test78 = dr.GetString(81);
                        if (u0.Test78.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test78" });
                        }
                    }
                    if (!dr.IsDBNull(82))
                    {
                        u0.Test79 = dr.GetString(82);
                        if (u0.Test79.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test79" });
                        }
                    }
                    if (!dr.IsDBNull(83))
                    {
                        u0.Test80 = dr.GetString(83);
                        if (u0.Test80.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test80" });
                        }
                    }
                    if (!dr.IsDBNull(84))
                    {
                        u0.Test81 = dr.GetString(84);
                        if (u0.Test81.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test81" });
                        }
                    }
                    if (!dr.IsDBNull(85))
                    {
                        u0.Test82 = dr.GetString(85);
                        if (u0.Test82.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test82" });
                        }
                    }
                    if (!dr.IsDBNull(86))
                    {
                        u0.Test83 = dr.GetString(86);
                        if (u0.Test83.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test83" });
                        }
                    }
                    if (!dr.IsDBNull(87))
                    {
                        u0.Test84 = dr.GetString(87);
                        if (u0.Test84.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test84" });
                        }
                    }
                    if (!dr.IsDBNull(88))
                    {
                        u0.Test85 = dr.GetString(88);
                        if (u0.Test85.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test85" });
                        }
                    }
                    if (!dr.IsDBNull(89))
                    {
                        u0.Test86 = dr.GetString(89);
                        if (u0.Test86.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test86" });
                        }
                    }
                    if (!dr.IsDBNull(90))
                    {
                        u0.Test87 = dr.GetString(90);
                        if (u0.Test87.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test87" });
                        }
                    }
                    if (!dr.IsDBNull(91))
                    {
                        u0.Test88 = dr.GetString(91);
                        if (u0.Test88.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test88" });
                        }
                    }
                    if (!dr.IsDBNull(92))
                    {
                        u0.Test89 = dr.GetString(92);
                        if (u0.Test89.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test89" });
                        }
                    }
                    if (!dr.IsDBNull(93))
                    {
                        u0.Test90 = dr.GetString(93);
                        if (u0.Test90.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test90" });
                        }
                    }
                    if (!dr.IsDBNull(94))
                    {
                        u0.Test91 = dr.GetString(94);
                        if (u0.Test91.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test91" });
                        }
                    }
                    if (!dr.IsDBNull(95))
                    {
                        u0.Test92 = dr.GetString(95);
                        if (u0.Test92.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test92" });
                        }
                    }
                    if (!dr.IsDBNull(96))
                    {
                        u0.Test93 = dr.GetString(96);
                        if (u0.Test93.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test93" });
                        }
                    }
                    if (!dr.IsDBNull(97))
                    {
                        u0.Test94 = dr.GetString(97);
                        if (u0.Test94.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test94" });
                        }
                    }
                    if (!dr.IsDBNull(98))
                    {
                        u0.Test95 = dr.GetString(98);
                        if (u0.Test95.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test95" });
                        }
                    }
                    if (!dr.IsDBNull(99))
                    {
                        u0.Test96 = dr.GetString(99);
                        if (u0.Test96.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test96" });
                        }
                    }
                    if (!dr.IsDBNull(100))
                    {
                        u0.Test97 = dr.GetString(100);
                        if (u0.Test97.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test97" });
                        }
                    }
                    if (!dr.IsDBNull(101))
                    {
                        u0.Test98 = dr.GetString(101);
                        if (u0.Test98.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test98" });
                        }
                    }
                    if (!dr.IsDBNull(102))
                    {
                        u0.Test99 = dr.GetString(102);
                        if (u0.Test99.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test99" });
                        }
                    }
                    if (!dr.IsDBNull(103))
                    {
                        u0.Test100 = dr.GetString(103);
                        if (u0.Test100.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test100" });
                        }
                    }
                    if (!dr.IsDBNull(104))
                    {
                        u0.Test101 = dr.GetString(104);
                        if (u0.Test101.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test101" });
                        }
                    }
                    if (!dr.IsDBNull(105))
                    {
                        u0.Test102 = dr.GetString(105);
                        if (u0.Test102.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test102" });
                        }
                    }
                    if (!dr.IsDBNull(106))
                    {
                        u0.Test103 = dr.GetString(106);
                        if (u0.Test103.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test103" });
                        }
                    }
                    if (!dr.IsDBNull(107))
                    {
                        u0.Test104 = dr.GetString(107);
                        if (u0.Test104.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test104" });
                        }
                    }
                    if (!dr.IsDBNull(108))
                    {
                        u0.Test105 = dr.GetString(108);
                        if (u0.Test105.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test105" });
                        }
                    }
                    if (!dr.IsDBNull(109))
                    {
                        u0.Test106 = dr.GetString(109);
                        if (u0.Test106.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test106" });
                        }
                    }
                    if (!dr.IsDBNull(110))
                    {
                        u0.Test107 = dr.GetString(110);
                        if (u0.Test107.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test107" });
                        }
                    }
                    if (!dr.IsDBNull(111))
                    {
                        u0.Test108 = dr.GetString(111);
                        if (u0.Test108.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test108" });
                        }
                    }
                    if (!dr.IsDBNull(112))
                    {
                        u0.Test109 = dr.GetString(112);
                        if (u0.Test109.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test109" });
                        }
                    }
                    if (!dr.IsDBNull(113))
                    {
                        u0.Test110 = dr.GetString(113);
                        if (u0.Test110.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test110" });
                        }
                    }
                    if (!dr.IsDBNull(114))
                    {
                        u0.Test111 = dr.GetString(114);
                        if (u0.Test111.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test111" });
                        }
                    }
                    if (!dr.IsDBNull(115))
                    {
                        u0.Test112 = dr.GetString(115);
                        if (u0.Test112.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test112" });
                        }
                    }
                    if (!dr.IsDBNull(116))
                    {
                        u0.Test113 = dr.GetString(116);
                        if (u0.Test113.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test113" });
                        }
                    }
                    if (!dr.IsDBNull(117))
                    {
                        u0.Test114 = dr.GetString(117);
                        if (u0.Test114.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test114" });
                        }
                    }
                    if (!dr.IsDBNull(118))
                    {
                        u0.Test115 = dr.GetString(118);
                        if (u0.Test115.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test115" });
                        }
                    }
                    if (!dr.IsDBNull(119))
                    {
                        u0.Test116 = dr.GetString(119);
                        if (u0.Test116.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test116" });
                        }
                    }
                    if (!dr.IsDBNull(120))
                    {
                        u0.Test117 = dr.GetString(120);
                        if (u0.Test117.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test117" });
                        }
                    }
                    if (!dr.IsDBNull(121))
                    {
                        u0.Test118 = dr.GetString(121);
                        if (u0.Test118.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test118" });
                        }
                    }
                    if (!dr.IsDBNull(122))
                    {
                        u0.Test119 = dr.GetString(122);
                        if (u0.Test119.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test119" });
                        }
                    }
                    if (!dr.IsDBNull(123))
                    {
                        u0.Test120 = dr.GetString(123);
                        if (u0.Test120.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test120" });
                        }
                    }
                    if (!dr.IsDBNull(124))
                    {
                        u0.Test121 = dr.GetString(124);
                        if (u0.Test121.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test121" });
                        }
                    }
                    if (!dr.IsDBNull(125))
                    {
                        u0.Test122 = dr.GetString(125);
                        if (u0.Test122.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test122" });
                        }
                    }
                    if (!dr.IsDBNull(126))
                    {
                        u0.Test123 = dr.GetString(126);
                        if (u0.Test123.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test123" });
                        }
                    }
                    if (!dr.IsDBNull(127))
                    {
                        u0.Test124 = dr.GetString(127);
                        if (u0.Test124.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test124" });
                        }
                    }
                    if (!dr.IsDBNull(128))
                    {
                        u0.Test125 = dr.GetString(128);
                        if (u0.Test125.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test125" });
                        }
                    }
                    if (!dr.IsDBNull(129))
                    {
                        u0.Test126 = dr.GetString(129);
                        if (u0.Test126.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test126" });
                        }
                    }
                    if (!dr.IsDBNull(130))
                    {
                        u0.Test127 = dr.GetString(130);
                        if (u0.Test127.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test127" });
                        }
                    }
                    if (!dr.IsDBNull(131))
                    {
                        u0.Test128 = dr.GetString(131);
                        if (u0.Test128.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test128" });
                        }
                    }
                    if (!dr.IsDBNull(132))
                    {
                        u0.Test129 = dr.GetString(132);
                        if (u0.Test129.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test129" });
                        }
                    }
                    if (!dr.IsDBNull(133))
                    {
                        u0.Test130 = dr.GetString(133);
                        if (u0.Test130.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test130" });
                        }
                    }
                    if (!dr.IsDBNull(134))
                    {
                        u0.Test131 = dr.GetString(134);
                        if (u0.Test131.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test131" });
                        }
                    }
                    if (!dr.IsDBNull(135))
                    {
                        u0.Test132 = dr.GetString(135);
                        if (u0.Test132.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test132" });
                        }
                    }
                    if (!dr.IsDBNull(136))
                    {
                        u0.Test133 = dr.GetString(136);
                        if (u0.Test133.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test133" });
                        }
                    }
                    if (!dr.IsDBNull(137))
                    {
                        u0.Test134 = dr.GetString(137);
                        if (u0.Test134.ToLower() == "true")
                        {
                            u1.Add(new Alarm_List() { Name = "Test134" });
                        }
                    }


                }
                //循环结束后，每一个用户数据都会被加入到用户类集合u1,最后返回u1
                return u1;
            }
        }








    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eaton_DG_PCC.Model;
using Eaton_DG_PCC.Model.DRAQ127;
using Eaton_DG_PCC.Models;
using Eaton_DG_PCC.Model.PCC;

namespace Eaton_DG_PCC.Controllers
{
    public class DRAQ127Controller : Controller
    {
        //you需要修改服务器地址2处
        DB_Single_station db_Single_station = new DB_Single_station();
        string Now_Years = DateTime.Now.Year.ToString();
        string Now_Months = DateTime.Now.Month.ToString();
        string Last_Months = DateTime.Now.AddMonths(-1).Month.ToString();
        string Now_Day = DateTime.Now.ToString("yyyy-MM-dd");
        string Next_Day = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");
        DB_DRAQ127 db_draq127 = new DB_DRAQ127();
        Dbs db = new Model.Dbs();

        //PCC1
        public static string SqlCon_PCC1 = ConfigurationManager.ConnectionStrings["PCC1ConnectionString"].ToString();
        //PCC2
        public static string SqlCon_PCC2 = ConfigurationManager.ConnectionStrings["PCC2ConnectionString"].ToString();
        //检测网络状态
        DataTable dt, dt1;
        string UpdateNetworkStatus;
        IList<NetworkStatus> networkstatus_old = new List<NetworkStatus>();
        IList<NetworkStatus> networkstatus_new = new List<NetworkStatus>();



        // GET: DRAQ127
        public ActionResult Index()
        {
            return View();
        }

        //返回主画面Json_AllStatus
        public JsonResult DRAQ127_AllStatus(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            
            String str = "select * from RealTimePlantData where LineID='" + DeviceId + "'";
            AllStatus list = db.DeviceAllStatus(str);
            return Json(new { msg = "success", data = list }, JsonRequestBehavior.AllowGet);
        }
        //返回主画面Json_Current Model NG
        public JsonResult DRAQ127_AllStatus2(string DeviceId)
        {
            String str = "select * from RealTimePlantData where LineID= '" + DeviceId + "'";
            RealTimePlantData list_Select_Real_Time_Data = db.Sel_RealTimePlantData(str);

            int[] j = { list_Select_Real_Time_Data.cap, list_Select_Real_Time_Data.ESR, list_Select_Real_Time_Data.Voltage };
            ViewBag.MaxData2 = j.Max();

            return Json(new { msg = "success", data = list_Select_Real_Time_Data, data2 = j.Max() }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult BigScreen()
        {
            string DeviceId = Request["DeviceId"];
            ViewBag.DeviceId = DeviceId;
            string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();
            //查询RealTimePlantData表当前型号的数据
            String str = "select * from RealTimePlantData where LineID= '" + DeviceId + "'";
            RealTimePlantData list_Select_Real_Time_Data = db.Sel_RealTimePlantData(str);

            int[] j = { list_Select_Real_Time_Data.cap, list_Select_Real_Time_Data.ESR, list_Select_Real_Time_Data.Voltage};
            ViewBag.MaxData2 = j.Max();

            //赋值ViewBag.Select_Real_Time_Data当前型号的数据
            ViewBag.Select_Real_Time_Data = list_Select_Real_Time_Data;
            ViewBag.Now_Model = list_Select_Real_Time_Data.DutMode;




            //查询最近生产的5种型号每月产量Latest Monthly Output&NG Top 5
            string str_select_top5_monthly_output = "select * from EveryMonthInfo nolock";
            List<Monthly_OutputAndNG> list_Monthly_OutputAndNG = db_draq127.select_top5_monthly_output(SqlCon_PCC,str_select_top5_monthly_output);

            //查询最近生产的5种型号每天产量Latest Daily Output&NG Top 5
            string str_select_top5_daily_output = "select * from EverydayInfo nolock";
            List<EveryDay_OutputAndNG> list_Everyday_OutputAndNG = db_draq127.select_top5_daily_output(SqlCon_PCC,str_select_top5_daily_output);


            //2019年12月-现场没看出问题，家里调试好像是周日看数据有问题，所以更新
            //查询当前一周内数据Order Progress This Week
            //DateTime dt = DateTime.Now; //当前时间
            //DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))); //本周周一
            //DateTime endWeek = startWeek.AddDays(6); //本周周日
            //string startDay = startWeek.Year.ToString() + "-" + startWeek.Month.ToString() + "-" + startWeek.Day.ToString();
            //string endDay = endWeek.Year.ToString() + "-" + endWeek.Month.ToString() + "-" + endWeek.Day.ToString();
            //String str_Monthly_Order_Info2 = "select * from DayInfoHistory  nolock where RecordTime BETWEEN '" + startDay + "' and '" + endDay + "'  and LineID='" + DeviceId + "'";

            //2020年2月-过年在家周日看数据好像有问题，所以更新
            //查询当前一周内数据Order Progress This Week
            DateTime dt = DateTime.Now; //当前时间

            int count = dt.DayOfWeek - DayOfWeek.Monday;
            if (count == -1) count = 6;

            DateTime startWeek = dt.AddDays(-count);//本周周一
            DateTime endWeek = startWeek.AddDays(7); //本周周日
            DateTime endWeek2 = startWeek.AddDays(5); //本周周日
            string startDay = startWeek.Year.ToString() + "-" + startWeek.Month.ToString() + "-" + startWeek.Day.ToString();
            string endDay = endWeek.Year.ToString() + "-" + endWeek.Month.ToString() + "-" + endWeek.Day.ToString();
            String str_Monthly_Order_Info2 = "select * from DayInfoHistory  nolock where RecordTime BETWEEN '" + startDay + "' and '" + endDay + "'  and LineID='" + DeviceId + "'";




            List<DayInfoHistory> list_Monthly_Order_Info_List = db_Single_station.Monthly_Order_Infos_List(SqlCon_PCC,str_Monthly_Order_Info2);



            return View(Tuple.Create(list_Monthly_OutputAndNG, list_Everyday_OutputAndNG, list_Monthly_Order_Info_List));
        }




        public ActionResult Order(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            return View();
        }
        public ActionResult Daily_Output(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            return View();
        }
        public ActionResult Monthly_Output(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            return View();
        }

        //第一次进入报警画面
        public ActionResult Alarm(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            return View();
        }

        //实时加载报警Json
        [HttpPost]
        public JsonResult Alarm_Real_Time(string DeviceId, string start_time, string end_time)
        {
            string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();
            //需要修改服务器地址1
             string str = "select * from WarnInfo where IfCure='0' and WarnTime between '" + Now_Day + "' and '" + Next_Day + "' and LineID='"+DeviceId+"' order by ID desc";
            List<Alarm_Messages> alarm_real_time = new List<Alarm_Messages>();
            List<Alarm_Messages> alarm_real_time2 = new List<Alarm_Messages>();

            try
            {
                alarm_real_time = db.Alarm_real_time(SqlCon_PCC,str);
                var query = alarm_real_time.Select((x, i) => new { 序号 = i++,x.LineID,x.StationID, x.WarnTime,x.NormalTime, x.WarnExplain,x.Duration });
                foreach (var item in query)
                {
                    Alarm_Messages r = new Alarm_Messages();
                    r.ID = item.序号 + 1;
                    r.LineID = item.LineID;
                    r.StationID = item.StationID;
                    r.WarnTime = item.WarnTime;
                    r.NormalTime = item.NormalTime;
                    r.WarnExplain = item.WarnExplain;
                    r.Duration = item.Duration;
                    alarm_real_time2.Add(r);
                }

            }
            catch (Exception ex)
            { }



            string str2 = "select COUNT(*) from WarnInfo where IfCure='1' and WarnTime between '" + Now_Day + "' and '" + Next_Day + "'";
            int Count = db.ExecuteScalar_Alarm(SqlCon_PCC,str2);




            return Json(new { count = Count, success = 1, data = alarm_real_time2 }, JsonRequestBehavior.AllowGet);
        }

        //历史报警
        public ActionResult Alarm_History(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();
            //需要修改服务器地址2

            //string Alarm_SqlCon = @"Data Source=test-PC\AndyLi;Initial Catalog=" + DeviceId + "_Message;User ID=sa;Password=ok;";
            
           

            string str = "";
            string str2 = "";
            ViewBag.DeviceId = DeviceId;
            if (limit == null || limit == "")
            {
                limit = "10";
            }
            if (start_time != null && start_time != "" && end_time != null && end_time != "")
            {
                str = "select top (select " + limit + ") * from (select row_number() over(order by WarnTime desc) as rownumber,* from WarnInfo where WarnTime between ('" + start_time + "') and ('" + end_time + "')) temp_row where rownumber>((" + page + "-1)*" + limit + ")";
                str2 = "select COUNT(*) from WarnInfo where WarnTime between ('" + start_time + "') and ('" + end_time + "')";
            }
            else
            {
                str = "select top (select " + limit + ") * from (select row_number() over(order by WarnTime desc) as rownumber,* from WarnInfo where WarnTime between ('" + Now_Day + "') and ('" + Next_Day + "')) temp_row where rownumber>((" + page + "-1)*" + limit + ")";
                str2 = "select COUNT(*) from WarnInfo where WarnTime between ('" + Now_Day + "') and ('" + Next_Day + "')";
            }
                //根据当前是第几页，一页有多少行，返回数据
            List<Alarm_Messages> alarm_real_time = new List<Alarm_Messages>();
            alarm_real_time = db.History_Alarm(SqlCon_PCC, str);



            //查询一共有多少行数据返回
            int Count = db.ExecuteScalar_Alarm(SqlCon_PCC,str2);
            
            //返回数据给js
            //return Json(new { count = Count, msg = "success", data = alarm_real_time }, JsonRequestBehavior.AllowGet);

            return Json(new { count = Count, success = 1, data = alarm_real_time }, JsonRequestBehavior.AllowGet);
        }


        //配方
        public ActionResult History(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            return View();
        }



        //报表画面-每盘测试结果
        public JsonResult OEE(int page, string DeviceId, string limit, string start_time, string end_time,string Model, string Product_ID)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();
                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                string str, str2;
                if (Product_ID == "")
                {
                    str2 = "exec proc_OEE_Report2 '" + page + "','" + limit + "','" + start_time + "','" + end_time + "','" + DeviceId + "','" + Model + "'";
                    str = "proc_OEE_Report_count2'" + start_time + "','" + end_time + "','" + DeviceId + "','" + Model + "'";
                }
                else {
                    str2 = "exec proc_OEE_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "','" + DeviceId + "','" + Model + "','" + Product_ID + "'";
                    str = "proc_OEE_Report_count'" + start_time + "','" + end_time + "','" + DeviceId + "','" + Model + "','" + Product_ID + "'";
                }

                List<OEE> oee;
                oee = db_draq127.oee(SqlCon_PCC, str2);


                //查询一共有多少行数据返回
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = oee }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }

        //报表画面-报警信息查询
        public JsonResult PO(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();
                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                String str2 = "exec proc_PO_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "','" + DeviceId + "'";
                List<PO> po;
                po = db_draq127.po(SqlCon_PCC, str2);

                //查询一共有多少行数据返回
                string str = "proc_PO_Report_count'" + start_time + "','" + end_time + "','" + DeviceId + "'";
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = po }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }

        //报表画面-DailyOutput
        public JsonResult DailyOutput(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();

                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                String str2 = "exec proc_Daily_Output_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "','" + DeviceId + "'";
                List<Daily_Output> daily_output;
                daily_output = db_draq127.daily_output(SqlCon_PCC, str2);

                //查询一共有多少行数据返回
                string str = "proc_Daily_Output_Report_count'" + start_time + "','" + end_time + "','" + DeviceId + "'";
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = daily_output }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }

        //报表画面-MonthlyOutput
        public JsonResult MonthlyOutput(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();

                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                String str2 = "exec proc_Monthly_Output_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "','" + DeviceId + "'";
                List<Monthly_Output> month_output;
                month_output = db_draq127.month_output(SqlCon_PCC, str2);

                //查询一共有多少行数据返回
                string str = "proc_Monthly_Output_Report_count'" + start_time + "','" + end_time + "','" + DeviceId + "'";
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = month_output }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }

        //报表画面-CapOutput
        public JsonResult CapOutput(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();

                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                String str2 = "exec proc_Cap_Output_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "'";
                List<Cap> cap_output;
                cap_output = db_draq127.Cap_output(SqlCon_PCC, str2);

                //查询一共有多少行数据返回
                string str = "proc_Cap_Output_Report_count'" + start_time + "','" + end_time + "'";
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = cap_output }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }

        //报表画面-ESROutput
        public JsonResult ESROutput(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();

                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                String str2 = "exec proc_ESR_Output_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "'";
                List<ESR> ESR_output;
                ESR_output = db_draq127.ESR_output(SqlCon_PCC, str2);
                
                //查询一共有多少行数据返回
                string str = "proc_ESR_Output_Report_count'" + start_time + "','" + end_time + "'";
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = ESR_output }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }


        //报表画面-VoltageOutput
        public JsonResult VoltageOutput(int page, string DeviceId, string limit, string start_time, string end_time)
        {
            if (DeviceId != null)
            {
                string SqlCon_PCC = ConfigurationManager.ConnectionStrings["PCC" + DeviceId + "ConnectionString"].ToString();

                ViewBag.DeviceId = DeviceId;
                //根据当前是第几页，一页有多少行，返回数据
                String str2 = "exec proc_Voltage_Output_Report '" + page + "','" + limit + "','" + start_time + "','" + end_time + "'";
                List<Voltage> Voltage_output;
                Voltage_output = db_draq127.Voltage_output(SqlCon_PCC, str2);

                //查询一共有多少行数据返回
                string str = "proc_Voltage_Output_Report_count'" + start_time + "','" + end_time + "'";
                int Count = db_draq127.ExecuteScalar(SqlCon_PCC, str);
                //返回数据给js
                return Json(new { count = Count, success = 1, data = Voltage_output }, JsonRequestBehavior.AllowGet);
            }
            else { return null; }
        }

    }
}
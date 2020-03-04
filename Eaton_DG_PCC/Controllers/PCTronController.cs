using LinqToExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Eaton_DG_PCC.BigScreen;
using Eaton_DG_PCC.Model;
using Eaton_DG_PCC.Model.DRAQ127;
using Eaton_DG_PCC.Models;
using Eaton_DG_PCC.Model.PCC;

namespace Eaton_DG_PCC.Controllers
{
    public class PCTronController : Controller
    {

        // GET: PCTron-需要修改服务器地址

        private PCTronEntities db2 = new PCTronEntities();
        //private SYRSCMEntities db = new SYRSCMEntities();
        private Device_List devicelist = new Models.Device_List();
        Dbs dbs = new Model.Dbs();
        DB_Single_station db_Single_station = new DB_Single_station();
        DB_Overall_Situation db_Overall_Situation = new DB_Overall_Situation();
        string dtStart, dtEnd;
        ArrayList arraylist = new ArrayList();

        //PHP-ServerPC-需要修改服务器地址1
        //string SqlCon1 = @"Data Source=test-PC\AndyLi;";
        //public static string SqlCon_PCTron = @"Data Source=test-PC\AndyLi;Initial Catalog=PCTron;User ID=sa;Password=ok;";
        //public static string SqlCon_DRAQ75 = @"Data Source=test-PC\AndyLi;Initial Catalog=DRAQ75;User ID=sa;Password=ok;";

        DB_DRAQ127 db_draq127 = new DB_DRAQ127();

        string Now_Years = DateTime.Now.Year.ToString();
        string Now_Months = DateTime.Now.Month.ToString();
        string Last_Months = DateTime.Now.AddMonths(-1).Month.ToString();


        string years = System.DateTime.Now.Year.ToString();
        string months = System.DateTime.Now.Month.ToString();
        string days = System.DateTime.Now.Day.ToString();

        string hours = System.DateTime.Now.Hour.ToString();
        string minutes = System.DateTime.Now.Minute.ToString();
        string seconds = System.DateTime.Now.Second.ToString();


        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]//该注解可以防止跨站攻击
        [ActionName("Login")]//该注解可以更改路由中Action名称
        public ActionResult Login(User model)
        {


            //if (!ModelState.IsValid)
            //{
            //    //用户输入服务端验证,此处处理验证不通过的提示代码 本例略过             
            //    return View("Login");
            //}
            string result = null;
            string sql = "select* from Users where UserName = '" + model.UserName + "' and PassWord = '" + model.Password + "'";
            User user = dbs.Select_UserInfo(sql); //执行Reader查询，存入dr
            if (user.RoleNum != null & user.RoleNum != "")
            {
                if (user.RoleNum == "1")
                {
                    result = "Admin,Edit,Select";
                }
                else if (user.RoleNum == "2")
                {
                    result = "Edit,Select";
                }
                else if (user.RoleNum == "3")
                {
                    result = "Select";
                }
            }




 
           if (result == null)
           {
                //ViewData["msg"] = "登陆失败";
                //用户名或者密码不正确的提示代码 本例略过

                return Content("<script>alert('UserName or Password Error !');history.go(-1);</script>");
            }
           else
           {
                //if () { } else { 
               //用户登陆核心代码
               FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    model.UserName,
                    DateTime.Now,
                    DateTime.Now.AddHours(12),//记住密码的时间
                    model.RememberMe,//是否保存cookie 记住密码
                    result //获取的用户权限列表 用逗号分割的字符串
                    );
               string encryptedTickt = FormsAuthentication.Encrypt(authTicket);
               HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTickt);
               Response.Cookies.Add(authCookie);
 
               Response.Redirect("/PCTron/", true);
               ActionResult empty = new EmptyResult();

                //return empty;
                return RedirectToAction("Indexs");
                
            }
        }

        public ActionResult Register()
        {

            return View();

        }


        public ActionResult Role_Manage()
        {

            String str = "proc_Select_UserInfoAll";
            List<User> list = dbs.Select_UserInfoAll(str);
            for (int i = 0; i < list.Count; i++)
            {
                ViewBag.ID = list[i].ID;
            }
            return View(list);

        }



        public ActionResult Add_Users()
        {
            int ID = Convert.ToInt32(Request["ID"]) + 1;
            ViewBag.ID = ID;



            List<Role_Info> role_info = new List<Role_Info>();
            List<Depart_Info> depart_info = new List<Depart_Info>();

            String Role_Info = "select * from Role_Manage";
            String Depart_Info = "select * from DepartInfo";
            role_info = dbs.Select_RoleInfoAll(Role_Info);
            depart_info = dbs.Select_DepartInfoAll(Depart_Info);


            return View(Tuple.Create(role_info, depart_info));


        }


        [HttpPost]
        public string Add_Users(List<User> model)
        {
            List<User> user=model;

            string username = "";
            string password = "";
            string rolenum = "";
            string realname = "";
            string email = "";
            string phone = "";
            string department="";
            foreach (var item in user)
            {
               username =  item.UserName;
               password = item.Password;
               rolenum = item.RoleNum;
               realname = item.RealName;
               email = item.Email;
               phone = item.Phone;
               department = item.DepartNum;
            }
            String sql = " insert into Users(UserName,PassWord,RoleNum,RealName,Email,Phone,DepartNum) values( '" + username + "','" + password + "','" + rolenum + "','" + realname + "','" + email + "','" + email + "','" + department + "')";
            int result = Dbs.ExecuteNonQuery(sql);
            if (result == 1) {
                return "Success";
            } else {
                return "no";
            }


        }


        public ActionResult Edit_Role(int? ID)
        {

            string DeviceId = Request["DeviceId"];



            String str = "exec proc_Select_Basic_Manage   '" + ID + "'";
            List<Role_Info> role_info = new List<Role_Info>();
            List<Depart_Info> depart_info = new List<Depart_Info>();

            String Role_Info = "select * from Role_Manage";
            String Depart_Info = "select * from DepartInfo";
            role_info = dbs.Select_RoleInfoAll(Role_Info);
            depart_info = dbs.Select_DepartInfoAll(Depart_Info);


            User list = dbs.Select_Role_Info(str);
            return View(Tuple.Create(list, role_info, depart_info));
        }

        [HttpPost]
        public ActionResult Edit_Role(List<String> Role_manage)
        {
            string ID = Role_manage[0];
            //string UserName = Role_manage[1];
            string Password = Role_manage[1];
            string Role = Role_manage[2];
            string RealName = Role_manage[3];
            string Phone = Role_manage[4];
            string DepartNum = Role_manage[5];


            //string newUserName = Leach(UserName);
            string newPassword = Leach(Password);
            string newRole = Leach(Role);
            string newRealName = Leach(RealName);
            string newPhone = Leach(Phone);
            string newDepartNum = Leach(DepartNum);

            String sql = "exec proc_Update_Role_Manage '" + ID + "','" + newPassword + "','" + newRole + "','" + newRealName + "','" + newPhone + "','" + newDepartNum + "'";
            int result = Dbs.ExecuteNonQuery(sql);
            if (result == 1)
            {
                ViewBag.saveStatus = 1;
                // return 1;
                String tip = "Success";
                return JavaScript(tip);
            }
            else
            {
                ViewBag.saveStatus = 0;
                String tip = "Fail";
                return JavaScript(tip);
                //return Content("<script>alert('no');history.go(-1);</script>");
            }

        }


        [HttpPost]
        public String Delete_Role(int id)
        {
            String sql = "proc_Delete_Role '" + id + "'";
            int result = Dbs.ExecuteNonQuery(sql);
            if (result == 1)
            {
                ViewBag.saveStatus = 1;
                // return 1;
                String tip = "success";
                //return RedirectToAction("Basci_faq");
                return tip;
            }
            else
            {
                ViewBag.saveStatus = 0;
                String tip = "Fail";
                return tip;
                //return Content("<script>alert('no');history.go(-1);</script>");
            }
        }



        public ActionResult DRAQ127()
        {
            string DeviceId = Request["DeviceId"];
            ViewBag.DeviceId = DeviceId;
            //String str = "exec proc_Device_Info '" + DeviceId + "'";
            //AllStatus list = dbs.DeviceAllStatus_DRAQ127(str);
            //ViewBag.Display_Model = list.Now_Model.ToString();

            String str_Monthly_Output_list = "proc_Select_Monthly_Output_PCTron";
            List<Monthly_Output_PCTron> Monthly_Output_list = dbs.Select_Monthly_Data_Output(str_Monthly_Output_list);
            //ViewBag.Monthly_Output_list = Monthly_Output_list;
            String str_Monthly_NG_list = "proc_Select_Monthly_NG_PCTron";
            List<Monthly_NG_PCTron> Monthly_NG_list = dbs.Select_Monthly_Data_NG(str_Monthly_NG_list);
            ViewBag.Monthly_OK_list = Monthly_NG_list;
            //return View(list);

            String str_Daily_Output_list = "proc_Select_Daily_Output";
            List<Model.Daily_Output_Model> Daily_Output_list = dbs.Select_Daily_Data(str_Daily_Output_list);
            //ViewBag.Daily_Output_list = Daily_Output_list;
            String str_Daily_NG_list = "proc_Select_Daily_NG";
            List<Daily_NG_Model> Daily_NG_list = dbs.Select_Daily_Data_NG(str_Daily_NG_list);
            //ViewBag.Daily_OK_list = Daily_OK_list;

            return View(Tuple.Create(Monthly_Output_list, Daily_Output_list, Daily_NG_list));
            //return View(Tuple.Create(list, Monthly_Output_list, Daily_Output_list, Daily_NG_list));

        }



        //[Authorize(Roles = "Admin,Edit,Select")]
        public ActionResult Indexs()
        {
            //登陆验证
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                return RedirectToAction("Login", "PCTron");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string role = ticket.UserData;
            string name = ticket.Name;
            ViewData["name"] = name;
            ViewData["role"] = role;

            return View();
        }
        [HttpPost]
        public ActionResult Indexs(string signout)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult LogOff()
        { //
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "PCTron");
        }



        public ActionResult Device_List()
        {

            //查询所有机型
            String str = "select * from RealTimePlantData";
            List<RealTimePlantData> list = dbs.DeviceSimpleInfo(str);

            return View(list);
        }

        public ActionResult Line(string DeviceId)
        {
            ViewBag.DeviceId = DeviceId;
            return View();

        }




        public ActionResult BigScreen4()
        {
            

            String Last_Months_Add = Last_Months.PadLeft(2, '0');
            String Monthly_Test_Output = "Monthly_Test_Output" + Last_Months_Add;
            String Monthly_Test_NG = "Monthly_Test_NG" + Last_Months_Add;
            String Monthly_Test_NG_Ratio = "Monthly_Test_NG_Ratio" + Last_Months_Add;


            String str_Select_Device_Information_Last_Month = "exec proc_BigScreen_Select_Device_Information_Last_Month '" + Monthly_Test_Output + "'" + ",'" + Monthly_Test_NG + "'";
            String str_proc_BigScreen_Select_Real_Time_Progress = "exec proc_BigScreen_Select_Real_Time_Progress ";
            String str_proc_BigScreen_Select_Statistical_data = "exec proc_BigScreen_Select_Statistical_data ";
            String str_Select_Top10_Last_Month_Output_NG = "exec proc_BigScreen_Select_Top10_Last_Month_Output_NG '" + Monthly_Test_Output + "'" + ",'" + Monthly_Test_NG + "'";
            String str_Select_Top10_Last_Month_Run_Alarm = "exec proc_BigScreen_Select_Top10_Last_Month_Run_Alarm";
            String str_Select_Top5_Alarm_times = "exec proc_BigScreen_Select_Top5_Alarm_times";
            String str_Select_Top5_NG = "exec proc_BigScreen_Select_Top5_NG  " + Monthly_Test_NG_Ratio + "";


            List<Select_Device_Information_Last_Month> list_Select_Device_Information_Last_Month = db_Overall_Situation.Select_Device_Information_Last_Months(str_Select_Device_Information_Last_Month);
            List<Select_Real_Time_Progress> list_Select_Real_Time_Progress = db_Overall_Situation.Select_Real_Time_Progresss(str_proc_BigScreen_Select_Real_Time_Progress);
            Select_Statistical_data list_Select_Statistical_data = db_Overall_Situation.Select_Statistical_datas(str_proc_BigScreen_Select_Statistical_data);
            List<Select_Top10_Last_Month_Output_NG> list_Select_Top10_Last_Month_Output_NG = db_Overall_Situation.Select_Top10_Last_Month_Output_NGs(str_Select_Top10_Last_Month_Output_NG);
            List<Select_Top10_Last_Month_Run_Alarm> list_Select_Top10_Last_Month_Run_Alarm = db_Overall_Situation.Select_Top10_Last_Month_Run_Alarms(str_Select_Top10_Last_Month_Run_Alarm);
            List<Select_Top5_Alarm_times> list_Select_Top5_Alarm_times = db_Overall_Situation.Select_Top5_Alarm_timess(str_Select_Top5_Alarm_times);
            List<Select_Top5_NG> list_Select_Top5_NG = db_Overall_Situation.Select_Top5_NGs(str_Select_Top5_NG);
            //int[] i = { list_Select_Top10_Last_Month_Run_Alarm[0].Last_Month_Runing_Time, list_Select_Top10_Last_Month_Run_Alarm[1].Last_Month_Runing_Time, list_Select_Top10_Last_Month_Run_Alarm[2].Last_Month_Runing_Time, list_Select_Top10_Last_Month_Run_Alarm[3].Last_Month_Runing_Time, list_Select_Top10_Last_Month_Run_Alarm[4].Last_Month_Runing_Time };
            //ViewBag.list_Select_Top5_Last_Month_Run_Alarm_MaxData = i.Max();

            //int[] j = { list_Select_Top10_Last_Month_Output_NG[0].Monthly_Test_Output, list_Select_Top10_Last_Month_Output_NG[1].Monthly_Test_Output, list_Select_Top10_Last_Month_Output_NG[2].Monthly_Test_Output, list_Select_Top10_Last_Month_Output_NG[3].Monthly_Test_Output, list_Select_Top10_Last_Month_Output_NG[4].Monthly_Test_Output };
            //ViewBag.list_Select_Top5_Last_Month_Output_NG_MaxData = j.Max();
            //ViewBag.list_Select_Top5_Last_Month_Output_NG_interval = j.Max() / 5;


            //需要改进报警次数集合数，容易超过索引值
            int[] k = { list_Select_Top5_Alarm_times[0].Last_Month_Alarm_Times, list_Select_Top5_Alarm_times[1].Last_Month_Alarm_Times, list_Select_Top5_Alarm_times[2].Last_Month_Alarm_Times, list_Select_Top5_Alarm_times[3].Last_Month_Alarm_Times, list_Select_Top5_Alarm_times[4].Last_Month_Alarm_Times };
            //int[] k = { list_Select_Top5_Alarm_times[0].Last_Month_Alarm_Times, list_Select_Top5_Alarm_times[1].Last_Month_Alarm_Times};
            ViewBag.list_Select_Top5_Alarm_times_MaxData = k.Max();


            ViewBag.Select_Device_Information_Last_Month = list_Select_Device_Information_Last_Month;
            ViewBag.Select_Statistical_data = list_Select_Statistical_data;
            ViewBag.Select_Top5_Last_Month_Output_NG = list_Select_Top10_Last_Month_Output_NG;
            return View(Tuple.Create(list_Select_Real_Time_Progress, list_Select_Top10_Last_Month_Run_Alarm, list_Select_Top5_Alarm_times, list_Select_Top5_NG));
            //return View(Tuple.Create(list_Select_Device_Information_Last_Month, list_Select_Real_Time_Progress, list_Select_Statistical_data, list_Select_Top10_Last_Month_Output_NG, list_Select_Top10_Last_Month_Run_Alarm, list_Select_Top5_Alarm_times, list_Select_Top5_NG));
        }
        /// <summary>
        /// 过滤不安全字符方法
        /// </summary>
        /// <param name="Leachcontent"></param>
        /// <returns></returns>
        public string Leach(string Leachcontent)
        {
            string str = Leachcontent.Trim();

            str = str.Replace("'", "''");
            return str;
        }

    }
}
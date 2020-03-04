using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.BigScreen
{
    public class Select_Device_Information_Last_Month
    {
        public string DeviceId { get; set; }
        public int Monthly_Test_Output { get; set; }
        public int Monthly_Test_NG { get; set; }
        public int Last_Month_Runing_Time { get; set; }
        public int Last_Month_Ready_Time { get; set; }
        public int Last_Month_Alarm_Time { get; set; }
        public int Last_Month_Alarm_Times { get; set; }
    }
}
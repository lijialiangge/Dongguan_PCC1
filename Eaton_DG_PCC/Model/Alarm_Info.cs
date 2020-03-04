using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Alarm_Info
    {
        public string AlarmID { get; set; }
        public string BeginTime { get; set; }
        public string Alarm_Station { get; set; }
        public string Alarm_Content { get; set; }
        public string Alarm_Level { get; set; }
        public string EndTime { get; set; }
    }
}
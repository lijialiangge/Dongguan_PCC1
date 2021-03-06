﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model.DRAQ127
{
    public class Alarm_Messages
    {
        public Int64 rownumber { get; set; }
        public int ID { get; set; }
        public string LineID { get; set; }
        public int StationID { get; set; }
        public DateTime WarnTime { get; set; }
        public DateTime NormalTime { get; set; }
        public string WarnID { get; set; }
        public string WarnExplain { get; set; }
        public int Duration { get; set; }
        public int IfCure { get; set; }
        
    }
}
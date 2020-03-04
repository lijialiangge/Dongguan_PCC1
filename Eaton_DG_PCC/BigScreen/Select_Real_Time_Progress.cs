using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.BigScreen
{
    public class Select_Real_Time_Progress
    {
        public string DeviceId { get; set; }
        public string Now_Order { get; set; }
        public string Now_Model { get; set; }
        public int Plan_Output { get; set; }
        public int Now_Output { get; set; }
        public int Now_NG { get; set; }
        public string Done_Ratio { get; set; }
        
    }
}
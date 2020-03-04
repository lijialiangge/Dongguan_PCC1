using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.BigScreen
{
    public class Select_Statistical_data
    {
        public int All { get; set; }
        public int Online { get; set; }
        public int Offline { get; set; }
        public int Null { get; set; }
        public int Run { get; set; }
        public int Alarm { get; set; }
        public int Ready { get; set; }
        public int Maintenance_advance { get; set; }
        public int Maintenance_completed { get; set; }
        public int Maintenance_expired { get; set; }
        public int Maintenance_count { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model.PCC
{
    public class DayInfoHistory
    {
        public int ID { get; set; }
        public string LineID { get; set; }
        public string UpdateTime { get; set; }
        public string RecordTime { get; set; }
        public string LastRecordTime { get; set; }
        public string ProductID { get; set; }
        public string DutMode { get; set; }
        public int DutTotalNum { get; set; }
        public int DutPassNum { get; set; }
        public int DutFailNum { get; set; }
        public double DutFailRate { get; set; }
        public int cap { get; set; }
        public int ESR { get; set; }
        public int Voltage { get; set; }

    }
}
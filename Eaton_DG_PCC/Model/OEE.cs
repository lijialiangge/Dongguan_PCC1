using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class OEE
    {
        public Int64 rownumber { get; set; }
        public int ReadID { get; set; }
        public int ID { get; set; }
        public DateTime InputTime { get; set; }
        public string LineID { get; set; }
        public string ProductID { get; set; }
        public string DutMode { get; set; }
        public string TraySN { get; set; }
        public int DutTotalNum { get; set; }
        public int DutPassNum { get; set; }
        public int DutFailNum { get; set; }
        public int cap { get; set; }
        public int ESR { get; set; }
        public int Voltage { get; set; }

    }
}
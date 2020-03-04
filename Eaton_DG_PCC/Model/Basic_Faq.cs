using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Basic_Faq
    {
        public int ID { get; set; }
        public string Ts { get; set; }
        public string DeviceId { get; set; }
        public string Problem { get; set; }
        public string Answer     { get; set; }
        public string Owner { get; set; }
    }
}
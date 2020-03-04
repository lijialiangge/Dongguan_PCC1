using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Order
    {
        public string OrderID { get; set; }
        public string BeginTime { get; set; }
        public string Plan_Output { get; set; }
        public string Output { get; set; }
        public string NG { get; set; }
        public string EndTime { get; set; }
    }
}
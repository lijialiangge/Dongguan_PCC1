using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Depart_Info
    {
        public int ID { get; set; }
        public string DepartNum { get; set; }
        public string DepartName { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string Remark { get; set; }
    }
}
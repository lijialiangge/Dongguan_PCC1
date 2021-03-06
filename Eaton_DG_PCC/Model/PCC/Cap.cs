﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model.PCC
{
    public class Cap
    {
        public Int64 rownumber { get; set; }
        public int DutID { get; set; }
        public DateTime InputTime { get; set; }
        public int ProductID { get; set; }
        public string DutMode { get; set; }
        public string TraySN { get; set; }
        public int Position { get; set; }
        public string State { get; set; }
        public double CapValue { get; set; }
        public double ResValue { get; set; }
        public DateTime OutputTime { get; set; }

    }
}
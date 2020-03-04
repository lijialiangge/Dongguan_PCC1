using System;


namespace Eaton_DG_PCC.Model.PCC
{
    public class ESR
    {
        public Int64 rownumber { get; set; }
        public int DutID { get; set; }
        public DateTime InputTime { get; set; }
        public int ProductID { get; set; }
        public string DutMode { get; set; }
        public string TraySN { get; set; }
        public int Position { get; set; }
        public string State { get; set; }
        public double EqualRes { get; set; }
        public DateTime OutputTime { get; set; }

    }
}
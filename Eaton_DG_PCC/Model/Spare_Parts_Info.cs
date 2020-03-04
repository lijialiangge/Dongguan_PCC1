using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Spare_Parts_Info
    {
        //2019-8-30
        public int ID { get; set; }
        public int Real_id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Num { get; set; }
        public string Model { get; set; }
        public Nullable<int> Stock_Quantity { get; set; }
        public string Unit { get; set; }
        public Nullable<int> Safety_Stock { get; set; }
        public string Supplier { get; set; }
        public string Contacts { get; set; }
        public string Phone { get; set; }
        public string Mark { get; set; }
        public string ImageUrl { get; set; }
    }
}
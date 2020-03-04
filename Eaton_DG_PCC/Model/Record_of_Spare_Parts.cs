using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Record_of_Spare_Parts
    {

      
            public int ID { get; set; }
            public string Replace_Date { get; set; }
            public string Replace_content { get; set; }
            public string Operator { get; set; }
            public string Telephone { get; set; }

        


    }
}
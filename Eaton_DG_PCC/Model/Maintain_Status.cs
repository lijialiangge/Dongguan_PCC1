
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class Maintain_Status
    {

      
            public int Maintenance_has_expired { get; set; }
            public int Already_maintained { get; set; }
            public int Maintenance_in_advance { get; set; }


        


    }
}
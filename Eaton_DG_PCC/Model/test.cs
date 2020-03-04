using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel.Attributes;

namespace Eaton_DG_PCC.Model
{
    public class test
    {
        [ExcelColumn("设备ID")]
        public string devcieid { get; set; }
        [ExcelColumn("报警名称")]
        public string AlarmName { get; set; }
        [ExcelColumn("时间")]
        public DateTime starttime { get; set; }
    }
}
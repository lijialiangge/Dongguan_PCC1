using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class NetworkStatus
    {
        public NetworkStatus(String deviceId, String versions)
        {

            this.DeviceId = deviceId;
            this.Versions = versions;
        }
        public String DeviceId { get; set; }
        public String Versions { get; set; }
    }
}
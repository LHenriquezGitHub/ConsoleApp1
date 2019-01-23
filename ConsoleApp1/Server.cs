using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Greenhouse.Data.Model.Setup
{
    [Serializable]
    public class Server : BasePOCO
    {
      
        public int ServerID { get; set; }
        public string ServerAlias { get; set; }
        public string ServerMachineName { get; set; }
        public string ServerName { get; set; }
        public string ServerIP { get; set; }
        public int ServerTypeID { get; set; }
        public int ExecutionTypeID { get; set; }
        public int ClusterID { get; set; }
        public string TimeZoneString { get; set; }
        public bool IsActive { get; set; }
    }
}

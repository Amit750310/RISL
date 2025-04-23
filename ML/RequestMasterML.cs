using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
 public  class RequestMasterML
    {


    }

    public class FirstModel
    {
        public string deptNAme { get; set; }
        public string deptNAmeid { get; set; }
        public string OICNAme { get; set; }
        public string TO { get; set; }
        public string Subject { get; set; }
        public string Ref { get; set; }
        public string Fileno { get; set; }
        public string information { get; set; }
        public string AddedBy { get; set; }

    }

    public class ServiceItem
    {
        public int SerialNumber { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string UnitCost { get; set; }
        public string TotalAmount { get; set; }
        public string AddedBy { get; set; }
        public string Oid { get; set; }

    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ML
{
    [DataContract]
    public class clsLoginML
    {
       
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string pswrd{get;set;}

        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string roleId { get; set; }
        [DataMember]
        public string loginId { get; set; }
        [DataMember]
        public string mobileno { get; set; }
        
    }

   
}

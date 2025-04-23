using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BL
{
    public class clsAPIBL
    {
        public static string PartnerCode= ConfigurationManager.AppSettings["PartnerCode"].ToString();
        public static string UserName = ConfigurationManager.AppSettings["UserName"].ToString();
        public static string Password = ConfigurationManager.AppSettings["Password"].ToString();
        public static string ContractId = ConfigurationManager.AppSettings["ContractId"].ToString();
        public static string ApiVersion = ConfigurationManager.AppSettings["ApiVersion"].ToString();

        public static string Method = "Reseller";
        public static string SignatureHashAlgorithm = "SHA2-256";
        public static string WebServerType = "iis";
    }
}

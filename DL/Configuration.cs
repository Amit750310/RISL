using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DL
{
    public class Configuration
    {
        public static string Connection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            }
        }
    }
}

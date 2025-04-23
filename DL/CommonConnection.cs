using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace DL
{
  
        public class CommonConnection
        {
            public string getConnection()
            {
              
               string connStr= DBConnection.ConStr;
                return connStr;
            }
          
            public  class DBConnection
            {
                
                public static String ConStr = System.Configuration.ConfigurationSettings.AppSettings["conStr"].ToString();
               
            }
           

        }
       
    
}

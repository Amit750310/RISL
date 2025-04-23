using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace BL
{
    public class conn
    {
        string str;
        private SqlConnection sql_con;

        public SqlConnection sql_open()
        {
            //str = "Data Source=.;Initial Catalog=eaudit;Persist Security Info=True;User ID=sa;Password=nirbhay@123;connect timeout=0;Max Pool Size=20000";
            str = ConfigurationManager.ConnectionStrings["conString"].ToString();
            // str = "Data Source=10.67.54.124;Initial Catalog=eaudit;Persist Security Info=True;User ID=eaudit;Password=EauD@@##1877;connect timeout=0;Max Pool Size=20000";
            sql_con = new SqlConnection(str);
            sql_con.Open();
            return sql_con;
        }
        public void sql_close()
        {
            sql_con.Dispose();
            sql_con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vms
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                    Session["roleID"] = null;
                    Session["loginId"] = null;
                    Session["Loginusername"] = null;
                    Session["username"] = null;
                    Session["Employeecode"] = null;
                    Session["HiLevel"] = null;
                    Response.Redirect("index.aspx");
                
            }
        }
    }
}
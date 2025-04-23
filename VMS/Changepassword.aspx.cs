using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DL;
using BL;
using ML;

namespace vms
{
    public partial class Changepassword : System.Web.UI.Page
    {
        clsLoginML obj = new clsLoginML();
        clsLoginBL dal = new clsLoginBL();
        Sendmail snd = new Sendmail();
        BaseCommon bc = new BaseCommon();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string msg = dal.ResetPassword(Convert.ToString(Session["Employeecode"]), txtoldpwd.Text.Trim(), txtnewpwd.Text.Trim());
            mymsg(msg);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            txtconfirmpwd.Text = "";
            txtnewpwd.Text = "";
        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
    }
}
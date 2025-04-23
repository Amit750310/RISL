using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DL;
using System.Configuration;
using System.DirectoryServices;
using ML;

namespace vms
{
    public partial class Index : System.Web.UI.Page
    {
        Sendmail snd = new Sendmail();
        BaseCommon bc = new BaseCommon();
        protected void Page_Load(object sender, EventArgs e)
        {
            string BMpwd = bc.Base64Decode("UmVzdGluRGVsaGlAMzMw");
            string rjpwd = bc.Base64Decode("VHJ5bWVvb3BzMQ==");
            string vkpwd = bc.Base64Decode("amF0aW5AMTIz");
            //if (!IsPostBack)
            //{
            //    try
            //    {
            //        Session["roleID"] = null;
            //        Session["loginId"] = null;
            //        Session["Loginusername"] = null;
            //        Session["username"] = null;
            //        Session["Employeecode"] = null;
            //        Session["HiLevel"] = null;
            //    }
            //    catch { }
            //}




        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            validateuser(txtUsername.Text, txtPassword.Text);

           
        }



        private void validateuser(string user, string pass)
        {
           // string ldapHost_ = ConfigurationManager.AppSettings["LdapServer"];
            string ldapHost_ = "ldap.example.com";
            int ldapPort = 389;
            string ldapUser = "cn=admin,dc=example,dc=com";
            string ldapPassword = "admin_password";
            string baseDn = "dc=example,dc=com";

            // Initialize LDAP service
            LdapService ldapService = new LdapService(ldapHost_, ldapPort, ldapUser, ldapPassword, baseDn);
            bool isAuthenticated = ldapService.Authenticate(ldapHost_, ldapPassword);
            Console.WriteLine(isAuthenticated ? "User authenticated successfully." : "Invalid credentials.");

            string pwd = bc.Base64Encode(pass);
            DataTable dt = BaseCommon.GetDataSet("CheckAdminValidation'" + user + "','" + pwd + "' ", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                try
                {

                    string loginId = dt.Rows[0]["emp_Id"].ToString();
                    string dtUserName = dt.Rows[0]["First_Name"].ToString() + " " + dt.Rows[0]["Last_Name"].ToString();
                    string roleID = dt.Rows[0]["role_Id"].ToString();
                    string EmailId = dt.Rows[0]["email_Id"].ToString();
                    string mobileno = dt.Rows[0]["mobile"].ToString();
                    string EmployeeCode = dt.Rows[0]["Employee_code"].ToString();
                    string HiLevel = dt.Rows[0]["HiLevel"].ToString();

                    string strrole = null;
                    Session["roleID"] = roleID;
                    Session["loginId"] = loginId;
                    Session["Loginusername"] = dtUserName;
                    Session["EmailId"] = EmailId;
                    Session["mobileno"] = mobileno;
                    Session["username"] = dtUserName;
                    Session["Employeecode"] = EmployeeCode;
                    Session["HiLevel"] = HiLevel;
                   // Response.Redirect("~/Dashboard.aspx");

                }
                catch (Exception ex)
                {
                   
                    DL.BaseCommon objerr = new DL.BaseCommon();
                    objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                   
                }
                Response.Redirect("~/Dashboard.aspx");
            }
            else
            {
                Session["roleID"] = null;
                Session["loginId"] = null;
                Session["Loginusername"] = null;
                Session["username"] = null;
                Session["dptmaster"] = null;

            }
        }



        private void check()
        {
            string strReq = "";
            strReq = Request.RawUrl;
            Int16 test = Convert.ToInt16(strReq.IndexOf('?'));
            if (test > 0)
            {
                strReq = strReq.Substring(strReq.IndexOf('?') + 1);

                if (!strReq.Equals(""))
                {

                    string[] arrMsgs = strReq.Split('&');
                    string[] name;
                    string[] pwd;
                    string[] branch;
                    string strName = "", strAge = "";
                    name = arrMsgs[0].Split('=');
                    pwd = arrMsgs[1].Split('=');
                    branch = arrMsgs[2].Split('=');
                    strName = name[1].ToString().Trim();
                    strAge = pwd[1].ToString().Trim();
                    string strBranch = branch[1].ToString().Trim();

                    if (strName != "" && strAge != "")
                    {

                    }
                }
            }
        }



        protected void btnFSubmit_Click(object sender, EventArgs e)
        {


            DataTable dt = BaseCommon.GetDataSet("[IMS_Forgot_Password] '" + txtemail.Text + "'", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string UserName = dt.Rows[0]["UserId"].ToString();
                string Password = dt.Rows[0]["Password"].ToString();
                string Mail = txtemail.Text;
                string sub = "Forgot Password ";
                string body = "Your User Name is : " + UserName + "  " + "and Password is : " + Password;

                bool str = bc.SendAuthenticatedMail(Mail, sub, body, "");
                if (str == true)
                {
                    mymsg("Password will be sent to your email");
                }
                else
                {
                    mymsg("Try again");
                }

            }
            else
            {
                mymsg("Email ID  may be wrong ");
            }



        }


        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {


            }
            else
            {
                validateuser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            }

        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }


    }
}
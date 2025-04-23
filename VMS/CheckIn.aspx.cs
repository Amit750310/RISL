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
using System.IO;
using System.Web.Services;

namespace vms
{
    public partial class CheckIn : System.Web.UI.Page
    {
        [WebMethod()]
        public static bool SaveCapturedImage(string data)
        {
            string fileName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");

            //Convert Base64 Encoded string to Byte Array.
            byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);

            //Save the Byte Array as Image File.
            string filePath = HttpContext.Current.Server.MapPath(string.Format("~/Captures/{0}.jpg", fileName));
            File.WriteAllBytes(filePath, imageBytes);
            return true;


        }
        ClsvendorsBL dal = new ClsvendorsBL();
        ClsvendorsML Obj = new ClsvendorsML();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
     
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }

        protected void btnproced_Click(object sender, EventArgs e)
        {
           
            flag = "I";
            InsertEmployee();
        }
        private void InsertEmployee()
        {

            Obj.Vendor_Id = "";
            Obj.VendorName = txtfirstname.Text;
           
            Obj.MobileNo = txtmailid.Text;
            Obj.Mobile = txtmobilno.Text;
            Obj.Gender = ddlgender.SelectedValue;
            Obj.Company = txtCompany.Text;
            Obj.Address = txtaddress.Text;
            Obj.whomtoMeet= txtwhomtomeet.Text;
            Obj.Last_Name = txtlastname.Text;
            Obj.mode = flag;
            Obj.CREATED_BY = "29";
            Obj.UPDATED_BY = "";
            string save = dal.InsertVisitor(Obj);
            if (save != "false")
            {

                Clear();

                pnlpop.Visible = true;
                pnlcheckin.Visible = false;
            }

        }
        private void Clear()
        {

            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtmailid.Text = "";
            txtmobilno.Text = "";
            txtCompany.Text = "";
            txtaddress.Text = "";

        }

       

        protected void lnkcheckinclose_Click(object sender, EventArgs e)
        {
            pnlcheckin.Visible = false;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            pnlcheckin.Visible = false;
        }

        protected void btnrecheckin_Click(object sender, EventArgs e)
        {
            pnlcheckin.Visible = true;
            pnlpop.Visible = false;
        }

        protected void btnpopupclose_Click(object sender, EventArgs e)
        {
            pnlpop.Visible = false;
        }

        

        protected void btnpopcancel_Click(object sender, EventArgs e)
        {
            pnlpop.Visible = false;
        }

       

        protected void btncheckin_Click(object sender, EventArgs e)
        {
            pnlcheckin.Visible = true;
            pnlpop.Visible = false;
        }
    }
}
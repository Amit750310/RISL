using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Data;
using ML;

namespace vms
{
    public partial class BrandMaster : System.Web.UI.Page
    {
        ClsBrandMasterBL tblbrand = new ClsBrandMasterBL();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();

            }
        }

        private void bind()
        {
            DataTable dt = tblbrand.Getallbrand();
            if (dt.Rows.Count > 0)
            {

                rptRole.DataSource = dt;
                rptRole.DataBind();
            }
            else
            {

                rptRole.DataSource = null;
                rptRole.DataBind();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:block";
                lblmsg2.Text = "No records found.";
            }
        }
        protected void btnAddrole_Click(object sender, EventArgs e)
        {
            btnsave.Visible = true;
            imgbtnupdate.Visible = false;
            Clear();
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
        }

        protected void imgbtnVbatch_Click(object sender, EventArgs e)
        {

            btnsave.Visible = false;
            imgbtnupdate.Visible = false;
            Clear();
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
            divfillgrid.Attributes["Style"] = "display:block";
            divsavedata.Attributes["Style"] = "display:none";
            bind();

        }

        protected void rptRole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                string Rcode = ((Label)e.Item.FindControl("lblRolecode")).Text;
                string name = ((Label)e.Item.FindControl("lblbrandname")).Text;
                string display = ((Label)e.Item.FindControl("lbldisplay")).Text;
                hfbrandid.Value = Rcode;
                txtbrand.Text = name;
                txtorderby.Text = display;
                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                btnsave.Visible = false;
                imgbtnupdate.Visible = true;
            }
            //if (e.CommandName == "Delete")
            //{

            //    string str = "";
            //    if (str != "false")
            //    {
            //        divmsg1.Attributes["Style"] = "display:block";
            //        divmsg2.Attributes["Style"] = "display:none";
            //        divfillgrid.Attributes["Style"] = "display:block";
            //        divsavedata.Attributes["Style"] = "display:none";
            //        lblmsg1.Text = "Client OWner Code deleted Successfully...";
            //        bind();
            //    }
            //    else
            //    {
            //        divmsg1.Attributes["Style"] = "display:none";
            //        divmsg2.Attributes["Style"] = "display:block";
            //        divfillgrid.Attributes["Style"] = "display:block";
            //        divsavedata.Attributes["Style"] = "display:none";
            //        lblmsg2.Text = "Client OWner Code not Deleted.";

            //    }
            //}
        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
        private void Clear()
        {
            txtbrand.Text = "";
            txtorderby.Text = "";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            flag = "I";
            InsertEmployee();

        }

        protected void imgbtnupdate_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
            flag = "M";
            InsertEmployee();
            // bind();
        }

        private void InsertEmployee()
        {
            ClsBrandMasterML obj = new ClsBrandMasterML();
            obj.BrandName = txtbrand.Text.Trim();
            obj.Orderby = txtorderby.Text.Trim();
            obj.mode = flag;
            obj.BrandID = hfbrandid.Value;
            obj.AddedBy = Convert.ToString(Session["LoginId"]);
            string save = tblbrand.InsertBarnd(obj);
            if (save != "false")
            {
                Clear();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                lblmsg1.Text = " Saved Successfully...";
                bind();
            }
        }
    }
}

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
    public partial class levelMaster : System.Web.UI.Page
    {
        ClsLevelMasterBL LevelMaster = new ClsLevelMasterBL();
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
            DataTable dt = LevelMaster.GetallhilevelMaster();
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

                Label lbllevel_ID = ((Label)e.Item.FindControl("lbllevel_ID"));
                Label lblhiLevel = ((Label)e.Item.FindControl("lblhiLevel"));
                
                hflevel_ID.Value = lbllevel_ID.Text;
                txthiLevel.Text = lblhiLevel.Text;
                
                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                btnsave.Visible = false;
                imgbtnupdate.Visible = true;
            }
           
        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
        private void Clear()
        {
            txthiLevel.Text = "";
            
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
            ClsLevelMasterML obj = new ClsLevelMasterML();
            obj.hiLevel = txthiLevel.Text.Trim();
            obj.mode = flag;
            obj.level_ID = hflevel_ID.Value;
            obj.AddedBy = Convert.ToString(Session["LoginId"]);
            string save = LevelMaster.InserthilevelMaster(obj);
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

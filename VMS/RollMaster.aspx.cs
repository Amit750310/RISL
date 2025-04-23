using BL;
using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vms
{
    public partial class RollMaster : System.Web.UI.Page
    {
        clsMenuMasterBL objBl = new clsMenuMasterBL();
        clsMenuMasterML objML = new clsMenuMasterML();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginId"] != null)
                {
                    bind();
                }
                else
                {
                    Response.Redirect("index.aspx", false);
                }
            }
        }
        private void bind()
        {
            objML.RollName = "";
            DataSet ds = objBl.getrollDetails(objML);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptRole.DataSource = ds ;
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
            btnproced.Visible = true;
            imgbtnupdate.Visible = false;
            ClearMe();
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
        }
        private void ClearMe()
        {
            txtrollName.Text = "";
            chkActive.Checked = false;
        }

        protected void btnproced_Click(object sender, EventArgs e)
        {
            flag = "I";
            InsertRollMaster();
        }
        protected void imgbtnupdate_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
            flag = "M";
            InsertRollMaster();
            // bind();
        }
        private void InsertRollMaster()
        {
            objML.RollId = hfid.Value;
            objML.RollActive = chkActive.Checked.ToString();
            objML.RollName = txtrollName.Text;
           if (flag == "I")
            {
                objBl.InsertRollMaster(objML);
                ClearMe();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                lblmsg1.Text = "  Saved Successfully...";
                bind();

            }
            else
            {
                objBl.UpdateRollMaster(objML);
                ClearMe();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                lblmsg1.Text = "  Update Successfully...";
                bind();
               
            }
        }
        protected void imgbtnVbatch_Click(object sender, EventArgs e)
        {

            btnproced.Visible = false;
            imgbtnupdate.Visible = false;
            ClearMe();
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
                string RollID = ((Label)e.Item.FindControl("lblRollID")).Text;
                hfid.Value = RollID;
                getsingleRoll();
                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
            }
        }
        private void getsingleRoll()
        {
           
            objML.RollId = hfid.Value;
            DataSet ds = objBl.getsingleRoll(objML);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                txtrollName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RollName"]);
                chkActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]);
                btnproced.Visible = false;
                imgbtnupdate.Visible = true;
            }
        }
        }
}
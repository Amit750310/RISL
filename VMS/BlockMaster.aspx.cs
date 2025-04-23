
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
    public partial class BlockMaster : System.Web.UI.Page
    {
        ClsBlockMasterBL tblsubcategory = new ClsBlockMasterBL();
        ClsStateMasterBL tblcategory = new ClsStateMasterBL();
        ClsDistrictMasterBL tblDis = new ClsDistrictMasterBL();

        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                bind();
                filldropdown();
                
            }
        }

        private void bind()
        {
            DataTable dt = tblsubcategory.Getallsubcategory();
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
        void filldropdown()
        {
            tblsubcategory.fill_Internal_State(drdstate);
        }

        protected void drdstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Internal_AuditUnit();
        }
        void fill_Internal_AuditUnit()
        {
            string Department_Id = drdstate.SelectedValue;
            tblsubcategory.fill_Internal_district(ref drddistrict, Department_Id);
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
                string subcategory_id = ((Label)e.Item.FindControl("IblID")).Text;
                string lblStateid = ((Label)e.Item.FindControl("lblStateid")).Text;
                string LbldistID = ((Label)e.Item.FindControl("LbldistID")).Text;
                string lblBlockName = ((Label)e.Item.FindControl("lblBlockName")).Text;

                hfsubCategoryID.Value = subcategory_id;
                drdstate.SelectedValue  = lblStateid;
                drddistrict.SelectedValue = LbldistID;
                txtBlock.Text= lblBlockName;

                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                btnsave.Visible = false;
                imgbtnupdate.Visible = true;
            }
            if (e.CommandName == "Delete")
            {
                string subcategory_id = ((Label)e.Item.FindControl("IblID")).Text;
                hfsubCategoryID.Value = subcategory_id;
                string save = tblsubcategory.DeleteBlock(hfsubCategoryID.Value);
                if (save != "false")
                {
                    Clear();
                    divfillgrid.Attributes["Style"] = "display:block";
                    divsavedata.Attributes["Style"] = "display:none";
                    divmsg1.Attributes["Style"] = "display:block";
                    lblmsg1.Text = "Delete Successfully...";
                    bind();
                }

            }
        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
        private void Clear()
        {
            txtBlock.Text = "";
            drddistrict.SelectedIndex=0;
            drdstate.SelectedIndex=0;
            hfsubCategoryID.Value = "";
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
            ClsBlockMasterML obj = new ClsBlockMasterML();
            obj.BlockName = txtBlock.Text.Trim();
            obj.State_ID=drdstate.SelectedValue;
            obj.DistrictID=drddistrict.SelectedValue;
            obj.DistrictName=drddistrict.SelectedItem.Text;
            obj.StateName=drdstate.SelectedItem.Text;
            obj.mode = flag;
            obj.ID = hfsubCategoryID.Value;
            obj.AddedBy = Convert.ToString(Session["LoginId"]);
            string save = tblsubcategory.Insertsubcategory(obj);
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

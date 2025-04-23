
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
    public partial class Districtmaster : System.Web.UI.Page
    {
        ClsDistrictMasterBL tblsubcategory = new ClsDistrictMasterBL();
        ClsStateMasterBL tblcategory = new ClsStateMasterBL();

        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                binddrd();

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
        private void binddrd()
        {
            DataTable dt = tblcategory.Getallcategory();
            if (dt.Rows.Count > 0)
            {

                drdcategoryname.DataSource = dt;
                drdcategoryname.DataTextField = "Name";
                drdcategoryname.DataValueField = "state_ID";
                drdcategoryname.DataBind();
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
                string subcategory_id = ((Label)e.Item.FindControl("lblsubcategory_id")).Text;
                string subcategoryname = ((Label)e.Item.FindControl("lblsubcategoryname")).Text;
                string category_id = ((Label)e.Item.FindControl("lblcategory_id")).Text;

                hfsubCategoryID.Value = subcategory_id;
                txtsubcategory.Text = subcategoryname;
                drdcategoryname.SelectedValue = category_id;

                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                btnsave.Visible = false;
                imgbtnupdate.Visible = true;
            }
            if (e.CommandName == "Delete")
            {
                string subcategory_id = ((Label)e.Item.FindControl("lblsubcategory_id")).Text;
                string subcategoryname = ((Label)e.Item.FindControl("lblsubcategoryname")).Text;
                string category_id = ((Label)e.Item.FindControl("lblcategory_id")).Text;

                hfsubCategoryID.Value = subcategory_id;
                txtsubcategory.Text = subcategoryname;
                drdcategoryname.SelectedValue = category_id;
                var a = tblsubcategory.Deletesubcategory(hfsubCategoryID.Value);
                Clear();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:block";
                lblmsg1.Text = "Delete Successfully";
                bind();
                //divfillgrid.Attributes["Style"] = "display:none";
                //divsavedata.Attributes["Style"] = "display:block";
                //divmsg1.Attributes["Style"] = "display:none";
                //divmsg2.Attributes["Style"] = "display:none";
                //btnsave.Visible = false;
                //imgbtnupdate.Visible = true;


            }
        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
        private void Clear()
        {
            txtsubcategory.Text = "";
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
            ClsDistrictMasterML obj = new ClsDistrictMasterML();
            obj.DistrictName = txtsubcategory.Text.Trim();
            obj.mode = flag;
            obj.Distict_ID = hfsubCategoryID.Value;
            obj.State_ID = drdcategoryname.SelectedValue;
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

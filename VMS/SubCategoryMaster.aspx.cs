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
    public partial class SubCategoryMaster : System.Web.UI.Page
    {
        ClsSubCategoryMasterBL tblsubcategory = new ClsSubCategoryMasterBL();
        ClsCategoryMasterBL tblcategory = new ClsCategoryMasterBL();
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
                drdcategoryname.DataTextField = "categoryname";
                drdcategoryname.DataValueField = "category_id";
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
            ClsSubCategoryMasterML obj = new ClsSubCategoryMasterML();
            obj.SubcategoryName = txtsubcategory.Text.Trim();
            obj.mode = flag;
            obj.SubCategory_ID = hfsubCategoryID.Value;
            obj.Category_ID = drdcategoryname.SelectedValue;
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

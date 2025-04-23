using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using ML;
using System.Data;

namespace vms
{
    public partial class Productmaster : System.Web.UI.Page
    {
        ClsProductMasterBL tblproductmaster = new ClsProductMasterBL();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldropdown();
                bind();
            }
        }
        private void filldropdown()
        {
            tblproductmaster.fill_brand_Drop(ref ddlbrand);
        }

        private void bind()
        {
            DataTable dt = tblproductmaster.GetallProduct();
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
        private void Fill(string prodid)
        {
            DataTable dt = tblproductmaster.GetSelectedProduct(prodid);
            if (dt.Rows.Count > 0)
            {
                txtdisplyorder.Text = dt.Rows[0]["DisplayOrder"].ToString();
                txtfulldesc.Text = dt.Rows[0]["FullDescription"].ToString();
                txtissuance.Text = dt.Rows[0]["Issuance"].ToString();
                txtprodcode.Text = dt.Rows[0]["ProductCode"].ToString();
                txtprodgroup.Text = dt.Rows[0]["ProductGroup"].ToString();
                txtprodname.Text = dt.Rows[0]["ProductName"].ToString();
                txtprodtype.Text = dt.Rows[0]["ProductType"].ToString();
                txtshortdesc.Text = dt.Rows[0]["ShortDescription"].ToString();
                txtunitprice.Text = dt.Rows[0]["UnitPrice"].ToString();
                txtvalidityperiod.Text = dt.Rows[0]["ValidityPeriod"].ToString();
                ddlbrand.SelectedValue = dt.Rows[0]["BrandID"].ToString();
                rdsgc.SelectedValue = dt.Rows[0]["SGC"].ToString();
                rdApprover.SelectedValue = dt.Rows[0]["approved"].ToString();
                rdSanName.SelectedValue = dt.Rows[0]["sanName"].ToString();
                rdCodeSigner.SelectedValue = dt.Rows[0]["CodeSigner"].ToString();
                txtsanname.Text = dt.Rows[0]["San_Name"].ToString();
                txtsanprice.Text = dt.Rows[0]["San_Price"].ToString();
                txtSite_Seal.Text = dt.Rows[0]["Site_Seal"].ToString();
                txtProduct_Specification.Text = dt.Rows[0]["Product_Specification"].ToString();
                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                btnsave.Visible = false;
                imgbtnupdate.Visible = true;

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
                hfid.Value = Rcode;
                Fill(Rcode);

            }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            flag = "I";
            insertproduct();
        }
        private void insertproduct()
        {
            ClsProductmasterML obj = new ClsProductmasterML();

            obj.Id = hfid.Value;
            obj.ProductCode = txtprodcode.Text;
            obj.ProductName = txtprodname.Text;
            obj.ShortDescription = txtshortdesc.Text;
            obj.FullDescription = txtfulldesc.Text;
            obj.DisplayOrder = txtdisplyorder.Text;
            obj.BrandID = ddlbrand.SelectedValue.ToString();
            obj.ProductBrand = ddlbrand.SelectedItem.Text;
            obj.ProductGroup = txtprodgroup.Text;
            obj.ProductType = txtprodtype.Text;
            obj.ValidityPeriod = txtvalidityperiod.Text;
            obj.UnitPrice = txtunitprice.Text;
            obj.SecondYearPrice = "2";
            obj.ThirdYearPrice = "3";
            obj.Issuance = txtissuance.Text;

            obj.San_Name = txtsanname.Text;
            if (txtsanprice.Text == "")
            {
                txtsanprice.Text = "0";
            }
            obj.San_Price = txtsanprice.Text;

            obj.SGC = rdsgc.SelectedValue;
            obj.Site_Seal = txtSite_Seal.Text;
            obj.mode = flag;
            obj.IsActive = "1";
            obj.AddedBy = Convert.ToString(Session["loginId"]);

            obj.approved = rdApprover.SelectedValue;
            obj.SanName = rdSanName.SelectedValue;
            obj.CodeSigner = rdCodeSigner.SelectedValue;
            obj.Product_Specification = txtProduct_Specification.Text;
            string save = tblproductmaster.InsertproductMaster(obj);
            if (save != "false")
            {
                Clear();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                lblmsg1.Text = " Saved Successfully...";
                bind();
            }

        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
        private void Clear()
        {
            ddlbrand.SelectedIndex = 0;
            txtdisplyorder.Text = "";
            txtfulldesc.Text = "";
            txtissuance.Text = "";
            txtprodcode.Text = "";
            txtprodgroup.Text = "";
            txtprodname.Text = "";
            txtprodtype.Text = "";
            txtshortdesc.Text = "";
            txtunitprice.Text = "";
            txtvalidityperiod.Text = "";
            txtsanname.Text = "";
            txtsanprice.Text = "0";
            txtSite_Seal.Text = "";
            txtProduct_Specification.Text = "";
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {

        }
        protected void imgbtnupdate_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
            flag = "M";
            insertproduct();
            // bind();
        }
    }
}
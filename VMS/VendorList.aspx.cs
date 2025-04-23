using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BL;
using System.IO;
using ML;
using DL;

namespace vms
{
    public partial class VendorList : System.Web.UI.Page
    {
        System.Globalization.CultureInfo dateFormat = new System.Globalization.CultureInfo("en-GB", true);
        ClsvendorsBL dal = new ClsvendorsBL();
        ClsvendorsML Obj = new ClsvendorsML();

        
        ClsCategoryMasterBL tblcategory = new ClsCategoryMasterBL();
        ClsSubCategoryMasterBL tblsubcategory = new ClsSubCategoryMasterBL();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                txtToDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                bind();
                bindCategoryProduct();
            }

           
        }
        private void bindCategoryProduct()
        {
            
            dtMenumaster.DataSource = tblcategory.Getallcategory();
            dtMenumaster.DataBind();
        }
            private void bind()
        {
            string searchcompany = txtCompanySearch.Text;
            string fromdate = txtFromDate.Text;
            string todate = txtToDate.Text;
            Obj.fdate = fromdate;
            Obj.tdate = todate;
            Obj.VendorName = searchcompany;
            DataTable dt = dal.getvendorsLIST(Obj);
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
        protected void btnproced_Click(object sender, EventArgs e)
        {
            flag = "I";
            hfid.Value = "";
            InsertVendors();


        }
        string list1(Repeater dtlist)
        {
            string menuId = "";
            string childmenuId = "";
            for (int i = 0; i < dtlist.Items.Count; i++)
            {
                CheckBox chkcategoryname = (CheckBox)dtlist.Items[i].FindControl("chkcategoryname");
                Label lblcategory_id = (Label)dtlist.Items[i].FindControl("lblcategory_id");
                CheckBoxList chksubcategory = (CheckBoxList)dtlist.Items[i].FindControl("chksubcategory");
                if (chkcategoryname.Checked == true)
                {
                    menuId += lblcategory_id.Text + ",";

                    for (int j = 0; j < chksubcategory.Items.Count; j++)
                    {
                        if (chksubcategory.Items[j].Selected)
                        {
                            childmenuId += chksubcategory.Items[j].Value + ",";
                        }

                    }
                }
            }
            return menuId + "^" + childmenuId;

        }
        private void InsertVendors()
        {

            Obj.Vendor_Id = hfid.Value;

            Obj.VendorName = txtVendorName.Text;
            Obj.MobileNo = txtmobilno.Text;
            Obj.Email = txtEmail.Text;

            Obj.PanNo = txtPanNo.Text;

            Obj.ContactPersonName = txtContactPersonName.Text;
            Obj.GSTRegistrationNo = txtGSTRegistrationNo.Text;

            Obj.mode = flag;

            Obj.CREATED_BY = Session["loginId"].ToString();
            Obj.UPDATED_BY = Session["loginId"].ToString();


            string Vendor_Id = dal.Insertvendors(Obj);
            string createdby = Convert.ToString(Session["loginId"]);

            string menulist = list1(dtMenumaster);
            if (menulist != "")
            {
                string[] mainmenu = menulist.Split('^');

                string menulist1 = mainmenu[0].Substring(0, mainmenu[0].Length - 1);
                string[] menulist2 = menulist1.Split(',');

                if (mainmenu[1].ToString() != "")
                {
                    string childmenulist1 = mainmenu[1].Substring(0, mainmenu[1].Length - 1);
                    string[] childmenulist2 = childmenulist1.Split(',');
                    int childemenulength = childmenulist2.Length;
                    clsvendorcategorylist[] objrmenurelChild = new clsvendorcategorylist[childemenulength];
                    for (int i = 0; i < childemenulength; i++)
                    {
                        string mode = "D";
                        if (i == 0)
                        {
                            mode = "H";
                        }
                        objrmenurelChild[i] = new clsvendorcategorylist();
                        objrmenurelChild[i].categoryid = childmenulist2[i].ToString();
                        objrmenurelChild[i].mode = mode;
                    }
                    dal.insertvendorsubcategoryrelation(objrmenurelChild, Vendor_Id, createdby);
                }

                int menulength = menulist2.Length;
                clsvendorcategorylist[] objrmenurel = new clsvendorcategorylist[menulength];
                for (int i = 0; i < menulength; i++)
                {
                    string mode = "D";
                    if (i == 0)
                    {
                        mode = "H";
                    }
                    objrmenurel[i] = new clsvendorcategorylist();
                    objrmenurel[i].categoryid = menulist2[i].ToString();
                    objrmenurel[i].mode = mode;
                }
                dal.insertvendorcategoryrelation(objrmenurel, Vendor_Id, createdby);
            }


                   
                    if (Vendor_Id != "false")
                    {

                        Clear();
                        divfillgrid.Attributes["Style"] = "display:block";
                        divsavedata.Attributes["Style"] = "display:none";
                        lblmsg1.Text = " Saved Successfully...";
                        bind();
                bindCategoryProduct();
                    }
                }
        protected void btnAddrole_Click(object sender, EventArgs e)
        {
            btnproced.Visible = true;
            imgbtnupdate.Visible = false;
            Clear();
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
        }

        private void Clear()
        {
           
            txtVendorName.Text = "";
            txtmobilno.Text = "";
            txtEmail.Text = "";
            txtPanNo.Text = "";
            txtContactPersonName.Text = "";
            txtGSTRegistrationNo.Text = "";
                   

        }

        protected void imgbtnVbatch_Click(object sender, EventArgs e)
        {

            btnproced.Visible = false;
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

                string vendor_id = ((Label)e.Item.FindControl("lblvendor_Id")).Text;
                hfid.Value = vendor_id;
                fill(hfid.Value);

                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
            }
            if (e.CommandName == "Delete")
            {

                string str = "";
                if (str != "false")
                {
                    divmsg1.Attributes["Style"] = "display:block";
                    divmsg2.Attributes["Style"] = "display:none";
                    divfillgrid.Attributes["Style"] = "display:block";
                    divsavedata.Attributes["Style"] = "display:none";
                    lblmsg1.Text = "Client OWner Code deleted Successfully...";
                    bind();
                }
                else
                {
                    divmsg1.Attributes["Style"] = "display:none";
                    divmsg2.Attributes["Style"] = "display:block";
                    divfillgrid.Attributes["Style"] = "display:block";
                    divsavedata.Attributes["Style"] = "display:none";
                    lblmsg2.Text = "Client OWner Code not Deleted.";

                }
            }
        }

        private void fill(string vendor_id)
        {
            btnproced.Visible = false;
            imgbtnupdate.Visible = true;
            DataTable dt = BaseCommon.GetDataSet("prc_GETGetvendorsIDWISE'" + vendor_id + "' ", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                hfid.Value = dt.Rows[0]["vendor_Id"].ToString();
                txtVendorName.Text = dt.Rows[0]["VendorName"].ToString();
              
                txtmobilno.Text = dt.Rows[0]["MobileNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                txtContactPersonName.Text = dt.Rows[0]["ContactPersonName"].ToString();
                txtGSTRegistrationNo.Text = dt.Rows[0]["GSTRegistrationNo"].ToString();

                bindCategoryProduct();
                



            }
        }
        protected void dtMenumaster_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string vendorid = hfid.Value;
                Label lblcategory_id = (Label)e.Item.FindControl("lblcategory_id");
                DataTable dt = tblsubcategory.Getallsubcategory(lblcategory_id.Text);
                CheckBoxList chksubcategory = (CheckBoxList)e.Item.FindControl("chksubcategory");
                fillchecklist(chksubcategory, dt, "subcategoryname", "subcategory_id");
                CheckBox chkcategoryname = (CheckBox)e.Item.FindControl("chkcategoryname");


                DataSet dsselectedCategory = dal.getvendorselectedCategory(lblcategory_id.Text, vendorid);
                if (dsselectedCategory.Tables.Count > 0 && dsselectedCategory.Tables[0].Rows.Count > 0)
                {
                    chkcategoryname.Checked = true;
                }
                else
                {
                    chkcategoryname.Checked = false;
                }
                chksubcategory.Enabled = chkcategoryname.Checked;
                for (int i = 0; i < chksubcategory.Items.Count; i++)
                {
                    string subcategoryid = chksubcategory.Items[i].Value;
                    DataSet dsRollselectedChildMenu = dal.getvendorselectedSubCategory(subcategoryid, vendorid);
                    if (dsRollselectedChildMenu.Tables.Count > 0 && dsRollselectedChildMenu.Tables[0].Rows.Count > 0)
                    {
                        chksubcategory.Items[i].Selected = true;
                    }
                    else
                    {
                        chksubcategory.Items[i].Selected = false;
                    }
                }
            }
        }

        void fillchecklist(CheckBoxList drd, DataTable dt, string textField, string valueField)
        {
            drd.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                drd.DataSource = dt;
                drd.DataTextField = textField;
                drd.DataValueField = valueField;
                drd.DataBind();
            }
            else
            {
                drd.DataSource = null;
                drd.DataBind();
            }


        }

     

        protected void imgbtnReset_Click(object sender, EventArgs e)
        {
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
            Clear();
        }


        protected void imgbtnupdate_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
            flag = "M";
            InsertVendors();
            // bind();
        }

        protected void btnrest_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();

        }
        protected void btnexport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=VendorList_" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            rptRole.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();



        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void chkcategoryname_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chkcategoryname = (CheckBox)sender;
            RepeaterItem Row = (RepeaterItem)chkcategoryname.NamingContainer;
            CheckBoxList chksubcategory = (CheckBoxList)Row.FindControl("chksubcategory");
            chksubcategory.Enabled = chkcategoryname.Checked;
            if (chkcategoryname.Checked == false)
            { chksubcategory.ClearSelection(); }
        }


    }
}
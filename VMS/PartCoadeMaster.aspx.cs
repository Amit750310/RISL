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
    public partial class PartCoadeMaster : System.Web.UI.Page
    {
        ClsDevicePartCodeMappingBL tblcategory = new ClsDevicePartCodeMappingBL();

        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldropdown();
                bind();
            }
        }

        void filldropdown()
        {
            DataTable dt = tblcategory.Dropdownlist();
            if (dt.Rows.Count > 0)
            {

                drdDevice.DataSource = dt;
                drdDevice.DataTextField = "Name";
                drdDevice.DataValueField = "Name";
                drdDevice.DataBind();
            }

        }
        private void bind()
        {
            DataTable dt = tblcategory.Getallcategory();
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
                string Rcode = ((Label)e.Item.FindControl("lblID")).Text;
                //string name = ((Label)e.Item.FindControl("lblName")).Text;
                //DropDownList dropDownList = ((DropDownList)e.Item.FindControl("drdDevocetype"));
                DataTable dt = new DataTable();
                dt = tblcategory.GetSingle(Rcode);
                if (dt.Rows.Count > 0)
                {
                    hfcategory_ID.Value = dt.Rows[0]["ID"].ToString();
                    txtcategory.Text = dt.Rows[0]["PartCode"].ToString();
                    drdDevice.SelectedItem.Text= dt.Rows[0]["DName"].ToString();

                    divmsg1.Attributes["Style"] = "display:none";
                    divmsg2.Attributes["Style"] = "display:none";
                    divfillgrid.Attributes["Style"] = "display:none";
                    divsavedata.Attributes["Style"] = "display:block";
                    btnsave.Visible = false;
                    imgbtnupdate.Visible = true;
                }
                else
                {

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
        }
       
        private void Clear()
        {
            txtcategory.Text = "";
            hfcategory_ID.Value = "";
            drdDevice.SelectedIndex=0;

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
            bind();
        }

        private void InsertEmployee()
        {
            ClsDevicePartCodeMappingML obj = new ClsDevicePartCodeMappingML();
            obj.Name = drdDevice.SelectedItem.Text;
            obj.PartCode = txtcategory.Text.Trim();
            obj.mode = flag;
            obj.ID = hfcategory_ID.Value;
            obj.AddedBy = Convert.ToString(Session["LoginId"]);
            string save = tblcategory.Insertcategory(obj);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Data;
using ML;
using System.Web.Services;

namespace vms
{
    public partial class StatusMaster : System.Web.UI.Page
    {
        ClsStatusMasterBL tblcategory = new ClsStatusMasterBL();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        public void bind()
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

                string Rcode = ((Label)e.Item.FindControl("lblcategory_id")).Text;
                string name = ((Label)e.Item.FindControl("lblcategoryname")).Text;

                hfcategory_ID.Value = Rcode;
                txtcategory.Text = name;

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
            txtcategory.Text = "";
            hfcategory_ID.Value = "";
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
            ClsStatusMasterML obj = new ClsStatusMasterML();
            obj.Name = txtcategory.Text.Trim();
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



        //    [WebMethod]
        //    public static bool SaveServiceItems(List<ServiceItem> serviceItems,string deptNAme,string OICNAme,string TO,string Subject,string Ref,string Fileno)
        //    {
        //        FirstModel firstModel= new FirstModel();
        //        firstModel.deptNAme=deptNAme;
        //        firstModel.OICNAme = OICNAme;
        //        firstModel.TO = TO;
        //        firstModel.Subject = Subject;
        //        firstModel.Ref = Ref;
        //        firstModel.Fileno = Fileno;
        //        ClsStatusMasterBL tblcategory = new ClsStatusMasterBL();
        //        var ID = tblcategory.InsertOrderDeatils(firstModel);
        //        ServiceItem serviceItem = new ServiceItem();
        //        serviceItem.Oid= ID;
        //        try
        //        {
        //                foreach (var item in serviceItems)
        //                {
        //                serviceItem.ServiceType= item.ServiceType;
        //                serviceItem.Description = item.Description;
        //                serviceItem.Unit = item.Unit;
        //                serviceItem.UnitCost = item.UnitCost;
        //                serviceItem.TotalAmount = item.TotalAmount;
        //                var FinalInsert = tblcategory.InsertOrderDeatils1(serviceItem);
        //            }
        //            return true;
        //        }
        //        catch (Exception eX)
        //        {
        //            return false;
        //        }
        //    }
        //}

    }

}


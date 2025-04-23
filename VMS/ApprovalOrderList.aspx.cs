
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
    public partial class ApprovalOrderList : System.Web.UI.Page
    {
        ApprovalOrderListBL tblcategory = new ApprovalOrderListBL();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void btnAddrole_Click(object sender, EventArgs e)
        {
            Hidesection();
            div1.Visible = true;
            div2.Visible = true;
            div3.Visible = true;
        }
        protected void imgbtnVbatch_Click(object sender, EventArgs e)
        {
            Hidesection();
            divfillgrid.Visible = true;
            btnAddrole.Visible = true;
            bind();
        }


        public void bind()
        {
            Hidesection();
            DataTable dt = tblcategory.Getallcategory();
            if (dt.Rows.Count > 0)
            {
                rptBind.DataSource = dt;
                rptBind.DataBind();
                divfillgrid.Visible=true;
            }
            else
            {

                rptBind.DataSource = null;
                rptBind.DataBind();
                //divfillgrid.Attributes["Style"] = "display:block";
                //divsavedata.Attributes["Style"] = "display:none";
                //divmsg1.Attributes["Style"] = "display:none";
                //divmsg2.Attributes["Style"] = "display:block";
                //lblmsg2.Text = "No records found.";
            }
        }
        //protected void btnAddrole_Click(object sender, EventArgs e)
        //{
        //    btnsave.Visible = true;
        //    imgbtnupdate.Visible = false;
        //    Clear();
        //    divmsg1.Attributes["Style"] = "display:none";
        //    divmsg2.Attributes["Style"] = "display:none";
        //    divfillgrid.Attributes["Style"] = "display:none";
        //    divsavedata.Attributes["Style"] = "display:block";
        //}

        //protected void imgbtnVbatch_Click(object sender, EventArgs e)
        //{

        //    btnsave.Visible = false;
        //    imgbtnupdate.Visible = false;
        //    Clear();
        //    divmsg1.Attributes["Style"] = "display:none";
        //    divmsg2.Attributes["Style"] = "display:none";
        //    divfillgrid.Attributes["Style"] = "display:block";
        //    divsavedata.Attributes["Style"] = "display:none";
        //    bind();

        //}

        protected void rptBind_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Hidesection();
            if (e.CommandName == "Edit")
            {
                string Rcode = ((Label)e.Item.FindControl("lblcategory_id")).Text;
                hfcategory_ID.Value = Rcode;
                DataSet ds = tblcategory.GetallItemdetails(hfcategory_ID.Value);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                    divfillgrid.Visible=true;
                    ShowDetails.Visible=true;
                    imgbtnVrole.Visible=true;
                }
                else
                {
                    bind();
                }
                 
            }

        }
        //public void mymsg(string msg)
        //{
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        //}
        //private void Clear()
        //{
        //    txtcategory.Text = "";
        //    hfcategory_ID.Value = "";
        //}
        //protected void btnsave_Click(object sender, EventArgs e)
        //{

        //    flag = "I";
        //    InsertEmployee();

        //}

        //protected void imgbtnupdate_Click(object sender, EventArgs e)
        //{
        //    divfillgrid.Attributes["Style"] = "display:none";
        //    divsavedata.Attributes["Style"] = "display:block";
        //    flag = "M";
        //    InsertEmployee();
        //    // bind();
        //}

        //private void InsertEmployee()
        //{
        //    ClsStatusMasterML obj = new ClsStatusMasterML();
        //    obj.Name = txtcategory.Text.Trim();
        //    obj.mode = flag;
        //    obj.ID = hfcategory_ID.Value;
        //    obj.AddedBy = Convert.ToString(Session["LoginId"]);
        //    string save = tblcategory.Insertcategory(obj);
        //    if (save != "false")
        //    {
        //        Clear();
        //        divfillgrid.Attributes["Style"] = "display:block";
        //        divsavedata.Attributes["Style"] = "display:none";
        //        lblmsg1.Text = " Saved Successfully...";
        //        bind();
        //    }
        //}


        public void Hidesection()
        {
            div1.Visible = false;
            div3.Visible = false;
            div2.Visible = false;
            divfillgrid.Visible = false;
            btnAddrole.Visible = false;
            imgbtnVrole.Visible = false;
            ShowDetails.Visible=false;
        }

       

        protected void BtnAddStatus_Click(object sender, EventArgs e)
        {
            //objml.Department_id = drdDepartment_Name.SelectedValue;
            //objml.ApprovedStatus = drdApprovedStatus.SelectedValue;
            //objml.ApprovedRemarks = txtApprovedRemarks.Text;
            //objml.ID = hfid.Value;
            //objml.UPDATED_BY = Convert.ToString(Session["csfr"]);


            //string save = objbl.UpdateAudit_Internal_PlaningApprovedStatus(objml);
            //if (save != "false")
            //{

            //    //Clear();
            //    //divfillgrid.Attributes["Style"] = "display:block";
            //    //divsavedata.Attributes["Style"] = "display:none";
            //    //divShowData.Attributes["Style"] = "display:none";
            //    //DivMainContent3.Attributes["Style"] = "display:none";
            //    //lblmsg1.Text = " Updated Successfully...";
            //    bind();
            //}
            bind();
        }

        protected void BtnCancelStatus_Click(object sender, EventArgs e)
        {
            Hidesection();
            bind();

        }
    }


}








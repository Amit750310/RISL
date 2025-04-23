
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DL;
using ML;
using System.Data;

namespace vms
{
    public partial class Location_Master : System.Web.UI.Page
    {
        ClsLocationmasterBL dal = new ClsLocationmasterBL();
        ClsLocationmasterML Obj = new ClsLocationmasterML();
        ClsBlockMasterBL blockBl= new ClsBlockMasterBL();
        string flag;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginId"] != null)
                {
                    fillRoll();
                }
                else
                {
                    Response.Redirect("index.aspx", false);
                }

                bind();

                //filllevel();
                filldropdown();

            }
        }
        
        void filldropdown()
        {
            dal.fill_Internal_State(DrdState);
        }

        protected void DrdState_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Internal_AuditUnit();
        }
      
        void fill_Internal_AuditUnit()
        {
            string Department_Id = DrdState.SelectedValue;
            dal.fill_Internal_district(ref DrdDistict, Department_Id);
        }
        protected void DrdDistict_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Internal_AuditUnit1();
        }
        void fill_Internal_AuditUnit1()
        {
            string Department_Id = DrdState.SelectedValue;
            string distict = DrdDistict.SelectedValue;
            dal.fill_Internal_Block(ref drdblock, Department_Id, distict);
        }

        void filllevel()
        {

            //DataSet ds = dal.fillgetallLevel();

            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    ddlhilevel.DataSource = ds.Tables[0];
            //    ddlhilevel.DataTextField = "hiLevel";
            //    ddlhilevel.DataValueField = "level_ID";
            //    ddlhilevel.DataBind();

            //}
        }
        void fillRoll()
        {
            //DataSet ds = objBl.GetRoll();

            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    drdrollname1.DataSource = ds.Tables[0];
            //    drdrollname1.DataTextField = "rollName";
            //    drdrollname1.DataValueField = "rollID";
            //    drdrollname1.DataBind();

            //}



        }
        protected void btnproced_Click(object sender, EventArgs e)
        {
            flag = "I";
            InsertEmployee();


        }

        private void InsertEmployee()
        {
            Obj.ID = hfid.Value;
            //Obj.Location_Name = txtLocation_Name.Text;
            Obj.Address = txtAddress.Text;
            //Obj.Address1 = txtAddress1.Text;
            Obj.District = DrdDistict.SelectedValue;
            Obj.State = DrdState.SelectedValue;
            Obj.City = txtcITY.Text;
            //Obj.Ucode=TxtUcode.Text;
            Obj.PINCode = txtPINCode.Text;
            Obj.Department = txtDepartment.Text;
            Obj.Display_Name = txtDisplay.Text;
            Obj.mode = flag;
            Obj.AddedBy = Session["loginId"].ToString();
            Obj.ModifiedBy = Session["loginId"].ToString();
            string save = dal.InsertEmployee(Obj);
            if (save != "false")
            {
                Clear();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                lblmsg1.Text = " Saved Successfully...";
                bind();
            }

        }

        private void bind()
        {
            DataTable dt = dal.fillgetallLevel();
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
            //txtAddress.Text = "";
            //txtAddress1.Text = "";
            txtDepartment.Text = "";
            txtPINCode.Text = "";
            txtDisplay.Text="";
            //txtContact_Person.Text = "";
            //txtLocation_Name.Text = "";
            //DrdDistict.SelectedIndex = 0;
            DrdState.SelectedIndex = 0;
            drdblock.SelectedIndex=0;
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
                string Rcode = ((Label)e.Item.FindControl("lblID")).Text;
                hfid.Value = Rcode;
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

        private void fill(string Rcode)
        {
            btnproced.Visible = false;
            imgbtnupdate.Visible = true;
            DataTable dt = BaseCommon.GetDataSet("GetAllLocation'" + Rcode + "' ", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                hfid.Value = dt.Rows[0]["Id"].ToString();
                //txtLocation_Name.Text = dt.Rows[0]["Location_Name"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                //txtAddress1.Text = dt.Rows[0]["Address1"].ToString();
                txtcITY.Text = dt.Rows[0]["City"].ToString();
                txtPINCode.Text = dt.Rows[0]["PINCode"].ToString();
                txtDepartment.Text = dt.Rows[0]["Department"].ToString();
                txtDisplay.Text = dt.Rows[0]["Display_Name"].ToString();

                //TxtUcode.Text = dt.Rows[0]["UCode"].ToString();

                try
                {
                    DrdState.SelectedValue = Convert.ToString(dt.Rows[0]["State"]);
                    fill_Internal_AuditUnit();
                    DrdDistict.SelectedValue= Convert.ToString(dt.Rows[0]["District"]);
                    fill_Internal_AuditUnit1();
                    drdblock.SelectedValue = Convert.ToString(dt.Rows[0]["Block"]);

                }
                catch (Exception ex)
                {


                }
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
            InsertEmployee();
            // bind();
        }

        protected void btnrest_Click(object sender, EventArgs e)
        {
            Clear();
        }

       
    }
}
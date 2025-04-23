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
    public partial class Employeemaster : System.Web.UI.Page
    {
        ClsemployeemasterBL dal = new ClsemployeemasterBL();
        ClsEmployemasterML Obj = new ClsEmployemasterML();
        string flag;
        clsRollMenuRelationBL objBl = new clsRollMenuRelationBL();
        clsMenuMasterML objML = new clsMenuMasterML();
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
                filllevel();
                

            }
        }

        void filllevel()
        {
            
            DataSet ds = dal.fillgetallLevel();
            
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlhilevel.DataSource = ds.Tables[0];
                ddlhilevel.DataTextField = "hiLevel";
                ddlhilevel.DataValueField = "level_ID";
                ddlhilevel.DataBind();

            }
        }
        void fillRoll()
        {
            DataSet ds = objBl.GetRoll();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                drdrollname1.DataSource = ds.Tables[0];
                drdrollname1.DataTextField = "rollName";
                drdrollname1.DataValueField = "rollID";
                drdrollname1.DataBind();

            }

            

        }
        protected void btnproced_Click(object sender, EventArgs e)
        {
            flag = "I";
            InsertEmployee();
        }
               
        private void InsertEmployee()
        {

            Obj.ID = hfid.Value;
            Obj.EMP_CODE = txtempcode.Text;
            Obj.First_Name = txtfirstname.Text;
            Obj.Last_Name = txtlastname.Text;
            Obj.MAILID = txtmailid.Text;
            Obj.PASSWORD = txtpassword.Text;
            Obj.MOBILE_NO = txtmobilno.Text;
            Obj.Designation = txtDesignation.Text;
            Obj.DOB = txtdob.Text;
            Obj.DOJ = txtdoj.Text;
            Obj.Gender = ddlgender.SelectedValue;
            Obj.Address = txtaddress.Text;
            Obj.mode = flag;
            Obj.role_Id = drdrollname1.SelectedValue;
            
            Obj.HiLevel = ddlhilevel.SelectedValue.ToString();
            Obj.CREATED_BY = Session["loginId"].ToString();
            Obj.UPDATED_BY = Session["loginId"].ToString();
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

            DataTable dt = BaseCommon.GetDataSet("prc_GetEMPLOYEELIST ", CommandType.Text).Tables[0];
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
            txtaddress.Text = "";
            txtDesignation.Text = "";
            txtdob.Text = "";
            txtdoj.Text = "";
            txtempcode.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtmailid.Text = "";
            txtmobilno.Text = "";
            txtpassword.Text = "";
            
            ddlhilevel.SelectedIndex = 0;

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

                string Rcode = ((Label)e.Item.FindControl("lblRolecode")).Text;
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
            DataTable dt = BaseCommon.GetDataSet("prc_GETEMPLOYEEIDWISE'" + Rcode + "' ", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                hfid.Value = dt.Rows[0]["emp_Id"].ToString();
                txtfirstname.Text = dt.Rows[0]["First_Name"].ToString();
                txtlastname.Text = dt.Rows[0]["Last_Name"].ToString();
                txtmobilno.Text = dt.Rows[0]["mobile"].ToString();
                txtaddress.Text = dt.Rows[0]["Address"].ToString();
                txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                txtdob.Text = dt.Rows[0]["DOB"].ToString();
                txtdoj.Text = dt.Rows[0]["DOJ"].ToString();
                txtempcode.Text = dt.Rows[0]["Employee_code"].ToString();
                txtmailid.Text = dt.Rows[0]["Email_Id"].ToString();
              
                try
                {
                    drdrollname1.SelectedValue = Convert.ToString(dt.Rows[0]["role_Id"]);
                    ddlhilevel.SelectedValue = Convert.ToString(dt.Rows[0]["HiLevel"]);
                    ddlgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                }
                catch (Exception ex)
                {

                  
                }
              
                string password = dt.Rows[0]["Password"].ToString();

                BaseCommon common = new BaseCommon();
                string PASSWORD = common.Base64Decode(password);
                txtpassword.Attributes.Add("value", PASSWORD);
                

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
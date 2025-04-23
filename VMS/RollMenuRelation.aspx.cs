using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using ML;

namespace vms
{
    public partial class RollMenuRelation : System.Web.UI.Page
    {
        //clsEmployeeMasterBl objEmpBl = new clsEmployeeMasterBl();
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
            dtMenumaster.DataSource = objBl.fillmenu();
            dtMenumaster.DataBind();
        }
        void fillchecklist(CheckBoxList drd, DataSet ds, string textField, string valueField)
        {
            drd.Items.Clear();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                drd.DataSource = ds;
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

        string checkuncheck(CheckBox Chkbox)
        {
            string chk = "N";
            if (Chkbox.Checked == true)
            {
                chk = "Y";
            }
            return chk;
        }
        protected void dtMenumaster_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string rollid = drdrollname1.SelectedValue;
                Label lblMenuId = (Label)e.Item.FindControl("lblMenuId");
                DataSet ds = objBl.getchildeMenu(lblMenuId.Text);
                CheckBoxList chkchildemenulist = (CheckBoxList)e.Item.FindControl("chkchildemenulist");
                fillchecklist(chkchildemenulist, ds, "childeMenuName", "id");
                CheckBox chkMenu = (CheckBox)e.Item.FindControl("chkMenu");
                DataSet dsRollselectedMenu = objBl.getrollSelectedMenu(lblMenuId.Text, rollid);
                if (dsRollselectedMenu.Tables.Count > 0 && dsRollselectedMenu.Tables[0].Rows.Count > 0)
                {
                    chkMenu.Checked = true;
                }
                else
                {
                    chkMenu.Checked = false;
                }
                for (int i = 0; i < chkchildemenulist.Items.Count; i++)
                {
                    string chldemenuid = chkchildemenulist.Items[i].Value;
                    DataSet dsRollselectedChildMenu = objBl.getRollselectedChildMenu(chldemenuid, rollid);
                    if (dsRollselectedChildMenu.Tables.Count > 0 && dsRollselectedChildMenu.Tables[0].Rows.Count > 0)
                    {
                        chkchildemenulist.Items[i].Selected = true;
                    }
                    else
                    {
                        chkchildemenulist.Items[i].Selected = false;
                    }
                }
            }
        }
        string list1(Repeater dtlist)
        {
            string menuId = "";
            string childmenuId = "";
            for (int i = 0; i < dtlist.Items.Count; i++)
            {
                CheckBox chkMenu = (CheckBox)dtlist.Items[i].FindControl("chkMenu");
                Label lblMenuId = (Label)dtlist.Items[i].FindControl("lblMenuId");
                CheckBoxList chkchildemenulist = (CheckBoxList)dtlist.Items[i].FindControl("chkchildemenulist");
                if (chkMenu.Checked == true)
                {
                    menuId += lblMenuId.Text + ",";

                    for (int j = 0; j < chkchildemenulist.Items.Count; j++)
                    {
                        if (chkchildemenulist.Items[j].Selected)
                        {
                            childmenuId += chkchildemenulist.Items[j].Value + ",";
                        }

                    }
                }
            }
            return menuId + "^" + childmenuId;

        }
        protected void btnproced_Click(object sender, EventArgs e)
        {
            string createdby = Convert.ToString(Session["loginId"]);
            string rollid = drdrollname1.SelectedValue;
            //Inser menu

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
                    clsmenulist[] objrmenurelChild = new clsmenulist[childemenulength];
                    for (int i = 0; i < childemenulength; i++)
                    {
                        string mode = "D";
                        if (i == 0)
                        {
                            mode = "H";
                        }
                        objrmenurelChild[i] = new clsmenulist();
                        objrmenurelChild[i].menuid = childmenulist2[i].ToString();
                        objrmenurelChild[i].mode = mode;
                    }

                    objBl.insertusermenurelChild(objrmenurelChild, rollid, createdby);

                }
                int menulength = menulist2.Length;
                clsmenulist[] objrmenurel = new clsmenulist[menulength];
                for (int i = 0; i < menulength; i++)
                {
                    string mode = "D";
                    if (i == 0)
                    {
                        mode = "H";
                    }
                    objrmenurel[i] = new clsmenulist();
                    objrmenurel[i].menuid = menulist2[i].ToString();
                    objrmenurel[i].mode = mode;
                }
                objBl.insertusermenurel(objrmenurel, rollid, createdby);
                divmsg1.Style.Add("display", "block");
                lblmsg1.Text = "  Saved Successfully...";
            }
        }

        protected void drdrollname1_SelectedIndexChanged(object sender, EventArgs e)
        {
            divmsg1.Style.Add("display", "none");
            lblmsg1.Text = "";
            dtMenumaster.DataSource = objBl.fillmenu();
            dtMenumaster.DataBind();
        }
    }
}
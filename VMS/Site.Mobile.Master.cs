using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace vms
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        clsMenuMasterBL objbl = new clsMenuMasterBL();
        clsLeftsideML objml = new clsLeftsideML();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["username"]) == "")
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                lblname.Text = Convert.ToString(Session["username"]);
                bindmenu();
            }
        }
        void bindmenu()
        {

            objbl = new BL.clsMenuMasterBL();
            objml = new ML.clsLeftsideML();
            objml.loginEmpId = Convert.ToString(Session["loginId"]);
            DataSet dsmainmenu = objbl.getleftMenu(objml);
            rptMenu.DataSource = dsmainmenu;
            rptMenu.DataBind();
        }

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblMenuId = (Label)e.Item.FindControl("lblMenuId");
                Repeater rptSubMenu = (Repeater)e.Item.FindControl("rptSubMenu");
                objbl = new BL.clsMenuMasterBL();
                ML.clsLeftsidechiledmenuML objchildmenuML = new ML.clsLeftsidechiledmenuML();
                objchildmenuML.menuId = lblMenuId.Text; ;
                objchildmenuML.loginEmpId = Convert.ToString(Session["loginId"]);
                DataSet dschildmenu = objbl.getleftchildeMenu(objchildmenuML);
                rptSubMenu.DataSource = dschildmenu;
                rptSubMenu.DataBind();

            }
        }
    }
}
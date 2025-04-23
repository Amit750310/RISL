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
    public partial class hierarchyLevel : System.Web.UI.Page
    {
        ClshierarchyLevelBL tblhierarchy = new ClshierarchyLevelBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        void getempwithLevel()
        {
            DataTable dt = tblhierarchy.getempwithLevel();
            Session["hierarchy"] = dt;
        }

        private void Bind()
        {
          getempwithLevel(); 
            DataTable dt = (DataTable)Session["hierarchy"];
            rptdisptch.DataSource = dt;
            rptdisptch.DataBind();
        }

        protected void rptdisptch_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Label lblemp_Id = (Label)e.Item.FindControl("lblemp_Id");
                    CheckBoxList chkemplist= (CheckBoxList)e.Item.FindControl("chkemplist");
                    if (Session["hierarchy"] == null)
                    { getempwithLevel(); }
                    DataTable dt = (DataTable)Session["hierarchy"];
                    chkemplist.DataSource = dt;
                    chkemplist.DataTextField = "name";
                    chkemplist.DataValueField = "emp_Id";
                    chkemplist.DataBind();
                    ClshierarchyLevelML prp = new ClshierarchyLevelML();
                    prp.Emp_Id = lblemp_Id.Text;
                    DataTable dtLevelRights = tblhierarchy.getempwithLevelRights(prp);
                    if (dtLevelRights != null && dtLevelRights.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtLevelRights.Rows.Count; i++)
                        {
                            string empid = Convert.ToString(dtLevelRights.Rows[i]["childemp_id"]);
                            for (int j = 0; j < chkemplist.Items.Count; j++)
                            {
                                string drdempid = Convert.ToString(chkemplist.Items[j].Value);
                                if (empid == drdempid)
                                {
                                    chkemplist.Items[j].Selected = true;
                                }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                  
                    DL.BaseCommon objerr = new DL.BaseCommon();
                    objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                   
                }
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string empcode = Convert.ToString(Session["loginId"]);
                tblhierarchy.delete_hilevelRights();

                for (int i = 0; i < rptdisptch.Items.Count; i++)
                {
                    try
                    {
                        string Emp_Id = ((Label)rptdisptch.Items[i].FindControl("lblemp_Id")).Text;
                        CheckBoxList chkemplist = ((CheckBoxList)rptdisptch.Items[i].FindControl("chkemplist"));
                        int selectedCount = chkemplist.Items.Cast<ListItem>().Count(li => li.Selected);
                        ClshierarchyLevelML[] objhilevelml = new ClshierarchyLevelML[selectedCount];
                        int k = 0;
                        for (int j = 0; j < chkemplist.Items.Count; j++)
                        {
                            if (chkemplist.Items[j].Selected)
                            {
                                objhilevelml[k] = new ClshierarchyLevelML();
                                objhilevelml[k].AddedBy = empcode;
                                objhilevelml[k].Emp_Id = Emp_Id;
                                objhilevelml[k].childemp_id = chkemplist.Items[j].Value;
                                k++;
                            }
                        }
                        tblhierarchy.insert_tblhilevelRights(objhilevelml);
                    }
                    catch (Exception ex)
                    {
                        DL.BaseCommon objerr = new DL.BaseCommon();
                        objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                    }
                }
                mymsg("Hierarchy Level Updated ");
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
        }
        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
    }
}
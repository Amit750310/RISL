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
    public partial class VendorSearchProductList : System.Web.UI.Page
    {
        System.Globalization.CultureInfo dateFormat = new System.Globalization.CultureInfo("en-GB", true);
        ClsvendorsSearchProductBL dal = new ClsvendorsSearchProductBL();
        ClsvendorsSearchProductML Obj = new ClsvendorsSearchProductML();

        
       
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                txtToDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                bind();
                
            }

           
        }
      
            private void bind()
        {
          
            string fromdate = txtFromDate.Text;
            string todate = txtToDate.Text;
            Obj.fdate = fromdate;
            Obj.tdate = todate;
          
            DataTable dt = dal.GetvendorsProductSearchLIST(Obj);
            if (dt.Rows.Count > 0)
            {

                rptRole.DataSource = dt;
                rptRole.DataBind();


            }
            else
            {

                rptRole.DataSource = null;
                rptRole.DataBind();
             
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();

        }





        protected void rptRole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
            
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

       

    }
}
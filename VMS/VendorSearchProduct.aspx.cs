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
    public partial class VendorSearchProduct : System.Web.UI.Page
    {
        System.Globalization.CultureInfo dateFormat = new System.Globalization.CultureInfo("en-GB", true);
        ClsSearchvendorProductBL dal = new ClsSearchvendorProductBL();
        ClsSearchVendorProductML Obj = new ClsSearchVendorProductML();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                bind();
                
            }

           
        }
       private void bind()
        {
            string searchProduct = txtsearchProduct.Text;
            DataTable dt = dal.getSearchProductLIST(searchProduct);
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

            InsertProductSearchVendors();


        }
      
        private void InsertProductSearchVendors()
        {

            Obj.FromEmailId = txtFrom.Text;
            Obj.ToEmailids=txtTo.Text;
            Obj.Subjects = txtSubject.Text;
            Obj.Products = hdProduct.Value;
            Obj.EmailBodys = hdText.Value;
            Obj.HasAttachment = fileupload.HasFile;
            Obj.AttachmentPath = "";
            if (fileupload.HasFile)
            {
                string filename = DateTime.Now.ToString("dd-MM-yyyyHHmmss") + fileupload.PostedFile.FileName;
                fileupload.PostedFile.SaveAs(Server.MapPath("VendorSearchProductFile/") + filename);
                Obj.AttachmentPath = "VendorSearchProductFile/" + filename;
            }

          
            Obj.CREATED_BY = Session["loginId"].ToString();
            Obj.UPDATED_BY = Session["loginId"].ToString();


            bool returnmsg = dal.InsertProductSearchVendors(Obj);
            string AddedBy = Convert.ToString(Session["loginId"]);
                  if (returnmsg != false)
                    {

                        Clear();
                        divfillgrid.Attributes["Style"] = "display:block";
                        divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:block";

                lblmsg1.Text = " Saved Successfully...";
                mymsg("Email sent to Selected Vendor");
                        bind();
               
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

          
            var emailids = new List<string>();

            var Productlist = new List<string>();
            for (int i = 0; i < rptRole.Items.Count; i++)
            {
                RepeaterItem item = (RepeaterItem)rptRole.Items[i];

                Label lblsubcategoryName = (Label)item.FindControl("lblsubcategoryName");
              
                if (Productlist.Contains(lblsubcategoryName.Text) == false)
                {
                    Productlist.Add(lblsubcategoryName.Text);
                }
                Label lblEmail = (Label)item.FindControl("lblEmail");
                if (emailids.Contains(lblEmail.Text) == false)
                {
                    emailids.Add(lblEmail.Text ) ;
                   
                }
            
            }
            string product = "";
            string hdProduct_ = "";
            for (int i = 0; i < Productlist.Count; i++)
            {
                hdProduct_ += Productlist[i].ToString()+",";
                product += "<p>"+ Productlist[i].ToString()+ "</p>";
            }
            hdProduct.Value = hdProduct_;
            string emailbodytext = "<p>Dear Sir,</p><p>Please share your beneficiary for the below material.</p>" + product + "</p><p>Kindly share the Commercial with terms and condition at the earliest.</p><p>Regards,</p><p>SISL Infotech Pvt. Ltd.</p>";
            hdText.Value = emailbodytext;
            txtEditor.Text = emailbodytext;


            string emailids_ = "";
            for (int i = 0; i < emailids.Count; i++)
            {
                emailids_ += emailids[i].ToString() + ";";
            }
            txtTo.Text= emailids_;
            txtSubject.Text = "Enquiry for " + hdProduct.Value;
        }

        private void Clear()
        {
           
            txtFrom.Text = "procurement@sislinfotech.com";
            txtTo.Text = "";
            txtSubject.Text = "Enquiry for ";
            hdText.Value = "";
            txtEditor.Text = "";



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
            InsertProductSearchVendors();
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
            Response.AddHeader("content-disposition", "attachment;filename=ProductSearch_" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xls");
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

        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }

    }
}
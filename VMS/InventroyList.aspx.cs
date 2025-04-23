
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Data;
using ML;
using DL;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace vms
{
    public partial class InventroyList : System.Web.UI.Page
    {
        ClsInventryListBL tblcategory = new ClsInventryListBL();
        string flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
              
            }
        }
        void filldropdown()
        {
            //tblcategory.bindLOcation(drdLocationName);
            //tblcategory.bindprojet(drdProjectID);
            //tblcategory.bindDevice(drdDeviceType);

        }
        private void bind()
        {
            DataTable dt = tblcategory.Getallcategory();
            if (dt.Rows.Count > 0)
            {
                rptRole.DataSource = dt;
                rptRole.DataBind();
                divfillgrid.Attributes["Style"] = "display:block";
                //divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                //UplaodExcel1.Attributes["Style"] = "display:none";
            }
            else
            {
                rptRole.DataSource = null;
                rptRole.DataBind();
                divfillgrid.Attributes["Style"] = "display:block";
                //divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:block";
                lblmsg2.Text = "No records found.";
            }
        }
        protected void btnAddrole_Click(object sender, EventArgs e)
        {
            //btnsave.Visible = true;
            //imgbtnupdate.Visible = false;
            //Clear();
            //divmsg1.Attributes["Style"] = "display:none";
            //divmsg2.Attributes["Style"] = "display:none";
            //divfillgrid.Attributes["Style"] = "display:none";
            //divsavedata.Attributes["Style"] = "display:block";
            //if (Rollname == "External")
            //{
            //    Divstart.Visible = false;
            //    DivEnd.Visible = false;


            //}
        }

        protected void imgbtnVbatch_Click(object sender, EventArgs e)
        {

            //btnsave.Visible = false;
            //imgbtnupdate.Visible = false;
            //Clear();
            //divmsg1.Attributes["Style"] = "display:none";
            //divmsg2.Attributes["Style"] = "display:none";
            //divfillgrid.Attributes["Style"] = "display:block";
            //divsavedata.Attributes["Style"] = "display:none";
            //bind();
        }

        protected void rptRole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                DataTable dt = new DataTable();
                string inventryName = ((Label)e.Item.FindControl("lblID")).Text;
                string projectid = ((Label)e.Item.FindControl("lblProjectid")).Text;

                fill(inventryName, projectid);

                divfillgrid.Attributes["Style"] = "display:block";
                divfillInventry.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
            }
            
        }


        private void fill(string inventryName, string projectid)
        {
            DataTable dt = new DataTable();
            var Login = Convert.ToString(Session["LoginId"]);
            dt = tblcategory.GetAllinvertrydetails(inventryName,Login,projectid);
            if (dt.Rows.Count > 0)
            {
                Session["dtTest"] = dt;
                Button11.Visible = true;
                btndown.Attributes["Style"] = "display:block";
                RptShowDetails.DataSource = dt;
                RptShowDetails.DataBind();
            }
            else
            {
                divmsg1.Attributes["Style"] = "display:block";
                lblmsg1.Text="NO Record found";
            }
        }

       
        private void Clear()
        {
            //hfcategory_ID.Value= "";
            //txtInventoryDB.Text=  "";
            //txtSubLocation.Text=  "";
            //drdLocationName.SelectedIndex = 0;
            //drdProjectID.SelectedIndex = 0;

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            flag = "I";
            InsertEmployee();

        }

        protected void imgbtnupdate_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            //divsavedata.Attributes["Style"] = "display:block";
            flag = "M";
            InsertEmployee();
            bind();
        }

        private void InsertEmployee()
        {
            //ClsInventryMasterML obj = new ClsInventryMasterML();
            //obj.mode = flag;
            //obj.id = hfcategory_ID.Value;
            //obj.InventoryDB = txtInventoryDB.Text;
            //obj.ProjectID = drdProjectID.SelectedItem.Text;
            //obj.LocationName = drdLocationName.SelectedItem.Text;
            //obj.SubLocation = txtSubLocation.Text ;
            //obj.DeviceType = drdDeviceType.SelectedItem.Text;
            //obj.PartCode = txtPartCode.Text ;
            //obj.PartDescription = txtPartDescription.Text ;
            //obj.HostName = txtHostName.Text ;
            //obj.IPAddress = txtIPAddress.Text ;
            //obj.Component = txtComponent.Text ;
            //obj.ComponentSerialNo = txtComponentSerialNo.Text ;
            //obj.SubComponent = txtSubComponent.Text ;
            //obj.ContactName = txtContactName.Text ;
            //obj.Phone = txtPhone.Text ;
            //obj.Address = txtAddress.Text ;
            //obj.Address1 = txtAddress1.Text ;
            //obj.State = drdState.SelectedItem.Text;
            //obj.District = drdDistrict.SelectedItem.Text;
            //obj.PinCode = txtPinCode.Text ;
            //obj.SupportType = drdSupportType.SelectedItem.Text ;
            //obj.SupportStart = Convert.ToDateTime(txtSupportStartdate.Text) ;
            //obj.SupportEndDate = Convert.ToDateTime(txtSupportEndDate.Text) ;
            //obj.OEMSupport = drdSupportType.SelectedItem.Text ;
            //obj.OEMStartDate = Convert.ToDateTime(txtOEMStartDate.Text);
            //obj.OEMEndDate = Convert.ToDateTime(txtOEMStartDate.Text);
            //obj.SubComponentSerialNo= txtSubComponentSerialNo.Text;
            //obj.AddedBy = Convert.ToString(Session["LoginId"]);
            //obj.ModifiedBy = Convert.ToString(Session["LoginId"]);
            //string save = tblcategory.Insertcategory(obj);
            //if (save != "false")
            //{
            //    Clear();
            //    divfillgrid.Attributes["Style"] = "display:block";
            //    divsavedata.Attributes["Style"] = "display:none";
            //    divmsg1.Attributes["Style"] = "display:block";
            //    lblmsg1.Text = " Saved Successfully...";
            //    lblmsg1.ForeColor = System.Drawing.Color.Green;
            //    bind();
            //}
        }
        protected void DownloadFile_click(object sender, EventArgs e)
        {
            DataTable dt = Session["dtTest"] as DataTable;
            CreateExcelFile(dt);
        }
        public void CreateExcelFile(DataTable Excel)
        {
            dynamic d = DateTime.Now;
            //Clears all content output from the buffer stream.  
            Response.ClearContent();
            //Adds HTTP header to the output stream  
            Response.AddHeader("content-disposition", string.Format("attachment; filename=inventory.xls"));

            // Gets or sets the HTTP MIME type of the output stream  
            Response.ContentType = "application/vnd.ms-excel";
            string space = "";
            foreach (DataColumn dcolumn in Excel.Columns)
            {
                Response.Write(space + dcolumn.ColumnName);
                space = "\t";
            }
            Response.Write("\n");
            int countcolumn;
            foreach (DataRow dr in Excel.Rows)
            {
                space = "";
                for (countcolumn = 0; countcolumn < Excel.Columns.Count; countcolumn++)
                {

                    Response.Write(space + dr[countcolumn].ToString());
                    space = "\t";

                }

                Response.Write("\n");
            }
            Response.End();
        }
        protected void UploadExcel_Click1(object sender, EventArgs e)
        {
            //if (FileUpload1.PostedFile != null)
            //{
            //    try
            //    {
            //        string loginid = Convert.ToString(Session["csfr"]);
            //        string path = string.Concat(Server.MapPath("~/UploadFile\\" + loginid + "-" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + FileUpload1.FileName));
            //        FileUpload1.SaveAs(path);
            //        // Connection String to Excel Workbook  
            //        string excelCS = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;Persist Security Info=False";
            //        //string excelCS = @"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=" + path + ";Extended Properties=Excel 15.0;Persist Security Info=False";
            //        // string excelCS = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + path + ";Extended Properties=Excel 16.0;Persist Security Info=False";

            //        using (OleDbConnection con = new OleDbConnection(excelCS))
            //        {
            //            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
            //            con.Open();

            //            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //            DataTable dt = new DataTable();
            //            da.Fill(dt);

            //            // SQL Server Connection String  
            //            string CS = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            //            SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
            //            bulkInsert.DestinationTableName = "tblInventory_Master";
            //            bulkInsert.ColumnMappings.Add("InventoryDB", "InventoryDB");
            //            bulkInsert.ColumnMappings.Add("ProjectID", "ProjectID");
            //            bulkInsert.ColumnMappings.Add("LocationName", "LocationName");
            //            bulkInsert.ColumnMappings.Add("SubLocation", "SubLocation");
            //            bulkInsert.ColumnMappings.Add("DeviceType", "DeviceType");
            //            bulkInsert.ColumnMappings.Add("PartCode", "PartCode");
            //            bulkInsert.ColumnMappings.Add("PartDescription", "PartDescription");
            //            bulkInsert.ColumnMappings.Add("HostName", "HostName");
            //            bulkInsert.ColumnMappings.Add("IPAddress", "IPAddress");
            //            bulkInsert.ColumnMappings.Add("Component", "Component");
            //            bulkInsert.ColumnMappings.Add("ComponentSerialNo", "ComponentSerialNo");
            //            bulkInsert.ColumnMappings.Add("SubComponent", "SubComponent");
            //            bulkInsert.ColumnMappings.Add("SubComponentSerialNo", "SubComponentSerialNo");
            //            bulkInsert.ColumnMappings.Add("ContactName", "ContactName");
            //            bulkInsert.ColumnMappings.Add("Phone", "Phone");
            //            bulkInsert.ColumnMappings.Add("Address", "Address");
            //            bulkInsert.ColumnMappings.Add("Address1", "Address1");
            //            bulkInsert.ColumnMappings.Add("State", "State");
            //            bulkInsert.ColumnMappings.Add("District", "District");
            //            bulkInsert.ColumnMappings.Add("PinCode", "PinCode");
            //            bulkInsert.ColumnMappings.Add("SupportType", "SupportType");
            //            bulkInsert.ColumnMappings.Add("SupportStart", "SupportStart");
            //            bulkInsert.ColumnMappings.Add("SupportEndDate", "SupportEndDate");
            //            bulkInsert.ColumnMappings.Add("OEMSupport", "OEMSupport");
            //            bulkInsert.ColumnMappings.Add("OEMStartDate", "OEMStartDate");
            //            bulkInsert.ColumnMappings.Add("OEMEndDate", "OEMEndDate");
            //            bulkInsert.WriteToServer(dt);
            //            bind();
            //            divmsg1.Attributes["Style"] = "display:block";
            //            lblmsg1.Text = "Your file uploaded successfully";
            //            lblmsg1.ForeColor = System.Drawing.Color.Green;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        divmsg2.Attributes["Style"] = "display:block";
            //        lblmsg2.Text = "Your file not uploaded";
            //        lblmsg2.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }
        protected void BtnUploadExcel_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            //divsavedata.Attributes["Style"] = "display:none";
            //UplaodExcel1.Attributes["Style"] = "display:block";
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
        }

        protected void drdLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Internal_AuditUnit();
        }
        void fill_Internal_AuditUnit()
        {
                //string Department_Id = drdLocationName.SelectedItem.Text;
                //DataTable dt = tblcategory.GetLocationByid(Department_Id);
                //if (dt.Rows.Count > 0)
                //{
                // tblcategory.fill_Internal_State(drdState);
                // tblcategory.fill_Internal_district(drdDistrict);

                //      drdState.SelectedItem.Text    = dt.Rows[0]["Name"].ToString();
                //      drdDistrict.SelectedItem.Text = dt.Rows[0]["DistrictName"].ToString();
                //      txtPinCode.Text = dt.Rows[0]["PINCode"].ToString();
                //      txtPhone.Text = dt.Rows[0]["Contact_Number"].ToString();
                //      txtContactName.Text = dt.Rows[0]["Contact_Person"].ToString();
                //  }
                //else
                //{
                   
                //    divfillgrid.Attributes["Style"] = "display:block";
                //    divsavedata.Attributes["Style"] = "display:none";
                //    divmsg1.Attributes["Style"] = "display:none";
                //    divmsg2.Attributes["Style"] = "display:block";
                //    lblmsg2.Text = "No records found.";
                //}
            }

        protected void RptShowDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "View")
            //{
            //    string Rcode = ((Label)e.Item.FindControl("lblID")).Text;
            //    string a = Rcode;
               
            //}

        }
        //tblcategory.fill_Internal_State(ref drdState, Department_Id);
    }

        //protected void drdState_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fill_Internal_AuditUnit1();
        //}
        
        //void fill_Internal_AuditUnit1()
        //{
        //    string Department_Id = drdState.SelectedValue;
        //    tblcategory.fill_Internal_district(ref drdDistrict, Department_Id);
        //}

    
}

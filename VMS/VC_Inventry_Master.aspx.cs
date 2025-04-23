
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
    public partial class VC_Inventry_Master : System.Web.UI.Page
    {
        ClsInventryMasterBL tblcategory = new ClsInventryMasterBL();
        string flag;
        string Fname = "";
        private static int _currentPageIndex = 0;
        private const int PageSize = 500;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                filldropdown();
            }
        }
        void filldropdown()
        {
            tblcategory.bindLOcation(drdLocationName);
            tblcategory.bindprojet(drdProjectID);
            tblcategory.bindDevice(drdDeviceType);
            tblcategory.bindStatus(drdStatus);
            tblcategory.fill_Internal_State(drdState);
            tblcategory.fill_Internal_district(drdDistrict);
        }
        private void bind()
        {
            string id = "";
            DataTable dt = tblcategory.GetallcategoryVC(id);
            if (dt.Rows.Count > 0)
            {
                int totalRecords = dt.Rows.Count;
                int totalPages = (int)Math.Ceiling((double)totalRecords / PageSize);

                // Get the current page data
                var pagedData = dt.AsEnumerable().Skip(_currentPageIndex * PageSize).Take(PageSize).CopyToDataTable();
                rptRole.DataSource = pagedData;
                rptRole.DataBind();

                // Update Page Number
                lblPageNumber.Text = $"Page {_currentPageIndex + 1} of {totalPages}";

                // Enable/Disable buttons based on page index
                btnPrevious.Enabled = _currentPageIndex > 0;
                btnNext.Enabled = (_currentPageIndex + 1) < totalPages;

                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                UplaodExcel1.Attributes["Style"] = "display:none";
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
            var a = Convert.ToString(Session["LoginId"]);
            DataTable dt = new DataTable();
            dt = tblcategory.GetRoll(a);
            string Rollname = dt.Rows[0]["rollName"].ToString();


            btnsave.Visible = true;
            imgbtnupdate.Visible = false;
            Clear();
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:block";
            if (Rollname == "External")
            {
                Divstart.Visible = false;
                DivEnd.Visible = false;


            }
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
                string Rcode = ((Label)e.Item.FindControl("lblID")).Text;
                hfcategory_ID.Value = Rcode;
                fill(hfcategory_ID.Value);

                divfillgrid.Attributes["Style"] = "display:none";
                divsavedata.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                btnsave.Visible = false;
                imgbtnupdate.Visible = true;
            }
            if (e.CommandName == "View")
            {
                DataTable dt = new DataTable();
                string Rcode = ((Label)e.Item.FindControl("lblID")).Text;
                hfcategory_ID.Value = Rcode;
                dt = tblcategory.GetHistory(Rcode);
                Session["dtTest"] = dt;
                if (dt.Rows.Count > 0)
                {
                    RptShowDetails.DataSource = dt;
                    RptShowDetails.DataBind();
                    // divmsg1.Attributes["Style"] = "display:block";
                    divmsg2.Attributes["Style"] = "display:none";
                    divfillgrid.Attributes["Style"] = "display:block";
                    divfillInventry.Attributes["Style"] = "display:block";
                    divsavedata.Attributes["Style"] = "display:none";
                    btndown.Attributes["Style"] = "display:block";
                    //lblmsg1.Text = "Client OWner Code deleted Successfully...";
                }



                //bind();
                //}
                //else
                //{
                //    divmsg1.Attributes["Style"] = "display:none";
                //    divmsg2.Attributes["Style"] = "display:block";
                //    divfillgrid.Attributes["Style"] = "display:block";
                //    divsavedata.Attributes["Style"] = "display:none";
                //    lblmsg2.Text = "Client OWner Code not Deleted.";

                //}
            }
        }

        private void fill(string Rcode)
        {
            btnsave.Visible = false;
            imgbtnupdate.Visible = true;
            DataTable dt = tblcategory.GetallcategoryVC(Rcode);
            ViewState["Check"] = dt.Rows[0]["Certificate"].ToString();
            if (dt.Rows.Count > 0)
            {
                hfcategory_ID.Value = dt.Rows[0]["id"].ToString();
                txtInventoryDB.Text = dt.Rows[0]["InventoryDB"].ToString();
                drdProjectID.SelectedItem.Text = dt.Rows[0]["ProjectID"].ToString();
                drdLocationName.SelectedItem.Text = dt.Rows[0]["LocationName"].ToString();
                txtSubLocation.Text = dt.Rows[0]["SubLocation"].ToString();
                drdDeviceType.SelectedItem.Text = dt.Rows[0]["DeviceType"].ToString();

                string partCode = dt.Rows[0]["PartCode"].ToString();
                ListItem item = drdPartCode.Items.FindByText(partCode);

                if (item != null)
                {
                    drdPartCode.SelectedValue = partCode;
                }
                else
                {
                    drdPartCode.SelectedIndex = -1;
                }

                txtPartDescription.Text = dt.Rows[0]["PartDescription"].ToString();

                txtHostName.Text = dt.Rows[0]["HostName"].ToString();
                txtIPAddress.Text = dt.Rows[0]["IPAddress"].ToString();
                txtComponent.Text = dt.Rows[0]["Component"].ToString();
                txtComponentSerialNo.Text = dt.Rows[0]["ComponentSerialNo"].ToString();
                txtSubComponent.Text = dt.Rows[0]["SubComponent"].ToString();
                drdStatus.SelectedItem.Text = Convert.ToString(dt.Rows[0]["Status"]);

                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtAddress1.Text = dt.Rows[0]["Address1"].ToString();
                fill_Internal_AuditUnit();
                txtSubComponentSerialNo.Text = dt.Rows[0]["SubComponentSerialNo"].ToString();
                drdSupportType.SelectedItem.Text = dt.Rows[0]["SupportType"].ToString();
                DrdVerification.SelectedItem.Text = dt.Rows[0]["InventryVerification"].ToString();


                if (dt.Rows[0]["SupportStart"] != DBNull.Value && dt.Rows[0]["SupportStart"] != null)
                {
                    txtSupportStartdate.Text = Convert.ToDateTime(dt.Rows[0]["SupportStart"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtSupportStartdate.Text = "";
                }
                if (dt.Rows[0]["SupportEndDate"] != DBNull.Value && dt.Rows[0]["SupportEndDate"] != null)
                {
                    txtSupportEndDate.Text = Convert.ToDateTime(dt.Rows[0]["SupportEndDate"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtSupportStartdate.Text = "";
                }

                drdOEMSupport.SelectedItem.Text = dt.Rows[0]["OEMSupport"].ToString();

                if (dt.Rows[0]["OEMStartDate"] != DBNull.Value && dt.Rows[0]["OEMStartDate"] != null)
                {
                    txtOEMStartDate.Text = Convert.ToDateTime(dt.Rows[0]["OEMStartDate"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtSupportStartdate.Text = "";
                }
                if (dt.Rows[0]["OEMEndDate"] != DBNull.Value && dt.Rows[0]["OEMEndDate"] != null)
                {
                    txtOEMEndDate.Text = Convert.ToDateTime(dt.Rows[0]["OEMEndDate"]).ToString("dd/MM/yyyy");
                }

                else
                {
                    txtSupportStartdate.Text = "";
                }

                if (dt.Rows[0]["Date_of_Verification"] != DBNull.Value && dt.Rows[0]["Date_of_Verification"] != null)
                {
                    Dateveri.Text = Convert.ToDateTime(dt.Rows[0]["Date_of_Verification"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    Dateveri.Text = "";
                }
                string File = dt.Rows[0]["Certificate"].ToString();
                if (File != null)
                {
                    lblCertificate.Visible = true;
                    dynamiclink.HRef = "~/Uploads/" + File;
                }

            }
        }

        public void mymsg(string msg)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert('" + msg + "');", true);
        }
        private void Clear()
        {
            hfcategory_ID.Value = "";
            txtInventoryDB.Text = "";
            txtSubLocation.Text = "";
            drdLocationName.SelectedIndex = 0;
            drdProjectID.SelectedIndex = 0;
            drdStatus.SelectedIndex = 0;

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
            bind();

        }

        public string Getfilename()
        {
            if (FileUpload2.HasFile)
            {
                // Check if the uploaded file is a PDF
                if (Path.GetExtension(FileUpload2.FileName).ToLower() == ".pdf")
                {
                    try
                    {
                        // Specify the folder to save the file
                        string folderPath = Server.MapPath("~/Uploads/");
                        // Create the directory if it doesn't exist
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        // Save the file to the specified folder
                        string filePath = Path.Combine(folderPath, FileUpload2.FileName);
                        FileUpload2.SaveAs(filePath);
                        Fname = FileUpload2.FileName;

                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload failed. Error: " + ex.Message;
                        return Fname;
                    }
                }
            }
            return Fname;
        }

        private void InsertEmployee()
        {
            ClsInventryMasterML obj = new ClsInventryMasterML();
            obj.mode = flag;
            obj.id = hfcategory_ID.Value;
            obj.InventoryDB = "RISL";
            obj.ProjectID = drdProjectID.SelectedItem.Text;
            obj.LocationName = drdLocationName.SelectedItem.Text;
            obj.SubLocation = txtSubLocation.Text;
            obj.DeviceType = drdDeviceType.SelectedItem.Text;
            obj.PartCode = drdPartCode.SelectedItem.Text;
            obj.PartDescription = txtPartDescription.Text;
            obj.HostName = txtHostName.Text;
            obj.IPAddress = txtIPAddress.Text;
            obj.Component = txtComponent.Text;
            obj.ComponentSerialNo = txtComponentSerialNo.Text;
            obj.SubComponent = txtSubComponent.Text;
            obj.ContactName = txtContactName.Text;
            obj.Phone = txtPhone.Text;
            obj.Address = txtAddress.Text;
            obj.Address1 = txtAddress1.Text;
            obj.State = drdState.SelectedItem.Text;
            obj.District = drdDistrict.SelectedItem.Text;
            obj.PinCode = txtPinCode.Text;
            obj.Status = drdStatus.SelectedItem.Text;
            obj.SupportType = drdSupportType.SelectedItem.Text;
            obj.SupportStart = txtSupportStartdate.Text;
            obj.SupportEndDate = txtSupportEndDate.Text;
            obj.OEMSupport = drdSupportType.SelectedItem.Text;
            obj.OEMStartDate = txtOEMStartDate.Text;
            obj.OEMEndDate = txtOEMStartDate.Text;
            obj.SubComponentSerialNo = txtSubComponentSerialNo.Text;
            string f = Getfilename();
            if (f != null)
            {
                obj.FileUploade = f;
            }
            else
            {
                obj.FileUploade = ViewState["Check"].ToString();
            }

            obj.Verification = DrdVerification.SelectedItem.Text;
            obj.VerificationDate = Dateveri.Text;
            obj.AddedBy = Convert.ToString(Session["LoginId"]);
            obj.ModifiedBy = Convert.ToString(Session["LoginId"]);
            string save = tblcategory.Insertcategory(obj);
            if (save != "false")
            {
                Clear();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:block";
                lblmsg1.Text = " Saved Successfully...";
                lblmsg1.ForeColor = System.Drawing.Color.Green;
                bind();
            }
        }
        protected void DownloadFile_click(object sender, EventArgs e)
        {

            string filePath = Server.MapPath("~/UploadFile/RislBook.xlsx");
            if (File.Exists(filePath))
            {
                Response.ContentType = "application/vnd.ms-excel"; // Set content type for Excel file
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            else
            {
                Response.Write("File not found.");
            }
        }

        protected void UploadExcel_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try
                {
                    string loginid = Convert.ToString(Session["csfr"]);
                    string path = string.Concat(Server.MapPath("~/UploadFile\\" + loginid + "-" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook  
                    string excelCS = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;Persist Security Info=False";
                    //string excelCS = @"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=" + path + ";Extended Properties=Excel 15.0;Persist Security Info=False";
                    // string excelCS = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + path + ";Extended Properties=Excel 16.0;Persist Security Info=False";

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();

                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        var filteredRows = dt.AsEnumerable().Where(row => !row.IsNull("InventoryDB"));
                        DataTable filteredTable = filteredRows.CopyToDataTable();

                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "tblInventory_Master";
                        bulkInsert.ColumnMappings.Add("InventoryDB", "InventoryDB");
                        bulkInsert.ColumnMappings.Add("Project", "ProjectID");
                        bulkInsert.ColumnMappings.Add("LocationName", "LocationName");
                        bulkInsert.ColumnMappings.Add("SubLocation", "SubLocation");
                        bulkInsert.ColumnMappings.Add("DeviceType", "DeviceType");
                        bulkInsert.ColumnMappings.Add("PartCode", "PartCode");
                        bulkInsert.ColumnMappings.Add("PartDescription", "PartDescription");
                        bulkInsert.ColumnMappings.Add("HostName", "HostName");
                        bulkInsert.ColumnMappings.Add("IPAddress", "IPAddress");
                        bulkInsert.ColumnMappings.Add("Component", "Component");
                        bulkInsert.ColumnMappings.Add("ComponentSerialNo", "ComponentSerialNo");
                        bulkInsert.ColumnMappings.Add("SubComponent", "SubComponent");
                        bulkInsert.ColumnMappings.Add("SubComponentSerialNo", "SubComponentSerialNo");
                        bulkInsert.ColumnMappings.Add("ContactName", "ContactName");
                        bulkInsert.ColumnMappings.Add("Phone", "Phone");
                        bulkInsert.ColumnMappings.Add("Address", "Address");
                        bulkInsert.ColumnMappings.Add("Address1", "Address1");
                        bulkInsert.ColumnMappings.Add("State", "State");
                        bulkInsert.ColumnMappings.Add("District", "District");
                        bulkInsert.ColumnMappings.Add("Block", "Block");
                        bulkInsert.ColumnMappings.Add("PinCode", "PinCode");
                        bulkInsert.ColumnMappings.Add("SupportType", "SupportType");
                        bulkInsert.ColumnMappings.Add("SupportStartDate", "SupportStart");
                        bulkInsert.ColumnMappings.Add("SupportEndDate", "SupportEndDate");
                        bulkInsert.ColumnMappings.Add("OEMSupport", "OEMSupport");
                        bulkInsert.ColumnMappings.Add("OEMStartDate", "OEMStartDate");
                        bulkInsert.ColumnMappings.Add("OEMEndDate", "OEMEndDate");
                        bulkInsert.ColumnMappings.Add("Status", "Status");
                        bulkInsert.WriteToServer(filteredTable);
                        string result = tblcategory.GetMergetable();
                        bind();
                        divmsg1.Attributes["Style"] = "display:block";
                        lblmsg1.Text = "Your file uploaded successfully";
                        lblmsg1.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    divmsg2.Attributes["Style"] = "display:block";
                    lblmsg2.Text = "Your file not uploaded";
                    lblmsg2.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void BtnUploadExcel_Click(object sender, EventArgs e)
        {
            divfillgrid.Attributes["Style"] = "display:none";
            divsavedata.Attributes["Style"] = "display:none";
            UplaodExcel1.Attributes["Style"] = "display:block";
            divmsg1.Attributes["Style"] = "display:none";
            divmsg2.Attributes["Style"] = "display:none";
        }

        protected void drdLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Internal_AuditUnit();
        }
        void fill_Internal_AuditUnit()
        {
            string Department_Id = drdLocationName.SelectedItem.Text;
            DataTable dt = tblcategory.GetLocationByid(Department_Id);
            if (dt.Rows.Count > 0)
            {
                tblcategory.fill_Internal_State(drdState);
                tblcategory.fill_Internal_district(drdDistrict);
                drdState.SelectedItem.Text = dt.Rows[0]["Name"].ToString();
                drdDistrict.SelectedItem.Text = dt.Rows[0]["DistrictName"].ToString();
                txtPinCode.Text = dt.Rows[0]["PINCode"].ToString();
                //txtPhone.Text = dt.Rows[0]["Contact_Number"].ToString();
                //txtContactName.Text = dt.Rows[0]["Contact_Person"].ToString();
            }
            else
            {
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:block";
                lblmsg2.Text = "No records found.";
            }
        }

        protected void BtnAllinventroy_Click(object sender, EventArgs e)
        {

            DataTable dt = tblcategory.Getallinventory();
            if (dt.Rows.Count > 0)
            {
                CreateExcelFile(dt);
            }
            else
            {
                divmsg2.Attributes["Style"] = "display:block";
                lblmsg2.Text = "Your Record Found";
                lblmsg2.ForeColor = System.Drawing.Color.Red;

            }
        }

        public void CreateExcelFile(DataTable Excel)
        {

            dynamic d = DateTime.Now;
            //Clears all content output from the buffer stream.  
            Response.ClearContent();
            //Adds HTTP header to the output stream  
            Response.AddHeader("content-disposition", string.Format("attachment; filename=Allinventory.xls"));

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


        protected void DownloadFile1_click(object sender, EventArgs e)
        {
            DataTable dt = Session["dtTest"] as DataTable;
            CreateExcelFile(dt);
        }

        protected void DrdVerification_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Y = DrdVerification.SelectedItem.Text;
            if (Y == "Yes")
            {
                Dateveri.Enabled = true;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Textvalue = TextBox1.Text;
            DataTable dt = tblcategory.SearchForDownload(Textvalue);
            ViewState["Search"] = dt;
            if (dt.Rows.Count > 0)
            {
                rptRole.DataSource = dt;
                rptRole.DataBind();
                Button3.Enabled = true;
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:none";
                UplaodExcel1.Attributes["Style"] = "display:none";
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["Search"] as DataTable;
            CreateExcelFile(dt);
        }

        protected void drdDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Internal_AuditUnit1();
        }
        void fill_Internal_AuditUnit1()
        {
            string Devicename = drdDeviceType.SelectedItem.Text;
            tblcategory.fill_Internal_Partcode(ref drdPartCode, Devicename);
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                bind();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string id = "";
            DataTable dt = tblcategory.GetallcategoryVC(id);
            int totalRecords = dt.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / PageSize);

            if (_currentPageIndex + 1 < totalPages)
            {
                _currentPageIndex++;
                bind();
            }

        }
    }
}

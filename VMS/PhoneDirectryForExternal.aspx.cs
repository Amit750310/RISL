
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
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace vms
{
    public partial class PhoneDirectryForExternal : System.Web.UI.Page
    {
        PhoneDirectoryBL dal = new PhoneDirectoryBL();
        PhoneDirectoryML Obj = new PhoneDirectoryML();
        ClsBlockMasterBL blockBl = new ClsBlockMasterBL();
        string flag;
        private static int _currentPageIndex = 0;
        private const int PageSize = 1000;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                //BindRepeater();
            }
        }

        protected void btnproced_Click(object sender, EventArgs e)
        {
            flag = "I";
            //InsertEmployee();
        }

        //private void InsertEmployee()
        //{
        //    Obj.ID = hfid.Value;
        //    //Obj.Location_Name = txtLocation_Name.Text;
        //    //Obj.Address1 = txtAddress1.Text;
        //    //Obj.Ucode=TxtUcode.Text;
        //    //Obj.State = DrdState.SelectedValue;
        //    //Obj.StateName=DrdState.SelectedItem.Text;
        //    //Obj.DistrictID = DrdDistict.SelectedValue;
        //    //Obj.BlockID = drdblock.SelectedValue;
        //    Obj.Districtname = TXTDistict.Text;
        //    Obj.BlockName = TXTblock.Text;
        //    Obj.OfficeName = txtofficename.Text;
        //    Obj.OfficeLocation = txtOfficeLocation.Text;
        //    Obj.Department = txtDepartment.Text;
        //    Obj.Description = txtAddress.Text;
        //    Obj.Extension = txtExtension.Text;
        //    Obj.mode = flag;
        //    Obj.AddedBy = Session["loginId"].ToString();
        //    Obj.ModifiedBy = Session["loginId"].ToString();
        //    string save = dal.InsertEmployee(Obj);
        //    if (save != "false")
        //    {
        //        Clear();
        //        divfillgrid.Attributes["Style"] = "display:block";
        //        divsavedata.Attributes["Style"] = "display:none";
        //        lblmsg1.Text = " Saved Successfully...";
        //        bind();
        //    }

        //}

        private void bind()
        {
            DataTable dt = dal.fillgetallLevel();
            Session["Projectbase"] = dt;
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
                UploadExcel.Visible = true;
            }
            else
            {

                rptRole.DataSource = null;
                rptRole.DataBind();
                divfillgrid.Attributes["Style"] = "display:block";
                divsavedata.Attributes["Style"] = "display:none";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:block";
                // UploadExcel.Visible = ;
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
            txtExtension.Text = "";
            txtOfficeLocation.Text = "";
            txtofficename.Text = "";
            txtDepartment.Text = "";
            txtAddress.Text = "";
            // DrdState.SelectedIndex = 0;
            TXTblock.Text = "";
            TXTDistict.Text = "";
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
            DataTable dt = BaseCommon.GetDataSet("GetAllPhoneDirectry'" + Rcode + "' ", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                hfid.Value = dt.Rows[0]["Id"].ToString();
                txtAddress.Text = dt.Rows[0]["Description"].ToString();
                txtDepartment.Text = dt.Rows[0]["Deapartment"].ToString();
                txtOfficeLocation.Text = dt.Rows[0]["OfficeLocation"].ToString();
                txtofficename.Text = dt.Rows[0]["OfficeName"].ToString();
                txtExtension.Text = dt.Rows[0]["Extension"].ToString();
                TXTDistict.Text = dt.Rows[0]["Districtname"].ToString();
                TXTblock.Text = dt.Rows[0]["BlockName"].ToString();

                //try
                //{
                //    DrdState.SelectedItem.Text = Convert.ToString(dt.Rows[0]["StateName"]);
                //    fill_Internal_AuditUnit();
                //    DrdDistict.SelectedItem.Text = Convert.ToString(dt.Rows[0]["Districtname"]);
                //    fill_Internal_AuditUnit1();
                //    drdblock.SelectedItem.Text = Convert.ToString(dt.Rows[0]["BlockName"]);
                //}
                //catch (Exception ex)
                //{


                //}
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
           // InsertEmployee();
            bind();
        }

        protected void btnrest_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void BtnUploadExcel_Click(object sender, EventArgs e)
        {
            UplaodExcel1.Visible = true;

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

                        var filteredRows = dt.AsEnumerable().Where(row => !row.IsNull("Districtname"));
                        DataTable filteredTable = filteredRows.CopyToDataTable();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "tblphonedir";
                        //bulkInsert.ColumnMappings.Add("StateName", "StateName");
                        bulkInsert.ColumnMappings.Add("Districtname", "Districtname");
                        bulkInsert.ColumnMappings.Add("BlockName", "BlockName");
                        bulkInsert.ColumnMappings.Add("OfficeName", "OfficeName");
                        bulkInsert.ColumnMappings.Add("OfficeLocation", "OfficeLocation");
                        bulkInsert.ColumnMappings.Add("Description", "Description");
                        bulkInsert.ColumnMappings.Add("Deapartment", "Deapartment");
                        bulkInsert.ColumnMappings.Add("Extension", "Extension");
                        bulkInsert.WriteToServer(filteredTable);
                        //string result = tblcategory.GetMergetable();
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
            DataTable dt = dal.fillgetallLevel();
            int totalRecords = dt.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / PageSize);

            if (_currentPageIndex + 1 < totalPages)
            {
                _currentPageIndex++;
                bind();
            }

        }

        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["Projectbase"] as DataTable;
            DataTable dt1 = Session["Projectbase_filter"] as DataTable;
            if (dt != null && dt1 != null)
            {
                if (dt.Rows.Count < dt1.Rows.Count)
                {
                    dt.Columns.Remove("ID");
                    dt.Columns.Remove("StateID");
                    dt.Columns.Remove("StateName");
                    dt.Columns.Remove("DistrictID");
                    CreateExcelFile(dt);
                }
                else
                {
                    dt1.Columns.Remove("ID");
                    dt1.Columns.Remove("StateID");
                    dt1.Columns.Remove("StateName");
                    dt1.Columns.Remove("DistrictID");
                    CreateExcelFile(dt1);
                }
            }
            else if (dt != null)
            {
                dt.Columns.Remove("ID");
                dt.Columns.Remove("StateID");
                dt.Columns.Remove("StateName");
                dt.Columns.Remove("DistrictID");
                CreateExcelFile(dt);
            }
            else if (dt1 != null)
            {
                dt1.Columns.Remove("ID");
                dt.Columns.Remove("StateID");
                dt1.Columns.Remove("StateName");
                dt1.Columns.Remove("DistrictID");
                CreateExcelFile(dt1);
            }
            else
            {
                // Handle the case where both are null (optional)
                Response.Write("No data available to export.");
            }
           
            // dt.Columns.Remove("");
            CreateExcelFile(dt);

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

         void FilterData()
        {
            DataTable dt = Session["Projectbase"] as DataTable;

            if (dt != null)
            {
                string district = txtSearchDistrict.Text;
                string block = txtSearchBlock.Text;
                string office = txtSearchOffice.Text;
                string location = txtSearchLocation.Text;
                string description = txtSearchDescription.Text;
                string department = txtSearchDepartment.Text;
                string extension = txtSearchExtension.Text;

                DataRow[] filteredRows = dt.Select("Districtname LIKE '%" + district + "%' AND " +
                                   "BlockName LIKE '%" + block + "%' AND " +
                                   "OfficeLocation LIKE '%" + location + "%' AND " +
                                   "Description LIKE '%" + description + "%' AND " +
                                   "Deapartment LIKE '%" + department + "%' AND " +
                                   "Extension LIKE '%" + extension + "%' AND " +
                                   "OfficeName LIKE '%" + office + "%'");
                //dt.AsEnumerable();


                //// Only filter by one column at a time
                //if (!string.IsNullOrEmpty(district)&&!string.IsNullOrEmpty(district))
                //    filteredRows = filteredRows.Where(row => row["Districtname"].ToString().Contains(district));
                //else if (!string.IsNullOrEmpty(block))
                //    filteredRows = filteredRows.Where(row => row["BlockName"].ToString().Contains(block));
                //else if (!string.IsNullOrEmpty(office))
                //    filteredRows = filteredRows.Where(row => row["OfficeName"].ToString().Contains(office));
                //else if (!string.IsNullOrEmpty(location))
                //    filteredRows = filteredRows.Where(row => row["OfficeLocation"].ToString().Contains(location));
                //else if (!string.IsNullOrEmpty(description))
                //    filteredRows = filteredRows.Where(row => row["Description"].ToString().Contains(description));
                //else if (!string.IsNullOrEmpty(department))
                //    filteredRows = filteredRows.Where(row => row["Deapartment"].ToString().Contains(department));
                //else if (!string.IsNullOrEmpty(extension))
                //    filteredRows = filteredRows.Where(row => row["Extension"].ToString().Contains(extension));

                DataTable dt2= filteredRows.Any() ? filteredRows.CopyToDataTable() : dt.Clone();
                rptRole.DataSource = dt2;
                rptRole.DataBind();

              Session["Projectbase_filter"] = dt2;
            }
        }

        protected void txtSearchDistrict_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        protected void txtSearchBlock_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        protected void txtSearchOffice_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        protected void txtSearchLocation_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        protected void txtSearchDescription_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        protected void txtSearchDepartment_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        protected void txtSearchExtension_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }
    }
}
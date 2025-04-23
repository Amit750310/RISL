using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vms
{
    public partial class Reports : System.Web.UI.Page
    {
        ClsInventryMasterBL tblcategory = new ClsInventryMasterBL();
        private static int _currentPageIndex = 0;
        private const int PageSize = 500;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string Name = "RISL-VC";
                //Session["before"]= Name;
                //bind(Name);
               // filldropdown();
            }
        }
        private void bind(string A)
        {
            DataTable dt = tblcategory.GetReports(A);
            Session["RTInventry"]= dt;
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
                    divfillgrid.Visible=true;
                    divmsg1.Attributes["Style"] = "display:none";
                    divmsg2.Attributes["Style"] = "display:none";
             }
            else
            {
                rptRole.DataSource = null;
                rptRole.DataBind();
                divfillgrid.Attributes["Style"] = "display:block";
                divmsg1.Attributes["Style"] = "display:none";
                divmsg2.Attributes["Style"] = "display:block";
                lblmsg2.Text = "No records found.";
            }
        }

        public void CreateExcelFile(DataTable Excel)
        {

            dynamic d = DateTime.Now;
            //Clears all content output from the buffer stream.  
            Response.ClearContent();
            //Adds HTTP header to the output stream  
            Response.AddHeader("content-disposition", string.Format("attachment; filename=Inventery.xls"));

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



        protected void BtnUploadExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["RTInventry"] as DataTable;
            CreateExcelFile(dt);
        }

        public void drdinventryselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string A = drdinventryselection.SelectedItem.Text;
            Session["Selection"]= A;
            bind(A);
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPageIndex > 0)
            {
                string A = Session["Selection"] as string;
                _currentPageIndex--;
                 bind(A);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        { 
            string A = Session["Selection"] as string;
            DataTable dt = tblcategory.GetReports(A);
            int totalRecords = dt.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / PageSize);

            if (_currentPageIndex + 1 < totalPages)
            {
                _currentPageIndex++;
                 bind(A);
            }
        }
    }
}
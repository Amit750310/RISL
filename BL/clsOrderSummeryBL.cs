
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DL;
using ML;
using System.Data;
namespace BL
{
 public   class clsOrderSummeryBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public void fill_Product_Summery(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_dropdown_Product_Summery", CommandType.StoredProcedure);

        }
        public DataTable GetProduct_OrderSummery(string fdate, string tdate, string ORDERSTATUS, string Product,string empcode,string Level,string sp_instruction)
        {
            DataTable dt = new DataTable();
            
            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_OrderSummery", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_SalesOrderSummery(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_SalesOrderSummery", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_TrailOrderSummery(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_TrailOrderSummery", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
     
        public DataTable GetProduct_SSLGranthItemsForUpdate(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[6];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);

            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_SelectSSLGranthItemsForUpdate", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable GetProduct_SalesOrderComment( string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[1] = new SqlParameter("@Product", Product);
            objSqlParam[2] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[3] = new SqlParameter("@Level", Level);
            objSqlParam[4] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_SalesComment", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_RenwalsOrderSummery(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectRenwalsOrderSummery", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_COMPLETEDOrderSummery(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectCOMPLETED_OrderSummery", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable GetProduct_AccCOMPLETEDOrderSummery(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectAccCOMPLETED_OrderSummery", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_AccInvoiceStatus(string fdate, string tdate, string ORDERSTATUS, 
            string Product, string empcode, string Level, string sp_instruction,bool isInvoicePending)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[8];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            objSqlParam[7] = new SqlParameter("@isInvoicePending", isInvoicePending);
            
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectAccAccInvoiceStatus", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable update_AccInvoiceStatus(string OrderReferenceNo, string isInvoicePending)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrderReferenceNo", OrderReferenceNo);
            objSqlParam[1] = new SqlParameter("@isInvoicePending", isInvoicePending);
   
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_updateInvoicestatus", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable update_TechnicalOrderStatus(string Technical_Status, string Technical_Remark, string OrderItemId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@OrderItemId", OrderItemId);
            objSqlParam[1] = new SqlParameter("@Technical_Status", Technical_Status);
            objSqlParam[2] = new SqlParameter("@Technical_Remark", Technical_Remark);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_update_TechnicalOrderStatus", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable update_AccInvoiceFile(string Invoice_File, string Invoice_File_Path,string OrderItemId)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@Invoice_File", Invoice_File);
            objSqlParam[1] = new SqlParameter("@Invoice_File_Path", Invoice_File_Path);
            objSqlParam[2] = new SqlParameter("@OrderItemId", OrderItemId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_updateInvoiceFile", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable update_AccTDSFile(string TDS_File, string TDS_File_Path, string OrderItemId)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@TDS_File", TDS_File);
            objSqlParam[1] = new SqlParameter("@TDS_File_Path", TDS_File_Path);
            objSqlParam[2] = new SqlParameter("@OrderItemId", OrderItemId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_updateTDSFile", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable update_SalesPOFile(string PO_File, string PO_File_Path, string OrderItemId)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@PO_File", PO_File);
            objSqlParam[1] = new SqlParameter("@PO_File_Path", PO_File_Path);
            objSqlParam[2] = new SqlParameter("@OrderItemId", OrderItemId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_updatePOFile", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable updateGSTNnumber(string GSTNNumber,  string OrderItemId)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@GSTNNumber", GSTNNumber);
            objSqlParam[1] = new SqlParameter("@OrderItemId", OrderItemId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_updateGSTNnumber", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_COMPLETEDOrderSummery_PendingPO( string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[5];
         
            objSqlParam[0] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[1] = new SqlParameter("@Product", Product);
            objSqlParam[2] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[3] = new SqlParameter("@Level", Level);
            objSqlParam[4] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectCOMPLETED_OrderSummery_pendingPO", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_OrderSummeryAutoStatus(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level, string sp_instruction)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Product", Product);
            objSqlParam[4] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[5] = new SqlParameter("@Level", Level);
            objSqlParam[6] = new SqlParameter("@sp_instruction", sp_instruction);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_OrderSummery_getautostatus", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_ReadyIssuance(string fdate, string tdate, string OrganizationName, string empcode, string Level)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@OrganizationName", OrganizationName);
            objSqlParam[3] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[4] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_Select_tblPlace_Ready_Issuance_Head", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GettblPlace_Ready_Issuance_Domain(string orderid)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@orderid", orderid);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_tblPlace_Ready_Issuance_Domain", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        
               public string updateOrderItems_RemarksRead(string OrderReferenceNo)
        {
            string ret = "Record deactivate Succesfully";
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@OrderReferenceNo", OrderReferenceNo);
                BaseCommon bc = new BaseCommon();
                bc.GetDatatable("prc_tblOrderItems_RemarksRead", CommandType.StoredProcedure, objSqlParam);
            }
            catch (Exception ex)
            {

                ret = ex.Message;
            }
            return ret;
        }
        public string  updateOrderSummeryRemarks(string OrderReferenceNo,string Remarks)
        {
            string ret = "Record Updated Succesfully";
            try
            {
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@Remarks", Remarks);
            objSqlParam[1] = new SqlParameter("@OrderReferenceNo", OrderReferenceNo);
            BaseCommon bc = new BaseCommon();
           bc.GetDatatable("prc_updateRemarks_tblorderitems", CommandType.StoredProcedure, objSqlParam);
            }
            catch (Exception ex)
            {

                ret = ex.Message;
            }
            return ret;
        }
        public DataTable GettblPlace_Ready_Issuance_ContactPair(string orderid)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@orderid", orderid);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_tblPlace_Ready_Issuance_ContactPair", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
    }
}

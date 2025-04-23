using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public   class clsgranthBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public string InsertGranthData(clsgranthML obj)
        {
            try
            {
                con.Open();
                BaseCommon common = new BaseCommon();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", obj.mode);
                cmd.Parameters.AddWithValue("@sslGRanthID", obj.sslGRanthID);
                cmd.Parameters.AddWithValue("@Emp_code", obj.Emp_code);
                cmd.Parameters.AddWithValue("@SymantecOrderId", obj.SymantecOrderId);
                cmd.Parameters.AddWithValue("@Enrol_Date", obj.Enrol_Date);
                cmd.Parameters.AddWithValue("@A_C_Mgr",obj.A_C_Mgr);
                cmd.Parameters.AddWithValue("@Resaller", obj.Resaller);
                cmd.Parameters.AddWithValue("@Retail_MPKI", obj.Retail_MPKI);
                cmd.Parameters.AddWithValue("@Product", obj.Product);
                cmd.Parameters.AddWithValue("@FQDN", obj.FQDN);
                cmd.Parameters.AddWithValue("@Validity", obj.Validity);
                cmd.Parameters.AddWithValue("@Organisation_Name", obj.Organisation_Name);
                cmd.Parameters.AddWithValue("@ItemStatus", obj.ItemStatus);
                cmd.Parameters.AddWithValue("@Starting_Date", obj.Starting_Date);
                cmd.Parameters.AddWithValue("@Expiry_Date", obj.Expiry_Date);
                cmd.Parameters.AddWithValue("@TP_Val_USD", obj.TP_Val_USD);
                cmd.Parameters.AddWithValue("@TP_Val_INR", obj.TP_Val_INR);
                cmd.Parameters.AddWithValue("@Sale_Value", obj.Sale_Value);
                cmd.Parameters.AddWithValue("@GST_18", obj.GST_18);
                cmd.Parameters.AddWithValue("@Total_Value", obj.Total_Value);
                cmd.Parameters.AddWithValue("@ServiceAmount", obj.ServiceAmount);
                cmd.Parameters.AddWithValue("@Total_Net_Value", obj.Total_Net_Value);
                cmd.Parameters.AddWithValue("@Profit", obj.Profit);
                cmd.Parameters.AddWithValue("@Percent_On_Sale", obj.Percent_On_Sale);
                cmd.Parameters.AddWithValue("@PO_No", obj.PO_No);
                cmd.Parameters.AddWithValue("@Billing_Name", obj.Billing_Name);
                cmd.Parameters.AddWithValue("@JNR_Bill_Number", obj.JNR_Bill_Number);
                cmd.Parameters.AddWithValue("@SymantecInvoiceNo", obj.SymantecInvoiceNo);
                cmd.Parameters.AddWithValue("@Dispatch_details", obj.Dispatch_details);
                cmd.Parameters.AddWithValue("@DDate", obj.DDate);
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);
                cmd.CommandText = "Prc_insertSSLGranthItems";
                if (cmd.ExecuteNonQuery() < 0)
                {

                    return "false";
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            finally
            {
                con.Close();


            }
            return "true";
        }
        public DataTable GetInrVal()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_getINRcurrencyVal", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable GetProduct_SSLGranthItems(string fdate, string tdate, string ORDERSTATUS, string Product, string empcode, string Level)
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
            dt = bc.GetDatatable("Prc_SelectSSLGranthItems", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProduct_SalesSSLGranthItems(string fdate, string tdate, string ORDERSTATUS, string empcode)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[4];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Emp_code", empcode);
           

            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_SelectSalesSSLGranthItems", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable getselectedsslGranthcolmnData(string fdate, string tdate, string ORDERSTATUS, string empcode,string colmnname)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", ORDERSTATUS);
            objSqlParam[3] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[4] = new SqlParameter("@colmnname", colmnname);

            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_getselectedSalesSSLGranthcolmn", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        
        public DataTable SelectSSLGranthItems_Single(string sslGRanthID)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@sslGRanthID", sslGRanthID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_SelectSSLGranthItems_Single", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class clsBulkOrderBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public DataTable getbulkorderRequest(clsBulkOrderML prp)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@fdate", prp.fdate);
            objSqlParam[1] = new SqlParameter("@tdate", prp.tdate);
            objSqlParam[2] = new SqlParameter("@ORDERSTATUS", prp.ORDERSTATUS);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_getbulkorderRequest", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public string updatebulkorderRequest(clsBulkOrderML prp)
        {
            string err = "";
            try
            {
                con.Open();


                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Id", prp.ID);
                cmd2.Parameters.AddWithValue("@PartnerBulkId", prp.PartnerBulkId);
                cmd2.Parameters.AddWithValue("@SubmittedOrders", prp.SubmittedOrders);
                cmd2.Parameters.AddWithValue("@TotalProcessed", prp.TotalProcessed);
                cmd2.Parameters.AddWithValue("@OrderStatus", prp.OrderStatus);
                cmd2.CommandText = "prc_Update_tblBulkOrderRequest";
                cmd2.ExecuteNonQuery();

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
            return err;
        }
        public string insertbulkorderRequest(clsBulkOrderML prp)
        {
            string err = "";
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@PartnerBulkId", prp.PartnerBulkId);
                cmd2.Parameters.AddWithValue("@OrderIds", prp.OrderIds);
                cmd2.Parameters.AddWithValue("@TotalCertificates", prp.TotalCertificates);
                cmd2.Parameters.AddWithValue("@RequestResponseLocation", prp.RequestResponseLocation);
                cmd2.Parameters.AddWithValue("@ResellerId", prp.ResellerId);
                cmd2.CommandText = "prc_insert_tblBulkOrderRequest";
                cmd2.ExecuteNonQuery();
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
            return err;
        }

        public string updatetblOrderItemsEE(clsBulkOrderML prp)
        {
            string err = "";
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@OrderReferenceNo", prp.partnerOrderId);
                cmd2.Parameters.AddWithValue("@SymantecOrderId", prp.SymantecOrderId);
                cmd2.Parameters.AddWithValue("@Pkcs", prp.Pkcs);
                cmd2.Parameters.AddWithValue("@x509", prp.x509);
                cmd2.Parameters.AddWithValue("@ItemStatus", prp.OrderStatus);
                cmd2.Parameters.AddWithValue("@SubmittedDate", prp.SubmittedDate);
                cmd2.Parameters.AddWithValue("@CertificateSerialNumber", prp.CertificateSerialNumber);
                cmd2.CommandText = "prc_updateBulk_tblOrderItemsEE";
                cmd2.ExecuteNonQuery();

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
            return err;
        }
        public string update_status_tblBulkOrderRequest(clsBulkOrderML prp)
        {
            string err = "";
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@PartnerBulkId", prp.PartnerBulkId);
                cmd2.Parameters.AddWithValue("@OrderStatus", prp.OrderStatus);
                cmd2.CommandText = "prc_update_status_tblBulkOrderRequest";
                cmd2.ExecuteNonQuery();

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
            return err;
        }
    }
}

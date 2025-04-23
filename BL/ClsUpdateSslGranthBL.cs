using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DL;
using ML;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BL
{
    public class ClsUpdateSslGranthBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public string UpdateSslGranth(ClsUpdateSslGranthML obj)
        {
            string retmsg = "true";
            try
            {
                con.Open();
                BaseCommon common = new BaseCommon();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@sslGRanthID", obj.sslGRanthID);
                cmd1.Parameters.AddWithValue("@Sale_Value", obj.Sale_Value);
                cmd1.Parameters.AddWithValue("@GST_18", obj.GST_18);
                cmd1.Parameters.AddWithValue("@Total_Value", obj.Total_Value);
                cmd1.Parameters.AddWithValue("@TP_Val_INR", obj.TP_Val_INR);
                cmd1.Parameters.AddWithValue("@Profit", obj.Profit);
                cmd1.Parameters.AddWithValue("@Percent_On_Sale", obj.Percent_On_Sale);
                cmd1.Parameters.AddWithValue("@PO_No", obj.PO_No);
                cmd1.Parameters.AddWithValue("@Billing_Name", obj.Billing_Name);
                cmd1.Parameters.AddWithValue("@JNR_Bill_Number", obj.JNR_Bill_Number);
                cmd1.Parameters.AddWithValue("@SymantecInvoiceNo", obj.SymantecInvoiceNo);
                cmd1.Parameters.AddWithValue("@Dispatch_details", obj.Dispatch_details);
                cmd1.Parameters.AddWithValue("@DDate", obj.DDate);
                cmd1.Parameters.AddWithValue("@ServiceAmount", obj.ServiceAmount);
                cmd1.Parameters.AddWithValue("@Total_Net_Value", obj.Total_Net_Value);
                cmd1.CommandText = "prc_update_tblsslgranth";

                if (cmd1.ExecuteNonQuery() < 0)
                {
                 retmsg= "false";
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                retmsg= "false";
            }
            finally
            {
                con.Close();


            }
            return retmsg;
        }

      
    }
}

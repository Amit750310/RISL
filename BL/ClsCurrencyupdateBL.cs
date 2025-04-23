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
    public class ClsCurrencyupdateBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public DataTable GetCurrencyList()
        {
            BaseCommon bc = new BaseCommon();
            return bc.GetDatatable("Prc_getAll_Currency", CommandType.Text);
        }

        public string UpdateCurrencyLIst(ClsCurrencyupdateML[] child)
        {
            string err = "";
            try
            {
                con.Open();
                foreach (ClsCurrencyupdateML prp in child)
                {

                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ID", prp.ID);
                    cmd2.Parameters.AddWithValue("@Value", prp.Value);
                    cmd2.Parameters.AddWithValue("@ModifiedBy", prp.ModifiedBy);
                    cmd2.CommandText = "Prc_Update_currency";
                    cmd2.ExecuteNonQuery();
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
            return err;
        }
    }
}

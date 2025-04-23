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
   public class ClsDevicePartCodeMappingBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Dropdownlist()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_DeviceFordrd", CommandType.StoredProcedure);
            return dt;
        }
        public string Insertcategory(ClsDevicePartCodeMappingML obj)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@DName", obj.Name);
            cmd.Parameters.AddWithValue("@PartCode", obj.PartCode);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.CommandText = "Prc_Insert_DevicePartCodemaster";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
        public DataTable Getallcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_DevicePArtcode", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetSingle(string id)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("Prc_Get_single_DevicePArtcode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                err = ex.Message;

                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);


            }

            return ds;
        }

    }
}

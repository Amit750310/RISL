
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class ClsDeviceMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Getallcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_Device", CommandType.StoredProcedure);
            return dt;
        }
        public string Insertcategory(ClsDeviceMasterML obj)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.CommandText = "Prc_Insert_Device_master";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
    }
}

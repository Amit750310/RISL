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
    public class ClsBrandMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Getallbrand()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_brand", CommandType.StoredProcedure);
            return dt;
        }
        public string InsertBarnd(ClsBrandMasterML obj)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BrandID", obj.BrandID);
            cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@Orderby", obj.Orderby);
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.CommandText = "Prc_Insert_brand_master";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
    }
}

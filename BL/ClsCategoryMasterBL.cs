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
    public class ClsCategoryMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Getallcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_category", CommandType.StoredProcedure);
            return dt;
        }
        public string Insertcategory(ClsCategoryMasterML obj)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Category_ID", obj.Category_ID);
            cmd.Parameters.AddWithValue("@categoryName", obj.categoryName);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.CommandText = "Prc_Insert_category_master";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
    }
}

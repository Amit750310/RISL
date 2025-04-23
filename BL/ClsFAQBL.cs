using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using System.Data;
using DL;
using System.Data.SqlClient;

namespace BL
{
    public class ClsFAQBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable GetallFAQ()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_GetAll_FAQ_Web", CommandType.StoredProcedure);
            return dt;
        }
        public string InsertFAQ(ClsFAQML obj)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FAQID", obj.FAQID);
            cmd.Parameters.AddWithValue("@Question", obj.Question);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@Answer", obj.Answer);
            cmd.Parameters.AddWithValue("@Mode", obj.Mode);
            cmd.CommandText = "Prc_insert_FAQ_Web";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
    }
}

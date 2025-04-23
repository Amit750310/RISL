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
    public class ClsSubCategoryMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Getallsubcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_subcategory", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable Getallsubcategory(string category_id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Category_ID", category_id);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_subcategory", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public string Insertsubcategory(ClsSubCategoryMasterML obj)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subCategory_ID", obj.SubCategory_ID);
            cmd.Parameters.AddWithValue("@Category_ID", obj.Category_ID);
            cmd.Parameters.AddWithValue("@subcategoryName", obj.SubcategoryName);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.CommandText = "Prc_Insert_sub_category_master";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
    }
}

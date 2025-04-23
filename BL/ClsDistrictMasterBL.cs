
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
    public class ClsDistrictMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Getallsubcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_district", CommandType.StoredProcedure);
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
        public string Insertsubcategory(ClsDistrictMasterML obj)
        {
            con.Open();
            try
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Distict_ID", obj.Distict_ID);
                cmd.Parameters.AddWithValue("@State_ID", obj.State_ID);
                cmd.Parameters.AddWithValue("@DistrictName", obj.DistrictName);
                cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                cmd.Parameters.AddWithValue("@mode", obj.mode);
                cmd.CommandText = "Prc_Insert_distict_master";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {

                return err;
            }
            finally
            {
                con.Close();


            }
            return err;
        }

        public string Deletesubcategory(string distict)
        {
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Distict_ID", Stateid);
              cmd.Parameters.AddWithValue("@Distict_ID", distict);
                cmd.CommandText = "Prc_Delete_distict_master";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {

                return err;
            }
            finally
            {
                con.Close();


            }
            return err;
        }
    }
}

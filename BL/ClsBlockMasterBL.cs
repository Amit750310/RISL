
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BL
{
    public class ClsBlockMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public void fill_Internal_State(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "DDState1", CommandType.StoredProcedure);
        }
        public void fill_Internal_district(ref DropDownList Xddl, string DistrictID)
        {
            SqlParameter[] parameters =
        {
        new SqlParameter("Statid", SqlDbType.VarChar, 50)
         };

            parameters[0].Value = DistrictID;
            BaseCommon.FillDropDown(ref Xddl, "DDDistict1", CommandType.StoredProcedure, parameters);
        }

        public DataTable Getallsubcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_Block", CommandType.StoredProcedure);
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
        public string Insertsubcategory(ClsBlockMasterML obj)
        {
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@State_ID", obj.State_ID);
                cmd.Parameters.AddWithValue("@DistrictID", obj.DistrictID);
                cmd.Parameters.AddWithValue("@StateName", obj.StateName);
                cmd.Parameters.AddWithValue("@DistrictName", obj.DistrictName);
                cmd.Parameters.AddWithValue("@BlockName", obj.BlockName);
                cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                cmd.Parameters.AddWithValue("@mode", obj.mode);
                cmd.CommandText = "InsertUpdateBlock";
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


        public string DeleteBlock(string ID)
        {
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.CommandText = "deleteBlock";
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


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
    public class PhoneDirectoryBL
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
            BaseCommon.FillDropDown(ref Xddl, "DDDistict12", CommandType.StoredProcedure, parameters);
        }
        public void fill_Internal_Block(ref DropDownList Xddl, string DistrictID, string Id)
        {
            SqlParameter[] parameters =
        {
        new SqlParameter("Statid", SqlDbType.VarChar, 50),
         new SqlParameter("ID", SqlDbType.VarChar, 50)
         };

            parameters[0].Value = DistrictID;
            parameters[1].Value = Id;
            BaseCommon.FillDropDown(ref Xddl, "DDBlock1", CommandType.StoredProcedure, parameters);
        }

        public string InsertEmployee(PhoneDirectoryML obj)
        {
            try
            {
                con.Open();
                BaseCommon common = new BaseCommon();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Id", obj.ID);
               // cmd1.Parameters.AddWithValue("@State", obj.State);
               // cmd1.Parameters.AddWithValue("@StateName", obj.StateName);
               // cmd1.Parameters.AddWithValue("@DistrictID", obj.DistrictID);
                cmd1.Parameters.AddWithValue("@Districtname", obj.Districtname);
               // cmd1.Parameters.AddWithValue("@BlockID", obj.BlockID);
                cmd1.Parameters.AddWithValue("@BlockName", obj.BlockName);
                cmd1.Parameters.AddWithValue("@OfficeName", obj.OfficeName);
                cmd1.Parameters.AddWithValue("@Description", obj.Description);
                cmd1.Parameters.AddWithValue("@Extension", obj.Extension);
                cmd1.Parameters.AddWithValue("@Department", obj.Department);
                cmd1.Parameters.AddWithValue("@OfficeLocation", obj.OfficeLocation);
                cmd1.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                cmd1.Parameters.AddWithValue("@ModifiedBy", obj.ModifiedBy);
                cmd1.Parameters.AddWithValue("@mode", obj.mode);
                cmd1.CommandText = "Insert_PhoneRepositry";
                if (cmd1.ExecuteNonQuery() < 0)
                {
                    return "false";
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
            return obj.ID;
        }

        public void fill_Employee_List(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Select_Employee_list", CommandType.Text);
        }
        public void fillgetallLevel(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "prc_getallLevel", CommandType.Text);
        }
        public DataTable fillgetallLevel()
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("GetAllPhoneDirectry", con);
                cmd.CommandType = CommandType.StoredProcedure;
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

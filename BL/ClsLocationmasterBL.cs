
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
    public class ClsLocationmasterBL
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
        public void fill_Internal_Block(ref DropDownList Xddl, string DistrictID,string Id)
        {
            SqlParameter[] parameters =
        {
        new SqlParameter("Statid", SqlDbType.VarChar, 50),
         new SqlParameter("ID", SqlDbType.VarChar, 50)
         };

            parameters[0].Value = DistrictID;
            parameters[1].Value = Id;
            BaseCommon.FillDropDown(ref Xddl, "DDBlock", CommandType.StoredProcedure, parameters);
        }

        public string InsertEmployee(ClsLocationmasterML obj)
        {
            try
            {
                con.Open();
                BaseCommon common = new BaseCommon();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Id", obj.ID);
                //cmd1.Parameters.AddWithValue("@Location_Name", obj.Location_Name);
                cmd1.Parameters.AddWithValue("@Address", obj.Address);
                //cmd1.Parameters.AddWithValue("@Address1", obj.Address1);
                cmd1.Parameters.AddWithValue("@City", obj.City);
                cmd1.Parameters.AddWithValue("@State", obj.State);
                cmd1.Parameters.AddWithValue("@District", obj.District);
                cmd1.Parameters.AddWithValue("@PINCode", obj.PINCode);
                //cmd1.Parameters.AddWithValue("@Contact_Person", obj.Contact_Person);
                //cmd1.Parameters.AddWithValue("@Contact_Number", obj.Contact_Number);
                cmd1.Parameters.AddWithValue("@Department", obj.Department);
                cmd1.Parameters.AddWithValue("@Display_Name", obj.Display_Name);
                cmd1.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                //cmd1.Parameters.AddWithValue("@Ucode", obj.Ucode);
                cmd1.Parameters.AddWithValue("@ModifiedBy", obj.ModifiedBy);
                cmd1.Parameters.AddWithValue("@mode", obj.mode);
                cmd1.CommandText = "Insert_LocationMaster";

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
                cmd = new SqlCommand("GetAllLocation", con);
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

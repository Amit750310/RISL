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
    public class ClsPageDetailBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public void fill_pagename_Drop(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Filldropdown_PageName", CommandType.Text);
        }
        public string InsertPageDetails(ClsPageDetailML obj)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Page_id", obj.Page_id);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            cmd.Parameters.AddWithValue("@Type", obj.Type);
            cmd.Parameters.AddWithValue("@Image_Path", obj.Image_Path);
            cmd.Parameters.AddWithValue("@Mode", obj.Mode);
            cmd.CommandText = "Prc_InsertPageDetail_Web";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
        public DataTable GetPageDetails_Pagewises(string page_id)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Page_id", page_id);

            return bc.GetDatatable("Prc_GetPageDetail_Pagewise_Web", CommandType.StoredProcedure, objSqlParam);
        }
    }
}

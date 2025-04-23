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
    public class ClsSearchvendorProductBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        CommonConnection cc = new CommonConnection();
        SqlCommand cmd;
        SqlTransaction lSqlTran;
        BaseCommon common = new BaseCommon();
        public bool InsertProductSearchVendors(ClsSearchVendorProductML obj)
        {
            try
            {
                con.Open();
            
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@FromEmailId", obj.FromEmailId);
                cmd1.Parameters.AddWithValue("@ToEmailids", obj.ToEmailids);
                cmd1.Parameters.AddWithValue("@Subjects", obj.Subjects);
                cmd1.Parameters.AddWithValue("@Products", obj.Products);
                cmd1.Parameters.AddWithValue("@EmailBodys", obj.EmailBodys);
                cmd1.Parameters.AddWithValue("@HasAttachment", obj.HasAttachment);
                cmd1.Parameters.AddWithValue("@AttachmentPath", obj.AttachmentPath);
                cmd1.Parameters.AddWithValue("@CREATED_BY", obj.CREATED_BY);
               
                cmd1.CommandText = "Insert_VendorProductSearch";

                if (cmd1.ExecuteNonQuery() < 0)
                {
                 
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return false;
            }
            finally
            {
                con.Close();


            }
            return true;
        }
        public DataTable getSearchProductLIST(string subcategoryname)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@subcategoryname", subcategoryname);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_GetSearchProductLIST", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
      


       

    }
   
}

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
   public  class RequestMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable Getallcategory()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_OrderDetail", CommandType.StoredProcedure);
            return dt;
        }

        public string InsertOrderDeatils(FirstModel obj)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                // cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@DepartmentName", obj.deptNAme);
                cmd.Parameters.AddWithValue("@DepartmentID", obj.deptNAmeid);
                cmd.Parameters.AddWithValue("@ToEmail", obj.TO);
                cmd.Parameters.AddWithValue("@Refrence", obj.Ref);
                cmd.Parameters.AddWithValue("@InformationEmail", obj.information);
                cmd.Parameters.AddWithValue("@ProjectOICNAme", obj.OICNAme);
                cmd.Parameters.AddWithValue("@Subject", obj.Subject);
                cmd.Parameters.AddWithValue("@Fileno", obj.Fileno);
                cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                cmd.Parameters.Add("@OID", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.CommandText = "insertOrderDetail";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
                string retrievedEmpId = cmd.Parameters["@OID"].Value.ToString();
                return retrievedEmpId;

            }
            catch (Exception ex)
            {
                string m = ex.Message;
                return m;
            }
            finally
            {
                con.Close();
            }

        }

        public string InsertOrderDeatils1(ServiceItem obj)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@Oid", obj.Oid);
                cmd.Parameters.AddWithValue("@ServiceType", obj.ServiceType);
                cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
                cmd.Parameters.AddWithValue("@UnitCost", obj.UnitCost);
                cmd.Parameters.AddWithValue("@Discription_of_work", obj.Description);
                cmd.Parameters.AddWithValue("@TotalAmount", obj.TotalAmount);
                cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                cmd.CommandText = "Prc_inserttblOrderItemDetail";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
                return "true";
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                return m;
            }

        }

    }




}

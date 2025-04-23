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
    public class ClsemployeemasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public string InsertEmployee(ClsEmployemasterML obj)
        {
            try
            {
                con.Open();
                BaseCommon common = new BaseCommon();
                string PASSWORD = common.Base64Encode(obj.PASSWORD);
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@emp_Id", obj.ID);
                cmd1.Parameters.AddWithValue("@Employee_code", obj.EMP_CODE);
                cmd1.Parameters.AddWithValue("@First_Name", obj.First_Name);
                cmd1.Parameters.AddWithValue("@Last_Name", obj.Last_Name);
                cmd1.Parameters.AddWithValue("@Email_Id", obj.MAILID);
                cmd1.Parameters.AddWithValue("@Password", PASSWORD);
                cmd1.Parameters.AddWithValue("@mobile", obj.MOBILE_NO);
                cmd1.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd1.Parameters.AddWithValue("@Date_Of_Birth", obj.DOB);
                cmd1.Parameters.AddWithValue("@Date_Of_Joining", obj.DOJ);
                cmd1.Parameters.AddWithValue("@Gender", obj.Gender);
                cmd1.Parameters.AddWithValue("@Address", obj.Address);
                cmd1.Parameters.AddWithValue("@mode", obj.mode);
                cmd1.Parameters.AddWithValue("@role_Id", obj.role_Id);
                cmd1.Parameters.AddWithValue("@HiLevel", obj.HiLevel);
                cmd1.CommandText = "Insert_Employee";
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
            return obj.EMP_CODE;
        }

        public void fill_Employee_List(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Select_Employee_list", CommandType.Text);
        }
        public void fillgetallLevel(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "prc_getallLevel", CommandType.Text);
        }
        public DataSet fillgetallLevel()
        {
            DataSet ds = new DataSet();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("prc_getallLevel", con);
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

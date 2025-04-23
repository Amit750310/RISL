using DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls;
using ML;

namespace BL
{
    public class ClshierarchyLevelBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        

        public DataTable getempwithLevel()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_getempwithLevel", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable delete_hilevelRights()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_delete_tblhilevelRights", CommandType.StoredProcedure);
            return dt;
        }
        public DataTable getempwithLevelRights(ClshierarchyLevelML prp)
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@emp_id", prp.Emp_Id);
            dt = bc.GetDatatable("prc_getempwithLevelRights", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public string insert_tblhilevelRights(ClshierarchyLevelML[] child)
        {
            int i = 0;
           
            string err = "";
            try
            {
                con.Open();
                foreach (ClshierarchyLevelML prp in child)
                {
                   
                    try
                    {
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@Emp_Id", prp.Emp_Id);
                        cmd2.Parameters.AddWithValue("@childemp_id", prp.childemp_id);
                        cmd2.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                        cmd2.CommandText = "prc_insert_tblhilevelRights";
                        cmd2.ExecuteNonQuery();
                        i = i + 1;
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                        DL.BaseCommon objerr = new DL.BaseCommon();
                        objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                        return "false";
                    }
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
            return err + i.ToString();
        }
    }
}

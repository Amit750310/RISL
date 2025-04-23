using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsDashboardBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public DataTable GetLeadCounter(string empid, string Level)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@Emp_code", empid);
            objSqlParam[1] = new SqlParameter("@type", Level);
            return bc.GetDatatable("Prc_GetDashboard", CommandType.StoredProcedure, objSqlParam);
        }



        public DataSet districtCount( string project)
        {
            DataSet ds = new DataSet();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("DistrictWise", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@projectName", project);
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

        public DataSet DashboradCount(string Projectname)
        {

            DataSet ds = new DataSet();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("StatusCount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@projectName", Projectname);
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

        public void bindprojet(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "Prc_drdBindProject", CommandType.StoredProcedure);
        }

        public DataSet DashboradCount1( string Projectname)
        {

            DataSet ds = new DataSet();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("totalCount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@projectName", Projectname);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DL;
using ML;

namespace BL
{
    public class clsMenuMasterBL
    {

        SqlConnection con;
        string err = "";
        BaseCommon common = new BaseCommon();

        //Roll Master
        public DataSet getrollDetails(clsMenuMasterML prp)
        {

            DataSet ds = new DataSet();
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("PrcAllRollDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@rollName", prp.RollName);
                cmd.Parameters.Add("@Out_Error", SqlDbType.VarChar, 500);
                cmd.Parameters["@Out_Error"].Direction = ParameterDirection.Output;
                da.Fill(ds);
                err = Convert.ToString(cmd.Parameters["@Out_Error"].Value);
                return ds;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
            return ds;
        }
        public DataSet getsingleRoll(clsMenuMasterML prp)
        {
            DataSet ds = new DataSet();

            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("prc_getsingleRoll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RollId", prp.RollId);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return ds;
        }
        public DataSet UpdateRollMaster(clsMenuMasterML prp)
        {
            DataSet ds = new DataSet();
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("prc_updateRollMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RollId", prp.RollId);
                cmd.Parameters.AddWithValue("@RollName", prp.RollName);
                cmd.Parameters.AddWithValue("@active", prp.RollActive);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return ds;
        }
        public DataSet InsertRollMaster(clsMenuMasterML prp)
        {
            DataSet ds = new DataSet();
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("prc_insertRollmaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RollName", prp.RollName);
                cmd.Parameters.AddWithValue("@active", prp.RollActive);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return ds;
        }

        //Header Menu
        public DataSet getleftMenu(clsLeftsideML prp)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@loginEmpId", prp.loginEmpId == "" ? "0" : prp.loginEmpId);
                ds = common.GetDataSet("prc_getMenu", objSqlParam);
            }
            catch (Exception ex)
            {
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            return ds;

        }
        public DataSet getleftchildeMenu(clsLeftsidechiledmenuML prp)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@menuId", prp.menuId == "" ? "0" : prp.menuId);
                objSqlParam[1] = new SqlParameter("@loginEmpId", prp.loginEmpId == "" ? "0" : prp.loginEmpId);
                ds = common.GetDataSet("prc_getchildMenu_BM", objSqlParam);
            }
            catch (Exception ex)
            {
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            return ds;

        }

    }
}

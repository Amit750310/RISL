using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DL;
using ML;
using DL;
namespace BL
{
    public class clsRollMenuRelationBL
    {
        CommonConnection cc = new CommonConnection();
        SqlConnection con;
        SqlCommand cmd;
        string err;
        SqlTransaction lSqlTran;
        BaseCommon common = new BaseCommon();
        public DataSet fillserchmenu(string text)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@text", text);
                ds = common.GetDataSet("prc_search_menu", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        public DataSet fillSubMenu(string menuId)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@menuId", menuId);
                ds = common.GetDataSet("prc_getSubMenu", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        public string insertmenumast(clsMenuMasterML menuma)
        {

            string p_out = "";
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];
                objSqlParam[0] = new SqlParameter("@menuName", menuma.menuName == "" ? "0" : menuma.menuName);
                objSqlParam[1] = new SqlParameter("@menuImage", menuma.menuImage == "" ? "0" : menuma.menuImage);
                objSqlParam[2] = new SqlParameter("@menuTitle", menuma.menuTitle == "" ? "0" : menuma.menuTitle);
                objSqlParam[3] = new SqlParameter("@menuPage", menuma.menuPage == "" ? "0" : menuma.menuPage);
                objSqlParam[4] = new SqlParameter("@P_OUT", SqlDbType.VarChar, 500);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@childeStatus", menuma.childeStatus == "" ? "0" : menuma.childeStatus);
                common.GetDataSet("prc_insert_menu_master", objSqlParam);

                p_out = Convert.ToString(objSqlParam[4].Value);
            }
            catch (Exception ex)
            {

                throw;


            }
            finally
            {

            }
            return p_out;
        }
        public string insertSubmenumast(string menuId, string submenuName, string submenuImage, string submenuTitle, string submenuPage)
        {

            string p_out = "";
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];
                objSqlParam[0] = new SqlParameter("@menuId", menuId);
                objSqlParam[1] = new SqlParameter("@submenuName", submenuName);
                objSqlParam[2] = new SqlParameter("@submenuImage", submenuImage);
                objSqlParam[3] = new SqlParameter("@submenuTitle", submenuTitle);
                objSqlParam[4] = new SqlParameter("@submenuPage", submenuPage);

                objSqlParam[5] = new SqlParameter("@P_OUT", SqlDbType.VarChar, 500);
                objSqlParam[5].Direction = ParameterDirection.Output;


                common.GetDataSet("prc_insert_submenu_master", objSqlParam);

                p_out = Convert.ToString(objSqlParam[5].Value);
            }
            catch (Exception ex)
            {

                throw;


            }
            finally
            {

            }
            return p_out;
        }
        public DataSet fillrollmenurel(string rollid)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@rollid", rollid);
                ds = common.GetDataSet("prc_fetch_rolmenu_rel", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        public string insertusermenurelChild(clsmenulist[] clmenulist, string rollid, string addedby)
        {

            if (rollid != "")
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    con = new SqlConnection(Configuration.Connection);
                    con.Open();
                    lSqlTran = con.BeginTransaction();
                    foreach (clsmenulist prp in clmenulist)
                    {
                        cmd = new SqlCommand("prc_insert_user_Childmenu_rel", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = lSqlTran;
                        cmd.Parameters.AddWithValue("@menuid", prp.menuid == "" ? "0" : prp.menuid);
                        cmd.Parameters.AddWithValue("@mode", prp.mode == "" ? "0" : prp.mode);
                        cmd.Parameters.AddWithValue("@rollid", rollid);
                        cmd.Parameters.AddWithValue("@Addedby", addedby);

                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            lSqlTran.Rollback();

                        }


                    }
                    lSqlTran.Commit();
                }
                catch (Exception ex)
                {

                    //throw;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                    con.Dispose();
                }
            }
            return "";


        }
        public string insertusermenurel(clsmenulist[] clmenulist, string rollid, string addedby)
        {

            if (rollid != "")
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    con = new SqlConnection(Configuration.Connection);
                    con.Open();
                    lSqlTran = con.BeginTransaction();
                    foreach (clsmenulist prp in clmenulist)
                    {
                        cmd = new SqlCommand("prc_insert_user_menu_rel", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = lSqlTran;
                        cmd.Parameters.AddWithValue("@menuid", prp.menuid == "" ? "0" : prp.menuid);
                        cmd.Parameters.AddWithValue("@mode", prp.mode == "" ? "0" : prp.mode);
                        cmd.Parameters.AddWithValue("@rollid", rollid);
                        cmd.Parameters.AddWithValue("@Addedby", addedby);

                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            lSqlTran.Rollback();

                        }


                    }
                    lSqlTran.Commit();
                }
                catch (Exception ex)
                {

                    //throw;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                    con.Dispose();
                }
            }
            return "";


        }
        //fill menu
        public DataSet fillmenu()
        {

            DataSet ds = new DataSet();
            try
            {
                ds = common.GetDataSet("prc_menu_master");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        //fill childemenu
        public DataSet getchildeMenu(string menuId)
        {

            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@menuId", menuId);
                ds = common.GetDataSet("prc_getchildeMenu", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        public DataSet getrollSelectedMenu(string menuId, string rollid)
        {

            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@menuId", menuId);
                objSqlParam[1] = new SqlParameter("@rollid", rollid);
                ds = common.GetDataSet("prc_getrollSelectedMenu", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }

        public DataSet getRollselectedChildMenu(string childemenuid, string rollid)
        {

            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@childemenuid", childemenuid);
                objSqlParam[1] = new SqlParameter("@rollid", rollid);
                ds = common.GetDataSet("prc_getRollselectedChildMenu", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        public DataSet GetRoll()
        {
            DataSet ds = new DataSet();
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("PrcRollDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Out_Error", SqlDbType.VarChar, 500);
                cmd.Parameters["@Out_Error"].Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


                return ds;
            }
            catch (Exception ex)
            {
               
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                //throw;
            }
           
            return ds;
        }


    }
}

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
    public class ClsSearchvendorsBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        CommonConnection cc = new CommonConnection();
        SqlCommand cmd;
        SqlTransaction lSqlTran;
        BaseCommon common = new BaseCommon();
        public string Insertvendors(ClsvendorsML obj)
        {
            try
            {
                con.Open();
            
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Vendor_Id", obj.Vendor_Id);
                cmd1.Parameters.AddWithValue("@VendorName", obj.VendorName);
                cmd1.Parameters.AddWithValue("@MobileNo", obj.MobileNo);
                cmd1.Parameters.AddWithValue("@Email", obj.Email);
               
                cmd1.Parameters.AddWithValue("@PanNo", obj.PanNo);
     
                cmd1.Parameters.AddWithValue("@ContactPersonName", obj.ContactPersonName);
                cmd1.Parameters.AddWithValue("@GSTRegistrationNo", obj.GSTRegistrationNo);
                
                cmd1.Parameters.AddWithValue("@mode", obj.mode);
               
                cmd1.Parameters.Add("@Vendor_Id_out", SqlDbType.Int, 100);
                cmd1.Parameters["@Vendor_Id_out"].Direction = ParameterDirection.Output;


                cmd1.CommandText = "Insert_vendors";

                if (cmd1.ExecuteNonQuery() < 0)
                {
                 
                    return "false";
                }
                obj.Vendor_Id= Convert.ToString(cmd1.Parameters["@Vendor_Id_out"].Value);
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
            return obj.Vendor_Id;
        }
        public DataTable getSearchProductLIST(ClsSubCategoryMasterML prp)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@subcategoryname", prp.SubcategoryName);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_GetSearchProductLIST", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataSet fillrollmenurel(string vendorid)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@vendorid", vendorid);
                ds = common.GetDataSet("prc_fetch_vendorcategoryrelation", objSqlParam);


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

        public DataSet getvendorselectedCategory(string categoryid, string vendorid)
        {

            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@categoryid", categoryid);
                objSqlParam[1] = new SqlParameter("@vendorid", vendorid);
                ds = common.GetDataSet("prc_getvendorSelectedcategory", objSqlParam);


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
        public DataSet getvendorselectedSubCategory(string subcategoryid, string vendorid)
        {

            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@subcategoryid", subcategoryid);
                objSqlParam[1] = new SqlParameter("@vendorid", vendorid);
                ds = common.GetDataSet("prc_getvendorSelectedSubcategory", objSqlParam);


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
        public string insertvendorsubcategoryrelation(clsvendorcategorylist[] clslist, string vendorid, string addedby)
        {

            if (vendorid != "")
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    con = new SqlConnection(Configuration.Connection);
                    con.Open();
                    lSqlTran = con.BeginTransaction();
                    foreach (clsvendorcategorylist prp in clslist)
                    {
                        cmd = new SqlCommand("prc_insert_vendorsubcategoryrelation", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = lSqlTran;
                        cmd.Parameters.AddWithValue("@subcategoryid", prp.categoryid == "" ? "0" : prp.categoryid);
                        cmd.Parameters.AddWithValue("@mode", prp.mode == "" ? "0" : prp.mode);
                        cmd.Parameters.AddWithValue("@vendorid", vendorid);
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
        public string insertvendorcategoryrelation(clsvendorcategorylist[] clslist, string vendorid, string addedby)
        {

            if (vendorid != "")
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    con = new SqlConnection(Configuration.Connection);
                    con.Open();
                    lSqlTran = con.BeginTransaction();
                    foreach (clsvendorcategorylist prp in clslist)
                    {
                        cmd = new SqlCommand("prc_insert_vendorcategoryrelation", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = lSqlTran;
                        cmd.Parameters.AddWithValue("@categoryid", prp.categoryid == "" ? "0" : prp.categoryid);
                        cmd.Parameters.AddWithValue("@mode", prp.mode == "" ? "0" : prp.mode);
                        cmd.Parameters.AddWithValue("@vendorid", vendorid);
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


       

    }
   
}

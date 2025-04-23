
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
    public class ClsInventryMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";


        public void bindLOcation(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "Prc_drdBindLocation", CommandType.StoredProcedure);
        }
        public void bindprojet(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "Prc_drdBindProject", CommandType.StoredProcedure);
        }
        public void bindDevice(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "Prc_drdBindDevice", CommandType.StoredProcedure);
        }

        public void bindStatus(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "Prc_drdBindStatus", CommandType.StoredProcedure);
        }
        public void fill_Internal_State(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "DDState", CommandType.StoredProcedure);
        }

        public void fill_Internal_district(System.Web.UI.WebControls.DropDownList list)
        {
            DL.BaseCommon.FillDropDown(ref list, "DDDistrict", CommandType.StoredProcedure);
        }

        public void fill_Internal_State(ref DropDownList Xddl, string DistrictID)
        {
            SqlParameter[] parameters =
        {
        new SqlParameter("locationID", SqlDbType.VarChar, 50)
         };
            parameters[0].Value = DistrictID;
            BaseCommon.FillDropDown(ref Xddl, "LDDState", CommandType.StoredProcedure, parameters);
        }
        public void fill_Internal_district(ref DropDownList Xddl, string DistrictID)
        {
            SqlParameter[] parameters =
        {
        new SqlParameter("locationID", SqlDbType.VarChar, 50)
         };

            parameters[0].Value = DistrictID;
            BaseCommon.FillDropDown(ref Xddl, "LDDdistrict", CommandType.StoredProcedure, parameters);
        }

        public void fill_Internal_Partcode(ref DropDownList Xddl, string Devicename)
        {
            SqlParameter[] parameters =
        {
        new SqlParameter("@locationID", SqlDbType.VarChar, 50)
         };

            parameters[0].Value = Devicename;
            BaseCommon.FillDropDown(ref Xddl, "Partcode", CommandType.StoredProcedure, parameters);
        }

        public DataTable Getallcategory(string id)
            {
                DataTable ds = new DataTable();
                BaseCommon common = new BaseCommon();
                SqlCommand cmd;
                try
                {
                    err = "";
                    con = new SqlConnection(Configuration.Connection);
                    con.Open();
                    cmd = new SqlCommand("getinvertrydetailsforadmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
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


        public DataTable GetallcategoryVC(string id)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("getinvertrydetailsforadminVC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable Getallinventory()
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("getinvertrydetailsfordownLoad", con);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@id", id);
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


        public DataTable GetLocationByid(string locationid)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("LDDdistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@locationID", locationid);
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

        public DataTable GetRoll(string rollid)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("rollcheck", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rollcheck", rollid);
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

        public string Insertcategory(ClsInventryMasterML obj)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@InventoryDB", obj.InventoryDB);
            cmd.Parameters.AddWithValue("@ProjectID", obj.ProjectID);
            cmd.Parameters.AddWithValue("@LocationName", obj.LocationName);
            cmd.Parameters.AddWithValue("@SubLocation", obj.SubLocation);
            cmd.Parameters.AddWithValue("@DeviceType", obj.DeviceType);
            cmd.Parameters.AddWithValue("@PartCode", obj.PartCode);
            cmd.Parameters.AddWithValue("@SubComponentSerialNo", obj.SubComponentSerialNo);
            cmd.Parameters.AddWithValue("@PartDescription", obj.PartDescription);
            cmd.Parameters.AddWithValue("@HostName", obj.HostName);
            cmd.Parameters.AddWithValue("@IPAddress", obj.IPAddress);
            cmd.Parameters.AddWithValue("@Component", obj.Component);
            cmd.Parameters.AddWithValue("@SubComponent", obj.SubComponent);
            cmd.Parameters.AddWithValue("@ComponentSerialNo", obj.ComponentSerialNo);
            cmd.Parameters.AddWithValue("@ContactName", obj.ContactName);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@District", obj.District);
            cmd.Parameters.AddWithValue("@PinCode", obj.PinCode);
            cmd.Parameters.AddWithValue("@SupportType", obj.SupportType);
            cmd.Parameters.AddWithValue("@SupportStart", obj.SupportStart);
            cmd.Parameters.AddWithValue("@SupportEndDate", obj.SupportEndDate);
            cmd.Parameters.AddWithValue("@OEMSupport", obj.OEMSupport);
            cmd.Parameters.AddWithValue("@OEMStartDate", obj.OEMStartDate);
            cmd.Parameters.AddWithValue("@OEMEndDate", obj.OEMEndDate);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@Verification", obj.Verification);
            cmd.Parameters.AddWithValue("@VerificationDate", obj.VerificationDate);
            cmd.Parameters.AddWithValue("@FileUploade", obj.FileUploade);
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.CommandText = "insertinventry";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }

        public string GetMergetable()
        {
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("InsertOrUpdateInventoryLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rettype", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@rettype"].Value.ToString();

                return result;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                common.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }

            return null;
        }

        public DataTable GetHistory(string ID)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("Prc_GetHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
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

        public DataTable SearchForDownload(string Text)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("searchBaseDownload", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Text);
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


        public DataTable GetPartcodeByid(string Devicename)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("Partcode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@locationID", Devicename);
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


        public DataTable GetReports(string id)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("forreports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable GetallcategoryExternal(string id)
        {
            DataTable ds = new DataTable();
            BaseCommon common = new BaseCommon();
            SqlCommand cmd;
            try
            {
                err = "";
                con = new SqlConnection(Configuration.Connection);
                con.Open();
                cmd = new SqlCommand("getinvertrydetailsforExternal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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


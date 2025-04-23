using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DL;
using ML;
using System.Data;
using System.Web.UI.WebControls;

namespace BL
{
    public class ClsCustomerConvertBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        #region All Drop Down List 
        public void fill_currency_Drop(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_filldropdown_currency", CommandType.Text);
        }

        public void fill_country_list(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "fill_country_list", CommandType.Text);
            try
            {
                string selectedvalue = BaseCommon.GetDataSet("Prc_get_selectedCountry", CommandType.Text).Tables[0].Rows[0][0].ToString();
                Xddl.SelectedValue = selectedvalue;

            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
               
            }

        }
        public void fill_OrganizationName(ref DropDownList Xddl, string AddedBy)
        {


            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon.FillDropDown(ref Xddl, "prc_select_tblLeadorganizationInfo", CommandType.StoredProcedure, objSqlParam);
        }
        public void fillCityLIST(ref DropDownList Xddl, string state)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@stateId", state);
            BaseCommon.FillDropDown(ref Xddl, "getCity_LIST", CommandType.StoredProcedure, objSqlParam);
        }


        public void fillStateList(ref DropDownList Xddl, string country)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@country", country);
            BaseCommon.FillDropDown(ref Xddl, "SelectState_List", CommandType.StoredProcedure, objSqlParam);
        }

        #endregion
     


        #region Select Lead Details 
        public DataTable select_single_tblLeadorganizationInfo(string OrgInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblLeadorganizationInfo", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblLeadorganizationAddress(string OrgInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblLeadorganizationAddress", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable select_single_tblLeadorganizationReseller(string OrgInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_Lead_tblLeadResellerInfo", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblLeadContact(string OrgInfoID, string AddedBy)
        {

            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblLeadContact", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }


        public DataTable getPENDINGCustomerList(string Emp_code, string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_pending_Convert_toCustomer_lead", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        #endregion
        public DataTable getAllCustomerList(string Emp_code,string Level,string Organisation,string Customertype,string salesPerson,string statename)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[6];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            objSqlParam[2] = new SqlParameter("@Organisation", Organisation);
            objSqlParam[3] = new SqlParameter("@Customertype", Customertype);
            objSqlParam[4] = new SqlParameter("@salesPerson", salesPerson);
            objSqlParam[5] = new SqlParameter("@statename", statename);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_All_Customer_list", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable getsaslesPerson(string Emp_code)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_getsalesPerson", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataSet getCustomerDet(string CustInfoID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            BaseCommon bc = new BaseCommon();
            ds = bc.GetDataSet("prc_getCustomerDet", CommandType.StoredProcedure, objSqlParam);
            return ds;
        }

        #region Fill Customer  For Updation
        public DataTable select_single_tblCustomerInfo(string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerInfo", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblCustomerAddress(string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerAddress", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable select_single_tblCustomerAddressDetails(string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerAddressDetails", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable select_single_tblCustomerReseller(string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_Customer_tblLeadResellerInfo", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblCustomerContact(string CustInfoID, string AddedBy)
        {

            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerContact", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        #endregion
    }
}


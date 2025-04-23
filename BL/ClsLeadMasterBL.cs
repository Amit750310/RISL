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
    public class ClsLeadMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public void fill_currency_Drop(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_filldropdown_currency", CommandType.Text);
        }
        public void fill_brand_Drop(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_dropdown_Brand_Master", CommandType.Text);
        }
        public void fill_Product_Drop(ref DropDownList Xddl, string Brand)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Brandid", Brand);
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_dropdown_Product_Master", CommandType.StoredProcedure, objSqlParam);

        }
        public void fill_ProductReport_Drop(ref DropDownList Xddl, string Brand)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Brandid", Brand);
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_dropdown_ProductReport_Master", CommandType.StoredProcedure, objSqlParam);

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
        public void fill_ResellerName(ref DropDownList Xddl, string AddedBy)
        {


            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon.FillDropDown(ref Xddl, "prc_select_tblLeadResellerInfo", CommandType.StoredProcedure, objSqlParam);
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
        public DataTable FillPrice(string prodid)
        {

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@ProductId", prodid);
            BaseCommon bc = new BaseCommon();
            return bc.GetDatatable("prc_getProductPrice", CommandType.StoredProcedure, objSqlParam);
        }
        public DataSet SelectSingleproposal(string QuoteNo)
        {
            ClsProposalBL dal = new ClsProposalBL();
            return dal.SelectSingleproposal(QuoteNo);
        }

        public string InsertLeadMaster(clstblLeadorganizationInfoML objtblLeadorganizationInfo, clstblLeadResellerInfoML objtblLeadResellerInfo,
        clstblLeadorganizationAddressML objtblLeadorganizationAddress,
        clstblLeadContactML[] objtblLeadContact, clstblLeadInfoML[] objtblLeadinfo, clstblLeadRemarksML objtblleadremarks)
        {
            string OrgInfoID = "";
            try
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgInfoID", SqlDbType.BigInt);
                cmd.Parameters["@OrgInfoID"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@OrganizationName", objtblLeadorganizationInfo.OrganizationName);
                cmd.Parameters.AddWithValue("@CustomerType", objtblLeadorganizationInfo.CustomerType);
                cmd.Parameters.AddWithValue("@ContactType", objtblLeadorganizationInfo.ContactType);
                cmd.Parameters.AddWithValue("@OrgGroup", objtblLeadorganizationInfo.OrgGroup);
                cmd.Parameters.AddWithValue("@AddedBy", objtblLeadorganizationInfo.AddedBy);
                cmd.Parameters.AddWithValue("@Currency_id", objtblLeadorganizationInfo.Currency_id);
                cmd.CommandText = "prc_insert_tblLeadorganizationInfo";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
                OrgInfoID = Convert.ToString(cmd.Parameters["@OrgInfoID"].Value);

                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.StoredProcedure;
                cmd0.Parameters.AddWithValue("@OrgInfoID", OrgInfoID);
                cmd0.Parameters.AddWithValue("@ResellerName", objtblLeadResellerInfo.ResellerName);
                cmd0.Parameters.AddWithValue("@ResellerGroup", objtblLeadResellerInfo.ResellerGroup);
                cmd0.Parameters.AddWithValue("@VendorCode", objtblLeadResellerInfo.VendorCode);
                cmd0.Parameters.AddWithValue("@CountryCode", objtblLeadResellerInfo.CountryCode);
                cmd0.Parameters.AddWithValue("@State", objtblLeadResellerInfo.State);
                cmd0.Parameters.AddWithValue("@City", objtblLeadResellerInfo.City);
                cmd0.Parameters.AddWithValue("@Address1", objtblLeadResellerInfo.Address1);
                cmd0.Parameters.AddWithValue("@Address2", objtblLeadResellerInfo.Address2);
                cmd0.Parameters.AddWithValue("@PostalCode", objtblLeadResellerInfo.PostalCode);
                cmd0.Parameters.AddWithValue("@Landline", objtblLeadResellerInfo.Landline);
                cmd0.Parameters.AddWithValue("@Companywebsite", objtblLeadResellerInfo.Companywebsite);
                cmd0.Parameters.AddWithValue("@AddedBy", objtblLeadResellerInfo.AddedBy);
                cmd0.CommandText = "prc_inserrt_tblLeadResellerInfo";
                cmd0.ExecuteNonQuery();


                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@OrgInfoID", OrgInfoID);
                cmd1.Parameters.AddWithValue("@CountryCode", objtblLeadorganizationAddress.CountryCode);
                cmd1.Parameters.AddWithValue("@State", objtblLeadorganizationAddress.State);
                cmd1.Parameters.AddWithValue("@City", objtblLeadorganizationAddress.City);
                cmd1.Parameters.AddWithValue("@Address1", objtblLeadorganizationAddress.Address1);
                cmd1.Parameters.AddWithValue("@Address2", objtblLeadorganizationAddress.Address2);
                cmd1.Parameters.AddWithValue("@PostalCode", objtblLeadorganizationAddress.PostalCode);
                cmd1.Parameters.AddWithValue("@Landline", objtblLeadorganizationAddress.Landline);
                cmd1.Parameters.AddWithValue("@Companywebsite", objtblLeadorganizationAddress.Companywebsite);
                cmd1.Parameters.AddWithValue("@VendorCode", objtblLeadorganizationAddress.VendorCode);
                cmd1.Parameters.AddWithValue("@AddedBy", objtblLeadorganizationAddress.AddedBy);
                cmd1.CommandText = "prc_insert_tblLeadorganizationAddress";
                cmd1.ExecuteNonQuery();



                

                foreach (clstblLeadContactML prp in objtblLeadContact)
                {

                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@OrgInfoID", OrgInfoID);
                    cmd2.Parameters.AddWithValue("@Name", prp.Name);
                    cmd2.Parameters.AddWithValue("@Designation", prp.Designation);
                    cmd2.Parameters.AddWithValue("@MobileNo", prp.MobileNo);
                    cmd2.Parameters.AddWithValue("@Email", prp.Email);
                    cmd2.Parameters.AddWithValue("@IsActive", prp.IsActive);
                    cmd2.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                    cmd2.CommandText = "prc_insert_tblLeadContact";
                    cmd2.ExecuteNonQuery();
                }

                foreach (clstblLeadInfoML prp in objtblLeadinfo)
                {

                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@OrgInfoID", OrgInfoID);
                    cmd2.Parameters.AddWithValue("@ProductID", prp.ProductID);
                    cmd2.Parameters.AddWithValue("@BrandID", prp.BrandID);
                    cmd2.Parameters.AddWithValue("@ModeOfLead", prp.ModeOfLead);
                    cmd2.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                    cmd2.CommandText = "prc_insert_tblLeadInfo";
                    cmd2.ExecuteNonQuery();
                }

                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@OrgInfoID", OrgInfoID);
                cmd3.Parameters.AddWithValue("@Remarks", objtblleadremarks.Remarks);
                cmd3.Parameters.AddWithValue("@VisitingCard", objtblleadremarks.VisitingCard);
                cmd3.Parameters.AddWithValue("@VisitingCardPath", objtblleadremarks.VisitingCardPath);
                cmd3.Parameters.AddWithValue("@AddedBy", objtblleadremarks.AddedBy);
                cmd3.Parameters.AddWithValue("@CommonName", objtblleadremarks.CommonName);
                cmd3.CommandText = "prc_insert_tblLeadRemarks";
                cmd3.ExecuteNonQuery();


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
            return OrgInfoID;
        }


        public bool UpdateLeadStatus(clstblLeadUpdationML obj, clsPlaceOrderAddressDetailsML[] objtblcustomeradddetail)
        {
            try
            {
                con.Open();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
                cmd1.Parameters.AddWithValue("@LeadStatus", obj.LeadStatus);
                cmd1.Parameters.AddWithValue("@REMARKS", obj.Remarks);
                cmd1.Parameters.AddWithValue("@SanName", obj.SanName);
                cmd1.Parameters.AddWithValue("@NextActionDate", obj.NextActionDate);
                cmd1.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
                cmd1.Parameters.AddWithValue("@Enrolment_Sheet", obj.Enrolment_Sheet);
                cmd1.Parameters.AddWithValue("@Enrolment_Sheet_path", obj.Enrolment_Sheet_path);
                cmd1.Parameters.AddWithValue("@Csr_Txt", obj.Csr_Txt);
                cmd1.Parameters.AddWithValue("@Csr_Txt_path", obj.Csr_Txt_path);
                cmd1.Parameters.AddWithValue("@PO_File", obj.PO_File);
                cmd1.Parameters.AddWithValue("@PO_File_path", obj.PO_File_path);
                cmd1.Parameters.AddWithValue("@GSTNNumber", obj.GSTNNumber);
                cmd1.Parameters.AddWithValue("@isPoPending", obj.isPoPending);
                cmd1.Parameters.AddWithValue("@isTrail", obj.isTrail);
                
                cmd1.CommandText = "prc_insert_tblLeadUpdation";

                if (cmd1.ExecuteNonQuery() < 0)
                {
                    return false;
                }
                foreach (clsPlaceOrderAddressDetailsML prp in objtblcustomeradddetail)
                {
                    SqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@Type", prp.Type);
                    cmd4.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
                    cmd4.Parameters.AddWithValue("@Cor_Legal_Name", prp.Cor_Legal_Name);
                    cmd4.Parameters.AddWithValue("@DBA_Name", prp.DBA_Name);
                    cmd4.Parameters.AddWithValue("@Division", prp.Division);
                    cmd4.Parameters.AddWithValue("@DUNS", prp.DUNS);
                    cmd4.Parameters.AddWithValue("@Fax", prp.Fax);
                    cmd4.Parameters.AddWithValue("@First_name", prp.First_name);
                    cmd4.Parameters.AddWithValue("@Last_name", prp.Last_name);
                    cmd4.Parameters.AddWithValue("@Title", prp.Title);
                    cmd4.Parameters.AddWithValue("@Add_Email", prp.Add_Email);
                    cmd4.Parameters.AddWithValue("@Add_Contact", prp.Add_Contact);
                    cmd4.Parameters.AddWithValue("@Comp_Name", prp.Comp_Name);
                    cmd4.Parameters.AddWithValue("@Address1", prp.Address1);
                    cmd4.Parameters.AddWithValue("@Address2", prp.Address2);
                    cmd4.Parameters.AddWithValue("@within_US", prp.within_US);
                    cmd4.Parameters.AddWithValue("@Outside_US", prp.Outside_US);
                    cmd4.Parameters.AddWithValue("@City", prp.City);
                    cmd4.Parameters.AddWithValue("@Country", prp.Country);
                    cmd4.Parameters.AddWithValue("@Postal_code", prp.Postal_code);
                    cmd4.Parameters.AddWithValue("@AddedBy", prp.AddedBy);

                    cmd4.CommandText = "Prc_insert_tblLeadorganizationAddressDetails";
                    cmd4.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                
            }
            return true;
        }
        public DataTable getLeadorganizationAddressDetails(string OrgInfoID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_get_tblLeadorganizationAddressDetails", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable getcustomerAddressDetails(string orderid)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@orderid", orderid);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_get_tblCustomerAddressDetails", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        //start Pending enq
        public DataTable getPENDINGENQUIRY(string Emp_code)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Emp_code", Emp_code);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_PENDING_ENQUIRY", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        //end pending enq
        //statr enqHistory
        public DataTable getENQUIRYHISTORY(string enquiryno)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Leadno", enquiryno);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_Lead_History", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable Chck_Lead_Proposal_Status(string enquiryno)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", enquiryno);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Check_Lead_Proposal_Submition", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable Check_Lead_orderRecived_Submition(string enquiryno)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", enquiryno);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Check_Lead_orderRecived_Submition", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        
        //end enqhistory

        //start enqReport
        public DataTable grtENQUIRYREPORTLeadMaster(string fdate, string tdate, string status, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[4];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@status", status);
            objSqlParam[3] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("ENQUIRY_REPORT_LeadMaster", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        //End EnqReport


        //start lead master exists

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
        public DataTable select_single_tblLeadResellerInfo(string ResellerID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@ResellerID", ResellerID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblLeadResellerInfo", CommandType.StoredProcedure, objSqlParam);
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
        public DataTable select_single_tblLeadInfo(string OrgInfoID, string AddedBy)
        {

            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblLeadInfo", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblLeadRemarks(string OrgInfoID, string AddedBy)
        {

            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblLeadRemarks", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }


        //end lead master exists

    }
}

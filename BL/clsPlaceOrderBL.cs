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
    public class clsPlaceOrderBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public DataTable select_single_tblCustomerResellerInfo(string ResellerID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@ResellerID", ResellerID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerResellerInfo", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public void fill_country_list(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_dropDown_Codewise_Country", CommandType.Text);

        }
        public bool select_Tax(string @OrgInfoID)
        {
            bool istax = false;
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_Selectproposal_Tax", CommandType.StoredProcedure, objSqlParam);
            if (dt.Rows.Count > 0)
            {
                istax = Convert.ToBoolean(dt.Rows[0]["Istax"]);
            }
            return istax;
        }
        public void fill_tblCustomerResellerInfo(ref DropDownList Xddl, string AddedBy)
        {


            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon.FillDropDown(ref Xddl, "prc_select_tblCustomerResellerInfo", CommandType.StoredProcedure, objSqlParam);
        }
        public void fill_tblCustomerInfo(ref DropDownList Xddl, string AddedBy)
        {


            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon.FillDropDown(ref Xddl, "prc_select_tblCustomerInfo", CommandType.StoredProcedure, objSqlParam);
        }
        public void fill_tblCustomerContactdrd(ref DropDownList Xddl, string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);

            BaseCommon.FillDropDown(ref Xddl, "prc_select_tblCustomerContactdrd", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable select_single_tblCustomerInfo_PlaceOrder(string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerInfo_PlaceOrder", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblCustomerContact_PlaceOrder(string ContactID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@ContactID", ContactID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerContact_PlaceOrder", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable select_single_tblCustomerAddressDetails_PlaceOrder(string CustInfoID, string AddedBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@CustInfoID", CustInfoID);
            objSqlParam[1] = new SqlParameter("@AddedBy", AddedBy);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_select_single_tblCustomerAddressDetails_PlaceOrder", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProductPlaceOrder(string OrgInfoID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_PlaceOrder", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetProductPlaceOrder_SalesPersons(string OrgInfoID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_selectproduct_PlaceOrder_SalesPersons", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable getleadContactInfo(string OrgInfoID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_getleadContactInfo_PlaceOrder", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable getleadContactInfo_SalesPersons(string OrgInfoID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_getleadContactInfo_PlaceOrder_SalesPersons", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable get_Order_Item_Domain_operation(string OrderItemId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrderItemId", OrderItemId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_get_Order_Item_Domain_operation", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        
        public DataTable GetPlaceOrder_Details_Product(string OrderId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrderId", OrderId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_order_Product_detail", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetOrderList(string empcode,string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@Emp_code", empcode);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_Order_list", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataSet GetSingleOrderList(string orderId)
        {
            DataSet dt = new DataSet();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@orderId", orderId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDataSet("Prc_Select_single_order", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public string InsertPlaceOrder(string oldOrderId, clsPlaceOrderML obj,  clsPlaceOrderML[] objtbldomain, clsPlaceOrderAddressDetailsML[] objtblcustomeradddetail)
        {
            string OrderId = "";
            con.Open();
            string CustInfoID = "";
            if (obj.Mode == "I")
            {
                try
                {
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandType = CommandType.StoredProcedure;
                    cmd0.Parameters.AddWithValue("@CustInfoID", SqlDbType.BigInt);
                    cmd0.Parameters["@CustInfoID"].Direction = ParameterDirection.Output;
                    cmd0.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
                    cmd0.CommandText = "prc_insert_Customer_Autofrom_Lead";
                    if (cmd0.ExecuteNonQuery() < 0)
                    {
                      //  return "false";
                    }
                    CustInfoID = Convert.ToString(cmd0.Parameters["@CustInfoID"].Value);
                }
                catch (Exception ex)
                {
                    DL.BaseCommon objerr = new DL.BaseCommon();
                    objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                }


                obj.CustomerId = CustInfoID;
            }
            else { CustInfoID = obj.CustomerId; }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", SqlDbType.BigInt);
            cmd.Parameters["@OrderId"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@oldorderid", obj.OrderId);
            cmd.Parameters.AddWithValue("@CustomerId", obj.CustomerId);
            cmd.Parameters.AddWithValue("@CustResellerId", obj.CustResellerId);
            cmd.Parameters.AddWithValue("@OrderStatus", obj.OrderStatus);
            cmd.Parameters.AddWithValue("@PlacerIpAddress", obj.PlacerIpAddress);
            cmd.Parameters.AddWithValue("@PlacementStatus", obj.PlacementStatus);
            cmd.Parameters.AddWithValue("@OrderApprovalStatus", obj.OrderApprovalStatus);
            
            cmd.Parameters.AddWithValue("@Istax", obj.Istax);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@Service_tax", obj.Service_tax);
            cmd.Parameters.AddWithValue("@Service_tax_amount", obj.Service_tax_amount);
            cmd.Parameters.AddWithValue("@Swach_bharat_tax", obj.Swach_bharat_tax);
            cmd.Parameters.AddWithValue("@Swach_bharat_amount", obj.Swach_bharat_amount);
            cmd.Parameters.AddWithValue("@Krisi_Klayan_tax", obj.Krisi_Klayan_tax);
            cmd.Parameters.AddWithValue("@Krisi_Klayan_amount", obj.Krisi_Klayan_amount);
            cmd.Parameters.AddWithValue("@Total_amount", obj.Total_amount);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@EmailAddress", obj.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@PostCode", obj.PostCode);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.Mode);
            cmd.CommandText = "Prc_insert_order_Header";
            try
            {
                if (cmd.ExecuteNonQuery() < 0)
                {
                  //  return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            OrderId = Convert.ToString(cmd.Parameters["@OrderId"].Value);
            string OrderItemId = "";

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@OrderItemId", SqlDbType.BigInt);
            cmd2.Parameters["@OrderItemId"].Direction = ParameterDirection.Output;
            cmd2.Parameters.AddWithValue("@OrderId", OrderId);
            cmd2.Parameters.AddWithValue("@OrderReferenceNo", obj.PartnerOrderID);
            cmd2.Parameters.AddWithValue("@ProductId", obj.ProductId);
            cmd2.Parameters.AddWithValue("@Productcode", obj.ProductCode);
            cmd2.Parameters.AddWithValue("@Proposalproduct_id", obj.Proposalproduct_id);
            cmd2.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
            cmd2.Parameters.AddWithValue("@CustInfoID", CustInfoID);
            cmd2.Parameters.AddWithValue("@TotalYears", obj.TotalYears);
            cmd2.Parameters.AddWithValue("@Unit_price", obj.Unit_price);
            cmd2.Parameters.AddWithValue("@QTY", obj.QTY);
            cmd2.Parameters.AddWithValue("@Discount", obj.Discount);
            cmd2.Parameters.AddWithValue("@Offer_price", obj.Offer_price);
            cmd2.Parameters.AddWithValue("@Total_price", obj.Total_price);
            cmd2.Parameters.AddWithValue("@AdditionalSan", obj.AdditionalSan);
            cmd2.Parameters.AddWithValue("@TotalServers", obj.TotalServers);
            cmd2.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd2.Parameters.AddWithValue("@ItemStatus", obj.ItemStatus);
            cmd2.Parameters.AddWithValue("@Comments", obj.Comments);
            cmd2.Parameters.AddWithValue("@OrganizationName", obj.OrganizationName);
            cmd2.Parameters.AddWithValue("@DomainName", obj.DomainName);
            cmd2.Parameters.AddWithValue("@ApproverEmail", obj.ApproverEmail);
            cmd2.Parameters.AddWithValue("@CsrContents", obj.CsrContents);
            cmd2.Parameters.AddWithValue("@ServerType", obj.ServerType);
            cmd2.Parameters.AddWithValue("@EncryptionAlgorithm", obj.EncryptionAlgorithm);
            cmd2.Parameters.AddWithValue("@ContractId", obj.ContractId);
            cmd2.Parameters.AddWithValue("@SerialNumber", obj.SerialNumber);
            cmd2.Parameters.AddWithValue("@AuthType", obj.AuthType);
            cmd2.Parameters.AddWithValue("@CertChainType", obj.CertChainType);
            cmd2.Parameters.AddWithValue("@SubmissionResponse", obj.SubmissionResponse);
            cmd2.Parameters.AddWithValue("@Pkcs", obj.Pkcs);
            cmd2.Parameters.AddWithValue("@x509", obj.x509);
            cmd2.Parameters.AddWithValue("@SymantecOrderId", obj.SymantecOrderId);
            cmd2.Parameters.AddWithValue("@CertificateSerialNumber", obj.CertificateSerialNumber);
            cmd2.Parameters.AddWithValue("@SubDomain", obj.SubDomain);
            cmd2.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd2.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd2.Parameters.AddWithValue("@COMMON_NAME", obj.COMMON_NAME);
            cmd2.Parameters.AddWithValue("@Renewal", obj.Renewal);
            cmd2.Parameters.AddWithValue("@competitive_replacment", obj.competitive_replacment);
            cmd2.Parameters.AddWithValue("@special_instruction", obj.special_instruction);
            cmd2.Parameters.AddWithValue("@ENCRYPTION_TYPE", obj.ENCRYPTION_TYPE);
            cmd2.Parameters.AddWithValue("@BrandInfo", obj.BrandInfo);
            cmd2.Parameters.AddWithValue("@Server_Licenses", obj.Server_Licenses);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet", obj.Enrolment_Sheet);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet_path", obj.Enrolment_Sheet_path);
            cmd2.Parameters.AddWithValue("@Csr_Txt", obj.Csr_Txt);
            cmd2.Parameters.AddWithValue("@Csr_Txt_path", obj.Csr_Txt_path);
            cmd2.Parameters.AddWithValue("@PO_File", obj.PO_File);
            cmd2.Parameters.AddWithValue("@PO_File_path", obj.PO_File_path);
            cmd2.Parameters.AddWithValue("@mode", obj.Mode);
            cmd2.Parameters.AddWithValue("@DVAuthMethod", obj.DVAuthMethod);
            cmd2.Parameters.AddWithValue("@DVAuthMethodContent", obj.DVAuthMethodContent);
            cmd2.CommandText = "Prc_insert_order_Items";
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            OrderItemId = ""; Convert.ToString(cmd2.Parameters["@OrderItemId"].Value);
            //order item End
            SqlCommand cmdCustomer = con.CreateCommand();
            cmdCustomer.CommandType = CommandType.StoredProcedure;
            cmdCustomer.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
            cmdCustomer.Parameters.AddWithValue("@OrderItemId", OrderItemId);
            cmdCustomer.Parameters.AddWithValue("@CustInfoID", CustInfoID);
            cmdCustomer.CommandText = "prc_insert_Customer_Autofrom_Lead_Details_PlaceOrder";
            cmdCustomer.ExecuteNonQuery();
            if (obj.Mode == "M")
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.CommandText = "Prc_delete_Order_Item_Domain";
                cmd3.ExecuteNonQuery();
            }
            foreach (clsPlaceOrderML prp in objtbldomain)
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@Domain", prp.AdditionalDomain);
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd3.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd3.CommandText = "Prc_insert_Order_Item_Domain";
                cmd3.ExecuteNonQuery();
            }
            if (obj.Mode == "M")
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd3.CommandText = "Prc_delete_Customer_adress_details";
                cmd3.ExecuteNonQuery();
            }
            foreach (clsPlaceOrderAddressDetailsML prp in objtblcustomeradddetail)
            {
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd4.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd4.Parameters.AddWithValue("@Add_name", prp.Add_name);
                cmd4.Parameters.AddWithValue("@Add_designation", prp.Add_designation);
                cmd4.Parameters.AddWithValue("@Add_Contact", prp.Add_Contact);
                cmd4.Parameters.AddWithValue("@Add_Email", prp.Add_Email);
                cmd4.Parameters.AddWithValue("@Add_Address", prp.Add_Address);
                cmd4.Parameters.AddWithValue("@Type", prp.Type);
                cmd4.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd4.Parameters.AddWithValue("@Modified", prp.Modified);
                cmd4.Parameters.AddWithValue("@ModifiedBy", prp.ModifiedBy);
                cmd4.Parameters.AddWithValue("@Cor_Legal_Name", prp.Cor_Legal_Name);
                cmd4.Parameters.AddWithValue("@DBA_Name", prp.DBA_Name);
                cmd4.Parameters.AddWithValue("@Division", prp.Division);
                cmd4.Parameters.AddWithValue("@DUNS", prp.DUNS);
                cmd4.Parameters.AddWithValue("@Fax", prp.Fax);
                cmd4.Parameters.AddWithValue("@Address1", prp.Address1);
                cmd4.Parameters.AddWithValue("@Address2", prp.Address2);
                cmd4.Parameters.AddWithValue("@City", prp.City);
                cmd4.Parameters.AddWithValue("@Country", prp.Country);
                cmd4.Parameters.AddWithValue("@within_US", prp.within_US);
                cmd4.Parameters.AddWithValue("@Outside_US", prp.Outside_US);
                cmd4.Parameters.AddWithValue("@Postal_code", prp.Postal_code);
                cmd4.Parameters.AddWithValue("@First_name", prp.First_name);
                cmd4.Parameters.AddWithValue("@Last_name", prp.Last_name);
                cmd4.Parameters.AddWithValue("@Title", prp.Title);
                cmd4.Parameters.AddWithValue("@Comp_Name", prp.Comp_Name);
                cmd4.CommandText = "Prc_insert_Customer_adress_details";
                cmd4.ExecuteNonQuery();
            }


            return OrderId;
        }
        public string InsertSalesPlaceOrder(string oldOrderId, clsPlaceOrderML obj, clsPlaceOrderML[] objtbldomain, clsPlaceOrderAddressDetailsML[] objtblcustomeradddetail)
        {
            string OrderId = "";
            con.Open();
            string CustInfoID = "";
            if (obj.Mode == "I")
            {
                try
                {
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandType = CommandType.StoredProcedure;
                    cmd0.Parameters.AddWithValue("@CustInfoID", SqlDbType.BigInt);
                    cmd0.Parameters["@CustInfoID"].Direction = ParameterDirection.Output;
                    cmd0.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
                    cmd0.CommandText = "prc_insert_Customer_Autofrom_Lead_SalesPersons";
                    if (cmd0.ExecuteNonQuery() < 0)
                    {
                        //  return "false";
                    }
                    CustInfoID = Convert.ToString(cmd0.Parameters["@CustInfoID"].Value);
                }
                catch (Exception ex)
                {
                    DL.BaseCommon objerr = new DL.BaseCommon();
                    objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                }


                obj.CustomerId = CustInfoID;
            }
            else { CustInfoID = obj.CustomerId; }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", SqlDbType.BigInt);
            cmd.Parameters["@OrderId"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@oldorderid", obj.OrderId);
            cmd.Parameters.AddWithValue("@CustomerId", obj.CustomerId);
            cmd.Parameters.AddWithValue("@CustResellerId", obj.CustResellerId);
            cmd.Parameters.AddWithValue("@OrderStatus", obj.OrderStatus);
            cmd.Parameters.AddWithValue("@PlacerIpAddress", obj.PlacerIpAddress);
            cmd.Parameters.AddWithValue("@PlacementStatus", obj.PlacementStatus);
            cmd.Parameters.AddWithValue("@OrderApprovalStatus", obj.OrderApprovalStatus);

            cmd.Parameters.AddWithValue("@Istax", obj.Istax);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@Service_tax", obj.Service_tax);
            cmd.Parameters.AddWithValue("@Service_tax_amount", obj.Service_tax_amount);
            cmd.Parameters.AddWithValue("@Swach_bharat_tax", obj.Swach_bharat_tax);
            cmd.Parameters.AddWithValue("@Swach_bharat_amount", obj.Swach_bharat_amount);
            cmd.Parameters.AddWithValue("@Krisi_Klayan_tax", obj.Krisi_Klayan_tax);
            cmd.Parameters.AddWithValue("@Krisi_Klayan_amount", obj.Krisi_Klayan_amount);
            cmd.Parameters.AddWithValue("@Total_amount", obj.Total_amount);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@EmailAddress", obj.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@PostCode", obj.PostCode);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.Mode);
            cmd.CommandText = "Prc_insert_order_Header_SalesPersons";
            try
            {
                if (cmd.ExecuteNonQuery() < 0)
                {
                    //  return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            OrderId = Convert.ToString(cmd.Parameters["@OrderId"].Value);
            string OrderItemId = "";
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@OLDOrderItemId", obj.OLDOrderItemId);
            cmd2.Parameters.AddWithValue("@OrderId", OrderId);
            cmd2.Parameters.AddWithValue("@CustInfoID", CustInfoID);
            cmd2.Parameters.AddWithValue("@OrderReferenceNo", obj.PartnerOrderID);
            cmd2.Parameters.AddWithValue("@ProductId", obj.ProductId);
            cmd2.Parameters.AddWithValue("@Productcode", obj.ProductCode);
            cmd2.Parameters.AddWithValue("@Proposalproduct_id", obj.Proposalproduct_id);
            cmd2.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
            cmd2.Parameters.AddWithValue("@TotalYears", obj.TotalYears);
            cmd2.Parameters.AddWithValue("@Unit_price", obj.Unit_price);
            cmd2.Parameters.AddWithValue("@QTY", obj.QTY);
            cmd2.Parameters.AddWithValue("@Discount", obj.Discount);
            cmd2.Parameters.AddWithValue("@Offer_price", obj.Offer_price);
            cmd2.Parameters.AddWithValue("@Total_price", obj.Total_price);
            cmd2.Parameters.AddWithValue("@AdditionalSan", obj.AdditionalSan);
            cmd2.Parameters.AddWithValue("@TotalServers", obj.TotalServers);
            cmd2.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd2.Parameters.AddWithValue("@ItemStatus", obj.ItemStatus);
            cmd2.Parameters.AddWithValue("@Comments", obj.Comments);
            cmd2.Parameters.AddWithValue("@OrganizationName", obj.OrganizationName);
            cmd2.Parameters.AddWithValue("@DomainName", obj.DomainName);
            cmd2.Parameters.AddWithValue("@ApproverEmail", obj.ApproverEmail);
            cmd2.Parameters.AddWithValue("@CsrContents", obj.CsrContents);
            cmd2.Parameters.AddWithValue("@ServerType", obj.ServerType);
            cmd2.Parameters.AddWithValue("@EncryptionAlgorithm", obj.EncryptionAlgorithm);
            cmd2.Parameters.AddWithValue("@ContractId", obj.ContractId);
            cmd2.Parameters.AddWithValue("@SerialNumber", obj.SerialNumber);
            cmd2.Parameters.AddWithValue("@AuthType", obj.AuthType);
            cmd2.Parameters.AddWithValue("@CertChainType", obj.CertChainType);
            cmd2.Parameters.AddWithValue("@SubmissionResponse", obj.SubmissionResponse);
            cmd2.Parameters.AddWithValue("@Pkcs", obj.Pkcs);
            cmd2.Parameters.AddWithValue("@x509", obj.x509);
            cmd2.Parameters.AddWithValue("@SymantecOrderId", obj.SymantecOrderId);
            cmd2.Parameters.AddWithValue("@CertificateSerialNumber", obj.CertificateSerialNumber);
            cmd2.Parameters.AddWithValue("@SubDomain", obj.SubDomain);
            cmd2.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd2.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd2.Parameters.AddWithValue("@COMMON_NAME", obj.COMMON_NAME);
            cmd2.Parameters.AddWithValue("@Renewal", obj.Renewal);
            cmd2.Parameters.AddWithValue("@competitive_replacment", obj.competitive_replacment);
            cmd2.Parameters.AddWithValue("@special_instruction", obj.special_instruction);
            cmd2.Parameters.AddWithValue("@ENCRYPTION_TYPE", obj.ENCRYPTION_TYPE);
            cmd2.Parameters.AddWithValue("@BrandInfo", obj.BrandInfo);
            cmd2.Parameters.AddWithValue("@Server_Licenses", obj.Server_Licenses);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet", obj.Enrolment_Sheet);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet_path", obj.Enrolment_Sheet_path);
            cmd2.Parameters.AddWithValue("@Csr_Txt", obj.Csr_Txt);
            cmd2.Parameters.AddWithValue("@Csr_Txt_path", obj.Csr_Txt_path);
            cmd2.Parameters.AddWithValue("@PO_File", obj.PO_File);
            cmd2.Parameters.AddWithValue("@PO_File_path", obj.PO_File_path);
            cmd2.Parameters.AddWithValue("@mode", obj.Mode);
            cmd2.Parameters.Add("@OrderItemId", SqlDbType.VarChar,50);
            cmd2.Parameters["@OrderItemId"].Direction = ParameterDirection.Output;
            cmd2.Parameters.AddWithValue("@CRMRemarks", obj.CRMRemarks);
            cmd2.Parameters.AddWithValue("@DVAuthMethod", obj.DVAuthMethod);
            cmd2.Parameters.AddWithValue("@DVAuthMethodContent", obj.DVAuthMethodContent);
            cmd2.CommandText = "Prc_insert_order_Items_SalesPersons";
            try
            {
                cmd2.ExecuteNonQuery();
                OrderItemId = Convert.ToString(cmd2.Parameters["@OrderItemId"].Value);
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            //order item End
            SqlCommand cmdCustomer = con.CreateCommand();
            cmdCustomer.CommandType = CommandType.StoredProcedure;
            cmdCustomer.Parameters.AddWithValue("@OrgInfoID",obj.OrgInfoID);
            cmdCustomer.Parameters.AddWithValue("@OrderItemId", OrderItemId);
            cmdCustomer.Parameters.AddWithValue("@CustInfoID", CustInfoID);
            cmdCustomer.CommandText = "prc_insert_Customer_Autofrom_Lead_Details_SalesPersons";
            cmdCustomer.ExecuteNonQuery();
         
            if (obj.Mode == "M")
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd3.CommandText = "Prc_delete_Order_Item_Domain_SalesPersons";
                cmd3.ExecuteNonQuery();
            }
            foreach (clsPlaceOrderML prp in objtbldomain)
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@Domain", prp.AdditionalDomain);
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd3.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd3.CommandText = "Prc_insert_Order_Item_Domain_SalesPersons";
                cmd3.ExecuteNonQuery();
            }
            if (obj.Mode == "M")
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd3.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd3.CommandText = "Prc_delete_Customer_adress_details_SalesPersons";
                cmd3.ExecuteNonQuery();
            }
            foreach (clsPlaceOrderAddressDetailsML prp in objtblcustomeradddetail)
            {
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.StoredProcedure;

                cmd4.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd4.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd4.Parameters.AddWithValue("@Addid", prp.Addid);
                cmd4.Parameters.AddWithValue("@Add_name", prp.Add_name);
                cmd4.Parameters.AddWithValue("@Add_designation", prp.Add_designation);
                cmd4.Parameters.AddWithValue("@Add_Contact", prp.Add_Contact);
                cmd4.Parameters.AddWithValue("@Add_Email", prp.Add_Email);
                cmd4.Parameters.AddWithValue("@Add_Address", prp.Add_Address);
                cmd4.Parameters.AddWithValue("@Type", prp.Type);
                cmd4.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd4.Parameters.AddWithValue("@Modified", prp.Modified);
                cmd4.Parameters.AddWithValue("@ModifiedBy", prp.ModifiedBy);
                cmd4.Parameters.AddWithValue("@Cor_Legal_Name", prp.Cor_Legal_Name);
                cmd4.Parameters.AddWithValue("@DBA_Name", prp.DBA_Name);
                cmd4.Parameters.AddWithValue("@Division", prp.Division);
                cmd4.Parameters.AddWithValue("@DUNS", prp.DUNS);
                cmd4.Parameters.AddWithValue("@Fax", prp.Fax);
                cmd4.Parameters.AddWithValue("@Address1", prp.Address1);
                cmd4.Parameters.AddWithValue("@Address2", prp.Address2);
                cmd4.Parameters.AddWithValue("@City", prp.City);
                cmd4.Parameters.AddWithValue("@Country", prp.Country);
                cmd4.Parameters.AddWithValue("@within_US", prp.within_US);
                cmd4.Parameters.AddWithValue("@Outside_US", prp.Outside_US);
                cmd4.Parameters.AddWithValue("@Postal_code", prp.Postal_code);
                cmd4.Parameters.AddWithValue("@First_name", prp.First_name);
                cmd4.Parameters.AddWithValue("@Last_name", prp.Last_name);
                cmd4.Parameters.AddWithValue("@Title", prp.Title);
                cmd4.Parameters.AddWithValue("@Comp_Name", prp.Comp_Name);
                cmd4.CommandText = "Prc_insert_Customer_adress_details_SalesPersons";
                cmd4.ExecuteNonQuery();
            }


            return OrderId;
        }
        public string InsertPlaceOrderOperation(string oldOrderId, clsPlaceOrderML obj, clsPlaceOrderML[] objtbldomain, clsPlaceOrderAddressDetailsML[] objtblcustomeradddetail,string apiResult)
        {
            string OrderId = "";
            con.Open();
            string CustInfoID = obj.CustomerId;

            //
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.StoredProcedure;
            cmd0.Parameters.AddWithValue("@OrderItemId", obj.OrderItemId);
            cmd0.Parameters.AddWithValue("@apiResult", apiResult);
            cmd0.CommandText = "Prc_insert_order_ApiResult";
            try
            {
                if (cmd0.ExecuteNonQuery() < 0)
                {
                    //  return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }




            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", SqlDbType.BigInt);
            cmd.Parameters["@OrderId"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@OrderItemId", obj.OrderItemId);
            cmd.CommandText = "Prc_insert_order_Header_operation";
            try
            {
                if (cmd.ExecuteNonQuery() < 0)
                {
                    //  return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            OrderId = Convert.ToString(cmd.Parameters["@OrderId"].Value);

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@OrderItemId", obj.OrderItemId);
            cmd2.Parameters.AddWithValue("@OrderId", OrderId);
            cmd2.Parameters.AddWithValue("@OrderReferenceNo", obj.PartnerOrderID);
            cmd2.Parameters.AddWithValue("@ProductId", obj.ProductId);
            cmd2.Parameters.AddWithValue("@Productcode", obj.ProductCode);
            cmd2.Parameters.AddWithValue("@Proposalproduct_id", obj.Proposalproduct_id);
            cmd2.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
            cmd2.Parameters.AddWithValue("@TotalYears", obj.TotalYears);
            cmd2.Parameters.AddWithValue("@Unit_price", obj.Unit_price);
            cmd2.Parameters.AddWithValue("@QTY", obj.QTY);
            cmd2.Parameters.AddWithValue("@Discount", obj.Discount);
            cmd2.Parameters.AddWithValue("@Offer_price", obj.Offer_price);
            cmd2.Parameters.AddWithValue("@Total_price", obj.Total_price);
            cmd2.Parameters.AddWithValue("@AdditionalSan", obj.AdditionalSan);
            cmd2.Parameters.AddWithValue("@TotalServers", obj.TotalServers);
            cmd2.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd2.Parameters.AddWithValue("@ItemStatus", obj.ItemStatus);
            cmd2.Parameters.AddWithValue("@Comments", obj.Comments);
            cmd2.Parameters.AddWithValue("@OrganizationName", obj.OrganizationName);
            cmd2.Parameters.AddWithValue("@DomainName", obj.DomainName);
            cmd2.Parameters.AddWithValue("@ApproverEmail", obj.ApproverEmail);
            cmd2.Parameters.AddWithValue("@CsrContents", obj.CsrContents);
            cmd2.Parameters.AddWithValue("@ServerType", obj.ServerType);
            cmd2.Parameters.AddWithValue("@EncryptionAlgorithm", obj.EncryptionAlgorithm);
            cmd2.Parameters.AddWithValue("@ContractId", obj.ContractId);
            cmd2.Parameters.AddWithValue("@SerialNumber", obj.SerialNumber);
            cmd2.Parameters.AddWithValue("@AuthType", obj.AuthType);
            cmd2.Parameters.AddWithValue("@CertChainType", obj.CertChainType);
            cmd2.Parameters.AddWithValue("@SubmissionResponse", obj.SubmissionResponse);
            cmd2.Parameters.AddWithValue("@Pkcs", obj.Pkcs);
            cmd2.Parameters.AddWithValue("@x509", obj.x509);
            cmd2.Parameters.AddWithValue("@SymantecOrderId", obj.SymantecOrderId);
            cmd2.Parameters.AddWithValue("@CertificateSerialNumber", obj.CertificateSerialNumber);
            cmd2.Parameters.AddWithValue("@SubDomain", obj.SubDomain);
            cmd2.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd2.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd2.Parameters.AddWithValue("@COMMON_NAME", obj.COMMON_NAME);
            cmd2.Parameters.AddWithValue("@Renewal", obj.Renewal);
            cmd2.Parameters.AddWithValue("@competitive_replacment", obj.competitive_replacment);
            cmd2.Parameters.AddWithValue("@special_instruction", obj.special_instruction);
            cmd2.Parameters.AddWithValue("@ENCRYPTION_TYPE", obj.ENCRYPTION_TYPE);
            cmd2.Parameters.AddWithValue("@BrandInfo", obj.BrandInfo);
            cmd2.Parameters.AddWithValue("@Server_Licenses", obj.Server_Licenses);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet", obj.Enrolment_Sheet);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet_path", obj.Enrolment_Sheet_path);
            cmd2.Parameters.AddWithValue("@Csr_Txt", obj.Csr_Txt);
            cmd2.Parameters.AddWithValue("@Csr_Txt_path", obj.Csr_Txt_path);
            cmd2.Parameters.AddWithValue("@PO_File", obj.PO_File);
            cmd2.Parameters.AddWithValue("@PO_File_path", obj.PO_File_path);
            cmd2.Parameters.AddWithValue("@CRMRemarks", obj.CRMRemarks);
            cmd2.Parameters.AddWithValue("@DVAuthMethod", obj.DVAuthMethod);
            cmd2.Parameters.AddWithValue("@DVAuthMethodContent", obj.DVAuthMethodContent);
            cmd2.CommandText = "Prc_Update_order_Items_operation";
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            //order item End
           
                SqlCommand cmdDomain3 = con.CreateCommand();
            cmdDomain3.CommandType = CommandType.StoredProcedure;
            cmdDomain3.Parameters.AddWithValue("@OrderID", OrderId);
            cmdDomain3.CommandText = "Prc_delete_Order_Item_Domain_operation";
            cmdDomain3.ExecuteNonQuery();
         
            foreach (clsPlaceOrderML prp in objtbldomain)
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@Domain", prp.AdditionalDomain);
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd3.CommandText = "Prc_insert_Order_Item_Domain_operation";
                cmd3.ExecuteNonQuery();
            }
           
          
            foreach (clsPlaceOrderAddressDetailsML prp in objtblcustomeradddetail)
            {
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.AddWithValue("@Addid", prp.Addid);
                cmd4.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd4.Parameters.AddWithValue("@Add_name", prp.Add_name);
                cmd4.Parameters.AddWithValue("@Add_designation", prp.Add_designation);
                cmd4.Parameters.AddWithValue("@Add_Contact", prp.Add_Contact);
                cmd4.Parameters.AddWithValue("@Add_Email", prp.Add_Email);
                cmd4.Parameters.AddWithValue("@Add_Address", prp.Add_Address);
                cmd4.Parameters.AddWithValue("@Type", prp.Type);
                cmd4.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd4.Parameters.AddWithValue("@Modified", prp.Modified);
                cmd4.Parameters.AddWithValue("@ModifiedBy", prp.ModifiedBy);
                cmd4.Parameters.AddWithValue("@Cor_Legal_Name", prp.Cor_Legal_Name);
                cmd4.Parameters.AddWithValue("@DBA_Name", prp.DBA_Name);
                cmd4.Parameters.AddWithValue("@Division", prp.Division);
                cmd4.Parameters.AddWithValue("@DUNS", prp.DUNS);
                cmd4.Parameters.AddWithValue("@Fax", prp.Fax);
                cmd4.Parameters.AddWithValue("@Address1", prp.Address1);
                cmd4.Parameters.AddWithValue("@Address2", prp.Address2);
                cmd4.Parameters.AddWithValue("@City", prp.City);
                cmd4.Parameters.AddWithValue("@Country", prp.Country);
                cmd4.Parameters.AddWithValue("@within_US", prp.within_US);
                cmd4.Parameters.AddWithValue("@Outside_US", prp.Outside_US);
                cmd4.Parameters.AddWithValue("@Postal_code", prp.Postal_code);
                cmd4.Parameters.AddWithValue("@First_name", prp.First_name);
                cmd4.Parameters.AddWithValue("@Last_name", prp.Last_name);
                cmd4.Parameters.AddWithValue("@Title", prp.Title);
                cmd4.Parameters.AddWithValue("@Comp_Name", prp.Comp_Name);
                cmd4.CommandText = "Prc_insert_Customer_adress_details_operation";
                cmd4.ExecuteNonQuery();
            }


            return OrderId;
        }
        public string InsertPlaceQuickInvite(string oldOrderId, clsPlaceQuickInviteML obj, clsPlaceQuickInviteML[] objtbldomain, clsPlaceQuickInviteAddressDetailsML[] objtblcustomeradddetail)
        {
            string OrderId = "";
            con.Open();
            string CustInfoID = "";
            if (obj.Mode == "I")
            {
                try
                {
                    SqlCommand cmd0 = con.CreateCommand();
                    cmd0.CommandType = CommandType.StoredProcedure;
                    cmd0.Parameters.AddWithValue("@CustInfoID", SqlDbType.BigInt);
                    cmd0.Parameters["@CustInfoID"].Direction = ParameterDirection.Output;
                    cmd0.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
                    cmd0.CommandText = "prc_insert_Customer_Autofrom_Lead";
                    if (cmd0.ExecuteNonQuery() < 0)
                    {
                        //  return "false";
                    }
                    CustInfoID = Convert.ToString(cmd0.Parameters["@CustInfoID"].Value);
                }
                catch (Exception ex)
                {
                    DL.BaseCommon objerr = new DL.BaseCommon();
                    objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                }


                obj.CustomerId = CustInfoID;
            }
            else { CustInfoID = obj.CustomerId; }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", SqlDbType.BigInt);
            cmd.Parameters["@OrderId"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@oldorderid", obj.OrderId);
            cmd.Parameters.AddWithValue("@CustomerId", obj.CustomerId);
            cmd.Parameters.AddWithValue("@CustResellerId", obj.CustResellerId);
            cmd.Parameters.AddWithValue("@OrderStatus", obj.OrderStatus);
            cmd.Parameters.AddWithValue("@PlacerIpAddress", obj.PlacerIpAddress);
            cmd.Parameters.AddWithValue("@PlacementStatus", obj.PlacementStatus);
            cmd.Parameters.AddWithValue("@OrderApprovalStatus", obj.OrderApprovalStatus);

            cmd.Parameters.AddWithValue("@Istax", obj.Istax);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@Service_tax", obj.Service_tax);
            cmd.Parameters.AddWithValue("@Service_tax_amount", obj.Service_tax_amount);
            cmd.Parameters.AddWithValue("@Swach_bharat_tax", obj.Swach_bharat_tax);
            cmd.Parameters.AddWithValue("@Swach_bharat_amount", obj.Swach_bharat_amount);
            cmd.Parameters.AddWithValue("@Krisi_Klayan_tax", obj.Krisi_Klayan_tax);
            cmd.Parameters.AddWithValue("@Krisi_Klayan_amount", obj.Krisi_Klayan_amount);
            cmd.Parameters.AddWithValue("@Total_amount", obj.Total_amount);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@EmailAddress", obj.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@PostCode", obj.PostCode);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@mode", obj.Mode);
            cmd.CommandText = "Prc_insert_order_Header";
            try
            {
                if (cmd.ExecuteNonQuery() < 0)
                {
                    //  return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            OrderId = Convert.ToString(cmd.Parameters["@OrderId"].Value);

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@OrderItemId",SqlDbType.VarChar);
            cmd2.Parameters["@OrderItemId"].Direction = ParameterDirection.Output;
            cmd2.Parameters.AddWithValue("@OrderId", OrderId);
            cmd2.Parameters.AddWithValue("@OrderReferenceNo", obj.PartnerOrderID);
            cmd2.Parameters.AddWithValue("@ProductId", obj.ProductId);
            cmd2.Parameters.AddWithValue("@Productcode", obj.ProductCode);
            cmd2.Parameters.AddWithValue("@Proposalproduct_id", obj.Proposalproduct_id);
            cmd2.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
            cmd2.Parameters.AddWithValue("@TotalYears", obj.TotalYears);
            cmd2.Parameters.AddWithValue("@Unit_price", obj.Unit_price);
            cmd2.Parameters.AddWithValue("@QTY", obj.QTY);
            cmd2.Parameters.AddWithValue("@Discount", obj.Discount);
            cmd2.Parameters.AddWithValue("@Offer_price", obj.Offer_price);
            cmd2.Parameters.AddWithValue("@Total_price", obj.Total_price);
            cmd2.Parameters.AddWithValue("@AdditionalSan", obj.AdditionalSan);
            cmd2.Parameters.AddWithValue("@TotalServers", obj.TotalServers);
            cmd2.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd2.Parameters.AddWithValue("@ItemStatus", obj.ItemStatus);
            cmd2.Parameters.AddWithValue("@Comments", obj.Comments);
            cmd2.Parameters.AddWithValue("@OrganizationName", obj.OrganizationName);
            cmd2.Parameters.AddWithValue("@DomainName", obj.DomainName);
            cmd2.Parameters.AddWithValue("@ApproverEmail", obj.ApproverEmail);
            cmd2.Parameters.AddWithValue("@RequestorEmail", obj.RequestorEmail);
            cmd2.Parameters.AddWithValue("@RequestorURL", obj.RequestorURL);
            cmd2.Parameters.AddWithValue("@CsrContents", obj.CsrContents);
            cmd2.Parameters.AddWithValue("@ServerType", obj.ServerType);
            cmd2.Parameters.AddWithValue("@EncryptionAlgorithm", obj.EncryptionAlgorithm);
            cmd2.Parameters.AddWithValue("@ContractId", obj.ContractId);
            cmd2.Parameters.AddWithValue("@SerialNumber", obj.SerialNumber);
            cmd2.Parameters.AddWithValue("@AuthType", obj.AuthType);
            cmd2.Parameters.AddWithValue("@CertChainType", obj.CertChainType);
            cmd2.Parameters.AddWithValue("@SubmissionResponse", obj.SubmissionResponse);
            cmd2.Parameters.AddWithValue("@Pkcs", obj.Pkcs);
            cmd2.Parameters.AddWithValue("@x509", obj.x509);
            cmd2.Parameters.AddWithValue("@SymantecOrderId", obj.SymantecOrderId);
            cmd2.Parameters.AddWithValue("@CertificateSerialNumber", obj.CertificateSerialNumber);
            cmd2.Parameters.AddWithValue("@SubDomain", obj.SubDomain);
            cmd2.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd2.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd2.Parameters.AddWithValue("@COMMON_NAME", obj.COMMON_NAME);
            cmd2.Parameters.AddWithValue("@Renewal", obj.Renewal);
            cmd2.Parameters.AddWithValue("@competitive_replacment", obj.competitive_replacment);
            cmd2.Parameters.AddWithValue("@special_instruction", obj.special_instruction);
            cmd2.Parameters.AddWithValue("@ENCRYPTION_TYPE", obj.ENCRYPTION_TYPE);
            cmd2.Parameters.AddWithValue("@BrandInfo", obj.BrandInfo);
            cmd2.Parameters.AddWithValue("@Server_Licenses", obj.Server_Licenses);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet", obj.Enrolment_Sheet);
            cmd2.Parameters.AddWithValue("@Enrolment_Sheet_path", obj.Enrolment_Sheet_path);
            cmd2.Parameters.AddWithValue("@Csr_Txt", obj.Csr_Txt);
            cmd2.Parameters.AddWithValue("@Csr_Txt_path", obj.Csr_Txt_path);
            cmd2.Parameters.AddWithValue("@PO_File", obj.PO_File);
            cmd2.Parameters.AddWithValue("@PO_File_path", obj.PO_File_path);
            cmd2.Parameters.AddWithValue("@mode", obj.Mode);
            cmd2.CommandText = "Prc_insert_Quickorder_Items";
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            string OrderItemId = Convert.ToString(cmd2.Parameters["@OrderItemId"]);
            //order item End
            SqlCommand cmdCustomer = con.CreateCommand();
            cmdCustomer.CommandType = CommandType.StoredProcedure;
            cmdCustomer.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
            cmdCustomer.Parameters.AddWithValue("@OrderItemId", OrderItemId);
            cmdCustomer.Parameters.AddWithValue("@CustInfoID", CustInfoID);
            cmdCustomer.CommandText = "prc_insert_Customer_Autofrom_Lead_Details_PlaceOrder";
            cmdCustomer.ExecuteNonQuery();
            if (obj.Mode == "M")
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.CommandText = "Prc_delete_Order_Item_Domain";
                cmd3.ExecuteNonQuery();
            }
            foreach (clsPlaceQuickInviteML prp in objtbldomain)
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@Domain", prp.AdditionalDomain);
                cmd3.Parameters.AddWithValue("@OrderID", OrderId);
                cmd3.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd3.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd3.CommandText = "Prc_insert_Order_Item_Domain";
                cmd3.ExecuteNonQuery();
            }
            if (obj.Mode == "M")
            {
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd3.CommandText = "Prc_delete_Customer_adress_details";
                cmd3.ExecuteNonQuery();
            }


            foreach (clsPlaceQuickInviteAddressDetailsML prp in objtblcustomeradddetail)
            {
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.AddWithValue("@CustInfoID", CustInfoID);
                cmd4.Parameters.AddWithValue("@OrderItemId", OrderItemId);
                cmd4.Parameters.AddWithValue("@Add_name", prp.Add_name);
                cmd4.Parameters.AddWithValue("@Add_designation", prp.Add_designation);
                cmd4.Parameters.AddWithValue("@Add_Contact", prp.Add_Contact);
                cmd4.Parameters.AddWithValue("@Add_Email", prp.Add_Email);
                cmd4.Parameters.AddWithValue("@Add_Address", prp.Add_Address);
                cmd4.Parameters.AddWithValue("@Type", prp.Type);
                cmd4.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                cmd4.Parameters.AddWithValue("@Modified", prp.Modified);
                cmd4.Parameters.AddWithValue("@ModifiedBy", prp.ModifiedBy);
                cmd4.Parameters.AddWithValue("@Cor_Legal_Name", prp.Cor_Legal_Name);
                cmd4.Parameters.AddWithValue("@DBA_Name", prp.DBA_Name);
                cmd4.Parameters.AddWithValue("@Division", prp.Division);
                cmd4.Parameters.AddWithValue("@DUNS", prp.DUNS);
                cmd4.Parameters.AddWithValue("@Fax", prp.Fax);
                cmd4.Parameters.AddWithValue("@Address1", prp.Address1);
                cmd4.Parameters.AddWithValue("@Address2", prp.Address2);
                cmd4.Parameters.AddWithValue("@City", prp.City);
                cmd4.Parameters.AddWithValue("@Country", prp.Country);
                cmd4.Parameters.AddWithValue("@within_US", prp.within_US);
                cmd4.Parameters.AddWithValue("@Outside_US", prp.Outside_US);
                cmd4.Parameters.AddWithValue("@Postal_code", prp.Postal_code);
                cmd4.Parameters.AddWithValue("@First_name", prp.First_name);
                cmd4.Parameters.AddWithValue("@Last_name", prp.Last_name);
                cmd4.Parameters.AddWithValue("@Title", prp.Title);
                cmd4.Parameters.AddWithValue("@Comp_Name", prp.Comp_Name);
                cmd4.CommandText = "Prc_insert_Customer_adress_details";
                cmd4.ExecuteNonQuery();
            }


            return OrderId;
        }
        public DataSet Select_Edit_order(string orderId)
        {
            DataSet dt = new DataSet();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@orderId", orderId);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDataSet("Prc_Select_Edit_order", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public string UpdateApproverEmail(string Refno, string Email)
        {

            con.Open();
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.StoredProcedure;
            cmd0.Parameters.AddWithValue("@OrderReferenceNo", Refno);
            cmd0.Parameters.AddWithValue("@ApproverEmail", Email);
            cmd0.CommandText = "Prc_Update_Approver_email";
            try
            {
                if (cmd0.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            return "true";

        }
        public string UpdateResendApproverEmail(string Refno, string Counter)
        {
            Int32 count = Convert.ToInt32(Counter);
            count = count + 1;
            con.Open();
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.StoredProcedure;
            cmd0.Parameters.AddWithValue("@Ref_no", Refno);
            cmd0.Parameters.AddWithValue("@Counter", count);
            cmd0.CommandText = "Prc_Update_resend_email_Counter";
            try
            {
                if (cmd0.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            return "true";

        }
        public string UpdateOrderStatus(string Refno, string status,string _OrderCompleteDate,
            string _OrderStateReasonDetails,string _OrderStatusMajor,string _getPKCS7, string _AuthenticationStatuses,
            string AuthenticationComment,string StartDate, string EndDate,string _Price,int _ValidityPeriod)
        {
            
            con.Open();
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.StoredProcedure;
            cmd0.Parameters.AddWithValue("@OrderReferenceNo", Refno);
            cmd0.Parameters.AddWithValue("@Status", status);
            cmd0.Parameters.AddWithValue("@OrderCompleteDate", _OrderCompleteDate);
            cmd0.Parameters.AddWithValue("@OrderStateReasonDetails", _OrderStateReasonDetails);
            cmd0.Parameters.AddWithValue("@OrderStatusMajor", _OrderStatusMajor);
            cmd0.Parameters.AddWithValue("@getPKCS7", _getPKCS7);
            cmd0.Parameters.AddWithValue("@AuthenticationStatuses", _AuthenticationStatuses);
            cmd0.Parameters.AddWithValue("@AuthenticationComment", AuthenticationComment);
            cmd0.Parameters.AddWithValue("@CertificateInfo_StartDate", StartDate);
            cmd0.Parameters.AddWithValue("@CertificateInfo_EndDate", EndDate);
            cmd0.Parameters.AddWithValue("@Price", _Price);
            cmd0.Parameters.AddWithValue("@ValidityPeriod", _ValidityPeriod);
            
            cmd0.CommandText = "Prc_Update_Order_Status";
            try
            {
                if (cmd0.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            finally {
                con.Close();
                cmd0.Dispose();
            }
            return "true";

        }

        public string InsertReissueOrder(ClsReissueOrderML obj)
        {

            con.Open();
            SqlCommand cmd0 = con.CreateCommand();
            cmd0.CommandType = CommandType.StoredProcedure;
          
            cmd0.Parameters.AddWithValue("@OrderReferenceNo", obj.OrderReferenceNo);
            cmd0.Parameters.AddWithValue("@OrignalOrderReferenceNo", obj.OrignalOrderReferenceNo);
            cmd0.Parameters.AddWithValue("@AdditionalSan", obj.AdditionalSan);
            cmd0.Parameters.AddWithValue("@ItemStatus", obj.ItemStatus);
            cmd0.Parameters.AddWithValue("@ApproverEmail", obj.ApproverEmail);
            cmd0.Parameters.AddWithValue("@CsrContents", obj.CsrContents);
            cmd0.Parameters.AddWithValue("@SymantecOrderId", obj.SymantecOrderId);
            cmd0.Parameters.AddWithValue("@SubmittedDate", obj.SubmittedDate);
            cmd0.Parameters.AddWithValue("@SubmissionResponse", obj.SubmissionResponse);
            cmd0.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd0.CommandText = "Prc_Insert_reissue_Order";
            try
            {
                if (cmd0.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            return "true";

        }

        public string Place_Ready_IssuanceOrder(string PartnerOrderID,string SymantecOrderId,
            clsPlace_Ready_Issuance_OrganizationML _clsPlace_Ready_IssuanceML,
            clsPlace_Ready_Issuance_DomainML[] _clsPlace_Ready_Issuance_DomainML,
            clsPlace_Ready_Issuance_ContactPairML[] _clsPlace_Ready_Issuance_ContactPairML)
        {
            
            con.Open();
            string orderid = "";
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_insert_tblPlace_Ready_Issuance_Head";
            cmd.Parameters.AddWithValue("@orderid", SqlDbType.BigInt);
            cmd.Parameters["@orderid"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@PartnerOrderID", PartnerOrderID);
            cmd.Parameters.AddWithValue("@SymantecOrderId", SymantecOrderId);
            cmd.Parameters.AddWithValue("@OrganizationName", _clsPlace_Ready_IssuanceML.OrganizationName);
            cmd.Parameters.AddWithValue("@Address1", _clsPlace_Ready_IssuanceML.Address1);
            cmd.Parameters.AddWithValue("@Address2", _clsPlace_Ready_IssuanceML.Address2);
            cmd.Parameters.AddWithValue("@City", _clsPlace_Ready_IssuanceML.City);
            cmd.Parameters.AddWithValue("@Outside_US", _clsPlace_Ready_IssuanceML.Outside_US);
            cmd.Parameters.AddWithValue("@within_US", _clsPlace_Ready_IssuanceML.within_US);
            cmd.Parameters.AddWithValue("@Postal_code", _clsPlace_Ready_IssuanceML.Postal_code);
            cmd.Parameters.AddWithValue("@Country", _clsPlace_Ready_IssuanceML.Country);
            cmd.Parameters.AddWithValue("@Phone", _clsPlace_Ready_IssuanceML.Phone);
            cmd.Parameters.AddWithValue("@AddedBy", _clsPlace_Ready_IssuanceML.AddedBy);
         


            cmd.ExecuteNonQuery();
            orderid = Convert.ToString(cmd.Parameters["@orderid"].Value);
                      
            foreach (clsPlace_Ready_Issuance_DomainML prp in _clsPlace_Ready_Issuance_DomainML)
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "prc_Insert_tblPlace_Ready_Issuance_Domain";
                cmd1.Parameters.AddWithValue("@orderid", orderid);
                cmd1.Parameters.AddWithValue("@DomainName", prp.DomainName);
                cmd1.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
               
                cmd1.ExecuteNonQuery();
            }

            foreach (clsPlace_Ready_Issuance_ContactPairML prp in _clsPlace_Ready_Issuance_ContactPairML)
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "prc_Insert_tblPlace_Ready_Issuance_ContactPair";
                cmd2.Parameters.AddWithValue("@orderid", orderid);
                cmd2.Parameters.AddWithValue("@OrganizationName", prp.OrganizationName);
                cmd2.Parameters.AddWithValue("@ccFirst_name", prp.ccFirst_name);
                cmd2.Parameters.AddWithValue("@ccLast_name", prp.ccLast_name);
                cmd2.Parameters.AddWithValue("@ccTitle", prp.ccTitle);
                cmd2.Parameters.AddWithValue("@ccEmail", prp.ccEmail);
                cmd2.Parameters.AddWithValue("@ccContact", prp.ccContact);
                cmd2.Parameters.AddWithValue("@ccComp_Name", prp.ccComp_Name);
                cmd2.Parameters.AddWithValue("@ccAddress1", prp.ccAddress1);
                cmd2.Parameters.AddWithValue("@ccAddress2", prp.ccAddress2);
                cmd2.Parameters.AddWithValue("@ccCity", prp.ccCity);
                cmd2.Parameters.AddWithValue("@ccwithin_US", prp.ccwithin_US);
                cmd2.Parameters.AddWithValue("@ccOutside_US", prp.ccOutside_US);
                cmd2.Parameters.AddWithValue("@ccPostal_code", prp.ccPostal_code);
                cmd2.Parameters.AddWithValue("@ccCountry", prp.ccCountry);

                cmd2.Parameters.AddWithValue("@tcFirst_name", prp.tcFirst_name);
                cmd2.Parameters.AddWithValue("@tcLast_name", prp.tcLast_name);
                cmd2.Parameters.AddWithValue("@tcTitle", prp.tcTitle);
                cmd2.Parameters.AddWithValue("@tcEmail", prp.tcEmail);
                cmd2.Parameters.AddWithValue("@tcContact", prp.tcContact);
                cmd2.Parameters.AddWithValue("@tcComp_Name", prp.tcComp_Name);
                cmd2.Parameters.AddWithValue("@tcAddress1", prp.tcAddress1);
                cmd2.Parameters.AddWithValue("@tcAddress2", prp.tcAddress2);
                cmd2.Parameters.AddWithValue("@tcCity", prp.tcCity);
                cmd2.Parameters.AddWithValue("@tcwithin_US", prp.tcwithin_US);
                cmd2.Parameters.AddWithValue("@tcOutside_US", prp.tcOutside_US);
                cmd2.Parameters.AddWithValue("@tcPostal_code", prp.tcPostal_code);
                cmd2.Parameters.AddWithValue("@tcCountry", prp.tcCountry);
                cmd2.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
            
                cmd2.ExecuteNonQuery();
            }
            
            return orderid;
        }

    }
}

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
    public class ClsCustomerEnquiryBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        public string InsertEnquiry(ClsCustomerEnqueryML obj)
        {
            try
            {
                con.Open();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ORG_NAME", obj.ORG_NAME);
                cmd1.Parameters.AddWithValue("@NAME_PERSON", obj.NAME_PERSON);
                cmd1.Parameters.AddWithValue("@DESIGNATION", obj.DESIGNATION);
                cmd1.Parameters.AddWithValue("@MOBILE_NO", obj.MOBILE_NO);
                cmd1.Parameters.AddWithValue("@ENQUIRY_DATE", obj.ENQUIRY_DATE);
                cmd1.Parameters.AddWithValue("@COUNTRY_ID", obj.COUNTRY);
                cmd1.Parameters.AddWithValue("@STATE_ID", obj.STATE);
                cmd1.Parameters.AddWithValue("@CITY_ID", obj.CITY);
                cmd1.Parameters.AddWithValue("@PLOT_NO", obj.PLOT_NO);
                cmd1.Parameters.AddWithValue("@STREET", obj.STREET);
                cmd1.Parameters.AddWithValue("@SECTOR", obj.SECTOR);
                cmd1.Parameters.AddWithValue("@DISTRICT", obj.DISTRICT);
                cmd1.Parameters.AddWithValue("@PHONE_NO", obj.PHONE_NO);
                cmd1.Parameters.AddWithValue("@EMAIL", obj.EMAIL);
                cmd1.Parameters.AddWithValue("@CONTACT_TYPE", obj.CONTACT_TYPE);
                cmd1.Parameters.AddWithValue("@ATTENDED_BY", obj.ATTENDED_BY);
                cmd1.Parameters.AddWithValue("@MODE_ENQUIRY", obj.MODE_ENQUIRY);
                cmd1.Parameters.AddWithValue("@OTHER_REMARKS", obj.OTHER_REMARKS);
                cmd1.Parameters.AddWithValue("@INTERESTED_PRODUCT", obj.INTERESTED_PRODUCT);
                cmd1.Parameters.AddWithValue("@VISITING_CARD", obj.VISITING_CARD);
                cmd1.Parameters.AddWithValue("@VISITING_CARD_PATH", obj.VISITING_CARD_PATH);
                cmd1.Parameters.AddWithValue("@REMARKS", obj.REMARKS);
                cmd1.Parameters.AddWithValue("@CREATED_BY", obj.CREATED_BY);
                cmd1.Parameters.AddWithValue("@ENQUIRY_STATUS", obj.ENQUIRY_STATUS);
                cmd1.Parameters.Add("@ENQUIRY_NO", SqlDbType.VarChar, 100);
                cmd1.CommandText = "INSERT_CUSTOMER_ENQUIRY";
                cmd1.Parameters["@ENQUIRY_NO"].Direction = ParameterDirection.Output;
                if (cmd1.ExecuteNonQuery() < 0)
                {

                    return "false";
                }
                obj.ENQUIRY_NO = (string)cmd1.Parameters["@ENQUIRY_NO"].Value;
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
            return obj.ENQUIRY_NO;
        }
        public void fill_Product_Drop(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_Product_Drop", CommandType.Text);
        }
        public void fill_country_list(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "fill_country_list", CommandType.Text);
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
            string value = "0";
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@ProductId", prodid);
            BaseCommon bc = new BaseCommon();
            return bc.GetDatatable("Prc_Select_product_Price", CommandType.StoredProcedure, objSqlParam);
        }
        public string InsertEnquiryDetails(ClsCustomerEnqueryML obj)
        {
            try
            {
                con.Open();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ENQUIRY_NO", obj.ENQUIRY_NO);
                cmd1.Parameters.AddWithValue("@ENQUIRY_STATUS", obj.ENQUIRY_STATUS);
                cmd1.Parameters.AddWithValue("@REMARKS", obj.REMARKS);
                cmd1.Parameters.AddWithValue("@ENQUIRY_DATE", obj.ENQUIRY_DATE);
                cmd1.Parameters.AddWithValue("@CREATED_BY", obj.CREATED_BY);
                cmd1.CommandText = "INSERT_CUSTOMER_ENQUIRY_DETAILS";

                if (cmd1.ExecuteNonQuery() < 0)
                {

                    return "false";
                }

                if (obj.ENQUIRY_STATUS == "Close")
                {
                    try
                    {
                        SqlCommand CMD = con.CreateCommand();
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.AddWithValue("@ENQUIRY_NO", obj.ENQUIRY_NO);
                        CMD.CommandText = "UPDATE_ENQUIRY_STATUS";
                        if (CMD.ExecuteNonQuery() < 0)
                        {

                            // return "false";
                        }
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                        DL.BaseCommon objerr = new DL.BaseCommon();
                        objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                        return "false";
                    }
                }
                if (obj.ENQUIRY_STATUS == "Close & Generate Proposal")
                {
                    try
                    {
                        SqlCommand CMD = con.CreateCommand();
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.AddWithValue("@ENQUIRY_NO", obj.ENQUIRY_NO);
                        CMD.CommandText = "UPDATE_ENQUIRY_STATUS";
                        if (CMD.ExecuteNonQuery() < 0)
                        {

                            // return "false";
                        }

                        //ClsProposalML objprop = new ClsProposalML();
                        //DataTable dtprod = BaseCommon.GetDataSet("Prc_Get_product_detail_Enquery_Wise '" + obj.ENQUIRY_NO + "'", CommandType.Text).Tables[0];
                        //if (dtprod.Rows.Count > 0)
                        //{
                        //    decimal price = Convert.ToDecimal(dtprod.Rows[0]["Listprice"]);
                        //    decimal servicetaxamont = (price * 14) / 100;
                        //    decimal swchbharat = Convert.ToDecimal((Convert.ToDouble(price) * .5) / 100);
                        //    decimal Krisi_Klayan_tax = Convert.ToDecimal((Convert.ToDouble(price) * .5) / 100);
                        //    decimal totalamount = price + servicetaxamont + swchbharat + Krisi_Klayan_tax;
                        //    objprop.Unit_price = price.ToString();
                        //    objprop.Units = "1";
                        //    objprop.Total_price = price.ToString();
                        //    objprop.Total_amount = totalamount.ToString();
                        //    objprop.Amount = price.ToString();
                        //    objprop.Krisi_Klayan_amount = Krisi_Klayan_tax.ToString();
                        //    objprop.Krisi_Klayan_tax = "0.5";
                        //    objprop.Pod_san_No = dtprod.Rows[0]["SanName"].ToString();
                        //    objprop.Prod_description = dtprod.Rows[0]["FullDescription"].ToString();
                        //    objprop.Prod_id = dtprod.Rows[0]["INTERESTED_PRODUCT"].ToString();
                        //    objprop.Prod_name = dtprod.Rows[0]["Name"].ToString();
                        //    objprop.Prod_other = "";
                        //    objprop.Prod_Seal = "XXXXX";// dtprod.Rows[0][""].ToString();
                        //    objprop.Prod_validate = dtprod.Rows[0]["ProductGroup"].ToString();
                        //    objprop.Prod_validity = dtprod.Rows[0]["NoOfYears"].ToString();
                        //    objprop.Netsure_Warranty = dtprod.Rows[0]["Warranty"].ToString();
                        //    objprop.Service_tax = "14";
                        //    objprop.Service_tax_amount = servicetaxamont.ToString();
                        //    objprop.Ssl_Encryption = "XXXX";
                        //    objprop.Swach_bharat_amount = swchbharat.ToString();
                        //    objprop.Swach_bharat_tax = "0.5";
                        //}
                        //objprop.Vendorid = "XXXXXX";

                        //objprop.Contact_preson = "";
                        //objprop.Contectno = "";
                        //objprop.Contect_email = "";
                        //objprop.TempEnqno = obj.ENQUIRY_NO;
                        //objprop.Created_by = obj.CREATED_BY;
                        //objprop.Cust_code = "";
                        //objprop.Expirein = "7 Days";
                        //objprop.From_email = "";
                        //objprop.From_Manager = "";
                        //objprop.From_Mobile = "";

                        //objprop.Quote_date = System.DateTime.Now.ToString();


                        //ClsProposalBL dlprop = new ClsProposalBL();
                        //string proposalno = dlprop.InsertProposal(objprop);
                        //if (proposalno != "false")
                        //{
                        //    return proposalno;
                        //}


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
            return obj.ENQUIRY_NO;
        }


        //start Pending enq
        public DataTable getPENDINGENQUIRYList(string Emp_code,string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
           dt = bc.GetDatatable("Prc_Select_pending_lead_list", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable getPENDINGENQUIRY(string fromdate, string todate, string status, string Emp_code, string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@fdate", fromdate);
            objSqlParam[1] = new SqlParameter("@tdate", todate);
            objSqlParam[2] = new SqlParameter("@status", status);
            objSqlParam[3] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[4] = new SqlParameter("@Level", Level);

            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_pending_lead", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable getAllENQUIRY(string Emp_code, string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_All_lead", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable getTodayENQUIRY(string Emp_code, string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_Today_lead", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }

        public DataTable getClosedENQUIRY(string Emp_code,string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[1] = new SqlParameter("@Level", Level);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Select_Closed_lead", CommandType.StoredProcedure, objSqlParam);
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

        public DataTable SelectSingleproposal(string QuoteNo)
        {
            DataTable dt = new DataTable();
            //ClsProposalBL dal = new ClsProposalBL();
            return dt;// dal.SelectSingleproposal(QuoteNo);
        }

        //end enqhistory

        //start enqReport
        public DataTable grtENQUIRYREPORT(string fdate, string tdate, string status)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@fdate", fdate);
            objSqlParam[1] = new SqlParameter("@tdate", tdate);
            objSqlParam[2] = new SqlParameter("@status", status);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("ENQUIRY_REPORT", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        //End EnqReport


    }
}

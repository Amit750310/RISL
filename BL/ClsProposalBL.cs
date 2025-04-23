using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using ML;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BL
{
    public class ClsProposalBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";
        BaseCommon commen = new BaseCommon();
        public void fill_Contactperso_Drop(ref DropDownList Xddl, string OrgInfoID)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            BaseCommon.FillDropDown(ref Xddl, "Prc_fill_dropdown_Leadcontactperson", CommandType.StoredProcedure, objSqlParam);

        }

        public DataTable GetContanctDetail(string OrgInfoID, string ContactID)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            objSqlParam[1] = new SqlParameter("@ContactID", ContactID);
            return commen.GetDatatable("Prc_Get_Leadcontactperson_detail", CommandType.StoredProcedure, objSqlParam);
        }

        public DataTable GetProductLeadwise(string OrgInfoID)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@OrgInfoID", OrgInfoID);
            return commen.GetDatatable("Prc_selectproduct_leadwise", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable GetproposalTermsMaster()
        {
            
            
            return commen.GetDatatable("PRc_Select_proposalTermsMaster", CommandType.StoredProcedure);
        }
        public string InsertProposal(ClsProposalML obj, ClsProposalproductML[] child, ClsProposalTermsML[] objProposalTermsML)
        {
            try
            {
                con.Open();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.AddWithValue("@OrgInfoID", obj.OrgInfoID);
                cmd1.Parameters.AddWithValue("@Expirein", obj.Expirein);
                cmd1.Parameters.AddWithValue("@Vendorid", obj.Vendorid);
                cmd1.Parameters.AddWithValue("@Cust_code", obj.Cust_code);
                cmd1.Parameters.AddWithValue("@From_Manager", obj.From_Manager);
                cmd1.Parameters.AddWithValue("@From_email", obj.From_email);
                cmd1.Parameters.AddWithValue("@From_Mobile", obj.From_Mobile);
                cmd1.Parameters.AddWithValue("@Contact_preson", obj.Contact_preson);
                cmd1.Parameters.AddWithValue("@Contectno", obj.Contectno);
                cmd1.Parameters.AddWithValue("@Contect_email", obj.Contect_email);
                cmd1.Parameters.AddWithValue("@Quote_date", obj.Quote_date);
                cmd1.Parameters.AddWithValue("@Quote_Expires", obj.Quote_Expires);
                cmd1.Parameters.AddWithValue("@Amount", obj.Amount);
                cmd1.Parameters.AddWithValue("@IsTax", obj.Istax);
                cmd1.Parameters.AddWithValue("@IsItemPrice", obj.IsItemPrice);
                cmd1.Parameters.AddWithValue("@IsWithTotalPrice", obj.IsWithTotalPrice);
                cmd1.Parameters.AddWithValue("@Created_by", obj.Created_by);
                cmd1.Parameters.AddWithValue("@TempEnqno", obj.TempEnqno);
                cmd1.Parameters.AddWithValue("@Netsure_Warranty", obj.Netsure_Warranty);
                cmd1.Parameters.Add("@QuoteNo", SqlDbType.VarChar, 50);
                cmd1.Parameters.Add("@id", SqlDbType.VarChar, 50);
                cmd1.CommandText = "prc_Insertproposal";
                cmd1.Parameters["@QuoteNo"].Direction = ParameterDirection.Output;
                cmd1.Parameters["@id"].Direction = ParameterDirection.Output;
                if (cmd1.ExecuteNonQuery() < 0)
                {

                    return "false";
                }
                obj.QuoteNo = (string)cmd1.Parameters["@QuoteNo"].Value;
                obj.ID = (string)cmd1.Parameters["@id"].Value;
                foreach (ClsProposalproductML prp in child)
                {
                    try
                    {
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.StoredProcedure;
                        //cmd2.Parameters.AddWithValue("@ID", prp.ID);
                        cmd2.Parameters.AddWithValue("@Propsal_id", obj.ID);
                        cmd2.Parameters.AddWithValue("@Brand_name", prp.Brand_name);
                        cmd2.Parameters.AddWithValue("@Brand_id", prp.Brand_id);
                        cmd2.Parameters.AddWithValue("@Prod_name", prp.Prod_name);
                        cmd2.Parameters.AddWithValue("@Prod_id", prp.Prod_id);
                        //cmd2.Parameters.AddWithValue("@Prod_validate", prp.Prod_validate);
                        //cmd2.Parameters.AddWithValue("@Pod_san_No", prp.Pod_san_No);
                        //cmd2.Parameters.AddWithValue("@Prod_Seal", prp.Prod_Seal);
                        //cmd2.Parameters.AddWithValue("@Ssl_Encryption", prp.Ssl_Encryption);
                        cmd2.Parameters.AddWithValue("@Prod_validity", prp.Prod_validity);
                        cmd2.Parameters.AddWithValue("@Unit_price", prp.Unit_price);
                        cmd2.Parameters.AddWithValue("@QTY", prp.QTY);
                        cmd2.Parameters.AddWithValue("@Discount", prp.Discount);
                        cmd2.Parameters.AddWithValue("@Offer_price", prp.Offer_price);
                        cmd2.Parameters.AddWithValue("@Total_price", prp.Total_price);
                        cmd2.Parameters.AddWithValue("@AddedBy", prp.AddedBy);
                        cmd2.Parameters.AddWithValue("@San_Name", prp.San_Name);
                        cmd2.Parameters.AddWithValue("@San_Price", prp.San_Price);
                        cmd2.Parameters.AddWithValue("@San_QTY", prp.San_QTY);
                        cmd2.Parameters.AddWithValue("@San_Discount", prp.San_Discount);
                        cmd2.Parameters.AddWithValue("@San_Offer_price", prp.San_Offer_price);
                        cmd2.Parameters.AddWithValue("@San_Amount", prp.San_Amount);
                        cmd2.Parameters.AddWithValue("@Is_San", prp.Is_San);
                        cmd2.Parameters.AddWithValue("@ModifiedBy", prp.ModifiedBy);
                        cmd2.Parameters.AddWithValue("@FQDN", prp.FQDN);
                        cmd2.Parameters.AddWithValue("@FQDNSAN", prp.FQDNSAN);
                        cmd2.CommandText = "prcinsertproposalproduct";
                        if (cmd2.ExecuteNonQuery() < 0)
                        {

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


                foreach (ClsProposalTermsML prp in objProposalTermsML)
                {
                    try
                    {
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@Propsal_id", obj.ID);
                        cmd2.Parameters.AddWithValue("@TermsId", prp.TermsId);
                        cmd2.Parameters.AddWithValue("@TermsValue", prp.TermsValue);
                        cmd2.CommandText = "PRc_insert_proposalTerms";
                        if (cmd2.ExecuteNonQuery() < 0)
                        {

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
            return obj.QuoteNo;
        }

        public DataSet SelectSingleproposal(string QuoteNo)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@QuoteNo", QuoteNo);
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_SelectSingleproposal", CommandType.StoredProcedure, objSqlParam);
            ds.Tables.Add(dt);
            SqlParameter[] objSqlParam1 = new SqlParameter[1];
            objSqlParam1[0] = new SqlParameter("@QuoteNo", QuoteNo);
            ds.Tables.Add(bc.GetDatatable("PRc_Select_proposal_product", CommandType.StoredProcedure, objSqlParam1));

            SqlParameter[] objSqlParam2 = new SqlParameter[1];
            objSqlParam2[0] = new SqlParameter("@QuoteNo", QuoteNo);
            ds.Tables.Add(bc.GetDatatable("PRc_get_proposalTerms", CommandType.StoredProcedure, objSqlParam2));

            return ds;
        }
    }
}

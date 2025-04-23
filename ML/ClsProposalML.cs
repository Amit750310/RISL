using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ClsProposalML
    {

        public string OrgInfoID { get; set; }
        public string ID { get; set; }
        public string QuoteNo { get; set; }
        public string Expirein { get; set; }
        public string Vendorid { get; set; }
        public string Cust_code { get; set; }
        public string From_Manager { get; set; }
        public string From_email { get; set; }
        public string From_Mobile { get; set; }
        public string Contact_preson { get; set; }
        public string Contectno { get; set; }
        public string Contect_email { get; set; }
        public string Quote_date { get; set; }
        public string Prod_name { get; set; }
        public string Prod_id { get; set; }
        public string Prod_description { get; set; }
        public string Prod_validate { get; set; }
        public string Pod_san_No { get; set; }
        public string Prod_Seal { get; set; }
        public string Ssl_Encryption { get; set; }
        public string Prod_validity { get; set; }
        public string Prod_other { get; set; }
        public string Unit_price { get; set; }
        public string Units { get; set; }
        public string Total_price { get; set; }
        public string Amount { get; set; }
        //public string Service_tax { get; set; }
        //public string Service_tax_amount { get; set; }
        //public string Swach_bharat_tax { get; set; }
        //public string Swach_bharat_amount { get; set; }
        //public string Krisi_Klayan_tax { get; set; }
        //public string Krisi_Klayan_amount { get; set; }
        public string Total_amount { get; set; }
        public string Created_at { get; set; }
        public string TempEnqno { get; set; }
        public string Quote_Expires { get; set; }

        public string Created_by { get; set; }
        public string Netsure_Warranty { get; set; }
        public bool Istax { get; set; }
        public bool IsItemPrice { get; set; }
        public bool IsWithTotalPrice { get; set; }
        public string Currency_id { get; set; }

    //public string SGST { get; set; }
    //public string SGST_amount { get; set; }
    //public string CGST { get; set; }
    //public string CGST_amount { get; set; }
    //public string IGST { get; set; }
    //public string IGST_amount { get; set; }
    //public bool isIGST { get; set; }

    }

    public class ClsProposalproductML
    {
        public string ID { get; set; }
        public string Propsal_id { get; set; }
        public string Brand_name { get; set; }
        public string Brand_id { get; set; }
        public string Prod_name { get; set; }
        public string Prod_id { get; set; }
        public string Prod_validate { get; set; }
        public string Pod_san_No { get; set; }
        public string Prod_Seal { get; set; }
        public string Ssl_Encryption { get; set; }
        public string Prod_validity { get; set; }
        public string Unit_price { get; set; }
        public string QTY { get; set; }
        public string Discount { get; set; }
        public string Offer_price { get; set; }
        public string Total_price { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string San_Name { get; set; }
        public string San_Price { get; set; }
        public string San_QTY { get; set; }
        public string San_Discount { get; set; }
        public string San_Offer_price { get; set; }
        public string San_Amount { get; set; }
   
        public bool  Is_San { get; set; }
        public string FQDN { get; set; }
        public string FQDNSAN { get; set; }

    }
    public class ClsProposalTermsML
    {
        public string Propsal_id { get; set; }
        public string TermsId { get; set; }
       public string TermsValue { get; set; }
    }
    }

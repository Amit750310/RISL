using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class clsPlaceOrderML
    {
        #region Header Property
        public string OrderId { get; set; }
        public string OrgInfoID { get; set; }

        public string CustomerId { get; set; }
        public string CustResellerId { get; set; }
        public string OrderStatus { get; set; }
        public string PlacerIpAddress { get; set; }
        public string PlacementStatus { get; set; }
        public string OrderApprovalStatus { get; set; }
        public string BrandInfo { get; set; }
        public string Istax { get; set; }
        public string Amount { get; set; }
        public string Service_tax { get; set; }
        public string Service_tax_amount { get; set; }
        public string Swach_bharat_tax { get; set; }
        public string Swach_bharat_amount { get; set; }
        public string Krisi_Klayan_tax { get; set; }
        public string Krisi_Klayan_amount { get; set; }
        public string Total_amount { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string AddedBy { get; set; }
        public string Mode { get; set; }
        public string CRMRemarks { get; set; }
        public string OLDOrderItemId { get; set; }
        

        #endregion
        #region  Details Property
        public string OrderItemId { get; set; }
        public string Server_Licenses { get; set; }
        public string ProductId { get; set; }
        public string Proposalproduct_id { get; set; }
        public string TotalYears { get; set; }
        public string Unit_price { get; set; }
        public string QTY { get; set; }
        public string Discount { get; set; }
        public string Offer_price { get; set; }
        public string Total_price { get; set; }
        public string AdditionalSan { get; set; }
        public string TotalServers { get; set; }
        public string ProductType { get; set; }
        public string ItemStatus { get; set; }
        public string Comments { get; set; }
        public string OrganizationName { get; set; }
        public string DomainName { get; set; }
        public string CsrContents { get; set; }
        public string CUCertificate { get; set; }
        public string OriginalPartnerOrderID { get; set; }
        public string symcOrderID { get; set; }

        public string ServerType { get; set; }
        public string EncryptionAlgorithm { get; set; }

        public string CertTransparency { get; set; }
        public string CTPrivacy { get; set; }


        public string ContractId { get; set; }
        public string SerialNumber { get; set; }
        public string AuthType { get; set; }
        public string CertChainType { get; set; }
        public string SubmissionResponse { get; set; }
        public string SubmittedDate { get; set; }
        public string Pkcs { get; set; }
        public string x509 { get; set; }
        public string SymantecOrderId { get; set; }
        public string CertificateSerialNumber { get; set; }
        public string SubDomain { get; set; }
        public string ProductName { get; set; }
        public string productGroup { get; set; }
        public int ValidityPeriod { get; set; }
        public string COMMON_NAME { get; set; }
        public string Renewal { get; set; }
        public string competitive_replacment { get; set; }
        public string special_instruction { get; set; }
        public string ENCRYPTION_TYPE { get; set; }

        public string Enrolment_Sheet { get; set; }
        public string Enrolment_Sheet_path { get; set; }
        public string Csr_Txt { get; set; }
        public string Csr_Txt_path { get; set; }
        public string PO_File { get; set; }
        public string PO_File_path { get; set; }

 

        #endregion
        public string AdditionalDomain { get; set; }
        public string ApiOrderID { get; set; }
        public string PartnerOrderID { get; set; }
        public string ApproverEmail { get; set; }
        public string CodeSigner { get; set; }

        public string ProductCode { get; set; }

        public string SalesOrderItemId { get; set; }

        public string DVAuthMethod { get; set; }
        public string DVAuthMethodContent { get; set; }

    }
    public class clsPlaceOrderAddressDetailsML
    {
        public string Addid { get; set; }
        public string CustInfoID { get; set; }
        public string Add_name { get; set; }
        public string Add_designation { get; set; }
        public string Add_Contact { get; set; }
        public string Add_Email { get; set; }
        public string Add_Address { get; set; }
        public string Type { get; set; }
        
        
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Cor_Legal_Name { get; set; }
        public string DBA_Name { get; set; }
        public string Division { get; set; }
        public string DUNS { get; set; }
        public string Fax { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string within_US { get; set; }
        public string Outside_US { get; set; }
        public string Postal_code { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Title { get; set; }
        public string Comp_Name { get; set; }
        public string Country { get; set; }
    }

    public class clsPlace_Ready_Issuance_OrganizationML
    {
        
        public string OrganizationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Outside_US { get; set; }
        public string within_US { get; set; }
        public string Postal_code { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AddedBy { get; set; }
        


    }
    public class clsPlace_Ready_Issuance_DomainML
    { public string DomainName { get; set; }
        public string AddedBy { get; set; }
    }
    public class clsPlace_Ready_Issuance_ContactPairML
    {
        
        public string OrganizationName { get; set; }
        public string ccFirst_name { get; set; }
        public string ccLast_name { get; set; }
        public string ccTitle { get; set; }
        public string ccEmail { get; set; }
        public string ccContact { get; set; }
        public string ccComp_Name { get; set; }
        public string ccAddress1 { get; set; }
        public string ccAddress2 { get; set; }
        public string ccCity { get; set; }
        public string ccwithin_US { get; set; }
        public string ccOutside_US { get; set; }
        public string ccPostal_code { get; set; }
        public string ccCountry { get; set; }


        public string tcCor_Legal_Name { get; set; }
        public string tcFirst_name { get; set; }
        public string tcLast_name { get; set; }
        public string tcTitle { get; set; }
        public string tcEmail { get; set; }
        public string tcContact { get; set; }
        public string tcComp_Name { get; set; }
        public string tcAddress1 { get; set; }
        public string tcAddress2 { get; set; }
        public string tcCity { get; set; }
        public string tcwithin_US { get; set; }
        public string tcOutside_US { get; set; }
        public string tcPostal_code { get; set; }
        public string tcCountry { get; set; }
        public string AddedBy { get; set; }


    }
}

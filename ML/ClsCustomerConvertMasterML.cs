using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML
{
    public class clstblCustomerInfoML
    {
        public int OrgInfoID { get; set; }

        public int CustInfoID { get; set; }
        public string OrganizationName { get; set; }
        public string CustomerType { get; set; }
        public string ContactType { get; set; }
        public string OrgGroup { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }

        public string Currency_id { get; set; }
    }
    public class clstblCustomerResellerInfoML
    {
        public string ResellerID { get; set; }
        public string CustInfoID { get; set; }
        public string ResellerName { get; set; }
        public string ResellerGroup { get; set; }
        public string VendorCode { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string Landline { get; set; }
        public string Companywebsite { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class clstblCustomerAddressML
    {
        public int CustInfoID { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Landline { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Companywebsite { get; set; }
        public string VendorCode { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }

      
        public string Other_Details { get; set; }
        public string Pancard_no { get; set; }
    }
    public class clstblCustomerContactML
    {
        public int CustInfoID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }


    }

    public class clstblCustomerAddressDetailsML 
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
}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML
{
    public class clstblLeadorganizationInfoML
    {
        public int OrgInfoID { get; set; }
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
    public class clstblLeadorganizationAddressML
    {
        public int OrgInfoID { get; set; }
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


    }
    public class clstblLeadResellerInfoML
    {
        public string ResellerID { get; set; }
        public string OrgInfoID { get; set; }
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
    public class clstblLeadContactML
    {
        public int OrgInfoID { get; set; }
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
    public class clstblLeadInfoML
    {
        public int OrgInfoID { get; set; }
        public string ModeOfLead { get; set; }
        public string BrandID { get; set; }
        public string ProductID { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class clstblLeadRemarksML
    {
        public int OrgInfoID { get; set; }
        public string Remarks { get; set; }
        public string VisitingCard { get; set; }
        public string VisitingCardPath { get; set; }
        public string CommonName { get; set; }
        
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class clstblLeadUpdationML
    {
        public int OrgInfoID { get; set; }
        public string LeadStatus { get; set; }
        public string NextActionDate { get; set; }
        public string Remarks { get; set; }
        public string SanName { get; set; }
        public string GSTNNumber { get; set; }
        public bool isPoPending { get; set; }
        public bool isTrail { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Enrolment_Sheet { get; set; }
        public string Enrolment_Sheet_path { get; set; }
        public string Csr_Txt { get; set; }
        public string Csr_Txt_path { get; set; }
        public string PO_File { get; set; }
        public string PO_File_path { get; set; }
    }
}

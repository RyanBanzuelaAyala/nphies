using System;
using System.Collections.Generic;
using System.Text;

namespace AG.Infra.Model.Params
{
    public class BranchCredentialsParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class EligibilityRequestParam : BranchCredentialsParam
    {
        public string InsuranceCode { get; set; }
        public string MembershipNo { get; set; }
        public string DepartmentCode { get; set; }
        public string ReferralIndicator { get; set; }
        public string IdCardNo { get; set; }
    }

    public class BUPA_PH_OPRequestParam
    {
        public int PreAuthId { get; set; }
        public int OPRequestId { get; set; }
        public int ReSubmit { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string DepartmentType { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }
        public double? EstimatedAmount { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MembershipNo { get; set; }
        public string PatientFileNo { get; set; }
        public string PhysicianName { get; set; }
        public string ProviderCode { get; set; }
        public string TreatmentType { get; set; }
        public List<BUPA_PH_RequestDetail> ItemDetail { get; set; }
    }

    public class BUPA_PH_RequestDetail
    {
        public int OPDoctorsOrderId { get; set; }
        public int? ItemNo { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
        public int? Quantity { get; set; }
        public double? EstimatedCost { get; set; }
        public int? Unit { get; set; }
        public string UnitType { get; set; }
        public int? Times { get; set; }
        public string Per { get; set; }
        public int? DayOfSupply { get; set; }
        public string ServiceType { get; set; }
        public DateTime SupplyDateFrom { get; set; }
        public DateTime SupplyDateTo { get; set; }
        public string DiagnosisCode { get; set; }
    }

    public class BUPA_PH_OPResponse
    {
        public long PreAuthId { get; set; }
        public int OPRequestId { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Remarks { get; set; }
        public List<BUPA_PH_ResponseDetail> ItemDetail { get; set; }
    }

    public class BUPA_PH_ResponseDetail
    {
        public int OPDoctorsOrderId { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Remarks { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }

    }

}

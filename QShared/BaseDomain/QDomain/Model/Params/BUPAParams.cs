using System;
using System.Collections.Generic;
using System.Text;

namespace AG.Infra.Model.Params
{

    public class BUPACommonSecret
    {
        public string ProviderId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
    }

    public class BUPAMembershipEligibility : BUPACommonSecret
    {
        public string MembershipNo { get; set; }
        public string ProviderCode { get; set; }
        public string DepartmentCode { get; set; }
        public string ReferralIndicator { get; set; }
        public string IdCardNo { get; set; }
    }

    public class BUPARequestCommonParam
    {
        public string age { get; set; }
        public int cardIssueNumber { get; set; }
        public string chiefComplaintsAndMainSymptoms { get; set; }
        public DateTime dateOfAdmission { get; set; }
        public string departmentType { get; set; }
        public List<string> detail_BenefitHead { get; set; }
        public List<double?> detail_EstimatedCost { get; set; }
        public List<int?> detail_ItemNo { get; set; }
        public List<long?> detail_Quantity { get; set; }
        public List<string> detail_ServiceCode { get; set; }
        public List<string> detail_ServiceDescription { get; set; }
        public string diagnosisCode { get; set; }
        public string diagnosisDescription { get; set; }
        public double? estimatedAmount { get; set; }
        public string gender { get; set; }
        public int lengthOfStay { get; set; }
        public string memberID_Igama { get; set; }
        public string memberMobileNo { get; set; }
        public string memberName { get; set; }
        public string membershipNo { get; set; }
        public string patientFileNo { get; set; }
        public string physician_Name { get; set; }
        public string processUser { get; set; }
        public string providerCode { get; set; }
        public string providerFaxNo { get; set; }
        public int quantity { get; set; }
        public int transactionID { get; set; }
        public string treatmentType { get; set; }
        public string trustedDoctor { get; set; }
        public int verificationID { get; set; }
        public string workRelated { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class BUPAPharmacyApprovalRequest : BUPARequestCommonParam
    {
        public BUPAPharmacyApprovalRequest() {
            detail = new List<string>();
            detail_BenefitHead = new List<string>();
            detail_Dosage = new List<string>();
            detail_Referral_Ind = new List<string>();
            detail_DayOfSupply = new List<int?>();
            detail_DiagnosisCode = new List<string>();
            detail_EstimatedCost = new List<double?>();
            detail_ExemptCat = new List<string>();
            detail_ItemNo = new List<int?>();
            detail_Per = new List<string>();
            detail_Quantity = new List<long?>();
            detail_Remark = new List<string>();
            detail_ServiceCode = new List<string>();
            detail_ServiceDescription = new List<string>();
            detail_ServiceType = new List<string>();
            detail_SupplyDateFrom = new List<DateTime>();
            detail_SupplyDateTo = new List<DateTime>();
            detail_SupplyPeriod = new List<string>();
            detail_Times = new List<int?>();
            detail_Unit = new List<int?>();
            detail_UnitType = new List<string>();
            exDetail = new List<string>();
        }

        public string IVF_Pregnancy { get; set; }
        public string RTA { get; set; }
        public string abortion { get; set; }
        public string bloodPressure { get; set; }
        public string checkUp { get; set; }
        public List<string> detail { get; set; }
        public string chronic { get; set; }
        public string congenital { get; set; }
        public int? death { get; set; }
        public List<int?> detail_DayOfSupply { get; set; }
        public List<string> detail_DiagnosisCode { get; set; }
        public List<string> detail_Dosage { get; set; }
        public List<string> detail_ExemptCat { get; set; }
        public List<string> detail_Per { get; set; }
        public List<string> detail_Referral_Ind { get; set; }
        public List<string> detail_Remark { get; set; }
        public List<string> detail_ServiceType { get; set; }
        public List<DateTime> detail_SupplyDateFrom { get; set; }
        public List<DateTime> detail_SupplyDateTo { get; set; }
        public List<string> detail_SupplyPeriod { get; set; }
        public List<int?> detail_Times { get; set; }
        public List<int?> detail_Unit { get; set; }
        public List<string> detail_UnitType { get; set; }
        public string durationOfIllness { get; set; }
        public List<string> exDetail { get; set; }
        public string exempted { get; set; }
        public DateTime? expected_Delivery_Date { get; set; }
        public int? gravida { get; set; }
        public string infertility { get; set; }
        public DateTime? last_Menstrual_Period { get; set; }
        public int? live { get; set; }
        public string medAutoValidateCode { get; set; }
        public string normal_Pregnancy { get; set; }
        public string otherConditions { get; set; }
        public int? para { get; set; }
        public string policyNo { get; set; }
        public string possibleLineOfTreatment { get; set; }
        public int preauthorisation_ID { get; set; }
        public string psychiatric { get; set; }
        public double? pulse { get; set; }
        public string referral { get; set; }
        public double? temperature { get; set; }
        public string transactionType { get; set; }
        public string vaccination { get; set; }

    }

    public class BUPADentalApprovalRequest : BUPARequestCommonParam
    {
        public List<string> detail_ServiceType { get; set; }
        public List<string> detail_ToothNo { get; set; }
        public List<string> detail_ToothNo_FDI { get; set; }
        public string RTA { get; set; }
        public string orthodontics { get; set; }
        public string checkUp { get; set; }
        public string congenitalDevelopmental { get; set; }
        public string cleaning { get; set; }
        public List<string> detail { get; set; }

    }

    public class BUPADiagnosisApprovalRequest : BUPARequestCommonParam
    {
        public string IVF_Pregnancy { get; set; }
        public string RTA { get; set; }
        public string abortion { get; set; }
        public string bloodPressure { get; set; }
        public string checkUp { get; set; }
        public string chronic { get; set; }
        public string congenital { get; set; }
        public int death { get; set; }
        public List<int> detail_ExemptCat { get; set; }
        public List<string> detail_Referral_Ind { get; set; }
        public List<string> detail_RequestCategory { get; set; }
        public List<string> detail_ServiceType { get; set; }
        public List<DateTime> detail_SupplyDateFrom { get; set; }
        public List<DateTime> detail_SupplyDateTo { get; set; }
        public List<string> detail_SupplyPeriod { get; set; }
        public string durationOfIllness { get; set; }
        public List<string> exDetail { get; set; }
        public string exempted { get; set; }
        public DateTime expected_Delivery_Date { get; set; }
        public int gravida { get; set; }
        public string infertility { get; set; }
        public DateTime lastMenstruationPeriod { get; set; }
        public DateTime last_Menstruation_Period { get; set; }
        public int live { get; set; }
        public string medAutoValidateCode { get; set; }
        public string normal_Pregnancy { get; set; }
        public string otherConditions { get; set; }
        public int para { get; set; }
        public string policyNo { get; set; }
        public int possibleLineOfTreatment { get; set; }
        public long preauthorisation_ID { get; set; }
        public string prevTelemedConsulInd { get; set; }
        public string psychiatric { get; set; }
        public double pulse { get; set; }
        public string referral { get; set; }
        public double temperature { get; set; }
        public string transactionType { get; set; }
        public string vaccination { get; set; }
        public List<string> detail { get; set; }

    }

    public class BUPAOpticalApprovalRequestParam : BUPARequestCommonParam
    {
        public double PD_Distance { get; set; }
        public double PD_Near { get; set; }
        public string benefitType { get; set; }
        public List<Detail> detail { get; set; }
        public List<string> detail_AntiReflectingCoating { get; set; }
        public List<string> detail_Anti_scratch { get; set; }
        public List<string> detail_Aspheric { get; set; }
        public List<string> detail_Bifocal { get; set; }
        public List<string> detail_Colored { get; set; }
        public List<string> detail_ContactLensesType { get; set; }
        public List<string> detail_Dark { get; set; }
        public List<string> detail_EyeTestReadingLeft { get; set; }
        public List<string> detail_EyeTestReadingRight { get; set; }
        public List<string> detail_HighIndex { get; set; }
        public List<string> detail_Lenticular { get; set; }
        public List<string> detail_Light { get; set; }
        public List<string> detail_Medium { get; set; }
        public List<string> detail_MultiCoated { get; set; }
        public List<string> detail_Photosensitive { get; set; }
        public List<string> detail_RegularLensesType { get; set; }
        public List<string> detail_SafetyThickness { get; set; }
        public List<string> detail_ServType { get; set; }
        public List<string> detail_SingleVision { get; set; }
        public List<string> detail_Varilux { get; set; }
        public double leftEyeDistanceAxis { get; set; }
        public double leftEyeDistanceCylinder { get; set; }
        public double leftEyeDistancePrism { get; set; }
        public double leftEyeDistanceSphere { get; set; }
        public double leftEyeDistanceVA { get; set; }
        public double leftEyeNearAxis { get; set; }
        public double leftEyeNearCylinder { get; set; }
        public double leftEyeNearPrism { get; set; }
        public double leftEyeNearSphere { get; set; }
        public double leftEyeNearVA { get; set; }
        public string policyNo { get; set; }
        public double rightEyeDistanceAxis { get; set; }
        public double rightEyeDistanceCylinder { get; set; }
        public double rightEyeDistancePrism { get; set; }
        public double rightEyeDistanceSphere { get; set; }
        public double rightEyeDistanceVA { get; set; }
        public double rightEyeNearAxis { get; set; }
        public double rightEyeNearCylinder { get; set; }
        public double rightEyeNearPrism { get; set; }
        public double rightEyeNearSphere { get; set; }
        public double rightEyeNearVA { get; set; }

    }
    public class Detail
    {
        public string SQLTypeName { get; set; }
        public string sql_type { get; set; }
        public long TXN_ID { get; set; }
        public string DOC_IMG_FILENAME { get; set; }
        public string DOC_IMG_LOCN { get; set; }
        public string DOC_PATH { get; set; }
    }

    //Response Params

    public class BUPAResponseCommonParam
    {
        public long transactionID { get; set; }
        public long preAuthorizationID { get; set; }
        public string providerName { get; set; }
        public string insuranceCompany { get; set; }
        public string patientFileNo { get; set; }
        public string department { get; set; }
        public string providerFaxNo { get; set; }
        public DateTime? dateOfAdmission { get; set; }
        public string memberName { get; set; }
        public string idCardNo { get; set; }
        public long age { get; set; }
        public string gender { get; set; }
        public string policyHolder { get; set; }
        public string membershipNo { get; set; }
        public string memberClass { get; set; }
        public DateTime? expiryDate { get; set; }
        public string preauthorisationStatus { get; set; }
        public DateTime? appValidity { get; set; }
        public string roomType { get; set; }
        public string comments { get; set; }
        public string insuranceOfficer { get; set; }
        public string addComments { get; set; }
        public DateTime? dateTime { get; set; }
        public string chronicInd { get; set; }
        public string extDate { get; set; }
        public string extInd { get; set; }
        public List<string> serviceCode { get; set; }
        public List<string> serviceDesc { get; set; }
        public List<string> notes { get; set; }
        public string status { get; set; }
        public List<string> errorID { get; set; }
        public List<string> errorMessage { get; set; }
    }

    public class BUPAPharmacyApprovalResponse : BUPAResponseCommonParam
    {
        public List<string> supplyPeriod { get; set; }
        public List<DateTime?> supplyFrom { get; set; }
        public List<DateTime?> supplyTo { get; set; }
        
    }


    public class BUPADentalApprovalResponse : BUPAResponseCommonParam
    {
        
    }

    public class BUPADiagnosisApprovalResponse : BUPAResponseCommonParam
    {
        
    }

    public class BUPAOpticalApprovalResponseParam : BUPAResponseCommonParam
    {

    }
    public class BUPAPreAuthByIdRequest : BranchCredentialsParam
    {
        public int? PreAuthorizationId { get; set; }
    }

    public class BUPAPreAuthByIdResponse : BUPAResponseCommonParam
    {
        public List<string> supplyPeriod { get; set; }
        public List<string> supplyFrom { get; set; }
        public List<string> supplyTo { get; set; }
        public List<string> adjQty { get; set; }
        public List<string> pbmReferInd { get; set; }
        public List<string> pbmStatus { get; set; }
        public List<string> pbmOverrideInd { get; set; }
        public List<string> pbmOverrideReason { get; set; }
        public List<string> pbmAdjInd { get; set; }
        public List<string> pbmDuration { get; set; }
        public List<string> pbmUnit { get; set; }
        public List<string> pbmUnitType { get; set; }
        public List<string> pbmTimes { get; set; }
        public List<string> pbmPer { get; set; }
        public List<string> pbmRequestID { get; set; }
        public List<object> pbmDosage { get; set; }
        public List<string> pbmRemark { get; set; }
        public string webExemptedInd { get; set; }
        public string webReferralInd { get; set; }
        public string webCheckupInd { get; set; }
        public string webCongenInd { get; set; }
        public string webPsycInd { get; set; }
        public string webRtaInd { get; set; }
        public string webInfertInd { get; set; }
        public string webWrkRelatedInd { get; set; }
        public string webVaccInd { get; set; }
        public string webBloodPressure { get; set; }
        public string webPulse { get; set; }
        public string webTemperature { get; set; }
        public string webIllness { get; set; }
        public string webLineOfTreatment { get; set; }
        public string webOtherCondition { get; set; }
        public string webGravida { get; set; }
        public string webPara { get; set; }
        public string webLive { get; set; }
        public string webAbortion { get; set; }
        public string webDeath { get; set; }
        public List<string> webServCode { get; set; }
        public List<string> webSuppPeriod { get; set; }
        public List<string> webSuppFrom { get; set; }
        public List<string> webSuppTo { get; set; }
        public List<string> webServDesc { get; set; }
        public List<string> webItemQty { get; set; }
        public List<string> webLineAmt { get; set; }
        public string webMobileNo { get; set; }
        public string webContractNo { get; set; }
        public string webVerificationId { get; set; }
        public string webProviderCode { get; set; }
        public string webMainSymptoms { get; set; }
        public string webDiagnosisCode { get; set; }
        public string webDiagnosisDesc { get; set; }
        public string webTreatmentType { get; set; }
        public string webLengthOfStay { get; set; }
        public string webDeptType { get; set; }
        public string provDeptName { get; set; }
        public string webIVFPregnancy { get; set; }
        public string webNormalPregnancy { get; set; }
        public string webCardIssueNo { get; set; }
        public string webIDCardNo { get; set; }
        public string lastMenstrualPeriodHijri { get; set; }
        public string expectedDeliveryHijri { get; set; }
        public string lastMenstrualPeriodGregorian { get; set; }
        public string expectedDeliveryGregorian { get; set; }
        public string eSigPath { get; set; }
        public string eSigText { get; set; }
        public string pbmInd { get; set; }
        public string cchiLetterInd { get; set; }
        public new string errorID { get; set; }
        public new string errorMessage { get; set; }

    }

    public class BUPACancelStatusResponse
    {
        public long TransactionId { get; set; }
        public List<long> PreauthorisationId { get; set; }
        public List<long> EpisodeNo { get; set; }
        public List<string> EpisodeStatus { get; set; }
        public List<string> ServiceDescription { get; set; }
        public List<string> LineItemStatus { get; set; }
        public List<string> ApprovalDate { get; set; }
        public List<string> MemberName { get; set; }
        public List<string> PatientFileNumber { get; set; }
        public string Status { get; set; }
        public string ErrorId { get; set; }
        public string ErrorMessage { get; set; }
    }


    public class BUPACancelInfoRequest
    {
        public long PreAuthorisationId { get; set; }
        public long EpisodeNo { get; set; }
        public string ProcessUser { get; set; }
        public string providerCode { get; set; }
        public string Detail { get; set; }
    }

    public class BUPACancelInfoResponse
    {
        public long TransactionId { get; set; }
        public string Status { get; set; }
        public string ErrorId { get; set; }
        public string ErrorMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QDomain.Model.Eligibility
{
    public class NAPHIES_Eligibility_Param
    {
        public string EligibilityID { get; set; }
        public string Purpose { get; set; } // Discovery, Validation, Benefit
        public DateTime ServicedDate { get; set; }
        public DateTime ServicePeriodStartDate { get; set; }
        public DateTime ServicePeriodEndDate { get; set; }
        public string CoverageCode { get; set; }
        public string CoverageDisplay { get; set; }
        public string MembershipID { get; set; }
        public string Relationship { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string MaritalStatus { get; set; }
        public string CellNumber { get; set; }
        public string IdentifierType { get; set; }
        public string Identifier { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string PayerID { get; set; }
        public string PayerName { get; set; }
    }
}

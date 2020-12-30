namespace QInfrastructure.Api.Service.V3.Eligibility.Query
{
    using Hl7.Fhir.Model;
    using Hl7.Fhir.Serialization;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using QData.Repository.V3.Interface;
    using QDomain.Model.Eligibility;
    using QHl7;
    using QInfrastructure.Api.Service.V3.Eligibility.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="EligibilityValidateQueryHandler" />.
    /// </summary>
    public class EligibilityValidateQueryHandler : IRequestHandler<EligibilityValidateQuery, EligibilityValidateVM>
    {
        /// <summary>
        /// Defines the adminBus.
        /// </summary>
        private readonly IConfigRepository adminBus;

        /// <summary>
        /// Defines the sghhl7.
        /// </summary>
        private readonly ISghQHl7 sghhl7;

        /// <summary>
        /// Initializes a new instance of the <see cref="EligibilityValidateQueryHandler"/> class.
        /// </summary>
        /// <param name="_adminBus">The _adminBus<see cref="IConfigRepository"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <param name="_sghhl7">The _sghhl7<see cref="ISghQHl7"/>.</param>
        public EligibilityValidateQueryHandler(IConfigRepository _adminBus, ISghQHl7 _sghhl7)
        {
            adminBus = _adminBus;
            sghhl7 = _sghhl7;
           
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="EligibilityValidateQuery"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{NAPHIES_Eligibility_Param}"/>.</returns>
        public async Task<EligibilityValidateVM> Handle(EligibilityValidateQuery request, CancellationToken cancellationToken)
        {
            string ServiceRootUrl = "http://sgw.s.nphies.sa/tmb/$process-message";
            //string ServiceRootUrl = "http://176.105.150.83/tmb/$process-message";

            string messageHeaderId = Guid.NewGuid().ToString();

            string bundleId = Guid.NewGuid().ToString();

            List<Bundle.EntryComponent> _entry = new List<Bundle.EntryComponent>();

            #region Bundle Definition

            //Bundle Initilization
            Bundle _bundle = new Bundle();
            _bundle.Type = Bundle.BundleType.Message;

            _bundle.Timestamp = DateTime.Now;
            _bundle.Id = bundleId;

            //Bundle Meta
            _bundle.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/bundle|1.0.0");

            #endregion

            #region MessageHeader

            //MessageHeader resource
            MessageHeader _header = new MessageHeader();
            _header.Id = messageHeaderId;

            //MessageHeader Meta
            _header.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/message-header|1.0.0");

            //MessageHeader EventCoding
            var messageEventCoding = new Coding();
            messageEventCoding.System = "http://nphies.sa/terminology/CodeSystem/ksa-message-events";
            messageEventCoding.Code = "eligibility-request";
            _header.Event = messageEventCoding;

            //MessageHeader Destination
            MessageHeader.MessageDestinationComponent messageHeaderDestination = new MessageHeader.MessageDestinationComponent();

            //http://nphies.sa/license/payer-license/TMB-INS
            messageHeaderDestination.Endpoint = "http://nphies.sa/license/payer-license/" + request.param.PayerID;

            //"TMB-INS"
            ResourceReference messageDestinationReceiver = new ResourceReference();
            messageDestinationReceiver.Identifier = sghhl7.getIdentifier("http://nphies.sa/license/payer-license", request.param.PayerID); 
            messageDestinationReceiver.Type = ResourceType.Organization.ToString();
            messageHeaderDestination.Receiver = messageDestinationReceiver;
            _header.Destination = new List<MessageHeader.MessageDestinationComponent> { messageHeaderDestination };

            //MessageHeader Sender
            //"PR-FHIR"
            ResourceReference messageSenderResource = new ResourceReference();
            messageSenderResource.Type = ResourceType.Organization.ToString();
            messageSenderResource.Identifier = sghhl7.getIdentifier("http://nphies.sa/license/provider-license", request.param.ProviderID);
            _header.Sender = messageSenderResource;

            //MessageHeader Source
            //http://nphies.sa/license/provider-license/PR-FHIR
            MessageHeader.MessageSourceComponent messageSourceComponent = new MessageHeader.MessageSourceComponent();
            messageSourceComponent.Endpoint = "http://nphies.sa/license/provider-license/" + request.param.ProviderID;
            _header.Source = messageSourceComponent;

            //MessageHeader Focus
            _header.Focus = new List<ResourceReference> { sghhl7.getResource("http://pr-fhir.com.sa/CoverageEligibilityRequest/1001") };

            //Adding MessageHeader Entry
            _bundle.AddResourceEntry(_header, "urn:uuid:" + messageHeaderId);

            #endregion

            #region CoverageEligibilityRequest

            //CoverageEligibilityRequest entry
            CoverageEligibilityRequest coverageEligibilityRequest = new CoverageEligibilityRequest();
            coverageEligibilityRequest.Id = "1001";

            //coverageEligibilityRequest.Meta = new Meta() { Profile = new List<string>() { } };
            //new Date("2020-12-25");
            coverageEligibilityRequest.Status = FinancialResourceStatusCodes.Active;
            coverageEligibilityRequest.Serviced = new Date(request.param.ServicedDate.ToString("yyyy-MM-dd")); 
            coverageEligibilityRequest.Created = DateTime.UtcNow.ToString("yyyy-MM-dd");

            //CoverageEligibilityRequest identifier
            coverageEligibilityRequest.Identifier = new List<Identifier>() { sghhl7.getIdentifier("http://pr-fhir.com.sa/CoverageEligibilityRequest", sghhl7.RandomNumber(13)) };

            if (request.param.Purpose.ToLower() != "discovery")
            {
                //CoverageEligibilityRequest Insurance
                CoverageEligibilityRequest.InsuranceComponent insuranceComponent = new CoverageEligibilityRequest.InsuranceComponent();
                insuranceComponent.Coverage = sghhl7.getResource("http://provider.com/Coverage/21");
                coverageEligibilityRequest.Insurance = new List<CoverageEligibilityRequest.InsuranceComponent>() { insuranceComponent };
            }

            //CoverageEligibilityRequest Priority
            coverageEligibilityRequest.Priority = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/processpriority", "normal");

            //CoverageEligibilityRequest Purpose
            if (request.param.Purpose == "Discovery")
            {
                coverageEligibilityRequest.Purpose = new List<CoverageEligibilityRequest.EligibilityRequestPurpose?>() { CoverageEligibilityRequest.EligibilityRequestPurpose.Discovery };
            }
            else if (request.param.Purpose == "Validation")
            {
                coverageEligibilityRequest.Purpose = new List<CoverageEligibilityRequest.EligibilityRequestPurpose?>() { CoverageEligibilityRequest.EligibilityRequestPurpose.Validation };
            }
            else
            {
                coverageEligibilityRequest.Purpose = new List<CoverageEligibilityRequest.EligibilityRequestPurpose?>() { CoverageEligibilityRequest.EligibilityRequestPurpose.Benefits };
            }

            //CoverageEligibilityRequest Patient Reference
            coverageEligibilityRequest.Patient = sghhl7.getResource("Patient/5588");

            //CoverageEligibilityRequest Provider Reference
            coverageEligibilityRequest.Provider = sghhl7.getResource("Organization/10");

            //CoverageEligibilityRequest Insurer Reference
            coverageEligibilityRequest.Insurer = sghhl7.getResource("Organization/11");

            _bundle.AddResourceEntry(coverageEligibilityRequest, "http://pr-fhir.com.sa/CoverageEligibilityRequest/1001");

            #endregion

            #region Coverage

            if (request.param.Purpose.ToLower() != "discovery")
            {
                //Coverage entry
                Coverage coverage = new Coverage();
                coverage.SubscriberId = request.param.Identifier;//"0000000099"
                coverage.Id = "21";
                coverage.Status = FinancialResourceStatusCodes.Active;

                //Coverage Identifier
                //"0000000099"
                coverage.Identifier = new List<Identifier>() { sghhl7.getIdentifier("http://payer.com/memberid", request.param.Identifier) };

                //Coverage Period
                //getPeriod("2020-09-28", "2020-09-30");
                coverage.Period = sghhl7.getPeriod(request.param.ServicePeriodStartDate.ToString("yyyy-MM-dd"), request.param.ServicePeriodEndDate.ToString("yyyy-MM-dd"));

                //Coverage Subscriber
                coverage.Subscriber = sghhl7.getResource("http://provider.com/Patient/5588");

                //Coverage Type
                //"EHCPOL", "extended healthcare"
                coverage.Type = sghhl7.getCodeableConceptWithDisplay("http://nphies.sa/terminology/CodeSystem/coverage-type", request.param.CoverageCode, request.param.CoverageDisplay);
                
                //Coverage Payer
                coverage.Payor = new List<ResourceReference>() { sghhl7.getResource("http://provider.com/Organization/11") };

                //Coverage Beneficiary
                coverage.Beneficiary = sghhl7.getResource("http://provider.com/Patient/5588");

                //Coverage Meta
                coverage.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/coverage");

                //Covrage Relationship
                coverage.Relationship = sghhl7.getCodeableConceptWithDisplay("http://terminology.hl7.org/CodeSystem/subscriber-relationship", "self", "self");

                //Coverage Policyholder
                coverage.PolicyHolder = sghhl7.getResource("http://provider.com/Organization/10");

                _bundle.AddResourceEntry(coverage, "http://provider.com/Coverage/21");
                
            }

            #endregion

            #region Patient

            //Patient Entry
            Patient patient = new Patient();
            patient.Id = "5588";
            patient.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/patient|1.0.0");

            if (request.param.Gender.ToLower() == "male")
            {
                patient.Gender = AdministrativeGender.Male;
            }
            else if (request.param.Gender.ToLower() == "female")
            {
                patient.Gender = AdministrativeGender.Female;
            }
            else
            {
                patient.Gender = AdministrativeGender.Unknown;
            }

            patient.Active = true;

            //"1949-08-04";
            patient.BirthDate = request.param.DateOfBirth.ToString("yyyy-MM-dd");

            //Patient Identifier
            //getPatientIdentifier("http://moi.gov.sa/id/iqama", "00000000003", "http://nphies.sa/terminology/CodeSystem/patient-identifier-type", "DP")
            patient.Identifier = new List<Identifier>() { sghhl7.getPatientIdentifier("http://moi.gov.sa/id/iqama", request.param.Identifier, "http://nphies.sa/terminology/CodeSystem/patient-identifier-type", request.param.IdentifierType) }; 
                                                                                                                                                                                                                           
            //Patient ManageOrganization
            patient.ManagingOrganization = sghhl7.getResource("http://provider.com/Organization/10");

            //Patient _gender
            CodeableConcept genderExtension = new CodeableConcept();
            Coding genderExtensionCoding = new Coding();
            genderExtensionCoding.System = "http://nphies.sa/terminology/CodeSystem/ksa-administrative-gender";
            genderExtensionCoding.Code = request.param.Gender.ToLower();//"male";
            genderExtension.Coding = new List<Coding>() { genderExtensionCoding };

            Extension extension = new Extension();
            extension.Value = genderExtension;
            extension.Url = "http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/extension-ksa-administrative-gender";

            patient.GenderElement.Extension.Add(extension);

            //Patient Name
            //{ getName(new List<string>() { "Sara", "Bashir", "Ahmad" }, HumanName.NameUse.Official, "Sara Bashir Ahmad Anabtawi") };
            patient.Name = new List<HumanName>() { sghhl7.getName(new List<string>() { request.param.FirstName, request.param.MiddleName, request.param.LastName }, HumanName.NameUse.Official, request.param.FullName) };

            //Patient Telecom
            //0099656856"
            patient.Telecom = new List<ContactPoint>() { sghhl7.getContactPoint(ContactPoint.ContactPointSystem.Phone, request.param.CellNumber) };

            //Patient Marital Status
            //"Married"
            patient.MaritalStatus = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/v3-MaritalStatus", request.param.MaritalStatus);

            _bundle.AddResourceEntry(patient, "http://provider.com/Patient/5588");

            #endregion

            #region Organization/Provider 

            //Provider Info
            Organization porviderOrganization = new Organization();

            // "PR-FHIR"
            porviderOrganization.Identifier = new List<Identifier>() { sghhl7.getIdentifierWithUse("http://nphies.sa/license/provider-license", request.param.ProviderID, Identifier.IdentifierUse.Official) };
            porviderOrganization.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/provider-organization");
            porviderOrganization.Name = request.param.ProviderName;//"Ibby Davydoch"
            porviderOrganization.Active = true;
            porviderOrganization.Id = "10";

            //"PR-34-309"
            porviderOrganization.Type = new List<CodeableConcept>() { sghhl7.getCodeableConceptWithText("http://nphies.sa/terminology/CodeSystem/organization-type", "prov", request.param.ProviderName) };

            _bundle.AddResourceEntry(porviderOrganization, "http://provider.com/Organization/10");

            #endregion

            #region Organization/Payer 

            //Provider Info
            Organization payerOrganization = new Organization();

            //"TMB-INS"
            payerOrganization.Identifier = new List<Identifier>() { sghhl7.getIdentifierWithUse("http://nphies.sa/license/payer-license", request.param.PayerID, Identifier.IdentifierUse.Official) };
            payerOrganization.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/insurer-organization");

            //"Insurance Company 18"
            payerOrganization.Name = request.param.PayerName;
            payerOrganization.Active = true;
            payerOrganization.Id = "11";

            //"TMB-INS"
            payerOrganization.Type = new List<CodeableConcept>() { sghhl7.getCodeableConceptWithText("http://nphies.sa/terminology/CodeSystem/organization-type", "ins", request.param.PayerID) };

            _bundle.AddResourceEntry(payerOrganization, "http://provider.com/Organization/11");

            #endregion

            var newBundle = new EligibilityValidateVM();

            newBundle.bundleJson = _bundle.ToJson();

            return newBundle;
        }
    }
}

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using MediatR;
using QData.Repository.V3.Interface;
using QHl7;
using QInfrastructure.Api.Service.V3.Eligibility.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QInfrastructure.Api.Service.V3.PreAuthorization.Query
{
    public class PreAuthorizationQueryHandler : IRequestHandler<PreAuthorizationQuery, EligibilityValidateVM>
    {
        /// <summary>
        /// Defines the adminBus.
        /// </summary>
        private readonly IConfigRepository adminBus;

        /// <summary>
        /// Defines the sghhl7.
        /// </summary>
        private readonly ISghQHl7PA sghhl7;

        /// <summary>
        /// Initializes a new instance of the <see cref="EligibilityValidateQueryHandler"/> class.
        /// </summary>
        /// <param name="_adminBus">The _adminBus<see cref="IConfigRepository"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <param name="_sghhl7">The _sghhl7<see cref="ISghQHl7"/>.</param>
        public PreAuthorizationQueryHandler(IConfigRepository _adminBus, ISghQHl7PA _sghhl7)
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
        public async Task<EligibilityValidateVM> Handle(PreAuthorizationQuery request, CancellationToken cancellationToken)
        {
            //string ServiceRootUrl = "http://sgw.s.nphies.sa/tmb/$process-message";
            string ServiceRootUrl = "http://176.105.150.83/tmb/$process-message";

            string messageHeaderId = Guid.NewGuid().ToString();

            string bundleId = Guid.NewGuid().ToString();

            List<Bundle.EntryComponent> _entry = new List<Bundle.EntryComponent>();


            #region "Bundle Definition"

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
            messageEventCoding.Code = "priorauth-request";
            _header.Event = messageEventCoding;

            //MessageHeader Destination
            MessageHeader.MessageDestinationComponent messageHeaderDestination = new MessageHeader.MessageDestinationComponent();
            messageHeaderDestination.Endpoint = "http://nphies.sa/license/payer-license/TMB-INS"; // param.PayerID;
            ResourceReference messageDestinationReceiver = new ResourceReference();
            messageDestinationReceiver.Identifier = sghhl7.getIdentifier("http://nphies.sa/license/payer-license", "TMB-INS"); //param.PayerID
            messageDestinationReceiver.Type = ResourceType.Organization.ToString();
            messageHeaderDestination.Receiver = messageDestinationReceiver;
            _header.Destination = new List<MessageHeader.MessageDestinationComponent> { messageHeaderDestination };

            //MessageHeader Sender
            ResourceReference messageSenderResource = new ResourceReference();
            messageSenderResource.Type = ResourceType.Organization.ToString();
            messageSenderResource.Identifier = sghhl7.getIdentifier("http://nphies.sa/license/provider-license", "PR-FHIR");//param.ProviderID
            _header.Sender = messageSenderResource;

            //MessageHeader Source
            MessageHeader.MessageSourceComponent messageSourceComponent = new MessageHeader.MessageSourceComponent();
            messageSourceComponent.Endpoint = "http://nphies.sa/license/provider-license/PR-FHIR"; //+ param.ProviderID
            _header.Source = messageSourceComponent;

            //MessageHeader Focus
            _header.Focus = new List<ResourceReference> { sghhl7.getResource("http://pr-fhir.com.sa/Claim/1001") };

            //Adding MessageHeader Entry
            _bundle.AddResourceEntry(_header, "urn:uuid:" + messageHeaderId);

            #endregion

            #region Claim
            //Bundle Claim Entry
            Claim claim = new Claim();
            claim.Id = "1001";
            claim.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/pharmacy-priorauth|1.0.0");
            claim.Identifier = new List<Identifier>() { sghhl7.getIdentifier("http://pr-fhir.com.sa/Authorization", sghhl7.RandomNumber(13)) };
            claim.Status = FinancialResourceStatusCodes.Active;
            claim.Type = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/claim-type", "pharmacy");
            claim.SubType = sghhl7.getCodeableConceptWithText("http://nphies.sa/terminology/CodeSystem/claim-subtype", "op", "emr");
            claim.Use = Use.Preauthorization;
            claim.Patient = sghhl7.getResource("Patient/5588");
            claim.Created = DateTime.Now.ToString("yyyy-MM-dd");
            claim.Insurer = sghhl7.getResource("Organization/11");
            claim.Provider = sghhl7.getResource("Organization/10");
            claim.Priority = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/processpriority", "normal");

            Claim.PayeeComponent payeeComponent = new Claim.PayeeComponent();
            payeeComponent.Type = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/payeetype", "provider");
            claim.Payee = payeeComponent;

            Claim.CareTeamComponent careTeamComponent = new Claim.CareTeamComponent();
            careTeamComponent.Sequence = 1;
            careTeamComponent.Provider = sghhl7.getResource("PractitionerRole/7");
            careTeamComponent.Role = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/claimcareteamrole", "primary");
            claim.CareTeam = new List<Claim.CareTeamComponent>() { careTeamComponent };

            Claim.DiagnosisComponent diagnosisComponent = new Claim.DiagnosisComponent();
            diagnosisComponent.Sequence = 1;
            diagnosisComponent.Diagnosis = sghhl7.getCodeableConcept("http://hl7.org/fhir/sid/icd-10-am", "A01.1");
            diagnosisComponent.Type = new List<CodeableConcept>() { sghhl7.getCodeableConcept("http://nphies.sa/terminology/CodeSystem/diagnosis-type", "principal") };
            claim.Diagnosis = new List<Claim.DiagnosisComponent>() { diagnosisComponent };

            Claim.InsuranceComponent insuranceComponent = new Claim.InsuranceComponent();
            insuranceComponent.Sequence = 1;
            insuranceComponent.Focal = true;
            insuranceComponent.Coverage = sghhl7.getResource("Coverage/3");
            claim.Insurance = new List<Claim.InsuranceComponent>() { insuranceComponent };

            Claim.ItemComponent itemComponent = new Claim.ItemComponent();
            itemComponent.Sequence = 1;
            itemComponent.CareTeamSequence = new List<int?>() { 1 };

            CodeableConcept cat = new CodeableConcept();
            cat.Text = "5";
            itemComponent.Category = cat;
            itemComponent.Serviced = new Date("2029-10-05");
            itemComponent.Quantity = sghhl7.getQuantity(1);
            itemComponent.UnitPrice = sghhl7.getMoney(200, Money.Currencies.SAR);
            itemComponent.Net = sghhl7.getMoney(200, Money.Currencies.SAR);
            itemComponent.ProductOrService = sghhl7.getCodeableConceptWithText("http://nphies.sa/terminology/CodeSystem/medication-codes", "06285096000798", "PANADOL 500 MG FILM-COATED TABLET");

            List<Extension> extensions = new List<Extension>();
            extensions.Add(new Extension("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/extension-tax", sghhl7.getMoney(10, Money.Currencies.SAR)));
            extensions.Add(new Extension("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/extension-patient-share", sghhl7.getMoney(0, Money.Currencies.SAR)));
            extensions.Add(new Extension("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/extension-package", new Hl7.Fhir.Model.FhirBoolean(false)));

            itemComponent.Extension = extensions;
            claim.Item = new List<Claim.ItemComponent>() { itemComponent };
            claim.Total = sghhl7.getMoney(200, Money.Currencies.SAR);

            _bundle.AddResourceEntry(claim, "http://pr-fhir.com.sa/Claim/1001");

            #endregion

            #region Coverage
            //Coverage entry
            Coverage coverage = new Coverage();
            coverage.SubscriberId = "0000000099";//"0000000099"
            coverage.Id = "3";
            coverage.Status = FinancialResourceStatusCodes.Active;

            //Coverage Identifier
            coverage.Identifier = new List<Identifier>() { sghhl7.getIdentifier("http://payer.com/memberid", "0000000099") };//"0000000099"

            //Coverage Period
            coverage.Period = sghhl7.getPeriod("2020-09-28", "2020-09-30");//getPeriod("2020-09-28", "2020-09-30");

            //Coverage Subscriber
            coverage.Subscriber = sghhl7.getResource("http://provider.com/Patient/5588");

            //Coverage Type
            coverage.Type = sghhl7.getCodeableConceptWithDisplay("http://nphies.sa/terminology/CodeSystem/coverage-type", "EHCPOL", "extended healthcare");//"EHCPOL", "extended healthcare"


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

            _bundle.AddResourceEntry(coverage, "http://provider.com/Coverage/3");
            #endregion

            #region Practitioner
            //Bundle Practitioner Entry
            Practitioner practitioner = new Practitioner();
            practitioner.Id = "7";
            practitioner.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/practitioner|1.0.0");
            practitioner.Identifier = new List<Identifier>() { sghhl7.getPractitionerIdentifier("http://nphies.sa/license/practitioner-license", "0007", "http://terminology.hl7.org/CodeSystem/v2-0203", "PRC") };
            practitioner.Active = true;
            _bundle.AddResourceEntry(practitioner, "http://pr-fhir.com.sa/Practitioner/7");
            #endregion

            #region PractitionerRole
            //Bundle PractitionerRole Entry
            PractitionerRole practitionerRole = new PractitionerRole();
            practitionerRole.Id = "7";
            practitionerRole.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/practitioner-role|1.0.0");
            practitionerRole.Active = true;
            practitionerRole.Practitioner = sghhl7.getResource("Practitioner/7");
            practitionerRole.Organization = sghhl7.getResource("Organization/10");
            practitionerRole.Code = new List<CodeableConcept>() { sghhl7.getCodeableConcept("http://nphies.sa/terminology/CodeSystem/practitioner-role", "doctor") };
            practitionerRole.Specialty = new List<CodeableConcept>() { sghhl7.getCodeableConcept("http://nphies.sa/terminology/CodeSystem/practice-codes", "19.00") };
            practitionerRole.Identifier = new List<Identifier>() { sghhl7.getIdentifier("http://nphies.sa/terminology/CodeSystem/practitioner-role", "ict") };
            _bundle.AddResourceEntry(practitionerRole, "http://pr-fhir.com.sa/PractitionerRole/7");
            #endregion

            #region Patient
            //Patient Entry
            Patient patient = new Patient();
            patient.Id = "5588";
            patient.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/patient|1.0.0");

            //if (param.Gender.ToLower() == "male")
            //{
            //    patient.Gender = AdministrativeGender.Male;
            //}
            //else if (param.Gender.ToLower() == "female")
            //{
            //    patient.Gender = AdministrativeGender.Female;
            //}
            //else
            //{
            //    patient.Gender = AdministrativeGender.Unknown;
            //}
            patient.Gender = AdministrativeGender.Male;

            patient.Active = true;
            patient.BirthDate = "1949-08-04";//param.DateOfBirth.ToString("yyyy-MM-dd");;

            //Patient Identifier
            patient.Identifier = new List<Identifier>() { sghhl7.getPatientIdentifier("http://moi.gov.sa/id/iqama", "00000000003", "http://nphies.sa/terminology/CodeSystem/patient-identifier-type", "DP") };
            //Patient ManageOrganization
            patient.ManagingOrganization = sghhl7.getResource("http://provider.com/Organization/10");

            //Patient _gender
            CodeableConcept genderExtension = new CodeableConcept();
            Coding genderExtensionCoding = new Coding();
            genderExtensionCoding.System = "http://nphies.sa/terminology/CodeSystem/ksa-administrative-gender";
            genderExtensionCoding.Code = "male";//param.Gender.ToLower();
            genderExtension.Coding = new List<Coding>() { genderExtensionCoding };

            Extension extension = new Extension();
            extension.Value = genderExtension;
            extension.Url = "http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/extension-ksa-administrative-gender";

            patient.GenderElement.Extension.Add(extension);

            //Patient Name
            patient.Name = new List<HumanName>() { sghhl7.getName(new List<string>() { "Sara", "Bashir", "Ahmad" }, HumanName.NameUse.Official, "Sara Bashir Ahmad Anabtawi") };//getName(new List<string>() { param.FirstName, param.MiddleName, param.LastName }, HumanName.NameUse.Official, param.FullName)

            //Patient Telecom
            patient.Telecom = new List<ContactPoint>() { sghhl7.getContactPoint(ContactPoint.ContactPointSystem.Phone, "0099656856") };//0099656856"

            //Patient Marital Status
            patient.MaritalStatus = sghhl7.getCodeableConcept("http://terminology.hl7.org/CodeSystem/v3-MaritalStatus", "Married");//param.MaritalStatus

            _bundle.AddResourceEntry(patient, "http://provider.com/Patient/5588");

            #endregion

            #region Organization/Provider 
            //Provider Info
            Organization porviderOrganization = new Organization();
            porviderOrganization.Identifier = new List<Identifier>() { sghhl7.getIdentifierWithUse("http://nphies.sa/license/provider-license", "PR-FHIR", Identifier.IdentifierUse.Official) };
            porviderOrganization.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/provider-organization");
            porviderOrganization.Name = "Ibby Davydoch"; //param.ProviderName;
            porviderOrganization.Active = true;
            porviderOrganization.Id = "10";
            porviderOrganization.Type = new List<CodeableConcept>() { sghhl7.getCodeableConceptWithText("http://nphies.sa/terminology/CodeSystem/organization-type", "prov", "ABC") };//param.ProviderName

            _bundle.AddResourceEntry(porviderOrganization, "http://provider.com/Organization/10");

            #endregion

            #region Organization/Payer 
            //Provider Info
            Organization payerOrganization = new Organization();
            payerOrganization.Identifier = new List<Identifier>() { sghhl7.getIdentifierWithUse("http://nphies.sa/license/payer-license", "TMB-INS", Identifier.IdentifierUse.Official) };//"TMB-INS"
            payerOrganization.Meta = sghhl7.getMeta("http://nphies.sa/fhir/ksa/nphies-fs/StructureDefinition/insurer-organization");
            payerOrganization.Name = "Insurance Company 18";
            payerOrganization.Active = true;
            payerOrganization.Id = "11";
            payerOrganization.Type = new List<CodeableConcept>() { sghhl7.getCodeableConceptWithText("http://nphies.sa/terminology/CodeSystem/organization-type", "ins", "TMB-INS") };//"TMB-INS"

            _bundle.AddResourceEntry(payerOrganization, "http://provider.com/Organization/11");
            
            #endregion

            var newBundle = new EligibilityValidateVM();

            newBundle.bundleJson = _bundle.ToJson();

            return newBundle;
        }
    }
    
}

namespace QHl7
{
    using Hl7.Fhir.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="SghQHl7" />.
    /// </summary>
    public class SghQHl7 : ISghQHl7
    {
        /// <summary>
        /// The getResource.
        /// </summary>
        /// <param name="Reference">The Reference<see cref="string"/>.</param>
        /// <returns>The <see cref="ResourceReference"/>.</returns>
        public ResourceReference getResource(string Reference)
        {
            ResourceReference resourceReference = new ResourceReference();
            resourceReference.Reference = Reference;

            return resourceReference;
        }

        /// <summary>
        /// The getMeta.
        /// </summary>
        /// <param name="profileURL">The profileURL<see cref="string"/>.</param>
        /// <returns>The <see cref="Meta"/>.</returns>
        public Meta getMeta(string profileURL)
        {
            Meta meta = new Meta();
            List<string> profiles = new List<string>();

            profiles.Add(profileURL);

            meta.Profile = profiles;

            return meta;
        }

        /// <summary>
        /// The getCodeableConceptWithDisplay.
        /// </summary>
        /// <param name="systemmUrl">The systemmUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <param name="display">The display<see cref="string"/>.</param>
        /// <returns>The <see cref="CodeableConcept"/>.</returns>
        public CodeableConcept getCodeableConceptWithDisplay(string systemmUrl, string code, string display)
        {
            CodeableConcept codeableConcept = new CodeableConcept();
            Coding coding = new Coding();
            coding.System = systemmUrl;
            coding.Code = code;
            coding.Display = display;
            codeableConcept.Coding = new List<Coding>() { coding };

            return codeableConcept;
        }

        /// <summary>
        /// The getCodeableConcept.
        /// </summary>
        /// <param name="systemmUrl">The systemmUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <returns>The <see cref="CodeableConcept"/>.</returns>
        public CodeableConcept getCodeableConcept(string systemmUrl, string code)
        {
            CodeableConcept codeableConcept = new CodeableConcept();
            Coding coding = new Coding();
            coding.System = systemmUrl;
            coding.Code = code;
            codeableConcept.Coding = new List<Coding>() { coding };

            return codeableConcept;
        }

        /// <summary>
        /// The getCodeableConceptWithText.
        /// </summary>
        /// <param name="systemmUrl">The systemmUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <returns>The <see cref="CodeableConcept"/>.</returns>
        public CodeableConcept getCodeableConceptWithText(string systemmUrl, string code, string text)
        {
            CodeableConcept codeableConcept = new CodeableConcept();
            Coding coding = new Coding();
            coding.System = systemmUrl;
            coding.Code = code;
            codeableConcept.Coding = new List<Coding>() { coding };
            codeableConcept.Text = text;

            return codeableConcept;
        }

        /// <summary>
        /// The getIdentifier.
        /// </summary>
        /// <param name="systemUrl">The systemUrl<see cref="string"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        /// <returns>The <see cref="Identifier"/>.</returns>
        public Identifier getIdentifier(string systemUrl, string value)
        {
            Identifier identifier = new Identifier();
            identifier.System = systemUrl;
            identifier.Value = value;

            return identifier;
        }

        /// <summary>
        /// The getPeriod.
        /// </summary>
        /// <param name="start">The start<see cref="string"/>.</param>
        /// <param name="end">The end<see cref="string"/>.</param>
        /// <returns>The <see cref="Period"/>.</returns>
        public Period getPeriod(string start, string end)
        {
            Period period = new Period();
            period.Start = start;
            period.End = end;


            return period;
        }

        /// <summary>
        /// The getContactPoint.
        /// </summary>
        /// <param name="system">The system<see cref="ContactPoint.ContactPointSystem"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        /// <returns>The <see cref="ContactPoint"/>.</returns>
        public ContactPoint getContactPoint(ContactPoint.ContactPointSystem system, string value)
        {
            ContactPoint contactpoint = new ContactPoint();
            contactpoint.System = system;
            contactpoint.Value = value;

            return contactpoint;
        }

        /// <summary>
        /// The getName.
        /// </summary>
        /// <param name="given">The given<see cref="List{string}"/>.</param>
        /// <param name="use">The use<see cref="HumanName.NameUse"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <returns>The <see cref="HumanName"/>.</returns>
        public HumanName getName(List<string> given, HumanName.NameUse use, string text)
        {
            HumanName humanName = new HumanName();
            humanName.Given = given;
            humanName.Use = use;
            humanName.Text = text;

            return humanName;
        }

        /// <summary>
        /// The getIdentifierWithUse.
        /// </summary>
        /// <param name="systemUrl">The systemUrl<see cref="string"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        /// <param name="use">The use<see cref="Identifier.IdentifierUse"/>.</param>
        /// <returns>The <see cref="Identifier"/>.</returns>
        public Identifier getIdentifierWithUse(string systemUrl, string value, Identifier.IdentifierUse use)
        {
            Identifier identifier = new Identifier();
            identifier.System = systemUrl;
            identifier.Value = value;
            identifier.Use = use;

            return identifier;
        }

        /// <summary>
        /// The getCoding.
        /// </summary>
        /// <param name="systemUrl">The systemUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <returns>The <see cref="Coding"/>.</returns>
        public Coding getCoding(string systemUrl, string code)
        {
            Coding coding = new Coding();
            coding.System = systemUrl;
            coding.Code = code;

            return coding;
        }

        /// <summary>
        /// The getPatientIdentifier.
        /// </summary>
        /// <param name="identifierSytem">The identifierSytem<see cref="string"/>.</param>
        /// <param name="identifierValue">The identifierValue<see cref="string"/>.</param>
        /// <param name="identifierCodingSystem">The identifierCodingSystem<see cref="string"/>.</param>
        /// <param name="identifierCodingCode">The identifierCodingCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Identifier"/>.</returns>
        public Identifier getPatientIdentifier(string identifierSytem, string identifierValue, string identifierCodingSystem, string identifierCodingCode)
        {
            Identifier patientIdentifier = new Identifier();
            patientIdentifier.System = identifierSytem;
            patientIdentifier.Value = identifierValue;
            CodeableConcept patientIdentifierType = new CodeableConcept();
            Coding patientIdentifierTypeCoding = new Coding();
            patientIdentifierTypeCoding.System = identifierCodingSystem;
            patientIdentifierTypeCoding.Code = identifierCodingCode;
            patientIdentifierType.Coding = new List<Coding> { patientIdentifierTypeCoding };
            patientIdentifier.Type = patientIdentifierType;

            return patientIdentifier;
        }

        /// <summary>
        /// Defines the random.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// The RandomNumber.
        /// </summary>
        /// <param name="length">The length<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string RandomNumber(int length)
        {
            const string chars = "1234567890";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

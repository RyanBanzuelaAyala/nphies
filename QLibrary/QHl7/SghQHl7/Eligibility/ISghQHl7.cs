namespace QHl7
{
    using Hl7.Fhir.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ISghQHl7" />.
    /// </summary>
    public interface ISghQHl7
    {
        /// <summary>
        /// The getResource.
        /// </summary>
        /// <param name="Reference">The Reference<see cref="string"/>.</param>
        /// <returns>The <see cref="ResourceReference"/>.</returns>
        ResourceReference getResource(string Reference);

        /// <summary>
        /// The getMeta.
        /// </summary>
        /// <param name="profileURL">The profileURL<see cref="string"/>.</param>
        /// <returns>The <see cref="Meta"/>.</returns>
        Meta getMeta(string profileURL);

        /// <summary>
        /// The getCodeableConceptWithDisplay.
        /// </summary>
        /// <param name="systemmUrl">The systemmUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <param name="display">The display<see cref="string"/>.</param>
        /// <returns>The <see cref="CodeableConcept"/>.</returns>
        CodeableConcept getCodeableConceptWithDisplay(string systemmUrl, string code, string display);

        /// <summary>
        /// The getCodeableConcept.
        /// </summary>
        /// <param name="systemmUrl">The systemmUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <returns>The <see cref="CodeableConcept"/>.</returns>
        CodeableConcept getCodeableConcept(string systemmUrl, string code);

        /// <summary>
        /// The getCodeableConceptWithText.
        /// </summary>
        /// <param name="systemmUrl">The systemmUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <returns>The <see cref="CodeableConcept"/>.</returns>
        CodeableConcept getCodeableConceptWithText(string systemmUrl, string code, string text);

        /// <summary>
        /// The getIdentifier.
        /// </summary>
        /// <param name="systemUrl">The systemUrl<see cref="string"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        /// <returns>The <see cref="Identifier"/>.</returns>
        Identifier getIdentifier(string systemUrl, string value);

        /// <summary>
        /// The getPeriod.
        /// </summary>
        /// <param name="start">The start<see cref="string"/>.</param>
        /// <param name="end">The end<see cref="string"/>.</param>
        /// <returns>The <see cref="Period"/>.</returns>
        Period getPeriod(string start, string end);

        /// <summary>
        /// The getContactPoint.
        /// </summary>
        /// <param name="system">The system<see cref="ContactPoint.ContactPointSystem"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        /// <returns>The <see cref="ContactPoint"/>.</returns>
        ContactPoint getContactPoint(ContactPoint.ContactPointSystem system, string value);

        /// <summary>
        /// The getName.
        /// </summary>
        /// <param name="given">The given<see cref="List{string}"/>.</param>
        /// <param name="use">The use<see cref="HumanName.NameUse"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <returns>The <see cref="HumanName"/>.</returns>
        HumanName getName(List<string> given, HumanName.NameUse use, string text);

        /// <summary>
        /// The getIdentifierWithUse.
        /// </summary>
        /// <param name="systemUrl">The systemUrl<see cref="string"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        /// <param name="use">The use<see cref="Identifier.IdentifierUse"/>.</param>
        /// <returns>The <see cref="Identifier"/>.</returns>
        Identifier getIdentifierWithUse(string systemUrl, string value, Identifier.IdentifierUse use);

        /// <summary>
        /// The getCoding.
        /// </summary>
        /// <param name="systemUrl">The systemUrl<see cref="string"/>.</param>
        /// <param name="code">The code<see cref="string"/>.</param>
        /// <returns>The <see cref="Coding"/>.</returns>
        Coding getCoding(string systemUrl, string code);

        /// <summary>
        /// The getPatientIdentifier.
        /// </summary>
        /// <param name="identifierSytem">The identifierSytem<see cref="string"/>.</param>
        /// <param name="identifierValue">The identifierValue<see cref="string"/>.</param>
        /// <param name="identifierCodingSystem">The identifierCodingSystem<see cref="string"/>.</param>
        /// <param name="identifierCodingCode">The identifierCodingCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Identifier"/>.</returns>
        Identifier getPatientIdentifier(string identifierSytem, string identifierValue, string identifierCodingSystem, string identifierCodingCode);

        /// <summary>
        /// The RandomNumber.
        /// </summary>
        /// <param name="length">The length<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string RandomNumber(int length);
    }
}

using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QHl7
{
    public class SghQHl7PA : SghQHl7, ISghQHl7PA
    {
        public Identifier getPractitionerIdentifier(string identifierSytem, string identifierValue, string identifierCodingSystem, string identifierCodingCode)
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

        public Money getMoney(decimal? value, Money.Currencies currency)
        {
            Money money = new Money();
            money.Value = value;
            money.Currency = currency;

            return money;

        }

        public Quantity getQuantity(decimal? value)
        {
            Quantity quantity = new Quantity();
            quantity.Value = value;

            return quantity;

        }
    }
}

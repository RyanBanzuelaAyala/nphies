using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QHl7
{
    public interface ISghQHl7PA : ISghQHl7
    {
        Identifier getPractitionerIdentifier(string identifierSytem, string identifierValue, string identifierCodingSystem, string identifierCodingCode);
        Money getMoney(decimal? value, Money.Currencies currency);
        Quantity getQuantity(decimal? value);

    }
}

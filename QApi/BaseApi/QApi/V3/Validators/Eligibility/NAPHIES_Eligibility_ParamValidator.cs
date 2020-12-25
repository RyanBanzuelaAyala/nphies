using FluentValidation;
using QApi.V3.Model.Eligibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QApi.V3.Validators.Eligibility
{
    public class NAPHIES_Eligibility_ParamValidator : AbstractValidator<NAPHIES_Eligibility_ParamVM>
    {
        public NAPHIES_Eligibility_ParamValidator()
        {
            RuleFor(x => x.EligibilityID)
                .NotNull()
                .Empty()
                .WithMessage("The eligibility id must not be null or empty");

            RuleFor(x => x.Purpose)
               .Empty()
               .WithMessage("The purpose must not be empty");
        }
    }
}

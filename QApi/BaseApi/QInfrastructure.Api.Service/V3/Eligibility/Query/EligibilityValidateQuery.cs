using MediatR;
using QDomain.Model.Eligibility;
using QInfrastructure.Api.Service.V3.Eligibility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QInfrastructure.Api.Service.V3.Eligibility.Query
{
    public class EligibilityValidateQuery : IRequest<EligibilityValidateVM>
    {
        public NAPHIES_Eligibility_Param param { get; set; }
        public string BranchId { get; set; }

    } 
}

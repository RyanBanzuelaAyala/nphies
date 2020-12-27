using System;
using System.Collections.Generic;
using System.Text;

namespace QDomain.Response
{
    public class NAPHIES_Eligibility_Response
    {
        public string EligibilityID { get; set; }
        public string ReferenceID { get; set; } // Response Identifier ID
        public List<NAPHIES_Eligibility_Benefits> Benefits { get; set; }
        public string StatusCode { get; set; } // true / false
        public string StatusDescription { get; set; } // Description
    }
}

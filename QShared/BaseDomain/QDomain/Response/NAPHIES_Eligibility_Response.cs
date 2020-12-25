using System;
using System.Collections.Generic;
using System.Text;

namespace QDomain.Response
{
    public class NAPHIES_Eligibility_Response
    {
        public int EligibilityID { get; set; }
        public int ReferenceID { get; set; } // Response Identifier ID
        public List<NAPHIES_Eligibility_Benefits> Benefits { get; set; }
        public string StatusCode { get; set; } // true / false
        public string StatusDescription { get; set; } // Description
    }
}

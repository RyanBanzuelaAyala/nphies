using AG.Infra.Model.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace AG.Infra.Model.Vm
{
    public class CommonVm { 
        public int ReturnCode { get; set; }
        public string ReturnMsgs { get; set; }
    }

    public class AccountVm : CommonVm { 
        public Account AccountDetails { get; set; }
    }

    public class InsuranceAccountVm : CommonVm {
        public InsuranceAccount InsuranceAccountDetails { get; set; }
    }
}

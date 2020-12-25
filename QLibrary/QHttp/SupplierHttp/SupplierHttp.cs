using Microsoft.Extensions.Configuration;
using QHttp.HttpInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace QHttp.SupplierHttp
{
    public class SupplierHttp<T> : HttpApi<T>
    {
        public SupplierHttp(IConfiguration iconfig) : base(iconfig)
        {
            base.__url = "supplierUri";
        }
    }
}

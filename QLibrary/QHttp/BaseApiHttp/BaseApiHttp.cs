using Microsoft.Extensions.Configuration;
using QHttp.HttpInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace QHttp.BaseApiHttp
{
    public class BaseApiHttp<T> : HttpApi<T>
    {
        public BaseApiHttp(IConfiguration iconfig) : base(iconfig)
        {
            base.__url = "baseSapApiUri";
        }
    }
}

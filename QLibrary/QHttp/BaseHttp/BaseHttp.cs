using Microsoft.Extensions.Configuration;
using QHttp.HttpInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace QHttp.BaseHttp
{
    public class BaseHttp<T> : HttpApi<T>
    {   
        public BaseHttp(IConfiguration iconfig) : base(iconfig)
        {
            base.__url = "baseUri";
        }
    }
}

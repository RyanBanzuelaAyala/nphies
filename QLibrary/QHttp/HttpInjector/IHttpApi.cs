using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QHttp.HttpInjector
{
    public interface IHttpApi<T>
    {
        
        Task<T> Request(string Url, string Token);

        Task<T> Request(string Url, object keyValues, string Token);

        Task<T> RequestGet(string Url);

        Task<T> RequestGet(string Url, string Token);

        Task<T> RequestGet(string Url, object keyValues, string Token);

        Task<T> RequestPost(string Url, object keyValues);

        Task<T> RequestPost(string Url, object keyValues, string Token);
    }
}

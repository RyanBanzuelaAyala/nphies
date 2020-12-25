using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QHttp.HttpInjector
{
    public class HttpApi<T> : IHttpApi<T>
    {
        private readonly IConfiguration _iconfig;

        public string __url;

        public HttpApi(IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }

        public async Task<T> Request(List<KeyValuePair<string, string>> keyValues, string Url, string Token)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var request = new HttpRequestMessage(HttpMethod.Post, Url);

                request.Content = new FormUrlEncodedContent(keyValues);

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }


        public async Task<T> Request(string Url, object keyValues, string Token)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var request = new HttpRequestMessage(HttpMethod.Post, Url);

                request.Content = new StringContent(keyValues.ToString(), Encoding.UTF8, "application/json");

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }

        public async Task<T> Request(string Url, string Token)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var request = new HttpRequestMessage(HttpMethod.Get, Url);

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }

        public async Task<T> RequestGet(string Url)
        {
            try
            {
                var client = new HttpClient();

                var tt = _iconfig[__url];

                client.BaseAddress = new Uri(tt);
                
                var request = new HttpRequestMessage(HttpMethod.Get, Url);

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return JsonConvert.DeserializeObject<T>(null);
            }
        } 

        public async Task<T> RequestGet(string Url, string Token)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                
                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return JsonConvert.DeserializeObject<T>(null);
            }
        }
        
        public async Task<T> RequestGet(string Url, object keyValues, string Token)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var request = new HttpRequestMessage(HttpMethod.Get, Url);

                request.Content = new StringContent(keyValues.ToString(), Encoding.UTF8, "application/json");

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }

        public async Task<T> RequestPost(string Url, object keyValues)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);
                
                var request = new HttpRequestMessage(HttpMethod.Post, Url);

                request.Content = new StringContent(keyValues.ToString(), Encoding.UTF8, "application/json");

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }

        public async Task<T> RequestPost(string Url, object keyValues, string Token)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(_iconfig[__url]);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var request = new HttpRequestMessage(HttpMethod.Post, Url);

                request.Content = new StringContent(keyValues.ToString(), Encoding.UTF8, "application/json");

                var result = await client.SendAsync(request);

                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(null);
            }
        }
    }
}

namespace QInfrastructure.Api.Http.V3.Eligibility
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.IO;
    using global::System.Net;
    using Hl7.Fhir.Model;
    using Hl7.Fhir.Serialization;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Defines the <see cref="HttpEligibility" />.
    /// </summary>
    public class HttpEligibility : IHttpEligibility
    {
        /// <summary>
        /// Gets the config.
        /// </summary>
        private IConfiguration config { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpEligibility"/> class.
        /// </summary>
        public HttpEligibility(IConfiguration configuration)
        {
            config = configuration;
        }

        /// <summary>
        /// The _httpEligibility.
        /// </summary>
        /// <param name="requestJson">The requestJson<see cref="string"/>.</param>
        /// <returns>The <see cref="IAsyncResult"/>.</returns>
        public HttpWebResponse _httpEligibility(string requestJson)
        {
            var fhirSerialzer = new FhirJsonParser();
            Bundle resultBundle;
            bool? coverageInforce = false;
            List<string> errorCodes = new List<string>();
            List<string> errorMessages = new List<string>();

            HttpWebResponse httpResponse = null;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://sgw.s.nphies.sa/tmb/$process-message");
                httpWebRequest.ContentType = "application/fhir+json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                //httpWebRequest.Headers["username"] = config.GetSection("NphiesCredentials").GetSection("Nphies_UserName").Value;//"Provider";
                //httpWebRequest.Headers["password"] = config.GetSection("NphiesCredentials").GetSection("Nphies_Password").Value;//"P@ssw0rd";
                //httpWebRequest.Headers["Authorization"] = "Bearer " + config.GetSection("NphiesCredentials").GetSection("Nphies_Token").Value; ;

                httpWebRequest.Headers["username"] = config["Nphies_UserName"];//"Provider";
                httpWebRequest.Headers["password"] = config["Nphies_Password"];//"P@ssw0rd";
                httpWebRequest.Headers["Authorization"] = "Bearer " + config["Nphies_Token"]; ;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(requestJson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                return (HttpWebResponse)httpWebRequest.GetResponse();
                
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    return (HttpWebResponse)wex.Response;
                }

                return null;
            }
        }
    }
}

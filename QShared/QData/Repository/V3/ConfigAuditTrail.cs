namespace QData.Repository.V3
{
    using QData.Data;
    using QData.Repository.V3.Base;
    using QData.Repository.V3.Interface;
    using QDomain.Logging;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ConfigAuditTrail" />.
    /// </summary>
    public class ConfigAuditTrail : BaseBusiness, IConfigAuditTrail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigAuditTrail"/> class.
        /// </summary>
        /// <param name="factory">The factory<see cref="Func{AppsDbContext}"/>.</param>
        public ConfigAuditTrail(Func<AppsDbContext> factory) :
            base(factory)
        {
        }

        /// <summary>
        /// The LogRequestWrite.
        /// </summary>
        /// <param name="jsonRequest">The jsonRequest<see cref="string"/>.</param>
        /// <param name="bundle">The bundle<see cref="string"/>.</param>
        /// <param name="requestType">The requestType<see cref="string"/>.</param>
        /// <param name="StatusCode">The StatusCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> LogRequestWrite(string jsonRequest, string bundle, string requestType, string StatusCode)
        {

            try
            {
                using (var context = Factory.Invoke())
                {

                    var _logRequest = new LogRequest()
                    {
                        RequestParam = jsonRequest,
                        JsonRequestBundle = bundle,
                        RequestType = requestType,
                        RequestStampDateAndTime = DateTime.Now,
                        StatusCode = StatusCode
                    };

                    await context.LogRequest.AddAsync(_logRequest);
                    await context.SaveChangesAsync();

                    return _logRequest.Id;
                }


            }
            catch (Exception E)
            {
                return 0;
            }
        }

        /// <summary>
        /// The LogResponseWrite.
        /// </summary>
        /// <param name="jsonResponse">The jsonResponse<see cref="string"/>.</param>
        /// <param name="LogRequestId">The LogRequestId<see cref="int"/>.</param>
        /// <param name="StatusCode">The StatusCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> LogResponseWrite(string jsonResponse, int LogRequestId, string StatusCode)
        {

            try
            {
                using (var context = Factory.Invoke())
                {

                    var _logResponse = new LogResponse()
                    {
                        LogRequestId = LogRequestId,
                        JsonResponseBundle = jsonResponse,
                        ResponseStampDateAndTime = DateTime.Now,
                        StatusCode = StatusCode
                    };

                    await context.LogResponse.AddAsync(_logResponse);
                    await context.SaveChangesAsync();

                    return _logResponse.Id;
                }


            }
            catch (Exception E)
            {
                return 0;
            }
        }
    }
}

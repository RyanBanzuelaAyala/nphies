namespace QInfrastructure.Api.Log
{
    using QData.Repository.V3.Interface;
    using System.Threading.Tasks;

    public class AuditTrail : IAuditTrail
    {
        private readonly IConfigAuditTrail _log;

        public AuditTrail(IConfigAuditTrail log)
        {
            _log = log;
        }

        public async Task LogRequestWrite(string jsonRequest, string bundle, string requestType, string StatusCode)
        {
            await _log.LogRequestWrite(jsonRequest, bundle, requestType, StatusCode);
        }

        public async Task LogResponseWrite(string jsonResponse, int LogRequestId, string StatusCode)
        {
            await _log.LogResponseWrite(jsonResponse, LogRequestId, StatusCode);
        }
    }
}

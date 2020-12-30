namespace QInfrastructure.Api.Log
{
    using System.Threading.Tasks;

    public interface IAuditTrail
    {
        Task LogRequestWrite(string jsonRequest, string bundle, string requestType, string StatusCode);

        Task LogResponseWrite(string jsonResponse, int LogRequestId, string StatusCode);
    }
}

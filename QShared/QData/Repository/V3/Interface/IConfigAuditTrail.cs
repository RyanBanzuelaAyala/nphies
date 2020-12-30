namespace QData.Repository.V3.Interface
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IConfigAuditTrail" />.
    /// </summary>
    public interface IConfigAuditTrail
    {
        /// <summary>
        /// The LogRequestWrite.
        /// </summary>
        /// <param name="jsonRequest">The jsonRequest<see cref="string"/>.</param>
        /// <param name="bundle">The bundle<see cref="string"/>.</param>
        /// <param name="requestType">The requestType<see cref="string"/>.</param>
        /// <param name="StatusCode">The StatusCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> LogRequestWrite(string jsonRequest, string bundle, string requestType, string StatusCode);

        /// <summary>
        /// The LogResponseWrite.
        /// </summary>
        /// <param name="jsonResponse">The jsonResponse<see cref="string"/>.</param>
        /// <param name="LogRequestId">The LogRequestId<see cref="int"/>.</param>
        /// <param name="StatusCode">The StatusCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> LogResponseWrite(string jsonResponse, int LogRequestId, string StatusCode);
    }
}

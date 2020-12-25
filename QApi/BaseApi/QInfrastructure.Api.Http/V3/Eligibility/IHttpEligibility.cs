using System.Net;

namespace QInfrastructure.Api.Http.V3.Eligibility
{
    /// <summary>
    /// Defines the <see cref="IHttpEligibility" />.
    /// </summary>
    public interface IHttpEligibility
    {
        /// <summary>
        /// The _httpEligibility.
        /// </summary>
        /// <param name="requestJson">The requestJson<see cref="string"/>.</param>
        /// <returns>The <see cref="HttpWebResponse"/>.</returns>
        HttpWebResponse _httpEligibility(string requestJson);
    }
}

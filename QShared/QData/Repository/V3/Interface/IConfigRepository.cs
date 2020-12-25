namespace QData.Repository.V3.Interface
{
    using AG.Infra.Model.Params;
    using AG.Infra.Model.Vm;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IConfigRepository" />.
    /// </summary>
    public interface IConfigRepository
    {
        /// <summary>
        /// The GetAccount.
        /// </summary>
        /// <param name="BranchId">The BranchId<see cref="int"/>.</param>
        /// <param name="UserName">The UserName<see cref="string"/>.</param>
        /// <param name="Password">The Password<see cref="string"/>.</param>
        /// <param name="SecretKey">The SecretKey<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{AccountVm}"/>.</returns>
        Task<AccountVm> GetAccount(int BranchId, string UserName, string Password, string SecretKey);

        /// <summary>
        /// The GetInsuranceAccount.
        /// </summary>
        /// <param name="BranchId">The BranchId<see cref="int"/>.</param>
        /// <param name="InsuranceCode">The InsuranceCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{InsuranceAccountVm}"/>.</returns>
        Task<InsuranceAccountVm> GetInsuranceAccount(int BranchId, string InsuranceCode);

        /// <summary>
        /// The LogBUPARequest.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="request">The request<see cref="T"/>.</param>
        /// <param name="param">The param<see cref="BUPA_PH_OPRequestParam"/>.</param>
        /// <param name="requestType">The requestType<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> LogBUPARequest<T>(T request, BUPA_PH_OPRequestParam param, string requestType);

        /// <summary>
        /// The LogBUPAResponse.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="response">The response<see cref="T"/>.</param>
        /// <param name="requestId">The requestId<see cref="int"/>.</param>
        /// <param name="requestType">The requestType<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> LogBUPAResponse<T>(T response, int requestId, string requestType);
    }
}

namespace QData.Repository.V3
{
    using AG.Infra.Model.Params;
    using AG.Infra.Model.Tables;
    using AG.Infra.Model.Vm;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using QData.Data;
    using QData.Repository.V3.Base;
    using QData.Repository.V3.Interface;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ConfigBusiness" />.
    /// </summary>
    public class ConfigBusiness : BaseBusiness, IConfigRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigBusiness"/> class.
        /// </summary>
        /// <param name="factory">The factory<see cref="Func{AppsDbContext}"/>.</param>
        public ConfigBusiness(Func<AppsDbContext> factory) : base(factory)
        {
        }

        /// <summary>
        /// The GetAccount.
        /// </summary>
        /// <param name="BranchId">The BranchId<see cref="int"/>.</param>
        /// <param name="UserName">The UserName<see cref="string"/>.</param>
        /// <param name="Password">The Password<see cref="string"/>.</param>
        /// <param name="SecretKey">The SecretKey<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{AccountVm}"/>.</returns>
        public async Task<AccountVm> GetAccount(int BranchId, string UserName, string Password, string SecretKey)
        {

            var result = new AccountVm();
            try
            {
                using (var context = Factory.Invoke())
                {

                    var accountDetails = await context.Accounts
                        .Where(d =>
                            d.BranchId == BranchId
                            && d.UserName == UserName
                            && d.Password == Password
                        ).SingleOrDefaultAsync();


                    if (accountDetails != null)
                    {
                        result.AccountDetails = accountDetails ?? null;

                        if (accountDetails.SecretKey != SecretKey)
                        {
                            result.ReturnCode = 3;
                            result.ReturnMsgs = "Secret Key is Incorrect";
                        }
                        else
                        {
                            result.ReturnCode = 0;
                            result.ReturnMsgs = "Authorized";
                        }
                    }
                    else
                    {
                        result.AccountDetails = null;
                        result.ReturnCode = 2;
                        result.ReturnMsgs = "Usename and/or Password is Incorrect.";
                    }
                    return result;
                }


            }
            catch (Exception E)
            {
                result.AccountDetails = null;
                result.ReturnCode = 99;
                result.ReturnMsgs = "Opps Unexpected Error Occured Please contact Support.";
                return result;
            }
        }

        /// <summary>
        /// The GetInsuranceAccount.
        /// </summary>
        /// <param name="BranchId">The BranchId<see cref="int"/>.</param>
        /// <param name="InsuranceCode">The InsuranceCode<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{InsuranceAccountVm}"/>.</returns>
        public async Task<InsuranceAccountVm> GetInsuranceAccount(int BranchId, string InsuranceCode)
        {
            var result = new InsuranceAccountVm();
            try
            {
                using (var context = Factory.Invoke())
                {

                    var insuranceDetails = await context.InsuranceAccounts
                        .Include(d => d.InsuranceServiceMaster)
                        .Include(d => d.DepartmentMappingProfileId)
                        .Where(d =>
                            d.BranchId == BranchId &&
                            d.InsuranceCode == InsuranceCode
                        ).SingleOrDefaultAsync();


                    //if (insuranceDetails != null)
                    //{
                    //    result.InsuranceAccountDetails = insuranceDetails ?? null;

                    //    if (accountDetails.SecretKey != SecretKey)
                    //    {
                    //        result.ReturnCode = 3;
                    //        result.ReturnMsgs = "Secret Key is Incorrect";
                    //    }
                    //    else
                    //    {
                    //        result.ReturnCode = 0;
                    //        result.ReturnMsgs = "Authorized";
                    //    }
                    //}
                    //else
                    //{
                    //    result.AccountDetails = null;
                    //    result.ReturnCode = 2;
                    //    result.ReturnMsgs = "Usename and/or Password is Incorrect.";
                    //}
                    return result;
                }


            }
            catch (Exception E)
            {
                result.InsuranceAccountDetails = null;
                result.ReturnCode = 99;
                result.ReturnMsgs = "Opps Unexpected Error Occured Please contact Support.";
                return result;
            }
        }

        /// <summary>
        /// The LogBUPARequest.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="request">The request<see cref="T"/>.</param>
        /// <param name="param">The param<see cref="BUPA_PH_OPRequestParam"/>.</param>
        /// <param name="requestType">The requestType<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> LogBUPARequest<T>(T request, BUPA_PH_OPRequestParam param, string requestType)
        {

            try
            {
                using (var context = Factory.Invoke())
                {

                    var _logEntry = new BUPARequestLog()
                    {
                        OPRequestId = param.OPRequestId,
                        MemberId = param.MemberId,
                        MemberName = param.MemberName,
                        MembershipNo = param.MembershipNo,
                        PatientFileNo = param.PatientFileNo,
                        PreAuthId = param.PreAuthId,
                        RequestBody = JsonConvert.SerializeObject(request),
                        ReSubmit = param.ReSubmit,
                        TreatmentType = param.TreatmentType,
                        CreatedAt = DateTime.Now,
                        RequestType = requestType

                    };

                    await context.BUPARequestLogs.AddAsync(_logEntry);
                    await context.SaveChangesAsync();

                    return _logEntry.Id;
                }


            }
            catch (Exception E)
            {
                return 0;
            }
        }

        /// <summary>
        /// The LogBUPAResponse.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="response">The response<see cref="T"/>.</param>
        /// <param name="requestId">The requestId<see cref="int"/>.</param>
        /// <param name="requestType">The requestType<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> LogBUPAResponse<T>(T response, int requestId, string requestType)
        {

            try
            {
                using (var context = Factory.Invoke())
                {

                    var _logEntry = new BUPAResponseLog()
                    {
                        RequestLogId = requestId,
                        ResponseBody = JsonConvert.SerializeObject(response),
                        CreatedAt = DateTime.Now,
                        RequestType = requestType

                    };

                    await context.BUPAResponseLogs.AddAsync(_logEntry);
                    await context.SaveChangesAsync();

                    return _logEntry.Id;
                }


            }
            catch (Exception E)
            {
                return 0;
            }
        }
    }
}

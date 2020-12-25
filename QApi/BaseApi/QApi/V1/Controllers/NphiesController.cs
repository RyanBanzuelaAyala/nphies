using Microsoft.AspNetCore.Mvc;
using QApi.V1.Models;
using QBase.Controller;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QApi.V1.Controllers
{
    /// <summary>
    /// Sample versioning REST API
    /// </summary>
    [ApiVersion("1.0")]
    public class NphiesController : QBaseController
    {
        /// <summary>
        /// I
        /// </summary>
        /// <returns>Collection of ProductModel instances</returns>
        [HttpGet]
        public async Task<IEnumerable<NphiesModelv1>> Get()
        {
            return await Task.FromResult<IEnumerable<NphiesModelv1>>(new List<NphiesModelv1>()
            {
                new NphiesModelv1()
                {
                    Id= Guid.Parse("6fab57fb-0c61-4552-9490-9161c2466e62")
                },
                new NphiesModelv1()
                {
                    Id= Guid.Parse("6648eb0f-0e54-4f6a-93a1-2825e3c8fc9d")
                }
            }.ToArray());
        }
    }
}
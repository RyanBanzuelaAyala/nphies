using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QInfrastructure.Api.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace QBase.Controller
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QBaseController : ControllerBase
    {        
    }
}

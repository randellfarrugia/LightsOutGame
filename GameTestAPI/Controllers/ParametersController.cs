using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ParametersController : ControllerBase
    {

        protected ParametersBL parametersBL;
        public ParametersController()
        {
            parametersBL = new ParametersBL();
        }

        [HttpGet]
        public IActionResult GetDefaultParams()
        {
            return CreateResponse(parametersBL.GetDefaultParams());
        }

        protected virtual IActionResult CreateResponse(Object response)
        {
            if (response == null) return new BadRequestResult();
            return new OkObjectResult(response);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace UpworkTask.Controllers.API
{
    /// <summary>
    /// Used to define a base API controller
    /// </summary>
    [Route("api/{controller}")]
    public class BaseApiController : ApiController
    {
    }
}
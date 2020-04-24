using $ext_safeprojectname$.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace $safeprojectname$.Controllers.Api
{
    [Route("api/$ext_supersafename$")]
    public class $ext_supersafename$Controller : Controller
    {
        // GET: api/$ext_supersafename$
        /// <summary>
        /// Get message
        /// </summary>
        /// <remarks>Return "Hello world!" message</remarks>
        [HttpGet]
        [Route("")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public ActionResult<string> Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}

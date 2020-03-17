using $ext_safeprojectname$.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace $safeprojectname$.Controllers.Api
{
    [RoutePrefix("api/$ext_supersafename$")]
    public class $ext_supersafename$Controller : ApiController
    {
        // GET: api/$ext_supersafename$
        [HttpGet]
        [Route("")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public ActionResult<string> Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}

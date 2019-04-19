using System.Web.Http;

namespace $safeprojectname$.Controllers.Api
{
    [RoutePrefix("api/$safeprojectname$")]
    public class MyModuleController : ApiController
    {
        // GET: api/managedModule
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}

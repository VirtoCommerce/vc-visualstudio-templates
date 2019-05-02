using System.Web.Http;

namespace $safeprojectname$.Controllers.Api
{
    [RoutePrefix("api/$ext_supersafename$")]
    public class $ext_supersafename$Controller : ApiController
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

using System.Web.Http;

namespace $safeprojectname$.Controllers.Api
{
    [RoutePrefix("api/$ext_supersafename$")]
    public class $ext_supersafename$Controller : ApiController
    {
        // GET: api/$ext_supersafename$
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}

using System.Web.Http;

namespace Module.Web.Controllers.Api
{
    [RoutePrefix("api/Module.Web")]
    public class ManagedModuleController : ApiController
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

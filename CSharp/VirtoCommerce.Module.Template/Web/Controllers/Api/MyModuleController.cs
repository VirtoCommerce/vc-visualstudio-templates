using System.Web.Http;
using $ext_safeprojectname$.Core;
using VirtoCommerce.Platform.Core.Web.Security;

namespace $safeprojectname$.Controllers.Api
{
    [RoutePrefix("api/$ext_supersafename$")]
    public class $ext_supersafename$Controller : ApiController
    {
        // GET: api/$ext_supersafename$
        [HttpGet]
        [Route("")]
        [CheckPermission(Permission = ModuleConstants.Security.Permissions.Read)]
        public IHttpActionResult Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}

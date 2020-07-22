using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Picassa.IDP.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HomeController : ControllerBase
    {
        [Authorize]
        public ActionResult Get()
        {
            return Ok("tests!");
        }
    }
}

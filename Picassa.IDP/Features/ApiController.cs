namespace Picassa.IDP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
    }
}

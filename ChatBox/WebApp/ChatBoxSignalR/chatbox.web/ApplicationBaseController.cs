using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chatbox.web
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationBaseController : ControllerBase
    {

    }
}

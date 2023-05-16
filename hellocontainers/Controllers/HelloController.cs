using hellocontainers.Models;
using Microsoft.AspNetCore.Mvc;

namespace hellocontainers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult<HelloResponse> GetResult(string? echo)
        {
            return MessagePrinter.PrintResponse(HttpContext, echo, nameof(HelloController));
        }

    }
}

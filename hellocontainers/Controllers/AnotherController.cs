using hellocontainers.Models;
using Microsoft.AspNetCore.Mvc;

namespace hellocontainers.Controllers
{
    [ApiController]
    [Route("/")]
    public class AnotherController : ControllerBase
    {
        [HttpGet]
        public ActionResult<HelloResponse> GetResult(string? echo)
        {
            return MessagePrinter.PrintResponse(HttpContext, echo, nameof(AnotherController));
        }

        [HttpGet("inner")]
        public ActionResult<HelloResponse> GetResultInner(string? echo)
        {
            return MessagePrinter.PrintResponse(HttpContext, echo, nameof(AnotherController));
        }
    }
}

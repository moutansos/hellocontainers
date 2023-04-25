using hellocontainers.Models;
using Microsoft.AspNetCore.Mvc;

namespace hellocontainers.Controllers
{
    [ApiController]
    public class AnotherController : ControllerBase
    {
        [HttpGet("/")]
        public ActionResult<HelloResponse> GetResult(string? echo)
        {
            return new HelloResponse(Message, YouSaid: echo ?? "Nothing");
        }
        private string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
    }
}

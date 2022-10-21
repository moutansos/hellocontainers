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
            return new HelloResponse(Message, YouSaid: echo ?? "Nothing");
        }

        [HttpPost]
        public ActionResult<HelloResponse> PostResult([FromBody]HelloRequest request)
        {
            return new HelloResponse(Message, YouSaid: request.Echo ?? "Nothing");
        }

        private string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
    }
}

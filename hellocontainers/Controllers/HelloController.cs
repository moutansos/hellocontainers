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
            var queryParams = HttpContext.Request.QueryString.ToString();

            return new HelloResponse(Message, YouSaid: echo ?? "Nothing", Controller: nameof(AnotherController), QueryParams: queryParams);
        }

        private string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
    }
}

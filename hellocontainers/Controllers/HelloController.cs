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
            var requestScheme = HttpContext.Request.Scheme;
            var isHttps = HttpContext.Request.IsHttps;
            var print = $"{Message}, requestScheme: {requestScheme}; isHttps: {isHttps}";
            var queryParams = HttpContext.Request.QueryString.ToString();

            return new HelloResponse(print, YouSaid: echo ?? "Nothing", Controller: nameof(HelloController), QueryParams: queryParams);
        }

        private string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
    }
}

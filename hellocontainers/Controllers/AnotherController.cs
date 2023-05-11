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
            var requestScheme = HttpContext.Request.Scheme;
            var isHttps = HttpContext.Request.IsHttps;
            var print = $"{Message}, requestScheme: {requestScheme}; isHttps: {isHttps}";
        
            var queryParams = HttpContext.Request.QueryString.ToString();

            return new HelloResponse(print, YouSaid: echo ?? "Nothing", Controller: $"{nameof(AnotherController)}, GetResult", QueryParams: queryParams);
        }

        [HttpGet("inner")]
        public ActionResult<HelloResponse> GetResultInner(string? echo)
        {
            var requestScheme = HttpContext.Request.Scheme;
            var isHttps = HttpContext.Request.IsHttps;
            var print = $"{Message}, requestScheme: {requestScheme}; isHttps: {isHttps}";
            var queryParams = HttpContext.Request.QueryString.ToString();

            return new HelloResponse(print, YouSaid: echo ?? "Nothing", Controller: $"{nameof(AnotherController)}, GetResultInner", QueryParams: queryParams);
        }


        private string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
    }
}

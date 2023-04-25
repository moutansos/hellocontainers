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
            var queryParams = HttpContext.Request.QueryString.ToString();

            return new HelloResponse(Message, YouSaid: echo ?? "Nothing", Controller: $"{nameof(AnotherController)}, GetResult", QueryParams: queryParams);
        }

        [HttpGet("inner")]
        public ActionResult<HelloResponse> GetResultInner(string? echo)
        {
            var queryParams = HttpContext.Request.QueryString.ToString();

            return new HelloResponse(Message, YouSaid: echo ?? "Nothing", Controller: $"{nameof(AnotherController)}, GetResultInner", QueryParams: queryParams);
        }


        private string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
    }
}

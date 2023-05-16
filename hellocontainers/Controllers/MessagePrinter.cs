using hellocontainers.Models;
using Microsoft.AspNetCore.Http.Features;

namespace hellocontainers.Controllers;

public static class MessagePrinter
{
    public static HelloResponse PrintResponse(HttpContext httpContext, string? echo, string controllerName)
    {
        var requestScheme = httpContext.Request.Scheme;
        var isHttps = httpContext.Request.IsHttps;
        var requestFeature = httpContext.Features.Get<IHttpRequestFeature>();
        var print = $"{Message}, requestScheme: {requestScheme}; isHttps: {isHttps}, Path: {requestFeature?.Path}, PathBase: {requestFeature?.PathBase}, RawTarget: {requestFeature?.RawTarget}";
        var queryParams = httpContext.Request.QueryString.ToString();

        return new HelloResponse(print, YouSaid: echo ?? "Nothing", Controller: controllerName, QueryParams: queryParams);
    }

    private static string Message => Environment.GetEnvironmentVariable("HELLOCONTAINERS_MESSAGE") ?? "No Message Set!";
}

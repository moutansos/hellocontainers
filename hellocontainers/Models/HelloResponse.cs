namespace hellocontainers.Models
{
    public record HelloResponse(string Message,
                                string YouSaid,
                                string Controller,
                                string QueryParams);
}
